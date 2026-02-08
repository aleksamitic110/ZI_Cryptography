using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ZI_Cryptography.ZI_Cryptography_App.Core.Algorithms;
using ZI_Cryptography.ZI_Cryptography_App.Core.Hashing;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;
using ZI_Cryptography.ZI_Cryptography_App.Models;
using ZI_Cryptography.ZI_Cryptography_App.Services.FileSystem;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;

namespace ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography
{
	public enum CryptoAlgorithmType
	{
		RC6_PCBC,
		Playfair
	}

	public class EncryptionService : ICryptoService
	{
		private const int IoBufferSize = 8192;
		private const int HashSize = 20;

		private readonly IMetadataManager _metadataManager;
		private readonly IHasher _hasher;
		private readonly string _storageDirectory;

		public EncryptionService()
		{
			_metadataManager = new MetadataManager();
			_hasher = new Sha1Hasher();
			_storageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CryptoStorage");
			Directory.CreateDirectory(_storageDirectory);
		}

		public string EncryptFile(string inputFilePath, string? outputFolder, string password)
		{
			return EncryptFile(inputFilePath, outputFolder, password, CryptoAlgorithmType.RC6_PCBC, null);
		}

		public string EncryptFile(string inputFilePath, string? outputFolder, string password, PasswordDerivationOptions? derivationOptions = null)
		{
			return EncryptFile(inputFilePath, outputFolder, password, CryptoAlgorithmType.RC6_PCBC, derivationOptions);
		}

		public string EncryptFile(string inputFilePath, string? outputFolder, string password, CryptoAlgorithmType algoType, PasswordDerivationOptions? derivationOptions = null)
		{
			if (!File.Exists(inputFilePath)) throw new FileNotFoundException("File not found", inputFilePath);
			if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty.", nameof(password));

			string destinationDir = string.IsNullOrWhiteSpace(outputFolder) ? _storageDirectory : outputFolder;
			Directory.CreateDirectory(destinationDir);
			string outputPath = Path.Combine(destinationDir, $"{Path.GetFileName(inputFilePath)}.locked");

			var metadata = new FileMetadata
			{
				OriginalFileName = Path.GetFileName(inputFilePath),
				FileSize = new FileInfo(inputFilePath).Length,
				CreationTime = File.GetCreationTime(inputFilePath),
				EncryptionAlgorithm = algoType == CryptoAlgorithmType.Playfair ? "Playfair" : "RC6-PCBC",
				HashAlgorithm = _hasher.Name
			};

			byte[] hashBytes;
			string? playfairNormalized = null;
			if (algoType == CryptoAlgorithmType.Playfair)
			{
				string extension = Path.GetExtension(inputFilePath).ToLowerInvariant();
				if (extension != ".txt")
				{
					throw new InvalidOperationException("Playfair supports only .txt files.");
				}

				string plainText = File.ReadAllText(inputFilePath, Encoding.UTF8);
				var playfair = new PlayfairCipher();
				playfairNormalized = playfair.NormalizePlaintext(plainText);
				byte[] normalizedBytes = Encoding.UTF8.GetBytes(playfairNormalized);
				hashBytes = _hasher.ComputeHash(normalizedBytes);
			}
			else
			{
				using var inputHashStream = File.OpenRead(inputFilePath);
				hashBytes = _hasher.ComputeHash(inputHashStream, IoBufferSize);
			}
			metadata.Hash = Convert.ToHexString(hashBytes);

			using var output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, IoBufferSize);
			byte[] headerBytes = _metadataManager.CreateHeaderBytes(metadata);
			output.Write(headerBytes, 0, headerBytes.Length);
			output.Write(hashBytes, 0, hashBytes.Length);

			if (algoType == CryptoAlgorithmType.Playfair)
			{
				EncryptPlayfairText(playfairNormalized ?? string.Empty, output, password);
			}
			else
			{
				byte[] key = DeriveKeyFromPassword(password, derivationOptions);
				using var input = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, IoBufferSize);
				EncryptRc6PcbcStream(input, output, key);
			}

			return outputPath;
		}

		public string DecryptFile(string encryptedFilePath, string? outputFolder, string password, PasswordDerivationOptions? derivationOptions = null)
		{
			if (!File.Exists(encryptedFilePath)) throw new FileNotFoundException("File not found", encryptedFilePath);
			if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty.", nameof(password));

			string destinationDir = string.IsNullOrWhiteSpace(outputFolder) ? _storageDirectory : outputFolder;
			Directory.CreateDirectory(destinationDir);

			using var input = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, IoBufferSize);
			FileMetadata metadata = _metadataManager.ReadHeader(input);
			string algorithm = NormalizeEncryptionAlgorithm(metadata.EncryptionAlgorithm);

			byte[] expectedHash = ResolveExpectedHash(metadata, algorithm, input);
			string outputPath = Path.Combine(destinationDir, $"Decrypted_{metadata.OriginalFileName}");

			if (algorithm == "PLAYFAIR")
			{
				DecryptPlayfair(input, outputPath, password);

				if (!IsOutputHashValid(outputPath, expectedHash))
				{
					TryDeleteFile(outputPath);
					ActivityLogService.Add("Integrity", $"SHA-1 verification failed for {metadata.OriginalFileName}", LogSeverity.Error);
					throw new Exception("INTEGRITY CHECK FAILED! File corrupted, wrong password, or incompatible interoperability settings.");
				}

				ActivityLogService.Add("Integrity", $"SHA-1 verified for {metadata.OriginalFileName}", LogSeverity.Success);
				return outputPath;
			}
			else if (algorithm == "RC6-PCBC")
			{
				DecryptRc6WithCompatibleKeys(input, outputPath, password, derivationOptions, metadata, expectedHash);
				ActivityLogService.Add("Integrity", $"SHA-1 verified for {metadata.OriginalFileName}", LogSeverity.Success);
				return outputPath;
			}
			else
			{
				throw new NotSupportedException($"Unknown encryption algorithm: {metadata.EncryptionAlgorithm}");
			}
		}

		private static string NormalizeEncryptionAlgorithm(string? algorithm)
		{
			if (string.IsNullOrWhiteSpace(algorithm))
			{
				return string.Empty;
			}

			return algorithm.Trim().Replace('_', '-').ToUpperInvariant();
		}

		private static byte[] ResolveExpectedHash(FileMetadata metadata, string algorithm, Stream input)
		{
			if (algorithm == "RC6-PCBC")
			{
				long bytesAfterHeader = input.Length - input.Position;
				bool looksLikeWithPrefixedHash = IsRc6PayloadLayout(bytesAfterHeader - HashSize);
				bool looksLikeWithoutPrefixedHash = IsRc6PayloadLayout(bytesAfterHeader);

				if (!looksLikeWithPrefixedHash && looksLikeWithoutPrefixedHash)
				{
					byte[]? metadataHash = TryParseHex(metadata.Hash);
					if (metadataHash == null || metadataHash.Length != HashSize)
					{
						throw new Exception("Missing or invalid SHA-1 hash in metadata.");
					}

					return metadataHash;
				}
			}

			return ReadExact(input, HashSize);
		}

		private static bool IsRc6PayloadLayout(long totalPayloadBytes)
		{
			const int blockSize = 16;
			return totalPayloadBytes >= blockSize * 2 && (totalPayloadBytes - blockSize) % blockSize == 0;
		}

		private static byte[]? TryParseHex(string? hex)
		{
			if (string.IsNullOrWhiteSpace(hex))
			{
				return null;
			}

			string normalized = hex.Trim().Replace("-", string.Empty).Replace(" ", string.Empty);
			if (normalized.Length % 2 != 0)
			{
				return null;
			}

			try
			{
				return Convert.FromHexString(normalized);
			}
			catch
			{
				return null;
			}
		}

		private static bool IsPaddingException(Exception ex)
		{
			return ex.Message.IndexOf("Invalid padding", StringComparison.OrdinalIgnoreCase) >= 0;
		}

		private void DecryptRc6WithCompatibleKeys(
			Stream input,
			string outputPath,
			string password,
			PasswordDerivationOptions? derivationOptions,
			FileMetadata metadata,
			byte[] expectedHash)
		{
			if (!input.CanSeek)
			{
				throw new NotSupportedException("RC6 decryption requires a seekable input stream.");
			}

			long payloadStart = input.Position;
			string lastError = "INTEGRITY CHECK FAILED! File corrupted, wrong password, or incompatible interoperability settings.";

			foreach (byte[] key in BuildRc6KeyCandidates(password, derivationOptions))
			{
				if (!TryDecryptRc6WithKey(input, payloadStart, outputPath, key, metadata.FileSize, out string? decryptError))
				{
					if (!string.IsNullOrWhiteSpace(decryptError))
					{
						lastError = decryptError;
					}

					continue;
				}

				if (IsOutputHashValid(outputPath, expectedHash))
				{
					return;
				}

				TryDeleteFile(outputPath);
			}

			ActivityLogService.Add("Integrity", $"SHA-1 verification failed for {metadata.OriginalFileName}", LogSeverity.Error);
			throw new Exception(lastError);
		}

		private bool TryDecryptRc6WithKey(
			Stream input,
			long payloadStart,
			string outputPath,
			byte[] key,
			long expectedPlainSize,
			out string? error)
		{
			error = null;

			try
			{
				input.Position = payloadStart;

				using var output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, IoBufferSize);
				try
				{
					DecryptRc6PcbcStream(input, output, key);
				}
				catch (Exception ex) when (IsPaddingException(ex))
				{
					output.SetLength(0);
					output.Position = 0;
					input.Position = payloadStart;
					DecryptRc6PcbcStreamUsingFileSize(input, output, key, expectedPlainSize);
				}

				return true;
			}
			catch (Exception ex)
			{
				TryDeleteFile(outputPath);
				error = ex.Message;
				return false;
			}
		}

		private bool IsOutputHashValid(string outputPath, byte[] expectedHash)
		{
			if (!File.Exists(outputPath))
			{
				return false;
			}

			using var outputHashStream = File.OpenRead(outputPath);
			byte[] currentHash = _hasher.ComputeHash(outputHashStream, IoBufferSize);
			return AreEqual(expectedHash, currentHash);
		}

		private void EncryptRc6PcbcStream(Stream input, Stream output, byte[] key)
		{
			var rc6 = new RC6Cipher();
			int blockSize = rc6.BlockSize;
			byte[] iv = new byte[blockSize];
			RandomNumberGenerator.Fill(iv);
			output.Write(iv, 0, iv.Length);

			byte[] prevPlain = (byte[])iv.Clone();
			byte[] prevCipher = (byte[])iv.Clone();
			byte[] ioBuffer = ArrayPool<byte>.Shared.Rent(IoBufferSize);
			byte[] pending = ArrayPool<byte>.Shared.Rent(blockSize * 2);
			int pendingLen = 0;

			try
			{
				while (true)
				{
					int read = input.Read(ioBuffer, 0, IoBufferSize);
					if (read <= 0) break;

					EnsurePendingCapacity(ref pending, pendingLen + read);
					Buffer.BlockCopy(ioBuffer, 0, pending, pendingLen, read);
					pendingLen += read;

					int processLen = pendingLen - (pendingLen % blockSize);
					for (int offset = 0; offset < processLen; offset += blockSize)
					{
						byte[] plainBlock = new byte[blockSize];
						Buffer.BlockCopy(pending, offset, plainBlock, 0, blockSize);
						byte[] inputBlock = XorBlocks(plainBlock, prevPlain, prevCipher);
						byte[] cipherBlock = rc6.EncryptBlock(inputBlock, key);
						output.Write(cipherBlock, 0, cipherBlock.Length);
						prevPlain = plainBlock;
						prevCipher = cipherBlock;
					}

					int remaining = pendingLen - processLen;
					if (remaining > 0)
					{
						Buffer.BlockCopy(pending, processLen, pending, 0, remaining);
					}

					pendingLen = remaining;
				}

				int padLen = blockSize - (pendingLen % blockSize);
				if (padLen == 0) padLen = blockSize;

				byte[] lastBlock = new byte[blockSize];
				if (pendingLen > 0)
				{
					Buffer.BlockCopy(pending, 0, lastBlock, 0, pendingLen);
				}

				for (int i = pendingLen; i < blockSize; i++)
				{
					lastBlock[i] = (byte)padLen;
				}

				byte[] paddedInput = XorBlocks(lastBlock, prevPlain, prevCipher);
				byte[] paddedCipher = rc6.EncryptBlock(paddedInput, key);
				output.Write(paddedCipher, 0, paddedCipher.Length);
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(ioBuffer);
				ArrayPool<byte>.Shared.Return(pending);
			}
		}

		private void DecryptRc6PcbcStream(Stream input, Stream output, byte[] key)
		{
			var rc6 = new RC6Cipher();
			int blockSize = rc6.BlockSize;
			byte[] iv = ReadExact(input, blockSize);
			byte[] prevPlain = (byte[])iv.Clone();
			byte[] prevCipher = (byte[])iv.Clone();

			long remainingCipherBytes = input.Length - input.Position;
			if (remainingCipherBytes <= 0 || remainingCipherBytes % blockSize != 0)
			{
				throw new Exception("Invalid encrypted payload size.");
			}

			byte[] currentCipher = new byte[blockSize];
			byte[] nextCipher = new byte[blockSize];

			ReadFully(input, currentCipher, blockSize);
			while (input.Position < input.Length)
			{
				ReadFully(input, nextCipher, blockSize);
				byte[] decrypted = rc6.DecryptBlock(currentCipher, key);
				byte[] plain = XorBlocks(decrypted, prevPlain, prevCipher);
				output.Write(plain, 0, plain.Length);
				prevPlain = plain;
				prevCipher = (byte[])currentCipher.Clone();
				Buffer.BlockCopy(nextCipher, 0, currentCipher, 0, blockSize);
			}

			byte[] finalDecrypted = rc6.DecryptBlock(currentCipher, key);
			byte[] finalPlainPadded = XorBlocks(finalDecrypted, prevPlain, prevCipher);
			int padLen = finalPlainPadded[^1];
			if (padLen < 1 || padLen > blockSize)
			{
				throw new Exception("Invalid padding: wrong password or incompatible interoperability settings.");
			}

			for (int i = 1; i <= padLen; i++)
			{
				if (finalPlainPadded[^i] != padLen)
				{
					throw new Exception("Invalid padding: wrong password or incompatible interoperability settings.");
				}
			}

			output.Write(finalPlainPadded, 0, blockSize - padLen);
		}

		private void DecryptRc6PcbcStreamUsingFileSize(Stream input, Stream output, byte[] key, long expectedPlainSize)
		{
			if (expectedPlainSize < 0)
			{
				throw new Exception("Invalid original file size in metadata.");
			}

			var rc6 = new RC6Cipher();
			int blockSize = rc6.BlockSize;
			byte[] iv = ReadExact(input, blockSize);
			byte[] prevPlain = (byte[])iv.Clone();
			byte[] prevCipher = (byte[])iv.Clone();

			long remainingCipherBytes = input.Length - input.Position;
			if (remainingCipherBytes <= 0 || remainingCipherBytes % blockSize != 0)
			{
				throw new Exception("Invalid encrypted payload size.");
			}

			if (expectedPlainSize > remainingCipherBytes)
			{
				throw new Exception("Invalid metadata file size for encrypted payload.");
			}

			byte[] currentCipher = new byte[blockSize];
			byte[] nextCipher = new byte[blockSize];
			long written = 0;

			ReadFully(input, currentCipher, blockSize);
			while (input.Position < input.Length)
			{
				ReadFully(input, nextCipher, blockSize);
				byte[] decrypted = rc6.DecryptBlock(currentCipher, key);
				byte[] plain = XorBlocks(decrypted, prevPlain, prevCipher);
				WriteTrimmed(output, plain, expectedPlainSize, ref written);
				prevPlain = plain;
				prevCipher = (byte[])currentCipher.Clone();
				Buffer.BlockCopy(nextCipher, 0, currentCipher, 0, blockSize);
			}

			byte[] finalDecrypted = rc6.DecryptBlock(currentCipher, key);
			byte[] finalPlain = XorBlocks(finalDecrypted, prevPlain, prevCipher);
			WriteTrimmed(output, finalPlain, expectedPlainSize, ref written);

			if (written != expectedPlainSize)
			{
				throw new Exception("Invalid metadata file size for decrypted output.");
			}
		}

		private static void WriteTrimmed(Stream output, byte[] block, long expectedSize, ref long written)
		{
			long remaining = expectedSize - written;
			if (remaining <= 0) return;

			int count = (int)Math.Min(block.Length, remaining);
			output.Write(block, 0, count);
			written += count;
		}

		private static void TryDeleteFile(string path)
		{
			try
			{
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
			catch
			{
				// Best effort cleanup after failed integrity verification.
			}
		}

		private void EncryptPlayfairText(string plainText, Stream output, string password)
		{
			var playfair = new PlayfairCipher();
			string cipher = playfair.Encrypt(plainText, password);
			byte[] cipherBytes = Encoding.UTF8.GetBytes(cipher);
			output.Write(cipherBytes, 0, cipherBytes.Length);
		}

		private void DecryptPlayfair(Stream input, string outputPath, string password)
		{
			string cipherText;
			using (var reader = new StreamReader(input, Encoding.UTF8, true, IoBufferSize, leaveOpen: true))
			{
				cipherText = reader.ReadToEnd();
			}

			var playfair = new PlayfairCipher();
			string plainText = playfair.Decrypt(cipherText, password);
			using var writer = new StreamWriter(outputPath, false, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), IoBufferSize);
			writer.Write(plainText);
		}

		private byte[] DeriveKeyFromPassword(string password, PasswordDerivationOptions? options)
		{
			PasswordDerivationOptions cfg = NormalizeDerivationOptions(options);
			byte[] passwordBytes = GetPasswordBytes(password, cfg);
			return DeriveLegacySha1Key(passwordBytes, cfg.Rc6KeyBytes);
		}

		private IEnumerable<byte[]> BuildRc6KeyCandidates(string password, PasswordDerivationOptions? options)
		{
			PasswordDerivationOptions cfg = NormalizeDerivationOptions(options);
			byte[] passwordBytes = GetPasswordBytes(password, cfg);
			int configuredKeyLength = Math.Clamp(cfg.Rc6KeyBytes, 4, 64);

			var keys = new List<byte[]>();
			var seen = new HashSet<string>(StringComparer.Ordinal);

			void Add(byte[] key)
			{
				string fingerprint = Convert.ToHexString(key);
				if (seen.Add(fingerprint))
				{
					keys.Add(key);
				}
			}

			// Local default derivation used by this app.
			Add(DeriveLegacySha1Key(passwordBytes, configuredKeyLength));

			// Interop derivation used by some students: SHA1(password || counter) expansion.
			Add(DeriveCounterSha1Key(passwordBytes, configuredKeyLength));
			if (configuredKeyLength != 32)
			{
				Add(DeriveCounterSha1Key(passwordBytes, 32));
			}

			if (configuredKeyLength != 16)
			{
				Add(DeriveCounterSha1Key(passwordBytes, 16));
			}

			if (configuredKeyLength != 20)
			{
				Add(DeriveCounterSha1Key(passwordBytes, 20));
			}

			return keys;
		}

		private static PasswordDerivationOptions NormalizeDerivationOptions(PasswordDerivationOptions? options)
		{
			var cfg = options?.Clone() ?? CryptoInteropSettings.Get();
			if (cfg.AutoMode)
			{
				cfg.UseUtf8Encoding = true;
				cfg.UseManualPasswordBytes = false;
				cfg.PasswordBytesForSha1 = 0;
				cfg.Rc6KeyBytes = 16;
			}

			return cfg;
		}

		private static byte[] GetPasswordBytes(string password, PasswordDerivationOptions cfg)
		{
			byte[] passwordBytes;
			if (cfg.UseManualPasswordBytes && !string.IsNullOrWhiteSpace(cfg.ManualPasswordBytesHex))
			{
				passwordBytes = ParseHex(cfg.ManualPasswordBytesHex);
			}
			else
			{
				Encoding encoding = cfg.UseUtf8Encoding ? Encoding.UTF8 : Encoding.ASCII;
				passwordBytes = encoding.GetBytes(password);
			}

			if (cfg.PasswordBytesForSha1 > 0 && cfg.PasswordBytesForSha1 < passwordBytes.Length)
			{
				byte[] limited = new byte[cfg.PasswordBytesForSha1];
				Buffer.BlockCopy(passwordBytes, 0, limited, 0, limited.Length);
				passwordBytes = limited;
			}

			return passwordBytes;
		}

		private byte[] DeriveLegacySha1Key(byte[] passwordBytes, int requestedKeyLength)
		{
			using var ms = new MemoryStream(passwordBytes, writable: false);
			byte[] hash = _hasher.ComputeHash(ms);
			int keyLength = Math.Clamp(requestedKeyLength, 4, hash.Length);
			byte[] key = new byte[keyLength];
			Buffer.BlockCopy(hash, 0, key, 0, key.Length);
			return key;
		}

		private byte[] DeriveCounterSha1Key(byte[] passwordBytes, int requestedKeyLength)
		{
			int keyLength = Math.Clamp(requestedKeyLength, 4, 64);
			byte[] derived = new byte[keyLength];

			int offset = 0;
			int counter = 0;

			while (offset < keyLength)
			{
				byte[] toHash = new byte[passwordBytes.Length + sizeof(int)];
				Buffer.BlockCopy(passwordBytes, 0, toHash, 0, passwordBytes.Length);
				Buffer.BlockCopy(BitConverter.GetBytes(counter), 0, toHash, passwordBytes.Length, sizeof(int));

				byte[] hash = _hasher.ComputeHash(toHash);
				int toCopy = Math.Min(hash.Length, keyLength - offset);
				Buffer.BlockCopy(hash, 0, derived, offset, toCopy);
				offset += toCopy;
				counter++;
			}

			return derived;
		}

		private static byte[] ParseHex(string hex)
		{
			string value = hex.Replace(" ", string.Empty).Replace("-", string.Empty);
			if (value.Length % 2 != 0)
			{
				throw new ArgumentException("Manual password bytes must be valid hex (even number of characters).");
			}

			byte[] output = new byte[value.Length / 2];
			for (int i = 0; i < output.Length; i++)
			{
				output[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
			}

			return output;
		}

		private static byte[] XorBlocks(byte[] a, byte[] b, byte[] c)
		{
			byte[] result = new byte[a.Length];
			for (int i = 0; i < a.Length; i++)
			{
				result[i] = (byte)(a[i] ^ b[i] ^ c[i]);
			}

			return result;
		}

		private static bool AreEqual(byte[] left, byte[] right)
		{
			if (left.Length != right.Length) return false;
			int diff = 0;
			for (int i = 0; i < left.Length; i++)
			{
				diff |= left[i] ^ right[i];
			}

			return diff == 0;
		}

		private static byte[] ReadExact(Stream stream, int count)
		{
			byte[] buffer = new byte[count];
			ReadFully(stream, buffer, count);
			return buffer;
		}

		private static void ReadFully(Stream stream, byte[] buffer, int count)
		{
			int offset = 0;
			while (offset < count)
			{
				int read = stream.Read(buffer, offset, count - offset);
				if (read <= 0)
				{
					throw new EndOfStreamException("Unexpected end of stream.");
				}

				offset += read;
			}
		}

		private static void EnsurePendingCapacity(ref byte[] buffer, int requiredLength)
		{
			if (requiredLength <= buffer.Length) return;
			byte[] replacement = ArrayPool<byte>.Shared.Rent(Math.Max(requiredLength, buffer.Length * 2));
			Buffer.BlockCopy(buffer, 0, replacement, 0, buffer.Length);
			ArrayPool<byte>.Shared.Return(buffer);
			buffer = replacement;
		}
	}
}
