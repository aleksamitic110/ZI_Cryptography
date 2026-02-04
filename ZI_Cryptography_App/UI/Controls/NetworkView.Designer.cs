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
			lblSendPassword = new Label();
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
			lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitle.Location = new Point(18, 16);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(179, 32);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "TCP Networking";
			// 
			// groupSender
			// 
			groupSender.Controls.Add(btnSend);
			groupSender.Controls.Add(txtSendPassword);
			groupSender.Controls.Add(lblSendPassword);
			groupSender.Controls.Add(txtTargetPort);
			groupSender.Controls.Add(lblTargetPort);
			groupSender.Controls.Add(txtTargetIp);
			groupSender.Controls.Add(lblTargetIp);
			groupSender.Controls.Add(btnBrowseFile);
			groupSender.Controls.Add(txtSelectedFile);
			groupSender.Controls.Add(lblSelectedFile);
			groupSender.Location = new Point(18, 57);
			groupSender.Name = "groupSender";
			groupSender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupSender.Size = new Size(692, 158);
			groupSender.TabIndex = 1;
			groupSender.TabStop = false;
			groupSender.Text = "Sender";
			// 
			// btnSend
			// 
			btnSend.Location = new Point(576, 116);
			btnSend.Name = "btnSend";
			btnSend.Size = new Size(95, 29);
			btnSend.TabIndex = 9;
			btnSend.Text = "Send";
			btnSend.UseVisualStyleBackColor = true;
			btnSend.Click += btnSend_Click;
			// 
			// txtSendPassword
			// 
			txtSendPassword.Location = new Point(111, 119);
			txtSendPassword.Name = "txtSendPassword";
			txtSendPassword.PlaceholderText = "Required if input is not .locked";
			txtSendPassword.Size = new Size(459, 23);
			txtSendPassword.TabIndex = 8;
			txtSendPassword.UseSystemPasswordChar = true;
			// 
			// lblSendPassword
			// 
			lblSendPassword.AutoSize = true;
			lblSendPassword.Location = new Point(12, 123);
			lblSendPassword.Name = "lblSendPassword";
			lblSendPassword.Size = new Size(60, 15);
			lblSendPassword.TabIndex = 7;
			lblSendPassword.Text = "Password:";
			// 
			// txtTargetPort
			// 
			txtTargetPort.Location = new Point(500, 76);
			txtTargetPort.Name = "txtTargetPort";
			txtTargetPort.Size = new Size(171, 23);
			txtTargetPort.TabIndex = 6;
			// 
			// lblTargetPort
			// 
			lblTargetPort.AutoSize = true;
			lblTargetPort.Location = new Point(430, 79);
			lblTargetPort.Name = "lblTargetPort";
			lblTargetPort.Size = new Size(64, 15);
			lblTargetPort.TabIndex = 5;
			lblTargetPort.Text = "Target Port:";
			// 
			// txtTargetIp
			// 
			txtTargetIp.Location = new Point(111, 76);
			txtTargetIp.Name = "txtTargetIp";
			txtTargetIp.PlaceholderText = "Example: 192.168.1.15";
			txtTargetIp.Size = new Size(311, 23);
			txtTargetIp.TabIndex = 4;
			// 
			// lblTargetIp
			// 
			lblTargetIp.AutoSize = true;
			lblTargetIp.Location = new Point(12, 79);
			lblTargetIp.Name = "lblTargetIp";
			lblTargetIp.Size = new Size(59, 15);
			lblTargetIp.TabIndex = 3;
			lblTargetIp.Text = "Target IP:";
			// 
			// btnBrowseFile
			// 
			btnBrowseFile.Location = new Point(576, 31);
			btnBrowseFile.Name = "btnBrowseFile";
			btnBrowseFile.Size = new Size(95, 29);
			btnBrowseFile.TabIndex = 2;
			btnBrowseFile.Text = "Browse";
			btnBrowseFile.UseVisualStyleBackColor = true;
			btnBrowseFile.Click += btnBrowseFile_Click;
			// 
			// txtSelectedFile
			// 
			txtSelectedFile.Location = new Point(111, 34);
			txtSelectedFile.Name = "txtSelectedFile";
			txtSelectedFile.ReadOnly = true;
			txtSelectedFile.Size = new Size(459, 23);
			txtSelectedFile.TabIndex = 1;
			// 
			// lblSelectedFile
			// 
			lblSelectedFile.AutoSize = true;
			lblSelectedFile.Location = new Point(12, 37);
			lblSelectedFile.Name = "lblSelectedFile";
			lblSelectedFile.Size = new Size(70, 15);
			lblSelectedFile.TabIndex = 0;
			lblSelectedFile.Text = "Selected file:";
			// 
			// groupReceiver
			// 
			groupReceiver.Controls.Add(lblLocalIps);
			groupReceiver.Controls.Add(btnStartStopReceiver);
			groupReceiver.Controls.Add(txtReceivePassword);
			groupReceiver.Controls.Add(lblReceivePassword);
			groupReceiver.Controls.Add(txtListenPort);
			groupReceiver.Controls.Add(lblListenPort);
			groupReceiver.Location = new Point(18, 224);
			groupReceiver.Name = "groupReceiver";
			groupReceiver.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupReceiver.Size = new Size(692, 119);
			groupReceiver.TabIndex = 2;
			groupReceiver.TabStop = false;
			groupReceiver.Text = "Receiver";
			// 
			// lblLocalIps
			// 
			lblLocalIps.AutoSize = true;
			lblLocalIps.Location = new Point(12, 28);
			lblLocalIps.Name = "lblLocalIps";
			lblLocalIps.Size = new Size(69, 15);
			lblLocalIps.TabIndex = 5;
			lblLocalIps.Text = "Local IPv4: -";
			// 
			// btnStartStopReceiver
			// 
			btnStartStopReceiver.Location = new Point(576, 78);
			btnStartStopReceiver.Name = "btnStartStopReceiver";
			btnStartStopReceiver.Size = new Size(95, 29);
			btnStartStopReceiver.TabIndex = 4;
			btnStartStopReceiver.Text = "Start Listening";
			btnStartStopReceiver.UseVisualStyleBackColor = true;
			btnStartStopReceiver.Click += btnStartStopReceiver_Click;
			// 
			// txtReceivePassword
			// 
			txtReceivePassword.Location = new Point(285, 81);
			txtReceivePassword.Name = "txtReceivePassword";
			txtReceivePassword.Size = new Size(285, 23);
			txtReceivePassword.TabIndex = 3;
			txtReceivePassword.UseSystemPasswordChar = true;
			// 
			// lblReceivePassword
			// 
			lblReceivePassword.AutoSize = true;
			lblReceivePassword.Location = new Point(196, 84);
			lblReceivePassword.Name = "lblReceivePassword";
			lblReceivePassword.Size = new Size(83, 15);
			lblReceivePassword.TabIndex = 2;
			lblReceivePassword.Text = "Shared secret:";
			// 
			// txtListenPort
			// 
			txtListenPort.Location = new Point(85, 81);
			txtListenPort.Name = "txtListenPort";
			txtListenPort.Size = new Size(96, 23);
			txtListenPort.TabIndex = 1;
			// 
			// lblListenPort
			// 
			lblListenPort.AutoSize = true;
			lblListenPort.Location = new Point(12, 84);
			lblListenPort.Name = "lblListenPort";
			lblListenPort.Size = new Size(62, 15);
			lblListenPort.TabIndex = 0;
			lblListenPort.Text = "Listen port:";
			// 
			// lstNetworkLogs
			// 
			lstNetworkLogs.FormattingEnabled = true;
			lstNetworkLogs.ItemHeight = 15;
			lstNetworkLogs.Location = new Point(18, 376);
			lstNetworkLogs.Name = "lstNetworkLogs";
			lstNetworkLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstNetworkLogs.Size = new Size(692, 124);
			lstNetworkLogs.TabIndex = 3;
			// 
			// lblLogs
			// 
			lblLogs.AutoSize = true;
			lblLogs.Location = new Point(18, 355);
			lblLogs.Name = "lblLogs";
			lblLogs.Size = new Size(72, 15);
			lblLogs.TabIndex = 4;
			lblLogs.Text = "Network log:";
			// 
			// NetworkView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = Color.FromArgb(2, 6, 23);
			Controls.Add(lblLogs);
			Controls.Add(lstNetworkLogs);
			Controls.Add(groupReceiver);
			Controls.Add(groupSender);
			Controls.Add(lblTitle);
			Name = "NetworkView";
			Size = new Size(840, 524);
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
		private Label lblSendPassword;
		private Button btnSend;
		private GroupBox groupReceiver;
		private Label lblListenPort;
		private TextBox txtListenPort;
		private TextBox txtReceivePassword;
		private Label lblReceivePassword;
		private Button btnStartStopReceiver;
		private Label lblLocalIps;
		private ListBox lstNetworkLogs;
		private Label lblLogs;
	}
}
