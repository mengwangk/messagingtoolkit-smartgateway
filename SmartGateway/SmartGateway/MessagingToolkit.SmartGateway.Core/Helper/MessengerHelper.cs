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
using System.Data;
using System.Data.Odbc;
using System.Data.Common;

using log4net;

using MessagingToolkit.Core;
using MessagingToolkit.Core.Base;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Core.Log;
using MessagingToolkit.Core.Mobile.Message;
using MessagingToolkit.Core.Mobile.Event;
using MessagingToolkit.Core.Helper;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;

namespace MessagingToolkit.SmartGateway.Core.Helper
{
    /// <summary>
    /// Messenger helper class
    /// </summary>
    public static class MessengerHelper
    {
        /// <summary>
        /// Message id prefix for messenger messages
        /// </summary>
        private const string MessagePrefix = "DATABASE MESSENGER";
        
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Generates the message id.
        /// </summary>
        /// <param name="messenger">The messenger.</param>
        /// <param name="id">The message id.</param>
        /// <returns></returns>
        public static string GenerateMessageId(DbMessenger messenger, string id)
        {
            return MessagePrefix + GuiHelper.FieldSplitter + messenger.Name + GuiHelper.FieldSplitter + id ;
        }

        /// <summary>
        /// Determines whether it is a messenger message
        /// </summary>
        /// <param name="messageId">The message id.</param>
        /// <returns>
        ///   <c>true</c> if [is messenger message] [the specified message id]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMessengerMessage(string messageId)
        {
            return (!string.IsNullOrEmpty(messageId) && messageId.StartsWith(MessagePrefix));
        }

        /// <summary>
        /// Extracts the name.
        /// </summary>
        /// <param name="messageId">The message id.</param>
        /// <returns></returns>
        public static string ExtractName(string messageId)
        {
            if (IsMessengerMessage(messageId))
            {
                return (messageId.Split(new string[]{GuiHelper.FieldSplitter}, StringSplitOptions.RemoveEmptyEntries))[1];
            }

            return string.Empty;
        }

        /// <summary>
        /// Extracts the id.
        /// </summary>
        /// <param name="messageId">The message id.</param>
        /// <returns></returns>
        public static string ExtractId(string messageId)
        {
            if (IsMessengerMessage(messageId))
            {
                return (messageId.Split(new string[] { GuiHelper.FieldSplitter }, StringSplitOptions.RemoveEmptyEntries))[2];
            }

            return string.Empty;
        }


        /// <summary>
        /// Gets the records.
        /// </summary>
        /// <param name="messenger">The messenger.</param>
        /// <returns></returns>
        public static DataTable GetRecords(DbMessenger messenger)
        {
            OdbcConnection dbConnection = null;
            OdbcCommand dbCommand = null;
            OdbcDataReader dbReader = null;
            try
            {
                string connString = BuildConnString(messenger);
                string sqlCommand = string.Format("SELECT * FROM {0}", messenger.DbTable);
                if (!messenger.DeleteAfterSending)
                {
                    sqlCommand = string.Format("{0} WHERE {1}='{2}'", sqlCommand, messenger.StatusColName, messenger.StatusColNewValue);
                }
                dbConnection = new OdbcConnection(connString);
                dbConnection.Open();
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = sqlCommand;
                dbReader = dbCommand.ExecuteReader();               
                DataTable dt = new DataTable();
                dt.TableName = messenger.DbTable;
                dt.Load(dbReader);
                dbReader.Close();
                return dt;
            }
            catch (Exception ex)
            {
                string msg = string.Format("Messenger [{0}] error, DSN is [{1}]", messenger.Name, messenger.Dsn);
                log.Error(msg, ex);
                throw new SmartGatewayException(msg, ex);
            }
            finally
            {
                if (dbReader != null && !dbReader.IsClosed)
                {                   
                    dbReader.Close();                   
                }
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                }

                if (dbConnection != null)
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                    dbConnection = null;
                }
            }
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="messenger">The messenger.</param>
        /// <param name="row">The row.</param>
        /// <param name="id">The id.</param>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public static bool UpdateStatus(DbMessenger messenger, string id, string status)
        {
            OdbcConnection dbConnection = null;
            OdbcCommand dbCommand = null;          
            try
            {
                string connString = BuildConnString(messenger);
                DataType idColDataType = (DataType)StringEnum.Parse(typeof(DataType), messenger.UniqMsgIdColDataType);
                string sqlCommand = string.Empty;
                sqlCommand = string.Format("UPDATE {0} SET {1}='{2}'", messenger.DbTable, messenger.StatusColName, status);

                if (!string.IsNullOrEmpty(messenger.StatusTimestampColName)) 
                {
                    sqlCommand += ", " + messenger.StatusTimestampColName + "=?";
                }

                if (idColDataType == DataType.Numeric)
                {
                    sqlCommand += " WHERE {0}={1}";
                }
                else
                {
                    sqlCommand += " WHERE {0}='{1}'";
                }
                
                sqlCommand = string.Format(sqlCommand, messenger.UniqMsgIdColName, id);
                dbConnection = new OdbcConnection(connString);
                dbConnection.Open();
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = sqlCommand;

                if (!string.IsNullOrEmpty(messenger.StatusTimestampColName))
                {
                    dbCommand.Parameters.Add("@ts", OdbcType.DateTime);
                    dbCommand.Parameters["@ts"].Value = DateTime.Now;
                }
                int rowCount = dbCommand.ExecuteNonQuery();              
                return true;
            }
            catch (Exception ex)
            {
                string msg = string.Format("Messenger [{0}] error, DSN is [{1}]", messenger.Name, messenger.Dsn);
                log.Error(msg, ex);
                return false;
            }
            finally
            {  
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                }

                if (dbConnection != null)
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                    dbConnection = null;
                }
            }
        }


        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <param name="messenger">The messenger.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public static bool DeleteMsg(DbMessenger messenger, string id)
        {
            OdbcConnection dbConnection = null;
            OdbcCommand dbCommand = null;
            try
            {
                string connString = BuildConnString(messenger);
                DataType idColDataType = (DataType)StringEnum.Parse(typeof(DataType), messenger.UniqMsgIdColDataType);
                string sqlCommand = string.Empty;
                sqlCommand = string.Format("DELETE FROM {0} ", messenger.DbTable);

               
                if (idColDataType == DataType.Numeric)
                {
                    sqlCommand += " WHERE {0}={1}";
                }
                else
                {
                    sqlCommand += " WHERE {0}='{1}'";
                }

                sqlCommand = string.Format(sqlCommand, messenger.UniqMsgIdColName, id);
                dbConnection = new OdbcConnection(connString);
                dbConnection.Open();
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = sqlCommand;

                int rowCount = dbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string msg = string.Format("Messenger [{0}] error, DSN is [{1}]", messenger.Name, messenger.Dsn);
                log.Error(msg, ex);
                return false;
            }
            finally
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                }

                if (dbConnection != null)
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                    dbConnection = null;
                }
            }
        }


        /// <summary>
        /// Builds the connection string.
        /// </summary>
        /// <param name="messenger">The messenger.</param>
        /// <returns></returns>
        private static string BuildConnString(DbMessenger messenger)
        {
            if (messenger.RequiredAuth)
            {
                return string.Format("DSN={0};Uid={1};Pwd={2};", messenger.Dsn, messenger.DbUserName, messenger.DbUserPassword);
            }
            else
            {
                return string.Format("DSN={0}", messenger.Dsn);
            }
        }
    }
}
