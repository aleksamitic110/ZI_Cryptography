using ZI_Cryptography.ZI_Cryptography_App.Services.Cryptography;

namespace ZI_Cryptography.ZI_Cryptography_App.Interfaces
{
	public interface ICryptoService
	{
		string EncryptFile(string inputFilePath, string? outputFolder, string password, PasswordDerivationOptions? derivationOptions = null);
		string EncryptFile(string inputFilePath, string? outputFolder, string password, CryptoAlgorithmType algoType, PasswordDerivationOptions? derivationOptions = null);
		string DecryptFile(string encryptedFilePath, string? outputFolder, string password, PasswordDerivationOptions? derivationOptions = null);
	}
}
