using Sonluk.Filters;
using System.Web;
using System.Web.Mvc;

namespace Sonluk
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //登录验证
            filters.Add(new SignInAttribute());
            //反盗链
            //filters.Add(new AntiOutSiteLinkAttribute());  
            //日志
            //filters.Add(new LogAttribute());
        }
    }
}