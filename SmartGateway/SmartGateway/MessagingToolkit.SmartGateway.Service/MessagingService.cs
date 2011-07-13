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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Services;

using log4net;

using MessagingToolkit.Core;
using MessagingToolkit.Core.Base;
using MessagingToolkit.Core.Helper;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Core.Log;
using MessagingToolkit.Core.Mobile.Message;
using MessagingToolkit.Core.Mobile.Event;
using MessagingToolkit.Core.Service;

using MessagingToolkit.SmartGateway.Core;
using MessagingToolkit.SmartGateway.Core.Helper;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Web;
using MessagingToolkit.SmartGateway.Core.Interprocess;
using MessagingToolkit.SmartGateway.Core.Poller;
using MessagingToolkit.SmartGateway.Service.Properties;

namespace MessagingToolkit.SmartGateway.Service
{
    /// <summary>
    /// Messaging server running as a Windows service
    /// </summary>
    public partial class MessagingService : ServiceBase
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Interval to wait for thread to complete, in milliseconds
        /// </summary>
        private const int ThreadWaitInterval = 500;

        /// <summary>
        /// Thread to start the service
        /// </summary>
        private Thread serviceControlThread;


        /// <summary>
        /// Message gateway service
        /// </summary>
        private MessageGatewayService messageGatewayService;


        /// <summary>
        /// Indicate if the service is started
        /// </summary>
        private ServiceStatus serviceStatus = ServiceStatus.Stopped;


        /// <summary>
        /// Service host for WCF service
        /// </summary>
        //private ServiceHost serviceHost = null;


        /// <summary>
        /// Console event listener URL
        /// </summary>
        private string consoleEventListenerUrl = AppConfigSettings.GetString(ConfigParameter.ConsoleEventListener, ModuleName.Console);

        // for interprocess communication
        private EventInvocation eventInvocation = null;
        private ObjRef eventListenerService = null;
        private TcpChannel eventListenerChannel = null;
        private PriorityQueue<EventAction, EventPriority> eventQueue;
        private object eventLock;
        private EventWaitHandle eventTrigger;
        private Thread eventProcessor;

        // Worker threads - for polling
        private List<Thread> workerThreads;
        private List<BasePoller> pollers;

        private WebServer webServer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingService"/> class.
        /// </summary>
        public MessagingService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            try
            {
                if (serviceControlThread != null && serviceControlThread.IsAlive)
                {
                    serviceControlThread.Abort();
                    serviceControlThread = null;
                }

                serviceControlThread = new Thread(InitializeService);
                serviceControlThread.IsBackground = true;
                serviceControlThread.Start();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error starting service: {0} ", ex.Message), ex);
                throw ex;
            }

            // Set to started
            serviceStatus = ServiceStatus.Started;

            //base.OnStart(args);
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            // Stop the service
            StopService();

            // Call the base action
            //base.Stop();

            // Set to stopped
            serviceStatus = ServiceStatus.Stopped;
        }

        /// <summary>
        /// When implemented in a derived class, executes when the system is shutting down. Specifies what should occur immediately prior to the system shutting down.
        /// </summary>
        protected override void OnShutdown()
        {
            // Stop the service
            StopService();

            // Call the base action
            //base.OnShutdown();

            // Set to shutdown
            serviceStatus = ServiceStatus.Shutdown;

        }

        /// <summary>
        /// When implemented in a derived class, executes when a Pause command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service pauses.
        /// </summary>
        protected override void OnPause()
        {
            // Call the base action
            //base.OnPause();

            // Set to pause
            serviceStatus = ServiceStatus.Paused;
        }

        /// <summary>
        /// When implemented in a derived class, <see cref="M:System.ServiceProcess.ServiceBase.OnContinue"/> runs when a Continue command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service resumes normal functioning after being paused.
        /// </summary>
        protected override void OnContinue()
        {

            // Call the base action
            //base.OnContinue();

            // Set to continue
            serviceStatus = ServiceStatus.Continue;
        }

        /// <summary>
        /// When implemented in a derived class, <see cref="M:System.ServiceProcess.ServiceBase.OnCustomCommand(System.Int32)"/> executes when the Service Control Manager (SCM) passes a custom command to the service. Specifies actions to take when a command with the specified parameter value occurs.
        /// </summary>
        /// <param name="command">The command message sent to the service.</param>
        protected override void OnCustomCommand(int command)
        {
            //base.OnCustomCommand(command);
        }


        /// <summary>
        /// Setups the service.
        /// </summary>
        private void InitializeService()
        {
            PrepareService();
            StartMessageService();
            StartEventListener();
            StartPollers();

            bool startWebServer = Convert.ToBoolean(AppConfigSettings.GetString(ConfigParameter.WebServerAutoStart));
            if (startWebServer) StartWebServer();
        }


        /// <summary>
        /// Prepares the service.
        /// </summary>
        private void PrepareService()
        {
            try
            {
                // Update sending status back to blank
                IQueryable<OutgoingMessage> messages = OutgoingMessage.All().Where(msg => msg.Status == StringEnum.GetStringValue(MessageStatus.Sending));
                foreach (OutgoingMessage msg in messages)
                {
                    msg.Status = string.Empty;
                    msg.LastUpdate = DateTime.Now;
                    msg.Update();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error preparing the service");
                log.Error(ex.Message, ex);
            }

        }

        /// <summary>
        /// Starts the message service.
        /// </summary>
        private void StartMessageService()
        {
            try
            {
                log.Info("Start message service");

                if (messageGatewayService != null)
                {
                    messageGatewayService.RemoveAll();
                    messageGatewayService = null;
                }

                // Create the gateway service instance
                messageGatewayService = MessageGatewayService.NewInstance();

                foreach (GatewayConfig gwConfig in GatewayConfig.All())
                {
                    if (gwConfig.AutoConnect.Value)
                        ConnectGateway(gwConfig);
                }

                log.Info("Message service started successfully");
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error starting message service: {0}", ex.Message, ex));
            }
        }

        /// <summary>
        /// Connects to the gateway
        /// </summary>
        /// <param name="gwConfig">The gateway config.</param>
        private void ConnectGateway(GatewayConfig gwConfig)
        {
            MobileGatewayConfiguration config = MobileGatewayConfiguration.NewInstance();
            config.PortName = gwConfig.ComPort;
            config.BaudRate = (PortBaudRate)Enum.Parse(typeof(PortBaudRate), gwConfig.BaudRate);
            config.DataBits = (PortDataBits)Enum.Parse(typeof(PortDataBits), gwConfig.DataBits);
            if (!string.IsNullOrEmpty(gwConfig.Parity))
            {
                PortParity portParity;
                if (EnumMatcher.Parity.TryGetValue(gwConfig.Parity, out portParity))
                {
                    config.Parity = portParity;
                }
            }
            if (!string.IsNullOrEmpty(gwConfig.StopBits))
            {
                PortStopBits portStopBits;
                if (EnumMatcher.StopBits.TryGetValue(gwConfig.StopBits, out portStopBits))
                {
                    config.StopBits = portStopBits;
                }
            }

            if (!string.IsNullOrEmpty(gwConfig.Handshake))
            {
                PortHandshake handshake;
                if (EnumMatcher.Handshake.TryGetValue(gwConfig.Handshake, out handshake))
                {
                    config.Handshake = handshake;
                }
            }

            if (!string.IsNullOrEmpty(gwConfig.LogSettings))
            {
                LogLevel logLevel;
                if (EnumMatcher.LoggingLevel.TryGetValue(gwConfig.LogSettings, out logLevel))
                {
                    config.LogLevel = logLevel;
                }
            }

            if (!string.IsNullOrEmpty(gwConfig.Pin))
            {
                config.Pin = gwConfig.Pin;
            }

            // Set the license key
            AppConfig licenseKey = AppConfig.SingleOrDefault(ac => ac.Name == ConfigParameter.LicenseKey);
            if (licenseKey != null)
                config.LicenseKey = licenseKey.Value;


            MessageGateway<IMobileGateway, MobileGatewayConfiguration> messageGateway =
                MessageGateway<IMobileGateway, MobileGatewayConfiguration>.NewInstance();
            try
            {
                IMobileGateway mobileGateway;
                mobileGateway = messageGateway.Find(config);

                if (mobileGateway == null)
                {
                    log.Error(string.Format("Error connecting to gateway. Check the log file", config.PortName));
                }

                if (!messageGatewayService.Add(mobileGateway))
                {
                    throw messageGatewayService.LastError;
                }

                if (!string.IsNullOrEmpty(gwConfig.MessageMemory))
                {
                    MessageStorage messageStorage = EnumMatcher.MessageMemory[gwConfig.MessageMemory];
                    mobileGateway.MessageStorage = messageStorage;
                }

                mobileGateway.Id = gwConfig.Id;
                mobileGateway.EnableNewMessageNotification(MessageNotification.StatusReport);
                mobileGateway.PollNewMessages = true;
                mobileGateway.Configuration.DeleteReceivedMessage = gwConfig.DeleteAfterRetrieve.Value;

                mobileGateway.MessageReceived += new MessageReceivedEventHandler(mobileGateway_MessageReceived);
                mobileGateway.MessageSendingFailed += new MessageErrorEventHandler(mobileGateway_MessageSendingFailed);
                mobileGateway.MessageSent += new MessageEventHandler(mobileGateway_MessageSent);

                mobileGateway.Attributes = GatewayAttribute.DeliveryReport | GatewayAttribute.FlashSms |
                    GatewayAttribute.LongMessage | GatewayAttribute.SmartSms | GatewayAttribute.WapPush;

                GatewayFunction functions = (GatewayFunction)Enum.Parse(typeof(GatewayFunction), gwConfig.Functions.ToString());
                if ((functions & GatewayFunction.SendMessage) == GatewayFunction.SendMessage)
                    mobileGateway.Attributes = mobileGateway.Attributes | GatewayAttribute.Send;
                if ((functions & GatewayFunction.ReceiveMessage) == GatewayFunction.ReceiveMessage)
                    mobileGateway.Attributes = mobileGateway.Attributes | GatewayAttribute.ReceiveByPolling | GatewayAttribute.ReceiveByTrigger;

                log.Info(string.Format("Successfully connected to gateway. Model is {0}. Port is {1}", mobileGateway.DeviceInformation.Model, config.PortName));

                if (gwConfig.Initialize.HasValue && !gwConfig.Initialize.Value)
                {
                    log.Info("Initializing gateway for the first time");
                    List<MessageInformation> messages = mobileGateway.GetMessages(MessageStatusType.ReceivedReadMessages);
                    bool isSuccessfulSave1 = SaveReceivedMessages(gwConfig, messages);
                    messages = mobileGateway.GetMessages(MessageStatusType.ReceivedUnreadMessages);
                    bool isSuccessfulSave2 = SaveReceivedMessages(gwConfig, messages);

                    if (isSuccessfulSave1 && isSuccessfulSave2)
                    {
                        gwConfig.Initialize = true;
                        gwConfig.Save();
                        log.Info("Gateway initialized successfully");
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("Failed to connect to gateway using {0}", config.PortName));
                log.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Handles the MessageSent event of the mobileGateway control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MessagingToolkit.Core.Mobile.Event.MessageEventArgs"/> instance containing the event data.</param>
        void mobileGateway_MessageSent(object sender, MessageEventArgs e)
        {
            if (e.Message != null)
            {
                if (e.Message is Sms)
                {
                    Sms sms = e.Message as Sms;
                    log.Info(string.Format("Message [{0}] is sent to [{1}] successfully", sms.Identifier, sms.DestinationAddress));

                    if (MessengerHelper.IsMessengerMessage(sms.Identifier))
                    {
                        string name = MessengerHelper.ExtractName(sms.Identifier);
                        string id = MessengerHelper.ExtractId(sms.Identifier);
                        DbMessenger messenger = DbMessenger.SingleOrDefault(m => m.Name.ToLower() == name.ToLower());
                        if (messenger != null)
                        {
                            if (!messenger.DeleteAfterSending)
                                MessengerHelper.UpdateStatus(messenger, id, messenger.StatusColUpdateSuccessVal);
                            else
                                MessengerHelper.DeleteMsg(messenger, id);
                        }
                    }
                    else
                    {
                        MessageHelper.UpdateStatus(sms, MessageStatus.Sent);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the MessageSendingFailed event of the mobileGateway control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MessagingToolkit.Core.Mobile.Event.MessageErrorEventArgs"/> instance containing the event data.</param>
        void mobileGateway_MessageSendingFailed(object sender, MessageErrorEventArgs e)
        {
            if (e.Message != null)
            {
                if (e.Message is Sms)
                {
                    Sms sms = e.Message as Sms;
                    log.Info(string.Format("Failed to send message [{0}] to [{1}]", sms.Identifier, sms.DestinationAddress));

                    if (MessengerHelper.IsMessengerMessage(sms.Content))
                    {
                        string name = MessengerHelper.ExtractName(sms.Content);
                        string id = MessengerHelper.ExtractId(sms.Content); 
                        DbMessenger messenger = DbMessenger.SingleOrDefault(m=>m.Name.ToLower()== name.ToLower());
                        if (messenger != null) 
                        {
                            MessengerHelper.UpdateStatus(messenger, id, messenger.StatusColUpdateFailedValue);
                        }
                    }
                    else
                    {
                        MessageHelper.UpdateStatus(sms, MessageStatus.Failed);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the MessageReceived event of the mobileGateway control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MessagingToolkit.Core.Mobile.Event.MessageReceivedEventArgs"/> instance containing the event data.</param>
        void mobileGateway_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageInformation receivedMessage = e.Message;
            log.Info(string.Format("Received message from [{0}] on [{1}]", receivedMessage.PhoneNumber, receivedMessage.ReceivedDate.ToString()));

            // Save the message
            SaveIncomingMessage(receivedMessage);
        }

        /// <summary>
        /// Saves the messages.
        /// </summary>
        /// <param name="gwConfig">The gateway config.</param>
        /// <param name="messages">The messages.</param>
        /// <returns></returns>
        private bool SaveReceivedMessages(GatewayConfig gwConfig, List<MessageInformation> messages)
        {
            bool isSuccessful = true;
            foreach (MessageInformation message in messages)
            {
                message.GatewayId = gwConfig.Id;
                if (!SaveIncomingMessage(message))
                    isSuccessful = false;
            }
            return isSuccessful;
        }


        /// <summary>
        /// Saves the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="gatewayId">The gateway id.</param>
        /// <returns></returns>
        private bool SaveIncomingMessage(MessageInformation message)
        {
            bool isSuccessful = true;
            try
            {
                IncomingMessage incomingMessage = new IncomingMessage();
                incomingMessage.Id = GatewayHelper.GenerateUniqueIdentifier();
                incomingMessage.GatewayId = message.GatewayId;
                incomingMessage.Originator = message.PhoneNumber;
                incomingMessage.OriginatorReceivedDate = message.DestinationReceivedDate;
                incomingMessage.Timezone = message.Timezone;
                incomingMessage.Message = message.Content;
                incomingMessage.MessageType = StringEnum.GetStringValue(message.MessageType);
                incomingMessage.DeliveryStatus = message.DeliveryStatus.ToString();
                incomingMessage.ReceivedDate = message.ReceivedDate;
                incomingMessage.ValidityTimeStamp = message.ValidityTimestamp;
                incomingMessage.OriginatorRefNo = message.ReferenceNo;
                incomingMessage.MessageStatusType = message.MessageStatusType.ToString();
                incomingMessage.SrcPort = message.SourcePort;
                incomingMessage.DestPort = message.DestinationPort;
                incomingMessage.Status = StringEnum.GetStringValue(MessageStatus.Received);
                incomingMessage.RawMessage = message.RawMessage;
                incomingMessage.LastUpdate = DateTime.Now;
                incomingMessage.CreateDate = incomingMessage.LastUpdate;
                incomingMessage.Indexes = string.Join(",", (message.Indexes.ConvertAll<string>(delegate(int i) { return i.ToString(); })).ToArray());
                incomingMessage.Save();
            }
            catch (Exception ex)
            {
                log.Error("Failed to save message");
                log.Error(ex.Message, ex);
                isSuccessful = false;
            }

            return isSuccessful;
        }

        /// <summary>
        /// Starts the event listener.
        /// </summary>
        private void StartEventListener()
        {
            /****
            try
            {
               
                // Start up the WCF service
                log.Info("Starting service event listener");


                if (serviceHost != null)
                {
                    serviceHost.Close();
                }

                // Create a ServiceHost for the CalculatorService type and 
                // provide the base address.
                serviceHost = new ServiceHost(typeof(ServiceCommand));

                // Open the ServiceHostBase to create listeners and start 
                // listening for messages.
                serviceHost.Open();

                // Start up the WCF service
                log.Info("Interprocess communication service started successfully");
            }
            catch (Exception ex)
            {
                // Start up the WCF service
                log.Error("Failed to start interprocess communication service");
                log.Error(string.Format("Error: {0}", ex.Message), ex);
            }
            ****/

            StopEventListener(); // if there is any channel still open --> close it

            try
            {
                log.Info("Starting event listener");
                int port = AppConfigSettings.GetInt(ConfigParameter.ListenerPort, ModuleName.Service);
                eventListenerChannel = new TcpChannel(port);
                ChannelServices.RegisterChannel(eventListenerChannel, false);

                eventInvocation = new EventInvocation();
                string serviceName = AppConfigSettings.GetString(ConfigParameter.ListenerServiceName, ModuleName.Service);

                eventListenerService = RemotingServices.Marshal(eventInvocation, serviceName);

                //RemotingConfiguration.RegisterWellKnownServiceType(typeof(EventInvocation),
                //        serviceName, WellKnownObjectMode.SingleCall);

                // define the event which is triggered when the Master calls the CallSlave() function
                eventInvocation.EventReceived += new EventInvocation.Received(OnEventReceived);

                // Create the event queue
                eventLock = new object();
                eventQueue = new PriorityQueue<EventAction, EventPriority>(10);
                eventTrigger = new AutoResetEvent(false);
                eventProcessor = new Thread(ProcessEvents);
                eventProcessor.IsBackground = true;
                eventProcessor.Start();

                log.Info(string.Format("Successfully started event listener {0} on port {1}", serviceName, port));
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error starting listener: {0}", ex.Message), ex);
                StopEventListener(); // calls StopEventListener
            }
        }

        /// <summary>
        /// Starts the pollers.
        /// </summary>
        private void StartPollers()
        {
            try
            {
                log.Debug("Starting outgoing message poller");

                // Stop all pollers, just in case
                StopPollers();

                // Start to poll incoming message
                if (workerThreads == null) workerThreads = new List<Thread>(1);
                if (pollers == null) pollers = new List<BasePoller>(1);

                OutgoingMessagePoller outgoingMessagePoller = new OutgoingMessagePoller(this.messageGatewayService);
                outgoingMessagePoller.Name = Resources.OutgoingMessagePoller;
                pollers.Add(outgoingMessagePoller);

                Thread worker = new Thread(new ThreadStart(outgoingMessagePoller.StartTimer));
                worker.IsBackground = true;
                worker.Name = Resources.OutgoingMessagePoller;
                workerThreads.Add(worker);
                worker.Start();
                               
                log.Info("Outgoing message poller is started successfully");

                log.Debug("Starting database messengers");
                foreach (DbMessenger messenger in DbMessenger.All())
                {
                    if (messenger.AutoStart)
                    {                       
                        EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.StartMessenger));
                        action.Values.Add(EventParameter.MessengerName, messenger.Name);
                        StartMessenger(action);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error starting pollers: {0}", ex.Message), ex);
                StopPollers(); // calls StopPollers
            }
        }

        /// <summary>
        /// Called when [event received].
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private EventResponse OnEventReceived(EventAction action)
        {
            // Put the event in a queue and respond immediately
            lock (eventLock)
            {
                try
                {
                    if (action.ActionType == EventAction.ASynchronous)
                    {
                        // Queue the event and trigger the processing
                        eventQueue.Enqueue(action, EventPriority.Normal);
                        eventTrigger.Set();

                        // Send back the processing
                        EventResponse response = new EventResponse();
                        response.Status = StringEnum.GetStringValue(EventNotificationResponse.OK);
                        return response;
                    }
                    else
                    {
                        return ProcessSyncEvents(action);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(string.Format("Error processing incoming event - [{0}]", action.ToString()));
                    log.Error(ex.Message, ex);
                }
            }

            return new EventResponse();
        }


        /// <summary>
        /// Processes synchronous events
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>Event response</returns>
        private EventResponse ProcessSyncEvents(EventAction action)
        {
            EventNotificationType notificationType = (EventNotificationType)StringEnum.Parse(typeof(EventNotificationType), action.Notification);
            if (notificationType == EventNotificationType.QueryGatewayStatus)
            {
                return CheckGatewayStatus(action);
            }
            else if (notificationType == EventNotificationType.QueryWebServerStatus)
            {
                return CheckWebServerStatus(action);
            }
            else if (notificationType == EventNotificationType.QueryMessengerStatus)
            {
                return CheckMessengerStatus(action);
            }
            EventResponse response = new EventResponse();
            response.Status = StringEnum.GetStringValue(EventNotificationResponse.Failed);
            return response;
        }


        /// <summary>
        /// Checks the messenger status.
        /// </summary>
        /// <param name="action">The action.</param>
        private EventResponse CheckMessengerStatus(EventAction action)
        {
            string name = action.Values[EventParameter.MessengerName];
            log.DebugFormat("Check messenger status. Name is [{0}]", name);
            EventResponse response = new EventResponse();

            if (pollers == null || !pollers.Exists(p=> p.Name.ToLower() == name.ToLower()))
            {
                response.Status = StringEnum.GetStringValue(EventNotificationResponse.Failed);
                response.Results.Add(EventParameter.GatewayStatus, StringEnum.GetStringValue(GatewayStatus.Stopped));
            } else 
            {
                response.Results.Add(EventParameter.MessengerStatus, StringEnum.GetStringValue(MessengerStatus.Started));                
            }
            return response;
        }

        /// <summary>
        /// Processes the events.
        /// </summary>
        private void ProcessEvents()
        {
            while (true)
            {
                EventAction action = null;
                lock (eventLock)
                {
                    if (eventQueue.Count > 0)
                    {
                        PriorityQueueItem<EventAction, EventPriority> eventItem = eventQueue.Dequeue();
                        action = eventItem.Value;
                        if (action == null) return;
                    }
                }

                if (action != null)
                {
                    log.Debug(string.Format("Processing events [{0}] from {1}", action.Notification, action.Computer));

                    // Start processing events
                    EventNotificationType notificationType = (EventNotificationType)StringEnum.Parse(typeof(EventNotificationType), action.Notification);
                    if (notificationType == EventNotificationType.NewGateway)
                    {
                        // New gateway added                      
                        InitializeGateway(action);
                    }
                    else if (notificationType == EventNotificationType.StartGateway)
                    {
                        // Start gateway
                        StartGateway(action);
                    }
                    else if (notificationType == EventNotificationType.NewMessage)
                    {
                        // New message created, call send mesages
                        SendMessages();
                    }
                    else if (notificationType == EventNotificationType.RemoveGateway)
                    {
                        // Remove gateway
                        StopGateway(action);
                    }
                    else if (notificationType == EventNotificationType.StopGateway)
                    {
                        // Stop gateway
                        StopGateway(action);
                    }
                    else if (notificationType == EventNotificationType.RestartGateway)
                    {
                        StopGateway(action);
                        StartGateway(action);
                    }
                    else if (notificationType == EventNotificationType.StartWebServer)
                    {
                        StartWebServer();
                    }
                    else if (notificationType == EventNotificationType.StopWebServer)
                    {
                        StopWebServer();
                    }
                    else if (notificationType == EventNotificationType.StartMessenger)
                    {
                        StartMessenger(action);
                    }
                    else if (notificationType == EventNotificationType.StopMessenger)
                    {
                        StopMessenger(action);
                    }
                }
                else
                {
                    if (eventQueue.Count() == 0)
                        eventTrigger.WaitOne();       // wait for events
                }
            }
        }

        /// <summary>
        /// Starts the messenger.
        /// </summary>
        /// <param name="action">The action.</param>
        private EventResponse StartMessenger(EventAction action)
        {
            string name = action.Values[EventParameter.MessengerName];
            log.InfoFormat("Starting messenger. Name is [{0}]", name);
            EventResponse response = new EventResponse();
            DbMessenger messenger = DbMessenger.SingleOrDefault(m =>m.Name.ToLower() == name.ToLower());
            if (messenger != null)
            {
                // Start to poll incoming message
                if (workerThreads == null) workerThreads = new List<Thread>(1);
                if (pollers == null) pollers = new List<BasePoller>(1);

                // Check if the poller is already started
                if (pollers.Exists(p => p.Name.ToLower() == messenger.Name.ToLower()))
                {
                    log.InfoFormat("Database messenger [{0}] is already started", messenger.Name);
                    return response;
                }

                DatabasePoller poller = new DatabasePoller(messenger, this.messageGatewayService);
                poller.Name = messenger.Name;
                pollers.Add(poller);

                Thread worker = new Thread(new ThreadStart(poller.StartTimer));
                worker.IsBackground = true;
                worker.Name = messenger.Name;
                workerThreads.Add(worker);
                worker.Start();

                log.InfoFormat("Messenger [{0}] is started", name);
            }
            return response;
        }

        /// <summary>
        /// Stops the messenger.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private EventResponse StopMessenger(EventAction action)
        {
            string name = action.Values[EventParameter.MessengerName];
            if (log.IsDebugEnabled) log.DebugFormat("Stopping messenger. Name is [{0}]", name);
            EventResponse response = new EventResponse();
            DbMessenger messenger = DbMessenger.SingleOrDefault(m => m.Name.ToLower() == name.ToLower());
            if (messenger != null)
            {
                if (pollers == null) return response;

                // Check if the poller is already started
                if (pollers.Exists(p => p.Name.ToLower() == messenger.Name.ToLower()))
                {
                    BasePoller poller = pollers.Find(p => p.Name.ToLower() == messenger.Name.ToLower());
                    pollers.Remove(poller);

                    if (workerThreads != null)
                    {
                        Thread t = workerThreads.Find(w => messenger.Name.ToLower() == w.Name.ToLower());
                        if (t != null)
                        {
                            try
                            {
                                t.Join(ThreadWaitInterval);
                            }
                            catch (Exception ex)
                            {
                                log.Info(string.Format("Aborting thread [{0}]", t.Name), ex);
                                try
                                {
                                    t.Abort();
                                }
                                catch (Exception) { }
                            }
                        }
                    }
                    log.InfoFormat("Messenger [{0}] is stopped", name);
                }
                else
                {
                    log.InfoFormat("Unable to find messenger [{0}]", name);
                }
               
            }
            return response;
        }

        /// <summary>
        /// Starts the web server.
        /// </summary>
        private bool StartWebServer()
        {
            if (StopWebServer())
            {
                try
                {
                    log.Info("Starting web server");

                    string appPath = AppConfigSettings.GetString(ConfigParameter.WebServerAppPath);
                    string virtRoot = AppConfigSettings.GetString(ConfigParameter.WebServerVirtualPath);
                    int port = AppConfigSettings.GetInt(ConfigParameter.WebServerPort);

                    webServer = new WebServer(port, virtRoot, appPath);
                    webServer.Start();

                    log.Info("Web server started");
                    return true;
                }
                catch (Exception ex)
                {
                    StopWebServer();
                    log.Error(string.Format("Error starting web server: [{0}]", ex.Message), ex);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Stops the web server.
        /// </summary>
        private bool StopWebServer()
        {
            try
            {
                if (webServer != null)
                {
                    log.Info("Stopping web server");
                    webServer.Stop();
                    webServer = null;
                    log.Info("Web server stopped");
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error starting web server: [{0}]", ex.Message), ex);
                return false;
            }
        }

        /// <summary>
        /// Starts the gateway.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private EventResponse StartGateway(EventAction action)
        {
            string gatewayId = action.Values[EventParameter.GatewayId];
            if (log.IsDebugEnabled) log.Debug(string.Format("Start gateway. ID is [{0}]", gatewayId));
            EventResponse response = new EventResponse();

            IGateway gateway;

            if (messageGatewayService.Find(gatewayId, out gateway))
            {
                // Check if the status is Stopped/Failed/Restart, if yes, remove and restart
                if (gateway.Status == GatewayStatus.Failed ||
                    gateway.Status == GatewayStatus.Stopped ||
                    gateway.Status == GatewayStatus.Restart)
                {
                    messageGatewayService.Remove(gatewayId);
                    ConnectGateway(gatewayId);
                }
            }
            else
            {
                ConnectGateway(gatewayId);
            }

            return response;
        }


        /// <summary>
        /// Stops the gateway.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private EventResponse StopGateway(EventAction action)
        {
            string gatewayId = action.Values[EventParameter.GatewayId];
            log.Debug(string.Format("Stop gateway. ID is [{0}]", gatewayId));
            EventResponse response = new EventResponse();

            IGateway gateway;
            if (messageGatewayService.Find(gatewayId, out gateway))
            {
                messageGatewayService.Remove(gatewayId);
            }

            return response;
        }

        /// <summary>
        /// Connects the gateway.
        /// </summary>
        /// <param name="gatewayId">The gateway id.</param>
        private void ConnectGateway(string gatewayId)
        {
            GatewayConfig gwConfig = GatewayConfig.SingleOrDefault(g => g.Id == gatewayId);
            if (gwConfig != null)
            {
                ConnectGateway(gwConfig);
            }
        }

        /// <summary>
        /// Checks the gateway status.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private EventResponse CheckGatewayStatus(EventAction action)
        {
            string gatewayId = action.Values[EventParameter.GatewayId];
            log.Debug(string.Format("Check gateway status. ID is [{0}]", gatewayId));
            EventResponse response = new EventResponse();
            IGateway gateway;
            if (messageGatewayService.Find(gatewayId, out gateway))
            {
                // Gateway found
                response.Status = StringEnum.GetStringValue(EventNotificationResponse.OK);
                response.Results.Add(EventParameter.GatewayStatus, StringEnum.GetStringValue(gateway.Status));
                if (gateway.Status == GatewayStatus.Started)
                {
                    IMobileGateway mobileGateway = gateway as IMobileGateway;
                    response.Results.Add(EventParameter.GatewayOperator, mobileGateway.NetworkOperator.OperatorInfo);
                    response.Results.Add(EventParameter.GatewaySignalStrength, Convert.ToString(mobileGateway.SignalQuality.SignalStrengthPercent));
                }
            }
            else
            {
                response.Status = StringEnum.GetStringValue(EventNotificationResponse.Failed);
                response.Results.Add(EventParameter.GatewayStatus, StringEnum.GetStringValue(GatewayStatus.Stopped));
            }

            return response;
        }


        /// <summary>
        /// Checks the web server status.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private EventResponse CheckWebServerStatus(EventAction action)
        {
            EventResponse response = new EventResponse();
            response.Status = StringEnum.GetStringValue(EventNotificationResponse.OK);
            if (webServer != null)
            {
                response.Results.Add(EventParameter.WebServerStatus, StringEnum.GetStringValue(WebServerStatus.Started));
                response.Results.Add(EventParameter.WebServerUrl, webServer.RootUrl);
            }
            else
            {
                response.Results.Add(EventParameter.WebServerStatus, StringEnum.GetStringValue(WebServerStatus.Stopped));
                response.Results.Add(EventParameter.WebServerUrl, string.Empty);
            }
            return response;
        }

        /// <summary>
        /// Initializes the gateway.
        /// </summary>
        /// <param name="action">The action.</param>
        private void InitializeGateway(EventAction action)
        {
            string gatewayId = action.Values[EventParameter.GatewayId];
            log.Info(string.Format("New gateway [{0}] is added", gatewayId));
            GatewayConfig gwConfig = GatewayConfig.SingleOrDefault(g => g.Id == gatewayId);
            if (gwConfig != null)
            {
                ConnectGateway(gwConfig);
            }
        }

        /// <summary>
        /// Sends the messages.
        /// </summary>
        private void SendMessages()
        {
        }

        /// <summary>
        /// Stops the service.
        /// </summary>
        public void StopService()
        {
            try
            {
                log.Info("Stopping message service");
                StopMessageService();

                log.Info("Stop event listener");
                StopEventListener();

                log.Info("Stop pollers");
                StopPollers();
            }
            catch (Exception ex)
            {
                log.Error("Error stopping service");
                log.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Stops the message service.
        /// </summary>
        private void StopMessageService()
        {
            try
            {
                if (serviceControlThread != null && serviceControlThread.IsAlive)
                {
                    serviceControlThread.Abort();
                    serviceControlThread = null;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error stoppping service: " + ex.Message, ex);                
            }
        }

        /// <summary>
        /// Stops the listen.
        /// </summary>
        private void StopEventListener()
        {
            /**
           // Close the WCF service            
           if (serviceHost != null)
           {
               serviceHost.Close();
               serviceHost = null;
           }
            ***/

            try
            {
                if (eventListenerService != null)
                    RemotingServices.Unmarshal(eventListenerService);

                if (eventInvocation != null)
                    RemotingServices.Disconnect(eventInvocation);

                if (eventListenerChannel != null)
                    ChannelServices.UnregisterChannel(eventListenerChannel);

                if (eventQueue != null)
                {
                    eventQueue.Clear();
                    eventQueue = null;
                }
                if (eventTrigger != null)
                {
                    eventTrigger.Close();
                    eventTrigger = null;
                }
                if (eventProcessor != null)
                {
                    try
                    {
                        if (eventProcessor.IsAlive) eventProcessor.Abort();
                    }
                    catch (Exception) { }
                    eventProcessor = null;
                }
                eventListenerService = null;
                eventInvocation = null;
                eventListenerChannel = null;
            }
            catch (Exception ex)
            {
                log.Error("Error stoppping event listener: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Stops the pollers.
        /// </summary>
        private void StopPollers()
        {
            try
            {
                if (pollers == null) return;
                foreach (BasePoller poller in pollers)
                {
                    log.DebugFormat("Stopping {0}", poller.Name);
                    poller.StopTimer();
                }
                pollers.Clear();
                pollers = null;

                // Stop all threads
                foreach (Thread t in workerThreads)
                {
                    try
                    {
                        log.DebugFormat("Stopping thread {0}", t.Name);
                        //t.Join(ThreadWaitInterval);
                        t.Abort();
                    }
                    catch (Exception ex)
                    {
                        log.Info(string.Format("Error aborting thread [{0}]", t.Name), ex);
                        /*
                        log.Info(string.Format("Aborting thread [{0}]", t.Name), ex);
                        try
                        {
                            t.Abort();
                        }
                        catch (Exception) { }
                        */
                    }
                }
                workerThreads.Clear();
                workerThreads = null;
            }
            catch (Exception ex)
            {
                log.Error("Error stoppping pollers: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Starts the service. Use for debugging purpose
        /// </summary>
        public void StartService()
        {
            OnStart(null);
        }


    }
}
