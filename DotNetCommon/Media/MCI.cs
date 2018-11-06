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
