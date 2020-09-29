using Sonluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class SenderController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/Sender/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Sender/_List
        public ActionResult _List()
        {
            return PartialView(models.Sender.Read());
        }
        public ActionResult _ListTYLB()
        {
            return PartialView();
        }
        //
        // GET: /LE/Sender/_Single
        public ActionResult _Single(string serialNumber)
        {
            return PartialView(models.Sender.Read(serialNumber));
        }
    }
}
