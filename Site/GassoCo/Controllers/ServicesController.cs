using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.ViewModels;

namespace GassoCo.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ServicesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Services
        public ActionResult Index()
        {
            ViewBag.Title = "فهرست خدمات";
            return View(db.Services.Where(a => a.IsDelete == false).OrderBy(a => a.SubmitDate).ToList());
        }


        // GET: Services/Create
        public ActionResult Create()
        {
            ViewBag.Title = "افزودن خدمت";
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Priority,IsDelete,SubmitDate,DeleteDate")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.IsDelete = false;
                service.SubmitDate = DateTime.Now;
                service.Id = Guid.NewGuid();
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Title = "افزودن خدمت";
            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "ویرایش خدمت";
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Service service)
        {
            if (ModelState.IsValid)
            {
                service.LastModificationDate = DateTime.Now;
                service.IsDelete = false;
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Title = "ویرایش خدمت";
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "حذف خدمت";
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Service service = db.Services.Find(id);
            service.IsDelete = true;
            service.DeleteDate = DateTime.Now;

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

        [AllowAnonymous]
        [Route("{language}/service")]
        public ActionResult List(string language)
        {

            Helpers.MenuData menuData = new Helpers.MenuData();

            menuData.SetCurrentCulture(language);

            ServiceListViewModel service = new ServiceListViewModel();
            service.Services = db.Services.Where(current => current.IsDelete == false)
                 .OrderBy(current => current.Priority).ToList();
            service.MenuProductGroupViewModel = menuData.MenuProductGroup();
            service.Footer = menuData.ReturnFooterViewModel();
            service.ServiceText = db.TextTypeItems.Find(new Guid("3488bb81-93f7-4c9e-8852-f140e9af8855"));
            service.InnerSlide = menuData.ReturnInnerSlider();


            if (language == "fa")
            {
                ViewBag.Title = "خدمات گروه صنعتی گازسو | تجهیزات رستوران";
                ViewBag.Description =
                    "شرکت گازسو با بیش از نیم قرن تجربه در صنعت غذا و رستوران، از مرحله طراحي تا بهره برداري، همراه مورد اعتماد شما در پروژه هاي صنعت غذا ، شامل كيترينگ ،رستوران ،كافي شاپ و نانوايي خواهد بود. و مسئولیت کل پروژه را بر عهده خواهد گرفت";
            }
            else
            {
                ViewBag.Title = "gasso group | restaurants equipment";
            }

            return View(service);
        }
    }
}
