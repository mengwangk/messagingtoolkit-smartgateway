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

namespace MessagingToolkit.UI
{
    #region Class : NavigateBarButtonEventArgs
    /// <summary>
    /// CancelEventArgs for NavigateBar.OnNavigateBarButtonSelecting event
    /// </summary>
    public class NavigateBarButtonCancelEventArgs : CancelEventArgs
    {

        #region Selected
        NavigateBarButton selected;
        /// <summary>
        /// New Selected NavigateBarButton
        /// <para>get</para>
        /// </summary>
        public NavigateBarButton Selected
        {
            get { return selected; }
        }
        #endregion

        #region PreviousSelected
        NavigateBarButton previousSelected;
        /// <summary>
        /// Previous Selected NavigateBarButton
        /// <para>Get</para>
        /// </summary>
        public NavigateBarButton PreviousSelected
        {
            get { return previousSelected; }
        }
        #endregion

        public NavigateBarButtonCancelEventArgs(NavigateBarButton tSelected, NavigateBarButton tPreviousSelected)
        {
            selected = tSelected;
            previousSelected = tPreviousSelected;
            this.Cancel = false;
        }
    }
    #endregion
}
