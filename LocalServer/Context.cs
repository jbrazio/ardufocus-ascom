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
using Common;
using System;
using System.Collections.Generic;
 
using ASCOM.Utilities;

namespace ASCOM.Ardufocus
{
    class Context : TrayIcon
    {
        internal static List<string> Buffer = new List<string>();
        internal static Common.Config.Profile config;

        private static readonly object lockObject = new object();
        private static Forms.DebugForm Form = null;
        private static TraceLogger ASCOMTrace;

        internal static List<string> LogBuffer
        {
            get
            {
                lock (lockObject)
                {
                    return Buffer;
                }
            }
        }

        public Context()
        {
            if (config == null)
            {
                config = new Common.Config.Profile
                {
                    StorageDriver = new Common.Config.Storage.WindowsRegistry()
                    {
                        ProfileName = Common.Metadata.Name
                    }
                };
                config.Load();
            }

            if (ASCOMTrace == null)
            {
                ASCOMTrace = new TraceLogger(String.Empty, Common.Metadata.Name)
                {
                    Enabled = config.ASCOMTraceLogEnable
                };
            }

            if (! Server.StartedByCOM)
            {
                if (Form == null)
                {
                    Form = new Forms.DebugForm();
                    Form.Show();
                }

                LogMessage("Context::Context", "LocalServer not started by COM");
            }

            LogMessage("Context::Context", "LocalServer ready");
        }

        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                if (Form != null)
                {
                    Form.Dispose();
                    Form = null;
                }

                if (ASCOMTrace != null)
                {
                    ASCOMTrace.Dispose();
                    ASCOMTrace = null;
                }
            }
            base.Dispose(Disposing);
        }

        internal static void UpdateUI()
        {
            if (Form != null) { Form.Invalidate(); }
            config.Load();
        }

        internal static void LogMessage(string identifier, string message, params object[] args)
        {
            lock (lockObject)
            {
                var msg = string.Format(message, args);

                if (Buffer.Count > 0)
                {
                    // Do not log repeated lines
                    if (Buffer[0] == msg) { return; }

                    if(Buffer.Count > 1023)
                    {
                        Buffer.RemoveAt(Buffer.Count -1);
                    }
                }

                Buffer.Insert(0, string.Format("[{0}] {1}", identifier, msg));

                if (ASCOMTrace != null) { ASCOMTrace.LogMessage(identifier, msg); }
                if (Form != null) { UpdateUI(); }
            }
        }
    }
}
