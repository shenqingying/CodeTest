using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.Mobile.Models;
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

namespace Sonluk.Mobile.Areas.CRM.Controllers
{
    public class KeHuController : Controller
    {
        //
        // GET: /CRM/KeHu/
        CRMModels crmModels = new CRMModels();
        string token = "";
        public ActionResult KeHuIndex()
        {
            Session["TITLENAME"] = "客户管理";
            return View();
        }

        public ActionResult Insert()
        {
            Session["TITLENAME"] = "新建客户";
            //更新PartialView                 
            //return PartialView("Insert");
            return View();

        }

        [HttpPost]
        public int Data_Insert(string data)          //新增客户信息
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //crmModels = js.Deserialize<CRMModels>(data);

            //crmModels = ParseFromJson<CRMModels>(data);
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH crmmodel = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH>(data);
            int id = crmModels.KH_KH.Create(crmmodel, token);

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
        public string Data_Select_UpKH(string data)        //选择上级客户
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH>(data);
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH[] list = crmModels.KH_KH.Read(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return s;
        }

        [HttpPost]
        public string Data_Select(string data)          //查询客户列表
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_KHService.CRM_Report_KHModel report_model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_Report_KHModel>(data);
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KHList[] list = crmModels.KH_KH.Report(report_model,Convert.ToInt32(Session["STAFFID"]), token);
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
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KHList model = crmModels.KH_KH.Read(id, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }

        [HttpPost]
        public int Data_Update(string data)            //修改客户信息
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH>(data);
            int count = crmModels.KH_KH.Update(model, token,true);
            return count;
        }

        [HttpPost]
        public int Data_Delete(int id)                //删除客户信息,当然只是逻辑删除
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int i = crmModels.KH_KH.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_QTXX(string data)         //新增客户其他信息
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX>(data);
            int count = crmModels.KH_KHQTXX.Create(model, token);
            return count;

        }

        [HttpPost]
        public int Data_Update_QTXX(string data)            //修改客户其他信息
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX>(data);
            int i = crmModels.KH_KHQTXX.Update(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_QTXX(int KHID, int XXLB)        //查询客户其他信息
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXXList[] data = crmModels.KH_KHQTXX.Read(KHID, XXLB, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_QTXX(int xxid)              //删除客户其他信息
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int i = crmModels.KH_KHQTXX.Delete(xxid, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_Contact(string data)      //新增客户联系人
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXR model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXR>(data);
            int i = crmModels.KH_LXR.Create(model, token);
            return i;
        }

        public string Data_Insert_ContacImg(int KHID)        //上传客户联系人照片
        {
            var file = Request.Files[0];

            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = date + "_" + KHID;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            string Path = @"E:\\CRM\\Areas\\CRM\\upload\\" + year + @"\\" + month + @"\\" + fileName + "." + name[count];
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"] + year + @"\/" + month + @"\/" + fileName + "." + name[count];
            file.SaveAs(Path);
            FileInfo fi = new FileInfo(Path);
            if (fi.Exists == true)
            {

                if (Session["token"] != null)
                {
                    token = Session["token"].ToString();
                }

                string json = "{\"code\":0,\"res\":\"" + netpath + "\"}";
                return json;
            }
            else
            {
                return "";
            }

        }

        [HttpPost]
        public string Data_Select_Contact(int id)               //查询客户联系人
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXRList[] data = crmModels.KH_LXR.Read(id,1081, token);

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
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXR model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_LXRService.CRM_KH_LXR>(data);
            int i = crmModels.KH_LXR.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Contact(int id)              //删除客户联系人
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int i = crmModels.KH_LXR.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_Area(string data)             //新建管辖区域
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY>(data);
            int i = crmModels.KH_GXQY.Create(model, token);

            return i;
        }

        [HttpPost]
        public string Data_Select_Area(int id)                //查询管辖区域
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQYList[] data = crmModels.KH_GXQY.Read(id, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return s;
        }

        [HttpPost]
        public int Data_Update_Area(string data)             //修改管辖区域
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_GXQYService.CRM_KH_GXQY>(data);
            int i = crmModels.KH_GXQY.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Area(int id)                 //删除管辖区域
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int i = crmModels.KH_GXQY.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_WJJL(string data)              // 新建文件记录
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_HG_WJmodel model = JsonConvert.DeserializeObject<CRM_HG_WJmodel>(data);
            int i = crmModels.HG_WJJL.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_WJJL(int dxname, int id)            //查询文件记录
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
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
                    string path = p[count];
                    data[i].ML = netpath + year + "\\" + month + "\\" + path;
                }
            }

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_WJJL(int id)                 //删除文件记录
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int i = crmModels.HG_WJJL.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_Group(int KHID, int GID)        //分配客户到组
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }

            int i = crmModels.KH_GROUP_KH.Create(KHID, GID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Group(int KHID)           //查询客户与组的关联
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            string[][] data = crmModels.KH_GROUP_KH.ReadByKHID(token, KHID);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_Group(int KHID, int GID)                     //删除客户与组的关联
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int i = crmModels.KH_GROUP_KH.Delete(KHID, GID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_AllGroup()             //查询出所有的客户分组     客户分组下拉框专用
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_KH_GROUPList[] data = crmModels.KH_GROUP.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_Partner(string sapsn)    //查询客户合作伙伴
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_KH_HZHBLIST[] data = crmModels.KH_HZHB.Read(sapsn, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_Allxszz()
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            string[] data = crmModels.KH_KH.ReadXSZZ(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return "{}";
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

        public ActionResult Qudao_Select()
        {

            return View();
        }

        public ActionResult Pinzhong_Select()
        {

            return View();
        }

        public ActionResult Area_Select()
        {
            
            return View();
        }

        public ActionResult Partner_Select()
        {

            return View();
        }

        public ActionResult Contact_Select()
        {

            return View();
        }

        public ActionResult Post_Select()
        {

            return View();
        }

        public ActionResult Display_Select()
        {

            return View();
        }

        public ActionResult Jingpin_Select()
        {

            return View();
        }

        public ActionResult Mentou_Select()
        {

            return View();
        }

        public ActionResult Group_Select()
        {

            return View();
        }

        public ActionResult Fujian_Select()
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
            Session["location"] = 2;
            //return PartialView("Select");
            return View();
        }

        public ActionResult Sap()
        {
            Session["location"] = 3;
            //return PartialView("Sap");
            return View();
        }

        [HttpPost]
        public int Data_SAP_PP(string CRMID, string SAPSN)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            int i = crmModels.KH_HZHB.SapDataSynchronization(CRMID, SAPSN, token);
            return i;
        }

        public ActionResult Daoru()
        {
            Session["location"] = 4;
            //return PartialView("Daoru");
            return View();
        }

        public ActionResult UpdateIndex(int KHID)
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            CRM_KH_KHList model = crmModels.KH_KH.Read(KHID, token);
            ViewBag.KHID = KHID;
            ViewBag.MC = model.MC;
            ViewBag.CRMID = model.CRMID;
            ViewBag.KHLX = model.KHLX;
            return View();
        }

        public ActionResult Update()
        {
            //return PartialView("Update");
            return View();
        }

        public ActionResult Power()
        {
            Session["location"] = 5;
            //return PartialView("Power");
            return View();
        }

        public ActionResult Insert_Power()
        {

            return View();
        }

        public ActionResult UserPower()
        {
            Session["location"] = 6;
            //return PartialView("UserPower");
            return View();
        }


        public ActionResult KeHuPower()
        {
            Session["location"] = 7;
            //return PartialView("KHPower"); 
            return View();
        }

        public ActionResult Baobiao()
        {
            Session["location"] = 8;
            //return PartialView("Baobiao"); 
            return View();
        }



    }
}
