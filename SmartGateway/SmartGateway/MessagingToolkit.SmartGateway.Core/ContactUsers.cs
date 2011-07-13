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

using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Contact user control
    /// </summary>
    public partial class ContactUsers : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUsers"/> class.
        /// </summary>
        public ContactUsers()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ContactUsers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ContactUsers_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            SetupView();
            RefreshView();
        }

        /// <summary>
        /// Setups the view.
        /// </summary>
        private void SetupView()
        {
            this.olvColCommonName.AspectGetter = delegate(object x) { return ((User)x).CommonName; };
            this.olvColPhoneNumber.AspectGetter = delegate(object x) { return ((User)x).Mobtel; };
            this.olvColEmail.AspectGetter = delegate(object x) { return ((User)x).Email; };
            this.olvColLoginName.AspectGetter = delegate(object x) { return ((User)x).LoginName; };           
        }

        /// <summary>
        /// Refreshes the view.
        /// </summary>
        private void RefreshView()
        {
            User selectedUser = lvwUsers.SelectedObject as User;

            lvwUsers.BeginUpdate();
            lvwUsers.ClearObjects();
            IQueryable<User> results = User.All().OrderBy(u => u.Id);
            List<User> users = new List<User>(results.AsEnumerable());
            lvwUsers.SetObjects(users);
            if (users.Count() == 0)
                lvwUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            else
                lvwUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            olvColLoginName.FillsFreeSpace = true;

            lvwUsers.EndUpdate();

            if (selectedUser != null)
            {
                lvwUsers.SelectObject(selectedUser);
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkAddUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkAddUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmContactUser userForm = new frmContactUser();
            if (userForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshView();
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkEditUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkEditUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditUser();
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkDeleteUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkDeleteUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User selectedUser = lvwUsers.SelectedObject as User;
            if (selectedUser == null) return;
            if (selectedUser.LoginName.Equals(GuiHelper.AdministratorName, StringComparison.OrdinalIgnoreCase))
            {
                FormHelper.ShowInfo(Resources.MsgUserCannotEdit);
                return;
            }

            if (FormHelper.Confirm(string.Format(Resources.MsgConfirmDeleteUser, selectedUser.CommonName)) == DialogResult.Yes)
            {
                selectedUser.Delete();
                RefreshView();
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the lvwUsers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvwUsers_DoubleClick(object sender, EventArgs e)
        {
            EditUser();
        }


        /// <summary>
        /// Edits the user.
        /// </summary>
        private void EditUser()
        {
            User selectedUser = lvwUsers.SelectedObject as User;
            if (selectedUser == null) return;

            //if (selectedUser.LoginName.Equals(GuiHelper.AdministratorName, StringComparison.OrdinalIgnoreCase))
            //{
            //    FormHelper.ShowInfo(Resources.MsgUserCannotEdit);
            //    return;
            //}

            frmContactUser userForm = new frmContactUser();
            userForm.User = selectedUser;
            if (userForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshView();
            }
        }
    }
}
