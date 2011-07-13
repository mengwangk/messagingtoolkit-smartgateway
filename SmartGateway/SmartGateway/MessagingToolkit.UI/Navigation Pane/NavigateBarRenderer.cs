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
using System.Drawing.Drawing2D;
using System.Drawing;

namespace MessagingToolkit.UI
{

    #region NavigateBarRenderer
    /// <summary>
    /// Renderer for navigatebar contextmenus
    /// </summary>
    class NavigateBarRenderer : ToolStripRenderer
    {

        #region Properties
        NavigateBarColorTable colorTable;
        public NavigateBarColorTable ColorTable
        {
            get { return colorTable; }
            set { colorTable = value; }
        }
        #endregion

        #region Constructor Method
        public NavigateBarRenderer(NavigateBarColorTable tColorTable)
        {
            colorTable = tColorTable;
        }
        #endregion

        #region OnRenderItemCheck
        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemCheck(e);
            if (e.Item is ToolStripMenuItem)
            {
                Rectangle r = e.ImageRectangle;
                r.Inflate(2, 2);
                if ((e.Item as ToolStripMenuItem).Checked)
                {
                    PaintItem(e.Graphics, r, ColorTable.ButtonSelectedMiddleBegin, ColorTable.ButtonSelectedMiddleBegin);
                }
                else
                    ControlPaint.DrawImageDisabled(e.Graphics, e.Image, e.ImageRectangle.X, e.ImageRectangle.Y, Color.Transparent);
            }
        }
        #endregion

        #region OnRenderItemText
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? ColorTable.SelectedTextColor : ColorTable.TextColor;
        }
        #endregion

        #region OnRenderMenuItemBackground
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);

            Rectangle r = e.Item.ContentRectangle;
            if (r.Width == 0 || r.Height == 0)
                return;

            Color cBegin = ColorTable.MenuBackColor;
            Color cMiddleTop = ColorTable.MenuBackColor;
            Color cMiddleEnd = ColorTable.MenuBackColor;
            Color cEnd = ColorTable.MenuBackColor;

            if (e.Item.Enabled)
            {
                if (e.Item.Selected)
                {
                    cBegin = ColorTable.ButtonMouseOverBegin;
                    cMiddleTop = ColorTable.ButtonMouseOverMiddleBegin;
                    cMiddleEnd = ColorTable.ButtonMouseOverMiddleEnd;
                    cEnd = ColorTable.ButtonMouseOverEnd;
                }
                else if (e.Item.Pressed)
                {
                    cBegin = ColorTable.ButtonSelectedBegin;
                    cMiddleTop = ColorTable.ButtonSelectedMiddleBegin;
                    cMiddleEnd = ColorTable.ButtonSelectedMiddleEnd;
                    cEnd = ColorTable.ButtonSelectedEnd;
                }
            }

            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Colors = new Color[] { cBegin, cMiddleTop, cMiddleEnd, cEnd };
            colorBlend.Positions = new float[] { 0.0f, ColorTable.PaintRatio, ColorTable.PaintRatio, 1.0f };

            using (LinearGradientBrush lgb = new LinearGradientBrush(r, cBegin, cEnd, ColorTable.PaintAngle))
            {
                lgb.InterpolationColors = colorBlend;
                e.Graphics.FillRectangle(lgb, r);
            }

            if (e.Item.Selected || e.Item.Pressed)
                e.Graphics.DrawRectangle(new Pen(e.Item.Enabled ? ColorTable.ButtonSelectedEnd : ColorTable.BorderColor), r);

        }
        #endregion

        #region OnRenderSeparator
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            base.OnRenderSeparator(e);

            PaintItem(e.Graphics, e.Item.ContentRectangle,
                ColorTable.ButtonNormalEnd,
                ColorTable.ButtonNormalEnd);
        }
        #endregion

        #region OnRenderToolStripBackground
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBackground(e);
            PaintItem(e.Graphics, e.ToolStrip.ClientRectangle,
                ColorTable.MenuBackColor,
                ColorTable.MenuBackColor);
        }
        #endregion

        #region PaintThis
        void PaintItem(Graphics g, Rectangle r, Color c1, Color c2)
        {
            if (r.IsEmpty)
                return;

            using (LinearGradientBrush lgb = new LinearGradientBrush(r,
              c1, c2, 90F))
            {
                g.FillRectangle(lgb, r);
            }
        }
        #endregion
    }
    #endregion

}
