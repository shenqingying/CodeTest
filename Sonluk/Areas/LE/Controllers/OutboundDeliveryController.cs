using Sonluk.Filters;
using Sonluk.Models;
using Sonluk.UI.Model.LE.OutboundDeliveryService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.Models;
using Sonluk.UI.Model.Account.AccessService;

namespace Sonluk.Areas.LE.Controllers
{
    public class OutboundDeliveryController : Controller
    {
        LEModels models = new LEModels();
        LETRAModels letramodels = new LETRAModels();

        //
        // GET: /LE/OutboundDelivery/
        [Authorization(Message = "Index")]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /LE/OutboundDelivery/_List
        [HttpPost]
        public ActionResult _List(DeliveryInfo keyword)
        {
            return PartialView(models.OutboundDelivery.Read(keyword));
        }

        //
        // GET: /LE/OutboundDelivery/_CNDeliveryList
        [HttpPost]
        public ActionResult _CNDeliveryList(string serialNumber)
        {
            AccountInfo account = (AccountInfo)Session["Account"];
            return PartialView(letramodels.ConsignmentNote.CNDeliveryUPDATE(serialNumber.Trim(), -1, 1, account.Name, account.ID));
        }

        //
        // POST: /LE/OutboundDelivery/_Items
        [HttpPost]
        public ActionResult _Items(string serialNumber)
        {
            return PartialView(models.OutboundDelivery.ItemRead(serialNumber));
        }


        //
        // POST: /MM/OutboundDelivery/_PrepareExport
        [HttpPost]
        public int _PrepareExport(IList<DeliveryInfo> nodes)
        {
            Session["OutboundDeliveryExportData"] = nodes;
            return 1;
        }

        //
        // GET: /MM/OutboundDelivery/_Export
        public ActionResult _Export()
        {
            IList<DeliveryInfo> nodes = (IList<DeliveryInfo>)Session["OutboundDeliveryExportData"];
            Session["OutboundDeliveryExportData"] = null;
            MemoryStream memoryStream = models.OutboundDelivery.Export(nodes);
            string fileName = "交货单[" + DateTime.Now.ToString("yyMMdd") + "].xls";
            return File(memoryStream.ToArray(), "application/vnd.ms-excel", HttpContext.Request.Browser.Browser == "IE" ? Url.Encode(fileName) : fileName);
        }

        //
        // GET: /LE/OutboundDelivery/Back
        public ActionResult Back()
        {
            return View();
        }

        //
        // GET: /LE/OutboundDelivery/Confirm
        public ActionResult Confirm()
        {
            return View();
        }

        ////
        //// POST: /Access/UpdatePassword
        //[HttpPost]
        //public ActionResult Confirm(string serialNumber)
        //{
        //    AccountInfo account = (AccountInfo)Session["Account"];
        //    if (letramodels.ConsignmentNote.JHDUPDATE(serialNumber,1,account.Name ))
        //        Session["UpdateResult"] = "";
        //    else
        //        Session["UpdateResult"] = "serialNumber";
        //    return View();
        //}
    }
}
