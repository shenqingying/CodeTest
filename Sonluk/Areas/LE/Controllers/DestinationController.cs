using Sonluk.Models;
using Sonluk.UI.Model.LE.TRA.DestinationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class DestinationController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/Destination/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Destination/_Modify
        [HttpPost]
        public int _Modify(DestinationInfo node)
        {
            return models.Destination.Modify(node);
        }
    }
}
