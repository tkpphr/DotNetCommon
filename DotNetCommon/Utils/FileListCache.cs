﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DotNetCommon.Utils
{
	/// <summary>
	/// Store the file list to xml.
	/// </summary>
	/// <example> 
	/// For use recent file list.
	/// </example>
	public class FileListCache
	{
		private string CacheName { get; set; }
		private int Limit { get; set; }
		private bool CheckExistsFile { get; set; }
		private bool CheckDistinct { get; set; }
		public string CachePath => Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\" + CacheName + ".xml";
		public bool Exists => File.Exists(CachePath);
		public bool CanRead
		{
			get
			{
				try
				{
					using (var fileStream = new FileStream(CachePath, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						return true;
					}
				}
				catch(IOException e)
				{
					Console.WriteLine(e);
					return false;
				}
			}
		}
		public bool CanWrite
		{
			get
			{
				try
				{
					using (var fileStream=new FileStream(CachePath, FileMode.Open, FileAccess.Write, FileShare.Write))
					{
						return true;
					}
				}
				catch(IOException e)
				{
					Console.WriteLine(e);
					return false;
				}
			}
		}

		public FileListCache(string cacheName,int limit,bool checkExistsFile = true,bool checkDistinct = true)
		{
			if (limit < 0)
			{
				throw new ArgumentException("limit must be greater than -1.");
			}
			CacheName = cacheName;
			Limit = limit;
			CheckExistsFile = checkExistsFile;
			CheckDistinct = checkDistinct;
		}

		public void Add(string filePath)
		{
			var filePaths=new List<string>();
			if (File.Exists(CachePath))
			{
				filePaths.AddRange(GetFiles());
				filePaths.Insert(0, filePath);
				if (CheckDistinct)
				{
					filePaths = filePaths.Distinct().ToList();
				}
				if (filePaths.Count > Limit)
				{
					filePaths = filePaths.GetRange(0, Limit);
				}
			}
			else
			{
				filePaths.Add(filePath);
			}
			AddFiles(filePaths);
		}

		public void AddFiles(List<string> filePaths)
		{
			var serializer = new XmlSerializer(typeof(List<string>));
			using (var fileStream = new FileStream(CachePath,FileMode.Create,FileAccess.Write,FileShare.Write))
			{
				using (var streamWriter=new StreamWriter(fileStream, new UTF8Encoding(false)))
				{
					serializer.Serialize(streamWriter, filePaths);
				}
			}
		}

		public List<string> GetFiles()
		{
			var serializer = new XmlSerializer(typeof(List<string>));				
			using (var fileStream = new FileStream(CachePath,FileMode.Open,FileAccess.Read,FileShare.Read))
			{
				using (var streamReader=new StreamReader(fileStream,new UTF8Encoding(false)))
				{
					var files = (List<string>)serializer.Deserialize(streamReader);
					if (CheckExistsFile)
					{
						return files.Where(filePath => File.Exists(filePath)).ToList();
					}
					else
					{
						return files;
					}
				}
			}
		}

		public string GetFile(int index)
		{
			return GetFiles()[index];
		}

		public void Clear()
		{
			AddFiles(new List<string>());
		}

	}
}
