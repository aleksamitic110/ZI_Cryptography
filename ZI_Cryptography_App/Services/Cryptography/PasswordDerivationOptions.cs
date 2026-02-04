namespace ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography
{
	public sealed class PasswordDerivationOptions
	{
		public bool AutoMode { get; set; } = true;
		public bool UseUtf8Encoding { get; set; } = true;
		public bool UseManualPasswordBytes { get; set; }
		public string ManualPasswordBytesHex { get; set; } = string.Empty;
		public int PasswordBytesForSha1 { get; set; }
		public int Rc6KeyBytes { get; set; } = 16;

		public PasswordDerivationOptions Clone()
		{
			return new PasswordDerivationOptions
			{
				AutoMode = AutoMode,
				UseUtf8Encoding = UseUtf8Encoding,
				UseManualPasswordBytes = UseManualPasswordBytes,
				ManualPasswordBytesHex = ManualPasswordBytesHex,
				PasswordBytesForSha1 = PasswordBytesForSha1,
				Rc6KeyBytes = Rc6KeyBytes
			};
		}
	}
}
