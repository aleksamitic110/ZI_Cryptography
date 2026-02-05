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
			panelMenu.Margin = new Padding(10);
			panelMenu.Name = "panelMenu";
			panelMenu.OutlineThickness = 1F;
			panelMenu.PanelColor = Color.FromArgb(37, 37, 38);
			panelMenu.PanelOutlineColor = Color.FromArgb(64, 128, 128, 128);
			panelMenu.Rounding = new Padding(5);
			panelMenu.Size = new Size(230, 700);
			panelMenu.TabIndex = 0;
			// 
			// btnSettings
			// 
			btnSettings.CheckButton = false;
			btnSettings.Checked = false;
			btnSettings.CheckedBackground = Color.FromArgb(255, 106, 0);
			btnSettings.CheckedForeColor = Color.White;
			btnSettings.CheckedImageTint = Color.White;
			btnSettings.CheckedOutline = Color.FromArgb(255, 106, 0);
			btnSettings.Content = "Settings";
			btnSettings.Cursor = Cursors.Hand;
			btnSettings.DialogResult = DialogResult.None;
			btnSettings.Dock = DockStyle.Top;
			btnSettings.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnSettings.ForeColor = Color.Black;
			btnSettings.HoverBackground = Color.White;
			btnSettings.HoverForeColor = Color.Black;
			btnSettings.HoverImageTint = Color.White;
			btnSettings.HoverOutline = Color.FromArgb(32, 128, 128, 128);
			btnSettings.Image = null;
			btnSettings.ImageAutoCenter = true;
			btnSettings.ImageExpand = new Point(0, 0);
			btnSettings.ImageOffset = new Point(0, 0);
			btnSettings.Location = new Point(0, 300);
			btnSettings.Margin = new Padding(10);
			btnSettings.Name = "btnSettings";
			btnSettings.NormalBackground = Color.White;
			btnSettings.NormalForeColor = Color.Black;
			btnSettings.NormalImageTint = Color.White;
			btnSettings.NormalOutline = Color.FromArgb(64, 128, 128, 128);
			btnSettings.OutlineThickness = 1F;
			btnSettings.Padding = new Padding(10, 0, 0, 0);
			btnSettings.PressedBackground = Color.WhiteSmoke;
			btnSettings.PressedForeColor = Color.FromArgb(32, 32, 32);
			btnSettings.PressedImageTint = Color.White;
			btnSettings.PressedOutline = Color.FromArgb(64, 128, 128, 128);
			btnSettings.Rounding = new Padding(8);
			btnSettings.Size = new Size(230, 55);
			btnSettings.TabIndex = 5;
			btnSettings.TextAlignment = StringAlignment.Near;
			btnSettings.TextOffset = new Point(10, 0);
			btnSettings.Click += btnSettings_Click;
			// 
			// btnLogs
			// 
			btnLogs.CheckButton = false;
			btnLogs.Checked = false;
			btnLogs.CheckedBackground = Color.FromArgb(255, 106, 0);
			btnLogs.CheckedForeColor = Color.White;
			btnLogs.CheckedImageTint = Color.White;
			btnLogs.CheckedOutline = Color.FromArgb(255, 106, 0);
			btnLogs.Content = "Activity Logs";
			btnLogs.DialogResult = DialogResult.None;
			btnLogs.Dock = DockStyle.Top;
			btnLogs.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnLogs.ForeColor = Color.Black;
			btnLogs.HoverBackground = Color.White;
			btnLogs.HoverForeColor = Color.Black;
			btnLogs.HoverImageTint = Color.White;
			btnLogs.HoverOutline = Color.FromArgb(32, 128, 128, 128);
			btnLogs.Image = null;
			btnLogs.ImageAutoCenter = true;
			btnLogs.ImageExpand = new Point(0, 0);
			btnLogs.ImageOffset = new Point(0, 0);
			btnLogs.Location = new Point(0, 245);
			btnLogs.Margin = new Padding(10);
			btnLogs.Name = "btnLogs";
			btnLogs.NormalBackground = Color.White;
			btnLogs.NormalForeColor = Color.Black;
			btnLogs.NormalImageTint = Color.White;
			btnLogs.NormalOutline = Color.FromArgb(64, 128, 128, 128);
			btnLogs.OutlineThickness = 1F;
			btnLogs.Padding = new Padding(10, 0, 0, 0);
			btnLogs.PressedBackground = Color.WhiteSmoke;
			btnLogs.PressedForeColor = Color.FromArgb(32, 32, 32);
			btnLogs.PressedImageTint = Color.White;
			btnLogs.PressedOutline = Color.FromArgb(64, 128, 128, 128);
			btnLogs.Rounding = new Padding(8);
			btnLogs.Size = new Size(230, 55);
			btnLogs.TabIndex = 4;
			btnLogs.TextAlignment = StringAlignment.Near;
			btnLogs.TextOffset = new Point(10, 0);
			btnLogs.Click += btnLogs_Click;
			// 
			// btnNetwork
			// 
			btnNetwork.CheckButton = false;
			btnNetwork.Checked = false;
			btnNetwork.CheckedBackground = Color.FromArgb(255, 106, 0);
			btnNetwork.CheckedForeColor = Color.White;
			btnNetwork.CheckedImageTint = Color.White;
			btnNetwork.CheckedOutline = Color.FromArgb(255, 106, 0);
			btnNetwork.Content = "Network Transfer";
			btnNetwork.DialogResult = DialogResult.None;
			btnNetwork.Dock = DockStyle.Top;
			btnNetwork.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnNetwork.ForeColor = Color.Black;
			btnNetwork.HoverBackground = Color.White;
			btnNetwork.HoverForeColor = Color.Black;
			btnNetwork.HoverImageTint = Color.White;
			btnNetwork.HoverOutline = Color.FromArgb(32, 128, 128, 128);
			btnNetwork.Image = null;
			btnNetwork.ImageAutoCenter = true;
			btnNetwork.ImageExpand = new Point(0, 0);
			btnNetwork.ImageOffset = new Point(0, 0);
			btnNetwork.Location = new Point(0, 190);
			btnNetwork.Margin = new Padding(10);
			btnNetwork.Name = "btnNetwork";
			btnNetwork.NormalBackground = Color.White;
			btnNetwork.NormalForeColor = Color.Black;
			btnNetwork.NormalImageTint = Color.White;
			btnNetwork.NormalOutline = Color.FromArgb(64, 128, 128, 128);
			btnNetwork.OutlineThickness = 1F;
			btnNetwork.Padding = new Padding(10, 0, 0, 0);
			btnNetwork.PressedBackground = Color.WhiteSmoke;
			btnNetwork.PressedForeColor = Color.FromArgb(32, 32, 32);
			btnNetwork.PressedImageTint = Color.White;
			btnNetwork.PressedOutline = Color.FromArgb(64, 128, 128, 128);
			btnNetwork.Rounding = new Padding(8);
			btnNetwork.Size = new Size(230, 55);
			btnNetwork.TabIndex = 3;
			btnNetwork.TextAlignment = StringAlignment.Near;
			btnNetwork.TextOffset = new Point(10, 0);
			btnNetwork.Click += btnNetwork_Click;
			// 
			// btnEncryption
			// 
			btnEncryption.CheckButton = false;
			btnEncryption.Checked = false;
			btnEncryption.CheckedBackground = Color.FromArgb(255, 106, 0);
			btnEncryption.CheckedForeColor = Color.White;
			btnEncryption.CheckedImageTint = Color.White;
			btnEncryption.CheckedOutline = Color.FromArgb(255, 106, 0);
			btnEncryption.Content = "Encryption & Decryption";
			btnEncryption.DialogResult = DialogResult.None;
			btnEncryption.Dock = DockStyle.Top;
			btnEncryption.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnEncryption.ForeColor = Color.Black;
			btnEncryption.HoverBackground = Color.White;
			btnEncryption.HoverForeColor = Color.Black;
			btnEncryption.HoverImageTint = Color.White;
			btnEncryption.HoverOutline = Color.FromArgb(32, 128, 128, 128);
			btnEncryption.Image = null;
			btnEncryption.ImageAutoCenter = true;
			btnEncryption.ImageExpand = new Point(0, 0);
			btnEncryption.ImageOffset = new Point(0, 0);
			btnEncryption.Location = new Point(0, 135);
			btnEncryption.Margin = new Padding(10);
			btnEncryption.Name = "btnEncryption";
			btnEncryption.NormalBackground = Color.White;
			btnEncryption.NormalForeColor = Color.Black;
			btnEncryption.NormalImageTint = Color.White;
			btnEncryption.NormalOutline = Color.FromArgb(64, 128, 128, 128);
			btnEncryption.OutlineThickness = 1F;
			btnEncryption.Padding = new Padding(10, 0, 0, 0);
			btnEncryption.PressedBackground = Color.WhiteSmoke;
			btnEncryption.PressedForeColor = Color.FromArgb(32, 32, 32);
			btnEncryption.PressedImageTint = Color.White;
			btnEncryption.PressedOutline = Color.FromArgb(64, 128, 128, 128);
			btnEncryption.Rounding = new Padding(8);
			btnEncryption.Size = new Size(230, 55);
			btnEncryption.TabIndex = 2;
			btnEncryption.TextAlignment = StringAlignment.Near;
			btnEncryption.TextOffset = new Point(10, 0);
			btnEncryption.Click += btnEncryption_Click;
			// 
			// btnDashboard
			// 
			btnDashboard.CheckButton = false;
			btnDashboard.Checked = false;
			btnDashboard.CheckedBackground = Color.FromArgb(255, 106, 0);
			btnDashboard.CheckedForeColor = Color.White;
			btnDashboard.CheckedImageTint = Color.White;
			btnDashboard.CheckedOutline = Color.FromArgb(255, 106, 0);
			btnDashboard.Content = "Dashboard";
			btnDashboard.DialogResult = DialogResult.None;
			btnDashboard.Dock = DockStyle.Top;
			btnDashboard.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnDashboard.ForeColor = Color.Black;
			btnDashboard.HoverBackground = Color.White;
			btnDashboard.HoverForeColor = Color.Black;
			btnDashboard.HoverImageTint = Color.White;
			btnDashboard.HoverOutline = Color.FromArgb(32, 128, 128, 128);
			btnDashboard.Image = null;
			btnDashboard.ImageAutoCenter = true;
			btnDashboard.ImageExpand = new Point(0, 0);
			btnDashboard.ImageOffset = new Point(0, 0);
			btnDashboard.Location = new Point(0, 80);
			btnDashboard.Margin = new Padding(10);
			btnDashboard.Name = "btnDashboard";
			btnDashboard.NormalBackground = Color.White;
			btnDashboard.NormalForeColor = Color.Black;
			btnDashboard.NormalImageTint = Color.White;
			btnDashboard.NormalOutline = Color.FromArgb(64, 128, 128, 128);
			btnDashboard.OutlineThickness = 1F;
			btnDashboard.Padding = new Padding(10, 0, 0, 0);
			btnDashboard.PressedBackground = Color.WhiteSmoke;
			btnDashboard.PressedForeColor = Color.FromArgb(32, 32, 32);
			btnDashboard.PressedImageTint = Color.White;
			btnDashboard.PressedOutline = Color.FromArgb(64, 128, 128, 128);
			btnDashboard.Rounding = new Padding(8);
			btnDashboard.Size = new Size(230, 55);
			btnDashboard.TabIndex = 1;
			btnDashboard.TextAlignment = StringAlignment.Near;
			btnDashboard.TextOffset = new Point(10, 0);
			btnDashboard.Click += btnDashboard_Click;
			// 
			// logoPanel
			// 
			logoPanel.Controls.Add(label2);
			logoPanel.Dock = DockStyle.Top;
			logoPanel.Location = new Point(0, 0);
			logoPanel.Name = "logoPanel";
			logoPanel.Size = new Size(230, 80);
			logoPanel.TabIndex = 0;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = SystemColors.AppWorkspace;
			label2.Location = new Point(8, 23);
			label2.Name = "label2";
			label2.Size = new Size(205, 32);
			label2.TabIndex = 3;
			label2.Text = "ZI_Cryptography";
			// 
			// panelContent
			// 
			panelContent.Dock = DockStyle.Fill;
			panelContent.Location = new Point(230, 0);
			panelContent.Margin = new Padding(10);
			panelContent.Name = "panelContent";
			panelContent.OutlineThickness = 1F;
			panelContent.PanelColor = Color.Transparent;
			panelContent.PanelOutlineColor = Color.FromArgb(64, 128, 128, 128);
			panelContent.Rounding = new Padding(8);
			panelContent.Size = new Size(870, 700);
			panelContent.TabIndex = 1;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(30, 30, 30);
			ClientSize = new Size(1100, 700);
			Controls.Add(panelContent);
			Controls.Add(panelMenu);
			MinimumSize = new Size(980, 620);
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
