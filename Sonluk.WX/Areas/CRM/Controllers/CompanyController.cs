using Sonluk.UI.Model.CRM.HG_WJJLService;
using Sonluk.UI.Model.CRM.QYJS_FILEService;
using Sonluk.UI.Model.CRM.QYJS_MENUService;
using Sonluk.WX.APPCLASS;
using Sonluk.WX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /CRM/Company/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Basic()
        {
            token = appClass.CRM_Gettoken();

            CRM_QYJS_MENU model = new CRM_QYJS_MENU();
            model.PLOGID = 2;
            CRM_QYJS_MENU[] data = crmModels.QYJS_MENU.ReadTTbyParam(model, token);
            ViewBag.data = data;
            return View();
        }

        public ActionResult Product()
        {
            token = appClass.CRM_Gettoken();

            CRM_QYJS_MENU model = new CRM_QYJS_MENU();
            model.PLOGID = 3;
            CRM_QYJS_MENU[] data = crmModels.QYJS_MENU.ReadTTbyParam(model, token);
            ViewBag.data = data;
            return View();
        }

        public ActionResult Promotion()
        {
            token = appClass.CRM_Gettoken();

            CRM_QYJS_MENU model = new CRM_QYJS_MENU();
            model.PLOGID = 4;
            CRM_QYJS_MENU[] data = crmModels.QYJS_MENU.ReadTTbyParam(model, token);
            ViewBag.data = data;
            return View();
        }

        [HttpPost]
        public ActionResult LoadDownMenu(int CATALOGID)
        {
            token = appClass.CRM_Gettoken();

            CRM_QYJS_MENU model = new CRM_QYJS_MENU();
            model.PLOGID = CATALOGID;
            CRM_QYJS_MENU[] data = crmModels.QYJS_MENU.ReadTTbyParam(model, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].ML != "")
                {
                    string[] p = data[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].ML = netpath + path;
                }
            }
            ViewBag.data = data;

            return View();
        }

        [HttpPost]
        public ActionResult LoadMenuMX(int CATALOGID)
        {
            token = appClass.CRM_Gettoken();

            CRM_QYJS_MENU menu = crmModels.QYJS_MENU.ReadbyID(CATALOGID, token);
            ViewBag.NAME = menu.NAME;

            CRM_QYJS_FILE model = new CRM_QYJS_FILE();
            model.CATALOGID = CATALOGID;
            model.MOBILE = 1;
            CRM_QYJS_FILE[] data = crmModels.QYJS_FILE.ReadByParam(model, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].ML != "")
                {
                    string[] p = data[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].ML = netpath + path;
                }
            }
            ViewBag.data = data;
            return View();
        }


        public ActionResult MenuMX(int CATALOGID)
        {
            token = appClass.CRM_Gettoken();

            CRM_QYJS_MENU menu = crmModels.QYJS_MENU.ReadbyID(CATALOGID, token);
            ViewBag.NAME = menu.NAME;

            CRM_QYJS_FILE model = new CRM_QYJS_FILE();
            model.CATALOGID = CATALOGID;
            model.MOBILE = 1;
            CRM_QYJS_FILE[] data = crmModels.QYJS_FILE.ReadByParam(model, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].ML != "")
                {
                    string[] p = data[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].ML = netpath + path;
                }
            }
            ViewBag.data = data;
            return View();
        }

        [HttpPost]
        public ActionResult LoadVideoIMG(int CATALOGID)
        {
            token = appClass.CRM_Gettoken();

            CRM_QYJS_FILE model = new CRM_QYJS_FILE();
            model.CATALOGID = CATALOGID;
            model.MOBILE = 1;
            CRM_QYJS_FILE[] data = crmModels.QYJS_FILE.ReadByParam(model, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].ML != "")
                {
                    string[] p = data[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].ML = netpath + path;
                }
                if (data[i].COVER != "")
                {
                    string[] p = data[i].COVER.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].COVER = netpath + path;
                }
            }
            ViewBag.data = data;

            return View();
        }

        public ActionResult Video_Play(int ID)
        {
            token = appClass.CRM_Gettoken();
            CRM_QYJS_FILE model = new CRM_QYJS_FILE();
            model.ID = ID;
            model.MOBILE = 1;
            CRM_QYJS_FILE[] data = crmModels.QYJS_FILE.ReadByParam(model, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)           //把图片的路径改成网络路径
            {
                if (data[i].ML != "")
                {
                    string[] p = data[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].ML = netpath + path;
                }
                if (data[i].COVER != "")
                {
                    string[] p = data[i].COVER.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].COVER = netpath + path;
                }
            }
            ViewBag.data = data[0];
            return View();
        }

        [HttpPost]
        public string Data_Insert_Menu(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_QYJS_MENU model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_QYJS_MENU>(data);
            model.CJR = appClass.CRM_GetStaffid();
            int i = crmModels.QYJS_MENU.Create(model, token);
            if (i > 0)
            {
                webmsg.KEY = i;
                webmsg.MSG = "新增成功！";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "新增失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_Menu(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_QYJS_MENU model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_QYJS_MENU>(data);
            model.XGR = appClass.CRM_GetStaffid();
            if (model.ML == "")
                model.ML = crmModels.QYJS_MENU.ReadbyID(model.CATALOGID, token).ML;
            int i = crmModels.QYJS_MENU.Update(model, token);
            if (i > 0)
            {
                webmsg.KEY = i;
                webmsg.MSG = "修改成功！";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "修改失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_Menu(int CATALOGID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.QYJS_MENU.Delete(CATALOGID, token);
            if (i > 0)
            {
                webmsg.KEY = i;
                webmsg.MSG = "修改成功！";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "修改失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_SelectByID(int CATALOGID)
        {
            token = appClass.CRM_Gettoken();
            CRM_QYJS_MENU data = crmModels.QYJS_MENU.ReadbyID(CATALOGID, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            if (data.ML != "")
            {
                string[] p = data.ML.Split('\\');
                int count = p.Length - 1;
                string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                data.ML = netpath + path;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SelectByParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_QYJS_MENU model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_QYJS_MENU>(cxdata);
            CRM_QYJS_MENU[] data = crmModels.QYJS_MENU.ReadTTbyParam(model, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)           //把查询出来的数据转换成layui属性列表要求的格式，顺便把图片的路径改成网络路径
            {
                if (data[i].ML != "")
                {
                    string[] p = data[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].ML = netpath + path;
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SelectQYJS_FileByParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_QYJS_FILE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_QYJS_FILE>(cxdata);

            CRM_QYJS_FILE[] data = crmModels.QYJS_FILE.ReadByParam(model, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)           //把图片的路径改成网络路径
            {
                if (data[i].ML != "")
                {
                    string[] p = data[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].ML = netpath + path;
                }
                if (data[i].COVER != "")
                {
                    string[] p = data[i].COVER.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].COVER = netpath + path;
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }






    }
}
