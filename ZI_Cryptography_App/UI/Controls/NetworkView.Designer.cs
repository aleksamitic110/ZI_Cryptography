namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	partial class NetworkView
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
			groupSender = new GroupBox();
			btnSend = new Button();
			txtSendPassword = new TextBox();
			btnToggleSendPasswordVisibility = new Button();
			lblSendPassword = new Label();
			rbSendPlayfair = new RadioButton();
			rbSendPcbcOnly = new RadioButton();
			rbSendRc6Only = new RadioButton();
			rbSendRc6 = new RadioButton();
			lblSendAlgorithm = new Label();
			txtTargetPort = new TextBox();
			lblTargetPort = new Label();
			txtTargetIp = new TextBox();
			lblTargetIp = new Label();
			btnBrowseFile = new Button();
			txtSelectedFile = new TextBox();
			lblSelectedFile = new Label();
			groupReceiver = new GroupBox();
			lblLocalIps = new Label();
			btnStartStopReceiver = new Button();
			txtReceivePassword = new TextBox();
			btnToggleReceivePasswordVisibility = new Button();
			lblReceivePassword = new Label();
			txtListenPort = new TextBox();
			lblListenPort = new Label();
			lstNetworkLogs = new ListBox();
			lblLogs = new Label();
			groupSender.SuspendLayout();
			groupReceiver.SuspendLayout();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
			lblTitle.Location = new Point(24, 16);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(194, 37);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "\uD83C\uDF10 TCP Networking";
			// 
			// groupSender
			// 
			groupSender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupSender.BackColor = Color.White;
			groupSender.Controls.Add(btnSend);
			groupSender.Controls.Add(txtSendPassword);
			groupSender.Controls.Add(btnToggleSendPasswordVisibility);
			groupSender.Controls.Add(lblSendPassword);
			groupSender.Controls.Add(rbSendPlayfair);
			groupSender.Controls.Add(rbSendPcbcOnly);
			groupSender.Controls.Add(rbSendRc6Only);
			groupSender.Controls.Add(rbSendRc6);
			groupSender.Controls.Add(lblSendAlgorithm);
			groupSender.Controls.Add(txtTargetPort);
			groupSender.Controls.Add(lblTargetPort);
			groupSender.Controls.Add(txtTargetIp);
			groupSender.Controls.Add(lblTargetIp);
			groupSender.Controls.Add(btnBrowseFile);
			groupSender.Controls.Add(txtSelectedFile);
			groupSender.Controls.Add(lblSelectedFile);
			groupSender.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			groupSender.ForeColor = Color.FromArgb(45, 52, 59);
			groupSender.Location = new Point(24, 66);
			groupSender.Name = "groupSender";
			groupSender.Size = new Size(788, 212);
			groupSender.TabIndex = 1;
			groupSender.TabStop = false;
			groupSender.Text = "\uD83D\uDCE4 Sender";
			// 
			// btnSend
			// 
			btnSend.BackColor = Color.FromArgb(42, 98, 186);
			btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnSend.FlatAppearance.BorderSize = 0;
			btnSend.FlatStyle = FlatStyle.Flat;
			btnSend.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnSend.ForeColor = Color.White;
			btnSend.Location = new Point(650, 165);
			btnSend.Name = "btnSend";
			btnSend.Size = new Size(120, 32);
			btnSend.TabIndex = 9;
			btnSend.Text = "\uD83D\uDCE4 Send";
			btnSend.UseVisualStyleBackColor = false;
			btnSend.Click += btnSend_Click;
			// 
			// txtSendPassword
			// 
			txtSendPassword.BackColor = Color.White;
			txtSendPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtSendPassword.BorderStyle = BorderStyle.FixedSingle;
			txtSendPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtSendPassword.ForeColor = Color.FromArgb(33, 37, 41);
			txtSendPassword.Location = new Point(120, 170);
			txtSendPassword.Name = "txtSendPassword";
			txtSendPassword.PlaceholderText = "Required if input is not .locked";
			txtSendPassword.Size = new Size(476, 23);
			txtSendPassword.TabIndex = 8;
			txtSendPassword.UseSystemPasswordChar = true;
			// 
			// btnToggleSendPasswordVisibility
			// 
			btnToggleSendPasswordVisibility.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnToggleSendPasswordVisibility.BackColor = Color.FromArgb(233, 238, 246);
			btnToggleSendPasswordVisibility.FlatAppearance.BorderSize = 0;
			btnToggleSendPasswordVisibility.FlatStyle = FlatStyle.Flat;
			btnToggleSendPasswordVisibility.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnToggleSendPasswordVisibility.ForeColor = Color.FromArgb(45, 52, 59);
			btnToggleSendPasswordVisibility.Location = new Point(604, 168);
			btnToggleSendPasswordVisibility.Name = "btnToggleSendPasswordVisibility";
			btnToggleSendPasswordVisibility.Size = new Size(36, 27);
			btnToggleSendPasswordVisibility.TabIndex = 15;
			btnToggleSendPasswordVisibility.Text = "\uD83D\uDD12";
			btnToggleSendPasswordVisibility.UseVisualStyleBackColor = false;
			btnToggleSendPasswordVisibility.Click += btnToggleSendPasswordVisibility_Click;
			// 
			// lblSendPassword
			// 
			lblSendPassword.AutoSize = true;
			lblSendPassword.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSendPassword.ForeColor = Color.FromArgb(96, 110, 126);
			lblSendPassword.Location = new Point(16, 172);
			lblSendPassword.Name = "lblSendPassword";
			lblSendPassword.Size = new Size(60, 15);
			lblSendPassword.TabIndex = 7;
			lblSendPassword.Text = "\uD83D\uDD11 Password:";
			// 
			// rbSendPlayfair
			// 
			rbSendPlayfair.AutoSize = true;
			rbSendPlayfair.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			rbSendPlayfair.ForeColor = Color.FromArgb(45, 52, 59);
			rbSendPlayfair.Location = new Point(420, 127);
			rbSendPlayfair.Name = "rbSendPlayfair";
			rbSendPlayfair.Size = new Size(115, 19);
			rbSendPlayfair.TabIndex = 14;
			rbSendPlayfair.Text = "Playfair (txt only)";
			rbSendPlayfair.UseVisualStyleBackColor = true;
			// 
			// rbSendPcbcOnly
			// 
			rbSendPcbcOnly.AutoSize = true;
			rbSendPcbcOnly.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			rbSendPcbcOnly.ForeColor = Color.FromArgb(45, 52, 59);
			rbSendPcbcOnly.Location = new Point(325, 127);
			rbSendPcbcOnly.Name = "rbSendPcbcOnly";
			rbSendPcbcOnly.Size = new Size(81, 19);
			rbSendPcbcOnly.TabIndex = 13;
			rbSendPcbcOnly.Text = "PCBC only";
			rbSendPcbcOnly.UseVisualStyleBackColor = true;
			// 
			// rbSendRc6Only
			// 
			rbSendRc6Only.AutoSize = true;
			rbSendRc6Only.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			rbSendRc6Only.ForeColor = Color.FromArgb(45, 52, 59);
			rbSendRc6Only.Location = new Point(230, 127);
			rbSendRc6Only.Name = "rbSendRc6Only";
			rbSendRc6Only.Size = new Size(72, 19);
			rbSendRc6Only.TabIndex = 12;
			rbSendRc6Only.Text = "RC6 only";
			rbSendRc6Only.UseVisualStyleBackColor = true;
			// 
			// rbSendRc6
			// 
			rbSendRc6.AutoSize = true;
			rbSendRc6.Checked = true;
			rbSendRc6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			rbSendRc6.ForeColor = Color.FromArgb(45, 52, 59);
			rbSendRc6.Location = new Point(120, 127);
			rbSendRc6.Name = "rbSendRc6";
			rbSendRc6.Size = new Size(90, 19);
			rbSendRc6.TabIndex = 11;
			rbSendRc6.TabStop = true;
			rbSendRc6.Text = "RC6 + PCBC";
			rbSendRc6.UseVisualStyleBackColor = true;
			// 
			// lblSendAlgorithm
			// 
			lblSendAlgorithm.AutoSize = true;
			lblSendAlgorithm.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSendAlgorithm.ForeColor = Color.FromArgb(96, 110, 126);
			lblSendAlgorithm.Location = new Point(16, 127);
			lblSendAlgorithm.Name = "lblSendAlgorithm";
			lblSendAlgorithm.Size = new Size(64, 15);
			lblSendAlgorithm.TabIndex = 10;
			lblSendAlgorithm.Text = "\u2699 Algorithm:";
			// 
			// txtTargetPort
			// 
			txtTargetPort.BackColor = Color.White;
			txtTargetPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			txtTargetPort.BorderStyle = BorderStyle.FixedSingle;
			txtTargetPort.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtTargetPort.ForeColor = Color.FromArgb(33, 37, 41);
			txtTargetPort.Location = new Point(555, 86);
			txtTargetPort.Name = "txtTargetPort";
			txtTargetPort.Size = new Size(215, 23);
			txtTargetPort.TabIndex = 6;
			// 
			// lblTargetPort
			// 
			lblTargetPort.AutoSize = true;
			lblTargetPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lblTargetPort.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblTargetPort.ForeColor = Color.FromArgb(96, 110, 126);
			lblTargetPort.Location = new Point(474, 89);
			lblTargetPort.Name = "lblTargetPort";
			lblTargetPort.Size = new Size(67, 15);
			lblTargetPort.TabIndex = 5;
			lblTargetPort.Text = "Target Port:";
			// 
			// txtTargetIp
			// 
			txtTargetIp.BackColor = Color.White;
			txtTargetIp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtTargetIp.BorderStyle = BorderStyle.FixedSingle;
			txtTargetIp.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtTargetIp.ForeColor = Color.FromArgb(33, 37, 41);
			txtTargetIp.Location = new Point(120, 86);
			txtTargetIp.Name = "txtTargetIp";
			txtTargetIp.PlaceholderText = "Example: 192.168.1.15";
			txtTargetIp.Size = new Size(344, 23);
			txtTargetIp.TabIndex = 4;
			// 
			// lblTargetIp
			// 
			lblTargetIp.AutoSize = true;
			lblTargetIp.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblTargetIp.ForeColor = Color.FromArgb(96, 110, 126);
			lblTargetIp.Location = new Point(16, 89);
			lblTargetIp.Name = "lblTargetIp";
			lblTargetIp.Size = new Size(55, 15);
			lblTargetIp.TabIndex = 3;
			lblTargetIp.Text = "Target IP:";
			// 
			// btnBrowseFile
			// 
			btnBrowseFile.BackColor = Color.FromArgb(233, 238, 246);
			btnBrowseFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnBrowseFile.FlatAppearance.BorderSize = 0;
			btnBrowseFile.FlatStyle = FlatStyle.Flat;
			btnBrowseFile.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnBrowseFile.ForeColor = Color.FromArgb(45, 52, 59);
			btnBrowseFile.Location = new Point(650, 36);
			btnBrowseFile.Name = "btnBrowseFile";
			btnBrowseFile.Size = new Size(120, 32);
			btnBrowseFile.TabIndex = 2;
			btnBrowseFile.Text = "\uD83D\uDCC2 Browse";
			btnBrowseFile.UseVisualStyleBackColor = false;
			btnBrowseFile.Click += btnBrowseFile_Click;
			// 
			// txtSelectedFile
			// 
			txtSelectedFile.BackColor = Color.White;
			txtSelectedFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtSelectedFile.BorderStyle = BorderStyle.FixedSingle;
			txtSelectedFile.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtSelectedFile.ForeColor = Color.FromArgb(33, 37, 41);
			txtSelectedFile.Location = new Point(120, 40);
			txtSelectedFile.Name = "txtSelectedFile";
			txtSelectedFile.ReadOnly = true;
			txtSelectedFile.Size = new Size(520, 23);
			txtSelectedFile.TabIndex = 1;
			// 
			// lblSelectedFile
			// 
			lblSelectedFile.AutoSize = true;
			lblSelectedFile.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSelectedFile.ForeColor = Color.FromArgb(96, 110, 126);
			lblSelectedFile.Location = new Point(16, 42);
			lblSelectedFile.Name = "lblSelectedFile";
			lblSelectedFile.Size = new Size(73, 15);
			lblSelectedFile.TabIndex = 0;
			lblSelectedFile.Text = "\uD83D\uDCC4 Selected file:";
			// 
			// groupReceiver
			// 
			groupReceiver.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupReceiver.BackColor = Color.White;
			groupReceiver.Controls.Add(lblLocalIps);
			groupReceiver.Controls.Add(btnStartStopReceiver);
			groupReceiver.Controls.Add(txtReceivePassword);
			groupReceiver.Controls.Add(btnToggleReceivePasswordVisibility);
			groupReceiver.Controls.Add(lblReceivePassword);
			groupReceiver.Controls.Add(txtListenPort);
			groupReceiver.Controls.Add(lblListenPort);
			groupReceiver.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			groupReceiver.ForeColor = Color.FromArgb(45, 52, 59);
			groupReceiver.Location = new Point(24, 288);
			groupReceiver.Name = "groupReceiver";
			groupReceiver.Size = new Size(788, 142);
			groupReceiver.TabIndex = 2;
			groupReceiver.TabStop = false;
			groupReceiver.Text = "\uD83D\uDCE5 Receiver";
			// 
			// lblLocalIps
			// 
			lblLocalIps.AutoSize = true;
			lblLocalIps.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLocalIps.ForeColor = Color.FromArgb(67, 109, 165);
			lblLocalIps.Location = new Point(16, 33);
			lblLocalIps.Name = "lblLocalIps";
			lblLocalIps.Size = new Size(71, 15);
			lblLocalIps.TabIndex = 5;
			lblLocalIps.Text = "Local IPv4: -";
			// 
			// btnStartStopReceiver
			// 
			btnStartStopReceiver.BackColor = Color.FromArgb(42, 98, 186);
			btnStartStopReceiver.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnStartStopReceiver.FlatAppearance.BorderSize = 0;
			btnStartStopReceiver.FlatStyle = FlatStyle.Flat;
			btnStartStopReceiver.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnStartStopReceiver.ForeColor = Color.White;
			btnStartStopReceiver.Location = new Point(650, 86);
			btnStartStopReceiver.Name = "btnStartStopReceiver";
			btnStartStopReceiver.Size = new Size(120, 32);
			btnStartStopReceiver.TabIndex = 4;
			btnStartStopReceiver.Text = "Start Listening";
			btnStartStopReceiver.UseVisualStyleBackColor = false;
			btnStartStopReceiver.Click += btnStartStopReceiver_Click;
			// 
			// txtReceivePassword
			// 
			txtReceivePassword.BackColor = Color.White;
			txtReceivePassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtReceivePassword.BorderStyle = BorderStyle.FixedSingle;
			txtReceivePassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtReceivePassword.ForeColor = Color.FromArgb(33, 37, 41);
			txtReceivePassword.Location = new Point(330, 91);
			txtReceivePassword.Name = "txtReceivePassword";
			txtReceivePassword.Size = new Size(264, 23);
			txtReceivePassword.TabIndex = 3;
			txtReceivePassword.UseSystemPasswordChar = true;
			// 
			// btnToggleReceivePasswordVisibility
			// 
			btnToggleReceivePasswordVisibility.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnToggleReceivePasswordVisibility.BackColor = Color.FromArgb(233, 238, 246);
			btnToggleReceivePasswordVisibility.FlatAppearance.BorderSize = 0;
			btnToggleReceivePasswordVisibility.FlatStyle = FlatStyle.Flat;
			btnToggleReceivePasswordVisibility.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnToggleReceivePasswordVisibility.ForeColor = Color.FromArgb(45, 52, 59);
			btnToggleReceivePasswordVisibility.Location = new Point(604, 89);
			btnToggleReceivePasswordVisibility.Name = "btnToggleReceivePasswordVisibility";
			btnToggleReceivePasswordVisibility.Size = new Size(36, 27);
			btnToggleReceivePasswordVisibility.TabIndex = 6;
			btnToggleReceivePasswordVisibility.Text = "\uD83D\uDD12";
			btnToggleReceivePasswordVisibility.UseVisualStyleBackColor = false;
			btnToggleReceivePasswordVisibility.Click += btnToggleReceivePasswordVisibility_Click;
			// 
			// lblReceivePassword
			// 
			lblReceivePassword.AutoSize = true;
			lblReceivePassword.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblReceivePassword.ForeColor = Color.FromArgb(96, 110, 126);
			lblReceivePassword.Location = new Point(236, 94);
			lblReceivePassword.Name = "lblReceivePassword";
			lblReceivePassword.Size = new Size(80, 15);
			lblReceivePassword.TabIndex = 2;
			lblReceivePassword.Text = "Shared secret:";
			// 
			// txtListenPort
			// 
			txtListenPort.BackColor = Color.White;
			txtListenPort.BorderStyle = BorderStyle.FixedSingle;
			txtListenPort.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtListenPort.ForeColor = Color.FromArgb(33, 37, 41);
			txtListenPort.Location = new Point(94, 91);
			txtListenPort.Name = "txtListenPort";
			txtListenPort.Size = new Size(126, 23);
			txtListenPort.TabIndex = 1;
			// 
			// lblListenPort
			// 
			lblListenPort.AutoSize = true;
			lblListenPort.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblListenPort.ForeColor = Color.FromArgb(96, 110, 126);
			lblListenPort.Location = new Point(16, 94);
			lblListenPort.Name = "lblListenPort";
			lblListenPort.Size = new Size(66, 15);
			lblListenPort.TabIndex = 0;
			lblListenPort.Text = "Listen port:";
			// 
			// lstNetworkLogs
			// 
			lstNetworkLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstNetworkLogs.BackColor = Color.White;
			lstNetworkLogs.BorderStyle = BorderStyle.FixedSingle;
			lstNetworkLogs.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lstNetworkLogs.ForeColor = Color.FromArgb(33, 37, 41);
			lstNetworkLogs.FormattingEnabled = true;
			lstNetworkLogs.Location = new Point(24, 464);
			lstNetworkLogs.Name = "lstNetworkLogs";
			lstNetworkLogs.Size = new Size(788, 138);
			lstNetworkLogs.TabIndex = 3;
			// 
			// lblLogs
			// 
			lblLogs.AutoSize = true;
			lblLogs.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblLogs.ForeColor = Color.FromArgb(45, 52, 59);
			lblLogs.Location = new Point(24, 441);
			lblLogs.Name = "lblLogs";
			lblLogs.Size = new Size(87, 19);
			lblLogs.TabIndex = 4;
			lblLogs.Text = "\uD83D\uDCDD Network log";
			// 
			// NetworkView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = Color.FromArgb(247, 249, 252);
			Controls.Add(lblLogs);
			Controls.Add(lstNetworkLogs);
			Controls.Add(groupReceiver);
			Controls.Add(groupSender);
			Controls.Add(lblTitle);
			Name = "NetworkView";
			Size = new Size(840, 620);
			groupSender.ResumeLayout(false);
			groupSender.PerformLayout();
			groupReceiver.ResumeLayout(false);
			groupReceiver.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblTitle;
		private GroupBox groupSender;
		private Label lblSelectedFile;
		private Button btnBrowseFile;
		private TextBox txtSelectedFile;
		private TextBox txtTargetPort;
		private Label lblTargetPort;
		private TextBox txtTargetIp;
		private Label lblTargetIp;
		private TextBox txtSendPassword;
		private Button btnToggleSendPasswordVisibility;
		private Label lblSendPassword;
		private Button btnSend;
		private RadioButton rbSendPlayfair;
		private RadioButton rbSendPcbcOnly;
		private RadioButton rbSendRc6Only;
		private RadioButton rbSendRc6;
		private Label lblSendAlgorithm;
		private GroupBox groupReceiver;
		private Label lblListenPort;
		private TextBox txtListenPort;
		private TextBox txtReceivePassword;
		private Button btnToggleReceivePasswordVisibility;
		private Label lblReceivePassword;
		private Button btnStartStopReceiver;
		private Label lblLocalIps;
		private ListBox lstNetworkLogs;
		private Label lblLogs;
	}
}

