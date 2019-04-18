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
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ASCOM.Ardufocus
{
    static class Program
    {
        public static readonly string GUID =
                    ((GuidAttribute)(Assembly.GetExecutingAssembly()).GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;

        private static Mutex Mutex;

        [STAThread]
        static void Main()
        {
            Mutex = new Mutex(
                true,
                String.Format("Local\\{0}", GUID),
                out bool IsMutexOwner
            );

            const string Title = Common.Metadata.Name + " Hand Controller";
            const string Text = "Only one instance of this program can be executed.";
                                                                                                                                                     
            if (!IsMutexOwner)
            {
                MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationContext ApplicationContext = new Context();
            Application.Run(ApplicationContext);
            Mutex.ReleaseMutex();
        }
    }
}
