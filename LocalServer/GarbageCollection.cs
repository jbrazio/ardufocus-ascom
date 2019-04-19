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
using System.Threading;

namespace ASCOM.Ardufocus
{
    /// <summary>
    /// Summary description for GarbageCollection.
    /// </summary>
    class GarbageCollection : IDisposable
    {
        protected bool m_bContinueThread;
        protected bool m_GCWatchStopped;
        protected int m_iInterval;
        protected ManualResetEvent m_EventThreadEnded;

        public GarbageCollection(int iInterval)
        {
            m_bContinueThread = true;
            m_GCWatchStopped = false;
            m_iInterval = iInterval;
            m_EventThreadEnded = new ManualResetEvent(false);
        }

        public void GCWatch()
        {
            // Pause for a moment to provide a delay to make threads more apparent.
            while (ContinueThread())
            {
                GC.Collect();
                Thread.Sleep(m_iInterval);
            }
            m_EventThreadEnded.Set();
        }

        protected bool ContinueThread()
        {
            lock (this)
            {
                return m_bContinueThread;
            }
        }

        public void StopThread()
        {
            lock (this)
            {
                m_bContinueThread = false;
            }
        }

        public void WaitForThreadToStop()
        {
            m_EventThreadEnded.WaitOne();
            m_EventThreadEnded.Reset();
        }

        public void Dispose()
        {
            if (m_EventThreadEnded != null)
            {
                m_EventThreadEnded.Dispose();
                m_EventThreadEnded = null;
            }
        }
    }
}
