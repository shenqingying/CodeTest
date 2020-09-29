using Sonluk.Mobile.APPCLASS;
using Sonluk.Mobile.Models;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Mobile.Areas.MES.Controllers
{
    public class TM_ManageController : Controller
    {
        //
        // GET: /MES/TM_Manage/
        MESModels mesmodels = new MESModels();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TPM_CHANGE()
        {
            return View();
        }
        [HttpPost]
        public string post_tm_th(string OLDTPM, string NEWTPM)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst_MES_RETURN_UI = mesmodels.TM_TMINFO.VERIFY_TPMTH(OLDTPM, NEWTPM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }
    }
}
