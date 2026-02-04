namespace ZI_Cryptography.ZI_Cryptography_App.Interfaces
{
	public interface ICipherMode
	{
		byte[] Encrypt(byte[] data, byte[] key);
		byte[] Decrypt(byte[] encryptedData, byte[] key);
	}
}