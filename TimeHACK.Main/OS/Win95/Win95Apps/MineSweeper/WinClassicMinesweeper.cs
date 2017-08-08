﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeHACK.OS.Win95.Win95Apps.MineSweeper;
using TimeHACK.Engine;
using System.Threading;
using TimeHACK.Engine.Template;

namespace TimeHACK.OS.Win95.Win95Apps
{
    public partial class WinClassicMinesweeper : UserControl
    {
        private Game _game;
        public int currentface = 1;
        public string level = "easy";
        public int customwidth;
        public int customheight;
        public int custommines;
        public WinClassicMinesweeper()
        {
            InitializeComponent();
            labelBombs.Font = new Font(TitleScreen.pfc.Families[2], 15, GraphicsUnit.Point);
            labelTime.Font = new Font(TitleScreen.pfc.Families[2], 15, GraphicsUnit.Point);
            panel2.Paint += (sender, args) => Paintbrush.PaintClassicBordersIndented(sender, args, 3);
            panel3.Paint += (sender, args) => Paintbrush.PaintClassicBorders(sender, args, 3);
            panel4.Paint += (sender, args) => Paintbrush.PaintClassicBordersIndented(sender, args, 2);
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular);
                item.BackColor = Color.Silver;
                item.BackgroundImage = Properties.Resources.sliversilver;
                item.BackgroundImageLayout = ImageLayout.Center;
                item.DisplayStyle = ToolStripItemDisplayStyle.Text;
            }
            toolStripSeparator1.Paint += Paintbrush.ExtendedToolStripSeparator_Paint;
            toolStripSeparator2.Paint += Paintbrush.ExtendedToolStripSeparator_Paint;
            toolStripSeparator3.Paint += Paintbrush.ExtendedToolStripSeparator_Paint;
            toolStripSeparator4.Paint += Paintbrush.ExtendedToolStripSeparator_Paint;
            toolStripSeparator5.Paint += Paintbrush.ExtendedToolStripSeparator_Paint;
        }
        private void GameTick(object sender, EventArgs e)
        {
            labelTime.Text = _game.Time.ToString();
        }
        private void GameDismantledMinesChanged(object sender, EventArgs e)
        {
            labelBombs.Text = (_game.Mines - _game.DismantledMines).ToString();
        }
        public void calculateFormSize(int x, int y)
        {
            panel1.Size = new Size(x * 16, y * 16);
            panel2.Size = new Size(x * 16 + 6, y * 16 + 6);
            this.ParentForm.Size = new Size(x * 16 + 41, y * 16 + 128);
            panel3.Size = new Size(Width, Height - 24);
            panel4.Size = new Size(panel2.Width, 37);
            labelTime.Location = new Point(panel4.Width - 58, 6);
            //panel2.Paint -= (sender, args) => Paintbrush.PaintClassicBordersIndented(sender, args, 3);
            panel2.Refresh();
            panel3.Refresh();
            //panel2.Paint += (sender, args) => Paintbrush.PaintClassicBordersIndented(sender, args, 3);
            button1.Location = new Point(panel4.Width / 2 - 12, 6);
            button1.PerformClick();
        }
        private void begginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = "easy";
            //button1.Location = new Point(70, 32);
            calculateFormSize(9, 9);
        }
        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = "medium";
            //button1.Location = new Point(158, 32);
            calculateFormSize(16, 16);
        }
        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = "hard";
            //button1.Location = new Point(381, 32);
            calculateFormSize(30, 16);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.WinClassicMinesweeperSmile;
            labelTime.Text = "0";
            switch (level)
            {
                case ("easy"):
                    Cursor.Current = Cursors.WaitCursor;
                    _game = new Game(this, panel1, 9, 9, 10);
                    break;
                case ("medium"):
                    Cursor.Current = Cursors.WaitCursor;
                    _game = new Game(this, panel1, 16, 16, 40);
                    break;
                case ("hard"):
                    Cursor.Current = Cursors.WaitCursor;
                    _game = new Game(this, panel1, 30, 16, 99);
                    break;
                case ("custom"):
                    Cursor.Current = Cursors.WaitCursor;
                    _game = new Game(this, panel1, customwidth, customheight, custommines);
                    break;
            }
            _game.Tick += new EventHandler(GameTick);
            _game.DismantledMinesChanged += new EventHandler(GameDismantledMinesChanged);
            _game.Start();
            timer1.Start();
        }

        private void WinClassicMinesweeper_Load(object sender, EventArgs e)
        {
            begginnerToolStripMenuItem.PerformClick();
            timer1.Start();
        }

        private void bestTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager wm = new WindowManager();
            wm.StartWin95(new MineBestTimes(), "Best Times", null, false, false, true, false);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_game.win == true)
            {
                button1.BackgroundImage = Properties.Resources.WinClassicMinesweeperWin;
                switch (level)
                {
                    case ("easy"):
                        if (SaveSystem.CurrentSave.mineSweepE > _game.Time) SaveSystem.CurrentSave.mineSweepE = _game.Time;
                        break;
                    case ("medium"):
                        if (SaveSystem.CurrentSave.mineSweepI > _game.Time) SaveSystem.CurrentSave.mineSweepI = _game.Time;
                        break;
                    case ("hard"):
                        if (SaveSystem.CurrentSave.mineSweepH > _game.Time) SaveSystem.CurrentSave.mineSweepH = _game.Time;
                        Thread t = new Thread(Achieve);
                        t.Start();
                        break;
                }
                SaveSystem.SaveGame();
                timer1.Stop();
            }
        }

        private void Achieve()
        {
            SaveSystem.SaveAchievement(20);
            new AchievementBox(20);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = "custom";
            new WindowManager().StartWin95(new CustomMinefield(this), "Custom Field", null, false, false, true, false);
        }
    }
}
