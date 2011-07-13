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

using MessagingToolkit.SmartGateway;
using MessagingToolkit.SmartGateway.Portal;
using MessagingToolkit.SmartGateway.Portal.DAL;
using MessagingToolkit.SmartGateway.Portal.ViewModels;
using MessagingToolkit.SmartGateway.Portal.Helpers;

namespace MessagingToolkit.SmartGateway.Portal.Helpers
{
    /// <summary>
    /// Security helper
    /// </summary>
    public static class SecurityHelper
    {

        /// <summary>
        /// Verifies the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static bool VerifyUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) return false;

            IRepository repository = new GenericRepository(new SmartGatewayEntities());

            User user = repository.First<User>(u=>u.LoginName.ToLower() == userName.ToLower() && u.Password == password);
            if (user != null) return true;

            return false ;
        }
    }
}