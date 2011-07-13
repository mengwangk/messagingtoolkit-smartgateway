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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Custom list view
    /// </summary>
    public class SmartListView: ListView
    {
        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="message">The message.</param>
        protected override void WndProc(ref Message message)
        {
            try
            {
                const int WM_PAINT = 0xf;

                // if the control is in details view mode and columns

                // have been added, then intercept the WM_PAINT message

                // and reset the last column width to fill the list view

                switch (message.Msg)
                {
                    case WM_PAINT:
                        if (this.View == View.Details && this.Columns.Count > 0)
                            this.Columns[this.Columns.Count - 1].Width = -2;
                        break;
                }
            }
            catch (Exception ex) { }
            // pass messages on to the base control for processing

            base.WndProc(ref message);
        }
    }
}
