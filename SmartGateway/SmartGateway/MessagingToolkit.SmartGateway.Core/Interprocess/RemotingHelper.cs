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

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Services;

using log4net;
using MessagingToolkit.Core;
using MessagingToolkit.SmartGateway.Core;

namespace MessagingToolkit.SmartGateway.Core.Interprocess
{
    /// <summary>
    /// Helper class to send custom event through remoting
    /// </summary>
    public static class RemotingHelper
    {
        // Static Logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Notifies the event.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public static EventResponse NotifyEvent(string url, EventAction action) 
        {
            try
            {
                if (log.IsDebugEnabled) log.Debug(string.Format("Sending event [{0}]", action.Notification));
                EventInvocation invoker = Activator.GetObject(typeof(EventInvocation), url) as EventInvocation;
                EventResponse response = invoker.Invoke(action);
                if (log.IsDebugEnabled) log.Debug("Event is successfully sent");
                return response;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Invocation error: {0}", ex.Message), ex);
            }

            EventResponse defaultResponse = new EventResponse();
            defaultResponse.Status = StringEnum.GetStringValue(EventNotificationResponse.Failed);
            return defaultResponse;
           
        }

        /// <summary>
        /// Verifies the response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static bool VerifyResponse(EventResponse response) 
        {
            return (!string.IsNullOrEmpty(response.Status) && !response.Status.Equals(StringEnum.GetStringValue(EventNotificationResponse.Failed), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Sends the event.
        /// </summary>
        /// <param name="eventListenerUrl">The event listener URL.</param>
        /// <param name="action">The action.</param>
        public static void SendEvent(string eventListenerUrl, EventAction action)
        {
            action.Computer = Environment.MachineName;
            NotifyEvent(eventListenerUrl, action);
        }
    }
}
