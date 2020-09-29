using Newtonsoft.Json;
using Sonluk.Filters;
using Sonluk.Models;
using Sonluk.UI.Model.Account.AccessService;
using Sonluk.UI.Model.MM.PurchaseOrderService;
using Sonluk.UI.Model.MM.ScheduleRequisitionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Sonluk.Areas.MM.Controllers
{
    public class ScheduleRequisitionController : Controller
    {
        MMModels models = new MMModels();

        //
        // GET: /MM/ScheduleRequisition/
        [Authorization(Message = "Index")]
        public ActionResult Index(string auth)
        {
            ViewBag.Auth = auth;
            ViewBag.SAPAuth = ((AccountInfo)Session["Account"]).SAPAuthorization;
            return View();
        }

        //
        // GET: /MM/ScheduleRequisition/_List
        public ActionResult _List(ScheReqInfo keyword, string auth)
        {
            ViewBag.Auth = auth;
            return View(models.ScheduleRequisition.Read(keyword));
        }

        //
        // GET: /MM/ScheduleRequisition/_Items
        public ActionResult _Items(ScheReqInfo keyword, string auth)
        {
            ViewBag.Auth = auth;
            return View(models.ScheduleRequisition.ItemRead(keyword));
        }

        //
        // GET: /MM/ScheduleRequisition/Edit
        [Authorization(Message = "Edit")]
        public ActionResult Edit(string auth, string sn)
        {
            ViewBag.Auth = auth;
            ViewBag.SN = sn;
            ViewBag.SAPAuth = ((AccountInfo)Session["Account"]).SAPAuthorization;
            return View();
        }

        //
        // POST: /MM/ScheduleRequisition/Schedule
        [HttpPost]
        public string Schedule(POKeywordInfo keyword)
        {
            keyword.DisplayPrintMinCost = 1;
            return JsonConvert.SerializeObject(models.PurchaseOrder.Read(keyword));
        }

        //
        // POST: /MM/ScheduleRequisition/Create
        [HttpPost]
        public string Create(ScheReqInfo scheReq)
        {
            return models.ScheduleRequisition.Create(scheReq);
        }

        //
        // GET: /MM/ScheduleRequisition/_Change
        public ActionResult _Change(string serialNumber, string auth)
        {
            ViewBag.Auth = auth;
            return View(models.ScheduleRequisition.Read(serialNumber));
        }

        //
        // POST: /MM/ScheduleRequisition/Update
        [HttpPost]
        public bool Update(ScheReqInfo scheReq)
        {
            return models.ScheduleRequisition.Update(scheReq);
        }

        //
        // POST: /MM/ScheduleRequisition/Delete
        [HttpPost]
        public bool Delete(string serialNumber)
        {
            return models.ScheduleRequisition.Delete(serialNumber);
        }

        //
        // GET: /MM/ScheduleRequisition/Check
        [Authorization(Message = "Check")]
        public ActionResult Release(string auth, string sn)
        {
            ViewBag.Auth = auth;
            ViewBag.SAPAuth = ((AccountInfo)Session["Account"]).SAPAuthorization;
            return View(models.ScheduleRequisition.Read(sn));
        }

        //
        // POST: /MM/ScheduleRequisition/Status
        [HttpPost]
        public bool Status(string serialNumber, string account, string status, string releaseCode, string comments)
        {
            return models.ScheduleRequisition.Update(serialNumber, account, status, releaseCode, comments);
        }

        //
        // GET: /MM/ScheduleRequisition/_DeliveryDestination
        public ActionResult _DeliveryDestination()
        {
            IList<ScheDelivDestInfo> nodes;
            if (Session["DeliveryDestination"] == null)
            {
                nodes = models.ScheduleRequisition.DeliveryDestination();
                Session["DeliveryDestination"] = nodes;
            }
            else
            {
                nodes = (IList<ScheDelivDestInfo>)Session["DeliveryDestination"];
            }
            return View(nodes);
        }

        //
        // POST: /MM/ScheduleRequisition/ItemRelease
        [HttpPost]
        public bool ItemStatus(IList<Sonluk.UI.Model.MM.ScheduleRequisitionService.ScheduleLineInfo> nodes, int status,string comments)
        {
            return models.ScheduleRequisition.ItemStatus(nodes, status, comments);
        }

    }
}
