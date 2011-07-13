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

using PagedList;
using MessagingToolkit.SmartGateway;
using MessagingToolkit.SmartGateway.Portal;
using MessagingToolkit.SmartGateway.Portal.DAL;
using MessagingToolkit.SmartGateway.Portal.ViewModels;
using MessagingToolkit.SmartGateway.Portal.Helpers;

namespace MessagingToolkit.SmartGateway.Portal.Controllers
{
    /// <summary>
    /// Controller class for outgoing message
    /// </summary>
    [Authorize]
    public class OutgoingMessageController : BaseController
    {   
        /// <summary>
        /// Generic repository
        /// </summary>
        private IRepository repository = new GenericRepository(new SmartGatewayEntities());

        //
        // GET: /OutgoingMessage/

        public ViewResult Index(string sortOrder, string currentFilter, string searchRecipient, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Recipient desc" : "Recipient";
            ViewBag.DateSortParm = sortOrder == "SentDate" ? "SentDate desc" : "SentDate";
            ViewBag.ScheduledDateSortParm = sortOrder == "ScheduledDate" ? "ScheduledDate desc" : "ScheduledDate";

            if (Request.HttpMethod == "GET")
            {
                searchRecipient = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchRecipient;
        
            IEnumerable<OutgoingMessage> messages = null;
            if (!string.IsNullOrEmpty(searchRecipient))
            { 
                messages = repository.Find<OutgoingMessage>(msg => msg.Status != "Archived" &&
                                    msg.Status != "Failed" && msg.Recipient.ToUpper().Contains(searchRecipient.ToUpper()));                
            }
            else
            {
                messages = repository.Find<OutgoingMessage>(msg => msg.Status != "Archived" &&
                                    msg.Status != "Failed");
            }
           
            switch (sortOrder)
            {
                case "Recipient":
                    messages = messages.OrderBy(m => m.Recipient);
                    break;
                case "Recipient desc":
                    messages = messages.OrderByDescending(m => m.Recipient);
                    break;  
                case "SentDate":
                    messages = messages.OrderBy(m => m.SentDate);
                    break;
                case "SentDate desc":
                    messages = messages.OrderByDescending(m => m.SentDate);
                    break;         
                case "ScheduledDate":
                    messages = messages.OrderBy(m => m.ScheduledDate);
                    break;     
                 case "ScheduledDate desc":
                    messages = messages.OrderByDescending(m => m.ScheduledDate);
                    break;      
                default:
                    messages = messages.OrderBy(m => m.SentDate);
                    break;
            }
            int pageSize = PageReference.DefaultPageSize;
            int pageIndex = (page ?? 1) - 1;
            return View(messages.ToPagedList(pageIndex, pageSize));           
        }

        //
        // GET: /OutgoingMessage/Details/5

        public ViewResult Details(string id)
        { 
            OutgoingMessage msg = repository.Single<OutgoingMessage>(o => o.Id == id);
            return View(msg);
        }

        //
        // GET: /OutgoingMessage/Create

        public ActionResult Create()
        {
            return View();
        }
              
        //
        // POST: /OutgoingMessage/Create

        [HttpPost]
        public ActionResult Create(OutgoingMessage outgoingmessage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Add<OutgoingMessage>(outgoingmessage);
                    repository.UnitOfWork.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                // Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            } 

            return View(outgoingmessage);
        }



        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <returns></returns>
        public ActionResult SendMessage()
        {
            OutgoingMessageViewModel msg = new OutgoingMessageViewModel();            
            return View(msg);
        }


        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SendMessage(OutgoingMessageViewModel msg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // The To list can be separated by comma or semicolon
                    string[] toList = msg.Recipient.Split(MessageHelper.SupportedSeparators, StringSplitOptions.RemoveEmptyEntries);      
                    string groupId = MessageHelper.GenerateUniqueIdentifier();

                    GatewayConfig gwConfig = repository.First<GatewayConfig>(gc => gc.Id == msg.Channel);

                    repository.UnitOfWork.BeginTransaction();
                    foreach (string to in toList)
                    {
                        OutgoingMessage message = new OutgoingMessage();
                        message.Id = MessageHelper.GenerateUniqueIdentifier();
                        message.GatewayId = msg.Channel;
                        message.Recipient = to.Trim();
                        if (gwConfig != null)
                        {
                            message.Originator = gwConfig.OwnNumber;
                        }
                        else
                        {
                            message.Originator = string.Empty;
                        }
                        message.MessageType = msg.MessageType;
                        message.MessageFormat = msg.MessageFormat;
                        message.LastUpdate = DateTime.Now;
                        message.CreateDate = message.LastUpdate;
                        message.SrcPort = Convert.ToInt32(msg.SrcPort);
                        message.DestPort = Convert.ToInt32(msg.DestPort);
                        message.Status = "Pending";
                        message.MessageClass = msg.MessageClass;
                        message.Priority = msg.Priority;
                        message.StatusReport = msg.StatusReport;
                        message.Quantity = 1;
                        message.GroupId = groupId;
                        message.ScheduledDate = msg.ScheduledDate;
                        message.Message = msg.Message;
                        
                        if (msg.MessageType.Equals("WAP Push", StringComparison.OrdinalIgnoreCase))
                        {
                            message.WapUrl = msg.WapUrl;
                            message.WapSignal = msg.WapSignal;
                            message.WapCreateDate = msg.WapCreateDate;
                            message.WapExpiryDate = msg.WapExpiryDate;
                        }
                        repository.Add<OutgoingMessage>(message);
                    }
                    repository.UnitOfWork.CommitTransaction();                    
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                if (repository.UnitOfWork.IsInTransaction)
                {
                    // Rollback the transaction
                    repository.UnitOfWork.RollBackTransaction();
                }

                // Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(msg);
        }


        //
        // GET: /OutgoingMessage/Edit/5
 
        public ActionResult Edit(string id)
        {
            OutgoingMessage msg = repository.Single<OutgoingMessage>(o => o.Id == id);            
            return View(msg);
        }

        //
        // POST: /OutgoingMessage/Edit/5

        [HttpPost]
        public ActionResult Edit(OutgoingMessage outgoingmessage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Update<OutgoingMessage>(outgoingmessage);
                    repository.UnitOfWork.SaveChanges();                    
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            } 
            return View(outgoingmessage);
        }

        //
        // GET: /OutgoingMessage/Delete/5
  
        public ActionResult Delete(string id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            OutgoingMessage outgoingmessage = repository.Single<OutgoingMessage>(o => o.Id == id);
            return View(outgoingmessage);
        }

        //
        // POST: /OutgoingMessage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                OutgoingMessage outgoingmessage = repository.Single<OutgoingMessage>(o => o.Id == id);
                repository.Delete<OutgoingMessage>(outgoingmessage);
                repository.UnitOfWork.SaveChanges();
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary { 
                { "id", id }, 
                { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}