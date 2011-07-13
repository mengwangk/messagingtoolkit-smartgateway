namespace MessagingToolkit.SmartGateway.Core
{
    partial class ContactUsers
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlHeader1 = new MessagingToolkit.SmartGateway.Core.ControlHeader();
            this.lvwUsers = new MessagingToolkit.UI.ObjectListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.olvColCommonName = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColPhoneNumber = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColEmail = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColLoginName = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.lnkEditUser = new System.Windows.Forms.LinkLabel();
            this.lnkDeleteUser = new System.Windows.Forms.LinkLabel();
            this.lnkAddUser = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lvwUsers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlHeader1
            // 
            this.controlHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHeader1.Location = new System.Drawing.Point(0, 0);
            this.controlHeader1.Logo = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.users;
            this.controlHeader1.Name = "controlHeader1";
            this.controlHeader1.Size = new System.Drawing.Size(732, 93);
            this.controlHeader1.SubTitle = "Users";
            this.controlHeader1.TabIndex = 1;
            this.controlHeader1.Title = "MessagingToolkit SmartGateway";
            // 
            // lvwUsers
            // 
            this.lvwUsers.AllColumns.Add(this.olvColCommonName);
            this.lvwUsers.AllColumns.Add(this.olvColPhoneNumber);
            this.lvwUsers.AllColumns.Add(this.olvColEmail);
            this.lvwUsers.AllColumns.Add(this.olvColLoginName);
            this.lvwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColCommonName,
            this.olvColPhoneNumber,
            this.olvColEmail,
            this.olvColLoginName});
            this.lvwUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwUsers.FullRowSelect = true;
            this.lvwUsers.Location = new System.Drawing.Point(0, 93);
            this.lvwUsers.MultiSelect = false;
            this.lvwUsers.Name = "lvwUsers";
            this.lvwUsers.ShowGroups = false;
            this.lvwUsers.Size = new System.Drawing.Size(732, 446);
            this.lvwUsers.TabIndex = 2;
            this.lvwUsers.UseCompatibleStateImageBehavior = false;
            this.lvwUsers.View = System.Windows.Forms.View.Details;
            this.lvwUsers.DoubleClick += new System.EventHandler(this.lvwUsers_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkEditUser);
            this.panel1.Controls.Add(this.lnkDeleteUser);
            this.panel1.Controls.Add(this.lnkAddUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 63);
            this.panel1.TabIndex = 3;
            // 
            // olvColCommonName
            // 
            this.olvColCommonName.Text = "Common Name";
            // 
            // olvColPhoneNumber
            // 
            this.olvColPhoneNumber.Text = "Phone Number";
            // 
            // olvColEmail
            // 
            this.olvColEmail.Text = "Email";
            // 
            // olvColLoginName
            // 
            this.olvColLoginName.FillsFreeSpace = true;
            this.olvColLoginName.Text = "Login Name";
            // 
            // lnkEditUser
            // 
            this.lnkEditUser.AutoSize = true;
            this.lnkEditUser.Location = new System.Drawing.Point(119, 26);
            this.lnkEditUser.Name = "lnkEditUser";
            this.lnkEditUser.Size = new System.Drawing.Size(50, 13);
            this.lnkEditUser.TabIndex = 5;
            this.lnkEditUser.TabStop = true;
            this.lnkEditUser.Text = "Edit User";
            this.lnkEditUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditUser_LinkClicked);
            // 
            // lnkDeleteUser
            // 
            this.lnkDeleteUser.AutoSize = true;
            this.lnkDeleteUser.Location = new System.Drawing.Point(196, 26);
            this.lnkDeleteUser.Name = "lnkDeleteUser";
            this.lnkDeleteUser.Size = new System.Drawing.Size(63, 13);
            this.lnkDeleteUser.TabIndex = 4;
            this.lnkDeleteUser.TabStop = true;
            this.lnkDeleteUser.Text = "Delete User";
            this.lnkDeleteUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDeleteUser_LinkClicked);
            // 
            // lnkAddUser
            // 
            this.lnkAddUser.AutoSize = true;
            this.lnkAddUser.Location = new System.Drawing.Point(41, 26);
            this.lnkAddUser.Name = "lnkAddUser";
            this.lnkAddUser.Size = new System.Drawing.Size(51, 13);
            this.lnkAddUser.TabIndex = 3;
            this.lnkAddUser.TabStop = true;
            this.lnkAddUser.Text = "Add User";
            this.lnkAddUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddUser_LinkClicked);
            // 
            // ContactUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvwUsers);
            this.Controls.Add(this.controlHeader1);
            this.Name = "ContactUsers";
            this.Size = new System.Drawing.Size(732, 539);
            this.Load += new System.EventHandler(this.ContactUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvwUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlHeader controlHeader1;
        private UI.ObjectListView lvwUsers;
        private System.Windows.Forms.Panel panel1;
        private UI.OLVColumn olvColCommonName;
        private UI.OLVColumn olvColPhoneNumber;
        private UI.OLVColumn olvColEmail;
        private UI.OLVColumn olvColLoginName;
        private System.Windows.Forms.LinkLabel lnkEditUser;
        private System.Windows.Forms.LinkLabel lnkDeleteUser;
        private System.Windows.Forms.LinkLabel lnkAddUser;
    }
}
