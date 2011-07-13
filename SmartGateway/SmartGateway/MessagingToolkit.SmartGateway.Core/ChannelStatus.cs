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
using System.Threading;

using log4net;

using MessagingToolkit.Core;
using MessagingToolkit.Core.Service;
using MessagingToolkit.SmartGateway.Core;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;
using MessagingToolkit.SmartGateway.Core.ViewModel;
using MessagingToolkit.SmartGateway.Core.Interprocess;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Channel status
    /// </summary>
    public partial class ChannelStatus : UserControl
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
        private static int ChannelPollingInterval;


        /// <summary>
        /// Poller for the channels
        /// </summary>
        private Thread channelPoller;

        /// <summary>
        /// Callback method to set the messages
        /// </summary>
        private delegate void SetListCallback(List<ChannelStatusView> channels);


        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelStatus"/> class.
        /// </summary>
        public ChannelStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ChannelStatus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ChannelStatus_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            ServiceEventListenerUrl = AppConfigSettings.GetString(ConfigParameter.ServiceEventListener, ModuleName.Service);
            ChannelPollingInterval = AppConfigSettings.GetInt(ConfigParameter.ChannelPollingInterval);

            SetupView();           
            StartPoller();
        }


        /// <summary>
        /// Setups the view.
        /// </summary>
        private void SetupView()
        {             
            this.olvColChannelName.AspectGetter = delegate(object x) { return ((ChannelStatusView)x).Name; };
            this.olvColPort.AspectGetter = delegate(object x) { return ((ChannelStatusView)x).Port; };
            this.olvColOperator.AspectGetter = delegate(object x) { return ((ChannelStatusView)x).Operator; };
            this.olvColSignalStrength.AspectGetter = delegate(object x) { return ((ChannelStatusView)x).SignalStrength; };
            this.olvColStatus.AspectGetter = delegate(object x) { return ((ChannelStatusView)x).Status; };
        }

        /// <summary>
        /// Refreshes the view.
        /// </summary>
        private void RefreshView()
        {
            List<GatewayConfig> gwList = new List<GatewayConfig>(GatewayConfig.All().OrderBy(gw => gw.Id).AsEnumerable());                       
        }

        /// <summary>
        /// Refreshes the view.
        /// </summary>
        private void RefreshView(List<ChannelStatusView> channels)
        {
            if (this.lvwChannelStatus.InvokeRequired)
            {
                SetListCallback callback = new SetListCallback(RefreshView);
                this.Invoke(callback, channels);
            }
            else
            {
                ChannelStatusView selectedChannel = lvwChannelStatus.SelectedObject as ChannelStatusView;

                lvwChannelStatus.BeginUpdate();
                lvwChannelStatus.ClearObjects();
                lvwChannelStatus.SetObjects(channels);                

                lvwChannelStatus.EndUpdate();
                lvwChannelStatus.Refresh();

                if (selectedChannel != null)
                {
                    lvwChannelStatus.SelectObject(selectedChannel, true);
                }
            }            
        }

        /// <summary>
        /// Starts the poller.
        /// </summary>
        private void StartPoller()
        {
            StopPoller();

            // Check for message every 5 seconds, starting now
            channelPoller = new Thread(new ThreadStart(CheckChannels));
            channelPoller.IsBackground = true;
            channelPoller.Start();
        }

        /// <summary>
        /// Stops the poller.
        /// </summary>
        private void StopPoller()
        {
            if (channelPoller != null)
            {
                try
                {                   
                    channelPoller.Abort();

                }
                catch (Exception) { }
                channelPoller = null;
            }
        }


        /// <summary>
        /// Checks the channels.
        /// </summary>
        private void CheckChannels()
        { 
            try
            {
                List<ChannelStatusView> channels = new List<ChannelStatusView>();
                while (true)
                {
                    channels.Clear();
                    foreach (GatewayConfig gwConfig in GatewayConfig.All().OrderBy(gw => gw.Id))
                    {
                        try
                        {
                            EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.QueryGatewayStatus));
                            action.ActionType = EventAction.Synchronous;
                            action.Values.Add(EventParameter.GatewayId, gwConfig.Id);
                            EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);

                            ChannelStatusView channel = new ChannelStatusView();
                            channel.Name = gwConfig.Id;
                            channel.Port = gwConfig.ComPort;

                            if (StringEnum.GetStringValue(EventNotificationResponse.Failed).Equals(response.Status))
                            {
                                channel.Status = StringEnum.GetStringValue(GatewayStatus.Stopped);
                            }
                            else
                            {
                                channel.Status = response.Results[EventParameter.GatewayStatus];
                                channel.Operator = response.Results[EventParameter.GatewayOperator];
                                channel.SignalStrength = response.Results[EventParameter.GatewaySignalStrength];
                            }

                            channels.Add(channel);
                        }
                        catch (Exception ex)
                        {
                            log.Error(string.Format("Error checking channel - [{0}]", gwConfig.Id));
                            log.Error(ex.Message, ex);
                        }
                    }
                    RefreshView(channels);
                    Thread.Sleep(ChannelPollingInterval);
                }
            }
            catch (Exception ex)
            {               
                log.Error(ex.Message, ex);
            }
           
        }

        /// <summary>
        /// Handles the Click event of the startChannelToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void startChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ChannelStatusView channel = lvwChannelStatus.SelectedObject as ChannelStatusView;
                if (channel != null)
                {
                    EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.StartGateway));
                    action.Values.Add(EventParameter.GatewayId, channel.Name);
                    EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);
                    channel.Status = StringEnum.GetStringValue(GatewayStatus.Starting);
                    lvwChannelStatus.RefreshObject(channel);
                    //lvwChannelStatus.RefreshSelectedObjects();
                    //FormHelper.ShowInfo(Resources.MsgGatewayStarting);
                }
                else
                {
                    FormHelper.ShowInfo(Resources.MsgNoChannelSelected);
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the stopChannelToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void stopChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ChannelStatusView channel = lvwChannelStatus.SelectedObject as ChannelStatusView;
                if (channel != null)
                {
                    EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.StopGateway));
                    action.Values.Add(EventParameter.GatewayId, channel.Name);
                    EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);
                    channel.Status = StringEnum.GetStringValue(GatewayStatus.Stopping);
                    lvwChannelStatus.RefreshObject(channel);                   
                }
                else
                {
                    FormHelper.ShowInfo(Resources.MsgNoChannelSelected);
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the restartChannelToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void restartChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ChannelStatusView channel = lvwChannelStatus.SelectedObject as ChannelStatusView;
                if (channel != null)
                {
                    EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.RestartGateway));
                    action.Values.Add(EventParameter.GatewayId, channel.Name);
                    EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);
                    channel.Status = StringEnum.GetStringValue(GatewayStatus.Restart);
                    lvwChannelStatus.RefreshObject(channel);
                }
                else
                {
                    FormHelper.ShowInfo(Resources.MsgNoChannelSelected);
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        private void lnkStartChannel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            startChannelToolStripMenuItem_Click(null, null);
        }

        private void lnkStopChannel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            stopChannelToolStripMenuItem_Click(null, null);
        }

        private void lnkRestartChannel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            restartChannelToolStripMenuItem_Click(null, null);
        }
    }
}
