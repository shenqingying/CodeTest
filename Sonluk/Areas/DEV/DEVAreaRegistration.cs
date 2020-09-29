using System.Web.Mvc;

namespace Sonluk.Areas.DEV
{
    public class DEVAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DEV";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DEV_default",
                "DEV/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
