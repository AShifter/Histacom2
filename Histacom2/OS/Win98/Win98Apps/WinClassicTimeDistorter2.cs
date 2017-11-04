﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Histacom2.OS.Win98.Win98Apps
{
    public partial class WinClassicTimeDistorter2 : UserControl
    {
        public int secsLeft = 120;

        public WinClassicTimeDistorter2()
        {
            InitializeComponent();
        }

        private void classicButton1_Click(object sender, EventArgs e)
        {
            classicButton1.Hide();
            classicLabel4.Show();
            classicLabel4.Text = "Preparing to travel. ETA: 120 secs.";
            timer1.Start();
            Story.Hack3.StartObjective(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            classicLabel4.Text = $"Preparing to travel. ETA: {secsLeft--} secs.";
        }
    }
}
