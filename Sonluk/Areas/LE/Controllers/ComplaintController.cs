using Sonluk.Filters;
using Sonluk.Models;
using Sonluk.UI.Model.LE.TRA.ComplaintService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class ComplaintController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/Complaint/
        [Authorization]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Complaint/_List
        [HttpPost]
        public ActionResult _List(ComplaintInfo keywords)
        {
            return PartialView(models.Complaint.Read(keywords));
        }

        //
        // GET: /LE/Complaint/_Items
        [HttpPost]
        public ActionResult _Items(ComplaintInfo keywords)
        {
            return PartialView(models.Complaint.Report(keywords));
        }

        //
        // GET: /LE/Complaint/_Generate
        public bool _Generate(int consignmentNote)
        {
            Session["Complaint"] = models.Complaint.Generate(consignmentNote);
            return true;
        }

        //
        // GET: /LE/Complaint/Edit
        public ActionResult Edit(int ID)
        {
            ComplaintInfo node;
            if (ID == -1 && Session["Complaint"] != null)
            {
                node = (ComplaintInfo)Session["Complaint"];
                Session["Complaint"] = null;
            }
            else
            {
                node = models.Complaint.Read(ID);
            }
            return View(node);
        }

        //
        // POST: /LE/Complaint/_Modify
        [HttpPost]
        public int _Modify(ComplaintInfo node)
        {
            return models.Complaint.Modify(node);
        }

        //
        // GET: /LE/Complaint/Details
        public ActionResult Details()
        {
            return View();
        }

        //
        // POST: /LE/Complaint/_PrepareExport
        [HttpPost]
        public int _PrepareExport(IList<ComplaintInfo> nodes)
        {
            Session["ComplaintExportData"] = nodes;
            return 1;
        }

        //
        // GET: /LE/Complaint/_Export
        public ActionResult _Export(string type)
        {
            IList<ComplaintInfo> nodes = (IList<ComplaintInfo>)Session["ComplaintExportData"];
            Session["ComplaintExportData"] = null;
            MemoryStream memoryStream = models.Complaint.Export(type, nodes);
            string fileName = "托运单投诉[" + DateTime.Now.ToString("yyMMdd") + "].xls";
            return File(memoryStream.ToArray(), "application/vnd.ms-excel", HttpContext.Request.Browser.Browser == "IE" ? Url.Encode(fileName) : fileName);
        }

        //
        // GET: /LE/Complaint/_Type
        public ActionResult _Type()
        {
            return PartialView();
        }

        //
        // GET: /LE/Complaint/_Reason
        public ActionResult _Reason()
        {
            return PartialView();
        }

    }
}
