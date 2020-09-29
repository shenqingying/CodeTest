using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;
using Sonluk.WX.Models;
using Sonluk.UI.Model.CRM.KQ_YGQJService;
using Sonluk.UI.Model.CRM.KQ_CCService;
using Sonluk.UI.Model.CRM.KQ_YCKQSMService;
using Sonluk.UI.Model.CRM.HG_KQDZService;
using Sonluk.UI.Model.CRM.KQ_QDService;
using Sonluk.UI.Model.CRM.HG_BZGZSJService;
using Sonluk.UI.Model.CRM_OAService;
using Sonluk.UI.Model.CRM.OA_TRANSMITService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.KH_DZService;
using Sonluk.WX.APPCLASS;
using Sonluk.UI.Model.CRM.HG_WJJLService;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class KaoQinController : Controller
    {
        //
        // GET: /CRM/KaoQin/
        CRMModels crmModels = new CRMModels();
        AppClass appclass = new AppClass();
        string token = "";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KaoQinIndex()
        {

            return View();
        }

        public ActionResult QianDao()
        {

            return View();
        }

        [HttpPost]
        public string Data_Select_KaoQinAddress(int KQDZID)               //根据考勤地址的ID查询对应的考勤点
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_KQDZ[] data = crmModels.HG_KQDZ.Read(KQDZID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Cacu_Distance(int staffid, string lat, string lon)            //计算当前位置与最近考勤点的距离
        {
            token = appclass.CRM_Gettoken();

            CRM_HG_KQDZ[] DZdata = crmModels.HG_KQDZ.ReadBySTAFFID(staffid, token);
            if (DZdata.Length == 0)
            {
                return "";
            }
            CRM_HG_KQDZ minModel = new CRM_HG_KQDZ();
            double min = double.MaxValue;
            for (int i = 0; i < DZdata.Length; i++)
            {
                double distance = GetDistance(Convert.ToDouble(DZdata[i].ED), Convert.ToDouble(DZdata[i].JD), Convert.ToDouble(lat), Convert.ToDouble(lon));
                if (distance < min)
                {
                    min = distance;
                    minModel = DZdata[i];
                }


            }
            int[] s = new int[2];
            s[0] = minModel.KQDZID;
            s[1] = Convert.ToInt32(min);


            //string[][] data = crmModels.KQ_QD.Verify_QD(staffid, lat, lon, accu, token);

            string ss = Newtonsoft.Json.JsonConvert.SerializeObject(s);
            return ss;

        }

        [HttpPost]
        public string Data_Cacu_KHDistance(int staffid, int khid, string lat, string lon)         //计算当前位置与最近客户签到地址的距离
        {
            token = appclass.CRM_Gettoken();
            CRM_KH_DZList[] DZdata = crmModels.KH_DZ.ReadByKHID(khid, token);
            if (DZdata.Length == 0)
            {
                return "";
            }
            CRM_KH_DZList minModel = new CRM_KH_DZList();
            double min = double.MaxValue;
            for (int i = 0; i < DZdata.Length; i++)
            {
                double distance = GetDistance(Convert.ToDouble(DZdata[i].ED), Convert.ToDouble(DZdata[i].JD), Convert.ToDouble(lat), Convert.ToDouble(lon));
                if (distance < min)
                {
                    min = distance;
                    minModel = DZdata[i];
                }


            }
            int[] s = new int[2];
            s[0] = minModel.DZID;
            s[1] = Convert.ToInt32(min);

            string ss = Newtonsoft.Json.JsonConvert.SerializeObject(s);
            return ss;
        }

        [HttpPost]
        public int Data_Insert_QianDao(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_QD model = JsonConvert.DeserializeObject<CRM_KQ_QD>(data);
            //double distance = Convert.ToDouble(model.KQJL);
            //model.KQJL = Math.Round(distance, 2).ToString();
            int i = crmModels.KQ_QD.Create(model, token);
            if (model.QDLX == 2)
            {
                //crmModels.KQ_CC.read
            }
            return i;
        }

        [HttpPost]
        public string Data_SelectQianDaoByKQQDID(int KQQDID)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_QD data = crmModels.KQ_QD.ReadByKQQDID(KQQDID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }


        public ActionResult QingJia()
        {
            Session["location"] = 13;
            //return PartialView("QingJia");
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-2).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.AddMonths(1).ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Insert_QingJia()
        {
            return View();
        }

        public ActionResult Update_QingJia()
        {
            return View();
        }

        [HttpPost]
        public int Data_Insert_QingJia(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_YGQJ model = JsonConvert.DeserializeObject<CRM_KQ_YGQJ>(data);
            int i = crmModels.KQ_YGQJ.Create(model, token);


            return i;
        }

        [HttpPost]
        public string Data_Select_QingJia(int STAFFID)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_YGQJList[] data = crmModels.KQ_YGQJ.ReadBySTAFFID(STAFFID, 4, token);
            for (int i = 0; i < data.Length; i++)
            {
                DateTime date = new DateTime();

                date = Convert.ToDateTime(data[i].JHQJKSSJ);
                data[i].JHQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].JHQJJSSJ);
                data[i].JHQJJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJQJKSSJ);
                data[i].SJQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJJSKSSJ);
                data[i].SJJSKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].QJRQ);
                data[i].QJRQ = date.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_QingJia_ByModel(string qjdata)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_YGQJ model = JsonConvert.DeserializeObject<CRM_KQ_YGQJ>(qjdata);
            Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] data = crmModels.KQ_YGQJ.Read(model, token);
            for (int i = 0; i < data.Length; i++)
            {
                DateTime date = new DateTime();

                date = Convert.ToDateTime(data[i].JHQJKSSJ);
                data[i].JHQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].JHQJJSSJ);
                data[i].JHQJJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJQJKSSJ);
                data[i].SJQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJJSKSSJ);
                data[i].SJJSKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].QJRQ);
                data[i].QJRQ = date.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_QingJia_ByYGQJID(int YGQJID)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_YGQJ data = crmModels.KQ_YGQJ.ReadByYGQJID(YGQJID, token);
            DateTime date = new DateTime();

            date = Convert.ToDateTime(data.JHQJKSSJ);
            data.JHQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.JHQJJSSJ);
            data.JHQJJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.SJQJKSSJ);
            data.SJQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.SJJSKSSJ);
            data.SJJSKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.QJRQ);
            data.QJRQ = date.ToString("yyyy-MM-dd HH:mm:ss");

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_QingJia(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_YGQJ model = JsonConvert.DeserializeObject<CRM_KQ_YGQJ>(data);
            int i = crmModels.KQ_YGQJ.Update(model, token);
            return i;

        }

        [HttpPost]
        public int Data_Delete_QingJia(int YGQJID)
        {
            token = appclass.CRM_Gettoken();
            int i = crmModels.KQ_YGQJ.Delete(YGQJID, token);
            return i;
        }


        public ActionResult ChuChai()
        {
            Session["location"] = 14;
            //return PartialView("ChuChai");
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-2).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.AddMonths(1).ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Insert_ChuChai()
        {
            Session["location"] = 43;
            return View();
        }

        public ActionResult Select_ChuChai()
        {
            Session["location"] = 44;
            return View();
        }

        public ActionResult Update_ChuChai()
        {

            return View();
        }

        public ActionResult HeXiao_ChuChai()
        {
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-2).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.AddMonths(1).ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult HeXiao_Update_ChuChai()
        {
            ViewBag.nowtime = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.nowtime2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return View();
        }

        public ActionResult CCimg()
        {
            return View();
        }

        [HttpPost]
        public int Data_Insert_CCTT(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCTT model = JsonConvert.DeserializeObject<CRM_KQ_CCTT>(data);
            int i = crmModels.KQ_CC.Create_TT(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_CCTT(int staffid, int status)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCTTList[] data = crmModels.KQ_CC.Read_TTbySTAFFID(staffid, status, token);
            for (int i = 0; i < data.Length; i++)
            {
                DateTime date = new DateTime();

                date = Convert.ToDateTime(data[i].JHCCKSSJ);
                data[i].JHCCKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].JHCCJSSJ);
                data[i].JHCCJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJKSSJ);
                data[i].SJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJCCJSSJ);
                data[i].SJCCJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].CCSQSJ);
                data[i].CCSQSJ = date.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_CCTT_ByCCID(int CCID)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCTT data = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
            DateTime date = new DateTime();

            date = Convert.ToDateTime(data.JHCCKSSJ);
            data.JHCCKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.JHCCJSSJ);
            data.JHCCJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.SJKSSJ);
            data.SJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.SJCCJSSJ);
            data.SJCCJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.CCSQSJ);
            data.CCSQSJ = date.ToString("yyyy-MM-dd HH:mm:ss");


            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_CCTT_ByModel(string cxdata, int status)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KQ_CCTT>(cxdata);
            Sonluk.UI.Model.CRM.KQ_CCService.CRM_KQ_CCTTList[] data = crmModels.KQ_CC.Read_TTbyParam(model, status, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;


        }

        [HttpPost]
        public int Data_Update_CCTT(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCTT model = JsonConvert.DeserializeObject<CRM_KQ_CCTT>(data);
            int i = crmModels.KQ_CC.Update_TT(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_CCTT(int CCID)
        {
            token = appclass.CRM_Gettoken();
            int i = crmModels.KQ_CC.Delete_TT(CCID, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_CCMX(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCMX model = JsonConvert.DeserializeObject<CRM_KQ_CCMX>(data);
            int i = crmModels.KQ_CC.Create_MX(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_CCMX(int ccid)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCMX[] model = crmModels.KQ_CC.Read_MXbyCCID(ccid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }
        [HttpPost]
        public string Data_Select_CCMXQD(int ccid)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCMXList[] model = crmModels.KQ_CC.Read_MXQDbyCCID(ccid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }

        [HttpPost]
        public int Data_Update_CCMX(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCMX model = JsonConvert.DeserializeObject<CRM_KQ_CCMX>(data);
            int i = crmModels.KQ_CC.Update_MX(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_CCMX(int MXID)
        {
            token = appclass.CRM_Gettoken();
            int i = crmModels.KQ_CC.Delete_MX(MXID, token);
            return i;
        }

        [HttpPost]
        public string Data_GetCCMXdate(int ccid)
        {
            token = appclass.CRM_Gettoken();
            string[] data = new string[2];
            data[0] = DateTime.Now.ToString("yyyy-MM-dd");
            data[1] = "0";
            CRM_KQ_CCMX[] model = crmModels.KQ_CC.Read_MXbyCCID(ccid, token);
            if (model.Length != 0)   //已经填过明细
            {
                if (model[model.Length - 1].CCSJLX == 1)    //上午
                {
                    data[0] = model[model.Length - 1].DATE;
                    data[1] = "2";
                }
                else
                {
                    data[0] = Convert.ToDateTime(model[model.Length - 1].DATE).AddDays(1).ToString("yyyy-MM-dd");
                    data[1] = "1";
                }
            }
            else
            {
                CRM_KQ_CCTT CCTT = crmModels.KQ_CC.Read_TTbyCCID(ccid, token);
                data[0] = Convert.ToDateTime(CCTT.SJKSSJ).ToString("yyyy-MM-dd");
                if (CCTT.SJKSSJ.Split(' ')[1] == "08:00:00")
                {
                    data[1] = "1";
                }
                else
                {
                    data[1] = "2";
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public ActionResult ChuChaiMX()
        {


            return View();
        }

        public ActionResult YiChang()
        {
            Session["location"] = 15;
            //return PartialView("YiChang");
            return View();
        }

        public ActionResult YiChang_Single()
        {
            return View();
        }

        [HttpPost]
        public int Data_Insert_YiChang(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_YCKQSMList model = JsonConvert.DeserializeObject<CRM_KQ_YCKQSMList>(data);
            model.ISACTIVE = 0;      //先传0，表示忽略该字段进行查询，查出来如果有，就不能继续新增
            int count = crmModels.KQ_YCKQSM.ReadByParam(model, token).Length;
            if (count != 0)
            {
                return -1;
            }

            model.SMR = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token).STAFFNAME;
            model.ISACTIVE = 1;
            int i = crmModels.KQ_YCKQSM.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_YiChang(int staffid)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_YCKQSMList[] model = crmModels.KQ_YCKQSM.ReadBySTAFFID(staffid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }

        [HttpPost]
        public string Data_Selece_QueQin()                    //找出当前人员的两个月内的缺勤记录
        {
            token = appclass.CRM_Gettoken();
            string now = DateTime.Now.ToString("yyyy-MM-dd");
            string ago = DateTime.Now.AddMonths(-2).ToString("yyyy-MM-dd");
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_QQList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QQ(Convert.ToInt32(Session["STAFFID"]), ago, now, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_YiChang(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_YCKQSM model = JsonConvert.DeserializeObject<CRM_KQ_YCKQSM>(data);
            int i = crmModels.KQ_YCKQSM.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_YiChang(int YCKQID)
        {
            token = appclass.CRM_Gettoken();
            int i = crmModels.KQ_YCKQSM.Delete(YCKQID, token);
            return i;
        }

        public ActionResult Apply_yichang()
        {

            return View();
        }

        public ActionResult BaoBiao()
        {
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult BaoBiao_Personal()
        {
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        [HttpPost]
        public string Data_Cacu_Date(int bbid, string open, string end, bool bopen, bool bend)           //计算一个时间段内的工作日天数
        {
            token = appclass.CRM_Gettoken();
            Double d = crmModels.KQ_GZRLMX.CountDaysByGZRLMX(bbid, open, end, bopen, bend, token);
            return d.ToString();
        }

        [HttpPost]
        public string Data_Verify(int staffid, string open, string end, int ygqjid, int ccid)             //校验出差和请假有没有重复时间
        {
            token = appclass.CRM_Gettoken();
            int i = crmModels.KQ_YGQJ.Verify_QJ(open, end, staffid, token, ygqjid, ccid);
            if (i == 0)
                return "ok";
            if (i == 1)
                return "与请假时间冲突";
            if (i == 2)
                return "与出差时间冲突";
            if (i == 3)
                return "与请假出差时间冲突";
            else
                return "登录过期";
        }

        [HttpPost]
        public int Data_Select_Dict(string dicname, int typeid)               //根据字典名称查出对应的ID,比如输入浙江，输出1
        {
            token = appclass.CRM_Gettoken();
            int i = crmModels.HG_DICT.ReadByDICNAME(dicname, typeid, token);
            return i;
        }

        [HttpPost]
        public string Data_Verify_BanZu(int staffid)             //校验当前人员当前时间能不能打卡
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_BZGZSJ[] data = crmModels.HG_BZGZSJ.Read(staffid, token);
            if(data.Length == 0)
            {
                return "0";
            }
            string hour = "";
            string minute = "";
            DateTime now = DateTime.Now;
            hour = now.Hour.ToString();
            if (now.Minute < 10)
                minute = "0" + now.Minute.ToString();
            else
                minute = now.Minute.ToString();
            int time = Convert.ToInt32(hour + minute);        //当前时间的数字格式，比如8点半就是0830
            int IsMorningOrAfternoon = 0;
            int rongcha = crmModels.SYS_CS.Read(2, token)[0].CS;
            if (time >= (Convert.ToInt32(data[0].KSSJ) - rongcha) && time <= Convert.ToInt32(data[0].KSSJ))    //在上班考勤时间内
                IsMorningOrAfternoon = 1;
            else if (time <= 1200)             //不在上班考勤时间，且为上午
                IsMorningOrAfternoon = 10;
            if (time >= Convert.ToInt32(data[0].JSSJ) && time <= (Convert.ToInt32(data[0].JSSJ) + rongcha))    //在下班考勤时间内
                IsMorningOrAfternoon = 2;
            else if (time > 1200)              //不在下班考勤时间，且为下午
                IsMorningOrAfternoon = 20;

            string data1 = "{\"IsMorningOrAfternoon\":" + IsMorningOrAfternoon + ",\"time\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\"}";
            return data1;
        }

        [HttpPost]
        public int Data_DaKa_Counts(int sxb)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_QD model = new CRM_KQ_QD();
            model.QDLX = 1;
            model.QDGSID = Convert.ToInt32(Session["STAFFID"]);
            model.SXB = sxb;
            model.QDRQ = DateTime.Now.ToString("yyyy-MM-dd");
            model.ISACTIVE = 1;
            int counts = crmModels.KQ_QD.ReadQD_COUNTS(model, token);
            return counts;

        }

        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
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
        public string Data_Submit_QingJia(int YGQJID)
        {
            token = appclass.CRM_Gettoken();
            //CRM_OA_BASIC basic = JsonConvert.DeserializeObject<CRM_OA_BASIC>(_basic);
            //basic.TemplateCode = crmModels.SYS_CS.Read(4, token)[0].CS.ToString();
            //CRM_OA_QJList list = JsonConvert.DeserializeObject<CRM_OA_QJList>(_list);
            //list.DEP = crmModels.HG_DEPT.ReadByDEPID(DEP, token).DEPNAME;

            CRM_HG_STAFF staff_model = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            basic.LoginName = staff_model.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(4, token)[0].CS.ToString();
            basic.Subject = "请假单(" + staff_model.STAFFNAME + " ";


            CRM_KQ_YGQJ QJ_model = crmModels.KQ_YGQJ.ReadByYGQJID(YGQJID, token);
            if (QJ_model.ISACTIVE != 1)
            {
                return "当前状态不可提交！";
            }

            CRM_OA_QJList list = new CRM_OA_QJList();
            list.STAFFID = QJ_model.STAFFID;
            list.OAID = "";
            list.STAFFNO = QJ_model.STAFFNO;
            list.STAFFNAME = QJ_model.STAFFNAME;
            switch (QJ_model.STAFFSEX)
            {
                case "1":
                    list.SEX = "男";
                    break;
                case "2":
                    list.SEX = "女";
                    break;
                default:
                    list.SEX = "";
                    break;
            }
            list.DEP = crmModels.HG_DEPT.ReadByDEPID(QJ_model.DEPNAME, token).DEPNAME;
            list.QJLB = crmModels.HG_DICT.ReadByDICID(QJ_model.QJLB, token).DICNAME;
            list.GO = QJ_model.QWHC;
            list.BEGINDATE = "";
            list.ENDDATE = "";
            list.BEGINTIME = QJ_model.SJQJKSSJ;
            list.ENDTIME = QJ_model.SJJSKSSJ;
            list.DAYS = QJ_model.SJQJTS.ToString();
            list.BZ = QJ_model.BZ;


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                CRM_KQ_YGQJ data = crmModels.KQ_YGQJ.ReadByYGQJID(YGQJID, token);
                data.ISACTIVE = 2;
                crmModels.KQ_YGQJ.Update(data, token);
                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = YGQJID;
                model.OACSLB = 92;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Get_NowTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        [HttpPost]
        public string Data_Submit_ChuChai(int CCID, int type)
        {
            token = appclass.CRM_Gettoken();
            //先校验这个ccid对应的天数是否等于明细的条数
            CRM_KQ_CCTT CCdata = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
            CRM_KQ_CCMX[] mxmodel = crmModels.KQ_CC.Read_MXbyCCID(CCID, token);
            if (CCdata.SJCCTS * 2 > mxmodel.Length)
            {
                return "0";
            }

            //CRM_OA_BASIC basic = JsonConvert.DeserializeObject<CRM_OA_BASIC>(_basic);
            //basic.LoginName = crmModels.HG_STAFF.ReadBySTAFFID(staffid, token).STAFFNO;
            //basic.TemplateCode = crmModels.SYS_CS.Read(5, token)[0].CS.ToString();
            //CRM_OA_CC list = JsonConvert.DeserializeObject<CRM_OA_CC>(_list);
            ////list.DEP = crmModels.HG_DEPT.ReadByDEPID(DEP, token).DEPNAME;
            //list.CXFS = crmModels.HG_DICT.ReadByDICID(Convert.ToInt32(list.CXFS), token).DICNAME;
            ////list.QTCXFSDES = crmModels.HG_DICT.ReadByDICID(Convert.ToInt32(list.QTCXFSDES), token).DICNAME;

            CRM_HG_STAFF staff_model = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            basic.LoginName = crmModels.HG_STAFF.ReadBySTAFFID(staff_model.STAFFID, token).STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(5, token)[0].CS.ToString();
            basic.Subject = "出差单(" + staff_model.STAFFNAME + " ";

            CRM_KQ_CCTT CCmodel = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
            if (CCmodel.ISACTIVE != 1)
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "当前状态不可提交";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            CRM_OA_CC list = new CRM_OA_CC();
            list.CCSQSJ = CCmodel.CCSQSJ;
            list.STAFFNAME = CCmodel.CCRNAME;
            list.CCLXDES = crmModels.HG_DICT.ReadByDICID(CCmodel.CCLX, token).DICNAME;
            list.CCDD = CCmodel.CCDD;
            list.BQYCCDES = CCmodel.BQYCC == true ? "是" : "否";
            list.ZCYWCCDES = CCmodel.ZCYWCC == true ? "是" : "否";
            list.JHCCKSSJ = CCmodel.SJKSSJ;
            list.JHCCJSSJ = CCmodel.JHCCJSSJ;
            list.CXFS = crmModels.HG_DICT.ReadByDICID(CCmodel.CXFS, token).DICNAME;
            list.YJJE = CCmodel.YJJE.ToString();
            list.QTCXFSDES = crmModels.HG_DICT.ReadByDICID(CCmodel.QTCXFS, token).DICNAME;
            list.QTCXFSJE = CCmodel.QTCXFSJE.ToString();
            switch (type)
            {
                case 1:
                    list.TITLE = "出差申请单";
                    break;
                case 2:
                    list.TITLE = "出差变更申请单";
                    break;
                case 3:
                    list.TITLE = "出差撤销申请单";
                    break;
                default:
                    list.TITLE = "";
                    break;
            }
            list.BEIZ = CCmodel.BEIZ;
            if (list.QTCXFSJE == "0" || list.QTCXFSJE == "0.00")
                list.QTCXFSJE = "";

            list.CRM_OA_CC_SUBList = new CRM_OA_CC_SUB[mxmodel.Length];
            for (int i = 0; i < mxmodel.Length; i++)
            {
                list.CRM_OA_CC_SUBList[i] = new CRM_OA_CC_SUB();
                list.CRM_OA_CC_SUBList[i].DATE = mxmodel[i].DATE;
                string sjlx = "";   //上午或下午
                if (mxmodel[i].CCSJLX == 1)
                    sjlx = "上午";
                else if (mxmodel[i].CCSJLX == 2)
                    sjlx = "下午";
                list.CRM_OA_CC_SUBList[i].CCSJLXDES = sjlx;
                list.CRM_OA_CC_SUBList[i].DD = mxmodel[i].DD;
                list.CRM_OA_CC_SUBList[i].GZMB = mxmodel[i].GZMB;
            }


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                CRM_KQ_CCTT data = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
                data.ISACTIVE = 2;
                crmModels.KQ_CC.Update_TT(data, token);


                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = CCID;
                model.OACSLB = 93;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Data_Submit_ChuChaiHeXiao(int CCID)
        {
            token = appclass.CRM_Gettoken();

            CRM_HG_STAFF staff_model = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);



            CRM_KQ_CCTT CCmodel = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
            if (CCmodel.ISACTIVE != 3 && CCmodel.ISACTIVE != 4)
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "当前状态不可提交";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            if (CCmodel.SJJE.ToString() == "")
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "实际金额不可为空";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            //校验明细的目标完成情况是不是都填了
            CRM_KQ_CCMX[] MXmodel = crmModels.KQ_CC.Read_MXbyCCID(CCID, token);
            for (int i = 0; i < MXmodel.Length; i++)
            {
                if (MXmodel[i].MBWCQK == "")
                {
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "请检查目标完成情况是否填写完整";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            basic.LoginName = staff_model.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(6, token)[0].CS.ToString();
            basic.Subject = "出差核销单(" + staff_model.STAFFNAME;

            CRM_OA_CC list = new CRM_OA_CC();
            list.CCSQSJ = CCmodel.CCSQSJ;
            list.STAFFNAME = CCmodel.CCRNAME;
            list.CCLXDES = crmModels.HG_DICT.ReadByDICID(CCmodel.CCLX, token).DICNAME;
            list.CCDD = CCmodel.CCDD;
            list.BQYCCDES = CCmodel.BQYCC == true ? "是" : "否";
            list.ZCYWCCDES = CCmodel.ZCYWCC == true ? "是" : "否";
            list.JHCCKSSJ = CCmodel.SJKSSJ;
            list.JHCCJSSJ = CCmodel.JHCCJSSJ;
            list.CXFS = crmModels.HG_DICT.ReadByDICID(CCmodel.CXFS, token).DICNAME;
            list.YJJE = CCmodel.YJJE.ToString();
            list.QTCXFSDES = crmModels.HG_DICT.ReadByDICID(CCmodel.QTCXFS, token).DICNAME;
            list.QTCXFSJE = CCmodel.QTCXFSJE.ToString();
            list.SJCCTS = CCmodel.SJCCTS.ToString();
            list.SJJE = CCmodel.SJJE.ToString();

            list.BEIZ = CCmodel.BEIZ;
            if (list.QTCXFSJE == "0" || list.QTCXFSJE == "0.00")
                list.QTCXFSJE = "";

            CRM_KQ_CCMXList[] mxmodel = crmModels.KQ_CC.Read_MXQDbyCCID(CCID, token);
            list.CRM_OA_CC_SUBList = new CRM_OA_CC_SUB[mxmodel.Length];
            for (int i = 0; i < mxmodel.Length; i++)
            {
                list.CRM_OA_CC_SUBList[i] = new CRM_OA_CC_SUB();
                list.CRM_OA_CC_SUBList[i].DATE = mxmodel[i].DATE;
                string sjlx = "";   //上午或下午
                if (mxmodel[i].CCSJLX == 1)
                    sjlx = "上午";
                else if (mxmodel[i].CCSJLX == 2)
                    sjlx = "下午";
                list.CRM_OA_CC_SUBList[i].CCSJLXDES = sjlx;
                list.CRM_OA_CC_SUBList[i].DD = mxmodel[i].DD;
                list.CRM_OA_CC_SUBList[i].GZMB = mxmodel[i].GZMB;
                list.CRM_OA_CC_SUBList[i].MBWCQK = mxmodel[i].MBWCQK;
                list.CRM_OA_CC_SUBList[i].QDWZ = mxmodel[i].QDSJ + "   " + mxmodel[i].QDWZ;
            }

            CRM_HG_WJJL[] imgdata = crmModels.HG_WJJL.Read(9, CCID, token);
            string[] img = new string[imgdata.Length];
            for (int i = 0; i < imgdata.Length; i++)
            {
                img[i] = imgdata[i].ML;
            }
            list.IMG = img;

            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                CRM_KQ_CCTT data = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
                data.ISACTIVE = 5;
                crmModels.KQ_CC.Update_TT(data, token);


                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = CCID;
                model.OACSLB = 105;
                model.OAZT = 3;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Data_Submit_YiChang(string data)
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList>(data);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.Subject = "异常考勤说明(" + staffmodel.STAFFNAME;
            basic.TemplateCode = crmModels.SYS_CS.Read(12, token)[0].CS.ToString();

            CRM_OA_YCKQSM list = new CRM_OA_YCKQSM();
            list.STAFFNAME = staffmodel.STAFFNAME;

            list.SMTABLEList = new SMTABLE[1];

            list.SMTABLEList[0] = new SMTABLE();
            list.SMTABLEList[0].SMRQ = checkdata.SMRQ;
            list.SMTABLEList[0].SMSXB = (checkdata.SMSXB == 1) ? "上班" : "下班";
            list.SMTABLEList[0].SMSX = checkdata.SMSX;

            if (checkdata.KQQDID != 0)
            {
                list.QDSJ = checkdata.QDSJ;
                list.QDWZ = checkdata.QDWZ;
                list.KQJL = checkdata.KQJL + "米";
            }
            else
            {
                list.QDSJ = "没有考勤";
                list.QDWZ = "";
                list.KQJL = "";
            }



            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {


                checkdata.ISACTIVE = 2;
                crmModels.KQ_YCKQSM.Update(checkdata, token);

                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = checkdata.YCKQID;
                model.OACSLB = 104;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);



        }

        [HttpPost]
        public string Data_InsertSubmit_YiChang(string data)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_YCKQSMList YCmodel = JsonConvert.DeserializeObject<CRM_KQ_YCKQSMList>(data);
            //先看看有没有重复数据
            YCmodel.ISACTIVE = 0;     //先传0，表示忽略该字段进行查询，查出来如果有，就不能继续新增
            int count = crmModels.KQ_YCKQSM.ReadByParam(YCmodel, token).Length;
            if (count != 0)
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "已经存在该说明记录";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            YCmodel.ISACTIVE = 1;
            //然后新增
            YCmodel.SMR = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token).STAFFNAME;
            int i = crmModels.KQ_YCKQSM.Create(YCmodel, token);
            if (i <= 0)
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "提交失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);

            }

            //没问题了就提交OA

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.Subject = "异常考勤说明(" + staffmodel.STAFFNAME;
            basic.TemplateCode = crmModels.SYS_CS.Read(12, token)[0].CS.ToString();

            CRM_OA_YCKQSM list = new CRM_OA_YCKQSM();
            list.STAFFNAME = staffmodel.STAFFNAME;

            list.SMTABLEList = new SMTABLE[1];

            list.SMTABLEList[0] = new SMTABLE();
            list.SMTABLEList[0].SMRQ = YCmodel.SMRQ;
            list.SMTABLEList[0].SMSXB = (YCmodel.SMSXB == 1) ? "上班" : "下班";
            list.SMTABLEList[0].SMSX = YCmodel.SMSX;

            if (YCmodel.KQQDID != 0)
            {
                CRM_KQ_QD QDdata = crmModels.KQ_QD.ReadByKQQDID(YCmodel.KQQDID, token);
                list.QDSJ = QDdata.QDSJ;
                list.QDWZ = QDdata.QDWZ;
                list.KQJL = QDdata.KQJL + "米";
            }
            else
            {
                list.QDSJ = "没有考勤";
                list.QDWZ = "";
                list.KQJL = "";
            }



            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                YCmodel.YCKQID = i;
                YCmodel.ISACTIVE = 2;
                crmModels.KQ_YCKQSM.Update(YCmodel, token);

                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = i;
                model.OACSLB = 104;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }

        public string Data_Selece_KaoQin(int STAFFLX, string STAFFNAME, string STAFFNO, string open, string end, int DEPID, int OnlyQQ)
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_COLLECTList[] data = crmModels.CRM_KQ_Report.CRM_KQ_REPORT_SUMMARY(0, DEPID, STAFFLX, STAFFNAME, STAFFNO, open, end, OnlyQQ, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Selece_KaoQin_Personal(string open, string end)
        {
            token = appclass.CRM_Gettoken();
            string staffno = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token).STAFFNO;
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_COLLECTList[] data = crmModels.CRM_KQ_Report.CRM_KQ_REPORT_SUMMARY(Convert.ToInt32(Session["STAFFID"]), 0, 0, "", staffno, open, end, 0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_QD(int staffid, string opentime, string endtime)
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_QDList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QD(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_CC(int staffid, string opentime, string endtime)
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_CCTTList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_CC(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_QJ(int staffid, string opentime, string endtime)
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_YGQJList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QJ(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_YC(int staffid, string opentime, string endtime)
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_YCKQSM[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_YC(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_QQ(int staffid, string opentime, string endtime)
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_QQList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QQ(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        public ActionResult Retreat_ChuChai()
        {
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-2).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.AddMonths(1).ToString("yyyy-MM-dd");
            return View();
        }



        [HttpPost]
        public string Data_Modify_CCTT(int CCID, string beiz)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_CCTT model = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
            model.BEIZ = beiz;
            int int1 = crmModels.KQ_CC.Update_TT(model, token);
            if (int1 <= 0)
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "保存失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            ////先校验这个ccid对应的天数是否等于明细的条数
            //CRM_KQ_CCMX[] mxmodel = crmModels.KQ_CC.Read_MXbyCCID(model.CCID, token);
            //if (model.SJCCTS * 2 > mxmodel.Length)
            //{
            //    MessageInfo msg = new MessageInfo();
            //    msg.Key = "0";
            //    msg.Value = "请确认明细数量与出差天数是否对应！";
            //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            //}

            ////然后先保存
            //int id = crmModels.KQ_CC.Update_TT(model, token);
            //if (id <= 0)
            //{
            //    MessageInfo msg = new MessageInfo();
            //    msg.Key = "0";
            //    msg.Value = "保存失败，未发起OA流程";
            //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            //}

            //开始做OA
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            basic.Subject = "出差撤销单(" + staffmodel.STAFFNAME + " ";
            basic.LoginName = crmModels.HG_STAFF.ReadBySTAFFID(staffmodel.STAFFID, token).STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(5, token)[0].CS.ToString();

            CRM_OA_CC list = new CRM_OA_CC();
            list.CCSQSJ = model.CCSQSJ;
            list.STAFFNAME = model.CCRNAME;
            list.CCLXDES = crmModels.HG_DICT.ReadByDICID(Convert.ToInt32(model.CCLX), token).DICNAME;
            list.CCDD = model.CCDD;
            list.BQYCCDES = model.BQYCC == true ? "是" : "否";
            list.ZCYWCCDES = model.ZCYWCC == true ? "是" : "否";
            list.JHCCKSSJ = model.JHCCKSSJ;
            list.JHCCJSSJ = model.JHCCJSSJ;
            list.CXFS = crmModels.HG_DICT.ReadByDICID(Convert.ToInt32(model.CXFS), token).DICNAME;
            list.YJJE = model.YJJE.ToString();
            list.QTCXFSDES = crmModels.HG_DICT.ReadByDICID(Convert.ToInt32(model.QTCXFS), token).DICNAME;
            list.QTCXFSJE = model.QTCXFSJE.ToString();
            list.BEIZ = model.BEIZ;
            if (list.QTCXFSJE == "0" || list.QTCXFSJE == "0.00")
                list.QTCXFSJE = "";

            list.TITLE = "出差撤销单";


            CRM_KQ_CCMX[] mxmodel = crmModels.KQ_CC.Read_MXbyCCID(model.CCID, token);
            list.CRM_OA_CC_SUBList = new CRM_OA_CC_SUB[mxmodel.Length];
            for (int i = 0; i < mxmodel.Length; i++)
            {
                list.CRM_OA_CC_SUBList[i] = new CRM_OA_CC_SUB();
                list.CRM_OA_CC_SUBList[i].DATE = mxmodel[i].DATE;
                string sjlx = "";   //上午或下午
                if (mxmodel[i].CCSJLX == 1)
                    sjlx = "上午";
                else if (mxmodel[i].CCSJLX == 2)
                    sjlx = "下午";
                list.CRM_OA_CC_SUBList[i].CCSJLXDES = sjlx;
                list.CRM_OA_CC_SUBList[i].DD = mxmodel[i].DD;
                list.CRM_OA_CC_SUBList[i].GZMB = mxmodel[i].GZMB;
            }


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                model.ISACTIVE = 2;
                crmModels.KQ_CC.Update_TT(model, token);


                CRM_OA_TRANSMIT TRANSMITmodel = new CRM_OA_TRANSMIT();
                TRANSMITmodel.OAID = info.Key;
                TRANSMITmodel.OACSBH = model.CCID;
                TRANSMITmodel.OACSLB = 1083;
                TRANSMITmodel.OAZT = 1;
                TRANSMITmodel.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(TRANSMITmodel, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }


        [HttpPost]
        public string Data_SelectYCQD_ByDate(string QDRQ, int SXB)
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_QD[] data = crmModels.KQ_QD.ReadYCQD_ByDATE(QDRQ, SXB, Convert.ToInt32(Session["STAFFID"]), token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;

        }

        [HttpPost]
        public string Data_VerifyQDdate(int IsMorningOrAfternoon)             //校验当前上下班签到是否与出差请假有重复时间
        {
            token = appclass.CRM_Gettoken();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string open = "", end = "";
            if (IsMorningOrAfternoon == 1 || IsMorningOrAfternoon == 10)        //上午
            {
                open = date + " 08:00:00";
                end = date + " 12:00:00";
            }
            else
            {
                open = date + " 12:00:00";
                end = date + " 17:00:00";
            }

            int i = crmModels.KQ_YGQJ.Verify_QJ(open, end, appclass.CRM_GetStaffid(), token, 0, 0);
            if (i == 0)
                return "ok";
            if (i == 1)
                return "请假期间，无需打卡";
            if (i == 2)
                return "出差期间，请在出差签到及评估界面进行签到";
            if (i == 3)
                return "请假出差期间，无需打卡";
            else
                return "登录过期";
        }

    }
}
