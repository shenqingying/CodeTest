using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.HG_WJJLService;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.MSG_INVOICEService;
using Sonluk.UI.Model.CRM.MSG_NOTICETTService;
using Sonluk.WX.APPCLASS;
using Sonluk.WX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class MSGController : Controller
    {
        //
        // GET: /CRM/MSG/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Notice()
        {
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Show_Notice(int NOTICETTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICETTList TTdata = crmModels.MSG_NOTICE.ReadTTbyTTID(NOTICETTID, token);

            CRM_HG_WJJL[] FJdata = crmModels.HG_WJJL.Read(12, NOTICETTID, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < FJdata.Length; i++)
            {
                if (FJdata[i].ML != "")
                {
                    string[] p = FJdata[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    FJdata[i].ML = netpath + path;
                }
            }

            ViewBag.FJdata = FJdata;
            ViewBag.TTdata = TTdata;

            return View();
        }

        [HttpPost]
        public ActionResult InvoicePart()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFF staff = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token);
            CRM_KH_KH kehu = crmModels.KH_KH.ReadBySAPSN(staff.STAFFNO, token);
            CRM_MSG_INVOICEList[] data = crmModels.MSG_INVOICE.ReadByKHID(kehu.KHID, token);
            ViewBag.data = data;
            return View();
        }

        [HttpPost]
        public ActionResult NoticePart()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFF staff = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token);
            CRM_MSG_NOTICETTList[] data = crmModels.MSG_NOTICE.ReadBySTAFFID(appClass.CRM_GetStaffid(), staff.USERLX, token);
            ViewBag.data = data;
            return View();
        }

    }
}
