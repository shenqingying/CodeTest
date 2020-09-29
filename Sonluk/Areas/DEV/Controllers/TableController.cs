using Sonluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.DEV.Controllers
{
    public class TableController : Controller
    {
        DEVModels models = new DEVModels();

        //
        // GET: /DEV/Table/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /DEV/Table/Read
        [HttpPost]
        public string _Read(string name)
        {
            return models.Table.Read(name);
        }

    }
}
