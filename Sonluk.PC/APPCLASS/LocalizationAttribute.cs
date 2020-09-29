using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.APPCLASS
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ///从cookie里读取语言设置
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies["Sonluk.Local.Culture"];
            if (cookie != null)
            {
                ///根据cookie设置语言（默认语言则传空字符串）
                string culture = "";
                if (cookie.Value != "zh" && cookie.Value != "zh_CN") culture = cookie.Value;
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
            }
            else
            {
                ///如果读取cookie失败则设置默认语言
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(filterContext.HttpContext.Request.UserLanguages[0]);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}