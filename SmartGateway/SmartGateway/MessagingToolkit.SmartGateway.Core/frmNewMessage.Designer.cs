namespace MessagingToolkit.SmartGateway.Core
{
    partial class frmNewMessage
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
            this.newMessage1 = new MessagingToolkit.SmartGateway.Core.NewMessage();
            this.SuspendLayout();
            // 
            // newMessage1
            // 
            this.newMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newMessage1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.newMessage1.Location = new System.Drawing.Point(0, 0);
            this.newMessage1.MessageContent = "";
            this.newMessage1.Name = "newMessage1";
            this.newMessage1.Size = new System.Drawing.Size(853, 652);
            this.newMessage1.TabIndex = 0;
            this.newMessage1.To = "";
            // 
            // frmNewMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 652);
            this.Controls.Add(this.newMessage1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewMessage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Message";
            this.Load += new System.EventHandler(this.frmNewMessage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMessage newMessage1;
    }
}