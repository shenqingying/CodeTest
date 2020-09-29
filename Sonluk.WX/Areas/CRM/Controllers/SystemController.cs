using Sonluk.UI.Model.CRM.HG_STAFFKHLXService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.WX.APPCLASS;
using Sonluk.WX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class SystemController : Controller
    {
        //
        // GET: /CRM/System/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Password()
        {
            return View();
        }

        public ActionResult KHPassword()
        {
            return View();
        }

        public ActionResult Users()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFFKHLX[] data = crmModels.HG_STAFFKHLX.Read(token);
            ViewData.Model = data;
            return View();
        }

        [HttpPost]
        public int Data_Update_Password(string oldp, string newp)
        {
            token = appClass.CRM_Gettoken();
            string pattern = @"(?=.*[a-zA-Z])(?=.*[0-9])";
            bool result = Regex.IsMatch(newp, pattern);
            if (result == false)
            {
                return -2;             //复杂度不够
            }
            if (newp.Length < 8)
            {
                return -3;            //长度少于8
            }



            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            string oldpass = FormsAuthentication.HashPasswordForStoringInConfigFile(oldp, "MD5").ToLower();
            if (oldpass != staffmodel.STAFFPW)
            {
                return -1;             //原密码不对
            }
            staffmodel.STAFFPW = FormsAuthentication.HashPasswordForStoringInConfigFile(newp, "MD5").ToLower();
            int i = crmModels.HG_STAFF.Update(staffmodel, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Users(string cxdata)        //查询出所有帐号,包括有帐号和没帐号的
        {
            token = appClass.CRM_Gettoken();
            CRM_Report_STAFFModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_Report_STAFFModel>(cxdata);
            model.ISACTIVE = 1;
            CRM_HG_STAFFList[] data = crmModels.HG_STAFF.Report(model, "user", token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Update_Users(int STAFFID, string STAFFPW, bool islock, int STAFFKHLXID)
        {
            token = appClass.CRM_Gettoken();
            WebMSG msg = new WebMSG();
            CRM_HG_STAFF data = crmModels.HG_STAFF.ReadBySTAFFID(STAFFID, token);        //根据staffid找到人员信息
            if (STAFFPW != "")              //如果密码有所改动
            {
                string pattern = @"(?=.*[a-zA-Z])(?=.*[0-9])";
                bool result = Regex.IsMatch(STAFFPW, pattern);
                if (result == false)
                {
                    msg.KEY = -2;
                    msg.MSG = "密码复杂度不够";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);             //复杂度不够
                }
                if (STAFFPW.Length < 8)
                {
                    msg.KEY = -3;
                    msg.MSG = "密码长度不得少于8";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);            //长度少于8
                }
                data.STAFFPW = FormsAuthentication.HashPasswordForStoringInConfigFile(STAFFPW, "MD5").ToLower();
            }

            data.SISLOCK = islock;
            data.STAFFKHLXID = STAFFKHLXID;
            if (!islock)
                data.E_COUNT = 0;

            int i = crmModels.HG_STAFF.Update(data, token);             //帐号密码加进去，更新人员信息
            if(i <= 0)
            {
                msg.KEY = 0;
                msg.MSG = "修改失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.KEY = 1;
                msg.MSG = "修改成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

        }


    }
}
