using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;
using ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography;
using ZI_Cryptography.ZI_Cryptography_App.Services.FileSystem;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;

namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	public partial class DashboardView : UserControl
	{
		private readonly IFileWatcherService _fileWatcher;
		private readonly ICryptoService _cryptoService;

		private DateTime _lastProcessTime = DateTime.MinValue;
		private string _lastProcessedFile = string.Empty;
		private string _currentSessionPassword = string.Empty;

		public string SelectedPath { get; private set; } = string.Empty;

		public DashboardView()
		{
			InitializeComponent();
			_fileWatcher = new FileWatcherService();
			_cryptoService = new EncryptionService();
			_fileWatcher.FileDetected += OnFileDetected;
		}

		private void OnFileDetected(string filePath)
		{
			if (Path.GetExtension(filePath).Equals(".locked", StringComparison.OrdinalIgnoreCase)) return;
			if (!File.Exists(filePath)) return;
			if (filePath == _lastProcessedFile && (DateTime.Now - _lastProcessTime).TotalSeconds < 2) return;

			if (GetSelectedAutoAlgorithm() == CryptoAlgorithmType.Playfair &&
				!filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
			{
				AppendDashboardLog($"Skipped (Playfair supports only .txt): {Path.GetFileName(filePath)}");
				ActivityLogService.Add("FSW", $"Skipped non-txt file for Playfair: {Path.GetFileName(filePath)}", LogSeverity.Warning);
				return;
			}

			_lastProcessedFile = filePath;
			_lastProcessTime = DateTime.Now;

			AppendDashboardLog($"Detected file: {Path.GetFileName(filePath)}");
			ActivityLogService.Add("FSW", $"Detected {Path.GetFileName(filePath)}", LogSeverity.Info);
			_ = ProcessEncryptionAsync(filePath);
		}

		private async Task ProcessEncryptionAsync(string filePath)
		{
			try
			{
				await Task.Delay(500);
				var derivation = CryptoInteropSettings.Get();
				CryptoAlgorithmType algorithm = GetSelectedAutoAlgorithm();
				string outputPath = await Task.Run(() =>
					_cryptoService.EncryptFile(filePath, null, _currentSessionPassword, algorithm, derivation));

				AppendDashboardLog($"Encrypted: {Path.GetFileName(outputPath)}");
				ActivityLogService.Add("FSW", $"Encrypted {Path.GetFileName(filePath)}", LogSeverity.Success);
			}
			catch (Exception ex)
			{
				AppendDashboardLog($"Error: {ex.Message}");
				ActivityLogService.Add("FSW", $"Encryption failed for {Path.GetFileName(filePath)}: {ex.Message}", LogSeverity.Error);
			}
		}

		private void btnToggleFSW_Click(object sender, EventArgs e)
		{
			try
			{
				if (!_fileWatcher.IsRunning)
				{
					if (string.IsNullOrWhiteSpace(SelectedPath))
					{
						MessageBox.Show("Please select a folder first.", "Folder Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					if (string.IsNullOrWhiteSpace(txtAutoPassword.Text))
					{
						MessageBox.Show("Please provide an auto-encryption password.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtAutoPassword.Focus();
						return;
					}

					_currentSessionPassword = txtAutoPassword.Text;
					txtAutoPassword.Enabled = false;
					_fileWatcher.StartWatching(SelectedPath);

					string algoLabel = GetSelectedAutoAlgorithm() == CryptoAlgorithmType.Playfair ? "Playfair" : "RC6-PCBC";
					lblStatus.Text = "ACTIVE";
					lblStatus.ForeColor = Color.FromArgb(22, 163, 74);
					btnToggleFSW.Text = "Stop Monitoring";
					AppendDashboardLog($"Watcher started on: {SelectedPath} (Algorithm: {algoLabel})");
					ActivityLogService.Add("FSW", $"Watcher started on {SelectedPath} (Algorithm: {algoLabel})", LogSeverity.Info);
				}
				else
				{
					_fileWatcher.StopWatching();
					txtAutoPassword.Enabled = true;
					_currentSessionPassword = string.Empty;

					lblStatus.Text = "STOPPED";
					lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
					btnToggleFSW.Text = "Start Monitoring";
					AppendDashboardLog("Watcher stopped.");
					ActivityLogService.Add("FSW", "Watcher stopped", LogSeverity.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "FSW Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ActivityLogService.Add("FSW", ex.Message, LogSeverity.Error);
			}
		}

		private void btnSelectFolder_Click(object sender, EventArgs e)
		{
			using var dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
			{
				SelectedPath = dialog.SelectedPath;
				txtFolderPath.Text = SelectedPath;
				AppendDashboardLog($"Folder selected: {SelectedPath}");
			}
		}

		private void AppendDashboardLog(string message)
		{
			if (IsDisposed || !IsHandleCreated) return;
			if (InvokeRequired)
			{
				BeginInvoke(new Action(() => AppendDashboardLog(message)));
				return;
			}

			lstDashboardLogs.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {message}");
		}

		private CryptoAlgorithmType GetSelectedAutoAlgorithm()
		{
			return rbAutoPlayfair.Checked ? CryptoAlgorithmType.Playfair : CryptoAlgorithmType.RC6_PCBC;
		}
	}
}
