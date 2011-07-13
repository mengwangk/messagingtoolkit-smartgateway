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
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Failed outbox user control
    /// </summary>
    public partial class OutboxFailed : UserControl
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
        /// Initializes a new instance of the <see cref="OutboxFailed"/> class.
        /// </summary>
        public OutboxFailed()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the OutboxFailed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OutboxFailed_Load(object sender, EventArgs e)
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
            // Check by last updated timestamp
            IOrderedQueryable<OutgoingMessage> results = OutgoingMessage.All().Where
                (msg => msg.Status == StringEnum.GetStringValue(MessageStatus.Failed) && msg.LastUpdate > this.lastUpdateTimestamp).OrderByDescending(msg => msg.LastUpdate);
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
        private void CopyMessage(OutgoingMessage from, OutgoingMessage to)
        {
            to.Recipient = from.Recipient;
            to.Status = from.Status;
            to.Originator = from.Originator;
            to.Priority = from.Priority;
            to.MessageType = from.MessageType;
            to.GatewayId = from.GatewayId;
            to.LastUpdate = from.LastUpdate;
            to.Message = from.Message;
            to.ScheduledDate = from.ScheduledDate;
        }

        /// <summary>
        /// Setups the view.
        /// </summary>
        private void SetupView()
        {
            //lvwMessages.Freeze();
            //lvwMessages.BeginUpdate();

            this.olvColTo.AspectGetter = delegate(object x) { return ((OutgoingMessage)x).Recipient; };
            this.olvColStatus.AspectGetter = delegate(object x) { return ((OutgoingMessage)x).Status; };
            this.olvColChannel.AspectGetter = delegate(object x) { return ((OutgoingMessage)x).GatewayId; };
            this.olvColScheduled.AspectGetter = delegate(object x)
            {
                OutgoingMessage message = (OutgoingMessage)x;
                if (message.ScheduledDate.HasValue)
                    return message.ScheduledDate;
                else
                    return Resources.MsgNow;
            };
            this.olvColBody.AspectGetter = delegate(object x) { return ((OutgoingMessage)x).Message; };
            this.olvColLastUpdate.AspectGetter = delegate(object x) { return ((OutgoingMessage)x).LastUpdate; };

            //lvwMessages.EndUpdate();
            //lvwMessages.Unfreeze();

            lblTo.Text = string.Empty;
            lblStatus.Text = string.Empty;
            lblID.Text = string.Empty;
            lblFrom.Text = string.Empty;
            lblPriority.Text = string.Empty;
            lblMessageType.Text = string.Empty;
            lblGatewayID.Text = string.Empty;
            lblLastUpdate.Text = string.Empty; ;
            rtbContent.Text = string.Empty;
            lblScheduled.Text = string.Empty;
            lblURL.Text = string.Empty;
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
            } else 
            {
                OutgoingMessage selectedMsg = lvwMessages.SelectedObject as OutgoingMessage;
                lvwMessages.BeginUpdate();
                lvwMessages.ClearObjects();
                IOrderedQueryable<OutgoingMessage> results = OutgoingMessage.All().Where(msg => msg.Status == StringEnum.GetStringValue(MessageStatus.Failed)).OrderByDescending(msg => msg.LastUpdate);
                List<OutgoingMessage> messages = new List<OutgoingMessage>(results.AsEnumerable());
                lvwMessages.SetObjects(messages);

                if (messages.Count() == 0)
                    lvwMessages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                else
                    lvwMessages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                lvwMessages.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);

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
        /// Handles the SelectedIndexChanged event of the lvwMessages control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvwMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            OutgoingMessage selectedMessage = (OutgoingMessage)lvwMessages.SelectedObject;
            if (selectedMessage != null)
            {
                OutgoingMessageType messageType = (OutgoingMessageType)StringEnum.Parse(typeof(OutgoingMessageType), selectedMessage.MessageType);
                lblTo.Text = selectedMessage.Recipient;
                lblStatus.Text = selectedMessage.Status;
                lblID.Text = selectedMessage.Id;
                lblFrom.Text = selectedMessage.Originator;
                lblPriority.Text = selectedMessage.Priority;
                lblMessageType.Text = selectedMessage.MessageType;
                lblGatewayID.Text = selectedMessage.GatewayId;
                lblLastUpdate.Text = selectedMessage.LastUpdate.ToString();
                rtbContent.Text = selectedMessage.Message;

                if (messageType == OutgoingMessageType.SMS)
                {
                    lblURL.Text = string.Empty;
                }
                else if (messageType == OutgoingMessageType.WAPPush)
                {
                    lblURL.Text = selectedMessage.WapUrl;
                }

                if (selectedMessage.ScheduledDate.HasValue)
                    lblScheduled.Text = selectedMessage.ScheduledDate.ToString();
                else
                    lblScheduled.Text = Resources.MsgNow;
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the lvwMessages control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvwMessages_DoubleClick(object sender, EventArgs e)
        {
            OutgoingMessage selectedMessage = (OutgoingMessage)lvwMessages.SelectedObject;
            frmMessageDetails messageDetails = new frmMessageDetails();
            messageDetails.Message = selectedMessage;
            messageDetails.ShowDialog(this);
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
                foreach (OutgoingMessage message in lvwMessages.SelectedObjects)
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
                method.Invoke(this.ParentForm, new object[] { ViewAction.RefreshArchivedOutbox  });
            }
        }
    }
}
