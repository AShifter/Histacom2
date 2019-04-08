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
using System.Threading;
using Histacom2.GlobalPrograms;

namespace Histacom2.OS.Win95.Win95Apps.IE3Sites
{
    public partial class Website12padams1998 : UserControl
    {
        bool clicked = false;
        public Website12padams1998()
        {
            InitializeComponent();
            button1.Paint += (s, args) => Paintbrush.PaintClassicBorders(s, args, 2);
            button2.Paint += (s, args) => Paintbrush.PaintClassicBorders(s, args, 2);
            button3.Paint += (s, args) => Paintbrush.PaintClassicBorders(s, args, 2);
            button4.Paint += (s, args) => Paintbrush.PaintClassicBorders(s, args, 2);
            button5.Paint += (s, args) => Paintbrush.PaintClassicBorders(s, args, 2);
            button6.Paint += (s, args) => Paintbrush.PaintClassicBorders(s, args, 2);
            button7.Paint += (s, args) => Paintbrush.PaintClassicBorders(s, args, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WinClassicDownloader opendownload = new WinClassicDownloader();
            WindowManager wm = new WindowManager();
            wm.Init(opendownload, "Downloader", null, false, true);
            opendownload.appName.Text = "Downloading: FTP Client";
            opendownload.amountToDL = 56;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WinClassicDownloader opendownload = new WinClassicDownloader();
            WindowManager wm = new WindowManager();
            wm.Init(opendownload, "Downloader", null, false, true);
            opendownload.appName.Text = "Downloading: Web Chat 1998";
            opendownload.amountToDL = 35;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (clicked) return;
            clicked = true;
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠ ̢͚̲̞̯͎͙̪̗̜̹͙͓͉͢ͅ#̡͙̻̫̝̪͙͚̺̝͓̘̬̬͙͔̀̕͠#̴҉͖̲̺̱͖͈̭̭ͅ#̸̸̷̼̫̪̖̻̻͈̭̬͓̘͓̦̟̻̪͇̞̕#̸̢̨̻̗̣̠̥̖̜̜̖̺͍̝̗͓̦̳̫#̛͡҉̭̝̙̟̘̩̬͖͎̘̞̭̖͔̪̼̠͢ͅ#̰̜̭̹̻̖̬̺͘͡#̛̬̣̳͔͔̘̟͜͢͟͡#̷̨̼̺̤̥̞́͢͡ ̢̞̬͙͍̬̪̪̰̰̰̙̮͙͚͕̩̟͇̕͜ͅ#̶͙̣̣̦͈͈̫̕͡#̸̡̥̹̮͇̱̱͍͜͜͢#̵̢̧̦͙̮̮͔͖̞̮͚͞#̧̗̤̱̪̜͓̠͖̞̰͍͢#̧̱̳̻̖̝͇͜͞#̛́҉͍̩̞̬͔̬̪̻̯̩";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠ ̢͚̲̞̯͎͙̪̗̜̹͙͓͉͢ͅ#̡͙̻̫̝̪͙͚̺̝͓̘̬̬͙͔̀̕͠#̴҉͖̲̺̱͖͈̭̭ͅ#̸̸̷̼̫̪̖̻̻͈̭̬͓̘͓̦̟̻̪͇̞̕#̸̢̨̻̗̣̠̥̖̜̜̖̺͍̝̗͓̦̳̫#̛͡҉̭̝̙̟̘̩̬͖͎̘̞̭̖͔̪̼̠͢ͅ#̰̜̭̹̻̖̬̺͘͡#̛̬̣̳͔͔̘̟͜͢͟͡#̷̨̼̺̤̥̞́͢͡ ̢̞̬͙͍̬̪̪̰̰̰̙̮͙͚͕̩̟͇̕͜ͅ#̶͙̣̣̦͈͈̫̕͡#̸̡̥̹̮͇̱̱͍͜͜͢#̵̢̧̦͙̮̮͔͖̞̮͚͞#̧̗̤̱̪̜͓̠͖̞̰͍͢#̧̱̳̻̖̝͇͜͞";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠ ̢͚̲̞̯͎͙̪̗̜̹͙͓͉͢ͅ#̡͙̻̫̝̪͙͚̺̝͓̘̬̬͙͔̀̕͠#̴҉͖̲̺̱͖͈̭̭ͅ#̸̸̷̼̫̪̖̻̻͈̭̬͓̘͓̦̟̻̪͇̞̕#̸̢̨̻̗̣̠̥̖̜̜̖̺͍̝̗͓̦̳̫#̛͡҉̭̝̙̟̘̩̬͖͎̘̞̭̖͔̪̼̠͢ͅ#̰̜̭̹̻̖̬̺͘͡#̛̬̣̳͔͔̘̟͜͢͟͡#̷̨̼̺̤̥̞́͢͡ ̢̞̬͙͍̬̪̪̰̰̰̙̮͙͚͕̩̟͇̕͜ͅ#̶͙̣̣̦͈͈̫̕͡#̸̡̥̹̮͇̱̱͍͜͜͢#̵̢̧̦͙̮̮͔͖̞̮͚͞";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠ ̢͚̲̞̯͎͙̪̗̜̹͙͓͉͢ͅ#̡͙̻̫̝̪͙͚̺̝͓̘̬̬͙͔̀̕͠#̴҉͖̲̺̱͖͈̭̭ͅ#̸̸̷̼̫̪̖̻̻͈̭̬͓̘͓̦̟̻̪͇̞̕#̸̢̨̻̗̣̠̥̖̜̜̖̺͍̝̗͓̦̳̫#̛͡҉̭̝̙̟̘̩̬͖͎̘̞̭̖͔̪̼̠͢ͅ#̰̜̭̹̻̖̬̺͘͡#̛̬̣̳͔͔̘̟͜͢͟͡#̷̨̼̺̤̥̞́͢͡ ̢̞̬͙͍̬̪̪̰̰̰̙̮͙͚͕̩̟͇̕͜ͅ#̶͙̣̣̦͈͈̫̕͡";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠ ̢͚̲̞̯͎͙̪̗̜̹͙͓͉͢ͅ#̡͙̻̫̝̪͙͚̺̝͓̘̬̬͙͔̀̕͠#̴҉͖̲̺̱͖͈̭̭ͅ#̸̸̷̼̫̪̖̻̻͈̭̬͓̘͓̦̟̻̪͇̞̕#̸̢̨̻̗̣̠̥̖̜̜̖̺͍̝̗͓̦̳̫#̛͡҉̭̝̙̟̘̩̬͖͎̘̞̭̖͔̪̼̠͢ͅ#̰̜̭̹̻̖̬̺͘͡#̛̬̣̳͔͔̘̟͜͢͟͡#̷̨̼̺̤̥̞́͢͡";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠ ̢͚̲̞̯͎͙̪̗̜̹͙͓͉͢ͅ#̡͙̻̫̝̪͙͚̺̝͓̘̬̬͙͔̀̕͠#̴҉͖̲̺̱͖͈̭̭ͅ#̸̸̷̼̫̪̖̻̻͈̭̬͓̘͓̦̟̻̪͇̞̕#̸̢̨̻̗̣̠̥̖̜̜̖̺͍̝̗͓̦̳̫#̛͡҉̭̝̙̟̘̩̬͖͎̘̞̭̖͔̪̼̠͢ͅ#̰̜̭̹̻̖̬̺͘͡";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠ ̢͚̲̞̯͎͙̪̗̜̹͙͓͉͢ͅ#̡͙̻̫̝̪͙͚̺̝͓̘̬̬͙͔̀̕͠#̴҉͖̲̺̱͖͈̭̭ͅ#̸̸̷̼̫̪̖̻̻͈̭̬͓̘͓̦̟̻̪͇̞̕#̸̢̨̻̗̣̠̥̖̜̜̖̺͍̝̗͓̦̳̫";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠ ̢͚̲̞̯͎͙̪̗̜̹͙͓͉͢ͅ#̡͙̻̫̝̪͙͚̺̝͓̘̬̬͙͔̀̕͠#̴҉͖̲̺̱͖͈̭̭ͅ";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠ ̢͚̲̞̯͎͙̪̗̜̹͙͓͉͢ͅ#̡͙̻̫̝̪͙͚̺̝͓̘̬̬͙͔̀̕͠";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕#̧͢͠͏̖̙͚͉͇̣̜̖ͅ#̜̝͚͓̳̘̭̣̲̟̤̖͇̬̠̯̠̀͠";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟ ̨̡̘͓͔̜̭̫͖͔̰̦̘̀#̛͓̬̭̦̹̙̭͕̕";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬#҉̵̻̜͇̻̹͈̀͟";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠҉̨̧҉̯̙̹̝̟̺̰͖̹̞̻̝̖̪͉͍͇̬";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝d̻̻̪̙͖̬͈͟͝e͠";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅÀ͏̰̮̞̲̠̩̳͙͓͉̭̼̠͕̣͇̜͎ͅd̢̩̝̙̩̭̫͓̮͙͔̘̥͝";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ ͏̙͇̮̤̠͇̜͚͈͇͔̠̙͜͡ͅ";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞:̧͟͏̰̣̠̹͍͔̼͕̲͇̪̥̗̞͚͇̖ͅ";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦9͠҉̶̢͔̹̖͇̫̩̻̪̬͔̥̟̺̼̺̟̫8̷̴̶̱̩͖̟̠̬̻̼̳̰̺͚͜͞";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "1̧͙̙̦̪͙͇̜̥͍̟͍̹̰̝͖̫̩͘͡͡9̸̨͏̖̱̗̣̥͕̲͈̬̦";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "P";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "Pa";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "Pas";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "Pass";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "Passw";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "Passwo";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "Passwor";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "Password";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "Password:";
            Thread.Sleep(100);
            Refresh();
            label16.Text = "Password: projectDeath98";
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WinClassicDownloader opendownload = new WinClassicDownloader();
            WindowManager wm = new WindowManager();
            wm.Init(opendownload, "Downloader", null, false, true);
            opendownload.appName.Text = "Downloading: Guess The Number V1";
            opendownload.amountToDL = 16;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WinClassicDownloader opendownload = new WinClassicDownloader();
            WindowManager wm = new WindowManager();
            wm.Init(opendownload, "Downloader", null, false, true);
            opendownload.appName.Text = "Downloading: Error Blaster 95";
            opendownload.amountToDL = 32;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WinClassicDownloader opendownload = new WinClassicDownloader();
            WindowManager wm = new WindowManager();
            wm.Init(opendownload, "Downloader", null, false, true);
            opendownload.appName.Text = "Downloading: Start Runner 95";
            opendownload.amountToDL = 32;
        }
    }
}
