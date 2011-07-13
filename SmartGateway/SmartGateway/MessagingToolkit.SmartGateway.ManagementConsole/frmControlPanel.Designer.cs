namespace MessagingToolkit.SmartGateway.ManagementConsole
{
    partial class frmControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlPanel));
            this.ssApplicationMain = new System.Windows.Forms.StatusStrip();
            this.tsApplicationMain = new System.Windows.Forms.ToolStrip();
            this.tsbConfiguration = new System.Windows.Forms.ToolStripButton();
            this.tsbStatusPanel = new System.Windows.Forms.ToolStripButton();
            this.tsbService = new System.Windows.Forms.ToolStripButton();
            this.tsbStatusConsole = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.mnsApplicationMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ctlChannelStatus = new MessagingToolkit.SmartGateway.Core.ChannelStatus();
            this.ctlManual = new MessagingToolkit.SmartGateway.Core.Manual();
            this.ctlLicensing = new MessagingToolkit.SmartGateway.Core.License();
            this.ctlApplications = new MessagingToolkit.SmartGateway.Core.Applications();
            this.ctlContactUsers = new MessagingToolkit.SmartGateway.Core.ContactUsers();
            this.ctlContactGroups = new MessagingToolkit.SmartGateway.Core.ContactGroups();
            this.ctlContacts = new MessagingToolkit.SmartGateway.Core.Contacts();
            this.ctlOutboxFailed = new MessagingToolkit.SmartGateway.Core.OutboxFailed();
            this.ctlArchive = new MessagingToolkit.SmartGateway.Core.Archive();
            this.ctlServerTools = new MessagingToolkit.SmartGateway.Core.ServerTools();
            this.ctlClientTools = new MessagingToolkit.SmartGateway.Core.ClientTools();
            this.ctlConfiguration = new MessagingToolkit.SmartGateway.Core.ConfigurationView();
            this.ctlInbox = new MessagingToolkit.SmartGateway.Core.Inbox();
            this.ctlMessages = new MessagingToolkit.SmartGateway.Core.Messages();
            this.ctlArchivedOutbox = new MessagingToolkit.SmartGateway.Core.ArchivedOutbox();
            this.ctlArchivedInbox = new MessagingToolkit.SmartGateway.Core.ArchivedInbox();
            this.ctlAbout = new MessagingToolkit.SmartGateway.Core.About();
            this.ctlOutbox = new MessagingToolkit.SmartGateway.Core.Outbox();
            this.ctlNewMessage = new MessagingToolkit.SmartGateway.Core.NewMessage();
            this.ctlChannels = new MessagingToolkit.SmartGateway.Core.Channels();
            this.ctlDocumentation = new MessagingToolkit.SmartGateway.Core.Documentation();
            this.ctlConfigurationViewPanel = new MessagingToolkit.SmartGateway.Core.ConfigurationViewPanel();
            this.ctlStartMenu = new MessagingToolkit.SmartGateway.Core.StartMenu();
            this.panelConfiguration = new MessagingToolkit.SmartGateway.Core.MenuPanel();
            this.ctlWebConsole = new MessagingToolkit.SmartGateway.Core.WebConsole();
            this.ctlDatabaseMessenger = new MessagingToolkit.SmartGateway.Core.DatabaseMessenger();
            this.tsApplicationMain.SuspendLayout();
            this.mnsApplicationMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssApplicationMain
            // 
            this.ssApplicationMain.Location = new System.Drawing.Point(0, 571);
            this.ssApplicationMain.Name = "ssApplicationMain";
            this.ssApplicationMain.Size = new System.Drawing.Size(1019, 22);
            this.ssApplicationMain.TabIndex = 0;
            this.ssApplicationMain.Text = "statusStrip1";
            // 
            // tsApplicationMain
            // 
            this.tsApplicationMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConfiguration,
            this.tsbStatusPanel,
            this.tsbService,
            this.tsbStatusConsole,
            this.tsbAbout,
            this.tsbExit});
            this.tsApplicationMain.Location = new System.Drawing.Point(0, 24);
            this.tsApplicationMain.Name = "tsApplicationMain";
            this.tsApplicationMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsApplicationMain.Size = new System.Drawing.Size(1019, 25);
            this.tsApplicationMain.TabIndex = 2;
            this.tsApplicationMain.Text = "tsApplicationMain";
            this.tsApplicationMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsApplicationMain_ItemClicked);
            // 
            // tsbConfiguration
            // 
            this.tsbConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("tsbConfiguration.Image")));
            this.tsbConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConfiguration.Name = "tsbConfiguration";
            this.tsbConfiguration.Size = new System.Drawing.Size(23, 22);
            this.tsbConfiguration.Text = "Configuration";
            this.tsbConfiguration.Click += new System.EventHandler(this.tsbConfiguration_Click);
            // 
            // tsbStatusPanel
            // 
            this.tsbStatusPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStatusPanel.Image = ((System.Drawing.Image)(resources.GetObject("tsbStatusPanel.Image")));
            this.tsbStatusPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStatusPanel.Name = "tsbStatusPanel";
            this.tsbStatusPanel.Size = new System.Drawing.Size(23, 22);
            this.tsbStatusPanel.Text = "Status Panel";
            this.tsbStatusPanel.Click += new System.EventHandler(this.tsbStatusPanel_Click);
            // 
            // tsbService
            // 
            this.tsbService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbService.Image = ((System.Drawing.Image)(resources.GetObject("tsbService.Image")));
            this.tsbService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbService.Name = "tsbService";
            this.tsbService.Size = new System.Drawing.Size(23, 22);
            this.tsbService.Text = "Service";
            this.tsbService.ToolTipText = "Message Server Service";
            this.tsbService.Click += new System.EventHandler(this.tsbService_Click);
            // 
            // tsbStatusConsole
            // 
            this.tsbStatusConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStatusConsole.Image = ((System.Drawing.Image)(resources.GetObject("tsbStatusConsole.Image")));
            this.tsbStatusConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStatusConsole.Name = "tsbStatusConsole";
            this.tsbStatusConsole.Size = new System.Drawing.Size(23, 22);
            this.tsbStatusConsole.Text = "Status Console";
            this.tsbStatusConsole.Click += new System.EventHandler(this.tsbStatusConsole_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(23, 22);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = global::MessagingToolkit.SmartGateway.ManagementConsole.Properties.Resources.exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(23, 22);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // mnsApplicationMain
            // 
            this.mnsApplicationMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mnsApplicationMain.Location = new System.Drawing.Point(0, 0);
            this.mnsApplicationMain.Name = "mnsApplicationMain";
            this.mnsApplicationMain.Size = new System.Drawing.Size(1019, 24);
            this.mnsApplicationMain.TabIndex = 3;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(224, 49);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 522);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // ctlChannelStatus
            // 
            this.ctlChannelStatus.Location = new System.Drawing.Point(1059, 532);
            this.ctlChannelStatus.Name = "ctlChannelStatus";
            this.ctlChannelStatus.Size = new System.Drawing.Size(164, 57);
            this.ctlChannelStatus.TabIndex = 32;
            // 
            // ctlManual
            // 
            this.ctlManual.Location = new System.Drawing.Point(998, 552);
            this.ctlManual.Name = "ctlManual";
            this.ctlManual.Size = new System.Drawing.Size(116, 71);
            this.ctlManual.TabIndex = 31;
            // 
            // ctlLicensing
            // 
            this.ctlLicensing.Location = new System.Drawing.Point(1006, 541);
            this.ctlLicensing.Name = "ctlLicensing";
            this.ctlLicensing.Size = new System.Drawing.Size(132, 94);
            this.ctlLicensing.TabIndex = 30;
            // 
            // ctlApplications
            // 
            this.ctlApplications.Location = new System.Drawing.Point(1108, 532);
            this.ctlApplications.Name = "ctlApplications";
            this.ctlApplications.Size = new System.Drawing.Size(82, 103);
            this.ctlApplications.TabIndex = 29;
            // 
            // ctlContactUsers
            // 
            this.ctlContactUsers.Location = new System.Drawing.Point(1169, 677);
            this.ctlContactUsers.Name = "ctlContactUsers";
            this.ctlContactUsers.Size = new System.Drawing.Size(51, 37);
            this.ctlContactUsers.TabIndex = 28;
            // 
            // ctlContactGroups
            // 
            this.ctlContactGroups.Location = new System.Drawing.Point(1018, 464);
            this.ctlContactGroups.Name = "ctlContactGroups";
            this.ctlContactGroups.Size = new System.Drawing.Size(70, 62);
            this.ctlContactGroups.TabIndex = 27;
            // 
            // ctlContacts
            // 
            this.ctlContacts.Location = new System.Drawing.Point(1148, 506);
            this.ctlContacts.Name = "ctlContacts";
            this.ctlContacts.Size = new System.Drawing.Size(60, 58);
            this.ctlContacts.TabIndex = 26;
            // 
            // ctlOutboxFailed
            // 
            this.ctlOutboxFailed.Location = new System.Drawing.Point(1108, 561);
            this.ctlOutboxFailed.Name = "ctlOutboxFailed";
            this.ctlOutboxFailed.Size = new System.Drawing.Size(60, 53);
            this.ctlOutboxFailed.TabIndex = 25;
            // 
            // ctlArchive
            // 
            this.ctlArchive.Location = new System.Drawing.Point(947, 519);
            this.ctlArchive.Name = "ctlArchive";
            this.ctlArchive.Size = new System.Drawing.Size(60, 44);
            this.ctlArchive.TabIndex = 24;
            // 
            // ctlServerTools
            // 
            this.ctlServerTools.Location = new System.Drawing.Point(1033, 561);
            this.ctlServerTools.Name = "ctlServerTools";
            this.ctlServerTools.Size = new System.Drawing.Size(105, 50);
            this.ctlServerTools.TabIndex = 23;
            // 
            // ctlClientTools
            // 
            this.ctlClientTools.Location = new System.Drawing.Point(980, 583);
            this.ctlClientTools.Name = "ctlClientTools";
            this.ctlClientTools.Size = new System.Drawing.Size(47, 66);
            this.ctlClientTools.TabIndex = 22;
            // 
            // ctlConfiguration
            // 
            this.ctlConfiguration.Location = new System.Drawing.Point(918, 579);
            this.ctlConfiguration.Name = "ctlConfiguration";
            this.ctlConfiguration.Size = new System.Drawing.Size(60, 67);
            this.ctlConfiguration.TabIndex = 21;
            // 
            // ctlInbox
            // 
            this.ctlInbox.Location = new System.Drawing.Point(949, 506);
            this.ctlInbox.Name = "ctlInbox";
            this.ctlInbox.Size = new System.Drawing.Size(47, 72);
            this.ctlInbox.TabIndex = 16;
            // 
            // ctlMessages
            // 
            this.ctlMessages.Location = new System.Drawing.Point(1088, 651);
            this.ctlMessages.Name = "ctlMessages";
            this.ctlMessages.Size = new System.Drawing.Size(71, 55);
            this.ctlMessages.TabIndex = 20;
            // 
            // ctlArchivedOutbox
            // 
            this.ctlArchivedOutbox.Location = new System.Drawing.Point(1073, 585);
            this.ctlArchivedOutbox.Name = "ctlArchivedOutbox";
            this.ctlArchivedOutbox.Size = new System.Drawing.Size(41, 64);
            this.ctlArchivedOutbox.TabIndex = 18;
            // 
            // ctlArchivedInbox
            // 
            this.ctlArchivedInbox.Location = new System.Drawing.Point(1009, 566);
            this.ctlArchivedInbox.Name = "ctlArchivedInbox";
            this.ctlArchivedInbox.Size = new System.Drawing.Size(60, 38);
            this.ctlArchivedInbox.TabIndex = 17;
            // 
            // ctlAbout
            // 
            this.ctlAbout.Location = new System.Drawing.Point(969, 477);
            this.ctlAbout.Name = "ctlAbout";
            this.ctlAbout.Size = new System.Drawing.Size(60, 54);
            this.ctlAbout.TabIndex = 15;
            // 
            // ctlOutbox
            // 
            this.ctlOutbox.Location = new System.Drawing.Point(949, 483);
            this.ctlOutbox.Name = "ctlOutbox";
            this.ctlOutbox.Size = new System.Drawing.Size(58, 68);
            this.ctlOutbox.TabIndex = 12;
            // 
            // ctlNewMessage
            // 
            this.ctlNewMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ctlNewMessage.Location = new System.Drawing.Point(926, 599);
            this.ctlNewMessage.Message = null;
            this.ctlNewMessage.MessageContent = "";
            this.ctlNewMessage.Name = "ctlNewMessage";
            this.ctlNewMessage.Size = new System.Drawing.Size(54, 42);
            this.ctlNewMessage.TabIndex = 11;
            this.ctlNewMessage.To = "";
            // 
            // ctlChannels
            // 
            this.ctlChannels.Location = new System.Drawing.Point(1059, 599);
            this.ctlChannels.Name = "ctlChannels";
            this.ctlChannels.Size = new System.Drawing.Size(47, 84);
            this.ctlChannels.TabIndex = 10;
            // 
            // ctlDocumentation
            // 
            this.ctlDocumentation.Location = new System.Drawing.Point(947, 469);
            this.ctlDocumentation.Name = "ctlDocumentation";
            this.ctlDocumentation.Size = new System.Drawing.Size(66, 82);
            this.ctlDocumentation.TabIndex = 9;
            // 
            // ctlConfigurationViewPanel
            // 
            this.ctlConfigurationViewPanel.Location = new System.Drawing.Point(918, 469);
            this.ctlConfigurationViewPanel.Name = "ctlConfigurationViewPanel";
            this.ctlConfigurationViewPanel.Size = new System.Drawing.Size(78, 94);
            this.ctlConfigurationViewPanel.TabIndex = 8;
            // 
            // ctlStartMenu
            // 
            this.ctlStartMenu.Location = new System.Drawing.Point(960, 544);
            this.ctlStartMenu.Name = "ctlStartMenu";
            this.ctlStartMenu.Size = new System.Drawing.Size(49, 54);
            this.ctlStartMenu.TabIndex = 7;
            // 
            // panelConfiguration
            // 
            this.panelConfiguration.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelConfiguration.Location = new System.Drawing.Point(0, 49);
            this.panelConfiguration.Name = "panelConfiguration";
            this.panelConfiguration.Size = new System.Drawing.Size(224, 522);
            this.panelConfiguration.TabIndex = 4;
            // 
            // ctlWebConsole
            // 
            this.ctlWebConsole.Location = new System.Drawing.Point(1040, 622);
            this.ctlWebConsole.Name = "ctlWebConsole";
            this.ctlWebConsole.Size = new System.Drawing.Size(168, 143);
            this.ctlWebConsole.TabIndex = 33;
            // 
            // ctlDatabaseMessenger
            // 
            this.ctlDatabaseMessenger.Location = new System.Drawing.Point(1022, 527);
            this.ctlDatabaseMessenger.Name = "ctlDatabaseMessenger";
            this.ctlDatabaseMessenger.Size = new System.Drawing.Size(137, 55);
            this.ctlDatabaseMessenger.TabIndex = 34;
            // 
            // frmControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 593);
            this.Controls.Add(this.ctlDatabaseMessenger);
            this.Controls.Add(this.ctlWebConsole);
            this.Controls.Add(this.ctlChannelStatus);
            this.Controls.Add(this.ctlManual);
            this.Controls.Add(this.ctlLicensing);
            this.Controls.Add(this.ctlApplications);
            this.Controls.Add(this.ctlContactUsers);
            this.Controls.Add(this.ctlContactGroups);
            this.Controls.Add(this.ctlContacts);
            this.Controls.Add(this.ctlOutboxFailed);
            this.Controls.Add(this.ctlArchive);
            this.Controls.Add(this.ctlServerTools);
            this.Controls.Add(this.ctlClientTools);
            this.Controls.Add(this.ctlConfiguration);
            this.Controls.Add(this.ctlInbox);
            this.Controls.Add(this.ctlMessages);
            this.Controls.Add(this.ctlArchivedOutbox);
            this.Controls.Add(this.ctlArchivedInbox);
            this.Controls.Add(this.ctlAbout);
            this.Controls.Add(this.ctlOutbox);
            this.Controls.Add(this.ctlNewMessage);
            this.Controls.Add(this.ctlChannels);
            this.Controls.Add(this.ctlDocumentation);
            this.Controls.Add(this.ctlConfigurationViewPanel);
            this.Controls.Add(this.ctlStartMenu);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelConfiguration);
            this.Controls.Add(this.tsApplicationMain);
            this.Controls.Add(this.ssApplicationMain);
            this.Controls.Add(this.mnsApplicationMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnsApplicationMain;
            this.Name = "frmControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartGateway - Management Console";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmControlPanel_FormClosing);
            this.Load += new System.EventHandler(this.frmControlPanel_Load);
            this.tsApplicationMain.ResumeLayout(false);
            this.tsApplicationMain.PerformLayout();
            this.mnsApplicationMain.ResumeLayout(false);
            this.mnsApplicationMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssApplicationMain;
        private System.Windows.Forms.ToolStrip tsApplicationMain;
        private System.Windows.Forms.MenuStrip mnsApplicationMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbConfiguration;
        private System.Windows.Forms.ToolStripButton tsbStatusPanel;
        private System.Windows.Forms.ToolStripButton tsbStatusConsole;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private MessagingToolkit.SmartGateway.Core.MenuPanel panelConfiguration;
        private System.Windows.Forms.Splitter splitter1;
        private MessagingToolkit.SmartGateway.Core.StartMenu ctlStartMenu;
        private MessagingToolkit.SmartGateway.Core.ConfigurationViewPanel ctlConfigurationViewPanel;
        private MessagingToolkit.SmartGateway.Core.Documentation ctlDocumentation;
        private MessagingToolkit.SmartGateway.Core.Channels ctlChannels;
        private MessagingToolkit.SmartGateway.Core.NewMessage ctlNewMessage;
        private MessagingToolkit.SmartGateway.Core.Outbox ctlOutbox;
        private MessagingToolkit.SmartGateway.Core.About ctlAbout;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private MessagingToolkit.SmartGateway.Core.Inbox ctlInbox;
        private System.Windows.Forms.ToolStripButton tsbService;
        private Core.ArchivedInbox ctlArchivedInbox;
        private Core.ArchivedOutbox ctlArchivedOutbox;
        private Core.Messages ctlMessages;
        private Core.ConfigurationView ctlConfiguration;
        private Core.ClientTools ctlClientTools;
        private Core.ServerTools ctlServerTools;
        private Core.Archive ctlArchive;
        private Core.OutboxFailed ctlOutboxFailed;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private Core.Contacts ctlContacts;
        private Core.ContactGroups ctlContactGroups;
        private Core.ContactUsers ctlContactUsers;
        private Core.Applications ctlApplications;
        private Core.License ctlLicensing;
        private Core.Manual ctlManual;
        private Core.ChannelStatus ctlChannelStatus;
        private Core.WebConsole ctlWebConsole;
        private Core.DatabaseMessenger ctlDatabaseMessenger;
    }
}