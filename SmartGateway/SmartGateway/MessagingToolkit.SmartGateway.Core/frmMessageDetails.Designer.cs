namespace MessagingToolkit.SmartGateway.Core
{
    partial class frmMessageDetails
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
            this.tsMessageDetails = new System.Windows.Forms.ToolStrip();
            this.tsbMessageReply = new System.Windows.Forms.ToolStripButton();
            this.tsbMessageForward = new System.Windows.Forms.ToolStripButton();
            this.tsbMessageDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastUpdate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtScheduled = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpSms = new System.Windows.Forms.GroupBox();
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.etchedLine2 = new MessagingToolkit.UI.Controls.EtchedLine();
            this.etchedLine1 = new MessagingToolkit.UI.Controls.EtchedLine();
            this.grpWapPush = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCreated = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSignal = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtWapPushMessage = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtWapPushUrl = new System.Windows.Forms.TextBox();
            this.tsMessageDetails.SuspendLayout();
            this.grpSms.SuspendLayout();
            this.grpWapPush.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMessageDetails
            // 
            this.tsMessageDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMessageReply,
            this.tsbMessageForward,
            this.tsbMessageDelete,
            this.tsbClose});
            this.tsMessageDetails.Location = new System.Drawing.Point(0, 0);
            this.tsMessageDetails.Name = "tsMessageDetails";
            this.tsMessageDetails.Size = new System.Drawing.Size(678, 54);
            this.tsMessageDetails.TabIndex = 0;
            // 
            // tsbMessageReply
            // 
            this.tsbMessageReply.Image = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.email_reply;
            this.tsbMessageReply.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMessageReply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMessageReply.Name = "tsbMessageReply";
            this.tsbMessageReply.Size = new System.Drawing.Size(40, 51);
            this.tsbMessageReply.Text = "Reply";
            this.tsbMessageReply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMessageReply.Click += new System.EventHandler(this.tsbMessageReply_Click);
            // 
            // tsbMessageForward
            // 
            this.tsbMessageForward.Image = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.email_forward;
            this.tsbMessageForward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMessageForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMessageForward.Name = "tsbMessageForward";
            this.tsbMessageForward.Size = new System.Drawing.Size(54, 51);
            this.tsbMessageForward.Text = "Forward";
            this.tsbMessageForward.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMessageForward.Click += new System.EventHandler(this.tsbMessageForward_Click);
            // 
            // tsbMessageDelete
            // 
            this.tsbMessageDelete.Image = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.email_delete;
            this.tsbMessageDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMessageDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMessageDelete.Name = "tsbMessageDelete";
            this.tsbMessageDelete.Size = new System.Drawing.Size(44, 51);
            this.tsbMessageDelete.Text = "Delete";
            this.tsbMessageDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMessageDelete.Click += new System.EventHandler(this.tsbMessageDelete_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.exit1;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(40, 51);
            this.tsbClose.Text = "Close";
            this.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Menu;
            this.txtID.Location = new System.Drawing.Point(77, 67);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(244, 20);
            this.txtID.TabIndex = 3;
            // 
            // txtType
            // 
            this.txtType.BackColor = System.Drawing.SystemColors.Menu;
            this.txtType.Location = new System.Drawing.Point(77, 89);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(244, 20);
            this.txtType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type";
            // 
            // txtLastUpdate
            // 
            this.txtLastUpdate.BackColor = System.Drawing.SystemColors.Menu;
            this.txtLastUpdate.Location = new System.Drawing.Point(77, 114);
            this.txtLastUpdate.Name = "txtLastUpdate";
            this.txtLastUpdate.ReadOnly = true;
            this.txtLastUpdate.Size = new System.Drawing.Size(244, 20);
            this.txtLastUpdate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last Update";
            // 
            // txtSent
            // 
            this.txtSent.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSent.Location = new System.Drawing.Point(77, 139);
            this.txtSent.Name = "txtSent";
            this.txtSent.ReadOnly = true;
            this.txtSent.Size = new System.Drawing.Size(244, 20);
            this.txtSent.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sent";
            // 
            // txtReceived
            // 
            this.txtReceived.BackColor = System.Drawing.SystemColors.Menu;
            this.txtReceived.Location = new System.Drawing.Point(77, 164);
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ReadOnly = true;
            this.txtReceived.Size = new System.Drawing.Size(244, 20);
            this.txtReceived.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Received";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Menu;
            this.txtStatus.Location = new System.Drawing.Point(423, 139);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(244, 20);
            this.txtStatus.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(358, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Status";
            // 
            // txtReference
            // 
            this.txtReference.BackColor = System.Drawing.SystemColors.Menu;
            this.txtReference.Location = new System.Drawing.Point(423, 114);
            this.txtReference.Name = "txtReference";
            this.txtReference.ReadOnly = true;
            this.txtReference.Size = new System.Drawing.Size(244, 20);
            this.txtReference.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(358, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Reference";
            // 
            // txtChannel
            // 
            this.txtChannel.BackColor = System.Drawing.SystemColors.Menu;
            this.txtChannel.Location = new System.Drawing.Point(423, 89);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.ReadOnly = true;
            this.txtChannel.Size = new System.Drawing.Size(244, 20);
            this.txtChannel.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(358, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Channel";
            // 
            // txtScheduled
            // 
            this.txtScheduled.BackColor = System.Drawing.SystemColors.Menu;
            this.txtScheduled.Location = new System.Drawing.Point(423, 67);
            this.txtScheduled.Name = "txtScheduled";
            this.txtScheduled.ReadOnly = true;
            this.txtScheduled.Size = new System.Drawing.Size(244, 20);
            this.txtScheduled.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(358, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Scheduled";
            // 
            // grpSms
            // 
            this.grpSms.Controls.Add(this.rtbBody);
            this.grpSms.Location = new System.Drawing.Point(5, 307);
            this.grpSms.Name = "grpSms";
            this.grpSms.Size = new System.Drawing.Size(667, 144);
            this.grpSms.TabIndex = 21;
            this.grpSms.TabStop = false;
            this.grpSms.Text = "Body";
            // 
            // rtbBody
            // 
            this.rtbBody.Location = new System.Drawing.Point(7, 19);
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.ReadOnly = true;
            this.rtbBody.Size = new System.Drawing.Size(644, 119);
            this.rtbBody.TabIndex = 0;
            this.rtbBody.Text = "";
            // 
            // txtPriority
            // 
            this.txtPriority.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPriority.Location = new System.Drawing.Point(77, 281);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.ReadOnly = true;
            this.txtPriority.Size = new System.Drawing.Size(538, 20);
            this.txtPriority.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Priority";
            // 
            // txtFormat
            // 
            this.txtFormat.BackColor = System.Drawing.SystemColors.Menu;
            this.txtFormat.Location = new System.Drawing.Point(77, 256);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.ReadOnly = true;
            this.txtFormat.Size = new System.Drawing.Size(538, 20);
            this.txtFormat.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Format";
            // 
            // txtTo
            // 
            this.txtTo.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTo.Location = new System.Drawing.Point(77, 231);
            this.txtTo.Name = "txtTo";
            this.txtTo.ReadOnly = true;
            this.txtTo.Size = new System.Drawing.Size(538, 20);
            this.txtTo.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "To";
            // 
            // txtFrom
            // 
            this.txtFrom.BackColor = System.Drawing.SystemColors.Menu;
            this.txtFrom.Location = new System.Drawing.Point(77, 207);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(538, 20);
            this.txtFrom.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "From";
            // 
            // etchedLine2
            // 
            this.etchedLine2.Location = new System.Drawing.Point(0, 199);
            this.etchedLine2.Name = "etchedLine2";
            this.etchedLine2.Size = new System.Drawing.Size(681, 2);
            this.etchedLine2.TabIndex = 12;
            this.etchedLine2.Text = "etchedLine2";
            // 
            // etchedLine1
            // 
            this.etchedLine1.Location = new System.Drawing.Point(0, 56);
            this.etchedLine1.Name = "etchedLine1";
            this.etchedLine1.Size = new System.Drawing.Size(681, 2);
            this.etchedLine1.TabIndex = 1;
            this.etchedLine1.Text = "etchedLine1";
            // 
            // grpWapPush
            // 
            this.grpWapPush.Controls.Add(this.label16);
            this.grpWapPush.Controls.Add(this.txtExpiry);
            this.grpWapPush.Controls.Add(this.label15);
            this.grpWapPush.Controls.Add(this.txtCreated);
            this.grpWapPush.Controls.Add(this.label14);
            this.grpWapPush.Controls.Add(this.txtSignal);
            this.grpWapPush.Controls.Add(this.label38);
            this.grpWapPush.Controls.Add(this.txtWapPushMessage);
            this.grpWapPush.Controls.Add(this.label37);
            this.grpWapPush.Controls.Add(this.txtWapPushUrl);
            this.grpWapPush.Location = new System.Drawing.Point(5, 307);
            this.grpWapPush.Name = "grpWapPush";
            this.grpWapPush.Size = new System.Drawing.Size(676, 174);
            this.grpWapPush.TabIndex = 55;
            this.grpWapPush.TabStop = false;
            this.grpWapPush.Text = "Body";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(228, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Expiry";
            // 
            // txtExpiry
            // 
            this.txtExpiry.BackColor = System.Drawing.SystemColors.Menu;
            this.txtExpiry.Enabled = false;
            this.txtExpiry.Location = new System.Drawing.Point(290, 139);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.Size = new System.Drawing.Size(158, 20);
            this.txtExpiry.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(10, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Created";
            // 
            // txtCreated
            // 
            this.txtCreated.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCreated.Enabled = false;
            this.txtCreated.Location = new System.Drawing.Point(72, 139);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.Size = new System.Drawing.Size(134, 20);
            this.txtCreated.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(10, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Signal";
            // 
            // txtSignal
            // 
            this.txtSignal.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSignal.Enabled = false;
            this.txtSignal.Location = new System.Drawing.Point(72, 113);
            this.txtSignal.Name = "txtSignal";
            this.txtSignal.Size = new System.Drawing.Size(134, 20);
            this.txtSignal.TabIndex = 26;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(10, 57);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(50, 13);
            this.label38.TabIndex = 23;
            this.label38.Text = "Message";
            // 
            // txtWapPushMessage
            // 
            this.txtWapPushMessage.BackColor = System.Drawing.SystemColors.Menu;
            this.txtWapPushMessage.Enabled = false;
            this.txtWapPushMessage.Location = new System.Drawing.Point(72, 42);
            this.txtWapPushMessage.Multiline = true;
            this.txtWapPushMessage.Name = "txtWapPushMessage";
            this.txtWapPushMessage.Size = new System.Drawing.Size(376, 65);
            this.txtWapPushMessage.TabIndex = 24;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(10, 22);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(29, 13);
            this.label37.TabIndex = 21;
            this.label37.Text = "URL";
            // 
            // txtWapPushUrl
            // 
            this.txtWapPushUrl.BackColor = System.Drawing.SystemColors.Menu;
            this.txtWapPushUrl.Enabled = false;
            this.txtWapPushUrl.Location = new System.Drawing.Point(72, 16);
            this.txtWapPushUrl.Name = "txtWapPushUrl";
            this.txtWapPushUrl.Size = new System.Drawing.Size(434, 20);
            this.txtWapPushUrl.TabIndex = 22;
            // 
            // frmMessageDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 485);
            this.ControlBox = false;
            this.Controls.Add(this.grpWapPush);
            this.Controls.Add(this.txtPriority);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFormat);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.grpSms);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtChannel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtScheduled);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.etchedLine2);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.etchedLine1);
            this.Controls.Add(this.tsMessageDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Details";
            this.Load += new System.EventHandler(this.frmMessageDetails_Load);
            this.tsMessageDetails.ResumeLayout(false);
            this.tsMessageDetails.PerformLayout();
            this.grpSms.ResumeLayout(false);
            this.grpWapPush.ResumeLayout(false);
            this.grpWapPush.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMessageDetails;
        private System.Windows.Forms.ToolStripButton tsbMessageReply;
        private UI.Controls.EtchedLine etchedLine1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.Label label5;
        private UI.Controls.EtchedLine etchedLine2;
        private System.Windows.Forms.ToolStripButton tsbMessageForward;
        private System.Windows.Forms.ToolStripButton tsbMessageDelete;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtScheduled;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpSms;
        private System.Windows.Forms.RichTextBox rtbBody;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpWapPush;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtWapPushMessage;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtWapPushUrl;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCreated;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSignal;
        private System.Windows.Forms.ToolStripButton tsbClose;
    }
}