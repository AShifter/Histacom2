﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeHACK.Engine;

namespace TimeHACK.OS.Win95.Win95Apps
{
    public partial class WinClassicThemePanel : UserControl
    {
        public WinClassicThemePanel()
        {
            InitializeComponent();
            applyButton.Paint += (sender, args) => Engine.Paintbrush.PaintClassicBorders(sender, args, 2);
            cancelButton.Paint += (sender, args) => Engine.Paintbrush.PaintClassicBorders(sender, args, 2);
            okButton.Paint += (sender, args) => Engine.Paintbrush.PaintClassicBorders(sender, args, 2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)comboBox1.SelectedItem)
            {
                case "Default":
                    pictureBox2.BackgroundImage = null;
                    break;
                case "Dangerous Creatures":
                    pictureBox2.BackgroundImage = Properties.Resources.DCTheme_BG;
                    break;
            }
        }

        private void WinClassicThemePanel_Load(object sender, EventArgs e)
        {
            switch (SaveSystem.CurrentSave.ThemeName)
            {
                case "default95":
                    comboBox1.SelectedItem = "Default";
                    break;
                case "dangeranimals":
                    comboBox1.SelectedItem = "Dangerous Creatures";
                    break;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            switch ((string)comboBox1.SelectedItem)
            {
                case "Default":
                    SaveSystem.currentTheme = new Default95Theme();
                    TitleScreen.frm95.BackgroundImage = null;
                    break;
                case "Dangerous Creatures":
                    SaveSystem.currentTheme = new DangerousCreaturesTheme();
                    TitleScreen.frm95.BackgroundImage = Properties.Resources.DCTheme_BG;
                    break;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            switch ((string)comboBox1.SelectedItem)
            {
                case "Default":
                    SaveSystem.currentTheme = new Default95Theme();
                    TitleScreen.frm95.BackgroundImage = null;
                    TitleScreen.frm95.desktopicons.BackgroundImage = null;
                    break;
                case "Dangerous Creatures":
                    SaveSystem.currentTheme = new DangerousCreaturesTheme();
                    TitleScreen.frm95.BackgroundImage = Properties.Resources.DCTheme_BG;
                    TitleScreen.frm95.desktopicons.BackgroundImage = new Bitmap(Properties.Resources.DCTheme_BG, TitleScreen.frm95.desktopicons.Width, TitleScreen.frm95.desktopicons.Height);
                    break;
            }
            ParentForm.Close();
        }
    }
}
