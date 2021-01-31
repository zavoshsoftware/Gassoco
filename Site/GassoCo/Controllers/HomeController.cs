using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers;
using Models.ViewModels;
using System.Text.RegularExpressions;

namespace GassoCo.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("{language?}")]
        public ActionResult Index(string language)
        {
            if (language == null)
                return RedirectPermanent("/fa");

            else if (language.ToLower() == "contact")
                return RedirectToAction("contact", "Home", new { language = "fa" });

            else if (language.ToLower() == "about")
                return RedirectToAction("about", "Home", new { language = "fa" });

            else if (language.ToLower() == "service")
                return RedirectToAction("List", "Services", new { language = "fa" });

            else if (language.ToLower() == "blog")
                return RedirectToAction("List", "Blogs", new { language = "fa" });

            else if (language.ToLower() == "gallery")
                return RedirectToAction("List", "Galleries", new { language = "fa" });

            else if (language.ToLower() == "career")
                return RedirectToAction("Request", "Careers", new { language = "fa" });

            else if (language.ToLower() == "login")
                return RedirectToAction("login", "Account");
            Helpers.MenuData menuData = new MenuData();
            menuData.SetCurrentCulture(language);

            HomeViewModel homeViewModel = new HomeViewModel
            {
                MenuProductGroupViewModel = menuData.MenuProductGroup(),
                WhyTextItems = ReturnTextItems(new Guid("7c1e6a81-8a09-449b-bcc0-2ce5c55affbe"), new Guid("cbbc2db6-49bd-42a2-9e95-053eb5672b9d")),
                AboutTextItem = ReturnSigleTextItem(new Guid("a65555d6-9796-4e25-b684-b614a6244630")),
                AboutTextItemSecond = ReturnSigleTextItem(new Guid("8d543118-881f-4d01-bbe7-8e6ec5559e6a")),
                RecentBlogs = ReturnRecentBlog(),
                Footer = menuData.ReturnFooterViewModel(),
                Products = ReturnTopProducts(),
                WhyTitle = db.TextTypeItems.Find(new Guid("cbbc2db6-49bd-42a2-9e95-053eb5672b9d")),
                InnerSlide = menuData.ReturnInnerSlider(),
                Sliders = db.Sliders.Where(p => p.IsDelete == false).OrderByDescending(t => t.Priority).ToList()
            };

            if (language == "fa")
            {
                ViewBag.Title = "تجهیزات آشپزخانه صنعتی - گازسو";
                ViewBag.Description =
                    "تجهیزات آشپزخانه صنعتی گازسو با بیش از نیم قرن تجربه در حوزه تولید تجهیزات آشپزخانه های صنعتی و تجهیزات رستوران ها یکی از قدیمی ترین تولید کنندگان این حوزه می باشد. تجهیزاتی از جمله تجهیزات پخت، ترولی و سلف سرویس، قفسه بندی و یخچال ها و ماشین های ظرفشویی و تجهیزات نانوایی تعدادی از تولیدات گازسو می باشد.";
                ViewBag.canonical = "http://gassoco.com/fa";
            }
            else
            {
                ViewBag.Title = "gasso group";
                ViewBag.Description = "In GASSO GROUP, a Brand with International Presence and Word-Wide recognition for Quality and Trust, we believe that our clients with their ever-expanding demand for Excellence";
                ViewBag.canonical = "http://gassoco.com/en";
            }
            return View(homeViewModel);
        }
        


        public List<Blog> ReturnRecentBlog()
        {
            return db.Blogs.Where(current => current.IsDelete == false).OrderBy(current => current.Order)
                .ThenByDescending(current => current.SubmitDate).Take(3).ToList();
        }
        public List<TextTypeItem> ReturnTextItems(Guid typeId, Guid? constraint)
        {
            if (constraint == null)
                return db.TextTypeItems.Where(current => current.TextTypeId == typeId).ToList();
            else
                return db.TextTypeItems.Where(current => current.TextTypeId == typeId && current.Id != constraint).ToList();

        }
        public TextTypeItem ReturnSigleTextItem(Guid typeId)
        {
            return db.TextTypeItems.Find(typeId);
        }

        public List<Product> ReturnTopProducts()
        {
            return db.Products.Where(current => current.IsInHome == true && current.IsDelete == false).ToList();
        }
        [Route("{language}/contact")]
        public ActionResult Contact(string language)
        {

            Helpers.MenuData menuData = new MenuData();

            menuData.SetCurrentCulture(language);

            ContactViewModel contactViewModel = new ContactViewModel
            {
                Footer = menuData.ReturnFooterViewModel(),
                MenuProductGroupViewModel = menuData.MenuProductGroup(),
                InnerSlide = menuData.ReturnInnerSlider()
            };

            return View(contactViewModel);
        }

        [Route("{language}/about")]
        public ActionResult About(string language)
        {

            Helpers.MenuData menuData = new MenuData();
            menuData.SetCurrentCulture(language);

            AboutViewModel aboutViewModel = new AboutViewModel
            {
                MenuProductGroupViewModel = menuData.MenuProductGroup(),
                Footer = menuData.ReturnFooterViewModel(),
                AboutCompanyText = db.TextTypeItems.Find(new Guid("afdd0f19-9f09-4b54-af87-9b05ae38e28a")),
                CompanyVisionText = db.TextTypeItems.Find(new Guid("ce2f47cf-acc9-4160-8dd1-f46edc8161ff")),
                InnerSlide = menuData.ReturnInnerSlider(),
                Certificates = db.Certificates.Where(p => p.IsDelete == false).ToList()
            };

            return View(aboutViewModel);
        }

        [AllowAnonymous]
        public ActionResult NewsLetter(string Email)
        {
            bool isEmail = Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            if (!isEmail)
            {
                return Json("InvalidEmail", JsonRequestBehavior.AllowGet);
            }
            else
            {
                InsertNewsletter(Email);
                return Json("true", JsonRequestBehavior.AllowGet);
            }
        }

        public void InsertNewsletter(string Email)
        {
            NewsLetter nl = new Models.NewsLetter()
            {
                Id = Guid.NewGuid(),
                IsDelete = false,
                SubmitDate = DateTime.Now,
                Email = Email

            };
            db.NewsLetters.Add(nl);
            db.SaveChanges();
        }
    }
}