using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetCommon.GUI.CustomControls
{
	public class ToolStripButton : Button
	{
		
		public ToolStripButton()
			: base()
		{
			
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			if(ContextMenuStrip==null || ContextMenuStrip.Items.Count == 0)
			{
				return;
			}
			ContextMenuStrip.Show(this, new Point(0, Height),ToolStripDropDownDirection.BelowRight);
		}


		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			var g = pevent.Graphics;
			var p1 = new Point(Width - 15, (int)((Height/2)*0.9f));
			var p2 = new Point(Width - 5, p1.Y);
			var p3 = new Point(Width - 10, p1.Y+5);
			using (var brush=new SolidBrush(Color.Black))
			{
				g.FillPolygon(brush, new Point[] { p1, p2, p3 });
			}
		}


	}
}
