﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeHACK.Engine;

namespace TimeHACK.OS.Win95.Win95Apps.Story
{
    class Hack1 : NormalHack
    {
        WinClassicTerminal term = new WinClassicTerminal();
        WindowManager wm = new WindowManager();

        

        // This is the very first story script!
        public void startObjective()
        {
            Thread terminalThread = new Thread(main);
            terminalThread.Start();
        }

        public void main()
        {
            wm.startWin95(term, "MS-DOS Prompt", null, true, true);
            term.WriteLine("192.168.0.1 Connecting...");

            term.Invalidate();
            Application.DoEvents();

            Thread soundThread = new Thread(dialup_sound_play);
            soundThread.Start();
            soundThread.Join();           

            term.WriteLine("192.168.0.1 Connected.");

            Application.DoEvents();

            Boolean ended = false;
            while (!ended) {
            }
        }
        public void dialup_sound_play()
        {
            SoundPlayer dialup_sound;
            // Play Dial-up Sound
            Stream audio = Properties.Resources.modem_dial;
            dialup_sound = new SoundPlayer(audio);
            dialup_sound.PlaySync();
        }
    }
}
