namespace MessagingToolkit.SmartGateway.Core
{
    partial class ChannelStatus
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
            
            // Stop the message poller
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
            this.lvwChannelStatus = new MessagingToolkit.UI.ObjectListView();
            this.olvColChannelName = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColPort = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColOperator = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColSignalStrength = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColStatus = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.cmChannel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkRestartChannel = new System.Windows.Forms.LinkLabel();
            this.lnkStopChannel = new System.Windows.Forms.LinkLabel();
            this.controlFooter1 = new MessagingToolkit.SmartGateway.Core.ControlFooter();
            this.lnkStartChannel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lvwChannelStatus)).BeginInit();
            this.cmChannel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwChannelStatus
            // 
            this.lvwChannelStatus.AllColumns.Add(this.olvColChannelName);
            this.lvwChannelStatus.AllColumns.Add(this.olvColPort);
            this.lvwChannelStatus.AllColumns.Add(this.olvColOperator);
            this.lvwChannelStatus.AllColumns.Add(this.olvColSignalStrength);
            this.lvwChannelStatus.AllColumns.Add(this.olvColStatus);
            this.lvwChannelStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColChannelName,
            this.olvColPort,
            this.olvColOperator,
            this.olvColSignalStrength,
            this.olvColStatus});
            this.lvwChannelStatus.ContextMenuStrip = this.cmChannel;
            this.lvwChannelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwChannelStatus.FullRowSelect = true;
            this.lvwChannelStatus.GridLines = true;
            this.lvwChannelStatus.Location = new System.Drawing.Point(0, 0);
            this.lvwChannelStatus.MultiSelect = false;
            this.lvwChannelStatus.Name = "lvwChannelStatus";
            this.lvwChannelStatus.ShowGroups = false;
            this.lvwChannelStatus.Size = new System.Drawing.Size(675, 582);
            this.lvwChannelStatus.TabIndex = 0;
            this.lvwChannelStatus.UseCompatibleStateImageBehavior = false;
            this.lvwChannelStatus.View = System.Windows.Forms.View.Details;
            // 
            // olvColChannelName
            // 
            this.olvColChannelName.Text = "Channel Name";
            this.olvColChannelName.Width = 200;
            // 
            // olvColPort
            // 
            this.olvColPort.Text = "Port";
            // 
            // olvColOperator
            // 
            this.olvColOperator.Text = "Operator Information";
            this.olvColOperator.Width = 120;
            // 
            // olvColSignalStrength
            // 
            this.olvColSignalStrength.Text = "Signal Strength %";
            this.olvColSignalStrength.Width = 100;
            // 
            // olvColStatus
            // 
            this.olvColStatus.FillsFreeSpace = true;
            this.olvColStatus.Text = "Status";
            // 
            // cmChannel
            // 
            this.cmChannel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startChannelToolStripMenuItem,
            this.stopChannelToolStripMenuItem,
            this.restartChannelToolStripMenuItem});
            this.cmChannel.Name = "cmChannel";
            this.cmChannel.Size = new System.Drawing.Size(153, 70);
            // 
            // startChannelToolStripMenuItem
            // 
            this.startChannelToolStripMenuItem.Name = "startChannelToolStripMenuItem";
            this.startChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startChannelToolStripMenuItem.Text = "Start Channel";
            this.startChannelToolStripMenuItem.Click += new System.EventHandler(this.startChannelToolStripMenuItem_Click);
            // 
            // stopChannelToolStripMenuItem
            // 
            this.stopChannelToolStripMenuItem.Name = "stopChannelToolStripMenuItem";
            this.stopChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopChannelToolStripMenuItem.Text = "Stop Channel";
            this.stopChannelToolStripMenuItem.Click += new System.EventHandler(this.stopChannelToolStripMenuItem_Click);
            // 
            // restartChannelToolStripMenuItem
            // 
            this.restartChannelToolStripMenuItem.Name = "restartChannelToolStripMenuItem";
            this.restartChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartChannelToolStripMenuItem.Text = "Restart Channel";
            this.restartChannelToolStripMenuItem.Click += new System.EventHandler(this.restartChannelToolStripMenuItem_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.Location = new System.Drawing.Point(0, 560);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(675, 22);
            this.ssStatus.TabIndex = 1;
            this.ssStatus.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkRestartChannel);
            this.panel1.Controls.Add(this.lnkStopChannel);
            this.panel1.Controls.Add(this.controlFooter1);
            this.panel1.Controls.Add(this.lnkStartChannel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 92);
            this.panel1.TabIndex = 2;
            // 
            // lnkRestartChannel
            // 
            this.lnkRestartChannel.AutoSize = true;
            this.lnkRestartChannel.Location = new System.Drawing.Point(191, 10);
            this.lnkRestartChannel.Name = "lnkRestartChannel";
            this.lnkRestartChannel.Size = new System.Drawing.Size(83, 13);
            this.lnkRestartChannel.TabIndex = 7;
            this.lnkRestartChannel.TabStop = true;
            this.lnkRestartChannel.Text = "Restart Channel";
            this.lnkRestartChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRestartChannel_LinkClicked);
            // 
            // lnkStopChannel
            // 
            this.lnkStopChannel.AutoSize = true;
            this.lnkStopChannel.Location = new System.Drawing.Point(99, 10);
            this.lnkStopChannel.Name = "lnkStopChannel";
            this.lnkStopChannel.Size = new System.Drawing.Size(71, 13);
            this.lnkStopChannel.TabIndex = 6;
            this.lnkStopChannel.TabStop = true;
            this.lnkStopChannel.Text = "Stop Channel";
            this.lnkStopChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkStopChannel_LinkClicked);
            // 
            // controlFooter1
            // 
            this.controlFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlFooter1.Location = new System.Drawing.Point(0, 26);
            this.controlFooter1.Message = "Right on the channel or click on the link to control the channels.";
            this.controlFooter1.Name = "controlFooter1";
            this.controlFooter1.Size = new System.Drawing.Size(675, 66);
            this.controlFooter1.TabIndex = 4;
            // 
            // lnkStartChannel
            // 
            this.lnkStartChannel.AutoSize = true;
            this.lnkStartChannel.Location = new System.Drawing.Point(19, 10);
            this.lnkStartChannel.Name = "lnkStartChannel";
            this.lnkStartChannel.Size = new System.Drawing.Size(71, 13);
            this.lnkStartChannel.TabIndex = 3;
            this.lnkStartChannel.TabStop = true;
            this.lnkStartChannel.Text = "Start Channel";
            this.lnkStartChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkStartChannel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // ChannelStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.lvwChannelStatus);
            this.Name = "ChannelStatus";
            this.Size = new System.Drawing.Size(675, 582);
            this.Load += new System.EventHandler(this.ChannelStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvwChannelStatus)).EndInit();
            this.cmChannel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.ObjectListView lvwChannelStatus;
        private System.Windows.Forms.StatusStrip ssStatus;
        private UI.OLVColumn olvColChannelName;
        private UI.OLVColumn olvColPort;
        private UI.OLVColumn olvColOperator;
        private UI.OLVColumn olvColSignalStrength;
        private UI.OLVColumn olvColStatus;
        private System.Windows.Forms.ContextMenuStrip cmChannel;
        private System.Windows.Forms.ToolStripMenuItem startChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartChannelToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnkRestartChannel;
        private System.Windows.Forms.LinkLabel lnkStopChannel;
        private ControlFooter controlFooter1;
        private System.Windows.Forms.LinkLabel lnkStartChannel;
        private System.Windows.Forms.Label label1;
    }
}
