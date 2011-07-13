using System;
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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Control footer
    /// </summary>
    public partial class ControlFooter : UserControl
    {
        private const string DefaultMessage = "Help message";

        private string message;

        public ControlFooter()
        {
            InitializeComponent();
            this.message = DefaultMessage;
            this.label1.Text = DefaultMessage;
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
                this.label1.Text = value;
            }
        }

        /// <summary>
        /// Handles the Resize event of the ControlFooter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ControlFooter_Resize(object sender, EventArgs e)
        {
            this.label2.Width = this.Width - 10;
        }
    }
}
