using System.IO;
using ZI_Cryptography.ZI_Cryptography_App.Models;

namespace ZI_Cryptography.ZI_Cryptography_App.Interfaces
{
	public interface IMetadataManager
	{
		byte[] CreateHeaderBytes(FileMetadata header);
		FileMetadata ReadHeader(Stream stream);
	}
}
