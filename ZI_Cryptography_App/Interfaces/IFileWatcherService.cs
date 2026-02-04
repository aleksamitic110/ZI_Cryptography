using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_Cryptography.ZI_Cryptography_App.Interfaces
{
	public interface IFileWatcherService
	{
		bool IsRunning { get; }
		string CurrentPath { get; }

		event Action<string> FileDetected;

		void StartWatching(string path);
		void StopWatching();
	}
}
