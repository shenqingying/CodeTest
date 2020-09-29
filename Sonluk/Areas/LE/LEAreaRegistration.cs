using System.Web.Mvc;

namespace Sonluk.Areas.LE
{
    public class LEAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "LE";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "LE_default",
                "LE/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
