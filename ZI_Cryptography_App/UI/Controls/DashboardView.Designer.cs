namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	partial class DashboardView
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
			panelCard = new Panel();
			btnToggleFSW = new Button();
			rbAutoPlayfair = new RadioButton();
			rbAutoPcbcOnly = new RadioButton();
			rbAutoRc6Only = new RadioButton();
			rbAutoRc6 = new RadioButton();
			lblAlgorithm = new Label();
			lblStatus = new Label();
			lblStatusTitle = new Label();
			txtAutoPassword = new TextBox();
			lblPassword = new Label();
			btnSelectFolder = new Button();
			txtFolderPath = new TextBox();
			lblFolder = new Label();
			lstDashboardLogs = new ListBox();
			lblLogTitle = new Label();
			panelCard.SuspendLayout();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
			lblTitle.ForeColor = Color.FromArgb(241, 245, 249);
			lblTitle.Location = new Point(24, 18);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(381, 41);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "File Watcher & Auto Encrypt";
			// 
			// panelCard
			// 
			panelCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panelCard.BackColor = Color.FromArgb(15, 23, 42);
			panelCard.Controls.Add(btnToggleFSW);
			panelCard.Controls.Add(rbAutoPlayfair);
			panelCard.Controls.Add(rbAutoPcbcOnly);
			panelCard.Controls.Add(rbAutoRc6Only);
			panelCard.Controls.Add(rbAutoRc6);
			panelCard.Controls.Add(lblAlgorithm);
			panelCard.Controls.Add(lblStatus);
			panelCard.Controls.Add(lblStatusTitle);
			panelCard.Controls.Add(txtAutoPassword);
			panelCard.Controls.Add(lblPassword);
			panelCard.Controls.Add(btnSelectFolder);
			panelCard.Controls.Add(txtFolderPath);
			panelCard.Controls.Add(lblFolder);
			panelCard.Location = new Point(24, 74);
			panelCard.Name = "panelCard";
			panelCard.Size = new Size(788, 206);
			panelCard.TabIndex = 1;
			// 
			// btnToggleFSW
			// 
			btnToggleFSW.BackColor = Color.FromArgb(14, 116, 144);
			btnToggleFSW.FlatAppearance.BorderSize = 0;
			btnToggleFSW.FlatStyle = FlatStyle.Flat;
			btnToggleFSW.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnToggleFSW.ForeColor = Color.White;
			btnToggleFSW.Location = new Point(633, 152);
			btnToggleFSW.Name = "btnToggleFSW";
			btnToggleFSW.Size = new Size(140, 38);
			btnToggleFSW.TabIndex = 7;
			btnToggleFSW.Text = "Start Monitoring";
			btnToggleFSW.UseVisualStyleBackColor = false;
			btnToggleFSW.Click += btnToggleFSW_Click;
			// 
			// rbAutoPlayfair
			// 
			rbAutoPlayfair.AutoSize = true;
			rbAutoPlayfair.ForeColor = Color.FromArgb(226, 232, 240);
			rbAutoPlayfair.Location = new Point(473, 116);
			rbAutoPlayfair.Name = "rbAutoPlayfair";
			rbAutoPlayfair.Size = new Size(115, 19);
			rbAutoPlayfair.TabIndex = 12;
			rbAutoPlayfair.Text = "Playfair (txt only)";
			rbAutoPlayfair.UseVisualStyleBackColor = true;
			// 
			// rbAutoPcbcOnly
			// 
			rbAutoPcbcOnly.AutoSize = true;
			rbAutoPcbcOnly.ForeColor = Color.FromArgb(226, 232, 240);
			rbAutoPcbcOnly.Location = new Point(365, 116);
			rbAutoPcbcOnly.Name = "rbAutoPcbcOnly";
			rbAutoPcbcOnly.Size = new Size(81, 19);
			rbAutoPcbcOnly.TabIndex = 11;
			rbAutoPcbcOnly.Text = "PCBC only";
			rbAutoPcbcOnly.UseVisualStyleBackColor = true;
			// 
			// rbAutoRc6Only
			// 
			rbAutoRc6Only.AutoSize = true;
			rbAutoRc6Only.ForeColor = Color.FromArgb(226, 232, 240);
			rbAutoRc6Only.Location = new Point(267, 116);
			rbAutoRc6Only.Name = "rbAutoRc6Only";
			rbAutoRc6Only.Size = new Size(72, 19);
			rbAutoRc6Only.TabIndex = 10;
			rbAutoRc6Only.Text = "RC6 only";
			rbAutoRc6Only.UseVisualStyleBackColor = true;
			// 
			// rbAutoRc6
			// 
			rbAutoRc6.AutoSize = true;
			rbAutoRc6.Checked = true;
			rbAutoRc6.ForeColor = Color.FromArgb(226, 232, 240);
			rbAutoRc6.Location = new Point(152, 116);
			rbAutoRc6.Name = "rbAutoRc6";
			rbAutoRc6.Size = new Size(90, 19);
			rbAutoRc6.TabIndex = 9;
			rbAutoRc6.TabStop = true;
			rbAutoRc6.Text = "RC6 + PCBC";
			rbAutoRc6.UseVisualStyleBackColor = true;
			// 
			// lblAlgorithm
			// 
			lblAlgorithm.AutoSize = true;
			lblAlgorithm.Font = new Font("Segoe UI", 10F);
			lblAlgorithm.ForeColor = Color.FromArgb(148, 163, 184);
			lblAlgorithm.Location = new Point(21, 114);
			lblAlgorithm.Name = "lblAlgorithm";
			lblAlgorithm.Size = new Size(70, 19);
			lblAlgorithm.TabIndex = 8;
			lblAlgorithm.Text = "Algorithm";
			// 
			// lblStatus
			// 
			lblStatus.AutoSize = true;
			lblStatus.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
			lblStatus.Location = new Point(406, 15);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new Size(135, 37);
			lblStatus.TabIndex = 6;
			lblStatus.Text = "STOPPED";
			// 
			// lblStatusTitle
			// 
			lblStatusTitle.AutoSize = true;
			lblStatusTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblStatusTitle.ForeColor = Color.FromArgb(148, 163, 184);
			lblStatusTitle.Location = new Point(174, 15);
			lblStatusTitle.Name = "lblStatusTitle";
			lblStatusTitle.Size = new Size(235, 37);
			lblStatusTitle.TabIndex = 5;
			lblStatusTitle.Text = "Monitoring Status:";
			// 
			// txtAutoPassword
			// 
			txtAutoPassword.BackColor = Color.FromArgb(30, 41, 59);
			txtAutoPassword.BorderStyle = BorderStyle.FixedSingle;
			txtAutoPassword.ForeColor = Color.White;
			txtAutoPassword.Location = new Point(152, 154);
			txtAutoPassword.Name = "txtAutoPassword";
			txtAutoPassword.Size = new Size(460, 23);
			txtAutoPassword.TabIndex = 4;
			txtAutoPassword.UseSystemPasswordChar = true;
			// 
			// lblPassword
			// 
			lblPassword.AutoSize = true;
			lblPassword.Font = new Font("Segoe UI", 10F);
			lblPassword.ForeColor = Color.FromArgb(148, 163, 184);
			lblPassword.Location = new Point(21, 156);
			lblPassword.Name = "lblPassword";
			lblPassword.Size = new Size(127, 19);
			lblPassword.TabIndex = 3;
			lblPassword.Text = "Auto Key Password";
			// 
			// btnSelectFolder
			// 
			btnSelectFolder.BackColor = Color.FromArgb(30, 64, 175);
			btnSelectFolder.FlatAppearance.BorderSize = 0;
			btnSelectFolder.FlatStyle = FlatStyle.Flat;
			btnSelectFolder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnSelectFolder.ForeColor = Color.White;
			btnSelectFolder.Location = new Point(633, 72);
			btnSelectFolder.Name = "btnSelectFolder";
			btnSelectFolder.Size = new Size(140, 38);
			btnSelectFolder.TabIndex = 2;
			btnSelectFolder.Text = "Select Folder";
			btnSelectFolder.UseVisualStyleBackColor = false;
			btnSelectFolder.Click += btnSelectFolder_Click;
			// 
			// txtFolderPath
			// 
			txtFolderPath.BackColor = Color.FromArgb(30, 41, 59);
			txtFolderPath.BorderStyle = BorderStyle.FixedSingle;
			txtFolderPath.ForeColor = Color.White;
			txtFolderPath.Location = new Point(152, 76);
			txtFolderPath.Name = "txtFolderPath";
			txtFolderPath.ReadOnly = true;
			txtFolderPath.Size = new Size(460, 23);
			txtFolderPath.TabIndex = 1;
			// 
			// lblFolder
			// 
			lblFolder.AutoSize = true;
			lblFolder.Font = new Font("Segoe UI", 10F);
			lblFolder.ForeColor = Color.FromArgb(148, 163, 184);
			lblFolder.Location = new Point(21, 78);
			lblFolder.Name = "lblFolder";
			lblFolder.Size = new Size(106, 19);
			lblFolder.TabIndex = 0;
			lblFolder.Text = "Monitored Path";
			// 
			// lstDashboardLogs
			// 
			lstDashboardLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstDashboardLogs.BackColor = Color.FromArgb(15, 23, 42);
			lstDashboardLogs.BorderStyle = BorderStyle.None;
			lstDashboardLogs.Font = new Font("Consolas", 10F);
			lstDashboardLogs.ForeColor = Color.FromArgb(226, 232, 240);
			lstDashboardLogs.FormattingEnabled = true;
			lstDashboardLogs.Location = new Point(24, 319);
			lstDashboardLogs.Name = "lstDashboardLogs";
			lstDashboardLogs.Size = new Size(788, 195);
			lstDashboardLogs.TabIndex = 2;
			// 
			// lblLogTitle
			// 
			lblLogTitle.AutoSize = true;
			lblLogTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			lblLogTitle.ForeColor = Color.FromArgb(148, 163, 184);
			lblLogTitle.Location = new Point(24, 291);
			lblLogTitle.Name = "lblLogTitle";
			lblLogTitle.Size = new Size(133, 21);
			lblLogTitle.TabIndex = 3;
			lblLogTitle.Text = "Realtime Activity";
			// 
			// DashboardView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = Color.FromArgb(2, 6, 23);
			Controls.Add(lblLogTitle);
			Controls.Add(lstDashboardLogs);
			Controls.Add(panelCard);
			Controls.Add(lblTitle);
			Name = "DashboardView";
			Size = new Size(840, 524);
			panelCard.ResumeLayout(false);
			panelCard.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblTitle;
		private Panel panelCard;
		private Button btnToggleFSW;
		private RadioButton rbAutoPlayfair;
		private RadioButton rbAutoPcbcOnly;
		private RadioButton rbAutoRc6Only;
		private RadioButton rbAutoRc6;
		private Label lblAlgorithm;
		private Label lblStatus;
		private Label lblStatusTitle;
		private TextBox txtAutoPassword;
		private Label lblPassword;
		private Button btnSelectFolder;
		private TextBox txtFolderPath;
		private Label lblFolder;
		private ListBox lstDashboardLogs;
		private Label lblLogTitle;
	}
}
