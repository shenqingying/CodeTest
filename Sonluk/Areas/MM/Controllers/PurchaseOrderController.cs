using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sonluk.Models;
using Sonluk.UI.Model.Account.AccessService;
using Sonluk.UI.Model.MM.PurchaseOrderService;
using Sonluk.Filters;
using Sonluk.Utility;

namespace Sonluk.Areas.MM.Controllers
{
    public class PurchaseOrderController : Controller
    {
        MMModels models = new MMModels();

        //
        // GET: /MM/PurchaseOrder/
        [Authorization(Message = "Index")]
        public ActionResult Index(string auth)
        {
            ViewBag.Auth = auth;
            ViewBag.SAPAuth = ((AccountInfo)Session["Account"]).SAPAuthorization;
            return View();
        }

        //
        // POST: /MM/PurchaseOrder/_List
        [HttpPost]
        public ActionResult _List(POKeywordInfo keyword)
        {
            
            return PartialView(models.PurchaseOrder.Read(keyword));
        }

        //
        // POST: /MM/PurchaseOrder/_History
        [HttpPost]
        public ActionResult _History(string number, int itemNumber)
        {
            ViewBag.Title = "采购订单" + number + "/" + itemNumber + "历史记录";
            return PartialView(models.PurchaseOrder.History(number, itemNumber));
        }

        //
        // POST: /MM/PurchaseOrder/PrepareExportSetData
        [HttpPost]
        public string PrepareExportSetData(IList<POItemInfo> itemNodes)
        {
            string message = "";
            Session["ExportData"] = itemNodes;

            return message;
        }

        //
        // GET: /MM/PurchaseOrder/ExportSet
        public ActionResult ExportSet(string type)
        {
            IList<POItemInfo> itemNodes = (IList<POItemInfo>)Session["ExportData"];
            Session["ExportData"] = null;
            MemoryStream memoryStream = models.PurchaseOrder.Export(type, itemNodes);
            string fileName = "采购订单清单[" + DateTime.Now.ToString("yyMMdd") + "].xls";
            return File(memoryStream.ToArray(), "application/vnd.ms-excel", HttpContext.Request.Browser.Browser == "IE" ? Url.Encode(fileName) : fileName);
        }

        //
        // POST: /MM/PurchaseOrder/PrepareExportData
        [HttpPost]
        public string PrepareExportData(IList<POItemInfo> itemNodes, int type)
        {
            string message = "";
            Session["ExportPO"] = itemNodes;
            Session["ExportPOType"] = type;
            return message;
        }

        //
        // GET: /MM/PurchaseOrder/Export
        public ActionResult Export()
        {
            IList<FileStreamInfo> files = new List<FileStreamInfo>();
            if (Session["ExportPO"] != null)
            {
                IList<POItemInfo> itemNodes = (IList<POItemInfo>)Session["ExportPO"];
                int type = (int)Session["ExportPOType"];
                Session["ExportPO"] = null;
                Session["ExportPOType"] = null;
                files = models.PurchaseOrder.Export(itemNodes, type);

            }
            return View(files);
        }

        //public ActionResult RKBSPrint()
        //{
        //    IList<FileStreamInfo> files = (IList<FileStreamInfo>)Session["RKBS_files"];
           
        //    return View(files);
        //}

        // public ActionResult RKBS()
        //{
        //    ViewBag.RKBS_PONumber = Session["RKBS_PONumber"].ToString();
        //    ViewBag.RKBS_Number = Session["RKBS_Number"].ToString();
        //    ViewBag.RKBS_Vendor = Session["RKBS_Vendor"].ToString();
        //    ViewBag.RKBS_DelivQty = Session["RKBS_DelivQty"].ToString();

        //    return View();
        //}

        // [HttpPost]
        // public string PrepareRKBSData(string CG,string XM, string TPM, string GYS, int TS, int XS, int SL)
        // {
        //     string message = "";
        //     string CGXM = "";
        //     CGXM = CG + XM.PadLeft(5, '0');

        //     IList<FileStreamInfo> files = new List<FileStreamInfo>();
             
        //     files = models.PurchaseOrder.GetRKBSPrint(CGXM, TPM, GYS, TS, XS, SL);
        //     Session["RKBS_files"] = files;
        //     return message;
        // }

        //
        // GET: /MM/PurchaseOrder/Temp
        [Authorization(Message = "Temp")]
        public ActionResult Temp()
        {
            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Temp/PO");
            FileInfo[] files = di.GetFiles();

            double len = 0;
            DateTime lastWriteTime = new DateTime(2015, 9, 1);
            foreach (FileInfo file in files)
            {
                len += file.Length;
                if (lastWriteTime < file.LastWriteTime)
                    lastWriteTime = file.LastWriteTime;
            }
            ViewBag.Length = (len / 1024 / 1024).ToString("###############0.###") + "MB";
            ViewBag.Count = files.Count();
            ViewBag.LastWriteTime = lastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            return View();
        }


        //
        // GET: /MM/PurchaseOrder/RemoveTemp
        [Authorization(Message = "RemoveTemp")]
        public ActionResult RemoveTemp()
        {
            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Temp/PO");
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime < DateTime.Now.AddHours(-1))
                {
                    file.Delete();
                }
            }
            return RedirectToAction("Temp");
        }

        //
        // GET: /MM/PurchaseOrder/UpdateDeliveryDate
        public ActionResult UpdateDeliveryDate()
        {
            ViewBag.SAPAuth = ((AccountInfo)Session["Account"]).SAPAuthorization;
            return View();
        }

        //
        // GET: /MM/PurchaseOrder/UpdateDeliveryDate
        [HttpPost]
        public string UpdateDeliveryDate(IList<POItemInfo> nodes)
        {
            //return (nodes[0].PONumber + nodes[0].Number + nodes[0].DelivDate);
            IList<MessageInfo> node = models.PurchaseOrder.UpdateDeliveryDate(nodes);
            return JsonConvert.SerializeObject(node);

        }

        //
        // POST: /MM/PurchaseOrder/_UpdateList
        [HttpPost]
        public ActionResult _UpdateList(POKeywordInfo keyword)
        {
            return PartialView(models.PurchaseOrder.Read(keyword));
        }

        //
        // GET: /MM/PurchaseOrder/_UpdateList
        public ActionResult _UpdateList()
        {
            IList<POItemInfo> nodes = null;
            if (Session["ImportUpdateResult"] != null)
            {
                nodes = (IList<POItemInfo>)Session["ImportUpdateResult"];
                Session["ImportUpdateResult"] = null;
            }
            return PartialView(nodes);
        }

        //
        // POST: /MM/PurchaseOrder/_ImportSalesOrders
        [HttpPost]
        public void _ImportSalesOrders(HttpPostedFileBase file)
        {
            try
            {
                Session["ImportUpdateResult"] = models.PurchaseOrder.Read(file.InputStream);
                Response.Write("<script>window.parent.readBySO();</script>");
            }
            catch (Exception e)
            {
                Logger.Write("MM.PurchaseOrderController", e.Message.ToString());
                Response.Write("<script>window.parent.importError();</script>");
            }
        }

        //
        // GET: /MM/PurchaseOrder/PrintTest
        public ActionResult PrintTest()
        {
            return View();
        }
    }
}
