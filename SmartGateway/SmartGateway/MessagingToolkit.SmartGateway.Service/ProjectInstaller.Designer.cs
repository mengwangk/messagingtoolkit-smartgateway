namespace MessagingToolkit.SmartGateway.Service
{
    partial class ProjectInstaller
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
            this.SmartGatewayProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SmartGatewayServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // SmartGatewayProcessInstaller
            // 
            this.SmartGatewayProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.SmartGatewayProcessInstaller.Password = null;
            this.SmartGatewayProcessInstaller.Username = null;
            // 
            // SmartGatewayServiceInstaller
            // 
            this.SmartGatewayServiceInstaller.Description = "Messaging server for SmartGateway";
            this.SmartGatewayServiceInstaller.DisplayName = "MessagingToolkit SmartGateway Message Server";
            this.SmartGatewayServiceInstaller.ServiceName = "MessagingToolkit SmartGateway Message Server";
            this.SmartGatewayServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SmartGatewayProcessInstaller,
            this.SmartGatewayServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SmartGatewayProcessInstaller;
        private System.ServiceProcess.ServiceInstaller SmartGatewayServiceInstaller;
    }
}