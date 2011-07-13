namespace MessagingToolkit.SmartGateway.Core
{
    partial class Messages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messages));
            this.controlHeader1 = new MessagingToolkit.SmartGateway.Core.ControlHeader();
            this.lineItem1 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.lineItem2 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.lineItem3 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.lineItem4 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.SuspendLayout();
            // 
            // controlHeader1
            // 
            this.controlHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHeader1.Location = new System.Drawing.Point(0, 0);
            this.controlHeader1.Logo = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.messages;
            this.controlHeader1.Name = "controlHeader1";
            this.controlHeader1.Size = new System.Drawing.Size(553, 91);
            this.controlHeader1.SubTitle = "Messages";
            this.controlHeader1.TabIndex = 0;
            this.controlHeader1.Title = "MessagingToolkit SmartGateway";
            // 
            // lineItem1
            // 
            this.lineItem1.LinkDescription = "Incoming messages.";
            this.lineItem1.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem1.LinkImage")));
            this.lineItem1.LinkName = "Inbox";
            this.lineItem1.LinkToClass = "ctlInbox";
            this.lineItem1.LinkToModule = "";
            this.lineItem1.Location = new System.Drawing.Point(14, 114);
            this.lineItem1.Name = "lineItem1";
            this.lineItem1.Size = new System.Drawing.Size(509, 62);
            this.lineItem1.TabIndex = 1;
            // 
            // lineItem2
            // 
            this.lineItem2.LinkDescription = "Outgoing messages.";
            this.lineItem2.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem2.LinkImage")));
            this.lineItem2.LinkName = "Outbox";
            this.lineItem2.LinkToClass = "ctlOutbox";
            this.lineItem2.LinkToModule = "";
            this.lineItem2.Location = new System.Drawing.Point(14, 180);
            this.lineItem2.Name = "lineItem2";
            this.lineItem2.Size = new System.Drawing.Size(509, 62);
            this.lineItem2.TabIndex = 2;
            // 
            // lineItem3
            // 
            this.lineItem3.LinkDescription = "Archived messages.";
            this.lineItem3.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem3.LinkImage")));
            this.lineItem3.LinkName = "Archive";
            this.lineItem3.LinkToClass = "ctlArchive";
            this.lineItem3.LinkToModule = "";
            this.lineItem3.Location = new System.Drawing.Point(14, 246);
            this.lineItem3.Name = "lineItem3";
            this.lineItem3.Size = new System.Drawing.Size(509, 62);
            this.lineItem3.TabIndex = 3;
            // 
            // lineItem4
            // 
            this.lineItem4.LinkDescription = "Create new messages for sending.";
            this.lineItem4.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem4.LinkImage")));
            this.lineItem4.LinkName = "Create New Message";
            this.lineItem4.LinkToClass = "ctlNewMessage";
            this.lineItem4.LinkToModule = "";
            this.lineItem4.Location = new System.Drawing.Point(14, 312);
            this.lineItem4.Name = "lineItem4";
            this.lineItem4.Size = new System.Drawing.Size(509, 62);
            this.lineItem4.TabIndex = 4;
            // 
            // Messages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lineItem4);
            this.Controls.Add(this.lineItem3);
            this.Controls.Add(this.lineItem2);
            this.Controls.Add(this.lineItem1);
            this.Controls.Add(this.controlHeader1);
            this.Name = "Messages";
            this.Size = new System.Drawing.Size(553, 540);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlHeader controlHeader1;
        private LineItem lineItem1;
        private LineItem lineItem2;
        private LineItem lineItem3;
        private LineItem lineItem4;
    }
}
