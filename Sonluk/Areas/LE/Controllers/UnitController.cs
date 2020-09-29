using Sonluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class UnitController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/Unit/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Unit/_List
        public ActionResult _List()
        {
            return PartialView(models.Unit.Read());
        }

    }
}
