using Sonluk.UI.Model.CRM.BF_BFService;
using Sonluk.WX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.BF_BFQDService;
using Sonluk.UI.Model.CRM.KQ_QDService;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.CRM_PENGDINGService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.KH_DZService;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.BF_BFJHMXService;
using Sonluk.WX.APPCLASS;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class BaiFangController : Controller
    {
        //
        // GET: /CRM/BaiFang/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult bf_log()
        {
            return View();
        }

        public ActionResult Select_KeHu_ToBaiFang()
        {
            Session["location"] = 49;
            return View();
        }

        public ActionResult Insert_BaiFang()
        {

            return View();
        }

        public ActionResult Update_BaiFang()
        {

            return View();
        }

        public ActionResult BaiFangManage()
        {
            Session["location"] = 47;
            return View();
        }

        public ActionResult CX_BaiFang()
        {
            Session["location"] = 48;
            return View();
        }



        [HttpPost]
        public string create_bfdj(string BFDJID, string XSQD, string BFDZ, string BFSJ, string LXR, string LXRTEL, string LXRZW, int BFMD, int BFJG, string XCBFSJ, string XCBFJH, string QTXX, string ISACTIVE, string BFJHID, string BFKH, string CRMID, string KHMC, string KHLX)
        {
            if (Session["STAFFID"] != null)
            {
                int STAFFID = Convert.ToInt32(Session["STAFFID"].ToString());
                string rst = "";
                CRM_BF_BFDJ bfdj_in = new CRM_BF_BFDJ();
                bfdj_in.BFJHID = Convert.ToInt32(BFJHID);
                bfdj_in.BFRYID = STAFFID;
                bfdj_in.BFKH = Convert.ToInt32(BFKH);
                bfdj_in.BFLX = 1;
                bfdj_in.CRMID = CRMID;
                bfdj_in.KHMC = KHMC;
                bfdj_in.KHLX = Convert.ToInt32(KHLX);
                bfdj_in.JHBFKSSJ = XCBFSJ;
                bfdj_in.JHBFJSSJ = XCBFSJ;
                //bfdj_in.BFPC = 0;

                bfdj_in.XSQD = XSQD;
                bfdj_in.BFDZ = BFDZ;
                //bfdj_in.BFSJ = BFSJ;
                bfdj_in.LXR = LXR;
                bfdj_in.LXRTEL = LXRTEL;
                bfdj_in.LXRZW = Convert.ToInt32(LXRZW);
                bfdj_in.BFMD = BFMD;
                bfdj_in.BFJG = BFJG;
                bfdj_in.XCBFSJ = XCBFSJ;
                bfdj_in.XCBFJH = XCBFJH;
                bfdj_in.QTXX = QTXX;
                bfdj_in.ISACTIVE = Convert.ToInt32(ISACTIVE);
                rst = crmModels.BF_BF.Create_BFDJ(bfdj_in, Session["token"].ToString()).ToString();
                return rst;
            }
            else
            {
                return "0";
            }
        }







        [HttpPost]
        public int Data_Insert_BFDJ(string data)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFDJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFDJ>(data);
            model.JHBFKSSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (model.ISACTIVE == 1)
                model.JHBFJSSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            else
                model.JHBFJSSJ = "";
            int i = crmModels.BF_BF.Create_BFDJ(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Insert_QiandaoAndBFDJ(string bfdata, string qddata, string sf, string cs)
        {
            string token = appClass.CRM_Gettoken();
            int[] data = { 0, 0 };
            CRM_BF_BFDJ bf = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFDJ>(bfdata);
            CRM_KQ_QD qd = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KQ_QD>(qddata);

            if (bf.BFKH != 0)
            {
                //先校验当前位置在不在客户的签到地址范围内
                CRM_KH_DZList[] KHDZmodel = crmModels.KH_DZ.ReadByKHID(bf.BFKH, token);
                if (KHDZmodel.Length == 0)
                {
                    data[0] = -2;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(data);
                }
                CRM_KH_DZList minModel = new CRM_KH_DZList();
                double min = double.MaxValue;
                for (int x = 0; x < KHDZmodel.Length; x++)
                {
                    double dist = GetDistance(Convert.ToDouble(qd.QDWD), Convert.ToDouble(qd.QDJD), Convert.ToDouble(KHDZmodel[x].ED), Convert.ToDouble(KHDZmodel[x].JD));
                    if (dist <= KHDZmodel[x].DZRC)     //在范围内
                    {
                        qd.QDGSHXMID = KHDZmodel[x].DZID;
                        qd.KQJL = dist.ToString();
                        //break;
                    }
                    else
                    {
                        if (dist < min)   //不在范围内的话就取出距离最近的那个签到点
                        {
                            min = dist;
                            minModel = KHDZmodel[x];
                        }
                    }

                }
                if (qd.QDGSHXMID == 0)     //不在范围内
                {
                    qd.QDGSHXMID = minModel.DZID;
                    qd.KQJL = min.ToString();
                    qd.ISACTIVE = 0;
                }
            }


            bf.JHBFKSSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bf.JHBFJSSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            qd.QDGSID = crmModels.BF_BF.Create_BFDJ(bf, token);
            qd.SF = crmModels.HG_DICT.ReadByDICNAME(sf, 1, token);
            qd.CS = crmModels.HG_DICT.ReadByDICNAME(cs, 2, token);
            int i = crmModels.KQ_QD.Create(qd, token);
            if (qd.ISACTIVE == 0)
            {
                data[0] = -1;
                data[1] = qd.QDGSID;
                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            else
            {
                data[0] = 1;
                data[1] = qd.QDGSID;
                return Newtonsoft.Json.JsonConvert.SerializeObject(data); ;
            }

        }

        [HttpPost]
        public string Data_Select_BFDJ_BY_STAFFID(string bfdata, int isGun)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFDJ_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFDJ_PARAMS>(bfdata);
            if (model.BFRYID == 0)
            {
                model.BFRYID = Convert.ToInt32(Session["STAFFID"]);
                isGun = 1;
            }

            CRM_BF_BFDJList[] data = crmModels.BF_BF.Read(model, isGun, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_BFDJ_BY_BFDJID(int BFDJID)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFDJ data = crmModels.BF_BF.ReadByBFDJID(BFDJID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_BFDJ(string data, int BFDJID)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFDJ newmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFDJ>(data);
            CRM_BF_BFDJ djmodel = crmModels.BF_BF.ReadByBFDJID(BFDJID, token);
            djmodel.LXR = newmodel.LXR;
            djmodel.LXRTEL = newmodel.LXRTEL;
            djmodel.LXRZW = newmodel.LXRZW;
            djmodel.BFMD = newmodel.BFMD;
            djmodel.BFJG = newmodel.BFJG;
            djmodel.QTXX = newmodel.QTXX;
            djmodel.ISACTIVE = newmodel.ISACTIVE;
            if (newmodel.ISACTIVE == 1)
                djmodel.JHBFJSSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int i = crmModels.BF_BF.Update_BFDJ(djmodel, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_BFDJ(int BFDJID)
        {
            string token = appClass.CRM_Gettoken();
            int i = crmModels.BF_BF.Delete_BFDJ(BFDJID, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_BFqudao(int BFDJID, string qudaoName)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFQD model = new CRM_BF_BFQD();
            model.BFDJID = BFDJID;
            model.QDID = crmModels.HG_DICT.ReadByDICNAME(qudaoName, 7, token);
            int i = crmModels.BF_BFQD.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_BFqudao(int BFDJID)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFQDLIST[] data = crmModels.BF_BFQD.ReadByBFDJID(BFDJID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_BFqudao(int BFQDID)
        {
            string token = appClass.CRM_Gettoken();
            int i = crmModels.BF_BFQD.Delete(BFQDID, token);
            return i;
        }

        public ActionResult Backlog()
        {

            return View();
        }

        public ActionResult BacklogMX()
        {
            return View();
        }

        [HttpPost]
        public string Data_Select_BacklogTotal()
        {
            string token = appClass.CRM_Gettoken();
            CRM_PENDING_SUMMARY[] data = crmModels.CRM_PENGING.Read_Summary(Convert.ToInt32(Session["STAFFID"]), token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_backlogMX(int summaryid)
        {
            string token = appClass.CRM_Gettoken();
            CRM_PENDING_DETAIL[] data = crmModels.CRM_PENGING.Read_Detail(Convert.ToInt32(Session["STAFFID"]), summaryid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_STAFF_ToDDL()
        {
            string token = appClass.CRM_Gettoken();
            CRM_HG_STAFF[] data = crmModels.HG_STAFF.ReadSTAFF_KHGOURPBYSTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
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

        public ActionResult ZXManage()         //专项活动
        {
            Session["location"] = 57;
            DateTime enddate = DateTime.Now;
            DateTime startdate = enddate.AddMonths(-3);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Insert_ZX()
        {
            return View();
        }

        public ActionResult Update_ZX()
        {
            return View();
        }

        public ActionResult ZPManage()        //拜访指派
        {
            Session["location"] = 58;
            DateTime enddate = DateTime.Now;
            DateTime startdate = enddate.AddMonths(-3);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Insert_ZP()
        {
            return View();
        }

        public ActionResult Update_ZP()
        {
            return View();
        }

        public ActionResult BaiFangReportBySTAFF()
        {
            string token = appClass.CRM_Gettoken();
            Session["location"] = 65;
            ViewBag.Department = crmModels.HG_DEPT.ReadByStaffid(Convert.ToInt32(Session["STAFFID"]), token);
            ViewBag.STAFF = crmModels.HG_STAFF.ReadSTAFF_KHGOURPBYSTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            ViewBag.STAFFLX = crmModels.HG_DICT.Read(33,0,token);
            return View();
        }

        [HttpPost]
        public int Data_Insert_Plan(string data)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFJH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFJH>(data);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            model.CJSJ = DateTime.Now.ToString();
            int i = crmModels.BF_BF.Create_BFJH(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Plan(int BFLX, string BFJHMC, string START, string END, int STAFFID)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFJHList[] data = crmModels.BF_BF.ReadByParams(BFLX, BFJHMC, START, END, STAFFID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_PlanByBFJHID(int BFJHID)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFJH data = crmModels.BF_BF.Read_BFJDByID(BFJHID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_Plan(string data)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFJH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFJH>(data);
            int i = crmModels.BF_BF.Update_BFJH(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Plan(int BFJHID)
        {
            string token = appClass.CRM_Gettoken();
            int i = crmModels.BF_BF.Delete_BFJH(BFJHID, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_PlanMX(string data, int BFJHID)
        {
            string token = appClass.CRM_Gettoken();
            CRM_KH_KHList[] khmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHList[]>(data);
            CRM_BF_BFJHMX[] model = new CRM_BF_BFJHMX[khmodel.Length];
            for (int j = 0; j < model.Length; j++)
            {
                STAFFDUTY_KH[] staff = crmModels.HG_STAFF.ReadSTAFFBYKHIDANDDUTY(khmodel[j].KHID, 5, token);
                model[j] = new CRM_BF_BFJHMX();
                model[j].BFJHID = BFJHID;
                model[j].KHID = khmodel[j].KHID;
                model[j].KHMC = khmodel[j].MC;
                model[j].KHLX = khmodel[j].KHLX;
                model[j].ISACTIVE = 1;
                if (staff == null || staff.Length == 0)
                {
                    model[j].BFRYID = 0;
                }
                else
                {
                    model[j].BFRYID = staff[staff.Length - 1].STAFFID;
                }

                int i = crmModels.BF_BFJHMX.Create(model[j], token);
                if (i <= 0)
                    return 0;
            }

            return 1;
        }

        [HttpPost]
        public string Data_Select_PlanMX(int BFJHID)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFJHMXList[] data = crmModels.BF_BFJHMX.ReadbyBFJHID(BFJHID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_PlanMX(string data)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFJHMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFJHMX>(data);
            int i = crmModels.BF_BFJHMX.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Update_PlanMX_STAFF(string data, int STAFFID)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFJHMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFJHMX>(data);
            model.BFRYID = STAFFID;
            int i = crmModels.BF_BFJHMX.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_PlanMX(int BFJHMXID)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_BFJHMX model = new CRM_BF_BFJHMX();
            model.BFJHMXID = BFJHMXID;
            int i = crmModels.BF_BFJHMX.Delete(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Report_BFDJ_Total(string cxdata)
        {
            string token = appClass.CRM_Gettoken();
            CRM_KHDJ_REPORT_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KHDJ_REPORT_PARAMS>(cxdata);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            CRM_KHDJ_REPORT_SUMMARY[] data = crmModels.BF_BF.ReadKHBF_BFDJ_SUMMARY(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Report_BFDJ_Detail(string cxdata)
        {
            string token = appClass.CRM_Gettoken();
            CRM_KHDJ_REPORT_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KHDJ_REPORT_PARAMS>(cxdata);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            CRM_KHDJ_REPORT_DETAIL[] data = crmModels.BF_BF.ReadKHBF_BFDJ_DETAIL(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Cacu_Distance(int KHID, string lat, string lon)
        {
            string token = appClass.CRM_Gettoken();

            CRM_KH_DZList[] DZdata = crmModels.KH_DZ.ReadByKHID(KHID, token);
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
            string[] s = new string[2];
            s[0] = Newtonsoft.Json.JsonConvert.SerializeObject(minModel);
            s[1] = min.ToString().Split('.')[0];


            //string[][] data = crmModels.KQ_QD.Verify_QD(staffid, lat, lon, accu, token);

            string ss = Newtonsoft.Json.JsonConvert.SerializeObject(s);
            return ss;
        }

        [HttpPost]
        public string Data_ReportBySTAFF_SummaryTotal(string cxdata)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_REPORT_BYSTAFF_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_REPORT_BYSTAFF_PARAMS>(cxdata);
            CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL[] data = crmModels.BF_BF.ReadKHBF_ReportByStaff_SummaryTotal(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_ReportBySTAFF_Summary(string cxdata)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_REPORT_BYSTAFF_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_REPORT_BYSTAFF_PARAMS>(cxdata);
            CRM_BF_REPORT_BYSTAFF_SUMMARY[] data = crmModels.BF_BF.ReadKHBF_ReportByStaff_Summary(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_ReportBySTAFF_Detail(string cxdata)
        {
            string token = appClass.CRM_Gettoken();
            CRM_BF_REPORT_BYSTAFF_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_REPORT_BYSTAFF_PARAMS>(cxdata);
            CRM_BF_BFDJList[] data = crmModels.BF_BF.ReadKHBF_ReportByStaff_Detail(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }



    }
}
