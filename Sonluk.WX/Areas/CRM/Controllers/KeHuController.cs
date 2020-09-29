using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.WX.Models;
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
using Sonluk.UI.Model.CRM.KH_DZService;
using Sonluk.UI.Model.CRM.KH_GROUP_STAFFService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.HG_KHLXService;
using Sonluk.UI.Model.CRM.HG_STAFFKHLXService;
using Sonluk.UI.Model.CRM.KH_KHXSService;
using Sonluk.UI.Model.CRM_OAService;
using Sonluk.UI.Model.CRM.OA_TRANSMITService;
using Sonluk.UI.Model.CRM.KH_XSYWJZService;
using Sonluk.UI.Model.CRM.KH_KHZZService;
using Sonluk.UI.Model.CRM.KH_HDService;
using Sonluk.WX.APPCLASS;
using System.Net;
using Sonluk.UI.Model.MES.MM_CKService;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class KeHuController : Controller
    {
        //
        // GET: /CRM/KeHu/
        CRMModels crmModels = new CRMModels();
        MESModels mesModels = new MESModels();
        AppClass appClass = new AppClass();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];


        public ActionResult KeHuIndex()
        {
            Session["TITLENAME"] = "客户管理";
            return View();
        }

        public ActionResult Insert()
        {
            token = appClass.CRM_Gettoken();
            Session["TITLENAME"] = "新建客户";
            //更新PartialView                 
            //return PartialView("Insert");
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            CRM_HG_KHLXList[] khlxmodel = crmModels.HG_KHLX.Read(staffmodel.STAFFKHLXID, 0, token);
            ViewData.Model = khlxmodel;
            CRM_HG_DICT[] YYZT = crmModels.HG_DICT.Read(114, 0, token);
            ViewBag.YYZT = YYZT;
            MES_MM_CK model = new MES_MM_CK();
            model.ROLENAME = "1000-KA仓库";
            MES_MM_CK_SELECT data = mesModels.MM_CK.SELECT_BY_ROLE_ASSEMBLE(model, token);
            ViewBag.KCDD = data.MES_MM_CK;
            return View();

        }

        [HttpPost]
        public int Data_Insert(string data, string zzdata)          //新增客户信息
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //crmModels = js.Deserialize<CRMModels>(data);

            //crmModels = ParseFromJson<CRMModels>(data);
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH crmmodel = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KH>(data);

            if (crmmodel.KHLX == 5)
            {
                //终端网点需要根据名称、地址、电话来校验是否重复
                CRM_KH_KH cx_check = new CRM_KH_KH();
                cx_check.MC_ALL = crmmodel.MC;
                cx_check.MDDZ = crmmodel.MDDZ;
                cx_check.GSLXDH = crmmodel.GSLXDH;
                CRM_KH_KH[] check = crmModels.KH_KH.Read(cx_check, token);
                if (check.Length != 0)
                {
                    return -2;
                }
            }



            crmmodel.FID = Convert.ToInt32(Session["STAFFID"]);
            if (crmmodel.IsOfficial == 10)
                crmmodel.ISACTIVE = 3;
            int id = crmModels.KH_KH.Create(crmmodel, token);

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
        public string Data_Select_ByID(int id)           //打开编辑页面时加载客户基本信息
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHService.CRM_KH_KHList model = crmModels.KH_KH.Read(id, token);
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
            //if (crmModels.KH_GROUP_KH.ReadByKHID(token, model.KHID).Length == 0)         //这个客户没有归属于任何分组
            //{
            //    if (crmModels.KH_GROUP_STAFF.ReadByStaffID(Convert.ToInt32(Session["STAFFID"]), token).Length != 1)        //这个人员有多个分组
            //    {
            //        return -10;
            //    }
            //}
            //if (model.KHLX == 5 && crmModels.KH_HD.ReadByKHID(model.KHID, token).Length == 0)      //是终端网点且没有活动信息
            //{
            //    return -11;
            //}
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
            int count = crmModels.KH_KHQTXX.Create(model, token);
            return count;

        }

        [HttpPost]
        public int Data_Update_QTXX(string data)            //修改客户其他信息
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KH_KHQTXXService.CRM_KH_KHQTXX>(data);
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

            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = date + "_" + KHID;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
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
            CRM_HG_WJJL[] data = crmModels.HG_WJJL.ReadLocation(dxname, id, token);
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
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
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
        public string Data_Select_Allxszz()
        {
            token = appClass.CRM_Gettoken();
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

        public ActionResult Qudao_Select()     //√
        {

            return View();
        }

        public ActionResult Pinzhong_Select()     //√
        {

            return View();
        }

        public ActionResult Area_Select()     //√
        {

            return View();
        }

        public ActionResult Partner_Select()     //√
        {

            return View();
        }

        public ActionResult Contact_Select()      //√
        {

            return View();
        }

        public ActionResult ZXRY_Select()      //√
        {

            return View();
        }

        public ActionResult Post_Select()      //√
        {

            return View();
        }

        public ActionResult Display_Select()     //√
        {

            return View();
        }

        public ActionResult DisplayImg_Select()     //√
        {

            return View();
        }

        public ActionResult Jingpin_Select()     //√
        {

            return View();
        }

        public ActionResult Mentou_Select()    //√
        {

            return View();
        }

        public ActionResult Group_Select()   //√
        {

            return View();
        }

        public ActionResult Fujian_Select()
        {

            return View();
        }

        public ActionResult KaoQin_Upload()
        {


            return View();
        }

        public ActionResult KaoQin_Select()
        {

            return View();
        }

        public ActionResult SongHuo()
        {
            return View();
        }

        public ActionResult XiaoShou()
        {
            return View();
        }

        public ActionResult WDshuliang()
        {
            return View();
        }

        public ActionResult ChePai()
        {
            return View();
        }

        public ActionResult ChePaiImg()
        {
            return View();
        }

        public ActionResult CuXiao()
        {
            return View();
        }

        public ActionResult JinZhan()
        {
            return View();
        }

        public ActionResult HuoDong()
        {
            token = appClass.CRM_Gettoken();

            CRM_HG_DICT[] HDCL = crmModels.HG_DICT.Read(106, 0, token);
            ViewBag.HDCL = HDCL;
            return View();
        }

        public ActionResult HuoDongImg_Select()
        {
            return View();
        }

        public ActionResult BatteryImg_Select()
        {
            return View();
        }

        public ActionResult PackImg_Select()
        {
            return View();
        }

        [HttpPost]
        public int Data_Upload_KaoQin(string data, string GJ, string SF, string CS)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_DZ model = JsonConvert.DeserializeObject<CRM_KH_DZ>(data);
            model.GJ = 0;
            model.DZRC = crmModels.SYS_CS.Read(3, token)[0].CS;
            model.SF = crmModels.HG_DICT.ReadByDICNAME(SF, 1, token);
            model.CS = crmModels.HG_DICT.ReadByDICNAME(CS, 2, token);
            model.DZSOURCE = 1091;
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

        public ActionResult Select_Only()
        {
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
            token = appClass.CRM_Gettoken();
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
            token = appClass.CRM_Gettoken();
            CRM_KH_KHList model = crmModels.KH_KH.Read(KHID, token);
            ViewBag.KHID = KHID;
            ViewBag.MC = model.MC;
            ViewBag.CRMID = model.CRMID;
            ViewBag.KHLX = model.KHLX;
            ViewBag.MCSX = model.MCSX;
            ViewBag.SAPSN = model.SAPSN;
            ViewBag.KHLX2 = model.KHLX2;
            ViewBag.IsOfficial = model.IsOfficial;
            return View();
        }

        public ActionResult Update()
        {
            token = appClass.CRM_Gettoken();
            //return PartialView("Update");
            CRM_HG_DICT[] YYZT = crmModels.HG_DICT.Read(114, 0, token);
            ViewBag.YYZT = YYZT;
            MES_MM_CK model = new MES_MM_CK();
            model.ROLENAME = "1000-KA仓库";
            MES_MM_CK_SELECT data = mesModels.MM_CK.SELECT_BY_ROLE_ASSEMBLE(model, token);
            ViewBag.KCDD = data.MES_MM_CK;
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
            CRM_KH_KHList checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHList>(data);

            if (crmModels.KH_GROUP_KH.ReadByKHID(token, checkdata.KHID).Length == 0)
            {
                //客户没有分组
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "请给客户分配分组";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            if (crmModels.KH_DZ.ReadByKHID(checkdata.KHID, token).Length == 0)
            {
                //客户没有签到地址
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "请给客户添加签到地址";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            //校验当客户是直销商时，直销必填项是否有数据
            if (checkdata.KHLX == 1 || checkdata.KHLX == 10)
            {
                if (checkdata.KHLX2 == 1064)    //该客户是直销商
                {
                    //车牌
                    CRM_KH_KHQTXXList[] chepaimodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 6, token);
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
                                msg.Value = "汽车或者电动车没有上传照片";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }

                    //直销人员信息
                    CRM_KH_LXRList[] contactmodel = crmModels.KH_LXR.Read(checkdata.KHID, 1082, token);
                    if (contactmodel.Length < 1)
                    {
                        //直销人员数据没有填写完整
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "人员信息没有填写完整";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }


                    if (checkdata.KHLX == 10)
                    {
                        CRM_KH_KHXS xsmodel = new CRM_KH_KHXS();
                        xsmodel.KHID = checkdata.KHID;
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
                        CRM_KH_KHQTXXList[] dpmodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 7, token);
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
            else if (checkdata.KHLX == 5)
            {
                if (crmModels.KH_HD.ReadByKHID(checkdata.KHID, token).Length == 0)
                {
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "终端网点客户需输入客户活动信息！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                CRM_KH_HD[] HuoDong = crmModels.KH_HD.ReadByKHID(checkdata.KHID, token);
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
            else if (checkdata.KHLX == 7)
            {
                CRM_KH_KHQTXXList[] nnData = crmModels.KH_KHQTXX.Read(checkdata.KHID, 3, token);
                if (nnData.Length == 0)
                {
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "所选客户，没有竞品,不允许提交，请检查数据";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                CRM_KH_KHQTXXList[] DISPLAY = crmModels.KH_KHQTXX.Read(checkdata.KHID, 4, token);
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

            //basic.Subject = crmModels.HG_DICT.ReadByDICID(checkdata.KHLX,token).DICNAME + "客户审核申请(" + staffmodel.STAFFNAME;


            CRM_OA_KH list = new CRM_OA_KH();

            //经销商
            if (checkdata.KHLX == 1 || checkdata.KHLX == 2 || checkdata.KHLX == 4)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(8, token)[0].CS.ToString();
                list.MC = checkdata.MC;
                list.JPXZ = crmModels.HG_DICT.ReadByDICID(checkdata.KPXZ, token).DICNAME;
                list.KPDZ = checkdata.KPDZ;
                list.KPDH = checkdata.KPDH;
                list.NSRSBH = checkdata.NSRSBH;
                list.YHZH = checkdata.YHZH;
                list.YHMC = checkdata.YHMC;
                list.GSLXR = checkdata.GSLXR;
                list.GSLXDH = checkdata.GSLXDH;
                list.FR = checkdata.FR;
                list.GSFRGX = checkdata.GSFRGX;
                list.KDJSDZ = checkdata.KDJSDZ;
                list.KDLXR = checkdata.KDLXR;
                list.KDLXDH = checkdata.KDLXDH;
                list.HTXSRW = checkdata.HTXSRW;
                list.HTJXXSRW = checkdata.HTJXXSRW;
                list.XSSJSM = checkdata.XSSJSM;
                list.FLSJSM = checkdata.FLSJSM;
                list.SFCCJ = checkdata.SFCCJ ? "是" : checkdata.SFCCJSM;
                list.KHSHDZ = checkdata.KHSHDZ;
                list.KHSHLXR = checkdata.KHSHLXR;
                list.KHSHLXDH = checkdata.KHSHLXDH;
                list.TSQKSM = checkdata.TSQKSM;
                list.KHJS = checkdata.KHJS;
                list.TITLE = crmModels.HG_DICT.ReadByDICID(checkdata.KHLX, token).DICNAME;
                list.FIRSTAMOUNT = checkdata.FIRSTAMOUNT;
                list.JOINACTIVITY = checkdata.JOINACTIVITY.ToString();
                CRM_KH_GXQYList[] AreaModel = crmModels.KH_GXQY.Read(checkdata.KHID, token);
                string area = "";
                for (int i = 0; i < AreaModel.Length; i++)
                {
                    if (i == 0)
                        area = AreaModel[i].GXQYMCDES;
                    else
                        area = area + "、" + AreaModel[i].GXQYMCDES;
                }
                list.GXQY = area;
                list.JXSYX = checkdata.JXSYX ? "是" : "否";
                list.YXSM = checkdata.YXSM;
                CRM_KH_KHQTXXList[] qdmodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 1, token);
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
                list.KHSOURCE = checkdata.KHSOURCEDES;

                //下面是经销商的子表信息
                list.CRM_OA_KH_ZXS = new CRM_OA_KH_ZXS();
                //车牌信息
                CRM_KH_KHQTXXList[] chepaimodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 6, token);
                list.CRM_OA_KH_ZXS.TABLE1List = new TABLE1[chepaimodel.Length];
                for (int i = 0; i < chepaimodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE1List[i] = new TABLE1();
                    list.CRM_OA_KH_ZXS.TABLE1List[i].CHEPAI = chepaimodel[i].XXMC;
                    list.CRM_OA_KH_ZXS.TABLE1List[i].AD = (chepaimodel[i].PD == 1) ? "有" : "无";
                    list.CRM_OA_KH_ZXS.TABLE1List[i].ZP = crmModels.HG_WJJL.Read(7, chepaimodel[i].XXID, token).Length.ToString() + "张";
                }

                //联系人信息
                CRM_KH_LXRList[] contactmodel = crmModels.KH_LXR.Read(checkdata.KHID, 1082, token);
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
            else if (checkdata.KHLX == 5)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(9, token)[0].CS.ToString();
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                list.CRM_OA_KH_subWDList = new CRM_OA_KH_WD[1];

                list.CRM_OA_KH_subWDList[0] = new CRM_OA_KH_WD();
                CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(checkdata.PKHID.ToString(), token);
                //if (pkhmodel.KHLX == 1)     //如果上级为经销商，那么经销商和直销商都填这个上级客户
                //{
                //    list.CRM_OA_KH_subWDList[0].JXSMC = pkhmodel.MC;
                //    list.CRM_OA_KH_subWDList[0].JXSID = pkhmodel.SAPSN;
                //    list.CRM_OA_KH_subWDList[0].ZXS = pkhmodel.MC;
                //}
                //else if (pkhmodel.KHLX == 10)   //如果上级为中间商，那么经销商填的是直销商的上级
                //{
                //    list.CRM_OA_KH_subWDList[0].ZXS = pkhmodel.MC;
                //    CRM_KH_KH ppkhmodel = crmModels.KH_KH.ReadByCRMID(pkhmodel.CRMID, token);
                //    list.CRM_OA_KH_subWDList[0].JXSMC = ppkhmodel.MC;
                //    list.CRM_OA_KH_subWDList[0].JXSID = ppkhmodel.SAPSN;
                //}
                list.CRM_OA_KH_subWDList[0].ZXS = pkhmodel.MC;
                CRM_KH_KH jxsmodel = crmModels.KH_KH.ReadJXSByKHID(checkdata.KHID, token);
                list.CRM_OA_KH_subWDList[0].JXSMC = jxsmodel.MC;
                list.CRM_OA_KH_subWDList[0].JXSID = jxsmodel.SAPSN;

                list.CRM_OA_KH_subWDList[0].STAFFNAME = staffmodel.STAFFNAME;
                list.CRM_OA_KH_subWDList[0].SF = crmModels.HG_DICT.ReadByDICID(checkdata.SF, token).DICNAME;
                list.CRM_OA_KH_subWDList[0].CS = crmModels.HG_DICT.ReadByDICID(checkdata.CS, token).DICNAME;
                list.CRM_OA_KH_subWDList[0].MC = checkdata.MC;
                list.CRM_OA_KH_subWDList[0].MDDZ = checkdata.MDDZ;
                list.CRM_OA_KH_subWDList[0].GSLXR = checkdata.GSLXR;
                list.CRM_OA_KH_subWDList[0].GSLXDH = checkdata.GSLXDH;
                list.CRM_OA_KH_subWDList[0].WDLX = crmModels.HG_DICT.ReadByDICID(checkdata.WDLX, token).DICNAME;
                CRM_KH_KHQTXXList[] pinzhongmodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 2, token);
                string pinzhong = "";
                for (int j = 0; j < pinzhongmodel.Length; j++)
                {
                    if (j == 0)
                        pinzhong = pinzhongmodel[j].XXMC;
                    else
                        pinzhong = pinzhong + "、" + pinzhongmodel[j].XXMC;
                }
                list.CRM_OA_KH_subWDList[0].XSPZ = pinzhong;

                CRM_KH_KHQTXXList[] jingpinmodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 3, token);
                string jingpin = "";
                for (int j = 0; j < jingpinmodel.Length; j++)
                {
                    if (j == 0)
                        jingpin = jingpinmodel[j].XXMC;
                    else
                        jingpin = jingpin + "、" + jingpinmodel[j].XXMC;
                }
                list.CRM_OA_KH_subWDList[0].JPMC = jingpin;

                CRM_KH_KHQTXXList[] displaymodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 4, token);
                string display = "";
                for (int j = 0; j < displaymodel.Length; j++)
                {
                    if (j == 0)
                        display = displaymodel[j].CLFSDES;
                    else
                        display = display + "、" + displaymodel[j].CLFSDES;
                }
                list.CRM_OA_KH_subWDList[0].CL = display;
                list.CRM_OA_KH_subWDList[0].SFBZWD = checkdata.SFBZWD ? "是" : "否";
                list.CRM_OA_KH_subWDList[0].BEIZ = checkdata.BEIZ;

                //传图片
                CRM_HG_WJJL[] MTZPmodel = crmModels.HG_WJJL.Read(3, checkdata.KHID, token);

                List<CRM_OA_KH_WD_IMG> all = new List<CRM_OA_KH_WD_IMG>();

                for (int j = 0; j < MTZPmodel.Length; j++)
                {
                    CRM_OA_KH_WD_IMG temp = new CRM_OA_KH_WD_IMG();
                    temp.MTZP = MTZPmodel[j].ML;
                    temp.MTZPMC = list.CRM_OA_KH_subWDList[0].MC + "-门头照片-";
                    all.Add(temp);
                }

                for (int j = 0; j < displaymodel.Length; j++)
                {
                    CRM_HG_WJJL[] CLZP = crmModels.HG_WJJL.Read(2, displaymodel[j].XXID, token);
                    for (int k = 0; k < CLZP.Length; k++)
                    {
                        CRM_OA_KH_WD_IMG temp = new CRM_OA_KH_WD_IMG();
                        temp.MTZP = CLZP[k].ML;
                        temp.MTZPMC = list.CRM_OA_KH_subWDList[0].MC + "-" + displaymodel[j].CLFSDES + "-陈列照片-";
                        all.Add(temp);
                    }
                }

                list.CRM_OA_KH_subWDList[0].IMG = all.ToArray();


                //有效网点、电子锁
                CRM_KH_KHZZList[] ZZmodel = crmModels.KH_KHZZ.ReadByKHID(checkdata.KHID, token);
                list.CRM_OA_KH_subWDList[0].YOUXIAO = "否";
                list.CRM_OA_KH_subWDList[0].ISDZS = "否";
                for (int j = 0; j < ZZmodel.Length; j++)
                {
                    if (ZZmodel[j].ZZMCID == 1080)    //有效网点
                    {
                        list.CRM_OA_KH_subWDList[0].YOUXIAO = "是";
                        list.CRM_OA_KH_subWDList[0].XL = ZZmodel[j].INFO1;
                        list.CRM_OA_KH_subWDList[0].SM = ZZmodel[j].INFO2;
                    }
                    if (ZZmodel[j].ZZMCID == 1058)   //电子锁
                    {
                        list.CRM_OA_KH_subWDList[0].ISDZS = "是";
                        list.CRM_OA_KH_subWDList[0].XYPP = ZZmodel[j].INFO1;
                    }

                }

                //活动
                CRM_KH_HDList[] HDmodel = crmModels.KH_HD.ReadByKHID(checkdata.KHID, token);
                for (int j = 0; j < HDmodel.Length; j++)
                {
                    if (HDmodel[j].HDMC == 1078)   //床头灯活动
                    {
                        list.CRM_OA_KH_subWDList[0].HDMC = HDmodel[j].HDMCDES;
                        list.CRM_OA_KH_subWDList[0].CPLX = HDmodel[j].CPLXDES;
                        list.CRM_OA_KH_subWDList[0].SHSL = HDmodel[j].XL;
                    }
                }
                list.CRM_OA_KH_subWDList[0].KHZZSJ = checkdata.KHZZSJ;

                basic.Subject = "JM037-直销终端网点登记表（CRM） " + GetJXS(checkdata.KHID).MC;
                #endregion
            }
            //LKA
            else if (checkdata.KHLX == 7)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(10, token)[0].CS.ToString();
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                list.CRM_OA_KH_LKAList = new CRM_OA_KH_LKA[1];

                list.CRM_OA_KH_LKAList[0] = new CRM_OA_KH_LKA();
                CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(checkdata.PKHID.ToString(), token);
                //CRM_KH_KH ppkhmodel = crmModels.KH_KH.ReadByCRMID(pkhmodel.PKHID.ToString(), token);
                CRM_KH_KH jxsmodel = crmModels.KH_KH.ReadJXSByKHID(checkdata.KHID, token);

                list.CRM_OA_KH_LKAList[0].STAFFNAME = staffmodel.STAFFNAME;
                //list.CRM_OA_KH_LKAList[0].JXSID = ppkhmodel.SAPSN;
                //list.CRM_OA_KH_LKAList[0].JXSMC = ppkhmodel.MC;
                list.CRM_OA_KH_LKAList[0].JXSID = jxsmodel.SAPSN;
                list.CRM_OA_KH_LKAList[0].JXSMC = jxsmodel.MC;
                list.CRM_OA_KH_LKAList[0].PKHMC = pkhmodel.MC;
                list.CRM_OA_KH_LKAList[0].MDJCSL = pkhmodel.MDJCSL;
                list.CRM_OA_KH_LKAList[0].ZBDZ = pkhmodel.MDDZ;
                list.CRM_OA_KH_LKAList[0].MC = checkdata.MC;
                list.CRM_OA_KH_LKAList[0].MCLC = crmModels.HG_DICT.ReadByDICID(checkdata.MCLC, token).DICNAME;
                list.CRM_OA_KH_LKAList[0].MDDZ = checkdata.MDDZ;
                list.CRM_OA_KH_LKAList[0].JCDPSL = checkdata.JCDPSL;
                list.CRM_OA_KH_LKAList[0].XSSJSM = checkdata.XSSJSM;
                CRM_KH_KHQTXXList[] jingpinmodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 3, token);
                string jingpin = "";
                for (int j = 0; j < jingpinmodel.Length; j++)
                {
                    if (j == 0)
                        jingpin = jingpinmodel[j].XXMC;
                    else
                        jingpin = jingpin + "、" + jingpinmodel[j].XXMC;
                }
                list.CRM_OA_KH_LKAList[0].JP = jingpin;

                CRM_KH_KHQTXXList[] displaymodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 4, token);
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
                list.CRM_OA_KH_LKAList[0].ZCL = display_major;
                list.CRM_OA_KH_LKAList[0].ECCL = display_no2;
                list.CRM_OA_KH_LKAList[0].BEIZ = checkdata.BEIZ;


                //有效网点
                CRM_KH_KHZZList[] ZZmodel = crmModels.KH_KHZZ.ReadByKHID(checkdata.KHID, token);
                list.CRM_OA_KH_LKAList[0].YOUXIAO = "否";
                for (int j = 0; j < ZZmodel.Length; j++)
                {
                    if (ZZmodel[j].ZZMCID == 1080)    //有效网点
                    {
                        list.CRM_OA_KH_LKAList[0].YOUXIAO = "是";
                        list.CRM_OA_KH_LKAList[0].XL = ZZmodel[j].INFO1;
                        list.CRM_OA_KH_LKAList[0].SM = ZZmodel[j].INFO2;
                    }

                }
                list.CRM_OA_KH_LKAList[0].KHZZSJ = checkdata.KHZZSJ;


                basic.Subject = "JM038-LKA网点登记表（CRM） " + crmModels.KH_KH.ReadByCRMID(checkdata.PKHID.ToString(), token).MC;

                #endregion
            }
            //直销商&中间商
            else if (checkdata.KHLX == 9 || checkdata.KHLX == 10)
            {
                #region
                basic.TemplateCode = crmModels.SYS_CS.Read(11, token)[0].CS.ToString();
                list.TXRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                list.CRM_OA_KH_ZXS = new CRM_OA_KH_ZXS();
                list.CRM_OA_KH_ZXS.SF = crmModels.HG_DICT.ReadByDICID(checkdata.SF, token).DICNAME;
                list.CRM_OA_KH_ZXS.MC = checkdata.MC;
                list.KHLX2 = checkdata.KHLX2DES;
                CRM_KH_KHXS xsmodel = new CRM_KH_KHXS();
                xsmodel.KHID = checkdata.KHID;
                xsmodel.XSLB = 2;
                xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                CRM_KH_KHXSList[] xsdata = crmModels.KH_KHXS.Read(xsmodel, token);
                if (xsdata.Length != 3)
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
                CRM_KH_GXQYList[] AreaModel = crmModels.KH_GXQY.Read(checkdata.KHID, token);
                string area = "";
                for (int i = 0; i < AreaModel.Length; i++)
                {
                    if (i == 0)
                        area = AreaModel[i].GXQYMCDES;
                    else
                        area = area + "、" + AreaModel[i].GXQYMCDES;
                }
                list.CRM_OA_KH_ZXS.AREA = area;
                list.CRM_OA_KH_ZXS.GSLXR = checkdata.GSLXR;
                list.CRM_OA_KH_ZXS.GSLXDH = checkdata.GSLXDH;
                list.CRM_OA_KH_ZXS.MDDZ = checkdata.MDDZ;


                xsmodel.XSLB = 3;
                xsmodel.XSMC = "网点数量";
                xsmodel.GSRQ = (DateTime.Now.Year - 1).ToString();
                CRM_KH_KHXSList[] wdsldata = crmModels.KH_KHXS.Read(xsmodel, token);
                if (wdsldata.Length == 0)
                {
                    //网点数量数据有误
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
                    //网点数量数据有误
                    list.CRM_OA_KH_ZXS.MBWDSL = "";
                }
                else
                {
                    list.CRM_OA_KH_ZXS.MBWDSL = mbwdsldata[0].XSSL.ToString();
                }

                list.CRM_OA_KH_ZXS.BEIZ = checkdata.BEIZ;

                CRM_KH_KH pkhmodel = crmModels.KH_KH.ReadByCRMID(checkdata.PKHID.ToString(), token);
                list.CRM_OA_KH_ZXS.JXSMC = pkhmodel.MC;
                list.CRM_OA_KH_ZXS.JXSID = pkhmodel.SAPSN;

                //车牌信息
                CRM_KH_KHQTXXList[] chepaimodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 6, token);
                list.CRM_OA_KH_ZXS.TABLE1List = new TABLE1[chepaimodel.Length];
                for (int i = 0; i < chepaimodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE1List[i] = new TABLE1();
                    list.CRM_OA_KH_ZXS.TABLE1List[i].CHEPAI = chepaimodel[i].XXMC;
                    list.CRM_OA_KH_ZXS.TABLE1List[i].AD = (chepaimodel[i].PD == 1) ? "有" : "无";
                    list.CRM_OA_KH_ZXS.TABLE1List[i].ZP = crmModels.HG_WJJL.Read(7, chepaimodel[i].XXID, token).Length.ToString() + "张";
                }

                //联系人信息
                CRM_KH_LXRList[] contactmodel = crmModels.KH_LXR.Read(checkdata.KHID, 1082, token);
                list.CRM_OA_KH_ZXS.TABLE2List = new TABLE2[contactmodel.Length];
                for (int i = 0; i < contactmodel.Length; i++)
                {
                    list.CRM_OA_KH_ZXS.TABLE2List[i] = new TABLE2();
                    list.CRM_OA_KH_ZXS.TABLE2List[i].KHSTAFF = contactmodel[i].LXR;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].TEL = contactmodel[i].YDDH;
                    list.CRM_OA_KH_ZXS.TABLE2List[i].GZNR = contactmodel[i].BEIZ;

                }


                //促销单品信息
                CRM_KH_KHQTXXList[] dpmodel = crmModels.KH_KHQTXX.Read(checkdata.KHID, 7, token);
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

            if (checkdata.KHLX == 5 || checkdata.KHLX == 7 || checkdata.KHLX == 10)
            {
                MessageInfo info = new MessageInfo();
                info.Key = "1";
                info.Value = "提交成功";

                CRM_KH_KH kh = crmModels.KH_KH.ReadByCRMID(checkdata.CRMID, token);
                if (checkdata.KHLX == 7 && checkdata.MCSX == 1)
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

                return Newtonsoft.Json.JsonConvert.SerializeObject(info);
            }
            else
            {
                MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
                if (info.Key != "0" && info.Key != "-1")
                {


                    CRM_KH_KH kh = crmModels.KH_KH.ReadByCRMID(checkdata.CRMID, token);
                    kh.ISACTIVE = 2;
                    crmModels.KH_KH.Update(kh, token, true);

                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = kh.KHID;
                    switch (checkdata.KHLX)
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
        public int Data_Insert_KHHD(string data)
        {
            token = appClass.CRM_Gettoken();

            CRM_KH_HD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_HD>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_HD.Create(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Update_KHHD(string data)
        {
            token = appClass.CRM_Gettoken();

            CRM_KH_HD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_HD>(data);
            model.CZR = Convert.ToInt32(Session["STAFFID"]);
            int i = crmModels.KH_HD.Update(model, token);

            return i;
        }

        [HttpPost]
        public string Data_Select_KHHD_ByKHID(int KHID)
        {
            token = appClass.CRM_Gettoken();

            CRM_KH_HDList[] data = crmModels.KH_HD.ReadByKHID(KHID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public int Data_Delete_KHHD(int HDID)
        {
            token = appClass.CRM_Gettoken();

            int i = crmModels.KH_HD.Delete(HDID, token);

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

        private CRM_KH_KH GetJXS(int khid)
        {
            //进来的是终端网点的PKHID
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
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
            }
            if (Updatemodel.KHLX == 5 && crmModels.KH_HD.ReadByKHID(Updatemodel.KHID, token).Length == 0)      //是终端网点且没有活动信息
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "请输入客户活动信息！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            int count = crmModels.KH_KH.Update(Updatemodel, token, true);
            if(count == -100)
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "同系统下门店编号重复！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

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
                    if (checkdata[i].PKHID != pkhid)
                    {
                        MessageInfo msg = new MessageInfo();
                        msg.Key = "0";
                        msg.Value = "所选客户必须为同一个系统下的门店！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                CRM_KH_KHQTXXList[] nnData = crmModels.KH_KHQTXX.Read(checkdata[0].KHID, 3, token);
                if (nnData.Length == 0)
                {
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "所选客户，没有竞品,不允许提交，请检查数据";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
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
                        temp.MTZPMC = list.CRM_OA_KH_subWDList[0].MC + "-门头照片-";
                        all.Add(temp);
                    }

                    for (int j = 0; j < displaymodel.Length; j++)
                    {
                        CRM_HG_WJJL[] CLZP = crmModels.HG_WJJL.Read(2, displaymodel[j].XXID, token);
                        for (int k = 0; k < CLZP.Length; k++)
                        {
                            CRM_OA_KH_WD_IMG temp = new CRM_OA_KH_WD_IMG();
                            temp.MTZP = CLZP[k].ML;
                            temp.MTZPMC = list.CRM_OA_KH_subWDList[0].MC + "-" + displaymodel[j].CLFSDES + "-陈列照片-";
                            all.Add(temp);
                        }
                    }

                    list.CRM_OA_KH_subWDList[0].IMG = all.ToArray();


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
                    msg.Value = info.Key;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }


            //return Newtonsoft.Json.JsonConvert.SerializeObject(info);


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




    }
}
