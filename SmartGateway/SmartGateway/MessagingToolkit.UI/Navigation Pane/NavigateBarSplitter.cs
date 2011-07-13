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

namespace MessagingToolkit.UI
{
    /// <summary>
    /// Splitter control for NavigateBar
    /// </summary>
    class NavigateBarSplitter : Panel
    {

        NavigateBar navigateBar = null;
        int splitterPointCount = 5;

        public NavigateBarSplitter(NavigateBar tNavigateBar)
        {
            navigateBar = tNavigateBar;
            this.Height = 6;
            this.Width = 120;
            this.Cursor = Cursors.SizeNS;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            if (navigateBar == null)
                return;

            Rectangle splitRectangle = this.ClientRectangle;
            Brush darkColor = new SolidBrush(navigateBar.NavigateBarColorTable.BorderColor);
            Brush lightColor = new SolidBrush(navigateBar.NavigateBarColorTable.SeparatorLight);

            NavigateBarHelper.PaintGradientControl(this, e.Graphics,
                navigateBar.NavigateBarColorTable.SeparatorLight,
                navigateBar.NavigateBarColorTable.SeparatorDark,
                navigateBar.NavigateBarColorTable.PaintAngle);

            // Point Position
            int pointWidth = 4, pointHeight = 2;
            int firstPointPos = (splitRectangle.Width - (splitterPointCount * pointWidth + this.splitterPointCount)) / 2;
            int Y = (int)((splitRectangle.Height - 1) / 2);

            // Draw Points
            for (int i = 0; i < this.splitterPointCount; i++)
            {
                e.Graphics.FillRectangle(darkColor, firstPointPos, Y, pointHeight, pointHeight);
                e.Graphics.FillRectangle(lightColor, firstPointPos + 1, Y + 1, pointHeight, pointHeight);
                e.Graphics.FillRectangle(SystemBrushes.GrayText, firstPointPos + 1, Y, pointHeight, pointHeight);

                firstPointPos += pointWidth + 1;
            }

            splitRectangle.Width--;
            e.Graphics.DrawRectangle(new Pen(navigateBar.NavigateBarColorTable.BorderColor), splitRectangle);

        }

    }
}
