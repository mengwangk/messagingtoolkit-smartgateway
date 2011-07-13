namespace MessagingToolkit.SmartGateway.Core
{
    partial class ContactGroups
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkEditGroup = new System.Windows.Forms.LinkLabel();
            this.lnkDeleteGroup = new System.Windows.Forms.LinkLabel();
            this.lnkAddGroup = new System.Windows.Forms.LinkLabel();
            this.lvwGroups = new MessagingToolkit.UI.ObjectListView();
            this.olvColName = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColDescription = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.controlHeader1 = new MessagingToolkit.SmartGateway.Core.ControlHeader();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvwGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lvwGroups);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 458);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lnkEditGroup);
            this.panel2.Controls.Add(this.lnkDeleteGroup);
            this.panel2.Controls.Add(this.lnkAddGroup);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 55);
            this.panel2.TabIndex = 1;
            // 
            // lnkEditGroup
            // 
            this.lnkEditGroup.AutoSize = true;
            this.lnkEditGroup.Location = new System.Drawing.Point(104, 20);
            this.lnkEditGroup.Name = "lnkEditGroup";
            this.lnkEditGroup.Size = new System.Drawing.Size(57, 13);
            this.lnkEditGroup.TabIndex = 2;
            this.lnkEditGroup.TabStop = true;
            this.lnkEditGroup.Text = "Edit Group";
            this.lnkEditGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditGroup_LinkClicked);
            // 
            // lnkDeleteGroup
            // 
            this.lnkDeleteGroup.AutoSize = true;
            this.lnkDeleteGroup.Location = new System.Drawing.Point(181, 20);
            this.lnkDeleteGroup.Name = "lnkDeleteGroup";
            this.lnkDeleteGroup.Size = new System.Drawing.Size(70, 13);
            this.lnkDeleteGroup.TabIndex = 1;
            this.lnkDeleteGroup.TabStop = true;
            this.lnkDeleteGroup.Text = "Delete Group";
            this.lnkDeleteGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDeleteGroup_LinkClicked);
            // 
            // lnkAddGroup
            // 
            this.lnkAddGroup.AutoSize = true;
            this.lnkAddGroup.Location = new System.Drawing.Point(26, 20);
            this.lnkAddGroup.Name = "lnkAddGroup";
            this.lnkAddGroup.Size = new System.Drawing.Size(58, 13);
            this.lnkAddGroup.TabIndex = 0;
            this.lnkAddGroup.TabStop = true;
            this.lnkAddGroup.Text = "Add Group";
            this.lnkAddGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddGroup_LinkClicked);
            // 
            // lvwGroups
            // 
            this.lvwGroups.AllColumns.Add(this.olvColName);
            this.lvwGroups.AllColumns.Add(this.olvColDescription);
            this.lvwGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColName,
            this.olvColDescription});
            this.lvwGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGroups.FullRowSelect = true;
            this.lvwGroups.Location = new System.Drawing.Point(0, 0);
            this.lvwGroups.MultiSelect = false;
            this.lvwGroups.Name = "lvwGroups";
            this.lvwGroups.ShowGroups = false;
            this.lvwGroups.Size = new System.Drawing.Size(634, 458);
            this.lvwGroups.TabIndex = 0;
            this.lvwGroups.UseCompatibleStateImageBehavior = false;
            this.lvwGroups.View = System.Windows.Forms.View.Details;
            this.lvwGroups.DoubleClick += new System.EventHandler(this.lvwGroups_DoubleClick);
            // 
            // olvColName
            // 
            this.olvColName.Text = "Name";
            this.olvColName.Width = 120;
            // 
            // olvColDescription
            // 
            this.olvColDescription.FillsFreeSpace = true;
            this.olvColDescription.Text = "Description";
            this.olvColDescription.Width = 120;
            // 
            // controlHeader1
            // 
            this.controlHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHeader1.Location = new System.Drawing.Point(0, 0);
            this.controlHeader1.Logo = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.groups;
            this.controlHeader1.Name = "controlHeader1";
            this.controlHeader1.Size = new System.Drawing.Size(634, 93);
            this.controlHeader1.SubTitle = "Groups";
            this.controlHeader1.TabIndex = 0;
            this.controlHeader1.Title = "MessagingToolkit SmartGateway";
            // 
            // ContactGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlHeader1);
            this.Name = "ContactGroups";
            this.Size = new System.Drawing.Size(634, 551);
            this.Load += new System.EventHandler(this.ContactGroups_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvwGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlHeader controlHeader1;
        private System.Windows.Forms.Panel panel1;
        private UI.ObjectListView lvwGroups;
        private UI.OLVColumn olvColName;
        private UI.OLVColumn olvColDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lnkDeleteGroup;
        private System.Windows.Forms.LinkLabel lnkAddGroup;
        private System.Windows.Forms.LinkLabel lnkEditGroup;
    }
}
