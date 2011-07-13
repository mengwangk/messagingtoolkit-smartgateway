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
using System.Windows.Forms;

namespace MessagingToolkit.UI
{
    public class OLVColumnAttribute : Attribute
    {
        #region Constructor

        public OLVColumnAttribute() {
        }

        public OLVColumnAttribute(string title) {
            this.Title = title;
        }

        #endregion

        #region Public properties

        public string AspectToStringFormat {
            get { return aspectToStringFormat; }
            set { aspectToStringFormat = value; }
        }
        private string aspectToStringFormat;

        public bool CheckBoxes {
            get { return checkBoxes; }
            set { checkBoxes = value; }
        }
        private bool checkBoxes;

        public int DisplayIndex {
            get { return displayIndex; }
            set { displayIndex = value; }
        }
        private int displayIndex;

        public bool FillsFreeSpace {
            get { return fillsFreeSpace; }
            set { fillsFreeSpace = value; }
        }
        private bool fillsFreeSpace;

        public int? FreeSpaceProportion {
            get { return freeSpaceProportion; }
            set { freeSpaceProportion = value; }
        }
        private int? freeSpaceProportion;

        public object[] GroupCutoffs {
            get { return groupCutoffs; }
            set { groupCutoffs = value; }
        }
        private object[] groupCutoffs;

        public string[] GroupDescriptions {
            get { return groupDescriptions; }
            set { groupDescriptions = value; }
        }
        private string[] groupDescriptions;

        public string GroupWithItemCountFormat {
            get { return groupWithItemCountFormat; }
            set { groupWithItemCountFormat = value; }
        }
        private string groupWithItemCountFormat;

        public string GroupWithItemCountSingularFormat {
            get { return groupWithItemCountSingularFormat; }
            set { groupWithItemCountSingularFormat = value; }
        }
        private string groupWithItemCountSingularFormat;

        public bool Hyperlink {
            get { return hyperlink; }
            set { hyperlink = value; }
        }
        private bool hyperlink;

        public string ImageAspectName {
            get { return imageAspectName; }
            set { imageAspectName = value; }
        }
        private string imageAspectName;

        // We actually want this to be bool? but it seems attribute properties can't be nullable types.
        // So we explicitly track if the property has been set.

        public bool IsEditable {
            get { return isEditable; }
            set {
                isEditable = value;
                this.IsEditableSet = true;
            }
        }
        private bool isEditable = true;
        internal bool IsEditableSet = false;

        public bool IsVisible {
            get { return isVisible; }
            set { isVisible = value; }
        }
        private bool isVisible = true;

        public bool IsTileViewColumn {
            get { return isTileViewColumn; }
            set { isTileViewColumn = value; }
        }
        private bool isTileViewColumn;

        public int MaximumWidth {
            get { return maximumWidth; }
            set { maximumWidth = value; }
        }
        private int maximumWidth = -1;

        public int MinimumWidth {
            get { return minimumWidth; }
            set { minimumWidth = value; }
        }
        private int minimumWidth = -1;

        public String Name {
            get { return name; }
            set { name = value; }
        }
        private String name;

        public HorizontalAlignment TextAlign {
            get { return this.textAlign; }
            set { this.textAlign = value; }
        }
        private HorizontalAlignment textAlign = HorizontalAlignment.Left;

        public String Tag {
            get { return tag; }
            set { tag = value; }
        }
        private String tag;

        public String Title {
            get { return title; }
            set { title = value; }
        }
        private String title;

        public String ToolTipText {
            get { return toolTipText; }
            set { toolTipText = value; }
        }
        private String toolTipText;

        public bool TriStateCheckBoxes {
            get { return triStateCheckBoxes; }
            set { triStateCheckBoxes = value; }
        }
        private bool triStateCheckBoxes;

        public bool UseInitialLetterForGroup {
            get { return useInitialLetterForGroup; }
            set { useInitialLetterForGroup = value; }
        }
        private bool useInitialLetterForGroup;

        public int Width {
            get { return width; }
            set { width = value; }
        }
        private int width = 150;

        #endregion
    }
}
