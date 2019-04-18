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
using System.Runtime.InteropServices;
using Common.Config;

namespace ASCOM.Ardufocus.Driver.M1
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("61b31228-9461-42be-b84b-17755d376522")]
    [ServedClassName(Common.Metadata.Name + " (M1)")]
    [ProgId(Common.Metadata.DriverID + ".Focuser.1")]
    public class Focuser : FocuserBase
    {
        /// <summary>
        /// Property to hold the motor ID controller by this driver
        /// </summary>
        public override Motor_t MotorID
        {
            get { return Motor_t.MOTOR_ONE; }
        }

        /// <summary>
        /// Property to hold an driver state
        /// </summary>
        public override bool ConnectionState { get; set; }

        /// <summary>
        /// Local cache of last valid readings
        /// </summary>
        public override Int32 LastPosition { get; set; }
        public override double LastTemperature { get; set; }
    }
}
