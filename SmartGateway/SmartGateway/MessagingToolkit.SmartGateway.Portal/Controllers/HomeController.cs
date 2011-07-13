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
using System.Web.Mvc;

using System.Data.Objects;
using System.Data.Objects.DataClasses;

using MessagingToolkit.SmartGateway.Portal.DAL;
using MessagingToolkit.SmartGateway.Portal.ViewModels;
using MessagingToolkit.SmartGateway.Portal;

namespace MessagingToolkit.SmartGateway.Portal.Controllers
{
    /// <summary>
    /// Default home controller
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// Database context
        /// </summary>
        private SmartGatewayEntities smartGatewayContext = new SmartGatewayEntities();

        /// <summary>
        /// Main page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Message = "SmartGateway Portal";
            return View();
        }

        /// <summary>
        /// Pages the not found.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult PageNotFound()
        {
            log.Warn("404 page not found - " + Request.QueryString["aspxerrorpath"]);
            return View();
        }

        /// <summary>
        /// About page
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }
    }
}
