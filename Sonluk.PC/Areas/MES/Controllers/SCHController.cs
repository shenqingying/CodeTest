using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sonluk.API.SDK.Http;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.MES.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.CRM_LoginService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.ZSL_PP_RFCService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class SCHController : Controller
    {
        //
        // GET: /MES/SCH/
        MESModels mesModels = new MESModels();
        CRMModels crmModels = new CRMModels();
        AccountModels AccountModel = new AccountModels();
        readonly SHttp sHttp = new SHttp();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BILL_MANAGE()
        {
            AppClass.SetSession("location", 246);           
            ViewData.Model = MvcModel();
            //sHttp.defaultTimeOut = new TimeSpan(0, 40, 0);
            //string result = sHttp.SApiPost("MES", "MES/SCH/LLNO_SYNC", "");
            //string arr = "[10307520]";
            //string result = sHttp.SApiPost("MES", "MES/SCH/ReadMaterial_Check", arr);
            //string result = sHttp.SApiPost("MES", "MES/SCH/ZPP_BZZYD_READ?IV_AUFNR=11000009", "");


            //ZPP_BZZYD_READ_RESULT rst = mesModels.ZSL_PP_RFC.ZPP_BZZYD_READ("11000009");
            
            return View();
        }
        public ActionResult BZYZDPrint(string aufnrArr)
        {
            AppClass.SetSession("location", 246);
            //string pageSize = "";
            //HttpCookie cookie = Request.Cookies.Get("IQCPMPageSize");
            //List<string> AufnrList = new List<string>
            //{
            //    "11000009"
            //    //"11000002"
            //};
            string[] arr = JsonConvert.DeserializeObject<string[]>(aufnrArr);
            ZPP_BZZYD_READ_RESULT[] rst = mesModels.ZSL_PP_RFC.ZPP_BZZYD_READ(arr);

            return View(rst); 
        }
        
        public ActionResult SCHEDULES_MANAGE()
        {
            AppClass.SetSession("location", 248);

            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult SCHEDULES_SELECT()
        {
            AppClass.SetSession("location", 251);

            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult PB_SELECT()
        {
            AppClass.SetSession("location", 253);

            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult PB_MANAGE()
        {
            AppClass.SetSession("location", 252);

            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult SCH_SHOWCHOICE()
        {
            AppClass.SetSession("location", 254);
            return View();
        }
        public ActionResult SCH_SHOWMACHINE(int ID = 0)
        {                      
            if (ID != 0)
            {
                string tokenres = sHttp.SApiPost("MES", "MES/SCH/ReadCRM_HG_STAFF?ID=" + ID,"");
                dynamic res = JsonConvert.DeserializeObject<JObject>(tokenres);
                string token = (string)res.data.access_token;
                int staffid = ID;
                Session["STAFFID"] = staffid;
                Session["token"] = token;
                //crmModels.HG_STAFF.ReadBySTAFFID(ID)
            }
            else
            {
                AppClass.SetSession("location", 255);
                //ID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            }
            ViewBag.ID = ID;
            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult SCH_SHOWWORKCENTER(int ID = 0)
        {
            if (ID != 0)
            {
                string tokenres = sHttp.SApiPost("MES", "MES/SCH/ReadCRM_HG_STAFF?ID=" + ID, "");
                dynamic res = JsonConvert.DeserializeObject<JObject>(tokenres);
                string token = (string)res.data.access_token;
                int staffid = ID;
                Session["STAFFID"] = staffid;
                Session["token"] = token;
                //crmModels.HG_STAFF.ReadBySTAFFID(ID)
            }
            else
            {
                AppClass.SetSession("location", 256);
                //ID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            }
            ViewBag.ID = ID;
            ViewData.Model = MvcModel();
            return View();
        }

        public ActionResult BILL_SELECT()
        {
            AppClass.SetSession("location", 247);
            ViewData.Model = MvcModel();
            return View();
        }
        public MODEL_Assign_WorkOrder MvcModel()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            return model;
        }
        public string GetGCbyStaffid(int STAFFID)
        {
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            //TokenInfo tokeninfo = AccountModel.UserToken.Token("api", "sonluk2018");
            //AccountModel.UserToken()
            model_MES_SY_GC.STAFFID = STAFFID;
            string token = AppClass.GetSession("token").ToString();
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            return JsonConvert.SerializeObject(MES_SY_GC_list);
        }
        
        [HttpPost]
        public string ReadSY_GZZX_SBBH(string data)
        {
            //MES_SY_GZZX_SBH node = new MES_SY_GZZX_SBH
            //{
            //    SBBH = tm
            //};

            return sHttp.SApiPost("MES", "MES/SY/ReadSY_GZZX_SBBH", data);
        }
        [HttpPost]
        public string GetRWDHINFOByGD_SBBH(string gd,string sbbh,string zprq)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "gd", gd },
                { "sbbh", sbbh },
                { "zprq", zprq }
            };
            return sHttp.SApiPost("MES", "MES/SCH/ReadRWDHINFOBYGD_SBBH","", dict);
        }
        [HttpPost]
        public string GetRWDHINFOByRWBH(string data)
        {
            //var RST = sHttp.SApiPost("MES", "MES/SCH/ReadRWBH", data); {"SBBH":"0000000218","ERPN":"10606219"}
            return sHttp.SApiPost("MES", "MES/SCH/ReadRWBH", data);
        }

        [HttpPost]
        public string ReadMaterialUnitConversion(string wlh,string unit)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "wlh", wlh },
                { "unit", unit }
            };
            return sHttp.SApiPost("MES", "MES/SCH/ReadMaterialUnitConversion", "", dict);
        }
        [HttpPost]
        public string CreateSCH_BILL(string data)
        {

            return sHttp.SApiPost("MES", "MES/SCH/CreateSCH_BILL", data);
        }
        [HttpPost]
        public string ReadSCH_BILL_Plus(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/ReadSCH_BILL_PLUS", data);
        }
        [HttpPost]
        public string ReadSCH_BILL(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/ReadSCH_BILL", data);
        }
        [HttpPost]
        public string UpdateSCH_BILL(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/UpdateSCH_BILL", data);
        }
        [HttpPost]
        public string DeleteSCH_BILL(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/DeleteSCH_BILL", data);
        }
        [HttpGet]
        public FileResult ExportSCH_BILL(string data)
        {
           
            return File(sHttp.SApiDownload("MES", "MES/SCH/ExportSCH_BILL", data), "application/octet-stream", "结账单导出.xlsx");
        }
        [HttpGet]
        public FileResult ExportSCH_MATERIALCHECK(string data)
        {

            return File(sHttp.SApiDownload("MES", "MES/SCH/ExportSCH_MATERIALCHECK", data), "application/octet-stream", "物料信息检查.xlsx");
        }
        [HttpGet]
        public FileResult ExportZPP_BZZYD_READ(string data)
        {
            string[] arr = JsonConvert.DeserializeObject<string[]>(data);
            return File(sHttp.SApiDownload("MES", "MES/SCH/ExportZPP_BZZYD_READ", data), "application/octet-stream", arr[0]+".xlsx");
        }
        [HttpPost]
        public string ReadMaterial_Check(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/ReadMaterial_Check", data); 
        }
        [HttpPost]
        public string SELECT_GD_SCHEDULES(string data)
        {
            return sHttp.SApiPost("MES", "MES/PD/SELECT_GD_SCHEDULES", data); 
        }
        [HttpPost]
        public string UpdateSCH_STATUS(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/UpdateSCH_STATUS", data);
        }
        
        [HttpPost]
        public string CreateSCHEDULES_STATUS(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/CreateSCHEDULES_STATUS", data);
        }
        [HttpPost]
        public string DeleteSCHEDULES_STATUS(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/DeleteSCHEDULES_STATUS", data);
        }
        [HttpPost]
        public string ReadSCHEDULES_STATUS(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/ReadSCHEDULES_STATUS", data);
        }
        [HttpPost]
        public string ModifyGD_SCH_STATUS(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/ModifyGD_SCH_STATUS", data);
        }
        [HttpPost]
        public string BatchModifyGD_SCH_STATUS(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/BatchModifyGD_SCH_STATUS", data);
        }
        
        [HttpPost]
        public string LLNO_SYNC()
        {
            return sHttp.SApiPost("MES", "MES/SCH/LLNO_SYNC","");
        }
        [HttpPost]
        public string FinishSCHEDULES_STATUS(string data)
        {            
            return sHttp.SApiPost("MES", "MES/SCH/FinishSCHEDULES_STATUS" + "?tm=" + data,"");
        }
        [HttpPost]
        public string ReadSCH_STATUS(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/ReadSCH_STATUS", data);
        }
        [HttpPost]
        public string ReadGDJGXX_BYERPNO(string data)
        {
            return sHttp.SApiPost("MES", "MES/PD/ReadGDJGXX_BYERPNO" + "?IV_AUFNR=" + data, "");
        }
        [HttpPost]
        public string ReadRWBH_BY_ERPNO(string data)
        {
            return sHttp.SApiPost("MES", "MES/PD/ReadRWBH_BY_ERPNO" + "?IV_AUFNR=" + data, "");
        }
        [HttpPost]
        public string ReadBillSCRWTIME(string data)
        {
            return sHttp.SApiPost("MES", "MES/PD/ReadBillSCRWTIME",data);
        }
        [HttpPost]
        public string ReadDW_MES_SBBH_OUTPUT_DAY(string data)
        {
            return sHttp.SApiPost("MES", "DW/MES/ReadDW_MES_SBBH_OUTPUT_DAY", data);
        }
        [HttpPost]
        public string ReadPD_SCRW_SJJL(string data)
        {
            return sHttp.SApiPost("MES", "MES/PD/ReadPD_SCRW_SJJL", data);
        }
        [HttpPost]
        public string ReadMES_ERPNO_SUMMARY(string data)
        {
            return sHttp.SApiPost("MES", "DW/MES/ReadMES_ERPNO_SUMMARY", data);
        }


    }
    
}
