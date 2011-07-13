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

using MessagingToolkit.UI;
using MessagingToolkit.Core;
using MessagingToolkit.Core.Helper;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// License control
    /// </summary>
    public partial class License : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="License"/> class.
        /// </summary>
        public License()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the License control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void License_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            InitializeForm();

        }

        /// <summary>
        /// Initializes the form.
        /// </summary>
        private void InitializeForm()
        {
            AppConfig licensee = AppConfig.SingleOrDefault(ac => ac.Name == ConfigParameter.Licensee);
            txtLicensee.Text = licensee.Value;

            AppConfig licenseKey = AppConfig.SingleOrDefault(ac => ac.Name == ConfigParameter.LicenseKey);
            txtLicenseKey.Text = licenseKey.Value;
            txtLicensee.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            InitializeForm();            
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                AppConfig licensee = AppConfig.SingleOrDefault(ac => ac.Name == ConfigParameter.Licensee);
                licensee.Value = txtLicensee.Text;
                licensee.Update();

                AppConfig licenseKey = AppConfig.SingleOrDefault(ac => ac.Name == ConfigParameter.LicenseKey);
                licenseKey.Value = txtLicenseKey.Text;
                licenseKey.Update();

                FormHelper.ShowInfo(Resources.MsgLicenseInformationSaved);
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }
    }
}
