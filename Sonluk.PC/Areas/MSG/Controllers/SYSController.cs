using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.MSG.MSG_SENDWAYService;
using Sonluk.UI.Model.MSG.MSG_TYPEService;
using Sonluk.UI.Model.MSG.MSGTYPE_WAYService;
using Sonluk.UI.Model.MSG.SEND_INFOService;
using Sonluk.UI.Model.MSG.SYS_STAFFService;
using Sonluk.UI.Model.MSG.SYS_SYSINFOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.MSG.Controllers
{
    public class SYSController : Controller
    {
        CRMModels crmModels = new CRMModels();
        MSGModels msgModels = new MSGModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";

        //
        // GET: /MSG/SYS/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SYS_Info()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 557;
            MSG_MSG_TYPE cxmodel = new MSG_MSG_TYPE();

            MSG_MSG_TYPE[] MSGTYPE = msgModels.MSG_TYPE.ReadByParam(cxmodel, token);
            ViewBag.MSGTYPE = MSGTYPE;

            CRM_HG_DICT[] MODE = crmModels.HG_DICT.Read(116, 0, token);
            ViewBag.MODE = MODE;
            return View();
        }

        public ActionResult MSG_SENDWAY()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 558;
            CRM_HG_DICT[] MEDIUM = crmModels.HG_DICT.Read(115, 0, token);
            ViewBag.MEDIUM = MEDIUM;
            CRM_HG_DICT[] WAYSIGN = crmModels.HG_DICT.Read(117, 0, token);
            ViewBag.WAYSIGN = WAYSIGN;
            CRM_HG_DICT[] MODEL = crmModels.HG_DICT.Read(118, 0, token);
            ViewBag.MODEL = MODEL;
            return View();
        }

        public ActionResult MSG_TYPE()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 559;

            return View();
        }







        public string Create_MSG_SENDWAY(string data)
        {
            token = appClass.CRM_Gettoken();
            MSG_MSG_SENDWAY model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSG_SENDWAY>(data);
            model.ISACTIVE = 10;
            model.CJR = appClass.CRM_GetStaffid();
            int id = msgModels.MSG_SENDWAY.Create(model, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "新增成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "新增失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Update_MSG_SENDWAY(string data)
        {
            token = appClass.CRM_Gettoken();
            MSG_MSG_SENDWAY model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSG_SENDWAY>(data);
            int id = msgModels.MSG_SENDWAY.Update(model, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "修改成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "修改失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Select_MSG_SENDWAY(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_MSG_SENDWAY model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSG_SENDWAY>(cxdata);
            MSG_MSG_SENDWAY[] data = msgModels.MSG_SENDWAY.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public string Delete_MSG_SENDWAY(int SENDWAYID)
        {
            token = appClass.CRM_Gettoken();
            int id = msgModels.MSG_SENDWAY.Delete(SENDWAYID, appClass.CRM_GetStaffid(), token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "删除成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Create_MSG_TYPE(string TTdata, string MXdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_MSG_TYPE TTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSG_TYPE>(TTdata);
            MSG_MSG_SENDWAY[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSG_SENDWAY[]>(MXdata);

            TTmodel.ISACTIVE = 10;
            TTmodel.CJR = appClass.CRM_GetStaffid();
            int id = msgModels.MSG_TYPE.Create(TTmodel, token);
            if (id <= 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "新增失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            for (int i = 0; i < MXmodel.Length; i++)
            {
                MSG_MSGTYPE_WAY temp = new MSG_MSGTYPE_WAY();
                temp.TYPEID = id;
                temp.SENDWAYID = MXmodel[i].SENDWAYID;
                int id2 = msgModels.MSGTYPE_WAY.Create(temp, token);
                if (id2 <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "关联推送方式失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }

            webmsg.KEY = 1;
            webmsg.MSG = "新增成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Update_MSG_TYPE(string TTdata, string MXdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_MSG_TYPE TTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSG_TYPE>(TTdata);
            MSG_MSG_SENDWAY[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSG_SENDWAY[]>(MXdata);

            int id = msgModels.MSG_TYPE.Update(TTmodel, token);
            if (id <= 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "修改失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            msgModels.MSGTYPE_WAY.DeleteByTYPEID(id, token);
            for (int i = 0; i < MXmodel.Length; i++)
            {
                MSG_MSGTYPE_WAY temp = new MSG_MSGTYPE_WAY();
                temp.TYPEID = id;
                temp.SENDWAYID = MXmodel[i].SENDWAYID;
                int id2 = msgModels.MSGTYPE_WAY.Create(temp, token);
                if (id2 <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "关联推送方式失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }

            webmsg.KEY = 1;
            webmsg.MSG = "修改成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Select_MSG_TYPE(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_MSG_TYPE model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSG_TYPE>(cxdata);
            MSG_MSG_TYPE[] data = msgModels.MSG_TYPE.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public string Delete_MSG_TYPE(int MSGTYPEID)
        {
            token = appClass.CRM_Gettoken();
            int id = msgModels.MSG_TYPE.Delete(MSGTYPEID, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "删除成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Create_MSGTYPE_WAY(string data)
        {
            token = appClass.CRM_Gettoken();
            MSG_MSGTYPE_WAY model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSGTYPE_WAY>(data);
            int id = msgModels.MSGTYPE_WAY.Create(model, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "新增成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "新增失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Select_MSGTYPE_WAY(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_MSGTYPE_WAY model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSGTYPE_WAY>(cxdata);
            MSG_MSGTYPE_WAY[] data = msgModels.MSGTYPE_WAY.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public string Delete_MSGTYPE_WAY(string data)
        {
            token = appClass.CRM_Gettoken();
            MSG_MSGTYPE_WAY model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_MSGTYPE_WAY>(data);
            int id = msgModels.MSGTYPE_WAY.Delete(model, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "删除成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Create_SYS_SYSINFO(string TTdata, string MXdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_SYS_SYSINFO TTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SYS_SYSINFO>(TTdata);
            MSG_SYS_STAFF[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SYS_STAFF[]>(MXdata);

            TTmodel.CJR = appClass.CRM_GetStaffid();
            int id = msgModels.SYS_SYSINFO.Create(TTmodel, token);
            if (id <= 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "新增失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            for (int i = 0; i < MXmodel.Length; i++)
            {
                MXmodel[i].SYSID = id;
                MXmodel[i].CJR = appClass.CRM_GetStaffid();
                int id2 = msgModels.SYS_STAFF.Create(MXmodel[i], token);
                if (id2 <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "新增负责人失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }

            webmsg.KEY = 1;
            webmsg.MSG = "新增成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Update_SYS_SYSINFO(string TTdata, string MXdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_SYS_SYSINFO TTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SYS_SYSINFO>(TTdata);
            MSG_SYS_STAFF[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SYS_STAFF[]>(MXdata);

            TTmodel.XGR = appClass.CRM_GetStaffid();
            int id = msgModels.SYS_SYSINFO.Update(TTmodel, token);
            if (id <= 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "修改失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            msgModels.SYS_STAFF.DeleteBySYSID(id, 0, token);
            for (int i = 0; i < MXmodel.Length; i++)
            {
                MXmodel[i].SYSID = id;
                MXmodel[i].CJR = appClass.CRM_GetStaffid();
                int id2 = msgModels.SYS_STAFF.Create(MXmodel[i], token);
                if (id2 <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "更新负责人失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }

            webmsg.KEY = 1;
            webmsg.MSG = "修改成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Update_SYS_AllMode(int mode)
        {
            token = appClass.CRM_Gettoken();
            MSG_SYS_SYSINFO model = new MSG_SYS_SYSINFO();
            MSG_SYS_SYSINFO[] TTmodel = msgModels.SYS_SYSINFO.ReadByParam(model, token);

            for (int i = 0; i < TTmodel.Length; i++)
            {
                TTmodel[i].MODE = mode;
                int id = msgModels.SYS_SYSINFO.Update(TTmodel[i], token);
                if (id <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "一键修改失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }

            webmsg.KEY = 1;
            webmsg.MSG = "一键修改成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Select_SYS_SYSINFO(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_SYS_SYSINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SYS_SYSINFO>(cxdata);
            MSG_SYS_SYSINFO[] data = msgModels.SYS_SYSINFO.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public string Delete_SYS_SYSINFO(int SYSID)
        {
            token = appClass.CRM_Gettoken();
            int id = msgModels.SYS_SYSINFO.Delete(SYSID, appClass.CRM_GetStaffid(), token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "删除成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Create_SYS_STAFF(string data)
        {
            token = appClass.CRM_Gettoken();
            MSG_SYS_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SYS_STAFF>(data);
            int id = msgModels.SYS_STAFF.Create(model, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "新增成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "新增失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Update_SYS_STAFF(string data)
        {
            token = appClass.CRM_Gettoken();
            MSG_SYS_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SYS_STAFF>(data);
            int id = msgModels.SYS_STAFF.Update(model, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "修改成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "修改失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Select_SYS_STAFF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_SYS_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SYS_STAFF>(cxdata);
            MSG_SYS_STAFF[] data = msgModels.SYS_STAFF.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public string Delete_SYS_STAFF(int ID)
        {
            token = appClass.CRM_Gettoken();
            int id = msgModels.SYS_STAFF.Delete(ID, appClass.CRM_GetStaffid(), token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "删除成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Create_SEND_INFO(string data)
        {
            token = appClass.CRM_Gettoken();
            MSG_SEND_INFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SEND_INFO>(data);
            int id = msgModels.SEND_INFO.Create(model, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "新增成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "新增失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Update_SEND_INFO(string data)
        {
            token = appClass.CRM_Gettoken();
            MSG_SEND_INFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SEND_INFO>(data);
            int id = msgModels.SEND_INFO.Update(model, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "修改成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "修改失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Select_SEND_INFO(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            MSG_SEND_INFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MSG_SEND_INFO>(cxdata);
            MSG_SEND_INFO[] data = msgModels.SEND_INFO.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public string Delete_SEND_INFO(int INFOID)
        {
            token = appClass.CRM_Gettoken();
            int id = msgModels.SEND_INFO.Delete(INFOID, token);
            if (id > 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "删除成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string AutoCheck()
        {
            token = appClass.CRM_Gettoken();
            string data = msgModels.SEND_INFO.AutoCheck();
            
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }










    }
}
