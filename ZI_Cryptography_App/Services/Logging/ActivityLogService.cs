using System;
using System.Collections.Generic;
using System.Linq;

namespace ZI_Cryptography.ZI_Cryptography_App.Services.Logging
{
	public enum LogSeverity
	{
		Info,
		Success,
		Warning,
		Error
	}

	public sealed class ActivityLogEntry
	{
		public DateTime Timestamp { get; init; } = DateTime.Now;
		public LogSeverity Severity { get; init; } = LogSeverity.Info;
		public string Source { get; init; } = "System";
		public string Message { get; init; } = string.Empty;
		public override string ToString() => $"[{Timestamp:HH:mm:ss}] [{Severity}] [{Source}] {Message}";
	}

	public static class ActivityLogService
	{
		private static readonly object Sync = new();
		private static readonly List<ActivityLogEntry> Entries = new();
		private const int MaxEntries = 2000;

		public static event Action<ActivityLogEntry>? LogAdded;

		public static IReadOnlyList<ActivityLogEntry> GetSnapshot()
		{
			lock (Sync)
			{
				return Entries.ToList();
			}
		}

		public static void Add(string source, string message, LogSeverity severity = LogSeverity.Info)
		{
			var entry = new ActivityLogEntry
			{
				Source = source,
				Message = message,
				Severity = severity,
				Timestamp = DateTime.Now
			};

			lock (Sync)
			{
				Entries.Add(entry);
				if (Entries.Count > MaxEntries)
				{
					Entries.RemoveRange(0, Entries.Count - MaxEntries);
				}
			}

			LogAdded?.Invoke(entry);
		}

		public static void Clear()
		{
			lock (Sync)
			{
				Entries.Clear();
			}
		}
	}
}
