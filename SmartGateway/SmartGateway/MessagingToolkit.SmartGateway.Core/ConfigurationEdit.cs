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

using SubSonic.DataProviders;
using MessagingToolkit.Core;
using MessagingToolkit.Core.Helper;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Edit form for all seetings
    /// </summary>
    public partial class ConfigurationEdit : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationEdit"/> class.
        /// </summary>
        public ConfigurationEdit()
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
            // Update licensing information
            if (!FormHelper.ValidateNotEmpty(txtLicensee, Resources.MsgLicenseeRequired)) return;
            if (!FormHelper.ValidateNotEmpty(txtLicenseKey, Resources.MsgLicenseKeyRequired)) return;
            //AppConfig.SingleOrDefault(c=>c.
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
