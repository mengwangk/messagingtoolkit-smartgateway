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
using System.Text;
using System.Collections;

namespace MessagingToolkit.SmartGateway.Core.Helper
{
    /// <summary>
    /// The types of data sources that can be set.
    /// </summary>
    public enum DataSourceType { System, User }

    /// <summary>
    /// ODBC data source helper class
    /// </summary>
    public class OdbcDataSourceManager
    {
        // Returns a list of data source names from the local machine.
        public static SortedList<string, DataSourceType> GetAllDataSourceNames()
        {
            // Get the list of user DSN's first.
            SortedList<string, DataSourceType> dsnList = GetUserDataSourceNames();

            // Get list of System DSN's and add them to the first list.
            SortedList<string, DataSourceType> systemDsnList = GetSystemDataSourceNames();
            for (int i = 0; i < systemDsnList.Count; i++)
            {
                string sName = systemDsnList.Keys[i] as string;
                DataSourceType type = (DataSourceType)systemDsnList.Values[i];
                try
                {
                    // This dsn to the master list
                    dsnList.Add(sName, type);
                }
                catch 
                { 
                    // An exception can be thrown if the key being added is a duplicate so 
                    // we just catch it here and have to ignore it.
                }
            }

            return dsnList;
        }

        /// <summary>
        /// Gets all System data source names for the local machine.
        /// </summary>
        public static SortedList<string, DataSourceType> GetSystemDataSourceNames()
        {
            SortedList<string, DataSourceType> dsnList = new SortedList<string, DataSourceType>();
            

            // get system dsn's
            Microsoft.Win32.RegistryKey reg = (Microsoft.Win32.Registry.LocalMachine).OpenSubKey("Software");
            if (reg != null)
            {
                reg = reg.OpenSubKey("ODBC");
                if (reg != null)
                {
                    reg = reg.OpenSubKey("ODBC.INI");
                    if (reg != null)
                    {
                        reg = reg.OpenSubKey("ODBC Data Sources");
                        if (reg != null)
                        {
                            // Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
                            foreach (string sName in reg.GetValueNames())
                            {
                                dsnList.Add(sName, DataSourceType.System);
                            }
                        }
                        try
                        {
                            reg.Close();
                        }
                        catch { /* ignore this exception if we couldn't close */ }
                    }
                }
            }

            return dsnList;
        }

        /// <summary>
        /// Gets all User data source names for the local machine.
        /// </summary>
        public static SortedList<string, DataSourceType> GetUserDataSourceNames()
        {
            SortedList<string, DataSourceType> dsnList = new SortedList<string, DataSourceType>();

            // get user dsn's
            Microsoft.Win32.RegistryKey reg = (Microsoft.Win32.Registry.CurrentUser).OpenSubKey("Software");
            if (reg != null)
            {
                reg = reg.OpenSubKey("ODBC");
                if (reg != null)
                {
                    reg = reg.OpenSubKey("ODBC.INI");
                    if (reg != null)
                    {
                        reg = reg.OpenSubKey("ODBC Data Sources");
                        if (reg != null)
                        {
                            // Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
                            foreach (string sName in reg.GetValueNames())
                            {
                                dsnList.Add(sName, DataSourceType.User);
                            }
                        }
                        try
                        {
                            reg.Close();
                        }
                        catch { /* ignore this exception if we couldn't close */ }
                    }
                }
            }

            return dsnList;
        }

    }
}
