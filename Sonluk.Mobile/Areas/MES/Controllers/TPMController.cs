using Sonluk.Mobile.Areas.MES.Models;
using Sonluk.Mobile.Models;
using Sonluk.UI.Model.MES.MES_TPMService;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.SY_GCService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Mobile.Areas.MES.Controllers
{
    public class TPMController : Controller
    {
        //
        // GET: /MES/TPM/
        MESModels mesmodels = new MESModels();
        public ActionResult Index()
        {
            return View();
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
        public ActionResult TPZHNO_ADD()
        {
            return View();
        }
        public ActionResult TP_RKBS_BD()
        {
            return View();
        }
        public ActionResult TP_RKBS_JC()
        {
            return View();
        }
        public ActionResult TP_TPYD()
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            int STAFFID = rst_TokenINFO.STAFFID;
            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesmodels.SY_GC.SELECT_BY_ROLE(gclist, rst_TokenINFO.Token);
            MES_MM_CK model_ck = new MES_MM_CK();
            model_ck.STAFFID = STAFFID;
            MES_MM_CK_SELECT data_ck = mesmodels.MM_CK.SELECT_BY_STAFFID(model_ck, rst_TokenINFO.Token);
            MODLE_TPM view_data = new MODLE_TPM();
            view_data.Sy_gc = gc;
            view_data.MES_MM_CK_SELECT = data_ck;
            ViewData.Model = view_data;
            return View();
        }

        [HttpPost]
        public string INSERT_TM_ZHM(string datastring)
        {
            TokenINFO rst_TokenINFO = GET_TokenINFO();
            int STAFFID = rst_TokenINFO.STAFFID;
            string STAFFNAME = rst_TokenINFO.STAFFNAME;
            ZSL_BCT011 model_ZSL_BCT011 = new ZSL_BCT011();
            model_ZSL_BCT011.CJR = STAFFID;
            model_ZSL_BCT011.CJRNAME = STAFFNAME;
            ZSL_BCT012[] model_ZSL_BCT012 = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT012[]>(datastring);
            ZBCFUN_TP_ZHM_GL res = mesmodels.MES_TPM.INSERT_TP_WZHM(model_ZSL_BCT011, model_ZSL_BCT012);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string INSERT_TP_RKBS(string datastring)
        {
            ZSL_BCT010[] model_ZSL_BCT010 = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT010[]>(datastring);
            ZBCFUN_TP_RKBS_GL res = mesmodels.MES_TPM.INSERT_TP_RKBS(model_ZSL_BCT010);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string SELECT_TP_RKBS(string TPNO)
        {
            ZBCFUN_TP_RKBS_GL rst = mesmodels.MES_TPM.SELECT_TP_RKBS(TPNO);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        //[HttpPost]
        //public string DELETE_TP_RKBS(string datastring)
        //{
        //    string msg = "";
        //    ZSL_BCT010[] IS_TPNO_GL = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT010[]>(datastring);
        //    for (int i = 0; i < IS_TPNO_GL.Length; i++)
        //    {
        //        ZBCFUN_TP_RKBS_GL rst = mesmodels.MES_TPM.DELETE_TP_RKBS(IS_TPNO_GL[i]);
        //        if (rst.MES_RETURN.TYPE == "E")
        //        {
        //            msg = rst.MES_RETURN.MESSAGE;
        //            break;
        //        }
        //        else {
        //            msg = "S";
        //        }
        //    }
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg); ;
        //}
        [HttpPost]
        public string DELETE_TP_RKBS(string datastring)
        {
            //string msg = "";
            ZSL_BCT010 IS_TPNO_GL = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT010>(datastring);
            ZBCFUN_TP_RKBS_GL rst = mesmodels.MES_TPM.DELETE_TP_RKBS(IS_TPNO_GL);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst); ;
        }
        [HttpPost]
        public string UPDATE_TPYD(string datastring, string GC, string KCDD)
        {
            ZSL_BCT012[] IT_TPYD = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT012[]>(datastring);
            ZBCFUN_TPINFO_INSERT model = mesmodels.MES_TPM.UPDATE_TPYD(IT_TPYD, KCDD, GC);
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }
        [HttpPost]
        public string SELECT_TP_ZHNOb(string TPZHNO)
        {
            ZBCFUN_TP_ZHM_GL res = mesmodels.MES_TPM.SELECT_TP_ZHNOb(TPZHNO);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string GET_TPM_INFO(string GC, string CJRQ, int ISFREE, string CJR, string TPNO, string LGORT, int TPGG)//, int ISFREE, string CJRQ, string CJR)
        {
            //string token = AppClass.GetSession("token").ToString();
            ZSL_BCS025 model_TMINFO = new ZSL_BCS025();
            model_TMINFO.WERKS = GC;
            model_TMINFO.TPNO = TPNO;
            model_TMINFO.LGORT = LGORT;
            model_TMINFO.TPGG = TPGG;
            model_TMINFO.ISFREE = ISFREE;
            model_TMINFO.CJRQ = CJRQ;
            model_TMINFO.CJRNAME = CJR;
            ZBCFUN_TPINFO_SELECT data = mesmodels.MES_TPM.SELECT_TPM(model_TMINFO);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);

        }
    }
}
