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

using System.Security.Cryptography;

namespace MessagingToolkit.SmartGateway.Core.Helper
{
    /// <summary>
    /// User helper class
    /// </summary>
    public class UserHelper
    {
        /// <summary>
        /// Compare user password
        /// </summary>
        /// <param name="password">Password stored in database</param>
        /// <param name="loginPassword">Login password</param>
        /// <returns>true if password is matched</returns>
        public static bool VerifyPassword(string password, string loginPassword)
        {
            SHA1Managed hashProvider = new SHA1Managed();            
            byte[] hash = hashProvider.ComputeHash(StringToByteArray(loginPassword));
            string hashedPassword = ByteArrayToString(hash);
            return (password.Equals(hashedPassword));
        }

        /// <summary>
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GenerateHashedPassword(string password)
        {
            SHA1Managed hashProvider = new SHA1Managed();
            byte[] hashedPassword = hashProvider.ComputeHash(StringToByteArray(password));
            return ByteArrayToString(hashedPassword);            
        }

        
        // ------------------------------------- Private Static Methods ---------------------------------------


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] StringToByteArray(string str)
        {
            return new UTF8Encoding().GetBytes(str);            
        }

        /// <summary>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static string ByteArrayToString(byte[] bytes)
        { 
            return new UTF8Encoding().GetString(bytes);
        }

    }
}
