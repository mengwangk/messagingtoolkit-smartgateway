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

using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Contact search form
    /// </summary>
    public partial class frmContactSearch : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="frmContactSearch"/> class.
        /// </summary>
        public frmContactSearch()
        {
            InitializeComponent();
        }

        

        /// <summary>
        /// Handles the Load event of the frmContactSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmContactSearch_Load(object sender, EventArgs e)
        {
            // Set up list view
            SetupView();

            // Show messages
            RefreshView();
           
        }

        /// <summary>
        /// Setups the view.
        /// </summary>
        private void SetupView()
        {
            this.olvColLogin.AspectGetter = delegate(object x) { return ((User)x).LoginName; };
            this.olvColName.AspectGetter = delegate(object x) { return ((User)x).CommonName; };
            this.olvColPhoneNo.AspectGetter = delegate(object x) { return ((User)x).Mobtel; };
        }

        /// <summary>
        /// Refreshes the view.
        /// </summary>
        private void RefreshView()
        {
            User selectedUser = lvwContacts.SelectedObject as User;

            lvwContacts.BeginUpdate();
            lvwContacts.ClearObjects();
            IQueryable<User> results = User.All().OrderBy(u => u.LoginName);
            List<User> users = new List<User>(results.AsEnumerable());
            lvwContacts.SetObjects(users);
            if (users.Count() == 0)
                lvwContacts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            else
                lvwContacts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            olvColPhoneNo.FillsFreeSpace = true;

            lvwContacts.EndUpdate();

            if (selectedUser != null)
            {
                lvwContacts.SelectObject(selectedUser);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddUsers();
        }


        /// <summary>
        /// Gets or sets the selected users.
        /// </summary>
        /// <value>The selected users.</value>
        public List<User> SelectedUsers { get; set; }

        /// <summary>
        /// Handles the DoubleClick event of the lvwContacts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvwContacts_DoubleClick(object sender, EventArgs e)
        {
            AddUsers();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Adds the users.
        /// </summary>
        private void AddUsers()
        {
            SelectedUsers = new List<User>();
            foreach (User user in lvwContacts.SelectedObjects)
            {
                SelectedUsers.Add(user);
            }
        }

    }
}
