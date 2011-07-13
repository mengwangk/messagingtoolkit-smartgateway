//===============================================================================
// OSML - Open Source Messaging Library
//
//===============================================================================
// Copyright © TWIT88.COM.  All rights reserved.
//
// This file is part of Open Source Messaging Library.
//
// Open Source Messaging Library is free software: you can redistribute it 
// and/or modify it under the terms of the GNU General Public License version 3.
//
// Open Source Messaging Library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this software.  If not, see <http://www.gnu.org/licenses/>.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

using log4net;

namespace MessagingToolkit.SmartGateway.Core.Poller
{
    /// <summary>
    /// Base class for all poller
    /// </summary>
    public abstract class BasePoller: IDisposable
    {
        // Static Logger
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Default polling interval in milliseconds. Default 5 seconds
        /// </summary>
        private const double DefaultPollingInterval = 5000;
 
        // Track whether Dispose has been called.
        private bool disposed = false;


        /// <summary>
        /// System timer
        /// </summary>
        protected Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePoller"/> class.
        /// </summary>
        public BasePoller()
        {
            this.timer = new Timer();
            this.timer.Elapsed += new ElapsedEventHandler(DoWork);
            this.timer.Enabled = false;
            this.timer.Interval = DefaultPollingInterval;            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePoller"/> class.
        /// </summary>
        /// <param name="interval">The interval.</param>
        public BasePoller(double interval)
        {
            this.timer = new Timer();
            this.timer.Elapsed += new ElapsedEventHandler(DoWork);
            this.timer.Enabled = false;
            this.timer.Interval = interval;            
        }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        public double Interval
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Start the timer.
        /// </summary>
        public void StartTimer()
        {
            this.timer.Enabled = true;
        }

        /// <summary>
        /// Stop the timer.
        /// </summary>
        public void StopTimer()
        {
            this.timer.Enabled = false;
        }

        /// <summary>
        /// Does the work.
        /// </summary>
        public abstract void DoWork(object sender, ElapsedEventArgs e);



        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="BasePoller"/> is reclaimed by garbage collection.
        /// </summary>
        ~BasePoller()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // Tell the garbage collector not to call the finalizer
            // since all the cleanup will already be done.
            GC.SuppressFinalize(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (disposed)
                return;

            if (isDisposing)
            {
                // Free any managed resources in this section
                if (timer != null)
                {
                    timer.Stop();
                    timer = null;
                }
            }

            // Free any unmanaged resources in this section
            disposed = true;
        }

    }
}
