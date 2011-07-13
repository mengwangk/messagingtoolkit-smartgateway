namespace MessagingToolkit.SmartGateway.Core
{
    partial class NewMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMessage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabNewMessage = new System.Windows.Forms.TabPage();
            this.pnlWapPush = new System.Windows.Forms.Panel();
            this.dtpWapPushExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.chkWapPushExpiry = new System.Windows.Forms.CheckBox();
            this.dtpWapPushCreated = new System.Windows.Forms.DateTimePicker();
            this.chkWapPushCreated = new System.Windows.Forms.CheckBox();
            this.cboWapPushSignal = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtWapPushMessage = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtWapPushUrl = new System.Windows.Forms.TextBox();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.txtMessageContent = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboStatusReport = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMessageType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkScheduleSendTime = new System.Windows.Forms.CheckBox();
            this.btnBrowseTo = new System.Windows.Forms.Button();
            this.npdQuantity = new System.Windows.Forms.NumericUpDown();
            this.dtpScheduleTime = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboMessageFormat = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboChannel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabAdvancedSettings = new System.Windows.Forms.TabPage();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.npdDestinationPort = new System.Windows.Forms.NumericUpDown();
            this.npdSourcePort = new System.Windows.Forms.NumericUpDown();
            this.cboMessageClass = new System.Windows.Forms.ComboBox();
            this.label92 = new System.Windows.Forms.Label();
            this.controlFooter1 = new MessagingToolkit.SmartGateway.Core.ControlFooter();
            this.controlHeader1 = new MessagingToolkit.SmartGateway.Core.ControlHeader();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabNewMessage.SuspendLayout();
            this.pnlWapPush.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdQuantity)).BeginInit();
            this.tabAdvancedSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdDestinationPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdSourcePort)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.controlFooter1);
            this.panel1.Controls.Add(this.controlHeader1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.tabMain);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCreate);
            this.panel4.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // btnCreate
            // 
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabNewMessage);
            this.tabMain.Controls.Add(this.tabAdvancedSettings);
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            // 
            // tabNewMessage
            // 
            this.tabNewMessage.Controls.Add(this.pnlWapPush);
            this.tabNewMessage.Controls.Add(this.pnlMessage);
            this.tabNewMessage.Controls.Add(this.cboStatusReport);
            this.tabNewMessage.Controls.Add(this.label2);
            this.tabNewMessage.Controls.Add(this.cboMessageType);
            this.tabNewMessage.Controls.Add(this.label1);
            this.tabNewMessage.Controls.Add(this.chkScheduleSendTime);
            this.tabNewMessage.Controls.Add(this.btnBrowseTo);
            this.tabNewMessage.Controls.Add(this.npdQuantity);
            this.tabNewMessage.Controls.Add(this.dtpScheduleTime);
            this.tabNewMessage.Controls.Add(this.label12);
            this.tabNewMessage.Controls.Add(this.cboPriority);
            this.tabNewMessage.Controls.Add(this.label9);
            this.tabNewMessage.Controls.Add(this.cboMessageFormat);
            this.tabNewMessage.Controls.Add(this.label8);
            this.tabNewMessage.Controls.Add(this.txtTo);
            this.tabNewMessage.Controls.Add(this.label7);
            this.tabNewMessage.Controls.Add(this.txtFrom);
            this.tabNewMessage.Controls.Add(this.label6);
            this.tabNewMessage.Controls.Add(this.cboChannel);
            this.tabNewMessage.Controls.Add(this.label5);
            resources.ApplyResources(this.tabNewMessage, "tabNewMessage");
            this.tabNewMessage.Name = "tabNewMessage";
            this.tabNewMessage.UseVisualStyleBackColor = true;
            // 
            // pnlWapPush
            // 
            this.pnlWapPush.Controls.Add(this.dtpWapPushExpiryDate);
            this.pnlWapPush.Controls.Add(this.chkWapPushExpiry);
            this.pnlWapPush.Controls.Add(this.dtpWapPushCreated);
            this.pnlWapPush.Controls.Add(this.chkWapPushCreated);
            this.pnlWapPush.Controls.Add(this.cboWapPushSignal);
            this.pnlWapPush.Controls.Add(this.label39);
            this.pnlWapPush.Controls.Add(this.label38);
            this.pnlWapPush.Controls.Add(this.txtWapPushMessage);
            this.pnlWapPush.Controls.Add(this.label37);
            this.pnlWapPush.Controls.Add(this.txtWapPushUrl);
            resources.ApplyResources(this.pnlWapPush, "pnlWapPush");
            this.pnlWapPush.Name = "pnlWapPush";
            // 
            // dtpWapPushExpiryDate
            // 
            this.dtpWapPushExpiryDate.Checked = false;
            resources.ApplyResources(this.dtpWapPushExpiryDate, "dtpWapPushExpiryDate");
            this.dtpWapPushExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWapPushExpiryDate.Name = "dtpWapPushExpiryDate";
            // 
            // chkWapPushExpiry
            // 
            resources.ApplyResources(this.chkWapPushExpiry, "chkWapPushExpiry");
            this.chkWapPushExpiry.Name = "chkWapPushExpiry";
            this.chkWapPushExpiry.UseVisualStyleBackColor = true;
            this.chkWapPushExpiry.CheckedChanged += new System.EventHandler(this.chkWapPushExpiry_CheckedChanged);
            // 
            // dtpWapPushCreated
            // 
            this.dtpWapPushCreated.Checked = false;
            resources.ApplyResources(this.dtpWapPushCreated, "dtpWapPushCreated");
            this.dtpWapPushCreated.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWapPushCreated.Name = "dtpWapPushCreated";
            // 
            // chkWapPushCreated
            // 
            resources.ApplyResources(this.chkWapPushCreated, "chkWapPushCreated");
            this.chkWapPushCreated.Name = "chkWapPushCreated";
            this.chkWapPushCreated.UseVisualStyleBackColor = true;
            this.chkWapPushCreated.CheckedChanged += new System.EventHandler(this.chkWapPushCreated_CheckedChanged);
            // 
            // cboWapPushSignal
            // 
            this.cboWapPushSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWapPushSignal.FormattingEnabled = true;
            resources.ApplyResources(this.cboWapPushSignal, "cboWapPushSignal");
            this.cboWapPushSignal.Name = "cboWapPushSignal";
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // txtWapPushMessage
            // 
            resources.ApplyResources(this.txtWapPushMessage, "txtWapPushMessage");
            this.txtWapPushMessage.Name = "txtWapPushMessage";
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // txtWapPushUrl
            // 
            resources.ApplyResources(this.txtWapPushUrl, "txtWapPushUrl");
            this.txtWapPushUrl.Name = "txtWapPushUrl";
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.txtMessageContent);
            this.pnlMessage.Controls.Add(this.label10);
            resources.ApplyResources(this.pnlMessage, "pnlMessage");
            this.pnlMessage.Name = "pnlMessage";
            // 
            // txtMessageContent
            // 
            this.txtMessageContent.AcceptsReturn = true;
            this.txtMessageContent.AcceptsTab = true;
            this.txtMessageContent.AllowDrop = true;
            resources.ApplyResources(this.txtMessageContent, "txtMessageContent");
            this.txtMessageContent.Name = "txtMessageContent";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // cboStatusReport
            // 
            this.cboStatusReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusReport.FormattingEnabled = true;
            resources.ApplyResources(this.cboStatusReport, "cboStatusReport");
            this.cboStatusReport.Name = "cboStatusReport";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cboMessageType
            // 
            this.cboMessageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessageType.FormattingEnabled = true;
            resources.ApplyResources(this.cboMessageType, "cboMessageType");
            this.cboMessageType.Name = "cboMessageType";
            this.cboMessageType.SelectedIndexChanged += new System.EventHandler(this.cboMessageType_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkScheduleSendTime
            // 
            resources.ApplyResources(this.chkScheduleSendTime, "chkScheduleSendTime");
            this.chkScheduleSendTime.Name = "chkScheduleSendTime";
            this.chkScheduleSendTime.UseVisualStyleBackColor = true;
            this.chkScheduleSendTime.CheckedChanged += new System.EventHandler(this.chkScheduleSendTime_CheckedChanged);
            // 
            // btnBrowseTo
            // 
            resources.ApplyResources(this.btnBrowseTo, "btnBrowseTo");
            this.btnBrowseTo.Name = "btnBrowseTo";
            this.btnBrowseTo.UseVisualStyleBackColor = true;
            this.btnBrowseTo.Click += new System.EventHandler(this.btnBrowseTo_Click);
            // 
            // npdQuantity
            // 
            resources.ApplyResources(this.npdQuantity, "npdQuantity");
            this.npdQuantity.Name = "npdQuantity";
            this.npdQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpScheduleTime
            // 
            resources.ApplyResources(this.dtpScheduleTime, "dtpScheduleTime");
            this.dtpScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScheduleTime.Name = "dtpScheduleTime";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // cboPriority
            // 
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.FormattingEnabled = true;
            resources.ApplyResources(this.cboPriority, "cboPriority");
            this.cboPriority.Name = "cboPriority";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // cboMessageFormat
            // 
            this.cboMessageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessageFormat.FormattingEnabled = true;
            resources.ApplyResources(this.cboMessageFormat, "cboMessageFormat");
            this.cboMessageFormat.Name = "cboMessageFormat";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtTo
            // 
            resources.ApplyResources(this.txtTo, "txtTo");
            this.txtTo.Name = "txtTo";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtFrom
            // 
            resources.ApplyResources(this.txtFrom, "txtFrom");
            this.txtFrom.Name = "txtFrom";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cboChannel
            // 
            this.cboChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChannel.FormattingEnabled = true;
            resources.ApplyResources(this.cboChannel, "cboChannel");
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.SelectedIndexChanged += new System.EventHandler(this.cboChannel_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tabAdvancedSettings
            // 
            this.tabAdvancedSettings.Controls.Add(this.label52);
            this.tabAdvancedSettings.Controls.Add(this.label51);
            this.tabAdvancedSettings.Controls.Add(this.npdDestinationPort);
            this.tabAdvancedSettings.Controls.Add(this.npdSourcePort);
            this.tabAdvancedSettings.Controls.Add(this.cboMessageClass);
            this.tabAdvancedSettings.Controls.Add(this.label92);
            resources.ApplyResources(this.tabAdvancedSettings, "tabAdvancedSettings");
            this.tabAdvancedSettings.Name = "tabAdvancedSettings";
            this.tabAdvancedSettings.UseVisualStyleBackColor = true;
            // 
            // label52
            // 
            resources.ApplyResources(this.label52, "label52");
            this.label52.Name = "label52";
            // 
            // label51
            // 
            resources.ApplyResources(this.label51, "label51");
            this.label51.Name = "label51";
            // 
            // npdDestinationPort
            // 
            resources.ApplyResources(this.npdDestinationPort, "npdDestinationPort");
            this.npdDestinationPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.npdDestinationPort.Name = "npdDestinationPort";
            // 
            // npdSourcePort
            // 
            resources.ApplyResources(this.npdSourcePort, "npdSourcePort");
            this.npdSourcePort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.npdSourcePort.Name = "npdSourcePort";
            // 
            // cboMessageClass
            // 
            this.cboMessageClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessageClass.FormattingEnabled = true;
            resources.ApplyResources(this.cboMessageClass, "cboMessageClass");
            this.cboMessageClass.Name = "cboMessageClass";
            // 
            // label92
            // 
            resources.ApplyResources(this.label92, "label92");
            this.label92.Name = "label92";
            // 
            // controlFooter1
            // 
            resources.ApplyResources(this.controlFooter1, "controlFooter1");
            this.controlFooter1.Message = "To send to multiple recipients, separate the numbers by comma or semicolon.";
            this.controlFooter1.Name = "controlFooter1";
            // 
            // controlHeader1
            // 
            resources.ApplyResources(this.controlHeader1, "controlHeader1");
            this.controlHeader1.Logo = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.newmessage;
            this.controlHeader1.Name = "controlHeader1";
            this.controlHeader1.SubTitle = "Create New Message";
            this.controlHeader1.Title = "MessagingToolkit SmartGateway";
            // 
            // NewMessage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "NewMessage";
            this.Load += new System.EventHandler(this.NewMessage_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabNewMessage.ResumeLayout(false);
            this.tabNewMessage.PerformLayout();
            this.pnlWapPush.ResumeLayout(false);
            this.pnlWapPush.PerformLayout();
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdQuantity)).EndInit();
            this.tabAdvancedSettings.ResumeLayout(false);
            this.tabAdvancedSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdDestinationPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdSourcePort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ControlHeader controlHeader1;
        private ControlFooter controlFooter1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabNewMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowseTo;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.NumericUpDown npdQuantity;
        private System.Windows.Forms.DateTimePicker dtpScheduleTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboMessageFormat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboChannel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabAdvancedSettings;
        private System.Windows.Forms.ComboBox cboMessageClass;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericUpDown npdDestinationPort;
        private System.Windows.Forms.NumericUpDown npdSourcePort;
        private System.Windows.Forms.CheckBox chkScheduleSendTime;
        private System.Windows.Forms.ComboBox cboMessageType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.ComboBox cboStatusReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtMessageContent;
        private System.Windows.Forms.Panel pnlWapPush;
        private System.Windows.Forms.DateTimePicker dtpWapPushExpiryDate;
        private System.Windows.Forms.CheckBox chkWapPushExpiry;
        private System.Windows.Forms.DateTimePicker dtpWapPushCreated;
        private System.Windows.Forms.CheckBox chkWapPushCreated;
        private System.Windows.Forms.ComboBox cboWapPushSignal;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtWapPushMessage;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtWapPushUrl;
    }
}
