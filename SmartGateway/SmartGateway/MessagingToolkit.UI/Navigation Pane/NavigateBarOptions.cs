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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MessagingToolkit.UI
{
    partial class NavigateBarOptions : Form
    {

        #region HasChange
        bool hasChange = false;
        public bool HasChange
        {
            get { return hasChange; }
        }
        #endregion

        bool isReset = false;
        NavigateBar navigateBar = null;

        // Order in collection
        Dictionary<int, NavigateBarButton> collectionOrder = new Dictionary<int, NavigateBarButton>();

        #region Yapıcı Metodlar
        public NavigateBarOptions(NavigateBar tNavigateBar)
        {
            navigateBar = tNavigateBar;

            InitializeComponent();
            InitNavigateBarOptions();

        }

        void InitNavigateBarOptions()
        {

            // Text

            btnCancel.Text = Properties.Resources.TEXT_BUTTON_CANCEL;
            btnMoveDown.Text = Properties.Resources.TEXT_BUTTON_MOVE_DOWN;
            btnMoveUp.Text = Properties.Resources.TEXT_BUTTON_MOVE_UP;
            btnReset.Text = Properties.Resources.TEXT_BUTTON_RESET;
            btnOK.Text = Properties.Resources.TEXT_BUTTON_OK;

            Text = Properties.Resources.TEXT_MENU_OPTIONS.Replace("&", "").Replace("...", "");
            lblOrderDescription.Text = Properties.Resources.TEXT_LABEL_ORDER_DESCRIPTION;

            // Orjinal durumlarını dictionary ekle
            // Save orjinal state

            for (int i = 0; i < navigateBar.NavigateBarButtons.Count; i++)
            {
                NavigateBarButton nvb = navigateBar.NavigateBarButtons[i];
                collectionOrder.Add(i, nvb);
            }

            // Listeyi yükle
            // Load checked list

            LoadList();

            // Listedeki eleman sayısına göre buttonları ayarla
            // Set enabled state for list button count

            if (lstButtons.Items.Count < 0)
            {
                btnMoveDown.Enabled = false;
                btnMoveUp.Enabled = false;
                btnOK.Enabled = false;
                btnReset.Enabled = false;
            }

            //

            lstButtons.SelectionMode = SelectionMode.One;
            lstButtons.ItemCheck += new ItemCheckEventHandler(CheckList_ItemCheck);

            this.KeyPreview = true;
            this.KeyPress += delegate(object sender, KeyPressEventArgs e)
                {
                    if (e.KeyChar == (char)Keys.Escape)
                        this.Close();
                };
        }
        #endregion

        #region LoadList
        /// <summary>
        /// Load checked list
        /// </summary>
        void LoadList()
        {

            int selectedIndex = lstButtons.SelectedIndex;

            // NavigateBar butonların ismini yüklerken orjinal isimleri yükle
            // Use caption text.  

            lstButtons.Items.Clear();

            for (int i = 0; i < collectionOrder.Count; i++)
            {
                CheckedListItem cli = new CheckedListItem(collectionOrder[i]);
                cli.Index = i;
                lstButtons.Items.Add(cli, cli.NavigateBarButton.IsDisplayed);
            }

            lstButtons.SelectedIndex = -1;
            lstButtons.SelectedItem = null;
            CheckList_SelectedIndexChanged(null, null);

        }
        #endregion

        #region OK Click
        /// <summary>
        /// Click OK Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            // Değişikli var mı kontrol et
            // Is any change on list
            hasChange = CheckChanges();

            if (hasChange) // Varsa uygula
            {
                // Liste içerisinde
                // Check button in list
                for (int i = 0; i < lstButtons.Items.Count; i++)
                {
                    CheckedListItem cli = (lstButtons.Items[i] as CheckedListItem);
                    navigateBar.NavigateBarButtons[i] = cli.NavigateBarButton;
                    navigateBar.NavigateBarButtons[i].IsChecked = cli.Checked;
                }
            }

            // Formu Kapat

            this.Close();

        }

        #endregion

        #region CheckChanges
        /// <summary>
        /// Check change in checked list on click OK button
        /// </summary>
        bool CheckChanges()
        {
            bool isChange = false;

            for (int i = 0; i < collectionOrder.Count; i++)
            {
                NavigateBarButton nvb = null;
                CheckedListItem cli = (lstButtons.Items[i] as CheckedListItem);

                collectionOrder.TryGetValue(i, out nvb);
                if (nvb != null)
                {
                    // Liste içerisindeki sırası değişti mi ?
                    // Is change button order
                    if (cli.Index != i)
                    {
                        isChange = true;
                        break;
                    }
                    else
                    {
                        // Check durumu değişti mi?
                        // Is change checked state
                        if (nvb.IsDisplayed != cli.Checked)
                        {
                            isChange = true;
                            break;
                        }
                    }
                }

            }

            return isChange || isReset;
        }

        #endregion

        #region Cancel Click
        /// <summary>
        /// Click CANCEL button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region CheckList Events
        /// <summary>
        /// SelectedIndex durumlarına göre butonların durumunu ayarlar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckList_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnMoveUp.Enabled = true;
            btnMoveDown.Enabled = true;

            // seçili eleman yok
            if (lstButtons.SelectedIndex < 0)
            {
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
            }

            // Listede en üstte
            if (lstButtons.SelectedIndex == 0)
            {
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = true;
            }

            // Listede en altta
            if (lstButtons.SelectedIndex == lstButtons.Items.Count - 1)
            {
                btnMoveUp.Enabled = true;
                btnMoveDown.Enabled = false;
            }

        }

        /// <summary>
        /// CheckState değiştiğinde bunu nesneye aktar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index < 0)
                return;

            CheckedListItem cli = (lstButtons.Items[e.Index] as CheckedListItem);
            cli.Checked = (e.NewValue == CheckState.Checked ? true : false);

            if (cli.NavigateBarButton.IsAlwaysDisplayed) // Her zaman gösterilecekse gizlenemesin
            {
                cli.Checked = true;
                e.NewValue = CheckState.Checked;
            }
        }

        #endregion

        #region MoveUp Click
        /// <summary>
        /// Move up item in list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            object listItem = lstButtons.SelectedItem;
            if (listItem == null)
                return;
            int index = lstButtons.SelectedIndex;
            if (index <= 0)
                return;
            else
            {
                CheckState checkState = lstButtons.GetItemCheckState(index);
                lstButtons.Items.RemoveAt(index);
                lstButtons.Items.Insert(index - 1, listItem);
                lstButtons.SelectedItem = lstButtons.Items[index - 1];
                lstButtons.SetItemCheckState(index - 1, checkState);
            }
        }
        #endregion

        #region MoveDown Click
        /// <summary>
        /// Move down item in list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            object listItem = lstButtons.SelectedItem;
            if (listItem == null)
                return;
            int index = lstButtons.SelectedIndex;
            if (index >= lstButtons.Items.Count - 1)
                return;
            else
            {
                CheckState checkState = lstButtons.GetItemCheckState(index);
                lstButtons.Items.RemoveAt(index);
                lstButtons.Items.Insert(index + 1, listItem);
                lstButtons.SelectedItem = lstButtons.Items[index + 1];
                lstButtons.SetItemCheckState(index + 1, checkState);
            }
        }
        #endregion

        #region Reset Click
        /// <summary>
        /// Click RESET button. ReLoad list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {

            collectionOrder.Clear();

            int i = 0;
            foreach (KeyValuePair<string, int> key in navigateBar.buttonOrder)
            {
                NavigateBarButton button = navigateBar.NavigateBarButtons.FindByKey(key.Key);
                if (button != null)
                {
                    collectionOrder.Add(i, button);
                    i++;
                }
            }
            isReset = true;

            LoadList();

        }
        #endregion

        #region SubClass : CheckListItem
        /// <summary>
        /// Each line in list
        /// </summary>
        class CheckedListItem
        {

            NavigateBarButton navigateBarButton;
            public NavigateBarButton NavigateBarButton
            {
                get { return navigateBarButton; }
            }

            int index = -1;
            public int Index
            {
                get { return index; }
                set { index = value; }
            }

            bool isChecked;
            public bool Checked
            {
                get { return isChecked; }
                set { isChecked = value; }
            }

            public CheckedListItem(NavigateBarButton tNavigateBarButton)
            {
                navigateBarButton = tNavigateBarButton;
                isChecked = navigateBarButton.IsDisplayed;
            }

            public override string ToString()
            {
                return navigateBarButton.Caption;
            }
        }
        #endregion

    }
}