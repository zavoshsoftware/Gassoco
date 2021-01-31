using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Helpers
{
    public class MenuData
    {
        DatabaseContext db = new DatabaseContext();

        #region Menu

        public List<ParentChildProductGroupViewModel> ReturbParentChild()
        {
            List<ParentChildProductGroupViewModel> parentChildProductGroup =
                new List<ParentChildProductGroupViewModel>();

            List<ProductGroup> productGroups = ReturnProductGroupsByParent(null);

            foreach (ProductGroup item in productGroups)
            {
                if (ReturnProductGroupsByParent(item.Id).Any())
                {
                    parentChildProductGroup.Add(new ParentChildProductGroupViewModel()
                    {
                        ParentProductGroup = item,
                        ProductGroups =
                            ReturnProductGroupsByParent(item.Id).OrderBy(current => current.Priority).ToList(),
                    });
                }
            }
            return parentChildProductGroup;
        }

        public _MenuProductGroupViewModel MenuProductGroup()
        {
            _MenuProductGroupViewModel allProductGroup = new _MenuProductGroupViewModel();

            allProductGroup.ParentChildProductGroupViewModel = ReturbParentChild();
            allProductGroup.ProductGroupsWithoutChild = ReturnProductGroupWithoutChild();

            return allProductGroup;
        }

        public List<ProductGroup> ReturnProductGroupWithoutChild()
        {
            List<ProductGroup> oProductGroups = new List<ProductGroup>();

            List<ProductGroup> productGroups = db.ProductGroups
                .Where(current => current.IsDelete == false && current.ParentId == null)
                .OrderBy(current => current.Priority).ToList();

            foreach (ProductGroup item in productGroups)
            {
                if (!db.ProductGroups.Any(current => current.ParentId == item.Id))
                {
                    oProductGroups.Add(item);
                }
            }
            return oProductGroups;
        }

        public List<ProductGroup> ReturnProductGroupsByParent(Guid? parentId)
        {
            return db.ProductGroups.OrderByDescending(current => current.Priority).Where(current =>
                    current.IsDelete == false && current.ParentId == parentId)
                .ToList();
        }

        public _FooterViewModel ReturnFooterViewModel()
        {
            _FooterViewModel footer = new _FooterViewModel()
            {
                Blogs = ReturnRecentBlog(),
                FooterText = ReternFooterText("39810742-5867-49bf-a5a4-f40bb8ecfd26"),
                AddressText = ReternFooterText("5d0b59b0-f5ba-4c13-943c-fdd002cd3dc9"),
                PhoneText = ReternFooterText("638e0195-568f-4df3-ad0a-c179cfebc409"),
                FaxText = ReternFooterText("9169d906-4894-4386-b1ee-321a3fbdd80b"),
                EmailText = ReternFooterText("ad3f9a5f-7202-406a-b0b7-91672366c3ac"),
                ZavoshLink = GetFooterLink()
            };
            return footer;
        }

        public string GetFooterLink()
        {
            string url = HttpContext.Current.Request.Url.PathAndQuery;
            if (url.ToLower() == "/fa")
                return
                    "<a href='https://zavoshsoftware.com/page/%D8%B7%D8%B1%D8%A7%D8%AD%DB%8C-%D9%88%D8%A8-%D8%B3%D8%A7%DB%8C%D8%AA'>طراحی سایت</a> توسط <a target='_blank' href='https://zavoshsoftware.com/'>زاوش</a>";
            if (url.ToLower() == "/en")
                return
                    "develop by <a target='_blank' href='https://zavoshsoftware.com/'>ZAVOSH</a>";

            if (url.Contains("/fa"))
                return "طراحی سایت توسط <a target='_blank' href='https://zavoshsoftware.com/' rel='nofollow'>زاوش</a>";

            else
                return "zavosh";
        }
      
    

    public List<Blog> ReturnRecentBlog()
        {
            return db.Blogs.Where(current => current.IsDelete == false).OrderBy(current => current.Order).ThenByDescending(current => current.SubmitDate)
                .Take(3).ToList();
        }

        public TextTypeItem ReternFooterText(string id)
        {
            return db.TextTypeItems.Find(new Guid(id));
        }

        public TextTypeItem ReturnInnerSlider()
        {
            return db.TextTypeItems.Find(new Guid("3be879cd-a54c-4014-a165-bba718252d7c"));
        }

        #endregion

        #region Culture

        public void SetCurrentCulture(string language)
        {
            if (language == null)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fa-IR");
                SetCookie("fa_IR");
            }
            else
            {
                if (language.ToLower() == "fa")
                {
                    SetCookie("fa_IR");
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fa-IR");

                }
                else
                {
                    SetCookie("en-US");
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                }
            }
        }

        private const string LanguageCookieName = "MyLanguageCookieName";

        private void SetCookie(string niputCoockie)
        {
            var lang = niputCoockie;
            var httpCookie = new HttpCookie(LanguageCookieName, lang) { Expires = DateTime.Now.AddYears(1) };
            HttpContext.Current.Response.SetCookie(httpCookie);
        }

        #endregion

    }
}