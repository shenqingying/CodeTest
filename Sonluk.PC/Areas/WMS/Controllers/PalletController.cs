using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sonluk.API.SDK.Http;
using Sonluk.PC.APPCLASS;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.WMS.Controllers
{
    public class PalletController : Controller
    {
        public ActionResult Index()
        {
            AppClass.SetSession("location", 0);
            return View();
        }
        public ActionResult Management()
        {
            AppClass.SetSession("location", 20020);
            return View();
        }
        public ActionResult Search()
        {
            AppClass.SetSession("location", 20021);
            return View();
        }
        public ActionResult StackSearch()
        {
            AppClass.SetSession("location", 20022);
            return View();
        }
        public ActionResult VehicleRequest()
        {
            AppClass.SetSession("location", 20023);
            return View();
        }

        [HttpPost]
        public ActionResult SearchExport(string input)
        {
            Stream rst = new SHttp().SApiDownload("WMS", "WMS/BC_TPM/Export", input);
            return File(rst, "application/vnd.ms-excel", "托盘信息查询导出.xls");
        }
        [HttpPost]
        public ActionResult SearchPrint(string input)
        {
            ViewBag.TPNOs = JsonConvert.DeserializeObject<List<string>>(input);
            return View();
        }
        [HttpPost]
        public ActionResult StackSearchExport(string input)
        {
            Stream rst = new SHttp().SApiDownload("WMS", "WMS/BC_TPM/StackExport", input);
            return File(rst, "application/vnd.ms-excel", "托盘组合码查询导出.xls");
        }
        [HttpPost]
        public ActionResult StackSearchPrint(string input)
        {
            ViewBag.TPZHNOs = JsonConvert.DeserializeObject<JArray>(input);
            return View();
        }
    }
}
