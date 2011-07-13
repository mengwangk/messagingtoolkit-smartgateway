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
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Database messenger data form
    /// </summary>
    public partial class frmDatabaseMessenger : Form
    {
        #region Event


        /// <summary>
        /// Occurs when messenger added.
        /// </summary>
        public event NewMessengerEventHandler MessengerAdded;


        /// <summary>
        /// Occurs when messenger updated.
        /// </summary>
        public event UpdateMessengerEventHandler MessengerUpdated;


        #endregion

        #region Constants

        /// <summary>
        /// Default command time out in seconds
        /// </summary>
        private const int DefaultPollingInterval = 5;

        #endregion

        #region  Private variables



        // Variable to indicate if any controls change
        private bool isFormChanged;


        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="frmDatabaseMessenger"/> class.
        /// </summary>
        public frmDatabaseMessenger()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the frmDatabaseMessenger control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmDatabaseMessenger_Load(object sender, EventArgs e)
        {
            SetupForm();
            SetFormStateChangeHandlers(this);
            DisplayMessenger();
        }

        /// <summary>
        /// Setups the form.
        /// </summary>
        private void SetupForm()
        {
            SortedList<string, DataSourceType> dsnList = OdbcDataSourceManager.GetSystemDataSourceNames();
            for (int i = 0; i < dsnList.Count; i++)
            {
                cboDsn.Items.Add(dsnList.Keys[i]);
            }

            npdPollingInterval.Value = DefaultPollingInterval;

            // Load priority
            cboDefaultMsgPriority.Items.Clear();
            cboDefaultMsgPriority.Items.AddRange(EnumMatcher.MessagePriority.Keys.ToArray());
            cboDefaultMsgPriority.SelectedIndex = 1;
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
            else if (result.AsyncDelegate is UpdateMessengerEventHandler)
            {
                ((UpdateMessengerEventHandler)result.AsyncDelegate).EndInvoke(result);
            }
            else
            {
            }
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
        /// Handles the FormClosing event of the frmDatabaseMessenger control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void frmDatabaseMessenger_FormClosing(object sender, FormClosingEventArgs e)
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
            string name = txtName.Text.Trim();
            if (!this.IsUpdate)
            {
                // The messenger name must be unique 
                if (DbMessenger.Exists(m => m.Name.ToLower() == name.ToLower()))
                {
                    FormHelper.ShowError(txtName, string.Format(Resources.MsgMessengerNameAlreadyExists, name));
                    return false;
                }              
            }
            
            if (!FormHelper.ValidateNotEmpty(cboDsn, Resources.MsgDsnRequired))
            {
                return false;
            }

            if (!FormHelper.ValidateNotEmpty(txtDbTable, Resources.MsgDbTableRequired))
            {
                return false;
            }

            if (chkRequireAuthentication.Checked)
            {
                if (!FormHelper.ValidateNotEmpty(txtDbUserName, Resources.MsgDbUserNameRequired))
                {
                    return false;
                }

                if (!FormHelper.ValidateNotEmpty(txtDbPassword, Resources.MsgDbUserPasswordRequired))
                {
                    return false;
                }
            }    


            if (!FormHelper.ValidateNotEmpty(txtUniqMsgIdColName, Resources.MsgUniqMsgIdColNameRequired))
            {
                return false;
            }

            if (!FormHelper.ValidateNotEmpty(txtDestNoColName, Resources.MsgDestNoColNameRequired))
            {
                return false;
            }

            if (!FormHelper.ValidateNotEmpty(txtDestNoColName, Resources.MsgDestNoColNameRequired))
            {
                return false;
            }

            if (!FormHelper.ValidateNotEmpty(txtMsgColName, txtDefaultTextMsg, Resources.MsgMsgColDefaultMsgRequired))
            {
                return false;
            }

            if (chkDeleteAfterSending.Checked)
            {
                if (!FormHelper.ValidateNotEmpty(txtStatusColName, Resources.MsgStatusColNameRequired))
                {
                    return false;
                }              
            }           


            try
            {
                // Save the messenger configuration
                DbMessenger dbMessenger = new DbMessenger();

                if (this.IsUpdate)
                {
                    dbMessenger = DbMessenger.SingleOrDefault(m => m.Name.ToLower() == name.ToLower());
                }
                               
                dbMessenger.Name = name;
                dbMessenger.Description = txtDescription.Text;
                dbMessenger.Dsn = cboDsn.Text;
                dbMessenger.DbTable = txtDbTable.Text;
                dbMessenger.PollingInterval = Convert.ToInt32(npdPollingInterval.Value);
                dbMessenger.RequiredAuth = chkRequireAuthentication.Checked;
                dbMessenger.DbUserName = txtDbUserName.Text;
                dbMessenger.DbUserPassword = txtDbPassword.Text;
                dbMessenger.UniqMsgIdColName = txtUniqMsgIdColName.Text;
                if (radMsgIdDataTypeString.Checked)
                    dbMessenger.UniqMsgIdColDataType = StringEnum.GetStringValue(DataType.String);
                else
                    dbMessenger.UniqMsgIdColDataType = StringEnum.GetStringValue(DataType.Numeric);

                dbMessenger.MsgColName = txtMsgColName.Text;
                dbMessenger.DestNoColName = txtDestNoColName.Text;
                dbMessenger.MsgPriorityColName = txtMsgPriorityColName.Text;
                dbMessenger.MsgAlertColName = txtMsgAlertColName.Text;
                dbMessenger.DefaultMsgPriority = cboDefaultMsgPriority.Text;
                dbMessenger.DefaultTextMsg = txtDefaultTextMsg.Text;
                dbMessenger.DeleteAfterSending = chkDeleteAfterSending.Checked;
                dbMessenger.StatusColName = txtStatusColName.Text;
                dbMessenger.StatusTimestampColName = txtStatusTimestampColName.Text;
                dbMessenger.StatusColNewValue = txtStatusColValue.Text;
                dbMessenger.StatusColUpdateSuccessVal = txtStatusColUpdateSentValue.Text;
                dbMessenger.StatusColUpdateFailedValue = txtStatusColUpdateFailedValue.Text;
                dbMessenger.StatusColUpdateSendingValue = txtStatusColUpdateSendingValue.Text;
                dbMessenger.AutoStart = chkAutoStart.Checked;           


                if (!this.IsUpdate)
                    dbMessenger.Save();
                else
                    dbMessenger.Update();

                if (MessengerAdded != null)
                {
                    // Raise the event
                    MessengerEventHandlerArgs arg = new MessengerEventHandlerArgs(name);
                    this.MessengerAdded.BeginInvoke(this, arg, new AsyncCallback(this.AsyncCallback), null);
                }

                if (MessengerUpdated != null)
                {
                    // Raise the event
                    MessengerEventHandlerArgs arg = new MessengerEventHandlerArgs(name);
                    this.MessengerUpdated.BeginInvoke(this, arg, new AsyncCallback(this.AsyncCallback), null);
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
            FormHelper.ShowInfo(Resources.MsgMessengerConfigSaved);

            // Return true as saving is successful
            return true;
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Shown event of the frmDatabaseMessenger control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmDatabaseMessenger_Shown(object sender, EventArgs e)
        {
            // Set to focus           
            txtName.Focus();
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
        /// Gets or sets the name of the messenger.
        /// </summary>
        /// <returns>The name of the messenger. The default is an empty string ("").</returns>
        [DefaultValue("")]
        public string MessengerName
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
        /// Handles the CheckedChanged event of the chkRequireAuthentication control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkRequireAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            txtDbUserName.Enabled = chkRequireAuthentication.Checked;
            txtDbPassword.Enabled = chkRequireAuthentication.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkDeleteAfterSending control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkDeleteAfterSending_CheckedChanged(object sender, EventArgs e)
        {
            txtStatusColName.Enabled = !chkDeleteAfterSending.Checked;
            txtStatusTimestampColName.Enabled = !chkDeleteAfterSending.Checked;
            txtStatusColValue.Enabled = !chkDeleteAfterSending.Checked;
            txtStatusColUpdateSentValue.Enabled = !chkDeleteAfterSending.Checked;
            txtStatusColUpdateFailedValue.Enabled = !chkDeleteAfterSending.Checked;
            txtStatusColUpdateSendingValue.Enabled = !chkDeleteAfterSending.Checked;
        }



        /// <summary>
        /// Displays the messenger.
        /// </summary>
        private void DisplayMessenger()
        {
            if (!string.IsNullOrEmpty(this.MessengerName))
            {
                // Retrieve and display the messenger configuration
                DbMessenger messenger = DbMessenger.SingleOrDefault(m => m.Name.ToLower() == this.MessengerName.ToLower());
                if (messenger != null)
                {
                    // Display the messenger information
                    txtName.Text = messenger.Name;
                    txtDescription.Text = messenger.Description;
                    cboDsn.Text = messenger.Dsn;
                    txtDbTable.Text = messenger.DbTable;
                    npdPollingInterval.Value = messenger.PollingInterval;
                    chkRequireAuthentication.Checked = messenger.RequiredAuth;
                    txtDbUserName.Text = messenger.DbUserName;
                    txtDbPassword.Text = messenger.DbUserPassword;
                    txtUniqMsgIdColName.Text = messenger.UniqMsgIdColName;

                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), messenger.UniqMsgIdColDataType.ToString());
                    if ((dataType & DataType.String) == DataType.String)
                        radMsgIdDataTypeString.Checked = true;
                    if ((dataType & DataType.Numeric) == DataType.Numeric)
                        radMsgIdDataTypeNumeric.Checked = true;

                    txtMsgColName.Text = messenger.MsgColName;
                    txtDestNoColName.Text = messenger.DestNoColName;
                    txtMsgPriorityColName.Text = messenger.MsgPriorityColName;
                    txtMsgAlertColName.Text = messenger.MsgAlertColName;
                    cboDefaultMsgPriority.Text = messenger.DefaultMsgPriority;
                    txtDefaultTextMsg.Text = messenger.DefaultTextMsg;
                    chkDeleteAfterSending.Checked = messenger.DeleteAfterSending;
                    txtStatusColName.Text = messenger.StatusColName;
                    txtStatusTimestampColName.Text = messenger.StatusTimestampColName;
                    txtStatusColValue.Text = messenger.StatusColNewValue;
                    txtStatusColUpdateSentValue.Text = messenger.StatusColUpdateSuccessVal;
                    txtStatusColUpdateFailedValue.Text = messenger.StatusColUpdateFailedValue;
                    txtStatusColUpdateSendingValue.Text = messenger.StatusColUpdateSendingValue;
                    chkAutoStart.Checked = messenger.AutoStart;

                    txtName.Enabled = false;
                    this.IsUpdate = true;
                }
            }
        }

    }
}
