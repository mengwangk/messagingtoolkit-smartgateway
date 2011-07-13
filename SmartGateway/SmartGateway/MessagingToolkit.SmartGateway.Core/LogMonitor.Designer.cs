using System;
using System.IO;

namespace MessagingToolkit.SmartGateway.Core
{
    public partial class LogMonitor
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
            if (disposing)
            {
                if (components != null) components.Dispose();
                ClearMonitoringMethod();
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
            this._textBoxContents = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _textBoxContents
            // 
            this._textBoxContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBoxContents.Location = new System.Drawing.Point(0, 0);
            this._textBoxContents.Name = "_textBoxContents";
            this._textBoxContents.ReadOnly = true;
            this._textBoxContents.Size = new System.Drawing.Size(658, 651);
            this._textBoxContents.TabIndex = 0;
            this._textBoxContents.Text = "";
            // 
            // LogMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._textBoxContents);
            this.Name = "LogMonitor";
            this.Size = new System.Drawing.Size(658, 651);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _textBoxContents;

    }
}
