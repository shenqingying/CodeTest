using System.Web.Mvc;

namespace Sonluk.PC.Areas.FICO
{
    public class FICOAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FICO";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "FICO_default",
                "FICO/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
