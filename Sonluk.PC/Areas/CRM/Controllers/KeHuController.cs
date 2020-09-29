using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Sonluk.UI.Model.CRM.CRM_KHService;
//using Sonluk.UI.Model.CRM.CRM_HGService;
using Sonluk.PC.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.KH_LXRService;
using Sonluk.UI.Model.CRM.KH_GXQYService;
using Sonluk.UI.Model.CRM.KH_KHQTXXService;
using Sonluk.UI.Model.CRM.HG_WJJLService;
using Sonluk.UI.Model.CRM.KH_GROUPService;
using Sonluk.UI.Model.CRM.HG_TYPEService;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.KH_HZHBService;
using Sonluk.UI.Model.CRM.KH_GROUP_KHService;
using Sonluk.UI.Model.CRM;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.KH_GROUP_STAFFService;
using Sonluk.UI.Model.CRM.KH_GROUP_XSQYService;
using Sonluk.UI.Model.CRM.HG_DUTYService;
using Sonluk.UI.Model.CRM.HG_STAFFDUTYService;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Text.RegularExpressions;
//using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Threading;
using Sonluk.UI.Model.CRM.KH_DZService;
using System.Net;
using Sonluk.UI.Model.CRM.KH_KHBFService;
using Sonluk.UI.Model.CRM.KH_BFService;
using Sonluk.UI.Model.CRM.HG_KHLXService;
using Sonluk.UI.Model.CRM.KH_KHXSService;
using Sonluk.UI.Model.CRM_OAService;
using Sonluk.UI.Model.CRM.OA_TRANSMITService;
//using System.Threading;
using Sonluk.UI.Model.CRM.KH_XSYWJZService;
using Sonluk.UI.Model.CRM.KH_KHZZService;
using NPOI.SS.Util;
using Sonluk.UI.Model.CRM.KH_HDService;
using Sonluk.PC.APPCLASS;
using Sonluk.UI.Model.CRM.HG_STAFFKHLXService;
using Sonluk.UI.Model.MES.MM_CKService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class KeHuController : Controller
    {
        //
        // GET: /CRM/KeHu/
        CRMModels crmModels = new CRMModels();
        MESModels mesModels = new MESModels();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];
        AppClass appClass = new AppClass();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 1;
            //更新PartialView                 
            //return PartialView("Insert");
            CRM_HG_DICT[] YYZT = crmModels.HG_DICT.Read(114, 0, token);
            ViewBag.YYZT = YYZT;
            MES_MM_CK model = new MES_MM_CK();
            model.ROLENAME = "1000-KA仓库";
            MES_MM_CK_SELECT data = mesModels.MM_CK.SELECT_BY_ROLE_ASSEMBLE(model, token);
            ViewBag.KCDD = data.MES_MM_CK;
            return View();

        }
        public ActionResult test()
        {

            return View();
        }

        [HttpPost]
        public double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double EARTH_RADIUS = 6378137;

            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }
        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }


        [HttpPost]
        public int Data_Insert(string data, string zzdata)          //新增客户信息
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //crmModels = js.Deserialize<CRMModels>(data);

            //crmModels = ParseFromJson<CRMModels>(data);

            token = appClass.CRM_Gettoken();

            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH>(data);

            if (model.KHLX == 5)
            {
                //终端网点需要根据名称、地址、电话来校验是否重复
                CRM_KH_KH cx_check = new CRM_KH_KH();
                cx_check.MC_ALL = model.MC;
                cx_check.MDDZ = model.MDDZ;
                cx_check.GSLXDH = model.GSLXDH;
                CRM_KH_KH[] check = crmModels.KH_KH.Read(cx_check, token);
                if(check.Length != 0)
                {
                    return -2;
                }
            }





            model.FID = Convert.ToInt32(Session["STAFFID"]);
            if (model.IsOfficial == 10)
                model.ISACTIVE = 3;
            int id = crmModels.KH_KH.Create(model, token);
            //如果当前人员只有一个分组时，默认把这个客户分配进这个分组

            if (crmModels.KH_GROUP_STAFF.ReadByStaffID(Convert.ToInt32(Session["STAFFID"]), token).Length == 1)       //这个人员只有一个分组
            {
                int gid = Convert.ToInt32(crmModels.KH_GROUP_STAFF.ReadByStaffID(Convert.ToInt32(Session["STAFFID"]), token)[0][0]);   //取出这个分组id
                crmModels.KH_GROUP_KH.Create(id, gid, token);
            }

            CRM_KH_KHZZ[] zzmodel = JsonConvert.DeserializeObject<CRM_KH_KHZZ[]>(zzdata);
            for (int i = 0; i < zzmodel.Length; i++)
            {
                zzmodel[i].CZR = Convert.ToInt32(Session["STAFFID"]);
                zzmodel[i].KHID = id;
                int j = crmModels.KH_KHZZ.Create(zzmodel[i], token);
                if (j <= 0)
                {
                    return 0;
                }
            }

            return id;
        }

        [HttpPost]
        public string Data_Load_Dropdown(int typeid, int fid)         //下拉框选项加载
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] list = crmModels.HG_DICT.Read(typeid, fid, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            return json;
        }

        [HttpPost]
        public string Data_LoadDDL_PKH(int typeid, int fid)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] list = crmModels.HG_DICT.Read(typeid, fid, token);
            List<CRM_HG_DICT> pkhlist = new List<CRM_HG_DICT>();
            foreach (CRM_HG_DICT s in list)
            {
                if (s.DICID == 1 || s.DICID == 10)
                    pkhlist.Add(s);
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pkhlist);

            return json;
        }

        [HttpPost]
        public string Data_SelectDict_ByDicID(int DICID)
        {
            token = appClass.CRM_Gettoken();
            //通过地级市的fid，也就是城市的dicid去获得城市的fid，也就是省份的dicid，然后来加载省份的下拉框
            CRM_HG_DICT xian_data = crmModels.HG_DICT.ReadByDICID(DICID, token);
            CRM_HG_DICT city_data = crmModels.HG_DICT.ReadByDICID(xian_data.FID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(city_data);
            return s;
        }

        [HttpPost]
        public string Data_Select_UpKH(string data)        //选择上级客户
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHService.CRM_Report_KHModel model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_Report_KHModel>(data);
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KHList[] list = crmModels.KH_KH.Report(model, Convert.ToInt32(Session["STAFFID"]), token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return s;
        }

        [HttpPost]
        public string Data_Select(string data)          //查询客户列表
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHService.CRM_Report_KHModel report_model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_Report_KHModel>(data);
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KHList[] list = crmModels.KH_KH.Report(report_model, Convert.ToInt32(Session["STAFFID"]), token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return s;
        }

        [HttpPost]
        public string Data_SelectAllKH(string data)          //查询所有客户列表
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHService.CRM_Report_KHModel report_model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_Report_KHModel>(data);
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KHList[] list = crmModels.KH_KH.Report(report_model, 0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return s;
        }

        [HttpPost]
        public string Data_Select_ByID(int id)           //打开编辑页面时加载客户基本信息
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KHList model = crmModels.KH_KH.Read(id, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }

        [HttpPost]
        public string Data_Select_KeHu_ByCRMID(string CRMID)           //打开编辑页面时加载客户基本信息
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(CRMID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }

        [HttpPost]
        public int Data_Update(string data, string zzdata)            //修改客户信息
        {
            token = appClass.CRM_Gettoken();

            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH>(data);
            model.FID = Convert.ToInt32(Session["STAFFID"]);
            //如果这个客户目前没有进任何分组，那么当当前人员只有一个分组时，默认把这个客户分配进这个分组
            if (crmModels.KH_GROUP_KH.ReadByKHID(token, model.KHID).Length == 0)         //这个客户没有归属于任何分组
            {
                if (crmModels.KH_GROUP_STAFF.ReadByStaffID(Convert.ToInt32(Session["STAFFID"]), token).Length != 1)        //这个人员有多个分组
                {
                    return -10;
                }
            }
            if (model.KHLX == 5 && crmModels.KH_HD.ReadByKHID(model.KHID, token).Length == 0)      //是终端网点且没有活动信息
            {
                return -11;
            }
            int count = crmModels.KH_KH.Update(model, token, true);

            crmModels.KH_KHZZ.DeleteByKHID(model.KHID, token);
            CRM_KH_KHZZ[] zzmodel = JsonConvert.DeserializeObject<CRM_KH_KHZZ[]>(zzdata);
            for (int i = 0; i < zzmodel.Length; i++)
            {
                zzmodel[i].CZR = Convert.ToInt32(Session["STAFFID"]);
                zzmodel[i].KHID = model.KHID;
                int j = crmModels.KH_KHZZ.Create(zzmodel[i], token);
                if (j <= 0)
                {
                    return 0;
                }
            }

            return count;
        }

        [HttpPost]
        public int Data_Delete(int id)                //删除客户信息,当然只是逻辑删除
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_KH.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_QTXX(string data)         //新增客户其他信息
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int count = crmModels.KH_KHQTXX.Create(model, token);
            return count;

        }

        [HttpPost]
        public int Data_Update_QTXX(string data)            //修改客户其他信息
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_KHQTXX.Update(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_QTXX(int KHID, int XXLB)        //查询客户其他信息
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXXList[] data = crmModels.KH_KHQTXX.Read(KHID, XXLB, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_QTXX(int xxid)              //删除客户其他信息
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_KHQTXX.Delete(xxid, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_Contact(string data)      //新增客户联系人
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXR model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXR>(data);
            int i = crmModels.KH_LXR.Create(model, token);
            return i;
        }

        public string Data_Insert_ContacImg(int KHID)        //上传客户联系人照片
        {
            var file = Request.Files[0];

            string date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss.fff");
            string fileName = date + "_" + KHID;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            //string Path = FileSavePath2 + @"\\Areas\\CRM\\upload\\" + year + @"\\" + month + @"\\" + fileName + "." + name[count];
            string Path = FileSavePath2 + @"\\upload\\" + year + @"\\" + month + @"\\" + fileName + "." + name[count];
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"] + year + @"\/" + month + @"\/" + fileName + "." + name[count];
            file.SaveAs(Path);
            FileInfo fi = new FileInfo(Path);
            if (fi.Exists == true)
            {

                token = appClass.CRM_Gettoken();

                string json = "{\"code\":0,\"res\":\"" + netpath + "\",\"locapath\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "";
            }

        }

        [HttpPost]
        public string Data_Select_Contact(int id, int LB)               //查询客户联系人
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXRList[] data = crmModels.KH_LXR.Read(id, LB, token);

            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].PHOTO != "")
                {
                    string[] p = data[i].PHOTO.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count];
                    data[i].PHOTO = netpath + year + "\\" + month + "\\" + path;
                }
            }

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_Contact(string data)            //修改客户联系人
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXR model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXR>(data);
            int i = crmModels.KH_LXR.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Contact(int id)              //删除客户联系人
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_LXR.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_Area(string data)             //新建管辖区域
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY>(data);
            int i = crmModels.KH_GXQY.Create(model, token);

            return i;
        }

        [HttpPost]
        public string Data_Select_Area(int id)                //查询管辖区域
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQYList[] data = crmModels.KH_GXQY.Read(id, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return s;
        }

        [HttpPost]
        public int Data_Update_Area(string data)             //修改管辖区域
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY>(data);
            int i = crmModels.KH_GXQY.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Area(int id)                 //删除管辖区域
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_GXQY.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_WJJL(string data)              // 新建文件记录
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_WJmodel model = JsonConvert.DeserializeObject<CRM_HG_WJmodel>(data);
            int i = crmModels.HG_WJJL.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_WJJL(int dxname, int id)            //查询文件记录
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_WJJL[] data = crmModels.HG_WJJL.Read(dxname, id, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
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

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_WJJLByParam(string cxdata)            //查询文件记录
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_WJJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_WJJL>(cxdata);
            CRM_HG_WJJL[] data = crmModels.HG_WJJL.ReadByParam(model, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
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

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_WJJL_DisplayImgReport(string cxdata)            //查询文件记录
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_WJJL_KHModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_WJJL_KHModel>(cxdata);
            CRM_HG_WJJL[] data = crmModels.HG_WJJL.DisplayImgReport(model, appClass.CRM_GetStaffid(), token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
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

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Update_WJJLSP(string data)
        {
            token = appClass.CRM_Gettoken();
            WebMSG webmsg = new WebMSG();
            CRM_HG_WJJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_WJJL>(data);
            model.SPR = appClass.CRM_GetStaffid();
            model.SPSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int i = crmModels.HG_WJJL.Update_SP(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "审核成功！";
            else
                webmsg.MSG = "审核失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_WJJLSP_Multi(string data, int SPZT, int SPYJ, string OPINION)
        {
            token = appClass.CRM_Gettoken();
            WebMSG webmsg = new WebMSG();
            CRM_HG_WJJL[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_WJJL[]>(data);
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            for (int i = 0; i < model.Length; i++)
            {
                model[i].SPZT = SPZT;
                model[i].SPYJ = SPYJ;
                model[i].OPINION = OPINION;
                model[i].SPR = appClass.CRM_GetStaffid();
                model[i].SPSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                int id = crmModels.HG_WJJL.Update_SP(model[i], token);
                if (id <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "批量操作出现问题，请重新查询！";
                }
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public int Data_Delete_WJJL(int id)                 //删除文件记录
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.HG_WJJL.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_Group(int KHID, int GID)        //分配客户到组
        {
            token = appClass.CRM_Gettoken();

            int i = crmModels.KH_GROUP_KH.Create(KHID, GID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Group(int KHID)           //查询客户与组的关联
        {
            token = appClass.CRM_Gettoken();
            string[][] data = crmModels.KH_GROUP_KH.ReadByKHID(token, KHID);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_Group(int KHID, int GID)                     //删除客户与组的关联
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_GROUP_KH.Delete(KHID, GID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_AllGroup()             //查询出所有权限内的客户分组     客户分组下拉框专用
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUPList[] data = crmModels.KH_GROUP.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            LayuiTree[] result = new LayuiTree[data.Length];

            for (int i = 0; i < data.Length; i++)           //把查询出来的数据转换成layui属性列表要求的格式
            {
                result[i] = new LayuiTree();
                result[i].Id = data[i].GID;
                result[i].XSQYID = data[i].XSQYID;
                result[i].Pid = data[i].PGID;
                result[i].title = data[i].NAME1;
                result[i].Khjlid = data[i].KHJLID;
                result[i].Fgldid = data[i].FGLDID;
                result[i].Gmemo = data[i].GMEMO;
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return s;
        }

        [HttpPost]
        public string Data_Select_KHGROUPbyParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUPList model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_GROUPList>(cxdata);
            CRM_KH_GROUPList[] data = crmModels.KH_GROUP.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_Partner(string sapsn)    //查询客户合作伙伴
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_HZHBLIST[] data = crmModels.KH_HZHB.Read(sapsn, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_Allxszz()         //查询出所有的销售组织     销售组织下拉框专用
        {
            token = appClass.CRM_Gettoken();
            string[] data = crmModels.KH_KH.ReadXSZZ(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        public static T ParseFromJson<T>(string szJson)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }


        public ActionResult Insert_Area()
        {

            return View();
        }

        public ActionResult Insert_Partner()
        {

            return View();
        }

        public ActionResult Insert_Contact()
        {

            return View();
        }

        public ActionResult Insert_Post()
        {

            return View();
        }

        public ActionResult Insert_Display()
        {

            return View();
        }

        public ActionResult Insert_Jingpin()
        {

            return View();
        }

        public ActionResult SubmitOA()
        {
            Session["location"] = 42;
            return View();
        }

        public ActionResult Select()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 2;

            CRM_HG_DICT[] YYZT = crmModels.HG_DICT.Read(114, 0, token);
            ViewBag.YYZT = YYZT;
            //return PartialView("Select");
            return View();
        }

        public ActionResult Select_Only()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 50;

            CRM_HG_DICT[] YYZT = crmModels.HG_DICT.Read(114, 0, token);
            ViewBag.YYZT = YYZT;
            //return PartialView("Select");
            return View();
        }

        public ActionResult Sap()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 3;
            //return PartialView("Sap");
            CRM_HG_DICT[] KHLX = crmModels.HG_DICT.Read(32, 0, token);
            ViewBag.KHLX = KHLX;
            return View();
        }

        [HttpPost]
        public string Data_SAP_PP(string CRMID, string SAPSN)
        {
            token = appClass.CRM_Gettoken();

            WebMSG webmsg = new WebMSG();
            int i = 0;
            if (SAPSN != "")
            {
                i = crmModels.KH_HZHB.SapDataSynchronization(CRMID, SAPSN, token);
            }
            else
            {
                CRM_KH_KH khdata = crmModels.KH_KH.ReadByCRMID(CRMID, token);
                if (khdata.SAPSN == "")
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "改客户没有维护SAP编号";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                //Sonluk.UI.Model.CRM.KH_HZHBService.SAP_KH[] KH = new Sonluk.UI.Model.CRM.KH_HZHBService.SAP_KH[1];
                //KH[0] = new UI.Model.CRM.KH_HZHBService.SAP_KH();
                //KH[0].KUNNR = khdata.SAPSN;

                //SAP_HZHBList result = crmModels.KH_HZHB.SyncSapRead(KH, khdata.KHLX, token);
                //if (result.ET_KH.Length == 0)
                //{
                //    webmsg.KEY = 0;
                //    webmsg.MSG = "找不到该客户所对应的SAP编号";
                //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                //}
                //else
                //{
                //    khdata.MC = result.ET_KH[0].NAME1;
                //    i = crmModels.KH_KH.Update(khdata, token, true);
                //}
                i = crmModels.KH_KH.Update(khdata, token, true);
            }


            webmsg.KEY = i;
            if (i > 0)
            {
                webmsg.MSG = "执行成功";
            }
            else if (i == -1)
            {
                webmsg.MSG = "该SAP编号不存在";
            }
            else if (i == -2)
            {
                webmsg.MSG = "该SAP编号已与其他客户匹配";
            }
            else if (i == -3)
            {
                webmsg.MSG = "CRM编号不存在";
            }
            else
            {
                webmsg.MSG = "执行失败";
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public ActionResult Daoru()
        {
            Session["location"] = 4;
            //return PartialView("Daoru");
            return View();
        }

        public ActionResult Dao_Ru_ZDWD()
        {
            Session["location"] = 541;
            return View();
        }

        [HttpPost]
        public string Data_DaoRu(int type)
        {
            string s = "";
            switch (type)
            {
                case 1:                 //新增客户主数据
                    s = Data_DaoRu_KeHu_Insert();
                    break;
                case 2:                 //修改客户主数据
                    s = Data_DaoRu_KeHu_Update();
                    break;
                case 3:                 //新增客户其他数据
                    s = Data_DaoRu_QT_Insert();
                    break;
                case 4:                 //修改客户其他数据
                    s = Data_DaoRu_QT_Update();
                    break;
                case 5:                 //只修改省份城市县级市
                    s = Data_DaoRu_SFCS_Update();
                    break;
                default:

                    break;
            }


            return s;
        }


        /// <summary>
        /// 批量新增客户主数据
        /// </summary>
        /// <returns></returns>
        public string Data_DaoRu_KeHu_Insert()
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                var file = Request.Files[0];
                //string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                //string fileName = date + "_" + KHID;
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                string gotname = file.FileName;
                //string[] name = gotname.Split('.');

                //int count = name.Length - 1;
                //string savePath = @"E:\CRM\Areas\CRM\upload\" + year + @"\" + month + @"\" + fileName + "." + name[count];
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);


                if (fi.Exists == true)
                {
                    string[] sheet = { "经销商、电商、B2B", "直营卖场系统", "直营卖场门店", "终端网点", "LKA", "LKA门店", "中间商", "OEM" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //经销商、电商、B2B
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("CRM编号") == true || data1.Columns.Contains("SAP编号") == false)
                        {
                            msg.Msg = "请使用客户新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["客户性质"].ToString() != "签约客户" && data1.Rows[i]["客户性质"].ToString() != "潜在客户")
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行客户性质不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        bool sap404 = false;  //要改成判断这个SAP编号存不存在   data1.Rows[i]["SAP编号"]
                                        if (data1.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data1.Rows[i]["SAP编号"].ToString(), token) == null)
                                            sap404 = true;
                                        if (sap404)
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行SAP编号不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["SAP编号"].ToString() != "")
                                        {
                                            CRM_Report_KHModel model = new CRM_Report_KHModel();
                                            model.SAPSN = data1.Rows[i]["SAP编号"].ToString();
                                            model.ISACTIVE = 3;
                                            CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                            if (sapkehu.Length >= 1)
                                            {
                                                msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行SAP编号已经存在！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                        if (data1.Rows[i]["上级客户编号"].ToString() != "")
                                        {
                                            if (Regex.IsMatch(data1.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                            {
                                                msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行上级客户编号必须为全数字！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (data1.Rows[i]["上级客户编号"].ToString().Length != 8)
                                            {
                                                msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行上级客户编号错误！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }

                                        //if (data1.Rows[i]["客户类型"].ToString() == "")
                                        //{
                                        //    int khlx = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["客户类型"].ToString(), 32, token);
                                        //    if (khlx == 0)
                                        //    {
                                        //        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行客户类型不能为空！";
                                        //        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //    }

                                        //}
                                        int KHLX2 = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["大客户类型"].ToString(), 52, token);
                                        if (KHLX2 == 0)
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行大客户类型不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        int MCLC = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["行业所属分类"].ToString(), 60, token);
                                        if (MCLC == 0)
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行行业所属分类不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["客户类型"].ToString() != "经销商" && data1.Rows[i]["客户类型"].ToString() != "电商" && data1.Rows[i]["客户类型"].ToString() != "B2B")
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行客户类型错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        int kpxz = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["开票性质"].ToString(), 39, token);
                                        if (kpxz == 0)
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行开票性质不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        int khsource = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["经销商来源"].ToString(), 44, token);
                                        if (khsource == 0 && data1.Rows[i]["经销商来源"].ToString() != "")
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行经销商来源不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["是否直销商"].ToString() != "是" && data1.Rows[i]["是否直销商"].ToString() != "否")
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行是否直销商错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["是否出厂价"].ToString() != "是" && data1.Rows[i]["是否出厂价"].ToString() != "否")
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行是否出厂价错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["是否对现有区域经销商影响"].ToString() != "是" && data1.Rows[i]["是否对现有区域经销商影响"].ToString() != "否")
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行是否对现有区域经销商影响错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg.Msg = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }



                        }
                    }
                    #endregion

                    DataTable data2 = ExcelToDataTable(savePath, sheet[1], true);      //直营卖场系统
                    #region
                    if (data2 != null)
                    {
                        if (data2.Columns.Contains("CRM编号") == true || data2.Columns.Contains("SAP编号") == false)
                        {
                            msg.Msg = "请使用客户新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            //做数据验证
                            if (data2.Rows.Count > 0)
                            {
                                for (int i = 0; i < data2.Rows.Count; i++)
                                {
                                    if (data2.Rows[i]["客户性质"].ToString() != "签约客户" && data2.Rows[i]["客户性质"].ToString() != "潜在客户")
                                    {
                                        msg.Msg = "直营卖场系统第" + (i + 2) + "行客户性质不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    bool sap404 = false;  //要改成判断这个SAP编号存不存在   data2.Rows[i]["SAP编号"]
                                    if (data2.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data2.Rows[i]["SAP编号"].ToString(), token) == null)
                                        sap404 = true;
                                    if (sap404)
                                    {
                                        msg.Msg = "直营卖场系统第" + (i + 2) + "行SAP编号不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    //if (Regex.IsMatch(data2.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                    //{
                                    //    msg.Msg = "直营卖场系统第" + (i + 2) + "行上级客户编号必须为全数字！";
                                    //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //}
                                    //if (data2.Rows[i]["上级客户编号"].ToString().Length != 8)
                                    //{
                                    //    msg.Msg = "直营卖场系统第" + (i + 2) + "行上级客户编号错误！";
                                    //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //}
                                    if (data2.Rows[i]["SAP编号"].ToString() != "")
                                    {
                                        CRM_Report_KHModel model = new CRM_Report_KHModel();
                                        model.SAPSN = data2.Rows[i]["SAP编号"].ToString();
                                        model.ISACTIVE = 3;
                                        CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                        if (sapkehu.Length >= 1)
                                        {
                                            msg.Msg = "直营卖场系统第" + (i + 2) + "行SAP编号已经存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                    if (data2.Rows[i]["省份"].ToString() != "")
                                    {
                                        int province = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["省份"].ToString(), 1, token);
                                        if (province == 0)
                                        {
                                            msg.Msg = "直营卖场系统第" + (i + 2) + "行省份不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                    if (data2.Rows[i]["城市"].ToString() != "")
                                    {
                                        int city = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["城市"].ToString(), 2, token);
                                        if (city == 0)
                                        {
                                            msg.Msg = "直营卖场系统第" + (i + 2) + "行城市不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                    if (data2.Rows[i]["县级市"].ToString() != "")
                                    {
                                        int county = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["县级市"].ToString(), 34, token);
                                        if (county == 0)
                                        {
                                            msg.Msg = "直营卖场系统第" + (i + 2) + "行县级市不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }

                                    int kpxz = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["开票性质"].ToString(), 39, token);
                                    if (kpxz == 0)
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行开票性质不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }

                                }
                            }

                        }
                    }
                    #endregion

                    DataTable data2s = ExcelToDataTable(savePath, sheet[2], true);      //直营卖场门店
                    #region
                    if (data2s != null)
                    {
                        if (data2s.Columns.Contains("CRM编号") == true || data2s.Columns.Contains("SAP编号") == false)
                        {
                            msg.Msg = "请使用客户新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            //做数据验证
                            if (data2s.Rows.Count > 0)
                            {
                                for (int i = 0; i < data2s.Rows.Count; i++)
                                {
                                    if (data2s.Rows[i]["客户性质"].ToString() != "签约客户" && data2s.Rows[i]["客户性质"].ToString() != "潜在客户")
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行客户性质不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    bool sap404 = false;  //要改成判断这个SAP编号存不存在   data2s.Rows[i]["SAP编号"]
                                    if (data2s.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data2s.Rows[i]["SAP编号"].ToString(), token) == null)
                                        sap404 = true;
                                    if (sap404)
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行SAP编号不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data2s.Rows[i]["SAP编号"].ToString() != "")
                                    {
                                        CRM_Report_KHModel model = new CRM_Report_KHModel();
                                        model.SAPSN = data2s.Rows[i]["SAP编号"].ToString();
                                        model.ISACTIVE = 3;
                                        CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                        if (sapkehu.Length >= 1)
                                        {
                                            msg.Msg = "直营卖场门店第" + (i + 2) + "行SAP编号已经存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }

                                    if (Regex.IsMatch(data2s.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行上级客户编号必须为全数字！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data2s.Rows[i]["上级客户编号"].ToString().Length != 8)
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行上级客户编号错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }

                                    if (data2s.Rows[i]["省份"].ToString() != "")
                                    {
                                        int province = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["省份"].ToString(), 1, token);
                                        if (province == 0)
                                        {
                                            msg.Msg = "直营卖场门店第" + (i + 2) + "行省份不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                    if (data2s.Rows[i]["城市"].ToString() != "")
                                    {
                                        int city = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["城市"].ToString(), 2, token);
                                        if (city == 0)
                                        {
                                            msg.Msg = "直营卖场门店第" + (i + 2) + "行城市不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                    if (data2s.Rows[i]["县级市"].ToString() != "")
                                    {
                                        int county = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["县级市"].ToString(), 34, token);
                                        if (county == 0)
                                        {
                                            msg.Msg = "直营卖场门店第" + (i + 2) + "行县级市不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }

                                }
                            }

                        }
                    }
                    #endregion

                    DataTable data3 = ExcelToDataTable(savePath, sheet[3], true);      //终端网点
                    #region
                    if (data3 != null)
                    {
                        if (data3.Columns.Contains("CRM编号") == true || data3.Columns.Contains("SAP编号") == false)
                        {
                            msg.Msg = "请使用客户新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            //做数据验证
                            if (data3.Rows.Count > 0)
                            {
                                for (int i = 0; i < data3.Rows.Count; i++)
                                {
                                    if (data3.Rows[i]["客户性质"].ToString() != "非签约客户" && data3.Rows[i]["客户性质"].ToString() != "潜在客户")
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行客户性质不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    bool sap404 = false;  //要改成判断这个SAP编号存不存在   data3.Rows[i]["SAP编号"]
                                    if (data3.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data3.Rows[i]["SAP编号"].ToString(), token) == null)
                                        sap404 = true;
                                    if (sap404)
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行SAP编号不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data3.Rows[i]["SAP编号"].ToString() != "")
                                    {
                                        CRM_Report_KHModel model = new CRM_Report_KHModel();
                                        model.SAPSN = data3.Rows[i]["SAP编号"].ToString();
                                        model.ISACTIVE = 3;
                                        CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                        if (sapkehu.Length >= 1)
                                        {
                                            msg.Msg = "终端网点第" + (i + 2) + "行SAP编号已经存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                    //if (data3.Rows[i]["客户类型"].ToString() != "")
                                    //{
                                    //    int khlx = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["客户类型"].ToString(), 32, token);
                                    //    if (khlx == 0)
                                    //    {
                                    //        msg.Msg = "终端网点第" + (i + 2) + "行客户类型错误！";
                                    //        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //    }
                                    //}
                                    if (Regex.IsMatch(data3.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行上级客户编号必须为全数字！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data3.Rows[i]["上级客户编号"].ToString().Length != 8)
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行上级客户编号错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int province = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["省份"].ToString(), 1, token);
                                    if (province == 0)
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行省份不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int city = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["城市"].ToString(), 2, token);
                                    if (city == 0)
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行城市不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int store_type = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["网点类型"].ToString(), 3, token);
                                    if (store_type == 0)
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行网点类型不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data3.Rows[i]["是否标准网点"].ToString().Trim() != "是" && data3.Rows[i]["是否标准网点"].ToString().Trim() != "否")
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行是否标准网点错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data3.Rows[i]["有效网点开发"].ToString().Trim() != "是" && data3.Rows[i]["有效网点开发"].ToString().Trim() != "否")
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行有效网点开发错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data3.Rows[i]["是否电子锁"].ToString().Trim() != "是" && data3.Rows[i]["是否电子锁"].ToString().Trim() != "否")
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行是否电子锁错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }

                                }
                            }

                        }
                    }
                    #endregion

                    DataTable data4 = ExcelToDataTable(savePath, sheet[4], true);      //LKA
                    #region
                    if (data4 != null)
                    {
                        if (data4.Columns.Contains("CRM编号") == true)
                        {
                            msg.Msg = "请使用客户新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            //做数据验证
                            if (data4.Rows.Count > 0)
                            {
                                for (int i = 0; i < data4.Rows.Count; i++)
                                {
                                    if (data4.Rows[i]["客户性质"].ToString() != "非签约客户" && data4.Rows[i]["客户性质"].ToString() != "潜在客户")
                                    {
                                        msg.Msg = "LKA第" + (i + 2) + "行客户性质不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    //bool sap404 = false;  //要改成判断这个SAP编号存不存在   data4.Rows[i]["SAP编号"]
                                    //if (data4.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data4.Rows[i]["SAP编号"].ToString(), token) == null)
                                    //    sap404 = true;
                                    //if (sap404)
                                    //{
                                    //    msg.Msg = "LKA第" + (i + 2) + "行SAP编号不存在！";
                                    //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //}
                                    //if (data4.Rows[i]["SAP编号"].ToString() != "")
                                    //{
                                    //    CRM_Report_KHModel model = new CRM_Report_KHModel();
                                    //    model.SAPSN = data4.Rows[i]["SAP编号"].ToString();
                                    //    model.ISACTIVE = 3;
                                    //    CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                    //    if (sapkehu.Length >= 1)
                                    //    {
                                    //        msg.Msg = "LKA第" + (i + 2) + "行SAP编号已经存在！";
                                    //        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //    }
                                    //}

                                    if (Regex.IsMatch(data4.Rows[i]["经销商CRM编号"].ToString(), @"^\d+$") == false)
                                    {
                                        msg.Msg = "LKA第" + (i + 2) + "行经销商CRM编号必须为全数字！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data4.Rows[i]["经销商CRM编号"].ToString().Length != 8)
                                    {
                                        msg.Msg = "LKA第" + (i + 2) + "行经销商CRM编号错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data4.Rows[i]["有效网点开发"].ToString().Trim() != "是" && data4.Rows[i]["有效网点开发"].ToString().Trim() != "否")
                                    {
                                        msg.Msg = "LKA第" + (i + 2) + "行有效网点开发错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int JYFS = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["经营方式"].ToString(), 57, token);
                                    if (JYFS == 0)
                                    {
                                        msg.Msg = "LKA第" + (i + 2) + "行经营方式不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int JKFS = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["结款方式"].ToString(), 58, token);
                                    if (JKFS == 0)
                                    {
                                        msg.Msg = "LKA第" + (i + 2) + "行结款方式不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int JQRZW = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["接洽人职务"].ToString(), 59, token);
                                    if (JQRZW == 0)
                                    {
                                        msg.Msg = "LKA第" + (i + 2) + "行接洽人职务不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }




                                }
                            }

                        }
                    }
                    #endregion

                    DataTable data5 = ExcelToDataTable(savePath, sheet[5], true);      //LKA门店
                    #region
                    if (data5 != null)
                    {
                        if (data5.Columns.Contains("CRM编号") == true)
                        {
                            msg.Msg = "请使用客户新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            //做数据验证
                            if (data5.Rows.Count > 0)
                            {
                                for (int i = 0; i < data5.Rows.Count; i++)
                                {
                                    if (data5.Rows[i]["客户性质"].ToString() != "非签约客户" && data5.Rows[i]["客户性质"].ToString() != "潜在客户")
                                    {
                                        msg.Msg = "LKA门店第" + (i + 2) + "行客户性质不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    //bool sap404 = false;  //要改成判断这个SAP编号存不存在   data5.Rows[i]["SAP编号"]
                                    //if (data5.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data5.Rows[i]["SAP编号"].ToString(), token) == null)
                                    //    sap404 = true;
                                    //if (sap404)
                                    //{
                                    //    msg.Msg = "LKA门店第" + (i + 2) + "行SAP编号不存在！";
                                    //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //}
                                    //if (data5.Rows[i]["SAP编号"].ToString() != "")
                                    //{
                                    //    CRM_Report_KHModel model = new CRM_Report_KHModel();
                                    //    model.SAPSN = data5.Rows[i]["SAP编号"].ToString();
                                    //    model.ISACTIVE = 3;
                                    //    CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                    //    if (sapkehu.Length >= 1)
                                    //    {
                                    //        msg.Msg = "LKA门店第" + (i + 2) + "行SAP编号已经存在！";
                                    //        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //    }
                                    //}

                                    if (Regex.IsMatch(data5.Rows[i]["卖场编号"].ToString(), @"^\d+$") == false)
                                    {
                                        msg.Msg = "LKA门店第" + (i + 2) + "行卖场编号必须为全数字！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data5.Rows[i]["卖场编号"].ToString().Length != 8)
                                    {
                                        msg.Msg = "LKA门店第" + (i + 2) + "行卖场编号错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int market_type = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["门店类型"].ToString(), 4, token);
                                    if (market_type == 0)
                                    {
                                        msg.Msg = "LKA门店第" + (i + 2) + "行门店类型不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data5.Rows[i]["有效网点开发"].ToString().Trim() != "是" && data5.Rows[i]["有效网点开发"].ToString().Trim() != "否")
                                    {
                                        msg.Msg = "LKA门店第" + (i + 2) + "行有效网点开发错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                            }

                        }
                    }
                    #endregion

                    DataTable data6 = ExcelToDataTable(savePath, sheet[6], true);      //中间商
                    #region
                    if (data6 != null)
                    {
                        if (data6.Columns.Contains("CRM编号") == true || data6.Columns.Contains("SAP编号") == false)
                        {
                            msg.Msg = "请使用新增客户模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            //做数据验证
                            if (data6.Rows.Count > 0)
                            {
                                for (int i = 0; i < data6.Rows.Count; i++)
                                {
                                    if (data6.Rows[i]["客户性质"].ToString() != "非签约客户" && data6.Rows[i]["客户性质"].ToString() != "潜在客户")
                                    {
                                        msg.Msg = "中间商第" + (i + 2) + "行客户性质不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    bool sap404 = false;  //要改成判断这个SAP编号存不存在   data6.Rows[i]["SAP编号"]
                                    if (data6.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data6.Rows[i]["SAP编号"].ToString(), token) == null)
                                        sap404 = true;
                                    if (sap404)
                                    {
                                        msg.Msg = "中间商第" + (i + 2) + "行SAP编号不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data6.Rows[i]["SAP编号"].ToString() != "")
                                    {
                                        CRM_Report_KHModel model = new CRM_Report_KHModel();
                                        model.SAPSN = data6.Rows[i]["SAP编号"].ToString();
                                        model.ISACTIVE = 3;
                                        CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                        if (sapkehu.Length >= 1)
                                        {
                                            msg.Msg = "中间商第" + (i + 2) + "行SAP编号已经存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }

                                    //if (Regex.IsMatch(data6.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                    //{
                                    //    msg.Msg = "直销商第" + (i + 2) + "行上级客户编号必须为全数字！";
                                    //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //}
                                    //if (data6.Rows[i]["上级客户编号"].ToString().Length != 8)
                                    //{
                                    //    msg.Msg = "直销商第" + (i + 2) + "行上级客户编号错误！";
                                    //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //}
                                    int province = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["省份"].ToString(), 1, token);
                                    if (province == 0)
                                    {
                                        msg.Msg = "中间商第" + (i + 2) + "行省份不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int city = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["城市"].ToString(), 2, token);
                                    if (city == 0)
                                    {
                                        msg.Msg = "中间商第" + (i + 2) + "行城市不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int ZJStype = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["中间商类型"].ToString(), 43, token);
                                    if (ZJStype == 0)
                                    {
                                        msg.Msg = "中间商第" + (i + 2) + "行中间商类型不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data6.Rows[i]["有效网点开发"].ToString().Trim() != "是" && data6.Rows[i]["有效网点开发"].ToString().Trim() != "否")
                                    {
                                        msg.Msg = "中间商第" + (i + 2) + "行有效网点开发错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                            }

                        }
                    }
                    #endregion

                    DataTable data7 = ExcelToDataTable(savePath, sheet[7], true);      //OEM
                    #region
                    if (data7 != null)
                    {
                        if (data7.Columns.Contains("CRM编号") == true || data7.Columns.Contains("SAP编号") == false)
                        {
                            msg.Msg = "请使用客户新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data7.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data7.Rows.Count; i++)
                                    {
                                        if (data7.Rows[i]["客户性质"].ToString() != "签约客户" && data7.Rows[i]["客户性质"].ToString() != "潜在客户")
                                        {
                                            msg.Msg = "OEM第" + (i + 2) + "行客户性质不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        bool sap404 = false;  //要改成判断这个SAP编号存不存在   data7.Rows[i]["SAP编号"]
                                        if (data7.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data7.Rows[i]["SAP编号"].ToString(), token) == null)
                                            sap404 = true;
                                        if (sap404)
                                        {
                                            msg.Msg = "OEM第" + (i + 2) + "行SAP编号不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data7.Rows[i]["SAP编号"].ToString() != "")
                                        {
                                            CRM_Report_KHModel model = new CRM_Report_KHModel();
                                            model.SAPSN = data7.Rows[i]["SAP编号"].ToString();
                                            model.ISACTIVE = 3;
                                            CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                            if (sapkehu.Length >= 1)
                                            {
                                                msg.Msg = "OEM第" + (i + 2) + "行SAP编号已经存在！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                        if (data7.Rows[i]["上级客户编号"].ToString() != "")
                                        {
                                            if (Regex.IsMatch(data7.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                            {
                                                msg.Msg = "OEM第" + (i + 2) + "行上级客户编号必须为全数字！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (data7.Rows[i]["上级客户编号"].ToString().Length != 8)
                                            {
                                                msg.Msg = "OEM第" + (i + 2) + "行上级客户编号错误！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }


                                        int kpxz = crmModels.HG_DICT.ReadByDICNAME(data7.Rows[i]["开票性质"].ToString(), 39, token);
                                        if (kpxz == 0)
                                        {
                                            msg.Msg = "OEM第" + (i + 2) + "行开票性质不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }

                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg.Msg = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }



                        }
                    }
                    #endregion




                    //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                    #region
                    //经销商
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        #region
                        CRM_KH_KH model = new CRM_KH_KH();
                        switch (data1.Rows[i]["客户性质"].ToString())
                        {
                            case "签约客户":
                                model.IsOfficial = 20;
                                break;
                            case "非签约客户":
                                model.IsOfficial = 30;
                                break;
                            case "潜在客户":
                                model.IsOfficial = 10;
                                break;
                            default:
                                model.IsOfficial = 0;
                                break;
                        }
                        model.SAPSN = data1.Rows[i]["SAP编号"].ToString();
                        switch (data1.Rows[i]["客户类型"].ToString())
                        {
                            case "经销商":
                                model.KHLX = 1;
                                break;
                            case "电商":
                                model.KHLX = 2;
                                break;
                            case "B2B":
                                model.KHLX = 4;
                                break;
                            default:
                                model.KHLX = 0;
                                break;
                        }
                        if (string.IsNullOrEmpty(data1.Rows[i]["上级客户编号"].ToString()) == false)
                            model.PKHID = Convert.ToInt32(data1.Rows[i]["上级客户编号"].ToString());
                        else
                            model.PKHID = 0;
                        model.MC = data1.Rows[i]["客户名称"].ToString().Trim();
                        model.JC = data1.Rows[i]["客户名称"].ToString().Trim();
                        model.KPXZ = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["开票性质"].ToString(), 39, token);
                        model.NSRSBH = data1.Rows[i]["纳税人识别号"].ToString();
                        model.KPDZ = data1.Rows[i]["开票地址"].ToString();
                        model.KPDH = data1.Rows[i]["开票电话"].ToString();
                        model.YHZH = data1.Rows[i]["银行帐号"].ToString();
                        model.YHMC = data1.Rows[i]["银行名称"].ToString();
                        model.GSLXR = data1.Rows[i]["公司联系人"].ToString();
                        model.GSLXDH = data1.Rows[i]["公司联系电话"].ToString();
                        model.FR = data1.Rows[i]["公司法人"].ToString();
                        model.GSFRGX = data1.Rows[i]["公司联系人与法人关系"].ToString();
                        model.KDJSDZ = data1.Rows[i]["快递寄送地址"].ToString();
                        model.KDLXR = data1.Rows[i]["快递联系人"].ToString();
                        model.KDLXDH = data1.Rows[i]["快递联系电话"].ToString();
                        model.KHSOURCE = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["经销商来源"].ToString(), 44, token);
                        if (model.KHLX == 1)
                            model.KHLX2 = data1.Rows[i]["是否直销商"].ToString() == "是" ? crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["是否直销商"].ToString(), 43, token) : 0;
                        else if (model.KHLX == 4)
                        {
                            model.KHLX2 = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["大客户类型"].ToString(), 39, token);
                            model.MCLC = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["行业所属分类"].ToString(), 60, token);
                        }

                        model.HTXSRW = data1.Rows[i]["合同销售任务（万）"].ToString();
                        model.HTJXXSRW = data1.Rows[i]["合同碱性销售任务（万）"].ToString();
                        model.FIRSTAMOUNT = data1.Rows[i]["首批订单A类产品订货金额(万)"].ToString();
                        model.JOINACTIVITY = data1.Rows[i]["是否参加A类产品满送活动(万)"].ToString() == "是" ? 1 : 0;
                        model.XSSJSM = data1.Rows[i]["销售归属"].ToString();
                        model.FLSJSM = data1.Rows[i]["返利归属"].ToString();
                        switch (data1.Rows[i]["是否出厂价"].ToString())
                        {
                            case "是":
                                model.SFCCJ = true;
                                break;
                            case "否":
                                model.SFCCJ = false;
                                break;
                            default:
                                model.SFCCJ = true;
                                break;
                        }
                        model.SFCCJSM = data1.Rows[i]["价格说明"].ToString();
                        model.KHSHDZ = data1.Rows[i]["客户收货地址"].ToString();
                        model.KHSHLXR = data1.Rows[i]["收货联系人"].ToString();
                        model.KHSHLXDH = data1.Rows[i]["收货联系电话"].ToString();
                        model.TSQKSM = data1.Rows[i]["特殊情况说明"].ToString();
                        switch (data1.Rows[i]["是否对现有区域经销商影响"].ToString())
                        {
                            case "是":
                                model.JXSYX = true;
                                break;
                            case "否":
                                model.JXSYX = false;
                                break;
                            default:
                                model.JXSYX = false;
                                break;
                        }
                        model.YXSM = data1.Rows[i]["影响说明"].ToString();
                        model.ISACTIVE = 3;
                        model.FID = Convert.ToInt32(Session["STAFFID"]);
                        model.SAPKHLX = "1";
                        int id = crmModels.KH_KH.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增经销商、电商、B2B的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
                    }
                    //直营卖场系统
                    for (int i = 0; i < data2.Rows.Count; i++)
                    {
                        #region
                        CRM_KH_KH model = new CRM_KH_KH();
                        switch (data2.Rows[i]["客户性质"].ToString())
                        {
                            case "签约客户":
                                model.IsOfficial = 20;
                                break;
                            case "非签约客户":
                                model.IsOfficial = 30;
                                break;
                            case "潜在客户":
                                model.IsOfficial = 10;
                                break;
                            default:
                                model.IsOfficial = 0;
                                break;
                        }
                        model.SAPSN = data2.Rows[i]["SAP编号"].ToString();
                        model.KHLX = 3;
                        model.MCSX = 1;
                        model.MC = data2.Rows[i]["客户名称"].ToString().Trim();
                        if (string.IsNullOrEmpty(data2.Rows[i]["上级客户编号"].ToString()) == false)
                            model.PKHID = Convert.ToInt32(data2.Rows[i]["上级客户编号"].ToString());
                        else
                            model.PKHID = 0;
                        model.SF = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["省份"].ToString(), 1, token);
                        model.CS = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["城市"].ToString(), 2, token);
                        model.COUNTY = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["县级市"].ToString(), 34, token);
                        model.FKTJ = data2.Rows[i]["付款条件"].ToString();
                        model.GSLXR = data2.Rows[i]["公司联系人"].ToString();
                        model.GSLXDH = data2.Rows[i]["公司联系电话"].ToString();
                        model.KPDZ = data2.Rows[i]["开票地址"].ToString();
                        model.KPDH = data2.Rows[i]["开票电话"].ToString();
                        model.KPXZ = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["开票性质"].ToString(), 39, token);
                        model.YHZH = data2.Rows[i]["银行帐号"].ToString();
                        model.YHMC = data2.Rows[i]["银行名称"].ToString();
                        model.NSRSBH = data2.Rows[i]["纳税人识别号"].ToString();
                        model.FR = data2.Rows[i]["公司法人"].ToString();
                        model.KDJSDZ = data2.Rows[i]["发票寄送地址"].ToString();
                        model.KDLXR = data2.Rows[i]["发票寄送人"].ToString();
                        model.KDLXDH = data2.Rows[i]["发票寄送电话"].ToString();
                        model.ISACTIVE = 3;
                        model.FID = Convert.ToInt32(Session["STAFFID"]);
                        model.SAPKHLX = "1";
                        int id = crmModels.KH_KH.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增直营卖场系统的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
                    }
                    //直营卖场门店
                    for (int i = 0; i < data2s.Rows.Count; i++)
                    {
                        #region
                        CRM_KH_KH model = new CRM_KH_KH();
                        switch (data2s.Rows[i]["客户性质"].ToString())
                        {
                            case "签约客户":
                                model.IsOfficial = 20;
                                break;
                            case "非签约客户":
                                model.IsOfficial = 30;
                                break;
                            case "潜在客户":
                                model.IsOfficial = 10;
                                break;
                            default:
                                model.IsOfficial = 0;
                                break;
                        }
                        model.SAPSN = data2s.Rows[i]["SAP编号"].ToString();
                        model.KHLX = 3;
                        model.MCSX = 2;
                        model.MC = data2s.Rows[i]["客户名称"].ToString().Trim();
                        if (string.IsNullOrEmpty(data2s.Rows[i]["上级客户编号"].ToString()) == false)
                            model.PKHID = Convert.ToInt32(data2s.Rows[i]["上级客户编号"].ToString());
                        else
                            model.PKHID = 0;
                        model.SF = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["省份"].ToString(), 1, token);
                        model.CS = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["城市"].ToString(), 2, token);
                        model.COUNTY = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["县级市"].ToString(), 34, token);
                        model.MDDZ = data2s.Rows[i]["客户收货地址"].ToString();
                        model.GSLXR = data2s.Rows[i]["客户收货联系人"].ToString();
                        model.GSLXDH = data2s.Rows[i]["客户收货联系电话"].ToString();
                        model.ISACTIVE = 3;
                        model.FID = Convert.ToInt32(Session["STAFFID"]);
                        model.SAPKHLX = "1";
                        model.BEIZ = data2s.Rows[i]["门店编号"].ToString();
                        int id = crmModels.KH_KH.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增直营卖场门店的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
                    }

                    //终端网点
                    for (int i = 0; i < data3.Rows.Count; i++)
                    {
                        #region
                        CRM_KH_KH model = new CRM_KH_KH();
                        switch (data3.Rows[i]["客户性质"].ToString())
                        {
                            case "签约客户":
                                model.IsOfficial = 20;
                                break;
                            case "非签约客户":
                                model.IsOfficial = 30;
                                break;
                            case "潜在客户":
                                model.IsOfficial = 10;
                                break;
                            default:
                                model.IsOfficial = 0;
                                break;
                        }
                        model.SAPSN = data3.Rows[i]["SAP编号"].ToString();
                        model.KHLX = 5;
                        model.SF = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["省份"].ToString(), 1, token);
                        model.CS = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["城市"].ToString(), 2, token);
                        if (string.IsNullOrEmpty(data3.Rows[i]["上级客户编号"].ToString()) == false)
                            model.PKHID = Convert.ToInt32(data3.Rows[i]["上级客户编号"].ToString());
                        else
                            model.PKHID = 0;
                        model.MC = data3.Rows[i]["客户名称"].ToString().Trim();
                        model.MDDZ = data3.Rows[i]["地址"].ToString();
                        model.GSLXR = data3.Rows[i]["联系人"].ToString();
                        model.GSLXDH = data3.Rows[i]["联系电话"].ToString();
                        model.WDLX = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["网点类型"].ToString(), 3, token);
                        switch (data3.Rows[i]["是否标准网点"].ToString())
                        {
                            case "是":
                                model.SFBZWD = true;
                                break;
                            case "否":
                                model.SFBZWD = false;
                                break;
                            default:
                                model.SFBZWD = true;
                                break;
                        }
                        model.KHZZSJ = Convert.ToDateTime(data3.Rows[i]["客户开发时间"]).ToString("yyyy-MM-dd");
                        model.BEIZ = data3.Rows[i]["备注"].ToString();
                        model.ISACTIVE = 3;
                        model.FID = Convert.ToInt32(Session["STAFFID"]);
                        model.SAPKHLX = "1";
                        int id = crmModels.KH_KH.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增终端网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        //客户新建完后开始建资质数据
                        if (data3.Rows[i]["有效网点开发"].ToString() == "是")
                        {
                            CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                            zzmodel.KHID = id;
                            zzmodel.ZZMCID = 1080;
                            zzmodel.INFO1 = data3.Rows[i]["有效网点销量"].ToString();
                            zzmodel.INFO2 = data3.Rows[i]["有效网点说明"].ToString();
                            zzmodel.INFO3 = "";
                            zzmodel.ISACTIVE = 3;
                            zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                            int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                            if (zzid <= 0)
                            {
                                msg.Msg = "新增终端网点有效网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                        if (data3.Rows[i]["是否电子锁"].ToString() == "是")
                        {
                            CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                            zzmodel.KHID = id;
                            zzmodel.ZZMCID = 1058;
                            zzmodel.INFO1 = data3.Rows[i]["现有品牌、数量"].ToString();
                            zzmodel.INFO2 = "";
                            zzmodel.INFO3 = "";
                            zzmodel.ISACTIVE = 3;
                            zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                            int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                            if (zzid <= 0)
                            {
                                msg.Msg = "新增终端网点电子锁的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }

                        }


                        #endregion
                    }
                    //LKA
                    for (int i = 0; i < data4.Rows.Count; i++)
                    {
                        #region
                        CRM_KH_KH model = new CRM_KH_KH();
                        switch (data4.Rows[i]["客户性质"].ToString())
                        {
                            case "签约客户":
                                model.IsOfficial = 20;
                                break;
                            case "非签约客户":
                                model.IsOfficial = 30;
                                break;
                            case "潜在客户":
                                model.IsOfficial = 10;
                                break;
                            default:
                                model.IsOfficial = 0;
                                break;
                        }
                        model.KHLX = 7;
                        model.MCSX = 1;
                        model.SAPSN = "";   //data4.Rows[i]["SAP编号"].ToString();
                        if (string.IsNullOrEmpty(data4.Rows[i]["经销商CRM编号"].ToString()) == false)
                            model.PKHID = Convert.ToInt32(data4.Rows[i]["经销商CRM编号"].ToString());
                        else
                            model.PKHID = 0;
                        model.MC = data4.Rows[i]["卖场名称"].ToString().Trim();
                        model.MDJCSL = data4.Rows[i]["门店进场数量"].ToString();
                        model.MDDZ = data4.Rows[i]["卖场总部地址"].ToString();
                        model.KHZZSJ = Convert.ToDateTime(data4.Rows[i]["客户开发时间"]).ToString("yyyy-MM-dd");
                        model.FIRSTAMOUNT = Convert.ToDateTime(data4.Rows[i]["首次进场时间"]).ToString("yyyy-MM-dd");
                        model.PSQK = data4.Rows[i]["配送情况"].ToString();
                        model.FSFW = data4.Rows[i]["辐射范围"].ToString();
                        model.MANAGEWAY = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["经营方式"].ToString(), 57, token);
                        model.PAYWAY = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["结款方式"].ToString(), 58, token);
                        model.GSLXR = data4.Rows[i]["卖场接洽人"].ToString();
                        model.GSLXRZW = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["接洽人职务"].ToString(), 59, token);
                        model.GSLXDH = data4.Rows[i]["接洽人电话"].ToString();
                        model.ISNEW = data4.Rows[i]["是否新进卖场"].ToString() == "是" ? 1 : 0;
                        model.BELONGKA = data4.Rows[i]["KA管理的LKA"].ToString() == "是" ? 1 : 0;
                        model.WEBSITE = data4.Rows[i]["卖场网址"].ToString();
                        model.ACCOUNT = data4.Rows[i]["帐号、密码"].ToString();
                        model.SUPPORTOTHER = data4.Rows[i]["经销商除供双鹿外是否供其他产品"].ToString() == "是" ? 1 : 0;
                        model.PACT = data4.Rows[i]["是否直接与公司签订合同"].ToString() == "是" ? 1 : 0;

                        model.BEIZ = data4.Rows[i]["备注"].ToString();
                        model.ISACTIVE = 3;
                        model.FID = Convert.ToInt32(Session["STAFFID"]);
                        model.SAPKHLX = "1";
                        int id = crmModels.KH_KH.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增LKA的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        //客户新建完后开始建资质数据
                        if (data4.Rows[i]["有效网点开发"].ToString() == "是")
                        {
                            CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                            zzmodel.KHID = id;
                            zzmodel.ZZMCID = 1080;
                            zzmodel.INFO1 = data4.Rows[i]["有效网点销量"].ToString();
                            zzmodel.INFO2 = data4.Rows[i]["有效网点说明"].ToString();
                            zzmodel.INFO3 = "";
                            zzmodel.ISACTIVE = 3;
                            zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                            int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                            if (zzid <= 0)
                            {
                                msg.Msg = "新增LKA有效网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }

                        #endregion
                    }
                    //LKA门店
                    for (int i = 0; i < data5.Rows.Count; i++)
                    {
                        #region
                        CRM_KH_KH model = new CRM_KH_KH();
                        switch (data5.Rows[i]["客户性质"].ToString())
                        {
                            case "签约客户":
                                model.IsOfficial = 20;
                                break;
                            case "非签约客户":
                                model.IsOfficial = 30;
                                break;
                            case "潜在客户":
                                model.IsOfficial = 10;
                                break;
                            default:
                                model.IsOfficial = 0;
                                break;
                        }
                        model.KHLX = 7;
                        model.MCSX = 2;
                        model.SAPSN = "";   //data5.Rows[i]["SAP编号"].ToString();
                        if (string.IsNullOrEmpty(data5.Rows[i]["卖场编号"].ToString()) == false)
                            model.PKHID = Convert.ToInt32(data5.Rows[i]["卖场编号"].ToString());
                        else
                            model.PKHID = 0;
                        model.MC = data5.Rows[i]["门店名称"].ToString().Trim();
                        model.MDDZ = data5.Rows[i]["门店地址"].ToString();
                        model.MCLC = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["门店类型"].ToString(), 4, token);
                        model.JCDPSL = data5.Rows[i]["进场单品数量"].ToString();
                        model.XSSJSM = data5.Rows[i]["双鹿销售主要品种"].ToString();
                        model.KHZZSJ = Convert.ToDateTime(data5.Rows[i]["客户开发时间"]).ToString("yyyy-MM-dd");
                        model.BEIZ = data5.Rows[i]["备注"].ToString();
                        model.ISACTIVE = 3;
                        model.FID = Convert.ToInt32(Session["STAFFID"]);
                        model.SAPKHLX = "1";
                        int id = crmModels.KH_KH.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增LKA门店的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        //客户新建完后开始建资质数据
                        if (data5.Rows[i]["有效网点开发"].ToString() == "是")
                        {
                            CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                            zzmodel.KHID = id;
                            zzmodel.ZZMCID = 1080;
                            zzmodel.INFO1 = data5.Rows[i]["有效网点销量"].ToString();
                            zzmodel.INFO2 = data5.Rows[i]["有效网点说明"].ToString();
                            zzmodel.INFO3 = "";
                            zzmodel.ISACTIVE = 3;
                            zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                            int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                            if (zzid <= 0)
                            {
                                msg.Msg = "新增LKA门店有效网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }

                        #endregion
                    }
                    //中间商
                    for (int i = 0; i < data6.Rows.Count; i++)
                    {
                        #region
                        CRM_KH_KH model = new CRM_KH_KH();
                        switch (data6.Rows[i]["客户性质"].ToString())
                        {
                            case "签约客户":
                                model.IsOfficial = 20;
                                break;
                            case "非签约客户":
                                model.IsOfficial = 30;
                                break;
                            case "潜在客户":
                                model.IsOfficial = 10;
                                break;
                            default:
                                model.IsOfficial = 0;
                                break;
                        }
                        model.KHLX = 9;
                        model.SAPSN = data6.Rows[i]["SAP编号"].ToString();
                        if (string.IsNullOrEmpty(data6.Rows[i]["上级客户编号"].ToString()) == false)
                            model.PKHID = Convert.ToInt32(data6.Rows[i]["上级客户编号"].ToString());
                        else
                            model.PKHID = 0;
                        model.SF = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["省份"].ToString(), 1, token);
                        model.CS = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["城市"].ToString(), 2, token);
                        model.MC = data6.Rows[i]["客户名称"].ToString().Trim();
                        model.MDDZ = data6.Rows[i]["地址"].ToString();
                        model.GSLXR = data6.Rows[i]["联系人"].ToString();
                        model.GSLXDH = data6.Rows[i]["联系电话"].ToString();
                        model.KHLX2 = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["中间商类型"].ToString(), 43, token);
                        model.KHZZSJ = Convert.ToDateTime(data6.Rows[i]["客户开发时间"]).ToString("yyyy-MM-dd");
                        model.BEIZ = data6.Rows[i]["备注"].ToString();
                        model.ISACTIVE = 3;
                        model.FID = Convert.ToInt32(Session["STAFFID"]);
                        model.SAPKHLX = "1";
                        int id = crmModels.KH_KH.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增中间商的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        //客户新建完后开始建资质数据
                        if (data6.Rows[i]["有效网点开发"].ToString() == "是")
                        {
                            CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                            zzmodel.KHID = id;
                            zzmodel.ZZMCID = 1080;
                            zzmodel.INFO1 = data6.Rows[i]["有效网点销量"].ToString();
                            zzmodel.INFO2 = data6.Rows[i]["有效网点说明"].ToString();
                            zzmodel.INFO3 = "";
                            zzmodel.ISACTIVE = 3;
                            zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                            int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                            if (zzid <= 0)
                            {
                                msg.Msg = "新增中间商有效网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }

                        #endregion
                    }
                    //OEM
                    for (int i = 0; i < data7.Rows.Count; i++)
                    {
                        #region
                        CRM_KH_KH model = new CRM_KH_KH();
                        switch (data7.Rows[i]["客户性质"].ToString())
                        {
                            case "签约客户":
                                model.IsOfficial = 20;
                                break;
                            case "非签约客户":
                                model.IsOfficial = 30;
                                break;
                            case "潜在客户":
                                model.IsOfficial = 10;
                                break;
                            default:
                                model.IsOfficial = 0;
                                break;
                        }
                        model.SAPSN = data7.Rows[i]["SAP编号"].ToString();
                        model.KHLX = 1105;
                        if (string.IsNullOrEmpty(data7.Rows[i]["上级客户编号"].ToString()) == false)
                            model.PKHID = Convert.ToInt32(data7.Rows[i]["上级客户编号"].ToString());
                        else
                            model.PKHID = 0;
                        model.MC = data7.Rows[i]["客户名称"].ToString().Trim();
                        model.KPXZ = crmModels.HG_DICT.ReadByDICNAME(data7.Rows[i]["开票性质"].ToString(), 39, token);
                        model.NSRSBH = data7.Rows[i]["纳税人识别号"].ToString();
                        model.KPDZ = data7.Rows[i]["开票地址"].ToString();
                        model.KPDH = data7.Rows[i]["开票电话"].ToString();
                        model.YHZH = data7.Rows[i]["银行帐号"].ToString();
                        model.YHMC = data7.Rows[i]["银行名称"].ToString();
                        model.GSLXR = data7.Rows[i]["公司联系人"].ToString();
                        model.GSLXDH = data7.Rows[i]["公司联系电话"].ToString();
                        model.FR = data7.Rows[i]["公司法人"].ToString();
                        model.GSFRGX = data7.Rows[i]["公司联系人与法人关系"].ToString();
                        model.KDJSDZ = data7.Rows[i]["快递寄送地址"].ToString();
                        model.KDLXR = data7.Rows[i]["快递联系人"].ToString();
                        model.KDLXDH = data7.Rows[i]["快递联系电话"].ToString();
                        model.ISACTIVE = 3;
                        model.FID = Convert.ToInt32(Session["STAFFID"]);
                        model.SAPKHLX = "1";
                        int id = crmModels.KH_KH.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增OEM的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
                    }
                    #endregion
                    msg.Msg = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.Msg = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.Msg = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }



        }


        /// <summary>
        /// 批量修改客户主数据
        /// </summary>
        /// <returns></returns>
        public string Data_DaoRu_KeHu_Update()
        {
            token = appClass.CRM_Gettoken();

            var file = Request.Files[0];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;

            string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
            if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
            {
                Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
            }
            file.SaveAs(savePath);
            FileInfo fi = new FileInfo(savePath);

            DaoRuMsg msg = new DaoRuMsg();
            if (fi.Exists == true)
            {
                string[] sheet = { "经销商、电商、B2B", "直营卖场系统", "直营卖场门店", "终端网点", "LKA", "LKA门店", "中间商", "OEM" };


                DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //经销商、电商、B2B
                #region
                if (data1 != null)
                {
                    if (data1.Columns.Contains("CRM编号") == false || data1.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        try
                        {
                            //做数据验证
                            if (data1.Rows.Count > 0)
                            {
                                for (int i = 0; i < data1.Rows.Count; i++)
                                {
                                    if (data1.Rows[i]["客户性质"].ToString() != "签约客户" && data1.Rows[i]["客户性质"].ToString() != "潜在客户")
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行客户性质不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    bool sap404 = false;  //要改成判断这个SAP编号存不存在   data1.Rows[i]["SAP编号"]
                                    if (data1.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data1.Rows[i]["SAP编号"].ToString(), token) == null)
                                        sap404 = true;
                                    if (data1.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data1.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data1.Rows[i]["CRM编号"].ToString().Length != 8)
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + ((i + 2)) + "行CRM编号错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (sap404)
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行SAP编号不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data1.Rows[i]["SAP编号"].ToString() != "")
                                    {
                                        CRM_Report_KHModel model = new CRM_Report_KHModel();
                                        model.SAPSN = data1.Rows[i]["SAP编号"].ToString();
                                        model.ISACTIVE = 3;
                                        CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                        if (sapkehu.Length >= 1)
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行SAP编号已经存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                    if (data1.Rows[i]["上级客户编号"].ToString() != "")
                                    {
                                        if (Regex.IsMatch(data1.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行上级客户编号必须为全数字！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["上级客户编号"].ToString().Length != 8)
                                        {
                                            msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行上级客户编号错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }

                                    //if (data1.Rows[i]["客户类型"].ToString() == "")
                                    //{
                                    //    msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行客户类型不能为空！";
                                    //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    //}
                                    if (data1.Rows[i]["客户类型"].ToString() != "经销商" && data1.Rows[i]["客户类型"].ToString() != "电商" && data1.Rows[i]["客户类型"].ToString() != "B2B")
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行客户类型错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int kpxz = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["开票性质"].ToString(), 39, token);
                                    if (kpxz == 0)
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行开票性质错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    int khsource = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["经销商来源"].ToString(), 44, token);
                                    if (khsource == 0 && data1.Rows[i]["经销商来源"].ToString() != "")
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行经销商来源不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data1.Rows[i]["是否直销商"].ToString() != "是" && data1.Rows[i]["是否直销商"].ToString() != "否")
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行是否直销商错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data1.Rows[i]["是否出厂价"].ToString() != "是" && data1.Rows[i]["是否出厂价"].ToString() != "否")
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行是否出厂价错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data1.Rows[i]["是否对现有区域经销商影响"].ToString() != "是" && data1.Rows[i]["是否对现有区域经销商影响"].ToString() != "否")
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行是否对现有区域经销商影响错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                for (int i = 0; i < data1.Rows.Count; i++)
                                {
                                    CRM_KH_KH kh_model = new CRM_KH_KH();
                                    kh_model = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["CRM编号"].ToString(), token);
                                    if (kh_model.KHID == 0)
                                    {
                                        msg.Msg = "经销商、电商、B2B第" + (i + 2) + "行CRM编号不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                            }
                        }
                        catch //(Exception e)
                        {

                        }


                    }
                }
                #endregion

                DataTable data2 = ExcelToDataTable(savePath, sheet[1], true);      //直营卖场系统
                #region
                if (data2 != null)
                {
                    if (data2.Columns.Contains("CRM编号") == false || data2.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data2.Rows.Count > 0)
                        {
                            for (int i = 0; i < data2.Rows.Count; i++)
                            {
                                if (data2.Rows[i]["客户性质"].ToString() != "签约客户" && data2.Rows[i]["客户性质"].ToString() != "潜在客户")
                                {
                                    msg.Msg = "直营卖场系统第" + (i + 2) + "行客户性质不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                bool sap404 = false;  //要改成判断这个SAP编号存不存在   data2.Rows[i]["SAP编号"]
                                if (data2.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data2.Rows[i]["SAP编号"].ToString(), token) == null)
                                    sap404 = true;
                                if (data2.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data2.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data2.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "直营卖场系统第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (sap404)
                                {
                                    msg.Msg = "直营卖场系统第" + (i + 2) + "行SAP编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data2.Rows[i]["SAP编号"].ToString() != "")
                                {
                                    CRM_Report_KHModel model = new CRM_Report_KHModel();
                                    model.SAPSN = data2.Rows[i]["SAP编号"].ToString();
                                    model.ISACTIVE = 3;
                                    CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                    if (sapkehu.Length >= 1)
                                    {
                                        msg.Msg = "直营卖场系统第" + (i + 2) + "行SAP编号已经存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data2.Rows[i]["省份"].ToString() != "")
                                {
                                    int province = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["省份"].ToString(), 1, token);
                                    if (province == 0)
                                    {
                                        msg.Msg = "直营卖场系统第" + (i + 2) + "行省份不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data2.Rows[i]["城市"].ToString() != "")
                                {
                                    int city = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["城市"].ToString(), 2, token);
                                    if (city == 0)
                                    {
                                        msg.Msg = "直营卖场系统第" + (i + 2) + "行城市不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                //if (Regex.IsMatch(data2.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                //{
                                //    msg.Msg = "直营卖场系统第" + (i + 2) + "行上级客户编号必须为全数字！";
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                //}
                                //if (data2.Rows[i]["上级客户编号"].ToString().Length != 8)
                                //{
                                //    msg.Msg = "直营卖场系统第" + (i + 2) + "行上级客户编号错误！";
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                //}
                                int kpxz = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["开票性质"].ToString(), 39, token);
                                if (kpxz == 0)
                                {
                                    msg.Msg = "直营卖场系统第" + (i + 2) + "行开票性质错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }


                            }
                            for (int i = 0; i < data2.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data2.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直营卖场系统第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data2s = ExcelToDataTable(savePath, sheet[2], true);      //直营卖场门店
                #region
                if (data2s != null)
                {
                    if (data2s.Columns.Contains("CRM编号") == false || data2s.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data2s.Rows.Count > 0)
                        {
                            for (int i = 0; i < data2s.Rows.Count; i++)
                            {
                                if (data2s.Rows[i]["客户性质"].ToString() != "签约客户" && data2s.Rows[i]["客户性质"].ToString() != "潜在客户")
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行客户性质不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data2s.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data2s.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data2s.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                bool sap404 = false;  //要改成判断这个SAP编号存不存在   data2s.Rows[i]["SAP编号"]
                                if (data2s.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data2s.Rows[i]["SAP编号"].ToString(), token) == null)
                                    sap404 = true;
                                if (sap404)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行SAP编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data2s.Rows[i]["SAP编号"].ToString() != "")
                                {
                                    CRM_Report_KHModel model = new CRM_Report_KHModel();
                                    model.SAPSN = data2s.Rows[i]["SAP编号"].ToString();
                                    model.ISACTIVE = 3;
                                    CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                    if (sapkehu.Length >= 1)
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行SAP编号已经存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (Regex.IsMatch(data2s.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行上级客户编号必须为全数字！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data2s.Rows[i]["上级客户编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行上级客户编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data2s.Rows[i]["省份"].ToString() != "")
                                {
                                    int province = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["省份"].ToString(), 1, token);
                                    if (province == 0)
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行省份不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data2s.Rows[i]["城市"].ToString() != "")
                                {
                                    int city = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["城市"].ToString(), 2, token);
                                    if (city == 0)
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行城市不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data2s.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data2s.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data3 = ExcelToDataTable(savePath, sheet[3], true);      //终端网点
                #region
                if (data3 != null)
                {
                    if (data3.Columns.Contains("CRM编号") == false || data3.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data3.Rows.Count > 0)
                        {
                            for (int i = 0; i < data3.Rows.Count; i++)
                            {
                                if (data3.Rows[i]["客户性质"].ToString() != "非签约客户" && data3.Rows[i]["客户性质"].ToString() != "潜在客户")
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行客户性质不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                bool sap404 = false;  //要改成判断这个SAP编号存不存在   data3.Rows[i]["SAP编号"]
                                if (data3.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data3.Rows[i]["SAP编号"].ToString(), token) == null)
                                    sap404 = true;
                                if (data3.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data3.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data3.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (sap404)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行SAP编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data3.Rows[i]["SAP编号"].ToString() != "")
                                {
                                    CRM_Report_KHModel model = new CRM_Report_KHModel();
                                    model.SAPSN = data3.Rows[i]["SAP编号"].ToString();
                                    model.ISACTIVE = 3;
                                    CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                    if (sapkehu.Length >= 1)
                                    {
                                        msg.Msg = "终端网点第" + (i + 2) + "行SAP编号已经存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                //if (data3.Rows[i]["客户类型"].ToString() != "网点终端" && data3.Rows[i]["客户类型"].ToString() != "批发")
                                //{
                                //    msg.Msg = "终端网点第" + (i + 2) + "行客户类型错误！";
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                //}
                                if (Regex.IsMatch(data3.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行上级客户编号必须为全数字！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data3.Rows[i]["上级客户编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行上级客户编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int province = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["省份"].ToString(), 1, token);
                                if (province == 0)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行省份不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int city = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["城市"].ToString(), 2, token);
                                if (city == 0)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行城市不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int store_type = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["网点类型"].ToString(), 3, token);
                                if (store_type == 0)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行网点类型不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data3.Rows[i]["是否标准网点"].ToString() != "是" && data3.Rows[i]["是否标准网点"].ToString() != "否")
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行是否标准网点错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data3.Rows[i]["有效网点开发"].ToString().Trim() != "是" && data3.Rows[i]["有效网点开发"].ToString().Trim() != "否")
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行有效网点开发错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data3.Rows[i]["是否电子锁"].ToString().Trim() != "是" && data3.Rows[i]["是否电子锁"].ToString().Trim() != "否")
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行是否电子锁错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data3.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data4 = ExcelToDataTable(savePath, sheet[4], true);      //LKA
                #region
                if (data4 != null)
                {
                    if (data4.Columns.Contains("CRM编号") == false || data4.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data4.Rows.Count > 0)
                        {
                            for (int i = 0; i < data4.Rows.Count; i++)
                            {
                                if (data4.Rows[i]["客户性质"].ToString() != "非签约客户" && data4.Rows[i]["客户性质"].ToString() != "潜在客户")
                                {
                                    msg.Msg = "LKA第" + (i + 2) + "行客户性质不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                bool sap404 = false;  //要改成判断这个SAP编号存不存在   data4.Rows[i]["SAP编号"]
                                if (data4.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data4.Rows[i]["SAP编号"].ToString(), token) == null)
                                    sap404 = true;
                                if (data4.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data4.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data4.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "LKA第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (sap404)
                                {
                                    msg.Msg = "LKA第" + (i + 2) + "行SAP编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data4.Rows[i]["SAP编号"].ToString() != "")
                                {
                                    CRM_Report_KHModel model = new CRM_Report_KHModel();
                                    model.SAPSN = data4.Rows[i]["SAP编号"].ToString();
                                    model.ISACTIVE = 3;
                                    CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                    if (sapkehu.Length >= 1)
                                    {
                                        msg.Msg = "LKA第" + (i + 2) + "行SAP编号已经存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (Regex.IsMatch(data4.Rows[i]["经销商编号"].ToString(), @"^\d+$") == false)
                                {
                                    msg.Msg = "LKA第" + (i + 2) + "行经销商编号必须为全数字！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data4.Rows[i]["经销商编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "LKA第" + (i + 2) + "行经销商编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                //int market_type = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["卖场类型"].ToString(), 4, token);
                                //if (market_type == 0)
                                //{
                                //    msg.Msg = "LKA第" + (i + 2) + "行卖场类型不存在！";
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                //}
                                if (data4.Rows[i]["有效网点开发"].ToString().Trim() != "是" && data4.Rows[i]["有效网点开发"].ToString().Trim() != "否")
                                {
                                    msg.Msg = "LKA第" + (i + 2) + "行有效网点开发错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data4.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data4.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data5 = ExcelToDataTable(savePath, sheet[5], true);      //LKA门店
                #region
                if (data5 != null)
                {
                    if (data5.Columns.Contains("CRM编号") == false || data5.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data5.Rows.Count > 0)
                        {
                            for (int i = 0; i < data5.Rows.Count; i++)
                            {
                                if (data5.Rows[i]["客户性质"].ToString() != "非签约客户" && data5.Rows[i]["客户性质"].ToString() != "潜在客户")
                                {
                                    msg.Msg = "LKA门店第" + (i + 2) + "行客户性质不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                bool sap404 = false;  //要改成判断这个SAP编号存不存在   data5.Rows[i]["SAP编号"]
                                if (data5.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data5.Rows[i]["SAP编号"].ToString(), token) == null)
                                    sap404 = true;
                                if (data5.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data5.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data5.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "LKA门店第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (sap404)
                                {
                                    msg.Msg = "LKA门店第" + (i + 2) + "行SAP编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data5.Rows[i]["SAP编号"].ToString() != "")
                                {
                                    CRM_Report_KHModel model = new CRM_Report_KHModel();
                                    model.SAPSN = data5.Rows[i]["SAP编号"].ToString();
                                    model.ISACTIVE = 3;
                                    CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                    if (sapkehu.Length >= 1)
                                    {
                                        msg.Msg = "LKA门店第" + (i + 2) + "行SAP编号已经存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (Regex.IsMatch(data5.Rows[i]["卖场编号"].ToString(), @"^\d+$") == false)
                                {
                                    msg.Msg = "LKA门店第" + (i + 2) + "行卖场编号必须为全数字！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data5.Rows[i]["卖场编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "LKA门店第" + (i + 2) + "行卖场编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int market_type = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["门店类型"].ToString(), 4, token);
                                if (market_type == 0)
                                {
                                    msg.Msg = "LKA门店第" + (i + 2) + "行门店类型不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data5.Rows[i]["有效网点开发"].ToString().Trim() != "是" && data5.Rows[i]["有效网点开发"].ToString().Trim() != "否")
                                {
                                    msg.Msg = "LKA门店第" + (i + 2) + "行有效网点开发错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data5.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data5.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data6 = ExcelToDataTable(savePath, sheet[6], true);      //中间商
                #region
                if (data6 != null)
                {
                    if (data6.Columns.Contains("CRM编号") == false || data6.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用修改客户模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data6.Rows.Count > 0)
                        {
                            for (int i = 0; i < data6.Rows.Count; i++)
                            {
                                if (data6.Rows[i]["客户性质"].ToString() != "非签约客户" && data6.Rows[i]["客户性质"].ToString() != "潜在客户")
                                {
                                    msg.Msg = "中间商第" + (i + 2) + "行客户性质不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data6.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data6.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data6.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "直营卖场第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                bool sap404 = false;  //要改成判断这个SAP编号存不存在   data6.Rows[i]["SAP编号"]
                                if (data6.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data6.Rows[i]["SAP编号"].ToString(), token) == null)
                                    sap404 = true;
                                if (sap404)
                                {
                                    msg.Msg = "直销商第" + (i + 2) + "行SAP编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data6.Rows[i]["SAP编号"].ToString() != "")
                                {
                                    CRM_Report_KHModel model = new CRM_Report_KHModel();
                                    model.SAPSN = data6.Rows[i]["SAP编号"].ToString();
                                    model.ISACTIVE = 3;
                                    CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                    if (sapkehu.Length >= 1)
                                    {
                                        msg.Msg = "直销商第" + (i + 2) + "行SAP编号已经存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                //if (Regex.IsMatch(data6.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                //{
                                //    msg.Msg = "直销商第" + (i + 2) + "行上级客户编号必须为全数字！";
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                //}
                                //if (data6.Rows[i]["上级客户编号"].ToString().Length != 8)
                                //{
                                //    msg.Msg = "直销商第" + (i + 2) + "行上级客户编号错误！";
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                //}
                                int province = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["省份"].ToString(), 1, token);
                                if (province == 0)
                                {
                                    msg.Msg = "直销商第" + (i + 2) + "行省份不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int city = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["城市"].ToString(), 2, token);
                                if (city == 0)
                                {
                                    msg.Msg = "直销商第" + (i + 2) + "行城市不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int ZJStype = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["中间商类型"].ToString(), 43, token);
                                if (ZJStype == 0)
                                {
                                    msg.Msg = "中间商第" + (i + 2) + "行中间商类型不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data6.Rows[i]["有效网点开发"].ToString().Trim() != "是" && data6.Rows[i]["有效网点开发"].ToString().Trim() != "否")
                                {
                                    msg.Msg = "中间商第" + (i + 2) + "行有效网点开发错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data6.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data6.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直销商第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data7 = ExcelToDataTable(savePath, sheet[7], true);      //OEM
                #region
                if (data7 != null)
                {
                    if (data7.Columns.Contains("CRM编号") == false || data7.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        try
                        {
                            //做数据验证
                            if (data7.Rows.Count > 0)
                            {
                                for (int i = 0; i < data7.Rows.Count; i++)
                                {
                                    if (data7.Rows[i]["客户性质"].ToString() != "签约客户" && data7.Rows[i]["客户性质"].ToString() != "潜在客户")
                                    {
                                        msg.Msg = "OEM第" + (i + 2) + "行客户性质不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    bool sap404 = false;  //要改成判断这个SAP编号存不存在   data7.Rows[i]["SAP编号"]
                                    if (data7.Rows[i]["SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data7.Rows[i]["SAP编号"].ToString(), token) == null)
                                        sap404 = true;
                                    if (data7.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data7.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data7.Rows[i]["CRM编号"].ToString().Length != 8)
                                    {
                                        msg.Msg = "OEM第" + ((i + 2)) + "行CRM编号错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (sap404)
                                    {
                                        msg.Msg = "OEM第" + (i + 2) + "行SAP编号不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data7.Rows[i]["SAP编号"].ToString() != "")
                                    {
                                        CRM_Report_KHModel model = new CRM_Report_KHModel();
                                        model.SAPSN = data7.Rows[i]["SAP编号"].ToString();
                                        model.ISACTIVE = 3;
                                        CRM_KH_KHList[] sapkehu = crmModels.KH_KH.Report(model, 0, token);
                                        if (sapkehu.Length >= 1)
                                        {
                                            msg.Msg = "OEM第" + (i + 2) + "行SAP编号已经存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                    if (data7.Rows[i]["上级客户编号"].ToString() != "")
                                    {
                                        if (Regex.IsMatch(data7.Rows[i]["上级客户编号"].ToString(), @"^\d+$") == false)
                                        {
                                            msg.Msg = "OEM第" + (i + 2) + "行上级客户编号必须为全数字！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data7.Rows[i]["上级客户编号"].ToString().Length != 8)
                                        {
                                            msg.Msg = "OEM第" + (i + 2) + "行上级客户编号错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }


                                    int kpxz = crmModels.HG_DICT.ReadByDICNAME(data7.Rows[i]["开票性质"].ToString(), 39, token);
                                    if (kpxz == 0)
                                    {
                                        msg.Msg = "OEM第" + (i + 2) + "行开票性质错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }

                                }
                                for (int i = 0; i < data7.Rows.Count; i++)
                                {
                                    CRM_KH_KH kh_model = new CRM_KH_KH();
                                    kh_model = crmModels.KH_KH.ReadByCRMID(data7.Rows[i]["CRM编号"].ToString(), token);
                                    if (kh_model.KHID == 0)
                                    {
                                        msg.Msg = "OEM第" + (i + 2) + "行CRM编号不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                            }
                        }
                        catch //(Exception e)
                        {

                        }


                    }
                }
                #endregion



                //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                #region
                //经销商
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["CRM编号"].ToString(), token);
                    switch (data1.Rows[i]["客户性质"].ToString())
                    {
                        case "签约客户":
                            model.IsOfficial = 20;
                            break;
                        case "非签约客户":
                            model.IsOfficial = 30;
                            break;
                        case "潜在客户":
                            model.IsOfficial = 10;
                            break;
                        default:
                            model.IsOfficial = 0;
                            break;
                    }
                    model.CRMID = data1.Rows[i]["CRM编号"].ToString();
                    model.SAPSN = data1.Rows[i]["SAP编号"].ToString();
                    model.SAPKHLX = "1";
                    switch (data1.Rows[i]["客户类型"].ToString())
                    {
                        case "经销商":
                            model.KHLX = 1;
                            break;
                        case "电商":
                            model.KHLX = 2;
                            break;
                        case "B2B":
                            model.KHLX = 4;
                            break;
                        default:
                            model.KHLX = 0;
                            break;
                    }
                    if (string.IsNullOrEmpty(data1.Rows[i]["上级客户编号"].ToString()) == false)
                        model.PKHID = Convert.ToInt32(data1.Rows[i]["上级客户编号"].ToString());
                    else
                        model.PKHID = 0;
                    model.MC = data1.Rows[i]["客户名称"].ToString();
                    model.KPXZ = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["开票性质"].ToString(), 39, token);
                    model.NSRSBH = data1.Rows[i]["纳税人识别号"].ToString();
                    model.KPDZ = data1.Rows[i]["开票地址"].ToString();
                    model.KPDH = data1.Rows[i]["开票电话"].ToString();
                    model.YHZH = data1.Rows[i]["银行帐号"].ToString();
                    model.YHMC = data1.Rows[i]["银行名称"].ToString();
                    model.GSLXR = data1.Rows[i]["公司联系人"].ToString();
                    model.GSLXDH = data1.Rows[i]["公司联系电话"].ToString();
                    model.FR = data1.Rows[i]["公司法人"].ToString();
                    model.GSFRGX = data1.Rows[i]["公司联系人与法人关系"].ToString();
                    model.KDJSDZ = data1.Rows[i]["快递寄送地址"].ToString();
                    model.KDLXR = data1.Rows[i]["快递联系人"].ToString();
                    model.KDLXDH = data1.Rows[i]["快递联系电话"].ToString();
                    model.KHSOURCE = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["经销商来源"].ToString(), 44, token);
                    model.KHLX2 = data1.Rows[i]["是否直销商"].ToString() == "是" ? crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["是否直销商"].ToString(), 43, token) : 0;
                    model.HTXSRW = data1.Rows[i]["合同销售任务（万）"].ToString();
                    model.HTJXXSRW = data1.Rows[i]["合同碱性销售任务（万）"].ToString();
                    model.XSSJSM = data1.Rows[i]["销售归属"].ToString();
                    model.FLSJSM = data1.Rows[i]["返利归属"].ToString();
                    switch (data1.Rows[i]["是否出厂价"].ToString())
                    {
                        case "是":
                            model.SFCCJ = true;
                            break;
                        case "否":
                            model.SFCCJ = false;
                            break;
                        default:
                            model.SFCCJ = true;
                            break;
                    }
                    model.SFCCJSM = data1.Rows[i]["价格说明"].ToString();
                    model.KHSHDZ = data1.Rows[i]["客户收货地址"].ToString();
                    model.KHSHLXR = data1.Rows[i]["收货联系人"].ToString();
                    model.KHSHLXDH = data1.Rows[i]["收货联系电话"].ToString();
                    model.TSQKSM = data1.Rows[i]["特殊情况说明"].ToString();
                    switch (data1.Rows[i]["是否对现有区域经销商影响"].ToString())
                    {
                        case "是":
                            model.JXSYX = true;
                            break;
                        case "否":
                            model.JXSYX = false;
                            break;
                        default:
                            model.JXSYX = false;
                            break;
                    }
                    model.YXSM = data1.Rows[i]["影响说明"].ToString();
                    model.ISACTIVE = 3;
                    model.FID = Convert.ToInt32(Session["STAFFID"]);
                    model.SAPKHLX = "1";

                    int id = crmModels.KH_KH.Update(model, token, false);
                    if (id <= 0)
                    {
                        msg.Msg = "修改经销商、电商、B2B的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    #endregion
                }
                //直营卖场系统
                for (int i = 0; i < data2.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data2.Rows[i]["CRM编号"].ToString(), token);
                    switch (data2.Rows[i]["客户性质"].ToString())
                    {
                        case "签约客户":
                            model.IsOfficial = 20;
                            break;
                        case "非签约客户":
                            model.IsOfficial = 30;
                            break;
                        case "潜在客户":
                            model.IsOfficial = 10;
                            break;
                        default:
                            model.IsOfficial = 0;
                            break;
                    }
                    model.CRMID = data2.Rows[i]["CRM编号"].ToString();
                    model.SAPSN = data2.Rows[i]["SAP编号"].ToString();
                    model.KHLX = 3;
                    model.MCSX = 1;
                    model.MC = data2.Rows[i]["客户名称"].ToString();
                    if (string.IsNullOrEmpty(data2.Rows[i]["上级客户编号"].ToString()) == false)
                        model.PKHID = Convert.ToInt32(data2.Rows[i]["上级客户编号"].ToString());
                    else
                        model.PKHID = 0;
                    model.SF = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["省份"].ToString(), 1, token);
                    model.CS = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["城市"].ToString(), 2, token);
                    model.FKTJ = data2.Rows[i]["付款条件"].ToString();
                    model.GSLXR = data2.Rows[i]["公司联系人"].ToString();
                    model.GSLXDH = data2.Rows[i]["公司联系电话"].ToString();
                    model.KPDZ = data2.Rows[i]["开票地址"].ToString();
                    model.KPDH = data2.Rows[i]["开票电话"].ToString();
                    model.KPXZ = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["开票性质"].ToString(), 39, token);
                    model.YHZH = data2.Rows[i]["银行帐号"].ToString();
                    model.YHMC = data2.Rows[i]["银行名称"].ToString();
                    model.NSRSBH = data2.Rows[i]["纳税人识别号"].ToString();
                    model.FR = data2.Rows[i]["公司法人"].ToString();
                    model.KDJSDZ = data2.Rows[i]["快递寄送地址"].ToString();
                    model.KDLXR = data2.Rows[i]["快递联系人"].ToString();
                    model.KDLXDH = data2.Rows[i]["快递联系电话"].ToString();
                    model.ISACTIVE = 3;
                    model.FID = Convert.ToInt32(Session["STAFFID"]);
                    model.SAPKHLX = "1";

                    int id = crmModels.KH_KH.Update(model, token, false);
                    if (id <= 0)
                    {
                        msg.Msg = "修改直营卖场的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    #endregion
                }
                //直营卖场门店
                for (int i = 0; i < data2s.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data2s.Rows[i]["CRM编号"].ToString(), token);
                    switch (data2s.Rows[i]["客户性质"].ToString())
                    {
                        case "签约客户":
                            model.IsOfficial = 20;
                            break;
                        case "非签约客户":
                            model.IsOfficial = 30;
                            break;
                        case "潜在客户":
                            model.IsOfficial = 10;
                            break;
                        default:
                            model.IsOfficial = 0;
                            break;
                    }
                    model.CRMID = data2s.Rows[i]["CRM编号"].ToString();
                    model.SAPSN = data2s.Rows[i]["SAP编号"].ToString();
                    model.KHLX = 3;
                    model.MCSX = 2;
                    model.MC = data2s.Rows[i]["客户名称"].ToString().Trim();
                    if (string.IsNullOrEmpty(data2s.Rows[i]["上级客户编号"].ToString()) == false)
                        model.PKHID = Convert.ToInt32(data2s.Rows[i]["上级客户编号"].ToString());
                    else
                        model.PKHID = 0;
                    model.SF = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["省份"].ToString(), 1, token);
                    model.CS = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["城市"].ToString(), 2, token);
                    model.MDDZ = data2s.Rows[i]["客户收货地址"].ToString();
                    model.GSLXR = data2s.Rows[i]["客户收货联系人"].ToString();
                    model.GSLXDH = data2s.Rows[i]["客户收货联系电话"].ToString();
                    model.ISACTIVE = 3;
                    model.FID = Convert.ToInt32(Session["STAFFID"]);
                    model.SAPKHLX = "1";
                    model.BEIZ = data2s.Rows[i]["门店编号"].ToString();
                    int id = crmModels.KH_KH.Update(model, token, false);
                    if (id <= 0)
                    {
                        msg.Msg = "修改直营卖场门店的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    #endregion
                }
                //终端网点
                for (int i = 0; i < data3.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["CRM编号"].ToString(), token);
                    switch (data3.Rows[i]["客户性质"].ToString())
                    {
                        case "签约客户":
                            model.IsOfficial = 20;
                            break;
                        case "非签约客户":
                            model.IsOfficial = 30;
                            break;
                        case "潜在客户":
                            model.IsOfficial = 10;
                            break;
                        default:
                            model.IsOfficial = 0;
                            break;
                    }
                    model.CRMID = data3.Rows[i]["CRM编号"].ToString();
                    model.SAPSN = data3.Rows[i]["SAP编号"].ToString();
                    model.KHLX = 5;
                    model.SF = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["省份"].ToString(), 1, token);
                    model.CS = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["城市"].ToString(), 2, token);
                    if (string.IsNullOrEmpty(data3.Rows[i]["上级客户编号"].ToString()) == false)
                        model.PKHID = Convert.ToInt32(data3.Rows[i]["上级客户编号"].ToString());
                    else
                        model.PKHID = 0;
                    model.MC = data3.Rows[i]["客户名称"].ToString();
                    model.MDDZ = data3.Rows[i]["地址"].ToString();
                    model.GSLXR = data3.Rows[i]["联系人"].ToString();
                    model.GSLXDH = data3.Rows[i]["联系电话"].ToString();
                    model.WDLX = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["网点类型"].ToString(), 3, token);
                    switch (data3.Rows[i]["是否标准网点"].ToString())
                    {
                        case "是":
                            model.SFBZWD = true;
                            break;
                        case "否":
                            model.SFBZWD = false;
                            break;
                        default:
                            model.SFBZWD = true;
                            break;
                    }
                    model.KHZZSJ = Convert.ToDateTime(data3.Rows[i]["客户开发时间"]).ToString("yyyy-MM-dd");
                    model.BEIZ = data3.Rows[i]["备注"].ToString();
                    model.ISACTIVE = 3;
                    model.FID = Convert.ToInt32(Session["STAFFID"]);
                    model.SAPKHLX = "1";

                    int id = crmModels.KH_KH.Update(model, token, false);
                    if (id <= 0)
                    {
                        msg.Msg = "修改终端网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                    crmModels.KH_KHZZ.DeleteByKHID(model.KHID, token);
                    //客户新建完后开始建资质数据
                    if (data3.Rows[i]["有效网点开发"].ToString() == "是")
                    {
                        CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                        zzmodel.KHID = id;
                        zzmodel.ZZMCID = 1080;
                        zzmodel.INFO1 = data3.Rows[i]["有效网点销量"].ToString();
                        zzmodel.INFO2 = data3.Rows[i]["有效网点说明"].ToString();
                        zzmodel.INFO3 = "";
                        zzmodel.ISACTIVE = 3;
                        zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                        int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                        if (zzid <= 0)
                        {
                            msg.Msg = "修改终端网点有效网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    if (data3.Rows[i]["是否电子锁"].ToString() == "是")
                    {
                        CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                        zzmodel.KHID = id;
                        zzmodel.ZZMCID = 1058;
                        zzmodel.INFO1 = data3.Rows[i]["现有品牌、数量"].ToString();
                        zzmodel.INFO2 = "";
                        zzmodel.INFO3 = "";
                        zzmodel.ISACTIVE = 3;
                        zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                        int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                        if (zzid <= 0)
                        {
                            msg.Msg = "修改终端网点电子锁的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                    }



                    #endregion
                }
                //LKA
                for (int i = 0; i < data4.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data4.Rows[i]["CRM编号"].ToString(), token);
                    switch (data4.Rows[i]["客户性质"].ToString())
                    {
                        case "签约客户":
                            model.IsOfficial = 20;
                            break;
                        case "非签约客户":
                            model.IsOfficial = 30;
                            break;
                        case "潜在客户":
                            model.IsOfficial = 10;
                            break;
                        default:
                            model.IsOfficial = 0;
                            break;
                    }
                    model.KHLX = 7;
                    model.MCSX = 1;
                    model.CRMID = data4.Rows[i]["CRM编号"].ToString();
                    model.SAPSN = data4.Rows[i]["SAP编号"].ToString();
                    if (string.IsNullOrEmpty(data4.Rows[i]["经销商编号"].ToString()) == false)
                        model.PKHID = Convert.ToInt32(data4.Rows[i]["经销商编号"].ToString());
                    else
                        model.PKHID = 0;
                    model.MC = data4.Rows[i]["卖场名称"].ToString();
                    model.MDJCSL = data4.Rows[i]["门店进场数量"].ToString();
                    model.MDDZ = data4.Rows[i]["卖场总部地址"].ToString();
                    model.KHZZSJ = Convert.ToDateTime(data4.Rows[i]["客户开发时间"]).ToString("yyyy-MM-dd");
                    model.BEIZ = data4.Rows[i]["备注"].ToString();
                    model.ISACTIVE = 3;
                    model.FID = Convert.ToInt32(Session["STAFFID"]);
                    model.SAPKHLX = "1";

                    int id = crmModels.KH_KH.Update(model, token, false);
                    if (id <= 0)
                    {
                        msg.Msg = "修改LKA的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                    crmModels.KH_KHZZ.DeleteByKHID(model.KHID, token);
                    //客户新建完后开始建资质数据
                    if (data4.Rows[i]["有效网点开发"].ToString() == "是")
                    {
                        CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                        zzmodel.KHID = id;
                        zzmodel.ZZMCID = 1080;
                        zzmodel.INFO1 = data4.Rows[i]["有效网点销量"].ToString();
                        zzmodel.INFO2 = data4.Rows[i]["有效网点说明"].ToString();
                        zzmodel.INFO3 = "";
                        zzmodel.ISACTIVE = 3;
                        zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                        int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                        if (zzid <= 0)
                        {
                            msg.Msg = "修改LKA有效网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }



                    #endregion
                }
                //LKA门店
                for (int i = 0; i < data5.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data5.Rows[i]["CRM编号"].ToString(), token);
                    switch (data5.Rows[i]["客户性质"].ToString())
                    {
                        case "签约客户":
                            model.IsOfficial = 20;
                            break;
                        case "非签约客户":
                            model.IsOfficial = 30;
                            break;
                        case "潜在客户":
                            model.IsOfficial = 10;
                            break;
                        default:
                            model.IsOfficial = 0;
                            break;
                    }
                    model.KHLX = 7;
                    model.MCSX = 2;
                    model.CRMID = data5.Rows[i]["CRM编号"].ToString();
                    model.SAPSN = data5.Rows[i]["SAP编号"].ToString();
                    if (string.IsNullOrEmpty(data5.Rows[i]["卖场编号"].ToString()) == false)
                        model.PKHID = Convert.ToInt32(data5.Rows[i]["卖场编号"].ToString());
                    else
                        model.PKHID = 0;
                    model.MC = data5.Rows[i]["门店名称"].ToString();
                    model.MDDZ = data5.Rows[i]["门店地址"].ToString();
                    model.MCLC = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["门店类型"].ToString(), 4, token);
                    model.JCDPSL = data5.Rows[i]["进场单品数量"].ToString();
                    model.XSSJSM = data5.Rows[i]["双鹿销售主要品种"].ToString();
                    model.KHZZSJ = Convert.ToDateTime(data5.Rows[i]["客户开发时间"]).ToString("yyyy-MM-dd");
                    model.BEIZ = data5.Rows[i]["备注"].ToString();
                    model.ISACTIVE = 3;
                    model.FID = Convert.ToInt32(Session["STAFFID"]);
                    model.SAPKHLX = "1";

                    int id = crmModels.KH_KH.Update(model, token, false);
                    if (id <= 0)
                    {
                        msg.Msg = "修改LKA门店的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                    crmModels.KH_KHZZ.DeleteByKHID(model.KHID, token);
                    //客户新建完后开始建资质数据
                    if (data5.Rows[i]["有效网点开发"].ToString() == "是")
                    {
                        CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                        zzmodel.KHID = id;
                        zzmodel.ZZMCID = 1080;
                        zzmodel.INFO1 = data5.Rows[i]["有效网点销量"].ToString();
                        zzmodel.INFO2 = data5.Rows[i]["有效网点说明"].ToString();
                        zzmodel.INFO3 = "";
                        zzmodel.ISACTIVE = 3;
                        zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                        int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                        if (zzid <= 0)
                        {
                            msg.Msg = "修改LKA门店有效网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }


                    #endregion
                }
                //中间商
                for (int i = 0; i < data6.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data6.Rows[i]["CRM编号"].ToString(), token);
                    switch (data6.Rows[i]["客户性质"].ToString())
                    {
                        case "签约客户":
                            model.IsOfficial = 20;
                            break;
                        case "非签约客户":
                            model.IsOfficial = 30;
                            break;
                        case "潜在客户":
                            model.IsOfficial = 10;
                            break;
                        default:
                            model.IsOfficial = 0;
                            break;
                    }
                    model.CRMID = data6.Rows[i]["CRM编号"].ToString();
                    model.KHLX = 9;
                    model.SAPSN = data6.Rows[i]["SAP编号"].ToString();
                    if (string.IsNullOrEmpty(data6.Rows[i]["上级客户编号"].ToString()) == false)
                        model.PKHID = Convert.ToInt32(data6.Rows[i]["上级客户编号"].ToString());
                    else
                        model.PKHID = 0;
                    model.SF = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["省份"].ToString(), 1, token);
                    model.CS = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["城市"].ToString(), 2, token);
                    model.MC = data6.Rows[i]["客户名称"].ToString().Trim();
                    model.MDDZ = data6.Rows[i]["地址"].ToString();
                    model.GSLXR = data6.Rows[i]["联系人"].ToString();
                    model.GSLXDH = data6.Rows[i]["联系电话"].ToString();
                    model.KHLX2 = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["中间商类型"].ToString(), 43, token);
                    model.KHZZSJ = Convert.ToDateTime(data6.Rows[i]["客户开发时间"]).ToString("yyyy-MM-dd");
                    model.BEIZ = data6.Rows[i]["备注"].ToString();
                    model.ISACTIVE = 3;
                    model.FID = Convert.ToInt32(Session["STAFFID"]);
                    model.SAPKHLX = "1";
                    int id = crmModels.KH_KH.Update(model, token, false);
                    if (id <= 0)
                    {
                        msg.Msg = "修改中间商的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                    crmModels.KH_KHZZ.DeleteByKHID(model.KHID, token);
                    //客户新建完后开始建资质数据
                    if (data6.Rows[i]["有效网点开发"].ToString() == "是")
                    {
                        CRM_KH_KHZZ zzmodel = new CRM_KH_KHZZ();
                        zzmodel.KHID = id;
                        zzmodel.ZZMCID = 1080;
                        zzmodel.INFO1 = data6.Rows[i]["有效网点销量"].ToString();
                        zzmodel.INFO2 = data6.Rows[i]["有效网点说明"].ToString();
                        zzmodel.INFO3 = "";
                        zzmodel.ISACTIVE = 3;
                        zzmodel.CZR = Convert.ToInt32(Session["STAFFID"]);
                        int zzid = crmModels.KH_KHZZ.Create(zzmodel, token);
                        if (zzid <= 0)
                        {
                            msg.Msg = "修改中间商有效网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }

                    #endregion
                }
                //OEM
                for (int i = 0; i < data7.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data7.Rows[i]["CRM编号"].ToString(), token);
                    switch (data7.Rows[i]["客户性质"].ToString())
                    {
                        case "签约客户":
                            model.IsOfficial = 20;
                            break;
                        case "非签约客户":
                            model.IsOfficial = 30;
                            break;
                        case "潜在客户":
                            model.IsOfficial = 10;
                            break;
                        default:
                            model.IsOfficial = 0;
                            break;
                    }
                    model.CRMID = data7.Rows[i]["CRM编号"].ToString();
                    model.SAPSN = data7.Rows[i]["SAP编号"].ToString();
                    model.SAPKHLX = "1";
                    model.KHLX = 1105;
                    if (string.IsNullOrEmpty(data7.Rows[i]["上级客户编号"].ToString()) == false)
                        model.PKHID = Convert.ToInt32(data7.Rows[i]["上级客户编号"].ToString());
                    else
                        model.PKHID = 0;
                    model.MC = data7.Rows[i]["客户名称"].ToString();
                    model.KPXZ = crmModels.HG_DICT.ReadByDICNAME(data7.Rows[i]["开票性质"].ToString(), 39, token);
                    model.NSRSBH = data7.Rows[i]["纳税人识别号"].ToString();
                    model.KPDZ = data7.Rows[i]["开票地址"].ToString();
                    model.KPDH = data7.Rows[i]["开票电话"].ToString();
                    model.YHZH = data7.Rows[i]["银行帐号"].ToString();
                    model.YHMC = data7.Rows[i]["银行名称"].ToString();
                    model.GSLXR = data7.Rows[i]["公司联系人"].ToString();
                    model.GSLXDH = data7.Rows[i]["公司联系电话"].ToString();
                    model.FR = data7.Rows[i]["公司法人"].ToString();
                    model.GSFRGX = data7.Rows[i]["公司联系人与法人关系"].ToString();
                    model.KDJSDZ = data7.Rows[i]["快递寄送地址"].ToString();
                    model.KDLXR = data7.Rows[i]["快递联系人"].ToString();
                    model.KDLXDH = data7.Rows[i]["快递联系电话"].ToString();

                    model.ISACTIVE = 3;
                    model.FID = Convert.ToInt32(Session["STAFFID"]);
                    model.SAPKHLX = "1";

                    int id = crmModels.KH_KH.Update(model, token, false);
                    if (id <= 0)
                    {
                        msg.Msg = "修改OEM的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    #endregion
                }
                #endregion

                msg.Msg = "修改成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.Msg = "文件读取失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

        }


        /// <summary>
        /// 批量新增客户其他数据
        /// </summary>
        /// <returns></returns>
        public string Data_DaoRu_QT_Insert()
        {
            token = appClass.CRM_Gettoken();

            var file = Request.Files[0];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;

            string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
            if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
            {
                Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
            }
            file.SaveAs(savePath);
            FileInfo fi = new FileInfo(savePath);

            DaoRuMsg msg = new DaoRuMsg();
            if (fi.Exists == true)
            {
                string[] sheet = { "渠道", "销售品种", "竞品", "管辖区域", "陈列", "客户分组", "邮寄地址", "客户联系人", "拜访频次", "送货数量", "直销商销售", "网点数量", "车牌", "促销单品", "签到地址", "直销人员", "活动" };


                //开始数据校验
                DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //渠道
                #region
                if (data1 != null)
                {
                    if (data1.Columns.Contains("CRM编号") == false || data1.Columns.Contains("渠道") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data1.Rows.Count > 0)
                        {
                            for (int i = 0; i < data1.Rows.Count; i++)
                            {
                                if (data1.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data1.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data1.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "渠道第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int qudao = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["渠道"].ToString(), 7, token);
                                if (qudao == 0)
                                {
                                    msg.Msg = "渠道第" + (i + 2) + "行渠道不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data1.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "渠道第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data2 = ExcelToDataTable(savePath, sheet[1], true);      //销售品种
                #region
                if (data2 != null)
                {
                    if (data2.Columns.Contains("CRM编号") == false || data2.Columns.Contains("销售品种") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data2.Rows.Count > 0)
                        {
                            for (int i = 0; i < data2.Rows.Count; i++)
                            {
                                if (data2.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data2.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data2.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "销售品种第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int pinzhong = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["销售品种"].ToString(), 8, token);
                                if (pinzhong == 0)
                                {
                                    msg.Msg = "销售品种第" + (i + 2) + "行销售品种不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data2.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data2.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "销售品种第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data3 = ExcelToDataTable(savePath, sheet[2], true);      //竞品
                #region
                if (data3 != null)
                {
                    if (data3.Columns.Contains("CRM编号") == false || data3.Columns.Contains("竞品") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data3.Rows.Count > 0)
                        {
                            for (int i = 0; i < data3.Rows.Count; i++)
                            {
                                if (data3.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data3.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data3.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "竞品第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int pinzhong = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["竞品"].ToString(), 10, token);
                                if (pinzhong == 0)
                                {
                                    msg.Msg = "竞品第" + (i + 2) + "行竞品不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data3.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "竞品第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data4 = ExcelToDataTable(savePath, sheet[3], true);      //管辖区域
                #region
                if (data4 != null)
                {
                    if (data4.Columns.Contains("CRM编号") == false || data4.Columns.Contains("管辖区域类型") == false || data4.Columns.Contains("管辖区域名称") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data4.Rows.Count > 0)
                        {
                            for (int i = 0; i < data4.Rows.Count; i++)
                            {
                                if (data4.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data4.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data4.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "管辖区域第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data4.Rows[i]["管辖区域类型"].ToString() != "全国" && data4.Rows[i]["管辖区域类型"].ToString() != "省份" && data4.Rows[i]["管辖区域类型"].ToString() != "城市" && data4.Rows[i]["管辖区域类型"].ToString() != "县级")
                                {
                                    msg.Msg = "管辖区域第" + (i + 2) + "行管辖区域类型错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data4.Rows[i]["管辖区域类型"].ToString() == "省份")
                                {
                                    int area = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 1, token);
                                    if (area == 0)
                                    {
                                        msg.Msg = "管辖区域第" + (i + 2) + "行管辖区域不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                else if (data4.Rows[i]["管辖区域类型"].ToString() == "城市")
                                {
                                    int area = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 2, token);
                                    if (area == 0)
                                    {
                                        msg.Msg = "管辖区域第" + (i + 2) + "行管辖区域不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                else if (data4.Rows[i]["管辖区域类型"].ToString() == "县级")
                                {
                                    int area = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 34, token);
                                    if (area == 0)
                                    {
                                        msg.Msg = "管辖区域第" + (i + 2) + "行管辖区域不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }


                            }
                            for (int i = 0; i < data4.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data4.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "管辖区域第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data5 = ExcelToDataTable(savePath, sheet[4], true);      //陈列
                #region
                if (data5 != null)
                {
                    if (data5.Columns.Contains("CRM编号") == false || data5.Columns.Contains("陈列类型") == false || data5.Columns.Contains("陈列方式") == false || data5.Columns.Contains("陈列归属日期") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data5.Rows.Count > 0)
                        {
                            for (int i = 0; i < data5.Rows.Count; i++)
                            {
                                if (data5.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data5.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data5.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "陈列第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data5.Rows[i]["陈列类型"].ToString() != "主陈列" && data5.Rows[i]["陈列类型"].ToString() != "二次陈列")
                                {
                                    msg.Msg = "陈列第" + (i + 2) + "行陈列类型错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int display = 0;
                                if (data5.Rows[i]["陈列类型"].ToString() == "主陈列")
                                {
                                    display = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["陈列方式"].ToString(), 9, token);
                                }
                                else if (data5.Rows[i]["陈列类型"].ToString() == "二次陈列")
                                {
                                    display = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["陈列方式"].ToString(), 23, token);
                                }

                                if (display == 0)
                                {
                                    msg.Msg = "陈列第" + (i + 2) + "行陈列不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data5.Rows[i]["陈列归属日期"].ToString() != "")
                                {
                                    try
                                    {
                                        DateTime myDT = Convert.ToDateTime(data5.Rows[i]["陈列归属日期"].ToString());

                                    }
                                    catch
                                    {
                                        msg.Msg = "陈列第" + (i + 2) + "行陈列归属日期格式错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data5.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data5.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "陈列第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data6 = ExcelToDataTable(savePath, sheet[5], true);      //分组
                #region
                if (data6 != null)
                {
                    if (data6.Columns.Contains("CRM编号") == false || data6.Columns.Contains("客户分组") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data6.Rows.Count > 0)
                        {
                            for (int i = 0; i < data6.Rows.Count; i++)
                            {
                                if (data6.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data6.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data6.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "分组第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int group = crmModels.KH_GROUP.ReadGidByGNAME(data6.Rows[i]["客户分组"].ToString(), token);
                                if (group == 0)
                                {
                                    msg.Msg = "分组第" + (i + 2) + "行分组不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data6.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data6.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "分组第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data7 = ExcelToDataTable(savePath, sheet[6], true);      //邮寄地址
                #region
                if (data7 != null)
                {
                    if (data7.Columns.Contains("CRM编号") == false || data7.Columns.Contains("客户邮寄地址") == false || data7.Columns.Contains("邮编") == false || data7.Columns.Contains("收件人") == false || data7.Columns.Contains("收件人联系方式") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data7.Rows.Count > 0)
                        {
                            for (int i = 0; i < data7.Rows.Count; i++)
                            {
                                if (data7.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data7.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data7.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "邮寄地址第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data7.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data7.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "邮寄地址第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data8 = ExcelToDataTable(savePath, sheet[7], true);      //客户联系人
                #region
                if (data8 != null)
                {
                    if (data8.Columns.Contains("CRM编号") == false || data8.Columns.Contains("联系人") == false || data8.Columns.Contains("性别") == false || data8.Columns.Contains("家庭地址") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data8.Rows.Count > 0)
                        {
                            for (int i = 0; i < data8.Rows.Count; i++)
                            {
                                if (data8.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data8.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data8.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "客户联系人第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data8.Rows[i]["性别"].ToString() != "")
                                {
                                    if (data8.Rows[i]["性别"].ToString().Trim() != "男" && data8.Rows[i]["性别"].ToString().Trim() != "女")
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行性别错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                                if (data8.Rows[i]["民族"].ToString() != "")
                                {
                                    int minzu = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["民族"].ToString(), 11, token);
                                    if (minzu == 0)
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行民族不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data8.Rows[i]["职位"].ToString() != "")
                                {
                                    int zhiwei = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["职位"].ToString(), 12, token);
                                    if (zhiwei == 0)
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行职位不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data8.Rows[i]["婚姻状况"].ToString() != "")
                                {
                                    int hyzk = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["婚姻状况"].ToString(), 31, token);
                                    if (hyzk == 0)
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行婚姻状况不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data8.Rows[i]["生日"].ToString() != "")
                                {
                                    try
                                    {
                                        string[] date = data8.Rows[i]["生日"].ToString().Split('-');
                                        if (date.Length != 3 && date.Length != 2)
                                        {
                                            msg.Msg = "客户联系人第" + (i + 2) + "行生日格式错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (date.Length == 3)
                                        {
                                            int y = Convert.ToInt32(date[0]);
                                            int m = Convert.ToInt32(date[1]);
                                            int d = Convert.ToInt32(date[2]);
                                        }
                                        else if (date.Length == 2)
                                        {
                                            int m = Convert.ToInt32(date[0]);
                                            int d = Convert.ToInt32(date[1]);
                                        }


                                    }
                                    catch
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行生日格式错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data8.Rows[i]["是否主要联系人"].ToString() != "")
                                {
                                    if (data8.Rows[i]["是否主要联系人"].ToString().Trim() != "是" && data8.Rows[i]["是否主要联系人"].ToString().Trim() != "否")
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行是否主要联系人错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data8.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data8.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "客户联系人第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data9 = ExcelToDataTable(savePath, sheet[8], true);      //拜访频次
                #region
                if (data9 != null)
                {
                    if (data9.Columns.Contains("CRM编号") == false || data9.Columns.Contains("拜访周期") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data9.Rows.Count > 0)
                        {
                            for (int i = 0; i < data9.Rows.Count; i++)
                            {
                                if (data9.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data9.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data9.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "拜访频次第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int ZQ = crmModels.HG_DICT.ReadByDICNAME(data9.Rows[i]["拜访周期"].ToString(), 26, token);
                                if (ZQ == 0)
                                {
                                    msg.Msg = "拜访频次第" + (i + 2) + "行拜访周期单位不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                CRM_KH_BF bfmodel = new CRM_KH_BF();
                                bfmodel.DUTYID = 5;
                                bfmodel.BFZQ = crmModels.HG_DICT.ReadByDICNAME(data9.Rows[i]["拜访周期"].ToString(), 26, token);
                                bfmodel.BFCS = Convert.ToInt32(data9.Rows[i]["拜访次数"].ToString());
                                bfmodel.ISACTIVE = 1;
                                CRM_KH_BFList[] bfdata = crmModels.KH_BF.Read(bfmodel, token);
                                if (bfdata.Length == 0)
                                {
                                    msg.Msg = "拜访频次第" + (i + 2) + "行拜访周期数据不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data9.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data9.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "拜访频次第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data10 = ExcelToDataTable(savePath, sheet[9], true);      //送货数量
                #region
                if (data10 != null)
                {
                    if (data10.Columns.Contains("CRM编号") == false || data10.Columns.Contains("送货数量") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data10.Rows.Count > 0)
                        {
                            for (int i = 0; i < data10.Rows.Count; i++)
                            {
                                if (data10.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data10.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data10.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "送货数量第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data10.Rows[i]["送货日期"].ToString() != "")
                                {
                                    try
                                    {
                                        DateTime mtDT = Convert.ToDateTime(data10.Rows[i]["送货日期"].ToString());

                                    }
                                    catch
                                    {
                                        msg.Msg = "送货数量第" + (i + 2) + "行送货日期格式错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data10.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data10.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "送货数量第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data11 = ExcelToDataTable(savePath, sheet[10], true);      //直销商销售
                #region
                if (data11 != null)
                {
                    if (data11.Columns.Contains("CRM编号") == false || data11.Columns.Contains("销售类别") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data11.Rows.Count > 0)
                        {
                            for (int i = 0; i < data11.Rows.Count; i++)
                            {
                                if (data11.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data11.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data11.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "直销商销售第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int XSLB = crmModels.HG_DICT.ReadByDICNAME(data11.Rows[i]["销售类别"].ToString(), 36, token);
                                if (XSLB == 0)
                                {
                                    msg.Msg = "直销商销售第" + (i + 2) + "行销售类别不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data11.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data11.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直销商销售第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data12 = ExcelToDataTable(savePath, sheet[11], true);      //网点数量
                #region
                if (data12 != null)
                {
                    if (data12.Columns.Contains("CRM编号") == false || data12.Columns.Contains("信息类别") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data12.Rows.Count > 0)
                        {
                            for (int i = 0; i < data12.Rows.Count; i++)
                            {
                                if (data12.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data12.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data12.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "网点数量第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int XXLB = crmModels.HG_DICT.ReadByDICNAME(data12.Rows[i]["信息类别"].ToString(), 37, token);
                                if (XXLB == 0)
                                {
                                    msg.Msg = "网点数量第" + (i + 2) + "行信息类别不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data12.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data12.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "网点数量第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data13 = ExcelToDataTable(savePath, sheet[12], true);      //车牌
                #region
                if (data13 != null)
                {
                    if (data13.Columns.Contains("CRM编号") == false || data13.Columns.Contains("车牌") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data13.Rows.Count > 0)
                        {
                            for (int i = 0; i < data13.Rows.Count; i++)
                            {
                                if (data13.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data13.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data13.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "车牌第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data13.Rows[i]["是否有车体广告"].ToString() != "有" && data13.Rows[i]["是否有车体广告"].ToString() != "无")
                                {
                                    msg.Msg = "车牌第" + (i + 2) + "行是否有车体广告错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data13.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data13.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "车牌第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data14 = ExcelToDataTable(savePath, sheet[13], true);      //促销单品
                #region
                if (data14 != null)
                {
                    if (data14.Columns.Contains("CRM编号") == false || data14.Columns.Contains("单品名称") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data14.Rows.Count > 0)
                        {
                            for (int i = 0; i < data14.Rows.Count; i++)
                            {
                                if (data14.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data14.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data14.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "促销单品第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int DP = crmModels.HG_DICT.ReadByDICNAME(data14.Rows[i]["单品名称"].ToString(), 38, token);
                                if (DP == 0)
                                {
                                    msg.Msg = "促销单品第" + (i + 2) + "行单品名称不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data14.Rows[i]["是否与LKA渠道重叠"].ToString() != "是" && data14.Rows[i]["是否与LKA渠道重叠"].ToString() != "否")
                                {
                                    msg.Msg = "促销单品第" + (i + 2) + "行是否与LKA渠道重叠错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data14.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data14.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "促销单品第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data15 = ExcelToDataTable(savePath, sheet[14], true);      //签到地址
                #region
                if (data15 != null)
                {
                    if (data15.Columns.Contains("CRM编号") == false || data15.Columns.Contains("地址") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data15.Rows.Count > 0)
                        {
                            for (int i = 0; i < data15.Rows.Count; i++)
                            {
                                if (data15.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data15.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data15.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "签到地址第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data15.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data15.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "签到地址第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data16 = ExcelToDataTable(savePath, sheet[15], true);      //直销人员
                #region
                if (data16 != null)
                {
                    if (data16.Columns.Contains("CRM编号") == false || data16.Columns.Contains("联系人") == false || data16.Columns.Contains("联系方式") == false || data16.Columns.Contains("工作内容") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data16.Rows.Count > 0)
                        {
                            for (int i = 0; i < data16.Rows.Count; i++)
                            {
                                if (data16.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data16.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data16.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "直销人员第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data16.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data16.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直销人员第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data17 = ExcelToDataTable(savePath, sheet[16], true);      //活动
                #region
                if (data17 != null)
                {
                    if (data17.Columns.Contains("CRM编号") == false || data17.Columns.Contains("活动名称") == false || data17.Columns.Contains("产品类型") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data17.Rows.Count > 0)
                        {
                            for (int i = 0; i < data17.Rows.Count; i++)
                            {
                                if (data17.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data17.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data17.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "活动第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int HDMC = crmModels.HG_DICT.ReadByDICNAME(data17.Rows[i]["活动名称"].ToString(), 46, token);
                                if (HDMC == 0)
                                {
                                    msg.Msg = "活动第" + (i + 2) + "行活动名称不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data17.Rows[i]["活动名称"].ToString() != "无")
                                {
                                    int CPLX = crmModels.HG_DICT.ReadByDICNAME(data17.Rows[i]["产品类型"].ToString(), 45, token);
                                    if (CPLX == 0)
                                    {
                                        msg.Msg = "活动第" + (i + 2) + "行产品类型不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data17.Rows[i]["销量"].ToString() == "")
                                    {
                                        msg.Msg = "活动第" + (i + 2) + "行销量不可为空！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data17.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data17.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "活动第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion



                //开始写入数据库

                //渠道
                #region
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 1;
                    model.XXMC = data1.Rows[i]["渠道"].ToString();
                    model.ISACTIVE = 1;
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    int id = crmModels.KH_KHQTXX.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "渠道的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //销售品种
                #region
                for (int i = 0; i < data2.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data2.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 2;
                    model.XXMC = data2.Rows[i]["销售品种"].ToString();
                    model.ISACTIVE = 1;
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    int id = crmModels.KH_KHQTXX.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "销售品种的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //竞品
                #region
                for (int i = 0; i < data3.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 3;
                    model.XXMC = data3.Rows[i]["竞品"].ToString();
                    model.ISACTIVE = 1;
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    int id = crmModels.KH_KHQTXX.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "竞品的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //管辖区域
                #region
                for (int i = 0; i < data4.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data4.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_GXQY model = new CRM_KH_GXQY();
                    model.KHID = khid;
                    switch (data4.Rows[i]["管辖区域类型"].ToString())
                    {
                        case "全国":
                            model.GXQYLX = 1;
                            model.GXQYMC = 0;
                            break;
                        case "省份":
                            model.GXQYLX = 2;
                            model.GXQYMC = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 1, token);
                            break;
                        case "城市":
                            model.GXQYLX = 3;
                            model.GXQYMC = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 2, token);
                            break;
                        case "县级":
                            model.GXQYLX = 4;
                            model.GXQYMC = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 34, token);
                            break;
                        default:
                            break;
                    }
                    model.ISACTIVE = 1;
                    model.BEIZ = data4.Rows[i]["备注"].ToString();
                    int id = crmModels.KH_GXQY.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "管辖区域的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //陈列
                #region
                for (int i = 0; i < data5.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data5.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 4;
                    switch (data5.Rows[i]["陈列类型"].ToString())
                    {
                        case "主陈列":
                            model.CLLX = 1;
                            model.CLFS = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["陈列方式"].ToString(), 9, token);
                            break;
                        case "二次陈列":
                            model.CLLX = 2;
                            model.CLFS = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["陈列方式"].ToString(), 23, token);
                            break;
                        default:
                            break;
                    }

                    model.CLGSRQ = Convert.ToDateTime(data5.Rows[i]["陈列归属日期"].ToString()).ToString("yyyy-MM-dd");
                    model.ISACTIVE = 1;
                    model.BEIZ = data5.Rows[i]["备注"].ToString();
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);

                    int id = crmModels.KH_KHQTXX.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "陈列的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //分组
                #region
                for (int i = 0; i < data6.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data6.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    int gid = crmModels.KH_GROUP.ReadGidByGNAME(data6.Rows[i]["客户分组"].ToString(), token);

                    int id = crmModels.KH_GROUP_KH.Create(khid, gid, token);
                    if (id <= 0)
                    {
                        msg.Msg = "分组的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //邮寄地址
                #region
                for (int i = 0; i < data7.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data7.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 5;
                    model.KHYJDZ = data7.Rows[i]["客户邮寄地址"].ToString();
                    model.YB = data7.Rows[i]["邮编"].ToString();
                    model.SJR = data7.Rows[i]["收件人"].ToString();
                    model.SJRLXFS = data7.Rows[i]["收件人联系方式"].ToString();
                    model.ISACTIVE = 1;
                    model.BEIZ = data7.Rows[i]["备注"].ToString();
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    int id = crmModels.KH_KHQTXX.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "邮寄地址的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //客户联系人
                #region
                for (int i = 0; i < data8.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data8.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_LXR model = new CRM_KH_LXR();
                    model.KHID = khid;
                    model.LB = 1081;
                    model.LXR = data8.Rows[i]["联系人"].ToString();
                    model.SEX = data8.Rows[i]["性别"].ToString();
                    model.JTDZ = data8.Rows[i]["家庭地址"].ToString();
                    model.JG = data8.Rows[i]["籍贯"].ToString();
                    model.MZ = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["民族"].ToString(), 11, token);
                    model.ZW = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["职位"].ToString(), 12, token);
                    model.AH = data8.Rows[i]["爱好"].ToString();
                    model.HYZK = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["婚姻状况"].ToString(), 31, token);
                    model.YDDH = data8.Rows[i]["移动电话"].ToString();
                    model.GDDH = data8.Rows[i]["固定电话"].ToString();
                    model.TEL = data8.Rows[i]["传真"].ToString();
                    model.EMAIL = data8.Rows[i]["邮箱"].ToString();
                    model.WXH = data8.Rows[i]["微信号"].ToString();
                    model.SR = data8.Rows[i]["生日"].ToString();
                    model.TXDZ = data8.Rows[i]["通信地址"].ToString();
                    model.YZBM = data8.Rows[i]["邮政编码"].ToString();
                    model.XGMS = data8.Rows[i]["性格描述"].ToString();
                    if (data8.Rows[i]["是否主要联系人"].ToString() == "是")
                        model.SFZYLXR = 1;
                    else
                        model.SFZYLXR = 0;
                    model.BEIZ = data8.Rows[i]["备注"].ToString();
                    model.ISACTIVE = 1;
                    int id = crmModels.KH_LXR.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "客户联系人的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //拜访频次
                #region
                for (int i = 0; i < data9.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data9.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_BF bfmodel = new CRM_KH_BF();
                    bfmodel.DUTYID = 5;
                    bfmodel.BFZQ = crmModels.HG_DICT.ReadByDICNAME(data9.Rows[i]["拜访周期"].ToString(), 26, token);
                    bfmodel.BFCS = Convert.ToInt32(data9.Rows[i]["拜访次数"].ToString());
                    bfmodel.ISACTIVE = 1;
                    int pinci = crmModels.KH_BF.Read(bfmodel, token)[0].BFID;

                    CRM_KH_KHBFList model = new CRM_KH_KHBFList();
                    model.KHID = khid;
                    model.BFID = pinci;
                    int id = crmModels.KH_KHBF.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "拜访频次的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //送货数量
                #region
                for (int i = 0; i < data10.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data10.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHXS model = new CRM_KH_KHXS();
                    model.KHID = khid;
                    model.XSLB = 1;
                    model.XSMC = data10.Rows[i]["送货次数"].ToString();
                    model.XSSL = Convert.ToInt32(data10.Rows[i]["送货数量"].ToString());
                    model.GSRQ = Convert.ToDateTime(data10.Rows[i]["送货日期"].ToString()).ToString("yyyy-MM-dd");
                    model.BEIZ = data10.Rows[i]["备注"].ToString();
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    int id = crmModels.KH_KHXS.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "送货数量的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //直销商销售
                #region
                for (int i = 0; i < data11.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data11.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHXS model = new CRM_KH_KHXS();
                    model.KHID = khid;
                    model.XSLB = 2;
                    model.XSMC = data11.Rows[i]["销售类别"].ToString();
                    model.XSJE = Convert.ToDouble(data11.Rows[i]["销售额(万元)"].ToString());
                    model.GSRQ = data11.Rows[i]["年份"].ToString();
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    int id = crmModels.KH_KHXS.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "直销商销售的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //网点数量
                #region
                for (int i = 0; i < data12.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data12.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHXS model = new CRM_KH_KHXS();
                    model.KHID = khid;
                    model.XSLB = 3;
                    model.XSMC = data12.Rows[i]["信息类别"].ToString();
                    model.XSSL = Convert.ToInt32(data12.Rows[i]["数量"].ToString());
                    model.GSRQ = data12.Rows[i]["年份"].ToString();
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    int id = crmModels.KH_KHXS.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "网点数量的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //车牌
                #region
                for (int i = 0; i < data13.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data13.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 6;
                    model.XXMC = data13.Rows[i]["车牌"].ToString();
                    model.PD = (data13.Rows[i]["是否有车体广告"].ToString() == "有") ? 1 : 2;
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    int id = crmModels.KH_KHQTXX.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "车牌的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //促销单品
                #region
                for (int i = 0; i < data14.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data14.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 7;
                    model.XXMC = data14.Rows[i]["单品名称"].ToString();
                    model.PD = (data14.Rows[i]["是否与LKA渠道重叠"].ToString() == "是") ? 1 : 2;
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    int id = crmModels.KH_KHQTXX.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "促销单品的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //签到地址
                #region
                for (int i = 0; i < data15.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data15.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;


                    string key = System.Configuration.ConfigurationManager.AppSettings["TXmapKey"];
                    string url = "http://apis.map.qq.com/ws/geocoder/v1/?address=" + data15.Rows[i]["地址"].ToString() + "&key=" + key;
                    Thread.Sleep(201);      //因为腾讯的接口的调用冷却为200毫秒
                    string json = GetJson(url);
                    TXcode.TXzcode DZmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<TXcode.TXzcode>(json);
                    if (DZmodel.message == "查询无结果")
                    {
                        msg.Msg = "签到地址的第" + (i + 2) + "行地址无法识别，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }



                    CRM_KH_DZ model = new CRM_KH_DZ();
                    model.KHID = khid;
                    model.DZMS = data15.Rows[i]["地址"].ToString();
                    model.ED = DZmodel.result.location.lat.ToString();
                    model.JD = DZmodel.result.location.lng.ToString();
                    model.ISACTIVE = 1;

                    model.DWDZMS = DZmodel.result.title;
                    if (DZmodel.result.title.IndexOf(DZmodel.result.address_components.district) < 0)
                    {
                        model.DWDZMS = DZmodel.result.address_components.district + model.DWDZMS;
                    }



                    model.GJ = 0;
                    model.DZRC = crmModels.SYS_CS.Read(3, token)[0].CS;
                    int province = crmModels.HG_DICT.ReadByDICNAME(DZmodel.result.address_components.province, 1, token);
                    int city = crmModels.HG_DICT.ReadByDICNAME(DZmodel.result.address_components.city, 2, token);
                    if (province == 0 || city == 0)
                    {
                        msg.Msg = "签到地址的第" + (i + 2) + "行地址的省份或城市不在系统中，请记录当前报错信息并联系管理员";
                    }
                    model.SF = province;
                    model.CS = city;



                    int id = crmModels.KH_DZ.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "签到地址的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //直销人员
                #region
                for (int i = 0; i < data16.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data16.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_LXR model = new CRM_KH_LXR();
                    model.KHID = khid;
                    model.LB = 1082;
                    model.LXR = data16.Rows[i]["联系人"].ToString();
                    model.YDDH = data16.Rows[i]["联系方式"].ToString();
                    model.BEIZ = data16.Rows[i]["工作内容"].ToString();
                    model.ISACTIVE = 1;
                    int id = crmModels.KH_LXR.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "直销人员的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //活动
                #region
                for (int i = 0; i < data17.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data17.Rows[i]["CRM编号"].ToString(), token);
                    int khid = kh_model.KHID;
                    if (khid == 0)
                        continue;

                    CRM_KH_HD model = new CRM_KH_HD();
                    model.KHID = khid;
                    model.HDMC = crmModels.HG_DICT.ReadByDICNAME(data17.Rows[i]["活动名称"].ToString(), 46, token);
                    if (data17.Rows[i]["活动名称"].ToString() != "无")
                    {
                        model.CPLX = crmModels.HG_DICT.ReadByDICNAME(data17.Rows[i]["产品类型"].ToString(), 45, token);
                        model.XL = data17.Rows[i]["销量"].ToString();
                    }
                    else
                    {
                        model.CPLX = 0;
                        model.XL = "";
                    }

                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    int id = crmModels.KH_HD.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "活动的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion




                msg.Msg = "新增成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.Msg = "文件读取失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }



        }


        /// <summary>
        /// 批量修改客户其他数据
        /// </summary>
        /// <returns></returns>
        public string Data_DaoRu_QT_Update()
        {
            token = appClass.CRM_Gettoken();

            var file = Request.Files[0];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;

            string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
            if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
            {
                Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
            }
            file.SaveAs(savePath);
            FileInfo fi = new FileInfo(savePath);

            DaoRuMsg msg = new DaoRuMsg();
            if (fi.Exists == true)
            {
                string[] sheet = { "渠道", "销售品种", "竞品", "管辖区域", "陈列", "客户分组", "邮寄地址", "客户联系人", "拜访频次", "送货数量", "直销商销售", "网点数量", "车牌", "促销单品", "签到地址", "直销人员", "活动" };


                //开始数据校验
                DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //渠道
                #region
                if (data1 != null)
                {
                    if (data1.Columns.Contains("id") == false || data1.Columns.Contains("CRM编号") == false || data1.Columns.Contains("渠道") == false)
                    {
                        msg.Msg = "请使用官方指定的修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data1.Rows.Count > 0)
                        {
                            for (int i = 0; i < data1.Rows.Count; i++)
                            {
                                if (data1.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data1.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data1.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "渠道第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int qudao = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["渠道"].ToString(), 7, token);
                                if (qudao == 0)
                                {
                                    msg.Msg = "渠道第" + (i + 2) + "行渠道不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data1.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "渠道第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data2 = ExcelToDataTable(savePath, sheet[1], true);      //销售品种
                #region
                if (data2 != null)
                {
                    if (data2.Columns.Contains("id") == false || data2.Columns.Contains("CRM编号") == false || data2.Columns.Contains("销售品种") == false)
                    {
                        msg.Msg = "请使用官方指定的修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data2.Rows.Count > 0)
                        {
                            for (int i = 0; i < data2.Rows.Count; i++)
                            {
                                if (data2.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data2.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data2.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "销售品种第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int pinzhong = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["销售品种"].ToString(), 8, token);
                                if (pinzhong == 0)
                                {
                                    msg.Msg = "销售品种第" + (i + 2) + "行销售品种不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data2.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data2.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "销售品种第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data3 = ExcelToDataTable(savePath, sheet[2], true);      //竞品
                #region
                if (data3 != null)
                {
                    if (data3.Columns.Contains("id") == false || data3.Columns.Contains("CRM编号") == false || data3.Columns.Contains("竞品") == false)
                    {
                        msg.Msg = "请使用官方指定的修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data3.Rows.Count > 0)
                        {
                            for (int i = 0; i < data3.Rows.Count; i++)
                            {
                                if (data3.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data3.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data3.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "竞品第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int pinzhong = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["竞品"].ToString(), 10, token);
                                if (pinzhong == 0)
                                {
                                    msg.Msg = "竞品第" + (i + 2) + "行竞品不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data3.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "竞品第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data4 = ExcelToDataTable(savePath, sheet[3], true);      //管辖区域
                #region
                if (data4 != null)
                {
                    if (data4.Columns.Contains("id") == false || data4.Columns.Contains("CRM编号") == false || data4.Columns.Contains("管辖区域类型") == false || data4.Columns.Contains("管辖区域名称") == false)
                    {
                        msg.Msg = "请使用官方指定的修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data4.Rows.Count > 0)
                        {
                            for (int i = 0; i < data4.Rows.Count; i++)
                            {
                                if (data4.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data4.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data4.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "管辖区域第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data4.Rows[i]["管辖区域类型"].ToString() != "全国" && data4.Rows[i]["管辖区域类型"].ToString() != "省份" && data4.Rows[i]["管辖区域类型"].ToString() != "城市")
                                {
                                    msg.Msg = "管辖区域第" + (i + 2) + "行管辖区域类型错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data4.Rows[i]["管辖区域类型"].ToString() == "省份")
                                {
                                    int area = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 1, token);
                                    if (area == 0)
                                    {
                                        msg.Msg = "管辖区域第" + (i + 2) + "行管辖区域不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                else if (data4.Rows[i]["管辖区域类型"].ToString() == "城市")
                                {
                                    int area = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 2, token);
                                    if (area == 0)
                                    {
                                        msg.Msg = "管辖区域第" + (i + 2) + "行管辖区域不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                else if (data4.Rows[i]["管辖区域类型"].ToString() == "县级")
                                {
                                    int area = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 34, token);
                                    if (area == 0)
                                    {
                                        msg.Msg = "管辖区域第" + (i + 2) + "行管辖区域不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }



                            }
                            for (int i = 0; i < data4.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data4.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "管辖区域第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data5 = ExcelToDataTable(savePath, sheet[4], true);      //陈列
                #region
                if (data5 != null)
                {
                    if (data5.Columns.Contains("id") == false || data5.Columns.Contains("CRM编号") == false || data5.Columns.Contains("陈列类型") == false || data5.Columns.Contains("陈列方式") == false || data5.Columns.Contains("陈列归属日期") == false)
                    {
                        msg.Msg = "请使用官方指定的修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data5.Rows.Count > 0)
                        {
                            for (int i = 0; i < data5.Rows.Count; i++)
                            {
                                if (data5.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data5.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data5.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "陈列第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data5.Rows[i]["陈列类型"].ToString() != "主陈列" && data5.Rows[i]["陈列类型"].ToString() != "二次陈列")
                                {
                                    msg.Msg = "陈列第" + (i + 2) + "行陈列类型错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int display = 0;
                                if (data5.Rows[i]["陈列类型"].ToString() == "主陈列")
                                {
                                    display = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["陈列方式"].ToString(), 9, token);
                                }
                                else if (data5.Rows[i]["陈列类型"].ToString() == "二次陈列")
                                {
                                    display = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["陈列方式"].ToString(), 23, token);
                                }

                                if (display == 0)
                                {
                                    msg.Msg = "陈列第" + (i + 2) + "行陈列不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data5.Rows[i]["陈列归属日期"].ToString() != "")
                                {
                                    try
                                    {
                                        DateTime myDT = Convert.ToDateTime(data5.Rows[i]["陈列归属日期"].ToString());

                                    }
                                    catch
                                    {
                                        msg.Msg = "陈列第" + (i + 2) + "行陈列归属日期格式错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data5.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data5.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "陈列第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data6 = ExcelToDataTable(savePath, sheet[5], true);      //分组
                #region
                if (data6 != null)
                {
                    if (data6.Columns.Contains("CRM编号") == false || data6.Columns.Contains("客户分组") == false)
                    {
                        msg.Msg = "请使用官方指定的修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data6.Rows.Count > 0)
                        {
                            for (int i = 0; i < data6.Rows.Count; i++)
                            {
                                if (data6.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data6.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data6.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "分组第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int group = crmModels.KH_GROUP.ReadGidByGNAME(data6.Rows[i]["客户分组"].ToString(), token);
                                if (group == 0)
                                {
                                    msg.Msg = "分组第" + (i + 2) + "行分组不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data6.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data6.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "分组第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data7 = ExcelToDataTable(savePath, sheet[6], true);      //邮寄地址
                #region
                if (data7 != null)
                {
                    if (data7.Columns.Contains("CRM编号") == false || data7.Columns.Contains("客户邮寄地址") == false || data7.Columns.Contains("邮编") == false || data7.Columns.Contains("收件人") == false || data7.Columns.Contains("收件人联系方式") == false)
                    {
                        msg.Msg = "请使用官方指定的修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data7.Rows.Count > 0)
                        {
                            for (int i = 0; i < data7.Rows.Count; i++)
                            {
                                if (data7.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data7.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data7.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "邮寄地址第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data7.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data7.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "邮寄地址第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data8 = ExcelToDataTable(savePath, sheet[7], true);      //客户联系人
                #region
                if (data8 != null)
                {
                    if (data8.Columns.Contains("CRM编号") == false || data8.Columns.Contains("联系人") == false || data8.Columns.Contains("性别") == false || data8.Columns.Contains("家庭地址") == false)
                    {
                        msg.Msg = "请使用官方指定的修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data8.Rows.Count > 0)
                        {
                            for (int i = 0; i < data8.Rows.Count; i++)
                            {
                                if (data8.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data8.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data8.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "客户联系人第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data8.Rows[i]["性别"].ToString() != "")
                                {
                                    if (data8.Rows[i]["性别"].ToString() != "男" && data8.Rows[i]["性别"].ToString() != "女")
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行性别错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data8.Rows[i]["民族"].ToString() != "")
                                {
                                    int minzu = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["民族"].ToString(), 11, token);
                                    if (minzu == 0)
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行民族不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data8.Rows[i]["职位"].ToString() != "")
                                {
                                    int zhiwei = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["职位"].ToString(), 12, token);
                                    if (zhiwei == 0)
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行职位不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data8.Rows[i]["婚姻状况"].ToString() != "")
                                {
                                    int hyzk = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["婚姻状况"].ToString(), 31, token);
                                    if (hyzk == 0)
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行婚姻状况不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data8.Rows[i]["生日"].ToString() != "")
                                {
                                    try
                                    {
                                        string[] date = data8.Rows[i]["生日"].ToString().Split('-');
                                        if (date.Length != 3 && date.Length != 2)
                                        {
                                            msg.Msg = "客户联系人第" + (i + 2) + "行生日格式错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (date.Length == 3)
                                        {
                                            int y = Convert.ToInt32(date[0]);
                                            int m = Convert.ToInt32(date[1]);
                                            int d = Convert.ToInt32(date[2]);
                                        }
                                        else if (date.Length == 2)
                                        {
                                            int m = Convert.ToInt32(date[0]);
                                            int d = Convert.ToInt32(date[1]);
                                        }

                                    }
                                    catch
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行生日格式错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data8.Rows[i]["是否主要联系人"].ToString() != "")
                                {
                                    if (data8.Rows[i]["是否主要联系人"].ToString().Trim() != "是" && data8.Rows[i]["是否主要联系人"].ToString().Trim() != "否")
                                    {
                                        msg.Msg = "客户联系人第" + (i + 2) + "行是否主要联系人错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }



                            }
                            for (int i = 0; i < data8.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data8.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "客户联系人第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data9 = ExcelToDataTable(savePath, sheet[8], true);      //拜访频次
                #region
                if (data9 != null)
                {
                    if (data9.Columns.Contains("CRM编号") == false || data9.Columns.Contains("拜访周期") == false)
                    {
                        msg.Msg = "请使用官方指定的修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data9.Rows.Count > 0)
                        {
                            for (int i = 0; i < data9.Rows.Count; i++)
                            {
                                if (data9.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data9.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data9.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "拜访频次第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int ZQ = crmModels.HG_DICT.ReadByDICNAME(data9.Rows[i]["拜访周期"].ToString(), 26, token);
                                if (ZQ == 0)
                                {
                                    msg.Msg = "拜访频次第" + (i + 2) + "行拜访周期单位不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                CRM_KH_BF bfmodel = new CRM_KH_BF();
                                bfmodel.DUTYID = 5;
                                bfmodel.BFZQ = crmModels.HG_DICT.ReadByDICNAME(data9.Rows[i]["拜访周期"].ToString(), 26, token);
                                bfmodel.BFCS = Convert.ToInt32(data9.Rows[i]["拜访次数"].ToString());
                                bfmodel.ISACTIVE = 1;
                                CRM_KH_BFList[] bfdata = crmModels.KH_BF.Read(bfmodel, token);
                                if (bfdata.Length == 0)
                                {
                                    msg.Msg = "拜访频次第" + (i + 2) + "行拜访周期数据不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data9.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data9.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "拜访频次第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data10 = ExcelToDataTable(savePath, sheet[9], true);      //送货数量
                #region
                if (data10 != null)
                {
                    if (data10.Columns.Contains("CRM编号") == false || data10.Columns.Contains("送货数量") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data10.Rows.Count > 0)
                        {
                            for (int i = 0; i < data10.Rows.Count; i++)
                            {
                                if (data10.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data10.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data10.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "送货数量第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data10.Rows[i]["送货日期"].ToString() != "")
                                {
                                    try
                                    {
                                        DateTime mtDT = Convert.ToDateTime(data10.Rows[i]["送货日期"].ToString());

                                    }
                                    catch
                                    {
                                        msg.Msg = "送货数量第" + (i + 2) + "行送货日期格式错误！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data10.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data10.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "送货数量第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data11 = ExcelToDataTable(savePath, sheet[10], true);      //直销商销售
                #region
                if (data11 != null)
                {
                    if (data11.Columns.Contains("CRM编号") == false || data11.Columns.Contains("销售类别") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data11.Rows.Count > 0)
                        {
                            for (int i = 0; i < data11.Rows.Count; i++)
                            {
                                if (data11.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data11.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data11.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "直销商销售第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int XSLB = crmModels.HG_DICT.ReadByDICNAME(data11.Rows[i]["销售类别"].ToString(), 36, token);
                                if (XSLB == 0)
                                {
                                    msg.Msg = "直销商销售第" + (i + 2) + "行销售类别不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data11.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data11.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直销商销售第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data12 = ExcelToDataTable(savePath, sheet[11], true);      //网点数量
                #region
                if (data12 != null)
                {
                    if (data12.Columns.Contains("CRM编号") == false || data12.Columns.Contains("信息类别") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data12.Rows.Count > 0)
                        {
                            for (int i = 0; i < data12.Rows.Count; i++)
                            {
                                if (data12.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data12.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data12.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "网点数量第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int XXLB = crmModels.HG_DICT.ReadByDICNAME(data12.Rows[i]["信息类别"].ToString(), 37, token);
                                if (XXLB == 0)
                                {
                                    msg.Msg = "网点数量第" + (i + 2) + "行信息类别不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data12.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data12.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "网点数量第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data13 = ExcelToDataTable(savePath, sheet[12], true);      //车牌
                #region
                if (data13 != null)
                {
                    if (data13.Columns.Contains("CRM编号") == false || data13.Columns.Contains("车牌") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data13.Rows.Count > 0)
                        {
                            for (int i = 0; i < data13.Rows.Count; i++)
                            {
                                if (data13.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data13.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data13.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "车牌第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data13.Rows[i]["是否有车体广告"].ToString() != "有" && data13.Rows[i]["是否有车体广告"].ToString() != "无")
                                {
                                    msg.Msg = "车牌第" + (i + 2) + "行是否有车体广告错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data13.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data13.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "车牌第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data14 = ExcelToDataTable(savePath, sheet[13], true);      //促销单品
                #region
                if (data14 != null)
                {
                    if (data14.Columns.Contains("CRM编号") == false || data14.Columns.Contains("单品名称") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data14.Rows.Count > 0)
                        {
                            for (int i = 0; i < data14.Rows.Count; i++)
                            {
                                if (data14.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data14.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data14.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "促销单品第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int DP = crmModels.HG_DICT.ReadByDICNAME(data14.Rows[i]["单品名称"].ToString(), 38, token);
                                if (DP == 0)
                                {
                                    msg.Msg = "促销单品第" + (i + 2) + "行单品名称不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data14.Rows[i]["是否与LKA渠道重叠"].ToString() != "是" && data14.Rows[i]["是否与LKA渠道重叠"].ToString() != "否")
                                {
                                    msg.Msg = "促销单品第" + (i + 2) + "行是否与LKA渠道重叠错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data14.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data14.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "促销单品第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data15 = ExcelToDataTable(savePath, sheet[14], true);      //签到地址
                #region
                if (data15 != null)
                {
                    if (data15.Columns.Contains("CRM编号") == false || data15.Columns.Contains("地址") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data15.Rows.Count > 0)
                        {
                            for (int i = 0; i < data15.Rows.Count; i++)
                            {
                                if (data15.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data15.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data15.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "签到地址第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data15.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data15.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "签到地址第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data16 = ExcelToDataTable(savePath, sheet[15], true);      //直销人员
                #region
                if (data16 != null)
                {
                    if (data16.Columns.Contains("CRM编号") == false || data16.Columns.Contains("联系人") == false || data16.Columns.Contains("联系方式") == false || data16.Columns.Contains("工作内容") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data16.Rows.Count > 0)
                        {
                            for (int i = 0; i < data16.Rows.Count; i++)
                            {
                                if (data16.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data16.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data16.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "直销人员第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data16.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data16.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直销人员第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion

                DataTable data17 = ExcelToDataTable(savePath, sheet[16], true);      //活动
                #region
                if (data17 != null)
                {
                    if (data17.Columns.Contains("CRM编号") == false || data17.Columns.Contains("活动名称") == false || data17.Columns.Contains("产品类型") == false)
                    {
                        msg.Msg = "请使用官方指定的新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        if (data17.Rows.Count > 0)
                        {
                            for (int i = 0; i < data17.Rows.Count; i++)
                            {
                                if (data17.Rows[i]["CRM编号"].ToString() == "" || Regex.IsMatch(data17.Rows[i]["CRM编号"].ToString(), @"^\d+$") == false || data17.Rows[i]["CRM编号"].ToString().Length != 8)
                                {
                                    msg.Msg = "活动第" + (i + 2) + "行CRM编号错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int HDMC = crmModels.HG_DICT.ReadByDICNAME(data17.Rows[i]["活动名称"].ToString(), 46, token);
                                if (HDMC == 0)
                                {
                                    msg.Msg = "活动第" + (i + 2) + "行活动名称不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data17.Rows[i]["活动名称"].ToString() != "无")
                                {
                                    int CPLX = crmModels.HG_DICT.ReadByDICNAME(data17.Rows[i]["产品类型"].ToString(), 45, token);
                                    if (CPLX == 0)
                                    {
                                        msg.Msg = "活动第" + (i + 2) + "行产品类型不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                    if (data17.Rows[i]["销量"].ToString() == "")
                                    {
                                        msg.Msg = "活动第" + (i + 2) + "行销量不可为空！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data17.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data17.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "活动第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }

                        }

                    }
                }
                #endregion


                //开始写入数据库

                int khid = 0;
                //渠道
                #region
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["CRM编号"].ToString(), token);

                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;
                    //if (khid != kh_model.KHID)          //当客户与上一行不同的时候
                    //{
                    //    khid = kh_model.KHID;
                    //    crmModels.KH_KHQTXX.DeleteByKHID_XXLB(khid, 1, token);
                    //}

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 1;
                    model.XXMC = data1.Rows[i]["渠道"].ToString();
                    model.ISACTIVE = 1;

                    try
                    {
                        int del = crmModels.KH_KHQTXX.Delete(Convert.ToInt32(data1.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_KHQTXX.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改渠道的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改渠道的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }


                }
                #endregion

                //销售品种
                #region
                khid = 0;
                for (int i = 0; i < data2.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data2.Rows[i]["CRM编号"].ToString(), token);

                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;
                    //if (khid != kh_model.KHID)          //当客户与上一行不同的时候
                    //{
                    //    khid = kh_model.KHID;
                    //    crmModels.KH_KHQTXX.DeleteByKHID_XXLB(khid, 2, token);
                    //}

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 2;
                    model.XXMC = data2.Rows[i]["销售品种"].ToString();
                    model.ISACTIVE = 1;
                    try
                    {
                        int del = crmModels.KH_KHQTXX.Delete(Convert.ToInt32(data2.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_KHQTXX.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改销售品种的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改销售品种的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //竞品
                #region
                khid = 0;
                for (int i = 0; i < data3.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["CRM编号"].ToString(), token);

                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;
                    //if (khid != kh_model.KHID)          //当客户与上一行不同的时候
                    //{
                    //    khid = kh_model.KHID;
                    //    crmModels.KH_KHQTXX.DeleteByKHID_XXLB(khid, 3, token);
                    //}

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 3;
                    model.XXMC = data3.Rows[i]["竞品"].ToString();
                    model.ISACTIVE = 1;

                    try
                    {
                        int del = crmModels.KH_KHQTXX.Delete(Convert.ToInt32(data3.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_KHQTXX.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改竞品的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改竞品的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //管辖区域
                #region
                khid = 0;
                for (int i = 0; i < data4.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data4.Rows[i]["CRM编号"].ToString(), token);

                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;
                    //if (khid != kh_model.KHID)          //当客户与上一行不同的时候
                    //{
                    //    khid = kh_model.KHID;
                    //    crmModels.KH_GXQY.DeleteByKHID(khid, token);
                    //}

                    CRM_KH_GXQY model = new CRM_KH_GXQY();

                    model.KHID = khid;
                    switch (data4.Rows[i]["管辖区域类型"].ToString())
                    {
                        case "全国":
                            model.GXQYLX = 1;
                            model.GXQYMC = 0;
                            break;
                        case "省份":
                            model.GXQYLX = 2;
                            model.GXQYMC = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 1, token);
                            break;
                        case "城市":
                            model.GXQYLX = 3;
                            model.GXQYMC = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 2, token);
                            break;
                        case "县级":
                            model.GXQYLX = 4;
                            model.GXQYMC = crmModels.HG_DICT.ReadByDICNAME(data4.Rows[i]["管辖区域名称"].ToString(), 34, token);
                            break;
                        default:
                            break;
                    }
                    model.ISACTIVE = 1;
                    model.BEIZ = data4.Rows[i]["备注"].ToString();

                    try
                    {
                        int del = crmModels.KH_GXQY.Delete(Convert.ToInt32(data4.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_GXQY.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改管辖区域的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改管辖区域的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //陈列
                #region
                khid = 0;
                for (int i = 0; i < data5.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data5.Rows[i]["CRM编号"].ToString(), token);

                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;
                    //if (khid != kh_model.KHID)          //当客户与上一行不同的时候
                    //{
                    //    khid = kh_model.KHID;
                    //    crmModels.KH_KHQTXX.DeleteByKHID_XXLB(khid, 4, token);
                    //}

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();

                    model.KHID = khid;
                    model.XXLB = 4;
                    switch (data5.Rows[i]["陈列类型"].ToString())
                    {
                        case "主陈列":
                            model.CLLX = 1;
                            model.CLFS = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["陈列方式"].ToString(), 9, token);
                            break;
                        case "二次陈列":
                            model.CLLX = 2;
                            model.CLFS = crmModels.HG_DICT.ReadByDICNAME(data5.Rows[i]["陈列方式"].ToString(), 23, token);
                            break;
                        default:
                            break;
                    }

                    model.CLGSRQ = data5.Rows[i]["陈列归属日期"].ToString();
                    model.ISACTIVE = 1;
                    model.BEIZ = data5.Rows[i]["备注"].ToString();
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);

                    try
                    {
                        int del = crmModels.KH_KHQTXX.Delete(Convert.ToInt32(data5.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_KHQTXX.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改陈列的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改陈列的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //分组
                #region
                int now_khid = 0;
                for (int i = 0; i < data6.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data6.Rows[i]["CRM编号"].ToString(), token);
                    khid = kh_model.KHID;
                    if (kh_model.KHID == 0)
                        continue;
                    if (i == 0 || now_khid != khid)
                    {
                        now_khid = khid;
                        crmModels.KH_GROUP_KH.DeletebyKHID(khid, token);          //每次遇到与上一行不同的khid就删除该客户与分组的关联
                    }


                    int gid = crmModels.KH_GROUP.ReadGidByGNAME(data6.Rows[i]["客户分组"].ToString(), token);

                    int id = crmModels.KH_GROUP_KH.Create(khid, gid, token);
                    if (id <= 0)
                    {
                        msg.Msg = "修改分组的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //邮寄地址
                #region
                khid = 0;
                for (int i = 0; i < data7.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data7.Rows[i]["CRM编号"].ToString(), token);

                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;
                    //if (khid != kh_model.KHID)          //当客户与上一行不同的时候
                    //{
                    //    khid = kh_model.KHID;
                    //    crmModels.KH_KHQTXX.DeleteByKHID_XXLB(khid, 5, token);
                    //}

                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 5;
                    model.KHYJDZ = data7.Rows[i]["客户邮寄地址"].ToString();
                    model.YB = data7.Rows[i]["邮编"].ToString();
                    model.SJR = data7.Rows[i]["收件人"].ToString();
                    model.SJRLXFS = data7.Rows[i]["收件人联系方式"].ToString();
                    model.ISACTIVE = 1;
                    model.BEIZ = data7.Rows[i]["备注"].ToString();

                    try
                    {
                        int del = crmModels.KH_KHQTXX.Delete(Convert.ToInt32(data7.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_KHQTXX.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改邮寄地址的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改邮寄地址的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //客户联系人
                #region
                khid = 0;
                for (int i = 0; i < data8.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data8.Rows[i]["CRM编号"].ToString(), token);

                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;
                    //if (khid != kh_model.KHID)          //当客户与上一行不同的时候
                    //{
                    //    khid = kh_model.KHID;
                    //    crmModels.KH_LXR.DeleteByKHID(khid, token);
                    //}

                    CRM_KH_LXR model = new CRM_KH_LXR();
                    model.KHID = khid;
                    model.LXR = data8.Rows[i]["联系人"].ToString();
                    model.SEX = data8.Rows[i]["性别"].ToString();
                    model.JTDZ = data8.Rows[i]["家庭地址"].ToString();
                    model.JG = data8.Rows[i]["籍贯"].ToString();
                    model.MZ = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["民族"].ToString(), 11, token);
                    model.ZW = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["职位"].ToString(), 12, token);
                    model.AH = data8.Rows[i]["爱好"].ToString();
                    model.HYZK = crmModels.HG_DICT.ReadByDICNAME(data8.Rows[i]["婚姻状况"].ToString(), 31, token);
                    model.YDDH = data8.Rows[i]["移动电话"].ToString();
                    model.GDDH = data8.Rows[i]["固定电话"].ToString();
                    model.TEL = data8.Rows[i]["传真"].ToString();
                    model.EMAIL = data8.Rows[i]["邮箱"].ToString();
                    model.WXH = data8.Rows[i]["微信号"].ToString();
                    model.SR = data8.Rows[i]["生日"].ToString();
                    model.TXDZ = data8.Rows[i]["通信地址"].ToString();
                    model.YZBM = data8.Rows[i]["邮政编码"].ToString();
                    model.XGMS = data8.Rows[i]["性格描述"].ToString();
                    if (data8.Rows[i]["是否主要联系人"].ToString() == "是")
                        model.SFZYLXR = 1;
                    else
                        model.SFZYLXR = 0;
                    model.BEIZ = data8.Rows[i]["备注"].ToString();
                    model.ISACTIVE = 1;

                    try
                    {
                        int del = crmModels.KH_LXR.Delete(Convert.ToInt32(data8.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_LXR.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改客户联系人的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改客户联系人的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //拜访频次
                #region
                now_khid = 0;
                for (int i = 0; i < data9.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data9.Rows[i]["CRM编号"].ToString(), token);
                    khid = kh_model.KHID;
                    if (kh_model.KHID == 0)
                        continue;
                    if (i == 0 || now_khid != khid)
                    {
                        now_khid = khid;
                        CRM_KH_KHBFList deldate = new CRM_KH_KHBFList();
                        deldate.KHID = khid;
                        deldate.BFID = 0;
                        crmModels.KH_KHBF.Delete(deldate, token);          //每次遇到与上一行不同的khid就删除该客户与拜访频次的关联
                    }


                    CRM_KH_BF bfmodel = new CRM_KH_BF();
                    bfmodel.DUTYID = 5;
                    bfmodel.BFZQ = crmModels.HG_DICT.ReadByDICNAME(data9.Rows[i]["拜访周期"].ToString(), 26, token);
                    bfmodel.BFCS = Convert.ToInt32(data9.Rows[i]["拜访次数"].ToString());
                    bfmodel.ISACTIVE = 1;
                    int pinci = crmModels.KH_BF.Read(bfmodel, token)[0].BFID;

                    CRM_KH_KHBFList model = new CRM_KH_KHBFList();
                    model.KHID = khid;
                    model.BFID = pinci;
                    int id = crmModels.KH_KHBF.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "修改拜访频次的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion

                //送货数量
                #region
                for (int i = 0; i < data10.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data10.Rows[i]["CRM编号"].ToString(), token);

                    if (khid == 0)
                        continue;
                    else
                        khid = kh_model.KHID;

                    CRM_KH_KHXS model = new CRM_KH_KHXS();
                    model.KHID = khid;
                    model.XSLB = 1;
                    model.XSMC = data10.Rows[i]["送货次数"].ToString();
                    model.XSSL = Convert.ToInt32(data10.Rows[i]["送货数量"].ToString());
                    model.GSRQ = Convert.ToDateTime(data10.Rows[i]["送货日期"].ToString()).ToString("yyyy-MM-dd");
                    model.BEIZ = data10.Rows[i]["备注"].ToString();
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    try
                    {
                        CRM_KH_KHXS delmodel = new CRM_KH_KHXS();
                        delmodel.XSID = Convert.ToInt32(data10.Rows[i]["id"].ToString());
                        int del = crmModels.KH_KHXS.Delete(delmodel, token);
                        int id = crmModels.KH_KHXS.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改送货数量的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改送货数量的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //直销商销售
                #region
                for (int i = 0; i < data11.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data11.Rows[i]["CRM编号"].ToString(), token);

                    if (khid == 0)
                        continue;
                    else
                        khid = kh_model.KHID;

                    CRM_KH_KHXS model = new CRM_KH_KHXS();
                    model.KHID = khid;
                    model.XSLB = 2;
                    model.XSMC = data11.Rows[i]["销售类别"].ToString();
                    model.XSJE = Convert.ToDouble(data11.Rows[i]["销售额(万元)"].ToString());
                    model.GSRQ = data11.Rows[i]["年份"].ToString();
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    try
                    {
                        CRM_KH_KHXS delmodel = new CRM_KH_KHXS();
                        delmodel.XSID = Convert.ToInt32(data11.Rows[i]["id"].ToString());
                        int del = crmModels.KH_KHXS.Delete(delmodel, token);
                        int id = crmModels.KH_KHXS.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改直销商销售的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改直销商销售的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //网点数量
                #region
                for (int i = 0; i < data12.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data12.Rows[i]["CRM编号"].ToString(), token);

                    if (khid == 0)
                        continue;
                    else
                        khid = kh_model.KHID;

                    CRM_KH_KHXS model = new CRM_KH_KHXS();
                    model.KHID = khid;
                    model.XSLB = 3;
                    model.XSMC = data12.Rows[i]["信息类别"].ToString();
                    model.XSSL = Convert.ToInt32(data12.Rows[i]["数量"].ToString());
                    model.GSRQ = data12.Rows[i]["年份"].ToString();
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    try
                    {
                        CRM_KH_KHXS delmodel = new CRM_KH_KHXS();
                        delmodel.XSID = Convert.ToInt32(data11.Rows[i]["id"].ToString());
                        int del = crmModels.KH_KHXS.Delete(delmodel, token);
                        int id = crmModels.KH_KHXS.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "网点数量的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "网点数量的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //车牌
                #region
                for (int i = 0; i < data13.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data13.Rows[i]["CRM编号"].ToString(), token);

                    if (khid == 0)
                        continue;
                    else
                        khid = kh_model.KHID;
                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 6;
                    model.XXMC = data13.Rows[i]["车牌"].ToString();
                    model.PD = (data13.Rows[i]["是否有车体广告"].ToString() == "有") ? 1 : 2;
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    try
                    {
                        int del = crmModels.KH_KHQTXX.Delete(Convert.ToInt32(data13.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_KHQTXX.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "车牌的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "车牌的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //促销单品
                #region
                for (int i = 0; i < data14.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data14.Rows[i]["CRM编号"].ToString(), token);

                    if (khid == 0)
                        continue;
                    else
                        khid = kh_model.KHID;
                    CRM_KH_KHQTXX model = new CRM_KH_KHQTXX();
                    model.KHID = khid;
                    model.XXLB = 7;
                    model.XXMC = data14.Rows[i]["单品名称"].ToString();
                    model.PD = (data14.Rows[i]["是否与LKA渠道重叠"].ToString() == "是") ? 1 : 2;
                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    try
                    {
                        int del = crmModels.KH_KHQTXX.Delete(Convert.ToInt32(data14.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_KHQTXX.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "促销单品的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "促销单品的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //签到地址
                #region
                for (int i = 0; i < data15.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data15.Rows[i]["CRM编号"].ToString(), token);
                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;


                    string key = System.Configuration.ConfigurationManager.AppSettings["TXmapKey"];
                    string url = "http://apis.map.qq.com/ws/geocoder/v1/?address=" + data15.Rows[i]["地址"].ToString() + "&key=" + key;
                    Thread.Sleep(201);      //因为腾讯的接口的调用冷却为200毫秒
                    string json = GetJson(url);
                    TXcode.TXzcode DZmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<TXcode.TXzcode>(json);
                    if (DZmodel.message == "查询无结果")
                    {
                        msg.Msg = "签到地址的第" + (i + 2) + "行地址无法识别，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }



                    CRM_KH_DZ model = new CRM_KH_DZ();
                    model.KHID = khid;
                    model.DZMS = data15.Rows[i]["地址"].ToString();
                    model.ED = DZmodel.result.location.lat.ToString();
                    model.JD = DZmodel.result.location.lng.ToString();
                    model.ISACTIVE = 1;

                    model.DWDZMS = DZmodel.result.title;
                    if (DZmodel.result.title.IndexOf(DZmodel.result.address_components.district) < 0)
                    {
                        model.DWDZMS = DZmodel.result.address_components.district + model.DWDZMS;
                    }



                    model.GJ = 0;
                    model.DZRC = crmModels.SYS_CS.Read(3, token)[0].CS;
                    int province = crmModels.HG_DICT.ReadByDICNAME(DZmodel.result.address_components.province, 1, token);
                    int city = crmModels.HG_DICT.ReadByDICNAME(DZmodel.result.address_components.city, 2, token);
                    if (province == 0 || city == 0)
                    {
                        msg.Msg = "签到地址的第" + (i + 2) + "行地址的省份或城市不在系统中，请记录当前报错信息并联系管理员";
                    }
                    model.SF = province;
                    model.CS = city;

                    try
                    {
                        int del = crmModels.KH_DZ.Delete(Convert.ToInt32(data8.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_DZ.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改签到地址的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改签到地址的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion

                //直销人员
                #region
                for (int i = 0; i < data16.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data16.Rows[i]["CRM编号"].ToString(), token);
                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;

                    CRM_KH_LXR model = new CRM_KH_LXR();
                    model.KHID = khid;
                    model.LB = 1082;
                    model.LXR = data16.Rows[i]["联系人"].ToString();
                    model.YDDH = data16.Rows[i]["联系方式"].ToString();
                    model.BEIZ = data16.Rows[i]["工作内容"].ToString();
                    model.ISACTIVE = 1;

                    try
                    {
                        int del = crmModels.KH_LXR.Delete(Convert.ToInt32(data8.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_LXR.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改直销人员的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改直销人员的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }


                }
                #endregion

                //活动
                #region
                for (int i = 0; i < data17.Rows.Count; i++)
                {
                    CRM_KH_KH kh_model = new CRM_KH_KH();
                    kh_model = crmModels.KH_KH.ReadByCRMID(data17.Rows[i]["CRM编号"].ToString(), token);
                    if (kh_model.KHID == 0)
                        continue;
                    else
                        khid = kh_model.KHID;

                    CRM_KH_HD model = new CRM_KH_HD();
                    model.KHID = khid;
                    model.HDMC = crmModels.HG_DICT.ReadByDICNAME(data17.Rows[i]["活动名称"].ToString(), 46, token);
                    if (data17.Rows[i]["活动名称"].ToString() != "无")
                    {
                        model.CPLX = crmModels.HG_DICT.ReadByDICNAME(data17.Rows[i]["产品类型"].ToString(), 45, token);
                        model.XL = data17.Rows[i]["销量"].ToString();
                    }
                    else
                    {
                        model.CPLX = 0;
                        model.XL = "";
                    }

                    model.CZR = Convert.ToInt32(Session["STAFFID"]);
                    model.ISACTIVE = 1;

                    try
                    {
                        int del = crmModels.KH_HD.Delete(Convert.ToInt32(data8.Rows[i]["id"].ToString()), token);
                        int id = crmModels.KH_HD.Create(model, token);
                        if (id <= 0 || del <= 0)
                        {
                            msg.Msg = "修改客户联系人的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        msg.Msg = "修改客户联系人的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员：" + e.ToString();
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                #endregion


                msg.Msg = "修改成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.Msg = "文件读取失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }



        }




        public string Data_DaoRu_SFCS_Update()
        {
            token = appClass.CRM_Gettoken();

            var file = Request.Files[0];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;

            string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
            if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
            {
                Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
            }
            file.SaveAs(savePath);
            FileInfo fi = new FileInfo(savePath);

            DaoRuMsg msg = new DaoRuMsg();
            if (fi.Exists == true)
            {
                string[] sheet = { "经销商、电商、B2B", "直营卖场系统", "直营卖场门店", "终端网点", "LKA", "LKA门店", "中间商", "OEM" };


                DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //经销商、电商、B2B


                DataTable data2 = ExcelToDataTable(savePath, sheet[1], true);      //直营卖场系统
                #region
                if (data2 != null)
                {
                    if (data2.Columns.Contains("CRM编号") == false || data2.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data2.Rows.Count > 0)
                        {
                            for (int i = 0; i < data2.Rows.Count; i++)
                            {
                                if (data2.Rows[i]["省份"].ToString() != "")
                                {
                                    int province = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["省份"].ToString(), 1, token);
                                    if (province == 0)
                                    {
                                        msg.Msg = "直营卖场系统第" + (i + 2) + "行省份不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data2.Rows[i]["城市"].ToString() != "")
                                {
                                    int city = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["城市"].ToString(), 2, token);
                                    if (city == 0)
                                    {
                                        msg.Msg = "直营卖场系统第" + (i + 2) + "行城市不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data2.Rows[i]["县级市"].ToString() != "")
                                {
                                    int city = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["县级市"].ToString(), 34, token);
                                    if (city == 0)
                                    {
                                        msg.Msg = "直营卖场系统第" + (i + 2) + "行县级市不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data2.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data2.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直营卖场系统第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data2s = ExcelToDataTable(savePath, sheet[2], true);      //直营卖场门店
                #region
                if (data2s != null)
                {
                    if (data2s.Columns.Contains("CRM编号") == false || data2s.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data2s.Rows.Count > 0)
                        {
                            for (int i = 0; i < data2s.Rows.Count; i++)
                            {
                                if (data2s.Rows[i]["省份"].ToString() != "")
                                {
                                    int province = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["省份"].ToString(), 1, token);
                                    if (province == 0)
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行省份不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data2s.Rows[i]["城市"].ToString() != "")
                                {
                                    int city = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["城市"].ToString(), 2, token);
                                    if (city == 0)
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行城市不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }
                                if (data2s.Rows[i]["县级市"].ToString() != "")
                                {
                                    int city = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["县级市"].ToString(), 34, token);
                                    if (city == 0)
                                    {
                                        msg.Msg = "直营卖场门店第" + (i + 2) + "行县级市不存在！";
                                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                    }
                                }

                            }
                            for (int i = 0; i < data2s.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data2s.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data3 = ExcelToDataTable(savePath, sheet[3], true);      //终端网点
                #region
                if (data3 != null)
                {
                    if (data3.Columns.Contains("CRM编号") == false || data3.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用客户修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data3.Rows.Count > 0)
                        {
                            for (int i = 0; i < data3.Rows.Count; i++)
                            {
                                int province = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["省份"].ToString(), 1, token);
                                if (province == 0)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行省份不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int city = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["城市"].ToString(), 2, token);
                                if (city == 0)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行城市不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int county = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["县级市"].ToString(), 34, token);
                                if (county == 0)
                                {
                                    msg.Msg = "终端网点第" + (i + 2) + "行县级市不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                            }
                            for (int i = 0; i < data3.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直营卖场门店第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data4 = ExcelToDataTable(savePath, sheet[4], true);      //LKA


                DataTable data5 = ExcelToDataTable(savePath, sheet[5], true);      //LKA门店


                DataTable data6 = ExcelToDataTable(savePath, sheet[6], true);      //中间商
                #region
                if (data6 != null)
                {
                    if (data6.Columns.Contains("CRM编号") == false || data6.Columns.Contains("SAP编号") == false)
                    {
                        msg.Msg = "请使用修改客户模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data6.Rows.Count > 0)
                        {
                            for (int i = 0; i < data6.Rows.Count; i++)
                            {
                                int province = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["省份"].ToString(), 1, token);
                                if (province == 0)
                                {
                                    msg.Msg = "直销商第" + (i + 2) + "行省份不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int city = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["城市"].ToString(), 2, token);
                                if (city == 0)
                                {
                                    msg.Msg = "直销商第" + (i + 2) + "行城市不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int county = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["县级市"].ToString(), 34, token);
                                if (county == 0)
                                {
                                    msg.Msg = "直销商第" + (i + 2) + "行县级市不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                            for (int i = 0; i < data6.Rows.Count; i++)
                            {
                                CRM_KH_KH kh_model = new CRM_KH_KH();
                                kh_model = crmModels.KH_KH.ReadByCRMID(data6.Rows[i]["CRM编号"].ToString(), token);
                                if (kh_model.KHID == 0)
                                {
                                    msg.Msg = "直销商第" + (i + 2) + "行CRM编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }

                    }
                }
                #endregion

                DataTable data7 = ExcelToDataTable(savePath, sheet[7], true);      //OEM




                //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                #region

                //直营卖场系统
                for (int i = 0; i < data2.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data2.Rows[i]["CRM编号"].ToString(), token);

                    model.SF = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["省份"].ToString(), 1, token);
                    model.CS = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["城市"].ToString(), 2, token);
                    if (data2.Rows[i]["县级市"].ToString() != "")
                    {
                        model.COUNTY = crmModels.HG_DICT.ReadByDICNAME(data2.Rows[i]["县级市"].ToString(), 34, token);
                    }
                    else
                    {
                        model.COUNTY = 0;
                    }

                    int id = crmModels.KH_KH.UpdateSFCS(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "修改直营卖场的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    #endregion
                }
                //直营卖场门店
                for (int i = 0; i < data2s.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data2s.Rows[i]["CRM编号"].ToString(), token);

                    model.SF = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["省份"].ToString(), 1, token);
                    model.CS = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["城市"].ToString(), 2, token);
                    if (data2s.Rows[i]["县级市"].ToString() != "")
                    {
                        model.COUNTY = crmModels.HG_DICT.ReadByDICNAME(data2s.Rows[i]["县级市"].ToString(), 34, token);
                    }
                    else
                    {
                        model.COUNTY = 0;
                    }

                    int id = crmModels.KH_KH.UpdateSFCS(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "修改直营卖场门店的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    #endregion
                }
                //终端网点
                for (int i = 0; i < data3.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["CRM编号"].ToString(), token);

                    model.SF = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["省份"].ToString(), 1, token);
                    model.CS = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["城市"].ToString(), 2, token);
                    if (data3.Rows[i]["县级市"].ToString() != "")
                    {
                        model.COUNTY = crmModels.HG_DICT.ReadByDICNAME(data3.Rows[i]["县级市"].ToString(), 34, token);
                    }
                    else
                    {
                        model.COUNTY = 0;
                    }

                    int id = crmModels.KH_KH.UpdateSFCS(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "修改终端网点的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }



                    #endregion
                }

                //中间商
                for (int i = 0; i < data6.Rows.Count; i++)
                {
                    #region
                    CRM_KH_KH model = crmModels.KH_KH.ReadByCRMID(data6.Rows[i]["CRM编号"].ToString(), token);

                    model.SF = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["省份"].ToString(), 1, token);
                    model.CS = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["城市"].ToString(), 2, token);
                    if (data6.Rows[i]["县级市"].ToString() != "")
                    {
                        model.COUNTY = crmModels.HG_DICT.ReadByDICNAME(data6.Rows[i]["县级市"].ToString(), 34, token);
                    }
                    else
                    {
                        model.COUNTY = 0;
                    }

                    int id = crmModels.KH_KH.UpdateSFCS(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "修改中间商的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                    #endregion
                }

                #endregion

                msg.Msg = "修改成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.Msg = "文件读取失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

        }

        public DataTable ExcelToDataTable(string fileName, string sheetName, bool isFirstRowColumn)
        {
            FileStream fs = null;
            ISheet sheet = null;
            IWorkbook workbook = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是""　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            //if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是""
                                //dataRow[j] = row.GetCell(j).ToString();
                            ICell cell = row.GetCell(j);

                            if (cell != null)
                            {
                                string cellValue = "";
                                if (cell.CellType == CellType.Numeric)
                                {
                                    short format = cell.CellStyle.DataFormat;
                                    if (format == 14)
                                    {
                                        cellValue = cell.DateCellValue.ToString("yyyy-MM-dd");
                                    }
                                    else
                                    {
                                        cellValue = row.GetCell(j).ToString();
                                    }
                                }
                                else
                                {
                                    cellValue = row.GetCell(j).ToString();
                                }
                                dataRow[j] = cellValue;
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 导出客户主数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public string Data_FileUpload_KeHu_DaoChu(string data)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                CRM_KH_KHList[] model = JsonConvert.DeserializeObject<CRM_KH_KHList[]>(data);


                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/修改客户模版.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("经销商、电商、B2B");
                ISheet worksheet2 = workbook.GetSheet("直营卖场系统");
                ISheet worksheet2s = workbook.GetSheet("直营卖场门店");
                ISheet worksheet3 = workbook.GetSheet("终端网点");
                ISheet worksheet4 = workbook.GetSheet("LKA");
                ISheet worksheet5 = workbook.GetSheet("LKA门店");
                ISheet worksheet6 = workbook.GetSheet("中间商");
                ISheet worksheet7 = workbook.GetSheet("OEM");
                if (worksheet1 == null || worksheet2 == null || worksheet2s == null || worksheet3 == null || worksheet4 == null || worksheet5 == null || worksheet6 == null || worksheet7 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 1, row2 = 1, row2s = 1, row3 = 1, row4 = 1, row5 = 1, row6 = 1, row7 = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    if (model[i].KHLX == 1 || model[i].KHLX == 2 || model[i].KHLX == 4)     //经销商电商B2B
                    {
                        #region
                        NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                        switch (model[i].IsOfficial)
                        {
                            case 10:
                                row.CreateCell(0).SetCellValue("潜在客户");
                                break;
                            case 20:
                                row.CreateCell(0).SetCellValue("签约客户");
                                break;
                            case 30:
                                row.CreateCell(0).SetCellValue("非签约客户");
                                break;
                            default:
                                row.CreateCell(0).SetCellValue("");
                                break;
                        }
                        row.CreateCell(1).SetCellValue(model[i].CRMID);
                        row.CreateCell(2).SetCellValue(model[i].SAPSN);
                        row.CreateCell(3).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].KHLX, token).DICNAME);
                        row.CreateCell(4).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].KHLX2, token).DICNAME);
                        row.CreateCell(5).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].MCLC, token).DICNAME);
                        row.CreateCell(6).SetCellValue(model[i].MC);
                        row.CreateCell(7).SetCellValue(model[i].PKHID);
                        row.CreateCell(8).SetCellValue(model[i].PKHIDDES);
                        row.CreateCell(9).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].KPXZ, token).DICNAME);
                        row.CreateCell(10).SetCellValue(model[i].NSRSBH);
                        row.CreateCell(11).SetCellValue(model[i].KPDZ);
                        row.CreateCell(12).SetCellValue(model[i].KPDH);
                        row.CreateCell(13).SetCellValue(model[i].YHZH);
                        row.CreateCell(14).SetCellValue(model[i].YHMC);
                        row.CreateCell(15).SetCellValue(model[i].GSLXR);
                        row.CreateCell(16).SetCellValue(model[i].GSLXDH);
                        row.CreateCell(17).SetCellValue(model[i].FR);
                        row.CreateCell(18).SetCellValue(model[i].GSFRGX);
                        row.CreateCell(19).SetCellValue(model[i].KDJSDZ);
                        row.CreateCell(20).SetCellValue(model[i].KDLXR);
                        row.CreateCell(21).SetCellValue(model[i].KDLXDH);
                        row.CreateCell(22).SetCellValue(model[i].KHSOURCEDES);
                        row.CreateCell(23).SetCellValue(model[i].KHLX2 == 1064 ? "是" : "否");
                        row.CreateCell(24).SetCellValue(model[i].HTXSRW);
                        row.CreateCell(25).SetCellValue(model[i].HTJXXSRW);
                        row.CreateCell(26).SetCellValue(model[i].FIRSTAMOUNT);
                        row.CreateCell(27).SetCellValue(model[i].JOINACTIVITY == 1 ? "是" : "否");
                        row.CreateCell(28).SetCellValue(model[i].XSSJSM);
                        row.CreateCell(29).SetCellValue(model[i].FLSJSM);
                        switch (model[i].SFCCJ)
                        {
                            case true:
                                row.CreateCell(30).SetCellValue("是");
                                break;
                            case false:
                                row.CreateCell(30).SetCellValue("否");
                                break;
                            default:
                                row.CreateCell(30).SetCellValue("");
                                break;
                        }
                        row.CreateCell(31).SetCellValue(model[i].SFCCJSM);
                        row.CreateCell(32).SetCellValue(model[i].KHSHDZ);
                        row.CreateCell(33).SetCellValue(model[i].KHSHLXR);
                        row.CreateCell(34).SetCellValue(model[i].KHSHLXDH);
                        row.CreateCell(35).SetCellValue(model[i].TSQKSM);
                        switch (model[i].JXSYX)
                        {
                            case true:
                                row.CreateCell(36).SetCellValue("是");
                                break;
                            case false:
                                row.CreateCell(36).SetCellValue("否");
                                break;
                            default:
                                row.CreateCell(36).SetCellValue("");
                                break;
                        }
                        row.CreateCell(37).SetCellValue(model[i].YXSM);

                        row1++;
                        #endregion
                    }
                    else if (model[i].KHLX == 3)                           //直营卖场系统
                    {
                        if (model[i].MCSX == 1)
                        {
                            #region
                            NPOI.SS.UserModel.IRow row = worksheet2.CreateRow(row2);
                            switch (model[i].IsOfficial)
                            {
                                case 10:
                                    row.CreateCell(0).SetCellValue("潜在客户");
                                    break;
                                case 20:
                                    row.CreateCell(0).SetCellValue("签约客户");
                                    break;
                                case 30:
                                    row.CreateCell(0).SetCellValue("非签约客户");
                                    break;
                                default:
                                    row.CreateCell(0).SetCellValue("");
                                    break;
                            }
                            row.CreateCell(1).SetCellValue(model[i].CRMID);
                            row.CreateCell(2).SetCellValue(model[i].SAPSN);
                            row.CreateCell(3).SetCellValue(model[i].MC);
                            row.CreateCell(4).SetCellValue(model[i].PKHID);
                            row.CreateCell(5).SetCellValue(model[i].PKHIDDES);
                            row.CreateCell(6).SetCellValue(model[i].SFDES);
                            row.CreateCell(7).SetCellValue(model[i].CSDES);
                            row.CreateCell(8).SetCellValue(model[i].COUNTYDES);
                            row.CreateCell(9).SetCellValue(model[i].FKTJ);
                            row.CreateCell(10).SetCellValue(model[i].GSLXR);
                            row.CreateCell(11).SetCellValue(model[i].GSLXDH);
                            row.CreateCell(12).SetCellValue(model[i].KPDZ);
                            row.CreateCell(13).SetCellValue(model[i].KPDH);
                            row.CreateCell(14).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].KPXZ, token).DICNAME);
                            row.CreateCell(15).SetCellValue(model[i].YHZH);
                            row.CreateCell(16).SetCellValue(model[i].YHMC);
                            row.CreateCell(17).SetCellValue(model[i].NSRSBH);
                            row.CreateCell(18).SetCellValue(model[i].FR);
                            row.CreateCell(19).SetCellValue(model[i].KDJSDZ);
                            row.CreateCell(20).SetCellValue(model[i].KDLXR);
                            row.CreateCell(21).SetCellValue(model[i].KDLXDH);

                            row2++;
                            #endregion
                        }
                        else if (model[i].MCSX == 2)          //直营卖场门店
                        {
                            #region
                            NPOI.SS.UserModel.IRow row = worksheet2s.CreateRow(row2s);
                            switch (model[i].IsOfficial)
                            {
                                case 10:
                                    row.CreateCell(0).SetCellValue("潜在客户");
                                    break;
                                case 20:
                                    row.CreateCell(0).SetCellValue("签约客户");
                                    break;
                                case 30:
                                    row.CreateCell(0).SetCellValue("非签约客户");
                                    break;
                                default:
                                    row.CreateCell(0).SetCellValue("");
                                    break;
                            }
                            row.CreateCell(1).SetCellValue(model[i].CRMID);
                            row.CreateCell(2).SetCellValue(model[i].SAPSN);
                            row.CreateCell(3).SetCellValue(model[i].MC);
                            row.CreateCell(4).SetCellValue(model[i].PKHID);
                            row.CreateCell(5).SetCellValue(model[i].PKHIDDES);
                            row.CreateCell(6).SetCellValue(model[i].SFDES);
                            row.CreateCell(7).SetCellValue(model[i].CSDES);
                            row.CreateCell(8).SetCellValue(model[i].COUNTYDES);
                            row.CreateCell(9).SetCellValue(model[i].BEIZ);
                            row.CreateCell(10).SetCellValue(model[i].KHSHDZ);
                            row.CreateCell(11).SetCellValue(model[i].KHSHLXR);
                            row.CreateCell(12).SetCellValue(model[i].KHSHLXDH);

                            row2s++;
                            #endregion
                        }

                    }
                    else if (model[i].KHLX == 5 || model[i].KHLX == 6)          //网点终端、批发
                    {
                        #region
                        NPOI.SS.UserModel.IRow row = worksheet3.CreateRow(row3);
                        switch (model[i].IsOfficial)
                        {
                            case 10:
                                row.CreateCell(0).SetCellValue("潜在客户");
                                break;
                            case 20:
                                row.CreateCell(0).SetCellValue("签约客户");
                                break;
                            case 30:
                                row.CreateCell(0).SetCellValue("非签约客户");
                                break;
                            default:
                                row.CreateCell(0).SetCellValue("");
                                break;
                        }
                        row.CreateCell(1).SetCellValue(model[i].CRMID);
                        row.CreateCell(2).SetCellValue(model[i].SAPSN);
                        row.CreateCell(3).SetCellValue(model[i].SFDES);
                        row.CreateCell(4).SetCellValue(model[i].CSDES);
                        row.CreateCell(5).SetCellValue(model[i].COUNTYDES);
                        row.CreateCell(6).SetCellValue(model[i].PKHID);
                        row.CreateCell(7).SetCellValue(model[i].PKHIDDES);
                        row.CreateCell(8).SetCellValue(model[i].MC);
                        row.CreateCell(9).SetCellValue(model[i].MDDZ);
                        row.CreateCell(10).SetCellValue(model[i].GSLXR);
                        row.CreateCell(11).SetCellValue(model[i].GSLXDH);
                        string wdlx = crmModels.HG_DICT.ReadByDICID(model[i].WDLX, token).DICNAME;
                        row.CreateCell(12).SetCellValue(wdlx);
                        switch (model[i].SFBZWD)
                        {
                            case true:
                                row.CreateCell(13).SetCellValue("是");
                                break;
                            case false:
                                row.CreateCell(13).SetCellValue("否");
                                break;
                            default:
                                row.CreateCell(13).SetCellValue("");
                                break;
                        }
                        row.CreateCell(14).SetCellValue(model[i].KHZZSJ);

                        CRM_KH_KHZZ cxdata = new CRM_KH_KHZZ();
                        cxdata.KHID = model[i].KHID;
                        cxdata.ZZMCID = 1080;
                        CRM_KH_KHZZ[] youxiao = crmModels.KH_KHZZ.ReadByParam(cxdata, token);
                        if (youxiao.Length != 0)            //有效网点开发
                        {
                            row.CreateCell(15).SetCellValue("是");
                            row.CreateCell(16).SetCellValue(youxiao[0].INFO1);
                            row.CreateCell(17).SetCellValue(youxiao[0].INFO2);
                        }
                        else
                        {
                            row.CreateCell(15).SetCellValue("否");
                        }

                        cxdata.ZZMCID = 1058;
                        CRM_KH_KHZZ[] dzs = crmModels.KH_KHZZ.ReadByParam(cxdata, token);
                        if (dzs.Length != 0)            //是否电子锁
                        {
                            row.CreateCell(18).SetCellValue("是");
                            row.CreateCell(19).SetCellValue(dzs[0].INFO1);

                        }
                        else
                        {
                            row.CreateCell(18).SetCellValue("否");
                        }

                        row.CreateCell(20).SetCellValue(model[i].BEIZ);

                        CRM_KH_KH JXS = crmModels.KH_KH.ReadJXSByKHID(model[i].KHID, token);
                        row.CreateCell(21).SetCellValue(JXS.CRMID);
                        row.CreateCell(22).SetCellValue(JXS.SAPSN);
                        row.CreateCell(23).SetCellValue(JXS.MC);

                        row3++;
                        #endregion
                    }
                    else if (model[i].KHLX == 7 && model[i].MCSX == 1)           //LKA
                    {
                        #region
                        NPOI.SS.UserModel.IRow row = worksheet4.CreateRow(row4);
                        switch (model[i].IsOfficial)
                        {
                            case 10:
                                row.CreateCell(0).SetCellValue("潜在客户");
                                break;
                            case 20:
                                row.CreateCell(0).SetCellValue("签约客户");
                                break;
                            case 30:
                                row.CreateCell(0).SetCellValue("非签约客户");
                                break;
                            default:
                                row.CreateCell(0).SetCellValue("");
                                break;
                        }
                        row.CreateCell(1).SetCellValue(model[i].CRMID);
                        row.CreateCell(2).SetCellValue(model[i].SAPSN);

                        CRM_KH_KH JXS = crmModels.KH_KH.ReadJXSByKHID(model[i].KHID, token);
                        row.CreateCell(3).SetCellValue(JXS.CRMID);
                        row.CreateCell(4).SetCellValue(JXS.SAPSN);
                        row.CreateCell(5).SetCellValue(JXS.MC);
                        row.CreateCell(6).SetCellValue(model[i].MC);
                        row.CreateCell(7).SetCellValue(model[i].MDJCSL);
                        row.CreateCell(8).SetCellValue(model[i].MDDZ);

                        CRM_KH_KHZZ cxdata = new CRM_KH_KHZZ();
                        cxdata.KHID = model[i].KHID;
                        cxdata.ZZMCID = 1080;
                        CRM_KH_KHZZ[] youxiao = crmModels.KH_KHZZ.ReadByParam(cxdata, token);
                        if (youxiao.Length != 0)            //有效网点开发
                        {
                            row.CreateCell(9).SetCellValue("是");
                            row.CreateCell(10).SetCellValue(youxiao[0].INFO1);
                            row.CreateCell(11).SetCellValue(youxiao[0].INFO2);
                        }
                        else
                        {
                            row.CreateCell(9).SetCellValue("否");
                        }

                        row.CreateCell(12).SetCellValue(model[i].KHZZSJ);
                        row.CreateCell(13).SetCellValue(model[i].FIRSTAMOUNT);
                        row.CreateCell(14).SetCellValue(model[i].PSQK);
                        row.CreateCell(15).SetCellValue(model[i].FSFW);
                        row.CreateCell(16).SetCellValue(model[i].MANAGEWAYDES);
                        row.CreateCell(17).SetCellValue(model[i].PAYWAYDES);
                        row.CreateCell(18).SetCellValue(model[i].GSLXR);
                        row.CreateCell(19).SetCellValue(model[i].GSLXRZWDES);
                        row.CreateCell(20).SetCellValue(model[i].GSLXDH);
                        row.CreateCell(21).SetCellValue(model[i].ISNEW == 1 ? "是" : "否");
                        row.CreateCell(22).SetCellValue(model[i].BELONGKA == 1 ? "是" : "否");
                        row.CreateCell(23).SetCellValue(model[i].WEBSITE);
                        row.CreateCell(24).SetCellValue(model[i].ACCOUNT);
                        row.CreateCell(25).SetCellValue(model[i].SUPPORTOTHER == 1 ? "是" : "否");
                        row.CreateCell(26).SetCellValue(model[i].PACT == 1 ? "是" : "否");
                        row.CreateCell(27).SetCellValue(model[i].BEIZ);

                        row4++;
                        #endregion
                    }
                    else if (model[i].KHLX == 7 && model[i].MCSX == 2)          //LKA门店
                    {
                        #region
                        NPOI.SS.UserModel.IRow row = worksheet5.CreateRow(row5);
                        switch (model[i].IsOfficial)
                        {
                            case 10:
                                row.CreateCell(0).SetCellValue("潜在客户");
                                break;
                            case 20:
                                row.CreateCell(0).SetCellValue("签约客户");
                                break;
                            case 30:
                                row.CreateCell(0).SetCellValue("非签约客户");
                                break;
                            default:
                                row.CreateCell(0).SetCellValue("");
                                break;
                        }
                        row.CreateCell(1).SetCellValue(model[i].CRMID);
                        row.CreateCell(2).SetCellValue(model[i].SAPSN);
                        row.CreateCell(3).SetCellValue(model[i].PKHID);
                        row.CreateCell(4).SetCellValue(model[i].PKHIDDES);
                        row.CreateCell(5).SetCellValue(model[i].MC);
                        string mclx = crmModels.HG_DICT.ReadByDICID(model[i].MCLC, token).DICNAME;
                        row.CreateCell(6).SetCellValue(mclx);
                        row.CreateCell(7).SetCellValue(model[i].MDDZ);
                        row.CreateCell(8).SetCellValue(model[i].JCDPSL);
                        row.CreateCell(9).SetCellValue(model[i].XSSJSM);
                        row.CreateCell(10).SetCellValue(model[i].KHZZSJ);

                        CRM_KH_KHZZ cxdata = new CRM_KH_KHZZ();
                        cxdata.KHID = model[i].KHID;
                        cxdata.ZZMCID = 1080;
                        CRM_KH_KHZZ[] youxiao = crmModels.KH_KHZZ.ReadByParam(cxdata, token);
                        if (youxiao.Length != 0)            //有效网点开发
                        {
                            row.CreateCell(11).SetCellValue("是");
                            row.CreateCell(12).SetCellValue(youxiao[0].INFO1);
                            row.CreateCell(13).SetCellValue(youxiao[0].INFO2);
                        }
                        else
                        {
                            row.CreateCell(11).SetCellValue("否");
                        }

                        row.CreateCell(14).SetCellValue(model[i].BEIZ);

                        CRM_KH_KH JXS = crmModels.KH_KH.ReadJXSByKHID(model[i].KHID, token);
                        row.CreateCell(15).SetCellValue(JXS.CRMID);
                        row.CreateCell(16).SetCellValue(JXS.SAPSN);
                        row.CreateCell(17).SetCellValue(JXS.MC);

                        row5++;
                        #endregion
                    }
                    else if (model[i].KHLX == 10)          //中间商
                    {
                        #region
                        NPOI.SS.UserModel.IRow row = worksheet6.CreateRow(row6);
                        switch (model[i].IsOfficial)
                        {
                            case 10:
                                row.CreateCell(0).SetCellValue("潜在客户");
                                break;
                            case 20:
                                row.CreateCell(0).SetCellValue("签约客户");
                                break;
                            case 30:
                                row.CreateCell(0).SetCellValue("非签约客户");
                                break;
                            default:
                                row.CreateCell(0).SetCellValue("");
                                break;
                        }
                        row.CreateCell(1).SetCellValue(model[i].CRMID);
                        row.CreateCell(2).SetCellValue(model[i].SAPSN);
                        row.CreateCell(3).SetCellValue(model[i].SFDES);
                        row.CreateCell(4).SetCellValue(model[i].CSDES);
                        row.CreateCell(5).SetCellValue(model[i].COUNTYDES);
                        row.CreateCell(6).SetCellValue(model[i].PKHID);
                        row.CreateCell(7).SetCellValue(model[i].PKHIDDES);
                        row.CreateCell(8).SetCellValue(model[i].MC);
                        row.CreateCell(9).SetCellValue(model[i].MDDZ);
                        row.CreateCell(10).SetCellValue(model[i].GSLXR);
                        row.CreateCell(11).SetCellValue(model[i].GSLXDH);
                        row.CreateCell(12).SetCellValue(model[i].KHLX2DES);
                        row.CreateCell(13).SetCellValue(model[i].KHZZSJ);

                        CRM_KH_KHZZ cxdata = new CRM_KH_KHZZ();
                        cxdata.KHID = model[i].KHID;
                        cxdata.ZZMCID = 1080;
                        CRM_KH_KHZZ[] youxiao = crmModels.KH_KHZZ.ReadByParam(cxdata, token);
                        if (youxiao.Length != 0)            //有效网点开发
                        {
                            row.CreateCell(14).SetCellValue("是");
                            row.CreateCell(15).SetCellValue(youxiao[0].INFO1);
                            row.CreateCell(16).SetCellValue(youxiao[0].INFO2);
                        }
                        else
                        {
                            row.CreateCell(14).SetCellValue("否");
                        }

                        row.CreateCell(17).SetCellValue(model[i].BEIZ);



                        row6++;
                        #endregion
                    }
                    else if (model[i].KHLX == 1105)
                    {
                        #region
                        NPOI.SS.UserModel.IRow row = worksheet7.CreateRow(row7);
                        switch (model[i].IsOfficial)
                        {
                            case 10:
                                row.CreateCell(0).SetCellValue("潜在客户");
                                break;
                            case 20:
                                row.CreateCell(0).SetCellValue("签约客户");
                                break;
                            case 30:
                                row.CreateCell(0).SetCellValue("非签约客户");
                                break;
                            default:
                                row.CreateCell(0).SetCellValue("");
                                break;
                        }
                        row.CreateCell(1).SetCellValue(model[i].CRMID);
                        row.CreateCell(2).SetCellValue(model[i].SAPSN);
                        row.CreateCell(3).SetCellValue(model[i].MC);
                        row.CreateCell(4).SetCellValue(model[i].PKHID);
                        row.CreateCell(5).SetCellValue(model[i].PKHIDDES);
                        row.CreateCell(6).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].KPXZ, token).DICNAME);
                        row.CreateCell(7).SetCellValue(model[i].NSRSBH);
                        row.CreateCell(8).SetCellValue(model[i].KPDZ);
                        row.CreateCell(9).SetCellValue(model[i].KPDH);
                        row.CreateCell(10).SetCellValue(model[i].YHZH);
                        row.CreateCell(11).SetCellValue(model[i].YHMC);
                        row.CreateCell(12).SetCellValue(model[i].GSLXR);
                        row.CreateCell(13).SetCellValue(model[i].GSLXDH);
                        row.CreateCell(14).SetCellValue(model[i].FR);
                        row.CreateCell(15).SetCellValue(model[i].GSFRGX);
                        row.CreateCell(16).SetCellValue(model[i].KDJSDZ);
                        row.CreateCell(17).SetCellValue(model[i].KDLXR);
                        row.CreateCell(18).SetCellValue(model[i].KDLXDH);


                        row7++;
                        #endregion
                    }
                    else
                    {
                        msg.Msg = "err";
                        msg.Info = "找不到对应的客户类型";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }




                }



                worksheet1.ForceFormulaRecalculation = true;
                worksheet2.ForceFormulaRecalculation = true;
                worksheet2s.ForceFormulaRecalculation = true;
                worksheet3.ForceFormulaRecalculation = true;
                worksheet4.ForceFormulaRecalculation = true;
                worksheet5.ForceFormulaRecalculation = true;
                worksheet6.ForceFormulaRecalculation = true;
                worksheet7.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }


        }


        /// <summary>
        /// 导出客户其他数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public string Data_FileUpload_KeHuQTXX_DaoChu(string data)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                CRM_KH_KHList[] kh_model = JsonConvert.DeserializeObject<CRM_KH_KHList[]>(data);


                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/修改客户细项数据.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("渠道");
                ISheet worksheet2 = workbook.GetSheet("销售品种");
                ISheet worksheet3 = workbook.GetSheet("竞品");
                ISheet worksheet4 = workbook.GetSheet("管辖区域");
                ISheet worksheet5 = workbook.GetSheet("陈列");
                ISheet worksheet6 = workbook.GetSheet("客户分组");
                ISheet worksheet7 = workbook.GetSheet("邮寄地址");
                ISheet worksheet8 = workbook.GetSheet("客户联系人");
                ISheet worksheet9 = workbook.GetSheet("拜访频次");
                ISheet worksheet10 = workbook.GetSheet("送货数量");
                ISheet worksheet11 = workbook.GetSheet("直销商销售");
                ISheet worksheet12 = workbook.GetSheet("网点数量");
                ISheet worksheet13 = workbook.GetSheet("车牌");
                ISheet worksheet14 = workbook.GetSheet("促销单品");
                ISheet worksheet15 = workbook.GetSheet("签到地址");
                ISheet worksheet16 = workbook.GetSheet("直销人员");
                ISheet worksheet17 = workbook.GetSheet("活动");


                if (worksheet1 == null || worksheet2 == null || worksheet3 == null || worksheet4 == null || worksheet5 == null || worksheet6 == null || worksheet7 == null || worksheet8 == null || worksheet9 == null || worksheet10 == null || worksheet11 == null || worksheet12 == null || worksheet13 == null || worksheet14 == null || worksheet15 == null || worksheet16 == null || worksheet17 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                int row1 = 0, row2 = 0, row3 = 0, row4 = 0, row5 = 0, row6 = 0, row7 = 0, row8 = 0, row9 = 0, row10 = 0, row11 = 0, row12 = 0, row13 = 0, row14 = 0, row15 = 0; //row16 = 0, row17 = 0;
                for (int i = 0; i < kh_model.Length; i++)
                {
                    CRM_KH_KHQTXXList[] qudao = crmModels.KH_KHQTXX.Read(kh_model[i].KHID, 1, token);
                    CRM_KH_KHQTXXList[] pinzhong = crmModels.KH_KHQTXX.Read(kh_model[i].KHID, 2, token);
                    CRM_KH_KHQTXXList[] jingpin = crmModels.KH_KHQTXX.Read(kh_model[i].KHID, 3, token);
                    CRM_KH_GXQYList[] area = crmModels.KH_GXQY.Read(kh_model[i].KHID, token);
                    CRM_KH_KHQTXXList[] display = crmModels.KH_KHQTXX.Read(kh_model[i].KHID, 4, token);
                    string[][] group = crmModels.KH_GROUP_KH.ReadByKHID(token, kh_model[i].KHID);

                    CRM_KH_KHQTXXList[] post = crmModels.KH_KHQTXX.Read(kh_model[i].KHID, 5, token);
                    CRM_KH_LXRList[] contact = crmModels.KH_LXR.Read(kh_model[i].KHID, 1081, token);
                    CRM_KH_KHBFList[] pinci = crmModels.KH_KHBF.Read(0, kh_model[i].KHID, token);

                    CRM_KH_KHXS cx_songhuo = new CRM_KH_KHXS();
                    cx_songhuo.KHID = kh_model[i].KHID;
                    cx_songhuo.XSLB = 1;
                    cx_songhuo.ISACTIVE = 1;
                    CRM_KH_KHXSList[] songhuo = crmModels.KH_KHXS.Read(cx_songhuo, token);

                    CRM_KH_KHXS cx_zxs_sale = new CRM_KH_KHXS();
                    cx_zxs_sale.KHID = kh_model[i].KHID;
                    cx_zxs_sale.XSLB = 2;
                    cx_zxs_sale.ISACTIVE = 1;
                    CRM_KH_KHXSList[] zxs_sale = crmModels.KH_KHXS.Read(cx_zxs_sale, token);

                    CRM_KH_KHXS cx_WDshuliang = new CRM_KH_KHXS();
                    cx_WDshuliang.KHID = kh_model[i].KHID;
                    cx_WDshuliang.XSLB = 3;
                    cx_WDshuliang.ISACTIVE = 1;
                    CRM_KH_KHXSList[] WDshuliang = crmModels.KH_KHXS.Read(cx_WDshuliang, token);

                    CRM_KH_KHQTXXList[] chepai = crmModels.KH_KHQTXX.Read(kh_model[i].KHID, 6, token);
                    CRM_KH_KHQTXXList[] cuxiao = crmModels.KH_KHQTXX.Read(kh_model[i].KHID, 7, token);

                    CRM_KH_DZList[] qiandaoDZ = crmModels.KH_DZ.ReadByKHID(kh_model[i].KHID, token);

                    if (qudao.Length != 0 && qudao != null)     //渠道
                    {
                        for (int j = 0; j < qudao.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1 + 1);
                            row.CreateCell(0).SetCellValue(qudao[j].XXID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(qudao[j].XXMC);

                            row1++;
                        }

                    }
                    if (pinzhong.Length != 0 && pinzhong != null)     //销售品种
                    {
                        for (int j = 0; j < pinzhong.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet2.CreateRow(row2 + 1);
                            row.CreateCell(0).SetCellValue(pinzhong[j].XXID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(pinzhong[j].XXMC);

                            row2++;
                        }

                    }
                    if (jingpin.Length != 0 && jingpin != null)     //竞品
                    {
                        for (int j = 0; j < jingpin.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet3.CreateRow(row3 + 1);
                            row.CreateCell(0).SetCellValue(jingpin[j].XXID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(jingpin[j].XXMC);

                            row3++;
                        }

                    }
                    if (area.Length != 0 && area != null)     //管辖区域
                    {
                        for (int j = 0; j < area.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet4.CreateRow(row4 + 1);
                            row.CreateCell(0).SetCellValue(area[j].GXQYID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            switch (area[j].GXQYLX)
                            {
                                case 1:
                                    row.CreateCell(3).SetCellValue("全国");
                                    break;
                                case 2:
                                    row.CreateCell(3).SetCellValue("省份");
                                    break;
                                case 3:
                                    row.CreateCell(3).SetCellValue("城市");
                                    break;
                                default:
                                    row.CreateCell(3).SetCellValue("");
                                    break;
                            }
                            row.CreateCell(4).SetCellValue(area[j].GXQYMCDES);
                            row.CreateCell(5).SetCellValue(area[j].BEIZ);

                            row4++;
                        }

                    }
                    if (display.Length != 0 && display != null)     //陈列
                    {
                        for (int j = 0; j < display.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet5.CreateRow(row5 + 1);
                            row.CreateCell(0).SetCellValue(display[j].XXID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            switch (display[j].CLLX)
                            {
                                case 1:
                                    row.CreateCell(3).SetCellValue("主陈列");
                                    break;
                                case 2:
                                    row.CreateCell(3).SetCellValue("二次陈列");
                                    break;
                                default:
                                    row.CreateCell(3).SetCellValue("");
                                    break;
                            }
                            row.CreateCell(4).SetCellValue(display[j].CLFSDES);
                            row.CreateCell(5).SetCellValue(display[j].CLGSRQ);
                            row.CreateCell(6).SetCellValue(display[j].BEIZ);

                            row5++;
                        }

                    }
                    if (group.Length != 0 && group != null)     //客户分组
                    {
                        for (int j = 0; j < group.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet6.CreateRow(row6 + 1);
                            row.CreateCell(0).SetCellValue(group[j][0]);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(group[j][1]);


                            row6++;
                        }

                    }
                    if (post.Length != 0 && post != null)     //邮寄地址
                    {
                        for (int j = 0; j < post.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet7.CreateRow(row7 + 1);
                            row.CreateCell(0).SetCellValue(post[j].XXID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(post[j].KHYJDZ);
                            row.CreateCell(4).SetCellValue(post[j].YB);
                            row.CreateCell(5).SetCellValue(post[j].SJR);
                            row.CreateCell(6).SetCellValue(post[j].SJRLXFS);
                            row.CreateCell(7).SetCellValue(post[j].BEIZ);
                            row7++;
                        }

                    }
                    if (contact.Length != 0 && contact != null)     //客户联系人
                    {
                        for (int j = 0; j < contact.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet8.CreateRow(row8 + 1);
                            row.CreateCell(0).SetCellValue(contact[j].KHLXRID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(contact[j].LXR);
                            row.CreateCell(4).SetCellValue(contact[j].SEX);
                            row.CreateCell(5).SetCellValue(contact[j].JTDZ);
                            row.CreateCell(6).SetCellValue(contact[j].JG);
                            row.CreateCell(7).SetCellValue(crmModels.HG_DICT.ReadByDICID(contact[j].MZ, token).DICNAME);
                            row.CreateCell(8).SetCellValue(crmModels.HG_DICT.ReadByDICID(contact[j].ZW, token).DICNAME);
                            row.CreateCell(9).SetCellValue(contact[j].AH);
                            row.CreateCell(10).SetCellValue(crmModels.HG_DICT.ReadByDICID(contact[j].HYZK, token).DICNAME);
                            row.CreateCell(11).SetCellValue(contact[j].YDDH);
                            row.CreateCell(12).SetCellValue(contact[j].GDDH);
                            row.CreateCell(13).SetCellValue(contact[j].TEL);
                            row.CreateCell(14).SetCellValue(contact[j].EMAIL);
                            row.CreateCell(15).SetCellValue(contact[j].WXH);
                            row.CreateCell(16).SetCellValue(contact[j].SR);
                            row.CreateCell(17).SetCellValue(contact[j].TXDZ);
                            row.CreateCell(18).SetCellValue(contact[j].YZBM);
                            row.CreateCell(19).SetCellValue(contact[j].XGMS);
                            row.CreateCell(20).SetCellValue(contact[j].SFZYLXR == 1 ? "是" : "否");
                            row.CreateCell(21).SetCellValue(contact[j].BEIZ);

                            row8++;
                        }

                    }
                    if (pinci.Length != 0 && pinci != null)     //拜访频次
                    {
                        for (int j = 0; j < pinci.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet9.CreateRow(row9 + 1);
                            row.CreateCell(0).SetCellValue(pinci[j].BFID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(pinci[j].BFZQDES);
                            row.CreateCell(4).SetCellValue(pinci[j].BFCS);
                            row9++;
                        }

                    }
                    if (songhuo.Length != 0 && songhuo != null)     //送货数量
                    {
                        for (int j = 0; j < songhuo.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet10.CreateRow(row10 + 1);
                            row.CreateCell(0).SetCellValue(songhuo[j].XSID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(songhuo[j].XSMC);
                            row.CreateCell(4).SetCellValue(songhuo[j].XSSL);
                            row.CreateCell(5).SetCellValue(songhuo[j].GSRQ);
                            row.CreateCell(6).SetCellValue(songhuo[j].BEIZ);
                            row10++;
                        }

                    }
                    if (zxs_sale.Length != 0 && zxs_sale != null)     //直销商销售
                    {
                        for (int j = 0; j < zxs_sale.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet11.CreateRow(row11 + 1);
                            row.CreateCell(0).SetCellValue(zxs_sale[j].XSID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(zxs_sale[j].XSMC);
                            row.CreateCell(4).SetCellValue(zxs_sale[j].XSJE);
                            row.CreateCell(5).SetCellValue(zxs_sale[j].GSRQ);
                            row11++;
                        }

                    }
                    if (WDshuliang.Length != 0 && WDshuliang != null)     //网点数量
                    {
                        for (int j = 0; j < WDshuliang.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet12.CreateRow(row12 + 1);
                            row.CreateCell(0).SetCellValue(WDshuliang[j].XSID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(WDshuliang[j].XSMC);
                            row.CreateCell(4).SetCellValue(WDshuliang[j].XSSL);
                            row.CreateCell(5).SetCellValue(WDshuliang[j].GSRQ);
                            row12++;
                        }

                    }
                    if (chepai.Length != 0 && chepai != null)     //车牌
                    {
                        for (int j = 0; j < chepai.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet13.CreateRow(row13 + 1);
                            row.CreateCell(0).SetCellValue(chepai[j].XXID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(chepai[j].XXMC);
                            row.CreateCell(4).SetCellValue(chepai[j].PD == 1 ? "有" : "无");
                            row13++;
                        }

                    }
                    if (cuxiao.Length != 0 && cuxiao != null)     //促销单品
                    {
                        for (int j = 0; j < cuxiao.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet14.CreateRow(row14 + 1);
                            row.CreateCell(0).SetCellValue(cuxiao[j].XXID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(cuxiao[j].XXMC);
                            row.CreateCell(4).SetCellValue(cuxiao[j].PD == 1 ? "是" : "否");
                            row14++;
                        }

                    }
                    if (qiandaoDZ.Length != 0 && qiandaoDZ != null)     //签到地址
                    {
                        for (int j = 0; j < qiandaoDZ.Length; j++)
                        {
                            NPOI.SS.UserModel.IRow row = worksheet15.CreateRow(row15 + 1);
                            row.CreateCell(0).SetCellValue(qiandaoDZ[j].DZID);
                            row.CreateCell(1).SetCellValue(kh_model[i].CRMID);
                            row.CreateCell(2).SetCellValue(kh_model[i].MC);
                            row.CreateCell(3).SetCellValue(qiandaoDZ[j].DZMS);
                            row.CreateCell(4).SetCellValue(qiandaoDZ[j].DWDZMS);
                            row.CreateCell(5).SetCellValue(qiandaoDZ[j].DZRC);
                            row15++;
                        }

                    }



                }



                worksheet1.ForceFormulaRecalculation = true;
                worksheet2.ForceFormulaRecalculation = true;
                worksheet3.ForceFormulaRecalculation = true;
                worksheet4.ForceFormulaRecalculation = true;
                worksheet5.ForceFormulaRecalculation = true;
                worksheet6.ForceFormulaRecalculation = true;
                worksheet7.ForceFormulaRecalculation = true;
                worksheet8.ForceFormulaRecalculation = true;
                worksheet9.ForceFormulaRecalculation = true;
                worksheet10.ForceFormulaRecalculation = true;
                worksheet11.ForceFormulaRecalculation = true;
                worksheet12.ForceFormulaRecalculation = true;
                worksheet13.ForceFormulaRecalculation = true;
                worksheet14.ForceFormulaRecalculation = true;
                worksheet15.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }


        }


        [HttpPost]
        public string Data_Delete_File(string name)
        {
            //Thread.Sleep(5000);
            try
            {
                string path = FileSavePath + @"\upload\" + name;
                System.IO.File.Delete(path);
                return "";
            }
            catch
            {
                return "";
            }

        }

        public ActionResult Update()
        {
            token = appClass.CRM_Gettoken();

            CRM_HG_DICT[] HDCL = crmModels.HG_DICT.Read(106, 0, token);
            ViewBag.HDCL = HDCL;
            CRM_HG_DICT[] YYZT = crmModels.HG_DICT.Read(114, 0, token);
            ViewBag.YYZT = YYZT;
            MES_MM_CK model = new MES_MM_CK();
            model.ROLENAME = "1000-KA仓库";
            MES_MM_CK_SELECT data = mesModels.MM_CK.SELECT_BY_ROLE_ASSEMBLE(model, token);
            ViewBag.KCDD = data.MES_MM_CK;
            //return PartialView("Update");
            return View();
        }

        public ActionResult Update_SelectOnly()
        {
            token = appClass.CRM_Gettoken();

            CRM_HG_DICT[] HDCL = crmModels.HG_DICT.Read(106, 0, token);
            ViewBag.HDCL = HDCL;
            CRM_HG_DICT[] YYZT = crmModels.HG_DICT.Read(114, 0, token);
            ViewBag.YYZT = YYZT;
            MES_MM_CK model = new MES_MM_CK();
            model.ROLENAME = "1000-KA仓库";
            MES_MM_CK_SELECT data = mesModels.MM_CK.SELECT_BY_ROLE_ASSEMBLE(model, token);
            ViewBag.KCDD = data.MES_MM_CK;

            //return PartialView("Update");
            return View();
        }

        public ActionResult Power()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 5;
            //return PartialView("Power");
            CRM_HG_DICT[] CPLX = crmModels.HG_DICT.Read(103, 0, token);
            ViewBag.CPLX = CPLX;
            return View();
        }

        [HttpPost]
        public int Data_Insert_Power(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUP model = JsonConvert.DeserializeObject<CRM_KH_GROUP>(data);
            int i = crmModels.KH_GROUP.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Power()
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUPList[] data = crmModels.KH_GROUP.Read(token);
            LayuiTree[] result = new LayuiTree[data.Length];

            for (int i = 0; i < data.Length; i++)           //把查询出来的数据转换成layui属性列表要求的格式
            {
                result[i] = new LayuiTree();
                result[i].Id = data[i].GID;
                result[i].XSQYID = data[i].XSQYID;
                result[i].Pid = data[i].PGID;
                result[i].title = data[i].NAME1;
                result[i].Khjlid = data[i].KHJLID;
                result[i].Fgldid = data[i].FGLDID;
                result[i].Gmemo = data[i].GMEMO;
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return s;
        }

        [HttpPost]
        public string Data_Select_Power_ByGid(int Gid)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUPList data = crmModels.KH_GROUP.ReadbyGId(Gid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_Power(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUP model = JsonConvert.DeserializeObject<CRM_KH_GROUP>(data);
            int i = crmModels.KH_GROUP.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Power(int GID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_GROUP.Delect(GID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_DDL_XSQY()
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUP_XSQY[] data = crmModels.KH_GROUP_XSQY.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        //继续  角色下拉框加载
        [HttpPost]
        public string Data_Select_DDL_Duty(int dutyid)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFF[] data = crmModels.HG_STAFF.ReadByDUTYID(dutyid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        public ActionResult UserPower()
        {
            Session["location"] = 6;
            //return PartialView("UserPower");
            return View();
        }

        [HttpPost]
        public int Data_Insert_GroupByStaffno(int STAFFID, int GID)        //分配人员到组by StaffNO
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_GROUP_STAFF.Create(STAFFID, GID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Group_Staff()           //查询所有！所有！所有的！用户与组的关联
        {
            token = appClass.CRM_Gettoken();
            string[][] data = crmModels.KH_GROUP_STAFF.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_KeHu_Group_Staff(int STAFFID, int OldGid, int NewGid)                //修改人员与组的关联
        {
            token = appClass.CRM_Gettoken();

            int i = crmModels.KH_GROUP_STAFF.Update(STAFFID, OldGid, NewGid, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_KH_Group_Staff(string staffname, int GID)       //根据传入的人员和组id来查询人员与组的关联
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUP_STAFFList[] data = crmModels.KH_GROUP_STAFF.Report(staffname, GID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_Group_Staff(int STAFFID, int GID)                     //删除用户与组的关联
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_GROUP_STAFF.Delete(STAFFID, GID, token);
            return i;
        }

        public ActionResult KeHuPower()
        {
            Session["location"] = 7;
            //return PartialView("KHPower"); 
            return View();
        }

        public ActionResult KeHuPower2()
        {
            Session["location"] = 549;
            //return PartialView("KHPower"); 
            return View();
        }

        [HttpPost]
        public int Data_Insert_GroupByCRMID(string crmid, int GID)        //分配客户到组by KHname
        {
            token = appClass.CRM_Gettoken();
            CRM_Report_KHModel report = new CRM_Report_KHModel();
            report.CRMID = crmid;
            CRM_KH_KHList[] model = crmModels.KH_KH.Report(report, 0, token);

            int i = crmModels.KH_GROUP_KH.Create(model[0].KHID, GID, token);
            return i;
        }

        [HttpPost]
        public int Data_Update_KeHu_Group_KeHu(string crmid, int OldGid, int NewGid)                //修改客户与组的关联
        {
            token = appClass.CRM_Gettoken();
            CRM_Report_KHModel report = new CRM_Report_KHModel();
            report.CRMID = crmid;
            CRM_KH_KHList[] model = crmModels.KH_KH.Report(report, 0, token);

            int i = crmModels.KH_GROUP_KH.Update(model[0].KHID, OldGid, NewGid, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Group_KH()           //查询所有！所有！所有的！客户与组的关联
        {
            token = appClass.CRM_Gettoken();
            string[][] data = crmModels.KH_GROUP_KH.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KH_Group_KH(string name, int Gid)     //根据传入的客户和组id来查询客户与组的关联
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUP_KHList[] data = crmModels.KH_GROUP_KH.Report(name, Gid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }


        [HttpPost]
        public string Data_Select_KH_Group_KH2(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_GROUP_KHList cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_GROUP_KHList>(cxdata);
            CRM_KH_GROUP_KHList[] data = crmModels.KH_GROUP_KH.Report2(cxmodel, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_GroupMove(int oldGroup, int newGroup)
        {
            token = appClass.CRM_Gettoken();
            WebMSG webmsg = new WebMSG();
            CRM_KH_GROUP_KHList[] olddata = crmModels.KH_GROUP_KH.Report("", oldGroup, token);
            for (int i = 0; i < olddata.Length; i++)
            {
                crmModels.KH_GROUP_KH.Update(olddata[i].KHID, oldGroup, newGroup, token);
            }
            CRM_KH_GROUP_KHList[] olddata2 = crmModels.KH_GROUP_KH.Report("", oldGroup, token);
            if (olddata2.Length == 0)
            {
                webmsg.KEY = 1;
                webmsg.MSG = "修改成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "修改失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

        }

        [HttpPost]
        public string Data_Update_GroupPartMove(string data, int newGroup)
        {
            token = appClass.CRM_Gettoken();
            WebMSG webmsg = new WebMSG();

            CRM_KH_GROUP_KHList[] KH = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_GROUP_KHList[]>(data);
            for (int i = 0; i < KH.Length; i++)
            {
                crmModels.KH_GROUP_KH.Update(KH[i].KHID, KH[i].GID, newGroup, token);
            }


            webmsg.KEY = 1;
            webmsg.MSG = "操作完成，请检查结果！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);


        }

        [HttpPost]
        public int Data_Upload_KaoQin(string data, string SF, string CS)         //新增客户签到地址
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_DZ model = JsonConvert.DeserializeObject<CRM_KH_DZ>(data);
            model.GJ = 0;
            model.DZRC = crmModels.SYS_CS.Read(3, token)[0].CS;
            int province = crmModels.HG_DICT.ReadByDICNAME(SF, 1, token);
            int city = crmModels.HG_DICT.ReadByDICNAME(CS, 2, token);
            if (province == 0 || city == 0)
                return -1;
            model.SF = province;
            model.CS = city;
            model.DZSOURCE = 1090;
            int i = crmModels.KH_DZ.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Selete_KaoQin(int KHID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_DZList[] data = crmModels.KH_DZ.ReadByKHID(KHID, token);
            string s = JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_KaoQinRC(string data, int rongcha)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_DZ databefore = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_DZ>(data);
            databefore.DZRC = rongcha;
            int i = crmModels.KH_DZ.Update(databefore, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_KaoQin(int DZID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_DZ.Delete(DZID, token);
            return i;
        }

        [HttpPost]
        public string Data_AddressToLocation(string address)
        {
            string key = System.Configuration.ConfigurationManager.AppSettings["TXmapKey"];
            string url = "http://apis.map.qq.com/ws/geocoder/v1/?address=" + address + "&key=" + key;
            string json = GetJson(url);
            return json;
        }

        public string GetJson(string url)               //获得htp get返回的值
        {
            //访问http  
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string returnText = wc.DownloadString(url);
            if (returnText.Contains("errcode"))
            {
                //可能发生错误  
            }
            //Response.Write(returnText);  
            return returnText;
        }

        public ActionResult SpaceArea_Baobiao()           //空白区域报表
        {
            Session["location"] = 8;
            //return PartialView("Baobiao"); 
            return View();
        }

        [HttpPost]
        public string Data_Select_SpaceArea(int province, int city)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_BankList[] data = crmModels.KH_KH.Blank_Report(province, city, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_DaoChu_SpaceArea(string data)
        {
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 0, "");

            return result;
        }

        [HttpPost]
        public string CRM_OA_FLOW()
        {
            try
            {
                crmModels.CRM_OA.Auto_UPDATE_All();
                return "1";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [HttpPost]
        public int Data_Insert_KH_KHBF(int KHID, int BFID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHBFList model = new CRM_KH_KHBFList();
            model.KHID = KHID;
            model.BFID = BFID;
            int i = crmModels.KH_KHBF.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_KH_BF()       //查询出所有的拜访频次信息
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_BF model = new CRM_KH_BF();
            CRM_KH_BFList[] data = crmModels.KH_BF.Read(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KH_KHBF_ByKHID(int KHID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHBFList[] data = crmModels.KH_KHBF.Read(0, KHID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_KH_KHBF(int KHID, int BFID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHBFList model = new CRM_KH_KHBFList();
            model.KHID = KHID;
            model.BFID = BFID;
            int i = crmModels.KH_KHBF.Delete(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_KHLXbySTAFFID()
        {
            token = appClass.CRM_Gettoken();
            int KHLX_GroupID = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token).STAFFKHLXID;
            CRM_HG_KHLXList[] data = crmModels.HG_KHLX.Read(KHLX_GroupID, 0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_STAFFKHLX_BySTAFFKHLXID()
        {
            token = appClass.CRM_Gettoken();
            int KHLX_GroupID = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token).STAFFKHLXID;
            CRM_HG_STAFFKHLX data = crmModels.HG_STAFFKHLX.ReadBySTAFFKHLXID(KHLX_GroupID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Insert_XSTJ(string data)                //客户销售统计表新增
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHXS>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_KHXS.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_XSTJ(int KHID, int XSLB)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHXS model = new CRM_KH_KHXS();
            model.KHID = KHID;
            model.XSLB = XSLB;
            CRM_KH_KHXSList[] data = crmModels.KH_KHXS.Read(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_XSTJ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHXS>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_KHXS.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_XSTJ(int XSID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHXS model = new CRM_KH_KHXS();
            model.XSID = XSID;
            int i = crmModels.KH_KHXS.Delete(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Submit_KeHu(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHList[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHList[]>(data);

            for (int i = 0; i < checkdata.Length; i++)
            {
                if (crmModels.KH_GROUP_KH.ReadByKHID(token, checkdata[i].KHID).Length == 0)
                {
                    //客户没有分组
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "请给" + checkdata[i].MC + "客户分配分组";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                if (crmModels.KH_DZ.ReadByKHID(checkdata[i].KHID, token).Length == 0)
                {
                    //客户没有签到地址
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "请给" + checkdata[i].MC + "客户添加签到地址";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }


            //校验当客户是直销商时，直销必填项是否有数据
            if (checkdata[0].KHLX == 1 || checkdata[0].KHLX == 10)
            {
                if (checkdata[0].KHLX2 == 1064)    //该客户是直销商
                {

                    //车牌
                    CRM_KH_KHQTXXList[] chepaimodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 6, token);
                    if (chepaimodel.Length < 1)
                    {
                        //车牌数据没有填写完整
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "汽车或者电动车没有填写完整";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        for (int i = 0; i < chepaimodel.Length; i++)
                        {
                            CRM_HG_WJJL[] chepaiIMG = crmModels.HG_WJJL.Read(7, chepaimodel[i].XXID, token);
                            if (chepaiIMG.Length < 1)
                            {
                                //车牌没有图片
                                MessageInfo msg = new MessageInfo();
                                msg.Key = "0";
                                msg.Value = "汽车或者电动车需要上传照片";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }

                    //直销人员信息
                    CRM_KH_LXRList[] contactmodel = crmModels.KH_LXR.Read(checkdata[0].KHID, 1082, token);
                    if (contactmodel.Length < 1)
                    {
                        //直销人员数据没有填写完整
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "人员信息没有填写完整";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }


                    if (checkdata[0].KHLX == 10)
                    {
                        CRM_KH_KHXS xsmodel = new CRM_KH_KHXS();
                        xsmodel.KHID = checkdata[0].KHID;
                        xsmodel.XSLB = 2;
                        xsmodel.XSMC = "销售";
                        xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                        CRM_KH_KHXSList[] xsdata = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (xsdata.Length != 1)
                        {
                            //直销商销售数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "直销商销售没有填写完整";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        xsmodel.XSMC = "碱性销售";
                        CRM_KH_KHXSList[] xsdata2 = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (xsdata2.Length != 1)
                        {
                            //直销商销售数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "直销商碱性销售没有填写完整";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        xsmodel.XSMC = "A类销售";
                        CRM_KH_KHXSList[] xsdata3 = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (xsdata3.Length != 1)
                        {
                            //直销商销售数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "直销商A类没有填写完整";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        xsmodel.XSMC = "网点数量";
                        xsmodel.XSLB = 3;
                        xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                        CRM_KH_KHXSList[] wdsldata = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (wdsldata.Length != 1)
                        {
                            //网点数量数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "网点数量填写有误";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        xsmodel.XSMC = "目标网点数量";
                        xsmodel.XSLB = 3;
                        xsmodel.GSRQ = (DateTime.Now.Year).ToString();
                        CRM_KH_KHXSList[] mbwdsldata = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (mbwdsldata.Length != 1)
                        {
                            //网点数量数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "目标网点数量填写有误";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        //促销单品信息
                        CRM_KH_KHQTXXList[] dpmodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 7, token);
                        if (dpmodel.Length < 1)
                        {
                            //促销单品信息数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "促销单品信息没有填写完整";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                    }



                }
            }
            else if (checkdata[0].KHLX == 5)
            {
                string jxsid = GetJXS(checkdata[0].KHID).CRMID;
                for (int i = 0; i < checkdata.Length; i++)
                {
                    if (crmModels.KH_HD.ReadByKHID(checkdata[i].KHID, token).Length == 0)
                    {
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "终端网点客户需输入客户活动信息！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    for (int j = 0; j < checkdata.Length; j++)
                    {
                        if (GetJXS(checkdata[i].KHID).CRMID != GetJXS(checkdata[j].KHID).CRMID)
                        {
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "所选客户必须为同一个经销商下的网点！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    //if (GetJXS(checkdata[i].KHID).CRMID != jxsid)
                    //{
                    //    MessageInfo msg = new MessageInfo();
                    //    msg.Key = "0";
                    //    msg.Value = "所选客户必须为同一个经销商下的网点！";
                    //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    //}
                    CRM_KH_HD[] HuoDong = crmModels.KH_HD.ReadByKHID(checkdata[0].KHID, token);
                    for (int j = 0; j < HuoDong.Length; j++)
                    {
                        CRM_HG_WJJL[] IMG = crmModels.HG_WJJL.Read(8, HuoDong[j].HDID, token);
                        if (IMG.Length == 0)
                        {
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "所选客户必须上传活动照片！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                }

            }
            else if (checkdata[0].KHLX == 7)
            {
                int pkhid = checkdata[0].PKHID;
                for (int i = 0; i < checkdata.Length; i++)
                {
                    if (checkdata[i].MCSX == 1)
                    {
                        int XXLB = 3;
                        CRM_KH_KHQTXXList[] nnData = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, XXLB, token);
                        if (nnData.Length == 0)
                        {
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "第" + (i + 1) + "行数据，没有竞品,不允许提交，请检查数据";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }

                    if (checkdata[i].PKHID != pkhid)
                    {
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "所选客户必须为同一个系统下的门店！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }

                CRM_KH_KHQTXXList[] DISPLAY = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 4, token);
                for (int j = 0; j < DISPLAY.Length; j++)
                {
                    CRM_HG_WJJL[] IMG = crmModels.HG_WJJL.Read(2, DISPLAY[j].XXID, token);
                    if (IMG.Length == 0)
                    {
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "所选客户必须上传陈列照片！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
            }

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;

            //basic.Subject = crmModels.HG_DICT.ReadByDICID(checkdata[0].KHLX,token).DICNAME + "客户审核申请(" + staffmodel.STAFFNAME;


            CRM_OA_KH list = new CRM_OA_KH();

            //经销商
            if (checkdata[0].KHLX == 1 || checkdata[0].KHLX == 2 || checkdata[0].KHLX == 4)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(8, token)[0].CS.ToString();
                list.MC = checkdata[0].MC;
                list.JPXZ = crmModels.HG_DICT.ReadByDICID(checkdata[0].KPXZ, token).DICNAME;
                list.KPDZ = checkdata[0].KPDZ;
                list.KPDH = checkdata[0].KPDH;
                list.NSRSBH = checkdata[0].NSRSBH;
                list.YHZH = checkdata[0].YHZH;
                list.YHMC = checkdata[0].YHMC;
                list.GSLXR = checkdata[0].GSLXR;
                list.GSLXDH = checkdata[0].GSLXDH;
                list.FR = checkdata[0].FR;
                list.GSFRGX = checkdata[0].GSFRGX;
                list.KDJSDZ = checkdata[0].KDJSDZ;
                list.KDLXR = checkdata[0].KDLXR;
                list.KDLXDH = checkdata[0].KDLXDH;
                list.HTXSRW = checkdata[0].HTXSRW;
                list.HTJXXSRW = checkdata[0].HTJXXSRW;
                list.XSSJSM = checkdata[0].XSSJSM;
                list.FLSJSM = checkdata[0].FLSJSM;
                list.SFCCJ = checkdata[0].SFCCJ ? "是" : checkdata[0].SFCCJSM;
                list.KHSHDZ = checkdata[0].KHSHDZ;
                list.KHSHLXR = checkdata[0].KHSHLXR;
                list.KHSHLXDH = checkdata[0].KHSHLXDH;
                list.TSQKSM = checkdata[0].TSQKSM;
                list.KHJS = checkdata[0].KHJS;
                list.TITLE = crmModels.HG_DICT.ReadByDICID(checkdata[0].KHLX, token).DICNAME;
                list.FIRSTAMOUNT = checkdata[0].FIRSTAMOUNT;
                list.JOINACTIVITY = checkdata[0].JOINACTIVITY.ToString();

                CRM_KH_GXQYList[] AreaModel = crmModels.KH_GXQY.Read(checkdata[0].KHID, token);
                string area = "";
                for (int i = 0; i < AreaModel.Length; i++)
                {
                    if (i == 0)
                        area = AreaModel[i].GXQYMCDES;
                    else
                        area = area + "、" + AreaModel[i].GXQYMCDES;
                }
                list.GXQY = area;
                list.JXSYX = checkdata[0].JXSYX ? "是" : "否";
                list.YXSM = checkdata[0].YXSM;
                CRM_KH_KHQTXXList[] qdmodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 1, token);
                string qd = "";
                for (int i = 0; i < qdmodel.Length; i++)
                {
                    if (i == 0)
                        qd = qdmodel[i].XXMC;
                    else
                        qd = qd + "、" + qdmodel[i].XXMC;
                }
                list.QD = qd;
                list.STAFFNAME = staffmodel.STAFFNAME;
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                list.KHSOURCE = checkdata[0].KHSOURCEDES;

                //下面是经销商的子表信息
                list.CRM_OA_KH_ZXS = new CRM_OA_KH_ZXS();
                //车牌信息
                CRM_KH_KHQTXXList[] chepaimodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 6, token);
                list.CRM_OA_KH_ZXS.TABLE1List = new TABLE1[chepaimodel.Length];
                for (int i = 0; i < chepaimodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE1List[i] = new TABLE1();
                    list.CRM_OA_KH_ZXS.TABLE1List[i].CHEPAI = chepaimodel[i].XXMC;
                    list.CRM_OA_KH_ZXS.TABLE1List[i].AD = (chepaimodel[i].PD == 1) ? "有" : "无";
                    list.CRM_OA_KH_ZXS.TABLE1List[i].ZP = crmModels.HG_WJJL.Read(7, chepaimodel[i].XXID, token).Length.ToString() + "张";
                }

                //联系人信息
                CRM_KH_LXRList[] contactmodel = crmModels.KH_LXR.Read(checkdata[0].KHID, 1082, token);
                list.CRM_OA_KH_ZXS.TABLE2List = new TABLE2[contactmodel.Length];
                for (int i = 0; i < contactmodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE2List[i] = new TABLE2();
                    list.CRM_OA_KH_ZXS.TABLE2List[i].KHSTAFF = contactmodel[i].LXR;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].TEL = contactmodel[i].YDDH;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].GZNR = contactmodel[i].BEIZ;

                }





                #endregion
            }
            //终端网点
            else if (checkdata[0].KHLX == 5)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(9, token)[0].CS.ToString();
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                list.CRM_OA_KH_subWDList = new CRM_OA_KH_WD[checkdata.Length];
                for (int i = 0; i < checkdata.Length; i++)
                {
                    list.CRM_OA_KH_subWDList[i] = new CRM_OA_KH_WD();
                    CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(checkdata[i].PKHID.ToString(), token);
                    //if (pkhmodel.KHLX == 1)     //如果上级为经销商，那么经销商和直销商都填这个上级客户
                    //{
                    //    list.CRM_OA_KH_subWDList[i].JXSMC = pkhmodel.MC;
                    //    list.CRM_OA_KH_subWDList[i].JXSID = pkhmodel.SAPSN;
                    //    list.CRM_OA_KH_subWDList[i].ZXS = pkhmodel.MC;
                    //}
                    //else if (pkhmodel.KHLX == 10)   //如果上级为中间商，那么经销商填的是中间商的上级
                    //{
                    //    list.CRM_OA_KH_subWDList[i].ZXS = pkhmodel.MC;
                    //    CRM_KH_KH ppkhmodel = crmModels.KH_KH.ReadByCRMID(pkhmodel.CRMID, token);
                    //    list.CRM_OA_KH_subWDList[i].JXSMC = ppkhmodel.MC;
                    //    list.CRM_OA_KH_subWDList[i].JXSID = ppkhmodel.SAPSN;
                    //}

                    list.CRM_OA_KH_subWDList[i].ZXS = pkhmodel.MC;
                    CRM_KH_KH jxsmodel = crmModels.KH_KH.ReadJXSByKHID(checkdata[0].KHID, token);
                    list.CRM_OA_KH_subWDList[i].JXSMC = jxsmodel.MC;
                    list.CRM_OA_KH_subWDList[i].JXSID = jxsmodel.SAPSN;

                    list.CRM_OA_KH_subWDList[i].STAFFNAME = staffmodel.STAFFNAME;
                    list.CRM_OA_KH_subWDList[i].SF = crmModels.HG_DICT.ReadByDICID(checkdata[i].SF, token).DICNAME;
                    list.CRM_OA_KH_subWDList[i].CS = crmModels.HG_DICT.ReadByDICID(checkdata[i].CS, token).DICNAME;
                    list.CRM_OA_KH_subWDList[i].MC = checkdata[i].MC;
                    list.CRM_OA_KH_subWDList[i].MDDZ = checkdata[i].MDDZ;
                    list.CRM_OA_KH_subWDList[i].GSLXR = checkdata[i].GSLXR;
                    list.CRM_OA_KH_subWDList[i].GSLXDH = checkdata[i].GSLXDH;
                    list.CRM_OA_KH_subWDList[i].WDLX = crmModels.HG_DICT.ReadByDICID(checkdata[i].WDLX, token).DICNAME;
                    CRM_KH_KHQTXXList[] pinzhongmodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 2, token);
                    string pinzhong = "";
                    for (int j = 0; j < pinzhongmodel.Length; j++)
                    {
                        if (j == 0)
                            pinzhong = pinzhongmodel[j].XXMC;
                        else
                            pinzhong = pinzhong + "、" + pinzhongmodel[j].XXMC;
                    }
                    list.CRM_OA_KH_subWDList[i].XSPZ = pinzhong;

                    CRM_KH_KHQTXXList[] jingpinmodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 3, token);
                    string jingpin = "";
                    for (int j = 0; j < jingpinmodel.Length; j++)
                    {
                        if (j == 0)
                            jingpin = jingpinmodel[j].XXMC;
                        else
                            jingpin = jingpin + "、" + jingpinmodel[j].XXMC;
                    }
                    list.CRM_OA_KH_subWDList[i].JPMC = jingpin;

                    CRM_KH_KHQTXXList[] displaymodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 4, token);
                    string display = "";
                    for (int j = 0; j < displaymodel.Length; j++)
                    {
                        if (j == 0)
                            display = displaymodel[j].CLFSDES;
                        else
                            display = display + "、" + displaymodel[j].CLFSDES;
                    }
                    list.CRM_OA_KH_subWDList[i].CL = display;
                    list.CRM_OA_KH_subWDList[i].SFBZWD = checkdata[i].SFBZWD ? "是" : "否";
                    list.CRM_OA_KH_subWDList[i].BEIZ = checkdata[i].BEIZ;

                    //传图片
                    CRM_HG_WJJL[] MTZPmodel = crmModels.HG_WJJL.Read(3, checkdata[i].KHID, token);

                    List<CRM_OA_KH_WD_IMG> all = new List<CRM_OA_KH_WD_IMG>();

                    for (int j = 0; j < MTZPmodel.Length; j++)
                    {
                        CRM_OA_KH_WD_IMG temp = new CRM_OA_KH_WD_IMG();
                        temp.MTZP = MTZPmodel[j].ML;
                        temp.MTZPMC = list.CRM_OA_KH_subWDList[i].MC + "-门头照片-";
                        all.Add(temp);
                    }

                    for (int j = 0; j < displaymodel.Length; j++)
                    {
                        CRM_HG_WJJL[] CLZP = crmModels.HG_WJJL.Read(2, displaymodel[j].XXID, token);
                        for (int k = 0; k < CLZP.Length; k++)
                        {
                            CRM_OA_KH_WD_IMG temp = new CRM_OA_KH_WD_IMG();
                            temp.MTZP = CLZP[k].ML;
                            temp.MTZPMC = list.CRM_OA_KH_subWDList[i].MC + "-" + displaymodel[j].CLFSDES + "-陈列照片-";
                            all.Add(temp);
                        }
                    }

                    list.CRM_OA_KH_subWDList[i].IMG = all.ToArray();






                    //有效网点、电子锁
                    CRM_KH_KHZZList[] ZZmodel = crmModels.KH_KHZZ.ReadByKHID(checkdata[i].KHID, token);
                    list.CRM_OA_KH_subWDList[i].YOUXIAO = "否";
                    list.CRM_OA_KH_subWDList[i].ISDZS = "否";
                    for (int j = 0; j < ZZmodel.Length; j++)
                    {
                        if (ZZmodel[j].ZZMCID == 1080)    //有效网点
                        {
                            list.CRM_OA_KH_subWDList[i].YOUXIAO = "是";
                            list.CRM_OA_KH_subWDList[i].XL = ZZmodel[j].INFO1;
                            list.CRM_OA_KH_subWDList[i].SM = ZZmodel[j].INFO2;
                        }
                        if (ZZmodel[j].ZZMCID == 1058)   //电子锁
                        {
                            list.CRM_OA_KH_subWDList[i].ISDZS = "是";
                            list.CRM_OA_KH_subWDList[i].XYPP = ZZmodel[j].INFO1;
                        }

                    }

                    //活动
                    CRM_KH_HDList[] HDmodel = crmModels.KH_HD.ReadByKHID(checkdata[i].KHID, token);
                    for (int j = 0; j < HDmodel.Length; j++)
                    {
                        if (HDmodel[j].HDMC == 1078)   //床头灯活动
                        {
                            list.CRM_OA_KH_subWDList[i].HDMC = HDmodel[j].HDMCDES;
                            list.CRM_OA_KH_subWDList[i].CPLX = HDmodel[j].CPLXDES;
                            list.CRM_OA_KH_subWDList[i].SHSL = HDmodel[j].XL;
                        }
                    }
                    list.CRM_OA_KH_subWDList[i].KHZZSJ = checkdata[i].KHZZSJ;
                }

                basic.Subject = "JM037-直销终端网点登记表（CRM） " + GetJXS(checkdata[0].KHID).MC;
                #endregion
            }
            //LKA
            else if (checkdata[0].KHLX == 7)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(10, token)[0].CS.ToString();
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                list.CRM_OA_KH_LKAList = new CRM_OA_KH_LKA[checkdata.Length];
                for (int i = 0; i < checkdata.Length; i++)
                {
                    list.CRM_OA_KH_LKAList[i] = new CRM_OA_KH_LKA();
                    CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(checkdata[i].PKHID.ToString(), token);
                    //CRM_KH_KH ppkhmodel = crmModels.KH_KH.ReadByCRMID(pkhmodel.PKHID.ToString(), token);
                    CRM_KH_KH jxsmodel = crmModels.KH_KH.ReadJXSByKHID(checkdata[0].KHID, token);

                    list.CRM_OA_KH_LKAList[i].STAFFNAME = staffmodel.STAFFNAME;
                    //list.CRM_OA_KH_LKAList[i].JXSID = ppkhmodel.SAPSN;
                    //list.CRM_OA_KH_LKAList[i].JXSMC = ppkhmodel.MC;
                    list.CRM_OA_KH_LKAList[i].JXSID = jxsmodel.SAPSN;
                    list.CRM_OA_KH_LKAList[i].JXSMC = jxsmodel.MC;
                    list.CRM_OA_KH_LKAList[i].PKHMC = pkhmodel.MC;
                    list.CRM_OA_KH_LKAList[i].MDJCSL = pkhmodel.MDJCSL;
                    list.CRM_OA_KH_LKAList[i].ZBDZ = pkhmodel.MDDZ;
                    list.CRM_OA_KH_LKAList[i].MC = checkdata[i].MC;
                    list.CRM_OA_KH_LKAList[i].MCLC = crmModels.HG_DICT.ReadByDICID(checkdata[i].MCLC, token).DICNAME;
                    list.CRM_OA_KH_LKAList[i].MDDZ = checkdata[i].MDDZ;
                    list.CRM_OA_KH_LKAList[i].JCDPSL = checkdata[i].JCDPSL;
                    list.CRM_OA_KH_LKAList[i].XSSJSM = checkdata[i].XSSJSM;
                    CRM_KH_KHQTXXList[] jingpinmodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 3, token);
                    string jingpin = "";
                    for (int j = 0; j < jingpinmodel.Length; j++)
                    {
                        if (j == 0)
                            jingpin = jingpinmodel[j].XXMC;
                        else
                            jingpin = jingpin + "、" + jingpinmodel[j].XXMC;
                    }
                    list.CRM_OA_KH_LKAList[i].JP = jingpin;

                    CRM_KH_KHQTXXList[] displaymodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 4, token);
                    string display_major = "";
                    string display_no2 = "";
                    for (int j = 0; j < displaymodel.Length; j++)
                    {
                        if (displaymodel[j].CLLX == 1)
                        {
                            if (display_major == "")
                                display_major = displaymodel[j].CLFSDES;
                            else
                                display_major = display_major + "、" + displaymodel[j].CLFSDES;
                        }
                        else if (displaymodel[j].CLLX == 2)
                        {
                            if (display_no2 == "")
                                display_no2 = displaymodel[j].CLFSDES;
                            else
                                display_no2 = display_no2 + "、" + displaymodel[j].CLFSDES;
                        }

                    }
                    list.CRM_OA_KH_LKAList[i].ZCL = display_major;
                    list.CRM_OA_KH_LKAList[i].ECCL = display_no2;
                    list.CRM_OA_KH_LKAList[i].BEIZ = checkdata[i].BEIZ;


                    //有效网点
                    CRM_KH_KHZZList[] ZZmodel = crmModels.KH_KHZZ.ReadByKHID(checkdata[i].KHID, token);
                    list.CRM_OA_KH_LKAList[i].YOUXIAO = "否";
                    for (int j = 0; j < ZZmodel.Length; j++)
                    {
                        if (ZZmodel[j].ZZMCID == 1080)    //有效网点
                        {
                            list.CRM_OA_KH_LKAList[i].YOUXIAO = "是";
                            list.CRM_OA_KH_LKAList[i].XL = ZZmodel[j].INFO1;
                            list.CRM_OA_KH_LKAList[i].SM = ZZmodel[j].INFO2;
                        }

                    }
                    list.CRM_OA_KH_LKAList[i].KHZZSJ = checkdata[i].KHZZSJ;

                }


                basic.Subject = "JM038-LKA网点登记表（CRM） " + crmModels.KH_KH.ReadByCRMID(checkdata[0].PKHID.ToString(), token).MC;

                #endregion
            }
            //直销商&中间商
            else if (checkdata[0].KHLX == 9 || checkdata[0].KHLX == 10)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(11, token)[0].CS.ToString();
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                list.CRM_OA_KH_ZXS = new CRM_OA_KH_ZXS();
                list.CRM_OA_KH_ZXS.SF = crmModels.HG_DICT.ReadByDICID(checkdata[0].SF, token).DICNAME;
                list.CRM_OA_KH_ZXS.MC = checkdata[0].MC;
                list.KHLX2 = checkdata[0].KHLX2DES;
                CRM_KH_KHXS xsmodel = new CRM_KH_KHXS();
                xsmodel.KHID = checkdata[0].KHID;
                xsmodel.XSLB = 2;
                xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                CRM_KH_KHXSList[] xsdata = crmModels.KH_KHXS.Read(xsmodel, token);
                if (xsdata.Length < 3)
                {
                    //直销商销售数据没有填写完整
                }
                for (int i = 0; i < xsdata.Length; i++)
                {
                    switch (xsdata[i].XSMC)
                    {
                        case "销售":
                            list.CRM_OA_KH_ZXS.XS = xsdata[i].XSJE.ToString();
                            break;
                        case "碱性销售":
                            list.CRM_OA_KH_ZXS.JXXS = xsdata[i].XSJE.ToString();
                            break;
                        case "A类销售":
                            list.CRM_OA_KH_ZXS.AXS = xsdata[i].XSJE.ToString();
                            break;
                        default:
                            break;
                    }
                }
                CRM_KH_GXQYList[] AreaModel = crmModels.KH_GXQY.Read(checkdata[0].KHID, token);
                string area = "";
                for (int i = 0; i < AreaModel.Length; i++)
                {
                    if (i == 0)
                        area = AreaModel[i].GXQYMCDES;
                    else
                        area = area + "、" + AreaModel[i].GXQYMCDES;
                }
                list.CRM_OA_KH_ZXS.AREA = area;
                list.CRM_OA_KH_ZXS.GSLXR = checkdata[0].GSLXR;
                list.CRM_OA_KH_ZXS.GSLXDH = checkdata[0].GSLXDH;
                list.CRM_OA_KH_ZXS.MDDZ = checkdata[0].MDDZ;


                xsmodel.XSLB = 3;
                xsmodel.XSMC = "网点数量";
                xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                CRM_KH_KHXSList[] wdsldata = crmModels.KH_KHXS.Read(xsmodel, token);
                if (wdsldata.Length == 0)
                {
                    //没有网点数量数据
                    list.CRM_OA_KH_ZXS.WDSL = "";
                }
                else
                {
                    list.CRM_OA_KH_ZXS.WDSL = wdsldata[0].XSSL.ToString();
                }


                xsmodel.XSMC = "目标网点数量";
                xsmodel.XSLB = 3;
                xsmodel.GSRQ = (DateTime.Now.Year).ToString();
                CRM_KH_KHXSList[] mbwdsldata = crmModels.KH_KHXS.Read(xsmodel, token);
                if (mbwdsldata.Length == 0)
                {
                    //没有目标网点数量数据
                    list.CRM_OA_KH_ZXS.MBWDSL = "";
                }
                else
                {
                    list.CRM_OA_KH_ZXS.MBWDSL = mbwdsldata[0].XSSL.ToString();
                }

                list.CRM_OA_KH_ZXS.BEIZ = checkdata[0].BEIZ;

                //CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(checkdata[0].PKHID.ToString(), token);
                //list.CRM_OA_KH_ZXS.JXSMC = pkhmodel.MC;
                //list.CRM_OA_KH_ZXS.JXSID = pkhmodel.SAPSN;

                CRM_KH_KH jxsmodel = crmModels.KH_KH.ReadJXSByKHID(checkdata[0].KHID, token);
                list.CRM_OA_KH_ZXS.JXSMC = jxsmodel.MC;
                list.CRM_OA_KH_ZXS.JXSID = jxsmodel.SAPSN;

                //车牌信息
                CRM_KH_KHQTXXList[] chepaimodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 6, token);
                list.CRM_OA_KH_ZXS.TABLE1List = new TABLE1[chepaimodel.Length];
                for (int i = 0; i < chepaimodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE1List[i] = new TABLE1();
                    list.CRM_OA_KH_ZXS.TABLE1List[i].CHEPAI = chepaimodel[i].XXMC;
                    list.CRM_OA_KH_ZXS.TABLE1List[i].AD = (chepaimodel[i].PD == 1) ? "有" : "无";
                    list.CRM_OA_KH_ZXS.TABLE1List[i].ZP = crmModels.HG_WJJL.Read(7, chepaimodel[i].XXID, token).Length.ToString() + "张";
                }

                //联系人信息
                CRM_KH_LXRList[] contactmodel = crmModels.KH_LXR.Read(checkdata[0].KHID, 1082, token);
                list.CRM_OA_KH_ZXS.TABLE2List = new TABLE2[contactmodel.Length];
                for (int i = 0; i < contactmodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE2List[i] = new TABLE2();
                    list.CRM_OA_KH_ZXS.TABLE2List[i].KHSTAFF = contactmodel[i].LXR;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].TEL = contactmodel[i].YDDH;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].GZNR = contactmodel[i].BEIZ;

                }


                //促销单品信息
                CRM_KH_KHQTXXList[] dpmodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 7, token);
                list.CRM_OA_KH_ZXS.TABLE3List = new TABLE3[dpmodel.Length];
                for (int i = 0; i < dpmodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE3List[i] = new TABLE3();
                    list.CRM_OA_KH_ZXS.TABLE3List[i].DPMC = dpmodel[i].XXMC;
                    list.CRM_OA_KH_ZXS.TABLE3List[i].CD = (dpmodel[i].PD == 1) ? "是" : "否";

                }


                #endregion
            }
            else
            {
                MessageInfo errinfo = new MessageInfo();
                errinfo.Key = "-1";
                errinfo.Value = "无法找到对应的客户类型";
                return Newtonsoft.Json.JsonConvert.SerializeObject(errinfo);
            }

            if (checkdata[0].KHLX == 5 || checkdata[0].KHLX == 7 || checkdata[0].KHLX == 10)
            {
                MessageInfo info = new MessageInfo();
                info.Key = "1";
                info.Value = "提交成功";
                for (int i = 0; i < checkdata.Length; i++)
                {
                    CRM_KH_KH kh = crmModels.KH_KH.ReadByCRMID(checkdata[i].CRMID, token);
                    if (checkdata[i].KHLX == 7 && checkdata[i].MCSX == 1)
                    {
                        kh.ISACTIVE = 2;
                    }
                    else
                    {
                        kh.ISACTIVE = 3;
                    }
                    int id = crmModels.KH_KH.Update(kh, token, true);
                    if (id < 0)
                    {
                        info.Key = "0";
                        info.Value = "提交失败";
                    }
                }
                return Newtonsoft.Json.JsonConvert.SerializeObject(info);
            }
            else
            {
                MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
                if (info.Key != "0" && info.Key != "-1")
                {

                    for (int i = 0; i < checkdata.Length; i++)
                    {
                        CRM_KH_KH kh = crmModels.KH_KH.ReadByCRMID(checkdata[i].CRMID, token);
                        kh.ISACTIVE = 2;
                        crmModels.KH_KH.Update(kh, token, true);

                        CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                        model.OAID = info.Key;
                        model.OACSBH = kh.KHID;
                        switch (checkdata[i].KHLX)
                        {
                            case 1:
                                model.OACSLB = 551;
                                break;
                            case 2:
                                model.OACSLB = 551;
                                break;
                            case 4:
                                model.OACSLB = 551;
                                break;
                            case 5:
                                model.OACSLB = 921;
                                break;
                            case 7:
                                model.OACSLB = 922;
                                break;
                            case 9:
                                model.OACSLB = 923;
                                break;
                            case 10:
                                model.OACSLB = 923;
                                break;
                            default:
                                model.OACSLB = 0;
                                break;
                        }

                        model.OAZT = 1;
                        model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                        crmModels.OA_TRANSMIT.Create(model, token);
                    }

                }
                return Newtonsoft.Json.JsonConvert.SerializeObject(info);
            }





        }

        [HttpPost]
        public int Data_Insert_XSYWJZ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_XSYWJZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_XSYWJZ>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_XSYWJZ.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_XSYWJZ_ByKHID(int KHID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_XSYWJZList[] data = crmModels.KH_XSYWJZ.ReadByKHID(KHID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public int Data_Update_XSYWJZ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_XSYWJZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_XSYWJZ>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_XSYWJZ.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_XSYWJZ(int XSYWJZID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_XSYWJZ.Delete(XSYWJZID, token);
            return i;
        }

        [HttpPost]
        public int Data_TurnKH_Official(string CRMID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KH data = crmModels.KH_KH.ReadByCRMID(CRMID, token);
            CRM_KH_XSYWJZList[] JZdata = crmModels.KH_XSYWJZ.ReadByKHID(data.KHID, token);
            if (JZdata.Length == 0 || JZdata[JZdata.Length - 1].JZID != 1056)
            {
                return -1;
            }


            data.ISACTIVE = 1;
            if (data.KHLX == 5 || data.KHLX == 7 || data.KHLX == 10)
            {
                data.IsOfficial = 30;
            }
            else
            {
                data.IsOfficial = 20;
                if (data.KHLX == 3 || data.KHLX == 1106)
                    data.ISACTIVE = 3;
            }


            int i = crmModels.KH_KH.Update(data, token, true);
            return i;
        }

        [HttpPost]
        public int Data_Insert_KHZZ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHZZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHZZ>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_KHZZ.Create(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Update_KHZZ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHZZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHZZ>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_KHZZ.Update(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_KHZZ_ByKHID(int KHID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHZZList[] data = crmModels.KH_KHZZ.ReadByKHID(KHID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public int Data_Delete_KHZZ(int ZZID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KH_KHZZ.Delete(ZZID, token);
            return i;
        }

        public ActionResult DataReport()
        {
            Session["location"] = 63;
            return View();
        }

        public ActionResult Report_LKA()
        {
            Session["location"] = 93;
            return View();
        }

        public ActionResult Report_DisplayImg()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 553;
            CRM_HG_DICT[] KHLX = crmModels.HG_DICT.Read(32, 0, token);
            ViewBag.KHLX = KHLX;
            CRM_HG_DICT[] HDMC = crmModels.HG_DICT.Read(46, 0, token);
            ViewBag.HDMC = HDMC;
            CRM_HG_DICT[] YYZT = crmModels.HG_DICT.Read(114, 0, token);
            ViewBag.YYZT = YYZT;
            return View();
        }

        [HttpPost]
        public string Data_Select_DZSreport(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHXS_DZSreport model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHXS_DZSreport>(cxdata);
            CRM_KH_KHXS_DZSreportList[] data = crmModels.KH_KHXS.DZSreport(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_FileUpload_DZSreport_daochu(string data)
        {
            token = appClass.CRM_Gettoken();
            try
            {
                CRM_KH_KHXS_DZSreportList[] model = JsonConvert.DeserializeObject<CRM_KH_KHXS_DZSreportList[]>(data);


                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/电子锁报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("Sheet1");
                if (worksheet1 == null)
                    return "工作薄中没有工作表";
                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 2;
                string uprowKH = "";
                int start = 2;    //前两行是标题
                int end = 3;
                for (int i = 0; i < model.Length; i++)
                {

                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                    row.CreateCell(0).SetCellValue(model[i].CZSJ);
                    row.CreateCell(1).SetCellValue(model[i].STAFFNAME);
                    row.CreateCell(2).SetCellValue(model[i].FGLDNAME);
                    row.CreateCell(3).SetCellValue(model[i].SFDES);
                    row.CreateCell(4).SetCellValue(model[i].CSDES);
                    row.CreateCell(5).SetCellValue(model[i].JXSID);
                    row.CreateCell(6).SetCellValue(model[i].JXSNAME);
                    row.CreateCell(7).SetCellValue(model[i].JXSSAPSN);
                    row.CreateCell(8).SetCellValue(model[i].CRMID);
                    row.CreateCell(9).SetCellValue(model[i].MC);
                    row.CreateCell(10).SetCellValue(model[i].MDDZ);
                    row.CreateCell(11).SetCellValue(model[i].GSLXR);
                    row.CreateCell(12).SetCellValue(model[i].GSLXDH);
                    row.CreateCell(13).SetCellValue(model[i].WDLXDES);
                    row.CreateCell(14).SetCellValue(model[i].XYPP);
                    row.CreateCell(15).SetCellValue(model[i].SH_CS);
                    row.CreateCell(16).SetCellValue(model[i].SH_SL);
                    row.CreateCell(17).SetCellValue(model[i].SH_SJ);
                    row.CreateCell(18).SetCellValue(model[i].FIDDES);
                    row.CreateCell(19).SetCellValue(model[i].CZRQ);
                    row.CreateCell(20).SetCellValue(model[i].CZRDES);



                    if (i > 0)    //第二行数据
                    {
                        if (uprowKH != model[i].CRMID)    //当客户名称与上一行不一样时
                        {
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 0, 0));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 1, 1));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 2, 2));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 3, 3));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 4, 4));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 5, 5));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 6, 6));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 7, 7));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 8, 8));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 9, 9));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 10, 10));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 11, 11));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 12, 12));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 13, 13));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 14, 14));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 18, 18));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 20, 20));

                            start = row1;
                            end = row1;
                        }
                        else
                        {
                            end = row1;
                        }
                    }



                    row1++;

                    uprowKH = model[i].CRMID;

                }

                //把最后一个客户的多行数据合并
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 0, 0));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 1, 1));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 2, 2));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 3, 3));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 4, 4));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 5, 5));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 6, 6));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 7, 7));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 8, 8));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 9, 9));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 10, 10));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 11, 11));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 12, 12));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 13, 13));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 14, 14));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 18, 18));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 20, 20));


                worksheet1.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch (Exception e)
            {
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = "err：" + e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }


        }

        [HttpPost]
        public string Data_DaoChu_DZSreportAll(string cxdata)
        {
            token = appClass.CRM_Gettoken();


            try
            {
                CRM_KH_KHXS_DZSreport cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHXS_DZSreport>(cxdata);

                CRM_KH_KHXS_DZSreportList[] model = crmModels.KH_KHXS.DZSreport(cxmodel, appClass.CRM_GetStaffid(), token);


                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/电子锁报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("Sheet1");
                if (worksheet1 == null)
                    return "工作薄中没有工作表";
                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 2;
                string uprowKH = "";
                int start = 2;    //前两行是标题
                int end = 3;
                for (int i = 0; i < model.Length; i++)
                {

                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                    row.CreateCell(0).SetCellValue(model[i].CZSJ);
                    row.CreateCell(1).SetCellValue(model[i].STAFFNAME);
                    row.CreateCell(2).SetCellValue(model[i].FGLDNAME);
                    row.CreateCell(3).SetCellValue(model[i].SFDES);
                    row.CreateCell(4).SetCellValue(model[i].CSDES);
                    row.CreateCell(5).SetCellValue(model[i].JXSID);
                    row.CreateCell(6).SetCellValue(model[i].JXSNAME);
                    row.CreateCell(7).SetCellValue(model[i].JXSSAPSN);
                    row.CreateCell(8).SetCellValue(model[i].CRMID);
                    row.CreateCell(9).SetCellValue(model[i].MC);
                    row.CreateCell(10).SetCellValue(model[i].MDDZ);
                    row.CreateCell(11).SetCellValue(model[i].GSLXR);
                    row.CreateCell(12).SetCellValue(model[i].GSLXDH);
                    row.CreateCell(13).SetCellValue(model[i].WDLXDES);
                    row.CreateCell(14).SetCellValue(model[i].XYPP);
                    row.CreateCell(15).SetCellValue(model[i].SH_CS);
                    row.CreateCell(16).SetCellValue(model[i].SH_SL);
                    row.CreateCell(17).SetCellValue(model[i].SH_SJ);
                    row.CreateCell(18).SetCellValue(model[i].FIDDES);
                    row.CreateCell(19).SetCellValue(model[i].CZRQ);
                    row.CreateCell(20).SetCellValue(model[i].CZRDES);



                    if (i > 0)    //第二行数据
                    {
                        if (uprowKH != model[i].CRMID)    //当客户名称与上一行不一样时
                        {
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 0, 0));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 1, 1));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 2, 2));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 3, 3));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 4, 4));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 5, 5));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 6, 6));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 7, 7));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 8, 8));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 9, 9));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 10, 10));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 11, 11));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 12, 12));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 13, 13));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 14, 14));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 18, 18));
                            worksheet1.AddMergedRegion(new CellRangeAddress(start, row1 - 1, 20, 20));

                            start = row1;
                            end = row1;
                        }
                        else
                        {
                            end = row1;
                        }
                    }



                    row1++;

                    uprowKH = model[i].CRMID;

                }

                //把最后一个客户的多行数据合并
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 0, 0));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 1, 1));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 2, 2));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 3, 3));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 4, 4));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 5, 5));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 6, 6));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 7, 7));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 8, 8));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 9, 9));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 10, 10));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 11, 11));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 12, 12));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 13, 13));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 14, 14));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 18, 18));
                worksheet1.AddMergedRegion(new CellRangeAddress(start, end, 20, 20));


                worksheet1.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch (Exception e)
            {
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = "err：" + e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }


        }

        [HttpPost]
        public int Data_Insert_KHHD(string data)
        {
            token = APPCLASS.AppClass.GetSession("token").ToString();

            CRM_KH_HD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_HD>(data);
            model.CZR = Convert.ToInt32(APPCLASS.AppClass.GetSession("STAFFID"));
            int i = crmModels.KH_HD.Create(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Update_KHHD(string data)
        {
            token = APPCLASS.AppClass.GetSession("token").ToString();

            CRM_KH_HD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_HD>(data);
            model.CZR = Convert.ToInt32(APPCLASS.AppClass.GetSession("STAFFID"));
            int i = crmModels.KH_HD.Update(model, token);

            return i;
        }

        [HttpPost]
        public string Data_Select_KHHD_ByKHID(int KHID)
        {
            token = APPCLASS.AppClass.GetSession("token").ToString();

            CRM_KH_HDList[] data = crmModels.KH_HD.ReadByKHID(KHID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public int Data_Delete_KHHD(int HDID)
        {
            token = APPCLASS.AppClass.GetSession("token").ToString();

            int i = crmModels.KH_HD.Delete(HDID, token);

            return i;
        }

        [HttpPost]
        public string Data_Select_ZDWDreport(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KH_Report_ZDWD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KH_Report_ZDWD>(cxdata);
            CRM_KH_KH_Report_ZDWDList[] data = crmModels.KH_KH.Report_ZDWD(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_LKAreport(string cxdata)           //按客户组权限
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KH_Report_LKA model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KH_Report_LKA>(cxdata);
            CRM_KH_KH_Report_LKAList[] data = crmModels.KH_KH.Report_LKA(model, appClass.CRM_GetStaffid(), 1, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_LKAreportAll(string cxdata)        //不按权限，查询全部LKA
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KH_Report_LKA model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KH_Report_LKA>(cxdata);
            CRM_KH_KH_Report_LKAList[] data = crmModels.KH_KH.Report_LKA(model, appClass.CRM_GetStaffid(), 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_DaoChu_ZDWDreport(string data)
        {
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 6, "");

            return result;
        }

        [HttpPost]
        public string Data_DaoChu_ZDWDreportAll(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KH_Report_ZDWD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KH_Report_ZDWD>(cxdata);
            CRM_KH_KH_Report_ZDWDList[] data = crmModels.KH_KH.Report_ZDWD(model, appClass.CRM_GetStaffid(), token);
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(Newtonsoft.Json.JsonConvert.SerializeObject(data), 6, "");

            return result;
        }

        [HttpPost]
        public string Data_DaoChu_LKAreport(string data)
        {
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 7, "");

            return result;
        }

        [HttpPost]
        public string Data_DaoChu_LKAreportAll(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KH_Report_LKA model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KH_Report_LKA>(cxdata);
            CRM_KH_KH_Report_LKAList[] data = crmModels.KH_KH.Report_LKA(model, appClass.CRM_GetStaffid(), 1, token);
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(Newtonsoft.Json.JsonConvert.SerializeObject(data), 7, "");

            return result;
        }

        private CRM_KH_KH GetJXS(int khid)
        {
            //进来的是终端网点的PKHID
            token = appClass.CRM_Gettoken();
            //string PKHID = pkhid.ToString();
            //CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(PKHID, token);
            //if (pkhmodel.KHLX == 1)     //如果上级为经销商，那么经销商和直销商都填这个上级客户
            //{
            //    return pkhmodel.CRMID;
            //}
            //else if (pkhmodel.KHLX == 10)   //如果上级为中间商，那么经销商填的是中间商的上级
            //{
            //    CRM_KH_KH ppkhmodel = crmModels.KH_KH.ReadByCRMID(pkhmodel.CRMID, token);
            //    return ppkhmodel.CRMID;
            //}
            //else
            //{
            //    return "0";
            //}

            CRM_KH_KH jxsmodel = crmModels.KH_KH.ReadJXSByKHID(khid, token);
            return jxsmodel;

        }

        [HttpPost]
        public string Data_SelectJXS(int KHID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KH data = crmModels.KH_KH.ReadJXSByKHID(KHID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_UpdateKH_Submit(string data, string zzdata)
        {
            token = appClass.CRM_Gettoken();

            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH Updatemodel = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH>(data);
            Updatemodel.FID = Convert.ToInt32(Session["STAFFID"]);
            //如果这个客户目前没有进任何分组，那么当当前人员只有一个分组时，默认把这个客户分配进这个分组
            if (crmModels.KH_GROUP_KH.ReadByKHID(token, Updatemodel.KHID).Length == 0)         //这个客户没有归属于任何分组
            {
                if (crmModels.KH_GROUP_STAFF.ReadByStaffID(Convert.ToInt32(Session["STAFFID"]), token).Length != 1)        //这个人员有多个分组
                {
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "请给客户分配分组！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "请给" + Updatemodel.MC + "客户分配分组";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            if (Updatemodel.KHLX == 5 && crmModels.KH_HD.ReadByKHID(Updatemodel.KHID, token).Length == 0)      //是终端网点且没有活动信息
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "请输入客户活动信息！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            int count = crmModels.KH_KH.Update(Updatemodel, token, true);

            crmModels.KH_KHZZ.DeleteByKHID(Updatemodel.KHID, token);
            CRM_KH_KHZZ[] zzmodel = JsonConvert.DeserializeObject<CRM_KH_KHZZ[]>(zzdata);
            for (int i = 0; i < zzmodel.Length; i++)
            {
                zzmodel[i].CZR = Convert.ToInt32(Session["STAFFID"]);
                zzmodel[i].KHID = Updatemodel.KHID;
                int j = crmModels.KH_KHZZ.Create(zzmodel[i], token);
                if (j <= 0)
                {
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "修改失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }

            //return count;



            CRM_Report_KHModel cxmodel = new CRM_Report_KHModel();
            cxmodel.CRMID = Updatemodel.CRMID;
            CRM_KH_KHList[] checkdata = crmModels.KH_KH.Report(cxmodel, Convert.ToInt32(Session["STAFFID"]), token);

            for (int i = 0; i < checkdata.Length; i++)
            {
                if (crmModels.KH_GROUP_KH.ReadByKHID(token, checkdata[i].KHID).Length == 0)
                {
                    //客户没有分组
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "请给" + checkdata[i].MC + "客户分配分组";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                if (crmModels.KH_DZ.ReadByKHID(checkdata[i].KHID, token).Length == 0)
                {
                    //客户没有签到地址
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "请给" + checkdata[i].MC + "客户添加签到地址";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }


            //校验当客户是直销商时，直销必填项是否有数据
            if (checkdata[0].KHLX == 1 || checkdata[0].KHLX == 10)
            {
                if (checkdata[0].KHLX2 == 1064)    //该客户是直销商
                {

                    //车牌
                    CRM_KH_KHQTXXList[] chepaimodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 6, token);
                    if (chepaimodel.Length < 1)
                    {
                        //车牌数据没有填写完整
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "汽车或者电动车没有填写完整";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        for (int i = 0; i < chepaimodel.Length; i++)
                        {
                            CRM_HG_WJJL[] chepaiIMG = crmModels.HG_WJJL.Read(7, chepaimodel[i].XXID, token);
                            if (chepaiIMG.Length < 1)
                            {
                                //车牌没有图片
                                MessageInfo msg = new MessageInfo();
                                msg.Key = "0";
                                msg.Value = "汽车或者电动车需要上传照片";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }

                    //直销人员信息
                    CRM_KH_LXRList[] contactmodel = crmModels.KH_LXR.Read(checkdata[0].KHID, 1082, token);
                    if (contactmodel.Length < 1)
                    {
                        //直销人员数据没有填写完整
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "人员信息没有填写完整";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }


                    if (checkdata[0].KHLX == 10)
                    {
                        CRM_KH_KHXS xsmodel = new CRM_KH_KHXS();
                        xsmodel.KHID = checkdata[0].KHID;
                        xsmodel.XSLB = 2;
                        xsmodel.XSMC = "销售";
                        xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                        CRM_KH_KHXSList[] xsdata = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (xsdata.Length != 1)
                        {
                            //直销商销售数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "直销商销售没有填写完整";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        xsmodel.XSMC = "碱性销售";
                        CRM_KH_KHXSList[] xsdata2 = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (xsdata2.Length != 1)
                        {
                            //直销商销售数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "直销商碱性销售没有填写完整";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        xsmodel.XSMC = "A类销售";
                        CRM_KH_KHXSList[] xsdata3 = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (xsdata3.Length != 1)
                        {
                            //直销商销售数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "直销商A类没有填写完整";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        xsmodel.XSMC = "网点数量";
                        xsmodel.XSLB = 3;
                        xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                        CRM_KH_KHXSList[] wdsldata = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (wdsldata.Length != 1)
                        {
                            //网点数量数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "网点数量填写有误";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        xsmodel.XSMC = "目标网点数量";
                        xsmodel.XSLB = 3;
                        xsmodel.GSRQ = (DateTime.Now.Year).ToString();
                        CRM_KH_KHXSList[] mbwdsldata = crmModels.KH_KHXS.Read(xsmodel, token);
                        if (mbwdsldata.Length != 1)
                        {
                            //网点数量数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "目标网点数量填写有误";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                        //促销单品信息
                        CRM_KH_KHQTXXList[] dpmodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 7, token);
                        if (dpmodel.Length < 1)
                        {
                            //促销单品信息数据没有填写完整
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "促销单品信息没有填写完整";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                    }



                }
            }
            else if (checkdata[0].KHLX == 5)
            {
                string jxsid = GetJXS(checkdata[0].KHID).CRMID;
                for (int i = 0; i < checkdata.Length; i++)
                {
                    if (crmModels.KH_HD.ReadByKHID(checkdata[i].KHID, token).Length == 0)
                    {
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "终端网点客户需输入客户活动信息！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    for (int j = 0; j < checkdata.Length; j++)
                    {
                        if (GetJXS(checkdata[i].KHID).CRMID != GetJXS(checkdata[j].KHID).CRMID)
                        {
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "所选客户必须为同一个经销商下的网点！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    //if (GetJXS(checkdata[i].KHID).CRMID != jxsid)
                    //{
                    //    MessageInfo msg = new MessageInfo();
                    //    msg.Key = "0";
                    //    msg.Value = "所选客户必须为同一个经销商下的网点！";
                    //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    //}
                    CRM_KH_HD[] HuoDong = crmModels.KH_HD.ReadByKHID(checkdata[0].KHID, token);
                    for (int j = 0; j < HuoDong.Length; j++)
                    {
                        CRM_HG_WJJL[] IMG = crmModels.HG_WJJL.Read(8, HuoDong[j].HDID, token);
                        if (IMG.Length == 0)
                        {
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "所选客户必须上传活动照片！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                }

            }
            else if (checkdata[0].KHLX == 7)
            {
                int pkhid = checkdata[0].PKHID;
                for (int i = 0; i < checkdata.Length; i++)
                {
                    if (checkdata[i].MCSX == 1)
                    {
                        int XXLB = 3;
                        CRM_KH_KHQTXXList[] nnData = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, XXLB, token);
                        if (nnData.Length == 0)
                        {
                            MessageInfo msg = new MessageInfo();
                            msg.Key = "0";
                            msg.Value = "客户：" + checkdata[i].MC + "，没有竞品,不允许提交，请检查数据";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    if (checkdata[i].PKHID != pkhid)
                    {
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "所选客户必须为同一个系统下的门店！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                CRM_KH_KHQTXXList[] DISPLAY = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 4, token);
                for (int j = 0; j < DISPLAY.Length; j++)
                {
                    CRM_HG_WJJL[] IMG = crmModels.HG_WJJL.Read(2, DISPLAY[j].XXID, token);
                    if (IMG.Length == 0)
                    {
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "所选客户必须上传陈列照片！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
            }

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;

            //basic.Subject = crmModels.HG_DICT.ReadByDICID(checkdata[0].KHLX,token).DICNAME + "客户审核申请(" + staffmodel.STAFFNAME;


            CRM_OA_KH list = new CRM_OA_KH();

            //经销商
            if (checkdata[0].KHLX == 1 || checkdata[0].KHLX == 2 || checkdata[0].KHLX == 4)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(8, token)[0].CS.ToString();
                list.MC = checkdata[0].MC;
                list.JPXZ = crmModels.HG_DICT.ReadByDICID(checkdata[0].KPXZ, token).DICNAME;
                list.KPDZ = checkdata[0].KPDZ;
                list.KPDH = checkdata[0].KPDH;
                list.NSRSBH = checkdata[0].NSRSBH;
                list.YHZH = checkdata[0].YHZH;
                list.YHMC = checkdata[0].YHMC;
                list.GSLXR = checkdata[0].GSLXR;
                list.GSLXDH = checkdata[0].GSLXDH;
                list.FR = checkdata[0].FR;
                list.GSFRGX = checkdata[0].GSFRGX;
                list.KDJSDZ = checkdata[0].KDJSDZ;
                list.KDLXR = checkdata[0].KDLXR;
                list.KDLXDH = checkdata[0].KDLXDH;
                list.HTXSRW = checkdata[0].HTXSRW;
                list.HTJXXSRW = checkdata[0].HTJXXSRW;
                list.XSSJSM = checkdata[0].XSSJSM;
                list.FLSJSM = checkdata[0].FLSJSM;
                list.SFCCJ = checkdata[0].SFCCJ ? "是" : checkdata[0].SFCCJSM;
                list.KHSHDZ = checkdata[0].KHSHDZ;
                list.KHSHLXR = checkdata[0].KHSHLXR;
                list.KHSHLXDH = checkdata[0].KHSHLXDH;
                list.TSQKSM = checkdata[0].TSQKSM;
                list.KHJS = checkdata[0].KHJS;
                list.TITLE = crmModels.HG_DICT.ReadByDICID(checkdata[0].KHLX, token).DICNAME;
                list.FIRSTAMOUNT = checkdata[0].FIRSTAMOUNT;
                list.JOINACTIVITY = checkdata[0].JOINACTIVITY.ToString();

                CRM_KH_GXQYList[] AreaModel = crmModels.KH_GXQY.Read(checkdata[0].KHID, token);
                string area = "";
                for (int i = 0; i < AreaModel.Length; i++)
                {
                    if (i == 0)
                        area = AreaModel[i].GXQYMCDES;
                    else
                        area = area + "、" + AreaModel[i].GXQYMCDES;
                }
                list.GXQY = area;
                list.JXSYX = checkdata[0].JXSYX ? "是" : "否";
                list.YXSM = checkdata[0].YXSM;
                CRM_KH_KHQTXXList[] qdmodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 1, token);
                string qd = "";
                for (int i = 0; i < qdmodel.Length; i++)
                {
                    if (i == 0)
                        qd = qdmodel[i].XXMC;
                    else
                        qd = qd + "、" + qdmodel[i].XXMC;
                }
                list.QD = qd;
                list.STAFFNAME = staffmodel.STAFFNAME;
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                list.KHSOURCE = checkdata[0].KHSOURCEDES;

                //下面是经销商的子表信息
                list.CRM_OA_KH_ZXS = new CRM_OA_KH_ZXS();
                //车牌信息
                CRM_KH_KHQTXXList[] chepaimodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 6, token);
                list.CRM_OA_KH_ZXS.TABLE1List = new TABLE1[chepaimodel.Length];
                for (int i = 0; i < chepaimodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE1List[i] = new TABLE1();
                    list.CRM_OA_KH_ZXS.TABLE1List[i].CHEPAI = chepaimodel[i].XXMC;
                    list.CRM_OA_KH_ZXS.TABLE1List[i].AD = (chepaimodel[i].PD == 1) ? "有" : "无";
                    list.CRM_OA_KH_ZXS.TABLE1List[i].ZP = crmModels.HG_WJJL.Read(7, chepaimodel[i].XXID, token).Length.ToString() + "张";
                }

                //联系人信息
                CRM_KH_LXRList[] contactmodel = crmModels.KH_LXR.Read(checkdata[0].KHID, 1082, token);
                list.CRM_OA_KH_ZXS.TABLE2List = new TABLE2[contactmodel.Length];
                for (int i = 0; i < contactmodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE2List[i] = new TABLE2();
                    list.CRM_OA_KH_ZXS.TABLE2List[i].KHSTAFF = contactmodel[i].LXR;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].TEL = contactmodel[i].YDDH;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].GZNR = contactmodel[i].BEIZ;

                }





                #endregion
            }
            //终端网点
            else if (checkdata[0].KHLX == 5)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(9, token)[0].CS.ToString();
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                list.CRM_OA_KH_subWDList = new CRM_OA_KH_WD[checkdata.Length];
                for (int i = 0; i < checkdata.Length; i++)
                {
                    list.CRM_OA_KH_subWDList[i] = new CRM_OA_KH_WD();
                    CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(checkdata[i].PKHID.ToString(), token);
                    //if (pkhmodel.KHLX == 1)     //如果上级为经销商，那么经销商和直销商都填这个上级客户
                    //{
                    //    list.CRM_OA_KH_subWDList[i].JXSMC = pkhmodel.MC;
                    //    list.CRM_OA_KH_subWDList[i].JXSID = pkhmodel.SAPSN;
                    //    list.CRM_OA_KH_subWDList[i].ZXS = pkhmodel.MC;
                    //}
                    //else if (pkhmodel.KHLX == 10)   //如果上级为中间商，那么经销商填的是中间商的上级
                    //{
                    //    list.CRM_OA_KH_subWDList[i].ZXS = pkhmodel.MC;
                    //    CRM_KH_KH ppkhmodel = crmModels.KH_KH.ReadByCRMID(pkhmodel.CRMID, token);
                    //    list.CRM_OA_KH_subWDList[i].JXSMC = ppkhmodel.MC;
                    //    list.CRM_OA_KH_subWDList[i].JXSID = ppkhmodel.SAPSN;
                    //}

                    list.CRM_OA_KH_subWDList[i].ZXS = pkhmodel.MC;
                    CRM_KH_KH jxsmodel = crmModels.KH_KH.ReadJXSByKHID(checkdata[0].KHID, token);
                    list.CRM_OA_KH_subWDList[i].JXSMC = jxsmodel.MC;
                    list.CRM_OA_KH_subWDList[i].JXSID = jxsmodel.SAPSN;

                    list.CRM_OA_KH_subWDList[i].STAFFNAME = staffmodel.STAFFNAME;
                    list.CRM_OA_KH_subWDList[i].SF = crmModels.HG_DICT.ReadByDICID(checkdata[i].SF, token).DICNAME;
                    list.CRM_OA_KH_subWDList[i].CS = crmModels.HG_DICT.ReadByDICID(checkdata[i].CS, token).DICNAME;
                    list.CRM_OA_KH_subWDList[i].MC = checkdata[i].MC;
                    list.CRM_OA_KH_subWDList[i].MDDZ = checkdata[i].MDDZ;
                    list.CRM_OA_KH_subWDList[i].GSLXR = checkdata[i].GSLXR;
                    list.CRM_OA_KH_subWDList[i].GSLXDH = checkdata[i].GSLXDH;
                    list.CRM_OA_KH_subWDList[i].WDLX = crmModels.HG_DICT.ReadByDICID(checkdata[i].WDLX, token).DICNAME;
                    CRM_KH_KHQTXXList[] pinzhongmodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 2, token);
                    string pinzhong = "";
                    for (int j = 0; j < pinzhongmodel.Length; j++)
                    {
                        if (j == 0)
                            pinzhong = pinzhongmodel[j].XXMC;
                        else
                            pinzhong = pinzhong + "、" + pinzhongmodel[j].XXMC;
                    }
                    list.CRM_OA_KH_subWDList[i].XSPZ = pinzhong;

                    CRM_KH_KHQTXXList[] jingpinmodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 3, token);
                    string jingpin = "";
                    for (int j = 0; j < jingpinmodel.Length; j++)
                    {
                        if (j == 0)
                            jingpin = jingpinmodel[j].XXMC;
                        else
                            jingpin = jingpin + "、" + jingpinmodel[j].XXMC;
                    }
                    list.CRM_OA_KH_subWDList[i].JPMC = jingpin;

                    CRM_KH_KHQTXXList[] displaymodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 4, token);
                    string display = "";
                    for (int j = 0; j < displaymodel.Length; j++)
                    {
                        if (j == 0)
                            display = displaymodel[j].CLFSDES;
                        else
                            display = display + "、" + displaymodel[j].CLFSDES;
                    }
                    list.CRM_OA_KH_subWDList[i].CL = display;
                    list.CRM_OA_KH_subWDList[i].SFBZWD = checkdata[i].SFBZWD ? "是" : "否";
                    list.CRM_OA_KH_subWDList[i].BEIZ = checkdata[i].BEIZ;

                    //传图片
                    CRM_HG_WJJL[] MTZPmodel = crmModels.HG_WJJL.Read(3, checkdata[i].KHID, token);

                    List<CRM_OA_KH_WD_IMG> all = new List<CRM_OA_KH_WD_IMG>();

                    for (int j = 0; j < MTZPmodel.Length; j++)
                    {
                        CRM_OA_KH_WD_IMG temp = new CRM_OA_KH_WD_IMG();
                        temp.MTZP = MTZPmodel[j].ML;
                        temp.MTZPMC = list.CRM_OA_KH_subWDList[i].MC + "-门头照片-";
                        all.Add(temp);
                    }

                    for (int j = 0; j < displaymodel.Length; j++)
                    {
                        CRM_HG_WJJL[] CLZP = crmModels.HG_WJJL.Read(2, displaymodel[j].XXID, token);
                        for (int k = 0; k < CLZP.Length; k++)
                        {
                            CRM_OA_KH_WD_IMG temp = new CRM_OA_KH_WD_IMG();
                            temp.MTZP = CLZP[k].ML;
                            temp.MTZPMC = list.CRM_OA_KH_subWDList[i].MC + "-" + displaymodel[j].CLFSDES + "-陈列照片-";
                            all.Add(temp);
                        }
                    }

                    list.CRM_OA_KH_subWDList[i].IMG = all.ToArray();

                    //有效网点、电子锁
                    CRM_KH_KHZZList[] ZZmodel = crmModels.KH_KHZZ.ReadByKHID(checkdata[i].KHID, token);
                    list.CRM_OA_KH_subWDList[i].YOUXIAO = "否";
                    list.CRM_OA_KH_subWDList[i].ISDZS = "否";
                    for (int j = 0; j < ZZmodel.Length; j++)
                    {
                        if (ZZmodel[j].ZZMCID == 1080)    //有效网点
                        {
                            list.CRM_OA_KH_subWDList[i].YOUXIAO = "是";
                            list.CRM_OA_KH_subWDList[i].XL = ZZmodel[j].INFO1;
                            list.CRM_OA_KH_subWDList[i].SM = ZZmodel[j].INFO2;
                        }
                        if (ZZmodel[j].ZZMCID == 1058)   //电子锁
                        {
                            list.CRM_OA_KH_subWDList[i].ISDZS = "是";
                            list.CRM_OA_KH_subWDList[i].XYPP = ZZmodel[j].INFO1;
                        }

                    }

                    //活动
                    CRM_KH_HDList[] HDmodel = crmModels.KH_HD.ReadByKHID(checkdata[i].KHID, token);
                    for (int j = 0; j < HDmodel.Length; j++)
                    {
                        if (HDmodel[j].HDMC == 1078)   //床头灯活动
                        {
                            list.CRM_OA_KH_subWDList[i].HDMC = HDmodel[j].HDMCDES;
                            list.CRM_OA_KH_subWDList[i].CPLX = HDmodel[j].CPLXDES;
                            list.CRM_OA_KH_subWDList[i].SHSL = HDmodel[j].XL;
                        }
                    }
                    list.CRM_OA_KH_subWDList[i].KHZZSJ = checkdata[i].KHZZSJ;
                }

                basic.Subject = "JM037-直销终端网点登记表（CRM） " + GetJXS(checkdata[0].KHID).MC;
                #endregion
            }
            //LKA
            else if (checkdata[0].KHLX == 7)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(10, token)[0].CS.ToString();
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                list.CRM_OA_KH_LKAList = new CRM_OA_KH_LKA[checkdata.Length];
                for (int i = 0; i < checkdata.Length; i++)
                {
                    list.CRM_OA_KH_LKAList[i] = new CRM_OA_KH_LKA();
                    CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(checkdata[i].PKHID.ToString(), token);
                    //CRM_KH_KH ppkhmodel = crmModels.KH_KH.ReadByCRMID(pkhmodel.PKHID.ToString(), token);
                    CRM_KH_KH jxsmodel = crmModels.KH_KH.ReadJXSByKHID(checkdata[0].KHID, token);

                    list.CRM_OA_KH_LKAList[i].STAFFNAME = staffmodel.STAFFNAME;
                    //list.CRM_OA_KH_LKAList[i].JXSID = ppkhmodel.SAPSN;
                    //list.CRM_OA_KH_LKAList[i].JXSMC = ppkhmodel.MC;
                    list.CRM_OA_KH_LKAList[i].JXSID = jxsmodel.SAPSN;
                    list.CRM_OA_KH_LKAList[i].JXSMC = jxsmodel.MC;
                    list.CRM_OA_KH_LKAList[i].PKHMC = pkhmodel.MC;
                    list.CRM_OA_KH_LKAList[i].MDJCSL = pkhmodel.MDJCSL;
                    list.CRM_OA_KH_LKAList[i].ZBDZ = pkhmodel.MDDZ;
                    list.CRM_OA_KH_LKAList[i].MC = checkdata[i].MC;
                    list.CRM_OA_KH_LKAList[i].MCLC = crmModels.HG_DICT.ReadByDICID(checkdata[i].MCLC, token).DICNAME;
                    list.CRM_OA_KH_LKAList[i].MDDZ = checkdata[i].MDDZ;
                    list.CRM_OA_KH_LKAList[i].JCDPSL = checkdata[i].JCDPSL;
                    list.CRM_OA_KH_LKAList[i].XSSJSM = checkdata[i].XSSJSM;
                    CRM_KH_KHQTXXList[] jingpinmodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 3, token);
                    string jingpin = "";
                    for (int j = 0; j < jingpinmodel.Length; j++)
                    {
                        if (j == 0)
                            jingpin = jingpinmodel[j].XXMC;
                        else
                            jingpin = jingpin + "、" + jingpinmodel[j].XXMC;
                    }
                    list.CRM_OA_KH_LKAList[i].JP = jingpin;

                    CRM_KH_KHQTXXList[] displaymodel = crmModels.KH_KHQTXX.Read(checkdata[i].KHID, 4, token);
                    string display_major = "";
                    string display_no2 = "";
                    for (int j = 0; j < displaymodel.Length; j++)
                    {
                        if (displaymodel[j].CLLX == 1)
                        {
                            if (display_major == "")
                                display_major = displaymodel[j].CLFSDES;
                            else
                                display_major = display_major + "、" + displaymodel[j].CLFSDES;
                        }
                        else if (displaymodel[j].CLLX == 2)
                        {
                            if (display_no2 == "")
                                display_no2 = displaymodel[j].CLFSDES;
                            else
                                display_no2 = display_no2 + "、" + displaymodel[j].CLFSDES;
                        }

                    }
                    list.CRM_OA_KH_LKAList[i].ZCL = display_major;
                    list.CRM_OA_KH_LKAList[i].ECCL = display_no2;
                    list.CRM_OA_KH_LKAList[i].BEIZ = checkdata[i].BEIZ;


                    //有效网点
                    CRM_KH_KHZZList[] ZZmodel = crmModels.KH_KHZZ.ReadByKHID(checkdata[i].KHID, token);
                    list.CRM_OA_KH_LKAList[i].YOUXIAO = "否";
                    for (int j = 0; j < ZZmodel.Length; j++)
                    {
                        if (ZZmodel[j].ZZMCID == 1080)    //有效网点
                        {
                            list.CRM_OA_KH_LKAList[i].YOUXIAO = "是";
                            list.CRM_OA_KH_LKAList[i].XL = ZZmodel[j].INFO1;
                            list.CRM_OA_KH_LKAList[i].SM = ZZmodel[j].INFO2;
                        }

                    }
                    list.CRM_OA_KH_LKAList[i].KHZZSJ = checkdata[i].KHZZSJ;

                }


                basic.Subject = "JM038-LKA网点登记表（CRM） " + crmModels.KH_KH.ReadByCRMID(checkdata[0].PKHID.ToString(), token).MC;

                #endregion
            }
            //直销商&中间商
            else if (checkdata[0].KHLX == 9 || checkdata[0].KHLX == 10)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(11, token)[0].CS.ToString();
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                list.CRM_OA_KH_ZXS = new CRM_OA_KH_ZXS();
                list.CRM_OA_KH_ZXS.SF = crmModels.HG_DICT.ReadByDICID(checkdata[0].SF, token).DICNAME;
                list.CRM_OA_KH_ZXS.MC = checkdata[0].MC;
                list.KHLX2 = checkdata[0].KHLX2DES;
                CRM_KH_KHXS xsmodel = new CRM_KH_KHXS();
                xsmodel.KHID = checkdata[0].KHID;
                xsmodel.XSLB = 2;
                xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                CRM_KH_KHXSList[] xsdata = crmModels.KH_KHXS.Read(xsmodel, token);
                if (xsdata.Length < 3)
                {
                    //直销商销售数据没有填写完整
                }
                for (int i = 0; i < xsdata.Length; i++)
                {
                    switch (xsdata[i].XSMC)
                    {
                        case "销售":
                            list.CRM_OA_KH_ZXS.XS = xsdata[i].XSJE.ToString();
                            break;
                        case "碱性销售":
                            list.CRM_OA_KH_ZXS.JXXS = xsdata[i].XSJE.ToString();
                            break;
                        case "A类销售":
                            list.CRM_OA_KH_ZXS.AXS = xsdata[i].XSJE.ToString();
                            break;
                        default:
                            break;
                    }
                }
                CRM_KH_GXQYList[] AreaModel = crmModels.KH_GXQY.Read(checkdata[0].KHID, token);
                string area = "";
                for (int i = 0; i < AreaModel.Length; i++)
                {
                    if (i == 0)
                        area = AreaModel[i].GXQYMCDES;
                    else
                        area = area + "、" + AreaModel[i].GXQYMCDES;
                }
                list.CRM_OA_KH_ZXS.AREA = area;
                list.CRM_OA_KH_ZXS.GSLXR = checkdata[0].GSLXR;
                list.CRM_OA_KH_ZXS.GSLXDH = checkdata[0].GSLXDH;
                list.CRM_OA_KH_ZXS.MDDZ = checkdata[0].MDDZ;


                xsmodel.XSLB = 3;
                xsmodel.XSMC = "网点数量";
                xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                CRM_KH_KHXSList[] wdsldata = crmModels.KH_KHXS.Read(xsmodel, token);
                if (wdsldata.Length == 0)
                {
                    //没有网点数量数据
                    list.CRM_OA_KH_ZXS.WDSL = "";
                }
                else
                {
                    list.CRM_OA_KH_ZXS.WDSL = wdsldata[0].XSSL.ToString();
                }


                xsmodel.XSMC = "目标网点数量";
                xsmodel.XSLB = 3;
                xsmodel.GSRQ = (DateTime.Now.Year).ToString();
                CRM_KH_KHXSList[] mbwdsldata = crmModels.KH_KHXS.Read(xsmodel, token);
                if (mbwdsldata.Length == 0)
                {
                    //没有目标网点数量数据
                    list.CRM_OA_KH_ZXS.MBWDSL = "";
                }
                else
                {
                    list.CRM_OA_KH_ZXS.MBWDSL = mbwdsldata[0].XSSL.ToString();
                }

                list.CRM_OA_KH_ZXS.BEIZ = checkdata[0].BEIZ;

                //CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(checkdata[0].PKHID.ToString(), token);
                //list.CRM_OA_KH_ZXS.JXSMC = pkhmodel.MC;
                //list.CRM_OA_KH_ZXS.JXSID = pkhmodel.SAPSN;

                CRM_KH_KH jxsmodel = crmModels.KH_KH.ReadJXSByKHID(checkdata[0].KHID, token);
                list.CRM_OA_KH_ZXS.JXSMC = jxsmodel.MC;
                list.CRM_OA_KH_ZXS.JXSID = jxsmodel.SAPSN;

                //车牌信息
                CRM_KH_KHQTXXList[] chepaimodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 6, token);
                list.CRM_OA_KH_ZXS.TABLE1List = new TABLE1[chepaimodel.Length];
                for (int i = 0; i < chepaimodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE1List[i] = new TABLE1();
                    list.CRM_OA_KH_ZXS.TABLE1List[i].CHEPAI = chepaimodel[i].XXMC;
                    list.CRM_OA_KH_ZXS.TABLE1List[i].AD = (chepaimodel[i].PD == 1) ? "有" : "无";
                    list.CRM_OA_KH_ZXS.TABLE1List[i].ZP = crmModels.HG_WJJL.Read(7, chepaimodel[i].XXID, token).Length.ToString() + "张";
                }

                //联系人信息
                CRM_KH_LXRList[] contactmodel = crmModels.KH_LXR.Read(checkdata[0].KHID, 1082, token);
                list.CRM_OA_KH_ZXS.TABLE2List = new TABLE2[contactmodel.Length];
                for (int i = 0; i < contactmodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE2List[i] = new TABLE2();
                    list.CRM_OA_KH_ZXS.TABLE2List[i].KHSTAFF = contactmodel[i].LXR;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].TEL = contactmodel[i].YDDH;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].GZNR = contactmodel[i].BEIZ;

                }


                //促销单品信息
                CRM_KH_KHQTXXList[] dpmodel = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 7, token);
                list.CRM_OA_KH_ZXS.TABLE3List = new TABLE3[dpmodel.Length];
                for (int i = 0; i < dpmodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE3List[i] = new TABLE3();
                    list.CRM_OA_KH_ZXS.TABLE3List[i].DPMC = dpmodel[i].XXMC;
                    list.CRM_OA_KH_ZXS.TABLE3List[i].CD = (dpmodel[i].PD == 1) ? "是" : "否";

                }


                #endregion
            }
            else
            {
                MessageInfo errinfo = new MessageInfo();
                errinfo.Key = "-1";
                errinfo.Value = "无法找到对应的客户类型";
                return Newtonsoft.Json.JsonConvert.SerializeObject(errinfo);
            }

            if (checkdata[0].KHLX == 5 || checkdata[0].KHLX == 7 || checkdata[0].KHLX == 10)
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "1";
                msg.Value = "提交成功";
                for (int i = 0; i < checkdata.Length; i++)
                {
                    CRM_KH_KH kh = crmModels.KH_KH.ReadByCRMID(checkdata[i].CRMID, token);
                    if (checkdata[i].KHLX == 7 && checkdata[i].MCSX == 1)
                    {
                        kh.ISACTIVE = 2;
                    }
                    else
                    {
                        kh.ISACTIVE = 3;
                    }
                    int id = crmModels.KH_KH.Update(kh, token, true);
                    if (id < 0)
                    {
                        msg.Key = "0";
                        msg.Value = "提交失败";
                    }
                }
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
                if (info.Key != "0" && info.Key != "-1")
                {

                    for (int i = 0; i < checkdata.Length; i++)
                    {
                        CRM_KH_KH kh = crmModels.KH_KH.ReadByCRMID(checkdata[i].CRMID, token);
                        kh.ISACTIVE = 2;
                        crmModels.KH_KH.Update(kh, token, true);

                        CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                        model.OAID = info.Key;
                        model.OACSBH = kh.KHID;
                        switch (checkdata[i].KHLX)
                        {
                            case 1:
                                model.OACSLB = 551;
                                break;
                            case 2:
                                model.OACSLB = 551;
                                break;
                            case 4:
                                model.OACSLB = 551;
                                break;
                            case 5:
                                model.OACSLB = 921;
                                break;
                            case 7:
                                model.OACSLB = 922;
                                break;
                            case 9:
                                model.OACSLB = 923;
                                break;
                            case 10:
                                model.OACSLB = 923;
                                break;
                            default:
                                model.OACSLB = 0;
                                break;
                        }

                        model.OAZT = 1;
                        model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                        crmModels.OA_TRANSMIT.Create(model, token);
                    }
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "1";
                    msg.Value = "提交成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = info.Value;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }


            //return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }


        [HttpPost]
        public string Data_DaoRu_ZDWD()
        {
            token = appClass.CRM_Gettoken();
            WebMSG webmsg = new WebMSG();
            try
            {
                var file = Request.Files[0];
                //string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                //string fileName = date + "_" + KHID;
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                string gotname = file.FileName;
                //string[] name = gotname.Split('.');

                //int count = name.Length - 1;
                //string savePath = @"E:\CRM\Areas\CRM\upload\" + year + @"\" + month + @"\" + fileName + "." + name[count];
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);


                if (fi.Exists == true)
                {
                    string[] sheet = { "网点登记表" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //网点登记表
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("序号") == false || data1.Columns.Contains("业务员") == false || data1.Columns.Contains("开发时间") == false)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = webmsg.MSG + "请使用指定的导入模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            //做数据验证
                            if (data1.Rows.Count > 0)
                            {
                                webmsg.KEY = 1;
                                for (int i = 0; i < data1.Rows.Count; i++)
                                {
                                    CRM_HG_STAFF cx_sqr = new CRM_HG_STAFF();
                                    cx_sqr.STAFFNAME = data1.Rows[i]["业务员"].ToString();
                                    CRM_HG_STAFFList[] SQR = crmModels.HG_STAFF.ReadByParam(cx_sqr, token);
                                    if (SQR.Length == 0)
                                    {
                                        webmsg.KEY = 0;
                                        webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行业务员不存在！";
                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    }

                                    try
                                    {
                                        string temp = Convert.ToDateTime(data1.Rows[i]["开发时间"]).ToString();
                                    }
                                    catch
                                    {
                                        webmsg.KEY = 0;
                                        webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行开发时间格式不正确！";
                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    }

                                    bool sap404 = false;  //要改成判断这个SAP编号存不存在   data3.Rows[i]["SAP编号"]
                                    if (data1.Rows[i]["经销商SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data1.Rows[i]["经销商SAP编号"].ToString(), token) == null)
                                        sap404 = true;
                                    if (sap404)
                                    {
                                        webmsg.KEY = 0;
                                        webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行经销商SAP编号不存在！";
                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    }



                                    int province = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["省份"].ToString(), 1, token);
                                    if (province == 0)
                                    {
                                        webmsg.KEY = 0;
                                        webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行省份不存在！";
                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    }
                                    int city = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["城市"].ToString(), 2, token);
                                    if (city == 0)
                                    {
                                        webmsg.KEY = 0;
                                        webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行城市不存在！";
                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    }
                                    int store_type = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["网点类型"].ToString(), 3, token);
                                    if (store_type == 0)
                                    {
                                        webmsg.KEY = 0;
                                        webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行网点类型不存在！";
                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    }
                                    //if (data1.Rows[i]["是否有陈列，品种齐全"].ToString().Trim() == "是" && data1.Rows[i]["陈列方式"].ToString().Trim() == "")
                                    //{
                                    //    webmsg.KEY = 0;
                                    //    webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行有陈列时陈列方式必填！";
                                    //    //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    //}
                                    int display = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["陈列方式"].ToString(), 9, token);
                                    if (display == 0)
                                    {
                                        webmsg.KEY = 0;
                                        webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行陈列方式不存在！";
                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    }
                                    int huodong = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["活动内容"].ToString(), 46, token);
                                    if (huodong == 0)
                                    {
                                        webmsg.KEY = 0;
                                        webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行活动内容不存在！";
                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    }
                                    int hdtc = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["活动套餐"].ToString(), 105, token);
                                    if (hdtc == 0)
                                    {
                                        webmsg.KEY = 0;
                                        webmsg.MSG = webmsg.MSG + "网点登记表第" + (i + 2) + "行活动套餐不存在！";
                                        //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                    }

                                }

                                if (webmsg.KEY == 0)
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);


                            }

                        }
                    }
                    #endregion





                    //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                    #region
                    //网点登记表
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        #region
                        CRM_KH_KH model = new CRM_KH_KH();

                        model.IsOfficial = 30;
                        model.KHLX = 5;

                        CRM_HG_STAFF cx_staff = new CRM_HG_STAFF();
                        cx_staff.STAFFNAME = data1.Rows[i]["业务员"].ToString();
                        model.FID = crmModels.HG_STAFF.ReadByParam(cx_staff, token)[0].STAFFID;

                        model.KHZZSJ = Convert.ToDateTime(data1.Rows[i]["开发时间"].ToString()).ToString("yyyy-MM-dd");


                        CRM_KH_KH JXS = crmModels.KH_KH.ReadBySAPSN(data1.Rows[i]["经销商SAP编号"].ToString(), token);
                        model.PKHID = Convert.ToInt32(JXS.CRMID);
                        model.MC = data1.Rows[i]["网点名称"].ToString().Trim();
                        model.SF = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["省份"].ToString(), 1, token);
                        model.CS = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["城市"].ToString(), 2, token);
                        if (data1.Rows[i]["省份"].ToString() == data1.Rows[i]["城市"].ToString())
                        {
                            model.MDDZ = data1.Rows[i]["省份"].ToString() + data1.Rows[i]["详细地址"].ToString();
                        }
                        else
                        {
                            model.MDDZ = data1.Rows[i]["省份"].ToString() + data1.Rows[i]["城市"].ToString() + data1.Rows[i]["详细地址"].ToString();
                        }

                        model.GSLXR = data1.Rows[i]["联系人"].ToString();
                        model.GSLXDH = data1.Rows[i]["联系电话"].ToString();
                        model.WDLX = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["网点类型"].ToString(), 3, token);
                        model.ISACTIVE = 1;
                        model.SAPKHLX = "1";



                        int id = crmModels.KH_KH.Create(model, token);
                        if (id <= 0)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "截至到网点登记表的第" + (i + 1) + "行新增完成，第" + (i + 2) + "行新增失败";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            //客户新增成功，开始导入细项数据

                            //权限分组
                            CRM_KH_GROUP_KHList[] con = crmModels.KH_GROUP_KH.ReadStruct(JXS.KHID, 0, token);
                            for (int j = 0; j < con.Length; j++)
                            {
                                int id2 = crmModels.KH_GROUP_KH.Create(id, con[j].GID, token);
                                if (id2 <= 0)
                                {
                                    webmsg.KEY = 0;
                                    webmsg.MSG = "截至到网点登记表的第" + (i + 1) + "行新增完成，第" + (i + 2) + "行客户已新建但权限分组新增失败";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                }
                            }


                            //考勤地址
                            #region
                            string key = System.Configuration.ConfigurationManager.AppSettings["TXmapKey"];
                            string url = "http://apis.map.qq.com/ws/geocoder/v1/?address=" + model.MDDZ + "&key=" + key;
                            Thread.Sleep(201);      //因为腾讯的接口的调用冷却为200毫秒
                            string json = GetJson(url);
                            TXcode.TXzcode DZmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<TXcode.TXzcode>(json);
                            if (DZmodel.message == "查询无结果")
                            {
                                webmsg.KEY = 0;
                                webmsg.MSG = "截至到网点登记表的第" + (i + 1) + "行新增完成，第" + (i + 2) + "行客户已新建但签到地址无法识别";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                            }



                            CRM_KH_DZ DZdata = new CRM_KH_DZ();
                            DZdata.KHID = id;
                            DZdata.DZMS = model.MDDZ;
                            DZdata.ED = DZmodel.result.location.lat.ToString();
                            DZdata.JD = DZmodel.result.location.lng.ToString();
                            DZdata.ISACTIVE = 1;

                            DZdata.DWDZMS = DZmodel.result.title;
                            if (DZmodel.result.title.IndexOf(DZmodel.result.address_components.district) < 0)
                            {
                                DZdata.DWDZMS = DZmodel.result.address_components.district + DZdata.DWDZMS;
                            }



                            DZdata.GJ = 0;
                            DZdata.DZRC = crmModels.SYS_CS.Read(3, token)[0].CS;
                            DZdata.SF = model.SF;
                            DZdata.CS = model.CS;



                            int id3 = crmModels.KH_DZ.Create(DZdata, token);
                            if (id3 <= 0)
                            {
                                webmsg.KEY = 0;
                                webmsg.MSG = "截至到网点登记表的第" + (i + 1) + "行新增完成，第" + (i + 2) + "行客户已新建但签到地址新增失败";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                            }


                            #endregion



                            //陈列
                            if (data1.Rows[i]["陈列方式"].ToString() != "")
                            {
                                CRM_KH_KHQTXX display = new CRM_KH_KHQTXX();
                                display.DISPLAYITEM = data1.Rows[i]["陈列方式"].ToString() == "是" ? 1 : 2;
                                display.KHID = id;
                                display.ISACTIVE = 1;
                                display.XXLB = 4;
                                display.CLLX = 1;
                                display.CLFS = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["陈列方式"].ToString(), 9, token);


                                display.CLGSRQ = "";
                                display.ISACTIVE = 1;
                                display.CZR = model.FID;

                                int id4 = crmModels.KH_KHQTXX.Create(display, token);
                                if (id4 <= 0)
                                {
                                    webmsg.KEY = 0;
                                    webmsg.MSG = "截至到网点登记表的第" + (i + 1) + "行新增完成，第" + (i + 2) + "行客户已新建但陈列新增失败";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                }

                            }



                            //活动
                            if (data1.Rows[i]["活动内容"].ToString() != "")
                            {
                                CRM_KH_HD huodong = new CRM_KH_HD();
                                huodong.KHID = id;
                                huodong.HDMC = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["活动内容"].ToString(), 46, token);
                                huodong.HDTC = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["活动套餐"].ToString(), 105, token);
                                huodong.CZR = model.FID;
                                huodong.ISACTIVE = 1;

                                int id5 = crmModels.KH_HD.Create(huodong, token);
                                if (id5 <= 0)
                                {
                                    webmsg.KEY = 0;
                                    webmsg.MSG = "截至到网点登记表的第" + (i + 1) + "行新增完成，第" + (i + 2) + "行客户已新建但活动新增失败";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                }
                            }


                        }
                        #endregion
                    }

                    #endregion
                    webmsg.KEY = 1;
                    webmsg.MSG = "导入成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                else
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            catch (Exception e)
            {
                webmsg.KEY = 0;
                webmsg.MSG = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }



        }



        [HttpPost]
        public string Move_KHHD()
        {
            token = appClass.CRM_Gettoken();
            CRM_Report_KHModel cxdata = new CRM_Report_KHModel();
            cxdata.KHLX = 5;
            cxdata.ISACTIVE = 1;
            CRM_KH_KHList[] model = crmModels.KH_KH.Report(cxdata, 35, token);


            try
            {
                for (int i = 0; i < model.Length; i++)
                {
                    CRM_KH_KHQTXXList[] DISPLAY = crmModels.KH_KHQTXX.Read(model[i].KHID, 4, token);
                    int ITEM = 0;
                    for (int j = 0; j < DISPLAY.Length; j++)
                    {
                        if (DISPLAY[j].DISPLAYITEM == 1)
                        {
                            ITEM = 1;
                            break;
                        }
                    }

                    CRM_KH_HD[] HD = crmModels.KH_HD.ReadByKHID(model[i].KHID, token);
                    for (int k = 0; k < HD.Length; k++)
                    {
                        if (HD[k].HDMC == 1432)
                        {
                            if (ITEM == 1)
                            {
                                //有陈列道具
                                HD[k].HDTC = 2054;
                                HD[k].CPLX = 1442;
                                HD[k].HDCL = 2058;
                                int id = crmModels.KH_HD.Update(HD[k], token);
                            }
                            else
                            {
                                //没有陈列道具
                                HD[k].HDTC = 2055;
                                HD[k].CPLX = 1443;
                                HD[k].HDCL = 2059;
                                int id = crmModels.KH_HD.Update(HD[k], token);
                            }


                        }
                    }

                }
            }
            catch (Exception e)
            {
                string ee = e.Message;
            }





            return "成功！";
        }

        public ActionResult EXPORT_DOWNLOAD(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = FileSavePath + @"\upload\" + filename; //+ ".xls";
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xls");
        }
        public ActionResult Select_LKA_SH()
        {
            Session["location"] = 554;
            return View();
        }
        [HttpPost]
        public string Data_SH_LKA(string data)
        {
            token = appClass.CRM_Gettoken();
            //  int XXLB = 3;
            WebMSG webmsg = new WebMSG();
            CRM_KH_KH[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KH[]>(data);

            for (int j = 0; j < model.Length; j++)
            {
                model[j].ISACTIVE = 3;
                crmModels.KH_KH.Update(model[j], token, true);
            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Data_SH_LKA2(string data)
        {
            token = appClass.CRM_Gettoken();
            //  int XXLB = 3;
            WebMSG webmsg = new WebMSG();
            CRM_KH_KH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KH>(data);
            model.ISACTIVE = 3;
            webmsg.KEY = crmModels.KH_KH.Update(model, token, true);

            webmsg.MSG = "审核成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Data_BACK_SH_LKA(string data)
        {
            token = appClass.CRM_Gettoken();
            //  int XXLB = 3;
            WebMSG webmsg = new WebMSG();
            CRM_KH_KH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KH>(data);
            model.ISACTIVE = 1;
            webmsg.KEY = crmModels.KH_KH.Update(model, token, true);

            webmsg.MSG = "回退成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }








    }
}
