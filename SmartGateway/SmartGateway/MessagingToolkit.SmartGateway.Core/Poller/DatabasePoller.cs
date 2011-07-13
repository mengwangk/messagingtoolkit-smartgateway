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
using System.Timers;
using System.Data;

using log4net;

using MessagingToolkit.Core;
using MessagingToolkit.Core.Base;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Core.Log;
using MessagingToolkit.Core.Mobile.Message;
using MessagingToolkit.Core.Mobile.Event;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core.Poller
{
    /// <summary>
    /// Database message poller
    /// </summary>
    public sealed class DatabasePoller : BasePoller
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
              
        /// <summary>
        /// Message gateway
        /// </summary>
        private MessageGatewayService messageGatewayService;

        /// <summary>
        /// Database messenger record
        /// </summary>
        private DbMessenger messenger;

        /// <summary>
        /// Flag to indicate if processing is going on
        /// </summary>
        private bool isRunning;

        /// <summary>
        /// Constructor
        /// </summary>
        public DatabasePoller(DbMessenger messenger, MessageGatewayService service)
            : base(messenger.PollingInterval * 1000)
        {
            this.messenger = messenger;
            this.messageGatewayService = service;
            this.isRunning = false;
        }

        /// <summary>
        /// Does the work.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void DoWork(object sender, ElapsedEventArgs e)
        {
            if (isRunning) return;

            if (messageGatewayService == null || messageGatewayService.Gateways.Count() == 0) return;
            
            if (log.IsDebugEnabled) log.DebugFormat("[{0}]: Polling from DSN [{1}]", messenger.Name, messenger.Dsn);
            try
            {
                isRunning = true;
                DataTable dt = MessengerHelper.GetRecords(messenger);
                if (dt.Rows.Count > 0)
                {
                    List<IMessage> outgoingMessages = new List<IMessage>();
                    try
                    {                       
                        foreach (DataRow row in dt.Rows)
                        {
                            Sms sms = Sms.NewInstance();
                            sms.DestinationAddress = row[messenger.DestNoColName].ToString();
                            string msgColName = messenger.MsgColName;
                            if (string.IsNullOrEmpty(msgColName))
                            {
                                sms.Content = messenger.DefaultTextMsg;
                            }
                            else
                            {
                                sms.Content = row[msgColName].ToString();
                            }
                            sms.ValidityPeriod = MessageValidPeriod.OneDay;

                            if (string.IsNullOrEmpty(messenger.MsgPriorityColName))
                            {
                                sms.QueuePriority = EnumMatcher.MessagePriority[messenger.DefaultMsgPriority];
                            }
                            else
                            {
                                sms.QueuePriority = EnumMatcher.MessagePriority[row[messenger.MsgPriorityColName].ToString()];
                            }

                            if (!string.IsNullOrEmpty(messenger.MsgAlertColName))
                            {
                                sms.DcsMessageClass = EnumMatcher.MessageClass[row[messenger.MsgAlertColName].ToString()];
                            }                           
                            sms.Identifier = MessengerHelper.GenerateMessageId(messenger, row[messenger.UniqMsgIdColName].ToString());
                            outgoingMessages.Add(sms);
                            MessengerHelper.UpdateStatus(messenger, row[messenger.UniqMsgIdColName].ToString(), messenger.StatusColUpdateSendingValue);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(string.Format("Messenger [{0}] encountered error in sending", messenger.Name), ex);
                    }

                    if (outgoingMessages.Count > 0)
                    {
                        int count = messageGatewayService.SendMessages(outgoingMessages);
                        log.InfoFormat("Database messenger [{0}] : Messages are queued for sending. Count of number of messages is [{1}]", messenger.Name, count);
                    }
                }               
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
            finally
            {
                isRunning = false;
            }            
        }          
    }
}
