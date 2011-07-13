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
using System.Transactions;

using SubSonic.DataProviders;

using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Contact group form
    /// </summary>
    public partial class frmContactGroup : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="frmContactGroup"/> class.
        /// </summary>
        public frmContactGroup()
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
            // Name cannot be empty
            if (!FormHelper.ValidateNotEmpty(txtName, Resources.MsgNameRequired))
            {   
                return;
            }

            if (this.Group == null)
            {
                // Name cannot be the built-in administrator group name
                if (GuiHelper.AdministratorGroupName.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase))
                {
                    FormHelper.ShowError(Resources.MsgAdminGroupNameNotAllowed);
                    txtName.Focus();
                    return;
                }
            }

            using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {

                        if (Group == null)
                        {
                            // Name must be unique
                            Role searchRole = Role.SingleOrDefault(r => r.Name.ToLower() == txtName.Text.ToLower());
                            if (searchRole != null)
                            {
                                FormHelper.ShowError(Resources.MsgGroupNameNotUnique);
                                return;
                            }

                            // Create a new one
                            Role role = new Role();
                            role.Name = txtName.Text.Trim();
                            role.Desc = txtDescription.Text;
                            if (role.Name.Equals(GuiHelper.AdministratorGroupName))
                                role.CanBeDeleted = false;
                            else
                                role.CanBeDeleted = true;
                            role.Save();
                            this.Group = role;
                        }
                        else
                        {
                            if (!this.Group.Name.Equals(txtName.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                // Check for duplicate                        
                                Role searchRole = Role.SingleOrDefault(r => r.Name.ToLower() == txtName.Text.ToLower());
                                if (searchRole != null)
                                {
                                    FormHelper.ShowError(Resources.MsgGroupNameNotUnique);
                                    return;
                                }
                            }

                            // Update an existing one
                            this.Group.Name = txtName.Text.Trim();
                            this.Group.Desc = txtName.Text;
                            if (this.Group.Name.Equals(GuiHelper.AdministratorGroupName))
                                this.Group.CanBeDeleted = false;
                            else
                                this.Group.CanBeDeleted = true;
                            this.Group.Update();
                        }


                        // Delete user related to existing groups
                        UserRoleMap.Delete(urm => urm.RoleId == this.Group.Id);
                        
                        // Save the users for the existing groups
                        foreach (object item in lstUsersInGroup.Items)
                        {
                            string loginName = GetLoginName(item);
                            
                            // Get the user id and save the user group mapping
                            User user = User.SingleOrDefault(u => u.LoginName == loginName);
                            if (user != null)
                            {
                                UserRoleMap urm = new UserRoleMap();
                                urm.UserId = user.Id;
                                urm.RoleId = this.Group.Id;
                                urm.Save();
                            }
                        }

                        FormHelper.ShowInfo(Resources.MsgGroupSaved);
                    }
                    catch (Exception ex)
                    {
                        FormHelper.ShowError(ex.Message);
                    }
                    finally
                    {
                        try
                        {
                            ts.Complete();
                        }
                        catch (Exception) { }
                    }
                }
            } 

            this.DialogResult = DialogResult.OK;
            
        }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        public Role Group { get; set; }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Load event of the frmContactGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmContactGroup_Load(object sender, EventArgs e)
        {
            List<User> usersInGroup = new List<User>();
            if (this.Group != null)
            {
                this.Text = this.Group.Name;
                this.txtName.Text = this.Group.Name;
                this.txtDescription.Text = this.Group.Desc;

                if (this.Group.Name.Equals(GuiHelper.AdministratorGroupName, StringComparison.OrdinalIgnoreCase))
                {
                    txtName.Enabled = false;
                }

                // Load users in those groups
                IList<UserRoleMap> userList = UserRoleMap.Find(urm => urm.RoleId == this.Group.Id);
                foreach (UserRoleMap urm in userList)
                {
                    User user = User.SingleOrDefault(u => u.Id == urm.UserId);
                    if (user != null)
                    {
                        lstUsersInGroup.Items.Add(BuildDisplayName(user));
                        usersInGroup.Add(user);
                    }
                }
            }

            List<User> users = new List<User>(User.All().OrderBy(u => u.CommonName).AsEnumerable());
            foreach (User user in users)
            {
                if (!usersInGroup.Exists(u => u.Id == user.Id))
                {
                    lstAvailableUsers.Items.Add(BuildDisplayName(user));
                }
            }

        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (object item in lstAvailableUsers.SelectedItems)
            {
                // Derive the login name
                string loginName = GetLoginName(item);

                // Check if already added
                if (AlreadyExists(loginName))
                {
                    return;
                }                
                lstUsersInGroup.Items.Add(item);
            }
        }

        /// <summary>
        /// Gets the name of the login.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private string GetLoginName(object item)
        {
            string user = item as string;
            string[] values = user.Split(new string[] { GuiHelper.FieldSplitter }, StringSplitOptions.None);
            return values[1];
        }

        /// <summary>
        /// Builds the display name.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>User display name</returns>
        private string BuildDisplayName(User user)
        {
            return (user.CommonName + GuiHelper.FieldSplitter + user.LoginName);
        }

        /// <summary>
        /// Alreadies the exists.
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <returns></returns>
        private bool AlreadyExists(string loginName)
        {
            foreach (object item in lstUsersInGroup.Items)
            {
                string userLoginName = GetLoginName(item);
                if (loginName.Equals(userLoginName))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Handles the Click event of the btnAddAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (object item in lstAvailableUsers.Items)
            {
                // Derive the login name
                string loginName = GetLoginName(item);

                // Check if already added
                if (AlreadyExists(loginName))
                {
                    return;
                }
                lstUsersInGroup.Items.Add(item);
            }

        }

        /// <summary>
        /// Handles the Click event of the btnRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            while (lstUsersInGroup.SelectedItems.Count > 0)
            {
                lstAvailableUsers.Items.Add(lstUsersInGroup.SelectedItems[0]);
                lstUsersInGroup.Items.Remove(lstUsersInGroup.SelectedItems[0]);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            while (lstUsersInGroup.Items.Count > 0)
            {
                lstAvailableUsers.Items.Add(lstUsersInGroup.Items[0]);
                lstUsersInGroup.Items.Remove(lstUsersInGroup.Items[0]);
            }
        }
    }
}
