using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sonluk.Filters
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string area = "";
            if (filterContext.RouteData.DataTokens["area"] != null)
            {
                area = (filterContext.RouteData.DataTokens["area"]).ToString() + "/";
            }
            string controller = (filterContext.RouteData.Values["controller"]).ToString();
            string action = (filterContext.RouteData.Values["action"]).ToString();

            string route = "";
            if (filterContext.HttpContext.Request.QueryString["Auth"] != null)
            {
                route = area + controller + "/" + action + "?Auth=" + (filterContext.HttpContext.Request.QueryString["Auth"]).ToString();
            }
            else
            {
                route = area + controller + "/" + action;
            }

            IList<string> routes = (IList<string>)filterContext.HttpContext.Session["Authorization"];
            bool access = false;
            if (routes != null)
            {
                foreach (string item in routes)
                {
                    if (route.Equals(item))
                    {
                        access = true;
                        break;
                    }
                }
            }

            if (!access)
            {
                filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Access", action = "Error" }));
            }
                

        }
    }
}

//[Authorization(Message = "Index")]