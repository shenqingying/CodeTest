using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.API.SDK;
using Sonluk.API.SDK.Address;
using Sonluk.API.SDK.Http;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.MES.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.HG_DEPTService;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.EM.SY_STAFF_EMTYPEService;
using Sonluk.UI.Model.HR.ROLE_DEPTService;
using Sonluk.UI.Model.HR.SY_GSService;
using Sonluk.UI.Model.MES.MES_FJService;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.ROLE_ASSEMBLEService;
using Sonluk.UI.Model.MES.ROLE_CKService;
using Sonluk.UI.Model.MES.ROLE_GCService;
using Sonluk.UI.Model.MES.ROLE_GZZXService;
using Sonluk.UI.Model.MES.ROLE_RY_ASSEMBLEService;
using Sonluk.UI.Model.MES.ROLR_GZZX_GWService;
using Sonluk.UI.Model.MES.SY_DCXH_COUNTService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBH_WLLBService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZX_WLLBService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_MACHINEINFOService;
using Sonluk.UI.Model.MES.SY_MATERIAL_BZCOUNTservice;
using Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService;
using Sonluk.UI.Model.MES.SY_MATERIALService;
using Sonluk.UI.Model.MES.SY_PFDH_CHILDService;
using Sonluk.UI.Model.MES.SY_PFDH_WLService;
using Sonluk.UI.Model.MES.SY_PFDHService;
using Sonluk.UI.Model.MES.SY_PLDHService;
using Sonluk.UI.Model.MES.SY_RYGHService;
using Sonluk.UI.Model.MES.SY_STAFFService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.SY_TYPEService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Mvc;
using System.Web.Security;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class SystemController : Controller
    {
        //
        // GET: /MES/System/
        string HRFile = System.Configuration.ConfigurationManager.AppSettings["HRFile"];
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        MESModels mesModels = new MESModels();
        CRMModels crmModels = new CRMModels();
        HRModels hrmodels = new HRModels();
        EMModel emModel = new EMModel();
        SHttp sHttp = new SHttp();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DataGather()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 100);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_TYPE[] sjlb = mesModels.SY_TYPE.SELECT(token);
            MES_SY_GC gcmc = new MES_SY_GC();
            gcmc.STAFFID = STAFFID;
            MES_SY_GC[] gcsj = mesModels.SY_GC.read(gcmc, token);
            MODLEDataGather zd_data = new MODLEDataGather();

            zd_data.Sy_type = sjlb;
            zd_data.Sy_gc = gcsj;
            ViewData.Model = zd_data;
            MES_SY_TYPEMX languMXmodel = new MES_SY_TYPEMX();
            languMXmodel.TYPEID = 26;
            MES_SY_TYPEMXLIST[] langulist = mesModels.SY_TYPEMX.SELECT(languMXmodel, token);

            ViewBag.langulist = langulist;


            return View();
        }
        public ActionResult SY_LANGUAGE_MANAGE()
        {
            AppClass.SetSession("location", 10021);
            return View();
        }
        public ActionResult PLDH_MANAGE()
        {
            AppClass.SetSession("location", 10022);
            return View();
        }
        public ActionResult RY_MANAGE()
        {
            AppClass.SetSession("location", 10029);
            return View();
        }
        public ActionResult SY_CN_MANAGE()
        {
            AppClass.SetSession("location", 242);
            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult SY_CN_SELECT()
        {
            AppClass.SetSession("location", 243);
            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult SY_GYLX_MANAGE()
        {
            AppClass.SetSession("location", 244);
            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult SY_GYLX_SELECT()
        {
            AppClass.SetSession("location", 245);
            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult SY_GZZX_SBBH_STATUS()
        {
            AppClass.SetSession("location", 249);
            ViewData.Model = MvcModel();
            return View();
        }
        public ActionResult SY_GZZX_SBBH_STATUS_SELECT()
        {
            AppClass.SetSession("location", 250);
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

        [HttpPost]
        public string Data_Select_DG(string GC, int TYPEID, string MXNAME)
        {
            string token = Session["token"].ToString();
            MES_SY_TYPEMX MX = new MES_SY_TYPEMX();
            MX.GC = GC;
            MX.TYPEID = TYPEID;
            MX.MXNAME = MXNAME;
            MES_SY_TYPEMXLIST[] data = mesModels.SY_TYPEMX.SELECT(MX, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Insert_DG(string data)
        {
            string token = Session["token"].ToString();
            MES_SY_TYPEMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_TYPEMX>(data);
            MES_RETURN_UI i = mesModels.SY_TYPEMX.INSERT(model, token);
            string add = Newtonsoft.Json.JsonConvert.SerializeObject(i);
            return add;
        }

        [HttpPost]
        public string Data_Update_DG(string data)
        {

            string token = Session["token"].ToString();

            MES_SY_TYPEMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_TYPEMX>(data);
            MES_RETURN_UI s = mesModels.SY_TYPEMX.UPDATE(model, token);
            string xg = Newtonsoft.Json.JsonConvert.SerializeObject(s);
            return xg;
        }

        [HttpPost]
        public string Data_Delete_DG(int ID)
        {
            string token = Session["token"].ToString();

            MES_RETURN_UI i = mesModels.SY_TYPEMX.DELETE(ID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(i);
            return s;
        }

        public ActionResult FactoryManage()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 101);

            MES_SY_GC gczx = new MES_SY_GC();
            gczx.STAFFID = STAFFID;
            MES_SY_GC[] gcsj = mesModels.SY_GC.read(gczx, token);
            ViewData.Model = gcsj;
            return View();
        }

        [HttpPost]
        public string Data_Select_GC()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();

            MES_SY_GC model = new MES_SY_GC();
            model.STAFFID = STAFFID;
            MES_SY_GC[] data = mesModels.SY_GC.read(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_GC_ROLE()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();

            MES_SY_GC model = new MES_SY_GC();
            model.STAFFID = STAFFID;
            MES_SY_GC[] data = mesModels.SY_GC.SELECT_BY_ROLE(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Insert_GC(string data)
        {
            string token = Session["token"].ToString();

            MES_SY_GC model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GC>(data);
            MES_RETURN_UI s = mesModels.SY_GC.insert(model, token);
            string ss = Newtonsoft.Json.JsonConvert.SerializeObject(s);
            return ss;

        }

        [HttpPost]
        public string Data_Update_GC(string data)
        {
            string token = Session["token"].ToString();

            MES_SY_GC model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GC>(data);
            MES_RETURN_UI s = mesModels.SY_GC.UPDATE(model, token);
            string ss = Newtonsoft.Json.JsonConvert.SerializeObject(s);
            return ss;

        }

        [HttpPost]
        public string Data_Delete_GC(string GC)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_RETURN_UI i = mesModels.SY_GC.delete(GC, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(i);
            return s;
        }

        public ActionResult WorkCenter()
        {
            AppClass.SetSession("location", 102);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GC gcmc = new MES_SY_GC();
            gcmc.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesModels.SY_GC.SELECT_BY_ROLE(gcmc, token);
            MES_SY_GZZX zxcx = new MES_SY_GZZX();
            zxcx.STAFFID = STAFFID;
            MES_SY_GZZX[] cx = mesModels.SY_GZZX.SELECT(zxcx, token);
            MES_SY_TYPEMX cxmx = new MES_SY_TYPEMX();
            cxmx.TYPEID = 1;
            MES_SY_TYPEMXLIST[] mx = mesModels.SY_TYPEMX.SELECT(cxmx, token);
            MES_ROLE_ASSEMBLE gzz = new MES_ROLE_ASSEMBLE();
            gzz.ROLELB = 2;
            MES_ROLE_ASSEMBLE_SELECT gz = mesModels.ROLE_ASSEMBLE.SELECT(gzz, token);
            MODLEDataGather zd_data = new MODLEDataGather();
            zd_data.Role_assemble_select = gz;
            zd_data.Sy_gc = gc;
            zd_data.Sy_gzzx = cx;
            zd_data.Sy_typemxlist = mx;
            ViewData.Model = zd_data;


            return View();
        }


        [HttpPost]
        public string Data_Select_CX(string GC, string GZZXBH)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GZZX CX = new MES_SY_GZZX();
            CX.GC = GC;
            CX.GZZXBH = GZZXBH;
            CX.STAFFID = STAFFID;
            MES_SY_GZZX[] data = mesModels.SY_GZZX.SELECT(CX, token);
            string c = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return c;
        }

        [HttpPost]
        public string Data_Select_CX_ROLE(string GC)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GZZX CX = new MES_SY_GZZX();
            CX.GC = GC;
            CX.STAFFID = STAFFID;
            MES_SY_GZZX[] data = mesModels.SY_GZZX.SELECT_BY_ROLE(CX, token);
            string c = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return c;
        }


        [HttpPost]
        public string Data_Select_CX_LB(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GZZX model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_GZZX[] data = mesModels.SY_GZZX.SELECT_LB(model, token);
            string c = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return c;
        }

        [HttpPost]
        public string Data_Insert_GZ(string data)
        {
            string token = Session["token"].ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_SY_GZZX model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX>(data);
            model.STAFFID = STAFFID;
            MES_RETURN_UI s = mesModels.SY_GZZX.INSERT(model, token);
            string ss = Newtonsoft.Json.JsonConvert.SerializeObject(s);
            return ss;

        }
        [HttpPost]
        public string Data_Update_GZ(string data)
        {
            string token = Session["token"].ToString();

            MES_SY_GZZX model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX>(data);
            MES_RETURN_UI s = mesModels.SY_GZZX.UPDATE(model, token);
            string ss = Newtonsoft.Json.JsonConvert.SerializeObject(s);
            return ss;
        }
        [HttpPost]
        public string Data_Delete_GZ(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_SY_GZZX model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX>(data);
            model.STAFFID = STAFFID;
            MES_RETURN_UI i = mesModels.SY_GZZX.DELETE(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(i);
            return s;
        }

        [HttpPost]
        public string Data_Select_WLLB(string GC, string GZZXBH)
        {
            string token = Session["token"].ToString();

            MES_SY_GZZX_WLLB wllb = new MES_SY_GZZX_WLLB();
            wllb.GZZXBH = GZZXBH;
            wllb.GC = GC;
            MES_SY_GZZX_WLLB_SELECT data = mesModels.SY_GZZX_WLLB.SELECT(wllb, token);
            string w = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return w;
        }
        [HttpPost]
        public string Data_Select_WLLBFP(string GC, string GZZXBH)
        {
            string token = Session["token"].ToString();
            MES_SY_GZZX_WLLB wlfp = new MES_SY_GZZX_WLLB();
            wlfp.GC = GC;
            wlfp.GZZXBH = GZZXBH;

            MES_SY_GZZX_WLLB_SELECT_LAY data = mesModels.SY_GZZX_WLLB.SELECT_LAY(wlfp, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Update_WLLBFP(string GC, string GZZXBH, string wllbdata)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GZZX_WLLB wlfp = new MES_SY_GZZX_WLLB();
            wlfp.GC = GC;
            wlfp.GZZXBH = GZZXBH;
            MES_SY_GZZX_WLLB[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX_WLLB[]>(wllbdata);
            //MES_SY_GZZX_WLLB wlfp=new MES_SY_GZZX_WLLB();
            //wlfp.GC = GC;
            //wlfp.GZZXBH = GZZXBH;
            //wlfp.WLLBID = WLLBID;
            mesModels.SY_GZZX_WLLB.DELETE(wlfp, token);
            MES_RETURN_UI data = mesModels.SY_GZZX_WLLB.INSERT_LIST(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return u;
        }
        [HttpPost]
        public string GET_SAP_GZZX(string GC)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_RETURN_UI SAP_GZZX = mesModels.MES_SYNC.MES_SYNC_GZZX(GC, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(SAP_GZZX);
            return rst;
        }
        public ActionResult DeviceManage()
        {
            AppClass.SetSession("location", 103);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GZZX gzzx = new MES_SY_GZZX();
            MES_SY_GZZX[] zx = mesModels.SY_GZZX.SELECT(gzzx, token);
            MES_SY_GZZX_SBH sbh = new MES_SY_GZZX_SBH();
            MES_SY_GZZX_SBH[] sb = mesModels.SY_GZZX_SBH.SELECT_ALL(sbh, token);
            MES_SY_GC gc = new MES_SY_GC();
            gc.STAFFID = STAFFID;
            MES_SY_GC[] gcid = mesModels.SY_GC.SELECT_BY_ROLE(gc, token);
            MES_SY_TYPEMX sbfl = new MES_SY_TYPEMX();
            sbfl.TYPEID = 14;
            MES_SY_TYPEMXLIST[] fl = mesModels.SY_TYPEMX.SELECT(sbfl, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gcid;
            data.Sy_gzzx = zx;
            data.Sy_gzzx_sbh = sb;
            data.Sy_typemxlist = fl;
            ViewData.Model = data;


            return View();
        }


        [HttpPost]
        public string Data_Select_Device(string GZZXBH, string GC, string WLLBNAME, string SBBH)
        {

            string token = Session["token"].ToString();

            MES_SY_GZZX_SBH sbh = new MES_SY_GZZX_SBH();
            sbh.GZZXBH = GZZXBH;
            sbh.GC = GC;
            sbh.WLLBNAME = WLLBNAME;
            sbh.SBBH = SBBH;
            MES_SY_GZZX_SBH[] data = mesModels.SY_GZZX_SBH.SELECT_ALL(sbh, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_Device_LB(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            MES_SY_GZZX_SBH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX_SBH>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_GZZX_SBH_SELECT data = mesModels.SY_GZZX_SBH.SELECT_LB(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Insert_Device(string data)
        {
            string token = Session["token"].ToString();

            MES_SY_GZZX_SBH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX_SBH>(data);
            MES_RETURN_UI i = mesModels.SY_GZZX_SBH.INSERT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(i);

            return s;
        }
        [HttpPost]
        public string Data_Update_Device(string data)
        {
            string token = Session["token"].ToString();

            MES_SY_GZZX_SBH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX_SBH>(data);
            MES_RETURN_UI d = mesModels.SY_GZZX_SBH.UPDATE(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(d);

            return s;
        }
        [HttpPost]
        public string Data_Delete_Device(string SBBH)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_RETURN_UI d = mesModels.SY_GZZX_SBH.DELETE(SBBH, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(d);

            return s;
        }
        [HttpPost]
        public string Data_Select_SBWLLB(string SBBH)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GZZX_SBH_WLLB wllb = new MES_SY_GZZX_SBH_WLLB();
            wllb.SBBH = SBBH;
            MES_SY_GZZX_SBH_WLLB_SELECT data = mesModels.SY_GZZX_SBH_WLLB.SELECT(wllb, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Update_SBWLLB(string SBBH, string sbdata)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GZZX_SBH_WLLB wllb = new MES_SY_GZZX_SBH_WLLB();
            wllb.SBBH = SBBH;
            MES_SY_GZZX_SBH_WLLB[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX_SBH_WLLB[]>(sbdata);
            mesModels.SY_GZZX_SBH_WLLB.DELETE(wllb, token);
            MES_RETURN_UI data = mesModels.SY_GZZX_SBH_WLLB.INSERT_LIST(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return u;
        }
        [HttpPost]
        public string Data_Select_SBWLLBFP(string SBBH)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GZZX_SBH_WLLB_SELECT data = mesModels.SY_GZZX_SBH_WLLB.SELECT_LAY(SBBH, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_Role_EMTYPE(int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_EMTYPE_LAY_SELECT s = emModel.SY_STAFF_EMTYPE.SELECT_EMTYPE_ROLE(STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(s); ;
        }
        public ActionResult WorkCenterRole()
        {
            AppClass.SetSession("location", 104);
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GC wcr = new MES_SY_GC();
            MES_SY_GC[] gzzx = mesModels.SY_GC.read(wcr, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gzzx;
            ViewData.Model = data;

            return View();
        }

        [HttpPost]
        public string Data_Select_ZRole(string GC)
        {
            string token = Session["token"].ToString();
            MES_ROLE_ASSEMBLE model = new MES_ROLE_ASSEMBLE();
            model.GC = GC;
            model.ROLELB = 1;
            MES_ROLE_ASSEMBLE_SELECT data = mesModels.ROLE_ASSEMBLE.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }


        [HttpPost]
        public string Data_Select_GZZXbyroleid(int ROLEID)       //根据权限ID找出工作中心
        {
            string token = Session["token"].ToString();

            MES_ROLE_GZZX_SELECT_BYROLEID data = mesModels.ROLE_GZZX.SELECT_BYROLEID(ROLEID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }


        [HttpPost]
        public string Data_Updata_FPRole(int ROLEID, string rightdata)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GZZX_LAY[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX_LAY[]>(rightdata);
            mesModels.ROLE_GZZX.DELETE(ROLEID, token);
            MES_RETURN_UI role = mesModels.ROLE_GZZX.INSERT(model, token);
            string r = Newtonsoft.Json.JsonConvert.SerializeObject(role);
            return r;

        }
        [HttpPost]
        public string Data_Update_Role(string data)
        {
            string token = Session["token"].ToString();

            MES_ROLE_ASSEMBLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE>(data);
            MES_RETURN_UI role = mesModels.ROLE_ASSEMBLE.UPDATE(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(role);
            return i;
        }

        [HttpPost]
        public string Data_Insert_Role(string data)
        {
            string token = Session["token"].ToString();

            MES_ROLE_ASSEMBLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE>(data);
            model.ROLELB = 1;
            MES_RETURN_UI role = mesModels.ROLE_ASSEMBLE.INSERT(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(role);
            return i;
        }

        [HttpPost]
        public string Data_Delete_Role(int ID)
        {
            string token = AppClass.GetSession("token").ToString();

            mesModels.ROLE_GZZX.DELETE(ID, token);
            MES_RETURN_UI model = mesModels.ROLE_ASSEMBLE.DELETE(ID, token);
            string d = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return d;

        }

        public ActionResult PositionRole()
        {
            AppClass.SetSession("location", 105);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ROLE_ASSEMBLE gw = new MES_ROLE_ASSEMBLE();
            gw.ROLELB = 2;
            MES_ROLE_ASSEMBLE_SELECT gzz = mesModels.ROLE_ASSEMBLE.SELECT(gw, token);
            MES_SY_GC gcm = new MES_SY_GC();
            gcm.STAFFID = STAFFID;
            MES_SY_GC[] prgc = mesModels.SY_GC.SELECT_BY_ROLE(gcm, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = prgc;
            data.Role_assemble_select = gzz;
            ViewData.Model = data;
            return View();
        }
        [HttpPost]
        public string Data_Select_GWZ(int ID)
        {
            string token = Session["token"].ToString();

            MES_ROLE_ASSEMBLE model = new MES_ROLE_ASSEMBLE();
            model.ROLELB = 2;
            model.ID = ID;
            MES_ROLE_ASSEMBLE_SELECT data = mesModels.ROLE_ASSEMBLE.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_GWZ_LB(int ID)
        {
            string token = Session["token"].ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ROLE_ASSEMBLE model = new MES_ROLE_ASSEMBLE();
            model.ROLELB = 2;
            model.ID = ID;
            model.LB = 1;
            model.STAFFID = STAFFID;
            MES_ROLE_ASSEMBLE_SELECT data = mesModels.ROLE_ASSEMBLE.SELECT_LB(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Insert_GWZ(string data)
        {
            string token = Session["token"].ToString();

            MES_ROLE_ASSEMBLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE>(data);
            model.ROLELB = 2;
            MES_RETURN_UI gwz = mesModels.ROLE_ASSEMBLE.INSERT(model, token);
            string g = Newtonsoft.Json.JsonConvert.SerializeObject(gwz);
            return g;
        }
        [HttpPost]
        public string Data_Update_GWZ(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_ROLE_ASSEMBLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE>(data);
            model.ROLELB = 2;
            MES_RETURN_UI gwz = mesModels.ROLE_ASSEMBLE.UPDATE(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(gwz);
            return u;
        }
        //[HttpPost]
        //public string Data_test(string data,string roledata,int ROLEID)
        //{
        //    string token = AppClass.GetSession("token").ToString();

        //    MES_ROLE_ASSEMBLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE>(data);
        //    model.ROLELB = 2;
        //    MES_RETURN_UI gwz = mesModels.ROLE_ASSEMBLE.UPDATE(model, token);
        //}
        [HttpPost]
        public string Data_Delete_GW(int ID)
        {
            string token = AppClass.GetSession("token").ToString();

            mesModels.ROLR_GZZX_GW.DELETE(ID, token);
            MES_RETURN_UI model = mesModels.ROLE_ASSEMBLE.DELETE(ID, token);
            string d = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            return d;
        }
        [HttpPost]
        public string Data_Select_GW(int ROLEID)
        {
            string token = Session["token"].ToString();

            MES_ROLR_GZZX_GW_LIST data = mesModels.ROLR_GZZX_GW.SELECT(ROLEID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Update_FPGW(int ROLEID, string roledata)
        {
            string token = Session["token"].ToString();

            MES_ROLR_GZZX_GW[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLR_GZZX_GW[]>(roledata);
            mesModels.ROLR_GZZX_GW.DELETE(ROLEID, token);
            MES_RETURN_UI gw = mesModels.ROLR_GZZX_GW.INSERT(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(gw);
            return u;
        }
        public ActionResult DepotRole()
        {
            AppClass.SetSession("location", 106);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] list = mesModels.SY_GC.SELECT_BY_ROLE(gclist, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = list;
            ViewData.Model = data;
            return View();
        }
        [HttpPost]
        public string Data_Select_CK(string GC)
        {
            string token = Session["token"].ToString();

            MES_ROLE_ASSEMBLE model = new MES_ROLE_ASSEMBLE();
            model.ROLELB = 3;
            model.GC = GC;
            MES_ROLE_ASSEMBLE_SELECT data = mesModels.ROLE_ASSEMBLE.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_CK_LB(string GC)
        {
            string token = Session["token"].ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ROLE_ASSEMBLE model = new MES_ROLE_ASSEMBLE();
            model.ROLELB = 3;
            model.GC = GC;
            model.LB = 1;
            model.STAFFID = STAFFID;
            MES_ROLE_ASSEMBLE_SELECT data = mesModels.ROLE_ASSEMBLE.SELECT_LB(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Insert_CK(string data)
        {
            string token = Session["token"].ToString();

            MES_ROLE_ASSEMBLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE>(data);
            model.ROLELB = 3;
            MES_RETURN_UI ck = mesModels.ROLE_ASSEMBLE.INSERT(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(ck);
            return i;
        }
        [HttpPost]
        public string Data_Update_CK(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_ROLE_ASSEMBLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE>(data);
            model.ROLELB = 3;
            MES_RETURN_UI ck = mesModels.ROLE_ASSEMBLE.UPDATE(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(ck);
            return u;
        }
        [HttpPost]
        public string Data_Delete_CK(int ID)
        {
            string token = AppClass.GetSession("token").ToString();

            mesModels.ROLE_CK.DELETE(ID, token);
            MES_RETURN_UI data = mesModels.ROLE_ASSEMBLE.DELETE(ID, token);
            string d = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return d;
        }
        [HttpPost]
        public string Data_Select_CKROLE(int ROLEID)
        {
            string token = Session["token"].ToString();

            MES_ROLE_CK_LIST data = mesModels.ROLE_CK.SELECT(ROLEID, token);
            string c = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return c;
        }
        [HttpPost]
        public string Data_Update_FPCK(int ROLEID, string ckdata)
        {
            string token = Session["token"].ToString();

            MES_ROLE_CK[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_CK[]>(ckdata);
            mesModels.ROLE_CK.DELETE(ROLEID, token);
            MES_RETURN_UI data = mesModels.ROLE_CK.INSERT(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return u;

        }
        [HttpPost]
        public string GET_SAP_CK(string GC)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_RETURN_UI SAP_CK = mesModels.MES_SYNC.MES_SYNC_KCDD(GC, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(SAP_CK);
            return rst;
        }

        public ActionResult Formula_Order()
        {
            AppClass.SetSession("location", 107);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesModels.SY_GC.SELECT_BY_ROLE(gclist, token);

            MES_SY_TYPEMX pflist = new MES_SY_TYPEMX();
            pflist.TYPEID = 3;
            MES_SY_TYPEMXLIST[] pf = mesModels.SY_TYPEMX.SELECT(pflist, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gc;
            data.Sy_typemxlist = pf;
            ViewData.Model = data;
            return View();
        }
        [HttpPost]
        public string Data_Select_FO(string GC, int LB, string PFDH)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH model = new MES_SY_PFDH();
            model.GC = GC;
            model.LB = LB;
            model.PFDH = PFDH;
            MES_SY_PFDH_LIST data = mesModels.SY_PFDH.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_FO_STAFFID(string GC, int LB, string PFDH)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_PFDH model = new MES_SY_PFDH();
            model.GC = GC;
            model.LB = LB;
            model.PFDH = PFDH;
            model.STAFFID = STAFFID;
            MES_SY_PFDH_LIST data = mesModels.SY_PFDH.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_FO_JG(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PFDH>(datastring);
            MES_SY_PFDH_LIST data = mesModels.SY_PFDH.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Insert_FO(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_SY_PFDH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PFDH>(data);
            model.CJRID = STAFFID;
            MES_RETURN_UI fo = mesModels.SY_PFDH.INSERT(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(fo);
            return i;
        }
        [HttpPost]
        public string Data_Update_FO(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_SY_PFDH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PFDH>(data);
            model.XGRID = STAFFID;
            MES_RETURN_UI fo = mesModels.SY_PFDH.UPDATE(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(fo);
            return u;
        }
        [HttpPost]
        public string Data_Delete_FO(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PFDH>(data);
            MES_RETURN_UI fo = mesModels.SY_PFDH.DELETE(model, token);
            string d = Newtonsoft.Json.JsonConvert.SerializeObject(fo);
            return d;
        }
        [HttpPost]
        public string Data_Select_FOWL(string GC, string PFDH, int PFLB)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH_WL model = new MES_SY_PFDH_WL();
            model.GC = GC;
            model.PFDH = PFDH;
            model.PFLB = PFLB;
            MES_SY_PFDH_WL_SELECT data = mesModels.SY_PFDH_WL.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_FOWLFP(string GC, string PFDH, int PFLB)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH_WL model = new MES_SY_PFDH_WL();
            model.GC = GC;
            model.PFDH = PFDH;
            model.PFLB = PFLB;
            MES_SY_PFDH_WL_SELECT_LAY data = mesModels.SY_PFDH_WL.SELECT_LAY(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Update_FOWLFP(string pfdata, string GC, string PFDH, int PFLB)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH_WL del = new MES_SY_PFDH_WL();
            del.GC = GC;
            del.PFDH = PFDH;
            del.PFLB = PFLB;
            //MES_SY_PFDH_WL del=Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PFDH_WL>(data);
            //mesModels.SY_PFDH_WL.DELETE(del, token);
            MES_SY_PFDH_WL[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PFDH_WL[]>(pfdata);

            mesModels.SY_PFDH_WL.DELETE(del, token);
            MES_RETURN_UI up = mesModels.SY_PFDH_WL.INSERT(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(up);
            return u;
        }
        [HttpPost]
        public string Data_Insert_WLZJ(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH_CHILD model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PFDH_CHILD>(data);
            MES_RETURN_UI i = mesModels.SY_PFDH_CHILD.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(i);

        }
        [HttpPost]
        public string Data_Select_WLZJ(string GC, string PFDH, int PFLB, string WLH)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH_CHILD model = new MES_SY_PFDH_CHILD();
            model.GC = GC;
            model.PFDH = PFDH;
            model.PFLB = PFLB;
            model.WLH = WLH;
            MES_SY_PFDH_CHILD_SELECT data = mesModels.SY_PFDH_CHILD.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Data_Delete_WLZJ(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH_CHILD model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PFDH_CHILD>(data);
            //mesModels.SY_PFDH_CHILD.DELETE_PFDH(model, token);
            MES_RETURN_UI del = mesModels.SY_PFDH_CHILD.DELETE_WLH(model, token);
            string d = Newtonsoft.Json.JsonConvert.SerializeObject(del);
            return d;
        }
        public ActionResult QuantityManage()
        {
            AppClass.SetSession("location", 108);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesModels.SY_GC.SELECT_BY_ROLE(gclist, token);

            MES_SY_TYPEMX dcxh = new MES_SY_TYPEMX();
            dcxh.TYPEID = 6;
            MES_SY_TYPEMXLIST[] dc = mesModels.SY_TYPEMX.SELECT(dcxh, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gc;
            data.Sy_typemxlist = dc;
            ViewData.Model = data;
            return View();
        }
        [HttpPost]
        public string Data_Select_DCXH(string GC)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_DCXH_COUNT model = new MES_SY_DCXH_COUNT();
            model.GC = GC;
            MES_SY_DCXH_COUNT_SELECT data = mesModels.SY_DCXH_COUNT.SELECT(model, token);
            string d = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return d;
        }
        [HttpPost]
        public string Data_Select_DCXH_LB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_DCXH_COUNT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_DCXH_COUNT>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_DCXH_COUNT_SELECT data = mesModels.SY_DCXH_COUNT.SELECT_LB(model, token);
            string d = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return d;
        }
        [HttpPost]
        public string Data_Insert_SLGL(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_DCXH_COUNT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_DCXH_COUNT>(data);
            Sonluk.UI.Model.MES.SY_DCXH_COUNTService.MES_RETURN sl = mesModels.SY_DCXH_COUNT.INSERT(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(sl);
            return i;
        }
        [HttpPost]
        public string Data_Update_SLGL(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_DCXH_COUNT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_DCXH_COUNT>(data);
            Sonluk.UI.Model.MES.SY_DCXH_COUNTService.MES_RETURN sl = mesModels.SY_DCXH_COUNT.UPDATE(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(sl);
            return u;
        }
        [HttpPost]
        public string Data_Delete_SLGL(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_DCXH_COUNT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_DCXH_COUNT>(data);
            Sonluk.UI.Model.MES.SY_DCXH_COUNTService.MES_RETURN sl = mesModels.SY_DCXH_COUNT.DELETE(model, token);
            string d = Newtonsoft.Json.JsonConvert.SerializeObject(sl);
            return d;
        }
        public ActionResult Material_Group()
        {
            AppClass.SetSession("location", 109);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesModels.SY_GC.SELECT_BY_ROLE(gclist, token);
            MES_SY_TYPEMX wllb = new MES_SY_TYPEMX();
            wllb.TYPEID = 4;
            MES_SY_TYPEMXLIST[] dc = mesModels.SY_TYPEMX.SELECT(wllb, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gc;
            data.Sy_typemxlist = dc;
            ViewData.Model = data;
            return View();
        }
        [HttpPost]
        public string Data_Select_WLZ(string GC)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL_GROUP model = new MES_SY_MATERIAL_GROUP();
            model.GC = GC;
            MES_SY_MATERIAL_GROUP_SELECT data = mesModels.SY_MATERIAL_GROUP.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_WLZ_LB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_MATERIAL_GROUP model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_GROUP>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_MATERIAL_GROUP_SELECT data = mesModels.SY_MATERIAL_GROUP.SELECT_LB(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_WLZ_WLLB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL_GROUP model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_GROUP>(datastring);
            MES_SY_MATERIAL_GROUP_SELECT data = mesModels.SY_MATERIAL_GROUP.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Insert_WLZ(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_SY_MATERIAL_GROUP model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_GROUP>(data);
            model.CJRID = STAFFID;
            MES_RETURN_UI wl = mesModels.SY_MATERIAL_GROUP.INSERT(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(wl);
            return i;
        }
        [HttpPost]
        public string Data_Update_WLZ(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_SY_MATERIAL_GROUP model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_GROUP>(data);
            model.XGRID = STAFFID;
            MES_RETURN_UI wlxg = mesModels.SY_MATERIAL_GROUP.UPDATE(model, token);
            string u = Newtonsoft.Json.JsonConvert.SerializeObject(wlxg);
            return u;
        }
        [HttpPost]
        public string Data_Delete_WLZ(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL_GROUP model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_GROUP>(data);
            MES_RETURN_UI del = mesModels.SY_MATERIAL_GROUP.DELETE(model, token);
            string d = Newtonsoft.Json.JsonConvert.SerializeObject(del);
            return d;
        }
        [HttpPost]
        public string GET_SAP()
        {
            string token = AppClass.GetSession("token").ToString();

            MES_RETURN_UI data = mesModels.MES_SYNC.MES_WLGROUP_SYNC(token);
            string g = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return g;
        }
        public ActionResult Material()
        {
            AppClass.SetSession("location", 115);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesModels.SY_GC.SELECT_BY_ROLE(gclist, token);
            MES_SY_MATERIAL_GROUP wlz = new MES_SY_MATERIAL_GROUP();
            MES_SY_MATERIAL_GROUP_SELECT wl = mesModels.SY_MATERIAL_GROUP.SELECT(wlz, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_material_group_select = wl;
            data.Sy_gc = gc;
            ViewData.Model = data;
            return View();
        }
        [HttpPost]
        public string Data_Select_WL(string GC, string WLGROUP, string WLH)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL model = new MES_SY_MATERIAL();
            model.GC = GC;
            model.WLGROUP = WLGROUP;
            model.WLH = WLH;
            MES_SY_MATERIAL_SELECT data = mesModels.SY_MATERIAL.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_WL_LB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_MATERIAL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_MATERIAL_SELECT data = mesModels.SY_MATERIAL.SELECT_LB(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Insert_WL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_SY_MATERIAL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL>(data);
            model.JLR = STAFFID;
            MES_RETURN_UI wl = mesModels.SY_MATERIAL.INSERT(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(wl);
            return i;
        }
        [HttpPost]
        public string Data_Update_WL(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL>(data);
            MES_RETURN_UI wl = mesModels.SY_MATERIAL.UPDATE(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(wl);
            return i;
        }
        [HttpPost]
        public string Data_Delete_WL(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL>(data);
            MES_RETURN_UI wl = mesModels.SY_MATERIAL.DELETE(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(wl);
            return i;
        }
        [HttpPost]
        public string GET_SAP_WL(string GC, string WLGROUP, string WLH, int JLR)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI SAP_WL = mesModels.MES_SYNC.MES_SYNC_WL(GC, WLGROUP, WLH, STAFFID, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(SAP_WL);
            return rst;
        }

        public ActionResult FJ()
        {
            AppClass.SetSession("location", 116);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesModels.SY_GC.SELECT_BY_ROLE(gclist, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gc;
            ViewData.Model = data;
            return View();
        }
        [HttpPost]
        public string Data_Select_PFDHLIST(string GC, string LBNAME)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_PFDH model = new MES_SY_PFDH();
            model.GC = GC;
            model.LBNAME = LBNAME;
            MES_SY_PFDH_LIST data = mesModels.SY_PFDH.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string GET_GDINFO(string GC, string GZZXBH, string WLLBNAME, string KSDATE, string JSDATE, int PFLB, string PFDH)
        {
            string rst = "";
            string token = Session["token"].ToString();
            MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
            model_MES_PD_GD.GC = GC;
            model_MES_PD_GD.GZZXBH = GZZXBH;
            model_MES_PD_GD.WLLBNAME = WLLBNAME;
            model_MES_PD_GD.KSDATE = KSDATE;
            model_MES_PD_GD.JSDATE = JSDATE;
            model_MES_PD_GD.PFLB = PFLB;
            model_MES_PD_GD.PFDH = PFDH;
            SELECT_MES_PD_GD rst_SELECT_MES_PD_GD = mesModels.PD_GD.SELECT(model_MES_PD_GD, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_GD);
            return rst;
        }
        [HttpPost]
        public string Data_Select_SCRW(string GC, string GZZXBH, string SBBH, string ZPRQKS, string ZPRQJS)
        {
            string token = Session["token"].ToString();

            MES_PD_SCRW model = new MES_PD_SCRW();
            model.GC = GC;
            model.GZZXBH = GZZXBH;
            model.SBBH = SBBH;
            model.ZPRQKS = ZPRQKS;
            model.ZPRQJS = ZPRQJS;
            //model.CXLB = CXLB;
            SELECT_MES_PD_SCRW data = mesModels.PD_SCRW.SELECT(model, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return rst;
        }
        [HttpPost]
        public string GET_XFLIST(string GC, string WLMS, string WLH, string WLGROUP)  //锌粉带出物料编号专用
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL model = new MES_SY_MATERIAL();
            model.GC = GC;
            model.WLMS = WLMS;
            //model.WLH = "";
            //model.WLGROUP = "";
            MES_SY_MATERIAL_SELECT data = mesModels.SY_MATERIAL.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string XFPCbyXFCD(string GC, string WLH)
        {
            string token = AppClass.GetSession("token").ToString();

            ZBCFUN_XFPC_READ data = mesModels.MES_FJ.SELECT_PC(GC, WLH, token);
            string x = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return x;
        }
        [HttpPost]
        public string Data_Insert_FJPD(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_PD_SCRW model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW>(data);
            model.RWLB = 2;
            model.JLR = STAFFID;
            Sonluk.UI.Model.MES.PD_SCRWService.MES_RETURN adddata = mesModels.PD_SCRW.INSERT_BY_FJPD(model, token);
            string i = Newtonsoft.Json.JsonConvert.SerializeObject(adddata);
            return i;
        }
        [HttpPost]
        public string Data_Select_FJ_GZZX(string GC, string WLLBNAME)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();

            MES_SY_GZZX CX = new MES_SY_GZZX();
            CX.GC = GC;
            CX.WLLBNAME = WLLBNAME;
            CX.STAFFID = STAFFID;
            MES_SY_GZZX[] data = mesModels.SY_GZZX.SELECT_BY_ROLE(CX, token);
            string c = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return c;
        }
        [HttpPost]
        public string Data_Select_SBH_FJ(string GZZXBH, string GC, string WLLBNAME, string SBBH)
        {

            string token = Session["token"].ToString();

            MES_SY_GZZX_SBH sbh = new MES_SY_GZZX_SBH();
            sbh.GZZXBH = GZZXBH;
            sbh.GC = GC;
            sbh.WLLBNAME = WLLBNAME;
            sbh.SBBH = SBBH;
            MES_SY_GZZX_SBH[] data = mesModels.SY_GZZX_SBH.SELECT(sbh, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;

        }
        [HttpPost]
        public string MES_PD_SCRW_SUM_SELECT(string GZZXBH, string GC, string ZPRQKS, string ZPRQJS)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_PD_SCRW_SUM_LIST model_MES_PD_SCRW_SUM_LIST = new MES_PD_SCRW_SUM_LIST();
            model_MES_PD_SCRW_SUM_LIST.GZZXBH = GZZXBH;
            model_MES_PD_SCRW_SUM_LIST.GC = GC;
            model_MES_PD_SCRW_SUM_LIST.ZPRQKS = ZPRQKS;
            model_MES_PD_SCRW_SUM_LIST.ZPRQJS = ZPRQJS;
            MES_PD_SCRW_SUM_SELECT data_MES_PD_SCRW_SUM_SELECT = mesModels.PD_SCRW.SELECT_SUM(model_MES_PD_SCRW_SUM_LIST, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data_MES_PD_SCRW_SUM_SELECT);
        }

        [HttpPost]
        public string Data_GetGDXX(string aufnr)
        {
            string token = AppClass.GetSession("token").ToString();
            ZBCFUN_GDJGXX_READ data = crmModels.PD_GD.get_GDJGXX_BYERPNO(aufnr, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string GETPLDH(string GC, string PFDH, int PFLB)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_PLDH model = new MES_SY_PLDH();
            model.GC = GC;
            model.PFDH = PFDH;
            model.PFLB = PFLB;
            MES_SY_PLDH_SELECT data = mesModels.SY_PLDH.SELECT_LIST(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string SELECT_PLDH(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_PLDH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_PLDH_SELECT data = mesModels.SY_PLDH.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


        public ActionResult StaffManage()
        {
            MODEK_StaffManage model = new MODEK_StaffManage();
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 117);
            CRM_HG_DEPT[] rst_CRM_HG_DEPT = crmModels.HG_DEPT.Read(token);
            model.CRM_HG_DEPT = rst_CRM_HG_DEPT;
            ViewData.Model = model;
            return View();
        }

        [HttpPost]
        public string GET_STAFF(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_STAFF>(datastring);
            MES_SY_STAFF_SELECT rst_MES_SY_STAFF_SELECT = mesModels.SY_STAFF.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_STAFF_SELECT);
        }
        [HttpPost]
        public string GET_ROLE_JS(int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_ROLE_ASSEMBLE_JS_LAY_SELECT rst = mesModels.ROLE_ASSEMBLE.SELECT_JS_LAY(STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string GET_ROLE_LAY(int STAFFID, int ROLELB)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_ROLE_ASSEMBLE_LAY_SELECT rst = mesModels.ROLE_ASSEMBLE.SELECT_LAY(STAFFID, ROLELB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string GET_GC_LAY(int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_GC_LAY_SELECT rst_MES_SY_GC_LAY_SELECT = mesModels.SY_GC.SELECT_LAY(STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GC_LAY_SELECT);
        }
        [HttpPost]
        public string INSERT_STAFF(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            CRM_HG_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_STAFF>(datastring);
            model.STAFFPW = FormsAuthentication.HashPasswordForStoringInConfigFile(model.STAFFPW, "MD5").ToLower();
            int STAFFID = crmModels.HG_STAFF.Create(model, token);
            return STAFFID.ToString();
        }
        [HttpPost]
        public string UPDATE_STAFF(string datastring, int ISNEWPW)
        {
            string token = AppClass.GetSession("token").ToString();
            CRM_HG_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_STAFF>(datastring);

            CRM_HG_STAFF data = crmModels.HG_STAFF.ReadBySTAFFID(model.STAFFID, token);
            data.DEPID = model.DEPID;
            data.STAFFNAME = model.STAFFNAME;
            data.STAFFNO = model.STAFFNO;
            data.STAFFUSER = model.STAFFUSER;
            if (ISNEWPW == 1)
            {
                data.STAFFPW = FormsAuthentication.HashPasswordForStoringInConfigFile(model.STAFFPW, "MD5").ToLower();
            }
            data.STAFFSEX = model.STAFFSEX;
            data.STAFFMOBILE = model.STAFFMOBILE;
            data.STAFFTEL = model.STAFFTEL;
            data.SISLOCK = model.SISLOCK;
            data.ISACTIVE = model.ISACTIVE;
            data.USERLX = model.USERLX;
            int STAFFID = crmModels.HG_STAFF.Update(data, token);
            return STAFFID.ToString();
        }
        [HttpPost]
        public string Data_Load_Dropdown(int typeid, int fid)
        {
            string token = AppClass.GetSession("token").ToString();
            CRM_HG_DICT[] list = crmModels.HG_DICT.Read(typeid, fid, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return json;
        }
        [HttpPost]
        public string UPDATE_STAFF_JS(string datastring, int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            mesModels.ROLE_ASSEMBLE.DELETE_JS(STAFFID, token);
            MES_ROLE_ASSEMBLE_JS_LAY[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE_JS_LAY[]>(datastring);
            for (int i = 0; i < model.Length; i++)
            {
                model[i].STAFFID = STAFFID;
            }
            MES_RETURN_UI rst = mesModels.ROLE_ASSEMBLE.INSERT_JS(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_ROLE_GC(string datastring, int STAFFID)
        {
            MES_RETURN_UI rst_MES_RETURN_UI = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            mesModels.ROLE_GC.DELETE(STAFFID, token);
            List<MES_ROLE_GC> model_MES_ROLE_GC = new List<MES_ROLE_GC>();
            MES_SY_GC_LAY[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GC_LAY[]>(datastring);
            if (model.Length > 0)
            {
                for (int i = 0; i < model.Length; i++)
                {
                    MES_ROLE_GC child = new MES_ROLE_GC();
                    child.STAFFID = STAFFID;
                    child.GC = model[i].GC;
                    model_MES_ROLE_GC.Add(child);
                }
                rst_MES_RETURN_UI = mesModels.ROLE_GC.INSERT(model_MES_ROLE_GC.ToArray(), token);
            }
            else
            {
                rst_MES_RETURN_UI.TYPE = "S";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }
        [HttpPost]
        public string UPDATE_ROLE_GZZZXANDCK(string datastring, string datastring1, int STAFFID)
        {
            MES_RETURN_UI rst_MES_RETURN_UI = new MES_RETURN_UI();
            List<MES_ROLE_RY_ASSEMBLE> model = new List<MES_ROLE_RY_ASSEMBLE>();
            string token = AppClass.GetSession("token").ToString();
            mesModels.ROLE_RY_ASSEMBLE.DELETE(STAFFID, token);
            MES_ROLE_ASSEMBLE_LAY[] model_MES_ROLE_ASSEMBLE_LAY1 = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE_LAY[]>(datastring);
            MES_ROLE_ASSEMBLE_LAY[] model_MES_ROLE_ASSEMBLE_LAY2 = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ROLE_ASSEMBLE_LAY[]>(datastring1);
            for (int i = 0; i < model_MES_ROLE_ASSEMBLE_LAY1.Length; i++)
            {
                MES_ROLE_RY_ASSEMBLE child = new MES_ROLE_RY_ASSEMBLE();
                child.STAFFID = STAFFID;
                child.ROLEID = model_MES_ROLE_ASSEMBLE_LAY1[i].ID;
                model.Add(child);
            }
            for (int i = 0; i < model_MES_ROLE_ASSEMBLE_LAY2.Length; i++)
            {
                MES_ROLE_RY_ASSEMBLE child = new MES_ROLE_RY_ASSEMBLE();
                child.STAFFID = STAFFID;
                child.ROLEID = model_MES_ROLE_ASSEMBLE_LAY2[i].ID;
                model.Add(child);
            }
            if (model.Count > 0)
            {
                rst_MES_RETURN_UI = mesModels.ROLE_RY_ASSEMBLE.INSERT(model.ToArray(), token);
            }
            else
            {
                rst_MES_RETURN_UI.TYPE = "S";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }
        public ActionResult ReplaceBZ()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 118);
            return View();
        }
        [HttpPost]
        public string S_TM_SWITCH_D_TM(string OLDTPM, string NEWTPM)
        {
            string token = Session["token"].ToString();
            MES_RETURN_UI data = mesModels.TM_TMINFO.VERIFY_TPMTH(OLDTPM, NEWTPM, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return rst;
        }
        public ActionResult PJCOUNT()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 119);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesModels.SY_GC.SELECT_BY_ROLE(gclist, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gc;
            ViewData.Model = data;
            return View();
        }
        [HttpPost]
        public string Data_Select_PJCOUNT(string GC, string GZZXBH, string WLH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL_BZCOUNT model = new MES_SY_MATERIAL_BZCOUNT();
            model.GC = GC;
            model.GZZXBH = GZZXBH;
            model.WLH = WLH;
            MES_SY_MATERIAL_BZCOUNT_SELECT data = mesModels.SY_MATERIAL_BZCOUNT.SELECT(model, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return rst;
        }
        [HttpPost]
        public string Data_Select_PJCOUNT_LB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_MATERIAL_BZCOUNT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_BZCOUNT>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_MATERIAL_BZCOUNT_SELECT data = mesModels.SY_MATERIAL_BZCOUNT.SELECT_LB(model, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return rst;
        }
        [HttpPost]
        public string Data_Insert_PJCOUNT(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL_BZCOUNT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_BZCOUNT>(data);
            MES_RETURN_UI list = mesModels.SY_MATERIAL_BZCOUNT.INSERT(model, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return rst;
        }
        [HttpPost]
        public string Data_Update_PJCOUNT(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL_BZCOUNT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_BZCOUNT>(data);
            MES_RETURN_UI list = mesModels.SY_MATERIAL_BZCOUNT.UPDATE(model, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return rst;
        }
        [HttpPost]
        public string Data_Delete_PJCOUNT(string data)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL_BZCOUNT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_BZCOUNT>(data);
            MES_RETURN_UI list = mesModels.SY_MATERIAL_BZCOUNT.DELETE(model, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return rst;
        }
        [HttpPost]
        public string Data_WLbyWLLB(string GC, int WLLB)
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MATERIAL model = new MES_SY_MATERIAL();
            model.GC = GC;
            model.WLLB = WLLB;
            MES_SY_MATERIAL_SELECT data = mesModels.SY_MATERIAL.SELECT(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        public ActionResult SBSelect()
        {
            AppClass.SetSession("location", 120);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GC gc = new MES_SY_GC();
            gc.STAFFID = STAFFID;
            MES_SY_GC[] gcid = mesModels.SY_GC.SELECT_BY_ROLE(gc, token);
            MES_SY_GZZX_SBH SBBH = new MES_SY_GZZX_SBH();
            MES_SY_GZZX_SBH[] SBH = mesModels.SY_GZZX_SBH.SELECT_ALL(SBBH, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gcid;
            data.Sy_gzzx_sbh = SBH;
            ViewData.Model = data;


            return View();
        }

        [HttpPost]
        public string QDCode(string code, string format, string width, string height, string pure)
        {
            Byte[] objcode = mesModels.BarCode.CreateBarCode(code, format, Convert.ToInt32(width), Convert.ToInt32(height), Convert.ToInt32(pure));
            string qd = Convert.ToBase64String(objcode);
            return Newtonsoft.Json.JsonConvert.SerializeObject(qd);
        }

        [HttpPost]
        public string POST_PRINT_SBQD_LIST(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_SY_GZZX_SBH[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX_SBH[]>(datastring);
            AppClass.SetSession("MES_SY_GZZX_SBH", model);
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string DELETE_STAFF(int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI model_MES_RETURN_UI = new MES_RETURN_UI();
            int rst_count = crmModels.HG_STAFF.Delete(STAFFID, token);
            if (rst_count > 0)
            {
                model_MES_RETURN_UI.TYPE = "S";
            }
            else
            {
                model_MES_RETURN_UI.TYPE = "E";
                model_MES_RETURN_UI.MESSAGE = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(model_MES_RETURN_UI);
        }
        public ActionResult SBQD()
        {
            string token = AppClass.GetSession("token").ToString();
            List<MODEL_RWQD_PRINT> rst = new List<MODEL_RWQD_PRINT>();
            MES_SY_GZZX_SBH[] model_MES_SY_GZZX_SBH = (MES_SY_GZZX_SBH[])Session["MES_SY_GZZX_SBH"];

            for (int i = 0; i < model_MES_SY_GZZX_SBH.Length; i++)
            {
                MODEL_RWQD_PRINT child_MODEL_RWQD_PRINT = new MODEL_RWQD_PRINT();
                child_MODEL_RWQD_PRINT.MES_SY_GZZX_SBH = model_MES_SY_GZZX_SBH[i];
                rst.Add(child_MODEL_RWQD_PRINT);
            }
            return View(rst);
        }
        public ActionResult QDCodeSC()
        {
            AppClass.SetSession("location", 121);
            return View();
        }
        public ActionResult BBXX()
        {
            AppClass.SetSession("location", 122);
            return View();
        }
        [HttpPost]
        public string SELECT_BBXX()
        {
            string token = AppClass.GetSession("token").ToString();

            MES_SY_MACHINEINFO_BBXX model_MES_SY_MACHINEINFO_BBXX = new MES_SY_MACHINEINFO_BBXX();
            MES_SY_MACHINEINFO_SELECTBBXX data_MES_SY_MACHINEINFO_SELECTBBXX = mesModels.SY_MACHINEINFO.SELECT_BBXX(model_MES_SY_MACHINEINFO_BBXX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data_MES_SY_MACHINEINFO_SELECTBBXX);
        }
        [HttpPost]
        public string EXPOST_BBXX(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                MES_SY_MACHINEINFO_BBXX[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MACHINEINFO_BBXX[]>(alldata);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/版本信息导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].MNUMBER);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WKINFO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].REMARK);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].NEWBB);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].LASTNEWBB);
                    if (model[i].NEWBB == model[i].LASTNEWBB)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("版本不同！");
                    }
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生产文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_READ_BBXX(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "版本信息.xls");
        }
        [HttpPost]
        public string EXPOST_FJ(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                MES_PD_SCRW_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW_LIST[]>(alldata);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/锌膏车间打印表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet1 = workbook.GetSheet("Sheet1");
                sheet1.GetRow(0).GetCell(0).SetCellValue("车号：" + model[0].SBH);

                int rowcount = 2;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    string gys = "";
                    if (model[i].GYSPC.Length >= 8)
                    {
                        gys = model[i].GYSPC.Substring(0, 8);
                    }
                    else
                    {
                        gys = model[i].GYSPC;
                    }
                    sheet1.GetRow(rowcount).GetCell(cellIndex++).SetCellValue(model[i].TH);
                    sheet1.GetRow(rowcount).GetCell(cellIndex++).SetCellValue(model[i].PFDH);
                    sheet1.GetRow(rowcount).GetCell(cellIndex++).SetCellValue(model[i].XFPC);
                    sheet1.GetRow(rowcount).GetCell(cellIndex++).SetCellValue(gys);
                    rowcount++;
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生产文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_READ_FJ(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "锌膏车间打印表.xls");
        }
        public ActionResult MES_SBBH_TD()
        {
            AppClass.SetSession("location", 162);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_MES_ALL model = new MODEL_MES_ALL();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            ViewData.Model = model;
            return View();
        }
        [HttpPost]
        public string GET_SBBH_BY_TDNO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_PD_TL_TD model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_TL_TD>(datastring);
            MES_PD_TL_TD_SELECT rst = mesModels.SY_GZZX_SBH.SELECT_BY_TDNO(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SET_SBBH_INSER_BY_TDNO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_PD_TL_TD model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_TL_TD>(datastring);
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.SY_GZZX_SBH.INSERT_BY_TDNO(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }
        [HttpPost]
        public string SET_SBBH_DELETE_BY_TDNO(string TDNO)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.SY_GZZX_SBH.DELETE_BY_TDNO(TDNO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }
        [HttpPost]
        public string SET_SBBH_UPDATE_BY_TDNO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_PD_TL_TD model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_TL_TD>(datastring);
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.SY_GZZX_SBH.UPDATE_BY_TDNO(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }

        [HttpPost]
        public string SY_ZJH_ROLE_INSERT_LAY(string datastring, int STAFFID)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            hrmodels.SY_ZJH.DELETE_ZJH_ROLE_LAY(STAFFID, token);
            Sonluk.UI.Model.HR.SY_ZJHService.HR_SY_ZJH_LAY[] model_HR_SY_ZJH_LAY = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.HR.SY_ZJHService.HR_SY_ZJH_LAY[]>(datastring);
            if (model_HR_SY_ZJH_LAY.Length > 0)
            {
                for (int i = 0; i < model_HR_SY_ZJH_LAY.Length; i++)
                {
                    model_HR_SY_ZJH_LAY[i].STAFFID = STAFFID;
                    rst = hrmodels.SY_ZJH.INSERT_ZJH_ROLE_LAY(model_HR_SY_ZJH_LAY[i], token);
                }
            }
            else
            {
                rst.TYPE = "S";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_ZJH_ROLE_SELECT_LAY(int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            Sonluk.UI.Model.HR.SY_ZJHService.HR_SY_ZJH_LAY_SELECT rst = hrmodels.SY_ZJH.SELECT_ZJH_ROLE_LAY(STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_GS_ROLE_INSERT_LAY(string datastring, int STAFFID)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            hrmodels.SY_GS.DELETE_GS_ROLE_LAY(STAFFID, token);
            HR_SY_GS_LAY[] model_HR_SY_GS_LAY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_GS_LAY[]>(datastring);
            if (model_HR_SY_GS_LAY.Length > 0)
            {
                for (int i = 0; i < model_HR_SY_GS_LAY.Length; i++)
                {
                    model_HR_SY_GS_LAY[i].STAFFID = STAFFID;
                    rst = hrmodels.SY_GS.INSERT_GS_ROLE_LAY(model_HR_SY_GS_LAY[i], token);
                }
            }
            else
            {
                rst.TYPE = "S";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SY_GS_ROLE_SELECT_LAY(int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_GS_LAY_SELECT rst = hrmodels.SY_GS.SELECT_GS_ROLE_LAY(STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ROLE_DEPT_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ROLE_DEPT model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ROLE_DEPT>(datastring);
            //model.STAFFID = STAFFID;
            HR_ROLE_DEPT_SELECT rst = hrmodels.ROLE_DEPT.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ROLE_DEPT_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_ROLE_DEPT model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ROLE_DEPT>(datastring);
            MES_RETURN_UI rst = hrmodels.ROLE_DEPT.UPDATE(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ROLE_DEPT_INSERT(string datastring, int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_ROLE_DEPT[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ROLE_DEPT[]>(datastring);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            for (int a = 0; a < model.Length; a++)
            {
                model[a].STAFFID = STAFFID;
                rst = hrmodels.ROLE_DEPT.INSERT(model[a], token);
            }
            if (model.Length == 0)
            {
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string SY_EMTYPE_ROLE_INSERT_LAY(string datastring, int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_EMTYPE_LAY_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_EMTYPE_LAY_LIST[]>(datastring);
            EM_SY_STAFF_EMTYPE node = new EM_SY_STAFF_EMTYPE();
            MES_RETURN_UI rst = new MES_RETURN_UI();

            node.STAFFID = STAFFID;
            emModel.SY_STAFF_EMTYPE.Delete(node, token);
            for (int i = 0; i < model.Length; i++)
            {
                node.EMTYPEID = model[i].EMTYPEID;
                rst = emModel.SY_STAFF_EMTYPE.Create(node, token);

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_SY_MATERIAL_DW_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL_DW model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_DW>(datastring);
            MES_SY_MATERIAL_DW_SELECT rst = mesModels.SY_MATERIAL.DW_SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_TIME_NOW()
        {
            string token = AppClass.GetSession("token").ToString();
            return mesModels.PUBLIC_FUNC.GET_TIME(token);
        }
        [HttpPost]
        public string MES_SY_PLDH_INSERT(string datastring, string datastring1, string datastring2)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_PLDH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH>(datastring);
            MES_SY_PLDH_SBBH[] model_MES_SY_PLDH_SBBH = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH_SBBH[]>(datastring1);
            MES_SY_PLDH_PH[] model_MES_SY_PLDH_PH = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH_PH[]>(datastring2);
            model.ISACTION = 1;
            model.JLRID = STAFFID;
            MES_RETURN_UI rst = mesModels.SY_PLDH.INSERT(model, token);
            if (rst.TYPE == "S")
            {
                for (int a = 0; a < model_MES_SY_PLDH_SBBH.Length; a++)
                {
                    model_MES_SY_PLDH_SBBH[a].GC = rst.GC;
                    model_MES_SY_PLDH_SBBH[a].PLDH = rst.BH;
                    model_MES_SY_PLDH_SBBH[a].CJR = STAFFID;
                    mesModels.SY_PLDH.PLDH_SBBH_INSERT(model_MES_SY_PLDH_SBBH[a], token);
                }
                for (int a = 0; a < model_MES_SY_PLDH_PH.Length; a++)
                {
                    model_MES_SY_PLDH_PH[a].GC = rst.GC;
                    model_MES_SY_PLDH_PH[a].PLDH = rst.BH;
                    mesModels.SY_PLDH.INSERT_PLDH_PH(model_MES_SY_PLDH_PH[a], token);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_SY_PLDH_SBBH_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_PLDH_SBBH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH_SBBH>(datastring);
            MES_SY_PLDH_SBBH_SELECT rst = mesModels.SY_PLDH.PLDH_SBBH_SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_SY_PLDH_PH_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_PLDH_PH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH_PH>(datastring);
            MES_SY_PLDH_PH_SELECT rst = mesModels.SY_PLDH.SELECT_PLDH_PH(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_SY_PLDH_PH_SELECT_LB(string datastring)
        {         
            string token = AppClass.GetSession("token").ToString();
            MES_SY_PLDH_PH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH_PH>(datastring);
            MES_SY_PLDH_PH_SELECT rst = mesModels.SY_PLDH.SELECT_PLDH_PH_LB(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_SY_PLDH_UPDATE_ALL(string datastring, string datastring1)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_PLDH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH>(datastring);
            model.LB = 2;
            MES_SY_PLDH_SBBH[] model_MES_SY_PLDH_SBBH = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH_SBBH[]>(datastring1);
            MES_RETURN_UI rst = mesModels.SY_PLDH.UPDATE(model, token);
            if (rst.TYPE == "S")
            {
                MES_SY_PLDH_SBBH model_MES_SY_PLDH_SBBH2 = new MES_SY_PLDH_SBBH();
                model_MES_SY_PLDH_SBBH2.LB = 2;
                model_MES_SY_PLDH_SBBH2.GC = model.GC;
                model_MES_SY_PLDH_SBBH2.PLDH = model.PLDH;
                model_MES_SY_PLDH_SBBH2.XGR = STAFFID;
                model_MES_SY_PLDH_SBBH2.CJR = STAFFID;
                mesModels.SY_PLDH.PLDH_SBBH_UPDATE(model_MES_SY_PLDH_SBBH2, token);
                for (int a = 0; a < model_MES_SY_PLDH_SBBH.Length; a++)
                {
                    model_MES_SY_PLDH_SBBH[a].GC = model.GC;
                    model_MES_SY_PLDH_SBBH[a].PLDH = model.PLDH;
                    mesModels.SY_PLDH.PLDH_SBBH_INSERT(model_MES_SY_PLDH_SBBH[a], token);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_SY_PLDH_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_PLDH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH>(datastring);
            MES_RETURN_UI rst = mesModels.SY_PLDH.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_SY_RYGH_GS_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_RYGH_GS model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_RYGH_GS>(datastring);
            MES_SY_RYGH_GS_SELECT rst = mesModels.SY_RYGH.SELECT_GS(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_SY_RYGH_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_RYGH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_RYGH>(datastring);
            MES_SY_RYGH_SELECT rst = mesModels.SY_RYGH.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_SY_RYGH_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_RYGH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_RYGH>(datastring);
            model.CJRID = STAFFID;
            MES_RETURN_UI rst = mesModels.SY_RYGH.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_SY_RYGH_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_RYGH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_RYGH>(datastring);
            model.XGRID = STAFFID;
            MES_RETURN_UI rst = mesModels.SY_RYGH.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_RY_MANAGE_MB()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "人员工号,人员姓名";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
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
        public string EXPOST_RY_MANAGE(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            try
            {
                MES_SY_RYGH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_RYGH>(datastring);
                MES_SY_RYGH_SELECT rst_MES_SY_RYGH_SELECT = mesModels.SY_RYGH.SELECT(model, token);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "归属代码,人员工号,人员姓名,生成工号";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int a = 0; a < rst_MES_SY_RYGH_SELECT.MES_SY_RYGH.Length; a++)
                {
                    rowtt = sheet.CreateRow(rowcount++);
                    cellIndex = 0;
                    rowtt.CreateCell(cellIndex++).SetCellValue(rst_MES_SY_RYGH_SELECT.MES_SY_RYGH[a].RYGSDM);
                    rowtt.CreateCell(cellIndex++).SetCellValue(rst_MES_SY_RYGH_SELECT.MES_SY_RYGH[a].RYGH);
                    rowtt.CreateCell(cellIndex++).SetCellValue(rst_MES_SY_RYGH_SELECT.MES_SY_RYGH[a].RYNAME);
                    rowtt.CreateCell(cellIndex++).SetCellValue(rst_MES_SY_RYGH_SELECT.MES_SY_RYGH[a].RYSCGH);
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
        public string Data_DaoRu_RYGH(string RYGSDM)
        {
            MES_RETURN_UI msg = new MES_RETURN_UI();
            if (RYGSDM == "")
            {
                msg.TYPE = "E";
                msg.MESSAGE = "请选择归属代码！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

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
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
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
                        if (data1.Columns.Contains("人员工号") == false || data1.Columns.Contains("人员姓名") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["人员工号"].ToString().Trim() != "")
                            {
                                if (data1.Rows[a]["人员工号"].ToString().Trim() == "" || data1.Rows[a]["人员姓名"].ToString().Trim() == "")
                                {
                                    msg.TYPE = "E";
                                    msg.MESSAGE = "第" + (a + 1).ToString() + "行数据不能为空！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["人员工号"].ToString().Trim() != "")
                            {
                                MES_SY_RYGH model = new MES_SY_RYGH();
                                model.RYGSDM = RYGSDM;
                                model.RYGH = data1.Rows[a]["人员工号"].ToString().Trim();
                                model.RYNAME = data1.Rows[a]["人员姓名"].ToString().Trim();
                                MES_SY_RYGH_SELECT rst_MES_SY_RYGH_SELECT = mesModels.SY_RYGH.SELECT(model, token);
                                if (rst_MES_SY_RYGH_SELECT.MES_RETURN.TYPE != "S")
                                {
                                    rst_MES_SY_RYGH_SELECT.MES_RETURN.MESSAGE = "第（" + (a + 1).ToString() + ")行校验出错";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_RYGH_SELECT.MES_RETURN);
                                }
                                if (rst_MES_SY_RYGH_SELECT.MES_SY_RYGH.Length > 0)
                                {
                                    msg.TYPE = "E";
                                    msg.MESSAGE = "第" + (a + 1).ToString() + "行人员已存在";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["人员工号"].ToString().Trim() != "")
                            {
                                MES_SY_RYGH model = new MES_SY_RYGH();
                                model.RYGSDM = RYGSDM;
                                model.RYGH = data1.Rows[a]["人员工号"].ToString().Trim();
                                model.RYNAME = data1.Rows[a]["人员姓名"].ToString().Trim();
                                model.CJRID = STAFFID;
                                MES_RETURN_UI rst = mesModels.SY_RYGH.INSERT(model, token);
                                if (rst.TYPE != "S")
                                {
                                    rst.MESSAGE = "第（" + (a + 1).ToString() + ")行" + rst.MESSAGE;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                            }
                        }
                    }
                    else
                    {
                        msg.TYPE = "E";
                        msg.MESSAGE = "无数据！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    msg.TYPE = "S";
                    msg.MESSAGE = "导入成功！";
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
        public string CreateSY_CN(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/CreateSY_CN", data);
        }
        [HttpPost]
        public string ReadSY_CN(string data)
        {           
            return sHttp.SApiPost("MES", "MES/SCH/ReadSY_CN", data);
        }
        [HttpGet]
        public FileResult ExportByExcel(string data)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("data", data);
            
            return File(sHttp.SApiDownload("MES", "MES/SCH/ExportByExcel", "", dict), "application/octet-stream", "产能标准值导出.xlsx");
        }
        [HttpGet]
        public FileResult ExportByExcelGYLX(string data)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("data", data);
            return File(sHttp.SApiDownload("MES", "MES/SCH/ExportByExcelGYLX", "", dict), "application/octet-stream", "工艺路线（车间）导出.xlsx");
        }
        [HttpGet]
        public FileResult ExportByExcelTemplet(string templetName,string exportName,string filetype)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("templetName", templetName);
            dict.Add("exportName", exportName);
            dict.Add("filetype", filetype);
            return File(sHttp.SApiDownload("MES", "Helper/File/ExportTempletExcel", "", dict), "application/octet-stream", "工艺路线（车间）模板导出.xlsx");
        }

        [HttpPost]
        public string UpdateSY_CN(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/UpdateSY_CN", data);
        }
        [HttpPost]
        public string ReadSY_TYPEMX(string TYPEID, string GC)
        {
            return sHttp.SApiPost("MES", "MES/SY/ReadSY_TYPEMX", "{\"TYPEID\":" + TYPEID + ",\"GC\":" + GC + "}");
        }
        [HttpPost]
        public string ReadSY_TYPEMX_LANGU(string data)
        {
            return sHttp.SApiPost("MES", "MES/SY/ReadSY_TYPEMX_LANGU", data);
        }
        [HttpPost]
        public string DeleteSY_CN(int ID)
        {
            return sHttp.SApiPost("MES", "MES/SCH/DeleteSY_CN", "{\"ID\":" + ID + "}");
        }
        [HttpPost]
        public string CreateSY_GYLX(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/CreateSY_GYLX", data);
        }
        [HttpPost]
        public string UpdateSY_GYLX(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/UpdateSY_GYLX", data);
        }
        [HttpPost]
        public string ReadSY_GYLX(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/ReadSY_GYLX", data);
        }
        [HttpPost]
        public string DeleteSY_GYLX(int ID)
        {
            return sHttp.SApiPost("MES", "MES/SCH/DeleteSY_GYLX", "{\"ID\":" + ID + "}");
        }
        [HttpPost]
        public string CreateSY_TYPEMX_LANGUAGE(string data)
        {
            return sHttp.SApiPost("MES", "MES/SY/CreateSY_TYPEMX_LANGUAGE", data);
        }
        [HttpPost]
        public string UpdateSY_TYPEMX_LANGUAGE(string data)
        {
            return sHttp.SApiPost("MES", "MES/SY/UpdateSY_TYPEMX_LANGUAGE", data);
        }
        [HttpPost]
        public string ReadSY_TYPEMX_LANGUAGE(string data)
        {
            return sHttp.SApiPost("MES", "MES/SY/ReadSY_TYPEMX_LANGUAGE", data);
        }
        [HttpPost]
        public string DeleteSY_TYPEMX_LANGUAGE(string data)
        {
            return sHttp.SApiPost("MES", "MES/SY/DeleteSY_TYPEMX_LANGUAGE", data);
        }
        [HttpPost]
        public string ReadSY_GZZX_SBBH(string data)
        {
            return sHttp.SApiPost("MES", "MES/SY/ReadSY_GZZX_SBBH", data);
        }
        [HttpPost]
        public string CreateSY_GZZX_SBBH_STATUS(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/CreateSY_GZZX_SBBH_STATUS", data);
        }
        [HttpPost]
        public string ReadSY_GZZX_SBBH_STATUS(string data)
        {
            return sHttp.SApiPost("MES", "MES/SCH/ReadSY_GZZX_SBBH_STATUS", data);
        }

        


        [HttpPost]
        public string ImportSY_GYLX(string gc, string gzzx)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI mr = new MES_RETURN_UI();
            if (string.IsNullOrEmpty(gc))
            {
                return "{\"code\":100,\"msg\":\"工厂信息不能为空\",\"scr\":\"\"}";
            }
            if (string.IsNullOrEmpty(gzzx))
            {
                return "{\"code\":100,\"msg\":\"工作中心不能为空\",\"scr\":\"\"}";
            }
            var file = Request.Files[0];
            string res = sHttp.SApiPost("MES", "MES/SCH/ImportSY_GYLXByExcel", SConvert.FilesToDic(Request.Files), new Dictionary<string, string>
            {
                { "gc", gc },
                { "gzzx", gzzx },
                {"type",".xlsx" }
            });
            //sHttp.SApiPost("Helper/Html/ReadTag", inputStr, "MES");
            // code 200
            return "{\"code\":100,\"msg\":\"导入数据成功\",\"scr\":\"\"}";

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
    }
}
