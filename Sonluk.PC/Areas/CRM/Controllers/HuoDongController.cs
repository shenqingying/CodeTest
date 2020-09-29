using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.HD_ZDFService;
using Sonluk.UI.Model.CRM_OAService;
using Newtonsoft.Json;
using Sonluk.UI.Model.CRM.OA_TRANSMITService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class HuoDongController : Controller
    {
        //
        // GET: /CRM/HuoDong/
        CRMModels crmModels = new CRMModels();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertFee()          //新建招待费申请
        {
            //ViewBag.TimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //Session["location"] = 22;
            return View();
        }

        public ActionResult SelectFee()          //招待费列表
        {
            Session["location"] = 23;
            return View();
        }

        public ActionResult SelectFee_Personal()          //个人招待费列表
        {
            Session["location"] = 62;
            return View();
        }

        public ActionResult UpdateFee()          //修改招待费申请
        {
            //ViewBag.TimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return View();
        }

        [HttpPost]
        public int Data_Insert_Fee(string data)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HD_ZDF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HD_ZDF>(data);
            model.SQSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int i = crmModels.HD_ZDF.Create(model,token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Fee(string cxdata)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HD_ZDF_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HD_ZDF_PARAMS>(cxdata);
            CRM_HD_ZDFList[] data = crmModels.HD_ZDF.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_FeeByZDFID(int ZDFID)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HD_ZDF data = crmModels.HD_ZDF.ReadByZDFID(ZDFID, token);
            CRM_HD_ZDFList list = new CRM_HD_ZDFList();
            list.ZDFID = data.ZDFID;
            list.SQRID = data.SQRID;
            list.SQBMID = data.SQBMID;
            list.SQSJ = data.SQSJ;
            list.ZDRQ = data.ZDRQ;
            list.KHID = data.KHID;
            list.KHNAME = data.KHNAME;
            list.KHMX = data.KHMX;
            list.JDRS = data.JDRS;
            list.PKRS = data.PKRS;
            list.ZDLY = data.ZDLY;
            list.YJJE = data.YJJE;
            list.ISACTIVE = data.ISACTIVE;
            list.STAFFNAME = crmModels.HG_STAFF.ReadBySTAFFID(data.SQRID, token).STAFFNAME;
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }

        [HttpPost]
        public string Data_Select_FeeBySTAFFID(string cxdata)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HD_ZDF_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HD_ZDF_PARAMS>(cxdata);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            CRM_HD_ZDFList[] data = crmModels.HD_ZDF.ReadBySTAFFID(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public int Data_Update_Fee(string data)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HD_ZDF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HD_ZDF>(data);
            int i = crmModels.HD_ZDF.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Fee(int ZDFID)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            return crmModels.HD_ZDF.Delete(ZDFID, token);

        }

        [HttpPost]
        public string Data_Submit_Fee(string _basic, string _list, int ZDFID)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_OA_BASIC basic = JsonConvert.DeserializeObject<CRM_OA_BASIC>(_basic);
            basic.TemplateCode = crmModels.SYS_CS.Read(13, token)[0].CS.ToString();
            CRM_OA_ZDF list = JsonConvert.DeserializeObject<CRM_OA_ZDF>(_list);
            //list.DEP = crmModels.HG_DEPT.ReadByDEPID(DEP, token).DEPNAME;

            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                CRM_HD_ZDF data = crmModels.HD_ZDF.ReadByZDFID(ZDFID, token);
                data.ISACTIVE = 2;
                crmModels.HD_ZDF.Update(data, token);


                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = ZDFID;
                model.OACSLB = 990;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }





        public ActionResult InsertSaler()          //新建促销员
        {
            Session["location"] = 24;
            return View();
        }

        //public ActionResult Insert_Saler()
        //{

        //    return View();
        //}
        public ActionResult SelectSaler()          //促销员列表
        {
            Session["location"] = 25;
            return View();
        }
        public ActionResult InsertSystem()          //新建系统工作评估
        {
            Session["location"] = 26;
            return View();
        }
        //public ActionResult Insert_System()
        //{

        //    return View();
        //}
        public ActionResult SelectSystem()          //系统评估列表
        {
            Session["location"] = 27;
            return View();
        }
        public ActionResult InsertStore()          //新建门店工作评估
        {
            Session["location"] = 28;
            return View();
        }
        //public ActionResult Insert_Store()
        //{

        //    return View();
        //}
        public ActionResult SelectStore()          //门店评估列表
        {
            Session["location"] = 29;
            return View();
        }




        [HttpPost]
        public string GetTimeNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }


        [HttpPost]
        public string Data_DaoChu_ZDF(string data)
        {
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 5, "");

            return result;
        }


    }
}
