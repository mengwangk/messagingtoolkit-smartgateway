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

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Manual user control
    /// </summary>
    public partial class Manual : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manual"/> class.
        /// </summary>
        public Manual()
        {
            InitializeComponent();  
        }

        /// <summary>
        /// Handles the Load event of the Manual control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Manual_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            this.richTextBox1.LinkClicked += new LinkClickedEventHandler(richTextBox1_LinkClicked);
        }

        /// <summary>
        /// Handles the LinkClicked event of the richTextBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkClickedEventArgs"/> instance containing the event data.</param>
        void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText); 
        }
    }
}
