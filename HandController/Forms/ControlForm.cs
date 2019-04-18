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
using System;
using System.Linq;
using System.Windows.Forms;
using ASCOM.Ardufocus.Controls;

using Common;
using Common.Config;

namespace ASCOM.Ardufocus.Forms
{
    public partial class ControlForm : Form
    {
        private System.Timers.Timer TimerTicker;
        internal static Common.Config.Profile config;

        public System.Timers.Timer Ticker
        {
            get
            {
                if (TimerTicker == null)
                {
                    TimerTicker = new System.Timers.Timer()
                    {
                        Interval = 1000,
                        Enabled = false,
                    };

                    TimerTicker.Elapsed += (source, e) =>
                    {
                        Context.TriggerUpdateUIState();
                    };

                    Utility.ConsoleLogMessage("Initialized the refresh timer.");
                }

                return TimerTicker;
            }
        }

        public ControlForm()
        {
            InitializeComponent();

            if (config == null)
            {
                config = new Common.Config.Profile
                {
                    StorageDriver = new Common.Config.Storage.WindowsRegistry()
                    {
                        ProfileName = Common.Metadata.Name
                    }
                };
                config.Load();
            }

            SetUIState();
        }

        private void SetUIState()
        {
            Context.ActiveMotor = Motor_t.MOTOR_ONE;

            // Load images from resource file
            button1.Image = Common.Properties.Resources.power_plug;
            button2.Image = Common.Properties.Resources.debug_step_over;
            button3.Image = Common.Properties.Resources.info;

            // Events
            button3.Click += (source, e) =>
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                Common.Forms.About form = new Common.Forms.About(
                    Metadata.Name,
                    string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision),
                    Metadata.DriverDescription);
                form.Show();
            };

            radioLabel1.Enabled = false;
            radioLabel2.Enabled = false;
        }

        private void UpdateUIState()
        {
            bool state = false;
            state = Context.CheckIfConnected(Motor_t.MOTOR_ONE) || Context.CheckIfConnected(Motor_t.MOTOR_TWO);

            this.Text = string.Format("{0} - {1}", Common.Metadata.Name, (state) ? "Connected" : "Disconnected");

            foreach (var control in Utility.GetControlHierarchy(this).ToList())
            {
                if ((control is Button || control is TextBox) && (control.Name != "button1" && control.Name != "button3"))
                {
                    control.Enabled = state;
                }
            }

            UpdateMotorOne();
            UpdateMotorTwo();

            if(state)
            {
                double temperature = 0F;

                // Fetch device information from ASCOM
                // the try-catch block is important to handle ASCOM exceptions given by the driver
                try
                {
                    temperature = Context.M1.Temperature;
                }
                catch (Exception e)
                {
                    Utility.ConsoleLogMessage("ASCOM Exception: {0}", e.Message.Replace(Environment.NewLine, string.Empty));
                }
                // -------------------------------------------------------------------------------

                label6.Enabled = true;
                this.label6.Text = string.Format("{0:0.0} ºC", temperature);

                // Activate the background task ticker
                if (!Ticker.Enabled)
                {
                    Ticker.Enabled = true;
                    Utility.ConsoleLogMessage("Refresh timer enabled.");
                }

                // Update images based on connection state
                button1.Image = Common.Properties.Resources.power_plug_off;
            }
            else
            {
                label6.Enabled = false;
                this.label6.Text = string.Format("{0:0.0} ºC", 0F);

                this.radioLabel1.Checked = false;
                this.radioLabel2.Checked = false;

                this.trackBar1.Value = 0;
                this.trackBar1.Maximum = 100;
                this.trackBar1.TickFrequency = 10;

                // Deactivate the background task ticker
                if (Ticker.Enabled)
                {
                    Ticker.Enabled = false;
                    Utility.ConsoleLogMessage("Refresh timer disabled.");
                }

                // Update images based on connection state
                button1.Image = Common.Properties.Resources.power_plug;
            }
        }

        private void UpdateMotorOne()
        {
            bool state = Context.CheckIfConnected(Motor_t.MOTOR_ONE);

            if (state)
            {
                int max = 0, position = 0;
                step_t step = step_t.NONE;
                speed_t speed = speed_t.NONE;

                try
                {
                    max = Context.M1.MaxStep;
                    position = Context.M1.Position;
                }
                catch (Exception e)
                {
                    Utility.ConsoleLogMessage("ASCOM Exception: {0}", e.Message.Replace(Environment.NewLine, string.Empty));
                }

                try
                {
                    step = Common.Utility.StringToStep(Context.M1.CommandString("GetMode", false));
                    speed = Common.Utility.StringToSpeed(Context.M1.CommandString("GetSpeed", false));
                }
                catch (Exception e)
                {
                    Utility.ConsoleLogMessage("ASCOM Exception: {0}", e.Message.Replace(Environment.NewLine, string.Empty));
                }

                if(Context.ActiveMotor == Motor_t.MOTOR_ONE)
                {
                    this.radioLabel1.Checked = true;
                    this.radioLabel2.Checked = false;

                    this.trackBar1.Maximum = max;
                    this.trackBar1.TickFrequency = (int)(max / 10);
                    this.trackBar1.Value = (position > max) ? max : position;
                }

                radioLabel1.Enabled = true;
                this.radioLabel1.Step = step;
                this.radioLabel1.Speed = speed;
                this.radioLabel1.Value = position.ToString();
            }
            else
            {
                radioLabel1.Enabled = false;
                this.radioLabel1.Value = "0";
                this.radioLabel1.Checked = false;
                this.radioLabel1.Step = step_t.NONE;
                this.radioLabel1.Speed = speed_t.NONE;
            }
        }

        private void UpdateMotorTwo()
        {
            bool state = Context.CheckIfConnected(Motor_t.MOTOR_TWO);

            if (state)
            {
                int max = 0, position = 0;
                step_t step = step_t.NONE;
                speed_t speed = speed_t.NONE;

                try
                {
                    max = Context.M2.MaxStep;
                    position = Context.M2.Position;
                }
                catch (Exception e)
                {
                    Utility.ConsoleLogMessage("ASCOM Exception: {0}", e.Message.Replace(Environment.NewLine, string.Empty));
                }

                try
                {
                    step = Common.Utility.StringToStep(Context.M2.CommandString("GetMode", false));
                    speed = Common.Utility.StringToSpeed(Context.M2.CommandString("GetSpeed", false));
                }
                catch (Exception e)
                {
                    Utility.ConsoleLogMessage("ASCOM Exception: {0}", e.Message.Replace(Environment.NewLine, string.Empty));
                }

                if (Context.ActiveMotor == Motor_t.MOTOR_TWO)
                {
                    this.radioLabel1.Checked = false;
                    this.radioLabel2.Checked = true;

                    this.trackBar1.Maximum = max;
                    this.trackBar1.TickFrequency = (int)(max / 10);
                    this.trackBar1.Value = (position > max) ? max : position;
                }

                radioLabel2.Enabled = true;
                this.radioLabel2.Step = step;
                this.radioLabel2.Speed = speed;
                this.radioLabel2.Value = position.ToString();
            }
            else
            {
                radioLabel2.Enabled = false;
                this.radioLabel2.Value = "0";
                this.radioLabel2.Checked = false;
                this.radioLabel2.Step = step_t.NONE;
                this.radioLabel2.Speed = speed_t.NONE;
            }
        }

        private void ControlForm_Paint(object sender, PaintEventArgs e)
        {
            UpdateUIState();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            Utility.ConsoleLogMessage("Saved window position: {0}, {1}",
                Properties.Settings.Default.ControlForm_X, Properties.Settings.Default.ControlForm_Y);

            if (Properties.Settings.Default.ControlForm_X == -1 || Properties.Settings.Default.ControlForm_Y == -1)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Top = Properties.Settings.Default.ControlForm_X;
                this.Left = Properties.Settings.Default.ControlForm_Y;
            }
        }

        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            Application.Exit();
        }

        private void ControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (Context.M1 != null)
                {
                    if (Context.CheckIfConnected(Motor_t.MOTOR_ONE))
                    {
                        Utility.ConsoleLogMessage("Disconnect ASCOM driver ONE.");
                        Context.M1.Connected = false;
                    }

                    //((IDisposable)Context.M1).Dispose();
                    Context.M1 = null;
                }

                if (Context.M2 != null)
                {
                    if (Context.CheckIfConnected(Motor_t.MOTOR_TWO))
                    {
                        Utility.ConsoleLogMessage("Disconnect ASCOM driver TWO.");
                        Context.M2.Connected = false;
                    }

                    //((IDisposable)Context.M2).Dispose();
                    Context.M2 = null;
                }

                if (this.Top >= -1 && this.Left >= -1)
                {
                    Utility.ConsoleLogMessage("Saving window position: {0}, {1}", this.Top, this.Left);
                    Properties.Settings.Default.ControlForm_X = this.Top;
                    Properties.Settings.Default.ControlForm_Y = this.Left;
                }
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs ea)
        {
            try
            {
                config.Load();

                if (config.M1.Enabled)
                {

                    if (Context.M1 != null && Context.M1.Connected)
                    {
                        Utility.ConsoleLogMessage("Disconnect ASCOM driver one.");
                        Context.M1.Connected = false;

                        ((IDisposable)Context.M1).Dispose();
                        Context.M1 = null;
                    }
                    else
                    {
                        if (Context.M1 == null)
                        {
                            try
                            {
                                Context.M1 = new DriverAccess.Focuser(Properties.Settings.Default.DriverOneID);
                                Utility.ConsoleLogMessage("Initialized the ASCOM driver access object.");
                            }
                            catch (Exception e)
                            {
                                Utility.ConsoleLogMessage("Failed to init the ASCOM driver access object.");
                                Utility.ConsoleLogMessage(e.Message);
                                return;
                            }
                        }

                        Utility.ConsoleLogMessage("Connect ASCOM driver one.");
                        Context.M1.Connected = true;
                    }
                }

                if (config.M2.Enabled)
                {
                    if (Context.M2 != null && Context.M2.Connected)
                    {
                        Utility.ConsoleLogMessage("Disconnect ASCOM driver two.");
                        Context.M2.Connected = false;

                        ((IDisposable)Context.M2).Dispose();
                        Context.M2 = null;
                    }
                    else
                    {
                        if (Context.M2 == null)
                        {
                            try
                            {
                                Context.M2 = new DriverAccess.Focuser(Properties.Settings.Default.DriverTwoID);
                                Utility.ConsoleLogMessage("Initialized the ASCOM driver access object.");
                            }
                            catch (Exception e)
                            {
                                Utility.ConsoleLogMessage("Failed to init the ASCOM driver access object.");
                                Utility.ConsoleLogMessage(e.Message);
                                return;
                            }
                        }

                        Utility.ConsoleLogMessage("Connect ASCOM driver two.");
                        Context.M2.Connected = true;
                    }
                }
            }
            catch (Exception e) {
                Utility.ConsoleLogMessage("ASCOM Exception: {0}.", e.Message.Replace(Environment.NewLine, string.Empty));
            };

            bool state = Context.CheckIfConnected(Motor_t.MOTOR_ONE);
            Utility.ConsoleLogMessage("ASCOM driver ONE state is {0}.", (state) ? "connected" : "disconnected");

            Utility.ConsoleLogMessage("ASCOM driver TWO state is {0}.",
                (Context.CheckIfConnected(Motor_t.MOTOR_TWO)) ? "connected" : "disconnected");

            if (state)
            {
                Ticker.Enabled = true;
                Utility.ConsoleLogMessage("Refresh timer enabled.");
            }
            else
            {
                Ticker.Enabled = false;
                Utility.ConsoleLogMessage("Refresh timer disabled.");
            }

            // Trigger a redraw of the form
            this.Refresh();
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            if(!Context.CheckIfConnected()) { return; }

            Utility.ConsoleLogMessage("Show Position input form.");
            PositionForm answer = new PositionForm();

            if (answer.ShowDialog(this) == DialogResult.OK)
            {
                int position = Convert.ToInt32(answer.GetUserInput());

                if (position < 0)
                {
                    position = 0;
                    Utility.ConsoleLogMessage("User input was bellow 0.");
                }
                else if (position > Context.Driver.MaxStep)
                {
                    position = Context.Driver.MaxStep;
                    Utility.ConsoleLogMessage("User input was above max step value.");
                }
                Context.Driver.Move(position);
                Utility.ConsoleLogMessage("Move motor 1 to {0} command sent to the ASCOM driver.", position);
            }
            else
            {
                Utility.ConsoleLogMessage("User canceled the move command.");
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            if (!Context.CheckIfConnected()) { return; }
            Utility.ConsoleLogMessage("Command halt sent to the first ASCOM driver.");
            Context.Driver.Halt();
        }

        private void ButtonHome_Click(object sender, EventArgs e)
        {
            if (!Context.CheckIfConnected()) { return; }
            Utility.ConsoleLogMessage("Command move to home sent to the first ASCOM driver.");
            Context.Driver.Move(0);
        }

        private void ButtonEnd_Click(object sender, EventArgs e)
        {
            if (!Context.CheckIfConnected()) { return; }
            Utility.ConsoleLogMessage("Command move to end sent to the ASCOM first driver.");
            Context.Driver.Move(Context.M1.MaxStep);
        }

        private void ButtonStep_Click(object sender, EventArgs e)
        {
            if (!Context.CheckIfConnected()) { return; }

            string name = ((Button)sender).Name.Substring(6);
            int value = Convert.ToInt16(name.Substring(0, name.Length - 1));
            if (name.Substring(name.Length - 1) == "n") { value *= -1; }

            int position = Context.Driver.Position + value;

            if (position < 0)
            {
                position = 0;
                Utility.ConsoleLogMessage("Calculated position was bellow 0.");
            }
            else if (position > Context.Driver.MaxStep)
            {
                position = Context.Driver.MaxStep;
                Utility.ConsoleLogMessage("Calculated position was above max step value.");
            }

            Context.Driver.Move(position);
            Utility.ConsoleLogMessage("Move to {0} command sent to the ASCOM driver.", position);
        }

        private void MotorSelect_Click(object sender, EventArgs e)
        {
            RadioLabel control = (RadioLabel)sender;

            switch(control.Name)
            {
                case "radioLabel1":
                    Context.ActiveMotor = Motor_t.MOTOR_ONE;
                    break;

                case "radioLabel2":
                    Context.ActiveMotor = Motor_t.MOTOR_TWO;
                    break;
            }

            this.Refresh();
        }
    }
}