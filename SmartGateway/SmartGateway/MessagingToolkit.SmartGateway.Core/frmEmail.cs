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

using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Email settings form
    /// </summary>
    public partial class frmEmail : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="frmEmail"/> class.
        /// </summary>
        public frmEmail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validate the sender email is not empty
            if (!FormHelper.ValidateNotEmpty(txtSenderEmail, Resources.MsgSenderEmailRequired))
            {
                return;
            }

            // Validate the email subject is not empty
            if (!FormHelper.ValidateNotEmpty(txtMailSubject, Resources.MsgEmailSubjectRequired))
            {
                return;
            }

            // Validate SMTP server is not empty
            if (!FormHelper.ValidateNotEmpty(txtSMTPServer, Resources.MsgSmtpServerRequired))
            {
                return;
            }

            // If checked then user name and password must be entered
            if (chkRequireAuthentication.Checked)
            {
                if (!FormHelper.ValidateNotEmpty(txtUserName, Resources.MsgSmtpInformationRequired))
                {
                    return;
                }
                if (!FormHelper.ValidateNotEmpty(txtPassword, Resources.MsgSmtpInformationRequired))
                {
                    return;
                }
            }

            try
            {                
                // Delete all records
                EmailConfig.Delete(config=>true);

                // Save current record
                EmailConfig emailConfig = new EmailConfig();
                emailConfig.SenderEmail = txtSenderEmail.Text.Trim();
                emailConfig.MailSubject = txtMailSubject.Text.Trim();
                emailConfig.SmtpServer = txtSMTPServer.Text.Trim();
                emailConfig.Authentication = chkRequireAuthentication.Checked;
                emailConfig.UserName = txtUserName.Text.Trim();
                emailConfig.UserPassword = txtPassword.Text;
                emailConfig.Save();

                FormHelper.ShowInfo(Resources.MsgEmailConfigSaved);

                this.Close();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }


        }

        /// <summary>
        /// Handles the Load event of the frmEmail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmEmail_Load(object sender, EventArgs e)
        {
            if (EmailConfig.All().Count() > 0)
            {
                EmailConfig emailConfig = EmailConfig.All().First();
                txtSenderEmail.Text = emailConfig.SenderEmail;
                txtMailSubject.Text = emailConfig.MailSubject;
                txtSMTPServer.Text = emailConfig.SmtpServer;
                chkRequireAuthentication.Checked = (bool)emailConfig.Authentication;
                txtUserName.Text = emailConfig.UserName;
                txtPassword.Text = emailConfig.UserPassword;                
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkRequireAuthentication control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkRequireAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = chkRequireAuthentication.Checked;
            txtPassword.Enabled = chkRequireAuthentication.Checked;
        }
    }
}
