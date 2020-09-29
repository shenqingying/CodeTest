using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sonluk.WX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{area}/{controller}/{action}/{id}",
                defaults: new { area = "CRM", controller = "Public", action = "GetCode", id = UrlParameter.Optional },
                namespaces: new[] { "Sonluk.PC.Areas.CRM.Controllers" }
            ).DataTokens.Add("area","CRM");
        }
    }
}