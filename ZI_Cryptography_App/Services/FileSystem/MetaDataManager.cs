using System;
using System.IO;
using System.Text;
using System.Text.Json;
using ZI_Cryptography.ZI_Cryptography_App.Interfaces;
using ZI_Cryptography.ZI_Cryptography_App.Models;

namespace ZI_Cryptography.ZI_Cryptography_App.Services.FileSystem
{
	public class MetadataManager : IMetadataManager
	{
		public byte[] CreateHeaderBytes(FileMetadata header)
		{
			string jsonString = header.ToJson();
			byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
			int length = jsonBytes.Length;
			byte[] lengthBytes = BitConverter.GetBytes(length);
			byte[] combined = new byte[4 + jsonBytes.Length];
			Array.Copy(lengthBytes, 0, combined, 0, 4);
			Array.Copy(jsonBytes, 0, combined, 4, jsonBytes.Length);

			return combined;
		}

		public FileMetadata ReadHeader(Stream stream)
		{
			byte[] lengthBytes = new byte[4];
			ReadExactly(stream, lengthBytes, 4);

			int jsonLength = BitConverter.ToInt32(lengthBytes, 0);
			if (jsonLength <= 0 || jsonLength > 1024 * 1024)
				throw new Exception("Invalid file format: Header length is out of bounds.");

			byte[] jsonBytes = new byte[jsonLength];
			ReadExactly(stream, jsonBytes, jsonLength);

			string jsonString = Encoding.UTF8.GetString(jsonBytes);

			try
			{
				var header = JsonSerializer.Deserialize<FileMetadata>(jsonString);
				return header ?? throw new Exception("Header is null.");
			}
			catch
			{
				throw new Exception("Corrupted metadata header.");
			}
		}

		private static void ReadExactly(Stream stream, byte[] buffer, int count)
		{
			int offset = 0;
			while (offset < count)
			{
				int read = stream.Read(buffer, offset, count - offset);
				if (read <= 0)
				{
					throw new Exception("Invalid file format: Incomplete header.");
				}

				offset += read;
			}
		}
	}
}
