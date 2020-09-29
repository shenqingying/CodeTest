using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.MES.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_SCDATE_THService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class TMManageController : Controller
    {
        //
        // GET: /MES/TMManage/
        MESModels mesModels = new MESModels();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TM_DELETE()
        {
            AppClass.SetSession("location", 158);
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
        public ActionResult TM_UPDATE_ZT_PL()
        {
            AppClass.SetSession("location", 159);
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
            if (model_MODEL_MES_ALL.GCCOUNT == 1)
            {
                MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                model_MES_SY_TYPEMX.TYPEID = 9;
                model_MES_SY_TYPEMX.GC= model_MODEL_MES_ALL.MES_SY_GC[0].GC;
                MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST_CPZT = mesModels.SY_TYPEMX.SELECT(model_MES_SY_TYPEMX, token);
                model_MODEL_MES_ALL.MES_SY_TYPEMXLIST_CPZT = rst_MES_SY_TYPEMXLIST_CPZT;
                model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                model_MES_SY_TYPEMX.TYPEID = 17;
                model_MES_SY_TYPEMX.GC = model_MODEL_MES_ALL.MES_SY_GC[0].GC;
                MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST_ZFLB = mesModels.SY_TYPEMX.SELECT(model_MES_SY_TYPEMX, token);
                model_MODEL_MES_ALL.MES_SY_TYPEMXLIST_ZFLB = rst_MES_SY_TYPEMXLIST_ZFLB;
            }
            ViewData.Model = model_MODEL_MES_ALL;
            return View();
        }
        public ActionResult SCDATE_TH()
        {
            AppClass.SetSession("location", 163);
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

            MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
            model_MES_SY_TYPEMX.TYPEID = 23;
            MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST_TSFH = mesModels.SY_TYPEMX.SELECT(model_MES_SY_TYPEMX, token);
            model_MODEL_MES_ALL.MES_SY_TYPEMXLIST_TSFH = rst_MES_SY_TYPEMXLIST_TSFH;
            ViewData.Model = model_MODEL_MES_ALL;
            return View();
        }
        [HttpPost]
        public string GET_TMINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_TMINFO_BY_ROLE(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model_MES_TM_TMINFO.STAFFID = STAFFID;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_BY_ROLE(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_YGNAME(string YGH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.PUBLIC_FUNC.GET_YGNAME(YGH, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string POST_TM_DELETE(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO_DELETE_IN model_MES_TM_TMINFO_DELETE_IN = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_DELETE_IN>(datastring);
            model_MES_TM_TMINFO_DELETE_IN.STAFFID = STAFFID;
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.TM_TMINFO.DELETE_LOG(model_MES_TM_TMINFO_DELETE_IN, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }
        [HttpPost]
        public string GET_TYPEMX(int TYPEID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
            model_MES_SY_TYPEMX.TYPEID = TYPEID;
            MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST = mesModels.SY_TYPEMX.SELECT(model_MES_SY_TYPEMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_TYPEMXLIST);
        }
        [HttpPost]
        public string POST_TM_UPDATE(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO[] model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO[]>(datastring);
            for (int i = 0; i < model_MES_TM_TMINFO.Length; i++)
            {
                model_MES_TM_TMINFO[i].JLR = STAFFID;
            }
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.TM_TMINFO.UPDATE_CPZT(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }
        [HttpPost]
        public string GET_SCDATE_TH_BY_ROLE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_SCDATE_TH_SELECT_IN model_MES_SY_SCDATE_TH_SELECT_IN = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_SCDATE_TH_SELECT_IN>(datastring);
            model_MES_SY_SCDATE_TH_SELECT_IN.STAFFID = STAFFID;
            MES_SY_SCDATE_TH_SELECT rst = mesModels.SY_SCDATE_TH.SELECT_BY_ROLE(model_MES_SY_SCDATE_TH_SELECT_IN, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GETTIME()
        {
            string token = AppClass.GetSession("token").ToString();
            string nowtime = Convert.ToDateTime(mesModels.PUBLIC_FUNC.GET_TIME(token)).ToString("yyyy-MM-dd");
            return nowtime;
        }
        [HttpPost]
        public string GET_GZZX_BY_ROLE(string GC)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
            model_MES_SY_GZZX.GC = GC;
            model_MES_SY_GZZX.STAFFID = STAFFID;
            MES_SY_GZZX[] rst = mesModels.SY_GZZX.SELECT_BY_ROLE(model_MES_SY_GZZX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string POST_SCDATE_TH(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_SCDATE_TH[] model_MES_SY_SCDATE_TH = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_SCDATE_TH[]>(datastring);
            for (int a = 0; a < model_MES_SY_SCDATE_TH.Length; a++)
            {
                model_MES_SY_SCDATE_TH[a].CJR = STAFFID;
            }
            MES_RETURN_UI rst = mesModels.SY_SCDATE_TH.INSERT(model_MES_SY_SCDATE_TH, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
    }
}
