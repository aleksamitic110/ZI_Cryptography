using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;
using ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;

namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	public partial class ManualEncryptionView : UserControl
	{
		private readonly ICryptoService _cryptoService;
		private string _selectedFilePath = string.Empty;

		public ManualEncryptionView() : this(new EncryptionService())
		{
		}

		public ManualEncryptionView(ICryptoService cryptoService)
		{
			_cryptoService = cryptoService;
			InitializeComponent();
			LoadOutputFoldersFromSettings();
			RefreshPathHint();
		}

		private void DropZone_DragEnter(object? sender, DragEventArgs e)
		{
			if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void DropZone_DragDrop(object? sender, DragEventArgs e)
		{
			if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
			{
				SetSelectedFile(files[0]);
			}
		}

		private void DropZone_Click(object? sender, EventArgs e)
		{
			using var openDialog = new OpenFileDialog();
			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				SetSelectedFile(openDialog.FileName);
			}
		}

		private void SetSelectedFile(string path)
		{
			_selectedFilePath = path;
			_dropZoneText.Text = $"Selected: {Path.GetFileName(path)}";
			AppendLog($"File selected: {path}");
			ActivityLogService.Add("Manual", $"Selected file {Path.GetFileName(path)}", LogSeverity.Info);
		}

		private async void EncryptButton_Click(object? sender, EventArgs e)
		{
			await RunCryptoAsync(encrypt: true);
		}

		private async void DecryptButton_Click(object? sender, EventArgs e)
		{
			await RunCryptoAsync(encrypt: false);
		}

		private async Task RunCryptoAsync(bool encrypt)
		{
			RefreshPathHint();

			if (string.IsNullOrWhiteSpace(_selectedFilePath) || !File.Exists(_selectedFilePath))
			{
				MessageBox.Show("Please select a valid file first.", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(_passwordTextBox.Text))
			{
				MessageBox.Show("Password is required.", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ToggleUi(false);
			try
			{
				string result = await Task.Run(() =>
				{
					var derivation = CryptoInteropSettings.Get();
					if (encrypt)
					{
						var mode = GetSelectedAlgorithm();
						return _cryptoService.EncryptFile(
							_selectedFilePath,
							ResolveOutputFolder(_encryptOutputTextBox.Text),
							_passwordTextBox.Text,
							mode,
							derivation);
					}

					return _cryptoService.DecryptFile(
						_selectedFilePath,
						ResolveOutputFolder(_decryptOutputTextBox.Text),
						_passwordTextBox.Text,
						derivation);
				});

				AppendLog($"{(encrypt ? "Encrypted" : "Decrypted")} OK: {result}");
				ActivityLogService.Add("Manual", $"{(encrypt ? "Encrypted" : "Decrypted")} {Path.GetFileName(result)}", LogSeverity.Success);
				_selectedFilePath = result;
				_dropZoneText.Text = $"Selected: {Path.GetFileName(result)}";
			}
			catch (Exception ex)
			{
				AppendLog($"Error: {ex.Message}");
				ActivityLogService.Add("Manual", ex.Message, LogSeverity.Error);
				MessageBox.Show(ex.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				ToggleUi(true);
			}
		}

		private void ToggleUi(bool enabled)
		{
			_encryptButton.Enabled = enabled;
			_decryptButton.Enabled = enabled;
			_passwordTextBox.Enabled = enabled;
			_togglePasswordVisibilityButton.Enabled = enabled;
			_encryptOutputTextBox.Enabled = enabled;
			_decryptOutputTextBox.Enabled = enabled;
			_browseEncryptOutputButton.Enabled = enabled;
			_browseDecryptOutputButton.Enabled = enabled;
			_rc6PcbcRadio.Enabled = enabled;
			_rc6OnlyRadio.Enabled = enabled;
			_pcbcOnlyRadio.Enabled = enabled;
			_playfairRadio.Enabled = enabled;
		}

		private CryptoAlgorithmType GetSelectedAlgorithm()
		{
			if (_playfairRadio.Checked) return CryptoAlgorithmType.Playfair;
			if (_pcbcOnlyRadio.Checked) return CryptoAlgorithmType.PCBC;
			if (_rc6OnlyRadio.Checked) return CryptoAlgorithmType.RC6;
			return CryptoAlgorithmType.RC6_PCBC;
		}

		private void RefreshPathHint()
		{
			var pathOptions = OutputPathSettings.Get();
			string encryptFolder = string.IsNullOrWhiteSpace(_encryptOutputTextBox.Text)
				? pathOptions.EncryptedFilesFolder
				: _encryptOutputTextBox.Text.Trim();
			string decryptFolder = string.IsNullOrWhiteSpace(_decryptOutputTextBox.Text)
				? pathOptions.DecryptedFilesFolder
				: _decryptOutputTextBox.Text.Trim();

			_pathHint.Text = $"Encrypt -> {encryptFolder} | Decrypt -> {decryptFolder}";
		}

		private void AppendLog(string message)
		{
			_logTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
		}

		private void TogglePasswordVisibilityButton_Click(object? sender, EventArgs e)
		{
			_passwordTextBox.UseSystemPasswordChar = !_passwordTextBox.UseSystemPasswordChar;
			_togglePasswordVisibilityButton.Text = _passwordTextBox.UseSystemPasswordChar ? "\uD83D\uDD12" : "\uD83D\uDD13";
		}

		private void BrowseEncryptOutputButton_Click(object? sender, EventArgs e)
		{
			BrowseFolder(_encryptOutputTextBox);
			RefreshPathHint();
		}

		private void BrowseDecryptOutputButton_Click(object? sender, EventArgs e)
		{
			BrowseFolder(_decryptOutputTextBox);
			RefreshPathHint();
		}

		private static void BrowseFolder(TextBox target)
		{
			using var dialog = new FolderBrowserDialog();
			if (Directory.Exists(target.Text))
			{
				dialog.SelectedPath = target.Text;
			}

			if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
			{
				target.Text = dialog.SelectedPath;
			}
		}

		private void LoadOutputFoldersFromSettings()
		{
			var pathOptions = OutputPathSettings.Get();
			_encryptOutputTextBox.Text = pathOptions.EncryptedFilesFolder;
			_decryptOutputTextBox.Text = pathOptions.DecryptedFilesFolder;
			_togglePasswordVisibilityButton.Text = _passwordTextBox.UseSystemPasswordChar ? "\uD83D\uDD12" : "\uD83D\uDD13";
		}

		private static string? ResolveOutputFolder(string value)
		{
			string folder = (value ?? string.Empty).Trim();
			if (string.IsNullOrWhiteSpace(folder))
			{
				return null;
			}

			string fullPath = Path.GetFullPath(folder);
			Directory.CreateDirectory(fullPath);
			return fullPath;
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (Visible)
			{
				RefreshPathHint();
			}
		}
	}
}

