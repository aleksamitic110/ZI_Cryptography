using System;
using System.IO;
using System.Text.Json;

namespace ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography
{
	public sealed class OutputPathOptions
	{
		public string EncryptedFilesFolder { get; set; } = string.Empty;
		public string DecryptedFilesFolder { get; set; } = string.Empty;
		public string ActivityLogsFolder { get; set; } = string.Empty;

		public OutputPathOptions Clone()
		{
			return new OutputPathOptions
			{
				EncryptedFilesFolder = EncryptedFilesFolder,
				DecryptedFilesFolder = DecryptedFilesFolder,
				ActivityLogsFolder = ActivityLogsFolder
			};
		}

		public static OutputPathOptions CreateDefaults()
		{
			string root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CryptoStorage");
			return new OutputPathOptions
			{
				EncryptedFilesFolder = Path.Combine(root, "Encrypted"),
				DecryptedFilesFolder = Path.Combine(root, "Decrypted"),
				ActivityLogsFolder = Path.Combine(root, "Logs")
			};
		}
	}

	public static class OutputPathSettings
	{
		private static readonly object Sync = new();
		private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output-paths.json");
		private static OutputPathOptions _current = LoadFromDisk();

		public static OutputPathOptions Get()
		{
			lock (Sync)
			{
				return _current.Clone();
			}
		}

		public static void Set(OutputPathOptions options)
		{
			if (options == null) throw new ArgumentNullException(nameof(options));

			var normalized = NormalizeOrThrow(options);
			Directory.CreateDirectory(normalized.EncryptedFilesFolder);
			Directory.CreateDirectory(normalized.DecryptedFilesFolder);
			Directory.CreateDirectory(normalized.ActivityLogsFolder);

			lock (Sync)
			{
				_current = normalized.Clone();
				SaveToDisk(_current);
			}
		}

		public static void Reset()
		{
			Set(OutputPathOptions.CreateDefaults());
		}

		private static OutputPathOptions LoadFromDisk()
		{
			try
			{
				if (!File.Exists(ConfigPath))
				{
					var defaults = OutputPathOptions.CreateDefaults();
					Directory.CreateDirectory(defaults.EncryptedFilesFolder);
					Directory.CreateDirectory(defaults.DecryptedFilesFolder);
					Directory.CreateDirectory(defaults.ActivityLogsFolder);
					return defaults;
				}

				string json = File.ReadAllText(ConfigPath);
				var loaded = JsonSerializer.Deserialize<OutputPathOptions>(json);
				if (loaded == null)
				{
					return OutputPathOptions.CreateDefaults();
				}

				var normalized = NormalizeOrThrow(loaded);
				Directory.CreateDirectory(normalized.EncryptedFilesFolder);
				Directory.CreateDirectory(normalized.DecryptedFilesFolder);
				Directory.CreateDirectory(normalized.ActivityLogsFolder);
				return normalized;
			}
			catch
			{
				var defaults = OutputPathOptions.CreateDefaults();
				Directory.CreateDirectory(defaults.EncryptedFilesFolder);
				Directory.CreateDirectory(defaults.DecryptedFilesFolder);
				Directory.CreateDirectory(defaults.ActivityLogsFolder);
				return defaults;
			}
		}

		private static void SaveToDisk(OutputPathOptions options)
		{
			string json = JsonSerializer.Serialize(options, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(ConfigPath, json);
		}

		private static OutputPathOptions NormalizeOrThrow(OutputPathOptions options)
		{
			string encrypted = (options.EncryptedFilesFolder ?? string.Empty).Trim();
			string decrypted = (options.DecryptedFilesFolder ?? string.Empty).Trim();
			string logs = (options.ActivityLogsFolder ?? string.Empty).Trim();

			if (string.IsNullOrWhiteSpace(encrypted))
			{
				throw new ArgumentException("Encrypted files folder cannot be empty.");
			}

			if (string.IsNullOrWhiteSpace(decrypted))
			{
				throw new ArgumentException("Decrypted files folder cannot be empty.");
			}

			if (string.IsNullOrWhiteSpace(logs))
			{
				logs = OutputPathOptions.CreateDefaults().ActivityLogsFolder;
			}

			return new OutputPathOptions
			{
				EncryptedFilesFolder = Path.GetFullPath(encrypted),
				DecryptedFilesFolder = Path.GetFullPath(decrypted),
				ActivityLogsFolder = Path.GetFullPath(logs)
			};
		}
	}
}
