﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Histacom2.Engine.UI
{
    public class ClassicButton : Control
    {
        private Color _lightBack;
        private Color _darkBack;
        private Font _font;

        private bool _pressing = false;

        public ClassicButton() : base()
        {
            if (SaveSystem.currentTheme != null) BackColor = SaveSystem.currentTheme.threeDObjectsColor;
            else BackColor = Color.Silver;
            _lightBack = ControlPaint.Light(BackColor, 50);
            _darkBack = ControlPaint.Dark(BackColor, 50);

            if (SaveSystem.currentTheme != null) ForeColor = SaveSystem.currentTheme.threeDObjectsTextColor;
            else ForeColor = Color.Black;

            if (SaveSystem.currentTheme != null) _font = SaveSystem.currentTheme.buttonFont;
            else _font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);

            MouseDown += (s, e) => { _pressing = true; Invalidate(); };
            MouseUp += (s, e) => { _pressing = false; Invalidate(); };
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (SaveSystem.currentTheme != null) BackColor = SaveSystem.currentTheme.threeDObjectsColor;
            else BackColor = Color.Silver;

            _lightBack = Paintbrush.GetLightFromColor(BackColor);
            _darkBack = Paintbrush.GetDarkFromColor(BackColor);

            var g = e.Graphics;
            g.Clear(BackColor);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
            
            if (_pressing)
            {
                g.FillRectangle(new SolidBrush(_lightBack), new Rectangle(0, 0, Width, Height));
                g.FillRectangle(Brushes.Black, new Rectangle(0, 0, Width - 1, Height - 1));
                g.FillRectangle(new SolidBrush(_darkBack), new Rectangle(1, 1, Width - 2, Height - 2));
                g.FillRectangle(new SolidBrush(BackColor), new Rectangle(2, 2, Width - 3, Height - 3));

                g.DrawString(Text, _font, new SolidBrush(ForeColor), ((Width / 2) + 1) + Padding.Left, (Height / 2) - (g.MeasureString(Text, Font).Height / 2) + 3, sf);
            }
            else
            {
                g.FillRectangle(Brushes.Black, new Rectangle(0, 0, Width, Height));
                g.FillRectangle(new SolidBrush(_lightBack), new Rectangle(0, 0, Width - 1, Height - 1));
                g.FillRectangle(new SolidBrush(_darkBack), new Rectangle(1, 1, Width - 2, Height - 2));
                g.FillRectangle(new SolidBrush(BackColor), new Rectangle(1, 1, Width - 3, Height - 3));

                g.DrawString(Text, _font, new SolidBrush(ForeColor), (Width / 2) + Padding.Left, (Height / 2) - (g.MeasureString(Text, Font).Height / 2) + 2, sf);
            }
        }
        
    }
}
