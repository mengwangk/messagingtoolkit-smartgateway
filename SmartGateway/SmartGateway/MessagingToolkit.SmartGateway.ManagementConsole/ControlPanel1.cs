//===============================================================================
// OSML - Open Source Messaging Library
//
//===============================================================================
// Copyright © TWIT88.COM.  All rights reserved.
//
// This file is part of Open Source Messaging Library.
//
// Open Source Messaging Library is free software: you can redistribute it 
// and/or modify it under the terms of the GNU General Public License version 3.
//
// Open Source Messaging Library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this software.  If not, see <http://www.gnu.org/licenses/>.
//===============================================================================


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Configuration;

using log4net;
using MessagingToolkit.SmartGateway.Core.Web;
using MessagingToolkit.SmartGateway.ManagementConsole.Properties;

namespace MessagingToolkit.SmartGateway.ManagementConsole
{
    public partial class ControlPanel1 : Form
    {
        // ------- Static Logger --------------------------
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // -------- Private Constants --------------------
        private const string PortalFolderName = "Portal";
        private const string PortalDefaultPort = "9090";
        private const string PortalDefaultVirtualRoot = "/";

        // the web server
        private WebServer server;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementConsole"/> class.
        /// </summary>
        public ControlPanel1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ManagementConsole control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ManagementConsole_Load(object sender, EventArgs e)
        {
            InitializeApp();
        }

        /// <summary>
        /// Initializes the application
        /// </summary>
        private void InitializeApp()
        {
            // Current directory
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            // Initialize web tab
            txtApplicationDirectory.Text = currentDirectory + Path.DirectorySeparatorChar + PortalFolderName;
            txtPort.Text = PortalDefaultPort;
            txtVirtualRoot.Text = PortalDefaultVirtualRoot;
            lblWebApplicationStatus.Text = "Stopped";
            
        }

        private void btnStartWebApplication_Click(object sender, EventArgs e)
        {
            string appPath = txtApplicationDirectory.Text;
            if (appPath.Length == 0 || !Directory.Exists(appPath))
            {
                ShowError("Invalid Application Directory");
                txtApplicationDirectory.SelectAll();
                txtApplicationDirectory.Focus();
                return;
            }

            string portString = txtPort.Text;
            int portNumber = -1;
            try
            {
                portNumber = Int32.Parse(portString);
            }
            catch
            {
            }
            if (portNumber <= 0)
            {
                ShowError("Invalid port");
                txtPort.SelectAll();
                txtPort.Focus();
                return;
            }

            string virtRoot = txtVirtualRoot.Text;
            if (virtRoot.Length == 0 || !virtRoot.StartsWith("/"))
            {
                ShowError("Invalid Virtual Root");
                txtVirtualRoot.SelectAll();
                txtVirtualRoot.Focus();
                return;
            }

            try
            {
                server = new WebServer(portNumber, virtRoot, appPath);
                server.Start();
            }
            catch
            {
                ShowError(
                    "MessagingToolkit MessageServer failed to start listening on port " + portNumber + ".\r\n" +
                    "Possible conflict with another Web Server on the same port.");
                txtPort.SelectAll();
                txtPort.Focus();
                return;
            }

            btnStartWebApplication.Enabled = false;
            txtApplicationDirectory.Enabled = false;
            txtPort.Enabled = false;
            txtVirtualRoot.Enabled = false;

            lnkWebPortal.Text = GetLinkText();
            lnkWebPortal.Focus();
        }

        private string GetLinkText()
        {
            string s = "http://localhost";
            if (txtPort.Text != "80") s += ":" + txtPort.Text;        
            if (!s.EndsWith("/")) s += "/";
            return s;
        }

        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnStopWebApplication_Click(object sender, EventArgs e)
        {
            try
            {
                if (server != null)
                    server.Stop();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                server = null;
            }          
        }

        private void btnAddGateway_Click(object sender, EventArgs e)
        {
            frmAddGateway addGateway = new frmAddGateway();
            addGateway.ShowDialog(this);
        }

        private void tabMain_Click(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;
            if (tc.SelectedTab == tabAbout)
            {
                Assembly assembly = Assembly.GetAssembly(this.GetType());
                string name = assembly.GetName().Name;
                string version = assembly.GetName().Version.ToString();
                string title = string.Empty;
                string description = string.Empty;
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length == 1)
                {
                    title = ((AssemblyTitleAttribute)attributes[0]).Title;
                }
                attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 1)
                {
                    description = ((AssemblyDescriptionAttribute)attributes[0]).Description;
                }
                lblAbout.Text = title + Environment.NewLine + version;
            }
        }
    }
}
