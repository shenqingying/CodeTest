using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;


namespace Sonluk.Filters
{
public class AntiOutSiteLinkAttribute : ActionFilterAttribute, IActionFilter
{
    //61f0ebcc
    void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
    {
        HttpContextBase httpContext = filterContext.HttpContext;
        //if (null != httpContext.Request.UrlReferrer)
        //{
        //    string serverDomain = httpContext.Request.Url.Host;
        //    string refDomain = httpContext.Request.UrlReferrer.Host;
        //    if (!GetRootDomain(refDomain).Equals(GetRootDomain(serverDomain), StringComparison.OrdinalIgnoreCase))
        //    {
        //        filterContext.HttpContext.Session["SignInError"] = true;
        //        filterContext.HttpContext.Session["ErrorMessage"] = "数据获取异常，请登录！";

        //        if (filterContext.HttpContext.Request.IsAjaxRequest())
        //        {

        //            filterContext.Result = new JavaScriptResult() { Script = "<script>window.location.href='" + FormsAuthentication.LoginUrl + "';</script>" };
        //        }
        //        else
        //        {
        //            filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Access", action = "SignIn" }));
        //        }
        //    }
        //}


    }

    private string GetRootDomain(string domain)
    {
        if (string.IsNullOrEmpty(domain))
        {
            throw new ArgumentNullException("参数'domain'不能为空");
        }
        string[] arr = domain.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        if (arr.Length <= 2)
        {
            return domain;
        }
        else
        {
            return arr[arr.Length - 2] + "." + arr[arr.Length - 1];
        }
    }
}


}