using Sonluk.Filters;
using Sonluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.BC.Controllers
{
    public class EnqueueController : Controller
    {
        BCModels models = new BCModels();

        //
        // GET: /BC/Enqueue/
        [Authorization]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /BC/Enqueue/_List
        [HttpPost]
        public ActionResult _List(string value)
        {
            return PartialView(models.Enqueue.Read(value));
        }

    }
}
