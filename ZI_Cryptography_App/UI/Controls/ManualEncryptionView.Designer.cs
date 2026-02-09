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
			_togglePasswordVisibilityButton = new Button();
			_encryptOutputLabel = new Label();
			_encryptOutputTextBox = new TextBox();
			_browseEncryptOutputButton = new Button();
			_decryptOutputLabel = new Label();
			_decryptOutputTextBox = new TextBox();
			_browseDecryptOutputButton = new Button();
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
			_title.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
			_title.ForeColor = Color.FromArgb(33, 37, 41);
			_title.Location = new Point(24, 16);
			_title.Name = "_title";
			_title.Size = new Size(306, 37);
			_title.TabIndex = 0;
			_title.Text = "Manual Encrypt / Decrypt";
			// 
			// _subtitle
			// 
			_subtitle.AutoSize = true;
			_subtitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			_subtitle.ForeColor = Color.FromArgb(96, 110, 126);
			_subtitle.Location = new Point(26, 58);
			_subtitle.Name = "_subtitle";
			_subtitle.Size = new Size(331, 17);
			_subtitle.TabIndex = 1;
			_subtitle.Text = "Encrypt or decrypt any file manually using RC6, PCBC, or Playfair.";
			// 
			// _dropZone
			// 
			_dropZone.AllowDrop = true;
			_dropZone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_dropZone.BackColor = Color.White;
			_dropZone.BorderStyle = BorderStyle.FixedSingle;
			_dropZone.Controls.Add(_dropZoneText);
			_dropZone.Location = new Point(24, 92);
			_dropZone.Name = "_dropZone";
			_dropZone.Size = new Size(780, 96);
			_dropZone.TabIndex = 2;
			_dropZone.Click += DropZone_Click;
			_dropZone.DragDrop += DropZone_DragDrop;
			_dropZone.DragEnter += DropZone_DragEnter;
			// 
			// _dropZoneText
			// 
			_dropZoneText.Dock = DockStyle.Fill;
			_dropZoneText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
			_dropZoneText.ForeColor = Color.FromArgb(96, 110, 126);
			_dropZoneText.Location = new Point(0, 0);
			_dropZoneText.Name = "_dropZoneText";
			_dropZoneText.Size = new Size(778, 94);
			_dropZoneText.TabIndex = 0;
			_dropZoneText.Text = "Drag and drop a file here, or click to browse.";
			_dropZoneText.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// _passwordTextBox
			// 
			_passwordTextBox.BackColor = Color.White;
			_passwordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
			_passwordTextBox.ForeColor = Color.FromArgb(33, 37, 41);
			_passwordTextBox.Location = new Point(24, 204);
			_passwordTextBox.Name = "_passwordTextBox";
			_passwordTextBox.PlaceholderText = "Password";
			_passwordTextBox.Size = new Size(734, 23);
			_passwordTextBox.TabIndex = 3;
			_passwordTextBox.UseSystemPasswordChar = true;
			// 
			// _togglePasswordVisibilityButton
			// 
			_togglePasswordVisibilityButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			_togglePasswordVisibilityButton.BackColor = Color.FromArgb(233, 238, 246);
			_togglePasswordVisibilityButton.FlatAppearance.BorderSize = 0;
			_togglePasswordVisibilityButton.FlatStyle = FlatStyle.Flat;
			_togglePasswordVisibilityButton.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
			_togglePasswordVisibilityButton.ForeColor = Color.FromArgb(45, 52, 59);
			_togglePasswordVisibilityButton.Location = new Point(764, 202);
			_togglePasswordVisibilityButton.Name = "_togglePasswordVisibilityButton";
			_togglePasswordVisibilityButton.Size = new Size(40, 27);
			_togglePasswordVisibilityButton.TabIndex = 4;
			_togglePasswordVisibilityButton.Text = "\uD83D\uDD12";
			_togglePasswordVisibilityButton.UseVisualStyleBackColor = false;
			_togglePasswordVisibilityButton.Click += TogglePasswordVisibilityButton_Click;
			// 
			// _encryptOutputLabel
			// 
			_encryptOutputLabel.AutoSize = true;
			_encryptOutputLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			_encryptOutputLabel.ForeColor = Color.FromArgb(96, 110, 126);
			_encryptOutputLabel.Location = new Point(24, 240);
			_encryptOutputLabel.Name = "_encryptOutputLabel";
			_encryptOutputLabel.Size = new Size(86, 15);
			_encryptOutputLabel.TabIndex = 5;
			_encryptOutputLabel.Text = "Encrypt output";
			// 
			// _encryptOutputTextBox
			// 
			_encryptOutputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_encryptOutputTextBox.BackColor = Color.White;
			_encryptOutputTextBox.BorderStyle = BorderStyle.FixedSingle;
			_encryptOutputTextBox.ForeColor = Color.FromArgb(33, 37, 41);
			_encryptOutputTextBox.Location = new Point(140, 237);
			_encryptOutputTextBox.Name = "_encryptOutputTextBox";
			_encryptOutputTextBox.Size = new Size(560, 23);
			_encryptOutputTextBox.TabIndex = 6;
			// 
			// _browseEncryptOutputButton
			// 
			_browseEncryptOutputButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			_browseEncryptOutputButton.BackColor = Color.FromArgb(233, 238, 246);
			_browseEncryptOutputButton.FlatAppearance.BorderSize = 0;
			_browseEncryptOutputButton.FlatStyle = FlatStyle.Flat;
			_browseEncryptOutputButton.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			_browseEncryptOutputButton.ForeColor = Color.FromArgb(45, 52, 59);
			_browseEncryptOutputButton.Location = new Point(706, 234);
			_browseEncryptOutputButton.Name = "_browseEncryptOutputButton";
			_browseEncryptOutputButton.Size = new Size(98, 29);
			_browseEncryptOutputButton.TabIndex = 7;
			_browseEncryptOutputButton.Text = "Browse...";
			_browseEncryptOutputButton.UseVisualStyleBackColor = false;
			_browseEncryptOutputButton.Click += BrowseEncryptOutputButton_Click;
			// 
			// _decryptOutputLabel
			// 
			_decryptOutputLabel.AutoSize = true;
			_decryptOutputLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			_decryptOutputLabel.ForeColor = Color.FromArgb(96, 110, 126);
			_decryptOutputLabel.Location = new Point(24, 274);
			_decryptOutputLabel.Name = "_decryptOutputLabel";
			_decryptOutputLabel.Size = new Size(89, 15);
			_decryptOutputLabel.TabIndex = 8;
			_decryptOutputLabel.Text = "Decrypt output";
			// 
			// _decryptOutputTextBox
			// 
			_decryptOutputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_decryptOutputTextBox.BackColor = Color.White;
			_decryptOutputTextBox.BorderStyle = BorderStyle.FixedSingle;
			_decryptOutputTextBox.ForeColor = Color.FromArgb(33, 37, 41);
			_decryptOutputTextBox.Location = new Point(140, 271);
			_decryptOutputTextBox.Name = "_decryptOutputTextBox";
			_decryptOutputTextBox.Size = new Size(560, 23);
			_decryptOutputTextBox.TabIndex = 9;
			// 
			// _browseDecryptOutputButton
			// 
			_browseDecryptOutputButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			_browseDecryptOutputButton.BackColor = Color.FromArgb(233, 238, 246);
			_browseDecryptOutputButton.FlatAppearance.BorderSize = 0;
			_browseDecryptOutputButton.FlatStyle = FlatStyle.Flat;
			_browseDecryptOutputButton.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			_browseDecryptOutputButton.ForeColor = Color.FromArgb(45, 52, 59);
			_browseDecryptOutputButton.Location = new Point(706, 268);
			_browseDecryptOutputButton.Name = "_browseDecryptOutputButton";
			_browseDecryptOutputButton.Size = new Size(98, 29);
			_browseDecryptOutputButton.TabIndex = 10;
			_browseDecryptOutputButton.Text = "Browse...";
			_browseDecryptOutputButton.UseVisualStyleBackColor = false;
			_browseDecryptOutputButton.Click += BrowseDecryptOutputButton_Click;
			// 
			// _rc6PcbcRadio
			// 
			_rc6PcbcRadio.AutoSize = true;
			_rc6PcbcRadio.Checked = true;
			_rc6PcbcRadio.ForeColor = Color.FromArgb(45, 52, 59);
			_rc6PcbcRadio.Location = new Point(24, 308);
			_rc6PcbcRadio.Name = "_rc6PcbcRadio";
			_rc6PcbcRadio.Size = new Size(86, 19);
			_rc6PcbcRadio.TabIndex = 11;
			_rc6PcbcRadio.TabStop = true;
			_rc6PcbcRadio.Text = "RC6 + PCBC";
			_rc6PcbcRadio.UseVisualStyleBackColor = true;
			// 
			// _rc6OnlyRadio
			// 
			_rc6OnlyRadio.AutoSize = true;
			_rc6OnlyRadio.ForeColor = Color.FromArgb(45, 52, 59);
			_rc6OnlyRadio.Location = new Point(130, 308);
			_rc6OnlyRadio.Name = "_rc6OnlyRadio";
			_rc6OnlyRadio.Size = new Size(72, 19);
			_rc6OnlyRadio.TabIndex = 12;
			_rc6OnlyRadio.Text = "RC6 only";
			_rc6OnlyRadio.UseVisualStyleBackColor = true;
			// 
			// _pcbcOnlyRadio
			// 
			_pcbcOnlyRadio.AutoSize = true;
			_pcbcOnlyRadio.ForeColor = Color.FromArgb(45, 52, 59);
			_pcbcOnlyRadio.Location = new Point(220, 308);
			_pcbcOnlyRadio.Name = "_pcbcOnlyRadio";
			_pcbcOnlyRadio.Size = new Size(80, 19);
			_pcbcOnlyRadio.TabIndex = 13;
			_pcbcOnlyRadio.Text = "PCBC only";
			_pcbcOnlyRadio.UseVisualStyleBackColor = true;
			// 
			// _playfairRadio
			// 
			_playfairRadio.AutoSize = true;
			_playfairRadio.ForeColor = Color.FromArgb(45, 52, 59);
			_playfairRadio.Location = new Point(320, 308);
			_playfairRadio.Name = "_playfairRadio";
			_playfairRadio.Size = new Size(109, 19);
			_playfairRadio.TabIndex = 14;
			_playfairRadio.Text = "Playfair (txt only)";
			_playfairRadio.UseVisualStyleBackColor = true;
			// 
			// _encryptButton
			// 
			_encryptButton.BackColor = Color.FromArgb(42, 98, 186);
			_encryptButton.FlatAppearance.BorderSize = 0;
			_encryptButton.FlatStyle = FlatStyle.Flat;
			_encryptButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			_encryptButton.ForeColor = Color.White;
			_encryptButton.Location = new Point(24, 340);
			_encryptButton.Name = "_encryptButton";
			_encryptButton.Size = new Size(130, 38);
			_encryptButton.TabIndex = 15;
			_encryptButton.Text = "Encrypt";
			_encryptButton.UseVisualStyleBackColor = false;
			_encryptButton.Click += EncryptButton_Click;
			// 
			// _decryptButton
			// 
			_decryptButton.BackColor = Color.FromArgb(233, 238, 246);
			_decryptButton.FlatAppearance.BorderSize = 0;
			_decryptButton.FlatStyle = FlatStyle.Flat;
			_decryptButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			_decryptButton.ForeColor = Color.FromArgb(45, 52, 59);
			_decryptButton.Location = new Point(170, 340);
			_decryptButton.Name = "_decryptButton";
			_decryptButton.Size = new Size(130, 38);
			_decryptButton.TabIndex = 16;
			_decryptButton.Text = "Decrypt";
			_decryptButton.UseVisualStyleBackColor = false;
			_decryptButton.Click += DecryptButton_Click;
			// 
			// _pathHint
			// 
			_pathHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_pathHint.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			_pathHint.ForeColor = Color.FromArgb(96, 110, 126);
			_pathHint.Location = new Point(24, 384);
			_pathHint.Name = "_pathHint";
			_pathHint.Size = new Size(780, 32);
			_pathHint.TabIndex = 17;
			_pathHint.Text = "Active output folders";
			// 
			// _logTextBox
			// 
			_logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			_logTextBox.BackColor = Color.White;
			_logTextBox.BorderStyle = BorderStyle.FixedSingle;
			_logTextBox.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			_logTextBox.ForeColor = Color.FromArgb(33, 37, 41);
			_logTextBox.Location = new Point(24, 420);
			_logTextBox.Multiline = true;
			_logTextBox.Name = "_logTextBox";
			_logTextBox.ReadOnly = true;
			_logTextBox.ScrollBars = ScrollBars.Vertical;
			_logTextBox.Size = new Size(780, 170);
			_logTextBox.TabIndex = 18;
			// 
			// ManualEncryptionView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = Color.FromArgb(247, 249, 252);
			Controls.Add(_logTextBox);
			Controls.Add(_pathHint);
			Controls.Add(_decryptButton);
			Controls.Add(_encryptButton);
			Controls.Add(_playfairRadio);
			Controls.Add(_pcbcOnlyRadio);
			Controls.Add(_rc6OnlyRadio);
			Controls.Add(_rc6PcbcRadio);
			Controls.Add(_browseDecryptOutputButton);
			Controls.Add(_decryptOutputTextBox);
			Controls.Add(_decryptOutputLabel);
			Controls.Add(_browseEncryptOutputButton);
			Controls.Add(_encryptOutputTextBox);
			Controls.Add(_encryptOutputLabel);
			Controls.Add(_togglePasswordVisibilityButton);
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
		private Button _togglePasswordVisibilityButton;
		private Label _encryptOutputLabel;
		private TextBox _encryptOutputTextBox;
		private Button _browseEncryptOutputButton;
		private Label _decryptOutputLabel;
		private TextBox _decryptOutputTextBox;
		private Button _browseDecryptOutputButton;
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

