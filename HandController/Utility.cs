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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System;

namespace ASCOM.Ardufocus
{
    class Utility
    {
        public static void ConsoleLogMessage(string message, params object[] args)
        {
#if DEBUG
            if(args.Length > 0)
                Console.WriteLine("[GUI] {0}", string.Format(message, args));
            else
                Console.WriteLine("[GUI] {0}", message);
#endif
        }

        public static IEnumerable<Control> GetControlHierarchy(Control root)
        {
            var queue = new Queue<Control>();

            queue.Enqueue(root);

            do
            {
                var control = queue.Dequeue();

                yield return control;

                foreach (var child in control.Controls.OfType<Control>())
                    queue.Enqueue(child);

            } while (queue.Count > 0);

        }
    }
}
