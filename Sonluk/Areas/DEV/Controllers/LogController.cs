using Sonluk.Models;
using Sonluk.UI.Model.OA.FlowService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.DEV.Controllers
{
    public class LogController : Controller
    {
        DEVModels models = new DEVModels();
        OAModels OAModels = new OAModels();

        //
        // GET: /DEV/Log/
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /DEV/Log/_List
        [HttpPost]
        public ActionResult _List(int daysAge)
        {
            return PartialView(models.Log.Read(daysAge));
        }


        //
        // GET: /DEV/Log/OA
        public ActionResult OA()
        {
            return View();
        }

        //
        // POST: /DEV/Log/_OAList
        [HttpPost]
        public ActionResult _OAList(string startDate, string endDate, string keyword)
        {
            return PartialView(OAModels.Flow.Log(startDate, endDate, keyword));
        }

    }
}
