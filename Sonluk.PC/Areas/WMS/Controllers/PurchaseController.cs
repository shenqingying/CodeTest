using Sonluk.API.SDK.Http;
using Sonluk.PC.APPCLASS;
using System.IO;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.WMS.Controllers
{
    public class PurchaseController : Controller
    {
        public ActionResult Index()
        {
            AppClass.SetSession("location", 0);
            return View();
        }
        public ActionResult EntryQC()
        {
            AppClass.SetSession("location", 20010);
            return View();
        }
        public ActionResult EntryReportBC()
        {
            AppClass.SetSession("location", 20011);
            return View();
        }
        public ActionResult WHEntryBC()
        {
            AppClass.SetSession("location", 20012);
            return View();
        }
        [HttpPost]
        public ActionResult ExportEntryReport(string input)
        {
            Stream rst = new SHttp().SApiDownload("WMS", "WMS/CG_SHNO/REPORT_ITEM", input);
            return File(rst, "application/vnd.ms-excel", "入库送检单(包材类)查询报表.xls");
        }
    }
}
