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
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Configuration;
using System.Reflection;
using System.IO;

using log4net;
using MessagingToolkit.SmartGateway.Core;

namespace MessagingToolkit.SmartGateway.Service
{
    static class Program
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // Exception handling
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
          
            // Configure the application configuration file
            ConfigureAppConfig();

            if (!Environment.UserInteractive)
            {
                log.Info("Start Message Server as Windows service");
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			                    { 
				                    new MessagingService() 
			                    };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                log.Info("Interactive mode. Start the service for debugging");

                // Run as interactive exe in debug mode to allow easy
                // debugging.
                MessagingService service = new MessagingService();
                service.StartService();
                
                // Sleep the main thread indefinitely while the service code runs
                Thread.Sleep(Timeout.Infinite);

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
             log.Error(string.Format("Unhandled exception occurred: {0}", ex.Message), ex);
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
