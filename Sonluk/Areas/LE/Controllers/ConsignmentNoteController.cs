using Newtonsoft.Json;
using Sonluk.Filters;
using Sonluk.Models;
using Sonluk.UI.Model.Account.AccessService;
using Sonluk.UI.Model.LE.TRA.ConsignmentNoteService;
using Sonluk.UI.Model.Print.LayoutService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class ConsignmentNoteController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/ConsignmentNote/_Exists
        public int _Exists(string serialNumber)
        {
            return models.ConsignmentNote.Exists(serialNumber);
        }

        //
        // GET: /LE/ConsignmentNote/
        [Authorization]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/ConsignmentNote/_List
        [HttpPost]
        public ActionResult _List(CNInfo keywords)
        {
         
          
            return PartialView(models.ConsignmentNote.Read(keywords));
        }

        //
        // GET: /LE/ConsignmentNote/_Generate
        public int _Generate(List<string> deliverySet, int carrier, bool replace)
        {
            CNInfo node = models.ConsignmentNote.Generate(deliverySet, carrier, replace);
            Session["ConsignmentNote"] = node;
            return node.ID;
        }

        //
        // GET: /LE/ConsignmentNote/Edit
        public ActionResult Edit(int ID, string quickPrint)
        {
            CNInfo node;
            if (ID == -1 && Session["ConsignmentNote"] != null)
            {
                node = (CNInfo)Session["ConsignmentNote"];
                Session["ConsignmentNote"] = null;
            }
            else
            {
                node = models.ConsignmentNote.Read(ID);
            }
            ViewBag.QuickPrint = quickPrint;
            return View(node);
        }

        //
        // GET: /LE/ConsignmentNote/Edit
        [HttpPost]
        public string _CurrentNumber(int carrierID)
        {
            return models.ConsignmentNote.CurrentNumber(carrierID);
        }

        //
        // POST: /LE/ConsignmentNote/_Create
        [HttpPost]
        public ActionResult _Create(CNInfo node)
        {
            return RedirectToAction("Edit", new { ID = models.ConsignmentNote.Create(node) });
        }

        //
        // POST: /LE/ConsignmentNote/_Modify
        [HttpPost]
        public ActionResult _Modify(CNInfo node, string quickPrint)
        {
            int ID = 0;
            if (node.ID > 0)
            {
                node.Creator = ((AccountInfo)Session["Account"]).Name;
                models.ConsignmentNote.Update(node);
                ID = node.ID;
            }
            else
            {
                node.Creator = ((AccountInfo)Session["Account"]).Name;
                ID = models.ConsignmentNote.Create(node);
            }
            return RedirectToAction("Edit", new { ID = ID, quickPrint = quickPrint });
        }

        //
        // POST: /LE/ConsignmentNote/_Delete
        [HttpPost]
        public int _Delete(int ID)
        {
            return models.ConsignmentNote.Delete(ID);
        }

        [HttpPost]
        public string _SelectDJ(int source, int destination, decimal weight)
        {
            string rst = (Convert.ToDouble(models.Route.ReadDJ(source, destination, weight))).ToString();

            return rst;
        }

        [HttpPost]
        public string _ReadZSF(int BZDID, int EZDID)
        {
            return models.Route.ReadZSF(BZDID, EZDID);
        }
        //
        // GET: /LE/ConsignmentNote/_Report
        public ActionResult _Report(CNInfo keywords)
        {
            return PartialView(models.ConsignmentNote.Report(keywords));
        }

        //
        // GET: /LE/ConsignmentNote/Print
        public ActionResult Print(int ID, int carrierID, string quickPrint)
        {
            CNInfo consignmentnote = models.ConsignmentNote.Read(ID);

            //检查是否已经存在托运单
            CNInfo keywords = new CNInfo();
            keywords.Carrier = consignmentnote.Carrier;
            keywords.Destination = consignmentnote.Destination;
            keywords.Date = consignmentnote.Date;
            keywords.DateEnd = consignmentnote.Date;
            keywords.Receiver = consignmentnote.Receiver;
            keywords.Status = 0;

            IList<CNInfo> nodes = models.ConsignmentNote.Read(keywords);
            string chk = "";
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].ID != ID)
                {
                    if (chk != "") chk = chk + "、";
                    chk = chk + nodes[i].SerialNumber;
                }
            }
            if (chk != "") chk = "存在物流公司、收货地址、日期相同的托运单（SN：" + chk + ")！";
            Session["ConsignmentNote_CHK"] = chk;

            Session["Print.ConsignmentNote.JSON"] = JsonConvert.SerializeObject(consignmentnote);
            return RedirectToAction("Print", "Layout", new { area = "Print", doc = "ConsignmentNote-" + carrierID, mac = "ee:ee:ee:ee:ee:ee", quickPrint = quickPrint });
        }

        //
        // POST: /LE/ConsignmentNote/_PrepareExport
        [HttpPost]
        public int _PrepareExport(IList<CNInfo> nodes)
        {
            Session["ConsignmentNoteExportData"] = nodes;
            return 1;
        }

        //
        // GET: /LE/ConsignmentNote/_Export
        public ActionResult _Export(string type)
        {
            IList<CNInfo> nodes = (IList<CNInfo>)Session["ConsignmentNoteExportData"];
            //for (int i = 0; i < nodes.Count; i++)
            //{
            //    if (nodes[i].Receiver.Name.Equals("国柜物流"))
            //    {
            //        nodes[i].TYLB = 3;
            //    }
                
            //}
   
            Session["ConsignmentNoteExportData"] = null;
            MemoryStream memoryStream = models.ConsignmentNote.Export(type, nodes);
            string fileName = "托运单[" + DateTime.Now.ToString("yyMMdd") + "].xls";
            return File(memoryStream.ToArray(), "application/vnd.ms-excel", HttpContext.Request.Browser.Browser == "IE" ? Url.Encode(fileName) : fileName);
        }



    }
}
