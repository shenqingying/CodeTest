using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MODEL;
using Sonluk.WX.APPCLASS;
using Sonluk.WX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.WX.Areas.WMS.Controllers
{
    public class BC_TMController : Controller
    {
        //
        // GET: /WMS/BC_TM/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        MESModels mesModels = new MESModels();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YH_MARK()
        {

            return View();
        }

        public ActionResult YH_MARK_Part(string data)
        {
            MES_TM_TMINFO_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_LIST[]>(data);
            ViewBag.data = model;
            return View();
        }

        [HttpPost]
        public string GET_TMINFO(string datastring)
        {
            string token = appClass.CRM_Gettoken();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model_MES_TM_TMINFO.TMLB = 1;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }

        [HttpPost]
        public string UPDATE_TMINFO(string data)
        {
            string token = appClass.CRM_Gettoken();
            MES_RETURN_UI temp2 = new MES_RETURN_UI();
            MES_TM_TMINFO_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_LIST[]>(data);
            for (int i = 0; i < model.Length; i++)
            {
                MES_TM_TMINFO temp = new MES_TM_TMINFO();
                temp.TM = model[i].TM;
                temp.YHBS = "X";
                MES_RETURN_UI res = mesModels.TM_TMINFO.UPDATE_LB(temp, 7, token);
            }
            temp2.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(temp2);
        }



    }
}
