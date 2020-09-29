using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.HR.GS_GSSLService;
using Sonluk.UI.Model.HR.SY_TYPEMXService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.HR.Controllers
{
    public class TAXController : Controller
    {
        //
        // GET: /HR/TAX/
        HRModels hrmodels = new HRModels();
        public ActionResult TAXMANAGE()
        {
            AppClass.SetSession("location", 129);
            return View();
        }
        [HttpPost]
        public string TAX_SLTT_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_GS_GSSL model_HR_GS_GSSL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_GS_GSSL>(datastring);
            HR_GS_GSSL_SELECT rst = hrmodels.GS_GSSL.SELECT(model_HR_GS_GSSL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string TAX_SLTT_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_GS_GSSL model_HR_GS_GSSL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_GS_GSSL>(datastring);
            model_HR_GS_GSSL.CJR = STAFFID;
            if (model_HR_GS_GSSL.HR_XZGL_TAX_TAXSLMX == null)
            {
                List<HR_XZGL_TAX_TAXSLMX> model_HR_XZGL_TAX_TAXSLMX_list = new List<HR_XZGL_TAX_TAXSLMX>();
                model_HR_GS_GSSL.HR_XZGL_TAX_TAXSLMX = model_HR_XZGL_TAX_TAXSLMX_list.ToArray();
            }
            MES_RETURN_UI rst = hrmodels.GS_GSSL.INSERT(model_HR_GS_GSSL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_TYPEMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_TYPEMX model_HR_SY_TYPEMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_TYPEMX>(datastring);
            HR_SY_TYPEMX_SELECT rst = hrmodels.SY_TYPEMX.SELECT(model_HR_SY_TYPEMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string TAX_SLTT_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_GS_GSSL model_HR_GS_GSSL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_GS_GSSL>(datastring);
            model_HR_GS_GSSL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.GS_GSSL.UPDATE(model_HR_GS_GSSL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string TAX_SLTT_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_GS_GSSL model_HR_GS_GSSL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_GS_GSSL>(datastring);
            model_HR_GS_GSSL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.GS_GSSL.DELETE(model_HR_GS_GSSL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
    }
}
