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
namespace Setup.Forms
{
    partial class SetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hr1 = new System.Windows.Forms.Label();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxDebug = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxHighResolution = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.M1Speed = new System.Windows.Forms.ComboBox();
            this.M1Mode = new System.Windows.Forms.ComboBox();
            this.M1MaxValue = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MotorOneGroup = new System.Windows.Forms.GroupBox();
            this.MotorTwoGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.M2Speed = new System.Windows.Forms.ComboBox();
            this.M2Mode = new System.Windows.Forms.ComboBox();
            this.M2MaxValue = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.verticalLabel3 = new Common.Controls.VerticalLabel();
            this.verticalLabel2 = new Common.Controls.VerticalLabel();
            this.verticalLabel1 = new Common.Controls.VerticalLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M1MaxValue)).BeginInit();
            this.MotorOneGroup.SuspendLayout();
            this.MotorTwoGroup.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M2MaxValue)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(164, 476);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 28);
            this.cmdOK.TabIndex = 9;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(270, 476);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 28);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = ((System.Drawing.Image)(resources.GetObject("picASCOM.Image")));
            this.picASCOM.Location = new System.Drawing.Point(322, 12);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(10, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(306, 33);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSubTitle
            // 
            this.labelSubTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSubTitle.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubTitle.Location = new System.Drawing.Point(15, 45);
            this.labelSubTitle.Name = "labelSubTitle";
            this.labelSubTitle.Size = new System.Drawing.Size(301, 23);
            this.labelSubTitle.TabIndex = 12;
            this.labelSubTitle.Text = "Subtitle";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Serial port:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hr1
            // 
            this.hr1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hr1.Location = new System.Drawing.Point(10, 460);
            this.hr1.Margin = new System.Windows.Forms.Padding(10);
            this.hr1.Name = "hr1";
            this.hr1.Size = new System.Drawing.Size(364, 2);
            this.hr1.TabIndex = 14;
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(103, 3);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(224, 21);
            this.comboBoxComPort.TabIndex = 0;
            this.comboBoxComPort.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(33, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(340, 104);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.comboBoxComPort, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDebug, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxHighResolution, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 18);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 81);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // checkBoxDebug
            // 
            this.checkBoxDebug.AutoSize = true;
            this.checkBoxDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDebug.Location = new System.Drawing.Point(103, 30);
            this.checkBoxDebug.Name = "checkBoxDebug";
            this.checkBoxDebug.Size = new System.Drawing.Size(224, 21);
            this.checkBoxDebug.TabIndex = 1;
            this.checkBoxDebug.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "ASCOM trace:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(0, 54);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 27);
            this.label9.TabIndex = 7;
            this.label9.Text = "High precision:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxHighResolution
            // 
            this.checkBoxHighResolution.AutoSize = true;
            this.checkBoxHighResolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxHighResolution.Location = new System.Drawing.Point(103, 57);
            this.checkBoxHighResolution.Name = "checkBoxHighResolution";
            this.checkBoxHighResolution.Size = new System.Drawing.Size(224, 21);
            this.checkBoxHighResolution.TabIndex = 2;
            this.checkBoxHighResolution.UseVisualStyleBackColor = true;
            this.checkBoxHighResolution.Click += new System.EventHandler(this.HighResCheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.checkBox1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.M1Speed, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.M1Mode, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.M1MaxValue, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 18);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 108);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Location = new System.Drawing.Point(103, 84);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(224, 21);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.DriverEnableCheckedChanged);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(0, 81);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 27);
            this.label10.TabIndex = 13;
            this.label10.Text = "Enabled:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 27);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stepping speed:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // M1Speed
            // 
            this.M1Speed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.M1Speed.FormattingEnabled = true;
            this.M1Speed.Location = new System.Drawing.Point(103, 3);
            this.M1Speed.Name = "M1Speed";
            this.M1Speed.Size = new System.Drawing.Size(224, 21);
            this.M1Speed.TabIndex = 3;
            this.M1Speed.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // M1Mode
            // 
            this.M1Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.M1Mode.FormattingEnabled = true;
            this.M1Mode.Items.AddRange(new object[] {
            ""});
            this.M1Mode.Location = new System.Drawing.Point(103, 30);
            this.M1Mode.Name = "M1Mode";
            this.M1Mode.Size = new System.Drawing.Size(224, 21);
            this.M1Mode.TabIndex = 4;
            this.M1Mode.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // M1MaxValue
            // 
            this.M1MaxValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.M1MaxValue.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.M1MaxValue.Location = new System.Drawing.Point(103, 57);
            this.M1MaxValue.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.M1MaxValue.Name = "M1MaxValue";
            this.M1MaxValue.Size = new System.Drawing.Size(224, 20);
            this.M1MaxValue.TabIndex = 5;
            this.M1MaxValue.ValueChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(0, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 27);
            this.label5.TabIndex = 11;
            this.label5.Text = "Stepping mode:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(0, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 27);
            this.label6.TabIndex = 12;
            this.label6.Text = "Max value:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MotorOneGroup
            // 
            this.MotorOneGroup.AutoSize = true;
            this.MotorOneGroup.Controls.Add(this.tableLayoutPanel2);
            this.MotorOneGroup.Location = new System.Drawing.Point(33, 181);
            this.MotorOneGroup.Name = "MotorOneGroup";
            this.MotorOneGroup.Padding = new System.Windows.Forms.Padding(5);
            this.MotorOneGroup.Size = new System.Drawing.Size(340, 131);
            this.MotorOneGroup.TabIndex = 18;
            this.MotorOneGroup.TabStop = false;
            // 
            // MotorTwoGroup
            // 
            this.MotorTwoGroup.AutoSize = true;
            this.MotorTwoGroup.Controls.Add(this.tableLayoutPanel3);
            this.MotorTwoGroup.Location = new System.Drawing.Point(28, 318);
            this.MotorTwoGroup.Name = "MotorTwoGroup";
            this.MotorTwoGroup.Padding = new System.Windows.Forms.Padding(5);
            this.MotorTwoGroup.Size = new System.Drawing.Size(340, 131);
            this.MotorTwoGroup.TabIndex = 19;
            this.MotorTwoGroup.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.checkBox2, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.M2Speed, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.M2Mode, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.M2MaxValue, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 18);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(330, 108);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox2.Location = new System.Drawing.Point(103, 84);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(224, 21);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Click += new System.EventHandler(this.DriverEnableCheckedChanged);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(0, 81);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 27);
            this.label11.TabIndex = 13;
            this.label11.Text = "Enabled:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "Stepping speed:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // M2Speed
            // 
            this.M2Speed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.M2Speed.FormattingEnabled = true;
            this.M2Speed.Location = new System.Drawing.Point(103, 3);
            this.M2Speed.Name = "M2Speed";
            this.M2Speed.Size = new System.Drawing.Size(224, 21);
            this.M2Speed.TabIndex = 6;
            this.M2Speed.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // M2Mode
            // 
            this.M2Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.M2Mode.FormattingEnabled = true;
            this.M2Mode.Items.AddRange(new object[] {
            ""});
            this.M2Mode.Location = new System.Drawing.Point(103, 30);
            this.M2Mode.Name = "M2Mode";
            this.M2Mode.Size = new System.Drawing.Size(224, 21);
            this.M2Mode.TabIndex = 7;
            this.M2Mode.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // M2MaxValue
            // 
            this.M2MaxValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.M2MaxValue.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.M2MaxValue.Location = new System.Drawing.Point(103, 57);
            this.M2MaxValue.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.M2MaxValue.Name = "M2MaxValue";
            this.M2MaxValue.Size = new System.Drawing.Size(224, 20);
            this.M2MaxValue.TabIndex = 8;
            this.M2MaxValue.ValueChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(0, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 27);
            this.label7.TabIndex = 11;
            this.label7.Text = "Stepping mode:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(0, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 27);
            this.label8.TabIndex = 12;
            this.label8.Text = "Max value:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(12, 484);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(28, 13);
            this.labelVersion.TabIndex = 20;
            this.labelVersion.Text = "v0.0";
            // 
            // verticalLabel3
            // 
            this.verticalLabel3.Flip180 = true;
            this.verticalLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalLabel3.Location = new System.Drawing.Point(5, 318);
            this.verticalLabel3.Name = "verticalLabel3";
            this.verticalLabel3.Size = new System.Drawing.Size(20, 131);
            this.verticalLabel3.TabIndex = 24;
            this.verticalLabel3.Text = "Second Driver";
            // 
            // verticalLabel2
            // 
            this.verticalLabel2.Flip180 = true;
            this.verticalLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalLabel2.Location = new System.Drawing.Point(7, 181);
            this.verticalLabel2.Name = "verticalLabel2";
            this.verticalLabel2.Size = new System.Drawing.Size(20, 131);
            this.verticalLabel2.TabIndex = 23;
            this.verticalLabel2.Text = "First Driver";
            // 
            // verticalLabel1
            // 
            this.verticalLabel1.Flip180 = true;
            this.verticalLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalLabel1.Location = new System.Drawing.Point(7, 71);
            this.verticalLabel1.Name = "verticalLabel1";
            this.verticalLabel1.Size = new System.Drawing.Size(20, 104);
            this.verticalLabel1.TabIndex = 22;
            this.verticalLabel1.Text = "General";
            // 
            // SetupForm
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(382, 516);
            this.Controls.Add(this.verticalLabel3);
            this.Controls.Add(this.verticalLabel2);
            this.Controls.Add(this.verticalLabel1);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.MotorTwoGroup);
            this.Controls.Add(this.MotorOneGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hr1);
            this.Controls.Add(this.labelSubTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.Shown += new System.EventHandler(this.SetupForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SetupForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M1MaxValue)).EndInit();
            this.MotorOneGroup.ResumeLayout(false);
            this.MotorOneGroup.PerformLayout();
            this.MotorTwoGroup.ResumeLayout(false);
            this.MotorTwoGroup.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M2MaxValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label hr1;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxDebug;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox M1Speed;
        private System.Windows.Forms.ComboBox M1Mode;
        private System.Windows.Forms.NumericUpDown M1MaxValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox MotorOneGroup;
        private System.Windows.Forms.GroupBox MotorTwoGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox M2Speed;
        private System.Windows.Forms.ComboBox M2Mode;
        private System.Windows.Forms.NumericUpDown M2MaxValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxHighResolution;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label11;
        private Common.Controls.VerticalLabel verticalLabel1;
        private Common.Controls.VerticalLabel verticalLabel2;
        private Common.Controls.VerticalLabel verticalLabel3;
    }
}