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
using System.Collections;

namespace MessagingToolkit.UI
{
    /// <summary>
    ///  NavigateBarButton collection
    /// </summary>
    public class NavigateBarButtonCollection : CollectionBase
    {

        #region Delegates
        internal delegate void OnButtonEventHandler(NavigateBarButtonEventArgs e);
        /// <summary>
        /// Occurs when remove button in collection
        /// </summary>
        internal event OnButtonEventHandler OnButtonAdded;

        /// <summary>
        /// Occurs when add new button in collection
        /// </summary>
        internal event OnButtonEventHandler OnButtonRemoved;
        #endregion

        #region Constructors

        private NavigateBar NavigationPane;

        public NavigateBarButtonCollection(NavigateBar tNavigateBar)
        {
            this.NavigationPane = tNavigateBar;
        }
        #endregion

        #region Indexer
        public NavigateBarButton this[int index]
        {
            get { return (NavigateBarButton)this.List[index]; }
            set
            {
                if (value is NavigateBarButton)
                {
                    this.List[index] = value;
                }
                else
                    throw new Exception("Value must be NavigateBarButton");
            }

        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a new button in collection
        /// </summary>
        /// <param name="tButton">NavigateBarButton object</param>
        public virtual void Add(NavigateBarButton tButton)
        {
            // Only once
            if (!this.Contains(tButton))
                this.List.Add(tButton);
        }

        /// <summary>
        /// Add buttons in collection
        /// </summary>
        /// <param name="tButtons"></param>
        public virtual void AddRange(NavigateBarButton[] tButtons)
        {
            foreach (NavigateBarButton nvb in tButtons)
                this.Add(nvb); 
        }
        
        /// <summary>
        /// Remove exist a button from collection
        /// </summary>
        /// <param name="tButton">NavigateBarButton object</param>
        public virtual void Remove(NavigateBarButton tButton)
        {
            if (this.Contains(tButton))
                this.List.Remove(tButton);
        }

        /// <summary>
        /// Remove exist a button from collection using key value
        /// </summary>
        /// <param name="tKey"></param>
        public virtual void RemoveByKey(string tKey)
        {
            NavigateBarButton nvb = this.FindByKey(tKey);
            if (nvb != null)
                this.Remove(nvb);
        }

        /// <summary>
        /// Insert a new button in collection
        /// </summary>
        /// <param name="tIndex">Index no</param>
        /// <param name="tButton">NavigateBarButton object</param>
        public virtual void Insert(int tIndex, NavigateBarButton tButton)
        {
            if (!this.Contains(tButton))
                this.List.Insert(tIndex, tButton);
        }

        protected override void OnInsertComplete(int index, object value)
        {
            base.OnInsertComplete(index, value);

            if (OnButtonAdded != null)
                OnButtonAdded(new NavigateBarButtonEventArgs(value as NavigateBarButton));

        }

        protected override void OnRemoveComplete(int index, object value)
        {
            base.OnRemoveComplete(index, value);

            if (OnButtonRemoved != null)
                OnButtonRemoved(new NavigateBarButtonEventArgs(value as NavigateBarButton));

        }

        /// <summary>
        /// Check collection 
        /// </summary>
        /// <param name="tButton">NavigateBarButton object</param>
        /// <returns>bool</returns>
        public virtual bool Contains(NavigateBarButton tButton)
        {
            return this.List.Contains(tButton);
        }

        /// <summary>
        /// Get index no in collection
        /// </summary>
        /// <param name="tButton">NavigateBarButton object</param>
        /// <returns>int</returns>
        public virtual int IndexOf(NavigateBarButton tButton)
        {
            return this.List.IndexOf(tButton);
        }
        #endregion

        #region Custom Methods
        /// <summary>
        /// Get displayed button count in panel
        /// </summary>
        /// <returns></returns>
        public int GetDisplayedItemCount()
        {
            int count = 0;
            foreach (NavigateBarButton nvb in this.List)
                if (nvb.IsDisplayed && nvb.Visible)
                    count++;

            return count;
        }

        /// <summary>
        /// Search button using key value
        /// </summary>
        /// <param name="tKey">NavigateBarButton key value</param>
        /// <returns></returns>
        public NavigateBarButton FindByKey(string tKey)
        {
            NavigateBarButton retButton = null;

            if (string.IsNullOrEmpty(tKey))
                return retButton;

            foreach (NavigateBarButton nvb in this.List)
            {
                if (!string.IsNullOrEmpty(nvb.Key) && nvb.Key.Equals(tKey))
                {
                    retButton = nvb;
                    break;
                }
            }

            return retButton;
        }

        /// <summary>
        /// Set new position in collection
        /// </summary>
        /// <param name="tButton">NavigateBarButton object</param>
        /// <param name="tNewIndex">New index in collection</param>
        public void SetChildIndex(NavigateBarButton tButton, int tNewIndex)
        {

            if (tButton == null)
                return;

            int oldIndex = this.List.IndexOf(tButton);

            // Eğer yeri daha önceli bir konuma alınmışsa
            if (oldIndex > tNewIndex)
            {
                for (int i = oldIndex; i >= (tNewIndex + 1); i--)
                    this.List[i] = this.List[i - 1];
            }
            else if (oldIndex < tNewIndex) // Eğer bulunduğu posizyondan sonraki bir posizyona alınmışsa
            {
                for (int i = oldIndex + 1; i <= tNewIndex; i++)
                    this.List[i - 1] = this.List[i];
            }

            this.List[tNewIndex] = tButton;

        }

        #endregion

    }
}
