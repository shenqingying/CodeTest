using Sonluk.Models;
using Sonluk.UI.Model.LE.TRA.FeedbackService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class FeedbackController : Controller
    {
        LETRAModels models = new LETRAModels();
        //
        // GET: /LE/Feedback/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Feedback/_List
        [HttpPost]
        public ActionResult _List(FeedbackInfo keywords)
        {
            return PartialView(models.Feedback.Read(keywords));
        }

        //
        // GET: /LE/Feedback/_Items
        [HttpPost]
        public ActionResult _Items(FeedbackInfo keywords)
        {
            return PartialView(models.Feedback.Report(keywords));
        }

        //
        // GET: /LE/Feedback/Edit
        public ActionResult Edit(int ID)
        {
            return View(models.Feedback.Read(ID));
        }

        //
        // POST: /LE/Feedback/_Import
        [HttpPost]
        public void _Import(HttpPostedFileBase file)
        {
            try
            {
                Session["ImportResult"] = models.Feedback.Import(file.InputStream);
                Response.Write("<script>window.parent.showImportFile();</script>");
            }
            catch (Exception e)
            {
                Logger.Write("LE.FeedbackController", e.Message);
                Response.Write("<script>window.parent.importError();</script>");
            }
        }

        //
        // GET: /LE/Feedback/_ImportList
        public ActionResult _ImportList()
        {
            IList<FeedbackItemInfo> nodes;
            if (Session["ImportResult"] != null)
            {
                nodes = (IList<FeedbackItemInfo>)Session["ImportResult"];
                Session["ImportResult"] = null;
            }
            else
            {
                nodes = new List<FeedbackItemInfo>();
            }
            return PartialView(nodes);
        }

        //
        // POST: /LE/Feedback/_Modify
        [HttpPost]
        public string _Verify(FeedbackInfo node)
        {
            return models.Feedback.Verify(node);
        }


        //
        // POST: /LE/Feedback/_Modify
        [HttpPost]
        public int _Modify(FeedbackInfo node)
        {
            return models.Feedback.Modify(node);
        }


        //
        // GET: /LE/Feedback/Details
        public ActionResult Details()
        {
            return View();
        }

        //
        // POST: /LE/Feedback/_PrepareExport
        [HttpPost]
        public int _PrepareExport(IList<FeedbackInfo> nodes)
        {
            Session["FeedbackExportData"] = nodes;
            return 1;
        }

        //
        // GET: /LE/Feedback/_Export
        public ActionResult _Export(string type)
        {
            IList<FeedbackInfo> nodes = (IList<FeedbackInfo>)Session["FeedbackExportData"];
            Session["FeedbackExportData"] = null;
            MemoryStream memoryStream = models.Feedback.Export(type, nodes);
            string fileName = "托运单反馈[" + DateTime.Now.ToString("yyMMdd") + "].xls";
            return File(memoryStream.ToArray(), "application/vnd.ms-excel", HttpContext.Request.Browser.Browser == "IE" ? Url.Encode(fileName) : fileName);
        }


    }
}
