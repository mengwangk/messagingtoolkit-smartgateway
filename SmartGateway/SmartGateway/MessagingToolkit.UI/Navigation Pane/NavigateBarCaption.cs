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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MessagingToolkit.UI
{
    #region Class : NavigateBarCaption

    [Browsable(false)]
    [ToolboxItem(false)]
    class NavigateBarCaption : UserControl
    {

        const int SPLIT_WIDTH = 3;

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

        #region Image
        Image image = null;
        public Image Image
        {
            get { return image; }
            set { image = value; }
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

        #region CollapseButton
        public NavigateBarCollapseButton CollapseButton
        {
            get { return collapseButton; }
        }
        #endregion

        #region CollapseMode
        private bool collapseMode = true;
        public bool CollapseMode
        {
            get { return collapseMode; }
            set
            {
                collapseMode = value;
                CollapseButton.IsExpandArrow = !collapseMode;
                CollapseButton.Invalidate();
            }
        }
        #endregion

        NavigateBarCollapseButton collapseButton;

        #region Constructor Method
        public NavigateBarCaption(NavigateBar tNavigateBar)
        {
            navigateBar = tNavigateBar;
            // Control
            this.Height = 24;
            this.Dock = DockStyle.Top;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            // Collapse Button
            collapseButton = new NavigateBarCollapseButton(navigateBar);
            this.CollapseMode = true;
            SetNewPositionForCollapseButton();
            collapseButton.Top = (this.Height - collapseButton.Size.Height) / 2;
            collapseButton.MouseClick += new MouseEventHandler(CollapseButton_MouseClick);

            //
            this.Controls.Add(collapseButton);

        }
        #endregion

        #region CollapseButton

        void CollapseButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            this.Invalidate();
            navigateBar.ChangeCollapseMode(collapseMode);
        }

        void SetNewPositionForCollapseButton()
        {

            if (this.NavigateBar.RightToLeft == RightToLeft.Yes)
            {
                collapseButton.Left = SPLIT_WIDTH;
            }
            else
            {
                collapseButton.Left = this.Width - collapseButton.Size.Width - SPLIT_WIDTH;
            }
        }

        #endregion

        #region Overrided Method

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            collapseButton.Invalidate();
            SetNewPositionForCollapseButton();
            base.OnInvalidated(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            PaintThisControl(e.Graphics);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (collapseButton != null)
                SetNewPositionForCollapseButton();

            Invalidate();
        }
        #endregion

        #region Other Metods

        void PaintThisControl(Graphics g)
        {

            // Gradient olarak boyama işlemi // Paint gradient

            NavigateBarHelper.PaintGradientControl(this, g,
                NavigateBar.NavigateBarColorTable.CaptionBegin,
                NavigateBar.NavigateBarColorTable.CaptionEnd,
                NavigateBar.NavigateBarColorTable.PaintAngle);

            //

            Size imgSize = new Size(16, 16);

            Pen penBorder = new Pen(navigateBar.NavigateBarColorTable.BorderColor);

            // Image

            if (image != null)
            {
                int halfHeight = ((this.Height - imgSize.Height) / 2);
                if (this.NavigateBar.RightToLeft == RightToLeft.Yes)
                    g.DrawImage(image, new Rectangle(new Point(this.Width - imgSize.Width - SPLIT_WIDTH - 2, halfHeight), imgSize));
                else
                    g.DrawImage(image, new Rectangle(new Point(SPLIT_WIDTH + 2, halfHeight), imgSize));

            }

            // Yazıyı yazma  // Draw caption text

            Font font = new Font(SystemFonts.CaptionFont.Name, 10, FontStyle.Bold);
            int capWidth = (int)g.MeasureString(this.Caption, font).Width;
            Brush captionColor = new SolidBrush(navigateBar.NavigateBarColorTable.CaptionTextColor);

            if (this.NavigateBar.RightToLeft == RightToLeft.Yes)
                g.DrawString(this.Caption, font, captionColor,
                    this.Width - capWidth - SPLIT_WIDTH * 2 - (image == null ? SPLIT_WIDTH * 2 : imgSize.Width + SPLIT_WIDTH), (this.Height - font.GetHeight()) / 2);
            else
                g.DrawString(this.Caption, font, captionColor,
                    image == null ? SPLIT_WIDTH * 2 : imgSize.Width + SPLIT_WIDTH * 2, (this.Height - font.GetHeight()) / 2);

            // Etrafın çizgisi // Draw rectangle

            if (this.CollapseMode) // Sadece başlık durumunda // only caption
                if (navigateBar.SelectedButton != null)
                    g.DrawRectangle(penBorder, new Rectangle(0, 0, Width - 1, Height - (navigateBar.SelectedButton.IsShowCaptionDescription ? 0 : 1)));
                else
                    g.DrawRectangle(penBorder, new Rectangle(0, 0, Width - 1, Height - 1));
            else // Başlık ve Daraltılmış durumda // Collapse and caption
                g.DrawRectangle(penBorder, new Rectangle(-1, 0, Width + 1, Height - 1));


        }
        #endregion

    }

    #endregion
}
