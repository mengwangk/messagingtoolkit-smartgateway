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

using MessagingToolkit.Core;

namespace MessagingToolkit.SmartGateway.Core.Interprocess
{
    [Serializable]
    public class EventAction
    {

        /// <summary>
        /// Synchronous action
        /// </summary>
        public const string Synchronous = "S";

        /// <summary>
        /// Asynchronous action
        /// </summary>
        public const string ASynchronous = "A";


        public string Notification; // the text to be sent by master
        public string Computer;     // Computer name of the sender (=slave)
        public string ActionType;   // Synchronous or asynchronous action type

        // to transfer more data expand here...
        public Dictionary<string, string> Values;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventAction"/> class.
        /// </summary>
        public EventAction()
        {
            Notification = string.Empty;
            Values = new Dictionary<string, string>(1);
            Computer = Environment.MachineName;
            ActionType = ASynchronous;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventAction"/> class.
        /// </summary>
        /// <param name="notification">The notification.</param>
        public EventAction(string notification)
        {
            Notification = notification;
            Values = new Dictionary<string, string>(1);
            Computer = Environment.MachineName;
            ActionType = ASynchronous;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Notification - [{0}]\r\n", Notification);
            sb.AppendFormat("Computer - [{0}]\r\n", Computer);
            return sb.ToString();
        }
    }
        
    [Serializable]
    public class EventResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventResponse"/> class.
        /// </summary>
        public EventResponse()
        {
            Status = StringEnum.GetStringValue(EventNotificationResponse.OK);
            Results = new Dictionary<string,string>();
        }
        /// <summary>
        /// Response status
        /// </summary>
        public string Status;  

        /// <summary>
        /// Results
        /// </summary>
        public Dictionary<string, string> Results;

        // to transfer more data expand here...
    }

    /// <summary>
    /// Event invocation 
    /// </summary>
    public class EventInvocation : MarshalByRefObject
    {
        public delegate EventResponse Received(EventAction action);
        public event Received EventReceived;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventInvocation"/> class.
        /// </summary>
        public EventInvocation()
        {
        }

        /// <summary>
        /// Invokes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public EventResponse Invoke(EventAction action)
        {
            if (EventReceived != null)
                return EventReceived(action);

            return new EventResponse();
        }

        /// <summary>
        /// This override is EXTREMELY important
        /// If it is missing the garbage collector of the Slave will delete the cTransfer object
        /// after 5 minutes and the event will be lost, so further calls to the slave will return
        /// "Server encountered an internal error" (a very helpful Mircrosoft error message!)
        /// This function sets the livetime to infinite
        /// See http://www.thinktecture.com/Resources/RemotingFAQ/SINGLETON_IS_DYING.html
        /// </summary>
        public override Object InitializeLifetimeService()
        {
            return null;
        }
    }
}
