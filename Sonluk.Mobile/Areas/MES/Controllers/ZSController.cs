using Sonluk.Mobile.APPCLASS;
using Sonluk.Mobile.Areas.MES.Models;
using Sonluk.Mobile.Models;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_MATERIAL_BZCOUNTservice;
using Sonluk.UI.Model.MES.TM_GLService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MES.ZS_QJ_QJJLService;
using Sonluk.UI.Model.MES.ZS_SY_JLService;
using Sonluk.UI.Model.MES.ZS_SY_KUService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Mobile.Areas.MES.Controllers
{
    public class ZSController : Controller
    {
        //
        // GET: /MES/ZS/
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
        public ActionResult ZS_WLBSKGL_MANAGE()
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
        public ActionResult ZS_WLBSKGL_BACK_MANAGE()
        {
            return View();
        }
        public ActionResult ZS_WLBSK_MOVE_MANAGE()
        {
            return View();
        }
        public ActionResult ZS_WLBSK_CK_MANAGE()
        {
            return View();
        }
        public ActionResult ZS_FGDJ_MANAGE()
        {
            return View();
        }
        public ActionResult ZS_THDJ_MANAGE()
        {
            return View();
        }
        public ActionResult ZS_MFQQJ_SBLIST()
        {
            return View();
        }
        public ActionResult ZS_MFQQJ_JY()
        {
            return View();
        }
        public ActionResult ZS_TM_CF_CJ()
        {
            return View();
        }
        public ActionResult ZS_TM_CF_WL()
        {
            return View();
        }
        [HttpPost]
        public string GET_TMINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesmodels.TM_TMINFO.SELECT(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_TMINFO_LB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesmodels.TM_TMINFO.SELECT_LB(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_SY_GC(int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_GC gcmodel = new MES_SY_GC();
            gcmodel.STAFFID = STAFFID;
            MES_SY_GC[] gcList = mesmodels.SY_GC.SELECT_BY_ROLE(gcmodel, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(gcList);
        }
        [HttpPost]
        public string GET_MM_CK(int STAFFID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_MM_CK model_ck = new MES_MM_CK();
            model_ck.STAFFID = STAFFID;
            MES_MM_CK_SELECT data_ck = mesmodels.MM_CK.SELECT_BY_STAFFID(model_ck, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data_ck);
        }
        [HttpPost]
        public string Verify_TMGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            Sonluk.UI.Model.MES.TM_GLService.MES_TM_GL model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.TM_GLService.MES_TM_GL>(datastring); ;
            try
            {
                Sonluk.UI.Model.MES.TM_GLService.MES_TM_GL_SELECT data = mesmodels.TM_GL.SELECT(model, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            catch (Exception E)
            {
                return E.ToString();
            }

        }
        [HttpPost]
        public string INSERT_ZS_WLKCBS(string TM_TMINFO_data, string TM_GL_data)
        {
            try
            {
                string token = AppClass.GetSession("token").ToString();
                MES_TM_TMINFO TM_TMINFO_MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(TM_TMINFO_data);
                Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_GL[] TM_GL_MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_GL[]>(TM_GL_data);
                MES_TM_TMINFO_INSERT_GL MODEL = new MES_TM_TMINFO_INSERT_GL();
                MODEL.MES_TM_TMINFO = TM_TMINFO_MODEL;
                MODEL.MES_TM_GL = TM_GL_MODEL;

                MES_RETURN_UI NEWDATA = mesmodels.TM_TMINFO.INSERT_ZS_WLKCBS(MODEL, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(NEWDATA);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        [HttpPost]
        public string DELETE_ZS_WLKCBS(string TM_TMINFO_data)
        {
            try
            {
                string token = AppClass.GetSession("token").ToString();
                MES_TM_TMINFO[] TM_TMINFO_MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO[]>(TM_TMINFO_data);
                MES_RETURN_UI NEWDATA = mesmodels.TM_TMINFO.DELETE_ZS_WLKCBS(TM_TMINFO_MODEL, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(NEWDATA);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public string Data_Select_GC_ROLE()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();

            MES_SY_GC model = new MES_SY_GC();
            model.STAFFID = STAFFID;
            MES_SY_GC[] data = mesmodels.SY_GC.SELECT_BY_ROLE(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_CK_ROLE(string GC)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();

            MES_MM_CK model_ck = new MES_MM_CK();
            model_ck.STAFFID = STAFFID;
            model_ck.GC = GC;
            MES_MM_CK_SELECT data_ck = mesmodels.MM_CK.SELECT_BY_STAFFID(model_ck, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data_ck);
            return s;
        }
        [HttpPost]
        public string ZS_WLKCBS_MOVE(string datastring, string RKTEXT)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_TM_TMINFO[] TM_TMINFO_MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO[]>(datastring);
            for (int a = 0; a < TM_TMINFO_MODEL.Length; a++)
            {
                TM_TMINFO_MODEL[a].JLR = STAFFID;
            }
            MES_RETURN_UI NEWDATA = mesmodels.TM_TMINFO.ZS_WLKCBS_MOVE(TM_TMINFO_MODEL, RKTEXT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(NEWDATA);
        }
        [HttpPost]
        public string ZS_SY_KH_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_KU model_MES_ZS_SY_KU = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_KU>(datastring);
            MES_ZS_SY_KU_SELECT rst_MES_ZS_SY_KU_SELECT = mesmodels.ZS_SY_KU.SELECT(model_MES_ZS_SY_KU, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_ZS_SY_KU_SELECT);
        }
        [HttpPost]
        public string ZS_WLKCBS_CK(string datastring, int KHID, string JLMS)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_TM_TMINFO[] TM_TMINFO_MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO[]>(datastring);
            for (int a = 0; a < TM_TMINFO_MODEL.Length; a++)
            {
                TM_TMINFO_MODEL[a].JLR = STAFFID;
            }
            MES_RETURN_UI NEWDATA = mesmodels.TM_TMINFO.ZS_WLKCBS_CK(TM_TMINFO_MODEL, KHID, JLMS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(NEWDATA);
        }
        [HttpPost]
        public string ZS_FGDJ(string datastring, string JLMS)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_TM_TMINFO[] TM_TMINFO_MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO[]>(datastring);
            for (int a = 0; a < TM_TMINFO_MODEL.Length; a++)
            {
                TM_TMINFO_MODEL[a].JLR = STAFFID;
            }
            MES_RETURN_UI NEWDATA = mesmodels.TM_TMINFO.ZS_FGDJ(TM_TMINFO_MODEL, JLMS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(NEWDATA);
        }
        [HttpPost]
        public string ZS_THDJ(string datastring, int KHID, string JLMS)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_TM_TMINFO[] TM_TMINFO_MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO[]>(datastring);
            for (int a = 0; a < TM_TMINFO_MODEL.Length; a++)
            {
                TM_TMINFO_MODEL[a].JLR = STAFFID;
            }
            MES_RETURN_UI NEWDATA = mesmodels.TM_TMINFO.ZS_THDJ(TM_TMINFO_MODEL, KHID, JLMS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(NEWDATA);
        }
        [HttpPost]
        public string QDCode(string code, string format, string width, string height, string pure)
        {
            Byte[] objcode = mesmodels.BarCode.CreateBarCode(code, format, Convert.ToInt32(width), Convert.ToInt32(height), Convert.ToInt32(pure));
            string qd = Convert.ToBase64String(objcode);
            return Newtonsoft.Json.JsonConvert.SerializeObject(qd);
        }
        [HttpPost]
        public string SELECT_QJSB()
        {
            string token = AppClass.GetSession("token").ToString();
            MES_ZS_QJ_QJSB model = new MES_ZS_QJ_QJSB();
            model.LB = 1;
            try
            {
                MES_ZS_QJ_QJSB_SELECT data = mesmodels.ZS_QJ_QJJL.SELECT_QJSB(model, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public string SY_MATERIAL_BZCOUNT_SELECT_LB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_MATERIAL_BZCOUNT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_BZCOUNT>(datastring);
            model.STAFFID = STAFFID;
            MES_SY_MATERIAL_BZCOUNT_SELECT data = mesmodels.SY_MATERIAL_BZCOUNT.SELECT_LB(model, token);
            string rst = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return rst;
        }
        [HttpPost]
        public string ZS_SY_JLMX_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_JL_MX model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_MX>(datastring);
            model.STAFFID = STAFFID;
            MES_ZS_SY_JL_MX_SELECT result = mesmodels.ZS_SY_JL.SELECT_MX(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string TM_TMINFO_UPDATE_CF(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_TM_TMINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model.STAFFID = STAFFID;
            model.JLR = STAFFID;
            MES_RETURN_UI result = mesmodels.TM_TMINFO.UPDATE_CF(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
    }
}
