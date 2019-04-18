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
using System.Runtime.InteropServices;

namespace Common
{
    [ComVisible(false)]
    public static class Metadata
    {
        /// <summary>
        /// ASCOM Device Name for this driver.
        /// </summary>
        public const string Name = "Ardufocus";

        /// <summary>
        /// ASCOM Device Type for this driver.
        /// </summary>
        public const string DeviceType = "Focuser";

        /// <summary>
        /// ASCOM DeviceID (COM ProgID) for this driver.
        /// The DeviceID is used by ASCOM applications to load the driver at runtime.
        /// </summary>
        public const string DriverID = "ASCOM.Ardufocus";

        /// <summary>
        /// Driver description that displays in the ASCOM Chooser.
        /// </summary>-+
        public const string DriverDescription = "ASCOM IFocuserV3 Driver for Ardufocus";

        /// <summary>
        /// Additional information about this driver
        /// </summary>
        public const string DriverInfo = "The most accurate Open Source focus controller";
    }
}
