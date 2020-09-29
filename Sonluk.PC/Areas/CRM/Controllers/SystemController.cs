using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.HG_DEPTService;
using Sonluk.UI.Model.CRM.HG_DUTYService;
using Sonluk.UI.Model.CRM.HG_STAFFDUTYService;
using Sonluk.UI.Model.CRM.HG_ROLEService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.HG_TYPEService;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.HG_RIGHTService;
using Sonluk.UI.Model.CRM.HG_RIGHTGROUPService;
using Sonluk.UI.Model.CRM.KQ_GZRLService;
using Sonluk.UI.Model.CRM.KQ_GZRLMXService;
using Sonluk.UI.Model.CRM.HG_BZGZSJService;
using Sonluk.UI.Model.CRM.KH_BFService;
using Sonluk.UI.Model.CRM.KH_GROUP_XSQYService;
using Sonluk.UI.Model.CRM.SYS_CSService;
using Sonluk.UI.Model.CRM.HG_STAFFKHLXService;
using Sonluk.UI.Model.CRM.HG_KHLXService;
using System.Text.RegularExpressions;
using Sonluk.PC.APPCLASS;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.WX_OPENIDService;
using System.Configuration;
using Sonluk.UI.Model.CRM.HG_STAFFDICTService;
using Newtonsoft.Json.Linq;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class SystemController : Controller
    {
        //
        // GET: /CRM/System/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        string token = "";
        WebMSG webmsg = new WebMSG();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Department()
        {
            Session["location"] = 33;
            return View();
        }

        [HttpPost]
        public int Data_Insert_Dep(string data)        //新建部门
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DEPT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_DEPT>(data);
            int i = crmModels.HG_DEPT.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_SeleceDep_ByDepID(int DEPID)            //根据部门ID查询部门的单条数据
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DEPTList data = crmModels.HG_DEPT.ReadByDEPID(DEPID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_Dep()             //查询所有的部门
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DEPT[] data = crmModels.HG_DEPT.Read(token);
            LayuiDep[] dep = new LayuiDep[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                dep[i] = new LayuiDep();
                dep[i].DEPID = data[i].DEPID;
                dep[i].title = data[i].DEPNAME;
                dep[i].PDEPID = data[i].PDEPID;
                dep[i].DLEVEL = data[i].DLEVEL;
                dep[i].DEPADDRESS = data[i].DEPADDRESS;
                dep[i].DEPMEMO = data[i].DEPMEMO;
                dep[i].ISACTIVE = data[i].ISACTIVE;
                dep[i].BEIZ = data[i].BEIZ;
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(dep);
            return s;

        }

        [HttpPost]
        public int Data_Update_Dep(string data)            //更新部门信息
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DEPT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_DEPT>(data);
            int i = crmModels.HG_DEPT.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Dep(int DEPID)         //删除部门信息
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_DEPT.Delete(DEPID, token);
            return i;
        }

        public ActionResult Job()
        {
            Session["location"] = 34;
            return View();
        }

        [HttpPost]
        public int Data_Insert_Job(string data)         //新建职务
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DUTY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_DUTY>(data);
            int i = crmModels.HG_DUTY.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Job()            //查询所有职务信息
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DUTY[] data = crmModels.HG_DUTY.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_Job(string data)         //更新职务信息
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DUTY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_DUTY>(data);
            int i = crmModels.HG_DUTY.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Job(int DUTYID)                  //删除职务信息
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_DUTY.Delete(DUTYID, token);
            return i;
        }

        public ActionResult Users()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 35;
            CRM_HG_STAFFKHLX[] data = crmModels.HG_STAFFKHLX.Read(token);
            ViewData.Model = data;
            return View();
        }

        [HttpPost]
        public int Data_Update_Users_Role_Duty(int staffid, string STAFFUSER, string STAFFPW, bool islock, int STAFFKHLXID, string roledata, string dutydata)    //给人员修改加用户名和密码并管理职务角色
        {
            token = appClass.CRM_Gettoken();
            //CRM_Report_STAFFModel model = new CRM_Report_STAFFModel();
            //model.STAFFNO = STAFFNO;
            //model.ISACTIVE = 1;
            //int staffid = crmModels.HG_STAFF.Report(model, token)[0].STAFFID;            //根据工号找到staffid
            CRM_HG_STAFF data = crmModels.HG_STAFF.ReadBySTAFFID(staffid, token);        //根据staffid找到人员信息
            data.STAFFUSER = STAFFUSER;
            if (STAFFPW != "")              //如果密码有所改动
            {
                string pattern = @"(?=.*[a-zA-Z])(?=.*[0-9])";
                bool result = Regex.IsMatch(STAFFPW, pattern);
                if (result == false)
                {
                    return -2;             //复杂度不够
                }
                if (STAFFPW.Length < 8)
                {
                    return -3;            //长度少于8
                }
                data.STAFFPW = FormsAuthentication.HashPasswordForStoringInConfigFile(STAFFPW, "MD5").ToLower();
            }

            data.SISLOCK = islock;
            if (!islock)
                data.E_COUNT = 0;
            data.STAFFKHLXID = STAFFKHLXID;
            if (data.USERLX == 0)       //等于0是人员新建账户的情况。改成1108代表人员账户，非0则不作修改
                data.USERLX = 1108;
            int i = crmModels.HG_STAFF.Update(data, token);             //帐号密码加进去，更新人员信息
            if (i == -1)
            {
                return -4;
            }

            CRM_HG_ROLE[] rolemodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_ROLE[]>(roledata);
            crmModels.HG_ROLE.Delete_STAFFROLEByStaffid(staffid, token);
            for (int x = 0; x < rolemodel.Length; x++)
            {
                int _i = crmModels.HG_ROLE.Create_STAFFROLE(staffid, rolemodel[x].ROLEID, token);
                if (_i <= 0)
                    return -10;
            }

            DutyModelForNow[] dutymodel = Newtonsoft.Json.JsonConvert.DeserializeObject<DutyModelForNow[]>(dutydata);
            crmModels.HG_STAFFDUTY.DeleteByStaffid(staffid, token);
            for (int x = 0; x < dutymodel.Length; x++)
            {
                int _i = crmModels.HG_STAFFDUTY.Create(staffid, Convert.ToInt32(dutymodel[x].DUTYID), token);
                if (_i <= 0)
                    return -20;
            }

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
        public string Data_Select_DutyByStaffno(int staffid)    //根据工号找出对应的职务
        {
            token = appClass.CRM_Gettoken();
            //CRM_Report_STAFFModel model = new CRM_Report_STAFFModel();
            //model.STAFFNO = staffno;
            //model.ISACTIVE = 1;
            //int staffid = crmModels.HG_STAFF.Report(model, token)[0].STAFFID;
            string[][] data = crmModels.HG_STAFFDUTY.ReadBySTAFFID(staffid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_RoleByStaffno(int staffid)    //根据工号找出对应的角色
        {
            token = appClass.CRM_Gettoken();
            //CRM_Report_STAFFModel model = new CRM_Report_STAFFModel();
            //model.STAFFNO = staffno;
            //model.ISACTIVE = 1;
            //int staffid = crmModels.HG_STAFF.Report(model, token)[0].STAFFID;
            CRM_HG_STAFFROLEList[] data = crmModels.HG_ROLE.Read_STAFFROLEbySTAFFID(staffid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        public ActionResult Role()
        {
            Session["location"] = 36;
            return View();
        }

        [HttpPost]
        public int Data_Insert_Role_RightRole(string data, string rightdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_ROLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_ROLE>(data);
            int i = crmModels.HG_ROLE.Create(model, token);

            CRM_HG_RIGHTList[] rightmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_RIGHTList[]>(rightdata);
            for (int j = 0; j < rightmodel.Length; j++)
            {
                int x = crmModels.HG_ROLE.Create_ROLERIGHT(i, rightmodel[j].RIGHTID, token);
                if (x <= 0)
                    return 0;
            }
            return i;
        }

        [HttpPost]
        public string Data_Select_Role()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_ROLE[] data = crmModels.HG_ROLE.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_Role_ReadByParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_ROLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_ROLE>(cxdata);
            CRM_HG_ROLE[] data = crmModels.HG_ROLE.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public int Data_Update_Role_RightRole(string data, string rightdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_ROLE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_ROLE>(data);
            int i = crmModels.HG_ROLE.Update(model, token);

            CRM_HG_RIGHTList[] rightmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_RIGHTList[]>(rightdata);
            crmModels.HG_ROLE.Delete_ROLERIGHT(model.ROLEID, 0, token);
            for (int j = 0; j < rightmodel.Length; j++)
            {
                int x = crmModels.HG_ROLE.Create_ROLERIGHT(model.ROLEID, rightmodel[j].RIGHTID, token);
                if (x <= 0)
                    return 0;
            }

            return i;
        }

        [HttpPost]
        public int Data_Delete_Role(int ROLEID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_ROLE.Delete(ROLEID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_ALLRight()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_RIGHTList[] data = crmModels.HG_RIGHT.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_Right_ReadByParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_RIGHT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_RIGHT>(cxdata);
            CRM_HG_RIGHT[] data = crmModels.HG_RIGHT.ReadByParam(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_RightByRole(int ROLEID)               //根据角色id对应的权限
        {
            token = appClass.CRM_Gettoken();
            int[] data = crmModels.HG_ROLE.ROLERIGHTByROLEID(ROLEID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        public ActionResult Data()
        {
            Session["location"] = 37;
            return View();
        }

        [HttpPost]
        public int Data_Insert_TYPE(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_TYPE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_TYPE>(data);
            int i = crmModels.HG_TYPE.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_TYPE()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_TYPE[] data = crmModels.HG_TYPE.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_TYPE_Reload(string DATA)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_TYPE MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_TYPE>(DATA);
            CRM_HG_TYPE[] cxdata = crmModels.HG_TYPE.ReadByTypeName(MODEL, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(cxdata);
            return s;
        }
        [HttpPost]
        public int Data_Update_type(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_TYPE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_TYPE>(data);
            int i = crmModels.HG_TYPE.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_TYPE(int TYPEID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_TYPE.Delete(TYPEID, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_DICT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_DICT>(data);
            int i = crmModels.HG_DICT.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_DICT(int TYPEID)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] data = crmModels.HG_DICT.Read(TYPEID, -1, token);       //FID传-1表示忽略这个条件
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Data_Select_DICT_DICNAME(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_DICT>(data);
            CRM_HG_DICT[] CXdata = crmModels.HG_DICT.ReadByParam(model, 0,token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(CXdata);
            return s;
        }

        [HttpPost]
        public int Data_Update_DICT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_DICT>(data);
            int i = crmModels.HG_DICT.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_DICT(int DICID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_DICT.Delete(DICID, token);
            return i;
        }

        public ActionResult Log()
        {
            Session["location"] = 38;
            return View();
        }

        public ActionResult Function()
        {
            Session["location"] = 39;
            return View();
        }

        [HttpPost]
        public int Data_Insert_RightGroup(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_RIGHTGROUP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_RIGHTGROUP>(data);
            int i = crmModels.HG_RIGHTGROUP.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_RightGroup()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_RIGHTGROUP[] data = crmModels.HG_RIGHTGROUP.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_RightGroup(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_RIGHTGROUP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_RIGHTGROUP>(data);
            int i = crmModels.HG_RIGHTGROUP.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_RightGroup(int RGROUPID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_RIGHTGROUP.Delete(RGROUPID, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_Right(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_RIGHT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_RIGHT>(data);
            int i = crmModels.HG_RIGHT.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Right(int RGROUPID)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_RIGHT[] data = crmModels.HG_RIGHT.ReadByRGROUPID(RGROUPID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_Right(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_RIGHT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_RIGHT>(data);
            int i = crmModels.HG_RIGHT.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Right(int RIGHTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_RIGHT.Delete(RIGHTID, token);
            return i;

        }

        public ActionResult RiLi()
        {
            Session["location"] = 52;
            return View();
        }

        [HttpPost]
        public string Data_Select_GZRL()
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_GZRL[] data = crmModels.KQ_GZRL.Read("", 0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_GZRLMX(int bbid, string start, string end)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_GZRLMX[] data = crmModels.KQ_GZRLMX.Read(bbid, start, end, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_GZRLMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_GZRLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KQ_GZRLMX>(data);
            int i = crmModels.KQ_GZRLMX.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Change_SFGZR(int bbid, string date)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_GZRLMX[] data = crmModels.KQ_GZRLMX.Read(bbid, date, date, token);
            data[0].SFGZR = !(data[0].SFGZR);
            CRM_KQ_GZRLMX model = data[0];
            int i = crmModels.KQ_GZRLMX.Update(model, token);
            return i;
        }

        public ActionResult BanZu()
        {
            Session["location"] = 53;
            return View();
        }

        [HttpPost]
        public int Data_Insert_Banzu(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_BZGZSJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_BZGZSJ>(data);
            int i = crmModels.HG_BZGZSJ.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_BanZu()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_BZGZSJ[] data = crmModels.HG_BZGZSJ.Read(0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_BanZu(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_BZGZSJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_BZGZSJ>(data);
            int i = crmModels.HG_BZGZSJ.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_BanZu(int BZID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_BZGZSJ.Delete(BZID, token);
            return i;
        }

        public ActionResult PinCi()
        {
            Session["location"] = 54;
            return View();
        }

        [HttpPost]
        public int Data_Insert_PinCi(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_BF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_BF>(data);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_BF.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_PinCi(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_BF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_BF>(cxdata);
            CRM_KH_BFList[] data = crmModels.KH_BF.Read(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_PinCi(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_BF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_BF>(data);
            int i = crmModels.KH_BF.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_PinCi(int BFID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_BF.Delete(BFID, token);
            return i;
        }

        public ActionResult SaleArea()
        {
            Session["location"] = 55;
            return View();
        }

        [HttpPost]
        public int Data_Insert_SaleArea(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUP_XSQY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_GROUP_XSQY>(data);
            int i = crmModels.KH_GROUP_XSQY.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_SaleArea()
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUP_XSQY[] data = crmModels.KH_GROUP_XSQY.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_SaleArea(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUP_XSQY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_GROUP_XSQY>(data);
            int i = crmModels.KH_GROUP_XSQY.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_SaleArea(int XSQYID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_GROUP_XSQY.Delete(XSQYID, token);
            return i;
        }

        public ActionResult System()
        {
            Session["location"] = 40;
            return View();
        }

        [HttpPost]
        public string Data_Select_Sys()
        {
            token = appClass.CRM_Gettoken();
            CRM_SYS_CS[] data = crmModels.SYS_CS.Read(0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_Sys(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_SYS_CS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_SYS_CS>(data);
            int i = crmModels.SYS_CS.Update(model, token);
            return i;
        }

        public ActionResult Password()
        {
            Session["location"] = 41;
            return View();
        }

        public ActionResult KHPassword()
        {
            Session["location"] = 86;
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
            if (oldpass != staffmodel.STAFFPW.ToLower())
            {
                return -1;             //原密码不对
            }
            staffmodel.STAFFPW = FormsAuthentication.HashPasswordForStoringInConfigFile(newp, "MD5").ToLower();
            int i = crmModels.HG_STAFF.Update(staffmodel, token);
            if (i > 0)
            {
                //TokenInfo tokeninfo = crmModels.CRM_Login.Login_SSO(staffmodel.STAFFUSER, newp, "", "");
                //MES_RETURN_UI rst_MES_RETURN_UI = new MES_RETURN_UI();
                //if (tokeninfo.access_token == null)
                //{
                //    rst_MES_RETURN_UI.TYPE = "E";
                //    rst_MES_RETURN_UI.MESSAGE = tokeninfo.MESSAGE;
                //}
                //else
                //{
                //    rst_MES_RETURN_UI.TYPE = "S";
                //    rst_MES_RETURN_UI.MESSAGE = tokeninfo.TOKENID;
                //    Session["token"] = tokeninfo.access_token;
                //    Session["STAFFID"] = tokeninfo.STAFFID;
                //    Session["NAME"] = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.STAFFID, tokeninfo.access_token).STAFFNAME;
                //    Response.Cookies["TOKENID"].Value = tokeninfo.TOKENID;
                //}
            }
            return i;
        }

        public ActionResult KHLX()
        {
            Session["location"] = 61;
            return View();
        }

        [HttpPost]
        public int Data_Insert_STAFFKHLX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFFKHLX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_STAFFKHLX>(data);
            int i = crmModels.HG_STAFFKHLX.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_STAFFKHLX()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFFKHLX[] data = crmModels.HG_STAFFKHLX.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_STAFFKHLX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFFKHLX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_STAFFKHLX>(data);
            int i = crmModels.HG_STAFFKHLX.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_STAFFKHLX(int STAFFKHLXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_STAFFKHLX.Delete(STAFFKHLXID, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_KHLX(int STAFFKHLXID, int DICID)             //新增一个客户类型的权限到组
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_KHLX.Create(STAFFKHLXID, DICID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_KHLXbySTAFFKHLX(int STAFFKHLXID)     //根据客户类型权限组id找到该组有哪些客户类型的权限
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_KHLXList[] data = crmModels.HG_KHLX.Read(STAFFKHLXID, 0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_KHLX(int STAFFKHLXID, int DICID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_KHLX.Delete(STAFFKHLXID, DICID, token);
            return i;
        }

        [HttpPost]
        public int Data_DaoRu_GZRLMX(int BBID, int year)
        {
            token = appClass.CRM_Gettoken();

            string date_begin = year.ToString() + "-01-01";
            string date_end = year.ToString() + "-12-31";
            crmModels.KQ_GZRLMX.Delete(BBID, date_begin, date_end, token);
            int year_days = 0;

            //if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            if (DateTime.IsLeapYear(year) == true)
                year_days = 366;
            else
                year_days = 365;

            for (int i = 0; i < year_days; i++)
            {
                CRM_KQ_GZRLMX data = new CRM_KQ_GZRLMX();
                data.BBID = BBID;
                data.DATE = date_begin;
                data.SFGZR = isGZR(date_begin.ToString());
                data.ISACTIVE = 1;
                data.BEIZ = "";
                int id = crmModels.KQ_GZRLMX.Create(data, token);
                if (id <= 0)
                {
                    return -1;
                }
                date_begin = Convert.ToDateTime(date_begin).AddDays(1).ToString("yyyy-MM-dd");
            }
            return 1;
        }

        private bool isGZR(string date)
        {
            DateTime time = Convert.ToDateTime(date);
            switch (time.DayOfWeek.ToString())
            {
                case "Monday":
                    return true;

                case "Tuesday":
                    return true;
                case "Wednesday":
                    return true;
                case "Thursday":
                    return true;
                case "Friday":
                    return true;
                case "Saturday":
                    return false;
                case "Sunday":
                    return false;
                default:
                    return false;
            }



        }

        public ActionResult KHAcount()
        {
            Session["location"] = 85;
            return View();
        }

        [HttpPost]
        public string Data_SelectKHAcount(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_Report_KHModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_Report_KHModel>(cxdata);
            CRM_KH_KHList[] data = crmModels.KH_KH.ReadKHAcount(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public int Data_Update_KHAcount_Role(int KHID, string STAFFUSER, string STAFFPW, string roledata)    //给客户修改加用户名和密码并管理角色
        {
            token = appClass.CRM_Gettoken();
            //CRM_Report_STAFFModel model = new CRM_Report_STAFFModel();
            //model.STAFFNO = STAFFNO;
            //model.ISACTIVE = 1;
            //int staffid = crmModels.HG_STAFF.Report(model, token)[0].STAFFID;            //根据工号找到staffid

            CRM_KH_KHList khdata = crmModels.KH_KH.Read(KHID, token);

            CRM_HG_STAFF data = new CRM_HG_STAFF();

            data.STAFFNO = khdata.SAPSN;
            data.STAFFNAME = khdata.MC;
            data.STAFFUSER = STAFFUSER;
            if (STAFFPW != "")              //如果密码有所改动
            {
                string pattern = @"(?=.*[a-zA-Z])(?=.*[0-9])";
                bool result = Regex.IsMatch(STAFFPW, pattern);
                if (result == false)
                {
                    return -2;             //复杂度不够
                }
                if (STAFFPW.Length < 8)
                {
                    return -3;            //长度少于8
                }
                data.STAFFPW = FormsAuthentication.HashPasswordForStoringInConfigFile(STAFFPW, "MD5").ToLower();
            }

            data.SISLOCK = false;
            data.USERLX = 1107;
            data.ISACTIVE = 1;

            int staffid = crmModels.HG_STAFF.Create(data, token);             //帐号密码加进去，更新人员信息
            if (staffid == -1)
            {
                return -4;
            }

            CRM_HG_ROLE[] rolemodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_ROLE[]>(roledata);
            crmModels.HG_ROLE.Delete_STAFFROLEByStaffid(staffid, token);
            for (int x = 0; x < rolemodel.Length; x++)
            {
                int _i = crmModels.HG_ROLE.Create_STAFFROLE(staffid, rolemodel[x].ROLEID, token);
                if (_i <= 0)
                    return -10;
            }



            return staffid;
        }

        public ActionResult STAFF_OPENID()
        {
            Session["location"] = 94;
            return View();
        }

        [HttpPost]
        public string Data_Insert_OPENID(int STAFFID, string OPENID, string WXDLCS)
        {
            token = appClass.CRM_Gettoken();
            CRM_WX_OPENID model = new CRM_WX_OPENID();
            model.STAFFID = STAFFID;
            model.OPENID = OPENID;
            string AppID = ConfigurationManager.AppSettings["AppID"];
            string CorpID = ConfigurationManager.AppSettings["CorpID"];
            if (WXDLCS == "1")
                model.WXDLCS = AppID;
            else if (WXDLCS == "2")
                model.WXDLCS = CorpID;
            else
                model.WXDLCS = "";

            CRM_WX_OPENID cxmodel = new CRM_WX_OPENID();
            cxmodel.OPENID = model.OPENID;
            cxmodel.WXDLCS = model.WXDLCS;
            CRM_WX_OPENID[] cxdata = crmModels.WX_OPENID.ReadByParam(cxmodel, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "已存在此OPENID";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }



            int i = crmModels.WX_OPENID.Create(model, "自动登录", token);
            webmsg.KEY = i;
            if (i > 0)
            {
                webmsg.MSG = "新建成功";
            }
            else
            {
                webmsg.MSG = "新建失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_OPENIDbyParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_WX_OPENIDList model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_WX_OPENIDList>(cxdata);
            CRM_WX_OPENIDList[] data = crmModels.WX_OPENID.ReadBySTAFFParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_OPENID(int ID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.WX_OPENID.DeleteByID(ID, token);
            webmsg.KEY = i;
            if (i > 0)
            {
                webmsg.MSG = "删除成功";
            }
            else
            {
                webmsg.MSG = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public ActionResult STAFFDICT()
        {
            Session["location"] = 552;
            token = appClass.CRM_Gettoken();
            CRM_HG_TYPE[] TYPE = crmModels.HG_TYPE.Read(token);
            ViewBag.TYPE = TYPE;
            return View();
        }

        [HttpPost]
        public string Data_Insert_STAFFDICT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFFDICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_STAFFDICT>(data);
            CRM_HG_STAFFDICT[] cxdata = crmModels.HG_STAFFDICT.ReadByParam(model, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "该数据已存在";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            int i = crmModels.HG_STAFFDICT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
            {
                webmsg.MSG = "新增成功";
            }
            else
            {
                webmsg.MSG = "新增失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_STAFFDICT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFFDICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_STAFFDICT>(cxdata);
            CRM_HG_STAFFDICT[] data = crmModels.HG_STAFFDICT.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_STAFFDICT(int STAFFID, int DICID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_STAFFDICT.Delete(STAFFID, DICID, token);
            webmsg.KEY = i;
            if (i > 0)
            {
                webmsg.MSG = "删除成功";
            }
            else
            {
                webmsg.MSG = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }



    }
}
