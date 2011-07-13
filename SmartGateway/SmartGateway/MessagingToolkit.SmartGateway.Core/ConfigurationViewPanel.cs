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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Transactions;
using log4net;

using MessagingToolkit.UI;
using MessagingToolkit.Core;
using MessagingToolkit.Core.Helper;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// User control to view the configuration properties
    /// </summary>
    public partial class ConfigurationViewPanel : UserControl
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       
        /// <summary>
        /// Modified configurations
        /// </summary>
        private Dictionary<string, AppConfig> modifyConfigs = new Dictionary<string, AppConfig>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationViewPanel"/> class.
        /// </summary>
        public ConfigurationViewPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ConfigurationViewPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ConfigurationViewPanel_Load(object sender, EventArgs e)
        {
            // Return in control design mode
            if (this.DesignMode) return;

            SetupView();

            SetupSettings();
        }


        /// <summary>
        /// Setups the view.
        /// </summary>
        private void SetupView()
        {                    
            this.olvColProperty.AspectGetter = delegate(object x) { return ((AppConfig)x).Description; };
            this.olvColValue.AspectGetter = delegate(object x) { return ((AppConfig)x).Value; };
            this.olvColModule.AspectGetter = delegate(object x) { return ((AppConfig)x).Module; };

            this.olvColValue.AspectPutter = 
                                            delegate(object x, object newValue) 
                                            {   
                                                AppConfig config = ((AppConfig)x);
                                                config.Value = ((string)newValue);
                                                modifyConfigs[config.Name + GuiHelper.FieldSplitter + config.Module] = config;

                                                /*
                                                if (config.Name.Equals(ConfigParameter.LicenseKey, StringComparison.OrdinalIgnoreCase))
                                                {
                                                    config.Value = GuiHelper.LicenseKeyMask;
                                                }
                                                */
                                            };
            
        }

        /// <summary>
        /// Setups the settings.
        /// </summary>
        private void SetupSettings()
        {           
            lvwSystemSettings.BeginUpdate();
            lvwSystemSettings.ClearObjects();

            lvwSystemSettings.SetObjects(AppConfig.All().Where(config=>config.Configurable == true).OrderBy(s => s.Module));

            //lvwSystemSettings.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwSystemSettings.EndUpdate();
            lvwSystemSettings.Refresh();

        }


        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                foreach (AppConfig config in modifyConfigs.Values)
                {
                    config.Update();
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
            finally
            {
                modifyConfigs.Clear();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnApplySettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnApplySettings_Click(object sender, EventArgs e)
        {
            if (FormHelper.Confirm(Resources.MsgApplySettings) == DialogResult.Yes)
            {                
                SaveSettings();
                /*
                try
                {
                    this.Dispose();
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    log.Error(string.Format("Error restarting application: {0}", ex.Message), ex);
                }
                */
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (FormHelper.Confirm(Resources.MsgResetSettings) == DialogResult.Yes)
            {
                SetupSettings();
            }
        }       
        
    }
}
