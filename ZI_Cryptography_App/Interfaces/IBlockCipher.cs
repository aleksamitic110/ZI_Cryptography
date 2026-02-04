using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_Cryptography.ZI_Cryptography_App.Interfaces
{
	public interface IBlockCipher
	{
		int BlockSize { get; }
		byte[] EncryptBlock(byte[] inputBlock, byte[] key);
		byte[] DecryptBlock(byte[] inputBlock, byte[] key);
	}
}