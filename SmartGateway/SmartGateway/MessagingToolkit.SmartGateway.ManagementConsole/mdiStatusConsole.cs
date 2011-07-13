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
using System.Collections.Specialized;
using System.IO;
using System.Reflection;

using log4net;
using MessagingToolkit.SmartGateway.Core;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.ManagementConsole
{
    /// <summary>
    /// Status console MDI form
    /// </summary>
    public partial class mdiStatusConsole : Form
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Stored initialized forms
        /// </summary>
        private static HybridDictionary InitializedForms = new HybridDictionary();

        private int childFormNumber = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="mdiStatusConsole"/> class.
        /// </summary>
        public mdiStatusConsole()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the new form.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

       
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        /// <summary>
        /// Handles the Load event of the mdiStatusConsole control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mdiStatusConsole_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            LoadFile(AppConfigSettings.GetString(ConfigParameter.ApplicationLogFileName, ModuleName.Console));
            LoadFile(AppConfigSettings.GetString(ConfigParameter.ServiceLogFileName, ModuleName.Service));
            LayoutMdi(MdiLayout.TileVertical);
        }


        /// <summary>
        /// Loads the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private void LoadFile(string fileName)
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string logFileName = Path.Combine(currentDirectory, fileName);
            if (File.Exists(logFileName))
            {
                log.Info(string.Format("Loading {0}", Path.GetFileName(logFileName)));
                LoadFormType(typeof(frmFileViewer), logFileName);
                //log.Info(string.Format("{0} is loaded", Path.GetFileName(logFileName)));
            }
            else
            {
                log.Info(string.Format("Unable to find {0}", logFileName));
            }
        }

        private static frmFileViewer GetForm(Type formType, string fileName)
        {
            return (frmFileViewer)InitializedForms[formType.Name + fileName];
        }

        
        private void LoadFormType(Type formType, string logFileName)
        {
            if (IsAlreadyLoaded(typeof(frmFileViewer), logFileName))
            {
                Form f = GetForm(typeof(frmFileViewer), logFileName);
                f.Focus();
                return;
            }

            /*
            frmFileViewer fileViewer = new frmFileViewer();
            fileViewer.FileName = logFileName;
            fileViewer.MdiParent = this;
            fileViewer.Closed += new EventHandler(Form_Closed);
            fileViewer.Show();
            */
            frmFileViewer fileViewer = Activator.CreateInstance(formType) as frmFileViewer;
            fileViewer.FileName = logFileName;
            fileViewer.MdiParent = this;
            fileViewer.Text = Path.GetFileName(logFileName);
            fileViewer.Closed += new EventHandler(FormClosed);
            fileViewer.Show();

            FlagAsLoaded(typeof(frmFileViewer), logFileName);          
          
        }
        

        private void FlagAsLoaded(Type formType, string fileName)
        {
            InitializedForms[formType.Name + fileName] = true;
        }

        private void FlagAsNotLoaded(Type formType, string fileName)
        {
            InitializedForms[formType.Name + fileName] = false;
        }
        
        private bool IsAlreadyLoaded(Type formType, string fileName)
        {
            return ((InitializedForms[formType.Name + fileName] != null) &&
                  (bool)InitializedForms[formType.Name + fileName] == true);
        }

        private void FormClosed(object sender, EventArgs e)
        {
            Form closingForm = (Form)sender;
            closingForm.Closed -= new EventHandler(FormClosed);
            if (closingForm is frmFileViewer)
            {
                frmFileViewer fileViewer = (frmFileViewer)closingForm;
                FlagAsNotLoaded(sender.GetType(), fileViewer.FileName);                
                fileViewer = null;
            }         
            
        }
      
    }
}
