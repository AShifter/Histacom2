﻿namespace Histacom2.OS.Win95.Win95Apps
{
    partial class WinClassicWelcome
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgTip = new System.Windows.Forms.PictureBox();
            this.imgPnl = new System.Windows.Forms.PictureBox();
            this.imgWelcome = new System.Windows.Forms.PictureBox();
            this.btnClose = new Histacom2.Engine.UI.ClassicButton();
            this.btnOnline = new Histacom2.Engine.UI.ClassicButton();
            this.btnTour = new Histacom2.Engine.UI.ClassicButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPnl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWelcome)).BeginInit();
            this.SuspendLayout();
            // 
            // imgTip
            // 
            this.imgTip.BackgroundImage = global::Histacom2.Properties.Resources.win95_welcometip;
            this.imgTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imgTip.Location = new System.Drawing.Point(16, 49);
            this.imgTip.Name = "imgTip";
            this.imgTip.Size = new System.Drawing.Size(330, 255);
            this.imgTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTip.TabIndex = 17;
            this.imgTip.TabStop = false;
            // 
            // imgPnl
            // 
            this.imgPnl.Image = global::Histacom2.Properties.Resources.win95_splitter;
            this.imgPnl.Location = new System.Drawing.Point(358, 142);
            this.imgPnl.Name = "imgPnl";
            this.imgPnl.Size = new System.Drawing.Size(112, 2);
            this.imgPnl.TabIndex = 16;
            this.imgPnl.TabStop = false;
            // 
            // imgWelcome
            // 
            this.imgWelcome.BackgroundImage = global::Histacom2.Properties.Resources.win95_welcome;
            this.imgWelcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imgWelcome.Location = new System.Drawing.Point(19, 17);
            this.imgWelcome.Name = "imgWelcome";
            this.imgWelcome.Size = new System.Drawing.Size(292, 19);
            this.imgWelcome.TabIndex = 18;
            this.imgWelcome.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(358, 156);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 26);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOnline
            // 
            this.btnOnline.BackColor = System.Drawing.Color.Silver;
            this.btnOnline.ForeColor = System.Drawing.Color.Black;
            this.btnOnline.Location = new System.Drawing.Point(356, 78);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(115, 26);
            this.btnOnline.TabIndex = 14;
            this.btnOnline.Text = "&Online Registration";
            // 
            // btnTour
            // 
            this.btnTour.BackColor = System.Drawing.Color.Silver;
            this.btnTour.ForeColor = System.Drawing.Color.Black;
            this.btnTour.Location = new System.Drawing.Point(356, 49);
            this.btnTour.Name = "btnTour";
            this.btnTour.Size = new System.Drawing.Size(115, 26);
            this.btnTour.TabIndex = 12;
            this.btnTour.Text = "What\'s &New";
            // 
            // WinClassicWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.imgWelcome);
            this.Controls.Add(this.imgTip);
            this.Controls.Add(this.imgPnl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOnline);
            this.Controls.Add(this.btnTour);
            this.Name = "WinClassicWelcome";
            this.Size = new System.Drawing.Size(483, 322);
            ((System.ComponentModel.ISupportInitialize)(this.imgTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPnl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWelcome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgTip;
        private System.Windows.Forms.PictureBox imgPnl;
        private Histacom2.Engine.UI.ClassicButton btnClose;
        private Histacom2.Engine.UI.ClassicButton btnOnline;
        private Histacom2.Engine.UI.ClassicButton btnTour;
        private System.Windows.Forms.PictureBox imgWelcome;
    }
}
