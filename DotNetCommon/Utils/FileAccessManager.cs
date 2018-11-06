using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotNetCommon.Utils
{
	public sealed class FileAccessManager
	{
		private static FileAccessManager _Instance=new FileAccessManager();
		private Dictionary<string,FileManaged> Files { get; set; }
		public List<string> FilePaths=> Files.Keys.ToList();
		public static FileAccessManager Instance => _Instance;

		private FileAccessManager()
		{
			Files = new Dictionary<string,FileManaged>();
		}

		public bool Contains(string path)
		{
			return Files.ContainsKey(path);
		}

		public void Add(string path,bool open = true, FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read, FileShare share = FileShare.ReadWrite)
		{
			if(!File.Exists(path))
			{
				throw new ArgumentException(string.Format("{0} is not exists.",path));
			}
			if(Files.ContainsKey(path))
			{
				Remove(path);
			}

			Files.Add(path,new FileManaged(path,mode,access,share));
			if(open)
			{
				Files[path].Open();
			}
		}

		public void Remove(string path)
		{
			Files[path].Close();
			Files.Remove(path);
		}

		public void Open(string path)
		{
			Files[path].Open();
		}

		public void OpenAll()
		{
			foreach(FileManaged fileManaged in Files.Values)
			{
				fileManaged.Open();
			}
		}

		public void Close(string path)
		{
			Files[path].Close();
		}

		public void CloseAll()
		{
			foreach (FileManaged fileManaged in Files.Values)
			{
				fileManaged.Close();
			}
		}

		public bool IsOpened(string path)
		{
			return Files[path].IsOpen;
		}

		public void SetAccessMode(string path, FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read, FileShare share = FileShare.ReadWrite)
		{
			Files[path].SetAccessMode(mode,access,share);
		}

		public void Clear()
		{
			foreach (FileManaged fileManaged in Files.Values)
			{
				fileManaged.Close();
			}
			Files.Clear();
		}

		public bool CanAccess(string path, FileMode mode, FileAccess access, FileShare share)
		{
			try
			{
				using (var fileStream = new FileStream(path, mode, access, share))
				{
					return true;
				}
			}
			catch(IOException e)
			{
				return false;
			}
		}

		public bool CanRead(string path)
		{
			try
			{
				using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read,FileShare.Read))
				{
					return true;
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e);
				return false;
			}
		}

		public bool CanWrite(string path)
		{
			try
			{
				using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Write))
				{
					return true;
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e);
				return false;
			}
		}

		private class FileManaged
		{
			public string FilePath { get; private set; }
			public FileMode Mode { private get; set; }
			public FileAccess Access { private get; set; }
			public FileShare Share { private get; set; }
			public bool IsOpen{get{ return FileStream != null; }}
			private FileStream FileStream { get; set; }

			public FileManaged(string filePath,FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read, FileShare share = FileShare.ReadWrite)
			{
				FilePath = filePath;
				Mode = mode;
				Access = access;
				Share = share;
			}

			public void Open()
			{
				FileStream = new FileStream(FilePath, Mode, Access, Share);	
			}

			public void Close()
			{
				FileStream?.Close();
				FileStream = null;
			}

			public void SetAccessMode(FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read, FileShare share = FileShare.ReadWrite)
			{
				Close();
				Mode = mode;
				Access = access;
				Share = share;
				Open();
			}
		}

		
	}
}
