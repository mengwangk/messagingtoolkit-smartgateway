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

using log4net;

using MessagingToolkit.Core;
using MessagingToolkit.Core.Base;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.SmartGateway.Core.Data.ActiveRecord;
using MessagingToolkit.SmartGateway.Core.Properties;

namespace MessagingToolkit.SmartGateway.Core.Helper
{
    /// <summary>
    /// Message helper class
    /// </summary>
    public static class MessageHelper
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Updates the message status.
        /// </summary>
        /// <param name="status">The message status.</param>
        /// <returns></returns>
        public static bool UpdateStatus(IMessage message, MessageStatus status)
        {
            try
            {
                // Update message status in database
                OutgoingMessage outgoingMessage = OutgoingMessage.SingleOrDefault(msg => msg.Id == message.Identifier);
                if (outgoingMessage == null) return false;
                outgoingMessage.Status = StringEnum.GetStringValue(status);
                outgoingMessage.LastUpdate = DateTime.Now;
                if (status == MessageStatus.Sent)
                {
                    outgoingMessage.SentDate = outgoingMessage.LastUpdate;
                }
                outgoingMessage.Update();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error updating message: {0} ", ex.Message), ex);
                return false;
            }
            return true;
        }
    }
}
