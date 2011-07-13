namespace MessagingToolkit.SmartGateway.Core
{
    partial class MenuPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPanel));
            this.treeConfig = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeConfig
            // 
            this.treeConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeConfig.ImageIndex = 0;
            this.treeConfig.ImageList = this.imageList1;
            this.treeConfig.Location = new System.Drawing.Point(0, 0);
            this.treeConfig.Name = "treeConfig";
            this.treeConfig.SelectedImageIndex = 0;
            this.treeConfig.Size = new System.Drawing.Size(330, 628);
            this.treeConfig.TabIndex = 0;
            this.treeConfig.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeConfig_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "computer.png");
            this.imageList1.Images.SetKeyName(1, "page.png");
            this.imageList1.Images.SetKeyName(2, "connect.png");
            this.imageList1.Images.SetKeyName(3, "folder-open-document.png");
            this.imageList1.Images.SetKeyName(4, "mobile-phone.png");
            this.imageList1.Images.SetKeyName(5, "user.png");
            this.imageList1.Images.SetKeyName(6, "users.png");
            this.imageList1.Images.SetKeyName(7, "application-list.png");
            this.imageList1.Images.SetKeyName(8, "script_edit.png");
            this.imageList1.Images.SetKeyName(9, "address-book-open.png");
            this.imageList1.Images.SetKeyName(10, "contacts.png");
            this.imageList1.Images.SetKeyName(11, "mails.png");
            this.imageList1.Images.SetKeyName(12, "alarm-clock--pencil.png");
            this.imageList1.Images.SetKeyName(13, "help.png");
            this.imageList1.Images.SetKeyName(14, "mails-stack.png");
            this.imageList1.Images.SetKeyName(15, "layout.png");
            this.imageList1.Images.SetKeyName(16, "mail.png");
            this.imageList1.Images.SetKeyName(17, "mail-minus.png");
            this.imageList1.Images.SetKeyName(18, "mail-arrow.png");
            this.imageList1.Images.SetKeyName(19, "mail-send.png");
            this.imageList1.Images.SetKeyName(20, "mail-receive.png");
            this.imageList1.Images.SetKeyName(21, "mail-pencil.png");
            this.imageList1.Images.SetKeyName(22, "magnifier.png");
            this.imageList1.Images.SetKeyName(23, "application_form_edit.png");
            this.imageList1.Images.SetKeyName(24, "hosting.png");
            this.imageList1.Images.SetKeyName(25, "hammer.png");
            this.imageList1.Images.SetKeyName(26, "databases-relation.png");
            this.imageList1.Images.SetKeyName(27, "manual.png");
            this.imageList1.Images.SetKeyName(28, "license.png");
            this.imageList1.Images.SetKeyName(29, "contacts.png");
            this.imageList1.Images.SetKeyName(30, "users.png");
            this.imageList1.Images.SetKeyName(31, "groups.png");
            this.imageList1.Images.SetKeyName(32, "about.png");
            this.imageList1.Images.SetKeyName(33, "messenger.png");
            this.imageList1.Images.SetKeyName(34, "monitoring.png");
            // 
            // MenuPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeConfig);
            this.Name = "MenuPanel";
            this.Size = new System.Drawing.Size(330, 628);
            this.Load += new System.EventHandler(this.MenuPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeConfig;
        private System.Windows.Forms.ImageList imageList1;
    }
}
