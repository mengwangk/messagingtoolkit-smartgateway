namespace MessagingToolkit.SmartGateway.ManagementConsole
{
    partial class ControlPanel1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel1));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveLogFolder = new System.Windows.Forms.Button();
            this.btnBrowserLogFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditGateway = new System.Windows.Forms.Button();
            this.btnRemoveGateway = new System.Windows.Forms.Button();
            this.btnAddGateway = new System.Windows.Forms.Button();
            this.dgdGateway = new System.Windows.Forms.DataGridView();
            this.tabServices = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStopAllGateway = new System.Windows.Forms.Button();
            this.btnStopGateway = new System.Windows.Forms.Button();
            this.btnRefreshGateway = new System.Windows.Forms.Button();
            this.btnRunAllGateway = new System.Windows.Forms.Button();
            this.btnRunGateway = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPreferences = new System.Windows.Forms.TabPage();
            this.tabDiagnostics = new System.Windows.Forms.TabPage();
            this.tabScheduler = new System.Windows.Forms.TabPage();
            this.tabIncomingRules = new System.Windows.Forms.TabPage();
            this.tabCommandLine = new System.Windows.Forms.TabPage();
            this.tabWeb = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lnkWebPortal = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowseApplicationDirectory = new System.Windows.Forms.Button();
            this.btnStopWebApplication = new System.Windows.Forms.Button();
            this.lblWebApplicationStatus = new System.Windows.Forms.Label();
            this.btnStartWebApplication = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAutoStartWebApplication = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVirtualRoot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApplicationDirectory = new System.Windows.Forms.TextBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.serverController = new System.ServiceProcess.ServiceController();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssAppStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMSCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.functionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gatewayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabMain.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdGateway)).BeginInit();
            this.tabServices.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabWeb.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gatewayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabConfiguration);
            this.tabMain.Controls.Add(this.tabServices);
            this.tabMain.Controls.Add(this.tabPreferences);
            this.tabMain.Controls.Add(this.tabDiagnostics);
            this.tabMain.Controls.Add(this.tabScheduler);
            this.tabMain.Controls.Add(this.tabIncomingRules);
            this.tabMain.Controls.Add(this.tabCommandLine);
            this.tabMain.Controls.Add(this.tabWeb);
            this.tabMain.Controls.Add(this.tabAbout);
            this.tabMain.Location = new System.Drawing.Point(-1, 12);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(762, 463);
            this.tabMain.TabIndex = 0;
            this.tabMain.Click += new System.EventHandler(this.tabMain_Click);
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.groupBox2);
            this.tabConfiguration.Controls.Add(this.groupBox1);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguration.Size = new System.Drawing.Size(754, 437);
            this.tabConfiguration.TabIndex = 0;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveLogFolder);
            this.groupBox2.Controls.Add(this.btnBrowserLogFolder);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(3, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 84);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Folder";
            // 
            // btnSaveLogFolder
            // 
            this.btnSaveLogFolder.Location = new System.Drawing.Point(395, 27);
            this.btnSaveLogFolder.Name = "btnSaveLogFolder";
            this.btnSaveLogFolder.Size = new System.Drawing.Size(84, 23);
            this.btnSaveLogFolder.TabIndex = 5;
            this.btnSaveLogFolder.Text = "&Save Path";
            this.btnSaveLogFolder.UseVisualStyleBackColor = true;
            // 
            // btnBrowserLogFolder
            // 
            this.btnBrowserLogFolder.Location = new System.Drawing.Point(344, 27);
            this.btnBrowserLogFolder.Name = "btnBrowserLogFolder";
            this.btnBrowserLogFolder.Size = new System.Drawing.Size(36, 23);
            this.btnBrowserLogFolder.TabIndex = 4;
            this.btnBrowserLogFolder.Text = "...";
            this.btnBrowserLogFolder.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditGateway);
            this.groupBox1.Controls.Add(this.btnRemoveGateway);
            this.groupBox1.Controls.Add(this.btnAddGateway);
            this.groupBox1.Controls.Add(this.dgdGateway);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 280);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gateway";
            // 
            // btnEditGateway
            // 
            this.btnEditGateway.Location = new System.Drawing.Point(633, 193);
            this.btnEditGateway.Name = "btnEditGateway";
            this.btnEditGateway.Size = new System.Drawing.Size(75, 23);
            this.btnEditGateway.TabIndex = 4;
            this.btnEditGateway.Text = "&Edit";
            this.btnEditGateway.UseVisualStyleBackColor = true;
            // 
            // btnRemoveGateway
            // 
            this.btnRemoveGateway.Location = new System.Drawing.Point(543, 193);
            this.btnRemoveGateway.Name = "btnRemoveGateway";
            this.btnRemoveGateway.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveGateway.TabIndex = 4;
            this.btnRemoveGateway.Text = "&Remove";
            this.btnRemoveGateway.UseVisualStyleBackColor = true;
            // 
            // btnAddGateway
            // 
            this.btnAddGateway.Location = new System.Drawing.Point(462, 193);
            this.btnAddGateway.Name = "btnAddGateway";
            this.btnAddGateway.Size = new System.Drawing.Size(75, 23);
            this.btnAddGateway.TabIndex = 3;
            this.btnAddGateway.Text = "&Add";
            this.btnAddGateway.UseVisualStyleBackColor = true;
            this.btnAddGateway.Click += new System.EventHandler(this.btnAddGateway_Click);
            // 
            // dgdGateway
            // 
            this.dgdGateway.AutoGenerateColumns = false;
            this.dgdGateway.BackgroundColor = System.Drawing.Color.White;
            this.dgdGateway.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgdGateway.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdGateway.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.portDataGridViewTextBoxColumn,
            this.ownNumberDataGridViewTextBoxColumn,
            this.sMSCDataGridViewTextBoxColumn,
            this.functionDataGridViewTextBoxColumn});
            this.dgdGateway.DataSource = this.gatewayBindingSource;
            this.dgdGateway.Location = new System.Drawing.Point(6, 19);
            this.dgdGateway.Name = "dgdGateway";
            this.dgdGateway.RowHeadersVisible = false;
            this.dgdGateway.Size = new System.Drawing.Size(702, 157);
            this.dgdGateway.TabIndex = 2;
            // 
            // tabServices
            // 
            this.tabServices.Controls.Add(this.groupBox3);
            this.tabServices.Location = new System.Drawing.Point(4, 22);
            this.tabServices.Name = "tabServices";
            this.tabServices.Padding = new System.Windows.Forms.Padding(3);
            this.tabServices.Size = new System.Drawing.Size(754, 437);
            this.tabServices.TabIndex = 1;
            this.tabServices.Text = "Services";
            this.tabServices.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStopAllGateway);
            this.groupBox3.Controls.Add(this.btnStopGateway);
            this.groupBox3.Controls.Add(this.btnRefreshGateway);
            this.groupBox3.Controls.Add(this.btnRunAllGateway);
            this.groupBox3.Controls.Add(this.btnRunGateway);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 241);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gateway";
            // 
            // btnStopAllGateway
            // 
            this.btnStopAllGateway.Location = new System.Drawing.Point(317, 210);
            this.btnStopAllGateway.Name = "btnStopAllGateway";
            this.btnStopAllGateway.Size = new System.Drawing.Size(75, 23);
            this.btnStopAllGateway.TabIndex = 6;
            this.btnStopAllGateway.Text = "Sto&p All";
            this.btnStopAllGateway.UseVisualStyleBackColor = true;
            // 
            // btnStopGateway
            // 
            this.btnStopGateway.Location = new System.Drawing.Point(236, 210);
            this.btnStopGateway.Name = "btnStopGateway";
            this.btnStopGateway.Size = new System.Drawing.Size(75, 23);
            this.btnStopGateway.TabIndex = 5;
            this.btnStopGateway.Text = "&Stop";
            this.btnStopGateway.UseVisualStyleBackColor = true;
            // 
            // btnRefreshGateway
            // 
            this.btnRefreshGateway.Location = new System.Drawing.Point(434, 210);
            this.btnRefreshGateway.Name = "btnRefreshGateway";
            this.btnRefreshGateway.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshGateway.TabIndex = 4;
            this.btnRefreshGateway.Text = "Re&fresh";
            this.btnRefreshGateway.UseVisualStyleBackColor = true;
            // 
            // btnRunAllGateway
            // 
            this.btnRunAllGateway.Location = new System.Drawing.Point(87, 210);
            this.btnRunAllGateway.Name = "btnRunAllGateway";
            this.btnRunAllGateway.Size = new System.Drawing.Size(75, 23);
            this.btnRunAllGateway.TabIndex = 4;
            this.btnRunAllGateway.Text = "Ru&n All";
            this.btnRunAllGateway.UseVisualStyleBackColor = true;
            // 
            // btnRunGateway
            // 
            this.btnRunGateway.Location = new System.Drawing.Point(6, 210);
            this.btnRunGateway.Name = "btnRunGateway";
            this.btnRunGateway.Size = new System.Drawing.Size(75, 23);
            this.btnRunGateway.TabIndex = 3;
            this.btnRunGateway.Text = "&Run";
            this.btnRunGateway.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(506, 185);
            this.dataGridView1.TabIndex = 2;
            // 
            // tabPreferences
            // 
            this.tabPreferences.Location = new System.Drawing.Point(4, 22);
            this.tabPreferences.Name = "tabPreferences";
            this.tabPreferences.Size = new System.Drawing.Size(754, 437);
            this.tabPreferences.TabIndex = 2;
            this.tabPreferences.Text = "Preferences";
            this.tabPreferences.UseVisualStyleBackColor = true;
            // 
            // tabDiagnostics
            // 
            this.tabDiagnostics.Location = new System.Drawing.Point(4, 22);
            this.tabDiagnostics.Name = "tabDiagnostics";
            this.tabDiagnostics.Size = new System.Drawing.Size(754, 437);
            this.tabDiagnostics.TabIndex = 3;
            this.tabDiagnostics.Text = "Diagnostics";
            this.tabDiagnostics.UseVisualStyleBackColor = true;
            // 
            // tabScheduler
            // 
            this.tabScheduler.Location = new System.Drawing.Point(4, 22);
            this.tabScheduler.Name = "tabScheduler";
            this.tabScheduler.Size = new System.Drawing.Size(754, 437);
            this.tabScheduler.TabIndex = 5;
            this.tabScheduler.Text = "Scheduler";
            this.tabScheduler.UseVisualStyleBackColor = true;
            // 
            // tabIncomingRules
            // 
            this.tabIncomingRules.Location = new System.Drawing.Point(4, 22);
            this.tabIncomingRules.Name = "tabIncomingRules";
            this.tabIncomingRules.Size = new System.Drawing.Size(754, 437);
            this.tabIncomingRules.TabIndex = 7;
            this.tabIncomingRules.Text = "Incoming Rules";
            this.tabIncomingRules.UseVisualStyleBackColor = true;
            // 
            // tabCommandLine
            // 
            this.tabCommandLine.Location = new System.Drawing.Point(4, 22);
            this.tabCommandLine.Name = "tabCommandLine";
            this.tabCommandLine.Size = new System.Drawing.Size(754, 437);
            this.tabCommandLine.TabIndex = 6;
            this.tabCommandLine.Text = "Command Line";
            this.tabCommandLine.UseVisualStyleBackColor = true;
            // 
            // tabWeb
            // 
            this.tabWeb.Controls.Add(this.groupBox4);
            this.tabWeb.Location = new System.Drawing.Point(4, 22);
            this.tabWeb.Name = "tabWeb";
            this.tabWeb.Size = new System.Drawing.Size(754, 437);
            this.tabWeb.TabIndex = 8;
            this.tabWeb.Text = "Web";
            this.tabWeb.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lnkWebPortal);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.btnBrowseApplicationDirectory);
            this.groupBox4.Controls.Add(this.btnStopWebApplication);
            this.groupBox4.Controls.Add(this.lblWebApplicationStatus);
            this.groupBox4.Controls.Add(this.btnStartWebApplication);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.chkAutoStartWebApplication);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtVirtualRoot);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtPort);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtApplicationDirectory);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(557, 315);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Application Settings";
            // 
            // lnkWebPortal
            // 
            this.lnkWebPortal.AutoSize = true;
            this.lnkWebPortal.Location = new System.Drawing.Point(126, 182);
            this.lnkWebPortal.Name = "lnkWebPortal";
            this.lnkWebPortal.Size = new System.Drawing.Size(38, 13);
            this.lnkWebPortal.TabIndex = 21;
            this.lnkWebPortal.TabStop = true;
            this.lnkWebPortal.Text = "http://";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Click to Browse";
            // 
            // btnBrowseApplicationDirectory
            // 
            this.btnBrowseApplicationDirectory.Location = new System.Drawing.Point(422, 38);
            this.btnBrowseApplicationDirectory.Name = "btnBrowseApplicationDirectory";
            this.btnBrowseApplicationDirectory.Size = new System.Drawing.Size(38, 23);
            this.btnBrowseApplicationDirectory.TabIndex = 19;
            this.btnBrowseApplicationDirectory.Text = "...";
            this.btnBrowseApplicationDirectory.UseVisualStyleBackColor = true;
            // 
            // btnStopWebApplication
            // 
            this.btnStopWebApplication.Location = new System.Drawing.Point(219, 219);
            this.btnStopWebApplication.Name = "btnStopWebApplication";
            this.btnStopWebApplication.Size = new System.Drawing.Size(75, 23);
            this.btnStopWebApplication.TabIndex = 16;
            this.btnStopWebApplication.Text = "Sto&p";
            this.btnStopWebApplication.UseVisualStyleBackColor = true;
            this.btnStopWebApplication.Click += new System.EventHandler(this.btnStopWebApplication_Click);
            // 
            // lblWebApplicationStatus
            // 
            this.lblWebApplicationStatus.AutoSize = true;
            this.lblWebApplicationStatus.Location = new System.Drawing.Point(125, 127);
            this.lblWebApplicationStatus.Name = "lblWebApplicationStatus";
            this.lblWebApplicationStatus.Size = new System.Drawing.Size(115, 13);
            this.lblWebApplicationStatus.TabIndex = 18;
            this.lblWebApplicationStatus.Text = "Web application status";
            // 
            // btnStartWebApplication
            // 
            this.btnStartWebApplication.Location = new System.Drawing.Point(128, 219);
            this.btnStartWebApplication.Name = "btnStartWebApplication";
            this.btnStartWebApplication.Size = new System.Drawing.Size(75, 23);
            this.btnStartWebApplication.TabIndex = 15;
            this.btnStartWebApplication.Text = "&Start";
            this.btnStartWebApplication.UseVisualStyleBackColor = true;
            this.btnStartWebApplication.Click += new System.EventHandler(this.btnStartWebApplication_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Status";
            // 
            // chkAutoStartWebApplication
            // 
            this.chkAutoStartWebApplication.AutoSize = true;
            this.chkAutoStartWebApplication.Location = new System.Drawing.Point(128, 155);
            this.chkAutoStartWebApplication.Name = "chkAutoStartWebApplication";
            this.chkAutoStartWebApplication.Size = new System.Drawing.Size(150, 17);
            this.chkAutoStartWebApplication.TabIndex = 16;
            this.chkAutoStartWebApplication.Text = "Auto Start with Application";
            this.chkAutoStartWebApplication.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Virtual Root";
            // 
            // txtVirtualRoot
            // 
            this.txtVirtualRoot.Location = new System.Drawing.Point(128, 93);
            this.txtVirtualRoot.Name = "txtVirtualRoot";
            this.txtVirtualRoot.Size = new System.Drawing.Size(332, 20);
            this.txtVirtualRoot.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(128, 67);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(43, 20);
            this.txtPort.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Application Directory";
            // 
            // txtApplicationDirectory
            // 
            this.txtApplicationDirectory.Location = new System.Drawing.Point(128, 41);
            this.txtApplicationDirectory.Name = "txtApplicationDirectory";
            this.txtApplicationDirectory.Size = new System.Drawing.Size(288, 20);
            this.txtApplicationDirectory.TabIndex = 8;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.lblLicense);
            this.tabAbout.Controls.Add(this.lblAbout);
            this.tabAbout.Controls.Add(this.linkLabel1);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(754, 437);
            this.tabAbout.TabIndex = 4;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicense.Location = new System.Drawing.Point(148, 76);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(0, 20);
            this.lblLicense.TabIndex = 4;
            this.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.Location = new System.Drawing.Point(148, 113);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(60, 20);
            this.lblAbout.TabIndex = 3;
            this.lblAbout.Text = "label12";
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(175, 166);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(162, 20);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.twit88.com";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnExit);
            this.groupBox5.Controls.Add(this.btnHelp);
            this.groupBox5.Location = new System.Drawing.Point(0, 481);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(742, 51);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(642, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(367, 19);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAppStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(773, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssAppStatus
            // 
            this.tssAppStatus.Name = "tssAppStatus";
            this.tssAppStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.DataPropertyName = "Port";
            this.portDataGridViewTextBoxColumn.HeaderText = "Port";
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            // 
            // ownNumberDataGridViewTextBoxColumn
            // 
            this.ownNumberDataGridViewTextBoxColumn.DataPropertyName = "Own Number";
            this.ownNumberDataGridViewTextBoxColumn.HeaderText = "Own Number";
            this.ownNumberDataGridViewTextBoxColumn.Name = "ownNumberDataGridViewTextBoxColumn";
            // 
            // sMSCDataGridViewTextBoxColumn
            // 
            this.sMSCDataGridViewTextBoxColumn.DataPropertyName = "SMSC";
            this.sMSCDataGridViewTextBoxColumn.HeaderText = "SMSC";
            this.sMSCDataGridViewTextBoxColumn.Name = "sMSCDataGridViewTextBoxColumn";
            // 
            // functionDataGridViewTextBoxColumn
            // 
            this.functionDataGridViewTextBoxColumn.DataPropertyName = "Function";
            this.functionDataGridViewTextBoxColumn.HeaderText = "Function";
            this.functionDataGridViewTextBoxColumn.Name = "functionDataGridViewTextBoxColumn";
            // 
            // gatewayBindingSource
            // 
            this.gatewayBindingSource.DataMember = "Gateway";
           // 
       
            // 
            // ManagementConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 567);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManagementConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartGateway - Management Console";
            this.Load += new System.EventHandler(this.ManagementConsole_Load);
            this.tabMain.ResumeLayout(false);
            this.tabConfiguration.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgdGateway)).EndInit();
            this.tabServices.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabWeb.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gatewayBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.TabPage tabServices;
        private System.Windows.Forms.TabPage tabPreferences;
        private System.Windows.Forms.TabPage tabDiagnostics;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgdGateway;
        private System.Windows.Forms.Button btnEditGateway;
        private System.Windows.Forms.Button btnRemoveGateway;
        private System.Windows.Forms.Button btnAddGateway;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveLogFolder;
        private System.Windows.Forms.Button btnBrowserLogFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabScheduler;
        private System.Windows.Forms.TabPage tabCommandLine;
        private System.Windows.Forms.TabPage tabIncomingRules;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStopAllGateway;
        private System.Windows.Forms.Button btnStopGateway;
        private System.Windows.Forms.Button btnRefreshGateway;
        private System.Windows.Forms.Button btnRunAllGateway;
        private System.Windows.Forms.Button btnRunGateway;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabWeb;
        private System.Windows.Forms.Button btnStartWebApplication;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVirtualRoot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApplicationDirectory;
        private System.Windows.Forms.CheckBox chkAutoStartWebApplication;
        private System.Windows.Forms.Label lblWebApplicationStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStopWebApplication;
        private System.Windows.Forms.Button btnBrowseApplicationDirectory;
        private System.ServiceProcess.ServiceController serverController;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.LinkLabel lnkWebPortal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource gatewayBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMSCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn functionDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssAppStatus;
      
    }
}