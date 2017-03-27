﻿namespace TimeHACK.Engine.Template
{
    partial class WinClassic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinClassic));
            this.program = new System.Windows.Forms.Panel();
            this.programContent = new System.Windows.Forms.Panel();
            this.programtopbar = new System.Windows.Forms.Panel();
            this.maximizebutton = new System.Windows.Forms.PictureBox();
            this.minimizebutton = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.closebutton = new System.Windows.Forms.PictureBox();
            this.toprightcorner = new System.Windows.Forms.Panel();
            this.bottomrightcorner = new System.Windows.Forms.Panel();
            this.bottomleftcorner = new System.Windows.Forms.Panel();
            this.topleftcorner = new System.Windows.Forms.Panel();
            this.left = new System.Windows.Forms.Panel();
            this.bottom = new System.Windows.Forms.Panel();
            this.right = new System.Windows.Forms.Panel();
            this.top = new System.Windows.Forms.Panel();
            this.programIcon = new System.Windows.Forms.PictureBox();
            this.program.SuspendLayout();
            this.programtopbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximizebutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizebutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closebutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // program
            // 
            this.program.BackColor = System.Drawing.Color.Silver;
            this.program.Controls.Add(this.programContent);
            this.program.Controls.Add(this.programtopbar);
            this.program.Controls.Add(this.toprightcorner);
            this.program.Controls.Add(this.bottomrightcorner);
            this.program.Controls.Add(this.bottomleftcorner);
            this.program.Controls.Add(this.topleftcorner);
            this.program.Controls.Add(this.left);
            this.program.Controls.Add(this.bottom);
            this.program.Controls.Add(this.right);
            this.program.Controls.Add(this.top);
            this.program.Dock = System.Windows.Forms.DockStyle.Fill;
            this.program.Location = new System.Drawing.Point(0, 0);
            this.program.Name = "program";
            this.program.Size = new System.Drawing.Size(300, 300);
            this.program.TabIndex = 8;
            // 
            // programContent
            // 
            this.programContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programContent.Location = new System.Drawing.Point(4, 22);
            this.programContent.Name = "programContent";
            this.programContent.Size = new System.Drawing.Size(292, 274);
            this.programContent.TabIndex = 9;
            // 
            // programtopbar
            // 
            this.programtopbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(170)))));
            this.programtopbar.Controls.Add(this.programIcon);
            this.programtopbar.Controls.Add(this.maximizebutton);
            this.programtopbar.Controls.Add(this.minimizebutton);
            this.programtopbar.Controls.Add(this.Title);
            this.programtopbar.Controls.Add(this.closebutton);
            this.programtopbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.programtopbar.Location = new System.Drawing.Point(4, 4);
            this.programtopbar.Name = "programtopbar";
            this.programtopbar.Size = new System.Drawing.Size(292, 18);
            this.programtopbar.TabIndex = 0;
            this.programtopbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.programtopbar_drag);
            // 
            // maximizebutton
            // 
            this.maximizebutton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.maximizebutton.Image = global::TimeHACK.Engine.Properties.Resources.WinClassicMax;
            this.maximizebutton.Location = new System.Drawing.Point(257, 2);
            this.maximizebutton.Name = "maximizebutton";
            this.maximizebutton.Size = new System.Drawing.Size(16, 14);
            this.maximizebutton.TabIndex = 6;
            this.maximizebutton.TabStop = false;
            this.maximizebutton.Click += new System.EventHandler(this.maximizebutton_Click);
            // 
            // minimizebutton
            // 
            this.minimizebutton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.minimizebutton.Image = global::TimeHACK.Engine.Properties.Resources.WinClassicMin;
            this.minimizebutton.Location = new System.Drawing.Point(241, 2);
            this.minimizebutton.Name = "minimizebutton";
            this.minimizebutton.Size = new System.Drawing.Size(16, 14);
            this.minimizebutton.TabIndex = 5;
            this.minimizebutton.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = fnt;
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(23, 3);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(99, 13);
            this.Title.TabIndex = 3;
            this.Title.Text = "Application Title";
            // 
            // closebutton
            // 
            this.closebutton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.closebutton.Image = global::TimeHACK.Engine.Properties.Resources.WinClassicClose;
            this.closebutton.Location = new System.Drawing.Point(275, 2);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(16, 14);
            this.closebutton.TabIndex = 4;
            this.closebutton.TabStop = false;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // toprightcorner
            // 
            this.toprightcorner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toprightcorner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toprightcorner.BackgroundImage")));
            this.toprightcorner.Location = new System.Drawing.Point(296, 0);
            this.toprightcorner.Name = "toprightcorner";
            this.toprightcorner.Size = new System.Drawing.Size(4, 4);
            this.toprightcorner.TabIndex = 6;
            // 
            // bottomrightcorner
            // 
            this.bottomrightcorner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomrightcorner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bottomrightcorner.BackgroundImage")));
            this.bottomrightcorner.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.bottomrightcorner.Location = new System.Drawing.Point(296, 296);
            this.bottomrightcorner.Name = "bottomrightcorner";
            this.bottomrightcorner.Size = new System.Drawing.Size(4, 4);
            this.bottomrightcorner.TabIndex = 4;
            // 
            // bottomleftcorner
            // 
            this.bottomleftcorner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bottomleftcorner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bottomleftcorner.BackgroundImage")));
            this.bottomleftcorner.Location = new System.Drawing.Point(0, 296);
            this.bottomleftcorner.Name = "bottomleftcorner";
            this.bottomleftcorner.Size = new System.Drawing.Size(4, 4);
            this.bottomleftcorner.TabIndex = 2;
            // 
            // topleftcorner
            // 
            this.topleftcorner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topleftcorner.BackgroundImage")));
            this.topleftcorner.Location = new System.Drawing.Point(0, 0);
            this.topleftcorner.Name = "topleftcorner";
            this.topleftcorner.Size = new System.Drawing.Size(4, 4);
            this.topleftcorner.TabIndex = 1;
            // 
            // left
            // 
            this.left.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("left.BackgroundImage")));
            this.left.Dock = System.Windows.Forms.DockStyle.Left;
            this.left.Location = new System.Drawing.Point(0, 4);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(4, 292);
            this.left.TabIndex = 3;
            // 
            // bottom
            // 
            this.bottom.BackgroundImage = global::TimeHACK.Engine.Properties.Resources.BottomSide;
            this.bottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom.Location = new System.Drawing.Point(0, 296);
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(296, 4);
            this.bottom.TabIndex = 5;
            // 
            // right
            // 
            this.right.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("right.BackgroundImage")));
            this.right.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.right.Dock = System.Windows.Forms.DockStyle.Right;
            this.right.Location = new System.Drawing.Point(296, 4);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(4, 296);
            this.right.TabIndex = 7;
            // 
            // top
            // 
            this.top.BackgroundImage = global::TimeHACK.Engine.Properties.Resources.TopSide;
            this.top.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Location = new System.Drawing.Point(0, 0);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(300, 4);
            this.top.TabIndex = 8;
            // 
            // programIcon
            // 
            this.programIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.programIcon.ErrorImage = null;
            this.programIcon.InitialImage = null;
            this.programIcon.Location = new System.Drawing.Point(2, 1);
            this.programIcon.Name = "programIcon";
            this.programIcon.Size = new System.Drawing.Size(16, 16);
            this.programIcon.TabIndex = 0;
            this.programIcon.TabStop = false;
            // 
            // WinClassic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.program);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinClassic";
            this.Text = "WinClassic";
            this.program.ResumeLayout(false);
            this.programtopbar.ResumeLayout(false);
            this.programtopbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximizebutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizebutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closebutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel program;
        internal System.Windows.Forms.Panel programtopbar;
        internal System.Windows.Forms.Label Title;
        internal System.Windows.Forms.PictureBox closebutton;
        internal System.Windows.Forms.Panel toprightcorner;
        internal System.Windows.Forms.Panel bottomrightcorner;
        internal System.Windows.Forms.Panel bottomleftcorner;
        internal System.Windows.Forms.Panel topleftcorner;
        internal System.Windows.Forms.Panel left;
        internal System.Windows.Forms.Panel bottom;
        internal System.Windows.Forms.Panel right;
        internal System.Windows.Forms.Panel top;
        public System.Windows.Forms.Panel programContent;
        public System.Windows.Forms.PictureBox maximizebutton;
        public System.Windows.Forms.PictureBox minimizebutton;
        public System.Windows.Forms.PictureBox programIcon;
    }
}