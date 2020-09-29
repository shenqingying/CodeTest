using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.WL_TTService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class WLController : Controller
    {
        //
        // GET: /CRM/WL/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Select_Wl()
        {
            Session["location"] = 508;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();
        }
        [HttpPost]
        public string GetData_Wl(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_WL_TT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_WL_TT>(cxdata);
            CRM_WL_TT[] data = crmModels.WL_TT.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


    }
}
