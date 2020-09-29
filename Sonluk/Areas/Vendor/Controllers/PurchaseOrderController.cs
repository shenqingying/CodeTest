using Sonluk.Filters;
using Sonluk.Models;
using Sonluk.UI.Model.Account.AccessService;
using Sonluk.UI.Model.MM.PurchaseOrderService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.Vendor.Controllers
{
    public class PurchaseOrderController : Controller
    {
        MMModels models = new MMModels();

        //
        // GET: /Vendor/PurchaseOrder/
        [Authorization(Message = "Index")]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Vendor/PurchaseOrder/_List
        [HttpPost]
        public ActionResult _List(POKeywordInfo title)
        {
            title.Vendor = ((UI.Model.Account.AccessService.AccountInfo)Session["Account"]).ID;
            return PartialView(models.PurchaseOrder.Read(title));
        }

    }
}
