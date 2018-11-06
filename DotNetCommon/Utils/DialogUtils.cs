using System.Drawing;
using System.Windows.Forms;

namespace DotNetCommon.Utils
{
	public static class DialogUtils
	{
		public static string ShowOpenFileDialog(string title, string filter)
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.InitialDirectory = @"";
				dialog.Title = title;
				dialog.Filter = filter;
				dialog.FilterIndex = 1;
				dialog.RestoreDirectory = true;
				return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : "";
			}
		}

		public static string ShowSaveFileDialog(string title, string filter, string fileName = "")
		{
			using (SaveFileDialog dialog = new SaveFileDialog())
			{
				dialog.InitialDirectory = @"";
				dialog.Title = title;
				dialog.Filter = filter;
				dialog.FileName = fileName;
				dialog.FilterIndex = 1;
				dialog.RestoreDirectory = true;
				return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : "";
			}
		}

		public static Color ShowColorDialog(Color selectedColor)
		{
			using (ColorDialog dialog = new ColorDialog())
			{
				return dialog.ShowDialog() == DialogResult.OK ? dialog.Color : selectedColor;
			}
		}
	}
}
