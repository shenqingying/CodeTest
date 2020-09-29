using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.MES.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.CRM_LoginService;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.PD_TL_ERRORService;
using Sonluk.UI.Model.MES.PD_TLGLService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZX_WLLBService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MES.SY_CHANGEINFOService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPOI.XSSF.UserModel;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.SY_PLDHService;
using Sonluk.UI.Model.MES.MES_TPMService;
using Sonluk.UI.Model.QM.ZSL_QMFG_RFCService;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class MESSelectController : Controller
    {
        //
        // GET: /MES/MESSelect/
        MESModels mesModels = new MESModels();
        CRMModels crmModels = new CRMModels();
        QMModels qmModels = new QMModels();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CHANGEINFO_SELECT()
        {
            AppClass.SetSession("location", 124);
            return View();
        }
        public ActionResult SCJD_SELECT()
        {
            AppClass.SetSession("location", 125);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            ViewData.Model = model;
            return View();
        }

        public ActionResult TMGL_SELECT()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            AppClass.SetSession("location", 151);
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            ViewData.Model = model;
            return View();
        }


        public ActionResult PD_TL_ERROR()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            AppClass.SetSession("location", 152);
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            ViewData.Model = model;
            return View();
        }

        public ActionResult PD_TL_SELECT()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            AppClass.SetSession("location", 154);
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            ViewData.Model = model;
            return View();
        }

        public ActionResult PD_SCRW_SELECT_FJ()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 155);
            MODEL_MES_VIEW model = new MODEL_MES_VIEW();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            if (Request.Cookies["FJLIST"] != null)
            {
                string SBBH = Request.Cookies["FJLIST"].Value;
                MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                model_MES_SY_GZZX_SBH.SBBH = SBBH;
                MES_SY_GZZX_SBH[] rst_MES_SY_GZZX_SBH = mesModels.SY_GZZX_SBH.SELECT(model_MES_SY_GZZX_SBH, token);
                if (rst_MES_SY_GZZX_SBH.Length > 0)
                {
                    model.GC = rst_MES_SY_GZZX_SBH[0].GC;
                    model.GZZXBH = rst_MES_SY_GZZX_SBH[0].GZZXBH;
                    model.SBBH = rst_MES_SY_GZZX_SBH[0].SBBH;
                    model.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
                    MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                    model_MES_SY_GZZX.GC = model.GC;
                    model_MES_SY_GZZX.STAFFID = STAFFID;
                    model_MES_SY_GZZX.WLLBNAME = "锌膏";
                    MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_BY_ROLE(model_MES_SY_GZZX, token);
                    model.MES_SY_GZZX = rst_MES_SY_GZZX;
                    model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                    model_MES_SY_GZZX_SBH.GC = model.GC;
                    model_MES_SY_GZZX_SBH.GZZXBH = model.GZZXBH;
                    rst_MES_SY_GZZX_SBH = mesModels.SY_GZZX_SBH.SELECT(model_MES_SY_GZZX_SBH, token);
                    model.MES_SY_GZZX_SBH = rst_MES_SY_GZZX_SBH;
                }
            }
            ViewData.Model = model;
            return View();
        }

        public ActionResult AUTO_LOGIN_FJVIEW()
        {
            ActionResult target;
            bool isautologin = AUTO_LOGIN();
            if (isautologin == false)
            {
                target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
            }
            else
            {
                string token = AppClass.GetSession("token").ToString();
                if (Request.Cookies["FJLIST"] != null)
                {
                    string SBBH = Request.Cookies["FJLIST"].Value;
                    MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                    model_MES_SY_GZZX_SBH.SBBH = SBBH;
                    MES_SY_GZZX_SBH[] rst_MES_SY_GZZX_SBH = mesModels.SY_GZZX_SBH.SELECT(model_MES_SY_GZZX_SBH, token);
                    MES_PD_SCRW model_MES_PD_SCRW_old = new MES_PD_SCRW();
                    model_MES_PD_SCRW_old.GC = rst_MES_SY_GZZX_SBH[0].GC;
                    model_MES_PD_SCRW_old.GZZXBH = rst_MES_SY_GZZX_SBH[0].GZZXBH;
                    model_MES_PD_SCRW_old.SBBH = rst_MES_SY_GZZX_SBH[0].SBBH;
                    model_MES_PD_SCRW_old.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
                    AppClass.SetSession("SCRW_FJ", model_MES_PD_SCRW_old);
                    Request.Cookies["FJLIST"].Value = SBBH;
                    Request.Cookies["FJLIST"].Expires = DateTime.Now.AddDays(10);
                    target = RedirectToAction("PD_SCRW_SELECT_FJ_LIST", "MESSelect", new { area = "MES" });

                }
                else
                {
                    target = RedirectToAction("PD_SCRW_SELECT_FJ", "MESSelect", new { area = "MES" });
                }
            }
            return target;
        }

        public ActionResult PD_SCRW_SELECT_FJ_LIST()
        {
            string token = AppClass.GetSession("token").ToString();

            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            AppClass.SetSession("location", 155);
            MES_PD_SCRW model_MES_PD_SCRW = (MES_PD_SCRW)AppClass.GetSession("SCRW_FJ");
            MODEL_MES_VIEW model = new MODEL_MES_VIEW();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            if (model_MES_PD_SCRW != null)
            {
                model.GC = model_MES_PD_SCRW.GC;
                model.GZZXBH = model_MES_PD_SCRW.GZZXBH;
                model.SBBH = model_MES_PD_SCRW.SBBH;
                model.ZPRQ = model_MES_PD_SCRW.ZPRQ;
                MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                model_MES_SY_GZZX.GC = model.GC;
                model_MES_SY_GZZX.STAFFID = STAFFID;
                model_MES_SY_GZZX.WLLBNAME = "锌膏";
                MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_BY_ROLE(model_MES_SY_GZZX, token);
                model.MES_SY_GZZX = rst_MES_SY_GZZX;
                MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                model_MES_SY_GZZX_SBH.GC = model.GC;
                model_MES_SY_GZZX_SBH.GZZXBH = model.GZZXBH;
                MES_SY_GZZX_SBH[] rst_MES_SY_GZZX_SBH = mesModels.SY_GZZX_SBH.SELECT(model_MES_SY_GZZX_SBH, token);
                model.MES_SY_GZZX_SBH = rst_MES_SY_GZZX_SBH;
            }
            ViewData.Model = model;
            return View();
        }
        public ActionResult TL_GL_CC_SELECT()
        {
            AppClass.SetSession("location", 160);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MODEL_MES_ALL model_MODEL_MES_ALL = new MODEL_MES_ALL();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model_MODEL_MES_ALL.MES_SY_GC = MES_SY_GC_list;
            model_MODEL_MES_ALL.GCCOUNT = MES_SY_GC_list.Length;
            model_MODEL_MES_ALL.GZZXCOUNT = 0;
            if (model_MODEL_MES_ALL.GCCOUNT == 1)
            {
                MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                model_MES_SY_GZZX.GC = MES_SY_GC_list[0].GC;
                model_MES_SY_GZZX.STAFFID = STAFFID;
                MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_BY_ROLE(model_MES_SY_GZZX, token);
                model_MODEL_MES_ALL.MES_SY_GZZX = rst_MES_SY_GZZX;
                model_MODEL_MES_ALL.GZZXCOUNT = rst_MES_SY_GZZX.Length;
            }
            model_MODEL_MES_ALL.SBHCOUNT = 0;
            if (model_MODEL_MES_ALL.GZZXCOUNT == 1)
            {
                MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                model_MES_SY_GZZX_SBH.GC = model_MODEL_MES_ALL.MES_SY_GC[0].GC;
                model_MES_SY_GZZX_SBH.GZZXBH = model_MODEL_MES_ALL.MES_SY_GZZX[0].GZZXBH;
                MES_SY_GZZX_SBH[] rst_MES_SY_GZZX_SBH = mesModels.SY_GZZX_SBH.SELECT(model_MES_SY_GZZX_SBH, token);
                model_MODEL_MES_ALL.MES_SY_GZZX_SBH = rst_MES_SY_GZZX_SBH;
                model_MODEL_MES_ALL.SBHCOUNT = rst_MES_SY_GZZX_SBH.Length;
            }
            ViewData.Model = model_MODEL_MES_ALL;
            return View();
        }
        public ActionResult PLDH_MANAGE_SELECT()
        {
            AppClass.SetSession("location", 10023);
            return View();
        }
        public ActionResult MES_NOSM_TPM_SELECT()
        {
            AppClass.SetSession("location", 10105);
            return View();
        }
        public ActionResult MES_YH_SELECT()
        {
            AppClass.SetSession("location", 10109);
            return View();
        }
        [HttpPost]
        public string GET_GZZX(string GC)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_SY_GZZX model = new MES_SY_GZZX();
            model.GC = GC;
            MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_USER(model, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX);
            return rst;
        }

        [HttpPost]
        public string GET_GZZX_BY_ROLE(string GC, string WLLBNAME)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_SY_GZZX model = new MES_SY_GZZX();
            model.GC = GC;
            model.STAFFID = STAFFID;
            model.WLLBNAME = WLLBNAME;
            MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_BY_ROLE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX);
        }
        [HttpPost]
        public string SCJD_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_PD_GD_GDJD_IMPORT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD_GDJD_IMPORT>(datastring);
            model.STAFFID = STAFFID;
            MES_PD_GD_GDJD_SELECT res = mesModels.PD_GD.SELECT_GDJD(model, token);
            if (res.ZBCFUN_GDRKS_READ != null && res.ZBCFUN_GDRKS_READ.ET_POLIST != null)
            {
                for (int i = 0; i < res.ZBCFUN_GDRKS_READ.ET_POLIST.Length; i++)
                {
                    try
                    {
                        res.ZBCFUN_GDRKS_READ.ET_POLIST[i].KDPOS = Convert.ToInt32(res.ZBCFUN_GDRKS_READ.ET_POLIST[i].KDPOS).ToString();
                        if (res.ZBCFUN_GDRKS_READ.ET_POLIST[i].KDPOS.Equals("0"))
                        {
                            res.ZBCFUN_GDRKS_READ.ET_POLIST[i].KDPOS = "";
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);

        }

        [HttpPost]
        public string GET_TYPEMX(string GC, int TYPEID)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_SY_TYPEMX model = new MES_SY_TYPEMX();
            model.GC = GC;
            model.TYPEID = TYPEID;
            MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST = mesModels.SY_TYPEMX.SELECT(model, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_TYPEMXLIST);
            return rst;
        }
        [HttpPost]
        public string GET_TYPEMX_ID(int ID, string GC, int TYPEID)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_SY_TYPEMX model = new MES_SY_TYPEMX();
            model.GC = GC;
            model.TYPEID = TYPEID;
            model.ID = ID;
            MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST = mesModels.SY_TYPEMX.SELECT(model, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_TYPEMXLIST);
            return rst;
        }

        [HttpPost]
        public string GET_WLGROUP(string GC)
        {
            string rst = "";
            string token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL_GROUP model_MES_SY_MATERIAL_GROUP = new MES_SY_MATERIAL_GROUP();
            model_MES_SY_MATERIAL_GROUP.GC = GC;
            MES_SY_MATERIAL_GROUP_SELECT rst_MES_SY_MATERIAL_GROUP_SELECT = mesModels.SY_MATERIAL_GROUP.SELECT_USER(model_MES_SY_MATERIAL_GROUP, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_MATERIAL_GROUP_SELECT);
            return rst;
        }
        [HttpPost]
        public string GET_WLGROUP_datastring(string datastring)
        {
            string rst = "";
            string token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL_GROUP model_MES_SY_MATERIAL_GROUP = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_GROUP>(datastring);
            MES_SY_MATERIAL_GROUP_SELECT rst_MES_SY_MATERIAL_GROUP_SELECT = mesModels.SY_MATERIAL_GROUP.SELECT_USER(model_MES_SY_MATERIAL_GROUP, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_MATERIAL_GROUP_SELECT);
            return rst;
        }

        [HttpPost]
        public string GET_KCDD(string GC)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_MM_CK model = new MES_MM_CK();
            model.GC = GC;
            MES_MM_CK_SELECT rst_MES_MM_CK_SELECT = mesModels.MM_CK.SELECT_USER(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_MM_CK_SELECT);
        }

        [HttpPost]
        public string GET_SBBH(string GC, string GZZXBH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.GC = GC;
            model.GZZXBH = GZZXBH;
            MES_SY_GZZX_SBH[] rst_MES_SY_GZZX_SBH = mesModels.SY_GZZX_SBH.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX_SBH);
        }

        [HttpPost]
        public string GET_TMINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model_MES_TM_TMINFO.TMLB = 1;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_TMINFO_ALL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model_MES_TM_TMINFO.TMLB = 1;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_ALL(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_TMINFO_TL_GL_CC(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model_MES_TM_TMINFO.STAFFID = STAFFID;
            MES_TM_TMINFO_SELECT_TL_GL_CC rst_MES_TM_TMINFO_SELECT_TL_GL_CC = mesModels.TM_TMINFO.SELECT_TL_GL_CC(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_TM_TMINFO_SELECT_TL_GL_CC);
        }
        [HttpPost]
        public string GET_TMINFO_GL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST[] model_MES_TM_TMINFO_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST[]>(datastring);
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_GLSELECT(model_MES_TM_TMINFO_LIST, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_TMINFO_GL_ALL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST[] model_MES_TM_TMINFO_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST[]>(datastring);
            for(int a=0;a<model_MES_TM_TMINFO_LIST.Length;a++)
            {
                if(string.IsNullOrEmpty(model_MES_TM_TMINFO_LIST[a].TM))
                {
                    model_MES_TM_TMINFO_LIST[a].TM = "";
                }
            }
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_GLSELECT_ALL(model_MES_TM_TMINFO_LIST, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string POST_GLSELECT(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST[]>(datastring);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/关联条码导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SCDATE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BCMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBHMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].RWBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CLCJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GYLX);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GYS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GYSMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GYSPC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CPZTNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PFDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PLDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH);
                    row.CreateCell(cellIndex++).SetCellValue((double)model[i].SL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].KSTIME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JSTIME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XFCDNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].DCDJMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].DCXHMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TPM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBCDMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].REMARK);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JLRMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JLTIME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].NOBILL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].NOBILLMX);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLGROUP);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLGROUPNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBZ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SIZENAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SYSCX);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SYCPGG);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERPNO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].UNITSNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].DCSLBS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].DCSLMBSL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].DCSLYS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].RQM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZFDCLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].KCDD);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].KCDDNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CGBILL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CGBILLMX);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CFTS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XDGXNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].MOULD);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CPTYPENAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WQH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].MFQCOLORNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CLPBDM);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), now + STAFFID + "2"), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now + STAFFID + "2";
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public ActionResult EXPORT_GLSELECT_TM(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "条码导出.xls");
        }
        [HttpPost]
        public string GET_TL_ERROR(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_PD_TL_ERROR model_MES_PD_TL_ERROR = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_TL_ERROR>(datastring);
            MES_PD_TL_ERROR_SELECT rst_MES_PD_TL_ERROR_SELECT = mesModels.PD_TL_ERROR.SELECT(model_MES_PD_TL_ERROR, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_TL_ERROR_SELECT);
        }
        [HttpPost]
        public string GET_TL_ERROR_BY_ROLE(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_PD_TL_ERROR model_MES_PD_TL_ERROR = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_TL_ERROR>(datastring);
            model_MES_PD_TL_ERROR.STAFFID = STAFFID;
            MES_PD_TL_ERROR_SELECT rst_MES_PD_TL_ERROR_SELECT = mesModels.PD_TL_ERROR.SELECT(model_MES_PD_TL_ERROR, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_TL_ERROR_SELECT);
        }
        public string EXPORT_SCJD_SELECT(string datastring, string exceltype)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            if (exceltype.Equals("0"))
            {
                try
                {
                    MES_PD_GD_GDJD_EXPORT[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD_GDJD_EXPORT[]>(datastring);
                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/生产进度查询-设备号.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 1;
                    for (int i = 0; i < model.Length; i++)
                    {
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXBH);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].SBHMS);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].WLLBNAME);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].ERPNO);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].WLH);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].WLMS);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].XSNOBILL);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].XSNOBILLMX);
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].GDCOUNT));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].FINISHCOUNT));
                        //row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].CYCOUNT));
                        row.CreateCell(cellIndex++).SetCellValue(model[i].UNITSNAME);

                    }

                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now + STAFFID + "13";
                }
                catch (Exception e)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "导出失败"+e.Message;
                }

            }
            else
            {
                try
                {
                    ZSL_BCST024_PO[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCST024_PO[]>(datastring);
                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/生产进度查询模版-工单.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 1;
                    for (int i = 0; i < model.Length; i++)
                    {
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].ARBPL);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].AUFNR);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].WLDL);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].MATNR);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].MAKTX);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KDAUF);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KDPOS);
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].PSMNG));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].WEMNG));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].TMSL));
                        row.CreateCell(cellIndex++).SetCellValue(model[i].AMEIN);

                    }

                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now + STAFFID + "13";
                }
                catch
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "导出失败！";
                }
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string EXPORT_CHANGEINFO_EXCEL(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                MES_SY_CHANGEINFOLIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_CHANGEINFOLIST[]>(datastring);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/信息变更模版.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CHANGGEDJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CHANGETABLE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CHANGEZD);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].OLDINFO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].NEWINFO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CHANGEPEOPLE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CHANGETIME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CHANGENAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CHANGEGH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CHANGESY);
                }

                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now + STAFFID + "13";
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string POST_TL_ERROR(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                MES_PD_TL_ERROR_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_TL_ERROR_LIST[]>(datastring);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/投料错误记录导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GCNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].RWBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZPRQ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERRORTM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERRORWLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERRORWLNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERRORINFO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERRORPC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERRORJLSJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERRORJLR);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), now + STAFFID + "3"), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now + STAFFID + "3";
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_CHANGEINFO(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "信息变更记录导出.xls");
        }
        public ActionResult EXPORT_CHANGEINFO_SCJD(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "生产进度查询导出.xlsx");
        }

        public ActionResult EXPORT_TL_ERROR(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "投料错误记录导出.xls");
        }

        [HttpPost]
        public string GET_NOWTIME()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        [HttpPost]
        public string GET_SBFL_BY_GZZXBH(string GC, string GZZXBH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_GZZX_WLLB model_MES_SY_GZZX_WLLB = new MES_SY_GZZX_WLLB();
            model_MES_SY_GZZX_WLLB.GC = GC;
            model_MES_SY_GZZX_WLLB.GZZXBH = GZZXBH;
            MES_SY_GZZX_WLLB_SELECT rst_MES_SY_GZZX_WLLB_SELECT = mesModels.SY_GZZX_WLLB.SELECT(model_MES_SY_GZZX_WLLB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX_WLLB_SELECT);
        }
        [HttpPost]
        public string GET_PD_TL_REPORT(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_PD_TL_IN_SELECT_REPORT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_TL_IN_SELECT_REPORT>(datastring);
            model.STAFFID = STAFFID;
            MES_PD_TL_SELECT_REPORT rst_MES_PD_TL_SELECT_REPORT = mesModels.PD_TLGL.SELECT_REPORT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_TL_SELECT_REPORT);
        }
        [HttpPost]
        public string GET_PD_TL_REPORT_XC(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            Sonluk.UI.Model.MES.TM_TMINFOService.MES_PD_TL_SELECT_REPORT_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.TM_TMINFOService.MES_PD_TL_SELECT_REPORT_LIST[]>(datastring);
            MES_TM_TMINFO_XCTMINFO rst_MES_TM_TMINFO_XCTMINFO = mesModels.TM_TMINFO.GET_XCTMINFO_BY_TMLIST(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_TM_TMINFO_XCTMINFO);
        }

        [HttpPost]
        public string POST_TL_REPORT(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                Sonluk.UI.Model.MES.PD_TLGLService.MES_PD_TL_SELECT_REPORT_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.PD_TLGLService.MES_PD_TL_SELECT_REPORT_LIST[]>(datastring);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/投料信息查询导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    string tlth = "";
                    if (model[i].TLTH == 0)
                    {
                        tlth = "";
                    }
                    else
                    {
                        tlth = model[i].TLTH.ToString();
                    }
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZPRQ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].RWBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GDDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERPNO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLTM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLWLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLWLNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLWLLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLRQ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JLRNAME);
                    row.CreateCell(cellIndex++).SetCellValue(tlth);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GYSPC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLSBHMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLPFDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLPLDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLSCDATE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLBCMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLREMARK);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PFDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].REMARK);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLINFOREMARK);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), now + STAFFID + "5"), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now + STAFFID + "5";
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public ActionResult EXPORT_TL_REPORT(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "信息查询导出.xls");
        }
        [HttpPost]
        public string POST_TL_REPORT_XC(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_XCTMINFO_BY_TMLIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_XCTMINFO_BY_TMLIST[]>(datastring);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/投料下层信息记录.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    string TH = "";
                    if (model[i].TH == 0)
                    {
                        TH = "";
                    }
                    else
                    {
                        TH = model[i].TH.ToString();
                    }
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLSJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLWLLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLWLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SCDATE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BCNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(TH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PFDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PLDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XCWLLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XCWLNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GYSJC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XCSBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GYSPC);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "5"), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now + STAFFID + "5";
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_TL_REPORT_XC(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "投料下层信息记录.xlsx");
        }
        [HttpPost]
        public string POST_SCRW_FJ(string GC, string GZZXBH, string SBBH, string ZPRQ)
        {
            Response.Cookies["FJLIST"].Value = SBBH;
            Response.Cookies["FJLIST"].Expires = DateTime.Now.AddDays(10);
            string token = AppClass.GetSession("token").ToString();
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.GC = GC;
            model_MES_PD_SCRW.GZZXBH = GZZXBH;
            model_MES_PD_SCRW.SBBH = SBBH;
            model_MES_PD_SCRW.ZPRQ = ZPRQ;
            AppClass.SetSession("SCRW_FJ", model_MES_PD_SCRW);
            MES_RETURN_UI model_MES_RETURN_UI = new MES_RETURN_UI();
            model_MES_RETURN_UI.TYPE = "S";
            model_MES_RETURN_UI.MESSAGE = "";
            return Newtonsoft.Json.JsonConvert.SerializeObject(model_MES_RETURN_UI);
        }

        [HttpPost]
        public string GET_SCRW_FJ(string GC, string GZZXBH, string SBBH, string ZPRQ)
        {
            //string token = AppClass.GetSession("token").ToString();
            string token = Request.Cookies["token"].Value;
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.GC = GC;
            model_MES_PD_SCRW.GZZXBH = GZZXBH;
            model_MES_PD_SCRW.SBBH = SBBH;
            model_MES_PD_SCRW.ZPRQ = ZPRQ;
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = mesModels.PD_SCRW.SELECT(model_MES_PD_SCRW, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_SCRW);
        }

        public bool AUTO_LOGIN()
        {
            string username = "";
            string password = "";
            if (Request.Cookies["userName"] != null && Request.Cookies["password"] != null)
            {
                username = Request.Cookies["userName"].Value;
                password = Request.Cookies["password"].Value;

                CRM_LoginInfo tokeninfo = crmModels.CRM_Login.Login(username, password, "", "", 1, 0);
                Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
                if (tokeninfo.TokenInfo.access_token == null)
                {
                    return false;
                }
                else
                {
                    Session["ErrorMessage"] = null;
                    Session["token"] = tokeninfo.TokenInfo.access_token;
                    Session["STAFFID"] = tokeninfo.TokenInfo.STAFFID;
                    Session["NAME"] = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token).STAFFNAME;
                    Response.Cookies["userName"].Value = username;
                    Response.Cookies["userName"].Expires = DateTime.Now.AddDays(10);
                    Response.Cookies["password"].Value = password;
                    Response.Cookies["password"].Expires = DateTime.Now.AddDays(10);
                    Response.Cookies["token"].Value = tokeninfo.TokenInfo.access_token;
                    Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
                    return true;
                }

            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        public string GET_TIME_NOW()
        {
            string token = AppClass.GetSession("token").ToString();
            return mesModels.PUBLIC_FUNC.GET_TIME(token);
        }
        public ActionResult SCRW_SELECT_FJ_YL()
        {
            AppClass.SetSession("location", 123);
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
        public string Data_Select_SCRW_FJYL(string GC, string GZZXBH, string ZPRQKS, string ZPRQJS, int CXLB)
        {
            string token = Session["token"].ToString();

            MES_PD_SCRW model = new MES_PD_SCRW();
            model.GC = GC;
            model.GZZXBH = GZZXBH;
            model.ZPRQKS = ZPRQKS;
            model.ZPRQJS = ZPRQJS;
            model.CXLB = CXLB;
            SELECT_MES_PD_SCRW data = mesModels.PD_SCRW.SELECT(model, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return rst;
        }

        [HttpPost]
        public string EXPOST_FJYL(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                MES_PD_SCRW_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW_LIST[]>(alldata);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/负极用料查询导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GDDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERPNO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XFWLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XFCDNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XFPC);
                    row.CreateCell(cellIndex++).SetCellValue((double)model[i].SL);
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
        public ActionResult EXPORT_READ_FJYL(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "负极用料查询信息.xls");
        }


        [HttpPost]
        public string GetChangeInfoData(string kstime, string jstime)
        {
            MES_SY_CHANGEINFOLIST model = new MES_SY_CHANGEINFOLIST();
            model.CHANGETIMEKS = kstime;
            model.CHANGETIMEJS = jstime;
            string token = Session["token"].ToString();
            MES_SY_CHANGEINFO_SELECT res = mesModels.SY_CHANGEINFO.SELECT(model, token);
            //string a = Newtonsoft.Json.JsonConvert.SerializeObject(res);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public ActionResult FJ_ALL_TLXX()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 161);
            MES_SY_GZZX_SBH sbh = new MES_SY_GZZX_SBH();
            sbh.GZZXBH = "Z2002";
            MES_SY_GZZX_SBH[] sb = mesModels.SY_GZZX_SBH.SELECT(sbh, token);
            MES_SY_FJ_RWKB model_MES_SY_FJ_RWKB = new MES_SY_FJ_RWKB();
            model_MES_SY_FJ_RWKB.GZZXBH = "Z2002";
            model_MES_SY_FJ_RWKB.ZPRQ = mesModels.PUBLIC_FUNC.GET_TIME(token).Substring(0, 10);
            MES_SY_FJ_RWKB_SELECT model_MES_SY_FJ_RWKB_SELECT = mesModels.PD_SCRW.SELECT_JDKB(model_MES_SY_FJ_RWKB, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gzzx_sbh = sb;
            data.Mes_sy_fj_rwkb_select = model_MES_SY_FJ_RWKB_SELECT;
            ViewData.Model = data;

            return View();
        }
        [HttpPost]
        public string GET_FJ_JDKB(string GZZXBH, string SBBH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_FJ_RWKB model_MES_SY_FJ_RWKB = new MES_SY_FJ_RWKB();
            model_MES_SY_FJ_RWKB.GZZXBH = GZZXBH;
            model_MES_SY_FJ_RWKB.SBBH = SBBH;
            model_MES_SY_FJ_RWKB.ZPRQ = mesModels.PUBLIC_FUNC.GET_TIME(token).Substring(0, 10);
            MES_SY_FJ_RWKB_SELECT rst_MES_SY_FJ_RWKB_SELECT = mesModels.PD_SCRW.SELECT_JDKB(model_MES_SY_FJ_RWKB, token);
            string listdata = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_FJ_RWKB_SELECT);
            return listdata;
        }
        [HttpPost]
        public string GET_SCRW_FJKB(string GC, string GZZXBH, string SBBH)
        {
            //string token = AppClass.GetSession("token").ToString();
            string token = Request.Cookies["token"].Value;
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.GC = GC;
            model_MES_PD_SCRW.GZZXBH = GZZXBH;
            model_MES_PD_SCRW.SBBH = SBBH;
            model_MES_PD_SCRW.ZPRQ = mesModels.PUBLIC_FUNC.GET_TIME(token).Substring(0, 10);
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = mesModels.PD_SCRW.SELECT(model_MES_PD_SCRW, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_SCRW);
        }
        [HttpPost]
        public string GET_SCRW_FJKB_NEXTDAY(string GC, string GZZXBH, string SBBH)
        {
            //string token = AppClass.GetSession("token").ToString();
            string token = Request.Cookies["token"].Value;
            string TIME = mesModels.PUBLIC_FUNC.GET_TIME(token).Substring(0, 10);
            DateTime NowTime = Convert.ToDateTime(TIME);
            string NextTime = NowTime.AddDays(1).ToString("yyyy-MM-dd");
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.GC = GC;
            model_MES_PD_SCRW.GZZXBH = GZZXBH;
            model_MES_PD_SCRW.SBBH = SBBH;
            model_MES_PD_SCRW.ZPRQ = NextTime;
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = mesModels.PD_SCRW.SELECT(model_MES_PD_SCRW, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_SCRW);
        }
        [HttpPost]
        public string UPDATE_ISLEAVE(string datastring)
        {
            string token = Request.Cookies["token"].Value;
            MES_PD_SCRW_UPDATE_IN model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW_UPDATE_IN>(datastring);
            MES_RETURN_UI rst_UPDATE_ISLEAVE = mesModels.PD_SCRW.UPDATE_ALL(model, 1, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_UPDATE_ISLEAVE);
        }
        public ActionResult AUTO_LOGIN_FJKB()
        {
            ActionResult target;
            bool isautologin = AUTO_LOGIN();
            if (isautologin == false)
            {
                target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
            }
            else
            {
                target = RedirectToAction("FJ_ALL_TLXX", "MESSelect", new { area = "MES" });
            }
            return target;
        }
        [HttpPost]
        public string POST_TL_GL_CC_OUT(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_SELECT_TL_GL_CC_OUT[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_SELECT_TL_GL_CC_OUT[]>(datastring);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/投料关联产出查询.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 2;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERPNO);
                    row.CreateCell(cellIndex++).SetCellValue((double)model[i].GDSL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].RQM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XDGXNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBCDMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].NOBILL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].NOBILLMX);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBHMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SCDATE);
                    row.CreateCell(cellIndex++).SetCellValue((double)model[i].SL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLTH);
                    row.CreateCell(cellIndex++).SetCellValue((double)model[i].TLSL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLWLLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLGZZXMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLSCDATE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLDCDJMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLWLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLWLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLTM);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "1"), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now + STAFFID + "1";
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_TL_GL_CC_REPORT(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "投料关联产出查询.xlsx");
        }
        [HttpPost]
        public string MES_SY_PLDH_PH_SELECT_LB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_PLDH_PH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH_PH>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_PLDH_PH_SELECT rst = mesModels.SY_PLDH.SELECT_PLDH_PH_LB(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_MES_SY_PLDH_PH_SELECT(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_PLDH_PH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_PLDH_PH>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_PLDH_PH_SELECT result = mesModels.SY_PLDH.SELECT_PLDH_PH_LB(model, token);
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
                string tt = "工厂,配方类别,配方单号,配料单号,物料编码,物料描述,批次,检验批";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < result.MES_SY_PLDH_PH.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_PLDH_PH[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_PLDH_PH[i].PFLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_PLDH_PH[i].PFDH);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_PLDH_PH[i].PLDH);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_PLDH_PH[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_PLDH_PH[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_PLDH_PH[i].PH);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_PLDH_PH[i].JYP);
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
        public string MES_TPM_SELECT_TPM_SYNC(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_TPM_SYNC model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_TPM_SYNC>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_TPM_SYNC_SELECT rst = mesModels.MES_TPM.SELECT_TPM_SYNC(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_NOSM_TPM(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_TPM_SYNC model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_TPM_SYNC>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_TPM_SYNC_SELECT result = mesModels.MES_TPM.SELECT_TPM_SYNC(model, token);
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
                string tt = "序号,工厂,工作中心,工作中心描述,托盘码,库存地点,仓位,物料编码,物料描述,批次,销售订单,销售项目,工单";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < result.MES_SY_TPM_SYNC.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue((i + 1).ToString());
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].WERKS);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].ARBPL);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].LTXA1);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].TPM);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].LGORT);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].LGPLA);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].MATNR);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].MAKTX);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].CHARG);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].KDAUF);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].KDPOS);
                    row.CreateCell(cellIndex++).SetCellValue(result.MES_SY_TPM_SYNC[i].AUFNR);
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
        public string QM_ZSL_QMFG_RFC_ZSL_QMFM_012(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            ZSL_QMFM_012_SELECT model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_QMFM_012_SELECT>(datastring);
            model.STAFFID = STAFFID;
            ZSL_QMFM_012_SELECT rst = qmModels.ZSL_QMFG_RFC.ZSL_QMFM_012(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_YHINFO(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            ZSL_QMFM_012_SELECT model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_QMFM_012_SELECT>(datastring);
            model.STAFFID = STAFFID;
            ZSL_QMFM_012_SELECT result = qmModels.ZSL_QMFG_RFC.ZSL_QMFM_012(model, token);
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
                string tt = "验货开始日期,验货结束日期,工作中心,物料,客户货号,客户物料描述,公司物料描述,销售凭证,销售凭证行项目,基本数量,单位,卡（缩）数,箱数,托数,仓位,仓位数量,仓位箱数,验货人员,创建人员,验货单号,验货单行项目,客户编号,客户名称,验货信息状态,备注,行项目备注一,行项目备注二,业务员提交日期,业务员提交时间,工厂,供应商,出运单号,销售雇员,负责雇员,品牌,品牌描述,包装形式,包装数量,产品型号,外观,色差,跌落,短路,三正一反,电性能,生产订单,生产完成日期,销售订单库存,情况说明,验货结果";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < result.ET_YHINFO.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZFYDAT);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZLYDAT);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].KTEXT);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].MATNR);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].BSTKD);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ARKTX);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].MAKTX);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].VBELN);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].POSNR);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].KWMENG);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].VRKME);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].I2);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZZCAT);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZBQTY);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].LGPLA2);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].GESME2);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].I3);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZNAME);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ERNAM);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].YHNO);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ITEM);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].KUNNR);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].NAME);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].FLAG);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZTEXT);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZTEXT1);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZTEXT2);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ERDAT1);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ERZET1);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].WERKS);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].LIFNR_PO);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].CYNO);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].NAME1);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].NAME2);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].LABOR);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].LBTXT);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].MVGR1T);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].MVGR2T);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].MVGR4T);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZWG);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZSEC);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZDL);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZDUANL);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZSZYF);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZDXN);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].AUFNR);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].GLTRP);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].KALAB);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZTEXT3);
                    row.CreateCell(cellIndex++).SetCellValue(result.ET_YHINFO[i].ZTEXT4);
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
    }
}
