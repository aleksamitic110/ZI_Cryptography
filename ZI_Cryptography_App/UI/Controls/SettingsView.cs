using System;
using System.Drawing;
using System.Windows.Forms;
using ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;

namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	public class SettingsView : UserControl
	{
		private readonly CheckBox _chkAuto;
		private readonly CheckBox _chkUtf8;
		private readonly CheckBox _chkManualBytes;
		private readonly NumericUpDown _numSha1Bytes;
		private readonly NumericUpDown _numKeyBytes;
		private readonly TextBox _txtHex;
		private readonly Button _btnSave;
		private readonly Button _btnReset;

		public SettingsView()
		{
			Dock = DockStyle.Fill;
			BackColor = Color.FromArgb(2, 6, 23);
			AutoScroll = true;

			var title = new Label
			{
				Text = "Interoperability Settings",
				Font = new Font("Segoe UI Semibold", 22, FontStyle.Bold),
				ForeColor = Color.FromArgb(241, 245, 249),
				Location = new Point(24, 18),
				AutoSize = true
			};

			var subtitle = new Label
			{
				Text = "Configure password-to-key behavior for cross-student compatibility.",
				Font = new Font("Segoe UI", 10),
				ForeColor = Color.FromArgb(148, 163, 184),
				Location = new Point(28, 62),
				AutoSize = true
			};

			var card = new Panel
			{
				BackColor = Color.FromArgb(15, 23, 42),
				Location = new Point(24, 92),
				Size = new Size(780, 350),
				Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
			};

			_chkAuto = new CheckBox
			{
				Text = "Automatic mode (recommended): UTF-8 + full password bytes + RC6 key=16",
				ForeColor = Color.FromArgb(226, 232, 240),
				Location = new Point(20, 20),
				AutoSize = true
			};
			_chkAuto.CheckedChanged += (_, _) => RefreshEnabledState();

			_chkUtf8 = new CheckBox
			{
				Text = "Use UTF-8 encoding (off = ASCII)",
				ForeColor = Color.FromArgb(226, 232, 240),
				Location = new Point(20, 70),
				AutoSize = true
			};

			_chkManualBytes = new CheckBox
			{
				Text = "Use manual password bytes (hex) instead of encoded text password",
				ForeColor = Color.FromArgb(226, 232, 240),
				Location = new Point(20, 105),
				AutoSize = true
			};
			_chkManualBytes.CheckedChanged += (_, _) => RefreshEnabledState();

			var lblHex = new Label
			{
				Text = "Manual bytes hex:",
				ForeColor = Color.FromArgb(148, 163, 184),
				Location = new Point(20, 138),
				AutoSize = true
			};

			_txtHex = new TextBox
			{
				Location = new Point(20, 160),
				Width = 740,
				BackColor = Color.FromArgb(30, 41, 59),
				ForeColor = Color.White,
				BorderStyle = BorderStyle.FixedSingle
			};

			var lblShaBytes = new Label
			{
				Text = "Password bytes used for SHA-1 (0 = all):",
				ForeColor = Color.FromArgb(148, 163, 184),
				Location = new Point(20, 200),
				AutoSize = true
			};

			_numSha1Bytes = new NumericUpDown
			{
				Location = new Point(320, 198),
				Minimum = 0,
				Maximum = 4096,
				Value = 0,
				Width = 110
			};

			var lblKeyBytes = new Label
			{
				Text = "RC6 key bytes from SHA-1:",
				ForeColor = Color.FromArgb(148, 163, 184),
				Location = new Point(20, 236),
				AutoSize = true
			};

			_numKeyBytes = new NumericUpDown
			{
				Location = new Point(320, 234),
				Minimum = 4,
				Maximum = 20,
				Value = 16,
				Width = 110
			};

			_btnSave = new Button
			{
				Text = "Save",
				Location = new Point(640, 300),
				Size = new Size(120, 34),
				BackColor = Color.FromArgb(14, 116, 144),
				ForeColor = Color.White,
				FlatStyle = FlatStyle.Flat
			};
			_btnSave.FlatAppearance.BorderSize = 0;
			_btnSave.Click += (_, _) => SaveSettings();

			_btnReset = new Button
			{
				Text = "Reset Auto",
				Location = new Point(510, 300),
				Size = new Size(120, 34),
				BackColor = Color.FromArgb(71, 85, 105),
				ForeColor = Color.White,
				FlatStyle = FlatStyle.Flat
			};
			_btnReset.FlatAppearance.BorderSize = 0;
			_btnReset.Click += (_, _) => ResetAuto();

			card.Controls.Add(_chkAuto);
			card.Controls.Add(_chkUtf8);
			card.Controls.Add(_chkManualBytes);
			card.Controls.Add(lblHex);
			card.Controls.Add(_txtHex);
			card.Controls.Add(lblShaBytes);
			card.Controls.Add(_numSha1Bytes);
			card.Controls.Add(lblKeyBytes);
			card.Controls.Add(_numKeyBytes);
			card.Controls.Add(_btnSave);
			card.Controls.Add(_btnReset);

			Controls.Add(title);
			Controls.Add(subtitle);
			Controls.Add(card);

			LoadSettings();
		}

		private void LoadSettings()
		{
			var cfg = CryptoInteropSettings.Get();
			_chkAuto.Checked = cfg.AutoMode;
			_chkUtf8.Checked = cfg.UseUtf8Encoding;
			_chkManualBytes.Checked = cfg.UseManualPasswordBytes;
			_numSha1Bytes.Value = cfg.PasswordBytesForSha1;
			_numKeyBytes.Value = cfg.Rc6KeyBytes;
			_txtHex.Text = cfg.ManualPasswordBytesHex;
			RefreshEnabledState();
		}

		private void ResetAuto()
		{
			CryptoInteropSettings.Set(new PasswordDerivationOptions());
			LoadSettings();
			ActivityLogService.Add("Settings", "Reset interoperability settings to automatic defaults", LogSeverity.Info);
		}

		private void SaveSettings()
		{
			var cfg = new PasswordDerivationOptions
			{
				AutoMode = _chkAuto.Checked,
				UseUtf8Encoding = _chkUtf8.Checked,
				UseManualPasswordBytes = _chkManualBytes.Checked,
				ManualPasswordBytesHex = _txtHex.Text.Trim(),
				PasswordBytesForSha1 = (int)_numSha1Bytes.Value,
				Rc6KeyBytes = (int)_numKeyBytes.Value
			};

			CryptoInteropSettings.Set(cfg);
			ActivityLogService.Add("Settings", "Updated interoperability settings", LogSeverity.Success);
			MessageBox.Show("Settings saved. These values are now used for encrypt/decrypt and network receive.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void RefreshEnabledState()
		{
			bool manualMode = !_chkAuto.Checked;
			_chkUtf8.Enabled = manualMode;
			_chkManualBytes.Enabled = manualMode;
			_numSha1Bytes.Enabled = manualMode;
			_numKeyBytes.Enabled = manualMode;
			_txtHex.Enabled = manualMode && _chkManualBytes.Checked;
		}
	}
}
