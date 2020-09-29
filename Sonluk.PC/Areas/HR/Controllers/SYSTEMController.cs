using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.HR.GS_LYService;
using Sonluk.UI.Model.HR.SY_GSService;
using Sonluk.UI.Model.HR.SY_MYINFOService;
using Sonluk.UI.Model.HR.SY_TYPEMXService;
using Sonluk.UI.Model.HR.SY_TYPEService;
using Sonluk.UI.Model.HR.SY_ZJHService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.HR.Controllers
{
    public class SYSTEMController : Controller
    {
        //
        // GET: /HR/SYSTEM/
        HRModels hrmodels = new HRModels();
        public ActionResult SY_TYPEMX()
        {
            AppClass.SetSession("location", 128);
            return View();
        }
        public ActionResult SY_GSLY()
        {
            AppClass.SetSession("location", 182);
            return View();
        }
        public ActionResult SY_ZJH()
        {
            AppClass.SetSession("location", 183);
            return View();
        }
        public ActionResult MYMANAGE()
        {
            AppClass.SetSession("location", 140);
            return View();
        }
        public ActionResult MYMANAGE_STAFFID()
        {
            AppClass.SetSession("location", 141);
            return View();
        }
        public ActionResult MYMANAGE_ADMIN()
        {
            AppClass.SetSession("location", 142);
            return View();
        }
        [HttpPost]
        public string GET_TYPE()
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_TYPE_SELECT rst = hrmodels.SY_TYPE.SELECT(token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_GS(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_GS model_HR_SY_GS = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_GS>(datastring);
            HR_SY_GS_SELECT rst = hrmodels.SY_GS.SELECT(model_HR_SY_GS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_TYPEMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_TYPEMX model_HR_SY_TYPEMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_TYPEMX>(datastring);
            HR_SY_TYPEMX_SELECT rst = hrmodels.SY_TYPEMX.SELECT(model_HR_SY_TYPEMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string TYPEMX_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_TYPEMX model_HR_SY_TYPEMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_TYPEMX>(datastring);
            MES_RETURN_UI rst = hrmodels.SY_TYPEMX.INSERT(model_HR_SY_TYPEMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string TYPEMX_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_TYPEMX model_HR_SY_TYPEMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_TYPEMX>(datastring);
            MES_RETURN_UI rst = hrmodels.SY_TYPEMX.UPDATE(model_HR_SY_TYPEMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string TYPEMX_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_TYPEMX model_HR_SY_TYPEMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_TYPEMX>(datastring);
            MES_RETURN_UI rst = hrmodels.SY_TYPEMX.DELETE(model_HR_SY_TYPEMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_GSLY_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_GS_LY model_HR_SY_GS_SELECT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_GS_LY>(datastring);
            HR_GS_LY_SELECT rst = hrmodels.GS_LY.SELECT(model_HR_SY_GS_SELECT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_GSLY_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_GS_LY model_HR_SY_GS = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_GS_LY>(datastring);
            MES_RETURN_UI rst = hrmodels.GS_LY.INSERT(model_HR_SY_GS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_GSLY_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_GS_LY model_HR_SY_GS = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_GS_LY>(datastring);
            MES_RETURN_UI rst = hrmodels.GS_LY.UPDATE(model_HR_SY_GS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_GSLY_DELETE(int LYID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.GS_LY.DELETE(LYID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_ZJH_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_ZJH model_HR_SY_ZJH = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_ZJH>(datastring);
            MES_RETURN_UI rst = hrmodels.SY_ZJH.INSERT(model_HR_SY_ZJH, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_ZJH_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_ZJH model_HR_SY_ZJH = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_ZJH>(datastring);
            HR_SY_ZJH_SELECT rst = hrmodels.SY_ZJH.SELECT(model_HR_SY_ZJH, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_ZJH_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_ZJH model_HR_SY_ZJH = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_ZJH>(datastring);
            MES_RETURN_UI rst = hrmodels.SY_ZJH.UPDATE(model_HR_SY_ZJH, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_ZJH_DELETE(int ZJHID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.SY_ZJH.DELETE(ZJHID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_ZJH_SELECT_LAY(int ZJHID, string GS)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_ZJH_LAY_SELECT rst = hrmodels.SY_ZJH.SELECT_ZJH_LAY(ZJHID, GS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_ZJH_INSERT_LAY(string datastring, int ZJHID)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            HR_SY_ZJH_LAY[] model_HR_SY_ZJH_LAY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_ZJH_LAY[]>(datastring);
            hrmodels.SY_ZJH.DELETE_ZJH_LAY(ZJHID, token);
            for (int i = 0; i < model_HR_SY_ZJH_LAY.Length; i++)
            {
                model_HR_SY_ZJH_LAY[i].ZJHID = ZJHID;
                rst = hrmodels.SY_ZJH.INSERT_ZJH_LAY(model_HR_SY_ZJH_LAY[i], token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_ZJH_ROLE_INSERT_LAY(string datastring, int STAFFID)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            HR_SY_ZJH_LAY[] model_HR_SY_ZJH_LAY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_ZJH_LAY[]>(datastring);
            hrmodels.SY_ZJH.DELETE_ZJH_ROLE_LAY(STAFFID, token);
            for (int i = 0; i < model_HR_SY_ZJH_LAY.Length; i++)
            {
                model_HR_SY_ZJH_LAY[i].STAFFID = STAFFID;
                rst = hrmodels.SY_ZJH.INSERT_ZJH_ROLE_LAY(model_HR_SY_ZJH_LAY[i], token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_ZJH_ROLE_SELECT_LAY(int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_ZJH_LAY_SELECT rst = hrmodels.SY_ZJH.SELECT_ZJH_ROLE_LAY(STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_MYINFO_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_MYINFO model_HR_SY_MYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_MYINFO>(datastring);
            if (model_HR_SY_MYINFO.STAFFID == 0)
            {
                model_HR_SY_MYINFO.STAFFID = STAFFID;
            }
            MES_RETURN_UI rst = hrmodels.SY_MYINFO.INSERT(model_HR_SY_MYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_MYINFO_SELECT_REPORT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_MYINFO model_HR_SY_MYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_MYINFO>(datastring);
            HR_SY_MYINFO_SELECT rst = hrmodels.SY_MYINFO.SELECT_REPORT(model_HR_SY_MYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_MYINFO_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_MYINFO model_HR_SY_MYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_MYINFO>(datastring);
            MES_RETURN_UI rst = hrmodels.SY_MYINFO.UPDATE(model_HR_SY_MYINFO, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_MYINFO_SELECT_REPORT_BY_STAFFID(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_MYINFO model_HR_SY_MYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_MYINFO>(datastring);
            model_HR_SY_MYINFO.STAFFID = STAFFID;
            HR_SY_MYINFO_SELECT rst = hrmodels.SY_MYINFO.SELECT_REPORT(model_HR_SY_MYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_MYINFO_SELECT(string datastring, int LB, int CXLB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_MYINFO model_HR_SY_MYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_MYINFO>(datastring);
            if (LB == 1)
            {
                model_HR_SY_MYINFO.STAFFID = STAFFID;
            }
            HR_SY_MYINFO_SELECT rst = hrmodels.SY_MYINFO.SELECT(model_HR_SY_MYINFO, CXLB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
    }
}
