﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Histacom2.Engine;
using Histacom2.GlobalPrograms;

namespace Histacom2.OS.Win95.Win95Apps
{
    public partial class WinClassicFTPClient : UserControl
    {
        public WinClassicFTPClient()
        {
            InitializeComponent();

            hostnameBox.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
            usernameBox.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
            passBox.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (hostnameBox.Text == "172.68.119.42")
            {
                infoLabel.Hide();
                if (usernameBox.Text == "12padams")
                {
                    infoLabel.Hide();
                    if (passBox.Text == "projectDeath98")
                    {
                        infoLabel.Hide();
                        infoLabel.ForeColor = Color.Green;
                        infoLabel.Text = "[200] OK";
                        welcomeLabel.Hide();
                        infoLabel.Show();
                        ftpFiles.Show();
                    }
                    else
                    {
                        infoLabel.Text = "[430] Incorrect Password";
                        infoLabel.Show();
                    }
                }
                else
                {
                    infoLabel.Text = "[430] Incorrect Username";
                    infoLabel.Show();
                }
            }
            else
            {
                infoLabel.Text = "[404] Not Found";
                infoLabel.Show();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void WinClassicFTPClient_Load(object sender, EventArgs e)
        {
            textBox4.Text = "21";
        }

        private void topBar_Paint(object sender, PaintEventArgs e)
        {
            topBar.BackColor = SaveSystem.currentTheme.threeDObjectsColor;
        }

        private void ftpFiles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Point objDrawingPoint = ftpFiles.PointToClient(Cursor.Position);
                ListViewItem objListViewItem = new ListViewItem();
                if (objDrawingPoint != null)
                {
                    objListViewItem = ftpFiles.GetItemAt(objDrawingPoint.X, objDrawingPoint.Y);
                    if (objListViewItem.Text == "/software/")
                    {
                        ftpFiles.Clear();
                        ListViewItem listViewItem1 = new ListViewItem(new string[] { "/downloads/" }, 0, Color.Black, Color.Empty, null);
                        ListViewItem listViewItem2 = new ListViewItem(new string[] { "skindows.html" }, 1, Color.Black, Color.Empty, null);
                        ftpFiles.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
                    }
                    else if (objListViewItem.Text == "/downloads/")
                    {
                        ftpFiles.Clear();
                        ListViewItem listViewItem1 = new ListViewItem(new string[] { "/totallynotthetimedistorter/" }, 0, Color.Black, Color.Empty, null);
                        ListViewItem listViewItem2 = new ListViewItem(new string[] { "FTP Client Setup.exe" }, 2, Color.Black, Color.Empty, null);
                        ListViewItem listViewItem3 = new ListViewItem(new string[] { "Web Chat Setup.exe" }, 2, Color.Black, Color.Empty, null);
                        ListViewItem listViewItem4 = new ListViewItem(new string[] { "Guess The Number V1 Setup.exe" }, 2, Color.Black, Color.Empty, null);
                        ftpFiles.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4 });
                    }
                    else if (objListViewItem.Text == "/totallynotthetimedistorter/")
                    {
                        ftpFiles.Clear();
                        ListViewItem listViewItem1 = new ListViewItem(new string[] { "Time Distorter Setup.exe" }, 2, Color.Black, Color.Empty, null);
                        ftpFiles.Items.AddRange(new ListViewItem[] { listViewItem1 });
                    }
                    else if (objListViewItem.Text == "FTP Client Setup.exe")
                    {
                        WinClassicDownloader opendownload = new WinClassicDownloader();
                        WindowManager wm = new WindowManager();
                        wm.Init(opendownload, "Downloader", null, false, true);
                        opendownload.appName.Text = "Downloading: FTP Client";
                    }
                    else if (objListViewItem.Text == "Web Chat Setup.exe")
                    {
                        WinClassicDownloader opendownload = new WinClassicDownloader();
                        WindowManager wm = new WindowManager();
                        wm.Init(opendownload, "Downloader", null, false, true);
                        opendownload.appName.Text = "Downloading: Web Chat 1998";
                        opendownload.amountToDL = 35;
                    }
                    else if (objListViewItem.Text == "Time Distorter Setup.exe")
                    {
                        WinClassicDownloader opendownload = new WinClassicDownloader();
                        WindowManager wm = new WindowManager();
                        wm.Init(opendownload, "Downloader", null, false, true);
                        opendownload.appName.Text = "Downloading: Time Distorter 0.1";
                    }
                    else if (objListViewItem.Text == "Guess The Number V1 Setup.exe")
                    {
                        WinClassicDownloader opendownload = new WinClassicDownloader();
                        WindowManager wm = new WindowManager();
                        wm.Init(opendownload, "Downloader", null, false, true);
                        opendownload.appName.Text = "Downloading: Guess The Number V1";
                        opendownload.amountToDL = 16;
                    }
                }
            } catch { } // Try catch due to if you have more then one item selected the game crashing.
        }
    }
}
