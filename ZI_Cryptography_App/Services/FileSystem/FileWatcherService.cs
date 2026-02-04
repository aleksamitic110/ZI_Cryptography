using System;
using System.IO;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;

namespace ZI_Cryptography.ZI_Cryptography_App.Services.FileSystem
{
	public class FileWatcherService : IFileWatcherService
	{
		private FileSystemWatcher _watcher;
		public bool IsRunning { get; private set; }
		public string CurrentPath { get; private set; }
		public event Action<string> FileDetected;

		public FileWatcherService()
		{
			_watcher = new FileSystemWatcher();
		}

		public void StartWatching(string path)
		{
			if (IsRunning) return;

			if (!Directory.Exists(path))
			{
				throw new DirectoryNotFoundException($"Directory not found: {path}");
			}

			CurrentPath = path;

			_watcher.Path = path;

			
			_watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

			_watcher.Filter = "*.*";

			
			_watcher.Created += OnFileEvent;  
			_watcher.Changed += OnFileEvent;  
			_watcher.Renamed += OnRenamed;    

			_watcher.EnableRaisingEvents = true;
			IsRunning = true;
		}

		public void StopWatching()
		{
			if (!IsRunning) return;

			_watcher.EnableRaisingEvents = false;

			
			_watcher.Created -= OnFileEvent;
			_watcher.Changed -= OnFileEvent;
			_watcher.Renamed -= OnRenamed;

			IsRunning = false;
		}
		private void OnFileEvent(object sender, FileSystemEventArgs e)
		{
			if (Directory.Exists(e.FullPath)) return;
			if (!HasContent(e.FullPath)) return;
			FileDetected?.Invoke(e.FullPath);
		}
		private bool HasContent(string filePath)
		{
			try
			{
				if (!File.Exists(filePath)) return false;

				var info = new FileInfo(filePath);
				return info.Length > 0;
			}
			catch
			{
				return false;
			}
		}

		private void OnRenamed(object sender, RenamedEventArgs e)
		{
			FileDetected?.Invoke(e.FullPath);
		}



	}
}
