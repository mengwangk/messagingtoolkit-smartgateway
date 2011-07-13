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
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel;
using System.Drawing;

namespace MessagingToolkit.UI
{
    /// <summary>
    /// NavigateBarButton for NavigateBar
    /// </summary>
    [Browsable(false)]
    [ToolboxItem(false)]
    [DefaultEvent("OnNavigateBarButtonSelected")]
    [DefaultProperty("Caption")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class NavigateBarButton : UserControl, IComponent
    {
        const int SPLIT_WIDTH = 5;

        // Delegate

        #region Delegate & Events

        public delegate void OnNavigateBarButtonSelectedEventHandler(NavigateBarButtonEventArgs e);
        /// <summary>
        /// Occurs when this button selected
        /// </summary>
        public event OnNavigateBarButtonSelectedEventHandler OnNavigateBarButtonSelected;

        public delegate void OnNavigateBarButtonCaptionChangedEventHandler(string tOldCaption, string tNewCaption);
        /// <summary>
        /// Occurs when this button caption changed
        /// </summary>
        public event OnNavigateBarButtonCaptionChangedEventHandler OnNavigateBarButtonCaptionChanged;

        public delegate void OnNavigateBarButtonCaptionDescriptionChangedEventHandler(string tOldCaptionDesc, string tNewCaptionDesc);
        /// <summary>
        /// Occurs when this button caption description cahnged
        /// </summary>
        public event OnNavigateBarButtonCaptionDescriptionChangedEventHandler OnNavigateBarButtonCaptionDescriptionChanged;

        public delegate void OnNavigateBarButtonDisplayChangedEventHandler(bool tOldValue, bool tNewValue);
        /// <summary>
        /// Occurs when this button manual visible changed
        /// </summary>
        public event OnNavigateBarButtonDisplayChangedEventHandler OnNavigateBarButtonDisplayChanged;

        #endregion

        // Properties

        #region Image
        private Image image = null;
        /// <summary>
        /// NavigateBarButton image (24x24 recommended)
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                if (image != null)
                    disableImage = (Image)NavigateBarHelper.ConvertToGrayscale((Bitmap)image);
                Invalidate();
            }
        }
        #endregion

        #region MouseOverImage
        private Image mouseOverImage = null;
        /// <summary>
        /// NavigateBarButton mouse over image  (24x24 recommended)
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image MouseOverImage
        {
            get { return mouseOverImage == null ? image : mouseOverImage; }
            set
            {
                mouseOverImage = value;
                Invalidate();
            }
        }
        #endregion

        #region SelectedImage
        private Image selectedImage = null;
        /// <summary>
        /// NavigateBarButton selected image  (24x24 recommended)
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image SelectedImage
        {
            get
            {
                return selectedImage == null ? image : selectedImage;
            }
            set
            {
                selectedImage = value;
                Invalidate();
            }
        }
        #endregion

        #region Caption
        private string caption = "";
        private string captionString = "";
        /// <summary>
        /// NavigateBarButton caption
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue("NavigateBar Button")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Caption
        {
            get { return caption; }
            set
            {
                string oldCaption = caption;
                caption = value;
                captionString = value;

                Invalidate();
                if (OnNavigateBarButtonCaptionChanged != null)
                    OnNavigateBarButtonCaptionChanged(oldCaption, caption);

            }
        }
        #endregion

        #region CaptionDescription
        private string captionDesc = "";
        /// <summary>
        /// Displayed text on description band
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CaptionDescription
        {
            get
            {
                if (string.IsNullOrEmpty(captionDesc))
                    return caption;
                else
                    return captionDesc;
            }
            set
            {
                string oldCaptionDesc = captionDesc;
                captionDesc = value;
                if (this.Parent != null)
                    this.Parent.Invalidate();

                if (OnNavigateBarButtonCaptionDescriptionChanged != null)
                    OnNavigateBarButtonCaptionDescriptionChanged(oldCaptionDesc, captionDesc);
            }
        }
        #endregion

        #region Key
        string key = NavigateBarHelper.CreateUniqKey();
        /// <summary>
        /// Key value for button. Key value must be uniq in collection. This value required save and restore settings.
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Key
        {
            get
            {
                if (string.IsNullOrEmpty(key))
                {
                    if (!string.IsNullOrEmpty(this.Caption))
                        return caption.Replace("-", "").Replace(" ", "").ToUpper();
                    else
                        return NavigateBarHelper.CreateUniqKey();
                }
                else
                    return key;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Cannot null or empty");
                key = value;
            }
        }
        #endregion

        #region IsSelected
        private bool isSelected = false;
        /// <summary>
        /// Is selected NavigateBarButton
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (this.Enabled)
                    isSelected = value;
                else
                    isSelected = false;

                this.PaintingType = isSelected ? PaintType.Selected : PaintType.Normal;

                overFlowPanelButton.IsSelected = isSelected;
                Invalidate();
            }
        }

        #endregion

        #region IsDisplayed
        private bool isDisplayed = true;
        /// <summary>
        /// Is display NavigateBarButton in NavigateBar ?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsDisplayed
        {
            get { return isDisplayed; }
            set
            {
                bool oldValue = isDisplayed;
                isDisplayed = IsAlwaysDisplayed ? true : value;

                if (oldValue != isDisplayed && OnNavigateBarButtonDisplayChanged != null)
                    OnNavigateBarButtonDisplayChanged(oldValue, isDisplayed);
            }
        }

        #endregion

        #region IsShowCaption
        bool isShowCaption = true;
        /// <summary>
        /// Is show caption band?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsShowCaption
        {
            get { return isShowCaption; }
            set { isShowCaption = value; }
        }
        #endregion

        #region IsAlwaysDisplayed
        bool isAlwaysDisplayed = false;
        /// <summary>
        /// Is always show in navigation paner ?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsAlwaysDisplayed
        {
            get { return isAlwaysDisplayed; }
            set
            {
                isAlwaysDisplayed = value;
                // Eğer gizlenemeyen düğme ve gizliyse göster
                // If set true
                if (isAlwaysDisplayed && !this.IsDisplayed)
                    this.IsDisplayed = true;
            }
        }
        #endregion

        #region IsShowCaptionDescription
        bool isShowCaptionDescription = true;
        /// <summary>
        /// Is show caption description band ?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsShowCaptionDescription
        {
            get { return isShowCaptionDescription; }
            set { isShowCaptionDescription = value; }
        }
        #endregion

        #region IsShowCaptionImage
        bool isShowCaptionImage = true;
        /// <summary>
        /// Is show image on caption band?
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsShowCaptionImage
        {
            get { return isShowCaptionImage; }
            set { isShowCaptionImage = value; }
        }
        #endregion

        #region RelatedControl
        private Control relatedControl = null;
        /// <summary>
        /// Displayed control for NavigateBarButton
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Control RelatedControl
        {
            get { return relatedControl; }
            set { relatedControl = value; }
        }
        #endregion

        #region Font
        private Font font = new Font("Tahoma", 8, FontStyle.Bold);
        /// <summary>
        /// NavigateBarButton font
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Font Font
        {
            get { return font; }
            set
            {
                font = value;
                Invalidate();
            }
        }
        #endregion

        #region ToolTipText
        string toolTipText = "";
        /// <summary>
        /// Tooltiptext for NavigateBarButton
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ToolTipText
        {
            get
            {
                toolTipText = string.IsNullOrEmpty(toolTipText) ? Caption + (Caption.Equals(CaptionDescription) ? "" : "\n" + CaptionDescription) : toolTipText;
                return toolTipText;
            }
            set
            {
                toolTipText = value;
            }
        }
        #endregion

        #region CollapsedScreenWidth
        int collapsibleScreenWidth = NavigateBar.COLLAPSIBLE_SCREEN_WIDTH;
        /// <summary>
        /// Collapsible screen width for this button.
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(NavigateBar.COLLAPSIBLE_SCREEN_WIDTH)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CollapsedScreenWidth
        {
            get { return collapsibleScreenWidth; }
            set { collapsibleScreenWidth = value; }
        }
        #endregion

        #region IsShowCollapseScreenCaption
        bool isShowCollapseScreenCaption = false;
        /// <summary>
        /// Is show caption band on collapse screen ? 
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsShowCollapseScreenCaption
        {
            get { return isShowCollapseScreenCaption; }
            set { isShowCollapseScreenCaption = value; }
        }
        #endregion

        // Internals Properties

        #region NavigateBar
        NavigateBar navigateBar = null;
        [Category("NavigateBarButton")]
        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal NavigateBar NavigateBar
        {
            get { return navigateBar; }
            set
            {
                navigateBar = value;
                Invalidate();
            }
        }
        #endregion

        #region OverFlowPanelButton
        NavigateBarOverFlowPanelButton overFlowPanelButton = null;
        /// <summary>
        /// Displayed button on OverFlowPanel
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal NavigateBarOverFlowPanelButton OverFlowPanelButton
        {
            get
            {
                contextMenuItem.Text = Caption;
                contextMenuItem.Image = Image;
                return overFlowPanelButton;
            }
        }
        #endregion

        #region ContextMenuItem
        NavigateBarOverFlowPanelMenuItem contextMenuItem = null;
        /// <summary>
        /// ContextMenu menu item
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal NavigateBarOverFlowPanelMenuItem ContextMenuItem
        {
            get { return contextMenuItem; }
        }
        #endregion

        #region DisableImage
        Image disableImage;
        [Category("NavigateBarButton")]
        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Image DisableImage
        {
            get { return disableImage; }
        }
        #endregion

        #region Checked
        bool isChecked = true;
        /// <summary>
        /// Contain isdisplay value for Menu Option form
        /// <para>Get / Set</para>
        /// </summary>
        [Category("NavigateBarButton")]
        [Browsable(false)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }
        #endregion

        // Static Properties

        #region DefaultButtonHeight
        static int defaultButtonHeight = NavigateBar.BUTTON_HEIGHT;
        /// <summary>
        /// Default button height
        /// <para>Get</para>
        /// </summary>
        public static int DefaultButtonHeight
        {
            get { return defaultButtonHeight; }
        }
        #endregion

        #region MinimumButtonHeight
        static int minimumButtonHeight = 20;
        /// <summary>
        /// Minimum button height
        /// <para>Get</para>
        /// </summary>
        public static int MinimumButtonHeight
        {
            get { return minimumButtonHeight; }
        }
        #endregion

        // ContextMenu on button right click

        ButtonContextMenu menu = null;
        internal ButtonContextMenu ButtonMenu
        {
            get { return menu; }
        }

        #region PaintingType
        PaintType paintType = PaintType.Normal;
        PaintType PaintingType
        {
            get { return paintType; }
            set
            {
                if (this.IsSelected)
                    value = PaintType.Selected;

                paintType = value;
                this.Invalidate();
            }
        }
        #endregion

        static ToolTip toolTip;

        #region Yapıcı Metodlar

        public NavigateBarButton()
        {
            this.Caption = "NavigateBarButton";
            this.Key = NavigateBarHelper.CreateUniqKey();
            InitNavigateBarButton();
        }

        /// <summary>
        /// Caption
        /// </summary>
        /// <param name="tCaption">Caption text</param>
        public NavigateBarButton(string tCaption)
        {
            this.Caption = tCaption;
            this.Key = NavigateBarHelper.CreateUniqKey();
            InitNavigateBarButton();
        }

        /// <summary>
        /// Caption and Image
        /// </summary>
        /// <param name="tCaption">Caption text</param>
        /// <param name="tImage">Image (24x24 recommended)</param>
        public NavigateBarButton(string tCaption, Image tImage)
        {
            this.Caption = tCaption;
            this.Image = tImage;
            this.Key = NavigateBarHelper.CreateUniqKey();
            InitNavigateBarButton();
        }

        /// <summary>
        /// Caption, image and related control
        /// </summary>
        /// <param name="tCaption">Caption text</param>
        /// <param name="tImage">Image (24x24 recommended)</param>
        /// <param name="tRelatedControl">Related control</param>
        public NavigateBarButton(string tCaption, Image tImage, Control tRelatedControl)
        {
            this.Caption = tCaption;
            this.Image = tImage;
            this.RelatedControl = tRelatedControl;
            this.Key = NavigateBarHelper.CreateUniqKey();
            InitNavigateBarButton();
        }

        /// <summary>
        /// Caption, key, image and related control
        /// </summary>
        /// <param name="tCaption">Caption text</param>
        /// <param name="tKey">Key value. Value must be uniq in collection</param>
        /// <param name="tImage">Image (24x24 recommended)</param>
        /// <param name="tRelatedControl">Related control</param>
        public NavigateBarButton(string tCaption, string tKey, Image tImage, Control tRelatedControl)
        {
            this.Caption = tCaption;
            this.Key = tKey;
            this.Image = tImage;
            this.RelatedControl = tRelatedControl;
            InitNavigateBarButton();
        }

        /// <summary>
        /// Related control
        /// </summary>
        /// <param name="tRelatedControl">Related control</param>
        public NavigateBarButton(Control tRelatedControl)
        {
            this.RelatedControl = tRelatedControl;
            this.Caption = "NavigateBarButton";
            this.Key = NavigateBarHelper.CreateUniqKey();
            InitNavigateBarButton();
        }


        void InitNavigateBarButton()
        {
            // Control

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.UpdateStyles();

            //this.ResizeRedraw = true;
            this.MinimumSize = new Size(NavigateBar.OVER_FLOW_BUTTON_WIDTH, minimumButtonHeight);
            this.Cursor = Cursors.Hand;

            // Menu

            menu = new ButtonContextMenu(this);
            this.ContextMenuStrip = menu;

            // ToolTip

            toolTip = new ToolTip();
            toolTip.ShowAlways = true;

            // OverFlowPanelButton (Panel içerisine sığmadığında overflowpanel içerisinde bu eleman gösteriliyor)
            // If cannot display navigatebutton then show this button on overflowpanel

            overFlowPanelButton = new NavigateBarOverFlowPanelButton(this);
            overFlowPanelButton.NavigateBarButton = this;
            overFlowPanelButton.IsSelected = isSelected;

            // ContextMenuItem (OverFlowPanel sığmadığında menüde bu eleman gösteriliyor)
            // If cannot display on overflowpanel then show on contextmenu

            contextMenuItem = new NavigateBarOverFlowPanelMenuItem(this, false);
            contextMenuItem.Click += delegate(object sender, EventArgs e)
                {
                    this.PerformClick();
                };

        }

        #endregion

        #region PerfromClick
        /// <summary>
        /// Run manual selected event
        /// </summary>
        public void PerformClick()
        {
            // Eğer gösterilen bir button ise click olayını çalıştır
            // Run button click
            if (this.IsDisplayed && this.Enabled)
            {
                if (this.OnNavigateBarButtonSelected != null)
                    this.OnNavigateBarButtonSelected(new NavigateBarButtonEventArgs(this));
            }

        }

        #endregion

        #region Overrided Metodlar

        /// <summary>
        /// Invalidete menuitem and overflowpanel button
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            overFlowPanelButton.Invalidate();
            contextMenuItem.Invalidate();
            base.OnInvalidated(e);
        }

        /// <summary>
        /// If cannot visible button then hide button on overflowpanel
        /// </summary>
        /// <param name="e"></param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            overFlowPanelButton.IsOnOverFlowPanel = !this.Visible; // önemli // important
            base.OnVisibleChanged(e);
        }

        /// <summary>
        /// if disable button select possible first button
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            overFlowPanelButton.Enabled = this.Enabled;
            contextMenuItem.Enabled = this.Enabled;

            // Eğer disable duruma getirildiyse bir önceki butona geç
            if (!this.Enabled && NavigateBar != null)
            {
                if (this.IsSelected) // Eğer seçili olan button disable edildiyse
                {
                    int index = 0;
                    for (int i = 0; i < NavigateBar.NavigateBarButtons.Count; i++)
                    {
                        if (NavigateBar.NavigateBarButtons[i].Equals(this))
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index > 0)
                        NavigateBar.SelectedButton = NavigateBar.NavigateBarButtons[index - 1];
                    else if (index == 0 && NavigateBar.NavigateBarButtons.Count > 0)
                        NavigateBar.SelectedButton = NavigateBar.NavigateBarButtons[1];
                    else
                        NavigateBar.SelectedButton = NavigateBar.NavigateBarButtons[index];
                }
            }

            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Select Button
            {
                this.IsSelected = true;
                this.PaintingType = PaintType.Selected;
                this.PerformClick();
            }
            else if (e.Button == MouseButtons.Right) // Show context menu
            {
                menu.Show();
            }
            base.OnMouseClick(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            this.PaintThisControl(e.Graphics);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!this.IsSelected)
                this.PaintingType = PaintType.Pressed;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.PaintingType = PaintType.Normal;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.PaintingType = PaintType.MouseOver;

            if (!Caption.Equals(captionString))
                toolTip.SetToolTip(this, ToolTipText);
            else
                toolTip.RemoveAll();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.PaintingType = PaintType.Normal;
            toolTip.RemoveAll();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            this.PaintingType = PaintType.MouseOver;

            if (!Caption.Equals(captionString))
                toolTip.SetToolTip(this, ToolTipText);
            else
                toolTip.RemoveAll();

        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.PaintingType = PaintType.Normal;
            toolTip.RemoveAll();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Space)
            {
                e.Handled = true;
                this.IsSelected = true;
                this.PaintingType = PaintType.Selected;
                this.PerformClick();
            }
            else
                base.OnKeyUp(e);

        }

        /// <summary>
        /// on resizing button reorganize caption text
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {

            if (navigateBar != null && this.Height > navigateBar.NavigateBarButtonHeight) // Tekil boyutlandırma yapılmamalı
                Height = navigateBar.NavigateBarButtonHeight;

            base.OnResize(e);

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.DesignMode || navigateBar == null)
                return;

            if (this.Height != navigateBar.NavigateBarButtonHeight)
                this.Height = navigateBar.NavigateBarButtonHeight;

            if (this.Width != navigateBar.Width)
                this.Width = navigateBar.Width;

            base.OnSizeChanged(e);
        }

        /// <summary>
        /// return CaptionOrjinal info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Caption;
        }

        #endregion

        #region Diğer Metodlar
        /// <summary>
        /// Paint NavigateBarButton
        /// </summary>
        /// <param name="LightColor"></param>
        /// <param name="DarkColor"></param>
        /// <param name="paintType"></param>
        void PaintThisControl(Graphics g)
        {

            Image imageButton = null;
            switch (this.PaintingType)
            {
                case PaintType.Normal:
                    {
                        imageButton = isSelected ? SelectedImage : Image;
                        break;
                    }
                case PaintType.Selected:
                    {
                        imageButton = SelectedImage;
                        break;
                    }
                case PaintType.MouseOver:
                    {
                        imageButton = MouseOverImage;
                        break;
                    }
                case PaintType.Pressed:
                    {
                        imageButton = Image;
                        break;
                    }
            }

            // Gradient olarak boyama işlemi
            // Paint gradient

            NavigateBarHelper.PaintGradientBack(this, g, navigateBar.NavigateBarColorTable, this.PaintingType);

            // Yazıyı yazma
            // Draw caption text

            if (!string.IsNullOrEmpty(Caption))
            {
                Brush brushText;
                if (this.Enabled)
                    brushText = new SolidBrush(isSelected ?
                        navigateBar.NavigateBarColorTable.SelectedTextColor :
                        navigateBar.NavigateBarColorTable.TextColor);
                else
                    brushText = SystemBrushes.GrayText; // Disable color

                // Caption ifadesini belirle

                int widthCaption = (int)g.MeasureString(caption, Font).Width; // Caption pixel olarak uzunluğunu al

                if (this.Width < (widthCaption + SPLIT_WIDTH * 2 + (Image == null ? SPLIT_WIDTH : Image.Width)))
                {
                    captionString = "..";
                    for (int i = Caption.Length - 1; i >= 0; i--)
                    {
                        string tmpCaption = caption.Trim().Substring(0, i);

                        int widthCaptionTmp = (int)g.MeasureString(tmpCaption + "..", Font).Width; // Caption pixel olarak uzunluğunu al
                        if (this.Width >= (widthCaptionTmp + SPLIT_WIDTH * 2 + (Image == null ? SPLIT_WIDTH : Image.Width)))
                        {
                            captionString = tmpCaption + "..";
                            break;
                        }
                    }
                }
                else
                    captionString = caption;

                //

                string cap = captionString.Equals("..") ? "" : captionString;
                if (this.NavigateBar.RightToLeft == RightToLeft.Yes && this.NavigateBar.IsUseRTLforButtons)
                {
                    int capWidth = (int)g.MeasureString(cap, this.Font).Width;
                    g.DrawString(cap, Font, brushText,
                                               this.Width - capWidth - SPLIT_WIDTH - (imageButton == null ? 0 : imageButton.Width + SPLIT_WIDTH), this.Height / 2 - Font.Height / 2);
                }
                else
                {
                    g.DrawString(cap, Font, brushText,
                        SPLIT_WIDTH + (imageButton == null ? 0 : imageButton.Width) + (imageButton != null ? SPLIT_WIDTH : 0), this.Height / 2 - Font.Height / 2);

                }
            }

            // Resmi gösterme
            // Draw Image

            if (imageButton != null)
            {
                Image img = null;
                if (this.Enabled) // Orjinal resmi kullan // use orjinal picture
                    img = imageButton;
                else
                    img = image;

                if (!this.Enabled)
                    img = disableImage;

                int leftPos = SPLIT_WIDTH;

                if (this.NavigateBar.RightToLeft == RightToLeft.Yes && this.NavigateBar.IsUseRTLforButtons)
                {
                    leftPos = this.Width - img.Width - SPLIT_WIDTH;
                }

                // Eğer button metni gözükmüyorsa sadece image gözükecek şekilde ortala
                // if cannot display button text then set image position center button
                if (captionString.Equals("..") || string.IsNullOrEmpty(captionString))
                {
                    // Center position
                    leftPos = (int)((Width - img.Width) / 2);
                    leftPos = leftPos <= 0 ? 1 : leftPos;
                }

                g.DrawImage(img,
                    new Rectangle(leftPos, (int)((Height - img.Height + 4) / 2),
                    img.Width,
                    img.Height > Height ? Height : img.Height));
            }

            // Dış Çizgi
            // Draw rectangle 

            Pen pen = new Pen(navigateBar.NavigateBarColorTable.BorderColor);
            g.DrawRectangle(pen, new Rectangle(0, 0, Width - 1, Height));

            //
        }
      
        #endregion

        #region Internal Class : ButtonContextMenu
        internal class ButtonContextMenu : ContextMenuStrip
        {

            NavigateBarButton button = null;

            ToolStripMenuItem mnHideItem;
            ToolStripMenuItem mnMenuOption;

            public ButtonContextMenu(NavigateBarButton tButton)
            {


                button = tButton;

                mnHideItem = new ToolStripMenuItem();
                mnHideItem.Text = Properties.Resources.TEXT_BUTTON_HIDE + " " + tButton.Caption;
                mnHideItem.Click += new EventHandler(mnHideItem_Click);

                mnMenuOption = new ToolStripMenuItem();
                mnMenuOption.Text = Properties.Resources.TEXT_MENU_OPTIONS;
                mnMenuOption.Click += new EventHandler(mnMenuOption_Click);

                Items.Add(mnHideItem);
                Items.Add(mnMenuOption);

                this.Opening += new CancelEventHandler(ButtonContextMenu_Opening);
            }

            void ButtonContextMenu_Opening(object sender, CancelEventArgs e)
            {
                foreach (ToolStripItem tsi in Items)
                    tsi.ForeColor = SystemColors.MenuText;

                mnHideItem.Text = Properties.Resources.TEXT_BUTTON_HIDE + " " + button.Caption;

                if (button.NavigateBar.IsUseRTLforMenus && button.NavigateBar.RightToLeft == RightToLeft.Yes)
                    this.RightToLeft = RightToLeft.Yes;
                else
                    this.RightToLeft = RightToLeft.No;

                mnHideItem.Visible = !button.IsAlwaysDisplayed;
                mnHideItem.Image = button.Image;

                this.Renderer = button.NavigateBar.ContextMenuRenderer;
            }

            void mnMenuOption_Click(object sender, EventArgs e)
            {
                button.NavigateBar.RunMenuOptionsDialog();
                button.PaintingType = PaintType.Normal;
            }

            void mnHideItem_Click(object sender, EventArgs e)
            {
                button.IsDisplayed = false;
                button.NavigateBar.Invalidate();
            }
        }
        #endregion

        #region IComponent Members

        event EventHandler IComponent.Disposed
        {
            add { }
            remove { }
        }

        ISite IComponent.Site
        {
            get
            {
                return this.Site;
            }
            set
            {
                this.Site = value;
            }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            base.Dispose();
        }

        #endregion
    }
}

