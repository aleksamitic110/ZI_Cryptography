namespace ZI_Cryptography
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			panelMenu = new CuoreUI.Controls.cuiPanel();
			btnSettings = new CuoreUI.Controls.cuiButton();
			btnLogs = new CuoreUI.Controls.cuiButton();
			btnNetwork = new CuoreUI.Controls.cuiButton();
			btnEncryption = new CuoreUI.Controls.cuiButton();
			btnDashboard = new CuoreUI.Controls.cuiButton();
			logoPanel = new Panel();
			label2 = new Label();
			panelContent = new CuoreUI.Controls.cuiPanel();
			panelMenu.SuspendLayout();
			logoPanel.SuspendLayout();
			SuspendLayout();
			// 
			// panelMenu
			// 
			panelMenu.Controls.Add(btnSettings);
			panelMenu.Controls.Add(btnLogs);
			panelMenu.Controls.Add(btnNetwork);
			panelMenu.Controls.Add(btnEncryption);
			panelMenu.Controls.Add(btnDashboard);
			panelMenu.Controls.Add(logoPanel);
			panelMenu.Dock = DockStyle.Left;
			panelMenu.Location = new Point(0, 0);
			panelMenu.Margin = new Padding(0);
			panelMenu.Name = "panelMenu";
			panelMenu.OutlineThickness = 1F;
			panelMenu.PanelColor = Color.FromArgb(245, 246, 248);
			panelMenu.PanelOutlineColor = Color.FromArgb(220, 223, 227);
			panelMenu.Rounding = new Padding(0);
			panelMenu.Size = new Size(184, 700);
			panelMenu.TabIndex = 0;
			// 
			// btnSettings
			// 
			btnSettings.CheckButton = true;
			btnSettings.Checked = false;
			btnSettings.CheckedBackground = Color.FromArgb(216, 228, 242);
			btnSettings.CheckedForeColor = Color.FromArgb(33, 37, 41);
			btnSettings.CheckedImageTint = Color.FromArgb(33, 37, 41);
			btnSettings.CheckedOutline = Color.FromArgb(142, 168, 198);
			btnSettings.Content = "Settings";
			btnSettings.Cursor = Cursors.Hand;
			btnSettings.DialogResult = DialogResult.None;
			btnSettings.Dock = DockStyle.Top;
			btnSettings.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnSettings.ForeColor = Color.FromArgb(33, 37, 41);
			btnSettings.HoverBackground = Color.FromArgb(234, 239, 245);
			btnSettings.HoverForeColor = Color.FromArgb(33, 37, 41);
			btnSettings.HoverImageTint = Color.FromArgb(33, 37, 41);
			btnSettings.HoverOutline = Color.FromArgb(211, 218, 226);
			btnSettings.Image = null;
			btnSettings.ImageAutoCenter = true;
			btnSettings.ImageExpand = new Point(0, 0);
			btnSettings.ImageOffset = new Point(0, 0);
			btnSettings.Location = new Point(0, 240);
			btnSettings.Margin = new Padding(0);
			btnSettings.Name = "btnSettings";
			btnSettings.NormalBackground = Color.White;
			btnSettings.NormalForeColor = Color.FromArgb(33, 37, 41);
			btnSettings.NormalImageTint = Color.FromArgb(33, 37, 41);
			btnSettings.NormalOutline = Color.FromArgb(223, 227, 232);
			btnSettings.OutlineThickness = 1F;
			btnSettings.Padding = new Padding(12, 0, 0, 0);
			btnSettings.PressedBackground = Color.FromArgb(227, 233, 241);
			btnSettings.PressedForeColor = Color.FromArgb(33, 37, 41);
			btnSettings.PressedImageTint = Color.FromArgb(33, 37, 41);
			btnSettings.PressedOutline = Color.FromArgb(200, 208, 217);
			btnSettings.Rounding = new Padding(4);
			btnSettings.Size = new Size(184, 44);
			btnSettings.TabIndex = 5;
			btnSettings.TextAlignment = StringAlignment.Near;
			btnSettings.TextOffset = new Point(6, 0);
			btnSettings.Click += btnSettings_Click;
			// 
			// btnLogs
			// 
			btnLogs.CheckButton = true;
			btnLogs.Checked = false;
			btnLogs.CheckedBackground = Color.FromArgb(216, 228, 242);
			btnLogs.CheckedForeColor = Color.FromArgb(33, 37, 41);
			btnLogs.CheckedImageTint = Color.FromArgb(33, 37, 41);
			btnLogs.CheckedOutline = Color.FromArgb(142, 168, 198);
			btnLogs.Content = "Logs";
			btnLogs.DialogResult = DialogResult.None;
			btnLogs.Dock = DockStyle.Top;
			btnLogs.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnLogs.ForeColor = Color.FromArgb(33, 37, 41);
			btnLogs.HoverBackground = Color.FromArgb(234, 239, 245);
			btnLogs.HoverForeColor = Color.FromArgb(33, 37, 41);
			btnLogs.HoverImageTint = Color.FromArgb(33, 37, 41);
			btnLogs.HoverOutline = Color.FromArgb(211, 218, 226);
			btnLogs.Image = null;
			btnLogs.ImageAutoCenter = true;
			btnLogs.ImageExpand = new Point(0, 0);
			btnLogs.ImageOffset = new Point(0, 0);
			btnLogs.Location = new Point(0, 196);
			btnLogs.Margin = new Padding(0);
			btnLogs.Name = "btnLogs";
			btnLogs.NormalBackground = Color.White;
			btnLogs.NormalForeColor = Color.FromArgb(33, 37, 41);
			btnLogs.NormalImageTint = Color.FromArgb(33, 37, 41);
			btnLogs.NormalOutline = Color.FromArgb(223, 227, 232);
			btnLogs.OutlineThickness = 1F;
			btnLogs.Padding = new Padding(12, 0, 0, 0);
			btnLogs.PressedBackground = Color.FromArgb(227, 233, 241);
			btnLogs.PressedForeColor = Color.FromArgb(33, 37, 41);
			btnLogs.PressedImageTint = Color.FromArgb(33, 37, 41);
			btnLogs.PressedOutline = Color.FromArgb(200, 208, 217);
			btnLogs.Rounding = new Padding(4);
			btnLogs.Size = new Size(184, 44);
			btnLogs.TabIndex = 4;
			btnLogs.TextAlignment = StringAlignment.Near;
			btnLogs.TextOffset = new Point(6, 0);
			btnLogs.Click += btnLogs_Click;
			// 
			// btnNetwork
			// 
			btnNetwork.CheckButton = true;
			btnNetwork.Checked = false;
			btnNetwork.CheckedBackground = Color.FromArgb(216, 228, 242);
			btnNetwork.CheckedForeColor = Color.FromArgb(33, 37, 41);
			btnNetwork.CheckedImageTint = Color.FromArgb(33, 37, 41);
			btnNetwork.CheckedOutline = Color.FromArgb(142, 168, 198);
			btnNetwork.Content = "Network";
			btnNetwork.DialogResult = DialogResult.None;
			btnNetwork.Dock = DockStyle.Top;
			btnNetwork.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnNetwork.ForeColor = Color.FromArgb(33, 37, 41);
			btnNetwork.HoverBackground = Color.FromArgb(234, 239, 245);
			btnNetwork.HoverForeColor = Color.FromArgb(33, 37, 41);
			btnNetwork.HoverImageTint = Color.FromArgb(33, 37, 41);
			btnNetwork.HoverOutline = Color.FromArgb(211, 218, 226);
			btnNetwork.Image = null;
			btnNetwork.ImageAutoCenter = true;
			btnNetwork.ImageExpand = new Point(0, 0);
			btnNetwork.ImageOffset = new Point(0, 0);
			btnNetwork.Location = new Point(0, 152);
			btnNetwork.Margin = new Padding(0);
			btnNetwork.Name = "btnNetwork";
			btnNetwork.NormalBackground = Color.White;
			btnNetwork.NormalForeColor = Color.FromArgb(33, 37, 41);
			btnNetwork.NormalImageTint = Color.FromArgb(33, 37, 41);
			btnNetwork.NormalOutline = Color.FromArgb(223, 227, 232);
			btnNetwork.OutlineThickness = 1F;
			btnNetwork.Padding = new Padding(12, 0, 0, 0);
			btnNetwork.PressedBackground = Color.FromArgb(227, 233, 241);
			btnNetwork.PressedForeColor = Color.FromArgb(33, 37, 41);
			btnNetwork.PressedImageTint = Color.FromArgb(33, 37, 41);
			btnNetwork.PressedOutline = Color.FromArgb(200, 208, 217);
			btnNetwork.Rounding = new Padding(4);
			btnNetwork.Size = new Size(184, 44);
			btnNetwork.TabIndex = 3;
			btnNetwork.TextAlignment = StringAlignment.Near;
			btnNetwork.TextOffset = new Point(6, 0);
			btnNetwork.Click += btnNetwork_Click;
			// 
			// btnEncryption
			// 
			btnEncryption.CheckButton = true;
			btnEncryption.Checked = false;
			btnEncryption.CheckedBackground = Color.FromArgb(216, 228, 242);
			btnEncryption.CheckedForeColor = Color.FromArgb(33, 37, 41);
			btnEncryption.CheckedImageTint = Color.FromArgb(33, 37, 41);
			btnEncryption.CheckedOutline = Color.FromArgb(142, 168, 198);
			btnEncryption.Content = "Manual Crypto";
			btnEncryption.DialogResult = DialogResult.None;
			btnEncryption.Dock = DockStyle.Top;
			btnEncryption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnEncryption.ForeColor = Color.FromArgb(33, 37, 41);
			btnEncryption.HoverBackground = Color.FromArgb(234, 239, 245);
			btnEncryption.HoverForeColor = Color.FromArgb(33, 37, 41);
			btnEncryption.HoverImageTint = Color.FromArgb(33, 37, 41);
			btnEncryption.HoverOutline = Color.FromArgb(211, 218, 226);
			btnEncryption.Image = null;
			btnEncryption.ImageAutoCenter = true;
			btnEncryption.ImageExpand = new Point(0, 0);
			btnEncryption.ImageOffset = new Point(0, 0);
			btnEncryption.Location = new Point(0, 108);
			btnEncryption.Margin = new Padding(0);
			btnEncryption.Name = "btnEncryption";
			btnEncryption.NormalBackground = Color.White;
			btnEncryption.NormalForeColor = Color.FromArgb(33, 37, 41);
			btnEncryption.NormalImageTint = Color.FromArgb(33, 37, 41);
			btnEncryption.NormalOutline = Color.FromArgb(223, 227, 232);
			btnEncryption.OutlineThickness = 1F;
			btnEncryption.Padding = new Padding(12, 0, 0, 0);
			btnEncryption.PressedBackground = Color.FromArgb(227, 233, 241);
			btnEncryption.PressedForeColor = Color.FromArgb(33, 37, 41);
			btnEncryption.PressedImageTint = Color.FromArgb(33, 37, 41);
			btnEncryption.PressedOutline = Color.FromArgb(200, 208, 217);
			btnEncryption.Rounding = new Padding(4);
			btnEncryption.Size = new Size(184, 44);
			btnEncryption.TabIndex = 2;
			btnEncryption.TextAlignment = StringAlignment.Near;
			btnEncryption.TextOffset = new Point(6, 0);
			btnEncryption.Click += btnEncryption_Click;
			// 
			// btnDashboard
			// 
			btnDashboard.CheckButton = true;
			btnDashboard.Checked = false;
			btnDashboard.CheckedBackground = Color.FromArgb(216, 228, 242);
			btnDashboard.CheckedForeColor = Color.FromArgb(33, 37, 41);
			btnDashboard.CheckedImageTint = Color.FromArgb(33, 37, 41);
			btnDashboard.CheckedOutline = Color.FromArgb(142, 168, 198);
			btnDashboard.Content = "Dashboard";
			btnDashboard.DialogResult = DialogResult.None;
			btnDashboard.Dock = DockStyle.Top;
			btnDashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnDashboard.ForeColor = Color.FromArgb(33, 37, 41);
			btnDashboard.HoverBackground = Color.FromArgb(234, 239, 245);
			btnDashboard.HoverForeColor = Color.FromArgb(33, 37, 41);
			btnDashboard.HoverImageTint = Color.FromArgb(33, 37, 41);
			btnDashboard.HoverOutline = Color.FromArgb(211, 218, 226);
			btnDashboard.Image = null;
			btnDashboard.ImageAutoCenter = true;
			btnDashboard.ImageExpand = new Point(0, 0);
			btnDashboard.ImageOffset = new Point(0, 0);
			btnDashboard.Location = new Point(0, 64);
			btnDashboard.Margin = new Padding(0);
			btnDashboard.Name = "btnDashboard";
			btnDashboard.NormalBackground = Color.White;
			btnDashboard.NormalForeColor = Color.FromArgb(33, 37, 41);
			btnDashboard.NormalImageTint = Color.FromArgb(33, 37, 41);
			btnDashboard.NormalOutline = Color.FromArgb(223, 227, 232);
			btnDashboard.OutlineThickness = 1F;
			btnDashboard.Padding = new Padding(12, 0, 0, 0);
			btnDashboard.PressedBackground = Color.FromArgb(227, 233, 241);
			btnDashboard.PressedForeColor = Color.FromArgb(33, 37, 41);
			btnDashboard.PressedImageTint = Color.FromArgb(33, 37, 41);
			btnDashboard.PressedOutline = Color.FromArgb(200, 208, 217);
			btnDashboard.Rounding = new Padding(4);
			btnDashboard.Size = new Size(184, 44);
			btnDashboard.TabIndex = 1;
			btnDashboard.TextAlignment = StringAlignment.Near;
			btnDashboard.TextOffset = new Point(6, 0);
			btnDashboard.Click += btnDashboard_Click;
			// 
			// logoPanel
			// 
			logoPanel.Controls.Add(label2);
			logoPanel.Dock = DockStyle.Top;
			logoPanel.Location = new Point(0, 0);
			logoPanel.Margin = new Padding(0);
			logoPanel.Name = "logoPanel";
			logoPanel.Size = new Size(184, 64);
			logoPanel.TabIndex = 0;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(45, 52, 59);
			label2.Location = new Point(12, 21);
			label2.Name = "label2";
			label2.Size = new Size(139, 23);
			label2.TabIndex = 3;
			label2.Text = "ZI Cryptography";
			// 
			// panelContent
			// 
			panelContent.Dock = DockStyle.Fill;
			panelContent.Location = new Point(184, 0);
			panelContent.Margin = new Padding(0);
			panelContent.Name = "panelContent";
			panelContent.OutlineThickness = 1F;
			panelContent.PanelColor = Color.FromArgb(250, 251, 253);
			panelContent.PanelOutlineColor = Color.FromArgb(224, 228, 233);
			panelContent.Rounding = new Padding(0);
			panelContent.Size = new Size(916, 700);
			panelContent.TabIndex = 1;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(250, 251, 253);
			ClientSize = new Size(1100, 700);
			Controls.Add(panelContent);
			Controls.Add(panelMenu);
			MinimumSize = new Size(900, 580);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "ZI Cryptography";
			Load += MainForm_Load;
			panelMenu.ResumeLayout(false);
			logoPanel.ResumeLayout(false);
			logoPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private CuoreUI.Controls.cuiPanel panelMenu;
		private CuoreUI.Controls.cuiPanel panelContent;
		private Panel logoPanel;
		private Label label2;
		private CuoreUI.Controls.cuiButton btnDashboard;
		private CuoreUI.Controls.cuiButton btnSettings;
		private CuoreUI.Controls.cuiButton btnLogs;
		private CuoreUI.Controls.cuiButton btnNetwork;
		private CuoreUI.Controls.cuiButton btnEncryption;
	}
}
