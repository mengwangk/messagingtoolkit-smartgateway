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
using System.ComponentModel;

using MessagingToolkit.UI.Design;

namespace MessagingToolkit.UI
{
    /// <summary>
    /// Show related control on this panel
    /// </summary>
    class NavigateBarControlPanel : UserControl
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

        public NavigateBarControlPanel()
        {

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw, true);
        }

        #region Overrided Methodlar

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.Controls.Count == 0 && !this.DesignMode)
            {
                base.OnPaintBackground(e);

                NavigateBarHelper.PaintGradientControl(this, e.Graphics,
                    navigateBar.NavigateBarColorTable.ButtonNormalBegin,
                    navigateBar.NavigateBarColorTable.ButtonNormalEnd,
                    navigateBar.NavigateBarColorTable.PaintAngle);
            }
        }
        #endregion
    }
}
