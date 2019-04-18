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
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using Common.Config;

using ASCOM.Ardufocus;
using ASCOM.DeviceInterface;

namespace ASCOM.Ardufocus.Driver
{
    /// <summary>
    /// ASCOM Focuser Driver for Ardufocus.
    /// </summary>
   [ComVisible(false)] 
    public abstract class FocuserBase : ReferenceCountedObjectBase, IFocuserV3
    {
        protected virtual string GET_CURRENT_POS { get { return "GP"; } }
        protected virtual string GET_DTR_RESET { get { return "GY{0:X2}"; } }
        protected virtual string GET_MODE { get { return "GH"; } }
        protected virtual string GET_SPEED { get { return "GD"; } }
        protected virtual string GET_TARGET_POS { get { return "GN"; } }
        protected virtual string GET_TEMPERATURE { get { return "GT"; } }
        protected virtual string GET_VERSION { get { return "GV"; } }
        protected virtual string IS_MOVING { get { return "GI"; } }
        protected virtual string RESET { get { return "Z"; } }
        protected virtual string SET_CURRENT_POS { get { return "SP{0:X4}"; } }
        protected virtual string SET_CURRENT_POS_HIRES { get { return "SP{0:X8}"; } }
        protected virtual string SET_DTR_RESET { get { return "SY{0:X2}"; } }
        protected virtual string SET_MODE_FULL { get { return "SF"; } }
        protected virtual string SET_MODE_HALF { get { return "SH"; } }
        protected virtual string SET_SPEED { get { return "SD{0:X2}"; } }
        protected virtual string SET_TARGET_POS { get { return "SN{0:X4}"; } }
        protected virtual string SET_TARGET_POS_HIRES { get { return "SN{0:X8}"; } }
        protected virtual string START_ADC_READING { get { return "C"; } }
        protected virtual string START_MOTION { get { return "FG"; } }
        protected virtual string STOP_MOTION { get { return "FQ"; } }

        #region Private fields
        /// <summary>
        /// Variable to hold a timer
        /// </summary>
        private static System.Timers.Timer timerADC;
        #endregion

        #region Abtract properties
        /// <summary>
        /// Property to hold the motor ID controller by this driver
        /// </summary>
        public abstract Motor_t MotorID { get; }

        /// <summary>
        /// Property to hold an driver state
        /// </summary>
        public abstract bool ConnectionState { get; set; }

        /// <summary>
        /// Local cache of last valid readings
        /// </summary>
        public abstract Int32 LastPosition { get; set; }
        public abstract double LastTemperature { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FocuserBase"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public FocuserBase()
        {
            if (timerADC == null)
            {
                timerADC = new System.Timers.Timer(10000);

                // ADC read timer
                timerADC.Elapsed += (source, e) =>
                {
                    try
                    {
                        SharedResources.SendSerialMessageBlind(START_ADC_READING);
                    }
                    catch (NotConnectedException)
                    {
                        timerADC.Enabled = false;
                        SharedResources.LogMessage("FocuserBase::timerADC", "NotConnectedException");
                    }
                };
            }
        }


        //
        // PUBLIC COM INTERFACE IFocuserV3 IMPLEMENTATION
        //

        #region IFocuser Implementation: Properties

        /// <summary>
        /// True if the focuser is capable of absolute position; that is, being commanded to a specific step location. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public bool Absolute
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Set True to connect to the device hardware. Set False to disconnect from the device hardware.
        /// You can also read the property to check whether it is connected. This reports the current hardware state.
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public bool Connected
        {
            get
            {
                return ConnectionState;
            }
            set 
            {
                if (value == ConnectionState) { return; }

                if (value)
                {
                    SharedResources.LogMessage(MotorID.ToString() + "::Connected", "Starting a new serial connection");

                    // Check if we are the first client using the shared serial
                    if (SharedResources.Connections == 0)
                    {
                        SharedResources.LogMessage(MotorID.ToString() + "::Connected", "We are the first connected client, setting serial port name");
                        SharedResources.COMPortName = SharedResources.Config.ComPortName;
                    }

                    SharedResources.Connected = true;

                    try
                    {
                        //
                        // Loops until the firmware reports a successful connection 
                        //
                        bool ready = false;
                        string hex;

                        do
                        {
                            try
                            {
                                hex = SharedResources.SendSerialMessage(GET_VERSION);
                                if (hex.Length > 0) { ready = true; }
                            }
                            catch (Exception) { ready = false; }

                        } while (!ready);

                        SharedResources.LogMessage(MotorID.ToString() + "::Connected", "Firmware ready");
                    }
                    catch(Exception e)
                    {
                        SharedResources.LogMessage(MotorID.ToString() + "::Connected", "Exception: {0}", e.Message);
                        ConnectionState = false;
                        return;
                    }

                    // Check if we are the first client using the shared serial
                    if (SharedResources.Connections == 1)
                    {
                        InitDevice();
                    }

                    ConnectionState = true;
                    timerADC.Enabled = true;
                    SharedResources.LogMessage(MotorID.ToString() + "::Connected", "Connected successfully");
                }
                else
                {
                    SharedResources.LogMessage(MotorID.ToString() + "::Connected", "Disconnecting the serial connection");

                    ConnectionState = false;
                    timerADC.Enabled = false;
                    SharedResources.Connected = false;
                    SharedResources.LogMessage(MotorID.ToString() + "::Connected", "Disconnected successfully");
                }
            }
        }

        /// <summary>
        /// Helper functiion to handle the initial device initializatioon
        /// </summary>
        private void InitDevice()
        {
            MotorConfig_t Motor = (MotorID == Motor_t.MOTOR_ONE) ? SharedResources.Config.M1 : SharedResources.Config.M2;

            //
            // Auto select the motor resolution
            //
            string hex;
            SharedResources.SendSerialMessageBlind(START_ADC_READING);
            hex = SharedResources.SendSerialMessage(GET_CURRENT_POS);

            if (hex.Length == 4)
            {
                SharedResources.Config.HighResolution = false;
                SharedResources.LogMessage(MotorID.ToString() + "::InitDevice", "Activating standard resolution mode (16-bit)");
            }
            else if (hex.Length == 8)
            {
                SharedResources.Config.HighResolution = true;
                SharedResources.LogMessage(MotorID.ToString() + "::InitDevice", "Activating high resolution mode (32-bit)");
            }
            else
            {
                throw new FormatException("Invalid hex string received");
            }

            //
            // Set the motor stepping speed
            //
            string Speed = String.Empty;
            SharedResources.LogMessage(MotorID.ToString() + "::InitDevice", "Set motor speed to {0}", Motor.SteppingSpeed.ToString());

            switch (Motor.SteppingSpeed)
            {
                case speed_t.SPEED100:
                    Speed = "02";
                    break;
                case speed_t.SPEED50:
                    Speed = "04";
                    break;
                case speed_t.SPEED25:
                    Speed = "08";
                    break;
                case speed_t.SPEED20:
                    Speed = "10";
                    break;
                case speed_t.SPEED10:
                    Speed = "20";
                    break;

                default:
                    throw new NotSupportedException("Selected SteppingSpeed not supported");
            }

            CommandBlind(string.Format(SET_SPEED, Speed), true);

            //
            // Set the motor mode
            //
            SharedResources.LogMessage(MotorID.ToString() + "::InitDevice", "Set motor stepping mode to {0}", Motor.SteppingMode.ToString());

            switch (Motor.SteppingMode)
            {
                case step_t.FULL:
                    CommandBlind("SetModeFull", false);
                    break;

                case step_t.ONE_HALF:
                    CommandBlind("SetModeHalf", false);
                    break;

                default:
                    throw new NotSupportedException("Selected SteppingMode not supported");
            }
        }

        /// <summary>
        /// Returns a description of the device, such as manufacturer and modelnumber. Any ASCII characters may be used. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public string Description
        {
            get
            {
                return Common.Metadata.DriverDescription;
            }
        }

        /// <summary>
        /// Descriptive and version information about this ASCOM driver. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public string DriverInfo
        {
            get
            {
                return Common.Metadata.DriverInfo;
            }
        }

        /// <summary>
        /// A string containing only the major and minor version of the driver. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public string DriverVersion
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverVersion = String.Format(CultureInfo.InvariantCulture,
                    "{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
                return driverVersion;
            }
        }

        /// <summary>
        /// The interface version number that this device supports. Should return 3 for this interface version. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public short InterfaceVersion
        {
            get
            {
                return Convert.ToInt16("3");
            }
        }

        /// <summary>
        /// True if the focuser is currently moving to a new position. False if the focuser is stationary. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public bool IsMoving
        {
            get
            {
                CheckConnected("IsMoving");

                bool ready = false, value = false;
                string hex;

                do
                {
                    try
                    {
                        hex = "0x" + SharedResources.SendSerialMessage(IS_MOVING);
                        value = Convert.ToBoolean(Convert.ToInt16(hex, 16));
                        ready = true;
                    }
                    catch (Exception) { }
                } while (!ready);

                return value;
            }
        }

        /// <summary>
        /// State of the connection to the focuser.
        /// Direct function to the connected method, the Link method is just here for backwards compatibility
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public bool Link
        {
            get
            {
                return this.Connected;
            }
            set
            {
                this.Connected = value;
            }
        }

        /// <summary>
        /// Maximum increment size allowed by the focuser; i.e. the maximum number of steps allowed in one move operation. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public int MaxIncrement
        {
            get
            {
                return MaxStep;
            }
        }

        /// <summary>
        /// Maximum step position permitted. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public int MaxStep
        {
            get
            {
                return (MotorID == Common.Config.Motor_t.MOTOR_ONE)
                    ? SharedResources.Config.M1.MaxNumberOfSteps : SharedResources.Config.M2.MaxNumberOfSteps;
            }
        }

        /// <summary>
        /// The short name of the driver, for display purposes.
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public string Name
        {
            get
            {
                return Common.Metadata.Name;
            }
        }

        /// <summary>
        /// Current focuser position, in steps. 
        /// 
        /// Can throw a not implemented exception
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public int Position
        {
            get
            {
                CheckConnected("Position");

                string hex;
                int value;

                try
                {
                    hex = "0x" + SharedResources.SendSerialMessage(GET_CURRENT_POS);
                    value = Convert.ToInt32(hex, 16);
                }
                catch(Exception)
                {
                    //throw new FormatException("Invalid hex string received");
                    SharedResources.LogMessage(MotorID.ToString() + "::Position", "Invalid hex string received");
                    return LastPosition;
                }

                //LogMessage("Position", "Return value int:{0} hex:{1}", value, hex);
                LastPosition = value;
                return LastPosition;
            }
        }

        /// <summary>
        /// Step size (microns) for the focuser.
        /// 
        /// Can throw a not implemented exception
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public double StepSize
        {
            get
            {
                SharedResources.LogMessage(MotorID.ToString() + "::StepSize", "Property not implemented by driver");
                throw new PropertyNotImplementedException("StepSize", false);
            }
        }

        /// <summary>
        /// Returns the list of action names supported by this driver.
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public ArrayList SupportedActions
        {
            get
            {
                return new ArrayList();
            }
        }

        /// <summary>
        /// The state of temperature compensation mode (if available), else always False.
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public bool TempComp
        {
            get
            {
                return false;
            }
            set
            {
                SharedResources.LogMessage(MotorID.ToString() + "::TempComp", "Set property not implemented by driver");
                throw new PropertyNotImplementedException("TempComp", false);
            }
        }

        /// <summary>
        /// True if focuser has temperature compensation available.
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public bool TempCompAvailable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Current ambient temperature as measured by the focuser.
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public double Temperature
        {
            get
            {
                CheckConnected("Temperature");

                double f;
                string hex = SharedResources.SendSerialMessage(GET_TEMPERATURE);

                if (hex.Length == 8)
                {
                    uint num = uint.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier);

                    byte[] floatVals = BitConverter.GetBytes(num);
                    f = BitConverter.ToSingle(floatVals, 0);
                }
                else if (hex.Length == 4)
                {
                    byte x = Convert.ToByte(hex, 16);
                    f = Convert.ToDouble(x) / 2;
                }
                else
                {
                    //throw new FormatException("Invalid hex string received");
                    SharedResources.LogMessage(MotorID.ToString() + "::Temperature", "Invalid hex string received");
                    return LastTemperature;
                }

                LastTemperature = Math.Round(f, 1, MidpointRounding.AwayFromZero);
                return LastTemperature;
            }
        }

        #endregion

        #region IFocuser Implementation: Methods

        /// <summary>
        /// Invokes the specified device-specific action.
        /// 
        /// Can throw a not implemented exception
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public string Action(string actionName, string actionParameters)
        {
            SharedResources.LogMessage(MotorID.ToString() + "::Action", "Action {0}, parameters {1} not implemented", actionName, actionParameters);
            throw new ActionNotImplementedException("Action " + actionName + " is not implemented by this driver");
        }

        /// <summary>
        /// Transmits an arbitrary string to the device and does not wait for a response.
        /// Optionally, protocol framing characters may be added to the string before transmission. 
        /// 
        /// Can throw a not implemented exception
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public void CommandBlind(string command, bool raw)
        {
            //CheckConnected("CommandBlind");
            //SharedResources.LogMessage(MotorID.ToString() + "::CommandBlind", "Command: {0}, raw: {1}", command, raw.ToString());

            if (raw)
            {
                SharedResources.SendSerialMessageBlind(command);
            }
            else
            { 
                switch (command)
                {
                    case "SetHome":
                        SharedResources.SendSerialMessageBlind(string.Format(
                            (SharedResources.Config.HighResolution) ? SET_CURRENT_POS : SET_CURRENT_POS_HIRES, 0));
                        break;

                    case "FindHome":
                        SharedResources.SendSerialMessageBlind(string.Format(
                            (SharedResources.Config.HighResolution) ? SET_TARGET_POS : SET_TARGET_POS_HIRES, Int32.MaxValue));
                        Move(0);
                        break;

                    case "SetModeFull":
                        SharedResources.SendSerialMessageBlind(SET_MODE_FULL);
                        break;

                    case "SetModeHalf":
                        SharedResources.SendSerialMessageBlind(SET_MODE_HALF);
                        break;

                    default:
                        throw new MethodNotImplementedException("MethodNotImplementedException: CommandBlind");
                }
            }
        }

        /// <summary>
        /// Transmits an arbitrary string to the device and waits for a boolean response. 
        /// Optionally, protocol framing characters may be added to the string before transmission. 
        /// 
        /// Can throw a not implemented exception
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public bool CommandBool(string command, bool raw)
        {
            //CheckConnected("CommandBool");
            //SharedResources.LogMessage(MotorID.ToString() + "::CommandBool", "Command: {0}, raw: {1}", command, raw.ToString());

            if (raw)
            {
                return Convert.ToBoolean(CommandString(command, true));
            }
            else
            {
                switch (command)
                {
                    default:
                        throw new MethodNotImplementedException("MethodNotImplementedException: CommandBool");
                }
            }
        }

        /// <summary>
        /// Transmits an arbitrary string to the device and waits for a string response.
        /// Optionally, protocol framing characters may be added to the string before transmission.
        /// 
        /// Can throw a not implemented exception
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public string CommandString(string command, bool raw)
        {
            //CheckConnected("CommandString");
            //SharedResources.LogMessage(MotorID.ToString() + "::CommandString", "Command: {0}, raw: {1}", command, raw.ToString());

            if (raw)
            {
                return SharedResources.SendSerialMessage(command);
            }
            else
            {
                switch (command)
                {
                    case "GetSpeed":
                        return SharedResources.SendSerialMessage(GET_SPEED);

                    case "GetMode":
                        return SharedResources.SendSerialMessage(GET_MODE);

                    default:
                        throw new MethodNotImplementedException("MethodNotImplementedException: CommandString");
                }
            }
        }

        /// <summary>
        /// Dispose the late-bound interface, if needed. Will release it via COM if it is a COM object, else if native .NET will just dereference it for GC. 
        /// 
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool Disposing)
        {
            //((IDisposable) obj).Dispose();

            if (Disposing)
            {
                // Clean up the timer
                if (timerADC != null)
                {
                    if (timerADC.Enabled) timerADC.Enabled = false;
                    timerADC.Dispose();
                    timerADC = null;
                }
            }

            //base.Dispose(Disposing);
        }

        /// <summary>
        /// Immediately stop any focuser motion due to a previous Move(Int32) method call.
        /// 
        /// Can throw a not implemented exception
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public void Halt()
        {
            CheckConnected("Halt");
            SharedResources.SendSerialMessageBlind(STOP_MOTION);
            SharedResources.LogMessage(MotorID.ToString() + "::Halt", "Stop motor movement");
        }

        /// <summary>
        /// Moves the focuser by the specified amount or to the specified position depending on the value of the Absolute property. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public void Move(int Position)
        {

            CheckConnected("Move");

            if (Position > MaxStep) { Position = MaxStep; }

            string command = string.Format(
                (SharedResources.Config.HighResolution) ? SET_TARGET_POS : SET_TARGET_POS_HIRES, Position);

            SharedResources.SendSerialMessageBlind(command);
            SharedResources.SendSerialMessageBlind(START_MOTION);

            SharedResources.LogMessage(MotorID.ToString() + "::Move", "Move motor to '{0}' (cmd: {1})", Position, command);
        }

        /// <summary>
        /// Launches a configuration dialog box for the driver. The call will not return until the user clicks OK or cancel manually. 
        /// 
        /// Must be implemented
        /// Namespace: ASCOM.DeviceInterface
        /// Assembly:  ASCOM.DeviceInterfaces(in ASCOM.DeviceInterfaces.dll) Version: 6.0.0.0 (6.4.1.2695)
        /// </summary>
        public void SetupDialog()
        {
            // consider only showing the setup dialog if not connected
            // or call a different dialog if connected
            if (IsConnected)
            {
                SharedResources.LogMessage(MotorID.ToString() + "::SetupDialog", "Disconnect first before changing driver settings.");
                System.Windows.Forms.MessageBox.Show("Disconnect first before changing driver settings.");
            }
            else
            {
                SharedResources.LogMessage(MotorID.ToString() + "::SetupDialog", "Execute external helper program");
                System.Diagnostics.Process.Start(string.Format("{0}\\ASCOM.Ardufocus.Setup.exe", AppDomain.CurrentDomain.BaseDirectory));
            }
        }

        #endregion

        #region Private properties and methods
        // here are some useful properties and methods that can be used as required
        // to help with driver development

        /// <summary>
        /// Returns true if there is a valid connection to the driver hardware
        /// </summary>
        private bool IsConnected
        {
            get
            {
                return ConnectionState;
            }
        }

        /// <summary>
        /// Use this function to throw an exception if we aren't connected to the hardware
        /// </summary>
        /// <param name="message"></param>
        private void CheckConnected(string message)
        {
            if (!IsConnected)
            {
                throw new ASCOM.NotConnectedException("NotConnectedException: " + message);
            }
        }
        #endregion
    }
}
