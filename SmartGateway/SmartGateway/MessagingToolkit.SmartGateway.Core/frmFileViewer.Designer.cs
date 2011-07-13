namespace MessagingToolkit.SmartGateway.Core
{
    partial class frmFileViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileViewer));
            this.logMonitor1 = new MessagingToolkit.SmartGateway.Core.LogMonitor();
            this.SuspendLayout();
            // 
            // logMonitor1
            // 
            this.logMonitor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logMonitor1.FileName = null;
            this.logMonitor1.Location = new System.Drawing.Point(0, 0);
            this.logMonitor1.Name = "logMonitor1";
            this.logMonitor1.Size = new System.Drawing.Size(688, 515);
            this.logMonitor1.TabIndex = 0;
            this.logMonitor1.UpdateEnabled = true;
            this.logMonitor1.UpdateInterval = 1000;
            this.logMonitor1.ViewEnd = true;
            this.logMonitor1.WatchMethod = MessagingToolkit.SmartGateway.Core.LogMonitor.MonitoringMethod.LastWriteTimestamp;
            // 
            // frmFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 515);
            this.Controls.Add(this.logMonitor1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFileViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Viewer";
            this.Load += new System.EventHandler(this.frmFileViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LogMonitor logMonitor1;

    }
}