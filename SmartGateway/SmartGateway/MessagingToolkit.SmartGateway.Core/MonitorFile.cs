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
using System.IO;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// User control to monitor file
    /// </summary>
    public partial class MonitorFile : UserControl
    {
        /// <summary>
        /// Text control callback
        /// </summary>
        private delegate void SetTextCallback(string text);

        /// <summary>
        /// File viewer instance
        /// </summary>
        private FileViewer fileViewer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorFile"/> class.
        /// </summary>
        public MonitorFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// Starts this monitoring process
        /// </summary>
        public void Start()
        {
            if (string.IsNullOrEmpty(FileName) || !File.Exists(FileName))
            {
                return;
            }

            this.txtFileContent.Text = string.Empty;
            fileViewer = new FileViewer(FileName);
            fileViewer.MoreData += new FileViewer.MoreDataHandler(FileViewer_MoreData);
            fileViewer.Start();
        }

        /// <summary>
        /// Files the viewer_ more data.
        /// </summary>
        /// <param name="tailObject">The tail object.</param>
        /// <param name="newData">The new data.</param>
        private void FileViewer_MoreData(object tailObject, string newData)
        {
            /*
			int maxChars = (int) this.maxCharsNumericUpDown.Value;
			if(newData.Length > maxChars)
			{
				newData = newData.Remove(0, newData.Length-maxChars);
			}
			int newLength = this.tailFileContentsTextbox.Text.Length + newData.Length;
			if (newLength > maxChars)
			{
				this.tailFileContentsTextbox.Text = this.tailFileContentsTextbox.Text.Remove(0, newLength-(int)maxChars);
			}
            */
            Output(newData);            
        }

        /// <summary>
        /// Outputs the specified new data.
        /// </summary>
        /// <param name="newData">The new data.</param>
        private void Output(string newData)
        {
            if (this.txtFileContent.InvokeRequired)
            {
                SetTextCallback stc = new SetTextCallback(Output);
                this.Invoke(stc, new object[] { newData });
            }
            else
            {
                if (this.txtFileContent.IsDisposed) return;
                this.txtFileContent.AppendText(newData);
                this.txtFileContent.SelectionLength = 0;
                this.txtFileContent.SelectionStart = this.txtFileContent.Text.Length;
                this.txtFileContent.ScrollToCaret();                
            }
           
        }

    }
}
