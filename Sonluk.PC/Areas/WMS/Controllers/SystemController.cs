using Sonluk.API.SDK.Http;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.WMS.Controllers
{
    public class SystemController : Controller
    {
        //
        // GET: /WMS/System/
        CRMModels crmModels = new CRMModels();
        MESModels mesModels = new MESModels();
        AppClass appClass = new AppClass();
        SHttp sHttp = new SHttp();
        string token = "";
        string RemoteAddress = System.Configuration.ConfigurationManager.AppSettings["RemoteAddress"];

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CK_Setting()
        {
            Session["location"] = 20000;
            token = appClass.CRM_Gettoken();
            MES_SY_TYPEMX cx_ljxt = new MES_SY_TYPEMX();
            cx_ljxt.TYPEID = 39;
            MES_SY_TYPEMXLIST[] LJXT = mesModels.SY_TYPEMX.SELECT(cx_ljxt, token);
            ViewBag.LJXT = LJXT;

            MES_SY_GC cx_gc = new MES_SY_GC();
            cx_gc.STAFFID = appClass.CRM_GetStaffid();
            MES_SY_GC[] GC = mesModels.SY_GC.SELECT_BY_ROLE(cx_gc, token);
            ViewBag.GC = GC;

            return View();
        }

        [HttpPost]
        public string Read_KCDD_ByGC(string GC)
        {
            token = appClass.CRM_Gettoken();
            MES_MM_CK cx_kcdd = new MES_MM_CK();
            cx_kcdd.STAFFID = appClass.CRM_GetStaffid();
            cx_kcdd.GC = GC;
            MES_MM_CK_SELECT KCDD = mesModels.MM_CK.SELECT_USER(cx_kcdd, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(KCDD);
        }

        [HttpPost]
        public string CREATE_CK(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/CREATE", data);
            return model;
        }
        [HttpPost]
        public string CREATE_ALL_CK(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/CREATE_ALL", data);
            return model;
        }
        [HttpPost]
        public string UPDATE_CK(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/UPDATE", data);
            return model;
        }
        [HttpPost]
        public string UPDATE_ALL_CK(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/UPDATE_ALL", data);
            return model;
        }
        [HttpPost]
        public string Read_CK(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/READ", data);
            return model;
        }
        [HttpPost]
        public string Delete_CK(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/Delete", data);
            return model;
        }


        [HttpPost]
        public string CREATE_CK_KCDD(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/CREATE_KCDD", data);
            return model;
        }
        [HttpPost]
        public string UPDATE_CK_KCDD(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/UPDATE_KCDD", data);
            return model;
        }
        [HttpPost]
        public string Read_CK_KCDD(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/READ_KCDD", data);
            return model;
        }



        [HttpPost]
        public string CREATE_CK_AREA(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/CREATE_AREA", data);
            return model;
        }
        [HttpPost]
        public string UPDATE_CK_AREA(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/UPDATE_AREA", data);
            return model;
        }
        [HttpPost]
        public string READ_CK_AREA(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/SY_WAREHOUSE/READ_AREA", data);
            return model;
        }

        //通用请求（需要Session）
        [HttpPost]
        public string SApiPost(string url, string data, string query = null)
        {
            Dictionary<string, string> queryParams = null;
            if (query != null) queryParams = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(query);
            return new SHttp().SApiPost("WMS", url, data);
        }
        [HttpPost]
        public string SApiGet(string url, string query = null)
        {
            Dictionary<string, string> queryParams = null;
            if (query != null) queryParams = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(query);
            return new SHttp().SApiGet("WMS", url, queryParams);
        }
    }
}
