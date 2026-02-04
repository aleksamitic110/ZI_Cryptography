using System;
using System.IO;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;

namespace ZI_Cryptography.ZI_Cryptography_App.Core.Hashing
{
	public class Sha1Hasher : IHasher
	{
		public string Name => "SHA-1";

		public byte[] ComputeHash(byte[] data)
		{
			if (data == null) throw new ArgumentNullException(nameof(data));
			using var ms = new MemoryStream(data, writable: false);
			return ComputeHash(ms);
		}

		public byte[] ComputeHash(Stream stream, int bufferSize = 8192)
		{
			if (stream == null) throw new ArgumentNullException(nameof(stream));
			if (!stream.CanRead) throw new InvalidOperationException("Hash stream must be readable.");
			if (bufferSize < 64) bufferSize = 64;

			uint h0 = 0x67452301;
			uint h1 = 0xEFCDAB89;
			uint h2 = 0x98BADCFE;
			uint h3 = 0x10325476;
			uint h4 = 0xC3D2E1F0;

			ulong totalBytes = 0;
			byte[] readBuffer = new byte[bufferSize];
			byte[] blockBuffer = new byte[64];
			int blockBufferLen = 0;

			while (true)
			{
				int read = stream.Read(readBuffer, 0, readBuffer.Length);
				if (read <= 0) break;

				totalBytes += (ulong)read;
				int offset = 0;

				while (offset < read)
				{
					int toCopy = Math.Min(64 - blockBufferLen, read - offset);
					Buffer.BlockCopy(readBuffer, offset, blockBuffer, blockBufferLen, toCopy);
					blockBufferLen += toCopy;
					offset += toCopy;

					if (blockBufferLen == 64)
					{
						ProcessBlock(blockBuffer, ref h0, ref h1, ref h2, ref h3, ref h4);
						blockBufferLen = 0;
					}
				}
			}

			FinalizeHash(blockBuffer, blockBufferLen, totalBytes, ref h0, ref h1, ref h2, ref h3, ref h4);

			byte[] result = new byte[20];
			ToBigEndianBytes(h0, result, 0);
			ToBigEndianBytes(h1, result, 4);
			ToBigEndianBytes(h2, result, 8);
			ToBigEndianBytes(h3, result, 12);
			ToBigEndianBytes(h4, result, 16);
			return result;
		}

		private void ProcessBlock(byte[] block, ref uint h0, ref uint h1, ref uint h2, ref uint h3, ref uint h4)
		{
			uint[] w = new uint[80];

			for (int j = 0; j < 16; j++)
			{
				int i = j * 4;
				w[j] = (uint)(block[i] << 24)
					 | (uint)(block[i + 1] << 16)
					 | (uint)(block[i + 2] << 8)
					 | block[i + 3];
			}

			for (int j = 16; j < 80; j++)
			{
				w[j] = RotateLeft(w[j - 3] ^ w[j - 8] ^ w[j - 14] ^ w[j - 16], 1);
			}

			uint a = h0;
			uint b = h1;
			uint c = h2;
			uint d = h3;
			uint e = h4;

			for (int j = 0; j < 80; j++)
			{
				uint f;
				uint k;

				if (j < 20)
				{
					f = (b & c) | ((~b) & d);
					k = 0x5A827999;
				}
				else if (j < 40)
				{
					f = b ^ c ^ d;
					k = 0x6ED9EBA1;
				}
				else if (j < 60)
				{
					f = (b & c) | (b & d) | (c & d);
					k = 0x8F1BBCDC;
				}
				else
				{
					f = b ^ c ^ d;
					k = 0xCA62C1D6;
				}

				uint temp = RotateLeft(a, 5) + f + e + k + w[j];
				e = d;
				d = c;
				c = RotateLeft(b, 30);
				b = a;
				a = temp;
			}

			h0 += a;
			h1 += b;
			h2 += c;
			h3 += d;
			h4 += e;
		}

		private void FinalizeHash(byte[] tailBlock, int tailLen, ulong totalBytes, ref uint h0, ref uint h1, ref uint h2, ref uint h3, ref uint h4)
		{
			byte[] finalData = new byte[128];
			Buffer.BlockCopy(tailBlock, 0, finalData, 0, tailLen);

			finalData[tailLen] = 0x80;

			ulong bitLength = totalBytes * 8;
			int lengthPos = (tailLen + 1 <= 56) ? 56 : 120;

			for (int i = 0; i < 8; i++)
			{
				finalData[lengthPos + i] = (byte)(bitLength >> (56 - (i * 8)));
			}

			ProcessBlock(finalData, ref h0, ref h1, ref h2, ref h3, ref h4);
			if (lengthPos == 120)
			{
				byte[] second = new byte[64];
				Buffer.BlockCopy(finalData, 64, second, 0, 64);
				ProcessBlock(second, ref h0, ref h1, ref h2, ref h3, ref h4);
			}
		}

		private uint RotateLeft(uint value, int count)
		{
			return (value << count) | (value >> (32 - count));
		}

		private void ToBigEndianBytes(uint value, byte[] array, int offset)
		{
			array[offset] = (byte)(value >> 24);
			array[offset + 1] = (byte)(value >> 16);
			array[offset + 2] = (byte)(value >> 8);
			array[offset + 3] = (byte)value;
		}
	}
}
