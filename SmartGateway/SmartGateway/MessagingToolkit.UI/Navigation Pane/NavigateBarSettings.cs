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
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace MessagingToolkit.UI
{
    /// <summary>
    /// Save and restore last settings in XML file for navigatebar and buttons.
    /// </summary>
    class NavigateBarSettings
    {

        #region NavigateBarColorTable
        NavigateBarColorTable colorTable = new NavigateBarColorTable();
        public NavigateBarColorTable ColorTable
        {
            get { return colorTable; }
        }
        #endregion

        #region DisplayedButtonCount
        int displayedbuttonCount = -1;
        /// <summary>
        /// How many button displayed in panel on exit ? (Get)
        /// </summary>
        public int DisplayedButtonCount
        {
            get { return displayedbuttonCount; }
        }
        #endregion

        #region ButtonRestoreInfo
        Dictionary<string, ButtonRestoreSettings> restoreInfo = new Dictionary<string, ButtonRestoreSettings>();
        /// <summary>
        /// Buttons info. string parameter is NavigateBarButton.Key value.
        /// </summary>
        public Dictionary<string, ButtonRestoreSettings> ButtonRestoreInfo
        {
            get { return restoreInfo; }
        }
        #endregion

        #region IsShowCollapseButton
        bool isShowCollapseButton = true;
        public bool IsShowCollapseButton
        {
            get { return isShowCollapseButton; }
        }
        #endregion

        #region IsCollapsible
        bool isCollapsible = true;
        public bool IsCollapsible
        {
            get { return isCollapsible; }
        }
        #endregion

        #region ButtonHeight
        int buttonHeight = NavigateBar.BUTTON_HEIGHT;
        /// <summary>
        /// What is button height on exit ? (Get)
        /// </summary>
        public int ButtonHeight
        {
            get { return buttonHeight; }
        }
        #endregion

        #region PaneWidth
        int paneWidth = NavigateBar.DEFAULT_WIDTH;
        /// <summary>
        /// What is pane width on exit ? (Get)
        /// </summary>
        public int PaneWidth
        {
            get { return paneWidth; }
        }
        #endregion

        #region IsLoad
        bool isLoad = true;
        /// <summary>
        /// Is load setting from XML file ?
        /// </summary>
        public bool IsLoad
        {
            get { return isLoad; }
        }
        #endregion

        #region OverFlowPanelHeight
        int overFlowPanelHeight = NavigateBar.BUTTON_HEIGHT;
        public int OverFlowPanelHeight
        {
            get { return overFlowPanelHeight; }
        }
        #endregion

        #region SettingsFileName
        /// <summary>
        /// Full path for setting file
        /// </summary>
        string settingsFileName = "";
        public string SettingsFileName
        {
            get { return settingsFileName; }
            set
            {
                settingsFileName = value;
                RestoreSettingsFromXmlFile();
            }
        }
        #endregion

        #region ErrorMessage
        string errorMessage = string.Empty;
        public string ErrorMessage
        {
            get { return errorMessage; }
        }
        #endregion

        // Var

        NavigateBar navigateBar;

        #region Yapıcı Method
        public NavigateBarSettings(NavigateBar tNavigateBar)
        {
            navigateBar = tNavigateBar;
        }

        #endregion

        #region Save Settings

        /// <summary>
        /// Save settings in XML file
        /// </summary>
        public bool SaveSettingsToXmlFile()
        {

            bool isSaved = true;
            if (string.IsNullOrEmpty(settingsFileName))
            {
                errorMessage = "Setting file name is null or empty";
                return false;
            }

            if (!navigateBar.SaveAndRestoreSettings)
            {
                if (File.Exists(settingsFileName))
                    File.Delete(settingsFileName);
                return false;
            }

            try
            {

                if (navigateBar.NavigateBarButtons.Count < 0)
                    return false;

                int dispCount = navigateBar.NavigateBarButtons.GetDisplayedItemCount();

                FileInfo fInfo = new FileInfo(settingsFileName);

                if (!Directory.Exists(fInfo.DirectoryName))
                    Directory.CreateDirectory(fInfo.DirectoryName);

                XmlTextWriter xtw = new XmlTextWriter(settingsFileName, Encoding.UTF8);
                xtw.Formatting = Formatting.Indented;
                xtw.WriteStartDocument(true);

                // Comment
                xtw.WriteComment("Outlook 2003 Style Navigation Pane Settings");
                xtw.WriteComment("Do not manual change this file");

                // Navigatebar panel info

                #region NavigateBar
                xtw.WriteStartElement("NavigationPaneSettings");
                xtw.WriteAttributeString("DiplayedButtonCount", dispCount.ToString());
                xtw.WriteAttributeString("ButtonHeight", navigateBar.NavigateBarButtonHeight.ToString());
                xtw.WriteAttributeString("PaneWidth", navigateBar.Width.ToString());
                xtw.WriteAttributeString("IsShowCollapseButton", navigateBar.IsShowCollapseButton.ToString());
                xtw.WriteAttributeString("IsCollapsible", navigateBar.IsCollapsible.ToString());
                xtw.WriteAttributeString("OverFlowPanelHeight", navigateBar.OverFlowPanelHeight.ToString());
                #endregion

                // Color Table info

                #region Color Table
                xtw.WriteStartElement("ColorTable");

                Type t = navigateBar.NavigateBarColorTable.GetType();
                foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {

                    //if (pi.MemberType != MemberTypes.Property) continue;

                    object obj = pi.GetValue(navigateBar.NavigateBarColorTable, null);

                    if (obj == null) continue;

                    string strval = "";

                    if (pi.PropertyType == typeof(Color)) strval = ((Color)obj).ToArgb().ToString();
                    if (pi.PropertyType == typeof(bool)) strval = ((bool)obj).ToString();
                    if (pi.PropertyType == typeof(float)) strval = ((float)obj).ToString();
                    if (pi.PropertyType == typeof(ContextMenuArrowStyle)) strval = ((ContextMenuArrowStyle)obj).ToString();

                    xtw.WriteElementString(pi.Name, strval);

                }

                xtw.WriteEndElement();

                #endregion

                // Buttons info

                #region Buttons
                for (int i = 0; i < navigateBar.NavigateBarButtons.Count; i++)
                {
                    NavigateBarButton nvb = navigateBar.NavigateBarButtons[i];
                    // If null or empty key value skip this button
                    if (!string.IsNullOrEmpty(nvb.Key)) // Key boş bırakılan buttonlar xml içerisine kayıt edilmiyor
                    {
                        xtw.WriteStartElement(nvb.Key.Replace(" ", ""));
                        xtw.WriteAttributeString("Enabled", nvb.Enabled.ToString());
                        xtw.WriteAttributeString("Display", nvb.IsDisplayed.ToString());
                        xtw.WriteAttributeString("Visible", nvb.Visible.ToString());
                        xtw.WriteAttributeString("Selected", nvb.IsSelected.ToString());
                        xtw.WriteAttributeString("OrderNo", i.ToString());
                        xtw.WriteEndElement();
                    }
                }
                #endregion

                xtw.WriteEndElement(); // NavigationPaneSettings

                xtw.Flush();
                xtw.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                isSaved = false;
            }

            return isSaved;
        }
        #endregion

        #region Restore Settings
        /// <summary>
        /// Restore settings from XML file
        /// </summary>
        void RestoreSettingsFromXmlFile()
        {

            if (string.IsNullOrEmpty(settingsFileName))
            {
                errorMessage = "Setting file name is empty or null";
                return;
            }

            if (!File.Exists(settingsFileName))
            {
                errorMessage = "File not found  ( " + settingsFileName + " )";
                isLoad = false;
                return;
            }

            restoreInfo.Clear();

            try
            {
                XmlTextReader xtr = new XmlTextReader(settingsFileName);

                while (xtr.Read())
                {
                    if (string.IsNullOrEmpty(xtr.Name))
                        xtr.Skip();

                    #region Color Table
                    if (xtr.IsStartElement("ColorTable"))
                    {

                        XmlReader xtrSub = xtr.ReadSubtree();
                        if (xtrSub != null)
                        {

                            while (!xtrSub.EOF)
                            {

                                xtr.Read();

                                if (string.IsNullOrEmpty(xtrSub.Name))
                                    xtrSub.Skip();

                                if (xtrSub.NodeType == XmlNodeType.Element)
                                {
                                    string strVal = xtrSub.ReadString();
                                    if (!string.IsNullOrEmpty(strVal))
                                    {
                                        object setValue = null;
                                        PropertyInfo pi = colorTable.GetType().GetProperty(xtrSub.Name);

                                        if (pi.PropertyType == typeof(float)) setValue = Convert.ToSingle(strVal);
                                        if (pi.PropertyType == typeof(bool)) setValue = strVal.Equals("True");
                                        if (pi.PropertyType == typeof(Color)) setValue = Color.FromArgb(Convert.ToInt32(strVal));
                                        if (pi.PropertyType == typeof(ContextMenuArrowStyle)) setValue = Enum.Parse(typeof(ContextMenuArrowStyle), strVal);

                                        colorTable.GetType().InvokeMember(xtrSub.Name, BindingFlags.SetProperty, null,
                                            colorTable, new object[] { setValue });

                                    }
                                }
                            }
                        }

                        xtrSub.Close();

                    }
                    #endregion

                    #region NavigateBar
                    if (xtr.Name.Equals("NavigationPaneSettings") && xtr.HasAttributes)
                    {
                        for (int i = 0; i < xtr.AttributeCount; i++)
                        {
                            xtr.MoveToAttribute(i);
                            if (xtr.Name.Equals("DiplayedButtonCount")) displayedbuttonCount = Convert.ToInt32(xtr.Value);
                            if (xtr.Name.Equals("ButtonHeight")) buttonHeight = Convert.ToInt32(xtr.Value);
                            if (xtr.Name.Equals("PaneWidth")) paneWidth = Convert.ToInt32(xtr.Value);
                            if (xtr.Name.Equals("OverFlowPanelHeight")) overFlowPanelHeight = Convert.ToInt32(xtr.Value);
                            if (xtr.Name.Equals("IsCollapsible")) isCollapsible = xtr.Value.ToUpper().Equals("TRUE");
                            if (xtr.Name.Equals("IsShowCollapseButton")) isShowCollapseButton = xtr.Value.ToUpper().Equals("TRUE");
                        }
                        continue;
                    }
                    #endregion

                    #region Buttons
                    ButtonRestoreSettings brs = new ButtonRestoreSettings();
                    brs.Key = xtr.Name;

                    if (xtr.HasAttributes)
                    {
                        for (int i = 0; i < xtr.AttributeCount; i++)
                        {
                            xtr.MoveToAttribute(i);
                            if (xtr.Name.Equals("Enabled")) brs.Enabled = xtr.Value.Equals("True");
                            if (xtr.Name.Equals("Display")) brs.Display = xtr.Value.Equals("True");
                            if (xtr.Name.Equals("Visible")) brs.Visible = xtr.Value.Equals("True");
                            if (xtr.Name.Equals("Selected")) brs.Selected = xtr.Value.Equals("True");
                            if (xtr.Name.Equals("OrderNo")) brs.Order = Convert.ToInt32(xtr.Value);
                        }
                    }

                    restoreInfo.Add(brs.Key, brs);
                    #endregion

                } //while

                xtr.Close();
            }
            catch (Exception e)
            {
                isLoad = false;
                errorMessage = e.Message;
            }
        }
        #endregion

        #region Overrided Method
        public override string ToString()
        {
            return "NavigationPaneSettings";
        }
        #endregion

        #region SubClass ButtonRestoreSettings
        internal class ButtonRestoreSettings
        {
            string key = "";
            public string Key
            {
                get { return key; }
                set { key = value; }
            }

            bool visible = true;
            public bool Visible
            {
                get { return visible; }
                set { visible = value; }
            }

            bool enabled = true;
            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }

            bool selected = false;
            public bool Selected
            {
                get { return selected; }
                set { selected = value; }
            }

            bool display = true;
            public bool Display
            {
                get { return display; }
                set { display = value; }
            }

            int order = 0;
            public int Order
            {
                get { return order; }
                set { order = value; }
            }
        }
        #endregion
    }
}
