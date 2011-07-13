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
using System.Transactions;
using System.Reflection;

using SubSonic.DataProviders;
using SubSonic.Schema;

using MessagingToolkit.Core;
using MessagingToolkit.Core.Helper;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;


namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Create message user control
    /// </summary>
    public partial class NewMessage : UserControl
    {
        /// <summary>
        /// Supported method name
        /// </summary>
        public const string SupportedMethodName = "RefreshMessageView";
      
        /// <summary>
        /// Initializes a new instance of the <see cref="NewMessage"/> class.
        /// </summary>
        public NewMessage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the NewMessage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void NewMessage_Load(object sender, EventArgs e)
        {
            // Return in control design mode
            if (this.DesignMode) return;

            CheckForIllegalCrossThreadCalls = false;

            // Set up the message settings
            SetupMessageSettings();
        }

       
        /// <summary>
        /// Setups the message settings.
        /// </summary>
        public void SetupMessageSettings()
        {   
            // First option is any channels
            if (cboChannel.Items.Count > 0)
                cboChannel.Items.Clear();
            cboChannel.Items.Add(Resources.AnyChannels);

            // Load all channels
            foreach (GatewayConfig g in GatewayConfig.All().OrderBy(gw => gw.Id))
            {
                cboChannel.Items.Add(string.Join(GuiHelper.FieldSplitter, new string[]{g.Id, g.ComPort}));
            }
            cboChannel.SelectedIndex = 0;

            // Load message format
            cboMessageFormat.Items.Clear();
            StringEnum e = new StringEnum(typeof(MessageFormat));    
            foreach (string s in e.GetStringValues())
            {
                cboMessageFormat.Items.Add(s);
            }
            cboMessageFormat.SelectedIndex = 0;

            // Load message status report
            cboStatusReport.Items.Clear();
            e = new StringEnum(typeof(MessageStatusReport));
            foreach (string s in e.GetStringValues())
            {
                cboStatusReport.Items.Add(s);
            }
            cboStatusReport.SelectedIndex = 0;
   
            // Load message type
            cboMessageType.Items.Clear();
            e = new StringEnum(typeof(OutgoingMessageType));
            foreach (string s in e.GetStringValues())
            {
                cboMessageType.Items.Add(s);
            }
            cboMessageType.SelectedIndex = 0;

            // Load priority
            cboPriority.Items.Clear();
            cboPriority.Items.AddRange(EnumMatcher.MessagePriority.Keys.ToArray());
            cboPriority.SelectedIndex = 1;

            cboMessageClass.Items.Clear();
            cboMessageClass.Items.AddRange(EnumMatcher.MessageClass.Keys.ToArray());
            cboMessageClass.SelectedIndex = 0;

            npdQuantity.Value = 1;
            dtpScheduleTime.Value = DateTime.Now;
            //txtMessageContent.Text = string.Empty;

            // WAP push signal
            cboWapPushSignal.Items.Clear();
            cboWapPushSignal.Items.AddRange(EnumMatcher.ServiceIndication.Keys.ToArray());
            cboWapPushSignal.SelectedIndex = 0;

            if (this.Message != null)
            {
                PresetMessageDetails(this.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCreate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (SaveChanges())
            {
                ResetMessageSettings();
            }
        }


        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        private bool SaveChanges()
        {
            OutgoingMessageType messageType =(OutgoingMessageType)StringEnum.Parse(typeof(OutgoingMessageType), cboMessageType.Text);
          
            // Validate recipients are not empty
            if (!FormHelper.ValidateNotEmpty(txtTo, Resources.MsgRecipientsRequired))
            {
                return false;
            }

            if (messageType == OutgoingMessageType.SMS) 
            {
                // Validate message is not empty
                if (!FormHelper.ValidateNotEmpty(txtMessageContent, Resources.MsgContentRequired))
                {
                    return false;
                }
            } 
            else if (messageType == OutgoingMessageType.WAPPush)
            {
                 // Validate URL
                if (!FormHelper.ValidateNotEmpty(txtWapPushUrl, Resources.MsgURLRequired))
                {
                    return false;
                }

                // Validate message is not empty
                if (!FormHelper.ValidateNotEmpty(txtWapPushMessage, Resources.MsgContentRequired))
                {
                    return false;
                }
            }


            // The To list can be separated by comma or semicolon
            string[] toList = txtTo.Text.Split(GuiHelper.SupportedSeparators, StringSplitOptions.RemoveEmptyEntries);                                   
            try
            {  
                string groupId = GatewayHelper.GenerateUniqueIdentifier();  
                using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                {                    
                    using (TransactionScope ts = new TransactionScope())
                    {
                        try
                        {
                            foreach (string to in toList)
                            {
                                OutgoingMessage message = new OutgoingMessage();
                                message.Id = GatewayHelper.GenerateUniqueIdentifier();
                                message.GatewayId = cboChannel.Text;
                                message.Recipient = to.Trim();
                                message.Originator = txtFrom.Text;
                                message.MessageType = cboMessageType.Text;                                
                                message.MessageFormat = cboMessageFormat.Text;
                                message.LastUpdate = DateTime.Now;
                                message.CreateDate = message.LastUpdate;
                                message.SrcPort = Convert.ToInt32(npdSourcePort.Value);
                                message.DestPort = Convert.ToInt32(npdDestinationPort.Value);
                                message.Status = StringEnum.GetStringValue(MessageStatus.Pending);
                                message.MessageClass = cboMessageClass.Text;
                                message.Priority = cboPriority.Text;
                                message.StatusReport = cboStatusReport.Text;
                                message.Quantity = Convert.ToInt32(npdQuantity.Value);
                                message.GroupId = groupId;
                                if (chkScheduleSendTime.Checked)
                                    message.ScheduledDate = dtpScheduleTime.Value;

                                if (messageType == OutgoingMessageType.SMS)
                                {
                                    message.Message = txtMessageContent.Text;
                                }
                                else if (messageType == OutgoingMessageType.WAPPush)
                                {
                                    message.WapUrl = txtWapPushUrl.Text;
                                    message.WapSignal = cboWapPushSignal.Text;
                                    message.Message = txtWapPushMessage.Text;
                                    if (chkWapPushCreated.Checked)
                                        message.WapCreateDate = dtpWapPushCreated.Value;
                                    if (chkWapPushExpiry.Checked)                                    
                                        message.WapExpiryDate = dtpWapPushExpiryDate.Value;
                                    
                                }

                                message.Save();
                            }
                        }
                        finally
                        {
                            try
                            {
                                ts.Complete();
                            }
                            catch (Exception) { }   
                            
                            // Refresh the message view
                            RefreshMessageView(ViewAction.RefreshOutbox);
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
                return false;
            }

            // Show successful save message
            if (toList.Count() == 1)
            {
                FormHelper.ShowInfo(Resources.MsgSingleMessageCreated);
            }
            else
            {
                FormHelper.ShowInfo(string.Format(Resources.MsgMultipleMessagesCreated, toList.Count()));
            }

            return true;
        }

        /// <summary>
        /// Resets the message settings.
        /// </summary>
        private void ResetMessageSettings()
        {
            cboChannel.SelectedIndex = 0;
            cboMessageFormat.SelectedIndex = 0;
            cboStatusReport.SelectedIndex = 0;
            cboMessageType.SelectedIndex = 0;
            cboPriority.SelectedIndex = 1;           
            cboMessageClass.SelectedIndex = 0;
            npdQuantity.Value = 1;
            dtpScheduleTime.Value = DateTime.Now;
            txtMessageContent.Text = string.Empty;
            txtTo.Text = string.Empty;            
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (FormHelper.Confirm(Resources.MsgConfirmResetMessageSettings) == DialogResult.Yes)
            {
                ResetMessageSettings();
            }
        }


        /// <summary>
        /// Handles the CheckedChanged event of the chkScheduleSendTime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkScheduleSendTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpScheduleTime.Enabled = chkScheduleSendTime.Checked;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboChannel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedChannel = cboChannel.Text;
            string[] values = selectedChannel.Split(new string[] { GuiHelper.FieldSplitter }, StringSplitOptions.RemoveEmptyEntries);
            selectedChannel = string.Empty;
            for (int i = 0; i < values.Length - 1; i++)
            {
                selectedChannel += values[i];
            }

            GatewayConfig gw = GatewayConfig.SingleOrDefault(g => g.Id == selectedChannel);
            if (gw != null)
                txtFrom.Text = gw.OwnNumber;            
        }

        /// <summary>
        /// Gets or sets recipient addresses.
        /// </summary>
        /// <value>To.</value>
        public string To
        {
            get
            {
                return txtTo.Text;
            }
            set
            {
                txtTo.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string MessageContent
        {
            get
            {
                return txtMessageContent.Text;
            }
            set
            {
                txtMessageContent.Text = value;
            }
        }

        /// <summary>
        /// Presets the message details.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        private void PresetMessageDetails(IActiveRecord rec)
        {
            if (rec.GetType() == typeof(IncomingMessage))
            {
                IncomingMessage msg = rec as IncomingMessage;
                txtMessageContent.Text = msg.Message;
                pnlMessage.Visible = true;
                pnlWapPush.Visible = false;
            }
            else if (rec.GetType() == typeof(OutgoingMessage))
            {
                 OutgoingMessage msg = rec as OutgoingMessage;
                 OutgoingMessageType messageType = (OutgoingMessageType)StringEnum.Parse(typeof(OutgoingMessageType), msg.MessageType);
                 if (messageType == OutgoingMessageType.SMS)
                 {
                     txtMessageContent.Text = msg.Message;
                     pnlMessage.Visible = true;
                     pnlWapPush.Visible = false;
                 }
                 else if (messageType == OutgoingMessageType.WAPPush)
                 {
                     cboMessageType.Text = msg.MessageType;
                     txtWapPushMessage.Text = msg.Message;
                     txtWapPushUrl.Text = msg.WapUrl;
                     cboWapPushSignal.Text = msg.WapSignal;

                     if (msg.WapCreateDate.HasValue)
                     {
                         chkWapPushCreated.Checked = true;
                         dtpWapPushCreated.Value = msg.WapCreateDate.Value;
                     }

                     if (msg.WapExpiryDate.HasValue)
                     {
                         chkWapPushExpiry.Checked = true;
                         dtpWapPushExpiryDate.Value = msg.WapExpiryDate.Value;
                     }

                     pnlMessage.Visible = false;
                     pnlWapPush.Visible = true;
                 }
            }
        }

        /// <summary>
        /// Refreshes the message.
        /// </summary>
        private void RefreshMessageView(ViewAction action)
        {
            Type type = this.ParentForm.GetType();
            MethodInfo method = type.GetMethod(SupportedMethodName);
            if (method != null)
            {              
                method.Invoke(this.ParentForm, new object[] {  action  });
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboMessageType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OutgoingMessageType messageType =(OutgoingMessageType)StringEnum.Parse(typeof(OutgoingMessageType), cboMessageType.Text);
            if (messageType == OutgoingMessageType.SMS)
            {
                pnlMessage.Visible = true;
                pnlWapPush.Visible = false;
            }
            else if (messageType == OutgoingMessageType.WAPPush)
            {
                pnlMessage.Visible = false;
                pnlWapPush.Visible = true;
            }

        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkWapPushCreated control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkWapPushCreated_CheckedChanged(object sender, EventArgs e)
        {
            dtpWapPushCreated.Enabled = chkWapPushCreated.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkWapPushExpiry control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkWapPushExpiry_CheckedChanged(object sender, EventArgs e)
        {
            dtpWapPushExpiryDate.Enabled = chkWapPushExpiry.Checked;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public IActiveRecord Message { get; set; }

        /// <summary>
        /// Handles the Click event of the btnBrowseTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnBrowseTo_Click(object sender, EventArgs e)
        {
            frmContactSearch contactSearchForm = new frmContactSearch();
            if (contactSearchForm.ShowDialog(this) == DialogResult.OK)
            {
                string contactList = string.Empty;
                foreach (User user in contactSearchForm.SelectedUsers)
                {
                    if (string.IsNullOrEmpty(contactList))
                        contactList = user.Mobtel;
                    else
                        contactList = contactList + GuiHelper.SupportedSeparators[0] + user.Mobtel;
                }

                if (!string.IsNullOrEmpty(contactList))
                {
                    if (!string.IsNullOrEmpty(txtTo.Text))
                    {
                        txtTo.Text += GuiHelper.SupportedSeparators[0];
                    }
                    txtTo.Text += contactList;
                }
            }
        }

    }
}
