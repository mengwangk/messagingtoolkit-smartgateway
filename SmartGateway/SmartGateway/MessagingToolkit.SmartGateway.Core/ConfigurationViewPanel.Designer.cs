namespace MessagingToolkit.SmartGateway.Core
{
    partial class ConfigurationViewPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationViewPanel));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvwSystemSettings = new MessagingToolkit.UI.DataListView();
            this.olvColProperty = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColValue = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.olvColModule = ((MessagingToolkit.UI.OLVColumn)(new MessagingToolkit.UI.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApplySettings = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.controlHeader1 = new MessagingToolkit.SmartGateway.Core.ControlHeader();
            ((System.ComponentModel.ISupportInitialize)(this.lvwSystemSettings)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "settings_icon.png");
            // 
            // lvwSystemSettings
            // 
            this.lvwSystemSettings.AllColumns.Add(this.olvColProperty);
            this.lvwSystemSettings.AllColumns.Add(this.olvColValue);
            this.lvwSystemSettings.AllColumns.Add(this.olvColModule);
            this.lvwSystemSettings.AllowColumnReorder = true;
            this.lvwSystemSettings.AllowDrop = true;
            this.lvwSystemSettings.CellEditActivation = MessagingToolkit.UI.ObjectListView.CellEditActivateMode.SingleClick;
            this.lvwSystemSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColProperty,
            this.olvColValue,
            this.olvColModule});
            this.lvwSystemSettings.DataSource = null;
            this.lvwSystemSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSystemSettings.FullRowSelect = true;
            this.lvwSystemSettings.GridLines = true;
            this.lvwSystemSettings.Location = new System.Drawing.Point(0, 101);
            this.lvwSystemSettings.Name = "lvwSystemSettings";
            this.lvwSystemSettings.ShowGroups = false;
            this.lvwSystemSettings.Size = new System.Drawing.Size(700, 572);
            this.lvwSystemSettings.TabIndex = 4;
            this.lvwSystemSettings.UseCellFormatEvents = true;
            this.lvwSystemSettings.UseCompatibleStateImageBehavior = false;
            this.lvwSystemSettings.View = System.Windows.Forms.View.Details;
            // 
            // olvColProperty
            // 
            this.olvColProperty.Text = "Property";
            this.olvColProperty.Width = 250;
            // 
            // olvColValue
            // 
            this.olvColValue.AspectName = "Value";
            this.olvColValue.Text = "Value";
            this.olvColValue.Width = 270;
            // 
            // olvColModule
            // 
            this.olvColModule.FillsFreeSpace = true;
            this.olvColModule.IsEditable = false;
            this.olvColModule.Text = "Module";
            this.olvColModule.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApplySettings);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 587);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 86);
            this.panel1.TabIndex = 5;
            // 
            // btnApplySettings
            // 
            this.btnApplySettings.Location = new System.Drawing.Point(178, 23);
            this.btnApplySettings.Name = "btnApplySettings";
            this.btnApplySettings.Size = new System.Drawing.Size(130, 34);
            this.btnApplySettings.TabIndex = 1;
            this.btnApplySettings.Text = "Apply";
            this.btnApplySettings.UseVisualStyleBackColor = true;
            this.btnApplySettings.Click += new System.EventHandler(this.btnApplySettings_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(325, 23);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 34);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // controlHeader1
            // 
            this.controlHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHeader1.Location = new System.Drawing.Point(0, 0);
            this.controlHeader1.Logo = ((System.Drawing.Bitmap)(resources.GetObject("controlHeader1.Logo")));
            this.controlHeader1.Name = "controlHeader1";
            this.controlHeader1.Size = new System.Drawing.Size(700, 101);
            this.controlHeader1.SubTitle = "Settings";
            this.controlHeader1.TabIndex = 1;
            this.controlHeader1.Title = "MessagingToolkit SmartGateway";
            // 
            // ConfigurationViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvwSystemSettings);
            this.Controls.Add(this.controlHeader1);
            this.Name = "ConfigurationViewPanel";
            this.Size = new System.Drawing.Size(700, 673);
            this.Load += new System.EventHandler(this.ConfigurationViewPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvwSystemSettings)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlHeader controlHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private UI.DataListView lvwSystemSettings;
        private UI.OLVColumn olvColProperty;
        private UI.OLVColumn olvColValue;
        private UI.OLVColumn olvColModule;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApplySettings;
        private System.Windows.Forms.Button btnReset;


    }
}
