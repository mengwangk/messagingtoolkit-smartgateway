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
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MessagingToolkit.UI
{
    /// <summary>
    /// OverFlowPanel button control
    /// </summary>
    [ToolboxItem(false)]
    class NavigateBarOverFlowPanelButton : UserControl
    {
        // change for arrow button draw area

        const int ARROW_WIDTH = 5;
        const int ARROW_HEIGHT = 3;

        #region IsSelected
        bool isSelected = false;
        [Category("NavigateBarButton")]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                if (isSelected)
                    this.PaintingType = PaintType.Selected;
                else
                    this.PaintingType = PaintType.Normal;

            }
        }
        #endregion

        #region IsOnOverFlowPanel
        bool isOnOverFlowPanel = false;
        public bool IsOnOverFlowPanel
        {
            get { return isOnOverFlowPanel; }
            set { isOnOverFlowPanel = value; }
        }
        #endregion

        #region IsArrowButton
        bool isArrowButton = false;
        public bool IsArrowButton
        {
            get { return isArrowButton; }
            set
            {
                if (value)
                    this.Cursor = Cursors.Default;
                isArrowButton = value;
            }
        }
        #endregion

        #region NavigateBarButton
        NavigateBarButton navigateBarButton;
        public NavigateBarButton NavigateBarButton
        {
            get { return navigateBarButton; }
            set
            {
                if (navigateBarButton != null)
                {
                    navigateBarButton = value;
                    if (navigateBarButton.NavigateBar != null)
                        Invalidate();

                }

            }
        }
        #endregion

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
                Invalidate();
            }
        }
        #endregion

        static ToolTip toolTip = new ToolTip();

        #region Yapıcı Methodlar

        public NavigateBarOverFlowPanelButton(NavigateBarButton tNavigateBarButton)
        {
            navigateBarButton = tNavigateBarButton;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            InitOverFlowButton();
        }

        void InitOverFlowButton()
        {
            this.Cursor = Cursors.Hand;
            this.Width = NavigateBar.OVER_FLOW_BUTTON_WIDTH;
            this.Height = NavigateBar.BUTTON_HEIGHT - 2; // Alt üst çizgilerin görünmesi için -2 ve 1 // for display button line (top & bottom)
            this.Top = 1;

            toolTip.ShowAlways = true;
            toolTip.InitialDelay = 200;
            toolTip.AutomaticDelay = 200;
        }

        #endregion

        #region Overrided Methodlar

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            //this.PaintingType = PaintType.Normal;
            PaintThisControl(e.Graphics);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            toolTip.SetToolTip(this, navigateBarButton.ToolTipText);
            this.PaintingType = PaintType.MouseOver;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            toolTip.RemoveAll();
            this.PaintingType = PaintType.Normal;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!this.IsSelected && e.Button == MouseButtons.Left)
                this.PaintingType = PaintType.Pressed;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
                this.PaintingType = PaintType.Normal;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            toolTip.RemoveAll();
            // Only left click
            if (e.Button == MouseButtons.Left && !this.IsArrowButton) // Sadece sol click ile button seçilebilmeli
            {
                this.IsSelected = true;
                this.PaintingType = PaintType.Selected;
                NavigateBarButton.PerformClick();
            }
            else
            {
                if (!this.IsArrowButton)
                {
                    Point p = this.PointToScreen(new Point(this.Location.X - this.Left + this.Width, this.Location.Y));
                    NavigateBarButton.ButtonMenu.Show(p);
                }
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!this.IsArrowButton)
            {
                this.PaintingType = PaintType.MouseOver;
                toolTip.SetToolTip(this, navigateBarButton.ToolTipText);
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!this.IsArrowButton)
            {
                this.PaintingType = PaintType.Normal;
                toolTip.RemoveAll();
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Space)
            {
                if (!this.IsArrowButton)
                {
                    e.Handled = true;
                    isSelected = true;
                    this.PaintingType = PaintType.Selected;
                    NavigateBarButton.PerformClick();
                }
            }
            else
                base.OnKeyUp(e);
        }

        #endregion

        #region Diğer Metodlar
        void PaintThisControl(Graphics tGraphics)
        {

            Image imageButton = null;
            switch (this.PaintingType)
            {
                case PaintType.Normal:
                    {
                        imageButton = isSelected ? navigateBarButton.SelectedImage : navigateBarButton.Image;
                        break;
                    }
                case PaintType.Selected:
                    {
                        imageButton = navigateBarButton.SelectedImage;
                        break;
                    }
                case PaintType.MouseOver:
                    {
                        imageButton = navigateBarButton.MouseOverImage;
                        break;
                    }
                case PaintType.Pressed:
                    {
                        imageButton = navigateBarButton.Image;
                        break;
                    }
            }
            // Gradient olarak boyama işlemi
            // Paint gradient

            NavigateBarHelper.PaintGradientBack(this, tGraphics,
                navigateBarButton.NavigateBar.NavigateBarColorTable,
                this.PaintingType);

            // Image

            // OverFlowPanelde mutlaka bir image gösterilmeli
            // Image must be on panel
            if (imageButton == null)
                imageButton = Properties.Resources.NoImage;

            if (!this.Enabled)
                imageButton = navigateBarButton.DisableImage;


            if (!this.IsArrowButton) // Draw image 
            {

                Size imgSize = new Size(16, 16);
                int left = (this.Width - imgSize.Width) / 2;
                int top = (this.Height - imgSize.Height) / 2 + 1;

                Rectangle r2 = new Rectangle(new Point(left, top), imgSize);

                tGraphics.DrawImage(imageButton, r2);
            }
            else // Draw Arrow
            {

                int halfHeight = this.Height / 2, halfWidth = this.Width / 2;

                // Office 2007
                if (this.NavigateBarButton.NavigateBar.NavigateBarColorTable.ContextMenuArrowStyle == ContextMenuArrowStyle.Office2007)
                {

                    // Draw triangles
                    SolidBrush brush = new SolidBrush(navigateBarButton.NavigateBar.NavigateBarColorTable.BorderColor);
                    SolidBrush brushShadow = new SolidBrush(Color.WhiteSmoke);

                    tGraphics.FillPolygon(brushShadow, new Point[] { 
                        new Point(halfWidth - ARROW_WIDTH /2 , halfHeight + 1), 
                        new Point(halfWidth + (int)Math.Ceiling((float)ARROW_WIDTH /2), halfHeight+ 1), 
                        new Point(halfWidth, halfHeight + ARROW_HEIGHT + 1) });

                    tGraphics.FillPolygon(brush, new Point[] { 
                        new Point(halfWidth - ARROW_WIDTH /2 , halfHeight), 
                        new Point(halfWidth + (int)Math.Ceiling((float)ARROW_WIDTH /2), halfHeight), 
                        new Point(halfWidth, halfHeight + ARROW_HEIGHT) });

                    brush.Dispose();
                    brushShadow.Dispose();
                }
                else // Office 2003
                {

                    SolidBrush brush = new SolidBrush(Color.Black);
                    Pen linePen = new Pen(brush, 1.6f);

                    const int ARROW_LINE_WIDTH = 2;
                    halfHeight -= 2;

                    if (this.NavigateBarButton.NavigateBar.RightToLeft == RightToLeft.Yes)
                    {
                        // <<

                        halfWidth -= 2;
                        tGraphics.DrawLine(linePen, new Point(halfWidth - 3, halfHeight), new Point(halfWidth - 1, halfHeight - ARROW_LINE_WIDTH));
                        tGraphics.DrawLine(linePen, new Point(halfWidth - 3, halfHeight), new Point(halfWidth - 1, halfHeight + ARROW_LINE_WIDTH));
                        //
                        tGraphics.DrawLine(linePen, new Point(halfWidth, halfHeight), new Point(halfWidth + ARROW_LINE_WIDTH, halfHeight - ARROW_LINE_WIDTH));
                        tGraphics.DrawLine(linePen, new Point(halfWidth, halfHeight), new Point(halfWidth + ARROW_LINE_WIDTH, halfHeight + ARROW_LINE_WIDTH));
                    }
                    else
                    {
                        // >>

                        tGraphics.DrawLine(linePen, new Point(halfWidth - ARROW_LINE_WIDTH, halfHeight - ARROW_LINE_WIDTH), new Point(halfWidth, halfHeight));
                        tGraphics.DrawLine(linePen, new Point(halfWidth - ARROW_LINE_WIDTH, halfHeight + ARROW_LINE_WIDTH), new Point(halfWidth, halfHeight));
                        //
                        tGraphics.DrawLine(linePen, new Point(halfWidth + 1, halfHeight - ARROW_LINE_WIDTH), new Point(halfWidth + 3, halfHeight));
                        tGraphics.DrawLine(linePen, new Point(halfWidth + 1, halfHeight + ARROW_LINE_WIDTH), new Point(halfWidth + 3, halfHeight));
                    }
                    //
                    halfHeight++;
                    // draw triangle
                    tGraphics.FillPolygon(brush, new Point[] { 
                        new Point(halfWidth - ARROW_WIDTH /2 , halfHeight + 5), 
                        new Point(halfWidth + (int)Math.Ceiling((float)ARROW_WIDTH /2), halfHeight +5), 
                        new Point(halfWidth, halfHeight + ARROW_HEIGHT + 5) });

                    brush.Dispose();
                }

            }
        }
        #endregion

    }
}
