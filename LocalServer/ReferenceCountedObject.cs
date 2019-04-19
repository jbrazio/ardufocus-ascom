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

namespace ASCOM.Ardufocus
{
    [ComVisible(true)]
    public class ReferenceCountedObjectBase
    {
        public ReferenceCountedObjectBase()
        {
            // We increment the global count of objects.
            Server.CountObject();
            SharedResources.LogMessage("ReferenceCountedObjectBase", "New object created: {0}", this.GetType().ToString());
        }

        ~ReferenceCountedObjectBase()
        {
            // We decrement the global count of objects.
            Server.UncountObject();
            SharedResources.LogMessage("ReferenceCountedObjectBase", "Object destroyed: {0}", this.GetType().ToString());

            // We then immediately test to see if we the conditions
            // are right to attempt to terminate this server application.
            Server.ExitIf();
        }
    }
}
