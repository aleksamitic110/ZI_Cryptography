using System;
using System.Buffers;
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
		RC6,
		PCBC,
		Playfair
	}

	public class EncryptionService : ICryptoService
	{
		private const int IoBufferSize = 8192;
		private const int HashSize = 20;
		private const string PlayfairAlgorithmName = "Playfair";
		private const string Rc6PcbcAlgorithmName = "RC6-PCBC";
		private const string Rc6AlgorithmName = "RC6";
		private const string PcbcAlgorithmName = "PCBC";

		private readonly IMetadataManager _metadataManager;
		private readonly IHasher _hasher;

		public EncryptionService()
		{
			_metadataManager = new MetadataManager();
			_hasher = new Sha1Hasher();
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

			string destinationDir = string.IsNullOrWhiteSpace(outputFolder)
				? OutputPathSettings.Get().EncryptedFilesFolder
				: outputFolder;
			Directory.CreateDirectory(destinationDir);
			string outputPath = Path.Combine(destinationDir, $"{Path.GetFileName(inputFilePath)}.locked");

			var metadata = new FileMetadata
			{
				OriginalFileName = Path.GetFileName(inputFilePath),
				FileSize = new FileInfo(inputFilePath).Length,
				CreationTime = File.GetCreationTime(inputFilePath),
				EncryptionAlgorithm = GetMetadataAlgorithmName(algoType),
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

			using var output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, IoBufferSize);
			byte[] headerBytes = _metadataManager.CreateHeaderBytes(metadata);
			output.Write(headerBytes, 0, headerBytes.Length);
			output.Write(hashBytes, 0, hashBytes.Length);

			switch (algoType)
			{
				case CryptoAlgorithmType.Playfair:
					EncryptPlayfairText(playfairNormalized ?? string.Empty, output, password);
					break;
				case CryptoAlgorithmType.RC6_PCBC:
				{
					byte[] key = DeriveKeyFromPassword(password, derivationOptions);
					using var input = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, IoBufferSize);
					EncryptRc6PcbcStream(input, output, key);
					break;
				}
				case CryptoAlgorithmType.RC6:
				{
					byte[] key = DeriveKeyFromPassword(password, derivationOptions);
					using var input = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, IoBufferSize);
					EncryptRc6Stream(input, output, key);
					break;
				}
				case CryptoAlgorithmType.PCBC:
				{
					byte[] key = DeriveKeyFromPassword(password, derivationOptions);
					using var input = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, IoBufferSize);
					EncryptPcbcStream(input, output, key);
					break;
				}
				default:
					throw new NotSupportedException($"Unsupported encryption algorithm: {algoType}");
			}

			return outputPath;
		}

		public string DecryptFile(string encryptedFilePath, string? outputFolder, string password, PasswordDerivationOptions? derivationOptions = null)
		{
			if (!File.Exists(encryptedFilePath)) throw new FileNotFoundException("File not found", encryptedFilePath);
			if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty.", nameof(password));

			string destinationDir = string.IsNullOrWhiteSpace(outputFolder)
				? OutputPathSettings.Get().DecryptedFilesFolder
				: outputFolder;
			Directory.CreateDirectory(destinationDir);

			using var input = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, IoBufferSize);
			FileMetadata metadata = _metadataManager.ReadHeader(input);

			byte[] expectedHash = ReadExact(input, HashSize);
			string outputPath = Path.Combine(destinationDir, $"Decrypted_{metadata.OriginalFileName}");
			string algorithmName = metadata.EncryptionAlgorithm?.Trim() ?? string.Empty;

			switch (algorithmName)
			{
				case PlayfairAlgorithmName:
					DecryptPlayfair(input, outputPath, password);
					break;
				case Rc6PcbcAlgorithmName:
				case "RC6 + PCBC":
				{
					byte[] key = DeriveKeyFromPassword(password, derivationOptions);
					using var output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, IoBufferSize);
					DecryptRc6PcbcStream(input, output, key);
					break;
				}
				case Rc6AlgorithmName:
				{
					byte[] key = DeriveKeyFromPassword(password, derivationOptions);
					using var output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, IoBufferSize);
					DecryptRc6Stream(input, output, key);
					break;
				}
				case PcbcAlgorithmName:
				{
					byte[] key = DeriveKeyFromPassword(password, derivationOptions);
					using var output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, IoBufferSize);
					DecryptPcbcStream(input, output, key);
					break;
				}
				default:
					throw new NotSupportedException($"Unknown encryption algorithm: {metadata.EncryptionAlgorithm}");
			}

			using var outputHashStream = File.OpenRead(outputPath);
			byte[] currentHash = _hasher.ComputeHash(outputHashStream, IoBufferSize);
			if (!AreEqual(expectedHash, currentHash))
			{
				File.Delete(outputPath);
				ActivityLogService.Add("Integrity", $"SHA-1 verification failed for {metadata.OriginalFileName}", LogSeverity.Error);
				throw new Exception("INTEGRITY CHECK FAILED! File corrupted or wrong password.");
			}

			ActivityLogService.Add("Integrity", $"SHA-1 verified for {metadata.OriginalFileName}", LogSeverity.Success);

			return outputPath;
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
				throw new Exception("Invalid padding or wrong password.");
			}

			for (int i = 1; i <= padLen; i++)
			{
				if (finalPlainPadded[^i] != padLen)
				{
					throw new Exception("Invalid padding or wrong password.");
				}
			}

			output.Write(finalPlainPadded, 0, blockSize - padLen);
		}

		private void EncryptRc6Stream(Stream input, Stream output, byte[] key)
		{
			var rc6 = new RC6Cipher();
			int blockSize = rc6.BlockSize;
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
						byte[] cipherBlock = rc6.EncryptBlock(plainBlock, key);
						output.Write(cipherBlock, 0, cipherBlock.Length);
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

				byte[] paddedCipher = rc6.EncryptBlock(lastBlock, key);
				output.Write(paddedCipher, 0, paddedCipher.Length);
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(ioBuffer);
				ArrayPool<byte>.Shared.Return(pending);
			}
		}

		private void DecryptRc6Stream(Stream input, Stream output, byte[] key)
		{
			var rc6 = new RC6Cipher();
			int blockSize = rc6.BlockSize;
			long remainingCipherBytes = input.Length - input.Position;
			if (remainingCipherBytes <= 0 || remainingCipherBytes % blockSize != 0)
			{
				throw new Exception("Invalid encrypted payload size.");
			}

			byte[] currentCipher = ReadExact(input, blockSize);
			while (input.Position < input.Length)
			{
				byte[] nextCipher = ReadExact(input, blockSize);
				byte[] plain = rc6.DecryptBlock(currentCipher, key);
				output.Write(plain, 0, plain.Length);
				currentCipher = nextCipher;
			}

			byte[] finalPlainPadded = rc6.DecryptBlock(currentCipher, key);
			int padLen = GetAndValidatePadding(finalPlainPadded, blockSize);
			output.Write(finalPlainPadded, 0, blockSize - padLen);
		}

		private void EncryptPcbcStream(Stream input, Stream output, byte[] key)
		{
			const int blockSize = 16;
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
						byte[] cipherBlock = XorWithKey(inputBlock, key);
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
				byte[] paddedCipher = XorWithKey(paddedInput, key);
				output.Write(paddedCipher, 0, paddedCipher.Length);
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(ioBuffer);
				ArrayPool<byte>.Shared.Return(pending);
			}
		}

		private void DecryptPcbcStream(Stream input, Stream output, byte[] key)
		{
			const int blockSize = 16;
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
				byte[] decrypted = XorWithKey(currentCipher, key);
				byte[] plain = XorBlocks(decrypted, prevPlain, prevCipher);
				output.Write(plain, 0, plain.Length);
				prevPlain = plain;
				prevCipher = (byte[])currentCipher.Clone();
				Buffer.BlockCopy(nextCipher, 0, currentCipher, 0, blockSize);
			}

			byte[] finalDecrypted = XorWithKey(currentCipher, key);
			byte[] finalPlainPadded = XorBlocks(finalDecrypted, prevPlain, prevCipher);
			int padLen = GetAndValidatePadding(finalPlainPadded, blockSize);
			output.Write(finalPlainPadded, 0, blockSize - padLen);
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
			var cfg = options?.Clone() ?? CryptoInteropSettings.Get();
			if (cfg.AutoMode)
			{
				cfg.UseUtf8Encoding = true;
				cfg.UseManualPasswordBytes = false;
				cfg.PasswordBytesForSha1 = 0;
				cfg.Rc6KeyBytes = 16;
			}

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

			using var ms = new MemoryStream(passwordBytes, writable: false);
			byte[] hash = _hasher.ComputeHash(ms);
			int keyLength = Math.Clamp(cfg.Rc6KeyBytes, 4, hash.Length);
			byte[] key = new byte[keyLength];
			Buffer.BlockCopy(hash, 0, key, 0, key.Length);
			return key;
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

		private static string GetMetadataAlgorithmName(CryptoAlgorithmType algorithm)
		{
			return algorithm switch
			{
				CryptoAlgorithmType.Playfair => PlayfairAlgorithmName,
				CryptoAlgorithmType.RC6 => Rc6AlgorithmName,
				CryptoAlgorithmType.PCBC => PcbcAlgorithmName,
				_ => Rc6PcbcAlgorithmName
			};
		}

		private static int GetAndValidatePadding(byte[] paddedBlock, int blockSize)
		{
			int padLen = paddedBlock[^1];
			if (padLen < 1 || padLen > blockSize)
			{
				throw new Exception("Invalid padding or wrong password.");
			}

			for (int i = 1; i <= padLen; i++)
			{
				if (paddedBlock[^i] != padLen)
				{
					throw new Exception("Invalid padding or wrong password.");
				}
			}

			return padLen;
		}

		private static byte[] XorWithKey(byte[] input, byte[] key)
		{
			byte[] output = new byte[input.Length];
			for (int i = 0; i < input.Length; i++)
			{
				output[i] = (byte)(input[i] ^ key[i % key.Length]);
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
