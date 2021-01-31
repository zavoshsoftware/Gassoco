using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GassoCo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{language}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, language = "fa" }
            );

            //  routes.MapRoute(
            //    name: "LocalizedDefault",
            //    url: "{lang}/{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index" },
            //    constraints: new { lang = "fa-ir|en-us" }
            //);

            //  routes.MapRoute(
            //      name: "Default",
            //      url: "{controller}/{action}",
            //      defaults: new { controller = "Home", action = "Index", lang = "en-us" }
            //  );
        }
    }
}
