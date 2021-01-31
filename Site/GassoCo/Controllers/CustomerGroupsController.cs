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
    public class CustomerGroupsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: CustomerGroups
        public ActionResult Index()
        {
            return View(db.CustomerGroups.Where(a=>a.IsDelete==false).OrderByDescending(a=>a.SubmitDate).ToList());
        }

        // GET: CustomerGroups/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerGroup customerGroup = db.CustomerGroups.Find(id);
            if (customerGroup == null)
            {
                return HttpNotFound();
            }
            return View(customerGroup);
        }

        // GET: CustomerGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,IsDelete,SubmitDate,DeleteDate")] CustomerGroup customerGroup)
        {
            if (ModelState.IsValid)
            {
				customerGroup.IsDelete=false;
				customerGroup.SubmitDate= DateTime.Now; 
                customerGroup.Id = Guid.NewGuid();
                db.CustomerGroups.Add(customerGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerGroup);
        }

        // GET: CustomerGroups/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerGroup customerGroup = db.CustomerGroups.Find(id);
            if (customerGroup == null)
            {
                return HttpNotFound();
            }
            return View(customerGroup);
        }

        // POST: CustomerGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,IsDelete,SubmitDate,DeleteDate")] CustomerGroup customerGroup)
        {
            if (ModelState.IsValid)
            {
				customerGroup.IsDelete=false;
                db.Entry(customerGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerGroup);
        }

        // GET: CustomerGroups/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerGroup customerGroup = db.CustomerGroups.Find(id);
            if (customerGroup == null)
            {
                return HttpNotFound();
            }
            return View(customerGroup);
        }

        // POST: CustomerGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CustomerGroup customerGroup = db.CustomerGroups.Find(id);
			customerGroup.IsDelete=true;
			customerGroup.DeleteDate=DateTime.Now;
 
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
