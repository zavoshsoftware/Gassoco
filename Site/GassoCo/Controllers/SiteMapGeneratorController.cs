using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers;
using Models;

namespace GassoCo.Controllers
{
    public class SiteMapGeneratorController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        [Route("{language?}/sitemap")]
        public ActionResult Sitemap(string language)
        {
            Sitemap sm = new Sitemap();

            StaticPageSiteMap(sm);
            ProductGroupsSiteMap(sm);
            ProductsSiteMap(sm);
            BlogsSiteMap(sm);
            GalleriesSiteMap(sm);
            return new XmlResult(sm);
        }

        public void GalleriesSiteMap(Sitemap sm)
        {
            AddToSiteMap(sm, "http://gassoco.com/fa/gallery/", 0.6D, Location.eChangeFrequency.monthly);
            AddToSiteMap(sm, "http://gassoco.com/en/gallery/", 0.6D, Location.eChangeFrequency.yearly);


            List<Gallery> galleries = db.Galleries.Where(current => current.IsDelete == false).ToList();

            foreach (Gallery gallery in galleries)
            {
                AddToSiteMap(sm, "http://gassoco.com/fa/gallery/" + gallery.Id, 0.7D, Location.eChangeFrequency.monthly);
                AddToSiteMap(sm, "http://gassoco.com/en/gallery/" + gallery.Id, 0.4D, Location.eChangeFrequency.yearly);
            }
        }

        public void BlogsSiteMap(Sitemap sm)
        {
            AddToSiteMap(sm, "http://gassoco.com/fa/blog/", 0.7D, Location.eChangeFrequency.weekly);
            AddToSiteMap(sm, "http://gassoco.com/en/blog/", 0.7D, Location.eChangeFrequency.yearly);


            List<Blog> blogs = db.Blogs.Where(current => current.IsDelete == false).ToList();

            foreach (Blog blog in blogs)
            {
                AddToSiteMap(sm, "http://gassoco.com/fa/blog/" + blog.Id, 0.9D, Location.eChangeFrequency.monthly);
                AddToSiteMap(sm, "http://gassoco.com/en/blog/" + blog.Id, 0.4D, Location.eChangeFrequency.yearly);
            }
        }

        public void ProductsSiteMap(Sitemap sm)
        {
            List<Product> products = db.Products.Where(current => current.IsDelete == false).ToList();

            foreach (Product product in products)
            {
                AddToSiteMap(sm, "http://gassoco.com/fa/product/" + product.ProductGroupId + "/" + product.Id, 0.9D, Location.eChangeFrequency.monthly);
                AddToSiteMap(sm, "http://gassoco.com/en/product/" + product.ProductGroupId + "/" + product.Id, 0.4D, Location.eChangeFrequency.yearly);
            }
        }

        public void ProductGroupsSiteMap(Sitemap sm)
        {
            List<ProductGroup> productGroups = db.ProductGroups
                .Where(current => current.IsDelete == false && current.ParentId == null).ToList();

            foreach (ProductGroup productGroup in productGroups)
            {
                if (db.ProductGroups.Any(current => current.ParentId == productGroup.Id && current.IsDelete == false))
                {
                    AddToSiteMap(sm, "http://gassoco.com/fa/productgroup/" + productGroup.Id, 0.9D, Location.eChangeFrequency.weekly);
                    AddToSiteMap(sm, "http://gassoco.com/en/productgroup/" + productGroup.Id, 0.4D, Location.eChangeFrequency.yearly);
                }
                else
                {
                    AddToSiteMap(sm, "http://gassoco.com/fa/product/" + productGroup.Id, 0.9D, Location.eChangeFrequency.weekly);
                    AddToSiteMap(sm, "http://gassoco.com/en/product/" + productGroup.Id, 0.4D, Location.eChangeFrequency.yearly);
                }
            }

            productGroups = db.ProductGroups
                          .Where(current => current.IsDelete == false && current.ParentId != null).ToList();

            foreach (ProductGroup productGroup in productGroups)
            {
                AddToSiteMap(sm, "http://gassoco.com/fa/product/" + productGroup.Id, 0.9D, Location.eChangeFrequency.weekly);
                AddToSiteMap(sm, "http://gassoco.com/en/product/" + productGroup.Id, 0.4D, Location.eChangeFrequency.yearly);
            }
        }

        public void StaticPageSiteMap(Sitemap sm)
        {
            //Home
            AddToSiteMap(sm, "http://gassoco.com/fa", 0.8D, Location.eChangeFrequency.weekly);
            AddToSiteMap(sm, "http://gassoco.com/en", 0.4D, Location.eChangeFrequency.monthly);

            //Services
            AddToSiteMap(sm, "http://gassoco.com/fa/service", 0.5D, Location.eChangeFrequency.monthly);
            AddToSiteMap(sm, "http://gassoco.com/en/service", 0.2D, Location.eChangeFrequency.yearly);

            //career
            AddToSiteMap(sm, "http://gassoco.com/fa/career", 0.1D, Location.eChangeFrequency.yearly);
            AddToSiteMap(sm, "http://gassoco.com/en/career", 0.1D, Location.eChangeFrequency.yearly);

            //about
            AddToSiteMap(sm, "http://gassoco.com/fa/about", 0.5D, Location.eChangeFrequency.monthly);
            AddToSiteMap(sm, "http://gassoco.com/en/about", 0.2D, Location.eChangeFrequency.yearly);

            //contact
            AddToSiteMap(sm, "http://gassoco.com/fa/contact", 0.5D, Location.eChangeFrequency.yearly);
            AddToSiteMap(sm, "http://gassoco.com/en/contact", 0.2D, Location.eChangeFrequency.yearly);


            //Catalog
            AddToSiteMap(sm, "http://gassoco.com/fa/catalog", 0.5D, Location.eChangeFrequency.monthly);
            AddToSiteMap(sm, "http://gassoco.com/en/catalog", 0.2D, Location.eChangeFrequency.yearly);
        }

        public void AddToSiteMap(Sitemap sm, string url, double? priority, Location.eChangeFrequency frequency)
        {
            sm.Add(new Location()
            {
                // Url = string.Format("http://www.TechnoDesign.ir/Articles/{0}/{1}", 1, "SEO-in-ASP.NET-MVC"),
                Url = url,
                LastModified = DateTime.UtcNow,
                Priority = priority,
                ChangeFrequency = frequency
            });
        }
    }
}