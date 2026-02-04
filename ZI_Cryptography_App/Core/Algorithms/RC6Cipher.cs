using System;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;

namespace ZI_Cryptography.ZI_Cryptography_App.Core.Algorithms
{
	public class RC6Cipher : IBlockCipher
	{
		private const int R = 20;
		private const uint P32 = 0xB7E15163;
		private const uint Q32 = 0x9E3779B9;
		private const int LG_W = 5;

		public int BlockSize => 16;

		public byte[] EncryptBlock(byte[] inputBlock, byte[] key)
		{
			if (inputBlock.Length != BlockSize)
				throw new ArgumentException($"Input block must be {BlockSize} bytes.");

			uint[] S = GenerateSubkeys(key);
			uint A = BitConverter.ToUInt32(inputBlock, 0);
			uint B = BitConverter.ToUInt32(inputBlock, 4);
			uint C = BitConverter.ToUInt32(inputBlock, 8);
			uint D = BitConverter.ToUInt32(inputBlock, 12);

			B += S[0];
			D += S[1];

			for (int i = 1; i <= R; i++)
			{
				uint t = RotateLeft(B * (2 * B + 1), LG_W);
				uint u = RotateLeft(D * (2 * D + 1), LG_W);
				A = RotateLeft(A ^ t, (int)u) + S[2 * i];
				C = RotateLeft(C ^ u, (int)t) + S[2 * i + 1];

				uint temp = A;
				A = B;
				B = C;
				C = D;
				D = temp;
			}

			A += S[2 * R + 2];
			C += S[2 * R + 3];

			byte[] output = new byte[16];
			Buffer.BlockCopy(BitConverter.GetBytes(A), 0, output, 0, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(B), 0, output, 4, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(C), 0, output, 8, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(D), 0, output, 12, 4);
			return output;
		}

		public byte[] DecryptBlock(byte[] inputBlock, byte[] key)
		{
			if (inputBlock.Length != BlockSize)
				throw new ArgumentException($"Input block must be {BlockSize} bytes.");

			uint[] S = GenerateSubkeys(key);
			uint A = BitConverter.ToUInt32(inputBlock, 0);
			uint B = BitConverter.ToUInt32(inputBlock, 4);
			uint C = BitConverter.ToUInt32(inputBlock, 8);
			uint D = BitConverter.ToUInt32(inputBlock, 12);

			C -= S[2 * R + 3];
			A -= S[2 * R + 2];

			for (int i = R; i >= 1; i--)
			{
				uint temp = D;
				D = C;
				C = B;
				B = A;
				A = temp;

				uint u = RotateLeft(D * (2 * D + 1), LG_W);
				uint t = RotateLeft(B * (2 * B + 1), LG_W);
				C = RotateRight(C - S[2 * i + 1], (int)t) ^ u;
				A = RotateRight(A - S[2 * i], (int)u) ^ t;
			}

			D -= S[1];
			B -= S[0];

			byte[] output = new byte[16];
			Buffer.BlockCopy(BitConverter.GetBytes(A), 0, output, 0, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(B), 0, output, 4, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(C), 0, output, 8, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(D), 0, output, 12, 4);
			return output;
		}

		private uint[] GenerateSubkeys(byte[] key)
		{
			int c = key.Length / 4;
			if (key.Length % 4 != 0) c++;

			uint[] L = new uint[c];
			for (int i = 0; i < c; i++)
			{
				int length = Math.Min(4, key.Length - i * 4);
				byte[] temp = new byte[4];
				Array.Copy(key, i * 4, temp, 0, length);
				L[i] = BitConverter.ToUInt32(temp, 0);
			}

			int t = 2 * R + 4;
			uint[] S = new uint[t];
			S[0] = P32;
			for (int i = 1; i < t; i++)
			{
				S[i] = S[i - 1] + Q32;
			}

			uint A = 0;
			uint B = 0;
			int i_idx = 0;
			int j_idx = 0;
			int v = 3 * Math.Max(c, t);

			for (int s = 1; s <= v; s++)
			{
				A = S[i_idx] = RotateLeft(S[i_idx] + A + B, 3);
				B = L[j_idx] = RotateLeft(L[j_idx] + A + B, (int)(A + B));
				i_idx = (i_idx + 1) % t;
				j_idx = (j_idx + 1) % c;
			}

			return S;
		}

		private uint RotateLeft(uint value, int count)
		{
			count &= 0x1F;
			return (value << count) | (value >> (32 - count));
		}

		private uint RotateRight(uint value, int count)
		{
			count &= 0x1F;
			return (value >> count) | (value << (32 - count));
		}
	}
}
