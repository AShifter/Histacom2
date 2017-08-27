﻿using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Histacom2.Engine
{
    public class TaskBarController
    {

        public static int AvalibleApplicationID = 0;

        public Panel AddTaskbarItem95(string ApplicationID, string ApplicationName, Image ApplicationIcon, UserControl taskbar_item, Panel oldPanel)
        {
            Panel returnPanel = oldPanel;

            AvalibleApplicationID++;

            taskbar_item.BackgroundImage = ApplicationIcon;
            taskbar_item.Tag = ApplicationName;
            if (AvalibleApplicationID == 1) taskbar_item.Dock = DockStyle.Left;
            taskbar_item.Location = new Point(160 * returnPanel.Controls.Count, 0);
            returnPanel.Controls.Add(taskbar_item);

            return returnPanel;
        }

        public List<Form> GetAllOpenApps()
        {
            List<Form> AppsList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                try
                {
                    if (form.Tag.ToString() != "ignoreFormOnTaskbar")
                    {
                        AppsList.Add(form);
                    }
                } catch {
                    AppsList.Add(form);
                }
            }
            return AppsList;
        }

        public void FocusAppFromID(string ApplicationID)
        {
            
            foreach (Form form in Application.OpenForms)
            {
                if (form.Tag.ToString() == ApplicationID)
                {
                    form.Show();
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }
        }
    }
}
