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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MessagingToolkit.UI.Design
{
    /// <summary>
    /// NavigateBar designer object
    /// </summary>
    class NavigateBarDesigner : ControlDesigner
    {
        DesignerActionUIService actionUISvc;
        IComponentChangeService componentChnSvc;
        IDesignerHost designerHost;
        ISelectionService selectionSvc;

        string lastSelectedControlName = string.Empty;

        #region ActionLists
        DesignerActionListCollection actionListCollection = null;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionListCollection == null)
                {
                    actionListCollection = new DesignerActionListCollection();
                    actionListCollection.Add(new NavigateBarActionList(this.Component));
                }
                return actionListCollection;
            }
        }
        #endregion

        #region Initialize & Dispose

        /// <summary>
        /// component kontrol et ve servisleri yükle
        /// </summary>
        /// <param name="component"></param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            if (component == null)
                throw new NullReferenceException("Component cannot be null");

            if (!(component is NavigateBar))
                throw new System.ArgumentException("Component not NavigateBar or derived ", "component");

            this.actionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
            this.componentChnSvc = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            this.designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            this.selectionSvc = (ISelectionService)GetService(typeof(ISelectionService));

            // Eventlar
            this.componentChnSvc.ComponentRemoving += new ComponentEventHandler(componentChnSvc_ComponentRemoving);
            this.selectionSvc.SelectionChanged += new EventHandler(selectionSvc_SelectionChanged);
        }
   
        /// <summary>
        /// Eventları bırak
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            this.componentChnSvc.ComponentRemoving -= new ComponentEventHandler(componentChnSvc_ComponentRemoving);
            this.selectionSvc.SelectionChanged -= new EventHandler(selectionSvc_SelectionChanged);
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Seçili olan kontrolün ismini yedekle ve bu bilgiyi kontrol kaldırılırken kullan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void selectionSvc_SelectionChanged(object sender, EventArgs e)
        {

            lastSelectedControlName = string.Empty;

            if (this.selectionSvc.PrimarySelection is NavigateBar)
            {
                lastSelectedControlName = (this.selectionSvc.PrimarySelection as NavigateBar).Name;
                (this.Component as NavigateBar).PerformNavigationPane();
            }
            if (this.selectionSvc.PrimarySelection is NavigateBarButton)
            {
                lastSelectedControlName = (this.selectionSvc.PrimarySelection as NavigateBarButton).Name;
                (this.Component as NavigateBar).SetCaptionText((this.selectionSvc.PrimarySelection as NavigateBarButton));
            }

        }

        /// <summary>
        /// Eğer bir button yada panel kaldırıldıysa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void componentChnSvc_ComponentRemoving(object sender, ComponentEventArgs e)
        {

            try
            {
                if (e.Component is NavigateBarButton)
                {
                    // eğer bir button kaldırıldıysa

                    NavigateBarButton nvButton = e.Component as NavigateBarButton;

                    if (!nvButton.Name.Equals(lastSelectedControlName))
                        return;

                    NavigateBar navigationPane = (NavigateBar)this.Control;


                    if (navigationPane.NavigateBarButtons.Contains(nvButton))
                    {
                        this.componentChnSvc.OnComponentChanging(this.Component, null);
                        navigationPane.NavigateBarButtons.Remove(nvButton);

                        if (navigationPane.NavigateBarDisplayedButtonCount > 0)
                        {
                            navigationPane.NavigateBarDisplayedButtonCount--;
                            if (navigationPane.DisplayedButtonCount > navigationPane.NavigateBarDisplayedButtonCount)
                                navigationPane.DisplayedButtonCount = navigationPane.NavigateBarDisplayedButtonCount;
                        }

                        if (navigationPane.NavigateBarButtons.Count == 0)
                            navigationPane.SetCaptionText(null);

                        navigationPane.PerformNavigationPane();

                        this.componentChnSvc.OnComponentChanged(this.Component, null, null, null);
                        return;
                    }
                }
                else if (e.Component is NavigateBar)
                {
                    // eğer navigation pane kaldırıldıysa panele baglı buttonlarıda kaldır

                    NavigateBar navigationPane = (NavigateBar)this.Component;

                    if (!navigationPane.Name.Equals(lastSelectedControlName))
                        return;

                    for (int i = navigationPane.NavigateBarButtons.Count - 1; i >= 0; i--)
                    {
                        NavigateBarButton nvButton = navigationPane.NavigateBarButtons[i];
                        this.componentChnSvc.OnComponentChanging(this.Component, null);

                        navigationPane.NavigateBarButtons.Remove(nvButton);

                        if (navigationPane.NavigateBarButtons.Count == 0)
                            navigationPane.SetCaptionText(null);

                        navigationPane.PerformNavigationPane();

                        this.designerHost.DestroyComponent(nvButton);

                        this.componentChnSvc.OnComponentChanged(this.Component, null, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "ComponentRemoving");
            }
        }

        #endregion

    }
}

