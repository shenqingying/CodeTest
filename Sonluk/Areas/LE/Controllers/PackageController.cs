using Sonluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class PackageController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/Package/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Package/_Type
        public ActionResult _Type()
        {
            return PartialView(models.Package.Type());
        }

    }
}
