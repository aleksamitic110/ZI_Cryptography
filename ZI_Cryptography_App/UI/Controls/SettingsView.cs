using System;
using System.IO;
using System.Windows.Forms;
using ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;

namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	public partial class SettingsView : UserControl
	{
		public SettingsView()
		{
			InitializeComponent();
			LoadSettings();
		}

		private void LoadSettings()
		{
			var cfg = CryptoInteropSettings.Get();
			chkAuto.Checked = cfg.AutoMode;
			chkUtf8.Checked = cfg.UseUtf8Encoding;
			chkManualBytes.Checked = cfg.UseManualPasswordBytes;
			numSha1Bytes.Value = cfg.PasswordBytesForSha1;
			numKeyBytes.Value = cfg.Rc6KeyBytes;
			txtHex.Text = cfg.ManualPasswordBytesHex;

			var paths = OutputPathSettings.Get();
			txtEncryptedFolder.Text = paths.EncryptedFilesFolder;
			txtDecryptedFolder.Text = paths.DecryptedFilesFolder;
			txtLogsFolder.Text = paths.ActivityLogsFolder;

			RefreshEnabledState();
		}

		private void SaveSettings()
		{
			try
			{
				var derivation = new PasswordDerivationOptions
				{
					AutoMode = chkAuto.Checked,
					UseUtf8Encoding = chkUtf8.Checked,
					UseManualPasswordBytes = chkManualBytes.Checked,
					ManualPasswordBytesHex = txtHex.Text.Trim(),
					PasswordBytesForSha1 = (int)numSha1Bytes.Value,
					Rc6KeyBytes = (int)numKeyBytes.Value
				};

				var paths = new OutputPathOptions
				{
					EncryptedFilesFolder = txtEncryptedFolder.Text.Trim(),
					DecryptedFilesFolder = txtDecryptedFolder.Text.Trim(),
					ActivityLogsFolder = txtLogsFolder.Text.Trim()
				};

				CryptoInteropSettings.Set(derivation);
				OutputPathSettings.Set(paths);

				ActivityLogService.Add("Settings", "Updated interoperability and output-path settings", LogSeverity.Success);
				MessageBox.Show("Settings saved. Output folders, activity-log folder, and crypto compatibility are now active.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				ActivityLogService.Add("Settings", ex.Message, LogSeverity.Error);
				MessageBox.Show(ex.Message, "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void ResetDefaults()
		{
			CryptoInteropSettings.Set(new PasswordDerivationOptions());
			OutputPathSettings.Reset();
			LoadSettings();
			ActivityLogService.Add("Settings", "Reset settings to defaults", LogSeverity.Info);
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

		private void RefreshEnabledState()
		{
			bool manualMode = !chkAuto.Checked;
			chkUtf8.Enabled = manualMode;
			chkManualBytes.Enabled = manualMode;
			numSha1Bytes.Enabled = manualMode;
			numKeyBytes.Enabled = manualMode;
			txtHex.Enabled = manualMode && chkManualBytes.Checked;
		}

		private void chkAuto_CheckedChanged(object? sender, EventArgs e)
		{
			RefreshEnabledState();
		}

		private void chkManualBytes_CheckedChanged(object? sender, EventArgs e)
		{
			RefreshEnabledState();
		}

		private void btnBrowseEncrypted_Click(object? sender, EventArgs e)
		{
			BrowseFolder(txtEncryptedFolder);
		}

		private void btnBrowseDecrypted_Click(object? sender, EventArgs e)
		{
			BrowseFolder(txtDecryptedFolder);
		}

		private void btnBrowseLogs_Click(object? sender, EventArgs e)
		{
			BrowseFolder(txtLogsFolder);
		}

		private void btnSave_Click(object? sender, EventArgs e)
		{
			SaveSettings();
		}

		private void btnReset_Click(object? sender, EventArgs e)
		{
			ResetDefaults();
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (Visible)
			{
				LoadSettings();
			}
		}
	}
}
