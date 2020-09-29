using Newtonsoft.Json;
using Sonluk.WX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.HG_DEPTService;
using Sonluk.UI.Model.CRM.HG_BZGZSJService;
using Sonluk.UI.Model.CRM.KQ_GZRLService;
using Sonluk.UI.Model.CRM.HG_KQDZService;
using Sonluk.UI.Model.CRM.HG_RYKQService;
using System.IO;
using System.Data;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class StaffController : Controller
    {
        //
        // GET: /CRM/Staff/
        CRMModels crmModels = new CRMModels();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }







        [HttpPost]
        public int Data_Insert(string data)          //新增人员信息
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //crmModels = js.Deserialize<CRMModels>(data);

            //crmModels = ParseFromJson<CRMModels>(data);
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HG_STAFF crmmodel = JsonConvert.DeserializeObject<CRM_HG_STAFF>(data);
            crmmodel.USERLX = 1108;
            int id = crmModels.HG_STAFF.Create(crmmodel, token);

            return id;
        }

        [HttpPost]
        public string Data_Load_Dropdown(int typeid, int fid)         //下拉框选项加载
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HG_DICT[] list = crmModels.HG_DICT.Read(typeid, fid, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            return json;
        }

        [HttpPost]
        public string Data_Select_Depart()             //查询出部门     部门下拉框专用
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HG_DEPT[] data = crmModels.HG_DEPT.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_DepartmentByStaffid()
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HG_DEPT[] data = crmModels.HG_DEPT.ReadByStaffid(Convert.ToInt32(Session["STAFFID"]), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_Banci()             //查询出班次     班次下拉框专用
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HG_BZGZSJ[] data = crmModels.HG_BZGZSJ.Read(0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_Rili()             //查询出日历     日历下拉框专用
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_KQ_GZRL[] data = crmModels.KQ_GZRL.Read("",0,token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select(string data)          //查询人员列表
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.HG_STAFFService.CRM_Report_STAFFModel report_model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_STAFFService.CRM_Report_STAFFModel>(data);
            Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFFList[] list = crmModels.HG_STAFF.Report(report_model, "staff", token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return s;
        }

        [HttpPost]
        public string Data_Select_ByID(int id)           //打开编辑页面时加载客户基本信息
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            //Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFFList[] list = crmModels.HG_STAFF.Read(id, token);
            Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFF model = crmModels.HG_STAFF.ReadBySTAFFID(id, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }

        [HttpPost]
        public int Data_Delete(int id)                //删除人员信息,只是逻辑删除
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int i = crmModels.HG_STAFF.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Update(string data)            //修改客户信息
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFF model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFF>(data);
            int count = crmModels.HG_STAFF.Update(model, token);
            return count;
        }
        [HttpPost]
        public string Data_Select_KQDZ(int id)                //查询考勤地址
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }

            CRM_HG_KQDZ[] data = crmModels.HG_KQDZ.ReadBySTAFFID(id, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return s;
        }
        [HttpPost]
        public string Data_Select_address_name(string KQDZ)                //根据考勤地址名称查询考勤地址
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }

            CRM_HG_KQDZ[] data = crmModels.HG_KQDZ.ReadBylikeKQDZ(KQDZ, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return s;
        }
        [HttpPost]
        public int Data_RYKQ_Insert(int STAFFID, int KQDZID)          //人员考勤信息
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //crmModels = js.Deserialize<CRMModels>(data);

            //crmModels = ParseFromJson<CRMModels>(data);
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int id = crmModels.HG_RYKQ.Create(STAFFID, KQDZID, token);

            return id;
        }
        [HttpPost]
        public int Data_RYKQ_Delete(int STAFFID, int KQDZID)          //人员考勤信息
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //crmModels = js.Deserialize<CRMModels>(data);

            //crmModels = ParseFromJson<CRMModels>(data);
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int id = crmModels.HG_RYKQ.Delete(STAFFID, KQDZID, token);

            return id;
        }

        [HttpPost]
        public string Data_Select_KQDZLIST(string data)          //查询未审核的考勤地址
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList>(data);
            Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList[] list = crmModels.HG_KQDZ.Report(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return s;
        }

        [HttpPost]
        public int Data_KQDZ_Update(string data)            //考勤地址审核
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ>(data);
            int count = crmModels.HG_KQDZ.Update(model, token);
            return count;
        }

        [HttpPost]
        public string GetEXCEL(string id, string data)
        {

            return "true";

        }
  
        public ActionResult StaffIndex()
        {

            return View();

        }


        public ActionResult Address_Staff()
        {

            return View();

        }

        [HttpPost]
        public int Data_KQDZ_Create(string data, string SF, string CS)            //考勤地址新增
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }

            Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ>(data);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            model.SF = crmModels.HG_DICT.ReadByDICNAME(SF, 1, token);
            model.CS = crmModels.HG_DICT.ReadByDICNAME(CS, 2, token);

            int count = crmModels.HG_KQDZ.Create(model, token);
            return count;
        }

    }
}
