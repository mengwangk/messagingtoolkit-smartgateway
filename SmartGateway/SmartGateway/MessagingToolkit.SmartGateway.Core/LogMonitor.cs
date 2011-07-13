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
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using MessagingToolkit.SmartGateway.Core.Win32;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// A control to watch a log file (any text file).
    /// </summary>
    public partial class LogMonitor : UserControl
    {

        /// <summary>
        /// Default update interval. Set to 500 milliseconds
        /// </summary>
        private readonly int DefaultUpdateInterval = 500;

        //private FileInfo _fileInfo;

        #region ctors

        /// <summary>
        /// Initializes a <see cref="LogMonitorControl"/>
        /// </summary>
        public LogMonitor()
        {
            InitializeComponent();
            InitialSettings();
            //ReadSettings();
        }

        /// <summary>
        /// Initializes a <see cref="LogMonitorControl"/>
        /// </summary>
        /// <param name="fileName">The log file to monitor.</param>
        public LogMonitor(string fileName)
        {
            InitializeComponent();
            FileName = fileName;
            InitialSettings();
            //ReadSettings();
        }

        #endregion ctors

        #region Events

        /// <summary>
        /// Raised when the user wants to associate a new log file with this control.
        /// </summary>
        public EventHandler<EventArgs> BrowseForLogFile;

        /// <summary>
        /// Called when user wants to open a new log file.
        /// </summary>
        protected void OnBrowseForLogFile()
        {
            EventHandler<EventArgs> handler = BrowseForLogFile;
            if (null != handler)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raised when a change to the log file is detected.
        /// </summary>
        public EventHandler<EventArgs> LogFileChanged;

        /// <summary>
        /// Called when the log file has changed to inform listeners.
        /// </summary>
        protected void OnLogFileChanged()
        {
            EventHandler<EventArgs> handler = LogFileChanged;
            if (null != handler)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets or sets the current log file being monitored.  (Can be set to null)
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    //if (null == _fileName) _textBoxFileName.Text = "";
                    //else
                    //{
                    //if (!string.IsNullOrEmpty(_fileName) && File.Exists(_fileName))
                    //{
                    //    _fileInfo = new FileInfo(_fileName);
                    //}
                      //  _textBoxFileName.Text = value;
                        ClearMonitoringMethod();
                        //UpdateControlEnabledStatus(); // if file does not exist that makes immediate mode impossible
                        PrepareMonitoringMethod();
                        ReloadFile();
                    //}
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Disconnect from whatever monitoring method is being used.
        /// </summary>
        private void ClearMonitoringMethod()
        {
            ClearTimer();
            ClearWatcher();
        }

        /// <summary>
        /// Cleanup the <see cref="Timer"/>
        /// </summary>
        private void ClearTimer()
        {
            if (null != _timer)
            {
                _timer.Tick -= timer_Tick;
                _timer.Dispose();
                _timer = null;
            }
        }

        /// <summary>
        /// Cleanup the <see cref="FileSystemWatcher"/>
        /// </summary>
        private void ClearWatcher()
        {
            if (null != _watcher)
            {
                FileSystemEventHandler handler = new FileSystemEventHandler(watcher_Changed);
                _watcher.Changed -= handler;
                _watcher.Created -= handler;
                _watcher.Deleted -= handler;
                _watcher.Renamed -= watcher_Renamed;
                _watcher.Dispose();
                _watcher = null;
            }
        }

        /// <summary>
        /// Copy the current selection (or all text if no selection) to the clipboard.
        /// </summary>
        public void CopyToClipboard()
        {
            if (0 < _textBoxContents.SelectionLength) _textBoxContents.Copy();
            else Clipboard.SetText(_textBoxContents.Text);
        }

        /// <summary>
        /// Change the Enabled property of the controls based on the current state.
        /// </summary>
        /*
        private void UpdateControlEnabledStatus()
        {
            bool fileExists = false;
            if (null != _fileName) fileExists = File.Exists(_fileName);
            if (!_checkBoxUpdate.Checked)
            {
                // No updates desired
                _textBoxTimeInterval.Enabled = false;
                _radioButtonTimed.Enabled = false;
                _radioButtonImmediate.Enabled = false;
            }
            else
            {
                if (!fileExists)
                {
                    // If the file does not exist then immediate mode is not an option
                    _radioButtonTimed.Enabled = true;
                    _radioButtonImmediate.Enabled = false;
                    _radioButtonTimed.Checked = true;
                    _textBoxTimeInterval.Enabled = true;
                }
                else
                {
                    _radioButtonTimed.Enabled = true;
                    _radioButtonImmediate.Enabled = true;
                    if (_radioButtonTimed.Checked)
                    {
                        _textBoxTimeInterval.Enabled = true;
                    }
                    else
                    {
                        _textBoxTimeInterval.Enabled = false;
                    }
                }
            }
        }
        */

        /// <summary>
        /// Hook up for the currently selected monitoring method.
        /// </summary>
        private void PrepareMonitoringMethod()
        {
            if (WatchMethod == MonitoringMethod.FileSystemWatcher)
            {
                // stop timer if running
                ClearTimer();
                // If a file is set and the watcher has not been set up yet then create it
                if (null != _fileName && null == _watcher)
                {
                    string path = Path.GetDirectoryName(_fileName);
                    string baseName = Path.GetFileName(_fileName);
                    // Use the FileSystemWatcher class to detect changes to the log file immediately
                    // We must watch for Changed, Created, Deleted, and Renamed events to cover all cases
                    _watcher = new System.IO.FileSystemWatcher(path, baseName);
                    FileSystemEventHandler handler = new FileSystemEventHandler(watcher_Changed);
                    _watcher.Changed += handler;
                    _watcher.Created += handler;
                    _watcher.Deleted += handler;
                    _watcher.Renamed += watcher_Renamed;
                    // Without setting EnableRaisingEvents nothing happens
                    _watcher.EnableRaisingEvents = true;
                }
            }
            else
            {
                // On a timer so clear the watcher if previously set up
                ClearWatcher();
                if (null != _timer)
                {
                    // Timer is already running so just make sure the interval is correct
                    if (_timer.Interval != this.UpdateInterval)
                    {
                        _timer.Interval = this.UpdateInterval;
                    }
                }
                else
                {
                    // Fire up a timer if the user entered a valid time interval
                    if (0 != this.UpdateInterval)
                    {
                        _timer = new Timer();
                        _timer.Interval = this.UpdateInterval;
                        _timer.Tick += timer_Tick;
                        _timer.Start();
                    }
                }
            }
        }

        /// <summary>
        /// Read any initial settings from the config file.
        /// </summary>
        /*
        private void ReadSettings()
        {
            // Read from config file
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            bool temp = true;
            bool.TryParse(config.AppSettings.Settings["UpdatesEnabled"].Value, out temp);
            _checkBoxUpdate.Checked = temp;

            temp = true;
            bool.TryParse(config.AppSettings.Settings["TimedUpdate"].Value, out temp);
            _radioButtonTimed.Checked = temp;
            _radioButtonImmediate.Checked = !temp;
            _textBoxTimeInterval.Text = config.AppSettings.Settings["UpdateInterval"].Value;

            temp = true;
            bool.TryParse(config.AppSettings.Settings["AutoScroll"].Value, out temp);
            _checkBoxAutoScroll.Checked = temp;

            UpdateControlEnabledStatus();
        }
        */

        /// <summary>
        /// Initials the settings.
        /// </summary>
        private void InitialSettings()
        {
            this.WatchMethod = MonitoringMethod.LastWriteTimestamp;
            this.UpdateEnabled = true;
            this.UpdateInterval = DefaultUpdateInterval; 
            this.ViewEnd = true;
        }

        /// <summary>
        /// Read the log file.
        /// </summary>
        /// <remarks>If the user has some text selected then keep that text selected.</remarks>
        private void ReloadFile()
        {
            if (_reloadingFile) return; // already busy doing this
            _reloadingFile = true;
            try
            {
                if (null == _fileName)
                {
                    _textBoxContents.Text = "";
                }
                else
                {
                    string newFileLines = "";
                    //_lastModifiedTime = File.GetLastWriteTime(_fileName); // Remember when we last read in this file
                    //FileInfo fileInfo = new FileInfo(_fileName);
                    //_fileInfo.Refresh();
                    //_lastModifiedTime = _fileInfo.LastWriteTime;     // Remember when we last read in this file
                    _lastModifiedTime = NativeMethods.GetLastModifiedTimeStamp(_fileName);
                    long newLength = 0;  // will be set properly later if all is well
                    bool fileExists = File.Exists(_fileName);
                    bool needToClear = !fileExists;
                    if (fileExists)
                    {
                        // It is possible the file will be in use when we read it (especially if using Immediate mode)
                        // So, we will try up to 5 times to access the file
                        int count = 0;
                        bool success = false;
                        while (count < 5 && !success)
                        {
                            try
                            {
                                // Open with the least amount of locking possible
                                using (FileStream stream = File.Open(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                {
                                    newLength = stream.Length;
                                    if (newLength >= _lastFileSize)
                                    {
                                        stream.Position = _lastFileSize;  // Only read in new lines added
                                    }
                                    else
                                    {
                                        needToClear = true;
                                    }
                                    using (StreamReader reader = new StreamReader(stream))
                                    {
                                        newFileLines = reader.ReadToEnd();
                                    }
                                }
                                success = true;
                            }
                            catch (IOException)
                            {
                                System.Threading.Thread.Sleep(50); // Give a little while to free up file
                            }
                            ++count;
                        }
                    }
                    // Remember the current file length so we can read only newly added log lines the next time the log file is read
                    _lastFileSize = newLength;
                    string fileSizeString = _lastFileSize.ToString();
                    string modifiedTimeStr = _lastModifiedTime.ToShortDateString() + " " + _lastModifiedTime.ToLongTimeString();
                    if (!fileExists)
                    {
                        fileSizeString = "<Not Found>";
                        modifiedTimeStr = "";
                    }
                    if (0 != newFileLines.Length)
                    {
                        // See if this log file has proper cr/lf and if not convert
                        int lastCr = newFileLines.LastIndexOf('\n');
                        if (-1 != lastCr && 0 < lastCr)
                        {
                            if (newFileLines[lastCr - 1] != '\r')
                            {
                                // OK, this file only has Cr and we need to convert to CrLf
                                newFileLines = newFileLines.Replace("\n", "\r\n");
                            }
                        }
                    }
                    if (needToClear)
                    {
                        // What?  A log file shrank?  OK, don't panic just read all the text and set the text control to this text
                        if (_textBoxContents.InvokeRequired)
                        {
                            _textBoxContents.Invoke(new MethodInvoker(delegate { _textBoxContents.Clear(); }));
                        }
                        else
                        {
                            _textBoxContents.Clear();
                        }
                    }
                    if (_textBoxContents.InvokeRequired)
                    {
                        // This branch is used if called via the FileSystemWatcher events
                        if (0 != newFileLines.Length)
                        {
                            _textBoxContents.Invoke(new DoUpdateTextDelegate(DoUpdateText), new object[] { newFileLines });
                        }
                        //_textBoxLogSize.Invoke(new MethodInvoker(delegate { _textBoxLogSize.Text = fileSizeString; }));
                        //_textBoxLastModified.Invoke(new MethodInvoker(delegate { _textBoxLastModified.Text = modifiedTimeStr; }));
                    }
                    else
                    {
                        if (0 != newFileLines.Length)
                        {
                            DoUpdateText(newFileLines);
                        }
                        //_textBoxLogSize.Text = fileSizeString;
                        //_textBoxLastModified.Text = modifiedTimeStr;
                    }
                    ScrollToEnd();
                }
            }
            finally
            {
                // Put clearing this flag in a finally so we know it will be cleared
                _reloadingFile = false;
            }
        }

        private delegate void DoUpdateTextDelegate(string newLogLines);

        /// <summary>
        /// Update the text box control with the new log lines.
        /// </summary>
        /// <param name="newLogLines">The newly added lines to the log file.</param>
        private void DoUpdateText(string newLogLines)
        {
            int selStart = _textBoxContents.SelectionStart;
            int selLength = _textBoxContents.SelectionLength;
            int textTrimSize = 40000;

            if (_textBoxContents.Text.Length + newLogLines.Length > 65535)
            {
                // Log file is too large so if Text in control is about to go over 65K then trim it
                if (newLogLines.Length >= textTrimSize)
                {
                    _textBoxContents.Text = "";
                    newLogLines = newLogLines.Substring(newLogLines.Length - textTrimSize);
                }
                else
                {
                    _textBoxContents.Text = _textBoxContents.Text.Substring(textTrimSize - newLogLines.Length);
                }
            }
            // Add new lines to log
            _textBoxContents.AppendText(newLogLines);

            if (-1 != selStart)
            {
                _textBoxContents.SelectionStart = selStart;
                _textBoxContents.SelectionLength = selLength;

            }
        }

        /// <summary>
        /// Scroll the text control to the end unless AutoScroll is off (while maintaining selection)
        /// </summary>
        /// <remarks>Checks to see if the control has to be accessed via Invoke and acts accordingly.</remarks>
        public void ScrollToEnd()
        {
            if (_textBoxContents.InvokeRequired)
            {
                _textBoxContents.Invoke(new MethodInvoker(DoScrollToEnd));
            }
            else
            {
                DoScrollToEnd();
            }
        }

        /// <summary>
        /// Scroll the text control to the end unless AutoScroll is off (while maintaining selection)
        /// </summary>
        private void DoScrollToEnd()
        {
            if (!this.ViewEnd)
            {
                if (0 != _textBoxContents.SelectionLength)
                {
                    // Just scroll to current selection position
                    _textBoxContents.ScrollToCaret();
                }
            }
            else
            {
                int selStart = _textBoxContents.SelectionStart;
                int selLength = _textBoxContents.SelectionLength;
                _textBoxContents.SelectionLength = 0;
                _textBoxContents.SelectionStart = _textBoxContents.Text.Length;              
                _textBoxContents.ScrollToCaret();
                /*
                if (-1 != selStart)
                {
                    _textBoxContents.SelectionStart = selStart;
                    _textBoxContents.SelectionLength = selLength;
                }
                */
            }
        }

        /// <summary>
        /// Update the log file if the modified timestamp has changed since the last time the file was read.
        /// </summary>
        private void UpdateBasedOnFileTime()
        {
            if (null != _fileName)
            {
                // This returns "12:00 midnight, January 1, 1601 A.D." if the file does not exist
                //DateTime newLastModifiedTime = File.GetLastAccessTime(_fileName);
                //_fileInfo.Refresh();
                //DateTime newLastModifiedTime = _fileInfo.LastWriteTime;
                DateTime newLastModifiedTime = NativeMethods.GetLastModifiedTimeStamp(_fileName);
                //Console.WriteLine(fileInfo.Length);
                if ((newLastModifiedTime.Year < 1620 && newLastModifiedTime != _lastModifiedTime)
                    || newLastModifiedTime > _lastModifiedTime)
                {
                    OnLogFileChanged();
                    ReloadFile();
                }
            }
        }

        #endregion Methods

        #region Event Handlers

        void timer_Tick(object sender, EventArgs e)
        {
            UpdateBasedOnFileTime();
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            OnLogFileChanged();
            ReloadFile();
        }

        void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            ReloadFile();
        }

        /****
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OnBrowseForLogFile();
        }

        private void checkBoxUpdate_CheckedChanged(object sender, EventArgs e)
        {
            //UpdateControlEnabledStatus();
            if (_checkBoxUpdate.Checked)
            {
                PrepareMonitoringMethod();
                // Update if was modified since last time displayed
                UpdateBasedOnFileTime();
            }
            else
            {
                ClearMonitoringMethod();
            }
        }

        private void radioButtonTimed_CheckedChanged(object sender, EventArgs e)
        {
            if (_radioButtonTimed.Checked)
            {
                //UpdateControlEnabledStatus();
                PrepareMonitoringMethod();
            }
        }

        private void radioButtonImmediate_CheckedChanged(object sender, EventArgs e)
        {
            if (_radioButtonImmediate.Checked)
            {
                //UpdateControlEnabledStatus();
                PrepareMonitoringMethod();
            }
        }

        private void textBoxTimeInterval_TextChanged(object sender, EventArgs e)
        {
            _intervalChanged = true;
        }

        private void textBoxTimeInterval_Leave(object sender, EventArgs e)
        {
            if (_intervalChanged)
            {
                _intervalChanged = false;
                PrepareMonitoringMethod();
            }
        }
        *****/

        #endregion Event Handlers

        #region Fields
        private string _fileName;
        private FileSystemWatcher _watcher;
        private Timer _timer;
        private DateTime _lastModifiedTime;
        private long _lastFileSize;
        private bool _intervalChanged;
        private bool _reloadingFile;
        #endregion Fields

        #region Properties


        /// <summary>
        /// Gets or sets the update interval.
        /// </summary>
        /// <value>The update interval.</value>
        public int UpdateInterval 
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        public MonitoringMethod WatchMethod 
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [update enabled].
        /// </summary>
        /// <value><c>true</c> if [update enabled]; otherwise, <c>false</c>.</value>
        public bool UpdateEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [view end].
        /// </summary>
        /// <value><c>true</c> if [view end]; otherwise, <c>false</c>.</value>
        public bool ViewEnd
        {
            get;
            set;
        }

        
        #endregion Properties

#region Enum

        /// <summary>
        /// File monitoring method
        /// </summary>
        public enum MonitoringMethod {
            /// <summary>
            /// Use the last write timestamp
            /// </summary>
            LastWriteTimestamp,
            /// <summary>
            /// Use FileSystemWatcher
            /// </summary>
            FileSystemWatcher
        }

#endregion Enum

    }
}
