/**
* Ardufocus GUI - ASCOM GUI for Ardufocus
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

using Common.Config;

namespace ASCOM.Ardufocus.Forms
{
    partial class ControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(Disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button15p = new System.Windows.Forms.Button();
            this.button50p = new System.Windows.Forms.Button();
            this.button100p = new System.Windows.Forms.Button();
            this.button250p = new System.Windows.Forms.Button();
            this.button500p = new System.Windows.Forms.Button();
            this.button1000p = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.button15n = new System.Windows.Forms.Button();
            this.button50n = new System.Windows.Forms.Button();
            this.button100n = new System.Windows.Forms.Button();
            this.button250n = new System.Windows.Forms.Button();
            this.button500n = new System.Windows.Forms.Button();
            this.button1000n = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioLabel2 = new ASCOM.Ardufocus.Controls.RadioLabel();
            this.radioLabel1 = new ASCOM.Ardufocus.Controls.RadioLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.Controls.Add(this.radioLabel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioLabel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(355, 318);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(35, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 35);
            this.button3.TabIndex = 35;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(70, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 35);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonGo_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 33);
            this.label6.TabIndex = 1;
            this.label6.Text = "0,0 ºC";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.label7, 3);
            this.label7.Location = new System.Drawing.Point(10, 80);
            this.label7.Margin = new System.Windows.Forms.Padding(10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(335, 1);
            this.label7.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.label8, 3);
            this.label8.Location = new System.Drawing.Point(10, 180);
            this.label8.Margin = new System.Windows.Forms.Padding(10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(335, 1);
            this.label8.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.label9, 3);
            this.label9.Location = new System.Drawing.Point(10, 272);
            this.label9.Margin = new System.Windows.Forms.Padding(10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(335, 1);
            this.label9.TabIndex = 28;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.tableLayoutPanel1.SetColumnSpan(this.trackBar1, 3);
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(3, 128);
            this.trackBar1.Maximum = 65535;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(349, 39);
            this.trackBar1.TabIndex = 18;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickFrequency = 1000;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 3);
            this.flowLayoutPanel2.Controls.Add(this.button15p);
            this.flowLayoutPanel2.Controls.Add(this.button50p);
            this.flowLayoutPanel2.Controls.Add(this.button100p);
            this.flowLayoutPanel2.Controls.Add(this.button250p);
            this.flowLayoutPanel2.Controls.Add(this.button500p);
            this.flowLayoutPanel2.Controls.Add(this.button1000p);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(9, 193);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(336, 30);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // button15p
            // 
            this.button15p.Location = new System.Drawing.Point(3, 3);
            this.button15p.Name = "button15p";
            this.button15p.Size = new System.Drawing.Size(50, 26);
            this.button15p.TabIndex = 0;
            this.button15p.Text = "+15";
            this.button15p.UseVisualStyleBackColor = true;
            this.button15p.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button50p
            // 
            this.button50p.Location = new System.Drawing.Point(59, 3);
            this.button50p.Name = "button50p";
            this.button50p.Size = new System.Drawing.Size(50, 26);
            this.button50p.TabIndex = 1;
            this.button50p.Text = "+50";
            this.button50p.UseVisualStyleBackColor = true;
            this.button50p.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button100p
            // 
            this.button100p.Location = new System.Drawing.Point(115, 3);
            this.button100p.Name = "button100p";
            this.button100p.Size = new System.Drawing.Size(50, 26);
            this.button100p.TabIndex = 2;
            this.button100p.Text = "+100";
            this.button100p.UseVisualStyleBackColor = true;
            this.button100p.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button250p
            // 
            this.button250p.Location = new System.Drawing.Point(171, 3);
            this.button250p.Name = "button250p";
            this.button250p.Size = new System.Drawing.Size(50, 26);
            this.button250p.TabIndex = 3;
            this.button250p.Text = "+250";
            this.button250p.UseVisualStyleBackColor = true;
            this.button250p.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button500p
            // 
            this.button500p.Location = new System.Drawing.Point(227, 3);
            this.button500p.Name = "button500p";
            this.button500p.Size = new System.Drawing.Size(50, 26);
            this.button500p.TabIndex = 4;
            this.button500p.Text = "+500";
            this.button500p.UseVisualStyleBackColor = true;
            this.button500p.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button1000p
            // 
            this.button1000p.Location = new System.Drawing.Point(283, 3);
            this.button1000p.Name = "button1000p";
            this.button1000p.Size = new System.Drawing.Size(50, 26);
            this.button1000p.TabIndex = 5;
            this.button1000p.Text = "+1000";
            this.button1000p.UseVisualStyleBackColor = true;
            this.button1000p.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel3, 3);
            this.flowLayoutPanel3.Controls.Add(this.button15n);
            this.flowLayoutPanel3.Controls.Add(this.button50n);
            this.flowLayoutPanel3.Controls.Add(this.button100n);
            this.flowLayoutPanel3.Controls.Add(this.button250n);
            this.flowLayoutPanel3.Controls.Add(this.button500n);
            this.flowLayoutPanel3.Controls.Add(this.button1000n);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(9, 228);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(336, 32);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // button15n
            // 
            this.button15n.Location = new System.Drawing.Point(3, 3);
            this.button15n.Name = "button15n";
            this.button15n.Size = new System.Drawing.Size(50, 26);
            this.button15n.TabIndex = 0;
            this.button15n.Text = "-15";
            this.button15n.UseVisualStyleBackColor = true;
            this.button15n.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button50n
            // 
            this.button50n.Location = new System.Drawing.Point(59, 3);
            this.button50n.Name = "button50n";
            this.button50n.Size = new System.Drawing.Size(50, 26);
            this.button50n.TabIndex = 1;
            this.button50n.Text = "-50";
            this.button50n.UseVisualStyleBackColor = true;
            this.button50n.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button100n
            // 
            this.button100n.Location = new System.Drawing.Point(115, 3);
            this.button100n.Name = "button100n";
            this.button100n.Size = new System.Drawing.Size(50, 26);
            this.button100n.TabIndex = 2;
            this.button100n.Text = "-100";
            this.button100n.UseVisualStyleBackColor = true;
            this.button100n.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button250n
            // 
            this.button250n.Location = new System.Drawing.Point(171, 3);
            this.button250n.Name = "button250n";
            this.button250n.Size = new System.Drawing.Size(50, 26);
            this.button250n.TabIndex = 3;
            this.button250n.Text = "-250";
            this.button250n.UseVisualStyleBackColor = true;
            this.button250n.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button500n
            // 
            this.button500n.Location = new System.Drawing.Point(227, 3);
            this.button500n.Name = "button500n";
            this.button500n.Size = new System.Drawing.Size(50, 26);
            this.button500n.TabIndex = 4;
            this.button500n.Text = "-500";
            this.button500n.UseVisualStyleBackColor = true;
            this.button500n.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // button1000n
            // 
            this.button1000n.Location = new System.Drawing.Point(283, 3);
            this.button1000n.Name = "button1000n";
            this.button1000n.Size = new System.Drawing.Size(50, 26);
            this.button1000n.TabIndex = 5;
            this.button1000n.Text = "-1000";
            this.button1000n.UseVisualStyleBackColor = true;
            this.button1000n.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel4, 3);
            this.flowLayoutPanel4.Controls.Add(this.buttonHome);
            this.flowLayoutPanel4.Controls.Add(this.buttonStop);
            this.flowLayoutPanel4.Controls.Add(this.buttonEnd);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(8, 285);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(338, 30);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(3, 3);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(75, 26);
            this.buttonHome.TabIndex = 0;
            this.buttonHome.TabStop = false;
            this.buttonHome.Text = "<<";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.ButtonHome_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(84, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(170, 26);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "STOP";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(260, 3);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(75, 26);
            this.buttonEnd.TabIndex = 2;
            this.buttonEnd.TabStop = false;
            this.buttonEnd.Text = ">>";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.ButtonEnd_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 32;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(361, 324);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.button1);
            this.flowLayoutPanel5.Controls.Add(this.button3);
            this.flowLayoutPanel5.Controls.Add(this.button2);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(105, 35);
            this.flowLayoutPanel5.TabIndex = 36;
            // 
            // radioLabel2
            // 
            this.radioLabel2.Checked = false;
            this.tableLayoutPanel1.SetColumnSpan(this.radioLabel2, 2);
            this.radioLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioLabel2.Location = new System.Drawing.Point(108, 38);
            this.radioLabel2.Name = "radioLabel2";
            this.radioLabel2.Size = new System.Drawing.Size(244, 29);
            this.radioLabel2.Speed = Common.Config.speed_t.NONE;
            this.radioLabel2.Step = Common.Config.step_t.NONE;
            this.radioLabel2.TabIndex = 34;
            this.radioLabel2.Value = "++";
            this.radioLabel2.Click += new System.EventHandler(this.MotorSelect_Click);
            // 
            // radioLabel1
            // 
            this.radioLabel1.Checked = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioLabel1, 2);
            this.radioLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioLabel1.Location = new System.Drawing.Point(108, 3);
            this.radioLabel1.Name = "radioLabel1";
            this.radioLabel1.Size = new System.Drawing.Size(244, 29);
            this.radioLabel1.Speed = Common.Config.speed_t.NONE;
            this.radioLabel1.Step = Common.Config.step_t.NONE;
            this.radioLabel1.TabIndex = 33;
            this.radioLabel1.Value = "++";
            this.radioLabel1.Click += new System.EventHandler(this.MotorSelect_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 326);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ardufocus GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlForm_FormClosed);
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlForm_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button button15n;
        private System.Windows.Forms.Button button50n;
        private System.Windows.Forms.Button button100n;
        private System.Windows.Forms.Button button250n;
        private System.Windows.Forms.Button button500n;
        private System.Windows.Forms.Button button1000n;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button15p;
        private System.Windows.Forms.Button button50p;
        private System.Windows.Forms.Button button100p;
        private System.Windows.Forms.Button button250p;
        private System.Windows.Forms.Button button500p;
        private System.Windows.Forms.Button button1000p;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private Controls.RadioLabel radioLabel1;
        private Controls.RadioLabel radioLabel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
    }
}