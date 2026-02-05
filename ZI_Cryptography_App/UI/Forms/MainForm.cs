using System.Drawing;
using CuoreUI.Controls;
using ZI_Cryptography.ZI_Cryptography_App.UI.Controls;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;
namespace ZI_Cryptography
{
	public partial class MainForm : Form
	{
		private DashboardView _dashboardView;
		private ManualEncryptionView _manualEncryptionView;
		private NetworkView _networkView;
		private LogsView _logsView;
		private SettingsView _settingsView;

		private void LoadView(UserControl view)
		{
			panelContent.Controls.Clear();
			view.Dock = DockStyle.Fill;
			panelContent.Controls.Add(view);
		}

		private void ApplyShellTheme()
		{
			panelMenu.PanelColor = Color.FromArgb(2, 6, 23);
			logoPanel.BackColor = Color.FromArgb(2, 6, 23);
			label2.ForeColor = Color.FromArgb(125, 211, 252);
			StyleNavButton(btnDashboard);
			StyleNavButton(btnEncryption);
			StyleNavButton(btnNetwork);
			StyleNavButton(btnLogs);
			StyleNavButton(btnSettings);
			panelContent.PanelColor = Color.FromArgb(3, 7, 18);
		}

		private static void StyleNavButton(cuiButton button)
		{
			button.CheckButton = true;
			button.NormalBackground = Color.FromArgb(17, 24, 39);
			button.NormalForeColor = Color.FromArgb(203, 213, 225);
			button.HoverBackground = Color.FromArgb(30, 41, 59);
			button.HoverForeColor = Color.White;
			button.PressedBackground = Color.FromArgb(14, 116, 144);
			button.PressedForeColor = Color.White;
			button.CheckedBackground = Color.FromArgb(14, 116, 144);
			button.CheckedForeColor = Color.White;
			button.NormalOutline = Color.FromArgb(31, 41, 55);
			button.HoverOutline = Color.FromArgb(56, 189, 248);
			button.PressedOutline = Color.FromArgb(56, 189, 248);
		}

		private void SetActiveNav(cuiButton active)
		{
			btnDashboard.Checked = false;
			btnEncryption.Checked = false;
			btnNetwork.Checked = false;
			btnLogs.Checked = false;
			btnSettings.Checked = false;
			active.Checked = true;
		}

		public MainForm()
		{
			InitializeComponent();

			_dashboardView = new DashboardView();
			_manualEncryptionView = new ManualEncryptionView();
			_networkView = new NetworkView();
			_logsView = new LogsView();
			_settingsView = new SettingsView();
			ApplyShellTheme();

			LoadView(_dashboardView);
			SetActiveNav(btnDashboard);
			ActivityLogService.Add("App", "Application started", LogSeverity.Info);

		}

		private void btnDashboard_Click(object sender, EventArgs e)
		{
			LoadView(_dashboardView);
			SetActiveNav(btnDashboard);
			ActivityLogService.Add("App", "Opened Dashboard view", LogSeverity.Info);
		}

		private void btnEncryption_Click(object sender, EventArgs e)
		{
			LoadView(_manualEncryptionView);
			SetActiveNav(btnEncryption);
			ActivityLogService.Add("App", "Opened Manual Encryption view", LogSeverity.Info);
		}

		private void btnNetwork_Click(object sender, EventArgs e)
		{
			LoadView(_networkView);
			SetActiveNav(btnNetwork);
			ActivityLogService.Add("App", "Opened Network view", LogSeverity.Info);
		}

		private void btnLogs_Click(object sender, EventArgs e)
		{
			LoadView(_logsView);
			SetActiveNav(btnLogs);
			ActivityLogService.Add("App", "Opened Activity Logs view", LogSeverity.Info);
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			LoadView(_settingsView);
			SetActiveNav(btnSettings);
			ActivityLogService.Add("App", "Opened Settings view", LogSeverity.Info);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{


		}
	}
}
