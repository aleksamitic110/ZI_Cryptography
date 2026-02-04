namespace ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography
{
	public static class CryptoInteropSettings
	{
		private static readonly object Sync = new();
		private static PasswordDerivationOptions _current = new();

		public static PasswordDerivationOptions Get()
		{
			lock (Sync)
			{
				return _current.Clone();
			}
		}

		public static void Set(PasswordDerivationOptions options)
		{
			lock (Sync)
			{
				_current = options.Clone();
			}
		}
	}
}
