namespace MessagingToolkit.SmartGateway.Core
{
    partial class Outbox
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbDisplayMessageContent = new System.Windows.Forms.ToolStripButton();
            this.tsbRefreshMessage = new System.Windows.Forms.ToolStripButton();
            this.lvwMessages = new MessagingToolkit.UI.ObjectListView();
            this.olvColTo = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColStatus = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColChannel = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColScheduled = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColBody = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColLastUpdate = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblURL = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblScheduled = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGatewayID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMessageType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvwMessages)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lvwMessages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtbContent, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(727, 603);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDisplayMessageContent,
            this.tsbRefreshMessage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 564);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(727, 39);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbDisplayMessageContent
            // 
            this.tsbDisplayMessageContent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDisplayMessageContent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbDisplayMessageContent.Image = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.hide_me;
            this.tsbDisplayMessageContent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDisplayMessageContent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisplayMessageContent.Name = "tsbDisplayMessageContent";
            this.tsbDisplayMessageContent.Size = new System.Drawing.Size(34, 36);
            this.tsbDisplayMessageContent.Text = "Hide Message Details";
            this.tsbDisplayMessageContent.Click += new System.EventHandler(this.tsbDisplayMessageContent_Click);
            // 
            // tsbRefreshMessage
            // 
            this.tsbRefreshMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshMessage.Image = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.refresh_view;
            this.tsbRefreshMessage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefreshMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshMessage.Name = "tsbRefreshMessage";
            this.tsbRefreshMessage.Size = new System.Drawing.Size(36, 36);
            this.tsbRefreshMessage.Text = "Refresh Message View";
            this.tsbRefreshMessage.Click += new System.EventHandler(this.tsbRefreshMessage_Click);
            // 
            // lvwMessages
            // 
            this.lvwMessages.AllColumns.Add(this.olvColTo);
            this.lvwMessages.AllColumns.Add(this.olvColStatus);
            this.lvwMessages.AllColumns.Add(this.olvColChannel);
            this.lvwMessages.AllColumns.Add(this.olvColScheduled);
            this.lvwMessages.AllColumns.Add(this.olvColBody);
            this.lvwMessages.AllColumns.Add(this.olvColLastUpdate);
            this.lvwMessages.AllowColumnReorder = true;
            this.lvwMessages.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lvwMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColTo,
            this.olvColStatus,
            this.olvColChannel,
            this.olvColScheduled,
            this.olvColBody,
            this.olvColLastUpdate});
            this.lvwMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMessages.EmptyListMsg = "No messages available. Press F3 to refresh.";
            this.lvwMessages.FullRowSelect = true;
            this.lvwMessages.Location = new System.Drawing.Point(3, 3);
            this.lvwMessages.Name = "lvwMessages";
            this.lvwMessages.OverlayText.Text = "";
            this.lvwMessages.ShowGroups = false;
            this.lvwMessages.Size = new System.Drawing.Size(721, 243);
            this.lvwMessages.TabIndex = 0;
            this.lvwMessages.UseAlternatingBackColors = true;
            this.lvwMessages.UseCompatibleStateImageBehavior = false;
            this.lvwMessages.View = System.Windows.Forms.View.Details;
            this.lvwMessages.SelectedIndexChanged += new System.EventHandler(this.lvwMessages_SelectedIndexChanged);
            this.lvwMessages.DoubleClick += new System.EventHandler(this.lvwMessages_DoubleClick);
            this.lvwMessages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwMessages_KeyDown);
            // 
            // olvColTo
            // 
            this.olvColTo.Text = "To";
            this.olvColTo.Width = 80;
            // 
            // olvColStatus
            // 
            this.olvColStatus.Text = "Status";
            // 
            // olvColChannel
            // 
            this.olvColChannel.Text = "Channel";
            this.olvColChannel.Width = 120;
            // 
            // olvColScheduled
            // 
            this.olvColScheduled.Text = "Scheduled";
            this.olvColScheduled.Width = 90;
            // 
            // olvColBody
            // 
            this.olvColBody.FillsFreeSpace = true;
            this.olvColBody.Text = "Body";
            this.olvColBody.Width = 250;
            // 
            // olvColLastUpdate
            // 
            this.olvColLastUpdate.Text = "Last Update";
            this.olvColLastUpdate.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblURL);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblScheduled);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblGatewayID);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblLastUpdate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblFrom);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblMessageType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblPriority);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblTo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 140);
            this.panel1.TabIndex = 15;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(75, 117);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(39, 13);
            this.lblURL.TabIndex = 19;
            this.lblURL.Text = "lblURL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "URL";
            // 
            // lblScheduled
            // 
            this.lblScheduled.AutoSize = true;
            this.lblScheduled.Location = new System.Drawing.Point(540, 31);
            this.lblScheduled.Name = "lblScheduled";
            this.lblScheduled.Size = new System.Drawing.Size(68, 13);
            this.lblScheduled.TabIndex = 17;
            this.lblScheduled.Text = "lblScheduled";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Scheduled";
            // 
            // lblGatewayID
            // 
            this.lblGatewayID.AutoSize = true;
            this.lblGatewayID.Location = new System.Drawing.Point(75, 95);
            this.lblGatewayID.Name = "lblGatewayID";
            this.lblGatewayID.Size = new System.Drawing.Size(70, 13);
            this.lblGatewayID.TabIndex = 15;
            this.lblGatewayID.Text = "lblGatewayID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Gateway ID";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Location = new System.Drawing.Point(540, 71);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(72, 13);
            this.lblLastUpdate.TabIndex = 13;
            this.lblLastUpdate.Text = "lblLastUpdate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Last Update";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(75, 74);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 13);
            this.lblID.TabIndex = 11;
            this.lblID.Text = "lblID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "ID";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(75, 8);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(40, 13);
            this.lblFrom.TabIndex = 9;
            this.lblFrom.Text = "lblFrom";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "From";
            // 
            // lblMessageType
            // 
            this.lblMessageType.AutoSize = true;
            this.lblMessageType.Location = new System.Drawing.Point(75, 52);
            this.lblMessageType.Name = "lblMessageType";
            this.lblMessageType.Size = new System.Drawing.Size(84, 13);
            this.lblMessageType.TabIndex = 7;
            this.lblMessageType.Text = "lblMessageType";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Type";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(540, 51);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(48, 13);
            this.lblPriority.TabIndex = 5;
            this.lblPriority.Text = "lblPriority";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Priority";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(540, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "lblStatus";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(469, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Status";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(75, 31);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(30, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "lblTo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To";
            // 
            // rtbContent
            // 
            this.rtbContent.BackColor = System.Drawing.SystemColors.Window;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Location = new System.Drawing.Point(3, 398);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ReadOnly = true;
            this.rtbContent.Size = new System.Drawing.Size(721, 163);
            this.rtbContent.TabIndex = 16;
            this.rtbContent.Text = "";
            // 
            // Outbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Outbox";
            this.Size = new System.Drawing.Size(727, 603);
            this.Load += new System.EventHandler(this.Messages_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvwMessages)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UI.ObjectListView lvwMessages;
        private UI.OLVColumn olvColTo;
        private UI.OLVColumn olvColStatus;
        private UI.OLVColumn olvColChannel;
        private UI.OLVColumn olvColScheduled;
        private UI.OLVColumn olvColBody;
        private UI.OLVColumn olvColLastUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGatewayID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMessageType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDisplayMessageContent;
        private System.Windows.Forms.Label lblScheduled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton tsbRefreshMessage;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Label label10;

    }
}
