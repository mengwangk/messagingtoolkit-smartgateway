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
using System.IO.Ports;
using System.Reflection;

using MessagingToolkit.Core;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Core.Log;
using MessagingToolkit.Core.Mobile.Message;
using MessagingToolkit.Core.Mobile.Event;

using MessagingToolkit.Pdu;
using MessagingToolkit.Pdu.Ie;
using MessagingToolkit.Pdu.WapPush;

using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Gateway configuration form
    /// </summary>
    public partial class frmGateway : Form
    {

        #region Event
        
        /// <summary>
        /// Occurs when a new gateway added.
        /// </summary>
        public event NewGatewayEventHandler GatewayAdded;

        /// <summary>
        /// Occurs when a gateway is updated.
        /// </summary>
        public event UpdateGatewayEventHandler GatewayUpdated;
                
        #endregion

        #region Constants

        /// <summary>
        /// Default command time out in milliseconds
        /// </summary>
        private const int DefaultTimeout = 30000;

        /// <summary>
        /// Default read interval time out in milliseconds
        /// </summary>
        private const int DefaultReadIntervalTimeout = 150;

        /// <summary>
        /// Default command delay in milliseconds
        /// </summary>
        private const int DefaultCommandDelay = 150;

        /// <summary>
        /// Default send retry
        /// </summary>
        private const int DefaultSendRetry = 3;

        /// <summary>
        /// Default send delay in milliseconds
        /// </summary>
        private const int DefaultSendDelay = 1000;


        /// <summary>
        /// Default signal refresh interval in milliseconds
        /// </summary>
        private const int DefaultSignalRefreshInterval = 120;

        /// <summary>
        /// Default days to archive message log
        /// </summary>
        private const int DefaultArchivedMessageLogInterval = 7;

        /// <summary>
        /// Default days to archive messages
        /// </summary>
        private const int DefaultArchivedMessageInterval = 7;

        /// <summary>
        /// Default days to delete archived messages
        /// </summary>
        private const int DefaultDeleteArchivedMessageInterval = 90;

        #endregion


        #region  Private variables

      
        // Variable to indicate if any controls change
        private bool isFormChanged;

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="frmGateway"/> class.
        /// </summary>
        public frmGateway()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the frmGateway control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmGateway_Load(object sender, EventArgs e)
        {         

            // General settings
            SetupGeneralSettings();

            // Communication settings
            SetupCommSettings();

            // Message settings
            SetupMessageSettings();

            // Other settings
            SetupOtherSettings();

            // Message log settings
            SetupMessageLogSettings();

            // Set change handler
            SetFormStateChangeHandlers(this);

            // Display gateway
            DisplayGateway();
           
        }

        /// <summary>
        /// Displays the gateway.
        /// </summary>
        private void DisplayGateway()
        {
            if (!string.IsNullOrEmpty(this.GatewayId))
            {
                // Retrieve and display the gateway configuration
                GatewayConfig gatewayConfig = GatewayConfig.SingleOrDefault(g => g.Id == this.GatewayId);
                if (gatewayConfig != null)
                {
                    // Display the gateway information
                    txtName.Text = gatewayConfig.Id;
                    txtPhoneNo.Text = gatewayConfig.OwnNumber;
                    chkConnectAtStartup.Checked = gatewayConfig.AutoConnect.Value;
                    GatewayFunction functions = (GatewayFunction)Enum.Parse(typeof(GatewayFunction), gatewayConfig.Functions.ToString());
                    if ((functions & GatewayFunction.SendMessage) == GatewayFunction.SendMessage)
                        chkSendMessage.Checked = true;
                    if ((functions & GatewayFunction.ReceiveMessage) == GatewayFunction.ReceiveMessage)
                        chkReceiveMessage.Checked = true;
                    cboLogType.Text = gatewayConfig.LogSettings;
                    chkClearLogOnConnect.Checked = gatewayConfig.ClearLogOnConnect.Value;
                    cboPort.Text = gatewayConfig.ComPort;
                    cboBaudRate.Text = gatewayConfig.BaudRate;
                    cboHandshake.Text = gatewayConfig.Handshake;
                    cboDataBits.Text = gatewayConfig.DataBits;
                    cboParity.Text = gatewayConfig.Parity;
                    cboStopBits.Text = gatewayConfig.StopBits;
                    updCommandTimeout.Value = gatewayConfig.CommandTimeout.Value;
                    updReadIntervalTimeout.Value = gatewayConfig.ReadTimeout.Value ;
                    updCommandDelay.Value = gatewayConfig.CommandDelay.Value;
                    txtSmsc.Text = gatewayConfig.Smsc;
                    
                    chkUseSmscFromSim.Checked = gatewayConfig.UseSimSmsc.Value;
                    cboMessageMemory.Text = gatewayConfig.MessageMemory ;
                    cboMessageValidity.Text = gatewayConfig.MessageValidity ;
                    updSendRetry.Value = gatewayConfig.SendRetry.Value;
                    updSendDelay.Value = gatewayConfig.SendDelay.Value;
                    chkRequestDeliveryStatusReport.Checked = gatewayConfig.RequestStatusReport.Value;
                    chkDeleteAfterRetrieve.Checked = gatewayConfig.DeleteAfterRetrieve.Value;

                    chkAutoArchiveMessageLog.Checked = gatewayConfig.AutoArchiveLog.Value;
                    updArchiveMessageLogDay.Value = gatewayConfig.AutoArchiveLogInterval.Value;
                    updArchiveMessageOlderThanDay.Value = gatewayConfig.ArchiveOldMessageInterval.Value;
                    chkForwardArchivedMessageLogAsEmail.Checked = gatewayConfig.ForwardArchivedMessage.Value;
                    txtEmailAddress.Text = gatewayConfig.ForwardEmail;
                    chkDeleteArchivedMessageOlderThan.Checked = gatewayConfig.DeleteArchivedMessage.Value;
                    updDeleteArchivedMessageOlderThanDay.Value = gatewayConfig.DeleteArchivedMessageInterval.Value;

                    updRefreshSignalInterval.Value = gatewayConfig.SignalRefreshInterval.Value;
                    txtPin.Text = gatewayConfig.Pin;
                    chkAutoResponseCall.Checked = gatewayConfig.AutoResponseCall.Value;
                    txtAutoResponseText.Text = gatewayConfig.AutoResponseCallText;

                    txtName.Enabled = false;
                    this.IsUpdate = true;
                }
            }
        }
        
        /// <summary>
        /// Setups the message log settings.
        /// </summary>
        private void SetupMessageLogSettings()
        {
            updArchiveMessageLogDay.Value = DefaultArchivedMessageLogInterval;
            updArchiveMessageOlderThanDay.Value = DefaultArchivedMessageInterval;
            updDeleteArchivedMessageOlderThanDay.Value = DefaultDeleteArchivedMessageInterval;
        }

        /// <summary>
        /// Setups the general settings.
        /// </summary>
        private void SetupGeneralSettings()
        {
            cboLogType.Items.AddRange(EnumMatcher.LoggingLevel.Keys.ToArray());
            cboLogType.SelectedIndex = 0;
        }

        /// <summary>
        /// Setups the other settings.
        /// </summary>
        private void SetupOtherSettings()
        {
            updRefreshSignalInterval.Value = DefaultSignalRefreshInterval;
        }

        /// <summary>
        /// Setups the communication settings.
        /// </summary>
        private void SetupCommSettings()
        {
            // Add the port
            string[] portNames = SerialPort.GetPortNames();
            // There is a bug that for high COM port there is a "c" at the back, e.g. "COM11c"
            var sortedList = portNames.OrderBy(port => Convert.ToInt32(port.Replace("COM", string.Empty)));
            foreach (string port in sortedList)
            {
                if (!cboPort.Items.Contains(port))
                    cboPort.Items.Add(port);
            }
            cboPort.SelectedIndex = 0;

            // Add baud rate
            foreach (string baudRate in Enum.GetNames(typeof(PortBaudRate)))
            {
                cboBaudRate.Items.Add((int)Enum.Parse(typeof(PortBaudRate), baudRate));
            }
            cboBaudRate.Text = "115200";

            // Add data bits
            foreach (string dataBit in Enum.GetNames(typeof(PortDataBits)))
            {
                cboDataBits.Items.Add((int)Enum.Parse(typeof(PortDataBits), dataBit));
            }
            cboDataBits.Text = "8";

            // Add parity            
            cboParity.Items.AddRange(EnumMatcher.Parity.Keys.ToArray());
            cboParity.SelectedIndex = 0;

            // Add stop bits         
            cboStopBits.Items.AddRange(EnumMatcher.StopBits.Keys.ToArray());
            cboStopBits.SelectedIndex = 0;

            // Add handshake          
            cboHandshake.Items.AddRange(EnumMatcher.Handshake.Keys.ToArray());
            cboHandshake.SelectedIndex = 0;

            updCommandTimeout.Value = DefaultTimeout;
            updReadIntervalTimeout.Value = DefaultReadIntervalTimeout;
            updCommandDelay.Value = DefaultCommandDelay;          

        }

        /// <summary>
        /// Setups the message settings.
        /// </summary>
        private void SetupMessageSettings()
        {
            // Message memory
            cboMessageMemory.Items.AddRange(EnumMatcher.MessageMemory.Keys.ToArray());
            cboMessageMemory.SelectedIndex = 0;

            // Message validity period
            cboMessageValidity.Items.AddRange(EnumMatcher.ValidityPeriod.Keys.ToArray());
            cboMessageValidity.SelectedIndex = 6;

            updSendRetry.Value = DefaultSendRetry;
            updSendDelay.Value = DefaultSendDelay;

        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save changes
            if (SaveChanges())
            {               
                // Close the form
                this.Close();
            }
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        private bool SaveChanges()
        {
            // Validate the name is not empty
            if (!FormHelper.ValidateNotEmpty(txtName, Resources.MsgUniqueNameRequired))
            {
                return false;
            }

            string gatewayId = txtName.Text.Trim();
            if (!this.IsUpdate)
            {
                // The gateway name must be unique 
                if (GatewayConfig.Exists(g => g.Id.ToLower() == gatewayId.ToLower()))
                {
                    FormHelper.ShowError(txtName, string.Format(Resources.MsgGatewayNameAlreadyExists, gatewayId));
                    return false;
                }

                // The port name should not be in use
                if (GatewayConfig.Exists(g => g.ComPort.ToLower() == cboPort.Text.ToLower()))
                {
                    DialogResult dialogResult = FormHelper.Confirm(string.Format(Resources.MsgDuplicateComPort, cboPort.Text));
                    if (dialogResult == DialogResult.No)
                    {
                        return false;
                    }
                }
            }           

            // If forwarded is checked, make sure email address is not empty
            if (chkForwardArchivedMessageLogAsEmail.Checked)
            {
                if (!FormHelper.ValidateNotEmpty(txtEmailAddress, Resources.MsgEmailAddressRequired))
                {
                    return false;
                }
            }

            // If auto response is required, make sure the text is not empty
            if (chkAutoResponseCall.Checked)
            {
                if (!FormHelper.ValidateNotEmpty(txtAutoResponseText, Resources.MsgAutoResponseTextRequired))
                {
                    return false;
                }
            }

            try
            {
                // Save the gateway configuration
                GatewayConfig gatewayConfig = new GatewayConfig();

                if (this.IsUpdate)
                {
                    gatewayConfig = GatewayConfig.SingleOrDefault(g => g.Id == gatewayId);
                }
                
                // General
                gatewayConfig.Id = gatewayId;
                gatewayConfig.OwnNumber = txtPhoneNo.Text;
                gatewayConfig.AutoConnect = chkConnectAtStartup.Checked;
                gatewayConfig.Functions = 0;
                if (chkSendMessage.Checked)
                    gatewayConfig.Functions += (int)GatewayFunction.SendMessage;
                if (chkReceiveMessage.Checked)
                    gatewayConfig.Functions += (int)GatewayFunction.ReceiveMessage;
                gatewayConfig.LogSettings = cboLogType.Text;
                gatewayConfig.ClearLogOnConnect = chkClearLogOnConnect.Checked;
                gatewayConfig.Initialize = false;
                
                // Communication
                gatewayConfig.ComPort = cboPort.Text;
                gatewayConfig.BaudRate = cboBaudRate.Text;
                gatewayConfig.DataBits = cboDataBits.Text;
                gatewayConfig.Parity = cboParity.Text;
                gatewayConfig.StopBits = cboStopBits.Text;
                gatewayConfig.Handshake = cboHandshake.Text;
                gatewayConfig.CommandTimeout = Convert.ToInt32(updCommandTimeout.Value);
                gatewayConfig.CommandDelay = Convert.ToInt32(updCommandDelay.Value);
                gatewayConfig.ReadTimeout = Convert.ToInt32(updReadIntervalTimeout.Value);
                
               
                // Message Settings
                gatewayConfig.Smsc = txtSmsc.Text;
                gatewayConfig.UseSimSmsc = chkUseSmscFromSim.Checked;
                gatewayConfig.MessageMemory = cboMessageMemory.Text;
                gatewayConfig.MessageValidity = cboMessageValidity.Text;
                gatewayConfig.SendRetry = Convert.ToInt32(updSendRetry.Value);
                gatewayConfig.SendDelay = Convert.ToInt32(updSendDelay.Value);
                gatewayConfig.RequestStatusReport = chkRequestDeliveryStatusReport.Checked;
                gatewayConfig.DeleteAfterRetrieve = chkDeleteAfterRetrieve.Checked;
                
               
                // Message log
                gatewayConfig.AutoArchiveLog = chkAutoArchiveMessageLog.Checked;
                gatewayConfig.AutoArchiveLogInterval = Convert.ToInt32(updArchiveMessageLogDay.Value);
                gatewayConfig.ArchiveOldMessageInterval = Convert.ToInt32(updArchiveMessageOlderThanDay.Value);
                gatewayConfig.ForwardArchivedMessage = chkForwardArchivedMessageLogAsEmail.Checked;
                gatewayConfig.ForwardEmail = txtEmailAddress.Text;
                gatewayConfig.DeleteArchivedMessage = chkDeleteArchivedMessageOlderThan.Checked;
                gatewayConfig.DeleteArchivedMessageInterval = Convert.ToInt32(updDeleteArchivedMessageOlderThanDay.Value);

                // Other settings
                gatewayConfig.SignalRefreshInterval = Convert.ToInt32(updRefreshSignalInterval.Value);
                gatewayConfig.Pin = txtPin.Text;
                gatewayConfig.AutoResponseCall = chkAutoResponseCall.Checked;
                gatewayConfig.AutoResponseCallText = txtAutoResponseText.Text;

                if (!this.IsUpdate)
                    gatewayConfig.Save();
                else
                    gatewayConfig.Update();

                if (GatewayAdded != null)
                {
                    // Raise the event
                    GatewayEventHandlerArgs arg = new GatewayEventHandlerArgs(gatewayId);
                    this.GatewayAdded.BeginInvoke(this, arg, new AsyncCallback(this.AsyncCallback), null);
                }

                if (GatewayUpdated != null)
                {
                    // Raise the event
                    GatewayEventHandlerArgs arg = new GatewayEventHandlerArgs(gatewayId);
                    this.GatewayUpdated.BeginInvoke(this, arg, new AsyncCallback(this.AsyncCallback), null);
                }

            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
                return false;
            }

            // Reset to false
            isFormChanged = false;

            // Show successful save message
            FormHelper.ShowInfo(Resources.MsgGatewayConfigSaved);

            // Return true as saving is successful
            return true;

        }

        /// <summary>
        /// Asynchronous callback method
        /// </summary>
        /// <param name="param">Result</param>
        private void AsyncCallback(IAsyncResult param)
        {
            System.Runtime.Remoting.Messaging.AsyncResult result = (System.Runtime.Remoting.Messaging.AsyncResult)param;
            if (result.AsyncDelegate is NewGatewayEventHandler)
            {
                ((NewGatewayEventHandler)result.AsyncDelegate).EndInvoke(result);
            }
            else if (result.AsyncDelegate is UpdateGatewayEventHandler)
            {
                ((UpdateGatewayEventHandler)result.AsyncDelegate).EndInvoke(result);
            }
            else
            {
            }
        }



        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form            
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnEmailSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnEmailSettings_Click(object sender, EventArgs e)
        {
            frmEmail email = new frmEmail();
            email.ShowDialog(this);
        }

        /// <summary>
        /// Sets the form state change handlers.
        /// </summary>
        /// <param name="parent">The parent.</param>
        private void SetFormStateChangeHandlers(Control parent)
        {
            isFormChanged = false;

            foreach (Control control in parent.Controls)
            {
                // Attach to text changed event
                EventInfo eventInfo = control.GetType().GetEvent("TextChanged",
                        BindingFlags.Instance | BindingFlags.Public);
                if (eventInfo != null)
                {
                    eventInfo.AddEventHandler(control, new EventHandler(ControlStateChanged));
                }

                // Attach to value changed event
                eventInfo = control.GetType().GetEvent("ValueChanged",
                        BindingFlags.Instance | BindingFlags.Public);
                if (eventInfo != null)
                {
                    eventInfo.AddEventHandler(control, new EventHandler(ControlStateChanged));
                }               

                // handle container controls which might have child controls
                if (control.Controls.Count > 0)
                {
                    SetFormStateChangeHandlers(control);
                }
            }
        }
               
        /// <summary>
        /// Controls the state changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ControlStateChanged(object sender, EventArgs e)
        {
            isFormChanged = true;
        }

        /// <summary>
        /// Handles the FormClosing event of the frmGateway control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void frmGateway_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFormChanged)
            {
                DialogResult dialogResult = MessageBox.Show(Resources.MsgSaveChangesBeforeExit, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!SaveChanges())
                    {
                        e.Cancel = true;
                    }
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Handles the Shown event of the frmGateway control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmGateway_Shown(object sender, EventArgs e)
        {
            // Set to focus           
            txtName.Focus();
            
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkUseSmscFromSim control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkUseSmscFromSim_CheckedChanged(object sender, EventArgs e)
        {
            txtSmsc.Enabled = chkUseSmscFromSim.Checked;
        }

        /// <summary>
        /// Gets or sets the gateway id.
        /// </summary>
        /// <value>The gateway id.</value>
        [DefaultValue("")]
        public string GatewayId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is update.
        /// </summary>
        /// <value><c>true</c> if this instance is update; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool IsUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkForwardArchivedMessageLogAsEmail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkForwardArchivedMessageLogAsEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmailAddress.Enabled = chkForwardArchivedMessageLogAsEmail.Checked;
        }

    }
}
