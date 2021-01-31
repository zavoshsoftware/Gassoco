using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace GassoCo.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ServiceItemsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ServiceItems
        public ActionResult Index()
        {
            var serviceItems = db.ServiceItems.Include(s => s.Service).Where(s=>s.IsDelete==false)
                .OrderBy(s=>s.Service.Priority).ThenBy(current=>current.Priority);
            return View(serviceItems.ToList());
        }

        // GET: ServiceItems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceItem serviceItem = db.ServiceItems.Find(id);
            if (serviceItem == null)
            {
                return HttpNotFound();
            }
            return View(serviceItem);
        }

        // GET: ServiceItems/Create
        public ActionResult Create()
        {
            ViewBag.ServiceId = new SelectList(db.Services.Where(current=>current.IsDelete==false).OrderBy(current=>current.Priority), "Id", "Title");
            return View();
        }

        // POST: ServiceItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceItem serviceItem)
        {
            if (ModelState.IsValid)
            {
				serviceItem.IsDelete=false;
				serviceItem.SubmitDate= DateTime.Now; 
                serviceItem.Id = Guid.NewGuid();
                db.ServiceItems.Add(serviceItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceId = new SelectList(db.Services.Where(current => current.IsDelete == false).OrderBy(current => current.Priority), "Id", "Title");
            return View(serviceItem);
        }

        // GET: ServiceItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceItem serviceItem = db.ServiceItems.Find(id);
            if (serviceItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceId = new SelectList(db.Services.Where(current => current.IsDelete == false).OrderBy(current => current.Priority), "Id", "Title", serviceItem.ServiceId);
            return View(serviceItem);
        }

        // POST: ServiceItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceItem serviceItem)
        {
            if (ModelState.IsValid)
            {
                serviceItem.LastModificationDate = DateTime.Now;
				serviceItem.IsDelete=false;
                db.Entry(serviceItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceId = new SelectList(db.Services.Where(current => current.IsDelete == false).OrderBy(current => current.Priority), "Id", "Title", serviceItem.ServiceId);
            return View(serviceItem);
        }

        // GET: ServiceItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceItem serviceItem = db.ServiceItems.Find(id);
            if (serviceItem == null)
            {
                return HttpNotFound();
            }
            return View(serviceItem);
        }

        // POST: ServiceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ServiceItem serviceItem = db.ServiceItems.Find(id);
			serviceItem.IsDelete=true;
			serviceItem.DeleteDate=DateTime.Now;
 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
