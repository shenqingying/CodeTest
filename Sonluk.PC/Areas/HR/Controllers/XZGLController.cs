using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.HR.RY_RYINFOService;
using Sonluk.UI.Model.HR.SY_DEPTService;
using Sonluk.UI.Model.HR.SY_TYPEMXService;
using Sonluk.UI.Model.HR.XZGL_FFJLZDService;
using Sonluk.UI.Model.HR.XZGL_FLFAMXService;
using Sonluk.UI.Model.HR.XZGL_FLFAService;
using Sonluk.UI.Model.HR.XZGL_XZDA_GZLBService;
using Sonluk.UI.Model.HR.XZGL_XZDAService;
using Sonluk.UI.Model.HR.XZGL_ZXFJKCService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.HR.XZGL_FLDAService;
using Sonluk.UI.Model.HR.XZGL_MBGLService;
using Sonluk.UI.Model.HR.XZGL_MBGLMXService;
using Sonluk.UI.Model.HR.XZGL_FLDATZService;
using Sonluk.UI.Model.HR.XZGL_FLDATZMXService;
using Sonluk.UI.Model.HR.RY_BANKNOService;
using Sonluk.UI.Model.HR.XZGL_KKGLService;
using Sonluk.UI.Model.HR.XZGL_KKGLMXService;
using Sonluk.UI.Model.HR.XZGL_FFJLService;
using Sonluk.UI.Model.HR.XZGL_FFJLMXService;
using Sonluk.UI.Model.HR.XZGL_ZDGLGLService;
using Sonluk.UI.Model.HR.KQ_JQGLMXService;
using Sonluk.UI.Model.HR.SY_GSService;
using Sonluk.UI.Model.HR.SY_ZJHService;
using Sonluk.UI.Model.HR.XZGL_JJFL_HEARNAMEService;
using Sonluk.UI.Model.HR.XZGL_JJFL_HEADService;
using Sonluk.UI.Model.HR.XZGL_JJFL_MXService;

namespace Sonluk.PC.Areas.HR.Controllers
{
    public class XZGLController : Controller
    {
        //
        // GET: /HR/XZGL/
        HRModels hrmodels = new HRModels();
        CRMModels crmmodels = new CRMModels();
        AppClass appclass = new AppClass();
        MESModels mesModels = new MESModels();
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["HRFile"];
        string HRFile = System.Configuration.ConfigurationManager.AppSettings["HRFile"];
        string HRFile2 = System.Configuration.ConfigurationManager.AppSettings["HRFile2"];
        public ActionResult XZGL_FLFA()
        {
            AppClass.SetSession("location", 130);
            return View();
        }
        public ActionResult XZGL_XZDA()
        {
            AppClass.SetSession("location", 131);
            return View();
        }
        public ActionResult XZGL_XZDA_TZJL()
        {
            AppClass.SetSession("location", 131);
            return View();
        }
        public ActionResult XZGL_XZDA_ZHMANAGE()
        {
            AppClass.SetSession("location", 131);
            return View();
        }
        public ActionResult XZGL_MONTHXZJL()
        {
            AppClass.SetSession("location", 131);
            return View();
        }
        public ActionResult XZGL_ZDMANAGE()
        {
            AppClass.SetSession("location", 132);
            return View();
        }
        public ActionResult XZGL_ZXFJKC()
        {
            AppClass.SetSession("location", 134);
            return View();
        }
        public ActionResult XZGL_FLDA()
        {
            AppClass.SetSession("location", 133);
            return View();
        }
        public ActionResult XZGL_FLDATZ()
        {
            AppClass.SetSession("location", 136);
            return View();
        }
        public ActionResult XZGL_FLDATZMX()
        {
            AppClass.SetSession("location", 136);
            return View();
        }
        public ActionResult XZGL_MBGL()
        {
            AppClass.SetSession("location", 137);
            return View();
        }
        public ActionResult XZGL_FFJL()
        {
            AppClass.SetSession("location", 138);
            return View();
        }
        public ActionResult XZGL_KKGL()
        {
            AppClass.SetSession("location", 139);
            return View();
        }
        public ActionResult XZGL_KKGLMX()
        {
            AppClass.SetSession("location", 139);
            return View();
        }
        public ActionResult XZGL_FFJLLIST()
        {
            string ss = "";
            if (Session["MYPW"] != null)
            {
                ss = Session["MYPW"].ToString();
            }
            AppClass.SetSession("location", 138);
            return View();
        }
        public ActionResult XZGL_FFJL_REPORT()
        {
            AppClass.SetSession("location", 138);
            return View();
        }
        public ActionResult XZGL_FFJL_FFMXREPORT()
        {
            AppClass.SetSession("location", 138);
            return View();
        }
        public ActionResult XZGL_FFJL_GZXJSDREPORT()
        {
            AppClass.SetSession("location", 138);
            return View();
        }
        public ActionResult XZGL_FFJLMX_TXFREPORT()
        {
            AppClass.SetSession("location", 143);
            return View();
        }
        public ActionResult XZGL_JJFL_HEARNAME_MANAGE()
        {
            AppClass.SetSession("location", 10007);
            return View();
        }
        public ActionResult XZGL_JJFL_HEAD_MANAGE()
        {
            AppClass.SetSession("location", 10008);
            return View();
        }
        public ActionResult XZGL_JJFL_MX_MANAGE()
        {
            AppClass.SetSession("location", 10008);
            return View();
        }
        public ActionResult XZGL_JJFL_MX()
        {
            AppClass.SetSession("location", 10008);
            return View();
        }
        public ActionResult XZGL_ZQMONTH_MANAGE()
        {
            AppClass.SetSession("location", 10011);
            return View();
        }
        public ActionResult XZGL_FFJLLIST_TZ()
        {
            AppClass.SetSession("location", 10012);
            return View();
        }
        public ActionResult XZGL_FFJL_GUOSREPORT()
        {
            AppClass.SetSession("location", 10013);
            return View();
        }
        public ActionResult XZGL_FFJLMX_GAOWENJTREPORT()
        {
            AppClass.SetSession("location", 143);
            return View();
        }
        public ActionResult XZGL_FFJL_BACK()
        {
            AppClass.SetSession("location", 10114);
            return View();
        }
        [HttpPost]
        public string XZGL_FLFA_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLFA model_HR_XZGL_FLFA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLFA>(datastring);
            HR_XZGL_FLFA_SELECT rst = hrmodels.XZGL_FLFA.SELECT(model_HR_XZGL_FLFA, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_CRM_DICT(int TYPEID, int FID)
        {
            string token = AppClass.GetSession("token").ToString();
            CRM_HG_DICT[] rst = crmmodels.HG_DICT.Read(TYPEID, FID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FLFAMX_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX model_HR_XZGL_FLFAMX = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX>(datastring);
            HR_XZGL_FLFAMX_SELECT rst = hrmodels.XZGL_FLFAMX.SELECT(model_HR_XZGL_FLFAMX, token);
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
        public string XZGL_FLFA_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FLFA model_HR_XZGL_FLFA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLFA>(datastring);
            model_HR_XZGL_FLFA.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_FLFA.INSERT(model_HR_XZGL_FLFA, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FLFAMX_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX model_HR_XZGL_FLFAMX = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_FLFAMX.INSERT(model_HR_XZGL_FLFAMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FLFA_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FLFA model_HR_XZGL_FLFA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLFA>(datastring);
            model_HR_XZGL_FLFA.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_FLFA.DELETE(model_HR_XZGL_FLFA, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FLFA_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FLFA model_HR_XZGL_FLFA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLFA>(datastring);
            model_HR_XZGL_FLFA.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_FLFA.UPDATE(model_HR_XZGL_FLFA, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FLFAMX_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX model_HR_XZGL_FLFAMX = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_FLFAMX.UPDATE(model_HR_XZGL_FLFAMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FLFAMX_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX model_HR_XZGL_FLFAMX = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_FLFAMX.DELETE(model_HR_XZGL_FLFAMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_DEPT_SELECT_BY_ROLE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_DEPT model_HR_SY_DEPT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DEPT>(datastring);
            model_HR_SY_DEPT.STAFFID = STAFFID;
            HR_SY_DEPT_SELECT rst = hrmodels.SY_DEPT.SELECT_BY_ROLE(model_HR_SY_DEPT, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_GZLB_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_XZDA_GZLB model_HR_XZGL_XZDA_GZLB = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA_GZLB>(datastring);
            HR_XZGL_XZDA_GZLB_SELECT rst = hrmodels.XZGL_XZDA_GZLB.SELECT(model_HR_XZGL_XZDA_GZLB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_GZLB_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_XZDA_GZLB model_HR_XZGL_XZDA_GZLB = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA_GZLB>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_XZDA_GZLB.UPDATE(model_HR_XZGL_XZDA_GZLB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_GZLB_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_XZDA_GZLB model_HR_XZGL_XZDA_GZLB = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA_GZLB>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_XZDA_GZLB.DELETE(model_HR_XZGL_XZDA_GZLB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_GZLB_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_XZDA_GZLB model_HR_XZGL_XZDA_GZLB = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA_GZLB>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_XZDA_GZLB.INSERT(model_HR_XZGL_XZDA_GZLB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLZD_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLZD model_HR_XZGL_FFJLZD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLZD>(datastring);
            HR_XZGL_FFJLZD_SELECT rst = hrmodels.XZGL_FFJLZD.SELECT(model_HR_XZGL_FFJLZD, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLZD_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLZD model_HR_XZGL_FFJLZD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLZD>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_FFJLZD.INSERT(model_HR_XZGL_FFJLZD, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLZD_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLZD model_HR_XZGL_FFJLZD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLZD>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_FFJLZD.UPDATE(model_HR_XZGL_FFJLZD, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLZD_YYTABLEZD_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLZD_YYTABLEZD model_HR_XZGL_FFJLZD_YYTABLEZD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLZD_YYTABLEZD>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_FFJLZD.UPDATE_YYTABLEZD(model_HR_XZGL_FFJLZD_YYTABLEZD, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLZD_YYTABLEZD_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLZD_YYTABLEZD model_HR_XZGL_FFJLZD_YYTABLEZD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLZD_YYTABLEZD>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_FFJLZD.INSERT_YYTABLEZD(model_HR_XZGL_FFJLZD_YYTABLEZD, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLZD_YYTABLEZD_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLZD_YYTABLEZD model_HR_XZGL_FFJLZD_YYTABLEZD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLZD_YYTABLEZD>(datastring);
            HR_XZGL_FFJLZD_YYTABLEZD_SELECT rst = hrmodels.XZGL_FFJLZD.SELECT_YYTABLEZD(model_HR_XZGL_FFJLZD_YYTABLEZD, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_MYINFO_JM_ISTRUE(string MYPW)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = hrmodels.SY_MYINFO.JM_ISTRUE(MYPW, STAFFID, 2, token);
            //if (rst.TYPE == "S")
            //{
            //    AppClass.SetSession("MYPW", rst.MESSAGE);
            //}
            //else
            //{
            //    AppClass.SetSession("MYPW", "");
            //}
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_MYINFO_JM_ISTRUE_sy(string MYPW)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = hrmodels.SY_MYINFO.JM_ISTRUE(MYPW, STAFFID, 1, token);
            if (rst.TYPE == "S")
            {
                AppClass.SetSession("MYPW", rst.MESSAGE);
            }
            else
            {
                AppClass.SetSession("MYPW", "");
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string RY_RYINFO_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_RYINFO_SELECT rst = hrmodels.RY_RYINFO.SELECT(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_SELECTALL(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_XZDA model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA>(datastring);
            model_HR_XZGL_XZDA.STAFFID = STAFFID;
            HR_XZGL_XZDA_SELECT rst = hrmodels.XZGL_XZDA.SELECTALL(model_HR_XZGL_XZDA, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_XZDA[] model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA[]>(datastring);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            for (int a = 0; a < model_HR_XZGL_XZDA.Length; a++)
            {
                model_HR_XZGL_XZDA[a].CJR = STAFFID;
                rst = hrmodels.XZGL_XZDA.INSERT(model_HR_XZGL_XZDA[a], token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_AUTO_ADD_TO_FFJLMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_XZDA model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_XZDA.AUTO_ADD_TO_FFJLMX(model_HR_XZGL_XZDA, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_XZDA model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA>(datastring);
            model_HR_XZGL_XZDA.STAFFID = STAFFID;
            HR_XZGL_XZDA_SELECT rst = hrmodels.XZGL_XZDA.SELECT(model_HR_XZGL_XZDA, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_SELECT_NOMY(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_XZDA model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA>(datastring);
            model_HR_XZGL_XZDA.STAFFID = STAFFID;
            HR_XZGL_XZDA_SELECT rst = hrmodels.XZGL_XZDA.SELECT_NOMY(model_HR_XZGL_XZDA, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_XZDA_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_XZDA model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_XZDA.UPDATE(model_HR_XZGL_XZDA, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_BANKINFO_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            HR_RY_BANKNO[] model_HR_RY_BANKNO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_BANKNO[]>(datastring);
            for (int i = 0; i < model_HR_RY_BANKNO.Length; i++)
            {
                model_HR_RY_BANKNO[i].CJR = appclass.CRM_GetStaffid();
                rst = hrmodels.RY_BANKNO.INSERT(model_HR_RY_BANKNO[i], token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_BANKINFO_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_BANKNO model_HR_RY_BANKNO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_BANKNO>(datastring);
            HR_RY_BANKNO_SELECT rst = hrmodels.RY_BANKNO.SELECT(model_HR_RY_BANKNO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_BANKINFO_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_BANKNO model_HR_RY_BANKNO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_BANKNO>(datastring);
            model_HR_RY_BANKNO.XGR = appclass.CRM_GetStaffid();
            MES_RETURN_UI rst = hrmodels.RY_BANKNO.UPDATE(model_HR_RY_BANKNO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_BANKINFO_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_BANKNO model_HR_RY_BANKNO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_BANKNO>(datastring);
            model_HR_RY_BANKNO.XGR = appclass.CRM_GetStaffid();
            MES_RETURN_UI rst = hrmodels.RY_BANKNO.DELETE(model_HR_RY_BANKNO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string Data_DaoRu_NSZH()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            string allgs = "";
            for (int i = 0; i < rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length; i++)
            {
                if (allgs == "")
                {
                    allgs = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
                else
                {
                    allgs = allgs + "," + rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
            }
            //DaoRuMsg msg = new DaoRuMsg();
            MES_RETURN_UI msg = new MES_RETURN_UI();
            try
            {
                var file = Request.Files[0];

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                string gotname = file.FileName;

                string savePath = HRFile + @"\upload\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(HRFile + @"\upload\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(HRFile + @"\upload\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);


                if (fi.Exists == true)
                {
                    string[] sheet = { "纳税账户导入" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, 0, true);      //专项附加扣除
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("工号") == false || data1.Columns.Contains("姓名") == false || data1.Columns.Contains("纳税人身份") == false || data1.Columns.Contains("纳税人识别号") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["工号"].ToString() != "")
                                        {
                                            if (data1.Rows[i]["工号"].ToString().Length != 5)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "纳税账户导入第" + (i + 2) + "行工号格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (data1.Rows[i]["姓名"].ToString().Trim() == "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "纳税账户导入第" + (i + 2) + "行姓名格为空！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            //HR_XZGL_XZDA model = new HR_XZGL_XZDA();
                                            //model.GH = data1.Rows[i]["工号"].ToString();
                                            //model.STAFFID = STAFFID;
                                            //model.YGNAME = data1.Rows[i]["姓名"].ToString();
                                            //HR_XZGL_XZDA_SELECT staffdata = hrmodels.XZGL_XZDA.SELECT_NOMY(model, 6, token);
                                            //if (staffdata.DataTable.Rows.Count == 0)
                                            //{
                                            //    msg.Msg = "纳税账户导入第" + (i + 2) + "行工号姓名不存在！";
                                            //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            //}
                                            HR_RY_RYINFO model = new HR_RY_RYINFO();
                                            model.GH = data1.Rows[i]["工号"].ToString();
                                            model.ALLGS = allgs;
                                            model.YGNAME = data1.Rows[i]["姓名"].ToString().Trim();
                                            HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(model, token);
                                            if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "纳税账户导入第" + (i + 2) + "行工号姓名不存在！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (data1.Rows[i]["纳税人身份"].ToString() == "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "纳税账户导入第" + (i + 2) + "行纳税人身份未输！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            HR_SY_TYPEMX model_HR_SY_TYPEMX = new HR_SY_TYPEMX();
                                            model_HR_SY_TYPEMX.TYPEID = 5;
                                            model_HR_SY_TYPEMX.MXNAME = data1.Rows[i]["纳税人身份"].ToString();
                                            HR_SY_TYPEMX_SELECT rst_HR_SY_TYPEMX_SELECT = hrmodels.SY_TYPEMX.SELECT(model_HR_SY_TYPEMX, token);
                                            if (rst_HR_SY_TYPEMX_SELECT.HR_SY_TYPEMX.Length == 0)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "纳税账户导入第" + (i + 2) + "行纳税人身份输入有问题，请检查！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (data1.Rows[i]["纳税人识别号"].ToString() == "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "纳税账户导入第" + (i + 2) + "行纳税人识别号未输！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        if (data1.Rows[i]["工号"].ToString() != "")
                        {
                            HR_XZGL_XZDA insert_model = new HR_XZGL_XZDA();
                            insert_model.GH = data1.Rows[i]["工号"].ToString();
                            insert_model.STAFFID = STAFFID;
                            HR_XZGL_XZDA_SELECT staffdata = hrmodels.XZGL_XZDA.SELECT_NOMY(insert_model, 6, token);
                            HR_SY_TYPEMX model_HR_SY_TYPEMX = new HR_SY_TYPEMX();
                            model_HR_SY_TYPEMX.MXNAME = data1.Rows[i]["纳税人身份"].ToString();
                            HR_SY_TYPEMX_SELECT model_NSR = hrmodels.SY_TYPEMX.SELECT(model_HR_SY_TYPEMX, token);
                            HR_XZGL_XZDA model = new HR_XZGL_XZDA();
                            model.RYID = Convert.ToInt32(staffdata.DataTable.Rows[0]["RYID"]);
                            model.NSRSF = model_NSR.HR_SY_TYPEMX[0].ID;//Convert.ToInt32(data1.Rows[i]["纳税人身份"].ToString().Trim());
                            model.NSRSBH = Convert.ToString(data1.Rows[i]["纳税人识别号"].ToString().Trim());
                            model.XGR = appclass.CRM_GetStaffid();


                            MES_RETURN_UI result = hrmodels.XZGL_XZDA.UPDATE(model, 3, token);


                            if (result.TYPE == "E")
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = "纳税账户导入的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }
                    msg.TYPE = "S";
                    msg.MESSAGE = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.TYPE = "E";
                msg.MESSAGE = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }

        [HttpPost]
        public string EXPOST_NSZH(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_XZDA model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA>(alldata);
            model_HR_XZGL_XZDA.STAFFID = STAFFID;
            try
            {
                HR_XZGL_XZDA_SELECT staffdata = hrmodels.XZGL_XZDA.SELECT_NOMY(model_HR_XZGL_XZDA, 4, token);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/纳税账户导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < staffdata.DataTable.Rows.Count; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["GH"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["YGNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["GSNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["DEPTNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["YGTYPENAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["ZZTYPENAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["ZZNO"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["NSRSFNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["NSRSBH"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["ZZZTNAME"]));
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_DOWNLOAD_NSZH(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "纳税账户导出.xls");
        }
        public ActionResult EXPORT_MBLOAD_NSZH()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            byte[] arrFile = null;
            try
            {
                //FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/纳税账户导入模板.xls", FileMode.Open, FileAccess.Read);
                //IWorkbook workbook = new HSSFWorkbook(file);
                //ISheet sheet = workbook.GetSheetAt(0);
                //string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                //FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                //workbook.Write(file1);
                //file1.Close();
                //string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now);
                string file = string.Format(@"{0}/Areas/HR/ExportFile/纳税账户导入模板.xls", Server.MapPath("~"));
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    arrFile = new byte[fs.Length];
                    fs.Read(arrFile, 0, arrFile.Length);
                }
                rst.TYPE = "S";
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "文件无法下载！";
            }
            return File(arrFile, "application/vnd.ms-excel", "纳税账户导入模板.xls");
        }
        [HttpPost]
        public string Data_DaoRu_YHZH()
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            string allgs = "";
            for (int i = 0; i < rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length; i++)
            {
                if (allgs == "")
                {
                    allgs = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
                else
                {
                    allgs = allgs + "," + rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
            }
            //DaoRuMsg msg = new DaoRuMsg();
            MES_RETURN_UI msg = new MES_RETURN_UI();
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                string savePath = HRFile + @"\upload\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(HRFile + @"\upload\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(HRFile + @"\upload\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    string[] sheet = { "银行账户导入" };
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("工号") == false || data1.Columns.Contains("姓名") == false || data1.Columns.Contains("卡类别") == false || data1.Columns.Contains("开户银行") == false || data1.Columns.Contains("银行账户") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["工号"].ToString().Length != 5)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "银行账户导入第" + (i + 2) + "行工号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //HR_XZGL_XZDA model = new HR_XZGL_XZDA();
                                        //model.GH = data1.Rows[i]["工号"].ToString();
                                        //model.STAFFID = STAFFID;
                                        //HR_XZGL_XZDA_SELECT staffdata = hrmodels.XZGL_XZDA.SELECT_NOMY(model, 6, token);

                                        //if (staffdata.DataTable.Rows.Count == 0)
                                        //{
                                        //    msg.Msg = "银行账户导入第" + (i + 2) + "行工号不存在！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        if (data1.Rows[i]["姓名"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "银行账户导入第" + (i + 2) + "行姓名格为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //HR_XZGL_XZDA model = new HR_XZGL_XZDA();
                                        //model.GH = data1.Rows[i]["工号"].ToString();
                                        //model.STAFFID = STAFFID;
                                        //model.YGNAME = data1.Rows[i]["姓名"].ToString();
                                        //HR_XZGL_XZDA_SELECT staffdata = hrmodels.XZGL_XZDA.SELECT_NOMY(model, 6, token);
                                        //if (staffdata.DataTable.Rows.Count == 0)
                                        //{
                                        //    msg.Msg = "纳税账户导入第" + (i + 2) + "行工号姓名不存在！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        HR_RY_RYINFO model = new HR_RY_RYINFO();
                                        model.GH = data1.Rows[i]["工号"].ToString();
                                        model.ALLGS = allgs;
                                        model.YGNAME = data1.Rows[i]["姓名"].ToString().Trim();
                                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(model, token);
                                        if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "银行账户导入第" + (i + 2) + "行工号姓名不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["卡类别"].ToString() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "银行账户导入第" + (i + 2) + "卡类别未输！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["开户银行"].ToString() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "银行账户导入第" + (i + 2) + "开户银行未输！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //if (data1.Rows[i]["银行账户"].ToString() == "")
                                        //{
                                        //    msg.TYPE = "E";
                                        //    msg.MESSAGE = "银行账户导入第" + (i + 2) + "银行账户未输！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        HR_XZGL_XZDA insert_model = new HR_XZGL_XZDA();
                        insert_model.GH = data1.Rows[i]["工号"].ToString();
                        insert_model.STAFFID = STAFFID;
                        HR_XZGL_XZDA_SELECT staffdata = hrmodels.XZGL_XZDA.SELECT_NOMY(insert_model, 6, token);

                        HR_SY_TYPEMX model_ZHLB = new HR_SY_TYPEMX();
                        model_ZHLB.MXNAME = data1.Rows[i]["卡类别"].ToString();
                        HR_SY_TYPEMX_SELECT model_LB = hrmodels.SY_TYPEMX.SELECT(model_ZHLB, token);

                        HR_SY_TYPEMX model_BANK = new HR_SY_TYPEMX();
                        model_BANK.MXNAME = data1.Rows[i]["开户银行"].ToString();
                        HR_SY_TYPEMX_SELECT model_BANKNAME = hrmodels.SY_TYPEMX.SELECT(model_BANK, token);

                        HR_RY_BANKNO model = new HR_RY_BANKNO();
                        model.RYID = Convert.ToInt32(staffdata.DataTable.Rows[0]["RYID"]);
                        model.ZHLB = model_LB.HR_SY_TYPEMX[0].ID;
                        model.BANK = model_BANKNAME.HR_SY_TYPEMX[0].ID;
                        model.BANKNO = data1.Rows[i]["银行账户"].ToString();
                        model.CJR = appclass.CRM_GetStaffid();
                        MES_RETURN_UI result = hrmodels.RY_BANKNO.INSERT(model, token);
                        if (result.TYPE == "E")
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "银行账户导入的第" + (i + 2) + "行出现问题，" + result.MESSAGE;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    msg.TYPE = "S";
                    msg.MESSAGE = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.TYPE = "E";
                msg.MESSAGE = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public string EXPOST_YHZH(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_XZDA model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA>(alldata);
            model_HR_XZGL_XZDA.STAFFID = STAFFID;
            try
            {
                HR_XZGL_XZDA_SELECT staffdata = hrmodels.XZGL_XZDA.SELECT_NOMY(model_HR_XZGL_XZDA, 5, token);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/银行账户导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < staffdata.DataTable.Rows.Count; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["GH"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["YGNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["GSNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["DEPTNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["YGTYPENAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["ZZTYPENAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["ZZNO"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["NSRSFNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["NSRSBH"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["ZZZTNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["ZHLBNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["BANKNAME"]));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(staffdata.DataTable.Rows[i]["BANKNO"]));
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_DOWNLOAD_YHZH(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "银行账户导出.xls");
        }
        public ActionResult EXPORT_MBLOAD_YHZH()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            byte[] arrFile = null;
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/中银HR系统_银行账号_导入模板.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now);
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    arrFile = new byte[fs.Length];
                    fs.Read(arrFile, 0, arrFile.Length);
                }
                System.IO.File.Delete(path);
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return File(arrFile, "application/vnd.ms-excel", "银行账号_导入模板.xlsx");
        }
        [HttpPost]
        public string Data_DaoRu_XZDA(string MYPW)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            string allgs = "";
            for (int i = 0; i < rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length; i++)
            {
                if (allgs == "")
                {
                    allgs = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
                else
                {
                    allgs = allgs + "," + rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
            }
            MES_RETURN_UI msg = new MES_RETURN_UI();
            try
            {
                if (MYPW == "")
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "请输入密钥！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                string savePath = HRFile + @"\upload\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(HRFile + @"\upload\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(HRFile + @"\upload\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    string[] sheet = { "员工薪资档案" };
                    HR_XZGL_XZDA_GZLB model_HR_XZGL_XZDA_GZLB = new HR_XZGL_XZDA_GZLB();
                    HR_XZGL_XZDA_GZLB_SELECT rst_HR_XZGL_XZDA_GZLB_SELECT = hrmodels.XZGL_XZDA_GZLB.SELECT(model_HR_XZGL_XZDA_GZLB, token);
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);      //专项附加扣除
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("工号") == false || data1.Columns.Contains("姓名") == false || data1.Columns.Contains("生效日期") == false || data1.Columns.Contains("调整原因") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        if (rst_HR_XZGL_XZDA_GZLB_SELECT.MES_RETURN.TYPE == "S")
                        {
                            for (int a = 0; a < rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB.Length; a++)
                            {
                                if (data1.Columns.Contains(rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBNAME) == false)
                                {
                                    msg.TYPE = "E";
                                    msg.MESSAGE = "请使用新增模版！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }
                        else
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = rst_HR_XZGL_XZDA_GZLB_SELECT.MES_RETURN.MESSAGE;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        try
                        {
                            if (data1.Rows.Count > 0)
                            {
                                for (int i = 0; i < data1.Rows.Count; i++)
                                {
                                    if (data1.Rows[i]["工号"].ToString().Trim() != "")
                                    {
                                        string sxdatemax = "";
                                        if (data1.Rows[i]["工号"].ToString().Length != 5)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工薪资档案第" + (i + 2) + "行工号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["姓名"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工薪资档案第" + (i + 2) + "行姓名格为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        HR_RY_RYINFO model = new HR_RY_RYINFO();
                                        model.GH = data1.Rows[i]["工号"].ToString();
                                        model.ALLGS = allgs;
                                        model.YGNAME = data1.Rows[i]["姓名"].ToString().Trim();
                                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(model, token);
                                        if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工薪资档案第" + (i + 2) + "行工号姓名不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["生效日期"].ToString(), @"(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)") == false)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工薪资档案第" + (i + 2) + "行生效日期格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        HR_XZGL_XZDA model_HR_XZGL_XZDA = new HR_XZGL_XZDA();
                                        model_HR_XZGL_XZDA.MYPW = MYPW;
                                        model_HR_XZGL_XZDA.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                                        HR_XZGL_XZDA_SELECT rst = hrmodels.XZGL_XZDA.SELECTALL(model_HR_XZGL_XZDA, 2, token);
                                        for (int a = 0; a < rst.HR_XZGL_XZDA_LIST.Length; a++)
                                        {
                                            if (sxdatemax == "")
                                            {
                                                sxdatemax = rst.HR_XZGL_XZDA_LIST[a].SXDATE;
                                            }
                                            else
                                            {
                                                if (DateTime.Parse(sxdatemax) < DateTime.Parse(rst.HR_XZGL_XZDA_LIST[a].SXDATE))
                                                {
                                                    sxdatemax = rst.HR_XZGL_XZDA_LIST[a].SXDATE;
                                                }
                                            }
                                        }
                                        if (sxdatemax != "" && DateTime.Parse(data1.Rows[i]["生效日期"].ToString()) <= DateTime.Parse(sxdatemax))
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工薪资档案第" + (i + 2) + "行生效日期早于上次更改日期，请核对后输入！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["调整原因"].ToString() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工薪资档案第" + (i + 2) + "行调整原因未输！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //if (Regex.IsMatch(data1.Rows[i]["工资"].ToString(), @"^\d{3,}$") == false)
                                        //{
                                        //    msg.Msg = "员工薪资档案第" + (i + 2) + "行工资格式不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        //if (Regex.IsMatch(data1.Rows[i]["绩效"].ToString(), @"^\d{3,}$") == false)
                                        //{
                                        //    msg.Msg = "员工薪资档案第" + (i + 2) + "行绩效格式不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        for (int a = 0; a < rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB.Length; a++)
                                        {
                                            try
                                            {
                                                if (data1.Rows[i][rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBNAME].ToString().Trim() != "")
                                                {
                                                    Convert.ToDecimal(data1.Rows[i][rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBNAME].ToString());
                                                }
                                            }
                                            catch
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "员工薪资档案第" + (i + 2) + "行" + rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBNAME + "格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = e.ToString();
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                    //专项附加扣除
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        HR_RY_RYINFO cxmodel = new HR_RY_RYINFO();
                        cxmodel.GH = data1.Rows[i]["工号"].ToString();
                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(cxmodel, token);

                        //HR_XZGL_XZDA_GZLB model_HR_XZGL_XZDA_GZLB = new HR_XZGL_XZDA_GZLB();
                        //HR_XZGL_XZDA_GZLB_SELECT rst = hrmodels.XZGL_XZDA_GZLB.SELECT(model_HR_XZGL_XZDA_GZLB, token);
                        //for (int j = 0; j < rst.HR_XZGL_XZDA_GZLB.Length; j++)
                        //{
                        //    HR_XZGL_XZDA model = new HR_XZGL_XZDA();
                        //    model.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                        //    model.GZLBID = rst.HR_XZGL_XZDA_GZLB[j].GZLBID;
                        //    model.TZH = Convert.ToDecimal(data1.Rows[i]["工资"].ToString().Trim());
                        //    model.TZYY = data1.Rows[i]["调整原因"].ToString().Trim();
                        //    model.SXDATE = data1.Rows[i]["生效日期"].ToString();
                        //    model.CJR = appclass.CRM_GetStaffid();
                        //    MES_RETURN_UI result = hrmodels.XZGL_XZDA.INSERT(model, token);
                        //}
                        //HR_XZGL_XZDA model = new HR_XZGL_XZDA();
                        //if (data1.Rows[i]["工资"].ToString().Trim() != "")
                        //{
                        //    model.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                        //    model.GZLBID = 1;
                        //    model.TZH = Convert.ToDecimal(data1.Rows[i]["工资"].ToString().Trim());
                        //    model.TZYY = data1.Rows[i]["调整原因"].ToString().Trim();
                        //    model.SXDATE = data1.Rows[i]["生效日期"].ToString();
                        //    model.CJR = appclass.CRM_GetStaffid();
                        //    MES_RETURN_UI result = hrmodels.XZGL_XZDA.INSERT(model, token);
                        //    if (result.TYPE == "E")
                        //    {
                        //        msg.Msg = "新增专项附加扣除的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        //        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        //    }
                        //}
                        //HR_XZGL_XZDA model1 = new HR_XZGL_XZDA();
                        //if (data1.Rows[i]["绩效"].ToString().Trim() != "")
                        //{
                        //    model.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                        //    model.GZLBID = 2;
                        //    model.TZH = Convert.ToDecimal(data1.Rows[i]["绩效"].ToString().Trim());
                        //    model.TZYY = data1.Rows[i]["调整原因"].ToString().Trim();
                        //    model.SXDATE = data1.Rows[i]["生效日期"].ToString();
                        //    model.CJR = appclass.CRM_GetStaffid();
                        //    MES_RETURN_UI result1 = hrmodels.XZGL_XZDA.INSERT(model, token);
                        //    if (result1.TYPE == "E")
                        //    {
                        //        msg.Msg = "新增专项附加扣除的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        //        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        //    }
                        //}
                        for (int a = 0; a < rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB.Length; a++)
                        {
                            if (data1.Rows[i]["工号"].ToString().Trim() != "")
                            {
                                if (data1.Rows[i][rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBNAME].ToString().Trim() != "")
                                {
                                    HR_XZGL_XZDA model_HR_XZGL_XZDA = new HR_XZGL_XZDA();
                                    model_HR_XZGL_XZDA.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                                    model_HR_XZGL_XZDA.GZLBID = rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBID;
                                    model_HR_XZGL_XZDA.TZH = Convert.ToDecimal(data1.Rows[i][rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBNAME].ToString().Trim());
                                    //model_HR_XZGL_XZDA.TZYY = data1.Rows[i]["调整原因"].ToString().Trim();
                                    HR_SY_TYPEMX model_HR_SY_TYPEMX = new HR_SY_TYPEMX();
                                    model_HR_SY_TYPEMX.GS = staffdata.HR_RY_RYINFO_LIST[0].GS;
                                    model_HR_SY_TYPEMX.TYPEID = 31;
                                    model_HR_SY_TYPEMX.MXNAME = data1.Rows[i]["调整原因"].ToString().Trim();
                                    HR_SY_TYPEMX_SELECT rst_HR_SY_TYPEMX_SELECT = hrmodels.SY_TYPEMX.SELECT(model_HR_SY_TYPEMX, token);
                                    if (rst_HR_SY_TYPEMX_SELECT.MES_RETURN.TYPE == "S")
                                    {
                                        if (rst_HR_SY_TYPEMX_SELECT.HR_SY_TYPEMX.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工薪资档案第" + (i + 2) + "行调整原因查询出错未输！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        else
                                        {
                                            model_HR_XZGL_XZDA.TZYY = rst_HR_SY_TYPEMX_SELECT.HR_SY_TYPEMX[0].ID;
                                        }
                                    }
                                    else
                                    {
                                        msg.TYPE = "E";
                                        msg.MESSAGE = "员工薪资档案第" + (i + 2) + "行调整原因查询出错未输！" + rst_HR_SY_TYPEMX_SELECT.MES_RETURN.MESSAGE;
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }

                                    model_HR_XZGL_XZDA.SXDATE = data1.Rows[i]["生效日期"].ToString();
                                    model_HR_XZGL_XZDA.CJR = appclass.CRM_GetStaffid();
                                    model_HR_XZGL_XZDA.MYPW = MYPW;
                                    MES_RETURN_UI result = hrmodels.XZGL_XZDA.INSERT(model_HR_XZGL_XZDA, token);
                                    if (result.TYPE == "E")
                                    {
                                        msg.TYPE = "E";
                                        msg.MESSAGE = "新增福利档案的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员" + result.MESSAGE;
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                            }
                        }
                    }
                    msg.TYPE = "S";
                    msg.MESSAGE = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.TYPE = "E";
                msg.MESSAGE = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }

        [HttpPost]
        public string Data_DaoRu_JJFLMX(int JJFLID)
        {
            MES_RETURN_UI msg = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_HEAD model_HR_XZGL_JJFL_HEAD = new HR_XZGL_JJFL_HEAD();
            model_HR_XZGL_JJFL_HEAD.JJFLID = JJFLID;
            model_HR_XZGL_JJFL_HEAD.STAFFID = STAFFID;
            HR_XZGL_JJFL_HEAD_SELECT rst_HR_XZGL_JJFL_HEAD_SELECT = hrmodels.XZGL_JJFL_HEAD.SELECT(model_HR_XZGL_JJFL_HEAD, token);
            if (rst_HR_XZGL_JJFL_HEAD_SELECT.MES_RETURN.TYPE != "S")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_JJFL_HEAD_SELECT.MES_RETURN);
            }
            if (rst_HR_XZGL_JJFL_HEAD_SELECT.DATALIST.Rows.Count == 0)
            {
                msg.TYPE = "E";
                msg.MESSAGE = "记录不存在，请检查！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            if (rst_HR_XZGL_JJFL_HEAD_SELECT.DATALIST.Rows[0]["ISACTION"].ToString() == "2")
            {
                msg.TYPE = "E";
                msg.MESSAGE = "已结案，不允许修改！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                string savePath = HRFile + @"\upload\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(HRFile + @"\upload\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(HRFile + @"\upload\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);      //专项附加扣除
                    try
                    {
                        System.IO.File.Delete(savePath);
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("工号") == false || data1.Columns.Contains("姓名") == false || data1.Columns.Contains("出勤") == false || data1.Columns.Contains("加班") == false || data1.Columns.Contains("绩效奖金") == false || data1.Columns.Contains("加班工资") == false || data1.Columns.Contains("爱岗敬业奖") == false || data1.Columns.Contains("借出部门") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        try
                        {
                            if (data1.Rows.Count > 0)
                            {
                                data1.Columns.Add("RYID", typeof(int));
                                for (int i = 0; i < data1.Rows.Count; i++)
                                {
                                    if (data1.Rows[i]["工号"].ToString().Trim() != "")
                                    {
                                        if (data1.Rows[i]["工号"].ToString().Length != 5)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行工号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["姓名"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行姓名格为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        HR_RY_RYINFO model = new HR_RY_RYINFO();
                                        model.GH = data1.Rows[i]["工号"].ToString();
                                        model.YGNAME = data1.Rows[i]["姓名"].ToString().Trim();
                                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(model, token);
                                        if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行工号姓名不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        else
                                        {
                                            data1.Rows[i]["RYID"] = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                                        }
                                        try
                                        {
                                            if (data1.Rows[i]["出勤"].ToString().Trim() != "")
                                            {
                                                Convert.ToDecimal(data1.Rows[i]["出勤"].ToString());
                                            }
                                        }
                                        catch
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "第" + (i + 2) + "行 出勤 格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        try
                                        {
                                            if (data1.Rows[i]["加班"].ToString().Trim() != "")
                                            {
                                                Convert.ToDecimal(data1.Rows[i]["加班"].ToString());
                                            }
                                        }
                                        catch
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "第" + (i + 2) + "行 加班 格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        try
                                        {
                                            if (data1.Rows[i]["绩效奖金"].ToString().Trim() != "")
                                            {
                                                Convert.ToDecimal(data1.Rows[i]["绩效奖金"].ToString());
                                            }
                                        }
                                        catch
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "第" + (i + 2) + "行 绩效奖金 格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        try
                                        {
                                            if (data1.Rows[i]["加班工资"].ToString().Trim() != "")
                                            {
                                                Convert.ToDecimal(data1.Rows[i]["加班工资"].ToString());
                                            }
                                        }
                                        catch
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "第" + (i + 2) + "行 加班工资 格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        try
                                        {
                                            if (data1.Rows[i]["爱岗敬业奖"].ToString().Trim() != "")
                                            {
                                                Convert.ToDecimal(data1.Rows[i]["爱岗敬业奖"].ToString());
                                            }
                                        }
                                        catch
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "第" + (i + 2) + "行 爱岗敬业奖 格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = e.ToString();
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    DataTable dtRYLIST = new DataTable();
                    dtRYLIST.Columns.Add("RYID", typeof(int));
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        if (data1.Rows[i]["工号"].ToString().Trim() != "")
                        {
                            DataRow dr = dtRYLIST.NewRow();
                            dr[0] = data1.Rows[i]["RYID"];
                            dtRYLIST.Rows.Add(dr);
                        }
                    }
                    HR_XZGL_JJFL_MX model_HR_XZGL_JJFL_MX = new HR_XZGL_JJFL_MX();
                    model_HR_XZGL_JJFL_MX.JJFLID = JJFLID;
                    dtRYLIST.TableName = "DataTable";
                    model_HR_XZGL_JJFL_MX.CJR = STAFFID;
                    MES_RETURN_UI rst = hrmodels.XZGL_JJFL_MX.INSERT(model_HR_XZGL_JJFL_MX, dtRYLIST, token);
                    if (rst.TYPE != "S")
                    {
                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    }
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        if (data1.Rows[i]["工号"].ToString().Trim() != "")
                        {
                            model_HR_XZGL_JJFL_MX = new HR_XZGL_JJFL_MX();
                            model_HR_XZGL_JJFL_MX.JJFLID = JJFLID;
                            model_HR_XZGL_JJFL_MX.RYID = Convert.ToInt32(data1.Rows[i]["RYID"].ToString().Trim());
                            model_HR_XZGL_JJFL_MX.XGR = STAFFID;
                            if (data1.Rows[i]["出勤"].ToString().Trim() != "")
                            {
                                model_HR_XZGL_JJFL_MX.CHUQCOUNT = Convert.ToDecimal(data1.Rows[i]["出勤"].ToString().Trim());
                                msg = hrmodels.XZGL_JJFL_MX.UPDATE(model_HR_XZGL_JJFL_MX, 3, token);
                                if (msg.TYPE != "S")
                                {
                                    msg.MESSAGE = "第 " + (i + 2) + "行 出勤" + msg.MESSAGE;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                            if (data1.Rows[i]["加班"].ToString().Trim() != "")
                            {
                                model_HR_XZGL_JJFL_MX.CHUQCOUNT = Convert.ToDecimal(data1.Rows[i]["加班"].ToString().Trim());
                                msg = hrmodels.XZGL_JJFL_MX.UPDATE(model_HR_XZGL_JJFL_MX, 4, token);
                                if (msg.TYPE != "S")
                                {
                                    msg.MESSAGE = "第 " + (i + 2) + "行 加班" + msg.MESSAGE;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                            if (data1.Rows[i]["绩效奖金"].ToString().Trim() != "")
                            {
                                model_HR_XZGL_JJFL_MX.CHUQCOUNT = Convert.ToDecimal(data1.Rows[i]["绩效奖金"].ToString().Trim());
                                msg = hrmodels.XZGL_JJFL_MX.UPDATE(model_HR_XZGL_JJFL_MX, 5, token);
                                if (msg.TYPE != "S")
                                {
                                    msg.MESSAGE = "第 " + (i + 2) + "行 绩效奖金" + msg.MESSAGE;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                            if (data1.Rows[i]["加班工资"].ToString().Trim() != "")
                            {
                                model_HR_XZGL_JJFL_MX.CHUQCOUNT = Convert.ToDecimal(data1.Rows[i]["加班工资"].ToString().Trim());
                                msg = hrmodels.XZGL_JJFL_MX.UPDATE(model_HR_XZGL_JJFL_MX, 6, token);
                                if (msg.TYPE != "S")
                                {
                                    msg.MESSAGE = "第 " + (i + 2) + "行 加班工资" + msg.MESSAGE;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                            if (data1.Rows[i]["爱岗敬业奖"].ToString().Trim() != "")
                            {
                                model_HR_XZGL_JJFL_MX.CHUQCOUNT = Convert.ToDecimal(data1.Rows[i]["爱岗敬业奖"].ToString().Trim());
                                msg = hrmodels.XZGL_JJFL_MX.UPDATE(model_HR_XZGL_JJFL_MX, 7, token);
                                if (msg.TYPE != "S")
                                {
                                    msg.MESSAGE = "第 " + (i + 2) + "行 爱岗敬业奖" + msg.MESSAGE;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                            if (data1.Rows[i]["借出部门"].ToString().Trim() != "")
                            {
                                model_HR_XZGL_JJFL_MX.JCDEPTNAME = data1.Rows[i]["借出部门"].ToString().Trim();
                                msg = hrmodels.XZGL_JJFL_MX.UPDATE(model_HR_XZGL_JJFL_MX, 8, token);
                                if (msg.TYPE != "S")
                                {
                                    msg.MESSAGE = "第 " + (i + 2) + "行 借出部门" + msg.MESSAGE;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }
                    }
                    msg.TYPE = "S";
                    msg.MESSAGE = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.TYPE = "E";
                msg.MESSAGE = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }

        [HttpPost]
        public string EXPOST_XZDA(string alldata)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_XZDA model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA>(alldata);
            model_HR_XZGL_XZDA.STAFFID = STAFFID;
            HR_XZGL_XZDA_SELECT rst_HR_XZGL_XZDA_SELECT = hrmodels.XZGL_XZDA.SELECT(model_HR_XZGL_XZDA, token);
            if (rst_HR_XZGL_XZDA_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_XZDA_SELECT.MES_RETURN);
            }
            MES_RETURN_UI rst = new MES_RETURN_UI();
            DataTable model = rst_HR_XZGL_XZDA_SELECT.DataTable;
            DataTable dt = model;
            try
            {
                HR_XZGL_XZDA_GZLB model_HR_XZGL_XZDA_GZLB = new HR_XZGL_XZDA_GZLB();
                HR_XZGL_XZDA_GZLB_SELECT rst_HR_XZGL_XZDA_GZLB_SELECT = hrmodels.XZGL_XZDA_GZLB.SELECT(model_HR_XZGL_XZDA_GZLB, token);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,公司,部门,员工类别,证照类型,证照号码,纳税人身份,纳税人识别号,在职状态";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int a = 0; a < rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBNAME);
                }
                //FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/员工薪资档案导出.xls", FileMode.Open, FileAccess.Read);
                //IWorkbook workbook = new HSSFWorkbook(file);
                //ISheet sheet = workbook.GetSheetAt(0);
                //int rowcount = 1;
                for (int i = 0; i < model.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["YGTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["ZZTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["ZZNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["NSRSFNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["NSRSBH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model.Rows[i]["ZZZTNAME"].ToString());
                    //row.CreateCell(cellIndex++).SetCellValue(model[i].M1);
                    //row.CreateCell(cellIndex++).SetCellValue(model[i].M2);
                    for (int a = 0; a < rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB.Length; a++)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dt.Rows[i]["M" + rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBID].ToString()));
                    }
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_DOWNLOAD_XZDA(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "员工薪资档案导出.xlsx");
        }
        public ActionResult EXPORT_MBLOAD_XZDA()
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            byte[] arrFile = null;
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/员工薪资档案导入模板.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                HR_XZGL_XZDA_GZLB model_HR_XZGL_XZDA_GZLB = new HR_XZGL_XZDA_GZLB();
                HR_XZGL_XZDA_GZLB_SELECT rst_HR_XZGL_XZDA_GZLB_SELECT = hrmodels.XZGL_XZDA_GZLB.SELECT(model_HR_XZGL_XZDA_GZLB, token);
                int rowcount = 0;
                string tt = "工号,姓名,生效日期,调整原因";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int a = 0; a < rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_XZDA_GZLB_SELECT.HR_XZGL_XZDA_GZLB[a].GZLBNAME);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now);
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    arrFile = new byte[fs.Length];
                    fs.Read(arrFile, 0, arrFile.Length);
                }
                System.IO.File.Delete(path);
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return File(arrFile, "application/vnd.ms-excel", "员工薪资档案导入模板.xls");
        }
        public ActionResult EXPORT_MBLOAD_JJFLMX()
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            byte[] arrFile = null;
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,出勤,加班,绩效奖金,加班工资,爱岗敬业奖";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now);
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    arrFile = new byte[fs.Length];
                    fs.Read(arrFile, 0, arrFile.Length);
                }
                System.IO.File.Delete(path);
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return File(arrFile, "application/vnd.ms-excel", "奖金福利明细导入模板.xlsx");
        }

        [HttpPost]
        public string DataTableToJsonWithJsonNet(DataTable table)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }
        [HttpPost]
        public string Data_Insert_ZXFJKC(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_ZXFJKC model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_ZXFJKC>(data);
            model.CJR = appclass.CRM_GetStaffid();
            MES_RETURN_UI result = hrmodels.XZGL_ZXFJKC.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Update_ZXFJKC(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_ZXFJKC model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_ZXFJKC>(data);
            model.XGR = appclass.CRM_GetStaffid();
            MES_RETURN_UI result = hrmodels.XZGL_ZXFJKC.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Select_ZXFJKC(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_ZXFJKC model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_ZXFJKC>(data);
            model.STAFFID = STAFFID;
            HR_XZGL_ZXFJKC_SELECT result = hrmodels.XZGL_ZXFJKC.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Delete_ZXFJKC(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_ZXFJKC model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_ZXFJKC>(data);
            MES_RETURN_UI result = hrmodels.XZGL_ZXFJKC.DELETE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string XZGL_ZXFJKC_AUTO_ADD_TO_FFJLMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_ZXFJKC model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_ZXFJKC>(datastring);
            MES_RETURN_UI result = hrmodels.XZGL_ZXFJKC.AUTO_ADD_TO_FFJLMX(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_DaoRu_ZXFJKC(string GS, string time)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            //HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            // string allgs = "";
            //for (int i = 0; i < rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length; i++)
            //{
            //    if (allgs == "")
            //    {
            //        allgs = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
            //    }
            //    else
            //    {
            //        allgs = allgs + "," + rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
            //    }
            //}
            MES_RETURN_UI msg = new MES_RETURN_UI();
            try
            {
                if (GS == "")
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "公司不可为空！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                if (time == "")
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "月份不可为空！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                string YEAR = time.Split('-')[0];
                string MONTH = time.Split('-')[1];

                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    System.IO.File.Delete(savePath);
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("姓名") == false || data1.Columns.Contains("累计子女教育支出") == false || data1.Columns.Contains("累计住房贷款利息支出") == false || data1.Columns.Contains("累计住房租金支出") == false || data1.Columns.Contains("累计赡养老人支出") == false || data1.Columns.Contains("累计继续教育支出") == false || data1.Columns.Contains("累计减除费用") == false || data1.Columns.Contains("累计捐赠") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                data1.Columns.Add("RYID", typeof(int));
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["工号"].ToString().Trim() != "")
                                        {
                                            if (data1.Rows[i]["工号"].ToString().Trim().Length != 5)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")工号格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (data1.Rows[i]["姓名"].ToString().Trim() == "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")姓名格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            HR_RY_RYINFO model = new HR_RY_RYINFO();
                                            model.GH = data1.Rows[i]["工号"].ToString().Trim();
                                            model.YGNAME = data1.Rows[i]["姓名"].ToString().Trim();
                                            HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(model, token);
                                            if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")工号不存在，请检查！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            else
                                            {
                                                data1.Rows[i]["RYID"] = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                                            }
                                            if (Regex.IsMatch(data1.Rows[i]["累计子女教育支出"].ToString().Trim(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["累计子女教育支出"].ToString().Trim() != "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")累计子女教育支出金额异常！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (Regex.IsMatch(data1.Rows[i]["累计住房贷款利息支出"].ToString().Trim(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["累计住房贷款利息支出"].ToString().Trim() != "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")累计住房贷款利息支出金额异常！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (Regex.IsMatch(data1.Rows[i]["累计住房租金支出"].ToString().Trim(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["累计住房租金支出"].ToString().Trim() != "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")累计住房租金支出金额异常！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (Regex.IsMatch(data1.Rows[i]["累计赡养老人支出"].ToString().Trim(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["累计赡养老人支出"].ToString().Trim() != "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")累计赡养老人支出金额异常！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (Regex.IsMatch(data1.Rows[i]["累计继续教育支出"].ToString().Trim(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["累计继续教育支出"].ToString().Trim() != "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")累计继续教育支出金额异常！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (Regex.IsMatch(data1.Rows[i]["累计减除费用"].ToString().Trim(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["累计减除费用"].ToString().Trim() != "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")累计减除费用金额异常！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (Regex.IsMatch(data1.Rows[i]["累计捐赠"].ToString().Trim(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["累计捐赠"].ToString().Trim() != "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "累计费用扣除项第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")累计捐赠金额异常！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }
                    //专项附加扣除
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        if (data1.Rows[i]["工号"].ToString().Trim() != "")
                        {
                            //HR_RY_RYINFO cxmodel = new HR_RY_RYINFO();
                            //cxmodel.GH = data1.Rows[i]["工号"].ToString();
                            //HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(cxmodel, token);

                            HR_XZGL_ZXFJKC model = new HR_XZGL_ZXFJKC();
                            model.RYID = Convert.ToInt32(data1.Rows[i]["RYID"].ToString());
                            model.LJYEAR = YEAR;
                            model.LJMOUTH = MONTH;
                            model.GS = GS;
                            model.LJZNJY = Convert.ToDecimal(data1.Rows[i]["累计子女教育支出"].ToString().Trim() == "" ? -1 : Convert.ToDecimal(data1.Rows[i]["累计子女教育支出"].ToString().Trim()));
                            model.LJFDLX = Convert.ToDecimal(data1.Rows[i]["累计住房贷款利息支出"].ToString().Trim() == "" ? -1 : Convert.ToDecimal(data1.Rows[i]["累计住房贷款利息支出"].ToString().Trim()));
                            model.LJZFZJ = Convert.ToDecimal(data1.Rows[i]["累计住房租金支出"].ToString().Trim() == "" ? -1 : Convert.ToDecimal(data1.Rows[i]["累计住房租金支出"].ToString().Trim()));
                            model.LJSYLR = Convert.ToDecimal(data1.Rows[i]["累计赡养老人支出"].ToString().Trim() == "" ? -1 : Convert.ToDecimal(data1.Rows[i]["累计赡养老人支出"].ToString().Trim()));
                            model.LJJXJY = Convert.ToDecimal(data1.Rows[i]["累计继续教育支出"].ToString().Trim() == "" ? -1 : Convert.ToDecimal(data1.Rows[i]["累计继续教育支出"].ToString().Trim()));
                            model.LJQZD = Convert.ToDecimal(data1.Rows[i]["累计减除费用"].ToString().Trim() == "" ? -1 : Convert.ToDecimal(data1.Rows[i]["累计减除费用"].ToString().Trim()));
                            model.LJDONATION = Convert.ToDecimal(data1.Rows[i]["累计捐赠"].ToString().Trim() == "" ? -1 : Convert.ToDecimal(data1.Rows[i]["累计捐赠"].ToString().Trim()));
                            model.CJR = appclass.CRM_GetStaffid();
                            MES_RETURN_UI result = hrmodels.XZGL_ZXFJKC.INSERT(model, token);
                            if (result.TYPE == "E")
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = "新增累计费用扣除项的第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")出现问题，请记录当前报错信息并联系管理员";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }
                    msg.TYPE = "S";
                    msg.MESSAGE = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.TYPE = "E";
                msg.MESSAGE = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }

        [HttpPost]
        public string Data_DaoChu_ZXFJKC(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                HR_XZGL_ZXFJKC cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_ZXFJKC>(data);
                cxmodel.STAFFID = STAFFID;
                HR_XZGL_ZXFJKC_SELECT result = hrmodels.XZGL_ZXFJKC.SELECT(cxmodel, token);
                if (result.MES_RETURN.TYPE == "E")
                {
                    msg.Msg = "err";
                    msg.Info = "查询数据失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                HR_XZGL_ZXFJKC_LIST[] model = result.HR_XZGL_ZXFJKC_LIST;

                //FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/专项附加扣除导出模板.xlsx", FileMode.Open, FileAccess.Read);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/专项附加扣除导出模板.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("专项附加扣除");
                if (worksheet1 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                    row.CreateCell(0).SetCellValue(model[i].GH);
                    row.CreateCell(1).SetCellValue(model[i].YGNAME);
                    row.CreateCell(2).SetCellValue(model[i].DEPTNAME);
                    row.CreateCell(3).SetCellValue(model[i].ZZTYPENAME);
                    row.CreateCell(4).SetCellValue(model[i].ZZNO);
                    row.CreateCell(5).SetCellValue(model[i].YGTYPENAME);
                    row.CreateCell(6).SetCellValue(Convert.ToDouble(model[i].LJQZD.ToString()));
                    row.CreateCell(7).SetCellValue(Convert.ToDouble(model[i].LJZNJY.ToString()));
                    row.CreateCell(8).SetCellValue(Convert.ToDouble(model[i].LJJXJY.ToString()));
                    row.CreateCell(9).SetCellValue(Convert.ToDouble(model[i].LJFDLX.ToString()));
                    row.CreateCell(10).SetCellValue(Convert.ToDouble(model[i].LJZFZJ.ToString()));
                    row.CreateCell(11).SetCellValue(Convert.ToDouble(model[i].LJSYLR.ToString()));
                    row.CreateCell(12).SetCellValue(Convert.ToDouble(model[i].LJDONATION.ToString()));
                    row.CreateCell(13).SetCellValue(Convert.ToDouble(model[i].LJALL.ToString()));
                    row1++;
                }
                worksheet1.ForceFormulaRecalculation = true;
                string now = cxmodel.LJYEAR + cxmodel.LJMOUTH;
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now;
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }


        }

        public ActionResult Data_DaoChu_ZXFJKC_File(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filename + "-累计费用扣除项.xlsx");
        }


        public DataTable ExcelToDataTable(string fileName, int sheetName, bool isFirstRowColumn)
        {
            FileStream fs = null;
            ISheet sheet = null;
            IWorkbook workbook = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);


                sheet = workbook.GetSheetAt(sheetName);

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是""　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是""
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch
            {
                //MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }

        [HttpPost]
        public string Data_Insert_FLDA(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLDA model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDA>(data);



            //先校验输入的两个基数在不在维护的范围内
            Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX cxmodel = new UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX();
            cxmodel.FLFAID = model.FLFAID;
            cxmodel.MXID = 1;
            HR_XZGL_FLFAMX_SELECT cxdata1 = hrmodels.XZGL_FLFAMX.SELECT(cxmodel, token);
            if (cxdata1.HR_XZGL_FLFAMX.Length == 0)
            {
                MES_RETURN_UI msg = new MES_RETURN_UI();
                msg.TYPE = "E";
                msg.MESSAGE = "没有维护养老保险对应的福利方案明细";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            if (model.SBJS > cxdata1.HR_XZGL_FLFAMX[0].FLMXSX || model.SBJS < cxdata1.HR_XZGL_FLFAMX[0].FLMXXX)
            {
                MES_RETURN_UI msg = new MES_RETURN_UI();
                msg.TYPE = "E";
                msg.MESSAGE = "输入的社保申报基数不在维护的范围内";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            cxmodel.MXID = 2;
            HR_XZGL_FLFAMX_SELECT cxdata2 = hrmodels.XZGL_FLFAMX.SELECT(cxmodel, token);
            if (cxdata2.HR_XZGL_FLFAMX.Length == 0)
            {
                MES_RETURN_UI msg = new MES_RETURN_UI();
                msg.TYPE = "E";
                msg.MESSAGE = "没有维护公积金对应的福利方案明细";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            if (model.GJJJS > cxdata2.HR_XZGL_FLFAMX[0].FLMXSX || model.GJJJS < cxdata2.HR_XZGL_FLFAMX[0].FLMXXX)
            {
                MES_RETURN_UI msg = new MES_RETURN_UI();
                msg.TYPE = "E";
                msg.MESSAGE = "输入的公积金申报基数不在维护的范围内";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            model.CJR = appclass.CRM_GetStaffid();

            MES_RETURN_UI result = hrmodels.XZGL_FLDA.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Update_FLDA(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLDA model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDA>(data);
            model.XGR = appclass.CRM_GetStaffid();
            Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX cxmodel = new UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX();
            cxmodel.FLFAID = model.FLFAID;
            cxmodel.MXID = 1;
            HR_XZGL_FLFAMX_SELECT cxdata1 = hrmodels.XZGL_FLFAMX.SELECT(cxmodel, token);
            if (cxdata1.HR_XZGL_FLFAMX.Length == 0)
            {
                MES_RETURN_UI msg = new MES_RETURN_UI();
                msg.TYPE = "E";
                msg.MESSAGE = "没有维护养老保险对应的福利方案明细";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            if (model.SBJS > cxdata1.HR_XZGL_FLFAMX[0].FLMXSX || model.SBJS < cxdata1.HR_XZGL_FLFAMX[0].FLMXXX)
            {
                MES_RETURN_UI msg = new MES_RETURN_UI();
                msg.TYPE = "E";
                msg.MESSAGE = "输入的社保申报基数不在维护的范围内";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            cxmodel.MXID = 2;
            HR_XZGL_FLFAMX_SELECT cxdata2 = hrmodels.XZGL_FLFAMX.SELECT(cxmodel, token);
            if (cxdata2.HR_XZGL_FLFAMX.Length == 0)
            {
                MES_RETURN_UI msg = new MES_RETURN_UI();
                msg.TYPE = "E";
                msg.MESSAGE = "没有维护公积金对应的福利方案明细";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            if (model.GJJJS > cxdata2.HR_XZGL_FLFAMX[0].FLMXSX || model.GJJJS < cxdata2.HR_XZGL_FLFAMX[0].FLMXXX)
            {
                MES_RETURN_UI msg = new MES_RETURN_UI();
                msg.TYPE = "E";
                msg.MESSAGE = "输入的公积金申报基数不在维护的范围内";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            MES_RETURN_UI result = hrmodels.XZGL_FLDA.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Select_FLDA(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLDA model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDA>(data);
            model.STAFFID = appclass.CRM_GetStaffid();
            HR_XZGL_FLDA_SELECT result = hrmodels.XZGL_FLDA.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Delete_FLDA(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLDA model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDA>(data);
            model.XGR = appclass.CRM_GetStaffid();
            MES_RETURN_UI result = hrmodels.XZGL_FLDA.DELETE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_DaoRu_FLDA(string MYPW)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            string allgs = "";
            for (int i = 0; i < rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length; i++)
            {
                if (allgs == "")
                {
                    allgs = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
                else
                {
                    allgs = allgs + "," + rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
            }
            MES_RETURN_UI msg = new MES_RETURN_UI();
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    string[] sheet = { "员工福利档案" };
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);      //员工福利档案
                    System.IO.File.Delete(savePath);
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("工号") == false || data1.Columns.Contains("姓名") == false || data1.Columns.Contains("社保账号") == false || data1.Columns.Contains("社保卡号") == false || data1.Columns.Contains("社保申报基数") == false || data1.Columns.Contains("社保起始缴纳月") == false || data1.Columns.Contains("社保最后缴纳月") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["工号"].ToString().Length != 5)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行工号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["姓名"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行姓名格为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        HR_RY_RYINFO staff = new HR_RY_RYINFO();
                                        staff.GH = data1.Rows[i]["工号"].ToString();
                                        staff.ALLGS = allgs;
                                        staff.YGNAME = data1.Rows[i]["姓名"].ToString().Trim();
                                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(staff, token);
                                        if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行工号姓名不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (staffdata.HR_RY_RYINFO_LIST[0].YGTYPENAME == "员工三")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行人员类型为员工三，无需录入！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //HR_XZGL_FLDA flda = new HR_XZGL_FLDA();
                                        //flda.RYID = staff.RYID;
                                        //HR_XZGL_FLDA_SELECT fldadata = hrmodels.XZGL_FLDA.SELECT(flda, token);
                                        //if (fldadata.HR_XZGL_FLDA_LIST.Length != 0)
                                        //{
                                        //    msg.Msg = "员工福利档案第" + (i + 2) + "行数据已经存在！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}

                                        HR_XZGL_FLFA flfa = new HR_XZGL_FLFA();
                                        flfa.FANAME = data1.Rows[i]["福利方案"].ToString();
                                        HR_XZGL_FLFA_SELECT flfadata = hrmodels.XZGL_FLFA.SELECT(flfa, token);
                                        if (flfadata.HR_XZGL_FLFA.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行福利方案不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }

                                        if (data1.Rows[i]["是否计算"].ToString() != "是" && data1.Rows[i]["是否计算"].ToString() != "否")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行是否计算格式错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["社保申报基数"].ToString() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行社保申报基数不可为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["公积金申报基数"].ToString() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行公积金申报基数不可为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }

                                        Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX cxmodel = new UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX();
                                        cxmodel.FLFAID = flfadata.HR_XZGL_FLFA[0].FLFAID;
                                        cxmodel.MXID = 1;
                                        HR_XZGL_FLFAMX_SELECT cxdata1 = hrmodels.XZGL_FLFAMX.SELECT(cxmodel, token);
                                        if (cxdata1.HR_XZGL_FLFAMX.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行没有维护养老保险对应的福利方案明细";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Convert.ToDecimal(data1.Rows[i]["社保申报基数"].ToString()) > cxdata1.HR_XZGL_FLFAMX[0].FLMXSX || Convert.ToDecimal(data1.Rows[i]["社保申报基数"].ToString()) < cxdata1.HR_XZGL_FLFAMX[0].FLMXXX)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行社保申报基数不在维护的范围内";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }

                                        cxmodel.MXID = 2;
                                        HR_XZGL_FLFAMX_SELECT cxdata2 = hrmodels.XZGL_FLFAMX.SELECT(cxmodel, token);
                                        if (cxdata2.HR_XZGL_FLFAMX.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行没有维护公积金对应的福利方案明细";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Convert.ToDecimal(data1.Rows[i]["公积金申报基数"].ToString()) > cxdata2.HR_XZGL_FLFAMX[0].FLMXSX || Convert.ToDecimal(data1.Rows[i]["公积金申报基数"].ToString()) < cxdata2.HR_XZGL_FLFAMX[0].FLMXXX)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行公积金申报基数不在维护的范围内";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //if (data1.Rows[i]["社保起始缴纳月"].ToString() == "")
                                        //{
                                        //    msg.TYPE = "E";
                                        //    msg.MESSAGE = "员工福利档案第" + (i + 2) + "行社保起始缴纳月不可为空！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        //if (data1.Rows[i]["公积金起始缴纳月"].ToString() == "")
                                        //{
                                        //    msg.TYPE = "E";
                                        //    msg.MESSAGE = "员工福利档案第" + (i + 2) + "行公积金起始缴纳月不可为空！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}

                                        try
                                        {
                                            DateTime mydate = new DateTime();
                                            if (data1.Rows[i]["社保起始缴纳月"].ToString() != "")
                                                mydate = Convert.ToDateTime(data1.Rows[i]["社保起始缴纳月"].ToString());
                                            if (data1.Rows[i]["社保最后缴纳月"].ToString() != "")
                                                mydate = Convert.ToDateTime(data1.Rows[i]["社保最后缴纳月"].ToString());
                                            if (data1.Rows[i]["公积金起始缴纳月"].ToString() != "")
                                                mydate = Convert.ToDateTime(data1.Rows[i]["公积金起始缴纳月"].ToString());
                                            if (data1.Rows[i]["公积金最后缴纳月"].ToString() != "")
                                                mydate = Convert.ToDateTime(data1.Rows[i]["公积金最后缴纳月"].ToString());
                                        }
                                        catch (Exception e)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = e.Message;
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }


                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }



                        }
                    }
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        HR_RY_RYINFO cxmodel = new HR_RY_RYINFO();
                        cxmodel.GH = data1.Rows[i]["工号"].ToString();
                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(cxmodel, token);
                        HR_XZGL_FLDA model = new HR_XZGL_FLDA();
                        model.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                        HR_XZGL_FLFA flfa = new HR_XZGL_FLFA();
                        flfa.FANAME = data1.Rows[i]["福利方案"].ToString();
                        HR_XZGL_FLFA_SELECT flfadata = hrmodels.XZGL_FLFA.SELECT(flfa, token);
                        model.FLFAID = flfadata.HR_XZGL_FLFA[0].FLFAID;
                        model.ISJS = data1.Rows[i]["是否计算"].ToString() == "是" ? 1 : 0;
                        model.SBJS = Convert.ToDecimal(data1.Rows[i]["社保申报基数"].ToString());
                        model.SBZH = data1.Rows[i]["社保账号"].ToString();
                        model.SBKH = data1.Rows[i]["社保卡号"].ToString();
                        model.GJJNO = data1.Rows[i]["公积金账号"].ToString();
                        model.GJJJS = Convert.ToDecimal(data1.Rows[i]["公积金申报基数"].ToString());


                        //string[] sbtime = Convert.ToDateTime(data1.Rows[i]["社保起始缴纳月"].ToString()).ToString("yyyy-MM").Split('-');
                        //model.SBKSYEAR = sbtime[0];
                        //model.SBKSMOUTH = sbtime[1];
                        if (data1.Rows[i]["社保最后缴纳月"].ToString() != "")
                        {
                            string[] sbtime2 = Convert.ToDateTime(data1.Rows[i]["社保起始缴纳月"].ToString()).ToString("yyyy-MM").Split('-');
                            model.SBKSYEAR = sbtime2[0];
                            model.SBKSMOUTH = sbtime2[1];
                        }
                        else
                        {
                            model.SBKSYEAR = "1900";
                            model.SBKSMOUTH = "01";
                        }

                        if (data1.Rows[i]["社保最后缴纳月"].ToString() != "")
                        {
                            string[] sbtime2 = Convert.ToDateTime(data1.Rows[i]["社保最后缴纳月"].ToString()).ToString("yyyy-MM").Split('-');
                            model.SBJSYEAR = sbtime2[0];
                            model.SBJSMOUTH = sbtime2[1];
                        }
                        else
                        {
                            model.SBJSYEAR = "9999";
                            model.SBJSMOUTH = "12";
                        }

                        //string[] gjjtime = Convert.ToDateTime(data1.Rows[i]["公积金起始缴纳月"].ToString()).ToString("yyyy-MM").Split('-');
                        //model.GJJKSYEAR = gjjtime[0];
                        //model.GJJKSMOUTH = gjjtime[1];

                        if (data1.Rows[i]["公积金起始缴纳月"].ToString() != "")
                        {
                            string[] gjjtime2 = Convert.ToDateTime(data1.Rows[i]["公积金起始缴纳月"].ToString()).ToString("yyyy-MM").Split('-');
                            model.GJJKSYEAR = gjjtime2[0];
                            model.GJJKSMOUTH = gjjtime2[1];
                        }
                        else
                        {
                            model.GJJKSYEAR = "1900";
                            model.GJJKSMOUTH = "01";
                        }

                        if (data1.Rows[i]["公积金最后缴纳月"].ToString() != "")
                        {
                            string[] gjjtime2 = Convert.ToDateTime(data1.Rows[i]["公积金最后缴纳月"].ToString()).ToString("yyyy-MM").Split('-');
                            model.GJJJSYEAR = gjjtime2[0];
                            model.GJJJSMOUTH = gjjtime2[1];
                        }
                        else
                        {
                            model.GJJJSYEAR = "9999";
                            model.GJJJSMOUTH = "12";
                        }
                        model.MYPW = MYPW;
                        MES_RETURN_UI result = hrmodels.XZGL_FLDA.INSERT(model, token);
                        if (result.TYPE == "E")
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "新增员工福利档案的第" + (i + 2) + "行：" + result.MESSAGE;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }

                    msg.TYPE = "S";
                    msg.MESSAGE = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.TYPE = "E";
                msg.MESSAGE = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public string Data_DaoRu_FLDA_JS(string MYPW)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            string allgs = "";
            for (int i = 0; i < rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length; i++)
            {
                if (allgs == "")
                {
                    allgs = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
                else
                {
                    allgs = allgs + "," + rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
            }
            MES_RETURN_UI msg = new MES_RETURN_UI();
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    System.IO.File.Delete(savePath);
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("工号") == false || data1.Columns.Contains("社保申报基数") == false || data1.Columns.Contains("公积金申报基数") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        int FLFAID = 0;
                                        if (data1.Rows[i]["工号"].ToString().Length != 5)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行工号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["姓名"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行姓名格为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        HR_RY_RYINFO staff = new HR_RY_RYINFO();
                                        staff.GH = data1.Rows[i]["工号"].ToString();
                                        staff.ALLGS = allgs;
                                        staff.YGNAME = data1.Rows[i]["姓名"].ToString().Trim();

                                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(staff, token);
                                        if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行工号不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (staffdata.HR_RY_RYINFO_LIST[0].YGTYPENAME == "员工三")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行人员类型为员工三，无需录入！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        HR_XZGL_FLDA flda = new HR_XZGL_FLDA();
                                        flda.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                                        flda.MYPW = MYPW;
                                        flda.STAFFID = STAFFID;
                                        HR_XZGL_FLDA_SELECT fldadata = hrmodels.XZGL_FLDA.SELECT(flda, token);
                                        if (fldadata.HR_XZGL_FLDA_LIST.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "员工福利档案第" + (i + 2) + "行工号 " + data1.Rows[i]["工号"].ToString() + "数据不存在，无法进行基数调整！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        else
                                        {
                                            FLFAID = fldadata.HR_XZGL_FLDA_LIST[0].FLFAID;
                                        }
                                        //if (data1.Rows[i]["社保申报基数"].ToString() == "")
                                        //{
                                        //    msg.TYPE = "E";
                                        //    msg.MESSAGE = "员工福利档案第" + (i + 2) + "行社保申报基数不可为空！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        //if (data1.Rows[i]["公积金申报基数"].ToString() == "")
                                        //{
                                        //    msg.TYPE = "E";
                                        //    msg.MESSAGE = "员工福利档案第" + (i + 2) + "行公积金申报基数不可为空！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}

                                        Sonluk.UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX cxmodel = new UI.Model.HR.XZGL_FLFAMXService.HR_XZGL_FLFAMX();
                                        cxmodel.FLFAID = FLFAID;
                                        cxmodel.MXID = 1;
                                        if (data1.Rows[i]["社保申报基数"].ToString() != "")
                                        {
                                            HR_XZGL_FLFAMX_SELECT cxdata1 = hrmodels.XZGL_FLFAMX.SELECT(cxmodel, token);
                                            if (cxdata1.HR_XZGL_FLFAMX.Length == 0)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "员工福利档案第" + (i + 2) + "行没有维护养老保险对应的福利方案明细";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (Convert.ToDecimal(data1.Rows[i]["社保申报基数"].ToString()) > cxdata1.HR_XZGL_FLFAMX[0].FLMXSX || Convert.ToDecimal(data1.Rows[i]["社保申报基数"].ToString()) < cxdata1.HR_XZGL_FLFAMX[0].FLMXXX)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "员工福利档案第" + (i + 2) + "行社保申报基数不在维护的范围内";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                        cxmodel.MXID = 2;
                                        if (data1.Rows[i]["公积金申报基数"].ToString() != "")
                                        {
                                            HR_XZGL_FLFAMX_SELECT cxdata2 = hrmodels.XZGL_FLFAMX.SELECT(cxmodel, token);
                                            if (cxdata2.HR_XZGL_FLFAMX.Length == 0)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "员工福利档案第" + (i + 2) + "行没有维护公积金对应的福利方案明细";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (Convert.ToDecimal(data1.Rows[i]["公积金申报基数"].ToString()) > cxdata2.HR_XZGL_FLFAMX[0].FLMXSX || Convert.ToDecimal(data1.Rows[i]["公积金申报基数"].ToString()) < cxdata2.HR_XZGL_FLFAMX[0].FLMXXX)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "员工福利档案第" + (i + 2) + "行公积金申报基数不在维护的范围内";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        HR_RY_RYINFO cxmodel = new HR_RY_RYINFO();
                        cxmodel.GH = data1.Rows[i]["工号"].ToString();
                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(cxmodel, token);
                        if (data1.Rows[i]["社保申报基数"].ToString() != "")
                        {
                            HR_XZGL_FLDA model = new HR_XZGL_FLDA();
                            model.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                            model.SBJS = Convert.ToDecimal(data1.Rows[i]["社保申报基数"].ToString());
                            //model.GJJJS = Convert.ToDecimal(data1.Rows[i]["公积金申报基数"].ToString());
                            model.MYPW = MYPW;
                            MES_RETURN_UI result = hrmodels.XZGL_FLDA.UPDATE_LB(model, 3, token);
                            if (result.TYPE == "E")
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = "修改员工福利档案的第" + (i + 2) + "行社保申报基数：" + result.MESSAGE;
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                        if (data1.Rows[i]["公积金申报基数"].ToString() != "")
                        {
                            HR_XZGL_FLDA model = new HR_XZGL_FLDA();
                            model.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                            //model.SBJS = Convert.ToDecimal(data1.Rows[i]["社保申报基数"].ToString());
                            model.GJJJS = Convert.ToDecimal(data1.Rows[i]["公积金申报基数"].ToString());
                            model.MYPW = MYPW;
                            MES_RETURN_UI result = hrmodels.XZGL_FLDA.UPDATE_LB(model, 4, token);
                            if (result.TYPE == "E")
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = "修改员工福利档案的第" + (i + 2) + "行公积金申报基数：" + result.MESSAGE;
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }
                    msg.TYPE = "S";
                    msg.MESSAGE = "修改成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.TYPE = "E";
                msg.MESSAGE = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public string Data_DaoChu_FLDA(string cxdata)
        {
            string token = AppClass.GetSession("token").ToString();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                HR_XZGL_FLDA cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDA>(cxdata);
                cxmodel.STAFFID = appclass.CRM_GetStaffid();
                HR_XZGL_FLDA_SELECT result = hrmodels.XZGL_FLDA.SELECT(cxmodel, token);
                if (result.MES_RETURN.TYPE == "E")
                {
                    msg.Msg = "err";
                    msg.Info = "查询数据失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                HR_XZGL_FLDA_LIST[] model = result.HR_XZGL_FLDA_LIST;
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/员工福利档案导出模板.xlsx", FileMode.Open, FileAccess.Read);
                //FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/员工福利档案导出模板.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("员工福利档案");
                if (worksheet1 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                    row.CreateCell(0).SetCellValue(model[i].GH);
                    row.CreateCell(1).SetCellValue(model[i].YGNAME);
                    row.CreateCell(2).SetCellValue(model[i].GSNAME);
                    row.CreateCell(3).SetCellValue(model[i].DEPTNAME);
                    row.CreateCell(4).SetCellValue(model[i].YGTYPENAME);
                    row.CreateCell(5).SetCellValue(model[i].ZZZTNAME);
                    row.CreateCell(6).SetCellValue(model[i].ZZTYPENAME);
                    row.CreateCell(7).SetCellValue(model[i].ZZNO);
                    row.CreateCell(8).SetCellValue(model[i].FLFANAME);
                    row.CreateCell(9).SetCellValue(model[i].ISJS == 1 ? "是" : "否");
                    row.CreateCell(10).SetCellValue(model[i].SBZH);
                    row.CreateCell(11).SetCellValue(model[i].SBKH);
                    row.CreateCell(12).SetCellValue(model[i].SBJS.ToString());
                    if (model[i].SBKSYEAR != "1900")
                        row.CreateCell(13).SetCellValue(model[i].SBKSYEAR + "-" + model[i].SBKSMOUTH);
                    else
                        row.CreateCell(13).SetCellValue("");
                    if (model[i].SBJSYEAR != "9999")
                        row.CreateCell(14).SetCellValue(model[i].SBJSYEAR + "-" + model[i].SBJSMOUTH);
                    else
                        row.CreateCell(14).SetCellValue("");
                    row.CreateCell(15).SetCellValue(model[i].GJJNO);
                    row.CreateCell(16).SetCellValue(model[i].GJJJS.ToString());
                    if (model[i].GJJKSYEAR != "1900")
                        row.CreateCell(17).SetCellValue(model[i].GJJKSYEAR + "-" + model[i].GJJKSMOUTH);
                    else
                        row.CreateCell(17).SetCellValue("");
                    if (model[i].GJJJSYEAR != "9999")
                        row.CreateCell(18).SetCellValue(model[i].GJJJSYEAR + "-" + model[i].GJJJSMOUTH);
                    else
                        row.CreateCell(18).SetCellValue("");

                    row1++;
                }
                worksheet1.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now;
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }


        public ActionResult Data_DaoChu_FLDA_File(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "员工福利档案.xlsx");
        }

        [HttpPost]
        public string Data_Insert_XZGL_FLDATZ(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLDATZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDATZ>(data);
            model.CJR = appclass.CRM_GetStaffid();
            MES_RETURN_UI result = hrmodels.XZGL_FLDATZ.AUTOINSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string XZGL_FLDATZ_AUTO_ADD_TO_FFJLMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLDATZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDATZ>(datastring);
            MES_RETURN_UI result = hrmodels.XZGL_FLDATZ.AUTO_ADD_TO_FFJLMX(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string Data_SELECT_REPORT_XZGL_FLDATZ(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FLDATZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDATZ>(datastring);
            model.STAFFID = STAFFID;
            HR_XZGL_FLDATZ_SELECT data = hrmodels.XZGL_FLDATZ.SELECT_REPORT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_XZGL_FLDATZ(int FLTZID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLDATZ model = new HR_XZGL_FLDATZ();
            model.FLTZID = FLTZID;
            MES_RETURN_UI result = hrmodels.XZGL_FLDATZ.DELETE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_SELECT_REPORT_XZGL_FLDATZMX(string cxdata)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FLDATZMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDATZMX>(cxdata);
            model.STAFFID = STAFFID;
            HR_XZGL_FLDATZMX_SELECT_REPORT data = hrmodels.XZGL_FLDATZMX.SELECT_REPORT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_XZGL_FLDATZMX(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLDATZMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDATZMX>(data);
            HR_XZGL_FLDATZMX_SELECT result = hrmodels.XZGL_FLDATZMX.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Update_XZGL_FLDATZMX(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FLDATZMX[] updatemodel = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDATZMX[]>(data);
            for (int i = 0; i < updatemodel.Length; i++)
            {
                HR_XZGL_FLDATZMX model = new HR_XZGL_FLDATZMX();
                model.FLTZMXID = updatemodel[i].FLTZMXID;
                model.FLGRJE = Convert.ToDecimal(updatemodel[i].FLGRJE);
                model.FLDWJE = Convert.ToDecimal(updatemodel[i].FLDWJE);
                model.XGR = appclass.CRM_GetStaffid();
                model.MYPW = updatemodel[i].MYPW;
                MES_RETURN_UI result = hrmodels.XZGL_FLDATZMX.UPDATE(model, token);
                if (result.TYPE != "S")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(result);
                }
            }
            MES_RETURN_UI res = new MES_RETURN_UI();
            res.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }

        [HttpPost]
        public string Data_DaoChu_FLDATZ(string cxdata)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                HR_XZGL_FLDATZMX MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FLDATZMX>(cxdata);
                MXmodel.STAFFID = STAFFID;
                HR_XZGL_FLDATZMX_SELECT_REPORT MXresult = hrmodels.XZGL_FLDATZMX.SELECT_REPORT(MXmodel, token);
                HR_XZGL_FLDATZ TTmodel = new HR_XZGL_FLDATZ();
                TTmodel.MYPW = MXmodel.MYPW;
                HR_XZGL_FLDATZ_SELECT TTresult = hrmodels.XZGL_FLDATZ.SELECT_REPORT(TTmodel, token);
                if (MXresult.MES_RETURN.TYPE == "E" || TTresult.MES_RETURN.TYPE == "E")
                {
                    msg.Msg = "err";
                    msg.Info = "查询数据失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                HR_XZGL_FLDATZ_LIST[] TTdata = TTresult.HR_XZGL_FLDATZ_LIST;
                HR_XZGL_FLDATZMX_LIST_REPORT[] MXdata = MXresult.HR_XZGL_FLDATZMX_LIST_REPORT;
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,部门,员工类别,证照类型,证照号码,福利方案,社保基数,公积金基数,养老个人,医保个人,失业个人,个人社保合计,公积金个人,个人公积金合计,个人福利合计,养老单位,医保单位,失业单位,生育单位,工伤单位,单位社保合计,公积金单位,单位公积金合计,单位福利合计,总计福利";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(a).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < MXdata.Length; i++)
                {
                    int ccount = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(ccount++).SetCellValue(MXdata[i].GH);
                    row.CreateCell(ccount++).SetCellValue(MXdata[i].YGNAME);
                    row.CreateCell(ccount++).SetCellValue(MXdata[i].DEPTNAME);
                    row.CreateCell(ccount++).SetCellValue(MXdata[i].YGTYPENAME);
                    row.CreateCell(ccount++).SetCellValue(MXdata[i].ZZTYPENAME);
                    row.CreateCell(ccount++).SetCellValue(MXdata[i].ZZNO);
                    row.CreateCell(ccount++).SetCellValue(MXdata[i].FANAME);
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].SBJS));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].GJJJS));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].GR_SB));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].GR_YB));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].GR_SY));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].GR_SBHJ));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].GR_GJJ));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].GR_GJJ));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].GR_ALL));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].DW_SB));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].DW_YB));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].DW_SY));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].DW_SHENGYU));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].DW_GONGSHANG));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].DW_SBHJ));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].DW_GJJ));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].DW_GJJ));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].DW_ALL));
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(MXdata[i].ALL));
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss") + "员工福利档案";
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now;
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        public ActionResult EXPORT_READ_XZGL_FLDATZMX(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "福利台账明细导出.xlsx");
        }

        [HttpPost]
        public string Data_Insert_XZGL_KKGL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_KKGL model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_KKGL>(data);
            model.CJR = appclass.CRM_GetStaffid();
            MES_RETURN_UI result = hrmodels.XZGL_KKGL.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Select_XZGL_KKGL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_KKGL model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_KKGL>(data);
            HR_XZGL_KKGL_SELECT result = hrmodels.XZGL_KKGL.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Delete_XZGL_KKGL(int KKID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_KKGL model = new HR_XZGL_KKGL();
            model.KKID = KKID;
            model.XGR = appclass.CRM_GetStaffid();
            MES_RETURN_UI result = hrmodels.XZGL_KKGL.DELETE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string Data_Update_XZGL_KKGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_KKGL model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_KKGL>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.XZGL_KKGL.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Select_XZGL_KKGLMX(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_KKGLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_KKGLMX>(data);
            HR_XZGL_KKGLMX_SELECT result = hrmodels.XZGL_KKGLMX.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Update_XZGL_KKGLMX(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_KKGLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_KKGLMX>(data);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.XZGL_KKGLMX.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Delete_XZGL_KKGLMX(int KKMXID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_KKGLMX model = new HR_XZGL_KKGLMX();
            model.KKMXID = KKMXID;
            model.XGR = appclass.CRM_GetStaffid();
            MES_RETURN_UI result = hrmodels.XZGL_KKGLMX.DELETE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string Data_Insert_XZGL_KKGLMX(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_KKGLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_KKGLMX>(data);
            model.CJR = STAFFID;
            MES_RETURN_UI result = hrmodels.XZGL_KKGLMX.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string XZGL_KKGLMX_AUTO_ADD_TO_FFJLMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_KKGLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_KKGLMX>(datastring);
            MES_RETURN_UI result = hrmodels.XZGL_KKGLMX.AUTO_ADD_TO_FFJLMX(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }











        [HttpPost]
        public string XZGL_FFJLZD_FORMULA_VERIFY(string gsinfo)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.XZGL_FFJLZD.GS_FORMULA_VERIFY(gsinfo, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string XZGL_FFJLZD_SELECT_YYTABLE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLZD_YYTABLE model_HR_XZGL_FFJLZD_YYTABLE = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLZD_YYTABLE>(datastring);
            HR_XZGL_FFJLZD_YYTABLE_SELECT rst = hrmodels.XZGL_FFJLZD.SELECT_YYTABLE(model_HR_XZGL_FFJLZD_YYTABLE, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLZD_SELECT_YYTABLEZD(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLZD_YYTABLEZD model_HR_XZGL_FFJLZD_YYTABLEZD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLZD_YYTABLEZD>(datastring);
            HR_XZGL_FFJLZD_YYTABLEZD_SELECT rst = hrmodels.XZGL_FFJLZD.SELECT_YYTABLEZD(model_HR_XZGL_FFJLZD_YYTABLEZD, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_MBGL_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_MBGL model_HR_XZGL_MBGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGL>(datastring);
            model_HR_XZGL_MBGL.STAFFID = STAFFID;
            HR_XZGL_MBGL_SELECT rst = hrmodels.XZGL_MBGL.SELECT(model_HR_XZGL_MBGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_MBGL_SELECT_YYCOUNT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_MBGL model_HR_XZGL_MBGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGL>(datastring);
            model_HR_XZGL_MBGL.STAFFID = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_MBGL.SELECT_YYCOUNT(model_HR_XZGL_MBGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_MBGL_INSERT(string datastring, string datastring1)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_MBGL model_HR_XZGL_MBGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGL>(datastring);
            HR_XZGL_MBGLMX[] model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX[]>(datastring1);
            model_HR_XZGL_MBGL.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_MBGL.INSERT(model_HR_XZGL_MBGL, token);
            if (rst.TYPE == "S")
            {
                for (int a = 0; a < model_HR_XZGL_MBGLMX.Length; a++)
                {
                    model_HR_XZGL_MBGLMX[a].MBID = rst.TID;
                    hrmodels.XZGL_MBGLMX.INSERT(model_HR_XZGL_MBGLMX[a], token);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string XZGL_MBGL_UPDATE(string datastring, string datastring1, string datastring2, string datastring3)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_MBGL model_HR_XZGL_MBGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGL>(datastring);
            HR_XZGL_MBGLMX[] model_HR_XZGL_MBGLMX1 = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX[]>(datastring1);
            HR_XZGL_MBGLMX[] model_HR_XZGL_MBGLMX2 = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX[]>(datastring2);
            HR_XZGL_MBGLMX[] model_HR_XZGL_MBGLMX3 = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX[]>(datastring3);
            model_HR_XZGL_MBGL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_MBGL.UPDATE(model_HR_XZGL_MBGL, 2, token);
            if (rst.TYPE == "S")
            {
                //HR_XZGL_MBGLMX model_HR_XZGL_MBGLMXdelete = new HR_XZGL_MBGLMX();
                //model_HR_XZGL_MBGLMXdelete.MBID = model_HR_XZGL_MBGL.MBID;
                //hrmodels.XZGL_MBGLMX.UPDATE(model_HR_XZGL_MBGLMXdelete, 1, token);
                //for (int a = 0; a < model_HR_XZGL_MBGLMX.Length; a++)
                //{
                //    model_HR_XZGL_MBGLMX[a].MBID = model_HR_XZGL_MBGL.MBID;
                //    hrmodels.XZGL_MBGLMX.INSERT(model_HR_XZGL_MBGLMX[a], token);
                //}
                for (int a = 0; a < model_HR_XZGL_MBGLMX1.Length; a++)
                {
                    model_HR_XZGL_MBGLMX1[a].MBID = model_HR_XZGL_MBGL.MBID;
                    hrmodels.XZGL_MBGLMX.INSERT(model_HR_XZGL_MBGLMX1[a], token);
                }
                for (int a = 0; a < model_HR_XZGL_MBGLMX2.Length; a++)
                {
                    hrmodels.XZGL_MBGLMX.UPDATE(model_HR_XZGL_MBGLMX2[a], 3, token);
                }
                for (int a = 0; a < model_HR_XZGL_MBGLMX3.Length; a++)
                {
                    hrmodels.XZGL_MBGLMX.UPDATE(model_HR_XZGL_MBGLMX3[a], 1, token);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_MBGL_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_MBGL model_HR_XZGL_MBGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGL>(datastring);
            model_HR_XZGL_MBGL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_MBGL.UPDATE(model_HR_XZGL_MBGL, 1, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_MBGLMX_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX>(datastring);
            HR_XZGL_MBGLMX_SELECT rst = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_MBGLMX_SELECT_LAY(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX>(datastring);
            HR_XZGL_MBGLMX_SELECT rst = hrmodels.XZGL_MBGLMX.SELECT_LAY(model_HR_XZGL_MBGLMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_MBGLMX_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_MBGLMX.UPDATE(model_HR_XZGL_MBGLMX, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJL_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJL model_HR_XZGL_FFJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJL>(datastring);
            model_HR_XZGL_FFJL.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_FFJL.INSERT(model_HR_XZGL_FFJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJL_SELECT(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJL model_HR_XZGL_FFJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJL>(datastring);
            model_HR_XZGL_FFJL.STAFFID = STAFFID;
            HR_XZGL_FFJL_SELECT rst = hrmodels.XZGL_FFJL.SELECT(model_HR_XZGL_FFJL, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJL_UPDATE(string datastring, int LB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                string token = AppClass.GetSession("token").ToString();
                int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                HR_XZGL_FFJL model_HR_XZGL_FFJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJL>(datastring);
                model_HR_XZGL_FFJL.STAFFID = STAFFID;
                rst = hrmodels.XZGL_FFJL.UPDATE(model_HR_XZGL_FFJL, LB, token);
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.ToString();
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLMX_SELECT(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            HR_XZGL_FFJLMX_SELECT rst = hrmodels.XZGL_FFJLMX.SELECT(model_HR_XZGL_FFJLMX, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLMX_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLMX_INSERT(string datastring, string datastring2)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.RYLIST.TableName = "RYLIST";
            MES_RETURN_UI rst = hrmodels.XZGL_FFJLMX.INSERT(model_HR_XZGL_FFJLMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLMX_SELECT_GUOSREPORT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst = hrmodels.XZGL_FFJLMX.SELECT_GUOSHUIREPORT(model_HR_XZGL_FFJLMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        //[HttpPost]
        //public string XZGL_FFJLMX_INSERT_LIST(string datastring)
        //{
        //    string token = AppClass.GetSession("token").ToString();
        //    HR_XZGL_FFJLMX[] model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX[]>(datastring);
        //    MES_RETURN_UI rst = new MES_RETURN_UI();
        //    for (int a = 0; a < model_HR_XZGL_FFJLMX.Length; a++)
        //    {
        //        MES_RETURN_UI rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.INSERT(model_HR_XZGL_FFJLMX[a], token);
        //        if (rst_MES_RETURN_UI.TYPE == "E")
        //        {

        //        }
        //    }
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        //}
        [HttpPost]
        public string XZGL_FFJLMX_FORMULA_JS(string datastring, int LB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                string token = AppClass.GetSession("token").ToString();
                HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
                rst = hrmodels.XZGL_FFJLMX.FORMULA_JS(model_HR_XZGL_FFJLMX, LB, token);
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.ToString();
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLMX_AUTO_ADD_TO_FFJLMX_OTHER(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_FFJLMX.AUTO_ADD_TO_FFJLMX_OTHER(model_HR_XZGL_FFJLMX, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLMX_SELECT_GSREPORT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst = hrmodels.XZGL_FFJLMX.SELECT_GSREPORT(model_HR_XZGL_FFJLMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLMX_SELECT_FFMXREPORT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst = hrmodels.XZGL_FFJLMX.SELECT_FFMXREPORT(model_HR_XZGL_FFJLMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLMX_SELECT_GZXJSDREPORT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst = hrmodels.XZGL_FFJLMX.SELECT_GZXJSDREPORT(model_HR_XZGL_FFJLMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJLMX_SELECT_FFMXGZDREPORT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst = hrmodels.XZGL_FFJLMX.SELECT_FFMXGZDREPORT(model_HR_XZGL_FFJLMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_FFJLID(int FFJLID)
        {
            AppClass.SetSession("FFJLID", FFJLID.ToString());
            MES_RETURN_UI rst = new MES_RETURN_UI();
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_JJFLINFO(int JJFLID, int ISACTION)
        {
            AppClass.SetSession("JJFLID", JJFLID.ToString());
            AppClass.SetSession("ISACTION", ISACTION.ToString());
            MES_RETURN_UI rst = new MES_RETURN_UI();
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPORT_GZMB(int MBID)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                string token = AppClass.GetSession("token").ToString();
                HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = new HR_XZGL_MBGLMX();
                model_HR_XZGL_MBGLMX.MBID = MBID;
                HR_XZGL_MBGLMX_SELECT rst_HR_XZGL_MBGLMX_SELECT = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
                if (rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN.TYPE == "S")
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length > 0)
                    {
                        FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/工资导入模版.xls", FileMode.Open, FileAccess.Read);
                        IWorkbook workbook = new HSSFWorkbook(file);
                        ISheet sheet = workbook.GetSheetAt(0);
                        int rowcount = 0;
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue("工号");
                        row.CreateCell(cellIndex++).SetCellValue("姓名");
                        for (int a = 0; a < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; a++)
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].ISHAVEGS == 0 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].MXID == 1 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].ISGDZD == 0)
                            {
                                row.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].FFJLZDMS);
                            }
                        }
                        string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                        FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                        workbook.Write(file1);
                        file1.Close();
                        rst.TYPE = "S";
                        rst.MESSAGE = now;
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "模版字段为空！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    }
                }
                else
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN);
                }
            }
            catch (Exception)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生产文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPORT_FFJL_TZ_MB()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                string token = AppClass.GetSession("token").ToString();
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                int cellIndex = 0;
                IRow row = sheet.CreateRow(rowcount++);
                row.CreateCell(cellIndex++).SetCellValue("工号");
                row.CreateCell(cellIndex++).SetCellValue("姓名");
                row.CreateCell(cellIndex++).SetCellValue("含税金额");
                row.CreateCell(cellIndex++).SetCellValue("不含税金额");
                row.CreateCell(cellIndex++).SetCellValue("个税个人");
                row.CreateCell(cellIndex++).SetCellValue("个税单位");
                row.CreateCell(cellIndex++).SetCellValue("应补个人");
                row.CreateCell(cellIndex++).SetCellValue("应补单位");
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch (Exception)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生产文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public ActionResult EXPORT_READ_GZMB(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "导入模版.xls");
        }
        [HttpPost]
        public string INPORT_READ_GZMB(int MBID, int FFJLID, string MYPW, int GSLB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            //string allgs = "";
            //for (int i = 0; i < rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length; i++)
            //{
            //    if (allgs == "")
            //    {
            //        allgs = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
            //    }
            //    else
            //    {
            //        allgs = allgs + "," + rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
            //    }
            //}
            //DaoRuMsg msg = new DaoRuMsg();
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    System.IO.File.Delete(savePath);
                    if (data1 != null)
                    {
                        data1.Columns.Add("RYID", typeof(int));
                        DataTable dt_RYINFOLIST = new DataTable();
                        dt_RYINFOLIST.Columns.Add("XH", typeof(int));
                        dt_RYINFOLIST.Columns.Add("GH", typeof(string));
                        dt_RYINFOLIST.Columns.Add("YGNAME", typeof(string));
                        HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = new HR_XZGL_MBGLMX();
                        model_HR_XZGL_MBGLMX.MBID = MBID;
                        HR_XZGL_MBGLMX_SELECT rst_HR_XZGL_MBGLMX_SELECT = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
                        if (rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN.TYPE == "S")
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length > 0)
                            {
                                if (data1.Columns.Contains("工号") == false)
                                {
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "工号字段不存在，请检查模版！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                if (data1.Columns.Contains("姓名") == false)
                                {
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "姓名字段不存在，请检查模版！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                for (int a = 0; a < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; a++)
                                {
                                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].ISHAVEGS == 0 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].MXID == 1 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].ISGDZD == 0)
                                    {
                                        if (data1.Columns.Contains(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].FFJLZDMS) == false)
                                        {
                                            rst.TYPE = "E";
                                            rst.MESSAGE = rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].FFJLZDMS + "字段不存在，请检查模版！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                        }
                                    }
                                }
                                for (int a = 0; a < data1.Rows.Count; a++)
                                {
                                    if (data1.Rows[a]["工号"].ToString().Trim() != "")
                                    {
                                        if (data1.Rows[a]["工号"].ToString().Length != 5)
                                        {
                                            rst.TYPE = "E";
                                            rst.MESSAGE = "第" + (a + 2) + "行工号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                        }
                                        if (data1.Rows[a]["姓名"].ToString().Trim() == "")
                                        {
                                            rst.TYPE = "E";
                                            rst.MESSAGE = "第" + (a + 2) + "行姓名格为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                        }
                                        DataRow dt_RYINFOLIST_row = dt_RYINFOLIST.NewRow();
                                        dt_RYINFOLIST_row[0] = a;
                                        dt_RYINFOLIST_row[1] = data1.Rows[a]["工号"].ToString().Trim().Replace(" ", "");
                                        dt_RYINFOLIST_row[2] = data1.Rows[a]["姓名"].ToString().Trim().Replace(" ", "");
                                        dt_RYINFOLIST.Rows.Add(dt_RYINFOLIST_row);
                                        //HR_RY_RYINFO model_HR_RY_RYINFO = new HR_RY_RYINFO();
                                        //model_HR_RY_RYINFO.GH = data1.Rows[a]["工号"].ToString();
                                        //model_HR_RY_RYINFO.YGNAME = data1.Rows[a]["姓名"].ToString().Trim();
                                        //HR_RY_RYINFO_SELECT rst_HR_RY_RYINFO_SELECT = hrmodels.RY_RYINFO.SELECT(model_HR_RY_RYINFO, token);
                                        //if (rst_HR_RY_RYINFO_SELECT.MES_RETURN.TYPE == "S")
                                        //{
                                        //    if (rst_HR_RY_RYINFO_SELECT.HR_RY_RYINFO_LIST.Length == 0)
                                        //    {
                                        //        rst.TYPE = "E";
                                        //        rst.MESSAGE = "第" + (a + 1) + "行工号 " + data1.Rows[a]["工号"].ToString() + "不存在，请检查！";
                                        //        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                        //    }
                                        //    else
                                        //    {
                                        //        if (rst_HR_RY_RYINFO_SELECT.HR_RY_RYINFO_LIST[0].NSRSF == 0)
                                        //        {
                                        //            rst.TYPE = "E";
                                        //            rst.MESSAGE = "第" + (a + 1) + "行工号 " + data1.Rows[a]["工号"].ToString() + "的纳税人身份不存在，请检查！";
                                        //            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                        //        }
                                        //        else
                                        //        {
                                        //            data1.Rows[a]["RYID"] = rst_HR_RY_RYINFO_SELECT.HR_RY_RYINFO_LIST[0].RYID;
                                        //        }
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN);
                                        //}

                                        for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                                        {
                                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].ISHAVEGS == 0 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].ISGDZD == 0)
                                            {
                                                if (data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString() != "")
                                                {
                                                    try
                                                    {
                                                        Convert.ToDecimal(data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString());
                                                    }
                                                    catch (Exception)
                                                    {
                                                        rst.TYPE = "E";
                                                        rst.MESSAGE = "第" + (a + 1) + "行 " + data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString() + " 不是数字或空，请检查！";
                                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                                    }
                                                }
                                            }
                                        }
                                        //if (GSLB == 56)
                                        //{
                                        //    HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                        //    model_HR_XZGL_FFJLMX.FFJLID = FFJLID;
                                        //    model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                        //    HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT(model_HR_XZGL_FFJLMX, 3, token);
                                        //    if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "S")
                                        //    {
                                        //        if (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count > 0)
                                        //        {
                                        //            rst.TYPE = "E";
                                        //            rst.MESSAGE = "第" + (a + 1) + "行工号 " + data1.Rows[a]["工号"].ToString() + "的全年一次性已经添加，不允许重复，请检查！";
                                        //            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
                                        //    }
                                        //}
                                    }
                                }
                                HR_RY_RYINFO model_HR_RY_RYINFO = new HR_RY_RYINFO();
                                dt_RYINFOLIST.TableName = "RYINFOLIST";
                                model_HR_RY_RYINFO.RYINFOLIST = dt_RYINFOLIST;
                                HR_RY_RYINFO_SELECT rst_HR_RY_RYINFO_SELECT = hrmodels.RY_RYINFO.SELECT_LB(model_HR_RY_RYINFO, 2, token);
                                if (rst_HR_RY_RYINFO_SELECT.MES_RETURN.TYPE == "E")
                                {
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_RY_RYINFO_SELECT.MES_RETURN);
                                }
                                DataTable rylist = rst_HR_RY_RYINFO_SELECT.DATALIST;
                                DataRow[] dr1 = rylist.Select("RYID=0");
                                if (dr1.Length > 0)
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "第" + (Convert.ToInt32(dr1[0]["XH"].ToString()) + 1) + "行工号 " + dr1[0]["GH"].ToString() + "不存在，请检查！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                DataRow[] dr2 = rylist.Select("NSRSF=0");
                                if (dr2.Length > 0)
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "第" + (Convert.ToInt32(dr2[0]["XH"].ToString()) + 1) + "行工号 " + dr2[0]["GH"].ToString() + "的纳税人身份不存在，请检查！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }

                                if (GSLB == 56)
                                {
                                    for (int a = 0; a < rylist.Rows.Count; a++)
                                    {
                                        HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                        model_HR_XZGL_FFJLMX.FFJLID = FFJLID;
                                        model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                        model_HR_XZGL_FFJLMX.RYID = Convert.ToInt32(rylist.Rows[a]["RYID"].ToString());
                                        HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT(model_HR_XZGL_FFJLMX, 3, token);
                                        if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "S")
                                        {
                                            if (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count > 0)
                                            {
                                                rst.TYPE = "E";
                                                rst.MESSAGE = "第" + (Convert.ToInt32(rylist.Rows[a]["XH"].ToString()) + 1) + "行工号 " + rylist.Rows[a]["GH"].ToString() + "的全年一次性已经添加，不允许重复，请检查！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                            }
                                        }
                                        else
                                        {
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
                                        }
                                    }
                                }

                                for (int a = 0; a < rylist.Rows.Count; a++)
                                {
                                    data1.Rows[Convert.ToInt32(rylist.Rows[a]["XH"].ToString())]["RYID"] = Convert.ToInt32(rylist.Rows[a]["RYID"].ToString());
                                }
                            }
                            else
                            {
                                rst.TYPE = "E";
                                rst.MESSAGE = "模版字段为空！";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                            }
                        }
                        else
                        {
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN);
                        }
                        DataTable dt_rylist = new DataTable();
                        dt_rylist.Columns.Add("RYID", typeof(int));
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["工号"].ToString().Trim() != "")
                            {
                                DataRow dr = dt_rylist.NewRow();
                                dr[0] = Convert.ToInt32(data1.Rows[a]["RYID"].ToString());
                                dt_rylist.Rows.Add(dr);
                            }
                        }
                        HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX_insert = new HR_XZGL_FFJLMX();
                        model_HR_XZGL_FFJLMX_insert.RYLIST = dt_rylist;
                        model_HR_XZGL_FFJLMX_insert.RYLIST.TableName = "RYLIST";
                        model_HR_XZGL_FFJLMX_insert.FFJLID = FFJLID;
                        model_HR_XZGL_FFJLMX_insert.MYPW = MYPW;
                        MES_RETURN_UI rst_MES_RETURN_UI_insert = new MES_RETURN_UI();
                        rst_MES_RETURN_UI_insert = hrmodels.XZGL_FFJLMX.INSERT(model_HR_XZGL_FFJLMX_insert, token);
                        if (rst_MES_RETURN_UI_insert.TYPE == "E")
                        {
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_insert);
                        }
                        DataTable FFJLMXLIST = new DataTable();
                        FFJLMXLIST.Columns.Add("RYID", typeof(int));
                        FFJLMXLIST.Columns.Add("FFJLID", typeof(int));
                        FFJLMXLIST.Columns.Add("FFJLMXID", typeof(int));
                        FFJLMXLIST.Columns.Add("FFJLZDNAME", typeof(string));
                        FFJLMXLIST.Columns.Add("ZDVALUE", typeof(decimal));
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["工号"].ToString().Trim() != "")
                            {
                                //MES_RETURN_UI rst_MES_RETURN_UI = new MES_RETURN_UI();
                                //HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                //model_HR_XZGL_FFJLMX.RYID = Convert.ToInt32(data1.Rows[a]["RYID"].ToString());
                                //model_HR_XZGL_FFJLMX.FFJLID = FFJLID;
                                //model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                //HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT(model_HR_XZGL_FFJLMX, 1, token);
                                //if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
                                //{
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
                                //}
                                //int FFJLMXID = 0;
                                //if (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count == 0)
                                //{
                                //    //DataTable dt_ffjlmx = new DataTable();
                                //    //dt_ffjlmx.Columns.Add("RYID", typeof(int));
                                //    //DataRow dr = dt_ffjlmx.NewRow();
                                //    //dr[0] = Convert.ToInt32(data1.Rows[a]["RYID"].ToString());
                                //    //dt_ffjlmx.Rows.Add(dr);
                                //    //rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.INSERT(model_HR_XZGL_FFJLMX, token);
                                //    //if (rst_MES_RETURN_UI.TYPE == "E")
                                //    //{
                                //    //    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                                //    //}
                                //    //else
                                //    //{
                                //    //    FFJLMXID = rst_MES_RETURN_UI.TID;
                                //    //}
                                //    FFJLMXID = 0;
                                //}
                                //else
                                //{
                                //    FFJLMXID = Convert.ToInt32(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[0]["FFJLMXID"].ToString());
                                //}
                                //if (FFJLMXID > 0)
                                //{
                                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                                {
                                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].ISHAVEGS == 0 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].ISGDZD == 0)
                                    {
                                        if (data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString() != "")
                                        {
                                            //model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                            //model_HR_XZGL_FFJLMX.FFJLMXID = FFJLMXID;
                                            //model_HR_XZGL_FFJLMX.FFJLZDNAME = rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME;
                                            //model_HR_XZGL_FFJLMX.ZDVALUE = Convert.ToDecimal(data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString());
                                            //model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                            //rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX, 2, token);
                                            //if (rst_MES_RETURN_UI.TYPE == "E")
                                            //{
                                            //    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                                            //}
                                            DataRow dr_FFJLMXLIST = FFJLMXLIST.NewRow();
                                            dr_FFJLMXLIST[0] = Convert.ToInt32(data1.Rows[a]["RYID"].ToString()); ;
                                            dr_FFJLMXLIST[1] = FFJLID;
                                            //dr_FFJLMXLIST[2] = FFJLMXID;
                                            dr_FFJLMXLIST[3] = rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME;
                                            dr_FFJLMXLIST[4] = Convert.ToDecimal(data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString());
                                            FFJLMXLIST.Rows.Add(dr_FFJLMXLIST);
                                        }
                                    }
                                }
                                //}
                            }
                        }
                        HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX_2 = new HR_XZGL_FFJLMX();
                        model_HR_XZGL_FFJLMX_2.MYPW = MYPW;
                        FFJLMXLIST.TableName = "FFJLMXLIST";
                        model_HR_XZGL_FFJLMX_2.FFJLMXLIST = FFJLMXLIST;
                        MES_RETURN_UI rst_MES_RETURN_UI_2 = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX_2, 4, token);
                        if (rst_MES_RETURN_UI_2.TYPE == "E")
                        {
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_2);
                        }
                        rst.TYPE = "S";
                        rst.MESSAGE = "";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    }
                    rst.TYPE = "E";
                    rst.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
        }
        [HttpPost]
        public string INPORT_READ_GZMB_JY(int MBID, int FFJLID, string MYPW, int GSLB, string GS)
        {
            List<MES_RETURN_UI> rst_MES_RETURN_UI_list = new List<MES_RETURN_UI>();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    System.IO.File.Delete(savePath);
                    if (data1 != null)
                    {
                        data1.Columns.Add("RYID", typeof(int));
                        DataTable dt_RYINFOLIST = new DataTable();
                        dt_RYINFOLIST.Columns.Add("XH", typeof(int));
                        dt_RYINFOLIST.Columns.Add("GH", typeof(string));
                        dt_RYINFOLIST.Columns.Add("YGNAME", typeof(string));
                        HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = new HR_XZGL_MBGLMX();
                        model_HR_XZGL_MBGLMX.MBID = MBID;
                        HR_XZGL_MBGLMX_SELECT rst_HR_XZGL_MBGLMX_SELECT = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
                        int errorcount = 0;
                        if (rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN.TYPE == "S")
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length > 0)
                            {
                                if (data1.Columns.Contains("工号") == false)
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "工号字段不存在，请检查模版！";
                                    rst_MES_RETURN_UI_list = new List<MES_RETURN_UI>();
                                    rst_MES_RETURN_UI_list.Add(rst);
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                }
                                if (data1.Columns.Contains("姓名") == false)
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "姓名字段不存在，请检查模版！";
                                    rst_MES_RETURN_UI_list = new List<MES_RETURN_UI>();
                                    rst_MES_RETURN_UI_list.Add(rst);
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                }
                                for (int a = 0; a < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; a++)
                                {
                                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].ISHAVEGS == 0 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].MXID == 1 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].ISGDZD == 0)
                                    {
                                        if (data1.Columns.Contains(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].FFJLZDMS) == false)
                                        {
                                            rst = new MES_RETURN_UI();
                                            rst.TYPE = "E";
                                            rst.MESSAGE = rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].FFJLZDMS + "字段不存在，请检查模版！";
                                            rst_MES_RETURN_UI_list = new List<MES_RETURN_UI>();
                                            rst_MES_RETURN_UI_list.Add(rst);
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                        }
                                    }
                                }
                                rst_MES_RETURN_UI_list = new List<MES_RETURN_UI>();

                                for (int a = 0; a < data1.Rows.Count; a++)
                                {
                                    if (data1.Rows[a]["工号"].ToString().Trim() != "")
                                    {
                                        if (data1.Rows[a]["工号"].ToString().Trim().Length != 5)
                                        {
                                            rst = new MES_RETURN_UI();
                                            rst.TYPE = "E";
                                            rst.MESSAGE = "第" + (a + 2) + "行工号格式不正确！";
                                            rst_MES_RETURN_UI_list.Add(rst);
                                            errorcount = errorcount + 1;
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                        }
                                        if (data1.Rows[a]["姓名"].ToString().Trim() == "")
                                        {
                                            rst = new MES_RETURN_UI();
                                            rst.TYPE = "E";
                                            rst.MESSAGE = "第" + (a + 2) + "行姓名格为空！";
                                            rst_MES_RETURN_UI_list.Add(rst);
                                            errorcount = errorcount + 1;
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                        }
                                        DataRow dt_RYINFOLIST_row = dt_RYINFOLIST.NewRow();
                                        dt_RYINFOLIST_row[0] = a;
                                        dt_RYINFOLIST_row[1] = data1.Rows[a]["工号"].ToString().Trim().Replace(" ", "");
                                        dt_RYINFOLIST_row[2] = data1.Rows[a]["姓名"].ToString().Trim().Replace(" ", "");
                                        dt_RYINFOLIST.Rows.Add(dt_RYINFOLIST_row);
                                        for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                                        {
                                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].ISHAVEGS == 0 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].ISGDZD == 0)
                                            {
                                                if (data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString() != "")
                                                {
                                                    try
                                                    {
                                                        Convert.ToDecimal(data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString());
                                                    }
                                                    catch (Exception)
                                                    {
                                                        rst = new MES_RETURN_UI();
                                                        rst.TYPE = "E";
                                                        rst.MESSAGE = "第" + (a + 1) + "行 " + data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString() + " 不是数字或空，请检查！";
                                                        rst_MES_RETURN_UI_list.Add(rst);
                                                        errorcount = errorcount + 1;
                                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (errorcount > 0)
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }

                                HR_RY_RYINFO model_HR_RY_RYINFO = new HR_RY_RYINFO();
                                dt_RYINFOLIST.TableName = "RYINFOLIST";
                                model_HR_RY_RYINFO.RYINFOLIST = dt_RYINFOLIST;
                                HR_RY_RYINFO_SELECT rst_HR_RY_RYINFO_SELECT = hrmodels.RY_RYINFO.SELECT_LB(model_HR_RY_RYINFO, 2, token);
                                if (rst_HR_RY_RYINFO_SELECT.MES_RETURN.TYPE == "E")
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "读取员工信息失败";
                                    rst_MES_RETURN_UI_list.Add(rst);
                                    rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                    //return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_RY_RYINFO_SELECT.MES_RETURN);
                                }
                                DataTable rylist = rst_HR_RY_RYINFO_SELECT.DATALIST;
                                DataRow[] dr1 = rylist.Select("RYID=0");
                                if (dr1.Length > 0)
                                {
                                    for (int a = 0; a < dr1.Count(); a++)
                                    {
                                        rst = new MES_RETURN_UI();
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (Convert.ToInt32(dr1[a]["XH"].ToString()) + 1) + "行工号 " + dr1[a]["GH"].ToString() + "不存在，请检查！";
                                        rst_MES_RETURN_UI_list.Add(rst);
                                        errorcount = errorcount + 1;
                                    }
                                    //return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                if (errorcount > 0)
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                DataRow[] dr2 = rylist.Select("NSRSF=0");
                                if (dr2.Length > 0)
                                {
                                    for (int a = 0; a < dr1.Count(); a++)
                                    {
                                        rst = new MES_RETURN_UI();
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (Convert.ToInt32(dr2[a]["XH"].ToString()) + 1) + "行工号 " + dr2[a]["GH"].ToString() + "的纳税人身份不存在，请检查！";
                                        rst_MES_RETURN_UI_list.Add(rst);
                                        errorcount = errorcount + 1;
                                    }
                                    //return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                if (errorcount > 0)
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                if (GSLB == 56)
                                {
                                    for (int a = 0; a < rylist.Rows.Count; a++)
                                    {
                                        HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                        model_HR_XZGL_FFJLMX.FFJLID = FFJLID;
                                        model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                        model_HR_XZGL_FFJLMX.RYID = Convert.ToInt32(rylist.Rows[a]["RYID"].ToString());
                                        HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT(model_HR_XZGL_FFJLMX, 3, token);
                                        if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "S")
                                        {
                                            if (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count > 0)
                                            {
                                                rst = new MES_RETURN_UI();
                                                rst.TYPE = "E";
                                                rst.MESSAGE = "第" + (Convert.ToInt32(rylist.Rows[a]["XH"].ToString()) + 1) + "行工号 " + rylist.Rows[a]["GH"].ToString() + "的全年一次性已经添加，不允许重复，请检查！";
                                                rst_MES_RETURN_UI_list.Add(rst);
                                                errorcount = errorcount + 1;
                                                //return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                            }
                                        }
                                        else
                                        {
                                            rst = new MES_RETURN_UI();
                                            rst.TYPE = "E";
                                            rst.MESSAGE = "第" + (Convert.ToInt32(rylist.Rows[a]["XH"].ToString()) + 1) + "行工号 " + rylist.Rows[a]["GH"].ToString() + "的全年一次性读取失败";
                                            rst_MES_RETURN_UI_list.Add(rst);
                                            errorcount = errorcount + 1;
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
                                        }
                                    }
                                }
                                if (errorcount > 0)
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                for (int a = 0; a < rylist.Rows.Count; a++)
                                {
                                    data1.Rows[Convert.ToInt32(rylist.Rows[a]["XH"].ToString())]["RYID"] = Convert.ToInt32(rylist.Rows[a]["RYID"].ToString());
                                    if (rylist.Rows[a]["GS"].ToString() != GS)
                                    {
                                        rst = new MES_RETURN_UI();
                                        rst.TYPE = "W";
                                        rst.MESSAGE = "第" + (a + 1).ToString() + "行工号" + rylist.Rows[a]["GH"].ToString() + "，姓名" + rylist.Rows[a]["YGNAME"].ToString() + "人员公司不匹配";
                                        rst_MES_RETURN_UI_list.Add(rst);
                                    }
                                }

                                DataRow[] dr_jycf = rylist.Select("", "GH");
                                for (int a = 0; a < dr_jycf.Count() - 1; a++)
                                {
                                    if (dr_jycf[a]["GH"].ToString() == dr_jycf[a + 1]["GH"].ToString())
                                    {
                                        rst = new MES_RETURN_UI();
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (Convert.ToInt32(dr_jycf[a]["XH"].ToString()) + 1) + "行工号 " + dr_jycf[a]["GH"].ToString() + "重复";
                                        rst_MES_RETURN_UI_list.Add(rst);
                                        errorcount = errorcount + 1;
                                    }
                                }
                                if (errorcount > 0)
                                {
                                    rst = new MES_RETURN_UI();
                                    rst.TYPE = "E";
                                    rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                            }
                            else
                            {
                                rst = new MES_RETURN_UI();
                                rst.TYPE = "E";
                                rst.MESSAGE = "模版字段为空！";
                                rst_MES_RETURN_UI_list.Add(rst);
                                rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                            }
                        }
                        else
                        {
                            rst = new MES_RETURN_UI();
                            rst.TYPE = "E";
                            rst.MESSAGE = "模版读取失败";
                            rst_MES_RETURN_UI_list.Add(rst);
                            rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                        }

                        if (errorcount > 0)
                        {
                            rst = new MES_RETURN_UI();
                            rst.TYPE = "E";
                            rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                        }

                        DataTable dt_rylist = new DataTable();
                        dt_rylist.Columns.Add("RYID", typeof(int));
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["工号"].ToString().Trim() != "")
                            {
                                DataRow dr = dt_rylist.NewRow();
                                dr[0] = Convert.ToInt32(data1.Rows[a]["RYID"].ToString());
                                dt_rylist.Rows.Add(dr);
                            }
                        }
                        HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX_insert = new HR_XZGL_FFJLMX();
                        model_HR_XZGL_FFJLMX_insert.RYLIST = dt_rylist;
                        model_HR_XZGL_FFJLMX_insert.RYLIST.TableName = "RYLIST";
                        model_HR_XZGL_FFJLMX_insert.FFJLID = FFJLID;
                        model_HR_XZGL_FFJLMX_insert.MYPW = MYPW;
                        MES_RETURN_UI rst_MES_RETURN_UI_insert = new MES_RETURN_UI();
                        //rst_MES_RETURN_UI_insert = hrmodels.XZGL_FFJLMX.INSERT(model_HR_XZGL_FFJLMX_insert, token);



                        DataTable FFJLMXLIST = new DataTable();
                        FFJLMXLIST.Columns.Add("RYID", typeof(int));
                        FFJLMXLIST.Columns.Add("FFJLID", typeof(int));
                        FFJLMXLIST.Columns.Add("FFJLMXID", typeof(int));
                        FFJLMXLIST.Columns.Add("FFJLZDNAME", typeof(string));
                        FFJLMXLIST.Columns.Add("ZDVALUE", typeof(decimal));
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["工号"].ToString().Trim() != "")
                            {
                                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                                {
                                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].ISHAVEGS == 0 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1 && rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].ISGDZD == 0)
                                    {
                                        if (data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString() != "")
                                        {
                                            DataRow dr_FFJLMXLIST = FFJLMXLIST.NewRow();
                                            dr_FFJLMXLIST[0] = Convert.ToInt32(data1.Rows[a]["RYID"].ToString()); ;
                                            dr_FFJLMXLIST[1] = FFJLID;
                                            dr_FFJLMXLIST[3] = rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME;
                                            dr_FFJLMXLIST[4] = Convert.ToDecimal(data1.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS].ToString());
                                            FFJLMXLIST.Rows.Add(dr_FFJLMXLIST);
                                        }
                                    }
                                }
                            }
                        }
                        HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX_2 = new HR_XZGL_FFJLMX();
                        model_HR_XZGL_FFJLMX_2.MYPW = MYPW;
                        FFJLMXLIST.TableName = "FFJLMXLIST";
                        model_HR_XZGL_FFJLMX_2.FFJLMXLIST = FFJLMXLIST;
                        //MES_RETURN_UI rst_MES_RETURN_UI_2 = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX_2, 4, token);
                        rst = new MES_RETURN_UI();
                        rst.TYPE = "S";
                        rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt_rylist);
                        ds.Tables.Add(FFJLMXLIST);
                        rst.TM = Newtonsoft.Json.JsonConvert.SerializeObject(ds);
                        rst.BH = FFJLID.ToString();
                        rst.GC = MYPW;

                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    }
                    //rst.TYPE = "E";
                    //rst.MESSAGE = "文件读取失败！";
                    //return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    rst = new MES_RETURN_UI();
                    rst.TYPE = "E";
                    rst.MESSAGE = "文件读取失败";
                    rst_MES_RETURN_UI_list.Add(rst);
                    rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
                else
                {
                    //rst.TYPE = "E";
                    //rst.MESSAGE = "文件读取失败！";
                    //return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    rst = new MES_RETURN_UI();
                    rst.TYPE = "E";
                    rst.MESSAGE = "文件读取失败";
                    rst_MES_RETURN_UI_list.Add(rst);
                    rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
            }
            catch (Exception e)
            {
                //rst.TYPE = "E";
                //rst.MESSAGE = e.Message;
                //return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                rst = new MES_RETURN_UI();
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                rst_MES_RETURN_UI_list.Add(rst);
                rst.MESSAGE = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_list);
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
        }
        [HttpPost]
        public string INPORT_READ_GZMB_INSERT(string datastring1, string datastring2, string datastring3)
        {
            string token = AppClass.GetSession("token").ToString();
            DataSet ds = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSet>(datastring1);
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX_insert = new HR_XZGL_FFJLMX();
            model_HR_XZGL_FFJLMX_insert.RYLIST = ds.Tables[0];
            model_HR_XZGL_FFJLMX_insert.RYLIST.TableName = "RYLIST";
            model_HR_XZGL_FFJLMX_insert.FFJLID = Convert.ToInt32(datastring2);
            model_HR_XZGL_FFJLMX_insert.MYPW = datastring3;
            MES_RETURN_UI rst_MES_RETURN_UI_insert = new MES_RETURN_UI();
            rst_MES_RETURN_UI_insert = hrmodels.XZGL_FFJLMX.INSERT(model_HR_XZGL_FFJLMX_insert, token);
            if (rst_MES_RETURN_UI_insert.TYPE != "S")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_insert);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX_2 = new HR_XZGL_FFJLMX();
                model_HR_XZGL_FFJLMX_2.MYPW = datastring3;
                model_HR_XZGL_FFJLMX_2.FFJLMXLIST = ds.Tables[1];
                model_HR_XZGL_FFJLMX_2.FFJLMXLIST.TableName = "FFJLMXLIST";
                MES_RETURN_UI rst_MES_RETURN_UI_2 = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX_2, 4, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_2);
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI_insert);
            }
        }
        [HttpPost]
        public string INPORT_READ_FFJL_TZ(int FFJLID, string MYPW)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            string allgs = "";
            for (int i = 0; i < rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length; i++)
            {
                if (allgs == "")
                {
                    allgs = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
                else
                {
                    allgs = allgs + "," + rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
                }
            }
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    System.IO.File.Delete(savePath);
                    if (data1 != null)
                    {
                        data1.Columns.Add("RYID", typeof(int));
                        data1.Columns.Add("FFJLMXID", typeof(int));
                        //int errorcount = 0;
                        if (data1.Columns.Contains("工号") == false)
                        {
                            rst.TYPE = "E";
                            rst.MESSAGE = "工号字段不存在，请检查模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                        }
                        if (data1.Columns.Contains("姓名") == false)
                        {
                            rst.TYPE = "E";
                            rst.MESSAGE = "姓名字段不存在，请检查模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                        }
                        if (data1.Columns.Contains("含税金额") == false || data1.Columns.Contains("不含税金额") == false || data1.Columns.Contains("个税个人") == false || data1.Columns.Contains("个税单位") == false || data1.Columns.Contains("应补个人") == false || data1.Columns.Contains("应补单位") == false)
                        {
                            rst.TYPE = "E";
                            rst.MESSAGE = "请使用新模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                        }
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["工号"].ToString().Trim() != "")
                            {
                                //int ryid = 0;
                                if (data1.Rows[a]["工号"].ToString().Length != 5)
                                {
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "第" + (a + 2) + "行工号格式不正确！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                if (data1.Rows[a]["姓名"].ToString().Trim() == "")
                                {
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "第" + (a + 2) + "行姓名格为空！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                HR_RY_RYINFO model_HR_RY_RYINFO = new HR_RY_RYINFO();
                                model_HR_RY_RYINFO.GH = data1.Rows[a]["工号"].ToString();
                                //model_HR_RY_RYINFO.ALLGS = allgs;
                                model_HR_RY_RYINFO.YGNAME = data1.Rows[a]["姓名"].ToString().Trim();
                                HR_RY_RYINFO_SELECT rst_HR_RY_RYINFO_SELECT = hrmodels.RY_RYINFO.SELECT(model_HR_RY_RYINFO, token);
                                if (rst_HR_RY_RYINFO_SELECT.MES_RETURN.TYPE == "S")
                                {
                                    if (rst_HR_RY_RYINFO_SELECT.HR_RY_RYINFO_LIST.Length == 0)
                                    {
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (a + 1) + "行工号 " + data1.Rows[a]["工号"].ToString() + "不存在，请检查！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                    }
                                    else
                                    {
                                        data1.Rows[a]["RYID"] = rst_HR_RY_RYINFO_SELECT.HR_RY_RYINFO_LIST[0].RYID;
                                        HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                        model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                        model_HR_XZGL_FFJLMX.FFJLID = FFJLID;
                                        model_HR_XZGL_FFJLMX.RYID = rst_HR_RY_RYINFO_SELECT.HR_RY_RYINFO_LIST[0].RYID;
                                        HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT(model_HR_XZGL_FFJLMX, 4, token);
                                        if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "S")
                                        {
                                            if (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count > 0)
                                            {
                                                data1.Rows[a]["FFJLMXID"] = Convert.ToInt32(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[0]["FFJLMXID"].ToString());
                                            }
                                            else
                                            {
                                                rst.TYPE = "E";
                                                rst.MESSAGE = "第" + (a + 1) + "行工号 " + data1.Rows[a]["工号"].ToString() + "发放记录不存在，请检查！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                            }
                                        }
                                        else
                                        {
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
                                        }
                                    }
                                }
                                else
                                {
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_RY_RYINFO_SELECT.MES_RETURN);
                                }
                                if (data1.Rows[a]["含税金额"].ToString() != "")
                                {
                                    try
                                    {
                                        Convert.ToDecimal(data1.Rows[a]["含税金额"].ToString());
                                    }
                                    catch (Exception)
                                    {
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (a + 1) + "行 " + data1.Rows[a]["含税金额"].ToString() + " 不是数字或空，请检查！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                    }
                                }
                                if (data1.Rows[a]["不含税金额"].ToString() != "")
                                {
                                    try
                                    {
                                        Convert.ToDecimal(data1.Rows[a]["不含税金额"].ToString());
                                    }
                                    catch (Exception)
                                    {
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (a + 1) + "行 " + data1.Rows[a]["不含税金额"].ToString() + " 不是数字或空，请检查！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                    }
                                }
                                if (data1.Rows[a]["个税个人"].ToString() != "")
                                {
                                    try
                                    {
                                        Convert.ToDecimal(data1.Rows[a]["个税个人"].ToString());
                                    }
                                    catch (Exception)
                                    {
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (a + 1) + "行 " + data1.Rows[a]["个税个人"].ToString() + " 不是数字或空，请检查！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                    }
                                }
                                if (data1.Rows[a]["个税单位"].ToString() != "")
                                {
                                    try
                                    {
                                        Convert.ToDecimal(data1.Rows[a]["个税单位"].ToString());
                                    }
                                    catch (Exception)
                                    {
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (a + 1) + "行 " + data1.Rows[a]["个税单位"].ToString() + " 不是数字或空，请检查！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                    }
                                }
                                if (data1.Rows[a]["应补个人"].ToString() != "")
                                {
                                    try
                                    {
                                        Convert.ToDecimal(data1.Rows[a]["应补个人"].ToString());
                                    }
                                    catch (Exception)
                                    {
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (a + 1) + "行 " + data1.Rows[a]["应补个人"].ToString() + " 不是数字或空，请检查！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                    }
                                }
                                if (data1.Rows[a]["应补单位"].ToString() != "")
                                {
                                    try
                                    {
                                        Convert.ToDecimal(data1.Rows[a]["应补单位"].ToString());
                                    }
                                    catch (Exception)
                                    {
                                        rst.TYPE = "E";
                                        rst.MESSAGE = "第" + (a + 1) + "行 " + data1.Rows[a]["应补单位"].ToString() + " 不是数字或空，请检查！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                    }
                                }
                            }
                        }
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["工号"].ToString().Trim() != "")
                            {
                                HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                MES_RETURN_UI rst_MES_RETURN_UI = new MES_RETURN_UI();
                                if (data1.Rows[a]["含税金额"].ToString() != "")
                                {
                                    model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                    model_HR_XZGL_FFJLMX.FFJLMXID = Convert.ToInt32(data1.Rows[a]["FFJLMXID"].ToString());
                                    model_HR_XZGL_FFJLMX.FFJLZDNAME = "FFJLHS";
                                    model_HR_XZGL_FFJLMX.ZDVALUE = Convert.ToDecimal(data1.Rows[a]["含税金额"].ToString());
                                    model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                    rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX, 3, token);
                                    if (rst_MES_RETURN_UI.TYPE == "E")
                                    {
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                                    }
                                }
                                if (data1.Rows[a]["不含税金额"].ToString() != "")
                                {
                                    model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                    model_HR_XZGL_FFJLMX.FFJLMXID = Convert.ToInt32(data1.Rows[a]["FFJLMXID"].ToString());
                                    model_HR_XZGL_FFJLMX.FFJLZDNAME = "FFJLNOHS";
                                    model_HR_XZGL_FFJLMX.ZDVALUE = Convert.ToDecimal(data1.Rows[a]["不含税金额"].ToString());
                                    model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                    rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX, 3, token);
                                    if (rst_MES_RETURN_UI.TYPE == "E")
                                    {
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                                    }
                                }
                                if (data1.Rows[a]["个税个人"].ToString() != "")
                                {
                                    model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                    model_HR_XZGL_FFJLMX.FFJLMXID = Convert.ToInt32(data1.Rows[a]["FFJLMXID"].ToString());
                                    model_HR_XZGL_FFJLMX.FFJLZDNAME = "FFJLGSGR";
                                    model_HR_XZGL_FFJLMX.ZDVALUE = Convert.ToDecimal(data1.Rows[a]["个税个人"].ToString());
                                    model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                    rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX, 3, token);
                                    if (rst_MES_RETURN_UI.TYPE == "E")
                                    {
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                                    }
                                }
                                if (data1.Rows[a]["个税单位"].ToString() != "")
                                {
                                    model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                    model_HR_XZGL_FFJLMX.FFJLMXID = Convert.ToInt32(data1.Rows[a]["FFJLMXID"].ToString());
                                    model_HR_XZGL_FFJLMX.FFJLZDNAME = "FFJLGSDW";
                                    model_HR_XZGL_FFJLMX.ZDVALUE = Convert.ToDecimal(data1.Rows[a]["个税单位"].ToString());
                                    model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                    rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX, 3, token);
                                    if (rst_MES_RETURN_UI.TYPE == "E")
                                    {
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                                    }
                                }
                                if (data1.Rows[a]["应补个人"].ToString() != "")
                                {
                                    model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                    model_HR_XZGL_FFJLMX.FFJLMXID = Convert.ToInt32(data1.Rows[a]["FFJLMXID"].ToString());
                                    model_HR_XZGL_FFJLMX.FFJLZDNAME = "FFJLGSGRYB";
                                    model_HR_XZGL_FFJLMX.ZDVALUE = Convert.ToDecimal(data1.Rows[a]["应补个人"].ToString());
                                    model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                    rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX, 3, token);
                                    if (rst_MES_RETURN_UI.TYPE == "E")
                                    {
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                                    }
                                }
                                if (data1.Rows[a]["应补单位"].ToString() != "")
                                {
                                    model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                    model_HR_XZGL_FFJLMX.FFJLMXID = Convert.ToInt32(data1.Rows[a]["FFJLMXID"].ToString());
                                    model_HR_XZGL_FFJLMX.FFJLZDNAME = "FFJLGSDWYB";
                                    model_HR_XZGL_FFJLMX.ZDVALUE = Convert.ToDecimal(data1.Rows[a]["应补单位"].ToString());
                                    model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                    rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.UPDATE(model_HR_XZGL_FFJLMX, 3, token);
                                    if (rst_MES_RETURN_UI.TYPE == "E")
                                    {
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                                    }
                                }

                                model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                                model_HR_XZGL_FFJLMX.FFJLID = FFJLID;
                                model_HR_XZGL_FFJLMX.FFJLMXID = Convert.ToInt32(data1.Rows[a]["FFJLMXID"].ToString());
                                model_HR_XZGL_FFJLMX.MYPW = MYPW;
                                rst_MES_RETURN_UI = hrmodels.XZGL_FFJLMX.FORMULA_JS_TZ(model_HR_XZGL_FFJLMX, 2, token);
                                if (rst_MES_RETURN_UI.TYPE == "E")
                                {
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                                }
                            }
                        }
                        rst.TYPE = "S";
                        rst.MESSAGE = "";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    }
                    rst.TYPE = "E";
                    rst.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
        }

        public ActionResult EXPORT_READ__FFJLREPORT(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "个税报表导出.xls");
        }
        [HttpPost]
        public string XZGL_ZDGLGL_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_ZDGLGL model_HR_XZGL_ZDGLGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_ZDGLGL>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_ZDGLGL.INSERT(model_HR_XZGL_ZDGLGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_ZDGLGL_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_ZDGLGL model_HR_XZGL_ZDGLGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_ZDGLGL>(datastring);
            MES_RETURN_UI rst = hrmodels.XZGL_ZDGLGL.UPDATE(model_HR_XZGL_ZDGLGL, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_ZDGLGL_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_ZDGLGL model_HR_XZGL_ZDGLGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_ZDGLGL>(datastring);
            HR_XZGL_ZDGLGL_SELECT rst = hrmodels.XZGL_ZDGLGL.SELECT(model_HR_XZGL_ZDGLGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_ZDGLGL_FORMULA_VERIFY_GLZD(string FORMULA, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.XZGL_ZDGLGL.FORMULA_VERIFY_GLZD(FORMULA, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string KQ_JQGLMX_AUTO_ADD_TO_FFJLMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_JQGLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_JQGLMX>(datastring);
            MES_RETURN_UI result = hrmodels.KQ_JQGLMX.AUTO_ADD_TO_FFJLMX(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string SY_DEPT_SELECT_BY_ROLE_LD(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_DEPT model_HR_SY_DEPT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DEPT>(datastring);
            model_HR_SY_DEPT.STAFFID = STAFFID;
            HR_SY_DEPT_SELECT rst = hrmodels.SY_DEPT.SELECT_BY_ROLE_LD(model_HR_SY_DEPT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_GS_SELECT_BY_ROLE()
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS_SELECT data = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Data_DaoChu_XZDA_TZJL(string datastring, int LB)
        {
            MES_RETURN_UI rst_MES_RETURN_UI = new MES_RETURN_UI();
            try
            {
                string token = AppClass.GetSession("token").ToString();
                int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                HR_XZGL_XZDA model_HR_XZGL_XZDA = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_XZDA>(datastring);
                model_HR_XZGL_XZDA.STAFFID = STAFFID;
                HR_XZGL_XZDA_SELECT rst_HR_XZGL_XZDA_SELECT = hrmodels.XZGL_XZDA.SELECTALL(model_HR_XZGL_XZDA, LB, token);
                if (rst_HR_XZGL_XZDA_SELECT.MES_RETURN.TYPE == "E")
                {
                    rst_MES_RETURN_UI.TYPE = "E";
                    rst_MES_RETURN_UI.MESSAGE = "查询数据失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
                }
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                int ccount = 0;
                string tt = "工号,姓名,公司,部门,员工类别,证照类型,证照号码,纳税人身份,纳税人识别号,在职状态,调整项目,调整原因,调整前,调整后,生效日期,操作人,操作时间";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(a).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < rst_HR_XZGL_XZDA_SELECT.DataTable.Rows.Count; i++)
                {
                    ccount = 0;
                    DataRow dr = rst_HR_XZGL_XZDA_SELECT.DataTable.Rows[i];
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(ccount++).SetCellValue(dr["GH"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["YGNAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["GSNAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["DEPTNAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["YGTYPENAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["ZZTYPENAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["ZZNO"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["NSRSFNAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["NSRSBH"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["ZZZTNAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["GZLBNAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["TZYYNAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(dr["TZQ"].ToString()).ToString());
                    row.CreateCell(ccount++).SetCellValue(Convert.ToDouble(dr["TZH"].ToString()).ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["SXDATE"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["XGRNAME"].ToString());
                    row.CreateCell(ccount++).SetCellValue(dr["XGTIME"].ToString());
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst_MES_RETURN_UI.TYPE = "S";
                rst_MES_RETURN_UI.MESSAGE = now;
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            }
            catch (Exception e)
            {
                rst_MES_RETURN_UI.TYPE = "E";
                rst_MES_RETURN_UI.MESSAGE = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            }
        }
        public ActionResult EXPORT_READ_XZDA_TZJL(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "薪资调整记录导出.xlsx");
        }
        [HttpPost]
        public string GET_FLDATZMX_TH(string MONTH, string GS)
        {
            AppClass.SetSession("MONTH", MONTH);
            AppClass.SetSession("GS", GS);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_TIME_NOW()
        {
            string token = AppClass.GetSession("token").ToString();
            return mesModels.PUBLIC_FUNC.GET_TIME(token);
        }
        [HttpPost]
        public string SY_ZJH_SELECT_BY_ROLE(string GS)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_ZJH_LAY_SELECT data = hrmodels.SY_ZJH.SELECT_BY_ROLE(STAFFID, GS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string EXPOST_FFJLMX(string datastring, int LB, string datastring1)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT(model_HR_XZGL_FFJLMX, LB, token);
            if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
            }
            HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX>(datastring1);
            HR_XZGL_MBGLMX_SELECT rst_HR_XZGL_MBGLMX_SELECT = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
            if (rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].FFJLZDMS);
                }
                for (int a = 0; a < rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count; a++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                    {
                        if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                        {
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                        }
                        else if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 2)
                        {
                            row.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString());
                        }
                    }

                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_DOWNLOAD_FFJLMX(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "发放明细导出.xlsx");
        }
        [HttpPost]
        public string EXPOST_FFJL(string datastring, int LB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJL model_HR_XZGL_FFJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJL>(datastring);
            model_HR_XZGL_FFJL.STAFFID = STAFFID;
            HR_XZGL_FFJL_SELECT rst_HR_XZGL_FFJL_SELECT = hrmodels.XZGL_FFJL.SELECT(model_HR_XZGL_FFJL, LB, token);
            if (rst_HR_XZGL_FFJL_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJL_SELECT.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "状态,发放日期,公司,发放模版,发放人数,累计含税收入,累计应纳税额,其中：单位,其中：个人,累计不含税收入,备注,发布时间";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = rst_HR_XZGL_FFJL_SELECT.DATALIST;
                for (int i = 0; i < rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    if (dtinfo.Rows[i]["ISFF"].ToString() == "0")
                    {
                        row.CreateCell(cellIndex++).SetCellValue("未发放");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("已发放");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["FFDATE"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["FFLBNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZJRS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["ZJHSJE"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["ZJGSDW"].ToString()) + Convert.ToDouble(dtinfo.Rows[i]["ZJGSGR"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["ZJGSDW"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["ZJGSGR"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["ZJNOHSJE"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["FFSM"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["FFJLFBTIME"].ToString());
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_FFJLMX_GUOSHUIREPORT(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJL_SELECT = hrmodels.XZGL_FFJLMX.SELECT_GUOSHUIREPORT(model_HR_XZGL_FFJLMX, token);
            if (rst_HR_XZGL_FFJL_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJL_SELECT.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,证件号码,公司,入职日期,离职日期,人数,员工类别,部门,归属部门,归属成本中心,手机号码,本期收入,本期养老,本期医疗,本期失业,本期公积金,本期其他扣除,累计收入额,累计减除费用,累计专项扣除,累计子女教育,累计赡养老人,累计继续教育,累计住房贷款,累计住房租金,累计专项附加,累计捐赠,累计其他扣除,累计应纳税所得额,税率,速算扣除数,累计应纳税额,累计个人,累计单位,累计已预扣,累计个人预扣,累计单位预扣,累计应补（退）额,累计个人应补（退）额,累计单位应补（退）额";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = rst_HR_XZGL_FFJL_SELECT.DATALIST;
                for (int i = 0; i < rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["RZRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LZRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["RYCOUNT"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSBMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTCBZX"].ToString());

                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["PHONENUMBER"].ToString());
                    //row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSLBNAME"].ToString());
                    //row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSCBZX"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["FFJLHS"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["YANGLAO"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["YIBAO"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["SHIYEFEI"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["GONGJIJIN"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["TONGXUNFEI"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJSHOURUE"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJIANCHUFY"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJZHUANXIANKC"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJZINVJY"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJSHANYANGLR"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJJIXUJY"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJZHUFANGDK"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJZHUFANGZJ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJZHUANXKFJ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJDONATION"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJQITAKC"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJYINGNASHUISDE"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["SHUILV"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["SUSUANKCS"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJYINGNASE"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJGEREN"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJDANWEI"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJYIYUKOU"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJGERENYK"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJDANWEIYK"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJYINGBUE"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJGERENYINGBUE"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["LJDANWEIYINGBUE"].ToString()));
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_DOWNLOAD(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xlsx");
        }
        [HttpPost]
        public string EXPOST_FFJLMX_GSREPORT(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT_GSREPORT(model_HR_XZGL_FFJLMX, token);
            if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,个税类别,含税收入,应纳税额,其中：个人,其中：单位,不含税收入";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = rst_HR_XZGL_FFJLMX_SELECT.DATALIST;
                DataRow drinfo = dtinfo.NewRow();
                drinfo["FFJLHS"] = 0;
                drinfo["FFJLGSGR"] = 0;
                drinfo["FFJLGSDW"] = 0;
                drinfo["FFJLNOHS"] = 0;
                for (int i = 0; i < rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSLBNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["FFJLHS"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["FFJLGSDW"].ToString()) + Convert.ToDouble(dtinfo.Rows[i]["FFJLGSGR"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["FFJLGSGR"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["FFJLGSDW"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["FFJLNOHS"].ToString()));
                    drinfo["FFJLHS"] = Convert.ToDecimal(drinfo["FFJLHS"].ToString()) + Convert.ToDecimal(Convert.ToDouble(dtinfo.Rows[i]["FFJLHS"].ToString()));
                    drinfo["FFJLGSGR"] = Convert.ToDecimal(drinfo["FFJLGSGR"].ToString()) + Convert.ToDecimal(Convert.ToDouble(dtinfo.Rows[i]["FFJLGSGR"].ToString()));
                    drinfo["FFJLGSDW"] = Convert.ToDecimal(drinfo["FFJLGSDW"].ToString()) + Convert.ToDecimal(Convert.ToDouble(dtinfo.Rows[i]["FFJLGSDW"].ToString()));
                    drinfo["FFJLNOHS"] = Convert.ToDecimal(drinfo["FFJLNOHS"].ToString()) + Convert.ToDecimal(Convert.ToDouble(dtinfo.Rows[i]["FFJLNOHS"].ToString()));
                }
                cellIndex = 0;
                IRow rowhj = sheet.CreateRow(rowcount++);
                rowhj.CreateCell(cellIndex++).SetCellValue("合计：");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo["FFJLHS"].ToString()));
                rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo["FFJLGSDW"].ToString()) + Convert.ToDouble(drinfo["FFJLGSGR"].ToString()));
                rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo["FFJLGSGR"].ToString()));
                rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo["FFJLGSDW"].ToString()));
                rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo["FFJLNOHS"].ToString()));
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_FFJLMX_FFMXREPORT(string datastring, string datastring1)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT_FFMXREPORT(model_HR_XZGL_FFJLMX, token);
            if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
            }
            HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX>(datastring1);
            HR_XZGL_MBGLMX_SELECT rst_HR_XZGL_MBGLMX_SELECT = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
            if (rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,证件号码,公司,入职日期,离职日期,人数,员工类别,部门,归属部门,归属成本中心,手机号码";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int a = 0; a < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; a++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].MXID == 1)
                    {
                        rowtt.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].FFJLZDMS);
                    }
                }
                DataTable dtinfo = rst_HR_XZGL_FFJLMX_SELECT.DATALIST;
                DataRow drinfo = dtinfo.NewRow();
                for (int i = 0; i < rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["RZRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LZRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["RYCOUNT"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSBMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTCBZX"].ToString());

                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["PHONENUMBER"].ToString());
                    for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                    {
                        if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                        {
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[i][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                            if (drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString() == "")
                            {
                                drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = 0;
                            }
                            drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = Convert.ToDecimal(drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME]) + Convert.ToDecimal(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[i][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString());
                        }
                    }
                }
                cellIndex = 0;
                IRow rowhj = sheet.CreateRow(rowcount++);
                rowhj.CreateCell(cellIndex++).SetCellValue("合计：");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                    }
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_FFJLMX_GZXJSDREPORT(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT_GZXJSDREPORT(model_HR_XZGL_FFJLMX, token);
            if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,证照类型,证照号码,本期收入,养老,医保,失业费,公积金,通讯费";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = rst_HR_XZGL_FFJLMX_SELECT.DATALIST;
                for (int i = 0; i < rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["FFJLHS"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["YANGLAO"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["YIBAO"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["SHIYEFEI"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["GONGJIJIN"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["TONGXUNFEI"].ToString()));
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string EXPOST_FFJLMX_FFMXGZDREPORT(string datastring, string datastring1, string NY)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT_FFMXGZDREPORT(model_HR_XZGL_FFJLMX, token);
            if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
            }
            if (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无数据！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX>(datastring1);
            HR_XZGL_MBGLMX_SELECT rst_HR_XZGL_MBGLMX_SELECT = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
            if (rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "年月,卡号,性别,工号,姓名,部门编码,人数,部门,归属部门,归属成本中心,卡名称,证件号码";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int a = 0; a < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; a++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].MXID == 1)
                    {
                        rowtt.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].FFJLZDMS);
                    }
                }

                ICellStyle style_math = workbook.CreateCellStyle();
                IDataFormat dataformat = workbook.CreateDataFormat();
                style_math.DataFormat = dataformat.GetFormat("0.00;[Red]-0.00");

                DataTable dtinfo = rst_HR_XZGL_FFJLMX_SELECT.DATALIST;
                DataRow drinfo = dtinfo.NewRow();
                for (int i = 0; i < rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    //row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YEARMONTH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(NY.Substring(2, 2) + NY.Substring(5, 2));
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["BANKNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["XB"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNO"].ToString().PadLeft(2, '0'));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(dtinfo.Rows[i]["RYCOUNT"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME_GS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTCBZX_GS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["BANKNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZNO"].ToString());
                    for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                    {
                        if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                        {
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[i][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                            row.GetCell(cellIndex - 1).CellStyle = style_math;
                            if (drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString() == "")
                            {
                                drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = 0;
                            }
                            drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = Convert.ToDecimal(drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME]) + Convert.ToDecimal(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[i][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString());
                        }
                    }
                }
                cellIndex = 0;
                IRow rowhj = sheet.CreateRow(rowcount++);
                rowhj.CreateCell(cellIndex++).SetCellValue("合计：");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count.ToString());
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                        rowhj.GetCell(cellIndex - 1).CellStyle = style_math;
                    }
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_FFJLMX_FFMXGZDREPORT_GZT(string datastring, string datastring1, string NY, string PRINTNAME)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT_FFMXGZDREPORT(model_HR_XZGL_FFJLMX, token);
            if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
            }
            HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX>(datastring1);
            HR_XZGL_MBGLMX_SELECT rst_HR_XZGL_MBGLMX_SELECT = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
            if (rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN);
            }
            HR_XZGL_FFJL model_HR_XZGL_FFJL = new HR_XZGL_FFJL();
            model_HR_XZGL_FFJL.FFJLID = model_HR_XZGL_FFJLMX.FFJLID;
            model_HR_XZGL_FFJL.MYPW = model_HR_XZGL_FFJLMX.MYPW;
            model_HR_XZGL_FFJL.STAFFID = STAFFID;
            HR_XZGL_FFJL_SELECT rst_HR_XZGL_FFJL_SELECT = hrmodels.XZGL_FFJL.SELECT(model_HR_XZGL_FFJL, 1, token);
            if (rst_HR_XZGL_FFJL_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJL_SELECT.MES_RETURN);
            }
            string GSNAME = "";
            string GS = "";
            if (rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows.Count > 0)
            {
                GSNAME = rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows[0]["GSNAME"].ToString();
                GS = rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows[0]["GS"].ToString();
            }
            HR_XZGL_MBGL model_HR_XZGL_MBGL = new HR_XZGL_MBGL();
            model_HR_XZGL_MBGL.MBID = model_HR_XZGL_MBGLMX.MBID;
            model_HR_XZGL_MBGL.STAFFID = STAFFID;
            HR_XZGL_MBGL_SELECT rst_HR_XZGL_MBGL_SELECT = hrmodels.XZGL_MBGL.SELECT(model_HR_XZGL_MBGL, token);
            if (rst_HR_XZGL_MBGL_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGL_SELECT.MES_RETURN);
            }
            string MBNAME = "";
            if (rst_HR_XZGL_MBGL_SELECT.HR_XZGL_MBGL_LIST.Length > 0)
                MBNAME = rst_HR_XZGL_MBGL_SELECT.HR_XZGL_MBGL_LIST[0].MBNAME;

            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                string tt = "年月,工号,姓名,部门";
                string[] ttlist = tt.Split(',');
                DataTable dtinfo = rst_HR_XZGL_FFJLMX_SELECT.DATALIST;
                ISheet sheet = workbook.GetSheetAt(0);
                sheet.FitToPage = false;
                workbook.RemoveSheetAt(0);
                string dept = "";
                int rowcount = 0;
                int cellIndex = 0;
                ICellStyle style = workbook.CreateCellStyle();
                IFont font = workbook.CreateFont();
                font.FontHeightInPoints = 8;
                font.FontName = "宋体";
                style.SetFont(font);
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.VerticalAlignment = VerticalAlignment.Center;

                ICellStyle style1 = workbook.CreateCellStyle();
                font = workbook.CreateFont();
                font.FontHeightInPoints = 8;
                font.FontName = "宋体";
                style1.SetFont(font);
                style1.BorderBottom = BorderStyle.Thin;
                style1.BorderLeft = BorderStyle.Thin;
                style1.BorderRight = BorderStyle.Thin;
                style1.BorderTop = BorderStyle.Thin;
                style1.VerticalAlignment = VerticalAlignment.Center;
                style1.Alignment = HorizontalAlignment.Center;

                ICellStyle style2 = workbook.CreateCellStyle();
                font = workbook.CreateFont();
                font.FontHeightInPoints = 8;
                font.FontName = "宋体";
                style2.SetFont(font);
                style2.BorderBottom = BorderStyle.Thin;
                style2.BorderLeft = BorderStyle.Thin;
                style2.BorderRight = BorderStyle.Thin;
                style2.BorderTop = BorderStyle.Thin;
                IDataFormat dataformat = workbook.CreateDataFormat();
                style2.DataFormat = dataformat.GetFormat("0.00;[Red]-0.00");
                style2.VerticalAlignment = VerticalAlignment.Center;

                model_HR_XZGL_FFJL = new HR_XZGL_FFJL();
                HR_XZGL_FFJL_SELECT rst_HR_XZGL_FFJLMX_SELECT_fycount = hrmodels.XZGL_FFJL.SELECT(model_HR_XZGL_FFJL, 2, token);
                if (rst_HR_XZGL_FFJLMX_SELECT_fycount.MES_RETURN.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT_fycount.MES_RETURN);
                }
                int fycount = Convert.ToInt32(rst_HR_XZGL_FFJLMX_SELECT_fycount.DATALIST.Rows[0][0].ToString());
                int rycount = 0;
                int fyno = 0;
                int hcount = 0;
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        hcount = hcount + 1;
                    }
                }
                hcount = hcount + 4;

                for (int a = 0; a < rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count; a++)
                {
                    cellIndex = 0;
                    if (dept == "")
                    {
                        fyno = 1;
                        workbook.CreateSheet(dtinfo.Rows[a]["DEPTNAME"].ToString());
                        rycount = 0;
                        sheet = workbook.GetSheet(dtinfo.Rows[a]["DEPTNAME"].ToString());
                        sheet.FitToPage = false;
                        dept = dtinfo.Rows[a]["DEPTNAME"].ToString();
                        sheet.SetColumnWidth(cellIndex++, 4 * 256);
                        sheet.SetColumnWidth(cellIndex++, 9 * 128);
                        sheet.SetColumnWidth(cellIndex++, 6 * 256);
                        sheet.SetColumnWidth(cellIndex++, 4 * 256);
                        for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                            {
                                sheet.SetColumnWidth(cellIndex++, rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].PRINTCD * 128);
                            }
                        }
                        rowcount = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(10).SetCellValue(PRINTNAME + "员工工资单");

                        row = sheet.CreateRow(rowcount++);
                        row.CreateCell(0).SetCellValue("部门：" + dept);
                        //row.CreateCell(1).SetCellValue(dept);
                        row.CreateCell(8).SetCellValue(NY.Substring(0, 4) + "年" + NY.Substring(5, 2) + "月");
                        row.CreateCell(13).SetCellValue(GSNAME);
                        row.CreateCell(hcount - 1).SetCellValue("第" + fyno.ToString() + "页");
                        fyno = fyno + 1;
                    }
                    else if (dept != dtinfo.Rows[a]["DEPTNAME"].ToString())
                    {
                        //fyno = 1;
                        workbook.CreateSheet(dtinfo.Rows[a]["DEPTNAME"].ToString());
                        rycount = 0;
                        sheet = workbook.GetSheet(dtinfo.Rows[a]["DEPTNAME"].ToString());
                        sheet.FitToPage = false;
                        dept = dtinfo.Rows[a]["DEPTNAME"].ToString();
                        sheet.SetColumnWidth(cellIndex++, 4 * 256);
                        sheet.SetColumnWidth(cellIndex++, 9 * 128);
                        sheet.SetColumnWidth(cellIndex++, 6 * 256);
                        sheet.SetColumnWidth(cellIndex++, 4 * 256);
                        for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                            {
                                sheet.SetColumnWidth(cellIndex++, rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].PRINTCD * 128);
                            }
                        }
                        rowcount = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(10).SetCellValue(PRINTNAME + "员工工资单");

                        row = sheet.CreateRow(rowcount++);
                        row.CreateCell(0).SetCellValue("部门：" + dept);
                        //row.CreateCell(1).SetCellValue(dept);
                        row.CreateCell(8).SetCellValue(NY.Substring(0, 4) + "年" + NY.Substring(5, 2) + "月");
                        row.CreateCell(13).SetCellValue(GSNAME);
                        row.CreateCell(hcount - 1).SetCellValue("第" + fyno.ToString() + "页");
                        fyno = fyno + 1;
                    }
                    //if (rowcount > 3)
                    //{
                    //    IRow rowtt_k = sheet.CreateRow(rowcount++);
                    //    rowtt_k.Height = 18 * 20;
                    //}
                    cellIndex = 0;
                    IRow rowtt = sheet.CreateRow(rowcount++);
                    rowtt.Height = 18 * 20;
                    for (int b = 0; b < ttlist.Length; b++)
                    {
                        rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[b]);
                        rowtt.GetCell(cellIndex - 1).CellStyle = style1;
                    }
                    for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                    {
                        if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                        {
                            rowtt.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS);
                            rowtt.GetCell(cellIndex - 1).CellStyle = style1;
                        }
                    }
                    rowtt = sheet.CreateRow(rowcount++);
                    rowtt.Height = 18 * 20;
                    cellIndex = 0;
                    //rowtt.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[a]["YEARMONTH"].ToString());
                    rowtt.CreateCell(cellIndex++).SetCellValue(NY.Substring(2, 2) + NY.Substring(5, 2));
                    rowtt.GetCell(cellIndex - 1).CellStyle = style;
                    rowtt.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[a]["GH"].ToString());
                    rowtt.GetCell(cellIndex - 1).CellStyle = style;
                    rowtt.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[a]["YGNAME"].ToString());
                    rowtt.GetCell(cellIndex - 1).CellStyle = style;
                    rowtt.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[a]["DEPTNO"].ToString());
                    rowtt.GetCell(cellIndex - 1).CellStyle = style;
                    for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                    {
                        if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                        {
                            rowtt.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                            rowtt.GetCell(cellIndex - 1).CellStyle = style2;
                        }
                    }
                    rycount = rycount + 1;
                    if ((rycount) >= (fycount))
                    {
                        sheet.SetRowBreak(rowcount - 1);
                        rycount = 0;
                        if (a < (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count - 1))
                        {
                            if (dtinfo.Rows[a]["DEPTNAME"].ToString() == dtinfo.Rows[a + 1]["DEPTNAME"].ToString())
                            {
                                rowtt = sheet.CreateRow(rowcount++);
                                rowtt.CreateCell(0).SetCellValue("部门：" + dept);
                                //rowtt.CreateCell(1).SetCellValue(dept);
                                rowtt.CreateCell(8).SetCellValue(NY.Substring(0, 4) + "年" + NY.Substring(5, 2) + "月");
                                rowtt.CreateCell(13).SetCellValue(GSNAME);
                                rowtt.CreateCell(hcount - 1).SetCellValue("第" + fyno.ToString() + "页");
                                fyno = fyno + 1;
                            }
                        }
                    }
                    else
                    {
                        if (a < (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count - 1))
                        {
                            if (dtinfo.Rows[a]["DEPTNAME"].ToString() == dtinfo.Rows[a + 1]["DEPTNAME"].ToString())
                            {
                                IRow rowtt_k = sheet.CreateRow(rowcount++);
                                rowtt_k.Height = 18 * 20;
                            }
                        }
                    }
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch (Exception ex)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！" + ex.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_FFJLMX_FFMXGZDREPORT_GZTDEPT(string datastring, string datastring1, string NY, string PRINTNAME)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT_FFMXGZDREPORT(model_HR_XZGL_FFJLMX, token);
            if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
            }
            HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX>(datastring1);
            HR_XZGL_MBGLMX_SELECT rst_HR_XZGL_MBGLMX_SELECT = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
            if (rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN);
            }
            HR_XZGL_FFJL model_HR_XZGL_FFJL = new HR_XZGL_FFJL();
            model_HR_XZGL_FFJL.FFJLID = model_HR_XZGL_FFJLMX.FFJLID;
            model_HR_XZGL_FFJL.MYPW = model_HR_XZGL_FFJLMX.MYPW;
            model_HR_XZGL_FFJL.STAFFID = STAFFID;
            HR_XZGL_FFJL_SELECT rst_HR_XZGL_FFJL_SELECT = hrmodels.XZGL_FFJL.SELECT(model_HR_XZGL_FFJL, 1, token);
            if (rst_HR_XZGL_FFJL_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJL_SELECT.MES_RETURN);
            }
            string GSNAME = "";
            string GS = "";
            if (rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows.Count > 0)
            {
                GSNAME = rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows[0]["GSNAME"].ToString();
                GS = rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows[0]["GS"].ToString();
            }
            HR_XZGL_MBGL model_HR_XZGL_MBGL = new HR_XZGL_MBGL();
            model_HR_XZGL_MBGL.MBID = model_HR_XZGL_MBGLMX.MBID;
            model_HR_XZGL_MBGL.STAFFID = STAFFID;
            HR_XZGL_MBGL_SELECT rst_HR_XZGL_MBGL_SELECT = hrmodels.XZGL_MBGL.SELECT(model_HR_XZGL_MBGL, token);
            if (rst_HR_XZGL_MBGL_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGL_SELECT.MES_RETURN);
            }
            string MBNAME = "";
            if (rst_HR_XZGL_MBGL_SELECT.HR_XZGL_MBGL_LIST.Length > 0)
                MBNAME = rst_HR_XZGL_MBGL_SELECT.HR_XZGL_MBGL_LIST[0].MBNAME;
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                string tt = "年月,卡号,工号,姓名,人数";
                string[] ttlist = tt.Split(',');
                DataTable dtinfo = rst_HR_XZGL_FFJLMX_SELECT.DATALIST;
                DataRow drinfo = dtinfo.NewRow();
                DataRow drinfohj = dtinfo.NewRow();
                ISheet sheet = workbook.GetSheetAt(0);
                workbook.RemoveSheetAt(0);
                string dept = "";
                int rowcount = 0;
                int cellIndex = 0;
                ICellStyle style = workbook.CreateCellStyle();
                IFont font = workbook.CreateFont();
                font.FontHeightInPoints = 8;
                font.FontName = "宋体";
                style.SetFont(font);
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.Alignment = HorizontalAlignment.Center;

                ICellStyle style_BANKNO = workbook.CreateCellStyle();
                IFont font_BANKNO = workbook.CreateFont();
                font_BANKNO.FontHeightInPoints = 8;
                font_BANKNO.FontName = "宋体";
                style_BANKNO.SetFont(font_BANKNO);
                style_BANKNO.BorderBottom = BorderStyle.Thin;
                style_BANKNO.BorderLeft = BorderStyle.Thin;
                style_BANKNO.BorderRight = BorderStyle.Thin;
                style_BANKNO.BorderTop = BorderStyle.Thin;
                style_BANKNO.VerticalAlignment = VerticalAlignment.Center;
                style_BANKNO.Alignment = HorizontalAlignment.Left;

                ICellStyle style_math = workbook.CreateCellStyle();
                IFont font_math = workbook.CreateFont();
                font_math.FontHeightInPoints = 8;
                font_math.FontName = "宋体";
                style_math.SetFont(font_math);
                style_math.BorderBottom = BorderStyle.Thin;
                style_math.BorderLeft = BorderStyle.Thin;
                style_math.BorderRight = BorderStyle.Thin;
                style_math.BorderTop = BorderStyle.Thin;
                style_math.VerticalAlignment = VerticalAlignment.Center;
                style_math.Alignment = HorizontalAlignment.Right;
                IDataFormat dataformat = workbook.CreateDataFormat();
                style_math.DataFormat = dataformat.GetFormat("0.00;[Red]-0.00");

                ICellStyle style1 = workbook.CreateCellStyle();
                IFont font1 = workbook.CreateFont();
                font1.FontHeightInPoints = 8;
                font1.FontName = "宋体";
                style1.SetFont(font1);
                style1.BorderBottom = BorderStyle.Thin;
                style1.BorderLeft = BorderStyle.Thin;
                style1.BorderRight = BorderStyle.Thin;
                style1.BorderTop = BorderStyle.Thin;
                style1.VerticalAlignment = VerticalAlignment.Center;
                style1.Alignment = HorizontalAlignment.Right;

                model_HR_XZGL_FFJL = new HR_XZGL_FFJL();
                HR_XZGL_FFJL_SELECT rst_HR_XZGL_FFJLMX_SELECT_fycount = hrmodels.XZGL_FFJL.SELECT(model_HR_XZGL_FFJL, 3, token);
                if (rst_HR_XZGL_FFJLMX_SELECT_fycount.MES_RETURN.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT_fycount.MES_RETURN);
                }
                int fycount = Convert.ToInt32(rst_HR_XZGL_FFJLMX_SELECT_fycount.DATALIST.Rows[0][0].ToString());
                int rycount = 0;
                int fyno = 0;
                int hcount = 0;
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        hcount = hcount + 1;
                    }
                }
                hcount = hcount + 5;
                string DEPTNO = "";
                for (int a = 0; a < rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count; a++)
                {

                    cellIndex = 0;
                    if (dept == "")
                    {
                        fyno = 1;
                        rycount = 0;
                        rowcount = 0;
                        workbook.CreateSheet(dtinfo.Rows[a]["DEPTNAME"].ToString());
                        sheet = workbook.GetSheet(dtinfo.Rows[a]["DEPTNAME"].ToString());
                        sheet.FitToPage = false;
                        dept = dtinfo.Rows[a]["DEPTNAME"].ToString();
                        DEPTNO = dtinfo.Rows[a]["DEPTNO"].ToString();
                        sheet.SetColumnWidth(cellIndex++, 10 * 128);
                        sheet.SetColumnWidth(cellIndex++, 17 * 256);
                        sheet.SetColumnWidth(cellIndex++, 5 * 256);
                        sheet.SetColumnWidth(cellIndex++, 7 * 256);
                        sheet.SetColumnWidth(cellIndex++, 4 * 256);
                        for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                            {
                                sheet.SetColumnWidth(cellIndex++, rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].PRINTCD * 128);
                            }
                        }
                        cellIndex = 0;
                        IRow rowtt = sheet.CreateRow(rowcount++);
                        rowtt.CreateCell(hcount / 2).SetCellValue(PRINTNAME + "员工工资表");

                        rowtt = sheet.CreateRow(rowcount++);
                        rowtt.CreateCell(0).SetCellValue("部门：" + dept + "(" + DEPTNO.PadLeft(2, '0') + ")");
                        //rowtt.CreateCell(1).SetCellValue(dept);
                        rowtt.CreateCell(hcount / 2).SetCellValue(NY.Substring(0, 4) + "年" + NY.Substring(5, 2) + "月");
                        rowtt.CreateCell(hcount - 6).SetCellValue(GSNAME);
                        rowtt.CreateCell(hcount - 1).SetCellValue("第" + fyno.ToString() + "页");
                        fyno = fyno + 1;

                        rowtt = sheet.CreateRow(rowcount++);
                        rowtt.Height = 20 * 20;
                        for (int b = 0; b < ttlist.Length; b++)
                        {
                            rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[b]);
                            rowtt.GetCell(cellIndex - 1).CellStyle = style;
                        }
                        for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                            {
                                rowtt.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS);
                                rowtt.GetCell(cellIndex - 1).CellStyle = style;
                            }
                        }
                    }
                    else if (dept != dtinfo.Rows[a]["DEPTNAME"].ToString())
                    {
                        rycount = 0;
                        IRow rowline_hj = sheet.CreateRow(rowcount++);
                        rowline_hj.Height = 20 * 20;
                        cellIndex = 0;
                        rowline_hj.CreateCell(cellIndex++).SetCellValue("合计：");
                        rowline_hj.GetCell(cellIndex - 1).CellStyle = style;
                        rowline_hj.CreateCell(cellIndex++).SetCellValue("");
                        rowline_hj.GetCell(cellIndex - 1).CellStyle = style;
                        rowline_hj.CreateCell(cellIndex++).SetCellValue("");
                        rowline_hj.GetCell(cellIndex - 1).CellStyle = style;
                        rowline_hj.CreateCell(cellIndex++).SetCellValue("");
                        rowline_hj.GetCell(cellIndex - 1).CellStyle = style;
                        rowline_hj.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(drinfo["RYCOUNT"].ToString()));
                        rowline_hj.GetCell(cellIndex - 1).CellStyle = style;
                        for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                            {
                                rowline_hj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                                rowline_hj.GetCell(cellIndex - 1).CellStyle = style_math;
                            }
                        }
                        //fyno = 1;
                        cellIndex = 0;
                        drinfo = dtinfo.NewRow();
                        rowcount = 0;
                        workbook.CreateSheet(dtinfo.Rows[a]["DEPTNAME"].ToString());
                        sheet = workbook.GetSheet(dtinfo.Rows[a]["DEPTNAME"].ToString());
                        sheet.FitToPage = false;
                        dept = dtinfo.Rows[a]["DEPTNAME"].ToString();
                        DEPTNO = dtinfo.Rows[a]["DEPTNO"].ToString();
                        sheet.SetColumnWidth(cellIndex++, 10 * 128);
                        sheet.SetColumnWidth(cellIndex++, 17 * 256);
                        sheet.SetColumnWidth(cellIndex++, 5 * 256);
                        sheet.SetColumnWidth(cellIndex++, 7 * 256);
                        sheet.SetColumnWidth(cellIndex++, 4 * 256);
                        for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                            {
                                sheet.SetColumnWidth(cellIndex++, rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].PRINTCD * 128);
                            }
                        }

                        cellIndex = 0;
                        IRow rowtt = sheet.CreateRow(rowcount++);
                        rowtt.CreateCell(hcount / 2).SetCellValue(PRINTNAME + "员工工资表");

                        rowtt = sheet.CreateRow(rowcount++);
                        rowtt.CreateCell(0).SetCellValue("部门：" + dept + "(" + DEPTNO.PadLeft(2, '0') + ")");
                        //rowtt.CreateCell(1).SetCellValue(dept);
                        rowtt.CreateCell(hcount / 2).SetCellValue(NY.Substring(0, 4) + "年" + NY.Substring(5, 2) + "月");
                        rowtt.CreateCell(hcount - 6).SetCellValue(GSNAME);
                        rowtt.CreateCell(hcount - 1).SetCellValue("第" + fyno.ToString() + "页");
                        fyno = fyno + 1;

                        rowtt = sheet.CreateRow(rowcount++);
                        rowtt.Height = 20 * 20;
                        for (int b = 0; b < ttlist.Length; b++)
                        {
                            rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[b]);
                            rowtt.GetCell(cellIndex - 1).CellStyle = style;
                        }
                        for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                        {
                            if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                            {
                                rowtt.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS);
                                rowtt.GetCell(cellIndex - 1).CellStyle = style;
                            }
                        }
                    }
                    IRow rowline = sheet.CreateRow(rowcount++);
                    rowline.Height = 20 * 20;
                    cellIndex = 0;
                    //rowline.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[a]["YEARMONTH"].ToString());
                    rowline.CreateCell(cellIndex++).SetCellValue(NY.Substring(2, 2) + NY.Substring(5, 2));
                    rowline.GetCell(cellIndex - 1).CellStyle = style;
                    rowline.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[a]["BANKNO"].ToString());
                    rowline.GetCell(cellIndex - 1).CellStyle = style_BANKNO;
                    rowline.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[a]["GH"].ToString());
                    rowline.GetCell(cellIndex - 1).CellStyle = style;
                    rowline.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[a]["YGNAME"].ToString());
                    rowline.GetCell(cellIndex - 1).CellStyle = style;
                    rowline.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(dtinfo.Rows[a]["RYCOUNT"].ToString()));
                    rowline.GetCell(cellIndex - 1).CellStyle = style;
                    if (drinfo["RYCOUNT"].ToString() == "")
                    {
                        drinfo["RYCOUNT"] = 0;
                    }
                    drinfo["RYCOUNT"] = Convert.ToDecimal(drinfo["RYCOUNT"]) + Convert.ToDecimal(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[a]["RYCOUNT"].ToString());
                    if (drinfohj["RYCOUNT"].ToString() == "")
                    {
                        drinfohj["RYCOUNT"] = 0;
                    }
                    drinfohj["RYCOUNT"] = Convert.ToDecimal(drinfohj["RYCOUNT"]) + Convert.ToDecimal(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[a]["RYCOUNT"].ToString());
                    for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                    {
                        if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                        {
                            rowline.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                            rowline.GetCell(cellIndex - 1).CellStyle = style_math;
                        }
                        if (drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString() == "")
                        {
                            drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = 0;
                        }
                        drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = Convert.ToDecimal(drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME]) + Convert.ToDecimal(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString());
                        if (drinfohj[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString() == "")
                        {
                            drinfohj[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = 0;
                        }
                        drinfohj[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = Convert.ToDecimal(drinfohj[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME]) + Convert.ToDecimal(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[a][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString());

                    }
                    rycount = rycount + 1;
                    if ((rycount) >= (fycount))
                    {
                        sheet.SetRowBreak(rowcount - 1);
                        rycount = 0;
                        if (a < (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count - 1))
                        {
                            if (dtinfo.Rows[a]["DEPTNAME"].ToString() == dtinfo.Rows[a + 1]["DEPTNAME"].ToString())
                            {
                                rowline = sheet.CreateRow(rowcount++);
                                rowline.CreateCell(hcount / 2).SetCellValue(PRINTNAME + "员工工资表");
                                rowline = sheet.CreateRow(rowcount++);
                                rowline.CreateCell(0).SetCellValue("部门：" + dept + "(" + DEPTNO.PadLeft(2, '0') + ")");
                                //rowline.CreateCell(1).SetCellValue(dept);
                                rowline.CreateCell(hcount / 2).SetCellValue(NY.Substring(0, 4) + "年" + NY.Substring(5, 2) + "月");
                                rowline.CreateCell(hcount - 6).SetCellValue(GSNAME);
                                rowline.CreateCell(hcount - 1).SetCellValue("第" + fyno.ToString() + "页");

                                rowline = sheet.CreateRow(rowcount++);
                                cellIndex = 0;
                                for (int b = 0; b < ttlist.Length; b++)
                                {
                                    rowline.CreateCell(cellIndex++).SetCellValue(ttlist[b]);
                                    rowline.GetCell(cellIndex - 1).CellStyle = style;
                                }
                                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                                {
                                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                                    {
                                        rowline.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS);
                                        rowline.GetCell(cellIndex - 1).CellStyle = style;
                                    }
                                }
                                fyno = fyno + 1;
                            }
                        }
                    }
                }
                IRow rowline_hj2 = sheet.CreateRow(rowcount++);
                rowline_hj2.Height = 20 * 20;
                cellIndex = 0;
                rowline_hj2.CreateCell(cellIndex++).SetCellValue("合计：");
                rowline_hj2.GetCell(cellIndex - 1).CellStyle = style;
                rowline_hj2.CreateCell(cellIndex++).SetCellValue("");
                rowline_hj2.GetCell(cellIndex - 1).CellStyle = style;
                rowline_hj2.CreateCell(cellIndex++).SetCellValue("");
                rowline_hj2.GetCell(cellIndex - 1).CellStyle = style;
                rowline_hj2.CreateCell(cellIndex++).SetCellValue("");
                rowline_hj2.GetCell(cellIndex - 1).CellStyle = style;
                rowline_hj2.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(drinfo["RYCOUNT"].ToString()));
                rowline_hj2.GetCell(cellIndex - 1).CellStyle = style;
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        rowline_hj2.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                        rowline_hj2.GetCell(cellIndex - 1).CellStyle = style_math;
                    }
                }

                cellIndex = 0;
                rowcount = 0;
                workbook.CreateSheet("合计");
                sheet = workbook.GetSheet("合计");
                sheet.FitToPage = false;
                cellIndex = 0;
                IRow rowhj = sheet.CreateRow(rowcount++);
                for (int b = 0; b < ttlist.Length; b++)
                {
                    rowhj.CreateCell(cellIndex++).SetCellValue(ttlist[b]);
                    rowhj.GetCell(cellIndex - 1).CellStyle = style;
                }
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        rowhj.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDMS);
                        rowhj.GetCell(cellIndex - 1).CellStyle = style;
                    }
                }
                rowhj = sheet.CreateRow(rowcount++);
                cellIndex = 0;
                rowhj.CreateCell(cellIndex++).SetCellValue("合计：");
                rowhj.GetCell(cellIndex - 1).CellStyle = style;
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.GetCell(cellIndex - 1).CellStyle = style;
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.GetCell(cellIndex - 1).CellStyle = style;
                rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.GetCell(cellIndex - 1).CellStyle = style;
                rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(drinfohj["RYCOUNT"].ToString()));
                rowhj.GetCell(cellIndex - 1).CellStyle = style;
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfohj[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                        rowhj.GetCell(cellIndex - 1).CellStyle = style_math;
                    }
                }

                cellIndex = 0;
                sheet.AutoSizeColumn(cellIndex++);
                sheet.AutoSizeColumn(cellIndex++);
                sheet.AutoSizeColumn(cellIndex++);
                sheet.AutoSizeColumn(cellIndex++);
                sheet.AutoSizeColumn(cellIndex++);
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        sheet.AutoSizeColumn(cellIndex++);
                    }
                }


                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_FFJLMX_FFMXGZHZREPORT(string datastring, string datastring1, string NY, string PRINTNAME)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT_FFMXGZHZREPORT(model_HR_XZGL_FFJLMX, token);
            if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
            }
            if (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无数据！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            HR_XZGL_MBGLMX model_HR_XZGL_MBGLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_MBGLMX>(datastring1);
            HR_XZGL_MBGLMX_SELECT rst_HR_XZGL_MBGLMX_SELECT = hrmodels.XZGL_MBGLMX.SELECT(model_HR_XZGL_MBGLMX, token);
            if (rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGLMX_SELECT.MES_RETURN);
            }
            HR_XZGL_FFJL model_HR_XZGL_FFJL = new HR_XZGL_FFJL();
            model_HR_XZGL_FFJL.FFJLID = model_HR_XZGL_FFJLMX.FFJLID;
            model_HR_XZGL_FFJL.MYPW = model_HR_XZGL_FFJLMX.MYPW;
            model_HR_XZGL_FFJL.STAFFID = STAFFID;
            HR_XZGL_FFJL_SELECT rst_HR_XZGL_FFJL_SELECT = hrmodels.XZGL_FFJL.SELECT(model_HR_XZGL_FFJL, 1, token);
            if (rst_HR_XZGL_FFJL_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJL_SELECT.MES_RETURN);
            }
            string GSNAME = "";
            string GS = "";
            if (rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows.Count > 0)
            {
                GSNAME = rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows[0]["GSNAME"].ToString();
                GS = rst_HR_XZGL_FFJL_SELECT.DATALIST.Rows[0]["GS"].ToString();
            }
            HR_XZGL_MBGL model_HR_XZGL_MBGL = new HR_XZGL_MBGL();
            model_HR_XZGL_MBGL.MBID = model_HR_XZGL_MBGLMX.MBID;
            model_HR_XZGL_MBGL.STAFFID = STAFFID;
            HR_XZGL_MBGL_SELECT rst_HR_XZGL_MBGL_SELECT = hrmodels.XZGL_MBGL.SELECT(model_HR_XZGL_MBGL, token);
            if (rst_HR_XZGL_MBGL_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_MBGL_SELECT.MES_RETURN);
            }
            string MBNAME = "";
            if (rst_HR_XZGL_MBGL_SELECT.HR_XZGL_MBGL_LIST.Length > 0)
                MBNAME = rst_HR_XZGL_MBGL_SELECT.HR_XZGL_MBGL_LIST[0].MBNAME;

            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);

                ICellStyle style2 = workbook.CreateCellStyle();
                IFont font = workbook.CreateFont();
                font.FontHeightInPoints = 9;
                font.FontName = "宋体";
                style2.SetFont(font);
                style2.BorderBottom = BorderStyle.Thin;
                style2.BorderLeft = BorderStyle.Thin;
                style2.BorderRight = BorderStyle.Thin;
                style2.BorderTop = BorderStyle.Thin;
                style2.VerticalAlignment = VerticalAlignment.Center;
                style2.Alignment = HorizontalAlignment.Left;


                ICellStyle style1 = workbook.CreateCellStyle();
                font = workbook.CreateFont();
                font.FontHeightInPoints = 9;
                font.FontName = "宋体";
                style1.SetFont(font);
                style1.BorderBottom = BorderStyle.Thin;
                style1.BorderLeft = BorderStyle.Thin;
                style1.BorderRight = BorderStyle.Thin;
                style1.BorderTop = BorderStyle.Thin;
                style1.VerticalAlignment = VerticalAlignment.Center;
                style1.Alignment = HorizontalAlignment.Center;

                ICellStyle style3 = workbook.CreateCellStyle();
                font = workbook.CreateFont();
                font.FontHeightInPoints = 9;
                font.FontName = "宋体";
                style3.SetFont(font);
                style3.BorderBottom = BorderStyle.Thin;
                style3.BorderLeft = BorderStyle.Thin;
                style3.BorderRight = BorderStyle.Thin;
                style3.BorderTop = BorderStyle.Thin;
                style3.VerticalAlignment = VerticalAlignment.Center;
                style3.Alignment = HorizontalAlignment.Right;
                IDataFormat dataformat = workbook.CreateDataFormat();
                style3.DataFormat = dataformat.GetFormat("0.00;[Red]-0.00");



                int rowcount = 0;
                int cellIndex = 0;
                string tt = "部门,人数";
                string[] ttlist = tt.Split(',');
                sheet.SetColumnWidth(cellIndex++, 18 * 256);
                sheet.SetColumnWidth(cellIndex++, 5 * 256);
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        sheet.SetColumnWidth(cellIndex++, rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].PRINTCD * 128);
                    }
                }
                IRow rowtt = sheet.CreateRow(rowcount++);
                rowtt.Height = 13 * 20;
                rowtt.CreateCell(5).SetCellValue(GSNAME);
                rowtt.CreateCell(9).SetCellValue(NY.Substring(0, 4) + "年" + NY.Substring(5, 2) + "月");
                rowtt.CreateCell(11).SetCellValue(PRINTNAME + "员工工资汇总表");
                //rowtt.CreateCell(14).SetCellValue(DateTime.Now.ToString("yyyy") + "年" + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日");
                rowtt = sheet.CreateRow(rowcount++);
                cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                    rowtt.GetCell(cellIndex - 1).CellStyle = style1;
                }
                for (int a = 0; a < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; a++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].MXID == 1)
                    {
                        rowtt.CreateCell(cellIndex++).SetCellValue(rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[a].FFJLZDMS);
                        rowtt.GetCell(cellIndex - 1).CellStyle = style1;
                    }
                }
                DataTable dtinfo = rst_HR_XZGL_FFJLMX_SELECT.DATALIST;
                DataRow drinfo = dtinfo.NewRow();
                for (int i = 0; i < rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.Height = 13 * 20;
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.GetCell(cellIndex - 1).CellStyle = style2;
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(dtinfo.Rows[i]["RYCOUNT"].ToString()));
                    row.GetCell(cellIndex - 1).CellStyle = style2;
                    if (drinfo["RYCOUNT"].ToString() == "")
                    {
                        drinfo["RYCOUNT"] = 0;
                    }
                    drinfo["RYCOUNT"] = Convert.ToDecimal(drinfo["RYCOUNT"]) + Convert.ToDecimal(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[i]["RYCOUNT"].ToString());
                    for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                    {
                        if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                        {
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[i][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                            row.GetCell(cellIndex - 1).CellStyle = style3;
                            if (drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString() == "")
                            {
                                drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = 0;
                            }
                            drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME] = Convert.ToDecimal(drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME]) + Convert.ToDecimal(rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows[i][rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString());
                        }
                    }
                }
                cellIndex = 0;
                IRow rowhj = sheet.CreateRow(rowcount++);
                rowhj.CreateCell(cellIndex++).SetCellValue("合计：");
                rowhj.GetCell(cellIndex - 1).CellStyle = style2;
                //rowhj.CreateCell(cellIndex++).SetCellValue("");
                rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(drinfo["RYCOUNT"].ToString()));
                rowhj.GetCell(cellIndex - 1).CellStyle = style2;
                for (int b = 0; b < rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX.Length; b++)
                {
                    if (rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].MXID == 1)
                    {
                        rowhj.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(drinfo[rst_HR_XZGL_MBGLMX_SELECT.HR_XZGL_MBGLMX[b].FFJLZDNAME].ToString()));
                        rowhj.GetCell(cellIndex - 1).CellStyle = style3;
                    }
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_FFJLMX_FFMXTXFREPORT(string datastring, int LB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJLMX>(datastring);
            model_HR_XZGL_FFJLMX.STAFFID = STAFFID;
            HR_XZGL_FFJLMX_SELECT rst_HR_XZGL_FFJLMX_SELECT = hrmodels.XZGL_FFJLMX.SELECT_FFMXTXFREPORT(model_HR_XZGL_FFJLMX, LB, token);
            if (rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_XZGL_FFJLMX_SELECT.MES_RETURN);
            }
            try
            {
                if (rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count > 0)
                {
                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 0;
                    string tt = "";
                    if (LB == 1)
                    {
                        tt = "工号,姓名,部门,通讯费";
                    }
                    else if (LB == 2)
                    {
                        tt = "部门,人数,通讯费";
                    }
                    else if (LB == 3)
                    {
                        tt = "工号,姓名,部门,高温津贴";
                    }
                    else
                    {
                        tt = "部门,人数,高温津贴";
                    }
                    string[] ttlist = tt.Split(',');
                    IRow rowtt = sheet.CreateRow(rowcount++);
                    int cellIndex = 0;
                    for (int a = 0; a < ttlist.Length; a++)
                    {
                        rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                    }
                    DataTable dtinfo = rst_HR_XZGL_FFJLMX_SELECT.DATALIST;
                    for (int i = 0; i < rst_HR_XZGL_FFJLMX_SELECT.DATALIST.Rows.Count; i++)
                    {
                        cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        if (LB == 1 || LB == 3)
                        {
                            row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                            row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                            row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["TXF"].ToString()));
                        }
                        else
                        {
                            row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["RYCOUNT"].ToString()));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["TXF"].ToString()));
                        }
                    }
                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now;
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "无数据！";
                }
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_DOWNLOAD_mb(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xlsx");
        }
        public ActionResult EXPORT_DOWNLOAD_mb_xls(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xls");
        }
        [HttpPost]
        public string GET_MONTH_LASTDAY(string MONTH)
        {
            MONTH = MONTH.Replace('"', ' ');
            DateTime dtime = Convert.ToDateTime(MONTH.Trim() + "-01");
            dtime = dtime.AddMonths(1);
            dtime = dtime.AddDays(-1);
            return dtime.ToString("yyyy-MM-dd");
        }
        [HttpPost]
        public string XZGL_JJFL_HEARNAME_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_HEARNAME model_HR_XZGL_JJFL_HEARNAME = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_HEARNAME>(datastring);
            model_HR_XZGL_JJFL_HEARNAME.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_JJFL_HEARNAME.INSERT(model_HR_XZGL_JJFL_HEARNAME, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_JJFL_HEARNAME_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_HEARNAME model_HR_XZGL_JJFL_HEARNAME = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_HEARNAME>(datastring);
            model_HR_XZGL_JJFL_HEARNAME.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_JJFL_HEARNAME.UPDATE(model_HR_XZGL_JJFL_HEARNAME, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_JJFL_HEARNAME_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_XZGL_JJFL_HEARNAME model_HR_XZGL_JJFL_HEARNAME = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_HEARNAME>(datastring);
            HR_XZGL_JJFL_HEARNAME_SELECT rst = hrmodels.XZGL_JJFL_HEARNAME.SELECT(model_HR_XZGL_JJFL_HEARNAME, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_JJFL_HEAD_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_HEAD model_HR_XZGL_JJFL_HEAD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_HEAD>(datastring);
            model_HR_XZGL_JJFL_HEAD.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_JJFL_HEAD.INSERT(model_HR_XZGL_JJFL_HEAD, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_JJFL_HEAD_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_HEAD model_HR_XZGL_JJFL_HEAD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_HEAD>(datastring);
            model_HR_XZGL_JJFL_HEAD.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_JJFL_HEAD.UPDATE(model_HR_XZGL_JJFL_HEAD, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_JJFL_HEAD_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_HEAD model_HR_XZGL_JJFL_HEAD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_HEAD>(datastring);
            model_HR_XZGL_JJFL_HEAD.STAFFID = STAFFID;
            HR_XZGL_JJFL_HEAD_SELECT rst = hrmodels.XZGL_JJFL_HEAD.SELECT(model_HR_XZGL_JJFL_HEAD, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_JJFL_HEAD(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_HEAD model_HR_XZGL_JJFL_HEAD = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_HEAD>(datastring);
            model_HR_XZGL_JJFL_HEAD.STAFFID = STAFFID;
            HR_XZGL_JJFL_HEAD_SELECT result = hrmodels.XZGL_JJFL_HEAD.SELECT(model_HR_XZGL_JJFL_HEAD, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "状态,奖金福利名称,计发月份,公司,计发部门,人数,奖金合计,爱岗敬业奖";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = result.DATALIST;
                for (int i = 0; i < dtinfo.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    if (dtinfo.Rows[i]["ISACTION"].ToString() == "1")
                    {
                        row.CreateCell(cellIndex++).SetCellValue("正常");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("结案");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["JJFLNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["SBMONTH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JLCOUNT"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JJHJ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["AIGJYJ"].ToString()));
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_JJFL_MX_INSERT(string datastring, string datastring1)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_MX model_HR_XZGL_JJFL_MX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_MX>(datastring);
            DataTable RYLIST = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(datastring1);
            RYLIST.TableName = "DataTable";
            model_HR_XZGL_JJFL_MX.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_JJFL_MX.INSERT(model_HR_XZGL_JJFL_MX, RYLIST, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_JJFL_MX_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_MX model_HR_XZGL_JJFL_MX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_MX>(datastring);
            model_HR_XZGL_JJFL_MX.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_JJFL_MX.UPDATE(model_HR_XZGL_JJFL_MX, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_JJFL_MX_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_MX model_HR_XZGL_JJFL_MX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_MX>(datastring);
            //model_HR_XZGL_JJFL_HEAD.STAFFID = STAFFID;
            HR_XZGL_JJFL_MX_SELECT rst = hrmodels.XZGL_JJFL_MX.SELECT(model_HR_XZGL_JJFL_MX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_JJFL_MX(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_MX model_HR_XZGL_JJFL_MX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_MX>(datastring);
            HR_XZGL_JJFL_MX_SELECT result = hrmodels.XZGL_JJFL_MX.SELECT(model_HR_XZGL_JJFL_MX, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,员工类别,在职状态,证照号码,银行卡号,出勤,加班,绩效奖金,加班工资,奖金合计,爱岗敬业奖,借出部门,计发部门,平常加班,周末加班";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = result.DATALIST;
                for (int i = 0; i < dtinfo.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZZTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["BANKNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["CHUQCOUNT"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JIABCOUNT"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JXJJ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JIABGZ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JJHJ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["AIGJYJ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["JCDEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JBPC"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JBZM"].ToString()));
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_JJFL_MX1(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_JJFL_MX model_HR_XZGL_JJFL_MX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_JJFL_MX>(datastring);
            HR_XZGL_JJFL_MX_SELECT result = hrmodels.XZGL_JJFL_MX.SELECT(model_HR_XZGL_JJFL_MX, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "计发月份,工号,姓名,公司,计发部门,员工类别,证照号码,银行卡号,出勤,加班,绩效奖金,加班工资,奖金合计,爱岗敬业奖,借出部门";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = result.DATALIST;
                for (int i = 0; i < dtinfo.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["SBMONTH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["BANKNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["CHUQCOUNT"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JIABCOUNT"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JXJJ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JIABGZ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JJHJ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["AIGJYJ"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["JCDEPTNAME"].ToString());
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJL_ZQMONTH_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJL model_HR_XZGL_FFJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJL>(datastring);
            model_HR_XZGL_FFJL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.XZGL_FFJL.ZQMONTH_UPDATE(model_HR_XZGL_FFJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJL_ZQMONTH_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJL model_HR_XZGL_FFJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJL>(datastring);
            model_HR_XZGL_FFJL.STAFFID = STAFFID;
            HR_XZGL_FFJL_SELECT rst = hrmodels.XZGL_FFJL.ZQMONTH_SELECT(model_HR_XZGL_FFJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string XZGL_FFJL_ZQMONTH_SELECT_LB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJL model_HR_XZGL_FFJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJL>(datastring);
            model_HR_XZGL_FFJL.STAFFID = STAFFID;
            HR_XZGL_FFJL_SELECT rst = hrmodels.XZGL_FFJL.ZQMONTH_SELECT_LB(model_HR_XZGL_FFJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_XZGL_FFJL_ZQMONTH_LB(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJL model_HR_XZGL_FFJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJL>(datastring);
            HR_XZGL_FFJL_SELECT result = hrmodels.XZGL_FFJL.ZQMONTH_SELECT_LB(model_HR_XZGL_FFJL, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            if (result.DATALIST.Rows.Count == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无相关数据！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = result.DATALIST;
                for (int i = 0; i < dtinfo.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_XZGL_FFJL_ZQMONTH_LB2(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_FFJL model_HR_XZGL_FFJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_FFJL>(datastring);
            HR_XZGL_FFJL_SELECT result = hrmodels.XZGL_FFJL.ZQMONTH_SELECT_LB(model_HR_XZGL_FFJL, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            if (result.DATALIST.Rows.Count == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无相关数据！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,证件号码,公司,入职日期,离职日期,人数,员工类别,部门,归属部门,归属成本中心,手机号码";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = result.DATALIST;
                for (int i = 0; i < dtinfo.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["RZDATE"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LZRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(dtinfo.Rows[i]["RYCOUNT"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSBMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTCBZX_GS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["PHONENUMBER"].ToString());
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_XZGL_FFJL_MESSAGELIST(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            List<MES_RETURN_UI> result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MES_RETURN_UI>>(datastring);
            if (result.Count == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无相关数据！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "消息类型，消息描述";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < result.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(result[i].TYPE);
                    row.CreateCell(cellIndex++).SetCellValue(result[i].MESSAGE);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
    }
}