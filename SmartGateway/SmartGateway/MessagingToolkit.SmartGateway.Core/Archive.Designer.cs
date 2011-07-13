namespace MessagingToolkit.SmartGateway.Core
{
    partial class Archive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Archive));
            this.lineItem2 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.lineItem1 = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.controlHeader1 = new MessagingToolkit.SmartGateway.Core.ControlHeader();
            this.SuspendLayout();
            // 
            // lineItem2
            // 
            this.lineItem2.LinkDescription = "Archive of outgoing messages.";
            this.lineItem2.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem2.LinkImage")));
            this.lineItem2.LinkName = "Outgoing Message Archive";
            this.lineItem2.LinkToClass = "ctlArchivedOutbox";
            this.lineItem2.LinkToModule = "";
            this.lineItem2.Location = new System.Drawing.Point(3, 185);
            this.lineItem2.Name = "lineItem2";
            this.lineItem2.Size = new System.Drawing.Size(488, 62);
            this.lineItem2.TabIndex = 6;
            // 
            // lineItem1
            // 
            this.lineItem1.LinkDescription = "Archive of incoming messages.";
            this.lineItem1.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lineItem1.LinkImage")));
            this.lineItem1.LinkName = "Incoming Message Archive";
            this.lineItem1.LinkToClass = "ctlArchivedInbox";
            this.lineItem1.LinkToModule = "";
            this.lineItem1.Location = new System.Drawing.Point(3, 117);
            this.lineItem1.Name = "lineItem1";
            this.lineItem1.Size = new System.Drawing.Size(488, 62);
            this.lineItem1.TabIndex = 5;
            // 
            // controlHeader1
            // 
            this.controlHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHeader1.Location = new System.Drawing.Point(0, 0);
            this.controlHeader1.Logo = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.archive;
            this.controlHeader1.Name = "controlHeader1";
            this.controlHeader1.Size = new System.Drawing.Size(548, 89);
            this.controlHeader1.SubTitle = "Archive";
            this.controlHeader1.TabIndex = 4;
            this.controlHeader1.Title = "MessagingToolkit SmartGateway";
            // 
            // Archive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lineItem2);
            this.Controls.Add(this.lineItem1);
            this.Controls.Add(this.controlHeader1);
            this.Name = "Archive";
            this.Size = new System.Drawing.Size(548, 586);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlHeader controlHeader1;
        private LineItem lineItem1;
        private LineItem lineItem2;
    }
}
