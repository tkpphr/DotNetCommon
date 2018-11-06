namespace DotNetCommon.Demo
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ScreenInfoLabel = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.StopButton = new System.Windows.Forms.Button();
			this.PlayButton = new System.Windows.Forms.Button();
			this.OpenButton = new System.Windows.Forms.Button();
			this.SoundLabel = new System.Windows.Forms.Label();
			this.RecentToolStripButton = new DotNetCommon.GUI.CustomControls.ToolStripButton();
			this.RecentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FullScreenButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.RecentContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// ScreenInfoLabel
			// 
			this.ScreenInfoLabel.AutoSize = true;
			this.ScreenInfoLabel.Location = new System.Drawing.Point(12, 23);
			this.ScreenInfoLabel.Name = "ScreenInfoLabel";
			this.ScreenInfoLabel.Size = new System.Drawing.Size(59, 12);
			this.ScreenInfoLabel.TabIndex = 2;
			this.ScreenInfoLabel.Text = "ScreenInfo";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.StopButton);
			this.groupBox1.Controls.Add(this.PlayButton);
			this.groupBox1.Controls.Add(this.OpenButton);
			this.groupBox1.Controls.Add(this.SoundLabel);
			this.groupBox1.Controls.Add(this.RecentToolStripButton);
			this.groupBox1.Location = new System.Drawing.Point(14, 109);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(244, 78);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sound Test";
			// 
			// StopButton
			// 
			this.StopButton.Enabled = false;
			this.StopButton.Location = new System.Drawing.Point(114, 49);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(44, 23);
			this.StopButton.TabIndex = 4;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// PlayButton
			// 
			this.PlayButton.Enabled = false;
			this.PlayButton.Location = new System.Drawing.Point(64, 49);
			this.PlayButton.Name = "PlayButton";
			this.PlayButton.Size = new System.Drawing.Size(44, 23);
			this.PlayButton.TabIndex = 3;
			this.PlayButton.Text = "Play";
			this.PlayButton.UseVisualStyleBackColor = true;
			this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
			// 
			// OpenButton
			// 
			this.OpenButton.Location = new System.Drawing.Point(8, 49);
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(49, 23);
			this.OpenButton.TabIndex = 2;
			this.OpenButton.Text = "Open";
			this.OpenButton.UseVisualStyleBackColor = true;
			this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
			// 
			// SoundLabel
			// 
			this.SoundLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SoundLabel.Location = new System.Drawing.Point(6, 15);
			this.SoundLabel.Name = "SoundLabel";
			this.SoundLabel.Size = new System.Drawing.Size(232, 31);
			this.SoundLabel.TabIndex = 1;
			// 
			// RecentToolStripButton
			// 
			this.RecentToolStripButton.ContextMenuStrip = this.RecentContextMenuStrip;
			this.RecentToolStripButton.Location = new System.Drawing.Point(164, 49);
			this.RecentToolStripButton.Name = "RecentToolStripButton";
			this.RecentToolStripButton.Size = new System.Drawing.Size(74, 23);
			this.RecentToolStripButton.TabIndex = 0;
			this.RecentToolStripButton.Text = "Recent";
			this.RecentToolStripButton.UseVisualStyleBackColor = true;
			// 
			// RecentContextMenuStrip
			// 
			this.RecentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem});
			this.RecentContextMenuStrip.Name = "RecentContextMenuStrip";
			this.RecentContextMenuStrip.Size = new System.Drawing.Size(104, 26);
			this.RecentContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.RecentContextMenuStrip_Opening);
			// 
			// noneToolStripMenuItem
			// 
			this.noneToolStripMenuItem.Enabled = false;
			this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
			this.noneToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.noneToolStripMenuItem.Text = "None";
			// 
			// FullScreenButton
			// 
			this.FullScreenButton.Location = new System.Drawing.Point(152, 5);
			this.FullScreenButton.Name = "FullScreenButton";
			this.FullScreenButton.Size = new System.Drawing.Size(106, 20);
			this.FullScreenButton.TabIndex = 4;
			this.FullScreenButton.Text = "Toggle Fullscreen";
			this.FullScreenButton.UseVisualStyleBackColor = true;
			this.FullScreenButton.Click += new System.EventHandler(this.FullScreenButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(270, 194);
			this.Controls.Add(this.FullScreenButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ScreenInfoLabel);
			this.Name = "MainForm";
			this.Text = "DotNetCommonDemo";
			this.groupBox1.ResumeLayout(false);
			this.RecentContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label ScreenInfoLabel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.Button PlayButton;
		private System.Windows.Forms.Button OpenButton;
		private System.Windows.Forms.Label SoundLabel;
		private DotNetCommon.GUI.CustomControls.ToolStripButton RecentToolStripButton;
		private System.Windows.Forms.Button FullScreenButton;
		private System.Windows.Forms.ContextMenuStrip RecentContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
	}
}

