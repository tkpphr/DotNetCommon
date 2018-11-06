using System;
using System.Windows.Forms;

namespace DotNetCommon.Utils
{
	public static class ControlUtils
	{
		public static void ClearChildControls(this Control control)
		{
			if (control == null)
			{
				throw new ArgumentNullException();
			}
			ClearControlsRecurive(control);
		}

		private static void ClearControlsRecurive(Control parent)
		{
			foreach (Control child in parent.Controls)
			{ 
				ClearControlsRecurive(child);
				if (!child.IsDisposed)
				{
					child.Dispose();
				}
			}
			parent.Controls.Clear();
		}
	}
}
