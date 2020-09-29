using Sonluk.API.SDK;
using Sonluk.API.SDK.Http;
using System.IO;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class ToolsController : Controller
    {
        //
        // GET: /MES/Show/
        SHttp sHttp = new SHttp();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EasyTools()
        {
            return View();
        }

        [HttpPost]
        public string GetUrl(string inputStr)
        {
            return sHttp.SApiPost("MES", "Helper/Text/ReadTag", inputStr);
        }

        [HttpPost]
        public string EasyEncrypt(string inputStr)
        {
            return sHttp.SApiPost("MES", "Helper/Scy/Encrypt", inputStr);
        }

        [HttpPost]
        public string EasyDecrypt(string inputStr)
        {
            return sHttp.SApiPost("MES", "Helper/Scy/Decrypt", inputStr);
        }

        [HttpPost]
        public string ApiPostTest(string location, string inputStr)
        {
            return sHttp.SApiPost("MES", location, inputStr);
        }

        [HttpPost]
        public ActionResult UploadTest(string location, string inputStr)
        {
            return Content(sHttp.SApiPost("MES", location, inputStr, SConvert.FilesToDic(HttpContext.Request.Files)));
        }

        [HttpPost]
        public ActionResult GlobalResources(string culture, string location)
        {
            string path = @"~/Global/" + location + "-" + culture + ".json";
            string path_zh = @"~/Global/" + location + "-zh" + ".json";
            string path_default = @"~/Global/" + location + ".json";
            if (new FileInfo(Server.MapPath(path)).Exists) return File(path, "application/json");
            else if (new FileInfo(Server.MapPath(path_default)).Exists) return File(path_default, "application/json");
            else if (new FileInfo(Server.MapPath(path_zh)).Exists) return File(path_zh, "application/json");
            else return Content("");
        }
    }
}
