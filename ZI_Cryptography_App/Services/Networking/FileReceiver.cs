using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;

namespace ZI_Cryptography.ZI_Cryptography_App.Services.Networking
{
	public class FileReceivedEventArgs : EventArgs
	{
		public string EncryptedPath { get; init; } = string.Empty;
		public string DecryptedPath { get; init; } = string.Empty;
		public string Message { get; init; } = string.Empty;
	}

	public class FileReceiver
	{
		private const int BufferSize = 8192;
		private readonly ICryptoService _encryptionService;
		private readonly string _downloadsEncryptedDir;
		private readonly string _downloadsDecryptedDir;
		private readonly string _decryptionPassword;
		private readonly Services.Cryptography.PasswordDerivationOptions? _derivationOptions;

		public event EventHandler<FileReceivedEventArgs>? FileReceivedAndVerified;
		public event EventHandler<string>? ReceiveFailed;

		public FileReceiver(ICryptoService encryptionService, string decryptionPassword, string baseDownloadsPath = "", Services.Cryptography.PasswordDerivationOptions? derivationOptions = null)
		{
			_encryptionService = encryptionService;
			_decryptionPassword = decryptionPassword;
			_derivationOptions = derivationOptions?.Clone();

			string root = string.IsNullOrWhiteSpace(baseDownloadsPath)
				? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads")
				: baseDownloadsPath;

			_downloadsEncryptedDir = Path.Combine(root, "Encrypted");
			_downloadsDecryptedDir = Path.Combine(root, "Decrypted");

			Directory.CreateDirectory(_downloadsEncryptedDir);
			Directory.CreateDirectory(_downloadsDecryptedDir);
		}

		public async Task StartAsync(int port, CancellationToken cancellationToken = default)
		{
			var listener = new TcpListener(IPAddress.Any, port);
			listener.Start();

			try
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					TcpClient client = await listener.AcceptTcpClientAsync(cancellationToken);
					_ = Task.Run(() => HandleClientAsync(client, cancellationToken), cancellationToken);
				}
			}
			catch (OperationCanceledException)
			{
				// Listener stopped.
			}
			finally
			{
				listener.Stop();
			}
		}

		private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
		{
			using (client)
			{
				try
				{
					await using NetworkStream stream = client.GetStream();

					int fileNameLen = BitConverter.ToInt32(await ReadExactAsync(stream, sizeof(int), cancellationToken), 0);
					string fileName = Encoding.UTF8.GetString(await ReadExactAsync(stream, fileNameLen, cancellationToken));
					long fileSize = BitConverter.ToInt64(await ReadExactAsync(stream, sizeof(long), cancellationToken), 0);

					string safeName = Path.GetFileName(fileName);
					string encryptedPath = Path.Combine(_downloadsEncryptedDir, safeName);
					encryptedPath = GetUniquePath(encryptedPath);

					await using (var fileStream = new FileStream(encryptedPath, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, useAsync: true))
					{
						await CopyExactAsync(stream, fileStream, fileSize, cancellationToken);
					}

					string decryptedPath = _encryptionService.DecryptFile(encryptedPath, _downloadsDecryptedDir, _decryptionPassword, _derivationOptions);
					FileReceivedAndVerified?.Invoke(this, new FileReceivedEventArgs
					{
						EncryptedPath = encryptedPath,
						DecryptedPath = decryptedPath,
						Message = "File received, integrity verified, and decrypted."
					});
				}
				catch (Exception ex)
				{
					ReceiveFailed?.Invoke(this, ex.Message);
				}
			}
		}

		private static async Task<byte[]> ReadExactAsync(Stream stream, int count, CancellationToken cancellationToken)
		{
			byte[] buffer = new byte[count];
			int offset = 0;
			while (offset < count)
			{
				int read = await stream.ReadAsync(buffer.AsMemory(offset, count - offset), cancellationToken);
				if (read <= 0) throw new EndOfStreamException("Connection closed before all expected bytes were received.");
				offset += read;
			}
			return buffer;
		}

		private static async Task CopyExactAsync(Stream input, Stream output, long bytesToCopy, CancellationToken cancellationToken)
		{
			byte[] buffer = new byte[BufferSize];
			long remaining = bytesToCopy;
			while (remaining > 0)
			{
				int read = await input.ReadAsync(buffer.AsMemory(0, (int)Math.Min(buffer.Length, remaining)), cancellationToken);
				if (read <= 0) throw new EndOfStreamException("Connection closed before full file was received.");
				await output.WriteAsync(buffer.AsMemory(0, read), cancellationToken);
				remaining -= read;
			}
		}

		private static string GetUniquePath(string path)
		{
			if (!File.Exists(path)) return path;

			string directory = Path.GetDirectoryName(path) ?? string.Empty;
			string fileName = Path.GetFileNameWithoutExtension(path);
			string extension = Path.GetExtension(path);
			int index = 1;

			while (true)
			{
				string candidate = Path.Combine(directory, $"{fileName}_{index}{extension}");
				if (!File.Exists(candidate)) return candidate;
				index++;
			}
		}
	}
}
