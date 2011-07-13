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
using System.Reflection;

using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.Core.Helper;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Display inbox messages
    /// </summary>
    public partial class Inbox : UserControl
    {
        /// <summary>
        /// Supported method name
        /// </summary>
        public const string SupportedMethodName = "RefreshMessageView";

        /// <summary>
        /// Default polling interval
        /// </summary>
        private static int DefaultPollingInterval = AppConfigSettings.GetInt(ConfigParameter.DefaultMessagePollingInterval);

        /// <summary>
        /// Last message updated timestamp
        /// </summary>
        private DateTime lastUpdateTimestamp = DateTime.MinValue;

        /// <summary>
        /// Thread to poll for new messages
        /// </summary>
        private System.Threading.Timer messagePoller;
              
        /// <summary>
        /// Callback method to set the messages
        /// </summary>
        private delegate void SetListCallback();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Inbox"/> class.
        /// </summary>
        public Inbox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Inbox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Inbox_Load(object sender, EventArgs e)
        {
            // Exit if is in design mode
            if (this.DesignMode) return;

            // Set up list view
            SetupView();

            // Show messages
            RefreshView();

            // Start message poller
            StartPoller();
        }                 

        /// <summary>
        /// Setups the view.
        /// </summary>
        private void SetupView()
        {
            //lvwMessages.Freeze();

            //lvwMessages.BeginUpdate();

            this.olvColFrom.AspectGetter = delegate(object x) { return ((IncomingMessage)x).Originator; };            
            this.olvColChannel.AspectGetter = delegate(object x) { return ((IncomingMessage)x).GatewayId; };
            this.olvColBody.AspectGetter = delegate(object x) { return ((IncomingMessage)x).Message; };
            this.olvColType.AspectGetter = delegate(object x) { return ((IncomingMessage)x).MessageType; };            
            this.olvColLastUpdate.AspectGetter = delegate(object x) { return ((IncomingMessage)x).LastUpdate; };
            this.olvColReceivedDate.AspectGetter = delegate(object x) { return ((IncomingMessage)x).ReceivedDate; };
                   
            //lvwMessages.EndUpdate();
            //lvwMessages.Unfreeze();

            lblFrom.Text = string.Empty;
            lblReceived.Text = string.Empty;
            lblID.Text = string.Empty;
            lblIndexes.Text = string.Empty;
            lblTimezone.Text = string.Empty;
            lblMessageType.Text = string.Empty;
            lblGatewayID.Text = string.Empty;
            lblLastUpdate.Text = string.Empty;
            rtbContent.Text = string.Empty;

        }

        /// <summary>
        /// Shows the messages.
        /// </summary>
        public void RefreshView()
        {
            if (this.lvwMessages.InvokeRequired)
            {
                SetListCallback callback = new SetListCallback(RefreshView);
                this.Invoke(callback);
            }
            else
            {
                IncomingMessage selectedMsg = lvwMessages.SelectedObject as IncomingMessage;
                lvwMessages.BeginUpdate();
                lvwMessages.ClearObjects();
                IOrderedQueryable<IncomingMessage> results = IncomingMessage.All().Where
                    (msg => string.IsNullOrEmpty(msg.Status) || msg.Status == StringEnum.GetStringValue(MessageStatus.Received)).OrderByDescending(msg => msg.ReceivedDate);

                List<IncomingMessage> messages = new List<IncomingMessage>(results.AsEnumerable());
                lvwMessages.SetObjects(messages);

                if (messages.Count() == 0)
                    lvwMessages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                else
                    lvwMessages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                if (selectedMsg != null)
                {
                    lvwMessages.SelectObject(selectedMsg);
                }
                lvwMessages.EndUpdate();
                lvwMessages.Refresh();                              

                if (messages.Count() > 0)
                {
                    this.lastUpdateTimestamp = messages.OrderByDescending(m => m.LastUpdate).ElementAt(0).LastUpdate;
                }
            }
        }

        /// <summary>
        /// Starts the message poller.
        /// </summary>
        private void StartPoller()
        {
            StopPoller();

            // Check for message every 5 seconds, starting now
            System.Threading.TimerCallback messagePollerDelegate = new System.Threading.TimerCallback(PollMessages);
            messagePoller = new System.Threading.Timer(messagePollerDelegate, null, 0, DefaultPollingInterval);           
        }

        /// <summary>
        /// Stops the poller.
        /// </summary>
        private void StopPoller()
        {
            if (messagePoller != null)
            {
                try
                {                    
                    messagePoller.Dispose();                
                   
                }
                catch (Exception) { }
                messagePoller = null;
            }
        }

        /// <summary>
        /// Polls the message.
        /// </summary>
        /// <param name="obj">The object</param>
        private void PollMessages(object obj)
        {  
            IOrderedQueryable<IncomingMessage> results = IncomingMessage.All().Where
                (msg => (string.IsNullOrEmpty(msg.Status) || msg.Status == StringEnum.GetStringValue(MessageStatus.Received)) && msg.LastUpdate > this.lastUpdateTimestamp).OrderByDescending(msg => msg.ReceivedDate);
            if (results.Count() > 0 && !this.Enabled)
            {
                RefreshView();
            }
        }
       
        /// <summary>
        /// Copies the message.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        private void CopyMessage(IncomingMessage from, IncomingMessage to)
        {
            to.Originator = from.Originator;
            to.ReceivedDate = from.ReceivedDate;
            to.Indexes = from.Indexes;
            to.Timezone = from.Timezone;
            to.MessageType = from.MessageType;
            to.GatewayId = from.GatewayId;
            to.LastUpdate = from.LastUpdate;
            to.Message = from.Message;            
        }


        /// <summary>
        /// Handles the DoubleClick event of the lvwMessages control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvwMessages_DoubleClick(object sender, EventArgs e)
        {
            IncomingMessage selectedMessage = (IncomingMessage) lvwMessages.SelectedObject;
            frmMessageDetails messageDetails = new frmMessageDetails();
            messageDetails.Message = selectedMessage;
            messageDetails.ShowDialog(this);
            
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lvwMessages control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvwMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            IncomingMessage selectedMessage = (IncomingMessage)lvwMessages.SelectedObject;
            if (selectedMessage != null)
            {               
                lblFrom.Text = selectedMessage.Originator;
                lblReceived.Text = selectedMessage.ReceivedDate.ToString();
                lblID.Text = selectedMessage.Id;
                lblIndexes.Text = selectedMessage.Indexes;
                lblTimezone.Text = selectedMessage.Timezone;
                lblMessageType.Text = selectedMessage.MessageType;
                lblGatewayID.Text = selectedMessage.GatewayId;
                lblLastUpdate.Text = selectedMessage.LastUpdate.ToString();
                rtbContent.Text = selectedMessage.Message;
            }
        }

        /// <summary>
        /// Handles the Click event of the tsbDisplayMessageContent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbDisplayMessageContent_Click(object sender, EventArgs e)
        {

            if (tableLayoutPanel1.RowStyles[1].SizeType == SizeType.AutoSize)
            {
                tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[1].Height = 0;
                tableLayoutPanel1.RowStyles[2].Height = 0;
                tsbDisplayMessageContent.Text = Resources.MsgShowMessageDetails;
            }
            else
            {
                tableLayoutPanel1.RowStyles[1].SizeType = SizeType.AutoSize;
                tableLayoutPanel1.RowStyles[2].SizeType = SizeType.AutoSize;
                tsbDisplayMessageContent.Text = Resources.MsgHideMessageDetails;
            }
        }

      
        /// <summary>
        /// Handles the KeyDown event of the lvwMessages control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void lvwMessages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (IncomingMessage message in lvwMessages.SelectedObjects)
                {
                    // Set the message status to "Archived"
                    message.Status = StringEnum.GetStringValue(MessageStatus.Archived);
                    message.Update();
                }
                // Remove the selected objects
                this.lvwMessages.RemoveObjects(this.lvwMessages.SelectedObjects);
                RefreshMessageView();
            }
            else if (e.KeyCode == Keys.F3)
            {
                RefreshView();
            }
        }

        /// <summary>
        /// Handles the Click event of the tsbRefreshMessage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbRefreshMessage_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        /// <summary>
        /// Refreshes the message.
        /// </summary>
        private void RefreshMessageView()
        {
            Type type = this.ParentForm.GetType();
            MethodInfo method = type.GetMethod(SupportedMethodName);
            if (method != null)
            {
                method.Invoke(this.ParentForm, new object[] {  ViewAction.RefreshArchivedInbox  });
            }
        }
    }
}
