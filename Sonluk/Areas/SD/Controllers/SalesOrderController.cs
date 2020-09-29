using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.Models;
using Sonluk.UI.Model.SD.SalesOrderService;
using Sonluk.Filters;

namespace Sonluk.Areas.SD.Controllers
{
    public class SalesOrderController : Controller
    {
        SDModels models = new SDModels();
        //
        // GET: /SD/SalesOrder/
        [Authorization(Message = "Index")]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /SD/SalesOrder/_List
        public ActionResult _List(SOKeywordInfo node)
        {
            return PartialView(models.SalesOrder.Read(node));
        }

        //
        // POST: /SD/SalesOrder/ProcessingRecords
        [HttpPost]
        public string ProcessingRecords(IList<SOItemInfo> nodes)
        {
            return models.SalesOrder.ProcessingRecords(nodes.ToArray());
        }

    }
}
