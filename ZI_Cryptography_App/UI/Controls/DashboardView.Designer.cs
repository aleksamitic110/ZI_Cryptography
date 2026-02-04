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
			lblTitle.Size = new Size(393, 41);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "File Watcher & Auto Encrypt";
			// 
			// panelCard
			// 
			panelCard.BackColor = Color.FromArgb(15, 23, 42);
			panelCard.Controls.Add(btnToggleFSW);
			panelCard.Controls.Add(lblStatus);
			panelCard.Controls.Add(lblStatusTitle);
			panelCard.Controls.Add(txtAutoPassword);
			panelCard.Controls.Add(lblPassword);
			panelCard.Controls.Add(btnSelectFolder);
			panelCard.Controls.Add(txtFolderPath);
			panelCard.Controls.Add(lblFolder);
			panelCard.Location = new Point(24, 74);
			panelCard.Name = "panelCard";
			panelCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panelCard.Size = new Size(788, 176);
			panelCard.TabIndex = 1;
			// 
			// btnToggleFSW
			// 
			btnToggleFSW.BackColor = Color.FromArgb(14, 116, 144);
			btnToggleFSW.FlatAppearance.BorderSize = 0;
			btnToggleFSW.FlatStyle = FlatStyle.Flat;
			btnToggleFSW.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnToggleFSW.ForeColor = Color.White;
			btnToggleFSW.Location = new Point(633, 122);
			btnToggleFSW.Name = "btnToggleFSW";
			btnToggleFSW.Size = new Size(140, 38);
			btnToggleFSW.TabIndex = 7;
			btnToggleFSW.Text = "Start Monitoring";
			btnToggleFSW.UseVisualStyleBackColor = false;
			btnToggleFSW.Click += btnToggleFSW_Click;
			// 
			// lblStatus
			// 
			lblStatus.AutoSize = true;
			lblStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
			lblStatus.Location = new Point(622, 30);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new Size(77, 20);
			lblStatus.TabIndex = 6;
			lblStatus.Text = "STOPPED";
			// 
			// lblStatusTitle
			// 
			lblStatusTitle.AutoSize = true;
			lblStatusTitle.Font = new Font("Segoe UI", 10F);
			lblStatusTitle.ForeColor = Color.FromArgb(148, 163, 184);
			lblStatusTitle.Location = new Point(484, 31);
			lblStatusTitle.Name = "lblStatusTitle";
			lblStatusTitle.Size = new Size(128, 19);
			lblStatusTitle.TabIndex = 5;
			lblStatusTitle.Text = "Monitoring Status:";
			// 
			// txtAutoPassword
			// 
			txtAutoPassword.BackColor = Color.FromArgb(30, 41, 59);
			txtAutoPassword.BorderStyle = BorderStyle.FixedSingle;
			txtAutoPassword.ForeColor = Color.White;
			txtAutoPassword.Location = new Point(152, 124);
			txtAutoPassword.Name = "txtAutoPassword";
			txtAutoPassword.Size = new Size(321, 23);
			txtAutoPassword.TabIndex = 4;
			txtAutoPassword.UseSystemPasswordChar = true;
			// 
			// lblPassword
			// 
			lblPassword.AutoSize = true;
			lblPassword.Font = new Font("Segoe UI", 10F);
			lblPassword.ForeColor = Color.FromArgb(148, 163, 184);
			lblPassword.Location = new Point(21, 126);
			lblPassword.Name = "lblPassword";
			lblPassword.Size = new Size(125, 19);
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
			lblFolder.Size = new Size(108, 19);
			lblFolder.TabIndex = 0;
			lblFolder.Text = "Monitored Path";
			// 
			// lstDashboardLogs
			// 
			lstDashboardLogs.BackColor = Color.FromArgb(15, 23, 42);
			lstDashboardLogs.BorderStyle = BorderStyle.None;
			lstDashboardLogs.Font = new Font("Consolas", 10F);
			lstDashboardLogs.ForeColor = Color.FromArgb(226, 232, 240);
			lstDashboardLogs.FormattingEnabled = true;
			lstDashboardLogs.ItemHeight = 15;
			lstDashboardLogs.Location = new Point(24, 289);
			lstDashboardLogs.Name = "lstDashboardLogs";
			lstDashboardLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstDashboardLogs.Size = new Size(788, 210);
			lstDashboardLogs.TabIndex = 2;
			// 
			// lblLogTitle
			// 
			lblLogTitle.AutoSize = true;
			lblLogTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			lblLogTitle.ForeColor = Color.FromArgb(148, 163, 184);
			lblLogTitle.Location = new Point(24, 261);
			lblLogTitle.Name = "lblLogTitle";
			lblLogTitle.Size = new Size(136, 21);
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
