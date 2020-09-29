using Sonluk.Models;
using Sonluk.UI.Model.LE.TRA.RouteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class RouteController : Controller
    {
        LETRAModels _Models = new LETRAModels();

        //
        // GET: /LE/Route/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Route/_Edit
        [HttpPost]
        public ActionResult _Edit(int cityID)
        {
            return PartialView(_Models.Route.Read(cityID));
        }


        //
        // GET: /LE/Route/_Update
        [HttpPost]
        public int _Update(RouteInfo node)
        {
            return _Models.Route.Update(node);
        }


        //
        // GET: /LE/City/_Read
        public JsonResult _Read(int source, int destination, decimal weight, string departure)
        {
            JsonResult json = new JsonResult();
            json.Data = _Models.Route.Read(source, destination, weight, departure);
            return json;
        }

    }
}
