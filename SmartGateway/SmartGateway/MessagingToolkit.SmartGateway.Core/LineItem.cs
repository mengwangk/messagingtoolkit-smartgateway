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
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using MessagingToolkit.SmartGateway.Core.Helper;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// User control representing a line item in a menu
    /// </summary>
    public partial class LineItem : UserControl
    {
        /// <summary>
        /// Supported method name
        /// </summary>
        public const string SupportedMethodName = "LinkClicked";

        /// <summary>
        /// Initializes a new instance of the <see cref="LineItem"/> class.
        /// </summary>
        public LineItem()
        {
            InitializeComponent();

            Initialize();
        }

        #region Private Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            if (string.IsNullOrEmpty(this.LinkToClass))
                this.LinkToClass = string.Empty;
            if (string.IsNullOrEmpty(this.LinkToModule))
                this.LinkToModule = string.Empty;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the link image.
        /// </summary>
        /// <value>The link image.</value>
        public Bitmap LinkImage 
        {
            get
            {
                if (this.picLinkImage.Image != null)
                    return new Bitmap(this.picLinkImage.Image);
                return null; 
            }
            set
            {
                if (value != null)
                {
                    this.picLinkImage.Image = value;
                }                
            }
        }


        /// <summary>
        /// Gets or sets the name of the link.
        /// </summary>
        /// <value>The name of the link.</value>
        public string LinkName 
        {
            get
            {
                return this.lnkName.Text;
            }
            set
            {
                this.lnkName.Text = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the link to.
        /// </summary>
        /// <value>The link to.</value>
        public string LinkToClass 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the link to module.
        /// </summary>
        /// <value>The link to module.</value>
        public string LinkToModule 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the link description.
        /// </summary>
        /// <value>The link description.</value>
        public string LinkDescription 
        {
            get
            {
                return this.lnkDescription.Text;
            }
            set
            {
                this.lnkDescription.Text = value;
            }
        }


        #endregion


        #region Private events

        /// <summary>
        /// Handles the Resize event of the LineItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LineItem_Resize(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Handles the Load event of the LineItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LineItem_Load(object sender, EventArgs e)
        {
            this.lnkName.Text = this.LinkName;
            this.lnkDescription.Text = this.LinkDescription;
                        
            if (this.LinkImage != null)
            {
                this.picLinkImage.Image = this.LinkImage;
            }

            Initialize();

        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Type type = this.ParentForm.GetType();            
            MethodInfo method = type.GetMethod(SupportedMethodName);
            if (method != null)
            {
                method.Invoke(this.ParentForm, new object[] { new object[]{this.LinkToClass, this.LinkToModule} });
            }            
        }

        #endregion

     

    }
}
