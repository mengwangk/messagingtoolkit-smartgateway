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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading;

using log4net;

using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.Core.Web;
using MessagingToolkit.SmartGateway.Core;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;
using MessagingToolkit.SmartGateway.Core.ViewModel;
using MessagingToolkit.SmartGateway.Core.Interprocess;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Web server console
    /// </summary>
    public partial class WebConsole : UserControl
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Service event listener URL
        /// </summary>
        private static string ServiceEventListenerUrl;


        /// <summary>
        /// Default polling interval
        /// </summary>
        private static int PollingInterval;


        /// <summary>
        /// Poller for the status
        /// </summary>
        private Thread statusPoller;

        /// <summary>
        /// Callback method to set the status
        /// </summary>
        private delegate void SetStatusCallback(string status, string url);
     

        /// <summary>
        /// Initializes a new instance of the <see cref="WebConsole"/> class.
        /// </summary>
        public WebConsole()
        {
            InitializeComponent();
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
                // Perform validation
                if (!FormHelper.ValidateNotEmpty(txtPath, Resources.MsgWebServerPathRequired))
                {
                    return;
                }

                if (!FormHelper.ValidateNotEmpty(txtVirtualPath, Resources.MsgWebServerVirtualPathRequired))
                {
                    return;
                }

                if (!FormHelper.ValidateGreaterThanZero(txtPort, Resources.MsgWebServerPortRequired))
                {
                    return;
                }

                // Save the existing setting to database
                AppConfigSettings.Update(ConfigParameter.WebServerAppPath, txtPath.Text);
                AppConfigSettings.Update(ConfigParameter.WebServerVirtualPath, txtVirtualPath.Text);
                AppConfigSettings.Update(ConfigParameter.WebServerPort, txtPort.Text);
                AppConfigSettings.Update(ConfigParameter.WebServerAutoStart, Convert.ToString(chkAutoStart.Checked));
                EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.StartWebServer));
                EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);
                txtStatus.Text = StringEnum.GetStringValue(WebServerStatus.Starting);
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
                EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.StopWebServer));
                EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);
                txtStatus.Text = StringEnum.GetStringValue(WebServerStatus.Stopping);
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Load event of the WebConsole control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WebConsole_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            InitializeForm();
        }



        /// <summary>
        /// Initializes the form.
        /// </summary>
        private void InitializeForm()
        {
            txtPath.Text = AppConfigSettings.GetString(ConfigParameter.WebServerAppPath);
            txtVirtualPath.Text = AppConfigSettings.GetString(ConfigParameter.WebServerVirtualPath);
            txtPort.Text = AppConfigSettings.GetString(ConfigParameter.WebServerPort);
            chkAutoStart.Checked  =  Convert.ToBoolean(AppConfigSettings.GetString(ConfigParameter.WebServerAutoStart));

            if (string.IsNullOrEmpty(txtPath.Text))
            {
                txtPath.Text = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Portal");
            }

            btnStart.Focus();

            ServiceEventListenerUrl = AppConfigSettings.GetString(ConfigParameter.ServiceEventListener, ModuleName.Service);
            PollingInterval = AppConfigSettings.GetInt(ConfigParameter.ChannelPollingInterval);
           
            StartPoller();
        }


        /// <summary>
        /// Starts the poller.
        /// </summary>
        private void StartPoller()
        {
            StopPoller();

            statusPoller = new Thread(new ThreadStart(CheckWebServerStatus));
            statusPoller.IsBackground = true;
            statusPoller.Start();
        }


        /// <summary>
        /// Stops the poller.
        /// </summary>
        private void StopPoller()
        {
            if (statusPoller != null)
            {
                try
                {
                    statusPoller.Abort();

                }
                catch (Exception) { }
                statusPoller = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnBrowse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.SelectedPath =  Assembly.GetExecutingAssembly().Location;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// Checks the web server status.
        /// </summary>
        private void CheckWebServerStatus()
        {
            try
            {               
                while (true)
                {
                    EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.QueryWebServerStatus));
                    action.ActionType = EventAction.Synchronous;
                    EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);
                    if (StringEnum.GetStringValue(EventNotificationResponse.OK).Equals(response.Status))
                    {
                        string status = response.Results[EventParameter.WebServerStatus];
                        string url = response.Results[EventParameter.WebServerUrl];
                        RefreshView(status, url);
                    }
                    Thread.Sleep(PollingInterval);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Refreshes the view.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="url">The URL.</param>
        private void RefreshView(string status, string url)
        {
            if (txtStatus.InvokeRequired)
            {
                SetStatusCallback callback = new SetStatusCallback(RefreshView);
                this.Invoke(callback, status, url);
            }
            else
            {
                txtStatus.Text = status;
                lnkURL.Text = url;
            }            
        }

        /// <summary>
        /// Handles the Click event of the lnkURL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lnkURL_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(lnkURL.Text);
        }
    }
}
