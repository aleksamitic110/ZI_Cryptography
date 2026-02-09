namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	partial class ManualEncryptionView
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
			_title = new Label();
			_subtitle = new Label();
			_dropZone = new Panel();
			_dropZoneText = new Label();
			_passwordTextBox = new TextBox();
			_rc6PcbcRadio = new RadioButton();
			_rc6OnlyRadio = new RadioButton();
			_pcbcOnlyRadio = new RadioButton();
			_playfairRadio = new RadioButton();
			_encryptButton = new Button();
			_decryptButton = new Button();
			_pathHint = new Label();
			_logTextBox = new TextBox();
			_dropZone.SuspendLayout();
			SuspendLayout();
			// 
			// _title
			// 
			_title.AutoSize = true;
			_title.Location = new Point(24, 20);
			_title.Name = "_title";
			_title.Size = new Size(138, 15);
			_title.TabIndex = 0;
			_title.Text = "Manual Encryption";
			// 
			// _subtitle
			// 
			_subtitle.AutoSize = true;
			_subtitle.Location = new Point(26, 62);
			_subtitle.Name = "_subtitle";
			_subtitle.Size = new Size(367, 15);
			_subtitle.TabIndex = 1;
			_subtitle.Text = "Encrypt or decrypt any file manually using RC6, PCBC, or Playfair.";
			// 
			// _dropZone
			// 
			_dropZone.AllowDrop = true;
			_dropZone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_dropZone.BorderStyle = BorderStyle.FixedSingle;
			_dropZone.Controls.Add(_dropZoneText);
			_dropZone.Location = new Point(24, 92);
			_dropZone.Name = "_dropZone";
			_dropZone.Size = new Size(780, 120);
			_dropZone.TabIndex = 2;
			_dropZone.Click += DropZone_Click;
			_dropZone.DragDrop += DropZone_DragDrop;
			_dropZone.DragEnter += DropZone_DragEnter;
			// 
			// _dropZoneText
			// 
			_dropZoneText.Dock = DockStyle.Fill;
			_dropZoneText.Location = new Point(0, 0);
			_dropZoneText.Name = "_dropZoneText";
			_dropZoneText.Size = new Size(778, 118);
			_dropZoneText.TabIndex = 0;
			_dropZoneText.Text = "Drag and drop a file here, or click to browse.";
			_dropZoneText.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// _passwordTextBox
			// 
			_passwordTextBox.Location = new Point(24, 240);
			_passwordTextBox.Name = "_passwordTextBox";
			_passwordTextBox.PlaceholderText = "Password";
			_passwordTextBox.Size = new Size(350, 23);
			_passwordTextBox.TabIndex = 3;
			_passwordTextBox.UseSystemPasswordChar = true;
			// 
			// _rc6PcbcRadio
			// 
			_rc6PcbcRadio.AutoSize = true;
			_rc6PcbcRadio.Checked = true;
			_rc6PcbcRadio.Location = new Point(24, 278);
			_rc6PcbcRadio.Name = "_rc6PcbcRadio";
			_rc6PcbcRadio.Size = new Size(86, 19);
			_rc6PcbcRadio.TabIndex = 4;
			_rc6PcbcRadio.TabStop = true;
			_rc6PcbcRadio.Text = "RC6 + PCBC";
			_rc6PcbcRadio.UseVisualStyleBackColor = true;
			// 
			// _rc6OnlyRadio
			// 
			_rc6OnlyRadio.AutoSize = true;
			_rc6OnlyRadio.Location = new Point(130, 278);
			_rc6OnlyRadio.Name = "_rc6OnlyRadio";
			_rc6OnlyRadio.Size = new Size(72, 19);
			_rc6OnlyRadio.TabIndex = 5;
			_rc6OnlyRadio.Text = "RC6 only";
			_rc6OnlyRadio.UseVisualStyleBackColor = true;
			// 
			// _pcbcOnlyRadio
			// 
			_pcbcOnlyRadio.AutoSize = true;
			_pcbcOnlyRadio.Location = new Point(220, 278);
			_pcbcOnlyRadio.Name = "_pcbcOnlyRadio";
			_pcbcOnlyRadio.Size = new Size(80, 19);
			_pcbcOnlyRadio.TabIndex = 6;
			_pcbcOnlyRadio.Text = "PCBC only";
			_pcbcOnlyRadio.UseVisualStyleBackColor = true;
			// 
			// _playfairRadio
			// 
			_playfairRadio.AutoSize = true;
			_playfairRadio.Location = new Point(320, 278);
			_playfairRadio.Name = "_playfairRadio";
			_playfairRadio.Size = new Size(109, 19);
			_playfairRadio.TabIndex = 7;
			_playfairRadio.Text = "Playfair (txt only)";
			_playfairRadio.UseVisualStyleBackColor = true;
			// 
			// _encryptButton
			// 
			_encryptButton.Location = new Point(24, 314);
			_encryptButton.Name = "_encryptButton";
			_encryptButton.Size = new Size(130, 38);
			_encryptButton.TabIndex = 8;
			_encryptButton.Text = "Encrypt";
			_encryptButton.UseVisualStyleBackColor = true;
			_encryptButton.Click += EncryptButton_Click;
			// 
			// _decryptButton
			// 
			_decryptButton.Location = new Point(170, 314);
			_decryptButton.Name = "_decryptButton";
			_decryptButton.Size = new Size(130, 38);
			_decryptButton.TabIndex = 9;
			_decryptButton.Text = "Decrypt";
			_decryptButton.UseVisualStyleBackColor = true;
			_decryptButton.Click += DecryptButton_Click;
			// 
			// _pathHint
			// 
			_pathHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_pathHint.Location = new Point(24, 364);
			_pathHint.Name = "_pathHint";
			_pathHint.Size = new Size(780, 36);
			_pathHint.TabIndex = 10;
			_pathHint.Text = "Encrypted -> ... | Decrypted -> ...";
			// 
			// _logTextBox
			// 
			_logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			_logTextBox.Location = new Point(24, 390);
			_logTextBox.Multiline = true;
			_logTextBox.Name = "_logTextBox";
			_logTextBox.ReadOnly = true;
			_logTextBox.ScrollBars = ScrollBars.Vertical;
			_logTextBox.Size = new Size(780, 180);
			_logTextBox.TabIndex = 11;
			// 
			// ManualEncryptionView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			Controls.Add(_logTextBox);
			Controls.Add(_pathHint);
			Controls.Add(_decryptButton);
			Controls.Add(_encryptButton);
			Controls.Add(_playfairRadio);
			Controls.Add(_pcbcOnlyRadio);
			Controls.Add(_rc6OnlyRadio);
			Controls.Add(_rc6PcbcRadio);
			Controls.Add(_passwordTextBox);
			Controls.Add(_dropZone);
			Controls.Add(_subtitle);
			Controls.Add(_title);
			Name = "ManualEncryptionView";
			Size = new Size(840, 620);
			_dropZone.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label _title;
		private Label _subtitle;
		private Panel _dropZone;
		private Label _dropZoneText;
		private TextBox _passwordTextBox;
		private RadioButton _rc6PcbcRadio;
		private RadioButton _rc6OnlyRadio;
		private RadioButton _pcbcOnlyRadio;
		private RadioButton _playfairRadio;
		private Button _encryptButton;
		private Button _decryptButton;
		private Label _pathHint;
		private TextBox _logTextBox;
	}
}
