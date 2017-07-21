using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeHACK.Engine;
using System.Threading;
using System.Media;
using System.IO;
using TimeHACK.Engine.Template;

namespace TimeHACK.OS.Win95.Win95Apps
{
    public partial class WebChat1998 : UserControl
    {
        int chat_index = 0;
        WindowManager wm = new WindowManager();
        MessageParser wcmp = new MessageParser();
        bool correctname = false;
        bool guessing = false;
        bool msgsound = true;

        bool wimponclose = false;

        SoundPlayer join = new SoundPlayer(Properties.Resources.AIMbuddyjoin);
        SoundPlayer leave = new SoundPlayer(Properties.Resources.AIMbuddyleave);
        SoundPlayer send = new SoundPlayer(Properties.Resources.AIMmessagesent);
        SoundPlayer receive = new SoundPlayer(Properties.Resources.AIMmessagereceived);
        SoundPlayer file = new SoundPlayer(Properties.Resources.AIMfile);

        BSODCreator bc = new BSODCreator();
        Win9XBSOD bsod = null;
        Win9XBSOD bsod2 = null;

        public WebChat1998()
        {
            InitializeComponent();
            bsod = bc.throw9XBSOD(false, BSODCreator.BSODCauses.WimpEnding);
            bsod2 = bc.throw9XBSOD(false, BSODCreator.BSODCauses.PiracyEnding);
            bsod.Hide();
            bsod2.Hide();

            this.button1.Paint += (sender, args) => Engine.Paintbrush.PaintClassicBorders(sender, args, 2);
            this.button2.Paint += (sender, args) => Engine.Paintbrush.PaintClassicBorders(sender, args, 2);
            this.button3.Paint += (sender, args) => Engine.Paintbrush.PaintClassicBorders(sender, args, 2);
            this.button4.Paint += (sender, args) => Engine.Paintbrush.PaintClassicBorders(sender, args, 2);
        }
        private void WebChat1998_Load(object sender, EventArgs e)
        {
            button5.Hide();
            button4.Hide();
            button3.Hide();
            label5.Hide();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtscreenname.Text == "") { wm.StartInfobox95("Invalid Username", "Your username cannot be blank.", Properties.Resources.Win95Warning); return; }
            if (txtscreenname.Text.Length > 12) { wm.StartInfobox95("Invalid Username", "Your username needs to be less than 12 characters.", Properties.Resources.Win95Warning); return; }
            if (txtscreenname.Text.Contains(" ")) { wm.StartInfobox95("Invalid Username", "Your username cannot contain spaces.", Properties.Resources.Win95Warning); return; }
            if (txtscreenname.Text == "SkyHigh" | txtscreenname.Text == "rain49" | txtscreenname.Text == "12padams") { wm.StartInfobox95("Invalid Username", "That username is already taken.", Properties.Resources.Win95Warning); return; }
            ParentForm.AcceptButton = button2;
            TitleScreen.username = txtscreenname.Text;
            login.Hide();
            listBox1.Items.Add(TitleScreen.username);
            history.AppendText("System: " + TitleScreen.username + " has joined the chat." + Environment.NewLine);
            join.Play();
            Chat.Start();
        }

        private void Chat_Tick(object sender, EventArgs e)
        {
            if (!guessing)
            {
                if (history.ScrollBars != ScrollBars.None) history.AppendText(wcmp.ParseMessage(resources.GetString("convo"), chat_index, TitleScreen.username));
                else history.Text = wcmp.ParseMessage(resources.GetString("convo"), chat_index, TitleScreen.username);
                switch (wcmp.GetSpecial(resources.GetString("convo"), chat_index))
                {
                    case "addsh":
                        listBox1.Items.Add("SkyHigh");
                        join.Play();
                        this.ParentForm.FormClosing += WebChatClosing;
                        wimponclose = true;
                        break;
                    case "nameguess":
                        typechat.Hide();
                        button2.Hide();
                        button3.Show();
                        button4.Show();
                        Chat.Stop();
                        guessing = true;
                        receive.Play();
                        break;
                    case "addrain":
                        listBox1.Items.Add("rain49");
                        join.Play();
                        break;
                    case "addfile":
                        label5.Show();
                        button5.Show();
                        file.Play();
                        break;
                    case "addpadams":
                        listBox1.Items.Add("12padams");
                        join.Play();
                        ((WinClassic)this.ParentForm).closeDisabled = true;
                        TitleScreen.frm95.startbutton.Enabled = false;
                        TitleScreen.frm95.startmenu.Hide();
                        break;
                    case "nostart":
                        TitleScreen.frm95.startbutton.Hide();
                        TitleScreen.frm95.startmenu.Hide();
                        receive.Play();
                        break;
                    case "removerain":
                        listBox1.Items.Remove("rain49");
                        leave.Play();
                        break;
                    case "iconsded":
                        TitleScreen.frm95.desktopicons.Enabled = false;
                        receive.Play();
                        break;
                    case "taskbarded":
                        TitleScreen.frm95.taskbar.Hide();
                        receive.Play();
                        break;
                    case "iconsgone":
                        TitleScreen.frm95.desktopicons.Hide();
                        receive.Play();
                        break;
                    case "bigtext":
                        history.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
                        ((WinClassic)this.ParentForm).maximizebutton.Enabled = false;
                        ((WinClassic)this.ParentForm).WindowState = FormWindowState.Maximized;
                        receive.Play();
                        break;
                    case "notopbar":
                        ((WinClassic)this.ParentForm).programtopbar.Hide();
                        receive.Play();
                        break; // TODO: Finish WebChat 1998
                    case "filepoof":
                        label5.Hide();
                        button5.Hide();
                        receive.Play();
                        break;
                    case "removesky":
                        listBox1.Items.Remove("SkyHigh");
                        leave.Play();
                        break;
                    case "notype":
                        typechat.Hide();
                        button2.Hide();
                        receive.Play();
                        break;
                    case ".labelgone":
                        label1.Hide();
                        label6.Hide();
                        label7.Hide();
                        break;
                    case ".blackout":
                        BackColor = Color.Black;
                        history.BackColor = Color.Black;
                        history.ForeColor = Color.White;
                        break;
                    case "nosound":
                        msgsound = false;
                        break;
                    case ".fulltext":
                        foreach (Control c in ((WinClassic)this.ParentForm).program.Controls)
                        {
                            if (c.Name != "programContent")
                            {
                                c.Hide();
                                ((WinClassic)this.ParentForm).program.Controls.Remove(c);
                            }
                        }
                        ((WinClassic)this.ParentForm).programContent.Location = new Point(0, 0);
                        ((WinClassic)this.ParentForm).programContent.Size = ((WinClassic)this.ParentForm).ClientSize;
                        panel1.Hide();
                        history.Dock = DockStyle.Fill;
                        break;
                    case "noscroll":
                        history.ScrollBars = ScrollBars.None;
                        break;
                    case "nomouse":
                        Cursor.Hide();
                        break;
                    default:
                        if (msgsound) receive.Play();
                        break;
                }
                if (TitleScreen.username == "devspeed") Chat.Interval = wcmp.GetMessageDelay(resources.GetString("convo"), chat_index) / 2;
                else Chat.Interval = wcmp.GetMessageDelay(resources.GetString("convo"), chat_index);
            }
            else
            {
                if (correctname)
                {
                    history.AppendText("SkyHigh: yay you got it right!" + Environment.NewLine);
                }
                else
                {
                    history.AppendText("SkyHigh: sorry, my name is actually bill" + Environment.NewLine);
                }
                guessing = false;
                receive.Play();
                Chat.Interval = wcmp.GetMessageDelay(resources.GetString("convo"), chat_index);
            }
            chat_index++;
        }

        private void WebChatClosing(object sender, FormClosingEventArgs e)
        {
            if (wimponclose)
            {
                bsod.FormClosing += new FormClosingEventHandler(Program.title.BSODRewind);
                bsod.Show();
                bsod.BringToFront();
                bsod2.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (typechat.Text != "") history.AppendText(TitleScreen.username + ": " + typechat.Text + Environment.NewLine);
            typechat.Text = "";
            if (msgsound) send.Play();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            correctname = false;
            button2.Show();
            button3.Hide();
            button4.Hide();
            typechat.Show();
            Chat.Start();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            correctname = true;
            button2.Show();
            button3.Hide();
            button4.Hide();
            typechat.Show();
            Chat.Start();
        }
    }
}
