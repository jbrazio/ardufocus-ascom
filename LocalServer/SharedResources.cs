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

using ASCOM.Utilities;

namespace ASCOM.Ardufocus
{
    /// <summary>
    /// The resources shared by all drivers and devices, in this example it's a serial port with a shared SendMessage method
    /// an idea for locking the message and handling connecting is given.
    /// In reality extensive changes will probably be needed.
    /// Multiple drivers means that several applications connect to the same hardware device, aka a hub.
    /// Multiple devices means that there are more than one instance of the hardware, such as two focusers.
    /// In this case there needs to be multiple instances of the hardware connector, each with it's own connection count.
    /// </summary>
    public static class SharedResources
    {
        // object used for locking to prevent multiple drivers accessing common code at the same time
        private static readonly object lockObject = new object();

        // Shared serial port. This will allow multiple drivers to use one single serial port.
        private static readonly ASCOM.Utilities.Serial ASCOMSerial = new ASCOM.Utilities.Serial();

        // Counter for the number of connections to the serial port
        private static int ConnectedClients = 0;

        // 
        private static string CMD_START { get { return ":"; } }
        private static string CMD_END { get { return "#"; } }

        //
        // Public access to shared resources
        //

        /// <summary>
        /// Shared config vault object
        /// </summary>
        public static Common.Config.Profile Config
        {
            get
            {
                return Context.config;
            }
        }

        /// <summary>
        /// Shared serial port
        /// </summary>
        private static ASCOM.Utilities.Serial SharedSerial {
            get
            {
                return ASCOMSerial;
            }
        }

        /// <summary>
        /// number of connections to the shared serial port
        /// </summary>
        public static string COMPortName
        {
            get
            {
                return SharedSerial.PortName;
            }
            set
            {
                if (SharedSerial.Connected)
                {
                    LogMessage("SharedResources::COMPortName", "NotSupportedException: Serial port already connected");
                    throw new NotSupportedException("Serial port already connected");
                }

                SharedSerial.PortName = value;
                LogMessage("SharedResources::COMPortName", "New serial port name: {0}", value);
            }
        }

        /// <summary>
        /// number of connections to the shared serial port
        /// </summary>
        public static int Connections {
            get
            {
                //LogMessage("Connections", "ConnectedClients: {0}", ConnectedClients);
                return ConnectedClients;
            }
            set
            {
                ConnectedClients = value;
                //LogMessage("Connections", "ConnectedClients new value: {0}", ConnectedClients);
            }
        }

        /// <summary>
        /// Bla bla bla wrapper
        /// </summary>
        public static bool Connected
        {
            get
            {
                LogMessage("SharedResources::Connected", "SharedSerial.Connected: {0}", SharedSerial.Connected);
                return SharedSerial.Connected;
            }
            set
            {
//                if (SharedSerial.Connected == value) { return; }

                // Check if we are the first client using the shared serial
                if (value)
                {
                    LogMessage("SharedResources::Connected", "New connection request");

                    if (Connections == 0)
                    {
                        LogMessage("SharedResources::Connected", "This is the first client");

                        // Check for a valid serial port name
                        if (Array.IndexOf(SharedSerial.AvailableCOMPorts, SharedSerial.PortName) > -1)
                        {
                            lock (lockObject)
                            {
                                // Sets serial parameters
                                SharedSerial.Speed = SerialSpeed.ps9600;
                                SharedSerial.ReceiveTimeout = 5;
                                SharedSerial.Connected = true;

                                Connections++;
                                LogMessage("SharedResources::Connected", "Connected successfully");
                            }
                        }
                        else
                        {
                            LogMessage("SharedResources::Connected", "Connection aborted, invalid serial port name");
                        }
                    }
                    else
                    {
                        lock (lockObject)
                        {
                            Connections++;
                            LogMessage("SharedResources::Connected", "Connected successfully");
                        }
                    }
                }
                else
                {
                    LogMessage("SharedResources::Connected", "Disconnect request");

                    lock (lockObject)
                    {
                        // Check if we are the last client connected
                        if (Connections == 1)
                        {
                            SharedSerial.ClearBuffers();
                            SharedSerial.Connected = false;
                            LogMessage("SharedResources::Connected", "This is the last client, disconnecting the serial port");
                        }
                        else
                        {
                            LogMessage("SharedResources::Connected", "Serial connection kept alive");
                        }

                        Connections--;
                        LogMessage("SharedResources::Connected", "Disconnected successfully");
                    }
                }

                Context.UpdateUI();
            }
        }

        public static string SendSerialMessage(string message)
        {
            string retval = String.Empty;

            if (SharedSerial.Connected)
            {
                lock (lockObject)
                {
                    SharedSerial.ClearBuffers();
                    SharedSerial.Transmit(CMD_START + message + CMD_END);
                    //LogMessage("SharedResources::SendSerialMessage", "Message: {0}", CMD_START + message + CMD_END);

                    try
                    { 
                        retval = SharedSerial.ReceiveTerminated(CMD_END).Replace(CMD_END, String.Empty);
                        //LogMessage("SharedResources::SendSerialMessage", "Message received: {0}", retval);
                    }
                    catch (Exception)
                    {
                        LogMessage("SharedResources::SendSerialMessage", "Serial timeout exception while receiving data");
                    }

                    LogMessage("SharedResources::SendSerialMessage", "Message sent: {0} received: {1}", CMD_START + message + CMD_END, retval);
                }
            }
            else
            {
                //throw new NotConnectedException("SendSerialMessage");
                LogMessage("SharedResources::SendSerialMessage", "NotConnectedException");
            }

            return retval;
        }

        public static void SendSerialMessageBlind(string message)
        {
            if (SharedSerial.Connected)
            {
                lock (lockObject)
                {
                    SharedSerial.Transmit(CMD_START + message + CMD_END);
                    LogMessage("SharedResources::SendSerialMessage", "Message: {0}", CMD_START + message + CMD_END);
                }
            }
            else
            {
                //throw new NotConnectedException("SendSerialMessageBlind");
                LogMessage("SharedResources::SendSerialMessageBlind", "NotConnectedException");
            }
        }

        public static void LogMessage(string identifier, string message, params object[] args)
        {
            Context.LogMessage(identifier, message, args);
        }
    }
}
