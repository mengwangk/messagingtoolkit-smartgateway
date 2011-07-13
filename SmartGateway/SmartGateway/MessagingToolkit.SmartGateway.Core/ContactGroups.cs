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
    /// Contact group control
    /// </summary>
    public partial class ContactGroups : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactGroups"/> class.
        /// </summary>
        public ContactGroups()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ContactGroups control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ContactGroups_Load(object sender, EventArgs e)
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
            this.olvColName.AspectGetter = delegate(object x) { return ((Role)x).Name; };
            this.olvColDescription.AspectGetter = delegate(object x) { return ((Role)x).Desc; };
            
        }

        /// <summary>
        /// Refreshes the view.
        /// </summary>
        private void RefreshView()
        {
            Role selectedRole = lvwGroups.SelectedObject as Role;

            lvwGroups.BeginUpdate();
            lvwGroups.ClearObjects();
            IQueryable<Role> results = Role.All().OrderBy(r=>r.Id);
            List<Role> roles = new List<Role>(results.AsEnumerable());
            lvwGroups.SetObjects(roles);
            if (roles.Count() == 0)
                lvwGroups.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            else
                lvwGroups.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            olvColDescription.FillsFreeSpace = true;            

            lvwGroups.EndUpdate();

            if (selectedRole != null)
            {
                lvwGroups.SelectObject(selectedRole);
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkAddGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkAddGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmContactGroup groupForm = new frmContactGroup();
            if (groupForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshView();
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkEditGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkEditGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditGroup();
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkDeleteGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkDeleteGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Role selectedRole = lvwGroups.SelectedObject as Role;
            if (selectedRole == null) return;
            if (selectedRole.Name.Equals(GuiHelper.AdministratorGroupName, StringComparison.OrdinalIgnoreCase))
            {
                FormHelper.ShowInfo(Resources.MsgGroupNameCannotEdit);
                return;
            }

            if (FormHelper.Confirm(string.Format(Resources.MsgConfirmDeleteGroup, selectedRole.Name)) == DialogResult.Yes)
            {
                selectedRole.Delete();
                RefreshView();
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the lvwGroups control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvwGroups_DoubleClick(object sender, EventArgs e)
        {
            EditGroup();
        }

        /// <summary>
        /// Edits the group.
        /// </summary>
        private void EditGroup()
        {
            Role selectedRole = lvwGroups.SelectedObject as Role;
            if (selectedRole == null) return;

            //if (selectedRole.Name.Equals(GuiHelper.AdministratorGroupName, StringComparison.OrdinalIgnoreCase))
            //{
            //    FormHelper.ShowInfo(Resources.MsgGroupNameCannotEdit);
            //    return;
            //}

            frmContactGroup groupForm = new frmContactGroup();
            groupForm.Group = selectedRole;
            if (groupForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshView();
            }
        }


    }
}
