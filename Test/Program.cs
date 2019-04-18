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
#define USE_SETUP

using System;

namespace ASCOM
{
    class Program
    {
        static void Main(string[] args)
        {
            // General information
            Console.WriteLine("This program is running in {0}-bit mode", (IntPtr.Size == 4) ? "32" : "64");
            Console.WriteLine();

            DriverAccess.Focuser device;
            //ASCOM.DeviceInterface.IFocuserV3 device = new ASCOM.Ardufocus.Focuser();

            try
            {
                // Select the driver
                device = new DriverAccess.Focuser("ASCOM.Ardufocus.Focuser.1");
            }
            catch(Exception)
            {
                Console.WriteLine("ASCOM.Ardufocus.Focuser driver not found.");
                Console.WriteLine("Press Enter to finish");
                Console.ReadLine();
                return;
            }

            // Basic driver information
            Console.WriteLine("          Name: " + device.Name);
            Console.WriteLine("   Description: " + device.Description);
            Console.WriteLine("   Driver Info: " + device.DriverInfo);
            Console.WriteLine("Driver Version: " + device.DriverVersion);
            Console.WriteLine();

#if USE_SETUP
            // Show the driver setup dialog
            device.SetupDialog();
#endif

            // Connect
            device.Connected = true;

            if(device.Connected)
            {
                // Driver tests 
                Console.WriteLine("         Absolute: " + device.Absolute);
                Console.WriteLine("        Connected: " + device.Connected);
                Console.WriteLine("        Interface: " + device.InterfaceVersion);
                Console.WriteLine("         IsMoving: " + device.IsMoving);
                Console.WriteLine("             Link: " + device.Link);
                Console.WriteLine("     MaxIncrement: " + device.MaxIncrement);
                Console.WriteLine("          MaxStep: " + device.MaxStep);
                Console.WriteLine("         Position: " + device.Position);

                // This one throws an exception
                //Console.WriteLine("         StepSize: " + device.StepSize);

                Console.WriteLine(" SupportedActions: " + device.SupportedActions);
                Console.WriteLine("         TempComp: " + device.TempComp);
                Console.WriteLine("TempCompAvailable: " + device.TempCompAvailable);
                Console.WriteLine("      Temperature: " + device.Temperature);
                Console.WriteLine();

                // Finish
                Console.WriteLine("Press Enter to test movement");
                Console.ReadLine();

                int target = 1234;
                device.Move(target);
                Console.WriteLine("Moving focuser to position {0}", target);

                while (device.IsMoving) {; }
                Console.WriteLine("Focuser stopped moving, current position is {0}", device.Position);

                int home = 0;
                device.Move(home);
                Console.WriteLine("Moving focuser to position {0}", home);

                while (device.IsMoving) {; }
                Console.WriteLine("Focuser stopped moving, current position is {0}", device.Position);

                device.Connected = false;
            }

            // Finish
            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }
    }
}
