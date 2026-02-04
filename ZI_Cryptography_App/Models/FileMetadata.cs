namespace ZI_Cryptography.ZI_Cryptography_App.Models
{
	public class FileMetadata
	{
		public string OriginalFileName { get; set; } = string.Empty;
		public long FileSize { get; set; }
		public DateTime CreationTime { get; set; }
		public string EncryptionAlgorithm { get; set; } = string.Empty;
		public string HashAlgorithm { get; set; } = string.Empty;

		public string ToJson()
		{
			return System.Text.Json.JsonSerializer.Serialize(this);
		}
	}
}
