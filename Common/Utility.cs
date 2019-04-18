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

using Common.Config;

namespace Common
{
    public static class Utility
    {
        public static speed_t StringToSpeed(string value)
        {
            switch (value)
            {
                case "02":
                    return speed_t.SPEED100;

                case "04":
                    return speed_t.SPEED50;

                case "08":
                    return speed_t.SPEED25;

                case "10":
                    return speed_t.SPEED20;

                case "20":
                    return speed_t.SPEED10;

                default:
                    return speed_t.NONE;
            }
        }

        public static step_t StringToStep(string value)
        {

            switch (value)
            {
                case "00":
                    return step_t.FULL;

                case "FF":
                    return step_t.ONE_HALF;

                default:
                    return step_t.NONE;
            }
        }
    }
}
