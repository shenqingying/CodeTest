using Sonluk.Mobile.APPCLASS;
using Sonluk.Mobile.Models;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.TM_CZRService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Mobile.Areas.MES.Controllers
{
    public class SCRW_TLController : Controller
    {
        //
        // GET: /MES/SCRW_TL/
        MESModels mesmodels = new MESModels();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TL_BB()
        {
            return View();
        }

        [HttpPost]
        public string GET_GZZX_SBH_BYSBBH(string in_sm)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            //string token = AppClass.GetSession("token").ToString();
            MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
            model_MES_SY_GZZX_SBH.SBBH = in_sm;
            MES_SY_GZZX_SBH[] rst_MES_SY_GZZX_SBH = mesmodels.SY_GZZX_SBH.SELECT(model_MES_SY_GZZX_SBH, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX_SBH);
        }

        [HttpPost]
        public string GET_GZZX_SBH_BYSBNO(string in_sm)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            //string token = AppClass.GetSession("token").ToString();
            MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
            model_MES_SY_GZZX_SBH.SBNO = in_sm;
            MES_SY_GZZX_SBH[] rst_MES_SY_GZZX_SBH = mesmodels.SY_GZZX_SBH.SELECT(model_MES_SY_GZZX_SBH, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX_SBH);
        }
        [HttpPost]
        public string GET_GZZX_SBH_BYSBNOANDGC(string in_sm,string GC)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            //string token = AppClass.GetSession("token").ToString();
            MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
            model_MES_SY_GZZX_SBH.SBNO = in_sm;
            model_MES_SY_GZZX_SBH.GC = GC;
            MES_SY_GZZX_SBH[] rst_MES_SY_GZZX_SBH = mesmodels.SY_GZZX_SBH.SELECT(model_MES_SY_GZZX_SBH, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX_SBH);
        }

        [HttpPost]
        public string GET_RWBH_BYTPM(string datastring)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            //string token = AppClass.GetSession("token").ToString();
            MES_PD_SCRW_GET_BY_TPM model_MES_PD_SCRW_GET_BY_TPM = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW_GET_BY_TPM>(datastring);
            model_MES_PD_SCRW_GET_BY_TPM.JLR = rst_TokenINFO.STAFFID;
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = mesmodels.PD_SCRW.GET_RWBH_BY_TPM(model_MES_PD_SCRW_GET_BY_TPM, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_SCRW);
        }

        [HttpPost]
        public string GET_CZR_RWBH(string RWBH)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            //string token = AppClass.GetSession("token").ToString();
            MES_TM_CZR model_MES_TM_CZR = new MES_TM_CZR();
            model_MES_TM_CZR.RWBH = RWBH;
            model_MES_TM_CZR.CZLB = 1;
            MES_TM_CZR_SELECT_CZR_NOW rst_MES_TM_CZR_SELECT_CZR_NOW = mesmodels.TM_CZR.SELECT_CZR_NOW(model_MES_TM_CZR, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_TM_CZR_SELECT_CZR_NOW);
        }
        [HttpPost]
        public string SET_CZR(string datastring)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            //string token = AppClass.GetSession("token").ToString();
            MES_TM_CZR model_MES_TM_CZR = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_CZR>(datastring);
            MES_RETURN_UI model_MES_RETURN_UI = mesmodels.TM_CZR.INSERT(model_MES_TM_CZR, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(model_MES_RETURN_UI);
        }
        [HttpPost]
        public string GET_GDJGXX(string RWBH, string ZPRQ, string GC)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            //string token = AppClass.GetSession("token").ToString();
            ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = mesmodels.PD_GD.SAP_GET_GDJGXX(RWBH, ZPRQ, GC, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_ZBCFUN_GDJGXX_READ);
        }
        [HttpPost]
        public string GET_TM_TL(string TM, string RWBH)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            //string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.TM = TM;
            model_MES_TM_TMINFO.RWBH = RWBH;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesmodels.TM_TMINFO.SELECT_BYTM(model_MES_TM_TMINFO, 0, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string SET_TM_INSERT(string datastring1, string datastring2)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            //string token = AppClass.GetSession("token").ToString();
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring1);
            model_MES_TM_TMINFO.JLR = rst_TokenINFO.STAFFID;
            model_MES_TM_TMINFO.TMCOUNT = 1;
            model_MES_TM_TMINFO.TMLB = 1;
            MES_TM_GL[] model_MES_TM_GL = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_GL[]>(datastring2);
            MES_TM_TMINFO_INSERT_GL model_MES_TM_TMINFO_INSERT_GL = new MES_TM_TMINFO_INSERT_GL();
            model_MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO = model_MES_TM_TMINFO;
            model_MES_TM_TMINFO_INSERT_GL.MES_TM_GL = model_MES_TM_GL;
            Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_INSERT_RETURN rst_MES_TM_TMINFO_INSERT_RETURN = mesmodels.TM_TMINFO.INSERT(model_MES_TM_TMINFO_INSERT_GL, 0, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_TM_TMINFO_INSERT_RETURN);
        }
        public TokenINFO GET_TokenINFO()
        {
            TokenINFO rst_TokenINFO = new TokenINFO();
            if (Request.Cookies["tokeninfo"] != null)
            {
                string ss = Request.Cookies["tokeninfo"].Value;
                rst_TokenINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenINFO>(HttpUtility.UrlDecode(Request.Cookies["tokeninfo"].Value));
            }
            else
            {
                rst_TokenINFO.STAFFID = 0;
                rst_TokenINFO.Token = "";
            }
            return rst_TokenINFO;
        }
        [HttpPost]
        public string DELETE_CZRY(int id)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            MES_RETURN_UI rst_MES_RETURN_UI = mesmodels.TM_CZR.UPDATE_LEAVE(id, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }
    }
}
