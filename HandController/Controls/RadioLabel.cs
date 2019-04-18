/**
* ASCOM.Ardufocus.Focuser - The most accurate Open Source focus controller
* Copyright (C) 2016-2019 João Brázio [joao@brazio.org]
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*
*/

using System;
using System.Drawing;
using System.Windows.Forms;

using Common.Config;

namespace ASCOM.Ardufocus.Controls
{
    public partial class RadioLabel : UserControl
    {
        public step_t Step { get; set; }
        public speed_t Speed { get; set; }

        public RadioLabel()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int w = this.Size.Width;
            int h = this.Size.Height;

            this.pictureBox1.Width = 10;
            this.pictureBox1.Height = h;
            this.pictureBox1.Location = new Point(0, 0);

            this.label1.Width = w - this.pictureBox1.Size.Width;
            this.label1.Height = h;
            this.label1.Location = new Point(10, 0);

            this.label2.Width = 50;
            this.label2.Height = h/2;
            this.label2.Location = new Point(10, 0);

            this.label3.Width = 50;
            this.label3.Height = h / 2;
            this.label3.Location = new Point(10, h/2);

            /*
            int x = w - this.radioButton1.Size.Width - border;
            int y = (h - this.radioButton1.Size.Height) / 2;
            this.radioButton1.Location = new Point(x, y);
            */
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            switch(this.Step)
            {
                case step_t.FULL:
                    label2.Text = "1";
                    break;

                case step_t.ONE_HALF:
                    label2.Text = "½";
                    break;

                case step_t.ONE_FOURTH:
                    label2.Text = "¼";
                    break;

                case step_t.ONE_EIGHTH:
                    label2.Text = "⅛";
                    break;

                case step_t.ONE_SIXTEENTH:
                    label2.Text = "16";
                    break;

                default:
                    label2.Text = string.Empty;
                    break;
            }

            switch (this.Speed)
            {
                case speed_t.SPEED100:
                    label3.Text = "100";
                    break;

                case speed_t.SPEED50:
                    label3.Text = "50";
                    break;

                case speed_t.SPEED25:
                    label3.Text = "25";
                    break;

                case speed_t.SPEED20:
                    label3.Text = "20";
                    break;

                case speed_t.SPEED10:
                    label3.Text = "10";
                    break;

                default:
                    label3.Text = string.Empty;
                    break;
            }
        }

        public string Value
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
                this.Invalidate();
            }
        }

        public bool Checked
        {
            get
            {
                return ((this.pictureBox1.BackColor == SystemColors.Control) ? false : true);
            }
            set
            {
                this.pictureBox1.BackColor = ((value) ? Color.Orange : SystemColors.Control);
            } 
        }

        private void ClickEvent(object sender, EventArgs e)
        {
            this.OnClick(e);
            
        }
    }
}
