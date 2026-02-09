namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	partial class SettingsView
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		private void InitializeComponent()
		{
			lblTitle = new Label();
			lblSubtitle = new Label();
			panelInterop = new Panel();
			lblInteropTitle = new Label();
			chkAuto = new CheckBox();
			chkUtf8 = new CheckBox();
			chkManualBytes = new CheckBox();
			lblHex = new Label();
			txtHex = new TextBox();
			lblSha1Bytes = new Label();
			numSha1Bytes = new NumericUpDown();
			lblKeyBytes = new Label();
			numKeyBytes = new NumericUpDown();
			panelStorage = new Panel();
			lblStorageTitle = new Label();
			lblEncryptedFolder = new Label();
			txtEncryptedFolder = new TextBox();
			btnBrowseEncrypted = new Button();
			lblDecryptedFolder = new Label();
			txtDecryptedFolder = new TextBox();
			btnBrowseDecrypted = new Button();
			lblLogsFolder = new Label();
			txtLogsFolder = new TextBox();
			btnBrowseLogs = new Button();
			lblStorageHint = new Label();
			btnSave = new Button();
			btnReset = new Button();
			panelInterop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numSha1Bytes).BeginInit();
			((System.ComponentModel.ISupportInitialize)numKeyBytes).BeginInit();
			panelStorage.SuspendLayout();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Location = new Point(24, 18);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(49, 15);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "Settings";
			// 
			// lblSubtitle
			// 
			lblSubtitle.AutoSize = true;
			lblSubtitle.Location = new Point(26, 62);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Size = new Size(501, 15);
			lblSubtitle.TabIndex = 1;
			lblSubtitle.Text = "Control key-derivation compatibility and where encrypted/decrypted files and logs are stored.";
			// 
			// panelInterop
			// 
			panelInterop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panelInterop.Controls.Add(lblInteropTitle);
			panelInterop.Controls.Add(chkAuto);
			panelInterop.Controls.Add(chkUtf8);
			panelInterop.Controls.Add(chkManualBytes);
			panelInterop.Controls.Add(lblHex);
			panelInterop.Controls.Add(txtHex);
			panelInterop.Controls.Add(lblSha1Bytes);
			panelInterop.Controls.Add(numSha1Bytes);
			panelInterop.Controls.Add(lblKeyBytes);
			panelInterop.Controls.Add(numKeyBytes);
			panelInterop.Location = new Point(24, 94);
			panelInterop.Name = "panelInterop";
			panelInterop.Size = new Size(792, 274);
			panelInterop.TabIndex = 2;
			// 
			// lblInteropTitle
			// 
			lblInteropTitle.AutoSize = true;
			lblInteropTitle.Location = new Point(14, 14);
			lblInteropTitle.Name = "lblInteropTitle";
			lblInteropTitle.Size = new Size(205, 15);
			lblInteropTitle.TabIndex = 0;
			lblInteropTitle.Text = "Password Derivation / Interoperability";
			// 
			// chkAuto
			// 
			chkAuto.AutoSize = true;
			chkAuto.Location = new Point(17, 48);
			chkAuto.Name = "chkAuto";
			chkAuto.Size = new Size(433, 19);
			chkAuto.TabIndex = 1;
			chkAuto.Text = "Automatic mode (recommended): UTF-8 + full password bytes + RC6 key=16";
			chkAuto.UseVisualStyleBackColor = true;
			chkAuto.CheckedChanged += chkAuto_CheckedChanged;
			// 
			// chkUtf8
			// 
			chkUtf8.AutoSize = true;
			chkUtf8.Location = new Point(17, 78);
			chkUtf8.Name = "chkUtf8";
			chkUtf8.Size = new Size(200, 19);
			chkUtf8.TabIndex = 2;
			chkUtf8.Text = "Use UTF-8 encoding (off = ASCII)";
			chkUtf8.UseVisualStyleBackColor = true;
			// 
			// chkManualBytes
			// 
			chkManualBytes.AutoSize = true;
			chkManualBytes.Location = new Point(17, 108);
			chkManualBytes.Name = "chkManualBytes";
			chkManualBytes.Size = new Size(382, 19);
			chkManualBytes.TabIndex = 3;
			chkManualBytes.Text = "Use manual password bytes (hex) instead of encoded text password";
			chkManualBytes.UseVisualStyleBackColor = true;
			chkManualBytes.CheckedChanged += chkManualBytes_CheckedChanged;
			// 
			// lblHex
			// 
			lblHex.AutoSize = true;
			lblHex.Location = new Point(17, 142);
			lblHex.Name = "lblHex";
			lblHex.Size = new Size(103, 15);
			lblHex.TabIndex = 4;
			lblHex.Text = "Manual bytes hex:";
			// 
			// txtHex
			// 
			txtHex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtHex.Location = new Point(17, 163);
			txtHex.Name = "txtHex";
			txtHex.Size = new Size(758, 23);
			txtHex.TabIndex = 5;
			// 
			// lblSha1Bytes
			// 
			lblSha1Bytes.AutoSize = true;
			lblSha1Bytes.Location = new Point(17, 201);
			lblSha1Bytes.Name = "lblSha1Bytes";
			lblSha1Bytes.Size = new Size(189, 15);
			lblSha1Bytes.TabIndex = 6;
			lblSha1Bytes.Text = "Password bytes for SHA-1 (0 = all):";
			// 
			// numSha1Bytes
			// 
			numSha1Bytes.Location = new Point(227, 199);
			numSha1Bytes.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
			numSha1Bytes.Name = "numSha1Bytes";
			numSha1Bytes.Size = new Size(104, 23);
			numSha1Bytes.TabIndex = 7;
			// 
			// lblKeyBytes
			// 
			lblKeyBytes.AutoSize = true;
			lblKeyBytes.Location = new Point(17, 234);
			lblKeyBytes.Name = "lblKeyBytes";
			lblKeyBytes.Size = new Size(149, 15);
			lblKeyBytes.TabIndex = 8;
			lblKeyBytes.Text = "RC6 key bytes from SHA-1:";
			// 
			// numKeyBytes
			// 
			numKeyBytes.Location = new Point(227, 232);
			numKeyBytes.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
			numKeyBytes.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
			numKeyBytes.Name = "numKeyBytes";
			numKeyBytes.Size = new Size(104, 23);
			numKeyBytes.TabIndex = 9;
			numKeyBytes.Value = new decimal(new int[] { 16, 0, 0, 0 });
			// 
			// panelStorage
			// 
			panelStorage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panelStorage.Controls.Add(lblStorageTitle);
			panelStorage.Controls.Add(lblEncryptedFolder);
			panelStorage.Controls.Add(txtEncryptedFolder);
			panelStorage.Controls.Add(btnBrowseEncrypted);
			panelStorage.Controls.Add(lblDecryptedFolder);
			panelStorage.Controls.Add(txtDecryptedFolder);
			panelStorage.Controls.Add(btnBrowseDecrypted);
			panelStorage.Controls.Add(lblLogsFolder);
			panelStorage.Controls.Add(txtLogsFolder);
			panelStorage.Controls.Add(btnBrowseLogs);
			panelStorage.Controls.Add(lblStorageHint);
			panelStorage.Location = new Point(24, 380);
			panelStorage.Name = "panelStorage";
			panelStorage.Size = new Size(792, 220);
			panelStorage.TabIndex = 3;
			// 
			// lblStorageTitle
			// 
			lblStorageTitle.AutoSize = true;
			lblStorageTitle.Location = new Point(14, 14);
			lblStorageTitle.Name = "lblStorageTitle";
			lblStorageTitle.Size = new Size(79, 15);
			lblStorageTitle.TabIndex = 0;
			lblStorageTitle.Text = "Storage Paths";
			// 
			// lblEncryptedFolder
			// 
			lblEncryptedFolder.AutoSize = true;
			lblEncryptedFolder.Location = new Point(17, 52);
			lblEncryptedFolder.Name = "lblEncryptedFolder";
			lblEncryptedFolder.Size = new Size(121, 15);
			lblEncryptedFolder.TabIndex = 1;
			lblEncryptedFolder.Text = "Encrypted files folder:";
			// 
			// txtEncryptedFolder
			// 
			txtEncryptedFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtEncryptedFolder.Location = new Point(145, 48);
			txtEncryptedFolder.Name = "txtEncryptedFolder";
			txtEncryptedFolder.Size = new Size(526, 23);
			txtEncryptedFolder.TabIndex = 2;
			// 
			// btnBrowseEncrypted
			// 
			btnBrowseEncrypted.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnBrowseEncrypted.Location = new Point(677, 47);
			btnBrowseEncrypted.Name = "btnBrowseEncrypted";
			btnBrowseEncrypted.Size = new Size(98, 25);
			btnBrowseEncrypted.TabIndex = 3;
			btnBrowseEncrypted.Text = "Browse...";
			btnBrowseEncrypted.UseVisualStyleBackColor = true;
			btnBrowseEncrypted.Click += btnBrowseEncrypted_Click;
			// 
			// lblDecryptedFolder
			// 
			lblDecryptedFolder.AutoSize = true;
			lblDecryptedFolder.Location = new Point(17, 86);
			lblDecryptedFolder.Name = "lblDecryptedFolder";
			lblDecryptedFolder.Size = new Size(122, 15);
			lblDecryptedFolder.TabIndex = 4;
			lblDecryptedFolder.Text = "Decrypted files folder:";
			// 
			// txtDecryptedFolder
			// 
			txtDecryptedFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtDecryptedFolder.Location = new Point(145, 82);
			txtDecryptedFolder.Name = "txtDecryptedFolder";
			txtDecryptedFolder.Size = new Size(526, 23);
			txtDecryptedFolder.TabIndex = 5;
			// 
			// btnBrowseDecrypted
			// 
			btnBrowseDecrypted.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnBrowseDecrypted.Location = new Point(677, 81);
			btnBrowseDecrypted.Name = "btnBrowseDecrypted";
			btnBrowseDecrypted.Size = new Size(98, 25);
			btnBrowseDecrypted.TabIndex = 6;
			btnBrowseDecrypted.Text = "Browse...";
			btnBrowseDecrypted.UseVisualStyleBackColor = true;
			btnBrowseDecrypted.Click += btnBrowseDecrypted_Click;
			// 
			// lblLogsFolder
			// 
			lblLogsFolder.AutoSize = true;
			lblLogsFolder.Location = new Point(17, 120);
			lblLogsFolder.Name = "lblLogsFolder";
			lblLogsFolder.Size = new Size(109, 15);
			lblLogsFolder.TabIndex = 7;
			lblLogsFolder.Text = "Activity logs folder:";
			// 
			// txtLogsFolder
			// 
			txtLogsFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtLogsFolder.Location = new Point(145, 116);
			txtLogsFolder.Name = "txtLogsFolder";
			txtLogsFolder.Size = new Size(526, 23);
			txtLogsFolder.TabIndex = 8;
			// 
			// btnBrowseLogs
			// 
			btnBrowseLogs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnBrowseLogs.Location = new Point(677, 115);
			btnBrowseLogs.Name = "btnBrowseLogs";
			btnBrowseLogs.Size = new Size(98, 25);
			btnBrowseLogs.TabIndex = 9;
			btnBrowseLogs.Text = "Browse...";
			btnBrowseLogs.UseVisualStyleBackColor = true;
			btnBrowseLogs.Click += btnBrowseLogs_Click;
			// 
			// lblStorageHint
			// 
			lblStorageHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lblStorageHint.Location = new Point(17, 154);
			lblStorageHint.Name = "lblStorageHint";
			lblStorageHint.Size = new Size(758, 48);
			lblStorageHint.TabIndex = 10;
			lblStorageHint.Text = "These folders are used by manual encrypt/decrypt, watcher output, network receive, and activity log files.";
			// 
			// btnSave
			// 
			btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnSave.Location = new Point(676, 612);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(140, 36);
			btnSave.TabIndex = 11;
			btnSave.Text = "Save Settings";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnReset
			// 
			btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnReset.Location = new Point(530, 612);
			btnReset.Name = "btnReset";
			btnReset.Size = new Size(140, 36);
			btnReset.TabIndex = 12;
			btnReset.Text = "Reset Defaults";
			btnReset.UseVisualStyleBackColor = true;
			btnReset.Click += btnReset_Click;
			// 
			// SettingsView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			Controls.Add(btnReset);
			Controls.Add(btnSave);
			Controls.Add(panelStorage);
			Controls.Add(panelInterop);
			Controls.Add(lblSubtitle);
			Controls.Add(lblTitle);
			Name = "SettingsView";
			Size = new Size(840, 658);
			panelInterop.ResumeLayout(false);
			panelInterop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numSha1Bytes).EndInit();
			((System.ComponentModel.ISupportInitialize)numKeyBytes).EndInit();
			panelStorage.ResumeLayout(false);
			panelStorage.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblTitle;
		private Label lblSubtitle;
		private Panel panelInterop;
		private Label lblInteropTitle;
		private CheckBox chkAuto;
		private CheckBox chkUtf8;
		private CheckBox chkManualBytes;
		private Label lblHex;
		private TextBox txtHex;
		private Label lblSha1Bytes;
		private NumericUpDown numSha1Bytes;
		private Label lblKeyBytes;
		private NumericUpDown numKeyBytes;
		private Panel panelStorage;
		private Label lblStorageTitle;
		private Label lblEncryptedFolder;
		private TextBox txtEncryptedFolder;
		private Button btnBrowseEncrypted;
		private Label lblDecryptedFolder;
		private TextBox txtDecryptedFolder;
		private Button btnBrowseDecrypted;
		private Label lblLogsFolder;
		private TextBox txtLogsFolder;
		private Button btnBrowseLogs;
		private Label lblStorageHint;
		private Button btnSave;
		private Button btnReset;
	}
}
