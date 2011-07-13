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
using System.Threading;


using log4net;

using MessagingToolkit.Core;
using MessagingToolkit.Core.Base;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Core.Log;
using MessagingToolkit.Core.Mobile.Message;
using MessagingToolkit.Core.Mobile.Event;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Poller;

namespace MessagingToolkit.SmartGateway.Core
{
    public partial class frmTestForm : Form
    {
        public frmTestForm()
        {
            InitializeComponent();
        }

        private void frmTestForm_Load(object sender, EventArgs e)
        {
            DbMessenger messenger = DbMessenger.SingleOrDefault(m => m.Name.ToLower() == "messagingtoolkit".ToLower());
            if (messenger != null)
            {
                DatabasePoller poller = new DatabasePoller(messenger, null);
                poller.Name = messenger.Name;
                Thread worker = new Thread(new ThreadStart(poller.StartTimer));
                worker.IsBackground = true;
                worker.Name = messenger.Name;               
                worker.Start();               
            }
        }

       
    }
}
