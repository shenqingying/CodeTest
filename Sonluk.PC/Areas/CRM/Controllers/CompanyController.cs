using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.QYJS_MENUService;
using System.IO;
using Sonluk.UI.Model.CRM.HG_WJJLService;
using Sonluk.UI.Model.CRM.QYJS_FILEService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /CRM/Company/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Basic()
        {
            Session["location"] = 87;
            token = appClass.CRM_Gettoken();

            CRM_QYJS_MENU model = new CRM_QYJS_MENU();
            model.PLOGID = 2;
            CRM_QYJS_MENU[] data = crmModels.QYJS_MENU.ReadTTbyParam(model, token);
            ViewBag.data = data;

            return View();
        }

        public ActionResult Product()
        {
            Session["location"] = 88;
            token = appClass.CRM_Gettoken();

            CRM_QYJS_MENU model = new CRM_QYJS_MENU();
            model.PLOGID = 3;
            CRM_QYJS_MENU[] data = crmModels.QYJS_MENU.ReadTTbyParam(model, token);
            ViewBag.data = data;
            return View();
        }

        public ActionResult Promotion()
        {
            Session["location"] = 89;
            token = appClass.CRM_Gettoken();

            CRM_QYJS_MENU model = new CRM_QYJS_MENU();
            model.PLOGID = 4;
            CRM_QYJS_MENU[] data = crmModels.QYJS_MENU.ReadTTbyParam(model, token);
            ViewBag.data = data;
            return View();
        }

        public ActionResult Basic_Edit()
        {
            Session["location"] = 90;
            return View();
        }

        public ActionResult Product_Edit()
        {
            Session["location"] = 91;
            return View();
        }

        public ActionResult QYJS_Edit()
        {
            Session["location"] = 92;
            return View();
        }

        public ActionResult QYJS_Edit1()
        {
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
            model.PC = 1;
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
            model.PC = 1;
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
            model.PC = 1;
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
            model.PC = 1;
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
        public string Data_Select_AllMenu()             //查询出所有菜单     然后转成树状结构
        {
            token = appClass.CRM_Gettoken();
            CRM_QYJS_MENU model = new CRM_QYJS_MENU();
            CRM_QYJS_MENU[] data = crmModels.QYJS_MENU.ReadTTbyParam(model, token);
            LayuiTree[] result = new LayuiTree[data.Length];

            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)           //把查询出来的数据转换成layui属性列表要求的格式，顺便把图片的路径改成网络路径
            {
                result[i] = new LayuiTree();
                result[i].Id = data[i].CATALOGID;
                result[i].Pid = data[i].PLOGID;
                result[i].title = data[i].NAME;

                if (data[i].ML != "")
                {
                    string[] p = data[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].ML = netpath + path;
                }
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return s;
        }

        [HttpPost]
        public string Data_Insert_MenuImg(int CATALOGID)        //上传照片
        {
            var file = Request.Files[0];

            string date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss.fff");
            string fileName = "cp_" + date;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            string Path_Data = FileSavePath + @"\upload\QYJS" + @"\file\" + fileName + "." + name[count];
            string Path = FileSavePath2 + @"\\upload\\QYJS" + @"\\file\\" + fileName + "." + name[count];
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"] + @"QYJS\/" + @"file\/" + fileName + "." + name[count];
            file.SaveAs(Path);
            FileInfo fi = new FileInfo(Path);
            if (fi.Exists == true)
            {
                if (CATALOGID != 0)
                {
                    token = appClass.CRM_Gettoken();
                    CRM_QYJS_MENU data = crmModels.QYJS_MENU.ReadbyID(CATALOGID, token);
                    data.ML = Path_Data;
                    crmModels.QYJS_MENU.Update(data, token);
                }


                string json = "{\"code\":0,\"res\":\"" + netpath + "\",\"locapath\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "";
            }

        }

        [HttpPost]
        public string Data_FileUpload(string data)
        {
            var file = Request.Files[0];


            string date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss.fff");
            string fileName = date;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            string Path = FileSavePath2 + @"\\upload\\QYJS\\file\\" + fileName + "." + name[count];
            string savePath = FileSavePath + @"\upload\QYJS\file\" + fileName + "." + name[count];

            file.SaveAs(savePath);
            FileInfo fi = new FileInfo(savePath);
            if (fi.Exists == true)
            {
                token = appClass.CRM_Gettoken();
                CRM_QYJS_FILE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_QYJS_FILE>(data);
                model.WJM = gotname;
                model.ML = savePath;
                model.ISACTIVE = 1;
                model.CJR = appClass.CRM_GetStaffid();
                if(model.PC == 0 && model.MOBILE == 0)
                {
                    model.PC = 1;
                }

                
                int i = crmModels.QYJS_FILE.Create(model, token);

                string json = "{\"code\":0,\"res\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "{}";
            }

        }

        [HttpPost]
        public string Data_Insert_QYJS_File(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_QYJS_FILE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_QYJS_FILE>(data);
            model.CJR = appClass.CRM_GetStaffid();
            int i = crmModels.QYJS_FILE.Create(model, token);
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
        public string Data_Update_QYJS_File(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_QYJS_FILE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_QYJS_FILE>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.QYJS_FILE.Update(model, token);
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
        public string Data_Delete_QYJS_File(int ID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.QYJS_FILE.Delete(ID, token);
            if (i > 0)
            {
                webmsg.KEY = i;
                webmsg.MSG = "删除成功！";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "删除失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
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
