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
using System.Reflection;

using SubSonic.Schema;

using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.Core;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Display message details
    /// </summary>
    public partial class frmMessageDetails : Form
    {
        /// <summary>
        /// Supported method name
        /// </summary>
        public const string SupportedMethodName = "RefreshMessageView";
      
        /// <summary>
        /// Initializes a new instance of the <see cref="frmMessageDetails"/> class.
        /// </summary>
        public frmMessageDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the frmMessageDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmMessageDetails_Load(object sender, EventArgs e)
        {
            if (Message == null)
            {
                FormHelper.ShowError(Resources.MsgNoMessageToDisplay);
                return;
            }

            if (this.Message.GetType() == typeof(IncomingMessage))
            {
                IncomingMessage msg = this.Message as IncomingMessage;
                txtID.Text = msg.Id;
                txtType.Text = msg.MessageType;
                txtLastUpdate.Text = msg.LastUpdate.ToString();
                txtSent.Text = string.Empty;
                txtReceived.Text = msg.ReceivedDate.ToString();
                txtScheduled.Text = string.Empty;
                txtChannel.Text = msg.GatewayId;
                txtReference.Text = msg.Indexes;
                txtStatus.Text = msg.Status;
                txtFrom.Text = msg.Originator;
                txtTo.Text = string.Empty;
                txtFormat.Text = string.Empty;
                txtPriority.Text = string.Empty;
                rtbBody.Text = msg.Message;
                grpSms.Visible = true;
                grpWapPush.Visible = false;

                tsbMessageReply.Enabled = true;

            }
            else if (this.Message.GetType() == typeof(OutgoingMessage))
            {
                OutgoingMessage msg = this.Message as OutgoingMessage;
                txtID.Text = msg.Id;
                txtType.Text = msg.MessageType;
                txtLastUpdate.Text = msg.LastUpdate.ToString();
                txtSent.Text = msg.SentDate.ToString();
                txtReceived.Text = string.Empty;
                if (msg.ScheduledDate.HasValue)
                    txtScheduled.Text = msg.ScheduledDate.ToString();
                else
                    txtScheduled.Text = Resources.MsgNow;
                txtChannel.Text = msg.GatewayId;
                txtReference.Text = msg.RefNo;
                txtStatus.Text = msg.Status;
                txtFrom.Text = msg.Originator;
                txtTo.Text = msg.Recipient;
                txtFormat.Text = msg.MessageFormat;
                txtPriority.Text = msg.Priority;

                OutgoingMessageType messageType = (OutgoingMessageType)StringEnum.Parse(typeof(OutgoingMessageType), msg.MessageType);
                if (messageType == OutgoingMessageType.SMS)
                {
                    rtbBody.Text = msg.Message;
                    grpSms.Visible = true;
                    grpWapPush.Visible = false;
                }
                else if (messageType == OutgoingMessageType.WAPPush)
                {
                    txtWapPushMessage.Text = msg.Message;
                    txtWapPushUrl.Text = msg.WapUrl;
                    txtCreated.Text = msg.WapCreateDate.ToString();
                    txtExpiry.Text = msg.WapExpiryDate.ToString();
                    txtSignal.Text = msg.WapSignal;
                    grpSms.Visible = false;
                    grpWapPush.Visible = true;
                }

                tsbMessageReply.Enabled = false;
            }
            
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public IActiveRecord Message { get; set; }


        /// <summary>
        /// Handles the Click event of the tsbMessageReply control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbMessageReply_Click(object sender, EventArgs e)
        {
            frmNewMessage newMessage = new frmNewMessage();
            newMessage.MessageForm.To = txtFrom.Text;
            newMessage.MessageForm.Message = this.Message;
            newMessage.ShowDialog(this);
        }

        /// <summary>
        /// Handles the Click event of the tsbMessageForward control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbMessageForward_Click(object sender, EventArgs e)
        {
            frmNewMessage newMessage = new frmNewMessage();
            newMessage.MessageForm.Message = this.Message;
            newMessage.ShowDialog(this);
        }

        /// <summary>
        /// Handles the Click event of the tsbMessageDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbMessageDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete the message
                if (this.Message.GetType() == typeof(IncomingMessage))
                {
                    // Delete the message
                    IncomingMessage msg = this.Message as IncomingMessage;
                    if (StringEnum.GetStringValue(MessageStatus.Archived).Equals(msg.Status))
                    {
                        DialogResult result = FormHelper.Confirm(Resources.MsgConfirmDeleteMessage);
                        if (result == DialogResult.Yes)
                        {
                            // Physically delete the message
                            msg.Delete();
                            RefreshMessageView(ViewAction.RefreshArchivedInbox);
                            FormHelper.ShowInfo(Resources.MsgMessageDeleted);
                        }
                    }
                    else
                    {
                        // Set the message status to "Archived"
                        msg.Status = StringEnum.GetStringValue(MessageStatus.Archived);
                        msg.Update();
                        RefreshMessageView(ViewAction.RefreshArchivedInbox);
                        RefreshMessageView(ViewAction.RefreshInbox);
                        FormHelper.ShowInfo(Resources.MsgMessageArchived);
                    }

                }
                else if (this.Message.GetType() == typeof(OutgoingMessage))
                {
                    // Delete the message
                    OutgoingMessage msg = this.Message as OutgoingMessage;
                    if (StringEnum.GetStringValue(MessageStatus.Archived).Equals(msg.Status))
                    {
                        DialogResult result = FormHelper.Confirm(Resources.MsgConfirmDeleteMessage);
                        if (result == DialogResult.Yes)
                        {
                            // Physically delete the message
                            msg.Delete();
                            RefreshMessageView(ViewAction.RefreshArchivedOutbox);
                            FormHelper.ShowInfo(Resources.MsgMessageDeleted);
                        }
                    }
                    else
                    {
                        // Set the message status to "Archived"
                        msg.Status = StringEnum.GetStringValue(MessageStatus.Archived);
                        msg.Update();
                        RefreshMessageView(ViewAction.RefreshArchivedOutbox);
                        RefreshMessageView(ViewAction.RefreshOutbox);
                        FormHelper.ShowInfo(Resources.MsgMessageArchived);
                    }
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Refreshes the message.
        /// </summary>
        private void RefreshMessageView(ViewAction action)
        {
            Type type = this.Owner.GetType();
            MethodInfo method = type.GetMethod(SupportedMethodName);
            if (method != null)
            {
                method.Invoke(this.Owner, new object[] { action });
            }
        }

        /// <summary>
        /// Handles the Click event of the tsbClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
