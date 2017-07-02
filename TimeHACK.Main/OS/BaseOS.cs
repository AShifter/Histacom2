﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using TimeHACK;
using TimeHACK.Engine;
using TimeHACK.Engine.Template;
using TimeHACK.Engine.Template.Taskbars;
using TimeHACK.OS.Win95.Win95Apps;
using TimeHACK.WinClassicForms;
using TimeHACK.OS.Win95.Win95Apps.Story;

namespace TimeHACK.OS.Win95
{
    public partial class BaseOS : Form
    {
        public WindowManager wm = new WindowManager();

        public TaskBarController tb = new TaskBarController();

        public OpenApplication openApp = new OpenApplication();

        // Init the form
        public BaseOS()
        {
            InitializeComponent();
        }

        //  When New Game is clicked in TitleScreen.cs
        private void Desktop_Load(object sender, EventArgs e)
        {

            // Hide the Startmenu
            startmenu.Hide();

            // Check for and set VM Mode
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                this.Text = "TimeHACK - VM Mode";
            }

            // Start the ClockTimer
            clockTimer.Start();

            // Set the StartMenu seperator
            startmenuitems.Items.Insert(6, new ToolStripSeparator());

            //Program.nonimportantapps.Capacity = 100;
            this.SendToBack();

            // Update the taskbar
            UpdateTaskbar();

            // Bring to this the front
            this.BringToFront();
        }

        private void fontLoad()
        {
            this.taskbartime.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ProgramsToolStripMenuItem.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.DocumentsToolStripMenuItem.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.SettingsToolStripMenuItem.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.FindToolStripMenuItem.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.HelpToolStripMenuItem.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.RunToolStripMenuItem.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.SuspendToolStripMenuItem.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ShutdownToolStripMenuItem.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.desktopicons.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        #region StartMenu

        // Paint StartMenu
        private void startmenu_Paint(object sender, PaintEventArgs e)
        {
            // Paint the StartMenu
            ControlPaint.DrawBorder(e.Graphics, startmenu.ClientRectangle,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
        }

        // StartButton Click
        private void startbutton_Click(object sender, EventArgs e)
        {
            startmenu.Show();
            startmenu.BringToFront();
        }

        // Shutdown button
        private void ShutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ShutdownApplication(Properties.Resources.tada);
        }

        #endregion //Region

        // When add new folder is clicked
        private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            desktopicons.Items.Add("New Folder");
        }

        // Give Year Code - NYI
        private void taskbartime_Click(object sender, EventArgs e)
        {
            //TODO: Set Up Save System
        }

        // Set the Clock
        private void clockTimer_Tick(object sender, EventArgs e)
        {
            taskbartime.Text = DateTime.Now.ToString("h:mm tt");
        }

        // On Desktop MouseDown
        private void desktop_mousedown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightclickbackproperties.Show();
                rightclickbackproperties.BringToFront();
                rightclickbackproperties.Location = MousePosition;
            }

            // If 
            else if (e.Button == MouseButtons.Left)
            {
                rightclickbackproperties.Hide();
                startmenu.Hide();
            }

            else if (e.Button == MouseButtons.Middle)
            {
                rightclickbackproperties.Hide();
            }
        }

        private void NotePadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openApp.OpenApp("Notepad");

            startmenu.Hide();
        }
        private void windowManagerTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestApp test = new TestApp();
            WinClassic app = wm.startWin95(test, "TestApp", null, true, true);
            AddTaskBarItem(app, app.Tag.ToString(), "TestApp", null);
            app.BringToFront();
            startmenu.Hide();
        }

        private void downloaderTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinClassicDownloader opendownload = new WinClassicDownloader();
            WinClassic app = wm.startWin95(opendownload, "Downloader", null, false, true);
            opendownload.appName.Text = "Downloading: Survive The Day";

            AddTaskBarItem(app, app.Tag.ToString(), "Downloader", null);

            app.BringToFront();
            startmenu.Hide();
        }

        private void installerTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinClassicInstaller openinstaller = new WinClassicInstaller();
            WinClassic app = wm.startWin95(openinstaller, "Installer", null, false, true);

            AddTaskBarItem(app, app.Tag.ToString(), "Installer", null);

            app.BringToFront();
            startmenu.Hide();
        }

        private void desktopicons_Click(object sender, EventArgs e)
        {
            Point objDrawingPoint = desktopicons.PointToClient(Cursor.Position);
            ListViewItem objListViewItem;

            if (objDrawingPoint != null)
            {
                objListViewItem = desktopicons.GetItemAt(objDrawingPoint.X, objDrawingPoint.Y);
                if (objListViewItem != null)
                {
                    if (objListViewItem.Text == "Internet Explorer")
                    {
                        switch (SaveSystem.CurrentSave.CurrentOS)
                        {
                            case "95":
                                openApp.OpenApp("ie4");

                                startmenu.Hide();
                                break;

                        }
                    } else if (objListViewItem.Text == "Web Chat Setup")
                    {
                        openApp.OpenApp("webchat1998");

                        startmenu.Hide();
                    }
                }
            }
        }

        private void infoboxTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinClassic app = wm.startInfobox95("AShifter's Infobox", "This is the very first TimeHACK Infobox. It's really easy to call, too! \n Just use wm.startInfobox95(String title, String text, Image erroricon)!", Properties.Resources.Win95Info);

            app.BringToFront();
            startmenu.Hide();
        }
        private void WebChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebChat1998 wc = new WebChat1998();
            WinClassic app = wm.startWin95(wc, "Web Chat 1998", null, true, true);

            AddTaskBarItem(app, app.Tag.ToString(), "Web Chat 1998", null);

            app.BringToFront();
            startmenu.Hide();
        }

        private void WordPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openApp.OpenApp("Wordpad");
        }

        public void AddTaskBarItem(Form Application, string ApplicationID, string ApplicationName, Image ApplicationIcon)
        {
            taskbarItems = tb.AddTaskbarItem95(ApplicationID, ApplicationName, ApplicationIcon, (UserControl)new Win95TaskBarItem(), taskbarItems);
            Application.FormClosed += new FormClosedEventHandler(UpdateTaskbarFromClosedApplication);
        }

        public void UpdateTaskbarFromClosedApplication(object sender, FormClosedEventArgs e)
        {
            UpdateTaskbar();
        }

        public void UpdateTaskbar()
        {
            // Clears out all the items on the taskbar
            taskbarItems.Controls.Clear();

            // Loops through all the Applications which are open

            foreach (Form form in tb.GetAllOpenApps()) 
            {
                // Calls that "AddToTaskbar" thing
                taskbarItems = tb.AddTaskbarItem95(form.Tag.ToString(), form.Text.ToString(), (Image)form.Icon.ToBitmap(), (UserControl)new Win95TaskBarItem(), taskbarItems);                
            }
        }

        private void AddressBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openApp.OpenApp("addressbook");

            startmenu.Hide();
        }

        private void WindowsExplorerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openApp.OpenApp("windowsexplorer");

            startmenu.Hide();
        }

        private void storyTest1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hack1.startObjective();
        }

        private void temp_for_std(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(StartSurviveTheDay);

            thread.Start();
        }

        void StartSurviveTheDay()
        {
            openApp.OpenApp("survivetheday");

            startmenu.Hide();
        }

        //TODO: Add Outlook Express 4
    }
}

