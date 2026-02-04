using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;
using ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;

namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	public class ManualEncryptionView : UserControl
	{
		private readonly ICryptoService _cryptoService;
		private string _selectedFilePath = string.Empty;

		private readonly Label _title;
		private readonly Panel _dropZone;
		private readonly Label _dropZoneText;
		private readonly TextBox _passwordTextBox;
		private readonly RadioButton _rc6Radio;
		private readonly RadioButton _playfairRadio;
		private readonly Button _encryptButton;
		private readonly Button _decryptButton;
		private readonly TextBox _logTextBox;

		public ManualEncryptionView() : this(new EncryptionService())
		{
		}

		public ManualEncryptionView(ICryptoService cryptoService)
		{
			_cryptoService = cryptoService;
			Dock = DockStyle.Fill;
			AutoScroll = true;
			BackColor = Color.FromArgb(2, 6, 23);

			_title = new Label
			{
				Text = "Manual Encryption",
				ForeColor = Color.FromArgb(241, 245, 249),
				Font = new Font("Segoe UI Semibold", 20, FontStyle.Bold),
				Location = new Point(24, 20),
				AutoSize = true
			};

			_dropZone = new Panel
			{
				Location = new Point(24, 70),
				Size = new Size(780, 120),
				BorderStyle = BorderStyle.FixedSingle,
				AllowDrop = true,
				BackColor = Color.FromArgb(15, 23, 42),
				Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
			};
			_dropZone.DragEnter += DropZone_DragEnter;
			_dropZone.DragDrop += DropZone_DragDrop;
			_dropZone.Click += DropZone_Click;

			_dropZoneText = new Label
			{
				Text = "Drag and drop a file here, or click to browse.",
				ForeColor = Color.FromArgb(148, 163, 184),
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleCenter,
				Dock = DockStyle.Fill,
				Font = new Font("Segoe UI", 11, FontStyle.Regular)
			};
			_dropZone.Controls.Add(_dropZoneText);

			_passwordTextBox = new TextBox
			{
				Location = new Point(24, 220),
				Width = 350,
				PlaceholderText = "Password",
				UseSystemPasswordChar = true,
				BackColor = Color.FromArgb(30, 41, 59),
				ForeColor = Color.White,
				BorderStyle = BorderStyle.FixedSingle
			};

			_rc6Radio = new RadioButton
			{
				Text = "RC6 + PCBC",
				Checked = true,
				ForeColor = Color.FromArgb(226, 232, 240),
				Location = new Point(24, 260),
				AutoSize = true
			};

			_playfairRadio = new RadioButton
			{
				Text = "Playfair (txt only)",
				ForeColor = Color.FromArgb(226, 232, 240),
				Location = new Point(150, 260),
				AutoSize = true
			};

			_encryptButton = new Button
			{
				Text = "Encrypt",
				Location = new Point(24, 300),
				Size = new Size(130, 38),
				BackColor = Color.FromArgb(14, 116, 144),
				ForeColor = Color.White,
				FlatStyle = FlatStyle.Flat
			};
			_encryptButton.FlatAppearance.BorderSize = 0;
			_encryptButton.Click += async (_, _) => await RunCryptoAsync(encrypt: true);

			_decryptButton = new Button
			{
				Text = "Decrypt",
				Location = new Point(170, 300),
				Size = new Size(130, 38),
				BackColor = Color.FromArgb(30, 64, 175),
				ForeColor = Color.White,
				FlatStyle = FlatStyle.Flat
			};
			_decryptButton.FlatAppearance.BorderSize = 0;
			_decryptButton.Click += async (_, _) => await RunCryptoAsync(encrypt: false);

			_logTextBox = new TextBox
			{
				Location = new Point(24, 350),
				Size = new Size(780, 170),
				Multiline = true,
				ReadOnly = true,
				ScrollBars = ScrollBars.Vertical,
				Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
				BackColor = Color.FromArgb(15, 23, 42),
				ForeColor = Color.FromArgb(226, 232, 240),
				BorderStyle = BorderStyle.FixedSingle,
				Font = new Font("Consolas", 10)
			};

			Controls.Add(_title);
			Controls.Add(_dropZone);
			Controls.Add(_passwordTextBox);
			Controls.Add(_rc6Radio);
			Controls.Add(_playfairRadio);
			Controls.Add(_encryptButton);
			Controls.Add(_decryptButton);
			Controls.Add(_logTextBox);

			Resize += (_, _) => ArrangeResponsiveLayout();
			ArrangeResponsiveLayout();
		}

		private void ArrangeResponsiveLayout()
		{
			int contentWidth = Math.Max(620, ClientSize.Width - 48);
			int fieldWidth = Math.Min(420, contentWidth - 48);

			_dropZone.Width = contentWidth;
			_passwordTextBox.Width = fieldWidth;
			_logTextBox.Width = contentWidth;
			_logTextBox.Height = Math.Max(170, ClientSize.Height - 370);
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

		private async Task RunCryptoAsync(bool encrypt)
		{
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
						var mode = _playfairRadio.Checked ? CryptoAlgorithmType.Playfair : CryptoAlgorithmType.RC6_PCBC;
						return _cryptoService.EncryptFile(_selectedFilePath, null, _passwordTextBox.Text, mode, derivation);
					}

					return _cryptoService.DecryptFile(_selectedFilePath, null, _passwordTextBox.Text, derivation);
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
			_rc6Radio.Enabled = enabled;
			_playfairRadio.Enabled = enabled;
		}

		private void AppendLog(string message)
		{
			_logTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
		}
	}
}
