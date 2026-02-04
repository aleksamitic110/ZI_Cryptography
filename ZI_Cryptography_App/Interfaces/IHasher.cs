using System.IO;

namespace ZI_Cryptography.ZI_Cryptography_App.Interfaces
{
	public interface IHasher
	{
		string Name { get; }
		byte[] ComputeHash(byte[] data);
		byte[] ComputeHash(Stream stream, int bufferSize = 8192);
	}
}
