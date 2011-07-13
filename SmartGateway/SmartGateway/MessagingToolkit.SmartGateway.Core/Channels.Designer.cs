namespace MessagingToolkit.SmartGateway.Core
{
    partial class Channels
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Channels));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvwChannels = new MessagingToolkit.UI.ObjectListView();
            this.olvColumn1 = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColumn2 = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColumn3 = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColumn4 = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColumn5 = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkMonitorChannel = new System.Windows.Forms.LinkLabel();
            this.lnkManageChannel = new System.Windows.Forms.LinkLabel();
            this.lnkDeleteChannel = new System.Windows.Forms.LinkLabel();
            this.controlFooter1 = new MessagingToolkit.SmartGateway.Core.ControlFooter();
            this.lnkAddChannel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.controlHeader1 = new MessagingToolkit.SmartGateway.Core.ControlHeader();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvwChannels)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvwChannels);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 483);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // lvwChannels
            // 
            this.lvwChannels.AllColumns.Add(this.olvColumn1);
            this.lvwChannels.AllColumns.Add(this.olvColumn2);
            this.lvwChannels.AllColumns.Add(this.olvColumn3);
            this.lvwChannels.AllColumns.Add(this.olvColumn4);
            this.lvwChannels.AllColumns.Add(this.olvColumn5);
            this.lvwChannels.AllowColumnReorder = true;
            this.lvwChannels.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvwChannels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5});
            this.lvwChannels.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwChannels.FullRowSelect = true;
            this.lvwChannels.LabelWrap = false;
            this.lvwChannels.LargeImageList = this.imageList1;
            this.lvwChannels.Location = new System.Drawing.Point(3, 16);
            this.lvwChannels.Name = "lvwChannels";
            this.lvwChannels.ShowGroups = false;
            this.lvwChannels.Size = new System.Drawing.Size(565, 372);
            this.lvwChannels.SmallImageList = this.imageList1;
            this.lvwChannels.TabIndex = 3;
            this.lvwChannels.UseAlternatingBackColors = true;
            this.lvwChannels.UseCompatibleStateImageBehavior = false;
            this.lvwChannels.View = System.Windows.Forms.View.Details;
            this.lvwChannels.DoubleClick += new System.EventHandler(this.lvwChannels_DoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "ID";
            this.olvColumn1.Width = 100;
            // 
            // olvColumn2
            // 
            this.olvColumn2.Text = "Port";
            this.olvColumn2.Width = 100;
            // 
            // olvColumn3
            // 
            this.olvColumn3.Text = "Baud Rate";
            this.olvColumn3.Width = 120;
            // 
            // olvColumn4
            // 
            this.olvColumn4.Text = "Type";
            this.olvColumn4.Width = 100;
            // 
            // olvColumn5
            // 
            this.olvColumn5.Text = "Protocol";
            this.olvColumn5.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteChannelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 92);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.modifyToolStripMenuItem.Text = "Manage Channel";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripMenuItem.Text = "Monitor Channel";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteChannelToolStripMenuItem
            // 
            this.deleteChannelToolStripMenuItem.Name = "deleteChannelToolStripMenuItem";
            this.deleteChannelToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteChannelToolStripMenuItem.Text = "Delete Channel";
            this.deleteChannelToolStripMenuItem.Click += new System.EventHandler(this.deleteChannelToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bin_closed.png");
            this.imageList1.Images.SetKeyName(1, "phone.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkMonitorChannel);
            this.panel1.Controls.Add(this.lnkManageChannel);
            this.panel1.Controls.Add(this.lnkDeleteChannel);
            this.panel1.Controls.Add(this.controlFooter1);
            this.panel1.Controls.Add(this.lnkAddChannel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 388);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 92);
            this.panel1.TabIndex = 1;
            // 
            // lnkMonitorChannel
            // 
            this.lnkMonitorChannel.AutoSize = true;
            this.lnkMonitorChannel.Location = new System.Drawing.Point(194, 10);
            this.lnkMonitorChannel.Name = "lnkMonitorChannel";
            this.lnkMonitorChannel.Size = new System.Drawing.Size(84, 13);
            this.lnkMonitorChannel.TabIndex = 7;
            this.lnkMonitorChannel.TabStop = true;
            this.lnkMonitorChannel.Text = "Monitor Channel";
            this.lnkMonitorChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMonitorChannel_LinkClicked);
            // 
            // lnkManageChannel
            // 
            this.lnkManageChannel.AutoSize = true;
            this.lnkManageChannel.Location = new System.Drawing.Point(98, 10);
            this.lnkManageChannel.Name = "lnkManageChannel";
            this.lnkManageChannel.Size = new System.Drawing.Size(88, 13);
            this.lnkManageChannel.TabIndex = 6;
            this.lnkManageChannel.TabStop = true;
            this.lnkManageChannel.Text = "Manage Channel";
            this.lnkManageChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkManageChannel_LinkClicked);
            // 
            // lnkDeleteChannel
            // 
            this.lnkDeleteChannel.AutoSize = true;
            this.lnkDeleteChannel.Location = new System.Drawing.Point(444, 10);
            this.lnkDeleteChannel.Name = "lnkDeleteChannel";
            this.lnkDeleteChannel.Size = new System.Drawing.Size(80, 13);
            this.lnkDeleteChannel.TabIndex = 5;
            this.lnkDeleteChannel.TabStop = true;
            this.lnkDeleteChannel.Text = "Delete Channel";
            this.lnkDeleteChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDeleteChannel_LinkClicked);
            // 
            // controlFooter1
            // 
            this.controlFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlFooter1.Location = new System.Drawing.Point(0, 26);
            this.controlFooter1.Message = "Click on the channel for details. Right click for more options.";
            this.controlFooter1.Name = "controlFooter1";
            this.controlFooter1.Size = new System.Drawing.Size(565, 66);
            this.controlFooter1.TabIndex = 4;
            // 
            // lnkAddChannel
            // 
            this.lnkAddChannel.AutoSize = true;
            this.lnkAddChannel.Location = new System.Drawing.Point(19, 10);
            this.lnkAddChannel.Name = "lnkAddChannel";
            this.lnkAddChannel.Size = new System.Drawing.Size(68, 13);
            this.lnkAddChannel.TabIndex = 3;
            this.lnkAddChannel.TabStop = true;
            this.lnkAddChannel.Text = "Add Channel";
            this.lnkAddChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddChannel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // controlHeader1
            // 
            this.controlHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHeader1.Location = new System.Drawing.Point(0, 0);
            this.controlHeader1.Logo = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.connect;
            this.controlHeader1.Name = "controlHeader1";
            this.controlHeader1.Size = new System.Drawing.Size(571, 79);
            this.controlHeader1.SubTitle = "Channels";
            this.controlHeader1.TabIndex = 0;
            this.controlHeader1.Title = "MessagingToolkit SmartGateway";
            // 
            // Channels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.controlHeader1);
            this.Name = "Channels";
            this.Size = new System.Drawing.Size(571, 562);
            this.Load += new System.EventHandler(this.Channels_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvwChannels)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlHeader controlHeader1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkAddChannel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteChannelToolStripMenuItem;
        private ControlFooter controlFooter1;
        private System.Windows.Forms.LinkLabel lnkMonitorChannel;
        private System.Windows.Forms.LinkLabel lnkManageChannel;
        private System.Windows.Forms.LinkLabel lnkDeleteChannel;
        private UI.ObjectListView lvwChannels;
        private UI.OLVColumn olvColumn1;
        private UI.OLVColumn olvColumn2;
        private UI.OLVColumn olvColumn3;
        private UI.OLVColumn olvColumn4;
        private UI.OLVColumn olvColumn5;
    }
}
