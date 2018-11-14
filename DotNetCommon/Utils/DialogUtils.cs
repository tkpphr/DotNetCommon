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
