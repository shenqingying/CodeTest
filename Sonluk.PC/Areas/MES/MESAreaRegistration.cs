using System.Web.Mvc;

namespace Sonluk.PC.Areas.MES
{
    public class MESAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MES";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MES_default",
                "MES/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
