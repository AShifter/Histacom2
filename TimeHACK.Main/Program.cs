﻿using System;
using System.Drawing.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;
using TimeHACK.OS;
using TimeHACK.OS.Win95;
using TimeHACK.OS.Win95.Win95Apps;


namespace TimeHACK
{
    static class Program
    {
        internal static bool nightly = true;
        internal static string gameID;
        internal static TitleScreen title = null;
        public static string AddressBookSelectedFolderName;
        public static AddressBookContact AddressBookSelectedContact;

        /// <summary>
        /// The main entry point for the application.
        /// Run TitleScreen.cs at launch.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Diagnostics.Debugger.Launch();
            if (nightly == true)
            {
                try
                {
                    WebClient wc = new WebClient();

                    // Set the GameID
                    string json = wc.DownloadString("http://ci.appveyor.com/api/projects/timehack/timehack");
                    JObject j = JObject.Parse(JObject.Parse(json)["build"].ToString());
                    gameID = "AppVeyor-" + j["buildNumber"].ToString();
                }
                catch (WebException)
                {
                    gameID = "AppVeyor";
                }
            }
            else
            {
                gameID = "TimeHACK 1.1";
            }

            //TimeHACK.Engine.GameSave.SaveData MySaveData = new TimeHACK.Engine.GameSave.SaveData()
            //{
            //    OS = 60,
            //    MyStringList = new List<string>
            //    {
            //        "Item1",
            //        "Item2"
            //    }
            //};

            //string TheJSON = JsonConvert.SerializeObject(MySaveData, Formatting.Indented);
            //MessageBox.Show(TheJSON);
            //MySaveData.OS = 40;
            //MessageBox.Show(MySaveData.OS.ToString());

            //MySaveData = (TimeHACK.Engine.GameSave.SaveData)JsonConvert.DeserializeObject(TheJSON, MySaveData.GetType());
            //MessageBox.Show(MySaveData.OS.ToString());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(title = new TitleScreen());
        }
    }
}
