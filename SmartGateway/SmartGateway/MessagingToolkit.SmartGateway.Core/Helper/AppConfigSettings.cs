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

using log4net;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;

namespace MessagingToolkit.SmartGateway.Core.Helper
{
    /// <summary>
    /// Read configuration settings from AppConfig database table
    /// </summary>
    public static class AppConfigSettings 
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static string GetString(string propertyName) 
        {
            string propertyValue = string.Empty;
            AppConfig config = AppConfig.SingleOrDefault(c => c.Name == propertyName);
            if (config != null)
                propertyValue = config.Value;
            return propertyValue;
        }
               


        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="moduleName">Name of the module.</param>
        /// <returns></returns>
        public static string GetString(string propertyName, string moduleName)
        {
            string propertyValue = string.Empty;
            AppConfig config = AppConfig.SingleOrDefault(c => c.Name == propertyName && c.Module == moduleName);
            if (config != null)
                propertyValue = config.Value;
            return propertyValue;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static int GetInt(string propertyName)
        {
            try
            {
                AppConfig config = AppConfig.SingleOrDefault(c => c.Name == propertyName);
                if (config != null)
                {
                    return int.Parse(config.Value);
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error retrieving property [{0}]", propertyName), ex);
            }
            return 0;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="moduleName">Name of the module.</param>
        /// <returns></returns>
        public static int GetInt(string propertyName, string moduleName)
        {
            try
            {
                AppConfig config = AppConfig.SingleOrDefault(c => c.Name == propertyName && c.Module == moduleName);
                if (config != null)
                    return int.Parse(config.Value);
            }             
            catch (Exception ex)
            {
                log.Error(string.Format("Error retrieving property [{0}], module [{1}]", propertyName, moduleName), ex);
            }
            return 0;
        }


        /// <summary>
        /// Saves the specified property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool Save(string propertyName, string moduleName, string value) 
        {
            try
            {
                AppConfig config = new AppConfig();
                config.Name = propertyName;
                config.Module = moduleName;
                config.Value = value;
                config.Description = propertyName;
                config.Save();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error saving property [{0}], module [{1}], value [{2}]", propertyName, moduleName, value), ex);
                return false;
            }
            return true;
        }


        /// <summary>
        /// Saves the specified property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool Save(string propertyName, string value)
        {
            return Save(propertyName, string.Empty, value);
        }

        /// <summary>
        /// Updates the specified property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool Update(string propertyName, string moduleName, string value)
        {
            try
            {
                AppConfig config = AppConfig.SingleOrDefault(ac => ac.Name == propertyName && ac.Module == moduleName);
                config.Value = value;
                config.Description = propertyName;
                config.Update();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error updating property [{0}], module [{1}], value [{2}]", propertyName, moduleName, value), ex);
                return false;
            }
            return true;            
        }


        /// <summary>
        /// Updates the specified property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool Update(string propertyName, string value)
        {
            try
            {
                AppConfig config = AppConfig.SingleOrDefault(ac => ac.Name == propertyName);
                config.Value = value;
                config.Description = propertyName;
                config.Update();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error updating property [{0}], value [{1}]", propertyName, value), ex);
                return false;
            }
            return true;
        }
    }
}
