using DotNetCommon.GUI.Forms;
using DotNetCommon.Media;
using DotNetCommon.Media.Sound;
using DotNetCommon.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetCommon.Demo
{
	public partial class MainForm : FullScreenForm
	{
		private FileListCache RecentFiles { get; set; }
		private MCISound Sound { get; set; }

		public MainForm()
		{
			InitializeComponent();
			RecentFiles = new FileListCache("recent",8,false);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			RefreshScreenInfo();
			if(RecentFiles.Exists && RecentFiles.CanWrite)
			{
				RecentFiles.Clear();
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			RefreshScreenInfo();
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			Sound?.Dispose();
			FileAccessManager.Instance.Clear();
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg==MCI.MM_MCINOTIFY)
			{
				if ((int)m.WParam==MCI.MCI_NOTIFY_SUCCESS)
				{
					StopButton.PerformClick();
				}
			}
			base.WndProc(ref m);
		}


		private void RefreshScreenInfo()
		{
			if (Width==0 || Height==0 || ClientSize.Width==0 || ClientSize.Height==0 )
			{
				return;
			}
			
			var windowAspectRatio = MathUtils.AspectRatio(Width, Height);
			var clientAspectRatio = MathUtils.AspectRatio(ClientSize.Width, ClientSize.Height);
			ScreenInfoLabel.Text = string.Format("ScreenInfo\nSize(Window) : x:{0} , y:{1}\nAspectRatio(Window) : x:{2} , y:{3}\nSize(Client) : x:{4} , y:{5}\nAspectRatio(Client) : x:{6} , y:{7}",
				Width, Height,
				windowAspectRatio.X, windowAspectRatio.Y,
				ClientSize.Width, ClientSize.Height,
				clientAspectRatio.X, clientAspectRatio.Y);
		}

		private void FullScreenButton_Click(object sender, EventArgs e)
		{
			ToggleFullScreen();
		}

		private void OpenButton_Click(object sender, EventArgs e)
		{
			if (Sound!=null)
			{
				StopButton.PerformClick();
			}

			string soundPath = DialogUtils.ShowOpenFileDialog("Open Sound","Sound Files(*.wav)|*.wav|All Files(*.*)|*.*");
			if (!string.IsNullOrEmpty(soundPath))
			{
				SetSound(soundPath);
			}
		}

		private void PlayButton_Click(object sender, EventArgs e)
		{
			Sound?.Play();
			PlayButton.Enabled = false;
			StopButton.Enabled = true;
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			Sound?.Stop();
			PlayButton.Enabled = true;
			StopButton.Enabled = false;
		}

		private void RecentContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			if (!RecentFiles.Exists || !RecentFiles.CanRead)
			{
				return;
			}
			RecentContextMenuStrip.Items.Clear();
			var files = RecentFiles.GetFiles();
			if (files.Count == 0)
			{
				RecentContextMenuStrip.Items.Add(new ToolStripMenuItem() { Text = "None", Enabled = false });
			}
			else
			{
				files.Select(file => new ToolStripMenuItem()
				{
					Text = StringUtils.EllipsisBySeparator(file, "\\", 3),
					Enabled = File.Exists(file)
				})
				.ToList()
				.ForEach(menuItem =>
				{
					RecentContextMenuStrip.Items.Add(menuItem);
					menuItem.Click += RecentMenuItem_Click;
				});
			}
		}

		private void RecentMenuItem_Click(object sender, EventArgs e)
		{
			var menuItem = sender as ToolStripMenuItem;
			int index = RecentContextMenuStrip.Items.IndexOf(menuItem);
			string filePath = RecentFiles.GetFile(index);
			SetSound(filePath);
		}

		private void SetSound(string soundPath)
		{
			FileAccessManager.Instance.Clear();
			Sound?.Dispose();
			Sound = new MCISound(soundPath, "sound", Handle);
			SoundLabel.Text = soundPath;
			FileAccessManager.Instance.Add(SoundLabel.Text);
			if (!RecentFiles.Exists || RecentFiles.CanWrite)
			{
				RecentFiles.Add(soundPath);
			}
			PlayButton.Enabled = true;
			StopButton.Enabled = false;
		}
	}
}
