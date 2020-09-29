using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using System.Web.Mvc;
using System;
using Sonluk.UI.Model.BARCODE.SY_CODINGService;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.CRM.HG_DICTService;

namespace Sonluk.PC.Areas.BARCODE.Controllers
{
    public class SYSTEMController : Controller
    {
        //
        // GET: /BARCODE/SYSTEM/
        BarCodingModels BarModels = new BarCodingModels();
        CRMModels crmModels = new CRMModels();
        MESModels mesModels = new MESModels();
        WebMSG webmsg = new WebMSG();
        string token = "";
        AppClass appClass = new AppClass();

        string RemoteAddress = System.Configuration.ConfigurationManager.AppSettings["RemoteAddress"];


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CODING()
        {
            Session["location"] = 11003;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] DATA = crmModels.HG_DICT.Read(128, 0, token);
            ViewBag.DATA = DATA;
            ViewBag.START = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            ViewBag.END = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.RemoteAddress = RemoteAddress;
            return View();
        }
        public ActionResult READ_CODING()
        {
            Session["location"] = 11004;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] DATA = crmModels.HG_DICT.Read(128, 0, token);
            ViewBag.DATA = DATA;
            ViewBag.START = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            ViewBag.END = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.RemoteAddress = RemoteAddress;
            return View();
        }
        public ActionResult MANAGE_CODING()
        {
            Session["location"] = 11005;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] DATA = crmModels.HG_DICT.Read(128, 0, token);
            ViewBag.DATA = DATA;
            ViewBag.START = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            ViewBag.END = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.RemoteAddress = RemoteAddress;
            return View();
        }
        public ActionResult CREATE_CODE()
        {
            Session["location"] = 11006;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] DATA = crmModels.HG_DICT.Read(128, 0, token);
            ViewBag.DATA = DATA;
            ViewBag.START = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            ViewBag.END = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.RemoteAddress = RemoteAddress;
            return View();
        }
    }
}
