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

using MessagingToolkit.Core;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Core.Log;
using MessagingToolkit.Core.Mobile.Message;
using MessagingToolkit.Core.Mobile.Event;

using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Gateway function
    /// </summary>
    [Flags]
    public enum GatewayFunction
    {
        /// <summary>
        /// Send messages
        /// </summary>
        SendMessage = 1,
        /// <summary>
        /// Receive messages
        /// </summary>
        ReceiveMessage = 2
    }

    /// <summary>
    /// Web server status
    /// </summary>
    public enum WebServerStatus
    {
        /// <summary>
        /// Stopped
        /// </summary>
        [StringValue("Stopped")]
        Stopped = 0,
        /// <summary>
        /// Started
        /// </summary>
        [StringValue("Started")]
        Started = 1,
        /// <summary>
        /// Starting
        /// </summary>
        [StringValue("Starting")]
        Starting = 2,
        /// <summary>
        /// Stopping
        /// </summary>
        [StringValue("Stopping")]
        Stopping = 3
    }


    /// <summary>
    /// Service status
    /// </summary>
    public enum ServiceStatus
    {
        /// <summary>
        /// Service is started
        /// </summary>
        Started,
        /// <summary>
        /// Service is stopped
        /// </summary>
        Stopped,
        /// <summary>
        /// Service is paused
        /// </summary>
        Paused,
        /// <summary>
        /// Service is continued
        /// </summary>
        Continue,
        /// <summary>
        /// Service is shutdown
        /// </summary>
        Shutdown
    }

    /// <summary>
    /// Event type
    /// </summary>
    public enum EventNotificationType
    {
        /// <summary>
        /// Message is created, and needs to be sent
        /// </summary>
        [StringValue("New Message")]
        NewMessage,
        /// <summary>
        /// New gateway is created
        /// </summary>
        [StringValue("New Gateway")]
        NewGateway,
        /// <summary>
        /// Gateway is removed
        /// </summary>
        [StringValue("Remove Gateway")]
        RemoveGateway,
        /// <summary>
        /// Check the gateway status
        /// </summary>
        [StringValue("Query Gateway Status")]
        QueryGatewayStatus,
        /// <summary>
        /// Start gateway
        /// </summary>
        [StringValue("Start Gateway")]
        StartGateway,
        /// <summary>
        /// Stop gateway
        /// </summary>
        [StringValue("Stop Gateway")]
        StopGateway,
        /// <summary>
        /// Restart gateway
        /// </summary>
        [StringValue("Restart Gateway")]
        RestartGateway,
        /// <summary>
        /// Query web server status
        /// </summary>
        [StringValue("Query Web Server Status")]
        QueryWebServerStatus,
        /// <summary>
        /// Start web server
        /// </summary>
        [StringValue("Start Web Server")]
        StartWebServer,
        /// <summary>
        /// Stop web server
        /// </summary>
        [StringValue("Stop Web Server")]
        StopWebServer,
        /// <summary>
        /// Query messenger status
        /// </summary>
        [StringValue("Query Messenger Status")]
        QueryMessengerStatus,
        /// <summary>
        /// Start messenger
        /// </summary>
        [StringValue("Start Messenger")]
        StartMessenger,
        /// <summary>
        /// Stop messenger
        /// </summary>
        [StringValue("Stop Messenger")]
        StopMessenger
    }


    /// <summary>
    /// Event response
    /// </summary>
    public enum EventNotificationResponse
    {
        /// <summary>
        /// Okay
        /// </summary>
        [StringValue("OK")]
        OK,
        [StringValue("Failed")]
        Failed
    }

    /// <summary>
    /// Event priority
    /// </summary>
    public enum EventPriority
    {
        /// <summary>
        /// 
        /// </summary>
        Low = 0,
        /// <summary>
        /// 
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 
        /// </summary>
        Hight = 2
    }


    /// <summary>
    /// Outgoing message type
    /// </summary>
    public enum OutgoingMessageType
    {
        [StringValue("SMS")]
        SMS,
        [StringValue("WAP Push")]
        WAPPush,
        //[StringValue("vCard")]
        //vCard,
        //[StringValue("vCalendar")]
        //vCalendar,
        //[StringValue("Email")]
        //Email,
        //[StringValue("Twitter")]
        //Twitter,
        //[StringValue("Facebook")]
        //Facebook
    }

    /// <summary>
    /// Incoming message type
    /// </summary>
    public enum IncomingMessageType
    {
        [StringValue("SMS")]
        SMS,
        [StringValue("WAP Push")]
        WAPPush,
        [StringValue("vCard")]
        vCard,
        [StringValue("vCalendar")]
        vCalendar,
        [StringValue("Status Report")]
        StatusReport
    }

    /// <summary>
    /// Message format
    /// </summary>
    public enum MessageFormat
    {
        [StringValue("Auto Detect")]
        Auto,
        [StringValue("Text")]
        Text,
        [StringValue("Unicode")]
        Unicode,
        [StringValue("Ansi - 8 Bits")]
        Ansi8Bits
    }

    /// <summary>
    /// Message status report
    /// </summary>
    public enum MessageStatusReport
    {
        /// <summary>
        /// No status report
        /// </summary>
        [StringValue("No")]
        NoStatusReport,
        /// <summary>
        /// Request for status report
        /// </summary>
        [StringValue("Yes")]
        StatusReport,
        /// <summary>
        /// Follow the channel
        /// </summary>
        [StringValue("Follow Channel")]
        FollowChannel
    }

    /// <summary>
    /// Message status
    /// </summary>
    public enum MessageStatus
    {
        /// <summary>
        /// Unsent status
        /// </summary>
        [StringValue("Pending")]
        Pending,
        /// <summary>
        /// Sending status
        /// </summary>
        [StringValue("Sending")]
        Sending,
        /// <summary>
        /// Sent status
        /// </summary>
        [StringValue("Sent")]
        Sent,
        /// <summary>
        /// Failed sending status
        /// </summary>
        [StringValue("Failed")]
        Failed,
        /// <summary>
        /// Archived status
        /// </summary>
        [StringValue("Archived")]
        Archived,
        /// <summary>
        /// Received status
        /// </summary>
        [StringValue("Received")]
        Received
    }

    /// <summary>
    /// View action
    /// </summary>
    public enum ViewAction
    {
        /// <summary>
        /// Refresh outbox
        /// </summary>
        [StringValue("Outbox")]
        RefreshOutbox,
        /// <summary>
        /// Refresh inbox
        /// </summary>
        [StringValue("Inbox")]
        RefreshInbox,
        /// <summary>
        /// Refresh failed outbox
        /// </summary>
        [StringValue("FailedOutbox")]
        RefreshFailedOutbox,
        /// <summary>
        /// REfresh archived inbox 
        /// </summary>
        [StringValue("ArchivedInbox")]
        RefreshArchivedInbox,
        /// <summary>
        /// Refresh archived outbox
        /// </summary>
        [StringValue("ArchivedOutbox")]
        RefreshArchivedOutbox,
    }

    /// <summary>
    /// Lookup for enum used
    /// </summary>
    public static class EnumMatcher
    {
        /// <summary>
        /// Port parity lookup
        /// </summary>
        public static Dictionary<string, PortParity> Parity =
            new Dictionary<string, PortParity> { { "None", PortParity.None }, { "Odd", PortParity.Odd }, { "Even", PortParity.Even }, { "Mark", PortParity.Mark }, { "Space", PortParity.Space } };

        /// <summary>
        /// Port stop bits lookup
        /// </summary>
        public static Dictionary<string, PortStopBits> StopBits =
          new Dictionary<string, PortStopBits> { { "1", PortStopBits.One }, { "1.5", PortStopBits.OnePointFive }, { "2", PortStopBits.Two }, { "None", PortStopBits.None } };

        /// <summary>
        /// Port handshake lookup
        /// </summary>
        public static Dictionary<string, PortHandshake> Handshake =
          new Dictionary<string, PortHandshake> { { "None", PortHandshake.None }, { "RequestToSendXOnXOff", PortHandshake.RequestToSendXOnXOff }, { "XOnXOff", PortHandshake.XOnXOff }, { "RequestToSend", PortHandshake.RequestToSend } };
        
        /// <summary>
        /// WAP push signal
        /// </summary>
        public static Dictionary<string, ServiceIndicationAction> ServiceIndication =
            new Dictionary<string, ServiceIndicationAction>
            {
                {"None", ServiceIndicationAction.SignalNone},
                {"Low", ServiceIndicationAction.SignalLow},
                {"Medium", ServiceIndicationAction.SignalMedium},
                {"High", ServiceIndicationAction.SignalHigh}                         
            };


        /// <summary>
        /// Message class
        /// </summary>
        public static Dictionary<string, MessageClasses> MessageClass =
              new Dictionary<string, MessageClasses>
                {
                    {"None", MessageClasses.None},
                    {"Flash", MessageClasses.Flash},
                    {"ME", MessageClasses.Me},
                    {"SIM", MessageClasses.Sim},
                    {"TE", MessageClasses.Te},                    
                };

        /// <summary>
        /// Message priority in queue
        /// </summary>
        public static Dictionary<string, MessageQueuePriority> MessagePriority =
              new Dictionary<string, MessageQueuePriority>
                {
                    {"Low", MessageQueuePriority.Low},
                    {"Normal", MessageQueuePriority.Normal},
                    {"High", MessageQueuePriority.High}
                };

        /// <summary>
        /// Message memory
        /// </summary>
        public static Dictionary<string, MessageStorage> MessageMemory =
          new Dictionary<string, MessageStorage>
          {
              {"SIM", MessageStorage.Sim},
              {"Phone", MessageStorage.Phone},
              {"SIM + Phone", MessageStorage.MobileTerminating}
          };

        /// <summary>
        /// Message validity period
        /// </summary>
        public static Dictionary<string, MessageValidPeriod> ValidityPeriod =
          new Dictionary<string, MessageValidPeriod>
            {
                {"1 Hour", MessageValidPeriod.OneHour},
                {"3 Hours", MessageValidPeriod.ThreeHours},
                {"6 Hours", MessageValidPeriod.SixHours},
                {"12 Hours", MessageValidPeriod.TwelveHours},
                {"1 Day", MessageValidPeriod.OneDay},
                {"3 Days", MessageValidPeriod.ThreeDays},
                {"1 Week", MessageValidPeriod.OneWeek},
                {"Maximum", MessageValidPeriod.Maximum}               
            };


        /// <summary>
        /// Logging level
        /// </summary>
        public static Dictionary<string, LogLevel> LoggingLevel =
            new Dictionary<string, LogLevel>
            {
                {"Error", LogLevel.Error},
                {"Warn", LogLevel.Warn},
                {"Info", LogLevel.Info},
                {"Verbose", LogLevel.Verbose}                                                 
            };


        /// <summary>
        /// Message data coding 
        /// </summary>
        public static Dictionary<MessageFormat, MessageDataCodingScheme> MessageCoding =
            new Dictionary<MessageFormat, MessageDataCodingScheme>
            {
                { MessageFormat.Auto, MessageDataCodingScheme.Undefined },
                { MessageFormat.Text, MessageDataCodingScheme.DefaultAlphabet } ,
                { MessageFormat.Ansi8Bits, MessageDataCodingScheme.EightBits } ,
                { MessageFormat.Unicode, MessageDataCodingScheme.Ucs2 } 
            };
    }


    /// <summary>
    /// General GUI application constants used in the program
    /// </summary>
    public static class GuiHelper
    {
        /// <summary>
        /// Separator to split fields
        /// </summary>
        public static string FieldSplitter = " - ";

        /// <summary>
        /// Supported separators - e.g. list of phone numbers, emails
        /// </summary>
        public static string[] SupportedSeparators = new string[] {";", ","};


        /// <summary>
        /// Mask for license key
        /// </summary>
        public static string LicenseKeyMask = "************";


        /// <summary>
        /// Administrator group name
        /// </summary>
        public static string AdministratorGroupName = "Administrator";

        /// <summary>
        /// Administrator name
        /// </summary>
        public static string AdministratorName = "Administrator";

    }

    /// <summary>
    /// General GUI constants
    /// </summary>
    public static class ConfigParameter
    {
        /// <summary>
        /// Parameter to get application log file name
        /// </summary>
        public static string ApplicationLogFileName = "ApplicationLogFileName";

        /// <summary>
        /// Listener port
        /// </summary>
        public static string ListenerPort = "ListenerPort";

        /// <summary>
        /// Listener service name
        /// </summary>
        public static string ListenerServiceName = "ListenerServiceName";

        /// <summary>
        /// Service log file name
        /// </summary>
        public static string ServiceLogFileName = "ServiceLogFileName";

        /// <summary>
        /// Console event listener
        /// </summary>
        public static string ConsoleEventListener = "ConsoleEventListener";

        /// <summary>
        /// Service event listener
        /// </summary>
        public static string ServiceEventListener = "ServiceEventListener";

        /// <summary>
        /// Licensee
        /// </summary>
        public static string Licensee = "Licensee";

        /// <summary>
        /// License key
        /// </summary>
        public static string LicenseKey = "LicenseKey";


        /// <summary>
        /// Default message polling interval
        /// </summary>
        public static string DefaultMessagePollingInterval = "DefaultMessagePollingInterval";

        /// <summary>
        /// Channel polling interval
        /// </summary>
        public static string ChannelPollingInterval = "ChannelPollingInterval";


        /// <summary>
        /// Connection string name
        /// </summary>
        public static string ConnectionStringName = "SmartGateway";

        /// <summary>
        /// Variable for database
        /// </summary>
        public static string DataSourceVariable = "{$data_source}";

        /// <summary>
        /// SQLite database name
        /// </summary>
        public static string SqLiteDbName = "messagingtoolkit.db";


        /// <summary>
        /// Web server application path
        /// </summary>
        public static string WebServerAppPath = "AppPath";

        /// <summary>
        /// Web server port
        /// </summary>
        public static string WebServerPort = "Port";

        /// <summary>
        /// Web server virtual path
        /// </summary>
        public static string WebServerVirtualPath = "VirtualPath";

        /// <summary>
        /// Auto start the web server
        /// </summary>
        public static string WebServerAutoStart = "AutoStartWebServer";

        
    }

    
    /// <summary>
    /// Event parameter
    /// </summary>
    public static class EventParameter
    {
        public static string GatewayId = "GatewayId";

        public static string GatewayStatus = "GatewayStatus";

        public static string GatewayOperator = "GatewayOperator";

        public static string GatewaySignalStrength = "GatewaySignalStrength";

        public static string WebServerStatus = "WebServerStatus";

        public static string WebServerUrl = "WebServerUrl";

        public static string MessengerName = "MessengerName";

        public static string MessengerStatus = "MessengerStatus";
               
    }

    /// <summary>
    /// Module name
    /// </summary>
    public static class ModuleName
    {
        /// <summary>
        /// Console module
        /// </summary>
        public static string Console = "Console";
        
        /// <summary>
        /// Web server module
        /// </summary>
        public static string WebServer = "WebServer";

        /// <summary>
        /// Service module
        /// </summary>
        public static string Service = "Service";

        /// <summary>
        /// Licensing module
        /// </summary>
        public static string Licensing = "Licensing";

    }

    /// <summary>
    /// Service parameter
    /// </summary>
    public static class ServiceParameter
    {
        /// <summary>
        /// Service name
        /// </summary>
        public static string WindowsServiceName = "MessagingToolkit SmartGateway Message Server";
    }

    /// <summary>
    /// Argument for new gateway event
    /// </summary>
    public class GatewayEventHandlerArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="GatewayEventHandlerArgs"/> class.
        /// </summary>
        /// <param name="gatewayId">The gateway id.</param>
        public GatewayEventHandlerArgs(string gatewayId)
        {
            this.GatewayId = gatewayId;
        }

        /// <summary>
        /// Gets the menu item.
        /// </summary>
        /// <value>The menu item.</value>
        public string GatewayId
        {
            get;
            internal set;
        }
    }

    /// <summary>
    /// New gateway added event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NewGatewayEventHandler(object sender, GatewayEventHandlerArgs e);

    /// <summary>
    /// Gateway removed event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DeleteGatewayEventHandler(object sender, GatewayEventHandlerArgs e);


    /// <summary>
    /// Gateway updated event handler
    /// </summary>
    public delegate void UpdateGatewayEventHandler(object sender, GatewayEventHandlerArgs e);



    /// <summary>
    /// Argument for new messenger event
    /// </summary>
    public class MessengerEventHandlerArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MessengerEventHandlerArgs"/> class.
        /// </summary>
        /// <param name="gatewayId">The gateway id.</param>
        public MessengerEventHandlerArgs(string name)
        {
            this.Name = name;
        }


        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get;
            internal set;
        }
    }


    /// <summary>
    /// New messenger event
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    public delegate void NewMessengerEventHandler(object sender, MessengerEventHandlerArgs e);


    /// <summary>
    /// Delete messenger event
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    public delegate void DeleteMessengerEventHandler(object sender, MessengerEventHandlerArgs e);


    /// <summary>
    /// Update messenger event
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    public delegate void UpdateMessengerEventHandler(object sender, MessengerEventHandlerArgs e);



    /// <summary>
    /// Data type
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// String data type
        /// </summary>
        [StringValue("String")]
        String,
        /// <summary>
        /// Numeric data type
        /// </summary>
        [StringValue("Numeric")]
        Numeric
    }


    /// <summary>
    /// Messenger status
    /// </summary>
    public enum MessengerStatus
    {
        /// <summary>
        /// Starting
        /// </summary>
        [StringValue("Starting")]
        Starting,
        /// <summary>
        /// Stopped
        /// </summary>
        [StringValue("Stopped")]
        Stopped,
        /// <summary>
        /// Started
        /// </summary>
        [StringValue("Started")]
        Started,
        /// <summary>
        /// Stopping
        /// </summary>
        [StringValue("Stopping")]
        Stopping
    }

}
