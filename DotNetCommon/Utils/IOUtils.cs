/*
Copyright 2018 tkpphr

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
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
