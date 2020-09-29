using Sonluk.Models;
using Sonluk.UI.Model.LE.TRA.CityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class CityController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/City/
        public ActionResult Index()
        {
            return View(models.City.Read());
        }

        //
        // GET: /LE/City/_List
        public ActionResult _List()
        {
            return PartialView(models.City.Read());
        }

        //
        // GET: /LE/City/_Modify
        [HttpPost]
        public int _Modify(CityInfo node)
        {
            return models.City.Modify(node);
        }

        //
        // GET: /LE/City/_Delete
        [HttpPost]
        public int _Delete(int ID, bool province)
        {
            return models.City.Delete(ID, province);
        }

    }
}
