namespace MessagingToolkit.SmartGateway.Core
{
    partial class DatabaseMessenger
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

            // Stop the poller
            StopPoller();
            
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvwDbMessenger = new MessagingToolkit.UI.ObjectListView();
            this.olvColName = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColDescription = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColStatus = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startMessengerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMessengerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkManageMessenger = new System.Windows.Forms.LinkLabel();
            this.lnkDeleteMessenger = new System.Windows.Forms.LinkLabel();
            this.controlFooter1 = new MessagingToolkit.SmartGateway.Core.ControlFooter();
            this.lnkAddMessenger = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.lvwDbMessenger)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwDbMessenger
            // 
            this.lvwDbMessenger.AllColumns.Add(this.olvColName);
            this.lvwDbMessenger.AllColumns.Add(this.olvColDescription);
            this.lvwDbMessenger.AllColumns.Add(this.olvColStatus);
            this.lvwDbMessenger.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColName,
            this.olvColDescription,
            this.olvColStatus});
            this.lvwDbMessenger.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwDbMessenger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDbMessenger.FullRowSelect = true;
            this.lvwDbMessenger.Location = new System.Drawing.Point(0, 0);
            this.lvwDbMessenger.Name = "lvwDbMessenger";
            this.lvwDbMessenger.ShowGroups = false;
            this.lvwDbMessenger.Size = new System.Drawing.Size(668, 633);
            this.lvwDbMessenger.TabIndex = 0;
            this.lvwDbMessenger.UseCompatibleStateImageBehavior = false;
            this.lvwDbMessenger.View = System.Windows.Forms.View.Details;
            this.lvwDbMessenger.DoubleClick += new System.EventHandler(this.olvDbMessenger_DoubleClick);
            // 
            // olvColName
            // 
            this.olvColName.Text = "Name";
            this.olvColName.Width = 100;
            // 
            // olvColDescription
            // 
            this.olvColDescription.Text = "Description";
            this.olvColDescription.Width = 400;
            // 
            // olvColStatus
            // 
            this.olvColStatus.FillsFreeSpace = true;
            this.olvColStatus.Text = "Status";
            this.olvColStatus.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMessengerToolStripMenuItem,
            this.stopMessengerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.manageToolStripMenuItem,
            this.deleteChannelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 120);
            // 
            // startMessengerToolStripMenuItem
            // 
            this.startMessengerToolStripMenuItem.Name = "startMessengerToolStripMenuItem";
            this.startMessengerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.startMessengerToolStripMenuItem.Text = "Start Messenger";
            this.startMessengerToolStripMenuItem.Click += new System.EventHandler(this.startMessengerToolStripMenuItem_Click);
            // 
            // stopMessengerToolStripMenuItem
            // 
            this.stopMessengerToolStripMenuItem.Name = "stopMessengerToolStripMenuItem";
            this.stopMessengerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.stopMessengerToolStripMenuItem.Text = "Stop Messenger";
            this.stopMessengerToolStripMenuItem.Click += new System.EventHandler(this.stopMessengerToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.manageToolStripMenuItem.Text = "Edit Messenger";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // deleteChannelToolStripMenuItem
            // 
            this.deleteChannelToolStripMenuItem.Name = "deleteChannelToolStripMenuItem";
            this.deleteChannelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deleteChannelToolStripMenuItem.Text = "Delete Messenger";
            this.deleteChannelToolStripMenuItem.Click += new System.EventHandler(this.deleteChannelToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkManageMessenger);
            this.panel1.Controls.Add(this.lnkDeleteMessenger);
            this.panel1.Controls.Add(this.controlFooter1);
            this.panel1.Controls.Add(this.lnkAddMessenger);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 541);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 92);
            this.panel1.TabIndex = 2;
            // 
            // lnkManageMessenger
            // 
            this.lnkManageMessenger.AutoSize = true;
            this.lnkManageMessenger.Location = new System.Drawing.Point(106, 10);
            this.lnkManageMessenger.Name = "lnkManageMessenger";
            this.lnkManageMessenger.Size = new System.Drawing.Size(101, 13);
            this.lnkManageMessenger.TabIndex = 6;
            this.lnkManageMessenger.TabStop = true;
            this.lnkManageMessenger.Text = "Manage Messenger";
            this.lnkManageMessenger.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkManageMessenger_LinkClicked);
            // 
            // lnkDeleteMessenger
            // 
            this.lnkDeleteMessenger.AutoSize = true;
            this.lnkDeleteMessenger.Location = new System.Drawing.Point(271, 10);
            this.lnkDeleteMessenger.Name = "lnkDeleteMessenger";
            this.lnkDeleteMessenger.Size = new System.Drawing.Size(93, 13);
            this.lnkDeleteMessenger.TabIndex = 5;
            this.lnkDeleteMessenger.TabStop = true;
            this.lnkDeleteMessenger.Text = "Delete Messenger";
            this.lnkDeleteMessenger.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDeleteMessenger_LinkClicked);
            // 
            // controlFooter1
            // 
            this.controlFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlFooter1.Location = new System.Drawing.Point(0, 26);
            this.controlFooter1.Message = "Click on the messenger for details. Right click for more options.";
            this.controlFooter1.Name = "controlFooter1";
            this.controlFooter1.Size = new System.Drawing.Size(668, 66);
            this.controlFooter1.TabIndex = 4;
            // 
            // lnkAddMessenger
            // 
            this.lnkAddMessenger.AutoSize = true;
            this.lnkAddMessenger.Location = new System.Drawing.Point(19, 10);
            this.lnkAddMessenger.Name = "lnkAddMessenger";
            this.lnkAddMessenger.Size = new System.Drawing.Size(81, 13);
            this.lnkAddMessenger.TabIndex = 3;
            this.lnkAddMessenger.TabStop = true;
            this.lnkAddMessenger.Text = "Add Messenger";
            this.lnkAddMessenger.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddMessenger_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // DatabaseMessenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvwDbMessenger);
            this.Name = "DatabaseMessenger";
            this.Size = new System.Drawing.Size(668, 633);
            this.Load += new System.EventHandler(this.DatabaseMessenger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvwDbMessenger)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ObjectListView lvwDbMessenger;
        private UI.OLVColumn olvColName;
        private UI.OLVColumn olvColDescription;
        private UI.OLVColumn olvColStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnkManageMessenger;
        private System.Windows.Forms.LinkLabel lnkDeleteMessenger;
        private ControlFooter controlFooter1;
        private System.Windows.Forms.LinkLabel lnkAddMessenger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopMessengerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMessengerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}
