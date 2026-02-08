using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ZI_Cryptography.ZI_Cryptography_App.Core.Hashing;
using ZI_Cryptography.ZI_Cryptography_App.Models;

namespace ZI_Cryptography.ZI_Cryptography_App.Services.Networking
{
	public class FileSender
	{
		private const int MaxHeaderSize = 1024 * 1024;
		private const int BufferSize = 8192;

		public async Task SendEncryptedFileAsync(string encryptedFilePath, string receiverIp, int receiverPort, CancellationToken cancellationToken = default)
		{
			if (!File.Exists(encryptedFilePath))
			{
				throw new FileNotFoundException("Encrypted file not found.", encryptedFilePath);
			}

			using var tcpClient = new TcpClient();
			await tcpClient.ConnectAsync(receiverIp, receiverPort, cancellationToken);
			await using NetworkStream networkStream = tcpClient.GetStream();

			FileInfo fileInfo = new FileInfo(encryptedFilePath);
			var header = new FileMetadata
			{
				OriginalFileName = fileInfo.Name,
				FileSize = fileInfo.Length,
				CreationTime = fileInfo.CreationTimeUtc,
				EncryptionAlgorithm = "NETWORK-TRANSFER",
				HashAlgorithm = "SHA-1",
				Hash = ComputeFileHashHex(encryptedFilePath)
			};

			byte[] headerBytes = JsonSerializer.SerializeToUtf8Bytes(header);
			if (headerBytes.Length <= 0 || headerBytes.Length > MaxHeaderSize)
			{
				throw new InvalidDataException("Network header size is out of allowed bounds.");
			}

			byte[] headerLengthBytes = BitConverter.GetBytes(headerBytes.Length);

			await networkStream.WriteAsync(headerLengthBytes, cancellationToken);
			await networkStream.WriteAsync(headerBytes, cancellationToken);

			byte[] buffer = new byte[BufferSize];
			await using var input = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, useAsync: true);
			while (true)
			{
				int read = await input.ReadAsync(buffer, cancellationToken);
				if (read <= 0) break;
				await networkStream.WriteAsync(buffer.AsMemory(0, read), cancellationToken);
			}

			await networkStream.FlushAsync(cancellationToken);
		}

		private static string ComputeFileHashHex(string filePath)
		{
			var hasher = new Sha1Hasher();
			using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize);
			byte[] hashBytes = hasher.ComputeHash(stream, BufferSize);
			return Convert.ToHexString(hashBytes);
		}
	}
}
