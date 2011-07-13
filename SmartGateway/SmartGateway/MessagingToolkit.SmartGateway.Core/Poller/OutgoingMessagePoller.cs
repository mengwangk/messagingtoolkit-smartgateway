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

using MessagingToolkit.Core;
using MessagingToolkit.Core.Base;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Core.Log;
using MessagingToolkit.Core.Mobile.Message;
using MessagingToolkit.Core.Mobile.Event;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;

namespace MessagingToolkit.SmartGateway.Core.Poller
{

    /// <summary>
    /// Poller for outgoing message
    /// </summary>
    public sealed class OutgoingMessagePoller : BasePoller
    {

        /// <summary>
        /// Message gateway
        /// </summary>
        private MessageGatewayService messageGatewayService;

        /// <summary>
        /// Constructor
        /// </summary>
        public OutgoingMessagePoller(MessageGatewayService service)
            : base()
        {
            this.messageGatewayService = service;
        }

        /// <summary>
        /// Does the work.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void DoWork(object sender, ElapsedEventArgs e)
        {            
            if (messageGatewayService.Gateways.Count() == 0) return;
         
            if (log.IsDebugEnabled) log.Debug("Checking outgoing message");

            IOrderedQueryable<OutgoingMessage> messages = OutgoingMessage.All().Where(msg => msg.Status != StringEnum.GetStringValue(MessageStatus.Archived) &&
                                                                                     msg.Status != StringEnum.GetStringValue(MessageStatus.Failed) &&
                                                                                     msg.Status != StringEnum.GetStringValue(MessageStatus.Sending) &&
                                                                                     msg.Status != StringEnum.GetStringValue(MessageStatus.Sent) &&
                                                                                     (
                                                                                        msg.ScheduledDate == null ||
                                                                                        msg.ScheduledDate <= DateTime.Now 
                                                                                     )).OrderBy(msg => msg.LastUpdate);


            // Send out messages
            foreach (OutgoingMessage message in messages)
            {
                List<IMessage> outgoingMessages = new List<IMessage>(messages.Count());
                OutgoingMessageType messageType = (OutgoingMessageType)StringEnum.Parse(typeof(OutgoingMessageType), message.MessageType);
                if (messageType == OutgoingMessageType.SMS)
                {                    
                    // Get the target routed gateway                    
                    Sms sms = Sms.NewInstance();
                    sms.Identifier = message.Id;
                    sms.DestinationAddress = message.Recipient;
                    sms.Content = message.Message;
                    MessageFormat format = (MessageFormat)StringEnum.Parse(typeof(MessageFormat), message.MessageFormat);
                    sms.DataCodingScheme = EnumMatcher.MessageCoding[format];
                    sms.ValidityPeriod = MessageValidPeriod.OneDay;

                    MessageStatusReport statusReport = (MessageStatusReport)StringEnum.Parse(typeof(MessageStatusReport), message.StatusReport);
                    if (statusReport == MessageStatusReport.StatusReport)
                        sms.StatusReportRequest = MessageStatusReportRequest.SmsReportRequest;
                    else if (statusReport == MessageStatusReport.NoStatusReport)
                        sms.StatusReportRequest = MessageStatusReportRequest.NoSmsReportRequest;
                    
                    sms.DcsMessageClass = EnumMatcher.MessageClass[message.MessageClass];
                    sms.QueuePriority = EnumMatcher.MessagePriority[message.Priority];

                    IGateway gateway = messageGatewayService.Router.GetRoute(sms);
                    GatewayConfig gatewayConfig = GatewayConfig.SingleOrDefault(g => g.Id == gateway.Id);
                    if (gatewayConfig != null)
                    {
                        // Message validity period
                        if (!string.IsNullOrEmpty(gatewayConfig.MessageValidity))
                            sms.ValidityPeriod = EnumMatcher.ValidityPeriod[gatewayConfig.MessageValidity];

                        // Status report
                        if (statusReport == MessageStatusReport.FollowChannel)
                        {
                            if (gatewayConfig.RequestStatusReport.Value)
                                sms.StatusReportRequest = MessageStatusReportRequest.SmsReportRequest;
                            else
                                sms.StatusReportRequest = MessageStatusReportRequest.NoSmsReportRequest;
                        }

                        if (gatewayConfig.UseSimSmsc.HasValue && !gatewayConfig.UseSimSmsc.Value && !string.IsNullOrEmpty(gatewayConfig.Smsc))
                        {
                            sms.ServiceCenterNumber = gatewayConfig.Smsc;
                        }
                    }
                    outgoingMessages.Add(sms);

                    // Update status to "Sending"
                    message.Status = StringEnum.GetStringValue(MessageStatus.Sending);
                    message.LastUpdate = DateTime.Now;
                    message.Update();
                }
                else if (messageType == OutgoingMessageType.WAPPush)
                {
                    Wappush wappush = Wappush.NewInstance(message.Recipient, message.WapUrl, message.Message);

                    ServiceIndicationAction signal;
                    if (EnumMatcher.ServiceIndication.TryGetValue(message.WapSignal, out signal))
                    {
                        wappush.Signal = signal;
                    }
                    wappush.CreateDate = message.WapCreateDate.Value;
                    wappush.ExpireDate = message.WapExpiryDate.Value;

                    MessageStatusReport statusReport = (MessageStatusReport)StringEnum.Parse(typeof(MessageStatusReport), message.StatusReport);
                    if (statusReport == MessageStatusReport.StatusReport)
                        wappush.StatusReportRequest = MessageStatusReportRequest.SmsReportRequest;
                    else if (statusReport == MessageStatusReport.NoStatusReport)
                        wappush.StatusReportRequest = MessageStatusReportRequest.NoSmsReportRequest;

                    wappush.DcsMessageClass = EnumMatcher.MessageClass[message.MessageClass];
                    wappush.QueuePriority = EnumMatcher.MessagePriority[message.Priority];

                    IGateway gateway = messageGatewayService.Router.GetRoute(wappush);
                    GatewayConfig gatewayConfig = GatewayConfig.SingleOrDefault(g => g.Id == gateway.Id);
                    if (gatewayConfig != null)
                    {
                        // Message validity period
                        if (!string.IsNullOrEmpty(gatewayConfig.MessageValidity))
                            wappush.ValidityPeriod = EnumMatcher.ValidityPeriod[gatewayConfig.MessageValidity];

                        // Status report
                        if (statusReport == MessageStatusReport.FollowChannel)
                        {
                            if (gatewayConfig.RequestStatusReport.Value)
                                wappush.StatusReportRequest = MessageStatusReportRequest.SmsReportRequest;
                            else
                                wappush.StatusReportRequest = MessageStatusReportRequest.NoSmsReportRequest;
                        }
                    }

                    outgoingMessages.Add(wappush);

                    // Update status to "Sending"
                    message.Status = StringEnum.GetStringValue(MessageStatus.Sending);
                    message.LastUpdate = DateTime.Now;
                    message.Update();

                }

                int count = messageGatewayService.SendMessages(outgoingMessages);                
                log.Debug(string.Format("Messages are queued for sending. Count of number of messages is [{0}]", count));
            }           

        }

    }
}
