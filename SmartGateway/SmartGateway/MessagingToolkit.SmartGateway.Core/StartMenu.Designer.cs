namespace MessagingToolkit.SmartGateway.Core
{
    partial class StartMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            this.lineItem5 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.lineItem4 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.lineItem3 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.lineItem2 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.lineItem1 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.lnmMessages = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.controlFooter1 = new MessagingToolkit.SmartGateway.Core.ControlFooter();
            this.controlHeader1 = new MessagingToolkit.SmartGateway.Core.ControlHeader();
            this.SuspendLayout();
            // 
            // lineItem5
            // 
            this.lineItem5.LinkDescription = "Help file, manual, and other useful information";
            this.lineItem5.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem5.LinkImage")));
            this.lineItem5.LinkName = "Documentation";
            this.lineItem5.LinkToClass = "ctlDocumentation";
            this.lineItem5.LinkToModule = "";
            this.lineItem5.Location = new System.Drawing.Point(12, 344);
            this.lineItem5.Name = "lineItem5";
            this.lineItem5.Size = new System.Drawing.Size(452, 56);
            this.lineItem5.TabIndex = 7;
            // 
            // lineItem4
            // 
            this.lineItem4.LinkDescription = "Client tools";
            this.lineItem4.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem4.LinkImage")));
            this.lineItem4.LinkName = "Client Tools";
            this.lineItem4.LinkToClass = "ctlClientTools";
            this.lineItem4.LinkToModule = "";
            this.lineItem4.Location = new System.Drawing.Point(12, 344);
            this.lineItem4.Name = "lineItem4";
            this.lineItem4.Size = new System.Drawing.Size(452, 56);
            this.lineItem4.TabIndex = 6;
            this.lineItem4.Visible = false;
            // 
            // lineItem3
            // 
            this.lineItem3.LinkDescription = "Web server and other system tools";
            this.lineItem3.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem3.LinkImage")));
            this.lineItem3.LinkName = "Server tools";
            this.lineItem3.LinkToClass = "ctlServerTools";
            this.lineItem3.LinkToModule = "";
            this.lineItem3.Location = new System.Drawing.Point(12, 282);
            this.lineItem3.Name = "lineItem3";
            this.lineItem3.Size = new System.Drawing.Size(452, 56);
            this.lineItem3.TabIndex = 5;
            // 
            // lineItem2
            // 
            this.lineItem2.LinkDescription = "Develop and setup your own applications";
            this.lineItem2.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem2.LinkImage")));
            this.lineItem2.LinkName = "Applications";
            this.lineItem2.LinkToClass = "ctlApplications";
            this.lineItem2.LinkToModule = "";
            this.lineItem2.Location = new System.Drawing.Point(12, 210);
            this.lineItem2.Name = "lineItem2";
            this.lineItem2.Size = new System.Drawing.Size(452, 56);
            this.lineItem2.TabIndex = 4;
            // 
            // lineItem1
            // 
            this.lineItem1.LinkDescription = "Configure SmartGateway";
            this.lineItem1.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem1.LinkImage")));
            this.lineItem1.LinkName = "Configuration";
            this.lineItem1.LinkToClass = "ctlConfiguration";
            this.lineItem1.LinkToModule = "";
            this.lineItem1.Location = new System.Drawing.Point(12, 148);
            this.lineItem1.Name = "lineItem1";
            this.lineItem1.Size = new System.Drawing.Size(452, 56);
            this.lineItem1.TabIndex = 3;
            // 
            // lnmMessages
            // 
            this.lnmMessages.LinkDescription = "Send, receive and manage messages";
            this.lnmMessages.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lnmMessages.LinkImage")));
            this.lnmMessages.LinkName = "Messages";
            this.lnmMessages.LinkToClass = "ctlMessages";
            this.lnmMessages.LinkToModule = "";
            this.lnmMessages.Location = new System.Drawing.Point(12, 86);
            this.lnmMessages.Name = "lnmMessages";
            this.lnmMessages.Size = new System.Drawing.Size(452, 56);
            this.lnmMessages.TabIndex = 2;
            // 
            // controlFooter1
            // 
            this.controlFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlFooter1.Location = new System.Drawing.Point(0, 496);
            this.controlFooter1.Message = "Click on the link to navigate to the module directly.";
            this.controlFooter1.Name = "controlFooter1";
            this.controlFooter1.Size = new System.Drawing.Size(494, 64);
            this.controlFooter1.TabIndex = 1;
            // 
            // controlHeader1
            // 
            this.controlHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHeader1.Location = new System.Drawing.Point(0, 0);
            this.controlHeader1.Logo = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.mobile_phone_cast;
            this.controlHeader1.Name = "controlHeader1";
            this.controlHeader1.Size = new System.Drawing.Size(494, 80);
            this.controlHeader1.SubTitle = "Start Menu";
            this.controlHeader1.TabIndex = 0;
            this.controlHeader1.Title = "MessagingToolkit SmartGateway";
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lineItem5);
            this.Controls.Add(this.lineItem4);
            this.Controls.Add(this.lineItem3);
            this.Controls.Add(this.lineItem2);
            this.Controls.Add(this.lineItem1);
            this.Controls.Add(this.lnmMessages);
            this.Controls.Add(this.controlFooter1);
            this.Controls.Add(this.controlHeader1);
            this.Name = "StartMenu";
            this.Size = new System.Drawing.Size(494, 560);
            this.Load += new System.EventHandler(this.StartMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MessagingToolkit.SmartGateway.Core.ControlHeader controlHeader1;
        private ControlFooter controlFooter1;
        private LineItem lnmMessages;
        private LineItem lineItem1;
        private LineItem lineItem2;
        private LineItem lineItem3;
        private LineItem lineItem4;
        private LineItem lineItem5;


    }
}
