using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZI_Cryptography.ZI_Cryptography_App.Core.Algorithms
{
	public class PlayfairCipher
	{
		private char[,] _keyTable;

		public string Encrypt(string input, string key)
		{
			GenerateKeyTable(key);
			string preparedText = PrepareText(input);
			return ProcessText(preparedText, true);
		}

		public string Decrypt(string input, string key)
		{
			GenerateKeyTable(key);
			return ProcessText(input, false);
		}

		private void GenerateKeyTable(string key)
		{
			_keyTable = new char[5, 5];
			string keyString = key.ToUpper().Replace("J", "I");
			keyString = new string(keyString.Where(char.IsLetter).ToArray());

			HashSet<char> usedChars = new HashSet<char>();
			List<char> keyList = new List<char>();

			foreach (char c in keyString)
			{
				if (!usedChars.Contains(c))
				{
					usedChars.Add(c);
					keyList.Add(c);
				}
			}

			for (char c = 'A'; c <= 'Z'; c++)
			{
				if (c == 'J') continue;
				if (!usedChars.Contains(c))
				{
					usedChars.Add(c);
					keyList.Add(c);
				}
			}

			int index = 0;
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					_keyTable[i, j] = keyList[index++];
				}
			}
		}

		private string PrepareText(string input)
		{
			string text = input.ToUpper().Replace("J", "I");
			text = new string(text.Where(char.IsLetter).ToArray());

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				char first = text[i];
				char second = (i + 1 < text.Length) ? text[i + 1] : 'X';

				if (first == second)
				{
					sb.Append(first);
					sb.Append('X');
				}
				else
				{
					sb.Append(first);
					sb.Append(second);
					i++;
				}
			}

			if (sb.Length % 2 != 0)
			{
				sb.Append('X');
			}

			return sb.ToString();
		}

		private string ProcessText(string text, bool encrypt)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < text.Length; i += 2)
			{
				char a = text[i];
				char b = text[i + 1];

				GetPosition(a, out int r1, out int c1);
				GetPosition(b, out int r2, out int c2);

				if (r1 == r2)
				{
					int shift = encrypt ? 1 : 4;
					result.Append(_keyTable[r1, (c1 + shift) % 5]);
					result.Append(_keyTable[r2, (c2 + shift) % 5]);
				}
				else if (c1 == c2)
				{
					int shift = encrypt ? 1 : 4;
					result.Append(_keyTable[(r1 + shift) % 5, c1]);
					result.Append(_keyTable[(r2 + shift) % 5, c2]);
				}
				else
				{
					result.Append(_keyTable[r1, c2]);
					result.Append(_keyTable[r2, c1]);
				}
			}

			return result.ToString();
		}

		private void GetPosition(char c, out int row, out int col)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (_keyTable[i, j] == c)
					{
						row = i;
						col = j;
						return;
					}
				}
			}

			throw new Exception($"Character {c} not found in table.");
		}
	}
}
