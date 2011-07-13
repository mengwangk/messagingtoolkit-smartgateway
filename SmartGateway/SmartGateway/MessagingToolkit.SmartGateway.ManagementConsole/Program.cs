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
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.Reflection;
using System.IO;

using log4net;
using MessagingToolkit.SmartGateway.Core;
using MessagingToolkit.SmartGateway.Core.Helper;
using MessagingToolkit.SmartGateway.ManagementConsole.Properties;

namespace MessagingToolkit.SmartGateway.ManagementConsole
{
    /// <summary>
    /// Program entry point
    /// </summary>
    static class Program
    {        
        /// <summary>
        /// Mutex to control program instances
        /// </summary>
        public static Mutex mutex;

        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                
        /// <summary>
        /// Mutex name
        /// </summary>
        private static string MutexName = Application.ProductName;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            try
            {                
                bool firstInstance;
                mutex = new Mutex(false, MutexName, out firstInstance);

                if (!firstInstance)
                {
                    FormHelper.ShowInfo(Resources.MsgInstanceRunning);
                    Application.Exit();
                }
                else
                {                   
                    // Configure the settings
                    ConfigureAppConfig();

                    Application.Run(new frmControlPanel());
                    //Application.Run(new frmTestForm());
                    //Application.Run(new frmGateway());
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
                while (ex.InnerException != null)
                {
                    FormHelper.ShowError(ex.InnerException.Message);
                    ex = ex.InnerException;

                }
            }
        }

        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            log.Error(string.Format("An error has occurred. Production version is [{0}]", Application.ProductVersion));
            log.Error(ex.Message + Environment.NewLine + ex.Source + Environment.NewLine +
                      ex.StackTrace + Environment.NewLine + ex.InnerException + Environment.NewLine +
                      ex.Data + Environment.NewLine + ex.HelpLink, ex);
        }

        /// <summary>
        /// Handles the ThreadException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Threading.ThreadExceptionEventArgs"/> instance containing the event data.</param>
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {           
            log.Error(string.Format("An error has occurred. Production version is [{0}]", Application.ProductVersion));
            log.Error(e.Exception.Message + Environment.NewLine + e.Exception.Source + Environment.NewLine +
                    e.Exception.StackTrace + Environment.NewLine + e.Exception.InnerException + Environment.NewLine +
                    e.Exception.Data + Environment.NewLine + e.Exception.HelpLink, e.Exception);
        }

        /// <summary>
        /// Configures the application configuration
        /// </summary>
        static void ConfigureAppConfig()
        {   
            /*
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Get the connection strings section.
            ConnectionStringsSection csSection = config.ConnectionStrings;
            string dataSource = csSection.ConnectionStrings[ConfigParameter.ConnectionStringName].ConnectionString;
            if (dataSource.Equals(ConfigParameter.DataSourceVariable))
            {
                string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string db = "Data Source=" + Path.Combine(currentDirectory, ConfigParameter.SqLiteDbName);
                csSection.ConnectionStrings[ConfigParameter.ConnectionStringName].ConnectionString = db;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection(config.ConnectionStrings.SectionInformation.SectionName);
            }
            */
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            AppDomain.CurrentDomain.SetData("DataDirectory", currentDirectory);
        }

       
    }
}
