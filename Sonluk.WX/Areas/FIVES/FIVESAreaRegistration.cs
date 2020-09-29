using System.Web.Mvc;

namespace Sonluk.WX.Areas.FIVES
{
    public class FIVESAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FIVES";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "FIVES_default",
                "FIVES/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
