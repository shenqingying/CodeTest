using System.Web.Mvc;

namespace Sonluk.Areas.MM
{
    public class MMAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MM_default",
                "MM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
