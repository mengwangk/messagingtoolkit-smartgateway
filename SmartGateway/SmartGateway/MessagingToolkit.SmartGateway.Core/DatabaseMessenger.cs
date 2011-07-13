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
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.ViewModel;
using MessagingToolkit.SmartGateway.Core.Interprocess;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Database messenger control
    /// </summary>
    public partial class DatabaseMessenger : UserControl
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Supported method name
        /// </summary>
        public const string SupportedMethodName = "LinkClicked";
            
        public event NewMessengerEventHandler MessengerAdded;
        public event DeleteMessengerEventHandler MessengerRemoved;
        public event UpdateMessengerEventHandler MessengerUpdated;

        /// <summary>
        /// Service event listener URL
        /// </summary>
        private static string ServiceEventListenerUrl;

        /// <summary>
        /// Default polling interval
        /// </summary>
        private static int PollingInterval;


        /// <summary>
        /// Poller for the messenger
        /// </summary>
        private Thread messengerPoller;


        /// <summary>
        /// Callback method to set the messages
        /// </summary>
        /// <param name="messengers">The messengers.</param>
        private delegate void SetListCallback(List<DbMessenger> messengers);

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseMessenger"/> class.
        /// </summary>
        public DatabaseMessenger()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the DoubleClick event of the olvDbMessenger control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void olvDbMessenger_DoubleClick(object sender, EventArgs e)
        {
            EditMessenger();
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkAddMessenger control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkAddMessenger_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDatabaseMessenger frm = new frmDatabaseMessenger();
            frm.MessengerAdded += new NewMessengerEventHandler(frm_MessengerAdded);
            DialogResult result = frm.ShowDialog();           
        }

        /// <summary>
        /// Handle the messenger added event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        void frm_MessengerAdded(object sender, MessengerEventHandlerArgs e)
        {
            DbMessenger newMessenger = DbMessenger.SingleOrDefault(m => m.Name.ToLower() == e.Name.ToLower());
            this.lvwDbMessenger.AddObject(newMessenger);
            if (MessengerAdded != null)
            {
                // Raise the event
                MessengerEventHandlerArgs arg = new MessengerEventHandlerArgs(e.Name);
                this.MessengerAdded.BeginInvoke(this, arg, new AsyncCallback(this.AsyncCallback), null);
            }
        }

        /// <summary>
        /// Asynchronous callback method
        /// </summary>
        /// <param name="param">Result</param>
        private void AsyncCallback(IAsyncResult param)
        {
            System.Runtime.Remoting.Messaging.AsyncResult result = (System.Runtime.Remoting.Messaging.AsyncResult)param;
            if (result.AsyncDelegate is NewMessengerEventHandler)
            {
                ((NewMessengerEventHandler)result.AsyncDelegate).EndInvoke(result);
            }
            else if (result.AsyncDelegate is DeleteMessengerEventHandler)
            {
                ((DeleteMessengerEventHandler)result.AsyncDelegate).EndInvoke(result);
            }
            else if (result.AsyncDelegate is UpdateMessengerEventHandler)
            {
                ((UpdateMessengerEventHandler)result.AsyncDelegate).EndInvoke(result);
            }
            else
            {
            }
        }
        /// <summary>
        /// Edits the db messenger.
        /// </summary>
        private void EditMessenger()
        {
            object obj = lvwDbMessenger.SelectedObject;
            if (obj != null)
            {
                DbMessenger messenger = obj as DbMessenger;

                frmDatabaseMessenger frm = new frmDatabaseMessenger();
                frm.MessengerUpdated += new UpdateMessengerEventHandler(frm_MessengerUpdated);
                frm.MessengerName = messenger.Name;

                DialogResult result = frm.ShowDialog();
                
            }
        }

        /// <summary>
        /// FRM_s the messenger updated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        void frm_MessengerUpdated(object sender, MessengerEventHandlerArgs e)
        {
            DbMessenger messenger = DbMessenger.SingleOrDefault(m => m.Name.ToLower() == e.Name.ToLower());
            if (MessengerUpdated != null)
            {
                // Raise the event
                MessengerEventHandlerArgs arg = new MessengerEventHandlerArgs(e.Name);
                this.MessengerUpdated.BeginInvoke(this, arg, new AsyncCallback(this.AsyncCallback), null);
            }
        }


        /// <summary>
        /// Shows the messages.
        /// </summary>
        public void RefreshView(List<DbMessenger> messengers)
        {
            if (this.lvwDbMessenger.InvokeRequired)
            {
                SetListCallback callback = new SetListCallback(RefreshView);
                this.Invoke(callback, messengers);
            }
            else
            {
                DbMessenger messenger = lvwDbMessenger.SelectedObject as DbMessenger;
                lvwDbMessenger.BeginUpdate();
                lvwDbMessenger.ClearObjects();
                lvwDbMessenger.SetObjects(messengers);
                if (messenger != null)
                {
                    lvwDbMessenger.SelectObject(messenger);
                }
                lvwDbMessenger.EndUpdate();
                lvwDbMessenger.Refresh();
            }
        }


        /// <summary>
        /// Handles the Load event of the DatabaseMessenger control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DatabaseMessenger_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            ServiceEventListenerUrl = AppConfigSettings.GetString(ConfigParameter.ServiceEventListener, ModuleName.Service);
            PollingInterval = AppConfigSettings.GetInt(ConfigParameter.ChannelPollingInterval);

            SetupView();
            StartPoller();
        }


        /// <summary>
        /// Shows the channels.
        /// </summary>
        private void SetupView()
        {
            lvwDbMessenger.BeginUpdate();
          
            this.olvColName.AspectGetter = delegate(object x) { return ((DbMessenger)x).Name; };
            this.olvColDescription.AspectGetter = delegate(object x) { return ((DbMessenger)x).Description; };
            this.olvColStatus.AspectGetter = delegate(object x) { return ((DbMessenger)x).Status; };

            lvwDbMessenger.SetObjects(DbMessenger.All());           
            lvwDbMessenger.EndUpdate();
            
        }

        private void StartPoller()
        {
            StopPoller();

            // Check for message every 5 seconds, starting now
            messengerPoller = new Thread(new ThreadStart(CheckMessengers));
            messengerPoller.IsBackground = true;
            messengerPoller.Start();
        }

        private void StopPoller()
        {

            if (messengerPoller != null)
            {
                try
                {
                    messengerPoller.Abort();

                }
                catch (Exception) { }
                messengerPoller = null;
            }
        }


        private void CheckMessengers()
        {
            try
            {
                List<DbMessenger> messengers = new List<DbMessenger>();
                while (true)
                {
                    messengers.Clear();
                    foreach (DbMessenger messenger in DbMessenger.All().OrderBy(m=> m.Name))
                    {
                        try
                        {
                            EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.QueryMessengerStatus));
                            action.ActionType = EventAction.Synchronous;
                            action.Values.Add(EventParameter.MessengerName, messenger.Name);
                            EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);
                            
                            if (StringEnum.GetStringValue(EventNotificationResponse.Failed).Equals(response.Status))
                            {
                                messenger.Status = StringEnum.GetStringValue(MessengerStatus.Stopped);
                            }
                            else
                            {
                                messenger.Status = response.Results[EventParameter.MessengerStatus];                            
                            }

                            messengers.Add(messenger);
                        }
                        catch (Exception ex)
                        {
                            log.ErrorFormat("Error checking messenger - [{0}]", messenger.Name);
                            log.Error(ex.Message, ex);
                        }
                    }
                    RefreshView(messengers);
                    Thread.Sleep(PollingInterval);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
           
        }

        private void lnkManageMessenger_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditMessenger();
        }

        private void lnkDeleteMessenger_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DeleteMessenger();
        }

        /// <summary>
        /// Deletes the channel.
        /// </summary>
        private void DeleteMessenger()
        {
            DbMessenger messenger = lvwDbMessenger.SelectedObject as DbMessenger;
            if (messenger != null)
            {
                DialogResult result = FormHelper.Confirm(string.Format(Resources.MsgConfirmDeleteMessenger, messenger.Name));
                if (result == DialogResult.Yes)
                {
                    // Delete the messenger
                    DbMessenger.Delete(m => m.Name.ToLower() == messenger.Name.ToLower());

                    this.lvwDbMessenger.RemoveObjects(this.lvwDbMessenger.SelectedObjects);

                    if (MessengerRemoved != null)
                    {
                        // Raise the event
                        MessengerEventHandlerArgs arg = new MessengerEventHandlerArgs(messenger.Name);
                        this.MessengerRemoved.BeginInvoke(this, arg, new AsyncCallback(this.AsyncCallback), null);
                    }
                }
            }
            else
            {
                FormHelper.ShowInfo(Resources.MsgMessengerMustBeSelected);
            }

        }

        /// <summary>
        /// Handles the Click event of the manageToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditMessenger();
        }

        private void deleteChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMessenger();
        }

        private void startMessengerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DbMessenger messenger = lvwDbMessenger.SelectedObject as DbMessenger;
                if (messenger != null)
                {
                    EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.StartMessenger));
                    action.Values.Add(EventParameter.MessengerName, messenger.Name);
                    EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);
                    messenger.Status = StringEnum.GetStringValue(MessengerStatus.Starting);
                    lvwDbMessenger.RefreshObject(messenger);                  
                }
                else
                {
                    FormHelper.ShowInfo(Resources.MsgNoMessengerSelected);
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        private void stopMessengerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DbMessenger messenger = lvwDbMessenger.SelectedObject as DbMessenger;
                if (messenger != null)
                {
                    EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.StopMessenger));
                    action.Values.Add(EventParameter.MessengerName, messenger.Name);
                    EventResponse response = RemotingHelper.NotifyEvent(ServiceEventListenerUrl, action);
                    messenger.Status = StringEnum.GetStringValue(MessengerStatus.Stopping);
                    lvwDbMessenger.RefreshObject(messenger);
                }
                else
                {
                    FormHelper.ShowInfo(Resources.MsgNoMessengerSelected);
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }
    }
}
