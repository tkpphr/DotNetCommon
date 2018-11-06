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
