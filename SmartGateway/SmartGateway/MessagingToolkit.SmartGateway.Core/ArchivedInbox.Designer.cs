namespace MessagingToolkit.SmartGateway.Core
{
    partial class ArchivedInbox
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
            this.lblGatewayID = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbDisplayMessageContent = new System.Windows.Forms.ToolStripButton();
            this.tsbRefreshMessage = new System.Windows.Forms.ToolStripButton();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblIndexes = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMessageType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTimezone = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReceived = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwMessages = new MessagingToolkit.UI.ObjectListView();
            this.olvColFrom = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColType = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColChannel = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColReceivedDate = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColBody = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColLastUpdate = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvwMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGatewayID
            // 
            this.lblGatewayID.AutoSize = true;
            this.lblGatewayID.Location = new System.Drawing.Point(75, 93);
            this.lblGatewayID.Name = "lblGatewayID";
            this.lblGatewayID.Size = new System.Drawing.Size(70, 13);
            this.lblGatewayID.TabIndex = 15;
            this.lblGatewayID.Text = "lblGatewayID";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.rtbContent, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lvwMessages, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(673, 553);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDisplayMessageContent,
            this.tsbRefreshMessage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 514);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(673, 39);
            this.toolStrip1.TabIndex = 12;
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
            // rtbContent
            // 
            this.rtbContent.BackColor = System.Drawing.SystemColors.Window;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Location = new System.Drawing.Point(3, 435);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ReadOnly = true;
            this.rtbContent.Size = new System.Drawing.Size(667, 76);
            this.rtbContent.TabIndex = 11;
            this.rtbContent.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblGatewayID);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblLastUpdate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblIndexes);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblMessageType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblTimezone);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblReceived);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 134);
            this.panel1.TabIndex = 13;
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
            this.lblLastUpdate.Location = new System.Drawing.Point(540, 52);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(72, 13);
            this.lblLastUpdate.TabIndex = 13;
            this.lblLastUpdate.Text = "lblLastUpdate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 52);
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
            // lblIndexes
            // 
            this.lblIndexes.AutoSize = true;
            this.lblIndexes.Location = new System.Drawing.Point(75, 54);
            this.lblIndexes.Name = "lblIndexes";
            this.lblIndexes.Size = new System.Drawing.Size(54, 13);
            this.lblIndexes.TabIndex = 9;
            this.lblIndexes.Text = "lblIndexes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Index(es)";
            // 
            // lblMessageType
            // 
            this.lblMessageType.AutoSize = true;
            this.lblMessageType.Location = new System.Drawing.Point(75, 31);
            this.lblMessageType.Name = "lblMessageType";
            this.lblMessageType.Size = new System.Drawing.Size(84, 13);
            this.lblMessageType.TabIndex = 7;
            this.lblMessageType.Text = "lblMessageType";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Type";
            // 
            // lblTimezone
            // 
            this.lblTimezone.AutoSize = true;
            this.lblTimezone.Location = new System.Drawing.Point(540, 31);
            this.lblTimezone.Name = "lblTimezone";
            this.lblTimezone.Size = new System.Drawing.Size(63, 13);
            this.lblTimezone.TabIndex = 5;
            this.lblTimezone.Text = "lblTimezone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Timezone";
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.Location = new System.Drawing.Point(540, 8);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(63, 13);
            this.lblReceived.TabIndex = 3;
            this.lblReceived.Text = "lblReceived";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Received";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(75, 8);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(40, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "lblFrom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // lvwMessages
            // 
            this.lvwMessages.AllColumns.Add(this.olvColFrom);
            this.lvwMessages.AllColumns.Add(this.olvColType);
            this.lvwMessages.AllColumns.Add(this.olvColChannel);
            this.lvwMessages.AllColumns.Add(this.olvColReceivedDate);
            this.lvwMessages.AllColumns.Add(this.olvColBody);
            this.lvwMessages.AllColumns.Add(this.olvColLastUpdate);
            this.lvwMessages.AllowColumnReorder = true;
            this.lvwMessages.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lvwMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColFrom,
            this.olvColType,
            this.olvColChannel,
            this.olvColReceivedDate,
            this.olvColBody,
            this.olvColLastUpdate});
            this.lvwMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMessages.EmptyListMsg = "No messages available. Press F3 to refresh.";
            this.lvwMessages.FullRowSelect = true;
            this.lvwMessages.HasCollapsibleGroups = false;
            this.lvwMessages.HighlightBackgroundColor = System.Drawing.Color.White;
            this.lvwMessages.Location = new System.Drawing.Point(3, 3);
            this.lvwMessages.Name = "lvwMessages";
            this.lvwMessages.ShowGroups = false;
            this.lvwMessages.Size = new System.Drawing.Size(667, 286);
            this.lvwMessages.TabIndex = 0;
            this.lvwMessages.UseAlternatingBackColors = true;
            this.lvwMessages.UseCompatibleStateImageBehavior = false;
            this.lvwMessages.View = System.Windows.Forms.View.Details;
            this.lvwMessages.SelectedIndexChanged += new System.EventHandler(this.lvwMessages_SelectedIndexChanged);
            this.lvwMessages.DoubleClick += new System.EventHandler(this.lvwMessages_DoubleClick);
            // 
            // olvColFrom
            // 
            this.olvColFrom.Text = "From";
            this.olvColFrom.Width = 100;
            // 
            // olvColType
            // 
            this.olvColType.Text = "Type";
            // 
            // olvColChannel
            // 
            this.olvColChannel.Text = "Channel";
            this.olvColChannel.Width = 100;
            // 
            // olvColReceivedDate
            // 
            this.olvColReceivedDate.Text = "Received Date";
            this.olvColReceivedDate.Width = 100;
            // 
            // olvColBody
            // 
            this.olvColBody.FillsFreeSpace = true;
            this.olvColBody.Text = "Body";
            this.olvColBody.Width = 200;
            // 
            // olvColLastUpdate
            // 
            this.olvColLastUpdate.Text = "Last Update";
            this.olvColLastUpdate.Width = 100;
            // 
            // ArchivedInbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ArchivedInbox";
            this.Size = new System.Drawing.Size(673, 553);
            this.Load += new System.EventHandler(this.ArchivedInbox_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvwMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGatewayID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDisplayMessageContent;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIndexes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMessageType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTimezone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReceived;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label1;
        private UI.ObjectListView lvwMessages;
        private UI.OLVColumn olvColFrom;
        private UI.OLVColumn olvColType;
        private UI.OLVColumn olvColChannel;
        private UI.OLVColumn olvColReceivedDate;
        private UI.OLVColumn olvColLastUpdate;
        private UI.OLVColumn olvColBody;
        private System.Windows.Forms.ToolStripButton tsbRefreshMessage;
    }
}
