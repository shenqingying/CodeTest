using System.Web.Mvc;

namespace Sonluk.PC.Areas.BARCODE
{
    public class BARCODEAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BARCODE";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BARCODE_default",
                "BARCODE/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
