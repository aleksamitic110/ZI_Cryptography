using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZI_Cryptography.ZI_Cryptography_App.Services.Networking
{
	public class FileSender
	{
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
			byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileInfo.Name);
			byte[] fileNameLenBytes = BitConverter.GetBytes(fileNameBytes.Length);
			byte[] fileSizeBytes = BitConverter.GetBytes(fileInfo.Length);

			await networkStream.WriteAsync(fileNameLenBytes, cancellationToken);
			await networkStream.WriteAsync(fileNameBytes, cancellationToken);
			await networkStream.WriteAsync(fileSizeBytes, cancellationToken);

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
	}
}
