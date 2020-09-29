using Sonluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class CarrierController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/Carrier/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Carrier/_List
        public ActionResult _List()
        {
            return PartialView(models.Carrier.Read());
        }

    }
}
