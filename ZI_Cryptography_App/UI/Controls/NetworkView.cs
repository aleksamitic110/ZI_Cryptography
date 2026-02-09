using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;
using ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;
using ZI_Cryptography.ZI_Cryptography_App.Services.Networking;

namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	public partial class NetworkView : UserControl
	{
		private readonly ICryptoService _cryptoService;
		private readonly FileSender _fileSender;

		private string _selectedFilePath = string.Empty;
		private FileReceiver? _fileReceiver;
		private CancellationTokenSource? _receiverCts;
		private Task? _receiverTask;

		public NetworkView()
		{
			InitializeComponent();
			_cryptoService = new EncryptionService();
			_fileSender = new FileSender();
			txtTargetPort.Text = "9000";
			txtListenPort.Text = "9000";
			lblLocalIps.Text = $"Local IPv4: {GetLocalIpv4List()}";
		}

		private async void btnSend_Click(object sender, EventArgs e)
		{
			if (!ValidateSendInputs(out int port))
			{
				return;
			}

			btnSend.Enabled = false;
			try
			{
				string encryptedPath = _selectedFilePath;
				if (!encryptedPath.EndsWith(".locked", StringComparison.OrdinalIgnoreCase))
				{
					CryptoAlgorithmType algorithm = GetSelectedSendAlgorithm();
					string algoLabel = GetAlgorithmLabel(algorithm);
					AppendLog($"Encrypting selected file before send (Algorithm: {algoLabel})...");
					var derivation = CryptoInteropSettings.Get();
					encryptedPath = await Task.Run(() =>
						_cryptoService.EncryptFile(_selectedFilePath, null, txtSendPassword.Text, algorithm, derivation));
					AppendLog($"Encrypted file created: {encryptedPath}");
				}

				AppendLog($"Sending file to {txtTargetIp.Text}:{port} ...");
				await _fileSender.SendEncryptedFileAsync(encryptedPath, txtTargetIp.Text.Trim(), port);
				AppendLog("Send completed.");
				ActivityLogService.Add("Network", $"Sent {Path.GetFileName(encryptedPath)} to {txtTargetIp.Text}:{port}", LogSeverity.Success);
			}
			catch (Exception ex)
			{
				AppendLog($"Send failed: {ex.Message}");
				ActivityLogService.Add("Network", ex.Message, LogSeverity.Error);
				MessageBox.Show(ex.Message, "Send Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				btnSend.Enabled = true;
			}
		}

		private async void btnStartStopReceiver_Click(object sender, EventArgs e)
		{
			if (_receiverCts != null)
			{
				await StopReceiverAsync();
				return;
			}

			if (!int.TryParse(txtListenPort.Text, out int port) || port < 1 || port > 65535)
			{
				MessageBox.Show("Enter a valid listen port (1-65535).", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(txtReceivePassword.Text))
			{
				MessageBox.Show("Enter shared receive password.", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			_receiverCts = new CancellationTokenSource();
			var pathOptions = OutputPathSettings.Get();
			_fileReceiver = new FileReceiver(
				_cryptoService,
				txtReceivePassword.Text.Trim(),
				derivationOptions: CryptoInteropSettings.Get(),
				encryptedOutputFolder: pathOptions.EncryptedFilesFolder,
				decryptedOutputFolder: pathOptions.DecryptedFilesFolder);
			_fileReceiver.FileReceivedAndVerified += FileReceiver_FileReceivedAndVerified;
			_fileReceiver.ReceiveFailed += FileReceiver_ReceiveFailed;

			btnStartStopReceiver.Text = "Stop Listening";
			txtListenPort.Enabled = false;
			txtReceivePassword.Enabled = false;

			AppendLog($"Receiver started on port {port}.");
			AppendLog($"Incoming encrypted folder: {pathOptions.EncryptedFilesFolder}");
			AppendLog($"Incoming decrypted folder: {pathOptions.DecryptedFilesFolder}");
			ActivityLogService.Add("Network", $"Receiver started on port {port}", LogSeverity.Info);
			_receiverTask = _fileReceiver.StartAsync(port, _receiverCts.Token);

			try
			{
				await _receiverTask;
			}
			catch (Exception ex)
			{
				AppendLog($"Receiver stopped with error: {ex.Message}");
				ActivityLogService.Add("Network", ex.Message, LogSeverity.Error);
			}
			finally
			{
				CleanupReceiver();
			}
		}

		private void btnBrowseFile_Click(object sender, EventArgs e)
		{
			using var dialog = new OpenFileDialog
			{
				Filter = "All files (*.*)|*.*"
			};

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_selectedFilePath = dialog.FileName;
				txtSelectedFile.Text = _selectedFilePath;
				ActivityLogService.Add("Network", $"Selected file {Path.GetFileName(_selectedFilePath)}", LogSeverity.Info);
			}
		}

		private void FileReceiver_FileReceivedAndVerified(object? sender, FileReceivedEventArgs e)
		{
			AppendLog($"Received: {Path.GetFileName(e.EncryptedPath)}");
			AppendLog($"Verified + decrypted: {e.DecryptedPath}");
			ActivityLogService.Add("Network", $"Received and verified {Path.GetFileName(e.EncryptedPath)}", LogSeverity.Success);
		}

		private void FileReceiver_ReceiveFailed(object? sender, string message)
		{
			AppendLog($"Receive failed: {message}");
			ActivityLogService.Add("Network", message, LogSeverity.Error);
		}

		private bool ValidateSendInputs(out int port)
		{
			port = 0;
			if (string.IsNullOrWhiteSpace(_selectedFilePath) || !File.Exists(_selectedFilePath))
			{
				MessageBox.Show("Select a file to send.", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (string.IsNullOrWhiteSpace(txtTargetIp.Text))
			{
				MessageBox.Show("Enter receiver IP address.", "Missing IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!IPAddress.TryParse(txtTargetIp.Text.Trim(), out _))
			{
				MessageBox.Show("Receiver IP address is invalid.", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!int.TryParse(txtTargetPort.Text, out port) || port < 1 || port > 65535)
			{
				MessageBox.Show("Enter a valid target port (1-65535).", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!_selectedFilePath.EndsWith(".locked", StringComparison.OrdinalIgnoreCase))
			{
				if (string.IsNullOrWhiteSpace(txtSendPassword.Text))
				{
					MessageBox.Show("Send password is required when sending an unencrypted file.", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}

				if (GetSelectedSendAlgorithm() == CryptoAlgorithmType.Playfair &&
					!_selectedFilePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
				{
					MessageBox.Show("Playfair supports only .txt files.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
			}

			return true;
		}

		private async Task StopReceiverAsync()
		{
			if (_receiverCts == null)
			{
				return;
			}

			_receiverCts.Cancel();
			if (_receiverTask != null)
			{
				try
				{
					await _receiverTask;
				}
				catch
				{
					// Receiver task canceled.
				}
			}

			CleanupReceiver();
			AppendLog("Receiver stopped.");
			ActivityLogService.Add("Network", "Receiver stopped", LogSeverity.Warning);
		}

		private void CleanupReceiver()
		{
			if (_fileReceiver != null)
			{
				_fileReceiver.FileReceivedAndVerified -= FileReceiver_FileReceivedAndVerified;
				_fileReceiver.ReceiveFailed -= FileReceiver_ReceiveFailed;
			}

			_receiverCts?.Dispose();
			_receiverCts = null;
			_receiverTask = null;
			_fileReceiver = null;

			btnStartStopReceiver.Text = "Start Listening";
			txtListenPort.Enabled = true;
			txtReceivePassword.Enabled = true;
		}

		private void AppendLog(string message)
		{
			if (IsDisposed || !IsHandleCreated)
			{
				return;
			}

			if (InvokeRequired)
			{
				BeginInvoke(new Action(() => AppendLog(message)));
				return;
			}

			lstNetworkLogs.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {message}");
		}

		private static string GetLocalIpv4List()
		{
			var ips = NetworkInterface
				.GetAllNetworkInterfaces()
				.Where(x => x.OperationalStatus == OperationalStatus.Up &&
							x.NetworkInterfaceType != NetworkInterfaceType.Loopback)
				.SelectMany(x => x.GetIPProperties().UnicastAddresses)
				.Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork)
				.Select(x => x.Address.ToString())
				.Distinct()
				.ToList();

			return ips.Count == 0 ? "Not found" : string.Join(", ", ips);
		}

		private CryptoAlgorithmType GetSelectedSendAlgorithm()
		{
			if (rbSendPlayfair.Checked) return CryptoAlgorithmType.Playfair;
			if (rbSendPcbcOnly.Checked) return CryptoAlgorithmType.PCBC;
			if (rbSendRc6Only.Checked) return CryptoAlgorithmType.RC6;
			return CryptoAlgorithmType.RC6_PCBC;
		}

		private static string GetAlgorithmLabel(CryptoAlgorithmType algorithm)
		{
			return algorithm switch
			{
				CryptoAlgorithmType.Playfair => "Playfair",
				CryptoAlgorithmType.RC6 => "RC6",
				CryptoAlgorithmType.PCBC => "PCBC",
				_ => "RC6 + PCBC"
			};
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			StopReceiverAsync().GetAwaiter().GetResult();
			base.OnHandleDestroyed(e);
		}

	}
}
