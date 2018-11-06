using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DotNetCommon.Utils
{
	public static class IOUtils
	{
		public static byte[] Serialize(this object obj)
		{
			if (obj==null)
			{
				return null;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (MemoryStream memoryStream=new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream,obj);
				return memoryStream.ToArray();
			}
		}

		public static object Deserialize(this byte[] data)
		{
			if (data==null)
			{
				return data;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (MemoryStream memoryStream=new MemoryStream(data)) {
				return binaryFormatter.Deserialize(memoryStream);
			}
		}

		public static byte[] ConvertFileToByteArray(string path)
		{
			if (string.IsNullOrEmpty(path) || !File.Exists(path))
			{
				return null;
			}
			try
			{

				using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					byte[] data = new byte[fileStream.Length];
					fileStream.Read(data, 0, data.Length);
					return data;
				}

			}
			catch (IOException e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		public static void WriteByteArrayToFile(string path,byte[] data)
		{
			try
			{
				using (var fileStream = new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite))
				{
					fileStream.Write(data, 0, data.Length);
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
