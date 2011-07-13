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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Management;
using System.Timers;

using log4net;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Service control panel
    /// </summary>
    public partial class frmServiceControl : Form
    {
        // Static logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Service controller
        /// </summary>
        private ServiceController serviceController;

        /// <summary>
        /// System timer
        /// </summary>
        private System.Timers.Timer timer;

        public frmServiceControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Load event of the frmServiceControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmServiceControl_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            txtService.Text = ServiceParameter.WindowsServiceName;
            txtServer.Text = Environment.MachineName;

            try
            {
                this.serviceController = new ServiceController(ServiceParameter.WindowsServiceName, Environment.MachineName);
                txtStatus.Text = this.serviceController.Status.ToString();
                              
               
                // Get the service logon as and password
                /*
                string objPath = string.Format("Win32_Service.Name='{0}'", ServiceParameter.WindowsServiceName);
                using (ManagementObject service = new ManagementObject(new ManagementPath(objPath)))
                {
                    foreach (PropertyData p in service.Properties)
                    {
                        Console.WriteLine(p.Name);
                        
                    }
                }
                */

                StartTimer();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }


        /// <summary>
        /// Starts the timer.
        /// </summary>
        private void StartTimer()
        {
            try
            {
                this.timer = new System.Timers.Timer();
                this.timer.Elapsed += new ElapsedEventHandler(CheckServiceStatus);
                this.timer.Enabled = true;
                this.timer.Interval = 3000;                
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// Handles the Click event of the btnStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Get latest status
                this.serviceController.Refresh();
                if (this.serviceController.Status == ServiceControllerStatus.Running)
                {
                    /*
                    txtStatus.Text = Resources.ServiceAttemptStop;
                    txtStatus.Refresh();

                    this.serviceController.Stop();
                    
                    // Wait for 1 minute for the service to stop
                    this.serviceController.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 1, 0));
                    */

                    FormHelper.ShowInfo(Resources.ServiceAlreadyStarted);
                    return;
                }

                txtStatus.Text = Resources.ServiceAttempStart;
                txtStatus.Refresh();

                this.serviceController.Start();

                // Wait for 1 minute for the service to start
                //this.serviceController.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 1, 0));
                //txtStatus.Text = this.serviceController.Status.ToString();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnStop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                // Get latest status
                this.serviceController.Refresh();
                if (this.serviceController.Status == ServiceControllerStatus.Stopped)
                {
                    txtStatus.Text = this.serviceController.Status.ToString();                  
                    FormHelper.ShowInfo(Resources.ServiceAlreadyStopped);
                    return;
                }

                txtStatus.Text = Resources.ServiceAttemptStop;
                txtStatus.Refresh();
                
                this.serviceController.Stop();

                // Wait for 1 minute for the service to stop
                //this.serviceController.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 1, 0));
                //txtStatus.Text = this.serviceController.Status.ToString();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }


        /// <summary>
        /// Checks the service status.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void CheckServiceStatus(object sender, ElapsedEventArgs e)
        {
            this.serviceController.Refresh();
            txtStatus.Text = this.serviceController.Status.ToString();   
        }

        /// <summary>
        /// Handles the FormClosing event of the frmServiceControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void frmServiceControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Free any managed resources in this section
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
        }
    }
}
