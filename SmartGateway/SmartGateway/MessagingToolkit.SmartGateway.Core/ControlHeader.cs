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

using MessagingToolkit.SmartGateway.Core.Properties;

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Control header
    /// </summary>
    public partial class ControlHeader : UserControl
    {
        private string title;
        private string subTitle;
        private Bitmap logo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlHeader"/> class.
        /// </summary>
        public ControlHeader()
        {
            InitializeComponent();

            // Set the default title
            this.Title = Resources.ApplicationTitle;
        }
               

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.lblTitle.Text = value;
            }
        }


        /// <summary>
        /// Gets or sets the sub title.
        /// </summary>
        /// <value>The sub title.</value>
        public string SubTitle
        {
            get
            {
                return this.subTitle;
            }
            set
            {
                this.subTitle = value;
                this.lblSubtitle.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        public Bitmap Logo
        {
            get
            {
                return this.logo;
            }
            set
            {
                this.logo = value;
                this.picLogo.Image = value;
            }
        }     
    }
}
