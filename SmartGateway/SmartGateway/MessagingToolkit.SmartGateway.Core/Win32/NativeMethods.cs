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
using System.Runtime.InteropServices;

using log4net;

namespace MessagingToolkit.SmartGateway.Core.Win32
{
    /// <summary>
    /// Win32 struct for file information
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WIN32_FIND_DATA
    {
        public uint fileAttributes;
        public System.Runtime.InteropServices.ComTypes.FILETIME creationTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME lastAccessTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME lastWriteTime;
        public uint fileSizeHigh;
        public uint fileSizeLow;
        public uint reserved0;
        public uint reserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string fileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string alternateFileName;
    }


    /// <summary>
    /// Wrapper class for native WIN32 API
    /// </summary>
    public static class NativeMethods
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets the file time.
        /// </summary>
        /// <param name="fileHandle">The file handle.</param>
        /// <param name="creationTime">The creation time.</param>
        /// <param name="accessTime">The access time.</param>
        /// <param name="modifiedTime">The modified time.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool GetFileTime(IntPtr fileHandle, out long creationTime, out long accessTime, out long modifiedTime);

        /// <summary>
        /// Finds the first file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindFirstFile(string path, out WIN32_FIND_DATA data);

        /// <summary>
        /// Finds the close.
        /// </summary>
        /// <param name="fileHandle">The file handle.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool FindClose(IntPtr fileHandle);

        /// <summary>
        /// Gets the last modified time stamp.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static DateTime GetLastModifiedTimeStamp(string filePath)
        {
            try
            {
                DateTime modifiedTimestamp = DateTime.Now;
                if (!File.Exists(filePath)) return modifiedTimestamp;
                WIN32_FIND_DATA data;
                IntPtr hfff = FindFirstFile(filePath, out data);
                FindClose(hfff);
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                IntPtr hf = fs.SafeFileHandle.DangerousGetHandle();
                long creation, accessed, modified;
                bool ok = GetFileTime(hf, out creation, out accessed, out modified);
                fs.Close();
                modifiedTimestamp = DateTime.FromFileTime(modified);
                return modifiedTimestamp;
            }
            catch (Exception ex)
            {
                log.Error("Error retrieving file timestamp: " + ex.Message, ex);
                return DateTime.Now;
            }
        }
    }
}
