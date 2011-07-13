namespace MessagingToolkit.SmartGateway.Core
{
    partial class Applications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Applications));
            this.controlHeader1 = new MessagingToolkit.SmartGateway.Core.ControlHeader();
            this.lnmDatabaseMessenger = new MessagingToolkit.SmartGateway.Core.LineItem();
            this.SuspendLayout();
            // 
            // controlHeader1
            // 
            this.controlHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHeader1.Location = new System.Drawing.Point(0, 0);
            this.controlHeader1.Logo = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.application_sidebar_list;
            this.controlHeader1.Name = "controlHeader1";
            this.controlHeader1.Size = new System.Drawing.Size(526, 77);
            this.controlHeader1.SubTitle = "Applications";
            this.controlHeader1.TabIndex = 4;
            this.controlHeader1.Title = "MessagingToolkit SmartGateway";
            // 
            // lnmDatabaseMessenger
            // 
            this.lnmDatabaseMessenger.LinkDescription = "Retrieve and send messages from database table";
            this.lnmDatabaseMessenger.LinkImage = ((System.Drawing.Bitmap)(resources.GetObject("lnmDatabaseMessenger.LinkImage")));
            this.lnmDatabaseMessenger.LinkName = "Database Messenger";
            this.lnmDatabaseMessenger.LinkToClass = "ctlDatabaseMessenger";
            this.lnmDatabaseMessenger.LinkToModule = "";
            this.lnmDatabaseMessenger.Location = new System.Drawing.Point(16, 103);
            this.lnmDatabaseMessenger.Name = "lnmDatabaseMessenger";
            this.lnmDatabaseMessenger.Size = new System.Drawing.Size(452, 56);
            this.lnmDatabaseMessenger.TabIndex = 5;
            // 
            // Applications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnmDatabaseMessenger);
            this.Controls.Add(this.controlHeader1);
            this.Name = "Applications";
            this.Size = new System.Drawing.Size(526, 593);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlHeader controlHeader1;
        private LineItem lnmDatabaseMessenger;
    }
}
