using Sonluk.WX.APPCLASS;
using Sonluk.WX.Models;
using Sonluk.UI.Model.CRM.HG_DEPTService;
using Sonluk.UI.Model.HR.SY_DEPTService;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_CHECKDETAILSService;
using Sonluk.UI.Model.S5.SY_DICTService;
using Sonluk.UI.Model.S5.SY_STAFF_DEPService;
using Sonluk.UI.Model.S5.SY_TYPEService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.WX.Areas.FIVES.Controllers
{
    public class SystemController : Controller
    {
        //
        // GET: /FIVES/System/
        FIVESModels fivesmodels = new FIVESModels();
        AppClass appClass = new AppClass();
        CRMModels crmModels = new CRMModels();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public string SY_DICT_Read(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_DICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_DICT>(data);
            FIVES_SY_DICT[] res = fivesmodels.SY_DICT.Read(model, token);
            //HR_SY_DEPT_SELECT r = hrmodels.SY_DEPT.SELECT(new HR_SY_DEPT(), token);

            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }


    }
}
