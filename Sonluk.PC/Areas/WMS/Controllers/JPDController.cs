using Sonluk.PC.APPCLASS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.WMS.Controllers
{
    public class JPDController : Controller
    {
        //
        // GET: /WMS/JPD/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JPDMANAGE()
        {
            AppClass.SetSession("location", 10120);

            return View();
        }
    }
}
