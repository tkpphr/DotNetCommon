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

namespace DotNetCommon.Media
{
	public static class MCI
	{
		public static readonly int MM_MCINOTIFY = 0x03b9;
		public static readonly int MCI_NOTIFY_SUCCESS = 0x01;
		public static readonly int MCI_NOTIFY_SUPERSEDED = 0x02;
		public static readonly int MCI_NOTIFY_ABORTED = 0x04;
		public static readonly int MCI_NOTIFY_FAILURE = 0x08;

		[System.Runtime.InteropServices.DllImport("winmm.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern int mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
	}
}
