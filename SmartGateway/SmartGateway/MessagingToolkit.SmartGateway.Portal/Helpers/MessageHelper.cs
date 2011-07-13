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
using System.Web;

namespace MessagingToolkit.SmartGateway.Portal.Helpers
{
    public static class MessageHelper
    {
        /// <summary>
        /// Supported separators - e.g. list of phone numbers, emails
        /// </summary>
        public static string[] SupportedSeparators = new string[] { ";", "," };


        /// <summary>
        /// Generates a unique identifier.
        /// </summary>
        /// <returns>A unique identifier string</returns>
        public static string GenerateUniqueIdentifier()
        {
            return System.Guid.NewGuid().ToString("N");
        }
    }
}