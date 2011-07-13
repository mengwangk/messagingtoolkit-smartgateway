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

namespace MessagingToolkit.SmartGateway.Core
{
    /// <summary>
    /// Customized exception
    /// </summary>
    public class SmartGatewayException: Exception
    {
        
        /// <summary>
        /// Initializes a new object of SmartGatewayException class.
        /// </summary>
        public SmartGatewayException() { }

        /// <summary>
        /// Initializes a new object of SmartGatewayException class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SmartGatewayException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new object of SmartGatewayException class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public SmartGatewayException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new object of SmartGatewayException class.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized
        /// object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual
        /// information about the source or destination.</param>
        protected SmartGatewayException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
