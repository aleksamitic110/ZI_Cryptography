using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZI_Cryptography.ZI_Cryptography_App.Services.Logging;

namespace ZI_Cryptography.ZI_Cryptography_App.UI.Helpers
{
	internal static class GlobalExceptionHandler
	{
		private static bool _registered;

		public static void Register()
		{
			if (_registered)
			{
				return;
			}

			_registered = true;
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += OnThreadException;
			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
			TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
		}

		private static void OnThreadException(object? sender, ThreadExceptionEventArgs e)
		{
			ShowErrorDialog("Unexpected Error", e.Exception);
		}

		private static void OnUnhandledException(object? sender, UnhandledExceptionEventArgs e)
		{
			var exception = e.ExceptionObject as Exception ?? new Exception("Unknown unhandled exception.");
			ShowErrorDialog("Critical Error", exception);
		}

		private static void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
		{
			ShowErrorDialog("Background Task Error", e.Exception);
			e.SetObserved();
		}

		private static void ShowErrorDialog(string title, Exception exception)
		{
			try
			{
				ActivityLogService.Add("UnhandledException", exception.ToString(), LogSeverity.Error);
			}
			catch
			{
				// Ignore logging failures while reporting an unhandled exception.
			}

			try
			{
				MessageBox.Show(
					$"An unexpected error occurred:{Environment.NewLine}{Environment.NewLine}{exception.Message}{Environment.NewLine}{Environment.NewLine}Details:{Environment.NewLine}{exception}",
					title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			catch
			{
				// Avoid throwing from global exception handler.
			}
		}
	}
}
