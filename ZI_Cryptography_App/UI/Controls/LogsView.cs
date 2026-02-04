using System;
using System.Linq;
using System.Windows.Forms;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;

namespace ZI_Cryptography.ZI_Cryptography_App.UI.Controls
{
	public partial class LogsView : UserControl
	{
		public LogsView()
		{
			InitializeComponent();
			ActivityLogService.LogAdded += OnLogAdded;
			LoadSnapshot();
		}

		private void LoadSnapshot()
		{
			foreach (var entry in ActivityLogService.GetSnapshot().OrderByDescending(x => x.Timestamp))
			{
				lstActivity.Items.Add(entry.ToString());
			}

			UpdateCount();
		}

		private void OnLogAdded(ActivityLogEntry entry)
		{
			if (IsDisposed || !IsHandleCreated) return;
			if (InvokeRequired)
			{
				BeginInvoke(new Action<ActivityLogEntry>(OnLogAdded), entry);
				return;
			}

			lstActivity.Items.Insert(0, entry.ToString());
			UpdateCount();
		}

		private void btnClearLogs_Click(object sender, EventArgs e)
		{
			ActivityLogService.Clear();
			lstActivity.Items.Clear();
			UpdateCount();
		}

		private void btnCopyLogs_Click(object sender, EventArgs e)
		{
			if (lstActivity.Items.Count == 0)
			{
				return;
			}

			string all = string.Join(Environment.NewLine, lstActivity.Items.Cast<object>().Select(x => x.ToString()));
			Clipboard.SetText(all);
			MessageBox.Show("Logs copied to clipboard.", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void UpdateCount()
		{
			lblCount.Text = $"Total Entries: {lstActivity.Items.Count}";
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			ActivityLogService.LogAdded -= OnLogAdded;
			base.OnHandleDestroyed(e);
		}
	}
}
