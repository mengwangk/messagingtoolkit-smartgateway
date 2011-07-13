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
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MessagingToolkit.UI
{
    #region Class : NavigateBarCaptionDescription

    [Browsable(false)]
    [ToolboxItem(false)]
    class NavigateBarCaptionDescription : UserControl
    {

        #region Caption
        private string caption = "";
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                Invalidate();
            }
        }
        #endregion

        #region NavigateBar
        NavigateBar navigateBar = null;
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

        #region Yapıcı Metod
        public NavigateBarCaptionDescription()
        {
            // Control
            this.Height = 20;
            this.Dock = DockStyle.Top;
            this.TabStop = false;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

        }
        #endregion

        #region Overrided Method
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            PaintThisControl(e.Graphics);
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }
        #endregion

        #region Diğer Metodlar
        void PaintThisControl(Graphics g)
        {

            NavigateBarHelper.PaintGradientControl(this, g,
                navigateBar.NavigateBarColorTable.CaptionDescBegin,
                navigateBar.NavigateBarColorTable.CaptionDescEnd,
                navigateBar.NavigateBarColorTable.PaintAngle);

            // Gradient olarak boyama işlemi
            // Paint gradient


            // Yazıyı yazma
            // Draw caption description text

            int capWidth = (int)g.MeasureString(Caption, SystemFonts.DialogFont).Width;
            g.DrawString(Caption,
                new Font(SystemFonts.DialogFont.Name, 8, FontStyle.Regular),
                new SolidBrush(navigateBar.NavigateBarColorTable.TextColor),
                (this.NavigateBar.RightToLeft == RightToLeft.Yes ? this.Width - capWidth - 8 : 8),
                (this.Height - SystemFonts.DialogFont.Height) / 2);


            // Etrafın çizgisi
            // Draw rectangle

            g.DrawRectangle(new Pen(navigateBar.NavigateBarColorTable.BorderColor), new Rectangle(0, 0, Width - 1, Height - 1));


        }
        #endregion

    }

    #endregion
}
