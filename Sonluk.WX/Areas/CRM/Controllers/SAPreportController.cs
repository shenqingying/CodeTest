using Sonluk.UI.Model.CRM.SAP_ReportService;
using Sonluk.WX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class SAPreportController : Controller
    {
        //
        // GET: /CRM/SAPreport/
        CRMModels crmModels = new CRMModels();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order()        //销售订单
        {
            return View();
        }

        public ActionResult Shipment()     //销售发货
        {
            return View();
        }

        public ActionResult Invoice()      //销售开票
        {
            return View();
        }

        [HttpPost]
        public string Data_SAP_Invoice(string cxdata)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            SAP_Invoice_Param model = Newtonsoft.Json.JsonConvert.DeserializeObject<SAP_Invoice_Param>(cxdata);
            SAP_Invoice[] data = crmModels.SAP_Report.Invoice(Convert.ToInt32(Session["STAFFID"]), model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SAP_Shipment(string cxdata)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }

            return "";
        }

        [HttpPost]
        public string Data_SAP_Order(string cxdata)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }

            return "";
        }



    }
}
