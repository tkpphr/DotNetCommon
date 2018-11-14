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
using System.Text;
using static DotNetCommon.Media.MCI;

namespace DotNetCommon.Media.Sound
{
	public class MCISound : IDisposable
	{
		private IntPtr Handle { get; set; }
		public string AliasName { get; private set; }
		public int Position
		{
			get
			{
				var buffer = new StringBuilder(10);
				mciSendString(string.Format("status {0} position", AliasName), buffer, buffer.Capacity, Handle);
				int position;
				if (int.TryParse(buffer.ToString(), out position))
				{
					return position;
				}
				else
				{
					return 0;
				}
			}
		}
		public int Length
		{
			get
			{
				var buffer = new StringBuilder(10);
				mciSendString(string.Format("status {0} length", AliasName), buffer, buffer.Capacity, Handle);
				int length;
				if (int.TryParse(buffer.ToString(), out length))
				{
					return length;
				}
				else
				{
					return 0;
				}
			}
		}


		public MCISound(string filePath, string aliasName)
			: this(filePath, aliasName, IntPtr.Zero)
		{
		}

		public MCISound(string filePath, string aliasName, IntPtr handle)
		{
			AliasName = aliasName;
			Handle = handle;
			string command = "open \"" + filePath + "\" alias " + AliasName;
			if (mciSendString(command, null, 0, handle) != 0)
			{
				throw new ArgumentException("filePath or aliasName is invaild.");
			}
		}

		public void Dispose()
		{
			mciSendString("stop " + AliasName, null, 0, Handle);
			mciSendString("close " + AliasName, null, 0, Handle);
		}

		public void Play()
		{
			mciSendString(string.Format("play {0} notify", AliasName), null, 0, Handle);
		}

		public void Stop()
		{
			mciSendString(string.Format("stop {0}", AliasName), null, 0, Handle);
			mciSendString(string.Format("seek {0} to 0", AliasName), null, 0, Handle);
		}

		public State GetState()
		{
			var buffer = new StringBuilder(10);
			mciSendString(string.Format("status {0} mode", AliasName), buffer, buffer.Capacity, Handle);
			string state = buffer.ToString();
			if (state=="playing")
			{
				return State.Playing;
			}
			else if(state=="paused")
			{
				return State.Paused;
			}
			else if(state=="stopped")
			{
				return State.Stopped;
			}
			else
			{
				return State.Unknown;
			}
		}

		public enum State
		{
			Playing,
			Stopped,
			Paused,
			Unknown,
		}

	}
}
