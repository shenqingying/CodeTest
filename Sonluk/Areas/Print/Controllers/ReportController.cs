using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.Print.Controllers
{
    public class ReportController : Controller
    {

        //
        // GET: /Print/Report/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Print/Report/IQCPM
        public ActionResult IQCPM()
        {
            return View();
        }

        //
        // GET: /Print/Report/PurchaseOrder
        public ActionResult PurchaseOrder()
        {

            return View();
        }



    }
}
