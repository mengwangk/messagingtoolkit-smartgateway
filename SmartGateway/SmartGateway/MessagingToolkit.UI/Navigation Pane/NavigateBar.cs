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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;

using MessagingToolkit.UI.Design;

namespace MessagingToolkit.UI
{

    #region Enums

    /// <summary>
    /// Button's visible type
    /// </summary>
    enum VisibleType
    {
        All,
        Visible,
        Unvisible
    }

    /// <summary>
    /// Button's move type
    /// </summary>
    enum MoveType
    {
        /// <summary>
        /// Show next button in panel
        /// </summary>
        MoveUp,
        /// <summary>
        /// Hide first button in panel
        /// </summary>
        MoveDown
    }

    /// <summary>
    /// Paint style for control
    /// </summary>
    enum PaintType
    {
        /// <summary>
        /// Painting control normal color 
        /// </summary>
        Normal,
        /// <summary>
        /// Painting control selected color 
        /// </summary>
        Selected,
        /// <summary>
        /// Painting control mouse over color 
        /// </summary>
        MouseOver,
        /// <summary>
        /// Painting control pressed color 
        /// </summary>
        Pressed
    }

    /// <summary>
    /// Overflow panel context menu arrow style
    /// </summary>
    public enum ContextMenuArrowStyle
    {
        /// <summary>
        /// Draw Office 2003 style context menu arrow
        /// </summary>
        Office2003,
        /// <summary>
        /// Draw Office 2007 style context menu arrow
        /// </summary>
        Office2007
    }
    #endregion

    #region Class : NavigateBar

    /// <summary>
    /// Outlook 2003 Style Navigation Pane
    /// </summary>
    [Description("Outlook 2003 Style Navigation Pane")]
    [ToolboxBitmap(typeof(NavigateBar), "Resources.NavigateBar.bmp")]
    [Browsable(true)]
    [DefaultEvent("OnNavigateBarButtonSelected")]
    [DefaultProperty("NavigateBarDisplayedButtonCount")]
    [DesignerAttribute(typeof(NavigateBarDesigner))]
    public class NavigateBar : ContainerControl, IComponent
    {

        #region Const

        /// <summary>
        /// value = 22
        /// </summary>
        internal const int OVER_FLOW_BUTTON_WIDTH = 22;
        /// <summary>
        /// value = 32
        /// </summary>
        internal const int BUTTON_HEIGHT = 32;

        /// <summary>
        /// value = 20
        /// </summary>
        const int HIDE_STEP = 20;

        /// <summary>
        /// value = 90F
        /// </summary>
        internal const float BUTTON_PAINT_ANGLE = 90F;

        /// <summary>
        /// Navigatebar defalut width
        /// </summary>
        internal const int DEFAULT_WIDTH = 140;

        /// <summary>
        /// Collapse screen default width
        /// </summary>
        internal const int COLLAPSIBLE_SCREEN_WIDTH = 160;
        #endregion

        // Delegate & Events

        #region Delegate & Events

        public delegate void OnNavigateBarButtonHeightChangedEventHandler(int tOldHeight, int tNewHeight);
        /// <summary>
        /// Occurs when button height changes
        /// </summary>
        public event OnNavigateBarButtonHeightChangedEventHandler OnNavigateBarButtonHeightChanged;

        public delegate void OnNavigateBarButtonEventHandler(NavigateBarButton tNavigateBarButton);
        /// <summary>
        /// Occurs when a new button added
        /// </summary>
        public event OnNavigateBarButtonEventHandler OnNavigateBarButtonAdded;
        /// <summary>
        /// Occurs when a button removed
        /// </summary>
        public event OnNavigateBarButtonEventHandler OnNavigateBarButtonRemoved;
        /// <summary>
        /// Occurs when a button selected
        /// </summary>
        public event OnNavigateBarButtonEventHandler OnNavigateBarButtonSelected;

        public delegate void OnNavigateBarButtonSelectingEventHandler(NavigateBarButtonCancelEventArgs e);
        /// <summary>
        /// Occurs when a button selecting
        /// </summary>
        public event OnNavigateBarButtonSelectingEventHandler OnNavigateBarButtonSelecting;

        public delegate void OnNavigateBarDisplayedButtonCountChangedEventHandler();
        /// <summary>
        /// Occurs when displayed button count change
        /// </summary>
        public event OnNavigateBarDisplayedButtonCountChangedEventHandler OnNavigateBarDisplayedButtonCountChanged;

        public delegate void OnNavigateBarCollapseModeChangedEventHandler(bool tIsCollaped);

        /// <summary>
        /// Occurs when change collapse mode (true collapsed)
        /// </summary>
        public event OnNavigateBarCollapseModeChangedEventHandler OnNavigateBarCollapseModeChanged;

        /// <summary>
        /// Occurs when change collapse mode (true collapsed)
        /// </summary>
        public event EventHandler OnNavigateBarColorChanged;


        #endregion

        // Properties

        #region NavigateBarButtons
        NavigateBarButtonCollection navigateBarButtons;

        /// <summary>
        /// NavigateBarButton Collection
        /// <para>Get</para>
        /// </summary>
        //[Browsable(false)]
        [Category("NavigationPane")]
        [Description("NavigateBarButton collection for NavigateBar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [Browsable(false)]
        // TODO :  ERROR : "An item with the same key has already been added" error message from collection editor
        public NavigateBarButtonCollection NavigateBarButtons
        {
            get { return navigateBarButtons; }
        }

        #endregion

        #region NavigateBarColorTable
        NavigateBarColorTable colorTable = null;
        /// <summary>
        /// Color table for navigation pane and subcontrols
        /// <para>Get / Set</para>
        /// </summary>
        //[Browsable(false)]
        [Category("NavigationPane")]
        [Description("Color table for navigation pane and subcontrols")]
        [DefaultValue(typeof(NavigateBarColorTable), "SystemColor")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public NavigateBarColorTable NavigateBarColorTable
        {
            get
            {
                if (colorTable == null)
                    colorTable = new NavigateBarColorTable();

                return colorTable;
            }
            set
            {

                if (value == null)
                    value = NavigateBarColorTable.SystemColor;

                if (this.AlwaysUseSystemColors)
                    value = NavigateBarColorTable.SystemColor;

                colorTable = (NavigateBarColorTable)value;

                renderer = new NavigateBarRenderer(colorTable);

                this.Invalidate();

                if (OnNavigateBarColorChanged != null)
                    OnNavigateBarColorChanged(this, EventArgs.Empty);
            }
        }
        #endregion

        #region NavigateBarButtonHeight

        private int navigateBarButtonHeight = NavigateBar.BUTTON_HEIGHT;
        /// <summary>
        /// NavigateBarButton height
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Buttons height")]
        [DefaultValue(BUTTON_HEIGHT)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int NavigateBarButtonHeight
        {
            get { return navigateBarButtonHeight; }
            set
            {
                int oldHeight = navigateBarButtonHeight;

                if (value < NavigateBarButton.MinimumButtonHeight)
                    value = NavigateBarButton.DefaultButtonHeight;
                navigateBarButtonHeight = value;

                foreach (NavigateBarButton nvb in navigateBarButtons)
                    nvb.Height = navigateBarButtonHeight;

                this.ChangeSplitterPosition();
                this.ReSizeControlPanel();

                if (OnNavigateBarButtonHeightChanged != null)
                    OnNavigateBarButtonHeightChanged(oldHeight, navigateBarButtonHeight);
            }
        }

        #endregion

        #region NavigateBarDisplayedButtonCount

        private int displayedNavigateBarButtonCount = -1;
        /// <summary>
        /// How many buttons displayed in NavigateBar ?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("How many buttons displayed in NavigateBar ?")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int NavigateBarDisplayedButtonCount
        {
            get
            {
                if (displayedNavigateBarButtonCount >= 0)
                    return displayedNavigateBarButtonCount;
                else
                    return navigateBarButtons.Count;
                //return   GetVisibleButtonCount(VisibleType.Visible);
            }
            set
            {
                if (this.CheckIndex(value))
                {
                    displayedNavigateBarButtonCount = value;
                    this.ReDisplay(displayedNavigateBarButtonCount);
                }
            }
        }

        #endregion

        #region SelectedButton
        private NavigateBarButton selectedButton = null;
        /// <summary>
        /// Selected NavigateBarButton
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Selected NavigateBarButton")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public NavigateBarButton SelectedButton
        {
            get { return selectedButton; }
            set
            {
                if (value != null && value.IsDisplayed && value.Enabled)
                    NavigateBarButton_Selected(new NavigateBarButtonEventArgs(value));
            }
        }
        #endregion

        #region SaveAndRestoreSettings
        bool saveAndRestoreSettings = false;
        /// <summary>
        /// If set TRUE then save and restore last settings.
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Is setting save or restore ?")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool SaveAndRestoreSettings
        {
            get { return saveAndRestoreSettings; }
            set { saveAndRestoreSettings = value; }
        }
        #endregion

        #region IsCollapsible
        bool isCollapsible = true;
        /// <summary>
        /// Is collapsible panel ?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Is collapsible panel ?")]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsCollapsible
        {
            get { return isCollapsible; }
            set
            {
                isCollapsible = value;
                navigateBarCaption.CollapseButton.Visible = isShowCollapseButton && isCollapsible;
                collapsibleText.CaptionBand.CollapseButton.Visible = isShowCollapseButton && isCollapsible;

                if (!isCollapsible)
                    this.Width = oldWidth;
            }
        }
        #endregion

        #region IsCollapsedMode
        bool isCollapsedMode = false;
        /// <summary>
        /// Is display collapsed mode
        /// <para>Get</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Is display collapsed mode?")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsCollapsedMode
        {
            get { return isCollapsedMode; }
        }
        #endregion

        #region IsShowCollapseButton
        bool isShowCollapseButton = true;
        /// <summary>
        /// Is display collapsible button on caption band ?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Is display collapse button on caption band ?")]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsShowCollapseButton
        {
            get { return isShowCollapseButton; }
            set
            {
                isShowCollapseButton = value;
                navigateBarCaption.CollapseButton.Visible = isShowCollapseButton && isCollapsible;
                collapsibleText.CaptionBand.CollapseButton.Visible = isShowCollapseButton && isCollapsible;
            }
        }
        #endregion

        #region IsShowCollapsibleScreen
        bool isShowCollapsibleScreen = false;
        /// <summary>
        /// Is display collapsible screen ?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Is display collapsible screen ?")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsShowCollapsibleScreen
        {
            get { return isShowCollapsibleScreen; }
            set { isShowCollapsibleScreen = value; }
        }
        #endregion

        #region IsCollapsibleScreenShowNow
        bool isCollapsibleScreenShowNow = false;
        /// <summary>
        /// Is show collapsible screen ?
        /// <para>Get</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Is show collapsible screen ?")]
        [DefaultValue(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsCollapsibleScreenShowNow
        {
            get { return isCollapsibleScreenShowNow; }
        }
        #endregion

        #region IsCollapseScreenShowOnButtonSelect
        bool isShowOnButtonSelect = false;
        /// <summary>
        /// Is show collapsible screen on button select ?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Is show collapsible screen on button select ?")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsCollapseScreenShowOnButtonSelect
        {
            get { return isShowOnButtonSelect; }
            set { isShowOnButtonSelect = value; }
        }
        #endregion

        #region IsUseRTLforButtons
        bool isUseRTLforButtons = true;
        /// <summary>
        /// Use RightToLeft for button's
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Use RightToLeft for button's")]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsUseRTLforButtons
        {
            get { return isUseRTLforButtons; }
            set
            {
                isUseRTLforButtons = value;

                if (this.RightToLeft == RightToLeft.Yes)
                    this.Invalidate(true);
            }
        }
        #endregion

        #region IsUseRTLforMenus
        bool isUseRTLforMenus = true;
        /// <summary>
        /// Use RightToLeft for context menu's
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Use RightToLeft for context menu's")]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsUseRTLforMenus
        {
            get { return isUseRTLforMenus; }
            set
            {
                isUseRTLforMenus = value;

                if (this.RightToLeft == RightToLeft.Yes)
                    this.Invalidate(true);
            }
        }
        #endregion

        #region CollapsibleWidth
        int collapsibleWidth = 0;
        /// <summary>
        /// Required minimum width for collapsible feature
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Collapsible width")]
        [DefaultValue(35)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CollapsibleWidth
        {
            get
            {
                if (collapsibleWidth < MinimumSize.Width + 5)
                    collapsibleWidth = MinimumSize.Width + 5;
                return collapsibleWidth;
            }
            set
            {
                collapsibleWidth = value;
                this.MinimumSize = new Size(collapsibleWidth, 100);
            }
        }
        #endregion

        #region CollapsibleScreenWidth
        int collapsibleScreenWidth = COLLAPSIBLE_SCREEN_WIDTH;
        /// <summary>
        /// Collapsible screen width
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Collapsible screen width")]
        [DefaultValue(COLLAPSIBLE_SCREEN_WIDTH)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CollapsedScreenWidth
        {
            get { return collapsibleScreenWidth; }
            set
            {
                collapsibleScreenWidth = value;
                collapsibleScreen.Width = collapsibleScreenWidth;
                collapsibleScreen.Invalidate();
            }
        }
        #endregion

        #region OverFlowPanelHeight

        int overFlowPanelHeight = BUTTON_HEIGHT;

        /// <summary>
        /// OverFlowPanel height
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("OverFlowPanel height")]
        [DefaultValue(BUTTON_HEIGHT)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int OverFlowPanelHeight
        {
            get { return overFlowPanelHeight; }
            set
            {
                if (value < 20)
                    value = BUTTON_HEIGHT;

                this.overFlowPanelHeight = value;

                // Set new height
                this.overFlowPanel.Height = overFlowPanelHeight;

                foreach (NavigateBarButton nvb in NavigateBarButtons)
                    nvb.OverFlowPanelButton.Height = overFlowPanelHeight - 2;

                this.overFlowPanel.Invalidate();
                this.relatedControlContainer.Invalidate();
                this.ChangeSplitterPosition();
                this.ReSizeControlPanel();
            }
        }

        #endregion

        #region DisplayedButtonCount
        /// <summary>
        /// Displayed button count in panel
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Displayed button count in panel")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int DisplayedButtonCount
        {
            get { return displayedButtonCount; }
            set { ReDisplay(value); }
        }
        #endregion

        #region Common RelatedControl
        private Control relatedControl = null;
        /// <summary>
        /// If Button.RelatedControl is empty then display this control
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("If Button.RelatedControl is empty then display this control")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Control RelatedControl
        {
            get { return relatedControl; }
            set { relatedControl = value; }
        }
        #endregion

        #region AlwaysUseSystemColors
        bool alwaysUseSystemColors = false;
        /// <summary>
        /// Use system color, do not use NavigateBarColorTable
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigationPane")]
        [Description("Use system color, do not use NavigateBarColorTable")]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AlwaysUseSystemColors
        {
            get { return alwaysUseSystemColors; }
            set
            {
                alwaysUseSystemColors = value;
                if (alwaysUseSystemColors)
                    this.NavigateBarColorTable = NavigateBarColorTable.SystemColor;
            }
        }
        #endregion

        // Internal Properties

        #region OverFlowItemCount
        int overFlowItemCount = 0;
        /// <summary>
        /// Button count on OverFlowPanel + ContextMenu
        /// </summary>
        internal int OverFlowItemCount
        {
            get { return overFlowItemCount; }
        }
        #endregion

        #region ContextMenuRenderer
        /// <summary>
        /// Toolstriprenderer for context menus
        /// </summary>
        internal NavigateBarRenderer ContextMenuRenderer
        {
            get { return renderer; }
        }
        #endregion

        // Overrided Properties

        #region DefaultSize
        protected override Size DefaultSize
        {
            get
            {
                return new Size(COLLAPSIBLE_SCREEN_WIDTH, 350);
            }
        }
        #endregion

        // Control
        NavigateBarCaption navigateBarCaption;
        NavigateBarCaptionDescription navigateBarCaptionDesc;
        NavigateBarControlPanel relatedControlContainer;
        NavigateBarControlPanel relatedControlEmpty;
        NavigateBarOverFlowPanel overFlowPanel;
        NavigateBarSplitter splitter;

        // Collapse
        NavigateBarCollapsibleScreen collapsibleScreen;
        NavigateBarCollapsibleScreenMessageFilter collapsibleScreenMessageFilter;
        NavigateBarCollapsibleText collapsibleText;

        // Other
        NavigateBarSettings settings;
        NavigateBarRenderer renderer;

        // Containers
        Panel captionPanel;

        //Var

        int displayedButtonCount = 0;
        int lastDisplayedButtonCount = 0;
        int oldWidth = 0, oldLeft;

        // Orjinal button order <KEY, OrderNO>;
        internal Dictionary<string, int> buttonOrder = new Dictionary<string, int>();

        #region /   Constructors   /
        public NavigateBar()
        {

            InitOutlookStyleNavigateBar();

            // Read from setting in XML file

            System.IO.FileInfo finfo = new System.IO.FileInfo(Application.ExecutablePath);
            settings.SettingsFileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + finfo.Name + @"\NavigateBarSettings.xml";

        }

        public NavigateBar(string tSettingsFileName)
        {
            InitOutlookStyleNavigateBar();

            // Read from setting in custom settings file
            this.SaveAndRestoreSettings = true;
            settings.SettingsFileName = tSettingsFileName;

        }

        void InitOutlookStyleNavigateBar()
        {

            oldWidth = DEFAULT_WIDTH;

            // Collection

            navigateBarButtons = new NavigateBarButtonCollection(this);
            navigateBarButtons.OnButtonAdded += new NavigateBarButtonCollection.OnButtonEventHandler(NavigateBarButtonCollection_OnButtonAdded);
            navigateBarButtons.OnButtonRemoved += new NavigateBarButtonCollection.OnButtonEventHandler(NavigateBarButtonCollection_OnButtonRemoved);

            // Control
            this.BackColor = SystemColors.ControlLightLight;
            this.MinimumSize = new Size(NavigateBar.OVER_FLOW_BUTTON_WIDTH, 100);
            this.Disposed += new EventHandler(NavigateBar_Disposed);

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.UpdateStyles();

            #region OverFlowPanel
            overFlowPanel = new NavigateBarOverFlowPanel(this);
            overFlowPanel.Dock = DockStyle.Bottom;
            overFlowPanel.Height = this.OverFlowPanelHeight;
            overFlowPanel.NavigateBar = this;
            #endregion

            #region CollapsibleText
            // If show collaplible screen display button caption on this control
            collapsibleText = new NavigateBarCollapsibleText(this);
            collapsibleText.Invalidate();
            collapsibleText.MouseClick += delegate(object sender, MouseEventArgs e)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (collapsibleScreen.IsShowWindow)
                            this.HideCollapseScreen();
                        else
                            this.ShowOverScreen();
                    }
                };

            #endregion

            #region Collapsibile Screen
            collapsibleScreen = new NavigateBarCollapsibleScreen(this);
            collapsibleScreen.Visible = false;
            collapsibleScreen.ControlBox = false;
            collapsibleScreen.FormBorderStyle = FormBorderStyle.None;
            collapsibleScreen.Width = COLLAPSIBLE_SCREEN_WIDTH;
            collapsibleScreen.ShowInTaskbar = false;
            collapsibleScreen.Activated += new EventHandler(collapsibleScreen_Activated);
            collapsibleScreen.Deactivate += new EventHandler(collapsibleScreen_Deactivate);
            collapsibleScreen.IsShowWindow = false;

            // MessageFilter
            collapsibleScreenMessageFilter = new NavigateBarCollapsibleScreenMessageFilter();
            collapsibleScreenMessageFilter.OnNonCollapsibleScreenAreaFocused += new EventHandler(CollapsibleScreenMessageFilter_OnNonCollapsibleScreenAreaFocused);

            #endregion

            #region Caption

            navigateBarCaption = new NavigateBarCaption(this);
            navigateBarCaption.Dock = DockStyle.Top;
            navigateBarCaption.CollapseButton.ToolTipText = Properties.Resources.TEXT_COLLAPSE_BUTTON_COLLAPSE;
            navigateBarCaption.VisibleChanged += new EventHandler(NavigateBarCaption_VisibleChanged);

            navigateBarCaptionDesc = new NavigateBarCaptionDescription();
            navigateBarCaptionDesc.NavigateBar = this;
            navigateBarCaptionDesc.Dock = DockStyle.Top;
            navigateBarCaptionDesc.VisibleChanged += new EventHandler(NavigateBarCaption_VisibleChanged);

            captionPanel = new Panel();
            captionPanel.Height = navigateBarCaption.Height + navigateBarCaptionDesc.Height;
            captionPanel.Dock = DockStyle.Top;
            captionPanel.Controls.Add(navigateBarCaptionDesc);
            captionPanel.Controls.Add(navigateBarCaption);

            #endregion

            #region Splitter
            splitter = new NavigateBarSplitter(this);
            splitter.Height = 8;
            splitter.Width = this.Width;
            splitter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            splitter.MouseDown += new MouseEventHandler(Splitter_MouseDown);
            splitter.MouseMove += new MouseEventHandler(Splitter_MouseMove);
            splitter.MouseUp += new MouseEventHandler(Splitter_MouseUp);
            #endregion

            // Display for related control
            relatedControlContainer = new NavigateBarControlPanel();
            relatedControlContainer.NavigateBar = this;

            relatedControlEmpty = new NavigateBarControlPanel();
            relatedControlEmpty.NavigateBar = this;
            relatedControlEmpty.Dock = DockStyle.Fill;

            // Renderer

            renderer = new NavigateBarRenderer(this.NavigateBarColorTable);

            // Settings class

            settings = new NavigateBarSettings(this);

            // Add controls in NavigateBar

            Controls.Add(captionPanel);
            Controls.Add(relatedControlContainer);
            Controls.Add(splitter);
            Controls.Add(overFlowPanel);

            // Add Message Filter

            Application.AddMessageFilter(collapsibleScreenMessageFilter);

        }

        #endregion

        #region  /   RestoreSettings   /
        void RestoreSettings()
        {
            // if loaded setting, displayed button count is last count else max displayed button count

            // Eğer ayarlar yüklenebilirse gösterilecek olan buttoun sayısı kayıt edilen sayıdır
            // değilse en fazla gösterilecek olan button sayısını kullan
            if (this.SaveAndRestoreSettings && !settings.IsLoad)
            {
                MessageBox.Show(settings.ErrorMessage);
                return;
            }

            this.SuspendLayout();

            // Panel's properties

            this.NavigateBarButtonHeight = settings.ButtonHeight; // load buttons height
            this.displayedButtonCount = settings.DisplayedButtonCount < 0 ? GetVisibleButtonCount(VisibleType.Visible) : settings.DisplayedButtonCount; // load last displayed button count
            this.NavigateBarColorTable = this.AlwaysUseSystemColors ? NavigateBarHelper.GetColorTableForWindowsTheme() : settings.ColorTable;

            // Width (and collapsed mode)

            this.IsCollapsible = settings.IsCollapsible;
            this.IsShowCollapseButton = settings.IsShowCollapseButton;
            this.oldWidth = this.Width;
            this.Width = settings.PaneWidth;

            // Re-Order buttons (In collection)
            // Buttonları yeniden sıraya yerleştir (Kolleksiyon içerisinde sıralanıyor)

            NavigateBarButton selBtn = this.SelectedButton; // Seçili button yedekle // backup selected button

            foreach (KeyValuePair<string, NavigateBarSettings.ButtonRestoreSettings> kvp in settings.ButtonRestoreInfo)
            {

                NavigateBarButton nvb = this.NavigateBarButtons.FindByKey(kvp.Key);

                if (nvb == null) continue;

                nvb.Visible = kvp.Value.Visible;
                nvb.Enabled = kvp.Value.Enabled;
                nvb.IsDisplayed = kvp.Value.Display;
                nvb.IsSelected = kvp.Value.Selected;

                this.ChangeButtonPosition(nvb, kvp.Value.Order);

                if (kvp.Value.Selected) // seçili // If selected on exit then select
                    selBtn = nvb;

            }

            this.SelectedButton = selBtn; // Sıralama sonrasında tekrar seç // set backuped selected button

            this.ResumeLayout(true);

            // Set old height for overflowpanel
            this.OverFlowPanelHeight = settings.OverFlowPanelHeight;

            this.ReDisplay(settings.DisplayedButtonCount);
            this.ReFreshOverFlowPanel(false);

        }
        #endregion

        #region /   NavigateBar Events & Overrided Methods  /

        /// <summary>
        /// if changed system color then apply new color on theme
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSystemColorsChanged(EventArgs e)
        {
            this.NavigateBarColorTable = NavigateBarColorTable.SystemColor;
            base.OnSystemColorsChanged(e);
        }

        /// <summary>
        /// If change righttoleft state, set new postion for overflowpanel items
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            this.SuspendLayout();
            base.OnRightToLeftChanged(e);

            this.ReDisplay(this.DisplayedButtonCount);

            if (this.SelectedButton != null)
                this.SelectedButton.PerformClick();

            overFlowPanel.Height = this.OverFlowPanelHeight;
            overFlowPanel.Invalidate();
            this.ResumeLayout(true);
        }

        /// <summary>
        /// Restore settings from xml file
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e)
        {

            oldLeft = this.Left;

            if (oldWidth <= this.CollapsibleWidth)
                oldWidth = DEFAULT_WIDTH;

            // Kullanıcı button için atama yapmadıysa

            foreach (NavigateBarButton nvb in this.NavigateBarButtons)
            {
                if (nvb.NavigateBar == null)
                    nvb.NavigateBar = this;
            }

            // if loaded setting, displayed button count is last count else max displayed button count

            // Eğer ayarlar yüklenebilirse gösterilecek olan buttoun sayısı kayıt edilen sayıdır
            // değilse en fazla gösterilecek olan button sayısını kullan
            if (saveAndRestoreSettings && settings.IsLoad)
            {
                this.RestoreSettings();
            }
            else
            {
                displayedButtonCount = this.NavigateBarDisplayedButtonCount;
                this.ReDisplay(displayedButtonCount);
            }

            // Buttonlar eklendikten sonra ContextMenuyü oluştur

            this.ReFreshOverFlowPanel(false);
            this.ChangeSplitterPosition();

            // Tüm nesneleri değişen(diğiştiyse) renk tablosunu yansıt
            this.Invalidate(true);

            // Geçerli ilk kontrole git

            if (this.SelectedButton != null)
            {
                this.SetCaptionText(this.SelectedButton);
                this.SelectedButton.Focus();
            }
            else if (NavigateBarButtons.Count > 0)
                this.NavigateBarButtons[0].Focus();
            else
                relatedControlContainer.Focus();

            // 

            if (this.IsCollapsedMode)
            {
                navigateBarCaption.Visible = !isCollapsedMode;
                navigateBarCaptionDesc.Visible = !isCollapsedMode;
            }
            else
            {
                if (this.SelectedButton != null)
                    this.SetCaptionText(this.SelectedButton);
                else
                {
                    navigateBarCaption.Visible = true;
                    navigateBarCaptionDesc.Visible = true;
                }
            }
            //

            if (this.AlwaysUseSystemColors)
                this.NavigateBarColorTable = NavigateBarHelper.GetColorTableForWindowsTheme();

            // 

            base.OnHandleCreated(e);

        }

        /// <summary>
        /// Invalidate subcontrol
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);

            foreach (NavigateBarButton tButton in NavigateBarButtons)
                tButton.Invalidate();

            splitter.Invalidate();
            navigateBarCaption.Invalidate();
            navigateBarCaptionDesc.Invalidate();
            collapsibleText.Invalidate();
            collapsibleScreen.Invalidate();
            relatedControlContainer.Invalidate();
            relatedControlEmpty.Invalidate();
            overFlowPanel.Invalidate();
        }

        /// <summary>
        /// Save settings on exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NavigateBar_Disposed(object sender, EventArgs e)
        {

            Application.RemoveMessageFilter(collapsibleScreenMessageFilter);

            if (this.SaveAndRestoreSettings)
                settings.SaveSettingsToXmlFile();
        }

        /// <summary>
        /// if resizing navigatebar resize sub-controls
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            try
            {

                // Check width and if required show collapsed mode

                isCollapsedMode = (Width <= CollapsibleWidth) && isCollapsible;

                if (isCollapsedMode && relatedControlContainer != null)
                    relatedControlContainer.Controls.Clear();

                if (SelectedButton != null)
                    SetControlForNavigateBarButton(SelectedButton.RelatedControl);

                // Check height and if required show less button in panel

                if ((this.Height - displayedButtonCount * this.NavigateBarButtonHeight - this.OverFlowPanelHeight - captionPanel.Height - this.NavigateBarButtonHeight) < 0)
                {
                    this.MoveButtons(MoveType.MoveDown);
                    this.ChangeSplitterPosition();
                }

                //

                splitter.Width = this.Width;

                //

                this.ReSizeControlPanel();
                this.ChangeSplitterPosition();

                if (navigateBarCaption != null)
                    navigateBarCaption.Invalidate();

            }
            catch { }

        }

        /// <summary>
        /// Paint out rectangle
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(colorTable.BorderColor), new Rectangle(0, 1, Width - 1, Height - 1));
        }
        #endregion

        #region /   Collapse Screen Events & Methods   /
        void ShowOverScreen()
        {
            if (!this.IsShowCollapsibleScreen ||
                !this.IsCollapsedMode ||
                collapsibleScreen.IsShowWindow ||
                !this.IsCollapsible ||
                this.SelectedButton == null ||
                this.SelectedButton.RelatedControl == null)
                return;

            isCollapsibleScreenShowNow = true;
            collapsibleText.IsSelected = true;

            Point p;
            //if (this.RightToLeft == RightToLeft.Yes)
            //{
            //    // RTL durumunda pozisyonu activate durumunda alıyor
            //    // Burası çalışmıyor
            //    p = this.PointToScreen(new Point(relatedControlContainer.Location.X - this.collapsibleScreenWidth, relatedControlContainer.Location.Y + collapsibleScreen.CaptionBand.Height));
            //}
            //else

            p = new Point(relatedControlContainer.Location.X + Width - 3, relatedControlContainer.Location.Y + collapsibleText.CaptionBand.Height - 1);

            collapsibleScreen.DesktopLocation = relatedControlContainer.PointToScreen(p);
            collapsibleScreen.Height = relatedControlContainer.Height - collapsibleText.CaptionBand.Height + 2;

            // Caption
            collapsibleScreen.CaptionBand.Caption = this.SelectedButton.Caption;

            // Caption Band
            if (this.SelectedButton != null)
                collapsibleScreen.CaptionBand.Visible = this.SelectedButton.IsShowCollapseScreenCaption;
            else
                collapsibleScreen.CaptionBand.Visible = true;

            collapsibleScreen.Width = 0; // this.SelectedButton.CollapsedScreenWidth;

            collapsibleScreen.SetControl(this.SelectedButton.RelatedControl);
            collapsibleScreen.IsShowWindow = true;
            collapsibleScreen.Focus();
            collapsibleScreen.Show();

        }

        /// <summary>
        /// If focused non collapsible screen area then hide collapse screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CollapsibleScreenMessageFilter_OnNonCollapsibleScreenAreaFocused(object sender, EventArgs e)
        {
            if (collapsibleScreen != null &&
                !collapsibleScreen.Bounds.Contains(Cursor.Position))
            {
                this.HideCollapseScreen();
            }
        }

        /// <summary>
        /// Collapse screen activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void collapsibleScreen_Activated(object sender, EventArgs e)
        {

            if (collapsibleScreen.IsShowWindow)
            {

                int width = COLLAPSIBLE_SCREEN_WIDTH;

                //Width
                if (SelectedButton != null && SelectedButton.CollapsedScreenWidth != COLLAPSIBLE_SCREEN_WIDTH)
                    width = this.SelectedButton.CollapsedScreenWidth;

                //

                int tmpWidth = width;
                if ((width % HIDE_STEP) != 0)
                {
                    int adet = (int)(width / HIDE_STEP);
                    tmpWidth = adet * HIDE_STEP;
                }

                collapsibleScreen.SuspendLayout();

                if (this.RightToLeft != RightToLeft.Yes)
                {
                    for (int i = 0; i <= tmpWidth; i += HIDE_STEP)
                    {
                        System.Threading.Thread.Sleep(3);
                        collapsibleScreen.Width = i;
                    }
                }

                //Set real width
                collapsibleScreen.Width = width;

                // Position on desktop
                if (RightToLeft == RightToLeft.Yes)
                    collapsibleScreen.DesktopLocation = this.PointToScreen(new Point(relatedControlContainer.Location.X - width, relatedControlContainer.Location.Y + collapsibleScreen.CaptionBand.Height + 3));

                collapsibleScreen.ResumeLayout();

            }

            System.Diagnostics.Debug.WriteLine("ACTIVATE");
        }


        void collapsibleScreen_Deactivate(object sender, EventArgs e)
        {
            collapsibleText.IsSelected = false;
        }

        /// <summary>
        /// If collapsed mode then show collapse screen
        /// </summary>
        public void ShowCollapseScreen()
        {
            this.ShowOverScreen();
        }

        /// <summary>
        /// If collapsed mode then hide collapse screen
        /// </summary>
        public void HideCollapseScreen()
        {
            isCollapsibleScreenShowNow = false;
            collapsibleText.IsSelected = false;
            collapsibleScreen.IsShowWindow = false;
            collapsibleScreen.Hide();
        }

        #endregion

        #region /   Splitter Events   /

        bool isSplitterMoved = false;

        void Splitter_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            isSplitterMoved = false;

        }

        void Splitter_MouseMove(object sender, MouseEventArgs e)
        {

            if (!isSplitterMoved || e.Button != MouseButtons.Left)
                return;

            try
            {
                int pos = (this.Height - (this.NavigateBarButtonHeight * this.GetVisibleButtonCount(VisibleType.All) + this.OverFlowPanelHeight));

                // Kaç adet button gösterilebilir

                int displayableCount = GetDisplayableCount();

                //

                this.ChangeSplitterPosition();

                if (displayableCount != lastDisplayedButtonCount)
                {
                    lastDisplayedButtonCount = displayableCount;
                    this.ReDisplay(displayableCount);
                    this.ChangeSplitterPosition();
                }

            }
            catch { }

        }

        void Splitter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            isSplitterMoved = true;
            splitter.Cursor = Cursors.SizeNS;
        }

        /// <summary>
        /// Farenin pozisyonuna göre kaç adet button gösterilebilir hesapla
        /// </summary>
        /// <returns></returns>
        int GetDisplayableCount()
        {
            //int displayableCount = (int)Math.Round((float)(navigateBarSplitter.SplitPosition / navigateBarButtonHeight), 2);
            int displayableCount = ((this.Height - this.PointToClient(Control.MousePosition).Y) / this.NavigateBarButtonHeight);

            //  Olmaz ama yinede kontrol et
            displayableCount = displayableCount <= 0 ? 0 : displayableCount;
            // Kolleksiyondan büyük olamaz // Cannot bigger collection button count
            displayableCount = displayableCount > this.NavigateBarButtons.Count ? this.GetVisibleButtonCount(VisibleType.Visible) : displayableCount;
            // İstenen adet sayısıdan fazla olamaz // Cannot bigger max displayed button count
            displayableCount = displayableCount > this.NavigateBarDisplayedButtonCount ? this.NavigateBarDisplayedButtonCount : displayableCount;

            return displayableCount;
        }

        #endregion

        #region /   NavigateBarCaption_VisibleChanged   /

        void NavigateBarCaption_VisibleChanged(object sender, EventArgs e)
        {

            bool showCaption = navigateBarCaption.Visible;
            bool showCaptionDesc = navigateBarCaptionDesc.Visible;

            captionPanel.Height = navigateBarCaption.Height + navigateBarCaptionDesc.Height;

            // Display only caption
            // Sadece Caption göster
            if (showCaption && !showCaptionDesc)
                captionPanel.Height = navigateBarCaption.Height;

            // Display only captiondescription
            // Sadece CaptionDesription göster
            if (!showCaption && showCaptionDesc)
                captionPanel.Height = navigateBarCaptionDesc.Height;

            // Hide caption and caption description
            // Her ikisinide gizle
            if (!showCaption && !showCaptionDesc)
                captionPanel.Height = 0;

            this.ReSizeControlPanel();
        }

        #endregion

        #region /   NavigateBarButtonCollection_OnButtonAdded   /
        /// <summary>
        /// Add new NavigateBarButton in collection
        /// </summary>
        /// <param name="e"></param>
        void NavigateBarButtonCollection_OnButtonAdded(NavigateBarButtonEventArgs e)
        {

            NavigateBarButton nbButton = e.NavigateBarButton;

            if (nbButton == null)
                return;

            // NavigateBarButtona özelliklerini belirt
            // Set NavigateBarButton properties

            nbButton.NavigateBar = this;
            nbButton.Height = this.NavigateBarButtonHeight;
            nbButton.OverFlowPanelButton.Height = this.OverFlowPanelHeight - 2;
            nbButton.Visible = true;
            nbButton.Dock = DockStyle.Bottom;

            // NavigateBarButtonu ekle
            // Add navigatebar button

            this.Controls.Add(nbButton);

            // Eğer gözükmesini istenen sayıdan dazla ise eklenen
            // NavigateBarButtonları görünmez yaparak OverFlowPanele gönder

            // if collection count bigger max displayed count then show on overflowpanel

            if (this.NavigateBarButtons.Count > this.NavigateBarDisplayedButtonCount)
                nbButton.Visible = false;

            // Orjinal Order

            string strKey = string.IsNullOrEmpty(nbButton.Key) ? nbButton.Caption : nbButton.Key;
            if (string.IsNullOrEmpty(strKey)) // if empty key create a new key from guid
                strKey = NavigateBarHelper.CreateUniqKey();

            buttonOrder.Add(strKey, this.NavigateBarButtons.Count);

            // Display Panel

            this.ReDisplayNavigateBarButtons();

            
            // if added first navigatebar button select first button

            if (this.NavigateBarButtons.Count == 1)
            {
                nbButton.IsSelected = true;
                NavigateBarButton_Selected(new NavigateBarButtonEventArgs(nbButton));
            }

            // Overflow panel daima en altta olmalı
            if (this.Controls.Contains(overFlowPanel))
                this.Controls.SetChildIndex(overFlowPanel, this.Controls.Count);

            // set new displayed button count

            displayedButtonCount = this.GetVisibleButtonCount(VisibleType.Visible);

            // NavigateBarButton olayları / events

            nbButton.OnNavigateBarButtonSelected += new NavigateBarButton.OnNavigateBarButtonSelectedEventHandler(NavigateBarButton_Selected);
            nbButton.OnNavigateBarButtonDisplayChanged += new NavigateBarButton.OnNavigateBarButtonDisplayChangedEventHandler(NavigateBarButton_DisplayChanged);

            // trigger Event
            if (OnNavigateBarButtonAdded != null)
                OnNavigateBarButtonAdded(nbButton);

        }

        #endregion

        #region /   NavigateBarButtonCollection_OnButtonRemoved   /
        /// <summary>
        /// Remove NavigateBarButton from collection
        /// </summary>
        /// <param name="e"></param>
        void NavigateBarButtonCollection_OnButtonRemoved(NavigateBarButtonEventArgs e)
        {
            try
            {

                // Remove from orjinal order
                string key = string.IsNullOrEmpty(e.NavigateBarButton.Key) ?
                    e.NavigateBarButton.Caption : e.NavigateBarButton.Key;

                if (buttonOrder.ContainsKey(key))
                    buttonOrder.Remove(key);

                // Collection

                if (this.NavigateBarButtons.Count >= 0)
                {

                    // set new displayed button count

                    displayedButtonCount = this.GetVisibleButtonCount(VisibleType.Visible);

             
                    // Select next button if possible

                    if (this.NavigateBarButtons.Count >= 0)
                        this.SelectedButton = this.NavigateBarButtons[0];
                    else
                        this.SelectedButton = null;

                    this.ReDisplay(displayedButtonCount);

                    // trigger event

                    if (OnNavigateBarButtonRemoved != null)
                        OnNavigateBarButtonRemoved(e.NavigateBarButton);
                }
            }
            catch { }

        }
        #endregion

        #region /   NavigateBarButton_Selected   /

        void NavigateBarButton_Selected(NavigateBarButtonEventArgs e)
        {

            // Zaten seçili ise 
            // If already selected return

            if (this.SelectedButton != null &&
                this.SelectedButton.Equals(e.NavigateBarButton))
                return;

            // Cancel Selected Button
            NavigateBarButton previousSelected = this.SelectedButton;

            NavigateBarButtonCancelEventArgs cancelArgs = new NavigateBarButtonCancelEventArgs(e.NavigateBarButton, previousSelected);

            if (this.OnNavigateBarButtonSelecting != null) // Run Selecting Event
                this.OnNavigateBarButtonSelecting(cancelArgs);

            if (cancelArgs.Cancel) // Check Cancel state
            {
                e.NavigateBarButton.IsSelected = false;
                this.SelectedButton = previousSelected;
                previousSelected = null;
                return;
            }

            // Control içerisindeki tüm butonların IsSelected ayarla
            // set IsSelected state for all buttons in collection

            foreach (NavigateBarButton nvb in this.NavigateBarButtons)
                nvb.IsSelected = nvb.Equals(e.NavigateBarButton);

            // Seçili NavigateBarButtonun özelliklerini aktar
            // Set new caption and image info for selected button

            this.SetCaptionText(e.NavigateBarButton);

            // Select Button

            selectedButton = e.NavigateBarButton;

            // Seçilen NavigateBarButton için Controlü göster
            // display releated control for selected button

            this.SetControlForNavigateBarButton(e.NavigateBarButton.RelatedControl);

            // If set true IsShowOnButtonSelect and not displayed screen then show collapse screen
            if (this.IsCollapseScreenShowOnButtonSelect && !collapsibleScreen.IsShowWindow)
                ShowOverScreen();

            // Trigger Event

            if (OnNavigateBarButtonSelected != null)
                OnNavigateBarButtonSelected(e.NavigateBarButton);

        }

        #endregion

        #region /   SetCaptionText   /
        internal void SetCaptionText(NavigateBarButton tButton)
        {
            if (tButton != null)
            {
                navigateBarCaption.Caption = tButton.Caption;
                navigateBarCaption.Image = tButton.IsShowCaptionImage ? tButton.Image : null;
                navigateBarCaptionDesc.Caption = tButton.CaptionDescription;

                navigateBarCaption.Visible = tButton.IsShowCaption;
                navigateBarCaptionDesc.Visible = tButton.IsShowCaptionDescription;
            }
            else
            {
                navigateBarCaption.Caption = "";
                navigateBarCaption.Image = null;
                navigateBarCaptionDesc.Caption = "";

                navigateBarCaption.Visible = true;
                navigateBarCaptionDesc.Visible = false;

            }

            navigateBarCaption.Invalidate();
            navigateBarCaptionDesc.Invalidate();

        }
        #endregion

        #region /   NavigateBarButton_DisplayChanged   /

        /// <summary>
        /// If changed IsDisplayed state NavigateBarButton
        /// </summary>
        /// <param name="tOldValue"></param>
        /// <param name="tNewValue"></param>
        void NavigateBarButton_DisplayChanged(bool tOldValue, bool tNewValue)
        {

            displayedButtonCount = this.GetVisibleButtonCount(VisibleType.Visible);
            lastDisplayedButtonCount = displayedButtonCount;

            bool existsDisplay = false;

            // Tüm butonlar eğer görünmüyorsa Control görünüm alanını ve 
            // overflow kontrol alanını temizle
            // selectedButton null olarak ata

            // If all buttons is not displayed then clear overflowpanel and set null selectedbutton 

            foreach (NavigateBarButton nvb in this.NavigateBarButtons)
            {
                if (nvb.IsDisplayed)
                {
                    existsDisplay = true;
                    break;
                }
            }

            // Eğer seçili button IsDisplayed değilse olan ilk tabı seç
            // If selected new button not isdisplayed then select possible first button

            if (existsDisplay && selectedButton != null)
            {
                if (!this.selectedButton.IsDisplayed)
                {
                    foreach (NavigateBarButton nvb in this.NavigateBarButtons)
                    {
                        if (nvb.IsDisplayed)
                        {
                            this.SelectedButton = nvb;
                            break;
                        }
                    }
                }

            }
            else
            {
                SetControlForNavigateBarButton(null);
                displayedButtonCount = this.GetVisibleButtonCount(VisibleType.Visible);
                navigateBarCaption.Caption = "";
                navigateBarCaptionDesc.Caption = "";
                selectedButton = null;
            }

            // NavigateBarı yenile
            // Refresh items on navigatebar

            ChangeSplitterPosition();
            ReDisplayNavigateBarButtons();

            // OverFlowPaneli yenile
            // Refresh items on overflowpanel

            ReFreshOverFlowPanel(false);
            ReSizeControlPanel();

        }
        #endregion

        #region /   ReDisplayNavigateBarButtons   /
        /// <summary>
        /// Set button visible state for splitter position
        /// </summary>
        void ReDisplayNavigateBarButtons()
        {
            try
            {
                int j = 0;
                overFlowItemCount = 0;
                for (int i = 0; i < this.NavigateBarButtons.Count; i++)
                {
                    if (this.NavigateBarButtons[i].IsDisplayed)
                    {
                        this.NavigateBarButtons[i].Visible = (j < displayedButtonCount);
                        // If not displayed in navigatebar then show on overflowpanel
                        if (!this.NavigateBarButtons[i].Visible)
                            overFlowItemCount++;
                        j++;
                    }
                    else
                    {
                        this.NavigateBarButtons[i].Visible = false;
                    }
                }

                if (OnNavigateBarDisplayedButtonCountChanged != null)
                    OnNavigateBarDisplayedButtonCountChanged();
            }
            catch { }
        }
        #endregion

        #region /   MoveButtons   /

        /// <summary>
        /// Programatic move navigatebar buttons
        /// </summary>
        /// <param name="tMoveType"></param>
        internal void MoveButtons(MoveType tMoveType)
        {

            int activeCount = 0;
            activeCount = displayedButtonCount;

            // Aşağı kaydır
            // Move Down
            if (tMoveType == MoveType.MoveDown)
                activeCount--;

            // Yukarı kaydır
            // Move Up
            if (tMoveType == MoveType.MoveUp)
                activeCount++;

            this.ReDisplay(activeCount);
        }

        #endregion

        #region /   ReDisplay   /
        /// <summary>
        /// Set displayed button count in NavigateBar panel
        /// </summary>
        /// <param name="tButtonCount">Displayed button count. This value cannot bigger NavigateBarDisplayedButtonCount value</param>
        void ReDisplay(int tButtonCount)
        {

            if (!this.CheckIndex(tButtonCount) || tButtonCount > this.NavigateBarDisplayedButtonCount)
                return;

            displayedButtonCount = tButtonCount;

            // Ekranı yenile
            // Refresh navigatebar items
            this.ReDisplayNavigateBarButtons();
            this.ChangeSplitterPosition();

            // OverFlow Panel
            this.ReFreshOverFlowPanel();

            // Control Panel
            this.ReSizeControlPanel();

        }
        #endregion

        #region /   RunMenuOptionsDialog   /
        /// <summary>
        /// Run NavigationPane Option screen 
        /// </summary>
        public void RunMenuOptionsDialog()
        {

            for (int i = 0; i < this.NavigateBarButtons.Count; i++)
                this.NavigateBarButtons[i].IsChecked = this.NavigateBarButtons[i].IsDisplayed;

            NavigateBarOptions frmNavBarOptions = new NavigateBarOptions(this);
            if (frmNavBarOptions.ShowDialog() == DialogResult.OK &&
                frmNavBarOptions.HasChange)
            {
                for (int i = 0; i < this.NavigateBarButtons.Count; i++)
                {

                    //this.Controls.SetChildIndex(this.NavigateBarButtons[i], i + 3); //
                    this.ChangeButtonPosition(this.NavigateBarButtons[i], i);

                    if (this.NavigateBarButtons[i].IsDisplayed != this.NavigateBarButtons[i].IsChecked)
                        this.NavigateBarButtons[i].IsDisplayed = this.NavigateBarButtons[i].IsChecked;

                }

                displayedButtonCount = this.GetVisibleButtonCount(VisibleType.Visible);

                this.ReDisplay(displayedButtonCount);
                this.ReFreshOverFlowPanel(false);
            }

            frmNavBarOptions.Dispose();

        }
        #endregion

        #region /   ReFreshOverFlowPanel   /

        /// <summary>
        /// ReFresh OverFlowPanel
        /// </summary>
        void ReFreshOverFlowPanel()
        {
            ReFreshOverFlowPanel(true);
        }

        /// <summary>
        /// ReFresh OverFlowPanel
        /// </summary>
        void ReFreshOverFlowPanel(bool tCheck)
        {
            overFlowPanel.ReDisplayOverFlowButtons(tCheck);
            overFlowPanel.SetContextMenuEnableState();
        }
        #endregion

        #region /   SplitterPosition   /

        /// <summary>
        /// Calculate new positon for splitter
        /// </summary>
        void ChangeSplitterPosition()
        {
            if (!this.Created)
                return;
            try
            {
                splitter.Top = this.Height - overFlowPanel.Height - displayedButtonCount * this.NavigateBarButtonHeight - splitter.Height;

                ReSizeControlPanel();
            }
            catch { }
        }

        #endregion

        #region /   GetVisibleButtonCount   /
        /// <summary>
        /// Get visible button count
        /// </summary>
        /// <param name="tVisibleType"></param>
        /// <returns></returns>
        internal int GetVisibleButtonCount(VisibleType tVisibleType)
        {

            int visibleItemCount = 0;

            foreach (NavigateBarButton nvb in navigateBarButtons)
            {

                // Gözükmeyecekse pas geç
                // If not displayed skip button
                if (!nvb.IsDisplayed) continue;

                switch (tVisibleType)
                {
                    case VisibleType.Unvisible:
                        {
                            if (!nvb.Visible) visibleItemCount++;
                            break;
                        }
                    case VisibleType.Visible:
                        {
                            if (nvb.Visible) visibleItemCount++;
                            break;
                        }
                    case VisibleType.All:
                        {
                            visibleItemCount++;
                            break;
                        }
                }
            }

            return visibleItemCount;
        }
        #endregion

        #region /   SetControlForNavigateBarButton   /
        /// <summary>
        /// Show selected control for selected button
        /// </summary>
        /// <param name="tControl"></param>
        void SetControlForNavigateBarButton(Control tControl)
        {

            Control displayedControl = tControl;

            if (isCollapsedMode) // Not enough width navigatebar, display only caption // Yeterli yer yok sadece başlık göster
            {
                navigateBarCaption.Visible = false;
                navigateBarCaptionDesc.Visible = false;

                if (SelectedButton != null)
                    collapsibleText.ContentText = this.SelectedButton.Caption;
                else
                    collapsibleText.ContentText = "Navigation Pane";

                displayedControl = collapsibleText;

            }
            else // Normal kontrolü göster // display releated control
            {
                if (this.SelectedButton != null)
                {
                    navigateBarCaption.Visible = this.SelectedButton.IsShowCaption;
                    navigateBarCaptionDesc.Visible = this.SelectedButton.IsShowCaptionDescription;
                }
            }

            // Check common control
            // Genel kontrole bak

            if (displayedControl == null)
                displayedControl = this.RelatedControl;

            // Eğer genel kontrolde yoksa boş paneli göster

            if (displayedControl == null)
                displayedControl = relatedControlEmpty;

            // Gösterilen kontrol ile aynı ise gösterme
            // If displayed related control same as new control then return

            if (displayedControl != null)
            {

                if (!relatedControlContainer.Controls.Contains(displayedControl))
                {
                    displayedControl.Dock = DockStyle.Fill;
                    displayedControl.RightToLeft = RightToLeft.No;
                    relatedControlContainer.Controls.Add(displayedControl);
                }

                displayedControl.BringToFront();
                displayedControl.Focus();
            }

        }

        #endregion

        #region /   ReSizeControlPanel   /
        void ReSizeControlPanel()
        {

            if (relatedControlContainer == null)
                return;

            try
            {
                int visibleItemCount = GetVisibleButtonCount(VisibleType.Visible); // displayedItemCount;
                int newHeight = Height - relatedControlContainer.Top - (visibleItemCount * this.NavigateBarButtonHeight) - splitter.Height - this.OverFlowPanelHeight;

                Point newLocation = new Point(1, captionPanel.Height); // Konum // Positon

                relatedControlContainer.SuspendLayout();
                relatedControlContainer.Location = newLocation;
                relatedControlContainer.Width = Width - 2;
                relatedControlContainer.Height = Height - relatedControlContainer.Top - (visibleItemCount * this.NavigateBarButtonHeight) - splitter.Height - this.OverFlowPanelHeight;
                relatedControlContainer.ResumeLayout();
            }
            catch { }

        }
        #endregion

        #region /   ChangeCollapseMode   /
        /// <summary>
        /// Change collapse mode
        /// <para>true : Collapsed mode</para>
        /// <para>false : Normal mode</para>
        /// </summary>
        /// <param name="tCollapseMode">if true collpsed mode else mormal mode</param>
        public void ChangeCollapseMode(bool tCollapseMode)
        {

            if (!IsCollapsible)
                return;

            if (tCollapseMode == IsCollapsedMode)
                return;

            this.SuspendLayout();

            if (this.RightToLeft == RightToLeft.Yes)
            {
                if (tCollapseMode)
                {

                    oldWidth = this.Width;
                    oldLeft = this.Left;
                    this.Left = this.Width - this.CollapsibleWidth;
                    this.Width = this.CollapsibleWidth;

                }
                else
                {
                    this.Left = oldLeft;
                    this.Width = oldWidth;
                }
            }
            else
            {
                if (tCollapseMode)
                {
                    oldWidth = this.Width;
                    this.Width = this.CollapsibleWidth;

                    // Show over screen as to option
                    //if (this.IsShowOnButtonSelect && !collapsibleScreen.IsShowWindow)
                    //    ShowOverScreen();
                }
                else
                    this.Width = oldWidth;
            }
            isCollapsedMode = tCollapseMode;

            this.ResumeLayout();

            // Trigger event
            if (OnNavigateBarCollapseModeChanged != null)
                OnNavigateBarCollapseModeChanged(tCollapseMode);
        }
        #endregion

        #region/   ChangeButtonPosition   /
        /// <summary>
        /// Change position in panel and collection
        /// </summary>
        /// <param name="tButton">NavigateBarButton object in collection</param>
        /// <param name="tNewPosition">New postion in panel</param>
        public void ChangeButtonPosition(NavigateBarButton tButton, int tNewPosition)
        {
            // Check parameters
            if (!this.NavigateBarButtons.Contains(tButton))
                return;

            if (tNewPosition < 0 || tNewPosition > navigateBarButtons.Count - 1)
                return;

            // Set new position
            this.NavigateBarButtons.SetChildIndex(tButton, tNewPosition);
            this.Controls.SetChildIndex(tButton, tNewPosition + 3); // Caption Panel + Rel. Cont. Panel + Splitter

            // ReDisplay Panel and overflowpanel
            this.ReDisplayNavigateBarButtons();
            this.ReFreshOverFlowPanel(false);

        }
        #endregion

        #region /   CheckIndex   /
        /// <summary>
        /// Check index value
        /// </summary>
        /// <param name="tIndex"></param>
        /// <returns></returns>
        bool CheckIndex(int tIndex)
        {
            return (tIndex >= 0 && tIndex <= this.NavigateBarButtons.Count);
        }
        #endregion

        #region /   Desinger   /


        #region IComponent Members

        event EventHandler IComponent.Disposed
        {
            add { }
            remove { }
        }

        ISite IComponent.Site
        {
            get { return this.Site; }
            set { this.Site = value; }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            this.Dispose(false);
        }

        #endregion

        /// <summary>
        /// Designtime işleminde ekranı yeniler
        /// </summary>
        internal void PerformNavigationPane()
        {
            // ReDisplay Panel and overflowpanel
            if (!this.DesignMode)
                return;

            SetCaptionText(this.SelectedButton);

            ReDisplay(this.NavigateBarButtons.Count);
            ReFreshOverFlowPanel(false);

        }

        #endregion

    }

    #endregion
}
