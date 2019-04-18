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
using System.Windows.Forms;
using ASCOM.DriverAccess;
using Common.Config;

namespace ASCOM.Ardufocus
{
    class Context : ApplicationContext
    {
        private static Form HandController;
        private static Focuser Focuser1, Focuser2;

        internal static Motor_t ActiveMotor { get; set; }

        public Context()
        {
            HandController = new Forms.ControlForm();
            HandController.Show();
        }

        ~Context()
        {
          
        }

        internal static void TriggerUpdateUIState()
        {
            HandController.Invalidate();
        }

        internal static bool CheckIfConnected()
        {
            try
            {
                if (Driver == null || !Driver.Connected) { return false; }
                else { return true; }
            }
            catch(Exception) { return false; }
        }

        internal static bool CheckIfConnected(Motor_t motor)
        {
            Focuser focuser;
            switch (motor)
            {
                case Motor_t.MOTOR_ONE:
                    focuser = M1;
                    break;

                case Motor_t.MOTOR_TWO:
                    focuser = M2;
                    break;

                default:
                    throw new IndexOutOfRangeException();
            }

            try
            {
                if (focuser == null || !focuser.Connected) { return false; }
                else { return true; }
            }
            catch (Exception) { return false; }
        }


        internal static Focuser Driver
        {
            get
            {
                switch (ActiveMotor)
                {
                    case Motor_t.MOTOR_ONE:
                        return (M1 ?? null);

                    case Motor_t.MOTOR_TWO:
                        return (M2 ?? null);

                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        internal static Focuser M1
        {
            get
            {
                /*
                if (Focuser1 == null)
                {
                    try
                    {
                        Focuser1 = new Focuser(Properties.Settings.Default.DriverOneID);
                        Utility.ConsoleLogMessage("Initialized the ASCOM driver access object.");
                    }
                    catch (Exception)
                    {
                        Utility.ConsoleLogMessage("Failed to init the ASCOM driver access object.");
                    }
                }
                */
                return (Focuser1 ?? null);
            }
            set
            {
                Focuser1 = value;
            }
        }

        internal static Focuser M2
        {
            get
            {
                /*
                if (Focuser2 == null)
                {
                    try
                    {
                        Focuser2 = new Focuser(Properties.Settings.Default.DriverTwoID);
                        Utility.ConsoleLogMessage("Initialized the ASCOM driver access object.");
                    }
                    catch (Exception)
                    {
                        Utility.ConsoleLogMessage("Failed to init the ASCOM driver access object.");
                    }
                }
                */

                return (Focuser2 ?? null);
            }
            set
            {
                Focuser2 = value;
            }
        }
    }
}
