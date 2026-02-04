using System;
using System.Security.Cryptography;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;

namespace ZI_Cryptography.ZI_Cryptography_App.Core.Modes
{
	public class PcbcMode : ICipherMode
	{
		private readonly IBlockCipher _cipher;

		public PcbcMode(IBlockCipher cipher)
		{
			_cipher = cipher;
		}

		public byte[] Encrypt(byte[] data, byte[] key)
		{
			int blockSize = _cipher.BlockSize;
			byte[] paddedData = AddPadding(data, blockSize);
			int blockCount = paddedData.Length / blockSize;

			byte[] iv = new byte[blockSize];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(iv);
			}

			byte[] result = new byte[blockSize + paddedData.Length];
			Array.Copy(iv, 0, result, 0, blockSize);

			byte[] prevPlain = new byte[blockSize];
			byte[] prevCipher = new byte[blockSize];
			Array.Copy(iv, prevPlain, blockSize);
			Array.Copy(iv, prevCipher, blockSize);

			for (int i = 0; i < blockCount; i++)
			{
				byte[] currentPlain = new byte[blockSize];
				Array.Copy(paddedData, i * blockSize, currentPlain, 0, blockSize);
				byte[] inputToCipher = XorBlocks(currentPlain, prevPlain, prevCipher);
				byte[] currentCipher = _cipher.EncryptBlock(inputToCipher, key);
				Array.Copy(currentCipher, 0, result, (i + 1) * blockSize, blockSize);
				prevPlain = currentPlain;
				prevCipher = currentCipher;
			}

			return result;
		}

		public byte[] Decrypt(byte[] encryptedData, byte[] key)
		{
			int blockSize = _cipher.BlockSize;
			byte[] iv = new byte[blockSize];
			Array.Copy(encryptedData, 0, iv, 0, blockSize);

			int dataLength = encryptedData.Length - blockSize;
			byte[] actualData = new byte[dataLength];
			Array.Copy(encryptedData, blockSize, actualData, 0, dataLength);

			int blockCount = actualData.Length / blockSize;
			byte[] decryptedPadded = new byte[dataLength];

			byte[] prevPlain = new byte[blockSize];
			byte[] prevCipher = new byte[blockSize];
			Array.Copy(iv, prevPlain, blockSize);
			Array.Copy(iv, prevCipher, blockSize);

			for (int i = 0; i < blockCount; i++)
			{
				byte[] currentCipher = new byte[blockSize];
				Array.Copy(actualData, i * blockSize, currentCipher, 0, blockSize);
				byte[] decryptedBlock = _cipher.DecryptBlock(currentCipher, key);
				byte[] currentPlain = XorBlocks(decryptedBlock, prevPlain, prevCipher);
				Array.Copy(currentPlain, 0, decryptedPadded, i * blockSize, blockSize);
				prevPlain = currentPlain;
				prevCipher = currentCipher;
			}

			return RemovePadding(decryptedPadded);
		}

		private byte[] XorBlocks(byte[] b1, byte[] b2, byte[] b3)
		{
			byte[] result = new byte[b1.Length];
			for (int i = 0; i < b1.Length; i++)
			{
				result[i] = (byte)(b1[i] ^ b2[i] ^ b3[i]);
			}
			return result;
		}

		private byte[] AddPadding(byte[] data, int blockSize)
		{
			int paddingBytes = blockSize - (data.Length % blockSize);
			byte[] output = new byte[data.Length + paddingBytes];
			Array.Copy(data, output, data.Length);

			for (int i = 0; i < paddingBytes; i++)
			{
				output[data.Length + i] = (byte)paddingBytes;
			}

			return output;
		}

		private byte[] RemovePadding(byte[] data)
		{
			int paddingBytes = data[data.Length - 1];
			if (paddingBytes < 1 || paddingBytes > _cipher.BlockSize)
				throw new Exception("Invalid padding or wrong key used!");

			byte[] output = new byte[data.Length - paddingBytes];
			Array.Copy(data, output, output.Length);
			return output;
		}
	}
}
