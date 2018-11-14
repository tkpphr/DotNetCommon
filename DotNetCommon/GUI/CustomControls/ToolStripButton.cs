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
