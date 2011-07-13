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
using System.ComponentModel;

namespace MessagingToolkit.UI
{

    #region NavigateBarColorTable
    /// <summary>
    /// Color table for Navigation Pane and subcontrols
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class NavigateBarColorTable
    {

        #region Static Color Tables
        static NavigateBarColorTable systemColor = new NavigateBarColorTable();
        /// <summary>
        /// Systemcolor based theme
        /// </summary>
        [Category("Color Tables")]
        public static NavigateBarColorTable SystemColor
        {
            get { return systemColor; }
        }

        static Office2003Blue office2003Blue = new Office2003Blue();
        /// <summary>
        /// Office 2003 blue based theme
        /// </summary>
        [Category("Color Tables")]
        public static NavigateBarColorTable Office2003Blue
        {
            get { return office2003Blue; }
        }

        static Office2003Silver office2003Silver = new Office2003Silver();
        /// <summary>
        /// Office 2003 style silver based theme
        /// </summary>
        [Category("Color Tables")]
        public static NavigateBarColorTable Office2003Silver
        {
            get { return office2003Silver; }
        }

        static Office2003Olive office2003Olive = new Office2003Olive();
        /// <summary>
        /// Office 2003 style green based theme
        /// </summary>
        [Category("Color Tables")]
        public static NavigateBarColorTable Office2003Olive
        {
            get { return office2003Olive; }
        }

        static Office2007Blue office2007Blue = new Office2007Blue();
        /// <summary>
        /// Office 2003 style blue based theme
        /// </summary>
        [Category("Color Tables")]
        public static NavigateBarColorTable Office2007Blue
        {
            get { return office2007Blue; }
        }

        static Office2007Black office2007Black = new Office2007Black();
        /// <summary>
        /// Office 2007 style black based theme
        /// </summary>
        [Category("Color Tables")]
        public static NavigateBarColorTable Office2007Black
        {
            get { return office2007Black; }
        }

        static Office2007Silver office2007Silver = new Office2007Silver();
        /// <summary>
        /// Office 2007 style silver based theme
        /// </summary>
        [Category("Color Tables")]
        public static NavigateBarColorTable Office2007Silver
        {
            get { return office2007Silver; }
        }
        #endregion

        #region Custom Properties

        ContextMenuArrowStyle arrowStyle = ContextMenuArrowStyle.Office2007;
        /// <summary>
        /// Overflow panel context menu arrow style
        /// </summary>
        [Description("Overflow panel context menu arrow style")]
        [DefaultValue(typeof(ContextMenuArrowStyle),"Office2007")]
        [Category("Customize")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContextMenuArrowStyle ContextMenuArrowStyle
        {
            get { return arrowStyle; }
            set { arrowStyle = value; }
        }

        float paintRatio = (float)0.50;
        /// <summary>
        /// Paint ratio for NavigateBar and sub-controls
        /// </summary>
        [Description("Paint ratio for NavigateBar and sub-controls")]
        [DefaultValue(0.50)]
        [Category("Customize")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float PaintRatio
        {
            get { return paintRatio; }
            set {
                if (value < 0 || value > 1)
                    throw new ArgumentException("value not 0 between 1");
                paintRatio = value; }
        }

        float paintAngle = 90F;
        /// <summary>
        /// Paint angle for NavigateBar and sub-controls
        /// </summary>
        [Description("Paint angle for NavigateBar and sub-controls")]
        [Category("Customize")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float PaintAngle
        {
            get { return paintAngle; }
            set { paintAngle = value; }
        }

        Color textColor = SystemColors.ControlText;
        /// <summary>
        /// Button text color
        /// </summary>
        [Description("Button text color")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        Color selectedTextColor = SystemColors.ControlText;
        /// <summary>
        /// Button selected text color
        /// </summary>
        [Description("Button selected text color")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color SelectedTextColor
        {
            get { return selectedTextColor; }
            set { selectedTextColor = value; }
        }

        Color borderColor = ProfessionalColors.ButtonSelectedHighlightBorder;
        /// <summary>
        /// Button and container out rectangle border color
        /// </summary>
        [Description("Button and container out rectangle border color")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        #endregion

        #region Caption

        Color captionTextColor = Color.Black;
        /// <summary>
        /// Caption band text color
        /// </summary>
        [Description("Caption band text color")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color CaptionTextColor
        {
            get { return captionTextColor; }
            set { captionTextColor = value; }
        }

        Color captionBegin = ProfessionalColors.ToolStripGradientBegin;
        /// <summary>
        /// Caption band gradient color begin
        /// </summary>
        [Description("Caption band gradient color begin")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color CaptionBegin
        {
            get { return captionBegin; }
            set { captionBegin = value; }
        }

        Color captionEnd = ProfessionalColors.ToolStripGradientEnd;
        /// <summary>
        /// Caption band gradient color end
        /// </summary>
        [Description("Caption band gradient color end")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color CaptionEnd
        {
            get { return captionEnd; }
            set { captionEnd = value; }
        }

        Color captionDescBegin = ProfessionalColors.ToolStripGradientBegin;
        /// <summary>
        /// Caption description band gradient color begin
        /// </summary>
        [Description("Caption description band gradient color begin")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color CaptionDescBegin
        {
            get { return captionDescBegin; }
            set { captionDescBegin = value; }
        }

        Color captionDescEnd = ProfessionalColors.ToolStripGradientEnd;
        /// <summary>
        /// Caption description band gradient color end
        /// </summary>
        [Description("Caption description band gradient color end")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color CaptionDescEnd
        {
            get { return captionDescEnd; }
            set { captionDescEnd = value; }
        }
        #endregion

        #region Separator

        Color separatorDark = ProfessionalColors.SeparatorDark;
        /// <summary>
        /// Separator gradient color end
        /// </summary>
        [Description("Separator gradient color end")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color SeparatorDark
        {
            get { return separatorDark; }
            set { separatorDark = value; }
        }

        Color separatorLight = ProfessionalColors.SeparatorLight;
        /// <summary>
        /// Separator gradient color begin
        /// </summary>
        [Description("Separator gradient color begin")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color SeparatorLight
        {
            get { return separatorLight; }
            set { separatorLight = value; }
        }

        #endregion

        #region Button Normal

        Color buttonNormalBegin = ProfessionalColors.ToolStripGradientBegin;
        /// <summary>
        /// Button gradient color begin
        /// </summary>
        [Description("Button gradient color begin")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonNormalBegin
        {
            get { return buttonNormalBegin; }
            set { buttonNormalBegin = value; }
        }

        Color buttonNormalMiddleBegin = ProfessionalColors.ToolStripGradientMiddle;
        /// <summary>
        /// Button gradient color middle color begin
        /// </summary>
        [Description("Button gradient color middle color begin")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonNormalMiddleBegin
        {
            get { return buttonNormalMiddleBegin; }
            set { buttonNormalMiddleBegin = value; }
        }

        Color buttonNormalMiddleEnd = ProfessionalColors.ToolStripGradientMiddle;
        /// <summary>
        /// Button gradient color middle color end
        /// </summary>
        [Description("Button gradient color middle color end")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonNormalMiddleEnd
        {
            get { return buttonNormalMiddleEnd; }
            set { buttonNormalMiddleEnd = value; }
        }

        Color buttonNormalEnd = ProfessionalColors.ToolStripGradientEnd;
        /// <summary>
        /// Button gradient color end 
        /// </summary>
        [Description("Button gradient color end")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonNormalEnd
        {
            get { return buttonNormalEnd; }
            set { buttonNormalEnd = value; }
        }

        #endregion

        #region Button Selected

        Color buttonSelectedBegin = ProfessionalColors.ButtonPressedGradientBegin;
        /// <summary>
        /// Button selected gradient color begin
        /// </summary>
        [Description("Button selected gradient color begin")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonSelectedBegin
        {
            get { return buttonSelectedBegin; }
            set { buttonSelectedBegin = value; }
        }

        Color buttonSelectedMiddleBegin = ProfessionalColors.ButtonPressedGradientMiddle;
        /// <summary>
        /// Button selected gradient color middle color begin
        /// </summary>
        [Description("Button selected gradient color middle color begin")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonSelectedMiddleBegin
        {
            get { return buttonSelectedMiddleBegin; }
            set { buttonSelectedMiddleBegin = value; }
        }

        Color buttonSelectedMiddleEnd = ProfessionalColors.ButtonPressedGradientMiddle;
        /// <summary>
        /// Button selected gradient color middle color end
        /// </summary>
        [Description("Button selected gradient color middle color end")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonSelectedMiddleEnd
        {
            get { return buttonSelectedMiddleEnd; }
            set { buttonSelectedMiddleEnd = value; }
        }

        Color buttonSelectedEnd = ProfessionalColors.ButtonPressedGradientEnd;
        /// <summary>
        /// Button selected gradient color end
        /// </summary>
        [Description("Button selected gradient color end")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonSelectedEnd
        {
            get { return buttonSelectedEnd; }
            set { buttonSelectedEnd = value; }
        }

        #endregion

        #region Button Mouse Over

        Color buttonMouseOverBegin = ProfessionalColors.ButtonSelectedGradientBegin;
        /// <summary>
        /// Button mouse over gradient color begin
        /// </summary>
        [Description("Button mouse over gradient color begin")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonMouseOverBegin
        {
            get { return buttonMouseOverBegin; }
            set { buttonMouseOverBegin = value; }
        }

        Color buttonMouseOverMiddleBegin = ProfessionalColors.ButtonSelectedGradientMiddle;
        /// <summary>
        /// Button mouse over gradient color middle color begin
        /// </summary>
        [Description("Button mouse over gradient color middle color begin")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonMouseOverMiddleBegin
        {
            get { return buttonMouseOverMiddleBegin; }
            set { buttonMouseOverMiddleBegin = value; }
        }

        Color buttonMouseOverMiddleEnd = ProfessionalColors.ButtonSelectedGradientMiddle;
        /// <summary>
        /// Button mouse over gradient color middle color end
        /// </summary>
        [Description("Button mouse over gradient color middle color end")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonMouseOverMiddleEnd
        {
            get { return buttonMouseOverMiddleEnd; }
            set { buttonMouseOverMiddleEnd = value; }
        }

        Color buttonMouseOverEnd = ProfessionalColors.ButtonSelectedGradientEnd;
        /// <summary>
        /// Button mouse over gradient color end
        /// </summary>
        [Description("Button mouse over gradient color end")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color ButtonMouseOverEnd
        {
            get { return buttonMouseOverEnd; }
            set { buttonMouseOverEnd = value; }
        }

        #endregion

        #region Menu
        Color menuBackColor = ProfessionalColors.ToolStripDropDownBackground;
        /// <summary>
        /// Context menu item back color
        /// </summary>
        [Description("Context menu item back color")]
        [Category("Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color MenuBackColor
        {
            get { return menuBackColor; }
            set { menuBackColor = value; }
        }
        #endregion

        #region Methods
        public static NavigateBarColorTable ImportColorsFromProfColorTable(ProfessionalColorTable tColorTable)
        {
            NavigateBarColorTable nvColorTable = new NavigateBarColorTable();

            // Custom
            nvColorTable.TextColor = SystemColors.ControlText;
            nvColorTable.SelectedTextColor = SystemColors.ControlText;
            nvColorTable.BorderColor = tColorTable.ButtonSelectedHighlightBorder;

            // Caption
            nvColorTable.CaptionTextColor = SystemColors.MenuText;
            nvColorTable.CaptionBegin = tColorTable.ToolStripGradientBegin;
            nvColorTable.CaptionEnd = tColorTable.ToolStripGradientEnd;
            nvColorTable.CaptionDescBegin = tColorTable.ToolStripGradientBegin;
            nvColorTable.CaptionDescEnd = tColorTable.ToolStripGradientEnd;

            // Separator
            nvColorTable.SeparatorDark = tColorTable.SeparatorDark;
            nvColorTable.SeparatorLight = tColorTable.SeparatorLight;

            // Button Normal
            nvColorTable.ButtonNormalBegin = tColorTable.ToolStripGradientBegin;
            nvColorTable.ButtonNormalMiddleBegin = tColorTable.ToolStripGradientMiddle;
            nvColorTable.ButtonNormalMiddleEnd = tColorTable.ToolStripGradientMiddle;
            nvColorTable.ButtonNormalEnd = tColorTable.ToolStripGradientEnd;

            // Button Selected
            nvColorTable.ButtonSelectedBegin = tColorTable.ButtonPressedGradientBegin;
            nvColorTable.ButtonSelectedMiddleBegin = tColorTable.ButtonPressedGradientMiddle;
            nvColorTable.ButtonSelectedMiddleEnd = tColorTable.ButtonPressedGradientMiddle;
            nvColorTable.ButtonSelectedEnd = tColorTable.ButtonPressedGradientEnd;

            // Button Mouse Over
            nvColorTable.ButtonMouseOverBegin = tColorTable.ButtonSelectedGradientBegin;
            nvColorTable.ButtonMouseOverMiddleBegin = tColorTable.ButtonSelectedGradientMiddle;
            nvColorTable.ButtonMouseOverMiddleEnd = tColorTable.ButtonSelectedGradientMiddle;
            nvColorTable.ButtonMouseOverEnd = tColorTable.ButtonSelectedGradientEnd;

            // Menu
            nvColorTable.MenuBackColor = tColorTable.ToolStripDropDownBackground;

            return nvColorTable;
        }

        public override string ToString()
        {
            return "NavigateBarColorTable";
        }

        #endregion
    }

    #endregion

    #region Office 2003 Blue
    /// <summary>
    /// Office 2003 style blue colors
    /// </summary>
    [Serializable()]
    class Office2003Blue : NavigateBarColorTable
    {
        public Office2003Blue()
        {
            // Separator

            this.SeparatorDark = Color.FromArgb(21, 28, 171);
            this.SeparatorLight = Color.FromArgb(129, 168, 226);

            // Panel Border Color

            this.BorderColor = Color.FromArgb(21, 28, 171);

            // Button Text Color

            this.TextColor = SystemColors.ControlText;

            // Button normal color

            this.ButtonNormalBegin = Color.FromArgb(201, 223, 251);
            this.ButtonNormalMiddleBegin = Color.FromArgb(165, 196, 239);
            this.ButtonNormalMiddleEnd = Color.FromArgb(165, 196, 239);
            this.ButtonNormalEnd = Color.FromArgb(129, 168, 226);

            // Button mouseover color

            this.ButtonMouseOverBegin = Color.FromArgb(255, 253, 216);
            this.ButtonMouseOverMiddleBegin = Color.FromArgb(251, 222, 152);
            this.ButtonMouseOverMiddleEnd = Color.FromArgb(251, 222, 152);
            this.ButtonMouseOverEnd = Color.FromArgb(248, 194, 95);

            // Button selected color

            this.ButtonSelectedBegin = Color.FromArgb(251, 228, 144);
            this.ButtonSelectedMiddleBegin = Color.FromArgb(245, 190, 85);
            this.ButtonSelectedMiddleEnd = Color.FromArgb(245, 190, 85);
            this.ButtonSelectedEnd = Color.FromArgb(240, 153, 25);

            // Captions

            this.CaptionBegin = this.ButtonNormalBegin;
            this.CaptionEnd = this.ButtonNormalEnd;
            this.CaptionDescBegin = this.ButtonNormalBegin;
            this.CaptionDescEnd = this.ButtonNormalEnd;
            this.CaptionTextColor = this.BorderColor;

            this.ContextMenuArrowStyle = ContextMenuArrowStyle.Office2003;
        }

        public override string ToString()
        {
            return "Office2003Blue";
        }
    }
    #endregion

    #region Office 2003 Silver
    /// <summary>
    /// Office 2003 style silver colors
    /// </summary>
    [Serializable()]
    class Office2003Silver : NavigateBarColorTable
    {
        public Office2003Silver()
        {

            // Separator

            this.SeparatorDark = Color.FromArgb(150, 148, 178);
            this.SeparatorLight = Color.FromArgb(223, 224, 234);

            // Panel Border Color

            this.BorderColor = Color.FromArgb(100, 97, 135);

            // Button Text Color

            this.TextColor = SystemColors.ControlText;

            // Button normal color

            this.ButtonNormalBegin = Color.FromArgb(223, 224, 234);
            this.ButtonNormalMiddleBegin = Color.FromArgb(190, 190, 209);
            this.ButtonNormalMiddleEnd = Color.FromArgb(190, 190, 209);
            this.ButtonNormalEnd = Color.FromArgb(150, 148, 178);

            // Button mouseover color

            this.ButtonMouseOverBegin = Color.FromArgb(255, 253, 216);
            this.ButtonMouseOverMiddleBegin = Color.FromArgb(251, 222, 152);
            this.ButtonMouseOverMiddleEnd = Color.FromArgb(251, 222, 152);
            this.ButtonMouseOverEnd = Color.FromArgb(248, 194, 95);

            // Button selected color

            this.ButtonSelectedBegin = Color.FromArgb(251, 228, 144);
            this.ButtonSelectedMiddleBegin = Color.FromArgb(245, 190, 85);
            this.ButtonSelectedMiddleEnd = Color.FromArgb(245, 190, 85);
            this.ButtonSelectedEnd = Color.FromArgb(240, 153, 25);

            // Captions

            this.CaptionBegin = this.ButtonNormalBegin;
            this.CaptionEnd = this.BorderColor;
            this.CaptionDescBegin = this.ButtonNormalBegin;
            this.CaptionDescEnd = this.ButtonNormalEnd;
            this.CaptionTextColor = Color.Black;

            this.ContextMenuArrowStyle = ContextMenuArrowStyle.Office2003;

        }

        public override string ToString()
        {
            return "Office2003Silver";
        }
    }
    #endregion

    #region Office 2003 Olive
    /// <summary>
    /// Office 2003 style olive colors
    /// </summary>
    [Serializable()]
    class Office2003Olive : NavigateBarColorTable
    {
        public Office2003Olive()
        {

            // Separator

            this.SeparatorDark = Color.FromArgb(182, 196, 144);
            this.SeparatorLight = Color.FromArgb(233, 239, 205);

            // Panel Border Color

            this.BorderColor = Color.FromArgb(134, 161, 105);

            // Button Text Color

            this.TextColor = SystemColors.ControlText;

            // Button normal color

            this.ButtonNormalBegin = Color.FromArgb(233, 239, 205);
            this.ButtonNormalMiddleBegin = Color.FromArgb(208, 218, 176);
            this.ButtonNormalMiddleEnd = Color.FromArgb(208, 218, 176);
            this.ButtonNormalEnd = Color.FromArgb(182, 196, 144);

            // Button mouseover color

            this.ButtonMouseOverBegin = Color.FromArgb(255, 253, 216);
            this.ButtonMouseOverMiddleBegin = Color.FromArgb(251, 222, 152);
            this.ButtonMouseOverMiddleEnd = Color.FromArgb(251, 222, 152);
            this.ButtonMouseOverEnd = Color.FromArgb(248, 194, 95);

            // Button selected color

            this.ButtonSelectedBegin = Color.FromArgb(251, 228, 144);
            this.ButtonSelectedMiddleBegin = Color.FromArgb(245, 190, 85);
            this.ButtonSelectedMiddleEnd = Color.FromArgb(245, 190, 85);
            this.ButtonSelectedEnd = Color.FromArgb(240, 153, 25);

            // Captions

            this.CaptionBegin = this.ButtonNormalBegin;
            this.CaptionEnd = this.BorderColor;
            this.CaptionDescBegin = this.ButtonNormalBegin;
            this.CaptionDescEnd = this.ButtonNormalEnd;
            this.CaptionTextColor = Color.Black;

            this.ContextMenuArrowStyle = ContextMenuArrowStyle.Office2003;
        }

        public override string ToString()
        {
            return "Office2003Olive";
        }
    }
    #endregion

    #region Office 2007 Blue
    /// <summary>
    /// Office 2007 style blue colors
    /// </summary>
    [Serializable()]
    class Office2007Blue : NavigateBarColorTable
    {

        public Office2007Blue()
        {

            // Separator

            this.SeparatorDark = Color.FromArgb(192, 219, 255);
            this.SeparatorLight = Color.FromArgb(227, 239, 255);

            // Panel Border Color

            this.BorderColor = Color.FromArgb(101, 147, 207);

            // Button Text Color

            this.TextColor = Color.FromArgb(32, 77, 137);

            // Button normal color

            this.ButtonNormalBegin = Color.FromArgb(227, 239, 255);
            this.ButtonNormalMiddleBegin = Color.FromArgb(196, 221, 255);
            this.ButtonNormalMiddleEnd = Color.FromArgb(173, 209, 255);
            this.ButtonNormalEnd = Color.FromArgb(192, 219, 255);

            // Button mouseover color

            this.ButtonMouseOverBegin = Color.FromArgb(255, 254, 228);
            this.ButtonMouseOverMiddleBegin = Color.FromArgb(255, 232, 167);
            this.ButtonMouseOverMiddleEnd = Color.FromArgb(255, 215, 103);
            this.ButtonMouseOverEnd = Color.FromArgb(255, 230, 158);

            // Button selected color

            this.ButtonSelectedBegin = Color.FromArgb(255, 217, 170);
            this.ButtonSelectedMiddleBegin = Color.FromArgb(255, 187, 110);
            this.ButtonSelectedMiddleEnd = Color.FromArgb(255, 171, 63);
            this.ButtonSelectedEnd = Color.FromArgb(254, 225, 122);

            //

            this.PaintRatio = (float)0.4;
            this.MenuBackColor = this.ButtonNormalBegin;

            // Captions

            this.CaptionBegin = Color.FromArgb(227, 239, 255);
            this.CaptionEnd = Color.FromArgb(173, 209, 255);
            this.CaptionDescBegin = this.ButtonNormalBegin;
            this.CaptionDescEnd = this.ButtonNormalEnd;
            this.CaptionTextColor = Color.FromArgb(21, 66, 139);

        }

        public override string ToString()
        {
            return "Office2007Blue";
        }
    }
    #endregion

    #region Office 2007 Black
    /// <summary>
    /// Office 2007 style black colors
    /// </summary>
    [Serializable()]
    class Office2007Black : NavigateBarColorTable
    {
        public Office2007Black()
        {

            // Separator

            this.SeparatorDark = Color.FromArgb(199, 203, 209);
            this.SeparatorLight = Color.FromArgb(219, 222, 226);

            // Panel Border Color

            this.BorderColor = Color.FromArgb(76, 83, 92);

            // Button Text Color

            this.TextColor = this.BorderColor;

            // Button normal color

            this.ButtonNormalBegin = Color.FromArgb(248, 248, 249);
            this.ButtonNormalMiddleBegin = Color.FromArgb(223, 226, 228);
            this.ButtonNormalMiddleEnd = Color.FromArgb(199, 203, 209);
            this.ButtonNormalEnd = Color.FromArgb(219, 222, 226);

            // Button mouseover color

            this.ButtonMouseOverBegin = Color.FromArgb(255, 254, 228);
            this.ButtonMouseOverMiddleBegin = Color.FromArgb(255, 232, 167);
            this.ButtonMouseOverMiddleEnd = Color.FromArgb(255, 215, 103);
            this.ButtonMouseOverEnd = Color.FromArgb(255, 230, 158);

            // Button selected color

            this.ButtonSelectedBegin = Color.FromArgb(255, 217, 170);
            this.ButtonSelectedMiddleBegin = Color.FromArgb(255, 187, 110);
            this.ButtonSelectedMiddleEnd = Color.FromArgb(255, 171, 63);
            this.ButtonSelectedEnd = Color.FromArgb(254, 225, 122);

            //

            this.PaintRatio = (float)0.4;
            this.MenuBackColor = this.ButtonNormalBegin;

            // Captions

            this.CaptionBegin = Color.FromArgb(240, 241, 242);
            this.CaptionEnd = Color.FromArgb(189, 193, 200);
            this.CaptionDescBegin = this.CaptionBegin;
            this.CaptionDescEnd = this.CaptionEnd;
            this.CaptionTextColor = Color.Black;

        }

        public override string ToString()
        {
            return "Office2007Silver";
        }
    }
    #endregion

    #region Office 2007 Olive
    /// <summary>
    /// Office 2007 style silver colors
    /// </summary>
    [Serializable()]
    class Office2007Silver : NavigateBarColorTable
    {
        public Office2007Silver()
        {

            // Separator

            this.SeparatorDark = Color.FromArgb(119, 118, 151);
            this.SeparatorLight = Color.FromArgb(168, 167, 191);

            // Panel Border Color

            this.BorderColor = Color.FromArgb(111, 112, 116);

            // Button Text Color

            this.TextColor = this.BorderColor;

            // Button normal color

            this.ButtonNormalBegin = Color.FromArgb(235, 238, 250);
            this.ButtonNormalMiddleBegin = Color.FromArgb(214, 218, 228);
            this.ButtonNormalMiddleEnd = Color.FromArgb(197, 199, 204);
            this.ButtonNormalEnd = Color.FromArgb(212, 216, 226);

            // Button mouseover color

            this.ButtonMouseOverBegin = Color.FromArgb(255, 254, 228);
            this.ButtonMouseOverMiddleBegin = Color.FromArgb(255, 232, 167);
            this.ButtonMouseOverMiddleEnd = Color.FromArgb(255, 215, 103);
            this.ButtonMouseOverEnd = Color.FromArgb(255, 230, 158);

            // Button selected color

            this.ButtonSelectedBegin = Color.FromArgb(255, 217, 170);
            this.ButtonSelectedMiddleBegin = Color.FromArgb(255, 187, 110);
            this.ButtonSelectedMiddleEnd = Color.FromArgb(255, 171, 63);
            this.ButtonSelectedEnd = Color.FromArgb(254, 225, 122);

            //

            this.PaintRatio = (float)0.4;
            this.MenuBackColor = this.ButtonNormalBegin;

            // Captions

            this.CaptionBegin = Color.FromArgb(246, 247, 248);
            this.CaptionEnd = Color.FromArgb(218, 223, 230);
            this.CaptionDescBegin = this.CaptionBegin;
            this.CaptionDescEnd = this.CaptionEnd;
            this.CaptionTextColor = Color.FromArgb(21, 66, 139);

        }

        public override string ToString()
        {
            return "Office2007Olive";
        }
    }
    #endregion

}