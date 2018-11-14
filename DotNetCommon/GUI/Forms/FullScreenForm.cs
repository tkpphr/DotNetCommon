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
using System.Windows.Forms;

namespace DotNetCommon.GUI.Forms
{
	public partial class FullScreenForm : Form
	{
		private FormBorderStyle WindowedFormBorderStyle { get; set; }
		private FormWindowState WindowedWindowState { get; set; }
		public bool FullScreenShortcutEnabled { get; set; } = true;
		public bool IsFullScreen=> WindowState == FormWindowState.Maximized && FormBorderStyle == FormBorderStyle.None;

		public FullScreenForm()
		{
			InitializeComponent();
		}

		public void ToggleFullScreen()
		{
			if(IsFullScreen)
			{
				FormBorderStyle = WindowedFormBorderStyle;
				WindowState = WindowedWindowState;
			}
			else
			{
				WindowedFormBorderStyle = FormBorderStyle;
				WindowedWindowState = WindowState;
				if(WindowState==FormWindowState.Maximized)
				{
					WindowState = FormWindowState.Normal;
				}
				FormBorderStyle=FormBorderStyle.None;
				WindowState = FormWindowState.Maximized;
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if(keyData==(Keys.Alt | Keys.Enter))
			{
				if (FullScreenShortcutEnabled)
				{
					ToggleFullScreen();
				}
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
