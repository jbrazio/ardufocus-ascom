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

namespace ASCOM.Ardufocus.Driver.M2
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("a2103f51-1b24-4f54-8c41-948361123ff4")]
    [ServedClassName(Common.Metadata.Name + " (M2)")]
    [ProgId(Common.Metadata.DriverID + ".Focuser.2")]
    public class Focuser : FocuserBase
    {
        /// <summary>
        /// Property to hold the motor ID controller by this driver
        /// </summary>
        public override Motor_t MotorID
        {
            get { return Motor_t.MOTOR_TWO; }
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

        /// <summary>
        /// Protocol command override
        /// </summary>
        protected override string GET_CURRENT_POS { get { return "2GP"; } }
        protected override string GET_MODE { get { return "2GH"; } }
        protected override string GET_SPEED { get { return "2GD"; } }
        protected override string GET_TARGET_POS { get { return "2GN"; } }
        protected override string IS_MOVING { get { return "2GI"; } }
        protected override string SET_CURRENT_POS { get { return "2SP{0:X4}"; } }
        protected override string SET_CURRENT_POS_HIRES { get { return "2SP{0:X8}"; } }
        protected override string SET_MODE_FULL { get { return "2SF"; } }
        protected override string SET_MODE_HALF { get { return "2SH"; } }
        protected override string SET_SPEED { get { return "2SD{0:X2}"; } }
        protected override string SET_TARGET_POS { get { return "2SN{0:X4}"; } }
        protected override string SET_TARGET_POS_HIRES { get { return "2SN{0:X8}"; } }
        protected override string START_MOTION { get { return "2FG"; } }
        protected override string STOP_MOTION { get { return "2FQ"; } }
    }
}
