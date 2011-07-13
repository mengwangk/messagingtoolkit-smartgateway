namespace MessagingToolkit.SmartGateway.Core
{
    partial class frmDatabaseMessenger
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDbPassword = new System.Windows.Forms.TextBox();
            this.txtDbUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkRequireAuthentication = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.npdPollingInterval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDbTable = new System.Windows.Forms.TextBox();
            this.cboDsn = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMessageRecord = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtStatusColUpdateSendingValue = new System.Windows.Forms.TextBox();
            this.txtStatusColUpdateFailedValue = new System.Windows.Forms.TextBox();
            this.txtStatusColUpdateSentValue = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtStatusColValue = new System.Windows.Forms.TextBox();
            this.txtStatusTimestampColName = new System.Windows.Forms.TextBox();
            this.txtStatusColName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkDeleteAfterSending = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboDefaultMsgPriority = new System.Windows.Forms.ComboBox();
            this.txtDefaultTextMsg = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMsgAlertColName = new System.Windows.Forms.TextBox();
            this.txtMsgPriorityColName = new System.Windows.Forms.TextBox();
            this.txtDestNoColName = new System.Windows.Forms.TextBox();
            this.txtMsgColName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radMsgIdDataTypeNumeric = new System.Windows.Forms.RadioButton();
            this.radMsgIdDataTypeString = new System.Windows.Forms.RadioButton();
            this.txtUniqMsgIdColName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabOtherSettings = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdPollingInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabMessageRecord.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabOtherSettings.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDatabase);
            this.tabMain.Controls.Add(this.tabMessageRecord);
            this.tabMain.Controls.Add(this.tabOtherSettings);
            this.tabMain.Location = new System.Drawing.Point(3, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(444, 466);
            this.tabMain.TabIndex = 0;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.groupBox3);
            this.tabDatabase.Controls.Add(this.groupBox2);
            this.tabDatabase.Controls.Add(this.groupBox1);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(436, 440);
            this.tabDatabase.TabIndex = 0;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDbPassword);
            this.groupBox3.Controls.Add(this.txtDbUserName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.chkRequireAuthentication);
            this.groupBox3.Location = new System.Drawing.Point(5, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 128);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtDbPassword
            // 
            this.txtDbPassword.Location = new System.Drawing.Point(83, 82);
            this.txtDbPassword.Name = "txtDbPassword";
            this.txtDbPassword.Size = new System.Drawing.Size(192, 20);
            this.txtDbPassword.TabIndex = 9;
            // 
            // txtDbUserName
            // 
            this.txtDbUserName.Location = new System.Drawing.Point(83, 52);
            this.txtDbUserName.Name = "txtDbUserName";
            this.txtDbUserName.Size = new System.Drawing.Size(192, 20);
            this.txtDbUserName.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "User Name";
            // 
            // chkRequireAuthentication
            // 
            this.chkRequireAuthentication.AutoSize = true;
            this.chkRequireAuthentication.Checked = true;
            this.chkRequireAuthentication.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRequireAuthentication.Location = new System.Drawing.Point(20, 19);
            this.chkRequireAuthentication.Name = "chkRequireAuthentication";
            this.chkRequireAuthentication.Size = new System.Drawing.Size(186, 17);
            this.chkRequireAuthentication.TabIndex = 0;
            this.chkRequireAuthentication.Text = "Require database authentication?";
            this.chkRequireAuthentication.UseVisualStyleBackColor = true;
            this.chkRequireAuthentication.CheckedChanged += new System.EventHandler(this.chkRequireAuthentication_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.npdPollingInterval);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDbTable);
            this.groupBox2.Controls.Add(this.cboDsn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(5, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 135);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "seconds";
            // 
            // npdPollingInterval
            // 
            this.npdPollingInterval.Location = new System.Drawing.Point(153, 91);
            this.npdPollingInterval.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.npdPollingInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.npdPollingInterval.Name = "npdPollingInterval";
            this.npdPollingInterval.Size = new System.Drawing.Size(51, 20);
            this.npdPollingInterval.TabIndex = 6;
            this.npdPollingInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Polling Interval *";
            // 
            // txtDbTable
            // 
            this.txtDbTable.Location = new System.Drawing.Point(153, 57);
            this.txtDbTable.Name = "txtDbTable";
            this.txtDbTable.Size = new System.Drawing.Size(181, 20);
            this.txtDbTable.TabIndex = 4;
            // 
            // cboDsn
            // 
            this.cboDsn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDsn.FormattingEnabled = true;
            this.cboDsn.Location = new System.Drawing.Point(153, 26);
            this.cboDsn.Name = "cboDsn";
            this.cboDsn.Size = new System.Drawing.Size(181, 21);
            this.cboDsn.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Database Table *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data Source Name (DSN) *";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(78, 47);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(258, 59);
            this.txtDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(258, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name *";
            // 
            // tabMessageRecord
            // 
            this.tabMessageRecord.Controls.Add(this.groupBox6);
            this.tabMessageRecord.Controls.Add(this.groupBox5);
            this.tabMessageRecord.Controls.Add(this.groupBox4);
            this.tabMessageRecord.Location = new System.Drawing.Point(4, 22);
            this.tabMessageRecord.Name = "tabMessageRecord";
            this.tabMessageRecord.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessageRecord.Size = new System.Drawing.Size(436, 440);
            this.tabMessageRecord.TabIndex = 1;
            this.tabMessageRecord.Text = "Message Record";
            this.tabMessageRecord.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtStatusColUpdateSendingValue);
            this.groupBox6.Controls.Add(this.txtStatusColUpdateFailedValue);
            this.groupBox6.Controls.Add(this.txtStatusColUpdateSentValue);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.txtStatusColValue);
            this.groupBox6.Controls.Add(this.txtStatusTimestampColName);
            this.groupBox6.Controls.Add(this.txtStatusColName);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.chkDeleteAfterSending);
            this.groupBox6.Location = new System.Drawing.Point(9, 312);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(424, 122);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            // 
            // txtStatusColUpdateSendingValue
            // 
            this.txtStatusColUpdateSendingValue.Location = new System.Drawing.Point(182, 71);
            this.txtStatusColUpdateSendingValue.Name = "txtStatusColUpdateSendingValue";
            this.txtStatusColUpdateSendingValue.Size = new System.Drawing.Size(64, 20);
            this.txtStatusColUpdateSendingValue.TabIndex = 12;
            this.txtStatusColUpdateSendingValue.Text = "SENDING";
            // 
            // txtStatusColUpdateFailedValue
            // 
            this.txtStatusColUpdateFailedValue.Location = new System.Drawing.Point(318, 71);
            this.txtStatusColUpdateFailedValue.Name = "txtStatusColUpdateFailedValue";
            this.txtStatusColUpdateFailedValue.Size = new System.Drawing.Size(52, 20);
            this.txtStatusColUpdateFailedValue.TabIndex = 14;
            this.txtStatusColUpdateFailedValue.Text = "FAILED";
            // 
            // txtStatusColUpdateSentValue
            // 
            this.txtStatusColUpdateSentValue.Location = new System.Drawing.Point(252, 71);
            this.txtStatusColUpdateSentValue.Name = "txtStatusColUpdateSentValue";
            this.txtStatusColUpdateSentValue.Size = new System.Drawing.Size(58, 20);
            this.txtStatusColUpdateSentValue.TabIndex = 13;
            this.txtStatusColUpdateSentValue.Text = "SENT";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 74);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(143, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Status Column Update Value";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Status Column Value";
            // 
            // txtStatusColValue
            // 
            this.txtStatusColValue.Location = new System.Drawing.Point(182, 48);
            this.txtStatusColValue.Name = "txtStatusColValue";
            this.txtStatusColValue.Size = new System.Drawing.Size(80, 20);
            this.txtStatusColValue.TabIndex = 11;
            this.txtStatusColValue.Text = "NEW";
            // 
            // txtStatusTimestampColName
            // 
            this.txtStatusTimestampColName.Location = new System.Drawing.Point(182, 94);
            this.txtStatusTimestampColName.Name = "txtStatusTimestampColName";
            this.txtStatusTimestampColName.Size = new System.Drawing.Size(188, 20);
            this.txtStatusTimestampColName.TabIndex = 15;
            // 
            // txtStatusColName
            // 
            this.txtStatusColName.Location = new System.Drawing.Point(182, 25);
            this.txtStatusColName.Name = "txtStatusColName";
            this.txtStatusColName.Size = new System.Drawing.Size(188, 20);
            this.txtStatusColName.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(160, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Status Timestamp Column Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Status Column Name";
            // 
            // chkDeleteAfterSending
            // 
            this.chkDeleteAfterSending.AutoSize = true;
            this.chkDeleteAfterSending.Location = new System.Drawing.Point(8, 10);
            this.chkDeleteAfterSending.Name = "chkDeleteAfterSending";
            this.chkDeleteAfterSending.Size = new System.Drawing.Size(166, 17);
            this.chkDeleteAfterSending.TabIndex = 9;
            this.chkDeleteAfterSending.Text = "Delete message after sending";
            this.chkDeleteAfterSending.UseVisualStyleBackColor = true;
            this.chkDeleteAfterSending.CheckedChanged += new System.EventHandler(this.chkDeleteAfterSending_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboDefaultMsgPriority);
            this.groupBox5.Controls.Add(this.txtDefaultTextMsg);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtMsgAlertColName);
            this.groupBox5.Controls.Add(this.txtMsgPriorityColName);
            this.groupBox5.Controls.Add(this.txtDestNoColName);
            this.groupBox5.Controls.Add(this.txtMsgColName);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(6, 87);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(425, 219);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // cboDefaultMsgPriority
            // 
            this.cboDefaultMsgPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultMsgPriority.FormattingEnabled = true;
            this.cboDefaultMsgPriority.Location = new System.Drawing.Point(182, 121);
            this.cboDefaultMsgPriority.Name = "cboDefaultMsgPriority";
            this.cboDefaultMsgPriority.Size = new System.Drawing.Size(188, 21);
            this.cboDefaultMsgPriority.TabIndex = 7;
            // 
            // txtDefaultTextMsg
            // 
            this.txtDefaultTextMsg.Location = new System.Drawing.Point(182, 148);
            this.txtDefaultTextMsg.Multiline = true;
            this.txtDefaultTextMsg.Name = "txtDefaultTextMsg";
            this.txtDefaultTextMsg.Size = new System.Drawing.Size(237, 63);
            this.txtDefaultTextMsg.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 156);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Default Text Message";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 124);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(121, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Default Message Priority";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Message Column Name";
            // 
            // txtMsgAlertColName
            // 
            this.txtMsgAlertColName.Location = new System.Drawing.Point(182, 95);
            this.txtMsgAlertColName.Name = "txtMsgAlertColName";
            this.txtMsgAlertColName.Size = new System.Drawing.Size(188, 20);
            this.txtMsgAlertColName.TabIndex = 6;
            // 
            // txtMsgPriorityColName
            // 
            this.txtMsgPriorityColName.Location = new System.Drawing.Point(182, 71);
            this.txtMsgPriorityColName.Name = "txtMsgPriorityColName";
            this.txtMsgPriorityColName.Size = new System.Drawing.Size(188, 20);
            this.txtMsgPriorityColName.TabIndex = 5;
            // 
            // txtDestNoColName
            // 
            this.txtDestNoColName.Location = new System.Drawing.Point(182, 45);
            this.txtDestNoColName.Name = "txtDestNoColName";
            this.txtDestNoColName.Size = new System.Drawing.Size(188, 20);
            this.txtDestNoColName.TabIndex = 4;
            // 
            // txtMsgColName
            // 
            this.txtMsgColName.Location = new System.Drawing.Point(182, 19);
            this.txtMsgColName.Name = "txtMsgColName";
            this.txtMsgColName.Size = new System.Drawing.Size(188, 20);
            this.txtMsgColName.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Message Alert Column Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Message Priority Column Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Destination Number Column Name *";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radMsgIdDataTypeNumeric);
            this.groupBox4.Controls.Add(this.radMsgIdDataTypeString);
            this.groupBox4.Controls.Add(this.txtUniqMsgIdColName);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(424, 76);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // radMsgIdDataTypeNumeric
            // 
            this.radMsgIdDataTypeNumeric.AutoSize = true;
            this.radMsgIdDataTypeNumeric.Location = new System.Drawing.Point(283, 50);
            this.radMsgIdDataTypeNumeric.Name = "radMsgIdDataTypeNumeric";
            this.radMsgIdDataTypeNumeric.Size = new System.Drawing.Size(64, 17);
            this.radMsgIdDataTypeNumeric.TabIndex = 3;
            this.radMsgIdDataTypeNumeric.TabStop = true;
            this.radMsgIdDataTypeNumeric.Text = "Numeric";
            this.radMsgIdDataTypeNumeric.UseVisualStyleBackColor = true;
            // 
            // radMsgIdDataTypeString
            // 
            this.radMsgIdDataTypeString.AutoSize = true;
            this.radMsgIdDataTypeString.Checked = true;
            this.radMsgIdDataTypeString.Location = new System.Drawing.Point(197, 50);
            this.radMsgIdDataTypeString.Name = "radMsgIdDataTypeString";
            this.radMsgIdDataTypeString.Size = new System.Drawing.Size(52, 17);
            this.radMsgIdDataTypeString.TabIndex = 2;
            this.radMsgIdDataTypeString.TabStop = true;
            this.radMsgIdDataTypeString.Text = "String";
            this.radMsgIdDataTypeString.UseVisualStyleBackColor = true;
            // 
            // txtUniqMsgIdColName
            // 
            this.txtUniqMsgIdColName.Location = new System.Drawing.Point(196, 24);
            this.txtUniqMsgIdColName.Name = "txtUniqMsgIdColName";
            this.txtUniqMsgIdColName.Size = new System.Drawing.Size(201, 20);
            this.txtUniqMsgIdColName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Unique Message ID Column Name *";
            // 
            // tabOtherSettings
            // 
            this.tabOtherSettings.Controls.Add(this.groupBox7);
            this.tabOtherSettings.Location = new System.Drawing.Point(4, 22);
            this.tabOtherSettings.Name = "tabOtherSettings";
            this.tabOtherSettings.Size = new System.Drawing.Size(436, 440);
            this.tabOtherSettings.TabIndex = 2;
            this.tabOtherSettings.Text = "Other Settings";
            this.tabOtherSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkAutoStart);
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(426, 88);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(23, 31);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(157, 17);
            this.chkAutoStart.TabIndex = 0;
            this.chkAutoStart.Text = "Run automatically at startup";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(251, 484);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(357, 484);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDatabaseMessenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 528);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabMain);
            this.Name = "frmDatabaseMessenger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Database Messenger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDatabaseMessenger_FormClosing);
            this.Load += new System.EventHandler(this.frmDatabaseMessenger_Load);
            this.Shown += new System.EventHandler(this.frmDatabaseMessenger_Shown);
            this.tabMain.ResumeLayout(false);
            this.tabDatabase.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdPollingInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabMessageRecord.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabOtherSettings.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.TabPage tabMessageRecord;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabOtherSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDbTable;
        private System.Windows.Forms.ComboBox cboDsn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown npdPollingInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDbPassword;
        private System.Windows.Forms.TextBox txtDbUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkRequireAuthentication;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtUniqMsgIdColName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radMsgIdDataTypeNumeric;
        private System.Windows.Forms.RadioButton radMsgIdDataTypeString;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMsgPriorityColName;
        private System.Windows.Forms.TextBox txtDestNoColName;
        private System.Windows.Forms.TextBox txtMsgColName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtStatusTimestampColName;
        private System.Windows.Forms.TextBox txtStatusColName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkDeleteAfterSending;
        private System.Windows.Forms.ComboBox cboDefaultMsgPriority;
        private System.Windows.Forms.TextBox txtDefaultTextMsg;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMsgAlertColName;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtStatusColValue;
        private System.Windows.Forms.TextBox txtStatusColUpdateSentValue;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtStatusColUpdateFailedValue;
        private System.Windows.Forms.TextBox txtStatusColUpdateSendingValue;
    }
}