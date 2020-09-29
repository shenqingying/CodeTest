using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using Sonluk.Models;
using System.Text.RegularExpressions;
using Sonluk.Utility;

namespace Sonluk.Filters
{
    public class SignInAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            bool access = false;
            if (filterContext.RouteData.DataTokens["area"] != null)
            {
                string controller = (filterContext.RouteData.Values["controller"]).ToString();
                if (filterContext.HttpContext.Session["Account"] != null)
                {
                    access = true;
                }
                else
                {
                    //大屏显示功能免登录
                    if (filterContext.RouteData.Values["action"].ToString().IndexOf("Pickingtask") >= 0)
                        access = true;

                    var parameters = filterContext.ActionDescriptor.GetParameters();
                    string[] path = new string[] { controller, "Index" };
                    if (parameters.Count() == 0)
                        path[1] = (filterContext.RouteData.Values["action"]).ToString();

                    filterContext.HttpContext.Session["AccessErrorPath"] = path;
                    filterContext.HttpContext.Session["SignInError"] = true;
                    filterContext.HttpContext.Session["ErrorMessage"] = "跳转异常或登录过期，请重新登录";
                }

            }
            else
            {

                access = true;

            }

            if (!access)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {

                    filterContext.Result = new JavaScriptResult() { Script = "<script>window.location.href='" + FormsAuthentication.LoginUrl + "';</script>" };
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Access", action = "SignIn" }));
                }
            }

        }
    }
}