using System.Web.Mvc;

namespace Sonluk.Areas.BC
{
    public class BCAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BC_default",
                "BC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
