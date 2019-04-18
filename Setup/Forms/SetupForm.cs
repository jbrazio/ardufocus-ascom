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
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Setup.Forms
{
    [ComVisible(false)]
    public partial class SetupForm : Form
    {
        internal static Common.Config.Profile config;

        const int LowResSteps = 65535;
        const int HighResSteps = 2147483647;

        public SetupForm()
        {
            InitializeComponent();

            config = new Common.Config.Profile
            {
                StorageDriver = new Common.Config.Storage.WindowsRegistry()
                {
                    ProfileName = Common.Metadata.Name
                }
            };

            config.Load();

            InitUI();
            UpdateUI();
        }

        private void SetupForm_Paint(object sender, PaintEventArgs e)
        {
            this.Text = String.Format("{0}", Common.Metadata.DriverDescription);
        }

        private void SetupForm_Shown(object sender, EventArgs e)
        {
            comboBoxComPort.Focus();
        }

        private void ControlTextChanged(object sender, EventArgs e)
        {
            Control obj = (Control)sender;
            if (obj.BackColor == Color.Red) obj.BackColor = SystemColors.Window;
        }

        private void InitUI()
        {
            labelTitle.Text = Common.Metadata.Name;
            labelSubTitle.Text = Common.Metadata.DriverInfo;
            this.Text = Common.Metadata.Name + " ASCOM Driver Setup";

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            labelVersion.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "v{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);


            Dictionary<Common.Config.step_t, string> ModeList = new Dictionary<Common.Config.step_t, string>
            {
                { Common.Config.step_t.FULL, "Full Step" },
                { Common.Config.step_t.ONE_HALF, "Half Step" },
                //{ Common.Config.step_t.ONE_FOURTH, "Quarter Step" },
                //{ Common.Config.step_t.ONE_EIGHTH, "Eighth Step" },
                //{ Common.Config.step_t.ONE_SIXTEENTH, "Sixteenth Step" }
            };

            Dictionary< Common.Config.speed_t, string> SpeedList = new Dictionary<Common.Config.speed_t, string>
            {
                { Common.Config.speed_t.SPEED100, "100%" },
                { Common.Config.speed_t.SPEED50,   "50%" },
                { Common.Config.speed_t.SPEED25,   "25%" },
                { Common.Config.speed_t.SPEED20,   "20%" },
                { Common.Config.speed_t.SPEED10,   "10%" }
            };

            M1Mode.DataSource = new BindingSource(ModeList, null);
            M1Mode.DisplayMember = "Value";
            M1Mode.ValueMember = "Key";

            M2Mode.DataSource = new BindingSource(ModeList, null);
            M2Mode.DisplayMember = "Value";
            M2Mode.ValueMember = "Key";

            M1Speed.DataSource = new BindingSource(SpeedList, null);
            M1Speed.DisplayMember = "Value";
            M1Speed.ValueMember = "Key";

            M2Speed.DataSource = new BindingSource(SpeedList, null);
            M2Speed.DisplayMember = "Value";
            M2Speed.ValueMember = "Key";

            M1MaxValue.Maximum = HighResSteps;
            M2MaxValue.Maximum = HighResSteps;

            comboBoxComPort.Items.Clear();
            comboBoxComPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        }

        private void UpdateUI()
        {
            if (comboBoxComPort.Items.Contains(config.ComPortName))
            {
                comboBoxComPort.SelectedItem = config.ComPortName;
            }

            checkBoxDebug.Checked = config.ASCOMTraceLogEnable;
            checkBoxHighResolution.Checked = config.HighResolution;

            checkBox1.Checked = config.M1.Enabled;
            checkBox2.Checked = config.M2.Enabled;

            M1Mode.SelectedValue = config.M1.SteppingMode;
            M1Speed.SelectedValue = config.M1.SteppingSpeed;
            M1MaxValue.Value = config.M1.MaxNumberOfSteps;

            M2Mode.SelectedValue = config.M2.SteppingMode;
            M2Speed.SelectedValue = config.M2.SteppingSpeed;
            M2MaxValue.Value = config.M2.MaxNumberOfSteps;

            label4.Enabled = config.M1.Enabled;
            M1Speed.Enabled = config.M1.Enabled;
            label5.Enabled = config.M1.Enabled;
            M1Mode.Enabled = config.M1.Enabled;
            label6.Enabled = config.M1.Enabled;
            M1MaxValue.Enabled = config.M1.Enabled;

            label2.Enabled = config.M2.Enabled;
            M2Speed.Enabled = config.M2.Enabled;
            label7.Enabled = config.M2.Enabled;
            M2Mode.Enabled = config.M2.Enabled;
            label8.Enabled = config.M2.Enabled;
            M2MaxValue.Enabled = config.M2.Enabled;
        }

        private bool UpdateConfig(bool Validate = true)
        {
            if (Validate && comboBoxComPort.Text.Length == 0)
            {
                MessageBox.Show("Serial communication port cannot be empty.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxComPort.BackColor = Color.Red;
                comboBoxComPort.Focus();
                return false;
            }
            else
            {
                config.ComPortName = (string)comboBoxComPort.SelectedItem;
            }

            config.HighResolution = checkBoxHighResolution.Checked;
            config.ASCOMTraceLogEnable = checkBoxDebug.Checked;

            if (MotorOneGroup.Enabled)
            {
                if (Validate && M1Speed.Text.Length == 0)
                {
                    MessageBox.Show("Speed value for motor one must not be empty.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    M1Speed.BackColor = Color.Red;
                    M1Speed.Focus();
                    return false;
                }
                else
                {
                    config.M1.SteppingSpeed = ((KeyValuePair<Common.Config.speed_t, string>)M1Speed.SelectedItem).Key;
                }

                if (Validate && M1Mode.Text.Length == 0)
                {
                    MessageBox.Show("Stepping mode for motor one must not be empty.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    M1Mode.BackColor = Color.Red;
                    M1Mode.Focus();
                    return false;
                }
                else
                {
                    config.M1.SteppingMode = ((KeyValuePair<Common.Config.step_t, string>)M1Mode.SelectedItem).Key;
                }

                if (Validate && M1MaxValue.Value.ToString().Length == 0)
                {
                    MessageBox.Show("Max stepping value must not be empty.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    M1MaxValue.BackColor = Color.Red;
                    M1MaxValue.Focus();
                    return false;
                }
                else if (Validate && M1MaxValue.Value > ((config.HighResolution) ? HighResSteps : LowResSteps))
                {
                    MessageBox.Show("Max stepping value is over the precision limit.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    M1MaxValue.BackColor = Color.Red;
                    M1MaxValue.Focus();
                    return false;
                }
                else
                {
                    config.M1.MaxNumberOfSteps = (int)M1MaxValue.Value;
                }

                config.M1.Enabled = checkBox1.Checked;
            }

            if (MotorTwoGroup.Enabled)
            {
                if (Validate && M2Speed.Text.Length == 0)
                {
                    MessageBox.Show("Speed value for motor one must not be empty.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    M2Speed.BackColor = Color.Red;
                    M2Speed.Focus();
                    return false;
                }
                else
                {
                    config.M2.SteppingSpeed = ((KeyValuePair<Common.Config.speed_t, string>)M2Speed.SelectedItem).Key;
                }

                if (Validate && M2Mode.Text.Length == 0)
                {
                    MessageBox.Show("Stepping mode for motor one must not be empty.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    M2Mode.BackColor = Color.Red;
                    M2Mode.Focus();
                    return false;
                }
                else
                {
                    config.M2.SteppingMode = ((KeyValuePair<Common.Config.step_t, string>)M2Mode.SelectedItem).Key;
                }

                if (Validate && M2MaxValue.Value.ToString().Length == 0)
                {
                    MessageBox.Show("Max stepping value must not be empty.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    M2MaxValue.BackColor = Color.Red;
                    M2MaxValue.Focus();
                    return false;
                }
                else if (Validate && M2MaxValue.Value > ((config.HighResolution) ? HighResSteps : LowResSteps))
                {
                    MessageBox.Show("Max stepping value is over the precision limit.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    M2MaxValue.BackColor = Color.Red;
                    M2MaxValue.Focus();
                    return false;
                }
                else
                {
                    config.M2.MaxNumberOfSteps = (int)M2MaxValue.Value;
                }

                config.M2.Enabled = checkBox2.Checked;
            }

            return true;
        }

        private void ButtonOK_Click(object sender, EventArgs e) // OK button event handler
        {
            if (UpdateConfig())
            {
                config.Save();
                this.Close();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void HighResCheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig(false);

            int steps = (config.HighResolution) ? HighResSteps : LowResSteps;

            switch (config.M1.MaxNumberOfSteps)
            {
                case 0:
                    config.M1.MaxNumberOfSteps = steps;
                    break;

                case LowResSteps:
                    config.M1.MaxNumberOfSteps = steps;
                    break;

                case HighResSteps:
                    config.M1.MaxNumberOfSteps = steps;
                    break;
            }

            switch (config.M2.MaxNumberOfSteps)
            {
                case 0:
                    config.M2.MaxNumberOfSteps = steps;
                    break;

                case LowResSteps:
                    config.M2.MaxNumberOfSteps = steps;
                    break;

                case HighResSteps:
                    config.M2.MaxNumberOfSteps = steps;
                    break;
            }

            UpdateUI();
        }

        private void DriverEnableCheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig(false);
            UpdateUI();
        }
    }
}