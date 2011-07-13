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

using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Archived inbox
    /// </summary>
    public partial class ArchivedInbox : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArchivedInbox"/> class.
        /// </summary>
        public ArchivedInbox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ArchivedInbox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ArchivedInbox_Load(object sender, EventArgs e)
        {
            // Exit if is in design mode
            if (this.DesignMode) return;

            // Set up list view
            SetupView();

            // Show messages
            RefreshView();
        }

        /// <summary>
        /// Setups the view.
        /// </summary>
        private void SetupView()
        {
            //lvwMessages.Freeze();
            //vwMessages.BeginUpdate();

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
            IncomingMessage selectedMsg = lvwMessages.SelectedObject as IncomingMessage;
            lvwMessages.BeginUpdate();
            lvwMessages.ClearObjects();
            IOrderedQueryable<IncomingMessage> results = IncomingMessage.All().Where(msg => msg.Status == StringEnum.GetStringValue(MessageStatus.Archived)).OrderByDescending(msg => msg.ReceivedDate);
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
          

        }

        /// <summary>
        /// Handles the DoubleClick event of the lvwMessages control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvwMessages_DoubleClick(object sender, EventArgs e)
        {
            IncomingMessage selectedMessage = (IncomingMessage)lvwMessages.SelectedObject;
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
                DialogResult result = FormHelper.Confirm(Resources.MsgConfirmDeleteMessage);
                if (result == DialogResult.Yes)
                {
                    foreach (IncomingMessage msg in lvwMessages.SelectedObjects)
                    {
                        // Physically delete the message
                        msg.Delete();
                    }
                    // Remove the selected objects
                    this.lvwMessages.RemoveObjects(this.lvwMessages.SelectedObjects);                                       
                    FormHelper.ShowInfo(Resources.MsgMessageDeleted);
                }
                
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

       
    }
}
