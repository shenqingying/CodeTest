using Sonluk.Mobile.APPCLASS;
using Sonluk.Mobile.Models;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Mobile.Areas.MES.Controllers
{
    public class PD_SCRWController : Controller
    {
        //
        // GET: /MES/PD_SCRW/
        MESModels mesmodels = new MESModels();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PD_SCRW_TL_ZJ()
        {
            return View();
        }
        [HttpPost]
        public string GET_SCRW_BYSBBH(string in_sm)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.SBBH = in_sm;
            string ZPRQ = mesmodels.PUBLIC_FUNC.GET_TIME(rst_TokenINFO.Token);
            if (ZPRQ.Length > 10)
            {
                ZPRQ = ZPRQ.Substring(0, 10);
            }
            else
            {
                ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
            }
            model_MES_PD_SCRW.ZPRQ = ZPRQ;
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = mesmodels.PD_SCRW.SELECT_LAST(model_MES_PD_SCRW, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_SCRW);
        }
        [HttpPost]
        public string GET_GDINFO_BYSCRW(string RWBH, string GC)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = mesmodels.PD_GD.SAP_GET_GDJGXX(RWBH, "", GC, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_ZBCFUN_GDJGXX_READ);
        }
        [HttpPost]
        public string SET_TMTL(string RWBH, string TM, string REMARK)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.RWBH = RWBH;
            model_MES_TM_TMINFO.TM = TM;
            model_MES_TM_TMINFO.JLR = rst_TokenINFO.STAFFID;
            model_MES_TM_TMINFO.TLREMARK = REMARK;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesmodels.TM_TMINFO.SELECT_BYTM(model_MES_TM_TMINFO, 1, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        public TokenINFO GET_TokenINFO()
        {
            TokenINFO rst_TokenINFO = new TokenINFO();
            if (Request.Cookies["tokeninfo"] != null)
            {
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
        public string GET_SBBH_BY_TDNO(string TDNO)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            MES_PD_TL_TD model_MES_PD_TL_TD = new MES_PD_TL_TD();
            model_MES_PD_TL_TD.TDNO = TDNO;
            MES_PD_TL_TD_SELECT rst_MES_PD_TL_TD_SELECT = mesmodels.SY_GZZX_SBH.SELECT_BY_TDNO(model_MES_PD_TL_TD, rst_TokenINFO.Token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_TL_TD_SELECT);
        }
    }
}
