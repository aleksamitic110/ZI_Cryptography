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
