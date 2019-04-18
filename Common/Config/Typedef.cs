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
namespace Common.Config
{
    public enum Motor_t
    {
        MOTOR_ONE,
        MOTOR_TWO
    };

    public enum step_t
    {
        NONE,
        FULL,
        ONE_HALF,
        ONE_FOURTH,
        ONE_EIGHTH,
        ONE_SIXTEENTH,
        ONE_THIRTY
    };

    public enum speed_t
    {
        NONE,
        SPEED100,
        SPEED50,
        SPEED25,
        SPEED20,
        SPEED10
    };

    public struct MotorConfig_t
    {
        public int MaxNumberOfSteps;
        public step_t SteppingMode;
        public speed_t SteppingSpeed;
        public bool Enabled;
    };
}
