using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Mobile.Areas.CRM.Controllers
{
    public class PublicController : Controller
    {
        //
        // GET: /CRM/Public/

        public ActionResult Index()
        {
            Session["TITLENAME"] = "主页";
            return View();
        }

        public ActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GlobalResources(string cultrue, string location)
        {
            string path = @"~/Global/" + location + "-" + cultrue + ".json";
            string path_zh = @"~/Global/" + location + "-zh" + ".json";
            string path_default = @"~/Global/" + location + ".json";
            if (new FileInfo(Server.MapPath(path)).Exists) return File(path, "application/json");
            else if (new FileInfo(Server.MapPath(path_default)).Exists) return File(path_default, "application/json");
            else if (new FileInfo(Server.MapPath(path_zh)).Exists) return File(path_zh, "application/json");
            else return Content("");
        }
    }
}
