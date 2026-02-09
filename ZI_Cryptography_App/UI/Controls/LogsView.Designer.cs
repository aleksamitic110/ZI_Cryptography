namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	partial class LogsView
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
			lstActivity = new ListBox();
			btnClearLogs = new Button();
			btnCopyLogs = new Button();
			lblCount = new Label();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
			lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
			lblTitle.Location = new Point(24, 18);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(151, 37);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "\uD83D\uDCDD Audit Logs";
			// 
			// lblSubtitle
			// 
			lblSubtitle.AutoSize = true;
			lblSubtitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSubtitle.ForeColor = Color.FromArgb(96, 110, 126);
			lblSubtitle.Location = new Point(27, 62);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Size = new Size(275, 17);
			lblSubtitle.TabIndex = 1;
			lblSubtitle.Text = "All file watcher, manual crypto and network events";
			// 
			// lstActivity
			// 
			lstActivity.BackColor = Color.White;
			lstActivity.BorderStyle = BorderStyle.FixedSingle;
			lstActivity.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lstActivity.ForeColor = Color.FromArgb(33, 37, 41);
			lstActivity.FormattingEnabled = true;
			lstActivity.ItemHeight = 15;
			lstActivity.Location = new Point(24, 110);
			lstActivity.Name = "lstActivity";
			lstActivity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstActivity.Size = new Size(788, 423);
			lstActivity.TabIndex = 2;
			// 
			// btnClearLogs
			// 
			btnClearLogs.BackColor = Color.FromArgb(187, 54, 54);
			btnClearLogs.FlatAppearance.BorderSize = 0;
			btnClearLogs.FlatStyle = FlatStyle.Flat;
			btnClearLogs.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnClearLogs.ForeColor = Color.White;
			btnClearLogs.Location = new Point(692, 18);
			btnClearLogs.Name = "btnClearLogs";
			btnClearLogs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnClearLogs.Size = new Size(120, 34);
			btnClearLogs.TabIndex = 3;
			btnClearLogs.Text = "\uD83D\uDDD1 Clear Logs";
			btnClearLogs.UseVisualStyleBackColor = false;
			btnClearLogs.Click += btnClearLogs_Click;
			// 
			// btnCopyLogs
			// 
			btnCopyLogs.BackColor = Color.FromArgb(42, 98, 186);
			btnCopyLogs.FlatAppearance.BorderSize = 0;
			btnCopyLogs.FlatStyle = FlatStyle.Flat;
			btnCopyLogs.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCopyLogs.ForeColor = Color.White;
			btnCopyLogs.Location = new Point(566, 18);
			btnCopyLogs.Name = "btnCopyLogs";
			btnCopyLogs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnCopyLogs.Size = new Size(120, 34);
			btnCopyLogs.TabIndex = 4;
			btnCopyLogs.Text = "\uD83D\uDCCB Copy";
			btnCopyLogs.UseVisualStyleBackColor = false;
			btnCopyLogs.Click += btnCopyLogs_Click;
			// 
			// lblCount
			// 
			lblCount.AutoSize = true;
			lblCount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCount.ForeColor = Color.FromArgb(96, 110, 126);
			lblCount.Location = new Point(24, 544);
			lblCount.Name = "lblCount";
			lblCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lblCount.Size = new Size(97, 17);
			lblCount.TabIndex = 5;
			lblCount.Text = "Total Entries: 0";
			// 
			// LogsView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = Color.FromArgb(247, 249, 252);
			Controls.Add(lblCount);
			Controls.Add(btnCopyLogs);
			Controls.Add(btnClearLogs);
			Controls.Add(lstActivity);
			Controls.Add(lblSubtitle);
			Controls.Add(lblTitle);
			Name = "LogsView";
			Size = new Size(840, 580);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblTitle;
		private Label lblSubtitle;
		private ListBox lstActivity;
		private Button btnClearLogs;
		private Button btnCopyLogs;
		private Label lblCount;
	}
}
