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
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MessagingToolkit.SmartGateway;
using MessagingToolkit.SmartGateway.Portal;
using MessagingToolkit.SmartGateway.Portal.DAL;

namespace MessagingToolkit.SmartGateway.Portal
{
    /// <summary>
    /// Page reference
    /// </summary>
    public static class PageReference
    {
        /// <summary>
        /// Page size
        /// </summary>
        public const int DefaultPageSize = 50;

      
        /// <summary>
        /// Supported message types
        /// </summary>
        public static SelectList MessageTypes = new SelectList(new List<string>(){"SMS", "WAP Push"});
        
        public static SelectList MessageFormat = new SelectList(new List<string>(){"Auto Detect", "Text", "Unicode","Ansi - 8 Bits" });

        public static SelectList MessagePriority = new SelectList(new List<string>() { "Low", "Normal", "High" });

        public static SelectList MessageClass = new SelectList(new List<string>() { "None", "Flash", "ME", "SIM", "TE" });

        public static SelectList StatusReport = new SelectList(new List<string>() { "No", "Yes", "Follow Channel" });

        public static SelectList WapSignal = new SelectList(new List<string>() { "None", "Low", "Medium", "High" });
                         
    }


    /// <summary>
    /// Database lookup
    /// </summary>
    public sealed class DbLookup
    {
        private static volatile DbLookup instance;
        private static object syncRoot = new Object();

        private DbLookup() 
        {
            IRepository repository = new GenericRepository(new SmartGatewayEntities());        
            IEnumerable<GatewayConfig> gcList = repository.GetAll<GatewayConfig>().OrderBy(gc=>gc.Id);

            List<string> names = new List<string>();
            foreach (GatewayConfig c in gcList)
            {
                names.Add(c.Id);
            }
            Channels = new SelectList(names);
        }

        public SelectList Channels { get; private set; }

        public static DbLookup Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DbLookup();
                    }
                }
                return instance;
            }
        }
    }
}