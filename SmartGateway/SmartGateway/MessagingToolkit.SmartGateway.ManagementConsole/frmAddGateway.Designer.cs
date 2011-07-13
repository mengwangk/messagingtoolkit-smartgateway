namespace MessagingToolkit.SmartGateway.ManagementConsole
{
    partial class frmAddGateway
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddGateway));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboHandshake = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.updSendWaitInterval = new System.Windows.Forms.NumericUpDown();
            this.chkDisablePinCheck = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.updPollingInterval = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.updSendRetries = new System.Windows.Forms.NumericUpDown();
            this.label83 = new System.Windows.Forms.Label();
            this.txtModelConfig = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.chkDeleteReceivedMessage = new System.Windows.Forms.CheckBox();
            this.txtSmsc = new System.Windows.Forms.TextBox();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkReceiveMessages = new System.Windows.Forms.CheckBox();
            this.chkSendMessages = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkDeleteAfterReceive = new System.Windows.Forms.CheckBox();
            this.cboMessageIndicationOption = new System.Windows.Forms.ComboBox();
            this.chkEnableMessageIndication = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMessageMemory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLongMessage = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updSendWaitInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updPollingInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updSendRetries)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboHandshake);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboStopBits);
            this.groupBox1.Controls.Add(this.cboParity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboDataBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboBaudRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Handshake";
            // 
            // cboHandshake
            // 
            this.cboHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHandshake.FormattingEnabled = true;
            this.cboHandshake.Location = new System.Drawing.Point(308, 68);
            this.cboHandshake.Name = "cboHandshake";
            this.cboHandshake.Size = new System.Drawing.Size(117, 21);
            this.cboHandshake.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Stop Bits";
            // 
            // cboStopBits
            // 
            this.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(308, 44);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(117, 21);
            this.cboStopBits.TabIndex = 11;
            // 
            // cboParity
            // 
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(308, 20);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(117, 21);
            this.cboParity.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Parity";
            // 
            // cboDataBits
            // 
            this.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(72, 68);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(113, 21);
            this.cboDataBits.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data Bits";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Location = new System.Drawing.Point(72, 44);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(113, 21);
            this.cboBaudRate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud Rate";
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(72, 20);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(113, 21);
            this.cboPort.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.updSendWaitInterval);
            this.groupBox2.Controls.Add(this.chkDisablePinCheck);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.updPollingInterval);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtPhoneNumber);
            this.groupBox2.Controls.Add(this.updSendRetries);
            this.groupBox2.Controls.Add(this.label83);
            this.groupBox2.Controls.Add(this.txtModelConfig);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.chkDeleteReceivedMessage);
            this.groupBox2.Controls.Add(this.txtSmsc);
            this.groupBox2.Controls.Add(this.txtPin);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Location = new System.Drawing.Point(5, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gateway Settings";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Model";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(240, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Send Wait Interval";
            // 
            // updSendWaitInterval
            // 
            this.updSendWaitInterval.Location = new System.Drawing.Point(335, 43);
            this.updSendWaitInterval.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.updSendWaitInterval.Name = "updSendWaitInterval";
            this.updSendWaitInterval.Size = new System.Drawing.Size(114, 20);
            this.updSendWaitInterval.TabIndex = 37;
            // 
            // chkDisablePinCheck
            // 
            this.chkDisablePinCheck.AutoSize = true;
            this.chkDisablePinCheck.Location = new System.Drawing.Point(379, 95);
            this.chkDisablePinCheck.Name = "chkDisablePinCheck";
            this.chkDisablePinCheck.Size = new System.Drawing.Size(15, 14);
            this.chkDisablePinCheck.TabIndex = 40;
            this.chkDisablePinCheck.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(240, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Polling Interval";
            // 
            // updPollingInterval
            // 
            this.updPollingInterval.Location = new System.Drawing.Point(335, 18);
            this.updPollingInterval.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.updPollingInterval.Name = "updPollingInterval";
            this.updPollingInterval.Size = new System.Drawing.Size(114, 20);
            this.updPollingInterval.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Send Retries";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(110, 18);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(114, 20);
            this.txtPhoneNumber.TabIndex = 28;
            // 
            // updSendRetries
            // 
            this.updSendRetries.Location = new System.Drawing.Point(110, 115);
            this.updSendRetries.Name = "updSendRetries";
            this.updSendRetries.Size = new System.Drawing.Size(114, 20);
            this.updSendRetries.TabIndex = 35;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(240, 96);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(97, 13);
            this.label83.TabIndex = 39;
            this.label83.Text = "Disable PIN Check";
            // 
            // txtModelConfig
            // 
            this.txtModelConfig.Location = new System.Drawing.Point(110, 92);
            this.txtModelConfig.Name = "txtModelConfig";
            this.txtModelConfig.Size = new System.Drawing.Size(114, 20);
            this.txtModelConfig.TabIndex = 34;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 22);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 13);
            this.label26.TabIndex = 27;
            this.label26.Text = "Own Number";
            // 
            // chkDeleteReceivedMessage
            // 
            this.chkDeleteReceivedMessage.AutoSize = true;
            this.chkDeleteReceivedMessage.Location = new System.Drawing.Point(379, 71);
            this.chkDeleteReceivedMessage.Name = "chkDeleteReceivedMessage";
            this.chkDeleteReceivedMessage.Size = new System.Drawing.Size(15, 14);
            this.chkDeleteReceivedMessage.TabIndex = 38;
            this.chkDeleteReceivedMessage.UseVisualStyleBackColor = true;
            // 
            // txtSmsc
            // 
            this.txtSmsc.Location = new System.Drawing.Point(110, 68);
            this.txtSmsc.Name = "txtSmsc";
            this.txtSmsc.Size = new System.Drawing.Size(114, 20);
            this.txtSmsc.TabIndex = 26;
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(110, 43);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(114, 20);
            this.txtPin.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "SMSC";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "PIN";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(240, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(133, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Delete Received Message";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Location = new System.Drawing.Point(235, 374);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 63);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log Settings";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 17);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.Text = "Error Messages";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(13, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(108, 17);
            this.checkBox2.TabIndex = 41;
            this.checkBox2.Text = "In/Out Messages";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkReceiveMessages);
            this.groupBox4.Controls.Add(this.chkSendMessages);
            this.groupBox4.Location = new System.Drawing.Point(5, 374);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 63);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Functionality";
            // 
            // chkReceiveMessages
            // 
            this.chkReceiveMessages.AutoSize = true;
            this.chkReceiveMessages.Location = new System.Drawing.Point(11, 42);
            this.chkReceiveMessages.Name = "chkReceiveMessages";
            this.chkReceiveMessages.Size = new System.Drawing.Size(117, 17);
            this.chkReceiveMessages.TabIndex = 40;
            this.chkReceiveMessages.Text = "Receive Messages";
            this.chkReceiveMessages.UseVisualStyleBackColor = true;
            // 
            // chkSendMessages
            // 
            this.chkSendMessages.AutoSize = true;
            this.chkSendMessages.Location = new System.Drawing.Point(11, 19);
            this.chkSendMessages.Name = "chkSendMessages";
            this.chkSendMessages.Size = new System.Drawing.Size(102, 17);
            this.chkSendMessages.TabIndex = 39;
            this.chkSendMessages.Text = "Send Messages";
            this.chkSendMessages.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkDeleteAfterReceive);
            this.groupBox6.Controls.Add(this.cboMessageIndicationOption);
            this.groupBox6.Controls.Add(this.chkEnableMessageIndication);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.cboMessageMemory);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.cboLongMessage);
            this.groupBox6.Location = new System.Drawing.Point(5, 277);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(455, 91);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Message Settings";
            // 
            // chkDeleteAfterReceive
            // 
            this.chkDeleteAfterReceive.AutoSize = true;
            this.chkDeleteAfterReceive.Location = new System.Drawing.Point(243, 67);
            this.chkDeleteAfterReceive.Name = "chkDeleteAfterReceive";
            this.chkDeleteAfterReceive.Size = new System.Drawing.Size(125, 17);
            this.chkDeleteAfterReceive.TabIndex = 36;
            this.chkDeleteAfterReceive.Text = "Delete After Receive";
            this.chkDeleteAfterReceive.UseVisualStyleBackColor = true;
            // 
            // cboMessageIndicationOption
            // 
            this.cboMessageIndicationOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessageIndicationOption.Enabled = false;
            this.cboMessageIndicationOption.FormattingEnabled = true;
            this.cboMessageIndicationOption.Location = new System.Drawing.Point(266, 40);
            this.cboMessageIndicationOption.Name = "cboMessageIndicationOption";
            this.cboMessageIndicationOption.Size = new System.Drawing.Size(107, 21);
            this.cboMessageIndicationOption.TabIndex = 35;
            // 
            // chkEnableMessageIndication
            // 
            this.chkEnableMessageIndication.AutoSize = true;
            this.chkEnableMessageIndication.Location = new System.Drawing.Point(243, 19);
            this.chkEnableMessageIndication.Name = "chkEnableMessageIndication";
            this.chkEnableMessageIndication.Size = new System.Drawing.Size(154, 17);
            this.chkEnableMessageIndication.TabIndex = 34;
            this.chkEnableMessageIndication.Text = "Enable Message Indication";
            this.chkEnableMessageIndication.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Memory";
            // 
            // cboMessageMemory
            // 
            this.cboMessageMemory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessageMemory.FormattingEnabled = true;
            this.cboMessageMemory.Location = new System.Drawing.Point(110, 46);
            this.cboMessageMemory.Name = "cboMessageMemory";
            this.cboMessageMemory.Size = new System.Drawing.Size(114, 21);
            this.cboMessageMemory.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Long Message";
            // 
            // cboLongMessage
            // 
            this.cboLongMessage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLongMessage.FormattingEnabled = true;
            this.cboLongMessage.Location = new System.Drawing.Point(110, 19);
            this.cboLongMessage.Name = "cboLongMessage";
            this.cboLongMessage.Size = new System.Drawing.Size(114, 21);
            this.cboLongMessage.TabIndex = 14;
            // 
            // AddGateway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 449);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddGateway";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Gateway";
            this.Load += new System.EventHandler(this.AddGateway_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updSendWaitInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updPollingInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updSendRetries)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboHandshake;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtSmsc;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown updSendWaitInterval;
        private System.Windows.Forms.CheckBox chkDisablePinCheck;
        private System.Windows.Forms.NumericUpDown updPollingInterval;
        private System.Windows.Forms.NumericUpDown updSendRetries;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.TextBox txtModelConfig;
        private System.Windows.Forms.CheckBox chkDeleteReceivedMessage;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboLongMessage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkReceiveMessages;
        private System.Windows.Forms.CheckBox chkSendMessages;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboMessageMemory;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox chkDeleteAfterReceive;
        private System.Windows.Forms.ComboBox cboMessageIndicationOption;
        private System.Windows.Forms.CheckBox chkEnableMessageIndication;
    }
}