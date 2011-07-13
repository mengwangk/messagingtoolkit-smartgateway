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
    /// Contact user form
    /// </summary>
    public partial class frmContactUser : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="frmContactUser"/> class.
        /// </summary>
        public frmContactUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the frmContactUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmContactUser_Load(object sender, EventArgs e)
        {
            List<Role> userRoles = new List<Role>();
            if (this.User != null)
            {
                this.txtName.Text = this.User.CommonName;
                this.txtPhoneNumber.Text = this.User.Mobtel;
                this.txtEmail.Text = this.User.Email;
                this.txtLoginName.Text = this.User.LoginName;
                this.txtPassword.Text = this.User.Password;
                this.txtPasswordAgain.Text = this.User.Password;

                if (this.User.LoginName.Equals(GuiHelper.AdministratorName, StringComparison.OrdinalIgnoreCase))
                {
                    txtLoginName.Enabled = false;
                }

                // Load user roles
                IList<UserRoleMap> userMappings = UserRoleMap.Find(urm => urm.UserId == this.User.Id);
                foreach (UserRoleMap urm in userMappings)
                {
                    Role role = Role.SingleOrDefault(r => r.Id == urm.RoleId);
                    if (role != null)
                    {
                        lstBelongedGroups.Items.Add(BuildDisplayName(role));
                        userRoles.Add(role);                       
                    }
                }
            }

            List<Role> roles = new List<Role>(Role.All().OrderBy(r=>r.Name).AsEnumerable());
            foreach (Role role in roles)
            {
                if (!userRoles.Exists(r => r.Id == role.Id))
                {
                    lstAvailableGroups.Items.Add(BuildDisplayName(role));                   
                }
            }
        }

        /// <summary>
        /// Builds the display name.
        /// </summary>
        /// <param name="role">The role.</param>
        private string BuildDisplayName(Role role)
        {
            return role.Name;
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public User User { get; set; }

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

            // Login name cannot be empty
            if (!FormHelper.ValidateNotEmpty(txtLoginName, Resources.MsgLoginNameRequired))
            {
                return;
            }

            // Password cannot be empty
            if (!FormHelper.ValidateNotEmpty(txtPassword, Resources.MsgPasswordRequired))
            {
                return;
            }

            if (this.User == null)
            {
                // Login name cannot be the built-in administrator name
                if (GuiHelper.AdministratorName.Equals(txtLoginName.Text, StringComparison.OrdinalIgnoreCase))
                {
                    FormHelper.ShowError(Resources.MsgAdminUserNameNotAllowed);
                    txtLoginName.Focus();
                    return;
                }
            }

            // Validate passwords are the same
            if (!txtPassword.Text.Equals(txtPasswordAgain.Text))
            {
                FormHelper.ShowError(Resources.MsgPasswordNotMatched);
                txtPassword.Focus();
                return;
            }

            using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {
                        if (User == null)
                        {
                            // Login name must be unique
                            if (IsDuplicate())
                            {
                                return;
                            }

                            // Create a new one
                            User user = new User();
                            user.CommonName = txtName.Text;
                            user.Mobtel = txtPhoneNumber.Text;
                            user.Email = txtEmail.Text;
                            user.LoginName = txtLoginName.Text;
                            user.Password = txtPassword.Text;
                            if (user.LoginName.Equals(GuiHelper.AdministratorName))
                                user.CanBeDeleted = false;
                            else
                                user.CanBeDeleted = true;
                            user.Save();

                            this.User = user;
                        }
                        else
                        {
                            if (!this.User.LoginName.Equals(txtLoginName.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                if (IsDuplicate())
                                {
                                    return;
                                }
                            }

                            // Update an existing one
                            this.User.CommonName = txtName.Text;
                            this.User.Mobtel = txtPhoneNumber.Text;
                            this.User.Email = txtEmail.Text;
                            this.User.LoginName = txtLoginName.Text;
                            this.User.Password = txtPassword.Text;
                            if (this.User.LoginName.Equals(GuiHelper.AdministratorName))
                                this.User.CanBeDeleted = false;
                            else
                                this.User.CanBeDeleted = true;
                            this.User.Update();
                        }


                        // Delete groups for this users
                        UserRoleMap.Delete(urm => urm.UserId == this.User.Id);

                        // Save the groups for this user
                        foreach (object item in lstBelongedGroups.Items)
                        {
                            string groupName = item as string;

                            // Get the user id and save the user role mapping
                            Role role = Role.SingleOrDefault(r => r.Name == groupName);
                            if (role != null)
                            {
                                UserRoleMap urm = new UserRoleMap();
                                urm.UserId = this.User.Id;
                                urm.RoleId = role.Id;
                                urm.Save();
                            }
                        }

                        FormHelper.ShowInfo(Resources.MsgUserSaved);
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
        /// Determines whether this instance is duplicate.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is duplicate; otherwise, <c>false</c>.
        /// </returns>
        private bool IsDuplicate()
        {
            // Check for duplicate                        
            User searchUser = User.SingleOrDefault(r => r.LoginName.ToLower() == txtLoginName.Text.ToLower());
            if (searchUser != null)
            {
                FormHelper.ShowError(Resources.MsgLoginNameNotUnique);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Alreadies the exists.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        private bool AlreadyExists(string groupName)
        {
            foreach (object item in lstBelongedGroups.Items)
            {
                string name = item as string;
                if (groupName.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (object item in lstAvailableGroups.SelectedItems)
            {
                // Get the group name
                string groupName = item as string;

                // Check if already added
                if (AlreadyExists(groupName))
                {
                    return;
                }
                lstBelongedGroups.Items.Add(item);
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (object item in lstAvailableGroups.Items)
            {
                // Get the group name
                string groupName = item as string;

                // Check if already added
                if (AlreadyExists(groupName))
                {
                    return;
                }
                lstBelongedGroups.Items.Add(item);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            while (lstBelongedGroups.SelectedItems.Count > 0)
            {
                lstAvailableGroups.Items.Add(lstBelongedGroups.SelectedItems[0]);
                lstBelongedGroups.Items.Remove(lstBelongedGroups.SelectedItems[0]);
            }

        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            while (lstBelongedGroups.Items.Count > 0)
            {
                lstAvailableGroups.Items.Add(lstBelongedGroups.Items[0]);
                lstBelongedGroups.Items.Remove(lstBelongedGroups.Items[0]);
            }
        }
    }
}
