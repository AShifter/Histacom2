﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Histacom2.GlobalPrograms
{
    public partial class WinClassicInstaller : UserControl
    {
        public string progName;
        public int state = 0;

        public WinClassicInstaller(string prog)
        {
            InitializeComponent();
            progName = prog;
        }

        private void WinClassicInstaller_Load(object sender, EventArgs e)
        {
            var welkom = new InstallerPanes.WelcomePane();
            welkom.Parent = panel1;
        }

        private void classicButton2_Click(object sender, EventArgs e)
        {
            classicButton3.Show();

            panel1.Controls.Clear();

            if (state == 0)
            {
                var eula = new InstallerPanes.EULAPane();
                eula.Parent = panel1;
                state = 1;
                classicButton2.Enabled = false;
            }
        }
    }
}
