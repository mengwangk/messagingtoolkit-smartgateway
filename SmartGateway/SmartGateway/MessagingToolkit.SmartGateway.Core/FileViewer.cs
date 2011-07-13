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
using System.IO;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// View and tail a file
    /// </summary>
    internal class FileViewer
    {
        private string filename = string.Empty;
        private FileSystemWatcher fileSystemWatcher = null;
        private long previousSeekPosition;

        public delegate void MoreDataHandler(object sender, string newData);
        public event MoreDataHandler MoreData;
        private int maxBytes = 1024 * 16;

        /// <summary>
        /// Gets or sets the max bytes.
        /// </summary>
        /// <value>The max bytes.</value>
        public int MaxBytes
        {
            get 
            { 
                return this.maxBytes; 
            }
            set 
            { 
                this.maxBytes = value; 
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileViewer"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public FileViewer(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            FileInfo targetFile = new FileInfo(this.filename);

            previousSeekPosition = 0;

            if (fileSystemWatcher != null) 
                Stop();

            fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.IncludeSubdirectories = true;
            fileSystemWatcher.Path = targetFile.DirectoryName;
            fileSystemWatcher.Filter = targetFile.Name;
            
            fileSystemWatcher.InternalBufferSize = 8 * 8192;
            //fileSystemWatcher.NotifyFilter = NotifyFilters.Size;
            //fileSystemWatcher.Disposed += new EventHandler(fileSystemWatcher_Disposed);

            if (!targetFile.Exists)
            {
                fileSystemWatcher.Created += new FileSystemEventHandler(TargetFile_Created);
                fileSystemWatcher.EnableRaisingEvents = true;
            }
            else
            {
                TargetFile_Changed(null, null);
                StartMonitoring();
            }
        }

      
        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            fileSystemWatcher.Dispose();
            fileSystemWatcher = null;
        }

        /// <summary>
        /// Reads the full file.
        /// </summary>
        /// <returns></returns>
        public string ReadFullFile()
        {
            using (StreamReader streamReader = new StreamReader(this.filename))
            {
                return streamReader.ReadToEnd();
            }
        }

        /// <summary>
        /// Starts the monitoring.
        /// </summary>
        public void StartMonitoring()
        {
            fileSystemWatcher.Changed += new FileSystemEventHandler(TargetFile_Changed);
            fileSystemWatcher.EnableRaisingEvents = true;            
        }

        /// <summary>
        /// Handles the Created event of the TargetFile control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="System.IO.FileSystemEventArgs"/> instance containing the event data.</param>
        public void TargetFile_Created(object source, FileSystemEventArgs e)
        {
            StartMonitoring();
        }

        /// <summary>
        /// Handles the Changed event of the TargetFile control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="System.IO.FileSystemEventArgs"/> instance containing the event data.</param>
        public void TargetFile_Changed(object source, FileSystemEventArgs e)
        {
            //lock (this)
            {
                //read from current seek position to end of file
                byte[] bytesRead = new byte[maxBytes];
                FileStream fs = new FileStream(this.filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if (fs.Length > maxBytes)
                {
                    this.previousSeekPosition = fs.Length - maxBytes;
                }
                this.previousSeekPosition = (int)fs.Seek(this.previousSeekPosition, SeekOrigin.Begin);
                int numBytes = fs.Read(bytesRead, 0, maxBytes);
                fs.Close();
                this.previousSeekPosition += numBytes;

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < numBytes; i++)
                {
                    sb.Append((char)bytesRead[i]);
                }

                //call delegates with the string
                this.MoreData(this, sb.ToString());
            }
        }
    }
}
