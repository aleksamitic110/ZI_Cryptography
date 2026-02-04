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
			lblTitle.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
			lblTitle.ForeColor = Color.FromArgb(241, 245, 249);
			lblTitle.Location = new Point(24, 18);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(165, 41);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "Audit Logs";
			// 
			// lblSubtitle
			// 
			lblSubtitle.AutoSize = true;
			lblSubtitle.Font = new Font("Segoe UI", 10F);
			lblSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
			lblSubtitle.Location = new Point(27, 62);
			lblSubtitle.Name = "lblSubtitle";
			lblSubtitle.Size = new Size(309, 19);
			lblSubtitle.TabIndex = 1;
			lblSubtitle.Text = "All file watcher, manual crypto and network events";
			// 
			// lstActivity
			// 
			lstActivity.BackColor = Color.FromArgb(15, 23, 42);
			lstActivity.BorderStyle = BorderStyle.None;
			lstActivity.Font = new Font("Consolas", 10F);
			lstActivity.ForeColor = Color.FromArgb(226, 232, 240);
			lstActivity.FormattingEnabled = true;
			lstActivity.ItemHeight = 15;
			lstActivity.Location = new Point(24, 110);
			lstActivity.Name = "lstActivity";
			lstActivity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstActivity.Size = new Size(788, 375);
			lstActivity.TabIndex = 2;
			// 
			// btnClearLogs
			// 
			btnClearLogs.BackColor = Color.FromArgb(127, 29, 29);
			btnClearLogs.FlatAppearance.BorderSize = 0;
			btnClearLogs.FlatStyle = FlatStyle.Flat;
			btnClearLogs.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnClearLogs.ForeColor = Color.White;
			btnClearLogs.Location = new Point(692, 18);
			btnClearLogs.Name = "btnClearLogs";
			btnClearLogs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnClearLogs.Size = new Size(120, 38);
			btnClearLogs.TabIndex = 3;
			btnClearLogs.Text = "Clear Logs";
			btnClearLogs.UseVisualStyleBackColor = false;
			btnClearLogs.Click += btnClearLogs_Click;
			// 
			// btnCopyLogs
			// 
			btnCopyLogs.BackColor = Color.FromArgb(30, 64, 175);
			btnCopyLogs.FlatAppearance.BorderSize = 0;
			btnCopyLogs.FlatStyle = FlatStyle.Flat;
			btnCopyLogs.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnCopyLogs.ForeColor = Color.White;
			btnCopyLogs.Location = new Point(566, 18);
			btnCopyLogs.Name = "btnCopyLogs";
			btnCopyLogs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnCopyLogs.Size = new Size(120, 38);
			btnCopyLogs.TabIndex = 4;
			btnCopyLogs.Text = "Copy";
			btnCopyLogs.UseVisualStyleBackColor = false;
			btnCopyLogs.Click += btnCopyLogs_Click;
			// 
			// lblCount
			// 
			lblCount.AutoSize = true;
			lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			lblCount.ForeColor = Color.FromArgb(125, 211, 252);
			lblCount.Location = new Point(24, 493);
			lblCount.Name = "lblCount";
			lblCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lblCount.Size = new Size(100, 19);
			lblCount.TabIndex = 5;
			lblCount.Text = "Total Entries: 0";
			// 
			// LogsView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = Color.FromArgb(2, 6, 23);
			Controls.Add(lblCount);
			Controls.Add(btnCopyLogs);
			Controls.Add(btnClearLogs);
			Controls.Add(lstActivity);
			Controls.Add(lblSubtitle);
			Controls.Add(lblTitle);
			Name = "LogsView";
			Size = new Size(840, 524);
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
