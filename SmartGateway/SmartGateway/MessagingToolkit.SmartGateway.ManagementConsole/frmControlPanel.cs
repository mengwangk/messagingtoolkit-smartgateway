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
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using System.ServiceProcess;

using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Services;

using log4net;
using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.ManagementConsole;
using MessagingToolkit.SmartGateway.ManagementConsole.Properties;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core;
using MessagingToolkit.SmartGateway.Core.Interprocess;
using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.ManagementConsole
{
    /// <summary>
    /// SmartGateway control panel
    /// </summary>
    public partial class frmControlPanel : Form
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                
        /// <summary>
        /// Naming pattern for user control
        /// </summary>
        private const string UserControlStartNamePattern = "ctl";
        
        /// <summary>
        /// User control
        /// </summary>
        private Dictionary<string, Control> userControlLookup;

        /// <summary>
        /// Current control
        /// </summary>
        private Control currentControl = null;

        /// <summary>
        /// Control callback
        /// </summary>
        private delegate void SetControlCallback(Control control, TreeMenu menuItem);


        /// <summary>
        /// Stored initialized forms
        /// </summary>
        private static HybridDictionary InitializedForms = new HybridDictionary();

        /// <summary>
        /// Service event listener URL
        /// </summary>
        private string serviceEventListenerUrl = AppConfigSettings.GetString(ConfigParameter.ServiceEventListener, ModuleName.Service);

        // for interprocess communication
        private EventInvocation eventInvocation = null;
        private ObjRef eventListenerService = null;
        private TcpChannel eventListenerChannel = null;
        private PriorityQueue<EventAction, EventPriority> eventQueue;
        private EventWaitHandle eventTrigger;
        private object eventLock;
        private Thread eventProcessor;
        private bool exitApplication = false;
    

        /// <summary>
        /// Initializes a new instance of the <see cref="frmControlPanel"/> class.
        /// </summary>
        public frmControlPanel()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Handles the Click event of the tsbStatusPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbStatusPanel_Click(object sender, EventArgs e)
        {
            DisplayControl(ctlChannelStatus.Name);
            /*
            log.Debug("testing");
            EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.NewGateway));
            action.Values.Add(EventParameter.GatewayId, "Test");
            RemotingHelper.NotifyEvent(serviceEventListenerUrl, action);
            */
        }

        /// <summary>
        /// Handles the ItemClicked event of the tsApplicationMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ToolStripItemClickedEventArgs"/> instance containing the event data.</param>
        private void tsApplicationMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (object obj in tsApplicationMain.Items)
            {
                if (obj.GetType() == tsbStatusConsole.GetType()) 
                {
                    ToolStripButton button = (ToolStripButton)obj;
                    button.CheckState = CheckState.Unchecked;
                    if (e.ClickedItem == button)
                    {
                        button.CheckState = CheckState.Checked;
                    }
                }
            }           
        }

      
        /// <summary>
        /// Handles the Load event of the frmControlPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmControlPanel_Load(object sender, EventArgs e)
        {
            // Initialize the application
            InitializeApp();

            // Start event listener
            StartEventListener();

            // Check service is started
            CheckServiceStatus();
                      
        }

        /// <summary>
        /// Initializes the app.
        /// </summary>
        private void InitializeApp()
        {             
            // Get the user controls
            userControlLookup = new Dictionary<string, Control>(10);
            foreach (Control control in this.Controls)
            {
                if (control.Name.StartsWith(UserControlStartNamePattern))
                {                   
                    control.Size = new Size(10, 10);
                    control.Enabled = false;
                    userControlLookup.Add(control.Name.ToLower(), control);
                }
            }

            // Raise event when a new gateway is added or removed
            ctlChannels.GatewayAdded += new NewGatewayEventHandler(ctlChannels_GatewayAdded);
            ctlChannels.GatewayRemoved += new DeleteGatewayEventHandler(ctlChannels_GatewayRemoved);
            
            panelConfiguration.ActionTrigger += new MenuPanel.ActionTriggerEventHandler(panelConfiguration_ActionTrigger);

            // Display start menu
            DisplayControl(ctlStartMenu.Name);
           
        }

        /// <summary>
        /// Checks the service status.
        /// </summary>
        private void CheckServiceStatus()
        {
            try
            {
                ServiceController serviceController = new ServiceController(ServiceParameter.WindowsServiceName, Environment.MachineName);
                if (serviceController.Status != ServiceControllerStatus.Running)
                {
                    FormHelper.ShowInfo(Resources.ServerServiceNotStarted);
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Handle gateway removed event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        void ctlChannels_GatewayRemoved(object sender, GatewayEventHandlerArgs e)
        {
            log.Info(string.Format("New gateway [{0}] is added", e.GatewayId));
            EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.RemoveGateway));
            action.Values.Add(EventParameter.GatewayId, e.GatewayId);
            RemotingHelper.NotifyEvent(serviceEventListenerUrl, action);

            // Reset the settings in NewMessage user control
            ctlNewMessage.SetupMessageSettings();
        }

        /// <summary>
        /// CTLs the channels_ gateway added.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void ctlChannels_GatewayAdded(object sender, GatewayEventHandlerArgs e)
        {
            log.Info(string.Format("New gateway [{0}] is added", e.GatewayId));
            EventAction action = new EventAction(StringEnum.GetStringValue(EventNotificationType.NewGateway));
            action.Values.Add(EventParameter.GatewayId, e.GatewayId);
            RemotingHelper.NotifyEvent(serviceEventListenerUrl, action);

            // Reset the settings in NewMessage user control
            ctlNewMessage.SetupMessageSettings();
        }

        /// <summary>
        /// Menu action
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The menu item argument.</param>
        private void panelConfiguration_ActionTrigger(object sender, MenuPanel.ActionTriggerEventHandlerArgs e)
        {
            ShowControl(e.MenuItem);
        }

        /// <summary>
        /// Shows the control.
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        private void ShowControl(TreeMenu menuItem)
        {
            if (menuItem != null)
            {
                if (currentControl != null && currentControl.Name.Equals(menuItem.ActionClass, StringComparison.OrdinalIgnoreCase))
                {
                    // Click on the same menu item
                    return;
                }

                Control control;
                if (userControlLookup.TryGetValue(menuItem.ActionClass.ToLower(), out control))
                {
                    SetControl(control, menuItem);
                }
            }
        }

        /// <summary>
        /// Outputs the specified text.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="menuItem">The menu item.</param>
        /// <param name="currentControl">The current control.</param>
        private void SetControl(Control control, TreeMenu menuItem)
        {            
            if (control.InvokeRequired)
            {
                SetControlCallback scc = new SetControlCallback(SetControl);
                this.Invoke(scc, new object[] { control, menuItem});
            }
            else
            {
                //if (currentControl != null) currentControl.Visible = false;    
                if (currentControl != null)
                {
                    currentControl.Enabled = false;
                    currentControl.Dock = DockStyle.None;
                } 
                control.Tag = menuItem.Module;
                control.Enabled = true;
                control.Dock = DockStyle.Fill;
                control.BringToFront();
                currentControl = control;
            }
        }

        /**
        /// <summary>
        /// Handles the VisibleChanged event of the ctlMonitorAppLogFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ctlMonitorAppLogFile_VisibleChanged(object sender, EventArgs e)
        {
            if (!ctlMonitorAppLogFile.Visible) return;

            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string appFileName = AppConfigSettings.GetString(ConfigParameter.ApplicationLogFileName);
            string logFileName = Path.Combine(currentDirectory, appFileName);
            if (File.Exists(logFileName))
            {                
                log.Info(string.Format("Loading {0}", logFileName));
                ctlMonitorAppLogFile.FileName = logFileName;
                ctlMonitorAppLogFile.Start();
            }
            else
            {
                log.Info(string.Format("Unable to find {0}", logFileName));
            }

        }
        **/

        /// <summary>
        /// Handles the Click event of the tsbStatusConsole control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbStatusConsole_Click(object sender, EventArgs e)
        {
            LoadFormType(typeof(mdiStatusConsole));
        }


        /// <summary>
        /// Loads the type of the form.
        /// </summary>
        /// <param name="formType">Type of the form.</param>
        private void LoadFormType(Type formType)
        {
            if (IsAlreadyLoaded(formType))
            {
                Form f = GetForm(formType);
                f.Focus();
                return;
            }            
           
            Form frm = (Form)Activator.CreateInstance(formType);
            frm.Closed += new EventHandler(Form_Closed);
            frm.Show();
            FlagAsLoaded(formType, frm);
        }

        /// <summary>
        /// Flags as loaded.
        /// </summary>
        /// <param name="formType">Type of the form.</param>
        /// <param name="frm">The FRM.</param>
        private void FlagAsLoaded(Type formType, Form frm)
        {            
            InitializedForms[formType.Name] = frm;
        }

        /// <summary>
        /// Flags as not loaded.
        /// </summary>
        /// <param name="formType">Type of the form.</param>
        private void FlagAsNotLoaded(Type formType)
        {           
            InitializedForms[formType.Name] = null;
        }



        /// <summary>
        /// Determines whether [is already loaded] [the specified form type].
        /// </summary>
        /// <param name="formType">Type of the form.</param>
        /// <returns>
        /// 	<c>true</c> if [is already loaded] [the specified form type]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsAlreadyLoaded(Type formType)
        {
            return ((InitializedForms[formType.Name] != null));                
        }

        /// <summary>
        /// Gets the form.
        /// </summary>
        /// <param name="formType">Type of the form.</param>
        /// <returns></returns>
        private Form GetForm(Type formType)
        {
            return (Form)InitializedForms[formType.Name];            
        }

        /// <summary>
        /// Handles the Closed event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Form_Closed(object sender, EventArgs e)
        {
            Form closingForm = (Form)sender;
            closingForm.Closed -= new EventHandler(Form_Closed);
            FlagAsNotLoaded(sender.GetType());
        }

        /// <summary>
        /// Handles the Click event of the tsbAbout control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbAbout_Click(object sender, EventArgs e)
        {           
            DisplayControl(ctlAbout.Name);           
        }

        /// <summary>
        /// Displays the control.
        /// </summary>
        /// <param name="actionClass">The action class.</param>
        private void DisplayControl(string actionClass)
        {
            if (currentControl != null && currentControl.Name.Equals(actionClass, StringComparison.OrdinalIgnoreCase))
            {
                // Click on the same menu item
                return;
            }

            Control control;
            if (userControlLookup.TryGetValue(actionClass.ToLower(), out control))
            {
                //if (currentControl != null) currentControl.Visible = false;
                //control.Visible = true;
                if (currentControl != null)
                {
                    currentControl.Enabled = false;
                    currentControl.Dock = DockStyle.None;
                }
                control.Enabled = true;
                control.Dock = DockStyle.Fill;
                control.BringToFront();
                currentControl = control;
            }
        }


        /// <summary>
        /// Handles the Click event of the exitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownApplication();
        }


        /// <summary>
        /// Exits the application.
        /// </summary>
        private bool ShutdownApplication()
        {
            if (FormHelper.Confirm(Resources.MsgConfirmExitApplication) == DialogResult.Yes)
            {
                this.exitApplication = true;
                this.Close();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Stops the listener
        /// </summary>
        private void StopEventListener()
        {
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
                log.Error("Error stopping event listener: " + ex.Message, ex);               
            }
        }

        /// <summary>
        /// Starts the listen.
        /// </summary>
        private void StartEventListener()
        {
            StopEventListener(); // if there is any channel still open --> close it

            try
            {
                log.Info("Starting event listener");
                int port = AppConfigSettings.GetInt(ConfigParameter.ListenerPort, ModuleName.Console);
                eventListenerChannel = new TcpChannel(port);
                ChannelServices.RegisterChannel(eventListenerChannel, false);

                eventInvocation = new EventInvocation();
                string serviceName = AppConfigSettings.GetString(ConfigParameter.ListenerServiceName, ModuleName.Console);

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
                log.Error("Error starting event listener: " + ex.Message, ex);
                StopEventListener(); // calls StopEventListener
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
                // Queue the event and trigger the processing
                eventQueue.Enqueue(action, EventPriority.Normal);
                eventTrigger.Set();

                // Send back the processing
                EventResponse response = new EventResponse();
                response.Status = StringEnum.GetStringValue(EventNotificationResponse.OK);
                return response;
            }
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
                    log.Info(string.Format("Processing events {0} from {1}", action.Notification, action.Computer));
                    
                    // Start processing events
                    EventNotificationType notificationType =  (EventNotificationType)StringEnum.Parse(typeof(EventNotificationType), action.Notification);
                    if (notificationType == EventNotificationType.NewMessage)
                    {
                        log.Info("New messages arrived");
                        RefreshMessageView(ViewAction.RefreshInbox);
                    }
                    
                }
                else 
                {
                    eventTrigger.WaitOne();       // wait for events
                }
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the frmControlPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void frmControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.exitApplication)
            {
                if (!ShutdownApplication())
                {
                    e.Cancel = true;
                    return;
                }
            }

            try
            {
                OnEventReceived(null);  // Signal the event processor to stop
                eventProcessor.Join();  // Wait for the consumer's thread to finish.
                eventTrigger.Close();
            }
            catch (Exception ex)
            {
                log.Error("Shutdown error", ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the tsbService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbService_Click(object sender, EventArgs e)
        {
            frmServiceControl serviceControl = new frmServiceControl();
            serviceControl.ShowDialog(this);
        }

        /// <summary>
        /// Triggered whenever any link is clicked
        /// </summary>
        /// <param name="parameters">The parameters passed in from the link</param>
        public void LinkClicked(params object[] parameters)
        {
            string className = parameters[0].ToString();
            string module = parameters[1].ToString();

            TreeMenu menuItem = new TreeMenu();
            menuItem.ActionClass = className;
            menuItem.Module = module;
            ShowControl(menuItem);
            panelConfiguration.SelectNode(menuItem);
        }

        /// <summary>
        /// Handles the Click event of the tsbExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbExit_Click(object sender, EventArgs e)
        {
            ShutdownApplication();
        }

        /// <summary>
        /// Refreshes the message view.
        /// </summary>
        /// <param name="action">The action.</param>
        public void RefreshMessageView(ViewAction action)
        {
            if (action == ViewAction.RefreshOutbox)
            {
                ctlOutbox.RefreshView();
            }
            else if (action == ViewAction.RefreshInbox)
            {
                ctlInbox.RefreshView();
            }
            else if (action == ViewAction.RefreshArchivedInbox)
            {
                ctlArchivedInbox.RefreshView();
            }
            else if (action == ViewAction.RefreshArchivedOutbox)
            {
                ctlArchivedOutbox.RefreshView();
            }
            else if (action == ViewAction.RefreshFailedOutbox)
            {
                ctlOutboxFailed.RefreshView();
            }
        }

        /// <summary>
        /// Handles the Click event of the tsbConfiguration control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tsbConfiguration_Click(object sender, EventArgs e)
        {
            DisplayControl(ctlConfiguration.Name);
        }

    }
}
