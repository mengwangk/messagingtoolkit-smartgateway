namespace MessagingToolkit.SmartGateway.Core
{
    partial class LineItem
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
            this.lnkName = new System.Windows.Forms.LinkLabel();
            this.lnkDescription = new System.Windows.Forms.Label();
            this.picLinkImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLinkImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkName
            // 
            this.lnkName.AutoSize = true;
            this.lnkName.Location = new System.Drawing.Point(119, 13);
            this.lnkName.Name = "lnkName";
            this.lnkName.Size = new System.Drawing.Size(56, 13);
            this.lnkName.TabIndex = 1;
            this.lnkName.TabStop = true;
            this.lnkName.Text = "Link name";
            this.lnkName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkName_LinkClicked);
            // 
            // lnkDescription
            // 
            this.lnkDescription.AutoSize = true;
            this.lnkDescription.Location = new System.Drawing.Point(119, 37);
            this.lnkDescription.Name = "lnkDescription";
            this.lnkDescription.Size = new System.Drawing.Size(81, 13);
            this.lnkDescription.TabIndex = 2;
            this.lnkDescription.Text = "Link description";
            // 
            // picLinkImage
            // 
            this.picLinkImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLinkImage.Image = global::MessagingToolkit.SmartGateway.Core.Properties.Resources.mobile_phone_cast;
            this.picLinkImage.Location = new System.Drawing.Point(0, 3);
            this.picLinkImage.Name = "picLinkImage";
            this.picLinkImage.Size = new System.Drawing.Size(57, 56);
            this.picLinkImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLinkImage.TabIndex = 5;
            this.picLinkImage.TabStop = false;
            // 
            // LineItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picLinkImage);
            this.Controls.Add(this.lnkDescription);
            this.Controls.Add(this.lnkName);
            this.Name = "LineItem";
            this.Size = new System.Drawing.Size(509, 62);
            this.Load += new System.EventHandler(this.LineItem_Load);
            this.Resize += new System.EventHandler(this.LineItem_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picLinkImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkName;
        private System.Windows.Forms.Label lnkDescription;
        private System.Windows.Forms.PictureBox picLinkImage;
    }
}
