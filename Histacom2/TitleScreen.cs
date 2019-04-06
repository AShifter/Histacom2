﻿using Histacom2.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Histacom2.OS.Win95;
using Histacom2.OS.Win98;
using Histacom2.Engine;
using static Histacom2.Engine.SaveSystem;
using Histacom2.SaveDialogs;
using System.Runtime.InteropServices;
using System.Reflection;
using System.ComponentModel;
using Histacom2.OS.WinXPBad;

namespace Histacom2
{
    public partial class TitleScreen : Form
    {
        public static System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();

        public static Windows95 frm95;
        public static Windows98 frm98;
        public static WindowsXPBad frmBadXP;
        public static string gameVersion = "Version 2.0.3-dev";
        public static string username;
        public static string progress = "95";
        
        public static NewGameDialog newGameBox;
        public static LoadGameDialog loadGameBox;

        // Border stuff

        public bool max = false;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public TitleScreen() {
            InitializeComponent();
            this.startmenu.Paint += (sender, args) => Paintbrush.PaintClassicBorders(sender, args, 2);
            SeizureWarning sw = new SeizureWarning();
            sw.Size = programContent.Size;
            programContent.Controls.Add(sw);
            sw.BringToFront();
        }

        public void StartGame() {
            // Time to decide which OS to start up!

			switch (CurrentSave.CurrentOS)
			{
				case "95":
					frm95 = new Windows95();
					frm95.TopMost = true;
					frm95.FormBorderStyle = FormBorderStyle.None;
					frm95.WindowState = FormWindowState.Maximized;
					//if (vm_mode.Checked)
					//{
					//    frm95.Size = new Size(Convert.ToInt32(VM_Width.Text), Convert.ToInt32(VM_Height.Text));
					//    frm95.FormBorderStyle = FormBorderStyle.Fixed3D;
					//}
					frm95.Show();
					Hide();

					break;
				case "98":
					frm98 = new Windows98();
					frm98.TopMost = true;
					frm98.FormBorderStyle = FormBorderStyle.None;
					frm98.WindowState = FormWindowState.Maximized;
					//if (vm_mode.Checked)
					//{
					//    frm98.Size = new Size(Convert.ToInt32(VM_Width.Text), Convert.ToInt32(VM_Height.Text));
					//    frm98.FormBorderStyle = FormBorderStyle.Fixed3D;
					//}
					frm98.Show();
					Hide();

					break;
				case "xpbad":
					frmBadXP = new WindowsXPBad();
					frmBadXP.TopMost = true;
					frmBadXP.FormBorderStyle = FormBorderStyle.None;
					frmBadXP.WindowState = FormWindowState.Maximized;
					//if (vm_mode.Checked)
					//{
					//    frm98.Size = new Size(Convert.ToInt32(VM_Width.Text), Convert.ToInt32(VM_Height.Text));
					//    frm98.FormBorderStyle = FormBorderStyle.Fixed3D;
					//}
					frmBadXP.Show();
					Hide();

					break;
				default:
					MessageBox.Show("WARNING! It looks like this save is corrupt!");
					MessageBox.Show("We will now open the Save troubleshooter");

					SaveFileTroubleShooter troubleshooter = new SaveFileTroubleShooter();

					troubleshooter.ShowDialog();
					break;
			}
        }

        private void VM_WidthHeight_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        // When the TitleScreen Loads
        private void TitleScreen_Load(object sender, EventArgs e) {
            Directory.CreateDirectory(GameDirectory);
            Directory.CreateDirectory(DataDirectory);
            Directory.CreateDirectory(AllProfilesDirectory);

            Resources.google.Save(Path.Combine(DataDirectory, "google.jpg"));

            // Set GameVersion
            gameversion.Text = gameVersion;

            // Initialize Font
            File.WriteAllBytes(DataDirectory + "\\LeviWindows.ttf", Resources.LeviWindows);
            File.WriteAllBytes(DataDirectory + "\\windows_command_prompt.ttf", Resources.windows_command_prompt);
            File.WriteAllBytes(DataDirectory + "\\lemon-lcd.ttf", Resources.Lemon_s_LCD);
            pfc.AddFontFile(DataDirectory + "\\LeviWindows.ttf");
            pfc.AddFontFile(DataDirectory + "\\windows_command_prompt.ttf");
            pfc.AddFontFile(DataDirectory + "\\lemon-lcd.ttf");
            gameversion.Font = new Font(pfc.Families[0], 16F, FontStyle.Bold, GraphicsUnit.Point, (0));
            ProgramsToolStripMenuItem.Font = new Font(pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            DocumentsToolStripMenuItem.Font = new Font(pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            achievementsToolStripMenuItem.Font = new Font(pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            SettingsToolStripMenuItem.Font = new Font(pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            HelpToolStripMenuItem.Font = new Font(pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ShutdownToolStripMenuItem.Font = new Font(pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }
        #region Menu Buttons

        #region NewGame

        // When NewGame is Clicked
        private void NewGame_Click(object sender, EventArgs e) {
            newGameBox = new NewGameDialog();
            newGameBox.ShowDialog();

            if (newGameBox.Successful) {
                NewGame();
                StartGame();
            }
        }

        public void BSODRewind(object sender, EventArgs e) {
            if (progress == "95") {
                frm95.Close();
                frm95 = null;

                try {
                    // Time to close all the game applications
                    foreach (Form frm in Application.OpenForms) if (frm.Tag.ToString() != "ignoreFormOnTaskbar") frm.Close();
                } catch {

                }

                // Generate fullscreen desktop
                frm95 = new Windows95();
                frm95.TopMost = true;
                frm95.FormBorderStyle = FormBorderStyle.None;
                frm95.WindowState = FormWindowState.Maximized;
                frm95.Show();
                Hide();
            }
        }
        #endregion

        #region LoadGame
        private void LoadGame_Click(object sender, EventArgs e) {
            loadGameBox = new LoadGameDialog();
            loadGameBox.ShowDialog();

            if (loadGameBox.successful) {
                LoadSave();
                SetTheme();
                StartGame();
            }            
        }
        #endregion

        #region ExitButton
        private void Exit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        #endregion

        #region HelpButton
        private void helpItemClick(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/TheRandomMelon/Histacom2/wiki");
        }
        #endregion

        #endregion

        private void gameversion_MouseHover(object sender, EventArgs e) {
            gameversion.Text = "There are no easter eggs here!";
        }

        private void gameversion_MouseLeave(object sender, EventArgs e) {
            gameversion.Text = gameVersion;
        }

        private void startbutton_Click(object sender, EventArgs e) {
            if (DevMode) {
                DevMode = false;
                gameversion.Text = "Developer Mode Deactivated";
            } else {
                DevMode = true;
                gameversion.Text = "Developer Mode Activated";
            }
        }

        private void closebutton_Click_1(object sender, EventArgs e) {
            Application.Exit();
        }

        private void updateText_Tick(object sender, EventArgs e) {
            if (gameversion.Text != gameVersion) {
                gameversion.Text = gameVersion;
                updateText.Stop();
            }
        }

        private void achievementsToolStripMenuItem_Click(object sender, EventArgs e) {
            AchievementScreen achievelist = new AchievementScreen();
            achievelist.ShowDialog();
        }

        private void helpMenu(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/TheRandomMelon/Histacom2/wiki");
        }
    }
}
