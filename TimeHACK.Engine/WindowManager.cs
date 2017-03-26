﻿using System;
using TimeHACK.Engine.Template;
using System.Windows.Forms;
using System.Drawing;

namespace TimeHACK.Engine
{
    public class WindowManager
    {
        public void startWinClassic(UserControl content, String title, PictureBox icon, Boolean MaxButton, Boolean MinButton)
        {
            // Setup Window
            WinClassic app = new WinClassic();
            app.Title.Text = title;
            app.Width = content.Width + 8;
            app.Height = content.Height + 26;
            content.Parent = app.programContent;
            content.BringToFront();
            content.Dock = DockStyle.Fill;
            if (icon == null)
            {
                icon = app.programIcon;
                icon.Image = Properties.Resources.nullIcon;
            }
            app.programIcon.Image = icon.Image;

            // Check if Max button is enabled and set proper X for Min button
            if (MaxButton == false)
            {
                app.maximizebutton.Visible = false;
                app.minimizebutton.Location = new Point(app.closebutton.Location.X - 16, app.minimizebutton.Location.Y);
            }

            // Check if Min button is enabled
            if (MinButton == false)
            {
                app.minimizebutton.Visible = false;
                app.minimizebutton.Location = new Point(app.minimizebutton.Location.X, app.minimizebutton.Location.Y);
            }

            // Show the app
            app.Show();


        }
    }
}