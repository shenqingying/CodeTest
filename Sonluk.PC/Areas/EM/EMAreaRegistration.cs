using System.Web.Mvc;

namespace Sonluk.PC.Areas.EM
{
    public class EMAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EM_default",
                "EM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
