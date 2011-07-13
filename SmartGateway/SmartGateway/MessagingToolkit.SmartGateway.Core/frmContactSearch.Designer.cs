namespace MessagingToolkit.SmartGateway.Core
{
    partial class frmContactSearch
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwContacts = new MessagingToolkit.UI.ObjectListView();
            this.olvColLogin = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColName = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColPhoneNo = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lvwContacts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwContacts
            // 
            this.lvwContacts.AllColumns.Add(this.olvColLogin);
            this.lvwContacts.AllColumns.Add(this.olvColName);
            this.lvwContacts.AllColumns.Add(this.olvColPhoneNo);
            this.lvwContacts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColLogin,
            this.olvColName,
            this.olvColPhoneNo});
            this.lvwContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwContacts.FullRowSelect = true;
            this.lvwContacts.GridLines = true;
            this.lvwContacts.Location = new System.Drawing.Point(0, 0);
            this.lvwContacts.Name = "lvwContacts";
            this.lvwContacts.ShowGroups = false;
            this.lvwContacts.Size = new System.Drawing.Size(420, 513);
            this.lvwContacts.TabIndex = 0;
            this.lvwContacts.UseCompatibleStateImageBehavior = false;
            this.lvwContacts.View = System.Windows.Forms.View.Details;
            this.lvwContacts.DoubleClick += new System.EventHandler(this.lvwContacts_DoubleClick);
            // 
            // olvColLogin
            // 
            this.olvColLogin.Text = "Login";
            this.olvColLogin.Width = 120;
            // 
            // olvColName
            // 
            this.olvColName.Text = "Name";
            this.olvColName.Width = 150;
            // 
            // olvColPhoneNo
            // 
            this.olvColPhoneNo.FillsFreeSpace = true;
            this.olvColPhoneNo.Text = "Phone Number";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 452);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 61);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(200, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(82, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 34);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmContactSearch
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(420, 513);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvwContacts);
            this.Name = "frmContactSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contact";
            this.Load += new System.EventHandler(this.frmContactSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvwContacts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ObjectListView lvwContacts;
        private UI.OLVColumn olvColLogin;
        private UI.OLVColumn olvColName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private UI.OLVColumn olvColPhoneNo;
    }
}