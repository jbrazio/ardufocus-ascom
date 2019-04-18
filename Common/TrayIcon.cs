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
using System.Windows.Forms;

namespace Common
{
    [ComVisible(false)]
    public class TrayIcon : ApplicationContext
    {
        private NotifyIcon Icon;

        public TrayIcon()
        {
            InitializeContext();
        }

        protected void InitializeContext()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            Icon = new NotifyIcon
            {
                Text = String.Format(System.Globalization.CultureInfo.InvariantCulture,
                    "{0} v{1}.{2}.{3}.{4}", Metadata.Name, version.Major, version.Minor, version.Build, version.Revision),
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = Properties.Resources.favicon,
                Visible = true
            };

            Icon.Click += new EventHandler(delegate (object sender, EventArgs e)
            {
                MouseEventArgs me = (MouseEventArgs)e;

                if (me.Button == MouseButtons.Left)
                    System.Diagnostics.Process.Start(string.Format("{0}\\ASCOM.Ardufocus.GUI.exe", AppDomain.CurrentDomain.BaseDirectory));
            });

            Icon.ContextMenuStrip.Items.Add("Show hand controller", null, (sender, e) => {
                System.Diagnostics.Process.Start(string.Format("{0}\\ASCOM.Ardufocus.GUI.exe", AppDomain.CurrentDomain.BaseDirectory));
            });

            Icon.ContextMenuStrip.Items.Add("Show setup form", null, (sender, e) => {
                System.Diagnostics.Process.Start(string.Format("{0}\\ASCOM.Ardufocus.Setup.exe", AppDomain.CurrentDomain.BaseDirectory));
            });

            Icon.ContextMenuStrip.Items.Add(new ToolStripSeparator());

            /*
            Icon.ContextMenuStrip.Items.Add("Help", null, (sender, e) => {
                MessageBox.Show("Help me !");
            });
            */

            Icon.ContextMenuStrip.Items.Add("About " + Metadata.Name, null, (sender, e) => {
                Forms.About form = new Forms.About(
                    Metadata.Name,
                    string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision),
                    Metadata.DriverDescription
                    );
                form.Show();
            });

            Icon.ContextMenuStrip.Items.Add("Exit", null, (sender, e) => {
                Application.Exit();
            });
        }

        protected override void Dispose(bool Disposing)
        {
            Icon.Dispose();
            Icon = null;
        }
    }
}
 