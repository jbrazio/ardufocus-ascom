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
using Common.Config.Storage;

namespace Common.Config
{
    [ComVisible(false)]
    public class Profile
    {
        public MotorConfig_t M1, M2;

        public string ComPortName { get; set; }
        public bool HighResolution { get; set; }
        public bool ASCOMTraceLogEnable { get; set; }
        public IConfigStorage ConfigStorage { get; private set; }

        public IConfigStorage StorageDriver
        {
            get
            {
                return ConfigStorage;
            }
            set
            {
                ConfigStorage = value;
                ConfigStorage.Open();
            }
        }

        public void Load()
        {
            ComPortName = ConfigStorage.ReadStringFromProfile("ComPortName", "COM1");
            ASCOMTraceLogEnable = ConfigStorage.ReadBoolFromProfile("ASCOMTraceLogEnable", false);
            HighResolution = ConfigStorage.ReadBoolFromProfile("HighResolution", false);

            Enum.TryParse(ConfigStorage.ReadStringFromProfile("SteppingMode", "M1", "FULL"), out M1.SteppingMode);
            Enum.TryParse(ConfigStorage.ReadStringFromProfile("SteppingSpeed", "M1", "SPEED100"), out M1.SteppingSpeed);
            M1.MaxNumberOfSteps = ConfigStorage.ReadIntFromProfile("MaxNumberOfSteps", "M1", 65535);
            M1.Enabled = ConfigStorage.ReadBoolFromProfile("Enabled", "M1", false);

            Enum.TryParse(ConfigStorage.ReadStringFromProfile("SteppingMode", "M2", "FULL"), out M2.SteppingMode);
            Enum.TryParse(ConfigStorage.ReadStringFromProfile("SteppingSpeed", "M2", "SPEED100"), out M2.SteppingSpeed);
            M2.MaxNumberOfSteps = ConfigStorage.ReadIntFromProfile("MaxNumberOfSteps", "M2", 65535);
            M2.Enabled = ConfigStorage.ReadBoolFromProfile("Enabled", "M2", false);
        }

        public void Save()
        {
            ConfigStorage.WriteStringToProfile("ComPortName", ComPortName);
            ConfigStorage.WriteStringToProfile("ASCOMTraceLogEnable", ASCOMTraceLogEnable.ToString());
            ConfigStorage.WriteStringToProfile("HighResolution", HighResolution.ToString());

            ConfigStorage.WriteStringToProfile("SteppingMode", M1.SteppingMode.ToString(), "M1");
            ConfigStorage.WriteStringToProfile("SteppingSpeed", M1.SteppingSpeed.ToString(), "M1");
            ConfigStorage.WriteStringToProfile("MaxNumberOfSteps", M1.MaxNumberOfSteps.ToString(), "M1");
            ConfigStorage.WriteStringToProfile("Enabled", M1.Enabled.ToString(), "M1");

            ConfigStorage.WriteStringToProfile("SteppingMode", M2.SteppingMode.ToString(), "M2");
            ConfigStorage.WriteStringToProfile("SteppingSpeed", M2.SteppingSpeed.ToString(), "M2");
            ConfigStorage.WriteStringToProfile("MaxNumberOfSteps", M2.MaxNumberOfSteps.ToString(), "M2");
            ConfigStorage.WriteStringToProfile("Enabled", M2.Enabled.ToString(), "M2");
        }
    }
}
