﻿using Histacom2.OS.Win95;

namespace Histacom2.OS.WinXPBad
{
    partial class WindowsXPBad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsXPBad));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.taskbar = new System.Windows.Forms.Panel();
            this.clockPanel = new System.Windows.Forms.Panel();
            this.taskbartime = new System.Windows.Forms.Label();
            this.taskbarItems = new System.Windows.Forms.Panel();
            this.startbutton = new System.Windows.Forms.PictureBox();
            this.startmenu = new System.Windows.Forms.Panel();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.desktopImages = new System.Windows.Forms.ImageList(this.components);
            this.desktopicons = new System.Windows.Forms.ListView();
            this.rightclickbackproperties = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.desktopupdate = new System.Windows.Forms.Timer(this.components);
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.taskbar.SuspendLayout();
            this.clockPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startbutton)).BeginInit();
            this.startmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.rightclickbackproperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 571);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 29);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(54, 22);
            this.panel2.TabIndex = 1;
            // 
            // taskbar
            // 
            this.taskbar.BackColor = System.Drawing.Color.Silver;
            this.taskbar.BackgroundImage = global::Histacom2.Properties.Resources.WinXPTaskbarBG;
            this.taskbar.Controls.Add(this.clockPanel);
            this.taskbar.Controls.Add(this.taskbarItems);
            this.taskbar.Controls.Add(this.startbutton);
            this.taskbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.taskbar.Location = new System.Drawing.Point(0, 570);
            this.taskbar.Name = "taskbar";
            this.taskbar.Size = new System.Drawing.Size(800, 30);
            this.taskbar.TabIndex = 2;
            // 
            // clockPanel
            // 
            this.clockPanel.BackgroundImage = global::Histacom2.Properties.Resources.WinXPTaskbarTime;
            this.clockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clockPanel.Controls.Add(this.taskbartime);
            this.clockPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.clockPanel.Location = new System.Drawing.Point(735, 0);
            this.clockPanel.Name = "clockPanel";
            this.clockPanel.Size = new System.Drawing.Size(65, 30);
            this.clockPanel.TabIndex = 4;
            // 
            // taskbartime
            // 
            this.taskbartime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.taskbartime.AutoSize = true;
            this.taskbartime.BackColor = System.Drawing.Color.Transparent;
            this.taskbartime.ForeColor = System.Drawing.Color.White;
            this.taskbartime.Location = new System.Drawing.Point(18, 9);
            this.taskbartime.Name = "taskbartime";
            this.taskbartime.Size = new System.Drawing.Size(26, 13);
            this.taskbartime.TabIndex = 2;
            this.taskbartime.Text = "time";
            this.taskbartime.Click += new System.EventHandler(this.taskbartime_Click);
            // 
            // taskbarItems
            // 
            this.taskbarItems.BackColor = System.Drawing.Color.Transparent;
            this.taskbarItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.taskbarItems.Location = new System.Drawing.Point(105, 4);
            this.taskbarItems.Name = "taskbarItems";
            this.taskbarItems.Size = new System.Drawing.Size(3606, 22);
            this.taskbarItems.TabIndex = 5;
            // 
            // startbutton
            // 
            this.startbutton.Image = global::Histacom2.Properties.Resources.WinXPTaskbarStart;
            this.startbutton.Location = new System.Drawing.Point(0, 0);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(99, 30);
            this.startbutton.TabIndex = 3;
            this.startbutton.TabStop = false;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // startmenu
            // 
            this.startmenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startmenu.BackColor = System.Drawing.Color.White;
            this.startmenu.Controls.Add(this.pictureBox12);
            this.startmenu.Controls.Add(this.pictureBox11);
            this.startmenu.Controls.Add(this.pictureBox10);
            this.startmenu.Controls.Add(this.pictureBox9);
            this.startmenu.Controls.Add(this.pictureBox8);
            this.startmenu.Controls.Add(this.pictureBox7);
            this.startmenu.Controls.Add(this.pictureBox6);
            this.startmenu.Controls.Add(this.pictureBox5);
            this.startmenu.Controls.Add(this.pictureBox4);
            this.startmenu.Controls.Add(this.panel3);
            this.startmenu.Location = new System.Drawing.Point(0, 133);
            this.startmenu.Name = "startmenu";
            this.startmenu.Size = new System.Drawing.Size(380, 438);
            this.startmenu.TabIndex = 3;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuBottomLeft;
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Location = new System.Drawing.Point(2, 396);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(188, 1);
            this.pictureBox11.TabIndex = 8;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuBottomCenter2;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox10.Location = new System.Drawing.Point(2, 397);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(376, 41);
            this.pictureBox10.TabIndex = 7;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuBottomRight2;
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox9.Location = new System.Drawing.Point(378, 397);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(2, 41);
            this.pictureBox9.TabIndex = 6;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuBottomLeft2;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox8.Location = new System.Drawing.Point(0, 397);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(2, 41);
            this.pictureBox8.TabIndex = 5;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuRightGradient;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(190, 63);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(188, 3);
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuRight;
            this.pictureBox6.Location = new System.Drawing.Point(378, 63);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(2, 334);
            this.pictureBox6.TabIndex = 3;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuLeftGradient;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(2, 63);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(188, 3);
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuLeft;
            this.pictureBox4.Location = new System.Drawing.Point(0, 63);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(2, 334);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 63);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Blue;
            this.pictureBox3.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuTopCenter;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(8, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(364, 63);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.pictureBox2.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuTopRight;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Location = new System.Drawing.Point(372, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(8, 63);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.pictureBox1.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuTopLeft;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(8, 63);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // clockTimer
            // 
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // desktopImages
            // 
            this.desktopImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("desktopImages.ImageStream")));
            this.desktopImages.TransparentColor = System.Drawing.Color.Transparent;
            this.desktopImages.Images.SetKeyName(0, "");
            this.desktopImages.Images.SetKeyName(1, "WinClassicFolder.png");
            this.desktopImages.Images.SetKeyName(2, "WinClassicIE3.png");
            this.desktopImages.Images.SetKeyName(3, "WinClassicInbox.png");
            this.desktopImages.Images.SetKeyName(4, "WinClassicMSN.png");
            this.desktopImages.Images.SetKeyName(5, "WinClassicNetworking.png");
            this.desktopImages.Images.SetKeyName(6, "WinClassicOutlook.png");
            this.desktopImages.Images.SetKeyName(7, "WinClassicRecycle.png");
            this.desktopImages.Images.SetKeyName(8, "WinClassicSetup.png");
            this.desktopImages.Images.SetKeyName(9, "WinClassicSetup.png");
            this.desktopImages.Images.SetKeyName(10, "WinClassicSetup.png");
            this.desktopImages.Images.SetKeyName(11, "WinClassicSetup.png");
            // 
            // desktopicons
            // 
            this.desktopicons.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.desktopicons.BackColor = System.Drawing.Color.DodgerBlue;
            this.desktopicons.BackgroundImageTiled = true;
            this.desktopicons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.desktopicons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktopicons.ForeColor = System.Drawing.Color.White;
            this.desktopicons.LargeImageList = this.desktopImages;
            this.desktopicons.Location = new System.Drawing.Point(0, 0);
            this.desktopicons.Name = "desktopicons";
            this.desktopicons.Size = new System.Drawing.Size(800, 600);
            this.desktopicons.TabIndex = 6;
            this.desktopicons.UseCompatibleStateImageBehavior = false;
            this.desktopicons.DoubleClick += new System.EventHandler(this.desktopicons_DoubleClick);
            this.desktopicons.MouseDown += new System.Windows.Forms.MouseEventHandler(this.desktop_mousedown);
            // 
            // rightclickbackproperties
            // 
            this.rightclickbackproperties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem1,
            this.deleteToolStripMenuItem,
            this.PropertiesToolStripMenuItem1});
            this.rightclickbackproperties.Name = "ContextMenuStrip1";
            this.rightclickbackproperties.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.rightclickbackproperties.Size = new System.Drawing.Size(128, 70);
            // 
            // NewToolStripMenuItem1
            // 
            this.NewToolStripMenuItem1.BackColor = System.Drawing.Color.Silver;
            this.NewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FolderToolStripMenuItem,
            this.TextDocumentToolStripMenuItem});
            this.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1";
            this.NewToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.NewToolStripMenuItem1.Text = "New";
            // 
            // FolderToolStripMenuItem
            // 
            this.FolderToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.FolderToolStripMenuItem.Name = "FolderToolStripMenuItem";
            this.FolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.FolderToolStripMenuItem.Text = "Folder";
            this.FolderToolStripMenuItem.Click += new System.EventHandler(this.FolderToolStripMenuItem_Click);
            // 
            // TextDocumentToolStripMenuItem
            // 
            this.TextDocumentToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.TextDocumentToolStripMenuItem.Name = "TextDocumentToolStripMenuItem";
            this.TextDocumentToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.TextDocumentToolStripMenuItem.Text = "Text Document";
            this.TextDocumentToolStripMenuItem.Click += new System.EventHandler(this.TextDocumentToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // PropertiesToolStripMenuItem1
            // 
            this.PropertiesToolStripMenuItem1.BackColor = System.Drawing.Color.Silver;
            this.PropertiesToolStripMenuItem1.Name = "PropertiesToolStripMenuItem1";
            this.PropertiesToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.PropertiesToolStripMenuItem1.Text = "Properties";
            // 
            // desktopupdate
            // 
            this.desktopupdate.Enabled = true;
            this.desktopupdate.Interval = 5000;
            this.desktopupdate.Tick += new System.EventHandler(this.desktopupdate_Tick);
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackgroundImage = global::Histacom2.Properties.Resources.WinXPStartMenuBottomCenter;
            this.pictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox12.Location = new System.Drawing.Point(189, 396);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(1, 1);
            this.pictureBox12.TabIndex = 9;
            this.pictureBox12.TabStop = false;
            // 
            // WindowsXPBad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.startmenu);
            this.Controls.Add(this.taskbar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.desktopicons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowsXPBad";
            this.Tag = "ignoreFormOnTaskbar";
            this.Text = "Histacom2Desktop";
            this.Load += new System.EventHandler(this.Desktop_Load);
            this.panel1.ResumeLayout(false);
            this.taskbar.ResumeLayout(false);
            this.clockPanel.ResumeLayout(false);
            this.clockPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startbutton)).EndInit();
            this.startmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.rightclickbackproperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Panel taskbar;
        internal System.Windows.Forms.PictureBox startbutton;
        internal System.Windows.Forms.Label taskbartime;
        internal System.Windows.Forms.Panel startmenu;
        private System.Windows.Forms.Panel clockPanel;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.ImageList desktopImages;
        internal System.Windows.Forms.ListView desktopicons;
        internal System.Windows.Forms.ContextMenuStrip rightclickbackproperties;
        internal System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem FolderToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TextDocumentToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PropertiesToolStripMenuItem1;
        internal System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Windows95));
        private System.Windows.Forms.Panel taskbarItems;
        private System.Windows.Forms.Timer desktopupdate;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
    }
}