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
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Configuration panel for SmartGateway
    /// </summary>
    public partial class MenuPanel : UserControl
    {
        // ---------- Event handling -------------

        /// <summary>
        /// Argument when the menu item action is triggered
        /// </summary>
        public class ActionTriggerEventHandlerArgs
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="ActionTriggerEventHandlerArgs"/> class.
            /// </summary>
            /// <param name="menuItem">The menu item.</param>
            public ActionTriggerEventHandlerArgs(TreeMenu menuItem)
            {
                this.MenuItem = menuItem;
            }

            /// <summary>
            /// Gets the menu item.
            /// </summary>
            /// <value>The menu item.</value>
            public TreeMenu MenuItem
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Action triggered event handler
        /// </summary>
        public delegate void ActionTriggerEventHandler(object sender, ActionTriggerEventHandlerArgs e);


        /// <summary>
        /// Occurs when menu click action is triggered
        /// </summary>
        public event ActionTriggerEventHandler ActionTrigger;


        // ----------------------------------------

        // ---------  Private variables -----------
        
        /*
        private const int MessageServerImageIndex = 0;
        private const int ServerLogImageIndex = 1;
        private const int ConnectorImageIndex = 2;
        private const int FolderImageIndex = 3;
        private const int GatewayImageIndex = 4;
        private const int UsersImageIndex = 5;
        private const int UserGroupsImageIndex = 6;
        private const int ApplicationImageIndex = 7;
        private const int SettingImageIndex = 8;
        private const int AddressBookImageIndex = 9;
        private const int ContactImageIndex = 10;
        private const int MessageImageIndex = 11;
        private const int SchedulerImageIndex = 12;
        private const int HelpImageIndex = 13;
        private const int MessagesImageIndex = 14;
        private const int ProcessLogImageIndex = 15;
        */
      

        //-----------------------------------------

        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationPanel"/> class.
        /// </summary>
        public MenuPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void LoadMenu()
        {
            LoadConfiguration();
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        private void LoadConfiguration()
        {            
            Dictionary<long, List<TreeMenu>> menuLevelLookup = new Dictionary<long, List<TreeMenu>>(10);
            TreeMenu rootMenu = null;
            foreach (TreeMenu menu in TreeMenu.All().Where(m=>m.Enabled == true).OrderBy(m => m.Id))
            {
                List<TreeMenu> menuList;
                if (!menuLevelLookup.TryGetValue((long)menu.ParentId, out menuList))
                {                   
                    menuList = new List<TreeMenu>(5);
                    menuList.Add(menu);
                    menuLevelLookup.Add((long)menu.ParentId, menuList);
                }
                else
                {
                    menuList.Add(menu);
                }

                // Assumption is that when parent id is 0, then it is the root node
                if (menu.ParentId == 0)
                {
                    rootMenu = menu;
                }
            }

            // Start with the root menu
            if (rootMenu != null)
            {
                treeConfig.BeginUpdate();
                TreeNode rootNode = new TreeNode(rootMenu.Text, (int)rootMenu.ImageIndex, (int)rootMenu.SelectedImageIndex);
                rootNode.Tag = rootMenu;
                treeConfig.Nodes.Add(rootNode);
                AddToTree(menuLevelLookup, rootNode, rootMenu);
                rootNode.Expand();
                treeConfig.EndUpdate();
                treeConfig.Refresh();
            }



            /*
            TreeNode rootNode = new TreeNode("Message Server", MessageServerImageIndex, MessageServerImageIndex);
            treeConfig.Nodes.Add(rootNode);

            TreeNode serverLogNode = new TreeNode("Server Log", ServerLogImageIndex, ServerLogImageIndex);
            rootNode.Nodes.Add(serverLogNode);

            TreeNode connectorNode = new TreeNode("Connectors", ConnectorImageIndex, ConnectorImageIndex);
            rootNode.Nodes.Add(connectorNode);

            TreeNode gatewayFolderNode = new TreeNode("Gateways", FolderImageIndex, FolderImageIndex);
            connectorNode.Nodes.Add(gatewayFolderNode);

            TreeNode gatewayNode = new TreeNode("Gateway-1", GatewayImageIndex, GatewayImageIndex);
            gatewayFolderNode.Nodes.Add(gatewayNode);

            TreeNode gatewaySettingNode = new TreeNode("Settings", SettingImageIndex, SettingImageIndex);
            gatewayNode.Nodes.Add(gatewaySettingNode);

            TreeNode gatewayMessageLogNode = new TreeNode("Message Log", MessagesImageIndex, MessagesImageIndex);
            gatewayNode.Nodes.Add(gatewayMessageLogNode);

            TreeNode gatewayProcessLogNode = new TreeNode("Process Log", ProcessLogImageIndex, ProcessLogImageIndex);
            gatewayNode.Nodes.Add(gatewayProcessLogNode);

            TreeNode userAccountNode = new TreeNode("User Accounts", FolderImageIndex, FolderImageIndex);
            rootNode.Nodes.Add(userAccountNode);

            TreeNode userNode = new TreeNode("Users", UsersImageIndex, UsersImageIndex);
            userAccountNode.Nodes.Add(userNode);

            TreeNode userGroupNode = new TreeNode("User Groups", UserGroupsImageIndex, UserGroupsImageIndex);
            userAccountNode.Nodes.Add(userGroupNode);


            TreeNode applicationNode = new TreeNode("Applications", FolderImageIndex, FolderImageIndex);
            rootNode.Nodes.Add(applicationNode);


            TreeNode messengerNode = new TreeNode("Messengers", ApplicationImageIndex, ApplicationImageIndex);
            applicationNode.Nodes.Add(messengerNode);

            TreeNode messengerSettingNode = new TreeNode("Settings", SettingImageIndex, SettingImageIndex);
            messengerNode.Nodes.Add(messengerSettingNode);

            TreeNode messengerAddressBookNode = new TreeNode("Address Book", AddressBookImageIndex, AddressBookImageIndex);
            messengerNode.Nodes.Add(messengerAddressBookNode);

            TreeNode addressBookContactNode = new TreeNode("All Contacts",ContactImageIndex, ContactImageIndex);
            messengerAddressBookNode.Nodes.Add(addressBookContactNode);

            TreeNode addressBookGroupNode = new TreeNode("Groups", ContactImageIndex, ContactImageIndex);
            messengerAddressBookNode.Nodes.Add(addressBookGroupNode);


            TreeNode triggerNode = new TreeNode("Triggers", ApplicationImageIndex, ApplicationImageIndex);
            applicationNode.Nodes.Add(triggerNode);

            TreeNode triggerMessageNode = new TreeNode("Incoming Messages", MessageImageIndex, MessageImageIndex);
            triggerNode.Nodes.Add(triggerMessageNode);

            TreeNode triggerSchedulerNode = new TreeNode("Schedulers", SchedulerImageIndex, SchedulerImageIndex);
            triggerNode.Nodes.Add(triggerSchedulerNode);

            TreeNode databaseWatcherNode = new TreeNode("Database Watchers", ApplicationImageIndex, ApplicationImageIndex);
            applicationNode.Nodes.Add(databaseWatcherNode);

            TreeNode helpNode = new TreeNode("Documentation", HelpImageIndex, HelpImageIndex);
            rootNode.Nodes.Add(helpNode);
            

            rootNode.ExpandAll();
             */
        }

        /// <summary>
        /// Add the nodes to the tree recursively.
        /// </summary>
        /// <param name="menuLevelLookup">The menu level lookup.</param>
        /// <param name="parentNode">The parent node.</param>
        /// <param name="parentMenu">The parent menu.</param>
        private void AddToTree(Dictionary<long, List<TreeMenu>> menuLevelLookup, TreeNode parentNode, TreeMenu parentMenu)
        {
            // Get the next level
            List<TreeMenu> menuList;
            if (menuLevelLookup.TryGetValue(parentMenu.Id, out menuList))
            {               
                foreach (TreeMenu menu in menuList.OrderBy(m => m.Sequence))
                {
                    TreeNode node = new TreeNode(menu.Text, (int)menu.ImageIndex, (int)menu.SelectedImageIndex);
                    node.Tag = menu;
                    parentNode.Nodes.Add(node);
                    AddToTree(menuLevelLookup, node, menu);
                }
            }           
        }

        /// <summary>
        /// Handles the AfterSelect event of the treeConfig control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        private void treeConfig_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeConfig.SelectedNode;
            object obj = selectedNode.Tag;
            if (obj != null && obj.GetType() == typeof(TreeMenu))
            {
                TreeMenu menu = (TreeMenu)obj;
                if (ActionTrigger != null && !string.IsNullOrEmpty(menu.ActionClass))
                {
                    ActionTriggerEventHandlerArgs arg = new ActionTriggerEventHandlerArgs(menu);
                    this.ActionTrigger.BeginInvoke(this, arg, new AsyncCallback(this.AsyncCallback), null);
                }               
            }
        }      


          /// <summary>
        /// Asynchronous callback method
        /// </summary>
        /// <param name="param">Result</param>
        private void AsyncCallback(IAsyncResult param)
        {
            System.Runtime.Remoting.Messaging.AsyncResult result = (System.Runtime.Remoting.Messaging.AsyncResult)param;
            if (result.AsyncDelegate is ActionTriggerEventHandler)
            {
                ((ActionTriggerEventHandler)result.AsyncDelegate).EndInvoke(result);
            }
            else
            {
            }
        }

        /// <summary>
        /// Handles the Load event of the MenuPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MenuPanel_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // Load the menu
            LoadMenu();
        }


        /// <summary>
        /// Selects the node.
        /// </summary>
        /// <param name="menu">The menu.</param>
        public void SelectNode(TreeMenu menu)
        {
            List<TreeNode> nodes = FlattenDepth(treeConfig);
            foreach (TreeNode node in nodes)
            {
                if (node.Tag != null && node.Tag.GetType() == typeof(TreeMenu))
                {
                    TreeMenu nodeMenu = (TreeMenu)node.Tag;
                    if (!string.IsNullOrEmpty(nodeMenu.ActionClass) && nodeMenu.ActionClass.Equals(menu.ActionClass))
                    {
                        treeConfig.SelectedNode = node;
                        node.ExpandAll();
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// This static utiltiy method flattens all the nodes in a tree view using
        /// a queue based breath first search rather than the overhead
        /// of recursive method calls.
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static List<TreeNode> FlattenBreath(TreeView tree)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            //
            // Bang all the top nodes into the queue.
            //
            foreach (TreeNode top in tree.Nodes)
            {
                queue.Enqueue(top);
            }

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node != null)
                {
                    //
                    // Add the node to the list of nodes.
                    //
                    nodes.Add(node);
                    if (node.Nodes != null && node.Nodes.Count > 0)
                    {
                        //
                        // Enqueue the child nodes.
                        //
                        foreach (TreeNode child in node.Nodes)
                        {
                            queue.Enqueue(child);
                        }
                    }
                }
            }
            return nodes;
        }

        /// <summary>
        /// This static utiltiy method flattens all the nodes in a tree view using
        /// a stack based depth first search rather than the overhead
        /// of recursive method calls.
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static List<TreeNode> FlattenDepth(TreeView tree)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            //
            // Bang all the top nodes into the queue.
            //
            foreach (TreeNode top in tree.Nodes)
            {
                stack.Push(top);
            }

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                if (node != null)
                {
                    //
                    // Add the node to the list of nodes.
                    //
                    nodes.Add(node);
                    if (node.Nodes != null && node.Nodes.Count > 0)
                    {
                        //
                        // Enqueue the child nodes.
                        //
                        foreach (TreeNode child in node.Nodes)
                        {
                            stack.Push(child);
                        }
                    }
                }
            }
            return nodes;
        }

    }
}
