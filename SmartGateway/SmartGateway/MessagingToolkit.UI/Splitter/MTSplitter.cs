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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace MessagingToolkit.UI
{
    /// <summary>
    /// Splitter
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.Splitter))]
    [Description("3D Splitter")]
    public class MTSplitter : Splitter
    {

        #region SplitterLightColor
        private Color splitterLightColor = ProfessionalColors.SeparatorLight;
        /// <summary>
        /// Get/Set, Splitter
        /// </summary>
        [Browsable(true)]
        [Description("Splitter")]
        [Category("MT Control")]
        [DefaultValue(typeof(Color), "ProfessionalColors.SeparatorLight")]
        public Color SplitterLightColor
        {
            get { return splitterLightColor; }
            set
            {
                splitterLightColor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region SplitterDarkColor
        private Color splitterDarkColor = ProfessionalColors.SeparatorDark;
        /// <summary>
        /// Get/Set, Splitter
        /// </summary>
        [Browsable(true)]
        [Description("Splitter")]
        [Category("MT Control")]
        [DefaultValue(typeof(Color), "ProfessionalColors.SeparatorDark")]
        public Color SplitterDarkColor
        {
            get { return splitterDarkColor; }
            set
            {
                splitterDarkColor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region SplitterBorderColor
        private Color splitterBorderColor = Color.Transparent;
        /// <summary>
        /// Get/Set, Splitter
        /// </summary>
        [Browsable(true)]
        [Description("Splitter")]
        [Category("MT Control")]
        [DefaultValue(typeof(Color), "ProfessionalColors.SeparatorDark")]
        public Color SplitterBorderColor
        {
            get { return splitterBorderColor; }
            set
            {
                splitterBorderColor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region SplitterPointCount
        int splitterPointCount = 5;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [Description("Splitter")]
        [Category("MT Control")]
        [DefaultValue(5)]
        public int SplitterPointCount
        {
            get { return splitterPointCount; }
            set
            {
                splitterPointCount = value;
                this.Invalidate();
            }
        }
        #endregion

        #region PaintAngle
        private float splitterPaintAngle = 90F;
        /// <summary>
        /// Get/Set, Splitter boyama açısı
        /// </summary>
        [Browsable(true)]
        [Description("Splitter")]
        [Category("MT Control")]
        public float SplitterPaintAngle
        {
            get { return splitterPaintAngle; }
            set
            {
                splitterPaintAngle = value;
                this.Invalidate();
            }
        }
        #endregion

        #region

        public MTSplitter()
        {
            this.Size = new Size(4, 100);

            this.SetCursorStyle();

            // DockStyle 
            this.DockChanged += delegate
            {
                this.SetCursorStyle();
            };

            // 
            this.SystemColorsChanged += delegate
            {
                this.SplitterDarkColor = ProfessionalColors.SeparatorDark;
                this.SplitterLightColor = ProfessionalColors.SeparatorLight;
            };

            // 
            this.Resize += delegate(object sender, EventArgs e)
            {
                this.Invalidate();
            };

        }


        void SetCursorStyle()
        {
            // Cursor doc

            if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right) 
                Cursor = Cursors.SizeWE;
            else if (this.Dock == DockStyle.Bottom || this.Dock == DockStyle.Top) 
                Cursor = Cursors.SizeNS;
            else
                Cursor = Cursors.Default; 
        }

        #endregion

        #region OnPaintBackground : Splitter
        /// <summary>
        /// Splitter 
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

            base.OnPaintBackground(pevent);

            Rectangle splitRectangle = this.ClientRectangle;

            if (!(splitRectangle.Width > 0 && splitRectangle.Height > 0))
                return;
                        

            Brush k = new SolidBrush(this.SplitterDarkColor);
            Brush a = new SolidBrush(this.SplitterLightColor);

           
            if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right) //
            {
                // Splitter 3D 
                using (Brush b = new LinearGradientBrush(splitRectangle, this.SplitterLightColor, this.SplitterDarkColor, this.SplitterPaintAngle))
                {
                    pevent.Graphics.FillRectangle(b, splitRectangle);
                }

                int nB = 5, nY = 2;
                int nk = (splitRectangle.Height - (this.SplitterPointCount * nB)) / 2;
                int nLeft = (int)(this.Width / 2);

                //
                for (int i = 0; i < this.SplitterPointCount; i++)
                {
                    
                    pevent.Graphics.FillRectangle(k, nLeft, nk, nY, nY);
               
                    pevent.Graphics.FillRectangle(a, nLeft, nk + 1, nY, nY);
                 
                    pevent.Graphics.FillRectangle(SystemBrushes.GrayText, nLeft, nk - 1, nY, nY);
                    nk += nB;
                }


            }
            else if (this.Dock == DockStyle.Bottom || this.Dock == DockStyle.Top) 
            {

                using (Brush b = new LinearGradientBrush(splitRectangle, this.SplitterLightColor, this.SplitterDarkColor, this.SplitterPaintAngle))
                {
                    pevent.Graphics.FillRectangle(b, splitRectangle);
                }

                int nB = 4, nY = 2;
                int nk = (splitRectangle.Width - (this.SplitterPointCount * nB)) / 2;
                int Y = (int)((splitRectangle.Height - 1) / 2);
                             
                for (int i = 0; i < this.SplitterPointCount; i++)
                {
                    pevent.Graphics.FillRectangle(k, nk, Y, nY, nY);
                    pevent.Graphics.FillRectangle(a, nk + 1, Y + 1, nY, nY);
                    pevent.Graphics.FillRectangle(SystemBrushes.GrayText, nk + 1, Y, nY, nY);

                    nk += nB;
                }

            }

            pevent.Graphics.DrawRectangle(new Pen(this.SplitterBorderColor),
                new Rectangle(0, 0, Width - 1, Height));


            if (k is IDisposable)
                k.Dispose();

            if (a is IDisposable)
                a.Dispose();

        }

        #endregion

    }
}
