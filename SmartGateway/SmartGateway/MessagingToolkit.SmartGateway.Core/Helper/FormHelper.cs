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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MessagingToolkit.SmartGateway.Core.Helper
{
    /// <summary>
    /// Utility class for Windows form
    /// </summary>
    public static class FormHelper
    {

        /// <summary>
        /// Shows the error
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="errorMessage">The error message.</param>
        public static void ShowError(Control control,string errorMessage)
        {
            MessageBox.Show(errorMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            control.Focus();
        }

        /// <summary>
        /// Shows the error
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public static void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }

        /// <summary>
        /// Shows the information
        /// </summary>
        /// <param name="message">The message.</param>
        public static void ShowInfo(string message)
        {            
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);         
        }

        /// <summary>
        /// Validates that the control value is not empty.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static bool ValidateNotEmpty(Control control,string message)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                FormHelper.ShowError(control, message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates that the control value is not empty.
        /// </summary>
        /// <param name="control1">The control1.</param>
        /// <param name="control2">The control2.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static bool ValidateNotEmpty(Control control1, Control control2, string message)
        {
            if (string.IsNullOrEmpty(control1.Text) && string.IsNullOrEmpty(control2.Text))
            {
                FormHelper.ShowError(control1, message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates that the control value is > 0
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static bool ValidateGreaterThanZero(Control control, string message)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                FormHelper.ShowError(control, message);
                return false;
            }

            try
            {
                int value = Convert.ToInt32(control.Text);
                if (value <= 0)
                {
                    FormHelper.ShowError(control, message);
                    return false;
                }
            }
            catch 
            {
                FormHelper.ShowError(control, message);
                return false;
            }
            return true;
        }


        /// <summary>
        /// Validates that the control value is not empty.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="message">The message.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool ValidateNotEmpty(Control control, string message, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                FormHelper.ShowError(control, message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get confirmation
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <returns>Dialog result</returns>
        public static DialogResult Confirm(string message)
        {
            return MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               
        }
    }
}
