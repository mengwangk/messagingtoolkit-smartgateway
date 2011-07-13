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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;

namespace MessagingToolkit.UI
{
    /// <summary>
    /// If cannot display button in NavigateBar then display button in this control
    /// </summary>
    [ToolboxItem(false)]
    class NavigateBarOverFlowPanel : UserControl
    {

        #region NavigateBar
        NavigateBar navigateBar = null;
        public NavigateBar NavigateBar
        {
            get { return navigateBar; }
            set
            {
                navigateBar = value;
                Invalidate();
            }
        }
        #endregion

        // Arrow Button

        NavigateBarOverFlowPanelButton panelArrowBtn = null;
        NavigateBarButton panelArrowNavBtn;

        // ContextMenu

        ContextMenuStrip mnContextMenu;

        NavigateBarOverFlowPanelMenuItem mnShowMoreButton;
        NavigateBarOverFlowPanelMenuItem mnShowFewerButton;
        NavigateBarOverFlowPanelMenuItem mnMenuOptions;
        NavigateBarOverFlowPanelMenuItem mnAddRemoveButton;

        // Var

        int lastItemCount = -1;

        #region Yapıcı Metodlar

        public NavigateBarOverFlowPanel(NavigateBar tNavigateBar)
        {
            NavigateBar = tNavigateBar;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            InitNavigateBarOverFlowPanel();
        }

        void InitNavigateBarOverFlowPanel()
        {

            // Control

            this.Dock = DockStyle.Fill;
            this.Height = navigateBar.OverFlowPanelHeight;
            this.MinimumSize = new Size(NavigateBar.OVER_FLOW_BUTTON_WIDTH, 20);

            #region Context Menu Items

            mnContextMenu = new ContextMenuStrip();
            mnContextMenu.Opening += delegate(object sender, CancelEventArgs e)
                {
                    foreach (ToolStripItem tsi in mnContextMenu.Items)
                        tsi.ForeColor = SystemColors.MenuText;
                };

            // Menü kapatıldığında okun clickini kaldır
            // Closed context menu remove selected state on arrow button
            mnContextMenu.Closed += delegate(object sender, ToolStripDropDownClosedEventArgs e)
                {
                    panelArrowBtn.IsSelected = false;
                    Refresh();
                };

            // Show More Button menu item

            mnShowMoreButton = new NavigateBarOverFlowPanelMenuItem(null, false);
            mnShowMoreButton.Text = Properties.Resources.TEXT_SHOW_MORE_BUTTONS;
            mnShowMoreButton.Image = Properties.Resources.ArrowUp;
            mnShowMoreButton.Click += delegate(object sender, EventArgs e)
                {
                    NavigateBar.MoveButtons(MoveType.MoveUp);
                };

            // Show Fewer Button menu item

            mnShowFewerButton = new NavigateBarOverFlowPanelMenuItem(null, false);
            mnShowFewerButton.Text = Properties.Resources.TEXT_SHOW_FEWER_BUTTONS;
            mnShowFewerButton.Image = Properties.Resources.ArrowDown;
            mnShowFewerButton.Click += delegate(object sender, EventArgs e)
                 {
                     NavigateBar.MoveButtons(MoveType.MoveDown);
                 };

            // Seçenek
            // Menu Options menu item
            mnMenuOptions = new NavigateBarOverFlowPanelMenuItem(null, false);
            mnMenuOptions.Text = Properties.Resources.TEXT_MENU_OPTIONS;
            mnMenuOptions.Click += delegate(object sender, EventArgs e)
                {
                    NavigateBar.RunMenuOptionsDialog();
                };

            // Ekle / Kaldır
            // Add or Remove Button menu item
            mnAddRemoveButton = new NavigateBarOverFlowPanelMenuItem(null, false);
            mnAddRemoveButton.Text = Properties.Resources.TEXT_ADD_OR_REMOVE_BUTTON;
            mnAddRemoveButton.DropDownOpening += delegate(object sender, EventArgs e)
                {
                    foreach (NavigateBarOverFlowPanelMenuItem item in mnAddRemoveButton.DropDownItems)
                        item.Checked = item.NavigateBarButton.IsDisplayed;
                };

            #endregion

            #region Arrow button for ContextMenu

            panelArrowNavBtn = new NavigateBarButton(Properties.Resources.TEXT_CONFIGURE_BUTTONS);
            panelArrowNavBtn.NavigateBar = NavigateBar;
            panelArrowNavBtn.ToolTipText = Properties.Resources.TEXT_CONFIGURE_BUTTONS;

            panelArrowBtn = new NavigateBarOverFlowPanelButton(panelArrowNavBtn);

            this.SetPanelArrowPosition();

            panelArrowBtn.IsSelected = false;
            panelArrowBtn.Visible = true;
            panelArrowBtn.IsArrowButton = true;
            panelArrowBtn.MouseClick += new MouseEventHandler(ArrowButton_MouseClick);

            this.Controls.Add(panelArrowBtn);

            #endregion

            this.ResizeRedraw = true;

            //

        }
        #endregion

        #region ContextMenu methods

        /// <summary>
        /// Build and show context menu on arrow button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ArrowButton_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
                return;

            mnContextMenu.RightToLeft = this.NavigateBar.IsUseRTLforMenus ? this.NavigateBar.RightToLeft : RightToLeft.No;
            mnContextMenu.Renderer = navigateBar.ContextMenuRenderer;

            // Sabit Elemanlar // Constant items

            this.BuildContextMenuItems();

            // Değişken Elemanlar // Changeable items

            bool isAddedSeparator = false;

            for (int i = 0; i < navigateBar.NavigateBarButtons.Count; i++)
            {
                NavigateBarButton nvbButton = navigateBar.NavigateBarButtons[i];

                if (!nvbButton.OverFlowPanelButton.Visible && nvbButton.IsDisplayed)
                {
                    // Add Separator
                    if (!isAddedSeparator)
                    {
                        isAddedSeparator = true;
                        mnContextMenu.Items.Add(new ToolStripSeparator());
                    }

                    // 

                    mnContextMenu.Items.Add(nvbButton.ContextMenuItem);
                }
            }

            // OK tıklandığında okun yanında context menü açılması sağlanıyor
            // Click arrow button show context menu near arrow button

            mnContextMenu.Show(this,
                this.Left + (this.NavigateBar.RightToLeft == RightToLeft.Yes ? 0 : this.Width),
                panelArrowBtn.Top + this.Height / 2);

        }

        /// <summary>
        /// Eklenen butonlara göre overflowpanel için contextmenuyu oluşturur
        /// </summary>
        void BuildContextMenuItems()
        {

            mnContextMenu.Items.Clear();
            mnAddRemoveButton.DropDownItems.Clear();

            mnContextMenu.Items.Add(mnShowMoreButton);
            mnContextMenu.Items.Add(mnShowFewerButton);
            mnContextMenu.Items.Add(mnMenuOptions);
            mnContextMenu.Items.Add(mnAddRemoveButton);

            // NavigateBarButton görünümleri değiştiren ContextMenu oluşturuluyor
            // Building context menu navigatebarbutton in collection

            foreach (NavigateBarButton nvbButton in navigateBar.NavigateBarButtons)
            {

                // Her zaman gösterilecek
                // If always show skip
                if (nvbButton.IsAlwaysDisplayed) continue;

                NavigateBarOverFlowPanelMenuItem ofpmi = new NavigateBarOverFlowPanelMenuItem(nvbButton, true);
                ofpmi.Click += delegate(object sender, EventArgs e)
                {
                    // Seçilen Button Panel içerisindek kaldırılır yada eklenilir
                    // Show or Hide NavigatebarButton in panel
                    if (sender is NavigateBarOverFlowPanelMenuItem)
                    {
                        NavigateBarButton nvb = (sender as NavigateBarOverFlowPanelMenuItem).NavigateBarButton;
                        nvb.IsDisplayed = !nvb.IsDisplayed;

                    }
                };

                mnAddRemoveButton.DropDownItems.Add(ofpmi);

            }

        }
        /// <summary>
        /// Görünen ve en fazla görünmesi gereken buton sayısına göre menülerin enable durumunu değiştirir
        /// </summary>
        public void SetContextMenuEnableState()
        {

            if (mnContextMenu == null)
                return;

            // Eğer düğme varsa
            // If any button displayed context menu

            mnMenuOptions.Enabled = (NavigateBar.NavigateBarButtons.Count > 0);
            mnAddRemoveButton.Enabled = (NavigateBar.NavigateBarButtons.Count > 0);
            mnShowFewerButton.Enabled = (NavigateBar.NavigateBarButtons.Count > 0);
            mnShowMoreButton.Enabled = (NavigateBar.NavigateBarButtons.Count > 0);

            //

            int visibleButtonCount = NavigateBar.GetVisibleButtonCount(VisibleType.Visible);

            // Tüm NavigateBarButonlar gözüküyor sadece aşağı hareket edebilir
            // All buttons is displayed. Only move down
            if (visibleButtonCount == NavigateBar.NavigateBarDisplayedButtonCount && NavigateBar.NavigateBarButtons.Count > 0)
            {
                mnShowMoreButton.Enabled = false;
                mnShowFewerButton.Enabled = true;
            }

            // Aşağı - yukarı hareket edebilir
            // Move up or down
            if (visibleButtonCount < NavigateBar.NavigateBarDisplayedButtonCount &&
                visibleButtonCount > 0 && NavigateBar.NavigateBarButtons.Count > 0)
            {
                mnShowMoreButton.Enabled = true;
                mnShowFewerButton.Enabled = true;
            }

            // Tüm NavigateBarButonlar gizli sadece yukarı hareket edebilir
            // All buttons is visible. Only move up
            if (visibleButtonCount == 0 && NavigateBar.NavigateBarButtons.Count > 0)
            {
                mnShowMoreButton.Enabled = true;
                mnShowFewerButton.Enabled = false;
            }

            // 

        }

        #endregion

        #region Method : ReDisplayOverFlowButtons

        /// <summary>
        /// If button cannot displayed NavigateBar panel then display on this panel
        /// </summary>
        public void ReDisplayOverFlowButtons(bool tCheck)
        {

            if (tCheck && lastItemCount == navigateBar.OverFlowItemCount)
                return;

            this.SuspendLayout();

            // OverFlowPanel üzerine simgeleri sırasına göre ekle
            // Eğer simgelerin toplam uzunluğu panelden fazla ise ContextMenu üzerine ekle
            // Panel içerisine kaç adet button sığıyor

            // Add button on overflowpanel looking order
            // calculate how many button displayable on panel
            // If cannot display button on overflowpanel then show on contextmenu

            int addedBtnCount = 0;
            int displayableBtnCount = (this.Width - NavigateBar.OVER_FLOW_BUTTON_WIDTH - 4) / NavigateBar.OVER_FLOW_BUTTON_WIDTH;
            displayableBtnCount = (displayableBtnCount > navigateBar.OverFlowItemCount ? navigateBar.OverFlowItemCount : displayableBtnCount);

            for (int i = 0; i < navigateBar.NavigateBarButtons.Count; i++)
            {

                NavigateBarButton nvbButton = navigateBar.NavigateBarButtons[i];
                NavigateBarOverFlowPanelButton overFlowPanelButton = nvbButton.OverFlowPanelButton;

                overFlowPanelButton.Visible = true;

                // Eğer button panel içerisinde gösterliyorsa ve daha önce overflowpanel 
                // içerisinde ise overlofwpanel buttonu kaldır

                if (nvbButton.Visible || !nvbButton.IsDisplayed)
                {
                    if (this.Controls.Contains(overFlowPanelButton))
                        this.Controls.Remove(overFlowPanelButton);
                    continue;
                }

                if (overFlowPanelButton.IsOnOverFlowPanel &&
                    overFlowPanelButton.NavigateBarButton.IsDisplayed) // Eğer panel üzerindeki button ise // If is display
                {

                    if (addedBtnCount < displayableBtnCount) // Tüm buttonlar sığıyor // all buttons can visible
                    {

                        if (this.NavigateBar.RightToLeft == RightToLeft.Yes)
                            overFlowPanelButton.Left = Math.Abs(displayableBtnCount - addedBtnCount) * NavigateBar.OVER_FLOW_BUTTON_WIDTH; // Normal sıralı dizmek için
                        else
                            overFlowPanelButton.Left = this.Width - Math.Abs(addedBtnCount - displayableBtnCount - 1 /* Arrow Button*/) * NavigateBar.OVER_FLOW_BUTTON_WIDTH; // Tersten dizmek için

                        if (!this.Controls.Contains(overFlowPanelButton))
                            this.Controls.Add(overFlowPanelButton);

                        addedBtnCount++;

                    }
                    else
                        overFlowPanelButton.Visible = false;
                }
                else
                    overFlowPanelButton.Visible = false;

            }

            lastItemCount = navigateBar.OverFlowItemCount;

            //

            this.ResumeLayout(false);

        }

        #endregion

        #region Overrided Methodlar

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            SetPanelArrowPosition();
            panelArrowBtn.Invalidate();
            base.OnInvalidated(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                ctrl.Top = 1;
                ctrl.Height = this.Height - 2;
            }

            base.OnSizeChanged(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            // Gradient olarak boyama işlemi
            // Paint gradient

            NavigateBarHelper.PaintGradientBack(this, e.Graphics, navigateBar.NavigateBarColorTable, PaintType.Normal);

            // Etrafın çizgisi
            // draw rectangle

            e.Graphics.DrawRectangle(new Pen(navigateBar.NavigateBarColorTable.BorderColor), new Rectangle(0, 0, Width - 1, Height - 1));

        }

        protected override void OnResize(EventArgs e)
        {
            if (panelArrowBtn != null)
                panelArrowBtn.Left = Width - NavigateBar.OVER_FLOW_BUTTON_WIDTH - 1;

            ReDisplayOverFlowButtons(false);

            Invalidate();
            base.OnResize(e);
        }
        #endregion

        #region Diğer Methodlar

        void SetPanelArrowPosition()
        {
            if (this.NavigateBar.RightToLeft == RightToLeft.Yes)
                panelArrowBtn.Left = 1;
            else
                panelArrowBtn.Left = Width - NavigateBar.OVER_FLOW_BUTTON_WIDTH - 1;
        }

        #endregion
    }
}
