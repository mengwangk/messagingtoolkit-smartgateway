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

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Create new message form
    /// </summary>
    public partial class frmNewMessage : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="frmNewMessage"/> class.
        /// </summary>
        public frmNewMessage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the frmNewMessage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmNewMessage_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Gets the message form.
        /// </summary>
        /// <value>The message form.</value>
        public NewMessage MessageForm
        {
            get
            {
                return this.newMessage1;
            }
        }
    }
}
