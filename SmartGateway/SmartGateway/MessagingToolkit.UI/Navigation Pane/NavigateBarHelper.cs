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
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Microsoft.Win32;

namespace MessagingToolkit.UI
{
    class NavigateBarHelper
    {

        #region IsXPOrAbove
        /// <summary>
        /// Is XP or above os
        /// </summary>
        public static bool IsXPOrAbove
        {
            get
            {
                return (Environment.OSVersion.Platform == PlatformID.Win32NT) && Environment.OSVersion.Version.CompareTo(new Version(5, 1, 0, 0)) >= 0;
            }
        }
        #endregion

        #region CreateUniqKey
        /// <summary>
        /// Generate a uniq key for button's key property
        /// </summary>
        /// <returns></returns>
        public static string CreateUniqKey()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }
        #endregion

        #region PaintGradientControl

        /// <summary>
        /// Paint gradient
        /// </summary>
        /// <param name="tControl">Painting control</param>
        /// <param name="tGraphics">Graphic</param>
        /// <param name="tLightColor">Light Color</param>
        /// <param name="tDarkColor">Dark Color</param>
        /// <param name="tAngle">Angle for painting</param>
        public static void PaintGradientControl(Control tControl, Graphics tGraphics, Color tLightColor, Color tDarkColor, float tAngle)
        {

            Rectangle r = tControl.ClientRectangle;

            if (r.Width == 0 || r.Height == 0)
                return;
            using (LinearGradientBrush lgb = new LinearGradientBrush(r, tLightColor, tDarkColor, tAngle))
            {
                tGraphics.FillRectangle(lgb, r);
            }

        }

        /// <summary>
        /// Paint gradient
        /// </summary>
        /// <param name="tControl"></param>
        /// <param name="tGraphics"></param>
        /// <param name="tTopColorBegin"></param>
        /// <param name="tTopColorEnd"></param>
        /// <param name="tBottomColorBegin"></param>
        /// <param name="tBottomColorEnd"></param>
        /// <param name="tAngle"></param>
        /// <param name="tPaintRatio"></param>
        public static void PaintGradientControl(
            Control tControl, Graphics tGraphics,
            Color tTopColorBegin, Color tTopColorEnd,
            Color tBottomColorBegin, Color tBottomColorEnd,
            float tAngle, float tPaintRatio)
        {

            if (tControl.ClientRectangle.Width == 0 || tControl.ClientRectangle.Height == 0)
                return;

            Rectangle r = new Rectangle(-1, 0, tControl.Width + 1, tControl.Height);
            //Rectangle r = tControl.ClientRectangle;

            tGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            tGraphics.CompositingQuality = CompositingQuality.HighQuality;
            tGraphics.SmoothingMode = SmoothingMode.HighQuality;
            tGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Colors = new Color[] { tTopColorBegin, tTopColorEnd, tBottomColorBegin, tBottomColorEnd };
            colorBlend.Positions = new float[] { 0.0f, tPaintRatio, tPaintRatio, 1.0f };

            using (LinearGradientBrush lgb = new LinearGradientBrush(r, tTopColorBegin, tBottomColorEnd, tAngle))
            {
                lgb.InterpolationColors = colorBlend;
                tGraphics.FillRectangle(lgb, r);
            }

        }

        #endregion

        #region PaintGradientBack
        /// <summary>
        /// Paint Gradient
        /// </summary>
        /// <param name="tControl">Painting control</param>
        /// <param name="tGraphics">Graphic object</param>
        /// <param name="tColorTable">NavigataBarColorTable inherited object</param>
        /// <param name="tPaintType">Paint type</param>
        public static void PaintGradientBack(Control tControl, Graphics tGraphics, NavigateBarColorTable tColorTable, PaintType tPaintType)
        {

            if (tControl.ClientRectangle.IsEmpty)
                return;

            #region Color Select

            Color cTopColorBegin = tColorTable.ButtonNormalBegin;
            Color cTopColorEnd = tColorTable.ButtonNormalMiddleBegin;
            Color cBottomColorBegin = tColorTable.ButtonNormalMiddleEnd;
            Color cBottomColorEnd = tColorTable.ButtonNormalEnd;

            switch (tPaintType)
            {
                case PaintType.Selected:
                    {
                        cTopColorBegin = tColorTable.ButtonSelectedBegin;
                        cTopColorEnd = tColorTable.ButtonSelectedMiddleBegin;
                        cBottomColorBegin = tColorTable.ButtonSelectedMiddleEnd;
                        cBottomColorEnd = tColorTable.ButtonSelectedEnd;

                        break;
                    }
                case PaintType.MouseOver:
                    {
                        cTopColorBegin = tColorTable.ButtonMouseOverBegin;
                        cTopColorEnd = tColorTable.ButtonMouseOverMiddleBegin;
                        cBottomColorBegin = tColorTable.ButtonMouseOverMiddleEnd;
                        cBottomColorEnd = tColorTable.ButtonMouseOverEnd;

                        break;
                    }

                case PaintType.Pressed:
                    {
                        cTopColorBegin = tColorTable.ButtonSelectedEnd;
                        cTopColorEnd = tColorTable.ButtonSelectedMiddleBegin;
                        cBottomColorBegin = tColorTable.ButtonSelectedMiddleEnd;
                        cBottomColorEnd = tColorTable.ButtonSelectedMiddleEnd;

                        break;
                    }

            }
            #endregion

            NavigateBarHelper.PaintGradientControl(tControl, tGraphics, cTopColorBegin, cTopColorEnd, cBottomColorBegin, cBottomColorEnd, tColorTable.PaintAngle, tColorTable.PaintRatio);
        }

        #endregion

        #region ConvertToGrayscale
        /// <summary>
        /// Convert image gray style
        /// </summary>
        /// <param name="tSourceBitmap">Bitmap source</param>
        /// <returns></returns>
        public static Bitmap ConvertToGrayscale(Bitmap tSourceBitmap)
        {

            Bitmap bitmap = new Bitmap(tSourceBitmap.Width, tSourceBitmap.Height);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color color = tSourceBitmap.GetPixel(x, y);
                    int luma = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    bitmap.SetPixel(x, y, Color.FromArgb(luma, luma, luma));
                }
            }

            bitmap.MakeTransparent(); // Convert transparent

            return bitmap;
        }
        #endregion

        #region GetColorTableForWindowsTheme
        /// <summary>
        /// Get color table for Windows theme( only XP )
        /// </summary>
        /// <returns></returns>
        public static NavigateBarColorTable GetColorTableForWindowsTheme()
        {

            NavigateBarColorTable themeColorTable = NavigateBarColorTable.SystemColor;

            // XP

            if ((Environment.OSVersion.Platform == PlatformID.Win32NT) && Environment.OSVersion.Version.CompareTo(new Version(5, 1, 0, 0)) != 0)
                return themeColorTable;

            RegistryKey themeKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\ThemeManager");

            if (themeKey == null)
                return themeColorTable;

            if (!themeKey.GetValue("ThemeActive").ToString().Equals("1"))
                themeColorTable = NavigateBarColorTable.SystemColor;

            if (themeKey.GetValue("ColorName").ToString().Equals("NormalColor"))
                themeColorTable = NavigateBarColorTable.Office2003Blue;

            if (themeKey.GetValue("ColorName").ToString().Equals("Metallic"))
                themeColorTable = NavigateBarColorTable.Office2003Silver;

            if (themeKey.GetValue("ColorName").ToString().Equals("HomeStead"))
                themeColorTable = NavigateBarColorTable.Office2003Olive;

            return themeColorTable;

        }

        #endregion

    }
}
