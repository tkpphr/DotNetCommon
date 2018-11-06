using DotNetCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetCommon.Demo
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (!FormUtils.SingleStart(Application.ProductName,typeof(MainForm)))
			{
				MessageBox.Show("already started.");
			}
		}
	}
}
