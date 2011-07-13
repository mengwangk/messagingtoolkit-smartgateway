using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessagingToolkit.SmartGateway.Portal;

using PagedList;
using MessagingToolkit.SmartGateway;
using MessagingToolkit.SmartGateway.Portal.DAL;
using MessagingToolkit.SmartGateway.Portal.ViewModels;
using MessagingToolkit.SmartGateway.Portal.Helpers;

namespace MessagingToolkit.SmartGateway.Portal.Controllers
{
    [Authorize]
    public class IncomingMessageController : Controller
    {
        private IRepository repository = new GenericRepository(new SmartGatewayEntities());
       
        //
        // GET: /IncomingMessage/

        public ViewResult Index(string sortOrder, string currentFilter, string searchOriginator, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Originator desc" : "Originator";
            ViewBag.DateSortParm = sortOrder == "ReceivedDate" ? "ReceivedDate desc" : "ReceivedDate";
            ViewBag.OriginatorReceivedDateSortParm = sortOrder == "OriginatorReceivedDate" ? "OriginatorReceivedDate desc" : "OriginatorReceivedDate";

            if (Request.HttpMethod == "GET")
            {
                searchOriginator = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchOriginator;

            IEnumerable<IncomingMessage> messages = null;
            if (!string.IsNullOrEmpty(searchOriginator))
            {
                messages = repository.Find<IncomingMessage>(
                    msg=>(string.IsNullOrEmpty(msg.Status) || msg.Status == "Received") 
                          && msg.Originator.ToUpper().Contains(searchOriginator.ToUpper()));
            }
            else
            {
                messages = repository.Find<IncomingMessage>(msg=>(string.IsNullOrEmpty(msg.Status) || msg.Status == "Received"));
            }

            switch (sortOrder)
            {
                case "Originator":
                    messages = messages.OrderBy(m => m.Originator);
                    break;
                case "Originator desc":
                    messages = messages.OrderByDescending(m => m.Originator);
                    break;
                case "ReceivedDate":
                    messages = messages.OrderBy(m => m.ReceivedDate);
                    break;
                case "ReceivedDate desc":
                    messages = messages.OrderByDescending(m => m.ReceivedDate);
                    break;
                case "OriginatorReceivedDate":
                    messages = messages.OrderBy(m => m.OriginatorReceivedDate);
                    break;
                case "OriginatorReceivedDate desc":
                    messages = messages.OrderByDescending(m => m.OriginatorReceivedDate);
                    break;
                default:
                    messages = messages.OrderBy(m => m.ReceivedDate);
                    break;
            }
            int pageSize = PageReference.DefaultPageSize;
            int pageIndex = (page ?? 1) - 1;
            return View(messages.ToPagedList(pageIndex, pageSize));
        }

        //
        // GET: /IncomingMessage/Details/5

        public ViewResult Details(string id)
        {
            IncomingMessage incomingmessage = repository.Single<IncomingMessage>(i => i.Id == id);
            return View(incomingmessage);
        }

        //
        // GET: /IncomingMessage/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /IncomingMessage/Create

        [HttpPost]
        public ActionResult Create(IncomingMessage incomingmessage)
        {
            if (ModelState.IsValid)
            {
                repository.Add<IncomingMessage>(incomingmessage);
                repository.UnitOfWork.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(incomingmessage);
        }
        
        //
        // GET: /IncomingMessage/Edit/5
 
        public ActionResult Edit(string id)
        {
            IncomingMessage incomingmessage = repository.Single<IncomingMessage>(i => i.Id == id);
            return View(incomingmessage);
        }

        //
        // POST: /IncomingMessage/Edit/5

        [HttpPost]
        public ActionResult Edit(IncomingMessage incomingmessage)
        {
            if (ModelState.IsValid)
            {
                repository.Update<IncomingMessage>(incomingmessage);
                repository.UnitOfWork.SaveChanges();          
                return RedirectToAction("Index");
            }
            return View(incomingmessage);
        }

        //
        // GET: /IncomingMessage/Delete/5
 
        public ActionResult Delete(string id)
        {
            IncomingMessage incomingmessage = repository.Single<IncomingMessage>(i => i.Id == id);
            return View(incomingmessage);
        }

        //
        // POST: /IncomingMessage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            IncomingMessage incomingMessage = repository.Single<IncomingMessage>(o => o.Id == id);
            repository.Delete<IncomingMessage>(incomingMessage);
            repository.UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}