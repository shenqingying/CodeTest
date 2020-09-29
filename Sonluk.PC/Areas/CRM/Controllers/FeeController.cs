using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.COST_LKAPRODUCTService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.COST_LKAXSService;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.COST_GGGSService;
using Sonluk.UI.Model.CRM.HG_WJJLService;
using Sonluk.UI.Model.CRM.COST_CPService;
using Sonluk.UI.Model.CRM.COST_LKAYEARMDService;
using Sonluk.UI.Model.CRM.COST_LKAYEARLISTService;
using Sonluk.UI.Model.CRM.COST_LKAYEARCOSTService;
using Sonluk.UI.Model.CRM.COST_LKAYEARTTService;
using Sonluk.UI.Model.CRM.COST_LKAYEARXSService;
using Sonluk.UI.Model.CRM.COST_ZZFSJTService;
using Sonluk.UI.Model.CRM.COST_ITEMService;
using Sonluk.UI.Model.CRM.COST_ZZFTTService;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.KH_KHQTXXService;
using Newtonsoft.Json;
using Sonluk.UI.Model.CRM.COST_ZZFMXService;
using Sonluk.UI.Model.CRM_OAService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.OA_TRANSMITService;
using Sonluk.UI.Model.CRM.OA_OPINIONService;
using Sonluk.UI.Model.CRM.COST_LKAFYTTService;
using Sonluk.UI.Model.CRM.COST_LKAFYMXDTService;
using Sonluk.UI.Model.CRM.COST_LKAFYMXTSCLService;
using Sonluk.UI.Model.CRM.COST_LKAHXZLTTService;
using Sonluk.UI.Model.CRM.COST_LKAHXZLMXService;
using Sonluk.UI.Model.CRM.COST_LKAHXZLMDService;
using Sonluk.UI.Model.CRM.COST_LKAYEARCOST_LKAHXZLMXService;
using Sonluk.UI.Model.CRM.COST_LKAHXDJTTService;
using Sonluk.UI.Model.CRM.COST_LKAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_LKAHXZLMX_LKAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_FIService;
using Sonluk.UI.Model.CRM.SAP_ReportService;
using Sonluk.UI.Model.CRM.COST_CLFMXService;
using Sonluk.UI.Model.CRM.COST_CLFTTService;
using Sonluk.UI.Model.CRM.COST_CLFTT_STAFFService;
using Sonluk.UI.Model.CRM.COST_CBZXService;
using Sonluk.UI.Model.CRM.COST_TSService;
using Sonluk.UI.Model.CRM.COST_TSMXService;
using Sonluk.UI.Model.CRM.COST_CLFMX_CLFHXService;
using Sonluk.UI.Model.CRM.COST_CLFHXService;
using Sonluk.UI.Model.CRM.COST_KAXSService;
using Sonluk.UI.Model.CRM.COST_KAYEARTTService;
using Sonluk.UI.Model.CRM.COST_KAYEARCOSTService;
using Sonluk.UI.Model.CRM.COST_PSFService;
using Sonluk.UI.Model.CRM.COST_OTHERService;
using Sonluk.UI.Model.CRM.COST_KADTTTService;
using Sonluk.UI.Model.CRM.COST_KADTDPService;
using Sonluk.UI.Model.CRM.COST_KADTMXService;
using Sonluk.UI.Model.CRM.COST_KATSCLTTService;
using Sonluk.UI.Model.CRM.COST_KATSCLMXService;
using Sonluk.UI.Model.CRM.COST_MDBSService;
using Sonluk.UI.Model.CRM.COST_KAHXZLTTService;
using Sonluk.UI.Model.CRM.COST_KAHXZLMXService;
using Sonluk.UI.Model.CRM.COST_CXYService;
using Sonluk.UI.Model.CRM.COST_KAHXDJTTService;
using Sonluk.UI.Model.CRM.COST_KAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_KAHXZLMX_KAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_MDBS_KAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_OTHER_KAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_PSF_KAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_KAYEARCOST_KAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_CXYGZService;
using Sonluk.UI.Model.CRM.COST_JXSHXDJTTService;
using Sonluk.UI.Model.CRM.COST_JXSHXDJMXService;
using Sonluk.UI.Model.CRM.KH_GROUPService;
using Sonluk.PC.Models.CRM;
using Sonluk.UI.Model.CRM.COST_CPLXService;
using Sonluk.UI.Model.CRM.COST_CXHDService;
using Sonluk.UI.Model.CRM.COST_CXHDTCService;
using Sonluk.UI.Model.CRM.COST_GSZCFSService;
using Sonluk.UI.Model.CRM.COST_CXHDPGQDService;
using Sonluk.UI.Model.CRM.COST_CXHDPGHZService;
using Sonluk.UI.Model.CRM.COST_JXSHXDJMX_COSTService;
using System.Text;
using Sonluk.UI.Model.CRM.COST_CJHDWDService;
using Sonluk.UI.Model.CRM.COST_WDTCService;
using Sonluk.UI.Model.CRM.COST_MDBSHXService;
using Sonluk.UI.Model.CRM.KH_DZService;
using Sonluk.UI.Model.CRM.HG_STAFFDICTService;
using Sonluk.UI.Model.CRM.COST_ZZFTT_LKAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService;
using Sonluk.UI.Model.CRM.COST_LKADTDPService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class FeeController : Controller
    {
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];
        //
        // GET: /CRM/Fee/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Insert_LKAyear()
        {
            return View();
        }

        public ActionResult Select_LKAyear()
        {
            Session["location"] = 95;
            ViewBag.STAFFID = appClass.CRM_GetStaffid();
            return View();
        }

        public ActionResult Select_LKAyear_UpdateAll()
        {
            Session["location"] = 556;
            ViewBag.STAFFID = appClass.CRM_GetStaffid();
            return View();
        }

        public ActionResult Update_LKAyear(int LKAYEARTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
            cxmodel.LKAYEARTTID = LKAYEARTTID;
            CRM_COST_LKAYEARTT data = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel, 0, token)[0];


            if (data.ISACTIVE == 10 || data.ISACTIVE == 40 || data.ISACTIVE == 45 || data.ISACTIVE == 55)
            {
                string year = DateTime.Now.Year.ToString();
                string begin = "";
                string end = "";
                if (year == data.HTYEAR)
                {
                    begin = year + "0101";
                    end = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    begin = data.HTYEAR + "0101";
                    end = data.HTYEAR + "1231";
                }
                SAP_RWJDInfo XSRW = crmModels.SAP_Report.SAP_RWJD(data.JXSSAPSN, data.HTYEAR, begin, end, token);
                data.XSRW = Convert.ToDouble(XSRW.Task1);
                data.AXSRW = Convert.ToDouble(XSRW.Task2);
                data.XSJD = Convert.ToDouble(XSRW.Jz1);
                data.AXSJD = Convert.ToDouble(XSRW.Jz2);

                CRM_KH_KHList KHmodel = crmModels.KH_KH.Read(data.LKAID, token);
                data.FIRSTTIME = KHmodel.FIRSTTIME;
                data.PSQK = KHmodel.PSQK;
                data.FSFW = KHmodel.FSFW;
                data.MANAGEWAY = KHmodel.MANAGEWAY;
                data.PAYWAY = KHmodel.PAYWAY;

                string JPstr = "";
                CRM_KH_KHQTXXList[] JP = crmModels.KH_KHQTXX.Read(data.LKAID, 3, token);
                if (JP.Length != 0)
                {
                    JPstr = JP[0].XXMC;
                    for (int j = 1; j < JP.Length; j++)
                    {
                        JPstr = JPstr + "," + JP[j].XXMC;
                    }
                }

                data.JZPPNAME = JPstr;
                data.GSLXR = KHmodel.GSLXR;
                data.GSLXRZW = KHmodel.GSLXRZW;
                data.GSLXDH = KHmodel.GSLXDH;
                data.QTCP = KHmodel.SUPPORTOTHER;
                //data.SFXJMC = KHmodel.ISNEW;
                data.SFZJQDHT = KHmodel.PACT;
                data.KAGXLKA = KHmodel.BELONGKA;
                data.WEBSITE = KHmodel.WEBSITE;
                data.ACCOUNT = KHmodel.ACCOUNT;

                crmModels.COST_LKAYEARTT.Update(data, token);

                //页面打开时需要更新对应的子表数据
                crmModels.COST_LKAYEARMD.UpdateMDSL(LKAYEARTTID, token);          //更新门店情况中的门店数量
                crmModels.COST_LKAYEARLIST.DeleteByTTID(LKAYEARTTID, token);      //先删光该TTID对应的LKA清单，然后重新新增
                CRM_COST_LKAYEARLIST[] LIST = crmModels.COST_LKAYEARLIST.ReadListByKHID(data.LKAID, data.HTYEAR, token);
                for (int i = 0; i < LIST.Length; i++)         //新增LKA清单子表
                {
                    CRM_COST_LKAYEARLIST LISTmodel = new CRM_COST_LKAYEARLIST();
                    LISTmodel.LKAYEARTTID = LKAYEARTTID;
                    LISTmodel.KHID = LIST[i].KHID;
                    LISTmodel.LAST2YEAR_HT = LIST[i].LAST2YEAR_HT;
                    LISTmodel.LAST2YEAR_GS = LIST[i].LAST2YEAR_GS;
                    LISTmodel.LASTYEAR_HT = LIST[i].LASTYEAR_HT;
                    LISTmodel.LASTYEAR_GS = LIST[i].LASTYEAR_GS;
                    LISTmodel.THISYEAR_HT = LIST[i].THISYEAR_HT;
                    LISTmodel.THISYEAR_GS = LIST[i].THISYEAR_GS;
                    LISTmodel.CCJ_HT = LIST[i].CCJ_HT;
                    LISTmodel.CCJ_GS = LIST[i].CCJ_GS;
                    int ii = crmModels.COST_LKAYEARLIST.Create(LISTmodel, token);
                }
            }





            //读取更新后的信息
            data = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel, 0, token)[0];

            ViewBag.TTdata = data;

            CRM_KH_KHList JXS = crmModels.KH_KH.Read(data.JXSID, token);
            ViewBag.JXS = JXS;

            CRM_HG_DICT[] ManageWay = crmModels.HG_DICT.Read(57, 0, token);
            CRM_HG_DICT[] PayWay = crmModels.HG_DICT.Read(58, 0, token);
            CRM_HG_DICT[] GXLXRZW = crmModels.HG_DICT.Read(59, 0, token);
            CRM_HG_DICT[] XSSOURCE = crmModels.HG_DICT.Read(63, 0, token);
            CRM_HG_DICT[] KKSOURCE = crmModels.HG_DICT.Read(64, 0, token);
            CRM_HG_DICT[] NFsupport = crmModels.HG_DICT.Read(65, 0, token);
            ViewBag.ManageWay = ManageWay;
            ViewBag.PayWay = PayWay;
            ViewBag.GXLXRZW = GXLXRZW;
            ViewBag.XSSOURCE = XSSOURCE;
            ViewBag.KKSOURCE = KKSOURCE;
            ViewBag.NFsupport = NFsupport;






            return View();
        }

        public ActionResult Update_LKAyear_UpdateAll(int LKAYEARTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
            cxmodel.LKAYEARTTID = LKAYEARTTID;
            CRM_COST_LKAYEARTT data = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel, 0, token)[0];


            if (data.ISACTIVE == 10 || data.ISACTIVE == 40 || data.ISACTIVE == 45 || data.ISACTIVE == 55)
            {
                string year = DateTime.Now.Year.ToString();
                string begin = "";
                string end = "";
                if (year == data.HTYEAR)
                {
                    begin = year + "0101";
                    end = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    begin = data.HTYEAR + "0101";
                    end = data.HTYEAR + "1231";
                }
                SAP_RWJDInfo XSRW = crmModels.SAP_Report.SAP_RWJD(data.JXSSAPSN, data.HTYEAR, begin, end, token);
                data.XSRW = Convert.ToDouble(XSRW.Task1);
                data.AXSRW = Convert.ToDouble(XSRW.Task2);
                data.XSJD = Convert.ToDouble(XSRW.Jz1);
                data.AXSJD = Convert.ToDouble(XSRW.Jz2);

                CRM_KH_KHList KHmodel = crmModels.KH_KH.Read(data.LKAID, token);
                data.FIRSTTIME = KHmodel.FIRSTTIME;
                data.PSQK = KHmodel.PSQK;
                data.FSFW = KHmodel.FSFW;
                data.MANAGEWAY = KHmodel.MANAGEWAY;
                data.PAYWAY = KHmodel.PAYWAY;

                string JPstr = "";
                CRM_KH_KHQTXXList[] JP = crmModels.KH_KHQTXX.Read(data.LKAID, 3, token);
                if (JP.Length != 0)
                {
                    JPstr = JP[0].XXMC;
                    for (int j = 1; j < JP.Length; j++)
                    {
                        JPstr = JPstr + "," + JP[j].XXMC;
                    }
                }

                data.JZPPNAME = JPstr;
                data.GSLXR = KHmodel.GSLXR;
                data.GSLXRZW = KHmodel.GSLXRZW;
                data.GSLXDH = KHmodel.GSLXDH;
                data.QTCP = KHmodel.SUPPORTOTHER;
                //data.SFXJMC = KHmodel.ISNEW;
                data.SFZJQDHT = KHmodel.PACT;
                data.KAGXLKA = KHmodel.BELONGKA;
                data.WEBSITE = KHmodel.WEBSITE;
                data.ACCOUNT = KHmodel.ACCOUNT;

                crmModels.COST_LKAYEARTT.Update(data, token);

                //页面打开时需要更新对应的子表数据
                crmModels.COST_LKAYEARMD.UpdateMDSL(LKAYEARTTID, token);          //更新门店情况中的门店数量
                crmModels.COST_LKAYEARLIST.DeleteByTTID(LKAYEARTTID, token);      //先删光该TTID对应的LKA清单，然后重新新增
                CRM_COST_LKAYEARLIST[] LIST = crmModels.COST_LKAYEARLIST.ReadListByKHID(data.LKAID, data.HTYEAR, token);
                for (int i = 0; i < LIST.Length; i++)         //新增LKA清单子表
                {
                    CRM_COST_LKAYEARLIST LISTmodel = new CRM_COST_LKAYEARLIST();
                    LISTmodel.LKAYEARTTID = LKAYEARTTID;
                    LISTmodel.KHID = LIST[i].KHID;
                    LISTmodel.LAST2YEAR_HT = LIST[i].LAST2YEAR_HT;
                    LISTmodel.LAST2YEAR_GS = LIST[i].LAST2YEAR_GS;
                    LISTmodel.LASTYEAR_HT = LIST[i].LASTYEAR_HT;
                    LISTmodel.LASTYEAR_GS = LIST[i].LASTYEAR_GS;
                    LISTmodel.THISYEAR_HT = LIST[i].THISYEAR_HT;
                    LISTmodel.THISYEAR_GS = LIST[i].THISYEAR_GS;
                    LISTmodel.CCJ_HT = LIST[i].CCJ_HT;
                    LISTmodel.CCJ_GS = LIST[i].CCJ_GS;
                    int ii = crmModels.COST_LKAYEARLIST.Create(LISTmodel, token);
                }
            }





            //读取更新后的信息
            data = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel, 0, token)[0];

            ViewBag.TTdata = data;

            CRM_KH_KHList JXS = crmModels.KH_KH.Read(data.JXSID, token);
            ViewBag.JXS = JXS;

            CRM_HG_DICT[] ManageWay = crmModels.HG_DICT.Read(57, 0, token);
            CRM_HG_DICT[] PayWay = crmModels.HG_DICT.Read(58, 0, token);
            CRM_HG_DICT[] GXLXRZW = crmModels.HG_DICT.Read(59, 0, token);
            CRM_HG_DICT[] XSSOURCE = crmModels.HG_DICT.Read(63, 0, token);
            CRM_HG_DICT[] KKSOURCE = crmModels.HG_DICT.Read(64, 0, token);
            CRM_HG_DICT[] NFsupport = crmModels.HG_DICT.Read(65, 0, token);
            ViewBag.ManageWay = ManageWay;
            ViewBag.PayWay = PayWay;
            ViewBag.GXLXRZW = GXLXRZW;
            ViewBag.XSSOURCE = XSSOURCE;
            ViewBag.KKSOURCE = KKSOURCE;
            ViewBag.NFsupport = NFsupport;






            return View();
        }

        public ActionResult Insert_LKAXS()
        {
            return View();
        }

        public ActionResult Select_LKAXS()
        {
            Session["location"] = 98;
            return View();
        }

        public ActionResult Update_LKAXS(int LKAXSTTID)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_LKAXSTT cxdata = new CRM_COST_LKAXSTT();
            cxdata.LKAXSTTID = LKAXSTTID;
            CRM_COST_LKAXSTT[] data = crmModels.COST_LKAXS.ReadTTByParam(cxdata, 0, token);
            ViewBag.data = data[0];

            CRM_HG_DICT[] XSSJLX = crmModels.HG_DICT.Read(62, 0, token);
            CRM_HG_DICT[] SOURCE = crmModels.HG_DICT.Read(63, 0, token);

            ViewBag.XSSJLX = XSSJLX;
            ViewBag.SOURCE = SOURCE;
            return View();
        }


        public ActionResult ABC_Product_Index()
        {

            return View();
        }
        public ActionResult Select_ABC_Product()
        {
            Session["location"] = 96;
            return View();
        }
        public ActionResult Insert_ABC_Product()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] CLASS1 = crmModels.HG_DICT.Read(108, 0, token);
            CRM_HG_DICT[] CLASS2 = crmModels.HG_DICT.Read(109, 0, token);
            CRM_HG_DICT[] CLASS3 = crmModels.HG_DICT.Read(110, 0, token);
            ViewBag.CLASS1 = CLASS1;
            ViewBag.CLASS2 = CLASS2;
            ViewBag.CLASS3 = CLASS3;

            CRM_COST_CPLX[] CPLX = crmModels.COST_CPLX.ReadByParam(new CRM_COST_CPLX(), token);
            ViewBag.CPLX = CPLX;
            return View();
        }
        public ActionResult Update_ABC_Product()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] CLASS1 = crmModels.HG_DICT.Read(108, 0, token);
            CRM_HG_DICT[] CLASS2 = crmModels.HG_DICT.Read(109, 0, token);
            CRM_HG_DICT[] CLASS3 = crmModels.HG_DICT.Read(110, 0, token);
            CRM_HG_DICT[] CLASS4 = crmModels.HG_DICT.Read(129, 0, token);
            ViewBag.CLASS1 = CLASS1;
            ViewBag.CLASS2 = CLASS2;
            ViewBag.CLASS3 = CLASS3;
            ViewBag.CLASS4 = CLASS4;

            CRM_COST_CPLX[] CPLX = crmModels.COST_CPLX.ReadByParam(new CRM_COST_CPLX(), token);
            ViewBag.CPLX = CPLX;
            return View();
        }
        public ActionResult AdCompany_Index()
        {
            return View();
        }
        public ActionResult Insert_AdCompany()
        {
            return View();
        }
        public ActionResult Select_AdCompany()
        {
            Session["location"] = 97;
            return View();
        }
        public ActionResult Update_AdCompany()
        {
            return View();
        }
        public ActionResult Check_AdCompany()
        {
            Session["location"] = 99;
            return View();
        }
        public ActionResult Select_Create_Fee()
        {
            Session["location"] = 500;
            return View();
        }
        public ActionResult Select_JXSFee()
        {
            Session["location"] = 537;
            return View();
        }
        public ActionResult Update_JXSFee(int TTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT cxdata = new CRM_COST_ZZFTT();
            cxdata.TTID = TTID;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(cxdata, 0, token);
            ViewBag.data = data[0];

            CRM_COST_GGGS model = new CRM_COST_GGGS();
            model.ISACTIVE = 3;
            CRM_COST_GGGS[] GGGSID = crmModels.COST_GGGS.ReadByParam(model, token);
            CRM_COST_GGGS[] GGGSMC = crmModels.COST_GGGS.ReadByParam(model, token);

            ViewBag.GGGSID = GGGSID;
            ViewBag.GGGSMC = GGGSMC;
            return View();
        }
        public ActionResult Update_Create_Fee(int TTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT cxdata = new CRM_COST_ZZFTT();
            cxdata.TTID = TTID;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(cxdata, 0, token);
            ViewBag.data = data[0];

            CRM_COST_GGGS model = new CRM_COST_GGGS();
            model.ISACTIVE = 3;
            model.SF = data[0].SF;
            CRM_COST_GGGS[] GGGSID = crmModels.COST_GGGS.ReadByParam(model, token);
            CRM_COST_GGGS[] GGGSMC = crmModels.COST_GGGS.ReadByParam(model, token);

            ViewBag.GGGSID = GGGSID;
            ViewBag.GGGSMC = GGGSMC;


            return View();

        }
        [HttpPost]
        public string SH_ZZF(int TTID, double FINALCOST)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT MODEL = new CRM_COST_ZZFTT();
            MODEL.TTID = TTID;
            CRM_COST_ZZFTT[] DATA = crmModels.COST_ZZFTT.ReadByParam(MODEL, 0, token);
            switch (DATA[0].KHLX)
            {
                case 3:
                    // CRM_COST_ZZFTT[] cxdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT[]>(data);
                    DATA[0].HXR = appClass.CRM_GetStaffid();
                    DATA[0].FINALCOST = FINALCOST;
                    crmModels.COST_ZZFTT.Update(DATA[0], token);


                    CRM_COST_KAHXZLMX model = new CRM_COST_KAHXZLMX();
                    model.COSTID = DATA[0].TTID;
                    model.COSTITEMID = 53;
                    model.COSTITEMIDSTR = "53";
                    CRM_COST_KAHXZLMX[] newdata = crmModels.COST_KAHXZLMX.ReadByParam(model, token);
                    newdata[0].ISACTIVE = 30;
                    int m = crmModels.COST_KAHXZLMX.Update(newdata[0], token);
                    if (m < 0)
                    {
                        webmsg.KEY = m;
                        webmsg.MSG = "审核失败！";
                    }


                    webmsg.KEY = 1;
                    webmsg.MSG = "审核成功！";

                    break;

                case 7:
                    DATA[0].HXR = appClass.CRM_GetStaffid();
                    DATA[0].FINALCOST = FINALCOST;
                    crmModels.COST_ZZFTT.Update(DATA[0], token);

                    CRM_COST_LKAYEARCOST_LKAHXZLMX CXmodel = new CRM_COST_LKAYEARCOST_LKAHXZLMX();
                    CXmodel.COSTID = DATA[0].TTID;
                    CXmodel.COSTITEMID = 14;
                    CRM_COST_LKAYEARCOST_LKAHXZLMX[] data1 = crmModels.COST_LKAYEARCOST_LKAHXZLMX.ReadByTTID(CXmodel, token);

                    CRM_COST_LKAHXZLMX model1 = new CRM_COST_LKAHXZLMX();
                    model1.HXZLMXID = data1[0].HXZLMXID;
                    model1.COSTITEMID = 14;
                    model1.COSTITEMIDSTR = "14";
                    CRM_COST_LKAHXZLMX[] a = crmModels.COST_LKAHXZLMX.ReadByParam(model1, token);
                    a[0].ISACTIVE = 30;
                    int X = crmModels.COST_LKAHXZLMX.Update(a[0], token);
                    if (X < 0)
                    {
                        webmsg.KEY = X;
                        webmsg.MSG = "审核失败！";
                    }

                    webmsg.KEY = 1;
                    webmsg.MSG = "审核成功！";

                    break;
                case 1:
                    DATA[0].ISACTIVE = 60;
                    DATA[0].FINALCOST = FINALCOST;
                    DATA[0].HXR = appClass.CRM_GetStaffid();
                    int Y = crmModels.COST_ZZFTT.Update(DATA[0], token);
                    if (Y < 0)
                    {
                        webmsg.KEY = Y;
                        webmsg.MSG = "审核失败！";
                    }

                    webmsg.KEY = 1;
                    webmsg.MSG = "审核成功！";

                    break;
                case 5:
                    DATA[0].ISACTIVE = 60;
                    DATA[0].FINALCOST = FINALCOST;
                    DATA[0].HXR = appClass.CRM_GetStaffid();
                    int Z = crmModels.COST_ZZFTT.Update(DATA[0], token);
                    if (Z < 0)
                    {
                        webmsg.KEY = Z;
                        webmsg.MSG = "审核失败！";
                    }
                    webmsg.KEY = 1;
                    webmsg.MSG = "审核成功！";
                    break;

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string BACK_ZZF(int TTID, double FINALCOST)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT MODEL = new CRM_COST_ZZFTT();
            MODEL.TTID = TTID;
            CRM_COST_ZZFTT[] DATA = crmModels.COST_ZZFTT.ReadByParam(MODEL, 0, token);
            switch (DATA[0].KHLX)
            {
                case 3:

                    DATA[0].HXR = appClass.CRM_GetStaffid();
                    DATA[0].FINALCOST = FINALCOST;
                    crmModels.COST_ZZFTT.Update(DATA[0], token);

                    CRM_COST_KAHXZLMX model = new CRM_COST_KAHXZLMX();
                    model.COSTID = DATA[0].TTID;
                    model.COSTITEMID = 53;
                    model.COSTITEMIDSTR = "53";
                    CRM_COST_KAHXZLMX[] newdata = crmModels.COST_KAHXZLMX.ReadByParam(model, token);
                    newdata[0].ISACTIVE = 10;
                    int m = crmModels.COST_KAHXZLMX.Update(newdata[0], token);
                    if (m < 0)
                    {
                        webmsg.KEY = m;
                        webmsg.MSG = "回退失败！";
                    }
                    webmsg.KEY = 1;
                    webmsg.MSG = "回退成功！";


                    break;

                case 7:
                    DATA[0].HXR = appClass.CRM_GetStaffid();
                    DATA[0].FINALCOST = FINALCOST;
                    crmModels.COST_ZZFTT.Update(DATA[0], token);
                    CRM_COST_LKAYEARCOST_LKAHXZLMX CXmodel = new CRM_COST_LKAYEARCOST_LKAHXZLMX();
                    CXmodel.COSTID = DATA[0].TTID;
                    CXmodel.COSTITEMID = 14;
                    CRM_COST_LKAYEARCOST_LKAHXZLMX[] data1 = crmModels.COST_LKAYEARCOST_LKAHXZLMX.ReadByTTID(CXmodel, token);

                    CRM_COST_LKAHXZLMX model1 = new CRM_COST_LKAHXZLMX();
                    model1.HXZLMXID = data1[0].HXZLMXID;
                    model1.COSTITEMID = 14;
                    model1.COSTITEMIDSTR = "14";
                    CRM_COST_LKAHXZLMX[] a = crmModels.COST_LKAHXZLMX.ReadByParam(model1, token);
                    a[0].ISACTIVE = 10;
                    int X = crmModels.COST_LKAHXZLMX.Update(a[0], token);
                    if (X < 0)
                    {
                        webmsg.KEY = X;
                        webmsg.MSG = "回退失败！";
                    }

                    webmsg.KEY = 1;
                    webmsg.MSG = "回退成功！";

                    break;
                case 1:
                    DATA[0].ISACTIVE = 30;
                    DATA[0].FINALCOST = FINALCOST;
                    DATA[0].HXR = appClass.CRM_GetStaffid();
                    int Y = crmModels.COST_ZZFTT.Update(DATA[0], token);
                    if (Y < 0)
                    {
                        webmsg.KEY = Y;
                        webmsg.MSG = "审核失败！";
                    }

                    webmsg.KEY = 1;
                    webmsg.MSG = "审核成功！";

                    break;
                case 5:
                    DATA[0].ISACTIVE = 30;
                    DATA[0].FINALCOST = FINALCOST;
                    DATA[0].HXR = appClass.CRM_GetStaffid();
                    int Z = crmModels.COST_ZZFTT.Update(DATA[0], token);
                    if (Z < 0)
                    {
                        webmsg.KEY = Z;
                        webmsg.MSG = "审核失败！";
                    }
                    webmsg.KEY = 1;
                    webmsg.MSG = "审核成功！";
                    break;

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string GetGGGS(int SF)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GGGS model = new CRM_COST_GGGS();
            model.ISACTIVE = 3;
            model.SF = SF;
            CRM_COST_GGGS[] data = crmModels.COST_GGGS.ReadByParam(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        public ActionResult Insert_Create_Fee()
        {
            return View();
        }
        public ActionResult Select_Check_Create_Fee()
        {
            Session["location"] = 507;
            return View();
        }
        public ActionResult Update_Check_Create_Fee(int TTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT cxdata = new CRM_COST_ZZFTT();
            cxdata.TTID = TTID;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(cxdata, 0, token);
            ViewBag.data = data[0];

            CRM_COST_GGGS model = new CRM_COST_GGGS();
            model.ISACTIVE = 3;
            CRM_COST_GGGS[] GGGSID = crmModels.COST_GGGS.ReadByParam(model, token);
            CRM_COST_GGGS[] GGGSMC = crmModels.COST_GGGS.ReadByParam(model, token);

            ViewBag.GGGSID = GGGSID;
            ViewBag.GGGSMC = GGGSMC;


            return View();


        }

        [HttpPost]
        public string SubmitOrder_Create_Fee(int TTID)  //更改isactive状态
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = new CRM_COST_ZZFTT();
            model.TTID = TTID;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(model, 0, token);
            CRM_HG_WJJL[] WJmodel = crmModels.HG_WJJL.Read(36, TTID, token);
            if (WJmodel.Length == 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "广告完成画面不允许为空！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            data[0].ISACTIVE = 40;
            int m = crmModels.COST_ZZFTT.Update(data[0], token);
            if (m < 0)
            {
                webmsg.KEY = m;
                webmsg.MSG = "审核失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);


        }
        [HttpPost]
        public string SubmitOrder_JSXFee(string TTID)  //更改isactive状态
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT[]>(TTID);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_ZZFTT model = new CRM_COST_ZZFTT();
                model.TTID = checkdata[i].TTID;
                CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(model, 0, token);
                data[0].ISACTIVE = 40;
                data[0].HXR = appClass.CRM_GetStaffid();
                int m = crmModels.COST_ZZFTT.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "审核失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }

            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);


        }
        [HttpPost]
        public string SubmitOrder_Create_Fee_LAST(int TTID)  //更改isactive状态
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = new CRM_COST_ZZFTT();
            model.TTID = TTID;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(model, 0, token);
            data[0].ISACTIVE = 50;
            int i = crmModels.COST_ZZFTT.Update(data[0], token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "提交至最终审核成功！";
            else
                webmsg.MSG = "提交至审最终核失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string SubmitOrder_Create_Fee_FINSH(int TTID)  //更改isactive状态
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = new CRM_COST_ZZFTT();
            model.TTID = TTID;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(model, 0, token);
            data[0].ISACTIVE = 60;
            int i = crmModels.COST_ZZFTT.Update(data[0], token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "确认最终审核成功！";
            else
                webmsg.MSG = "确认最终审核失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public int Insert_ZZFMX(string data)         //新增制作费申请
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFMX model = JsonConvert.DeserializeObject<CRM_COST_ZZFMX>(data);
            int i = crmModels.COST_ZZFMX.Create(model, token);

            CRM_COST_ZZFTT NNMODEL = new CRM_COST_ZZFTT();
            NNMODEL.TTID = model.TTID;
            CRM_COST_ZZFTT[] NEWDATA = crmModels.COST_ZZFTT.ReadByParam(NNMODEL, 0, token);
            NEWDATA[0].SQJE = NEWDATA[0].SQJEAll;
            crmModels.COST_ZZFTT.Update(NEWDATA[0], token);

            return i;
        }
        [HttpPost]
        public string Select_ZZFMX(int dataid)   //查询制作费申请
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFMX model = new CRM_COST_ZZFMX();
            model.TTID = dataid;
            CRM_COST_ZZFMX[] data = crmModels.COST_ZZFMX.ReadByParam(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public int Update_ZZFMX(string data)   //更新制作费申请
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFMX model = JsonConvert.DeserializeObject<CRM_COST_ZZFMX>(data);
            int i = crmModels.COST_ZZFMX.Update(model, token);

            CRM_COST_ZZFTT NNMODEL = new CRM_COST_ZZFTT();
            NNMODEL.TTID = model.TTID;
            CRM_COST_ZZFTT[] NEWDATA = crmModels.COST_ZZFTT.ReadByParam(NNMODEL, 0, token);
            NEWDATA[0].SQJE = NEWDATA[0].SQJEAll;
            crmModels.COST_ZZFTT.Update(NEWDATA[0], token);

            return i;
        }
        [HttpPost]
        public int Delete_ZZFMX(int MXID, int TTID)                 //删除制作费申请
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_ZZFMX.Delete(MXID, token);

            CRM_COST_ZZFTT NNMODEL = new CRM_COST_ZZFTT();
            NNMODEL.TTID = TTID;
            CRM_COST_ZZFTT[] NEWDATA = crmModels.COST_ZZFTT.ReadByParam(NNMODEL, 0, token);
            NEWDATA[0].SQJE = NEWDATA[0].SQJEAll;
            crmModels.COST_ZZFTT.Update(NEWDATA[0], token);

            return i;
        }

        [HttpPost]
        public int Insert_ZZFSJT(string data)         //新增制作费用设计图明细
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.COST_ZZFSJTService.CRM_COST_ZZFSJT model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.COST_ZZFSJTService.CRM_COST_ZZFSJT>(data);
            int i = crmModels.COST_ZZFSJT.Create(model, token);
            return i;
        }
        [HttpPost]
        public string Select_ZZFSJT(int id)   //查询制作费用设计图明细
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFSJT model = new CRM_COST_ZZFSJT();
            model.TTID = id;
            CRM_COST_ZZFSJT[] data = crmModels.COST_ZZFSJT.ReadByParam(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public int Update_ZZFSJT(string data)   //更新制作费用设计图明细
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.COST_ZZFSJTService.CRM_COST_ZZFSJT model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.COST_ZZFSJTService.CRM_COST_ZZFSJT>(data);
            int i = crmModels.COST_ZZFSJT.Update(model, token);
            return i;
        }
        [HttpPost]
        public int Delete_ZZFSJT(int id)                 //删除制作费用设计图明细
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_ZZFSJT.Delete(id, token);
            return i;
        }
        public ActionResult Select_ITEM()
        {
            Session["location"] = 501;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] class1 = crmModels.HG_DICT.Read(67, 0, token);
            CRM_HG_DICT[] class2 = crmModels.HG_DICT.Read(68, 0, token);
            CRM_HG_DICT[] class3 = crmModels.HG_DICT.Read(84, 0, token);
            CRM_HG_DICT[] class4 = crmModels.HG_DICT.Read(85, 0, token);
            CRM_HG_DICT[] cwbh = crmModels.HG_DICT.Read(69, 0, token);
            ViewBag.CLASS1 = class1;
            ViewBag.CLASS2 = class2;
            ViewBag.CLASS3 = class3;
            ViewBag.CLASS4 = class4;
            ViewBag.CWBH = crmModels.COST_FI.ReadByParam(new CRM_COST_FI(), token);
            return View();
        }
        public ActionResult Select_CBZX()
        {
            Session["location"] = 518;
            token = appClass.CRM_Gettoken();

            return View();
        }

        public ActionResult Select_LKAHXZL()
        {
            Session["location"] = 502;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] HXXS = crmModels.HG_DICT.Read(71, 0, token);
            ViewBag.HXXS = HXXS;
            return View();
        }
        public ActionResult Update_LKAHXZL(int HXZLTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLTT cx = new CRM_COST_LKAHXZLTT();
            cx.HXZLTTID = HXZLTTID;
            CRM_COST_LKAHXZLTT TTdata = crmModels.COST_LKAHXZLTT.ReadByParam(cx, 0, token)[0];


            //如果对应的年度费用中的产品利润有一行没有审核，则页面不允许修改
            CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
            cxmodel.LKAID = TTdata.LKAID;
            cxmodel.HTYEAR = TTdata.HTYEAR;
            CRM_COST_LKAYEARTT[] YearCost = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel, 0, token);
            if (YearCost.Length == 0)
            {
                //
            }
            else
            {
                CRM_COST_CP cxmodel2 = new CRM_COST_CP();
                cxmodel2.LKAYEARTTID = YearCost[0].LKAYEARTTID;
                CRM_COST_CP[] CP = crmModels.COST_CP.ReadByParam(cxmodel2, token);
                ViewBag.ISACTIVE = 3;
                for (int i = 0; i < CP.Length; i++)
                {
                    if (CP[i].ISACTIVE == 1)
                    {
                        ViewBag.ISACTIVE = 1;
                        break;
                    }
                }
                ViewBag.MCXSSOURCE = YearCost[0].MCXSSOURCEDES;
                ViewBag.MCXSSOURCE_OTHER = YearCost[0].MCXSSOURCE_OTHER;
                ViewBag.MCFYSOURCEDES = YearCost[0].MCFYSOURCEDES;
                ViewBag.MCFYSOURCE_OTHER = YearCost[0].MCFYSOURCE_OTHER;
            }




            //更新抬头数据
            CRM_COST_LKAHXZLTT cxmodel3 = new CRM_COST_LKAHXZLTT();
            cxmodel3.HTYEAR = TTdata.HTYEAR;
            cxmodel3.LKAID = TTdata.LKAID;
            cxmodel3.BEGINDATE = TTdata.BEGINDATE;
            cxmodel3.ENDDATE = TTdata.ENDDATE;
            CRM_COST_LKAHXZLTT info = crmModels.COST_LKAHXZLTT.ReadTTGLinfo(cxmodel3, token);

            TTdata.SPJE = info.SPJE;
            TTdata.YHXJE = info.YHXJE;
            TTdata.LKAXSSJLX = info.LKAXSSJLX;
            TTdata.HTNDYGXS = info.HTNDYGXS;
            TTdata.MQLKAXSSJ = info.MQLKAXSSJ;
            TTdata.LKAYJCMDSL = info.LKAYJCMDSL;
            TTdata.LKABNDWCL = info.LKABNDWCL;
            TTdata.CRMBAMD = info.CRMBAMD;


            string year = DateTime.Now.Year.ToString();
            string begin = "";
            string end = "";
            if (year == TTdata.HTYEAR)
            {
                begin = year + "0101";
                end = DateTime.Now.ToString("yyyyMMdd");
            }
            else
            {
                begin = TTdata.HTYEAR + "0101";
                end = TTdata.HTYEAR + "1231";
            }
            SAP_RWJDInfo XSRW = crmModels.SAP_Report.SAP_RWJD(TTdata.JXSSAPSN, TTdata.HTYEAR, begin, end, token);
            TTdata.BNDXSRW = Convert.ToDouble(XSRW.Task1);
            TTdata.BNDALRW = Convert.ToDouble(XSRW.Task2);
            TTdata.XSWCL = Convert.ToDouble(XSRW.Jz1);
            TTdata.ALWCL = Convert.ToDouble(XSRW.Jz2);





            crmModels.COST_LKAHXZLTT.Update(TTdata, token);

            ViewBag.TTdata = TTdata;







            CRM_HG_DICT[] HXXS = crmModels.HG_DICT.Read(71, 0, token);
            ViewBag.HXXS = HXXS;
            CRM_HG_DICT[] MCHT = crmModels.HG_DICT.Read(74, 0, token);
            ViewBag.MCHT = MCHT;
            CRM_HG_DICT[] CSFP = crmModels.HG_DICT.Read(75, 0, token);
            ViewBag.CSFP = CSFP;

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;

            return View();
        }
        public ActionResult Select_SH_LKAHXZL()
        {
            Session["location"] = 520;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] HXXS = crmModels.HG_DICT.Read(71, 0, token);
            ViewBag.HXXS = HXXS;

            return View();
        }
        public ActionResult Update_SH_LKAHXZL(int HXZLTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLTT cx = new CRM_COST_LKAHXZLTT();
            cx.HXZLTTID = HXZLTTID;
            CRM_COST_LKAHXZLTT TTdata = crmModels.COST_LKAHXZLTT.ReadByParam(cx, 0, token)[0];
            ViewBag.TTdata = TTdata;

            CRM_HG_DICT[] HXXS = crmModels.HG_DICT.Read(71, 0, token);
            ViewBag.HXXS = HXXS;
            CRM_HG_DICT[] MCHT = crmModels.HG_DICT.Read(74, 0, token);
            ViewBag.MCHT = MCHT;
            CRM_HG_DICT[] CSFP = crmModels.HG_DICT.Read(75, 0, token);
            ViewBag.CSFP = CSFP;

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;




            CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
            cxmodel.LKAID = TTdata.LKAID;
            cxmodel.HTYEAR = TTdata.HTYEAR;
            CRM_COST_LKAYEARTT[] YearCost = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel, 0, token);

            if (YearCost.Length != 0)
            {
                ViewBag.MCXSSOURCE = YearCost[0].MCXSSOURCEDES;
                ViewBag.MCXSSOURCE_OTHER = YearCost[0].MCXSSOURCE_OTHER;
                ViewBag.MCFYSOURCEDES = YearCost[0].MCFYSOURCEDES;
                ViewBag.MCFYSOURCE_OTHER = YearCost[0].MCFYSOURCE_OTHER;
            }
            else
            {
                ViewBag.MCXSSOURCE = "";
                ViewBag.MCXSSOURCE_OTHER = "";
                ViewBag.MCFYSOURCEDES = "";
                ViewBag.MCFYSOURCE_OTHER = "";
            }





            return View();
        }
        public ActionResult Select_LKAHXDJ()
        {
            Session["location"] = 503;
            return View();
        }
        public ActionResult Update_LKAHXDJ(int HXDJTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXDJTT cxmodel = new CRM_COST_LKAHXDJTT();
            cxmodel.HXDJTTID = HXDJTTID;
            CRM_COST_LKAHXDJTT[] TTdata = crmModels.COST_LKAHXDJTT.ReadByParam(cxmodel, 0, token);
            ViewBag.TTdata = TTdata[0];

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;

            CRM_COST_FI[] CWBH = crmModels.COST_FI.ReadByParam(new CRM_COST_FI(), token);
            ViewBag.CWBH = CWBH;

            CRM_COST_CBZX[] CBZX = crmModels.COST_CBZX.ReadByParam(new CRM_COST_CBZX(), token);
            ViewBag.CBZX = CBZX;

            CRM_HG_DICT[] SL = crmModels.HG_DICT.Read(86, 0, token);
            ViewBag.SL = SL;

            CRM_HG_DICT[] FYHXXS = crmModels.HG_DICT.Read(71, 0, token);
            ViewBag.FYHXXS = FYHXXS;
            return View();
        }
        public ActionResult Select_HaiBao()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 505;

            CRM_COST_LKAPRODUCT cx_cp = new CRM_COST_LKAPRODUCT();
            cx_cp.CLASS1 = 2076;
            ViewBag.PRODUCT = crmModels.COST_LKAPRODUCT.ReadByParam(cx_cp, token);

            return View();
        }
        public ActionResult Select_HaiBao_Other()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 519;

            CRM_COST_LKAPRODUCT cx_cp = new CRM_COST_LKAPRODUCT();
            cx_cp.CLASS1 = 2076;
            ViewBag.PRODUCT = crmModels.COST_LKAPRODUCT.ReadByParam(cx_cp, token);

            return View();
        }
        public ActionResult Update_HaiBao(int LKAFYTTID)
        {
            token = appClass.CRM_Gettoken();
            crmModels.COST_LKAFYTT.UpdateCost(LKAFYTTID, token);

            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = LKAFYTTID;
            CRM_COST_LKAFYTT[] data = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token);
            ViewBag.TTdata = data[0];

            CRM_HG_DICT[] CXLX = crmModels.HG_DICT.Read(73, 0, token);
            ViewBag.CXLX = CXLX;

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;

            CRM_COST_LKAPRODUCT cx_cp = new CRM_COST_LKAPRODUCT();
            cx_cp.CLASS4 = 4137;
            ViewBag.PRODUCT = crmModels.COST_LKAPRODUCT.ReadByParam(cx_cp, token);
            return View();
        }

        public ActionResult Update_HaiBao_Other(int LKAFYTTID)
        {
            token = appClass.CRM_Gettoken();
            crmModels.COST_LKAFYTT.UpdateCost(LKAFYTTID, token);

            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = LKAFYTTID;
            CRM_COST_LKAFYTT[] data = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token);
            ViewBag.TTdata = data[0];

            CRM_HG_DICT[] CXLX = crmModels.HG_DICT.Read(73, 0, token);
            ViewBag.CXLX = CXLX;

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;

            CRM_COST_LKAPRODUCT cx_cp = new CRM_COST_LKAPRODUCT();
            cx_cp.CLASS4 = 4137;
            ViewBag.PRODUCT = crmModels.COST_LKAPRODUCT.ReadByParam(cx_cp, token);
            return View();
        }

        public ActionResult Select_Special_Display()
        {
            Session["location"] = 506;
            return View();
        }
        public ActionResult Select_Special_Display_HX()
        {
            Session["location"] = 563;
            return View();
        }
        public ActionResult Update_Special_Display(int LKAFYTTID)
        {
            token = appClass.CRM_Gettoken();
            crmModels.COST_LKAFYTT.UpdateCost(LKAFYTTID, token);

            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = LKAFYTTID;

            CRM_COST_LKAFYTT[] data = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token);
            ViewBag.TTdata = data[0];

            CRM_HG_DICT[] DISPLAY = crmModels.HG_DICT.Read(9, 0, token);
            ViewBag.DISPLAY = DISPLAY;

            return View();
        }
        public ActionResult Update_Special_Display2(int LKAFYTTID)
        {
            token = appClass.CRM_Gettoken();
            crmModels.COST_LKAFYTT.UpdateCost(LKAFYTTID, token);

            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = LKAFYTTID;

            CRM_COST_LKAFYTT[] data = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token);
            ViewBag.TTdata = data[0];

            CRM_HG_DICT[] DISPLAY = crmModels.HG_DICT.Read(9, 0, token);
            ViewBag.DISPLAY = DISPLAY;

            return View();
        }
        public ActionResult Update_Special_Display_HX(int LKAFYTTID)
        {
            token = appClass.CRM_Gettoken();
            crmModels.COST_LKAFYTT.UpdateCost(LKAFYTTID, token);

            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = LKAFYTTID;

            CRM_COST_LKAFYTT[] data = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token);
            ViewBag.TTdata = data[0];

            CRM_HG_DICT[] DISPLAY = crmModels.HG_DICT.Read(9, 0, token);
            ViewBag.DISPLAY = DISPLAY;

            return View();
        }
        public ActionResult Select_Travel()
        {
            Session["location"] = 509;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();
        }
        public ActionResult Select_Travel_SH()
        {
            Session["location"] = 525;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();
        }
        public ActionResult Select_Travel_SP()
        {
            Session["location"] = 526;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();
        }
        public ActionResult Update_Travel_SH()
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ITEM model = new CRM_COST_ITEM();
            model.ISACTIVE = 1;
            model.COSTCLASS3 = 1439;
            CRM_COST_ITEM[] COSTITEMID = crmModels.COST_ITEM.ReadByParam(model, token);
            CRM_COST_ITEM[] COSTITEMMC = crmModels.COST_ITEM.ReadByParam(model, token);


            ViewBag.COSTITEMID = COSTITEMID;
            ViewBag.COSTITEMMC = COSTITEMMC;


            ViewBag.number = 100;
            return View();
        }
        public ActionResult Insert_Travel()
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CBZX[] CBZX = crmModels.COST_CBZX.ReadByParam(new CRM_COST_CBZX(), token);
            ViewBag.CBZX = CBZX;
            DateTime now = DateTime.Now;
            ViewBag.date = now.ToString("yyyy-MM-dd");
            return View();
        }
        public ActionResult Update_Travel()
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_CBZX[] CBZX = crmModels.COST_CBZX.ReadByParam(new CRM_COST_CBZX(), token);
            ViewBag.CBZX = CBZX;

            CRM_COST_ITEM model = new CRM_COST_ITEM();
            model.ISACTIVE = 1;
            model.COSTCLASS3 = 1439;
            CRM_COST_ITEM[] COSTITEMID = crmModels.COST_ITEM.ReadByParam(model, token);
            CRM_COST_ITEM[] COSTITEMMC = crmModels.COST_ITEM.ReadByParam(model, token);


            ViewBag.COSTITEMID = COSTITEMID;
            ViewBag.COSTITEMMC = COSTITEMMC;


            ViewBag.number = 100;
            return View();

        }
        public ActionResult Update_Travel123()
        {
            return View();
        }
        public ActionResult Select_SH_Travel()
        {
            Session["location"] = 521;



            token = appClass.CRM_Gettoken();

            CRM_COST_ITEM model = new CRM_COST_ITEM();
            model.ISACTIVE = 1;
            model.COSTCLASS3 = 1439;
            CRM_COST_ITEM[] COSTITEMID = crmModels.COST_ITEM.ReadByParam(model, token);
            CRM_COST_ITEM[] COSTITEMMC = crmModels.COST_ITEM.ReadByParam(model, token);
            ViewBag.COSTITEMID = COSTITEMID;
            ViewBag.COSTITEMMC = COSTITEMMC;

            CRM_COST_FI[] CWBH = crmModels.COST_FI.ReadByParam(new CRM_COST_FI(), token);
            ViewBag.CWBH = CWBH;

            CRM_COST_CBZX[] CBZX = crmModels.COST_CBZX.ReadByParam(new CRM_COST_CBZX(), token);
            ViewBag.CBZX = CBZX;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-3).ToString("yyyy-MM");
            ViewBag.enddate = now.ToString("yyyy-MM");
            ViewBag.starttime = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.endtime = now.ToString("yyyy-MM-dd");

            // ViewBag.Current = now.ToString("yyyy-MM-dd");

            return View();
        }
        public ActionResult Update_SH_Travel()
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_FI[] CWBH = crmModels.COST_FI.ReadByParam(new CRM_COST_FI(), token);
            ViewBag.CWBH = CWBH;
            CRM_COST_CBZX[] CBZX = crmModels.COST_CBZX.ReadByParam(new CRM_COST_CBZX(), token);
            ViewBag.CBZX = CBZX;

            CRM_COST_ITEM model = new CRM_COST_ITEM();
            model.ISACTIVE = 1;
            model.COSTCLASS3 = 1439;
            CRM_COST_ITEM[] COSTITEMID = crmModels.COST_ITEM.ReadByParam(model, token);
            CRM_COST_ITEM[] COSTITEMMC = crmModels.COST_ITEM.ReadByParam(model, token);
            ViewBag.COSTITEMID = COSTITEMID;
            ViewBag.COSTITEMMC = COSTITEMMC;

            return View();
        }
        [HttpPost]
        public string BackOrder_CLFHX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFHX[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFHX[]>(cxdata);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_CLFHX model = new CRM_COST_CLFHX();
                model.CLFHXID = checkdata[i].CLFHXID;
                CRM_COST_CLFHX[] data = crmModels.COST_CLFHX.ReadByParam(model, token);
                data[0].ISACTIVE = 10;
                int m = crmModels.COST_CLFHX.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "修改失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "修改成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Submit_CLFTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT[]>(cxdata);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_CLFTT model = new CRM_COST_CLFTT();
                model.CLFTTID = checkdata[i].CLFTTID;
                CRM_COST_CLFTT[] data = crmModels.COST_CLFTT.ReadByAll(model, 0, token);
                data[0].ISACTIVE = 20;
                int m = crmModels.COST_CLFTT.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "提交失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "提交成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string OneCheck_CLFTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT[]>(cxdata);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_CLFTT model = new CRM_COST_CLFTT();
                model.CLFTTID = checkdata[i].CLFTTID;
                CRM_COST_CLFTT[] data = crmModels.COST_CLFTT.ReadByAll(model, 0, token);
                data[0].ISACTIVE = 30;
                int m = crmModels.COST_CLFTT.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "审核失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string TwoCheck_CLFTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT[]>(cxdata);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_CLFTT model = new CRM_COST_CLFTT();
                model.CLFTTID = checkdata[i].CLFTTID;
                CRM_COST_CLFTT[] data = crmModels.COST_CLFTT.ReadByAll(model, 0, token);
                data[0].ISACTIVE = 60;
                int m = crmModels.COST_CLFTT.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "审核失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Back_CLFTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT[]>(cxdata);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_CLFTT model = new CRM_COST_CLFTT();
                model.CLFTTID = checkdata[i].CLFTTID;
                CRM_COST_CLFTT[] data = crmModels.COST_CLFTT.ReadByAll(model, 0, token);
                data[0].ISACTIVE = 10;
                data[0].SHR = appClass.CRM_GetStaffid();
                int m = crmModels.COST_CLFTT.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "回退失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "回退成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string TwoBack_CLFTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT[]>(cxdata);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_CLFTT model = new CRM_COST_CLFTT();
                model.CLFTTID = checkdata[i].CLFTTID;
                CRM_COST_CLFTT[] data = crmModels.COST_CLFTT.ReadByAll(model, 0, token);
                data[0].ISACTIVE = 20;
                data[0].SHR = appClass.CRM_GetStaffid();
                int m = crmModels.COST_CLFTT.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "回退失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "回退成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string ChangeOrder_CLFHX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFHX[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFHX[]>(cxdata);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_CLFHX model = new CRM_COST_CLFHX();
                model.CLFHXID = checkdata[i].CLFHXID;
                CRM_COST_CLFHX[] data = crmModels.COST_CLFHX.ReadByParam(model, token);
                data[0].ISACTIVE = 20;
                int m = crmModels.COST_CLFHX.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "修改失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "修改成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Update_CLFHX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFHX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFHX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CLFHX.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Delete_CLFHX(int id)
        {
            token = appClass.CRM_Gettoken();


            //CRM_COST_CLFMX_CLFHX model = new CRM_COST_CLFMX_CLFHX();
            //model.CLFHXID = id;
            CRM_COST_CLFMX_CLFHX[] data = crmModels.COST_CLFMX_CLFHX.ReadByCLFHXID(id, token);
            for (int x = 0; x < data.Length; x++)
            {
                CRM_COST_CLFMX_CLFHX[] data2 = crmModels.COST_CLFMX_CLFHX.ReadByCLFMXID(data[x].CLFMXID, token);
                for (int j = 0; j < data2.Length; j++)
                {
                    crmModels.COST_CLFMX_CLFHX.DeleteByCLFHXID(data2[j].CLFHXID, token);
                    crmModels.COST_CLFHX.Delete(data2[j].CLFHXID, token);
                }

            }




            webmsg.KEY = 1;

            webmsg.MSG = "删除成功！";

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);

        }
        [HttpPost]
        public string Select_CLFHXById(int CLFHXID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFHX model = new CRM_COST_CLFHX();
            model.CLFHXID = CLFHXID;
            CRM_COST_CLFHX[] data = crmModels.COST_CLFHX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }
        [HttpPost]
        public string Select_CLFHX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFHX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFHX>(cxdata);
            CRM_COST_CLFHX[] data = crmModels.COST_CLFHX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Get_ClfmxInfo(string data)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_CLFTT xmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT>(data);
            CRM_COST_CLFTT[] xdata = crmModels.COST_CLFTT.ReadByParam(xmodel, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(xdata);
        }
        [HttpPost]
        public string Data_Insert_CLFHX(string data, int CLFMXID, int x)
        {
            token = appClass.CRM_Gettoken();


            CRM_COST_CLFMX[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFMX[]>(data);
            CRM_COST_CLFHX model = new CRM_COST_CLFHX();
            for (int i = 0; i < checkdata.Length; i++)
            {
                model.STAFFID = checkdata[i].STAFFID;
                //  model.HXJE = checkdata[i].HJ;
                model.FGLD = checkdata[i].FGLD;
                model.SF = checkdata[i].SF;
                model.CBZX = checkdata[i].CBZX;
                model.JT_JE = model.JT_JE + (checkdata[i].JT_PLANE + checkdata[i].JT_TRAIN + checkdata[i].JT_BUS);
                model.JT_JPJE = model.JT_JPJE + checkdata[i].JT_PLANE;
                model.JT_HCPJE = model.JT_HCPJE + checkdata[i].JT_TRAIN;
                model.JT_KCPJE = model.JT_KCPJE + checkdata[i].JT_BUS;

                model.ZS_DAYS = model.ZS_DAYS + checkdata[i].ZS_DAYS;
                model.ZS_JE = model.ZS_JE + checkdata[i].ZS_JE;
                model.BT_DAYS = model.BT_DAYS + checkdata[i].BT_DAYS;
                model.BT_JE = model.BT_JE + checkdata[i].BT_JE;
                model.QT_ITEM = checkdata[i].QT_ITEM;
                model.QT_JE = model.QT_JE + checkdata[i].QT_JE;
                model.BT_DAYS = model.BT_DAYS + checkdata[i].BT_DAYS;
                model.BT_DAYS = model.BT_DAYS + checkdata[i].BT_DAYS;
                model.BEIZ = checkdata[i].BEIZ;
            }
            model.JT_JPSL = 0;
            model.JT_JPWSJE = 0;
            model.JT_HCPSL = 0;
            model.JT_HCPWSJE = 0;
            model.JT_KCPSL = 0;
            model.JT_KCPWSJE = 0;
            model.JCJSF = 0;
            model.CWHSBH = "";
            model.HXJE = model.JT_JE + model.ZS_JE + model.BT_JE + model.QT_JE;
            model.BXFS = 0;
            model.PMJG = 0;
            model.PJ = 0;
            model.SL = 0;
            model.WSJE = 0;
            model.XSSJ = "";
            model.ISACTIVE = 10;
            model.CJR = appClass.CRM_GetStaffid();
            int m = crmModels.COST_CLFHX.Create(model, token);
            if (m > 0)
            {
                for (int i = 0; i < x; i++)
                {
                    CRM_COST_CLFMX_CLFHX nonnModel = new CRM_COST_CLFMX_CLFHX();
                    //  nonnModel.CLFMXID = CLFMXID;
                    nonnModel.CLFMXID = checkdata[i].CLFMXID;
                    nonnModel.CLFHXID = m;
                    int y = crmModels.COST_CLFMX_CLFHX.Create(nonnModel, token);

                    if (y < 0)
                    {
                        webmsg.KEY = y;
                        webmsg.MSG = "新增失败，检查勾选的值是否有误";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }
            }
            else
            {
                // webmsg.KEY = m;
                webmsg.MSG = "新增失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            webmsg.KEY = m;
            webmsg.MSG = "新增成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Sum_Info(string data)
        {
            CRM_COST_CLFMX[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFMX[]>(data);
            CRM_COST_CLFHX model = new CRM_COST_CLFHX();
            for (int i = 0; i < checkdata.Length; i++)
            {

                model.JT_JE = model.JT_JE + (checkdata[i].JT_PLANE + checkdata[i].JT_TRAIN + checkdata[i].JT_BUS);
                model.JT_JPJE = model.JT_JPJE + checkdata[i].JT_PLANE;
                model.JT_HCPJE = model.JT_HCPJE + checkdata[i].JT_TRAIN;
                model.JT_KCPJE = model.JT_KCPJE + checkdata[i].JT_BUS;

                model.ZS_DAYS = model.ZS_DAYS + checkdata[i].ZS_DAYS;
                model.ZS_JE = model.ZS_JE + checkdata[i].ZS_JE;
                model.BT_DAYS = model.BT_DAYS + checkdata[i].BT_DAYS;
                model.BT_JE = model.BT_JE + checkdata[i].BT_JE;
                model.QT_ITEM = checkdata[i].QT_ITEM;
                model.QT_JE = model.QT_JE + checkdata[i].QT_JE;
                // model.BT_DAYS = model.BT_DAYS + checkdata[i].BT_DAYS;
                //   model.BT_DAYS = model.BT_DAYS + checkdata[i].BT_DAYS;

            }
            model.JT_HCPJE2 = 0;
            model.JT_KCPJE2 = 0;
            model.ZS_DAYS2 = 0;
            model.ZS_JE2 = 0;
            model.BEIZ = checkdata[0].BEIZ;
            model.STAFFID = checkdata[0].STAFFID;
            model.FGLD = checkdata[0].FGLD;
            model.SF = checkdata[0].SF;
            model.CBZX = checkdata[0].CBZX;
            model.HXJE = model.JT_JE + model.ZS_JE + model.BT_JE + model.QT_JE;

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string Insert_CLFHX(string data, string CLFMXID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFMX[] CXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFMX[]>(CLFMXID);
            CRM_COST_CLFHX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFHX>(data);



            #region
            if (model.QT_ITEM == 0 || model.QT_ITEM == 15 || model.QT_ITEM == 16 || model.QT_ITEM == 17 || model.QT_ITEM == 18 || model.QT_ITEM == 19
                || model.QT_ITEM == 20)
            {
                model.CJR = appClass.CRM_GetStaffid();
                model.ISACTIVE = 10;
                int i = crmModels.COST_CLFHX.Create(model, token);

                if (i > 0)
                {
                    CRM_COST_CLFMX_CLFHX nonnModel = new CRM_COST_CLFMX_CLFHX();
                    for (int j = 0; j < CXmodel.Length; j++)
                    {
                        nonnModel.CLFMXID = CXmodel[j].CLFMXID;
                        nonnModel.CLFHXID = i;
                        int y = crmModels.COST_CLFMX_CLFHX.Create(nonnModel, token);

                        if (y < 0)
                        {
                            webmsg.KEY = y;
                            webmsg.MSG = "新增失败，检查勾选的值是否有误";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }

                }
                if (i > 0)
                {
                    webmsg.MSG = "新增成功";
                    webmsg.KEY = i;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                else
                {
                    webmsg.KEY = i;
                    webmsg.MSG = "新增失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            #endregion
            #region
            if (model.JT_JPJE == 0 && model.JT_HCPJE == 0 && model.JT_KCPJE == 0 && model.ZS_JE == 0 && model.BT_JE == 0 && model.QT_ITEM != 0)
            {
                model.CJR = appClass.CRM_GetStaffid();
                model.ISACTIVE = 10;
                int i = crmModels.COST_CLFHX.Create(model, token);

                if (i > 0)
                {
                    CRM_COST_CLFMX_CLFHX nonnModel = new CRM_COST_CLFMX_CLFHX();
                    for (int j = 0; j < CXmodel.Length; j++)
                    {
                        nonnModel.CLFMXID = CXmodel[j].CLFMXID;
                        nonnModel.CLFHXID = i;
                        int y = crmModels.COST_CLFMX_CLFHX.Create(nonnModel, token);

                        if (y < 0)
                        {
                            webmsg.KEY = y;
                            webmsg.MSG = "新增失败，检查勾选的值是否有误";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }

                }
                if (i > 0)
                {
                    webmsg.MSG = "新增成功";
                    webmsg.KEY = i;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                else
                {
                    webmsg.KEY = i;
                    webmsg.MSG = "新增失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            #endregion

            if (model.QT_ITEM != 0 && model.QT_ITEM != 15 && model.QT_ITEM != 16 && model.QT_ITEM != 17 && model.QT_ITEM != 18 && model.QT_ITEM != 19
                && model.QT_ITEM != 20)
            {
                CRM_COST_CLFHX List = new CRM_COST_CLFHX();

                List.STAFFID = model.STAFFID;
                List.FGLD = model.FGLD;
                List.SF = model.SF;
                List.CBZX = model.CBZX;
                List.CWHSBH = model.CWHSBH;
                List.BEIZ = model.BEIZ;
                List.JT_JE = model.JT_JE;
                List.ZS_DAYS = model.ZS_DAYS;
                List.ZS_JE = model.ZS_JE;
                List.BT_DAYS = model.BT_DAYS;
                List.BT_JE = model.BT_JE;
                List.GSNY = model.GSNY;
                List.BXFS = model.BXFS;
                List.PMJG = model.PMJG;
                List.PJ = model.PJ;
                List.SL = model.SL;

                List.XSSJ = model.XSSJ;
                List.HXJE = model.JT_JPJE + model.JT_HCPJE + model.JT_KCPJE + model.ZS_JE + model.BT_JE;
                List.WSJE = model.JT_JPWSJE + model.JT_HCPWSJE + model.JT_KCPWSJE + model.ZS_WSJE + model.BT_JE;

                List.JT_JPTZJE = model.JT_JPTZJE;
                List.JCJSF = model.JCJSF;
                List.JT_JPJE = model.JT_JPJE;
                List.JT_HCPJE = model.JT_HCPJE;
                List.JT_KCPJE = model.JT_KCPJE;
                List.JT_JPSL = model.JT_JPSL;
                List.JT_JPWSJE = model.JT_JPWSJE;
                List.JT_HCPSL = model.JT_HCPSL;
                List.JT_HCPWSJE = model.JT_HCPWSJE;
                List.JT_KCPSL = model.JT_KCPSL;
                List.JT_KCPWSJE = model.JT_KCPWSJE;
                List.ZS_SL = model.ZS_SL;
                List.ZS_WSJE = model.ZS_WSJE;
                List.ISACTIVE = 10;
                List.CJR = appClass.CRM_GetStaffid();
                int i = crmModels.COST_CLFHX.Create(List, token);

                if (i > 0)
                {


                    //nonnModel.CLFMXID = CXmodel[0].CLFMXID;
                    //nonnModel.CLFHXID = i;
                    //int y = crmModels.COST_CLFMX_CLFHX.Create(nonnModel, token);

                    CRM_COST_CLFMX_CLFHX nonnModel = new CRM_COST_CLFMX_CLFHX();
                    for (int j = 0; j < CXmodel.Length; j++)
                    {
                        nonnModel.CLFMXID = CXmodel[j].CLFMXID;
                        nonnModel.CLFHXID = i;
                        int y = crmModels.COST_CLFMX_CLFHX.Create(nonnModel, token);

                        if (y < 0)
                        {
                            webmsg.KEY = y;
                            webmsg.MSG = "新增失败，检查勾选的值是否有误";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }
                    //  string str = model.COSTITEMMC.Substring(1, 3);

                    CRM_COST_CLFHX List2 = new CRM_COST_CLFHX();
                    List2.STAFFID = model.STAFFID;
                    List2.FGLD = model.FGLD;
                    List2.SF = model.SF;
                    List2.CBZX = model.CBZX;
                    List2.CWHSBH = model.CWHSBH;
                    List2.BEIZ = model.BEIZ;
                    List2.JT_JE = 0;
                    List2.ZS_DAYS = 0;
                    List2.ZS_JE = 0;
                    List2.BT_DAYS = 0;
                    List2.BT_JE = 0;
                    List2.BXFS = 0;
                    List2.PMJG = 0;
                    List2.PJ = 0;
                    List2.SL = 0;
                    List2.JT_JPTZJE = 0;
                    List2.JCJSF = 0;
                    List2.JT_JPJE = 0;
                    List2.JT_HCPJE = 0;
                    List2.JT_KCPJE = 0;
                    List2.JT_JPSL = 0;
                    List2.JT_JPWSJE = 0;
                    List2.JT_HCPSL = 0;
                    List2.JT_HCPWSJE = 0;
                    List2.JT_KCPSL = 0;
                    List2.JT_KCPWSJE = 0;
                    List2.ZS_SL = 0;
                    List2.ZS_WSJE = 0;
                    List2.WSJE = model.QT_WSJE;
                    List2.HXJE = model.QT_JE;
                    List2.GSNY = model.GSNY;
                    List2.XSSJ = model.XSSJ;
                    List2.QT_ITEM = model.QT_ITEM;
                    List2.QT_JE = model.QT_JE;
                    List2.QT_SL = model.QT_SL;
                    List2.QT_WSJE = model.QT_WSJE;
                    List2.ISACTIVE = 10;
                    List2.CJR = appClass.CRM_GetStaffid();
                    int a = crmModels.COST_CLFHX.Create(List2, token);






                    if (a > 0)
                    {
                        CRM_COST_CLFHX XXMODEL = new CRM_COST_CLFHX();
                        XXMODEL.CLFHXID = a;
                        CRM_COST_CLFHX[] cxdata = crmModels.COST_CLFHX.ReadByParam(XXMODEL, token);
                        cxdata[0].CWHSBH = cxdata[0].COSTITEMMC.Substring(0, 3);
                        crmModels.COST_CLFHX.Update(cxdata[0], token);

                        CRM_COST_CLFMX_CLFHX nnModel = new CRM_COST_CLFMX_CLFHX();
                        nnModel.CLFMXID = CXmodel[0].CLFMXID;
                        nnModel.CLFHXID = a;
                        int z = crmModels.COST_CLFMX_CLFHX.Create(nnModel, token);
                        if (z < 0)
                        {
                            webmsg.KEY = z;
                            webmsg.MSG = "新增失败，检查数据是否有误";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }
                }

                webmsg.MSG = "新增成功";
                webmsg.KEY = i;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                webmsg.MSG = "新增失败";
                //  webmsg.KEY = i;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

        }


        [HttpPost]
        public string Post_Print_Clf(string data)
        {
            try
            {
                CRM_COST_CLFTT[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT[]>(data);
                Session["PRINTORDER"] = model;
                webmsg.KEY = 1;
                webmsg.MSG = "";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            catch (Exception e)
            {
                webmsg.KEY = 0;
                webmsg.MSG = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }
        public ActionResult Print_Clf()
        {
            token = appClass.CRM_Gettoken();

            if (Session["PRINTORDER"] != null)
            {
                CRM_COST_CLFTT[] data = (CRM_COST_CLFTT[])Session["PRINTORDER"];
                PrintClf[] PO = new PrintClf[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    PO[i] = new PrintClf();
                    PO[i].TTdata = data[i];


                    //CRM_HG_STAFF staffmodel = new CRM_HG_STAFF();
                    //staffmodel.STAFFNAME = 

                    CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(PO[i].TTdata.STAFFID, token);
                    PO[i].TTdata.STAFFNO = staffmodel.STAFFNO;


                    PO[i].TTdata.TOTAL_HJ = MoneyToChinese(PO[i].TTdata.JESUM.ToString());
                    PO[i].MXdata = crmModels.COST_CLFMX.ReadByTTID(data[i].CLFTTID, token);
                    for (int j = 0; j < PO[i].MXdata.Length; j++)
                    {

                        PO[i].TTdata.TOTAL_JT_PLANE = PO[i].MXdata[j].JT_PLANE + PO[i].TTdata.TOTAL_JT_PLANE;

                        PO[i].TTdata.TOTAL_JT_TRAIN = PO[i].MXdata[j].JT_TRAIN + PO[i].TTdata.TOTAL_JT_TRAIN;
                        PO[i].TTdata.TOTAL_JT_BUS = PO[i].MXdata[j].JT_BUS + PO[i].TTdata.TOTAL_JT_BUS;
                        PO[i].TTdata.TOTAL_JT_BILL = PO[i].MXdata[j].JT_BILL + PO[i].TTdata.TOTAL_JT_BILL;
                        PO[i].TTdata.TOTAL_ZS_DAYS = PO[i].MXdata[j].ZS_DAYS + PO[i].TTdata.TOTAL_ZS_DAYS;
                        PO[i].TTdata.TOTAL_ZS_JE = PO[i].MXdata[j].ZS_JE + PO[i].TTdata.TOTAL_ZS_JE;
                        PO[i].TTdata.TOTAL_ZS_BILL = PO[i].MXdata[j].ZS_BILL + PO[i].TTdata.TOTAL_ZS_BILL;
                        PO[i].TTdata.TOTAL_BT_DAYS = PO[i].MXdata[j].BT_DAYS + PO[i].TTdata.TOTAL_BT_DAYS;
                        PO[i].TTdata.TOTAL_BT_JE = PO[i].MXdata[j].BT_JE + PO[i].TTdata.TOTAL_BT_JE;
                        PO[i].TTdata.TOTAL_QT_JE = PO[i].MXdata[j].QT_JE + PO[i].TTdata.TOTAL_QT_JE;
                        PO[i].TTdata.TOTAL_QT_BILL = PO[i].MXdata[j].QT_BILL + PO[i].TTdata.TOTAL_QT_BILL;

                    }
                }

                ViewBag.data = PO;
            }
            else
            {
                PrintClf[] PO = new PrintClf[0];
                ViewBag.data = PO;
            }

            return View();
        }
        public string MoneyToChinese(string LowerMoney)
        {

            string functionReturnValue = null;

            bool IsNegative = false; // 是否是负数

            if (LowerMoney.Trim().Substring(0, 1) == "-")
            {

                // 是负数则先转为正数

                LowerMoney = LowerMoney.Trim().Remove(0, 1);

                IsNegative = true;

            }

            string strLower = null;

            string strUpart = null;

            string strUpper = null;

            int iTemp = 0;

            // 保留两位小数 123.489→123.49　　123.4→123.4

            LowerMoney = Math.Round(double.Parse(LowerMoney), 2, MidpointRounding.AwayFromZero).ToString();

            if (LowerMoney.IndexOf(".") > 0)
            {

                if (LowerMoney.IndexOf(".") == LowerMoney.Length - 2)
                {

                    LowerMoney = LowerMoney + "0";

                }

            }

            else
            {

                LowerMoney = LowerMoney + ".00";

            }

            strLower = LowerMoney;

            iTemp = 1;

            strUpper = "";

            while (iTemp <= strLower.Length)
            {

                switch (strLower.Substring(strLower.Length - iTemp, 1))
                {

                    case ".":

                        strUpart = "圆";

                        break;

                    case "0":

                        strUpart = "零";

                        break;

                    case "1":

                        strUpart = "壹";

                        break;

                    case "2":

                        strUpart = "贰";

                        break;

                    case "3":

                        strUpart = "叁";

                        break;

                    case "4":

                        strUpart = "肆";

                        break;

                    case "5":

                        strUpart = "伍";

                        break;

                    case "6":

                        strUpart = "陆";

                        break;

                    case "7":

                        strUpart = "柒";

                        break;

                    case "8":

                        strUpart = "捌";

                        break;

                    case "9":

                        strUpart = "玖";

                        break;

                }



                switch (iTemp)
                {

                    case 1:

                        strUpart = strUpart + "分";

                        break;

                    case 2:

                        strUpart = strUpart + "角";

                        break;

                    case 3:

                        strUpart = strUpart + "";

                        break;

                    case 4:

                        strUpart = strUpart + "";

                        break;

                    case 5:

                        strUpart = strUpart + "拾";

                        break;

                    case 6:

                        strUpart = strUpart + "佰";

                        break;

                    case 7:

                        strUpart = strUpart + "仟";

                        break;

                    case 8:

                        strUpart = strUpart + "万";

                        break;

                    case 9:

                        strUpart = strUpart + "拾";

                        break;

                    case 10:

                        strUpart = strUpart + "佰";

                        break;

                    case 11:

                        strUpart = strUpart + "仟";

                        break;

                    case 12:

                        strUpart = strUpart + "亿";

                        break;

                    case 13:

                        strUpart = strUpart + "拾";

                        break;

                    case 14:

                        strUpart = strUpart + "佰";

                        break;

                    case 15:

                        strUpart = strUpart + "仟";

                        break;

                    case 16:

                        strUpart = strUpart + "万";

                        break;

                    default:

                        strUpart = strUpart + "";

                        break;

                }



                strUpper = strUpart + strUpper;

                iTemp = iTemp + 1;

            }



            strUpper = strUpper.Replace("零拾", "零");

            strUpper = strUpper.Replace("零佰", "零");

            strUpper = strUpper.Replace("零仟", "零");

            strUpper = strUpper.Replace("零零零", "零");

            strUpper = strUpper.Replace("零零", "零");

            strUpper = strUpper.Replace("零角零分", "整");

            strUpper = strUpper.Replace("零分", "整");

            strUpper = strUpper.Replace("零角", "零");

            strUpper = strUpper.Replace("零亿零万零圆", "亿圆");

            strUpper = strUpper.Replace("亿零万零圆", "亿圆");

            strUpper = strUpper.Replace("零亿零万", "亿");

            strUpper = strUpper.Replace("零万零圆", "万圆");

            strUpper = strUpper.Replace("零亿", "亿");

            strUpper = strUpper.Replace("零万", "万");

            strUpper = strUpper.Replace("零圆", "圆");

            strUpper = strUpper.Replace("零零", "零");



            // 对壹圆以下的金额的处理

            if (strUpper.Substring(0, 1) == "圆")
            {

                strUpper = strUpper.Substring(1, strUpper.Length - 1);

            }

            if (strUpper.Substring(0, 1) == "零")
            {

                strUpper = strUpper.Substring(1, strUpper.Length - 1);

            }

            if (strUpper.Substring(0, 1) == "角")
            {

                strUpper = strUpper.Substring(1, strUpper.Length - 1);

            }

            if (strUpper.Substring(0, 1) == "分")
            {

                strUpper = strUpper.Substring(1, strUpper.Length - 1);

            }

            if (strUpper.Substring(0, 1) == "整")
            {

                strUpper = "零圆整";

            }

            functionReturnValue = strUpper;



            if (IsNegative == true)
            {

                return "负" + functionReturnValue;

            }

            else
            {

                return functionReturnValue;

            }

        }



        [HttpPost]
        public string Select_Travel(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT>(cxdata);
            CRM_COST_CLFTT[] data = crmModels.COST_CLFTT.ReadByAll(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Select_TravelByID(int CLFTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT model = new CRM_COST_CLFTT();
            model.CLFTTID = CLFTTID;
            CRM_COST_CLFTT[] data = crmModels.COST_CLFTT.ReadByAll(model, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }
        [HttpPost]
        public string Select_TravelByCLFTTID(int CLFTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT model = new CRM_COST_CLFTT();
            model.CLFTTID = CLFTTID;
            CRM_COST_CLFTT[] data = crmModels.COST_CLFTT.ReadByAll(model, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }
        [HttpPost]
        public string Insert_Travel(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT>(data);
            model.STAFFID = appClass.CRM_GetStaffid();
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;
            int i = crmModels.COST_CLFTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Delete_Travel(int CLFTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CLFTT.Delete(CLFTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Update_Travel(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CLFTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Update_CLFTT(string data)
        {
            token = appClass.CRM_Gettoken();
            //CRM_COST_CLFTT model = new CRM_COST_CLFTT();
            //model.CLFTTID = CLFTTID;
            //CRM_COST_CLFTT[] data = crmModels.COST_CLFTT.ReadByAll(model, token);
            CRM_COST_CLFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT>(data);

            model.XGR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 20;
            int i = crmModels.COST_CLFTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "保存并提交成功！";
            else
                webmsg.MSG = "保存并提交失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        public string Select_PartClfmx(int id)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFMX model = new CRM_COST_CLFMX();
            model.CLFTTID = id;
            CRM_COST_CLFMX[] data = crmModels.COST_CLFMX.ReadPart(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Select_Clfmx(int id)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFMX model = new CRM_COST_CLFMX();
            model.CLFTTID = id;
            CRM_COST_CLFMX[] data = crmModels.COST_CLFMX.ReadByParam(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Select_ClfmxByMXID(int id)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFMX model = new CRM_COST_CLFMX();
            model.CLFMXID = id;
            CRM_COST_CLFMX[] data = crmModels.COST_CLFMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);

        }
        [HttpPost]
        public string Insert_Clfmx(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFMX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_CLFMX.Create(model, token);

            CRM_COST_CLFTT NNMODEL = new CRM_COST_CLFTT();
            NNMODEL.CLFTTID = model.CLFTTID;
            CRM_COST_CLFTT[] newdata = crmModels.COST_CLFTT.ReadByAll(NNMODEL, 0, token);
            newdata[0].HJ = newdata[0].JESUM;
            crmModels.COST_CLFTT.Update(newdata[0], token);


            return i.ToString();
        }
        [HttpPost]
        public string Delete_Clfmx(int CLFMXID, int CLFTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CLFMX.Delete(CLFMXID, token);

            CRM_COST_CLFTT NNMODEL = new CRM_COST_CLFTT();
            NNMODEL.CLFTTID = CLFTTID;
            CRM_COST_CLFTT[] newdata = crmModels.COST_CLFTT.ReadByAll(NNMODEL, 0, token);
            newdata[0].HJ = newdata[0].JESUM;
            crmModels.COST_CLFTT.Update(newdata[0], token);

            return i.ToString();
        }
        [HttpPost]
        public string Update_Clfmx(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFMX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CLFMX.Update(model, token);

            CRM_COST_CLFTT NNMODEL = new CRM_COST_CLFTT();
            NNMODEL.CLFTTID = model.CLFTTID;
            CRM_COST_CLFTT[] newdata = crmModels.COST_CLFTT.ReadByAll(NNMODEL, 0, token);
            newdata[0].HJ = newdata[0].JESUM;
            crmModels.COST_CLFTT.Update(newdata[0], token);

            return i.ToString();
        }
        [HttpPost]
        public string GetData_CLFTT_STAFF()
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT_STAFF model = new CRM_COST_CLFTT_STAFF();
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            CRM_COST_CLFTT_STAFF[] data = crmModels.COST_CLFTT_STAFF.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string GetData_CLFTT_ALLSTAFF(int STAFFID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT_STAFF model = new CRM_COST_CLFTT_STAFF();
            model.STAFFID = STAFFID;
            CRM_COST_CLFTT_STAFF[] data = crmModels.COST_CLFTT_STAFF.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public ActionResult Select_FI()
        {
            Session["location"] = 510;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] CLASS1 = crmModels.HG_DICT.Read(76, 0, token);
            ViewBag.CLASS1 = CLASS1;
            return View();
        }

        public ActionResult Select_JXSCXHD()
        {
            Session["location"] = 511;
            return View();
        }

        public ActionResult Update_JXSCXHD()
        {
            return View();
        }

        public ActionResult Select_JXSRYZC()
        {
            Session["location"] = 512;
            return View();
        }

        public ActionResult Update_JXSRYZC()
        {
            return View();
        }

        public ActionResult Select_KAyear()
        {
            Session["location"] = 513;
            return View();
        }

        public ActionResult Update_KAyear(int KAYEARTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAYEARTT cxmodel = new CRM_COST_KAYEARTT();
            cxmodel.KAYEARTTID = KAYEARTTID;
            CRM_COST_KAYEARTT TTdata = crmModels.COST_KAYEARTT.ReadByParam(cxmodel, 0, token)[0];
            ViewBag.TTdata = TTdata;

            CRM_COST_ITEM cx_cost = new CRM_COST_ITEM();
            cx_cost.COSTCLASS2 = 1454;
            cx_cost.COSTCLASS3 = 1441;
            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(cx_cost, token);
            ViewBag.ITEM = ITEM;

            CRM_HG_DICT[] SL = crmModels.HG_DICT.Read(86, 0, token);
            ViewBag.SL = SL;

            return View();
        }

        public ActionResult Select_OutDisplay()
        {
            Session["location"] = 514;
            return View();
        }

        public ActionResult Select_KACXY()
        {
            Session["location"] = 515;
            return View();
        }
        public ActionResult Select_CXYGL()
        {
            Session["location"] = 544;
            return View();
        }
        public ActionResult Update_KACXY()
        {
            return View();
        }
        [HttpPost]
        public string Select_KACXYByCXYID(int CXYID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXY model = new CRM_COST_CXY();
            model.CXYID = CXYID;
            CRM_COST_CXY[] data = crmModels.COST_CXY.ReadByParam(model, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }
        [HttpPost]
        public string GetData_KACXY(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXY>(cxdata);
            CRM_COST_CXY[] data = crmModels.COST_CXY.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string GetData_KACXY2(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXY>(cxdata);
            CRM_COST_CXY[] data = crmModels.COST_CXY.ReadByGZ(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Insert_KACXY(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXY>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;
            int i = crmModels.COST_CXY.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Delete_KACXY(int CXYID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CXY.Delete(CXYID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Update_KACXY(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXY>(data);

            CRM_COST_CXY CXMODEL = new CRM_COST_CXY();
            CXMODEL.CXYID = model.CXYID;
            CRM_COST_CXY[] CXDATA = crmModels.COST_CXY.ReadByParam(CXMODEL, appClass.CRM_GetStaffid(), token);
            switch (CXDATA[0].ISACTIVE)
            {
                case 30:
                    model.ISACTIVE = 40;
                    break;
                case 40:
                    model.ISACTIVE = 60;
                    break;
                case 60:
                    model.ISACTIVE = 60;
                    break;
                default:
                    break;
            }
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CXY.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Select_KACXY(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXY>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CXY.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_KACXY(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXY[] CXYmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXY[]>(data);


            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(23, token)[0].CS.ToString();

            CRM_OA_KACXY list = new CRM_OA_KACXY();
            list.SQR = staffmodel.STAFFNO;
            list.SQRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            list.MDMC = CXYmodel[0].MC;
            list.MC = CXYmodel[0].PKHIDDES;

            list.KACXYMX = new CRM_OA_KACXYMX[CXYmodel.Length];

            for (int i = 0; i < CXYmodel.Length; i++)
            {
                list.KACXYMX[i] = new CRM_OA_KACXYMX();
                list.KACXYMX[i].SF = CXYmodel[i].SFDES;
                list.KACXYMX[i].CS = CXYmodel[i].CSDES;
                list.KACXYMX[i].FZR = CXYmodel[i].CJRDES;
                list.KACXYMX[i].XS1 = CXYmodel[i].LAST3.ToString();
                list.KACXYMX[i].XS2 = CXYmodel[i].LAST2.ToString();
                list.KACXYMX[i].XS3 = CXYmodel[i].LAST1.ToString();
                list.KACXYMX[i].XSZE = CXYmodel[i].XSZE.ToString();
                list.KACXYMX[i].SUPPORT = CXYmodel[i].ZYZC;
                list.KACXYMX[i].GW = CXYmodel[i].GWDES;
                list.KACXYMX[i].CHANGE = CXYmodel[i].ISCHANGE == 1 ? "是" : "否";
                list.KACXYMX[i].KHJS = CXYmodel[i].BASE.ToString();
                list.KACXYMX[i].YJXS = CXYmodel[i].YGXSE.ToString();
                list.KACXYMX[i].NAME = CXYmodel[i].NAME;
                switch (CXYmodel[i].SEX)
                {
                    case 1:
                        list.KACXYMX[i].SEX = "男";
                        break;
                    case 2:
                        list.KACXYMX[i].SEX = "女";
                        break;
                    default:
                        list.KACXYMX[i].SEX = "";
                        break;
                };
                list.KACXYMX[i].SFZ = CXYmodel[i].CODE;
                list.KACXYMX[i].TEL = CXYmodel[i].TEL;
                list.KACXYMX[i].SGRQ = CXYmodel[i].SGRQ;
                list.KACXYMX[i].BANK = CXYmodel[i].BANK;
                list.KACXYMX[i].BANKCARD = CXYmodel[i].CARDNUM;
                list.KACXYMX[i].QZCS = CXYmodel[i].QZCS;
                list.KACXYMX[i].BEIZ = CXYmodel[i].BEIZ;
            }



            List<CRM_OA_KACXY_IMG> all_img = new List<CRM_OA_KACXY_IMG>();
            List<CRM_OA_KACXY_OPINION> all_opinion = new List<CRM_OA_KACXY_OPINION>();
            for (int i = 0; i < CXYmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 2027;
                cx_opinion.OACSBH = CXYmodel[i].CXYID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_KACXY_OPINION temp = new CRM_OA_KACXY_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;

                    //temp.MS = CXYmodel[i].MC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(39, CXYmodel[i].CXYID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_KACXY_IMG temp = new CRM_OA_KACXY_IMG();
                    temp.IMGML = FJ[j].ML;
                    //temp.IMGMS = FJ[j].WJM.Replace(".jpg"," ");//CXYmodel[i].MC;
                    all_img.Add(temp);
                }



            }

            list.OPINION = all_opinion.ToArray();
            list.IMG = all_img.ToArray();



            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int j = 0; j < CXYmodel.Length; j++)
                {
                    CXYmodel[j].ISACTIVE = 20;
                    crmModels.COST_CXY.Update(CXYmodel[j], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = CXYmodel[j].CXYID;
                    model.OACSLB = 2027;
                    model.OAZT = 1;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Data_Submit_KACXY2(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXY CXYmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXY>(data);
            int x = crmModels.COST_CXY.Update(CXYmodel, token);
            if (x < 0)
            {
                MessageInfo infomation = new MessageInfo();

                infomation.Key = "0";
                infomation.Value = "保存并提交失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(infomation);
            }


            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(23, token)[0].CS.ToString();

            CRM_OA_KACXY list = new CRM_OA_KACXY();
            list.SQR = staffmodel.STAFFNO;
            list.SQRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            list.MDMC = CXYmodel.MC;
            list.MC = CXYmodel.PKHIDDES;

            list.KACXYMX = new CRM_OA_KACXYMX[1];


            list.KACXYMX[0] = new CRM_OA_KACXYMX();
            list.KACXYMX[0].SF = CXYmodel.SFDES;
            list.KACXYMX[0].CS = CXYmodel.CSDES;
            list.KACXYMX[0].FZR = CXYmodel.CJRDES;
            list.KACXYMX[0].XS1 = CXYmodel.LAST3.ToString();
            list.KACXYMX[0].XS2 = CXYmodel.LAST2.ToString();
            list.KACXYMX[0].XS3 = CXYmodel.LAST1.ToString();
            list.KACXYMX[0].XSZE = CXYmodel.XSZE.ToString();
            list.KACXYMX[0].SUPPORT = CXYmodel.ZYZC;
            list.KACXYMX[0].GW = crmModels.HG_DICT.ReadByDICID(CXYmodel.GW, token).DICNAME;
            list.KACXYMX[0].CHANGE = CXYmodel.ISCHANGE == 1 ? "是" : "否";
            list.KACXYMX[0].KHJS = CXYmodel.BASE.ToString();
            list.KACXYMX[0].YJXS = CXYmodel.YGXSE.ToString();
            list.KACXYMX[0].NAME = CXYmodel.NAME;
            switch (CXYmodel.SEX)
            {
                case 1:
                    list.KACXYMX[0].SEX = "男";
                    break;
                case 2:
                    list.KACXYMX[0].SEX = "女";
                    break;
                default:
                    list.KACXYMX[0].SEX = "";
                    break;
            };
            list.KACXYMX[0].SFZ = CXYmodel.CODE;
            list.KACXYMX[0].TEL = CXYmodel.TEL;
            list.KACXYMX[0].SGRQ = CXYmodel.SGRQ;
            list.KACXYMX[0].BANK = CXYmodel.BANK;
            list.KACXYMX[0].BANKCARD = CXYmodel.CARDNUM;
            list.KACXYMX[0].QZCS = CXYmodel.QZCS;
            list.KACXYMX[0].BEIZ = CXYmodel.BEIZ;




            List<CRM_OA_KACXY_IMG> all_img = new List<CRM_OA_KACXY_IMG>();
            List<CRM_OA_KACXY_OPINION> all_opinion = new List<CRM_OA_KACXY_OPINION>();

            CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
            cx_opinion.OACSLB = 2027;
            cx_opinion.OACSBH = CXYmodel.CXYID;
            CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
            for (int j = 0; j < opinion.Length; j++)
            {
                CRM_OA_KACXY_OPINION temp = new CRM_OA_KACXY_OPINION();
                temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;

                //temp.MS = CXYmodel[i].MC;
                all_opinion.Add(temp);
            }


            CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(39, CXYmodel.CXYID, token);
            for (int j = 0; j < FJ.Length; j++)
            {
                CRM_OA_KACXY_IMG temp = new CRM_OA_KACXY_IMG();
                temp.IMGML = FJ[j].ML;
                //temp.IMGMS = CXYmodel[i].MC;
                all_img.Add(temp);
            }





            list.OPINION = all_opinion.ToArray();
            list.IMG = all_img.ToArray();



            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {


                CXYmodel.ISACTIVE = 20;
                crmModels.COST_CXY.Update(CXYmodel, token);

                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = CXYmodel.CXYID;
                model.OACSLB = 2027;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }


        public ActionResult Select_KACXYGZ()
        {
            Session["location"] = 516;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] CXYHS = crmModels.HG_DICT.Read(97, 0, token);
            CRM_HG_DICT[] CXYGW = crmModels.HG_DICT.Read(95, 0, token);
            ViewBag.CXYHS = CXYHS;
            ViewBag.CXYGW = CXYGW;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM");
            ViewBag.enddate = now.ToString("yyyy-MM");
            return View();
        }
        public ActionResult Update_KACXYGZ()
        {
            return View();
        }

        [HttpPost]
        public string Insert_ALL_KACXYGZ_Part(string cxdata, string CXYYEAR, string CXYMONTH)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_CXY cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXY>(cxdata);
            cxmodel.SALARY_YEAR = CXYYEAR;
            cxmodel.SALARY_MONTH = CXYMONTH;
            //查询出未发工资的促销员
            CRM_COST_CXY[] newdata = crmModels.COST_CXY.ReadByGZ(cxmodel, token);

            //验证促销员工资是否存在
            CRM_COST_CXYGZ GzModel = new CRM_COST_CXYGZ();
            GzModel.TIME_BEGIN = CXYYEAR + "-" + CXYMONTH;
            GzModel.TIME_END = CXYYEAR + "-" + CXYMONTH;
            CRM_COST_CXYGZ[] GzData = crmModels.COST_CXYGZ.ReadByParam(GzModel, token);
            for (int i = 0; i < newdata.Length; i++)
            {
                var ResList = (from c in GzData where c.CXYID == newdata[i].CXYID select c).ToList();

                if (ResList.Count > 0)
                {
                    webmsg.MSG = "当前促销员本年度本月工资已存在";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            for (int i = 0; i < newdata.Length; i++)
            {
                double temp_hjxh = 0;
                CRM_COST_KAXS model = new CRM_COST_KAXS();
                model.KHID = newdata[i].KHID;
                model.XSLX = 1461;
                model.SJLX = 1462;
                model.KAYEAR = CXYYEAR;
                model.KAMONTH = CXYMONTH;
                CRM_COST_KAXS[] data = crmModels.COST_KAXS.ReadByParam(model, token);
                //获取促销员对应KHID的当前年月销售金额
                for (int j = 0; j < data.Length; j++)
                {
                    temp_hjxh = temp_hjxh + (data[j].JXXS + data[j].TXXS);  //计算当前业务员对应门店的月销售额
                }
                //促销员提成核算方式
                CRM_HG_DICT[] CXYHS = crmModels.HG_DICT.Read(94, 0, token);

                //兼职，退休返聘促销员核算系数
                CRM_HG_DICT[] CxyCoefficient = crmModels.HG_DICT.Read(130, 0, token);

                CRM_COST_CXYGZ GZModel = new CRM_COST_CXYGZ();
                //全职，全职外包
                if (newdata[i].GW == 2008 || newdata[i].GW == 2009)
                {
                    if ((temp_hjxh - newdata[i].BASE) < Convert.ToDouble(CXYHS[0].DICNAME))
                    {
                        // TCJE  提成金额
                        GZModel.TCJE = (temp_hjxh - newdata[i].BASE) * (Convert.ToDouble(CXYHS[1].DICNAME));
                    }
                    else if ((temp_hjxh - newdata[i].BASE) > Convert.ToDouble(CXYHS[0].DICNAME))
                    {
                        GZModel.TCJE = (temp_hjxh - newdata[i].BASE) * Convert.ToDouble(CXYHS[2].DICNAME);
                    }
                    else
                    {
                        GZModel.TCJE = 0;
                    }
                }
                //兼职，退休返聘
                else if (newdata[i].GW == 2010 || newdata[i].GW == 2011)
                {

                    string str = (from c in CxyCoefficient where newdata[i].COEFFICIENT == c.DICID select c.DICNAME).FirstOrDefault().ToString();

                    var test = Convert.ToInt32(str.Split('%')[0]);

                    Double strA = Convert.ToInt32(str.Split('%')[0]) * 0.01;

                    if ((temp_hjxh - newdata[i].BASE) > 0)
                    {
                        GZModel.TCJE = (temp_hjxh - newdata[i].BASE) * strA;
                    }
                    else
                    {
                        GZModel.TCJE = 0;
                    }
                }
                else
                {
                    GZModel.TCJE = 0;
                }
                //未达到最低考核基数，提成金额为0，不能是负数
                if (GZModel.TCJE < 0)
                {
                    GZModel.TCJE = 0;
                }

                GZModel.CXYXHJE = temp_hjxh;
                GZModel.YFHJ = 0;          //newdata[i].BASE + GZModel.TCJE;
                GZModel.THCBKJ = 0;
                GZModel.CXYMONTH = CXYMONTH;
                GZModel.CXYYEAR = CXYYEAR;
                GZModel.CXYID = newdata[i].CXYID;
                GZModel.SBKC = 0;
                GZModel.SFGZ = 0;          //GZModel.YFHJ - GZModel.SBKC;
                GZModel.CJR = appClass.CRM_GetStaffid();
                GZModel.BEIZ = "";
                GZModel.ISACTIVE = 1;
                GZModel.OTHERFEE = 0;
                int m = crmModels.COST_CXYGZ.Create(GZModel, token);

                if (m < 0)
                {
                    webmsg.MSG = "新增失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }

            }
            webmsg.KEY = 1;
            webmsg.MSG = "新增成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string GetData_KACXYGZByKHID(int KHID)
        {
            token = appClass.CRM_Gettoken();

            //DateTime now = DateTime.Now;
            //CXYMONTH = now.ToString("yyyy-MM");


            CRM_COST_KAXS model = new CRM_COST_KAXS();
            model.KHID = KHID;
            model.XSLX = 1461;
            model.SJLX = 1462;
            CRM_COST_KAXS[] data = crmModels.COST_KAXS.ReadByParam(model, token);

            CRM_COST_CXY model1 = new CRM_COST_CXY();
            model1.KHID = KHID;
            CRM_COST_CXY[] data1 = crmModels.COST_CXY.ReadByParam(model1, 0, token);

            CRM_HG_DICT[] CXY = crmModels.HG_DICT.Read(95, 0, token);

            CRM_HG_DICT[] CXYHS = crmModels.HG_DICT.Read(94, 0, token);

            CRM_COST_CXYGZ model2 = new CRM_COST_CXYGZ();

            if (CXY[0].DICID == 2008 || CXY[0].DICID == 2009)
            {
                if ((data[0].HJXS - data1[0].BASE) < Convert.ToDouble(CXYHS[0].DICNAME))
                {
                    model2.TCJE = (data[0].HJXS - data1[0].BASE) * (Convert.ToDouble(CXYHS[1].DICNAME));
                }
                else if ((data[0].HJXS - data1[0].BASE) > Convert.ToDouble(CXYHS[0].DICNAME))
                {
                    model2.TCJE = (data[0].HJXS - data1[0].BASE) * Convert.ToDouble(CXYHS[2].DICNAME);
                }
                else
                {
                    model2.TCJE = 0;
                }
            }
            else if (CXY[0].DICID == 2010 || CXY[0].DICID == 2011)
            {
                if (data[0].HJXS - data1[0].BASE > 0)
                {
                    model2.TCJE = (data[0].HJXS - data1[0].BASE) * Convert.ToDouble(CXYHS[3].DICNAME);
                }
                else
                {
                    model2.TCJE = 0;
                }
            }
            else
            {
                model2.TCJE = 0;
            }
            model2.XHJE = data[0].HJXS;
            return Newtonsoft.Json.JsonConvert.SerializeObject(model2);

        }
        [HttpPost]
        public string Insert_KACXYGZ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXYGZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXYGZ>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;
            int i = crmModels.COST_CXYGZ.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Delete_KACXYGZ(int CXYGZID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CXYGZ.Delete(CXYGZID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Update_KACXYGZ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXYGZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXYGZ>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CXYGZ.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Select_KACXYGZ(string newdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXYGZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXYGZ>(newdata);
            //  model.ISACTIVE = 1;
            CRM_COST_CXYGZ[] data = crmModels.COST_CXYGZ.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Select_KACXYGZByName(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXY model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXY>(cxdata);
            CRM_COST_CXY[] data = crmModels.COST_CXY.ReadByParam(model, 0, token);

            CRM_COST_CXYGZ newmodel = new CRM_COST_CXYGZ();
            newmodel.CXYID = data[0].CXYID;
            CRM_COST_CXYGZ[] newdata = crmModels.COST_CXYGZ.ReadByParam(newmodel, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(newdata);
        }
        [HttpPost]
        public string Select_KACXYByCXYGZID(int CXYGZID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXYGZ model = new CRM_COST_CXYGZ();
            model.CXYGZID = CXYGZID;
            CRM_COST_CXYGZ[] data = crmModels.COST_CXYGZ.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }

        [HttpPost]
        public string Post_Print_CXYGZ(string data)
        {
            try
            {
                CRM_COST_CXYGZ[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXYGZ[]>(data);
                Session["PRINTCXYGZ"] = model;
                webmsg.KEY = 1;
                webmsg.MSG = "";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            catch (Exception e)
            {
                webmsg.KEY = 0;
                webmsg.MSG = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }

        public ActionResult PRINT_CXYGZ(int Add, int format)
        {
            token = appClass.CRM_Gettoken();

            if (Session["PRINTCXYGZ"] != null)
            {
                CRM_COST_CXYGZ[] CXYGZdata = (CRM_COST_CXYGZ[])Session["PRINTCXYGZ"];




                string str = CXYGZdata[0].CXYGZID.ToString();
                double HJ = CXYGZdata[0].YFHJ;
                crmModels.COST_CXYGZ.AddPrintCount(CXYGZdata[0].CXYGZID, token);
                for (int i = 1; i < CXYGZdata.Length; i++)
                {
                    str = str + "," + CXYGZdata[i].CXYGZID.ToString();
                    HJ = HJ + CXYGZdata[i].YFHJ;
                    crmModels.COST_CXYGZ.AddPrintCount(CXYGZdata[i].CXYGZID, token);
                }

                CRM_COST_CXYGZ cx_print = new CRM_COST_CXYGZ();
                cx_print.CXYGZIDSTR = str;
                CRM_COST_CXYGZ[] data = crmModels.COST_CXYGZ.ReadByParam(cx_print, token);
                ViewBag.data = data;

                ViewBag.FORMAT = format;
                ViewBag.HJ = HJ;

            }
            else
            {
                CRM_COST_CXYGZ[] data = new CRM_COST_CXYGZ[0];
                ViewBag.data = data;
            }

            return View();
        }

        public ActionResult Select_KHTS()
        {
            Session["location"] = 517;
            return View();
        }

        public ActionResult Update_KHTS()
        {
            return View();
        }
        public ActionResult Select_KHTSSH()
        {
            Session["location"] = 539;
            return View();
        }

        public ActionResult Select_KHTSSP()
        {
            Session["location"] = 540;
            return View();
        }
        public ActionResult Update_KHTSSH()
        {
            return View();
        }
        [HttpPost]
        public string SubmitOrder_KHTSSH(string TSID)  //更改isactive状态
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TS[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_TS[]>(TSID);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_TS model = new CRM_COST_TS();
                model.TSID = checkdata[i].TSID;
                CRM_COST_TS[] data = crmModels.COST_TS.ReadByParam(model, 0, token);
                data[0].ISACTIVE = 30;
                int m = crmModels.COST_TS.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "审核失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }

            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);


        }
        //[HttpPost]
        //public string GetData_KHTSSH(string cxdata)
        //{
        //    token = appClass.CRM_Gettoken();
        //    CRM_COST_TS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_TS>(cxdata);
        //    model.ISACTIVE = 30;
        //    CRM_COST_TS[] data = crmModels.COST_TS.ReadByParam(model, 0, token);
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        //}
        //[HttpPost]
        //public string GetData_KHTSSP(string cxdata)
        //{
        //    token = appClass.CRM_Gettoken();
        //    CRM_COST_TS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_TS>(cxdata);
        //    model.ISACTIVE = 40;
        //    CRM_COST_TS[] data = crmModels.COST_TS.ReadByParam(model, 0, token);
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        //}
        public ActionResult Select_NKAXS()
        {
            Session["location"] = 522;

            return View();
        }

        public ActionResult Report_NKAXS()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 523;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.ToString("yyyy");

            ViewBag.date = now.ToString("yyyy-MM");

            CRM_HG_DICT[] SJLX = crmModels.HG_DICT.Read(88, 0, token);
            CRM_HG_DICT[] XSLX = crmModels.HG_DICT.Read(87, 0, token);
            ViewBag.SJLX = SJLX;
            ViewBag.XSLX = XSLX;


            return View();
        }
        [HttpPost]
        public string Report_NKAXS(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS>(cxdata);
            CRM_COST_KAXS[] data = crmModels.COST_KAXS.Report(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Report_NKAXS_KP(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXSReportKP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXSReportKP>(cxdata);
            CRM_COST_KAXSReportKP[] data = crmModels.COST_KAXS.Report_KP(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Report_NKAXS_FH(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXSReportFH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXSReportFH>(cxdata);
            CRM_COST_KAXSReportFH[] data = crmModels.COST_KAXS.Report_FH(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Report_NKAXS_MX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXSReportMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXSReportMX>(cxdata);
            CRM_COST_KAXSReportMX[] data = crmModels.COST_KAXS.Report_MX(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Report_NKAXS_MXFH(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXS_Report_MXFH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS_Report_MXFH>(cxdata);
            CRM_COST_KAXS_Report_MXFH[] data = crmModels.COST_KAXS.Report_MXFH(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Report_NKAXS_MXKP(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXS_Report_MXFH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS_Report_MXFH>(cxdata);
            CRM_COST_KAXS_Report_MXFH[] data = crmModels.COST_KAXS.Report_MXFH(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        public ActionResult Select_KAXS()
        {
            Session["location"] = 524;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-3).ToString("yyyy-MM");
            ViewBag.enddate = now.ToString("yyyy-MM");
            return View();
        }
        public ActionResult Update_KAXS()
        {
            return View();
        }

        public ActionResult Select_PSF()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 527;

            CRM_HG_DICT[] PSFTYPE = crmModels.HG_DICT.Read(99, 0, token);
            ViewBag.PSFTYPE = PSFTYPE;

            CRM_HG_DICT[] PSFBL = crmModels.HG_DICT.Read(100, 0, token);
            ViewBag.PSFBL = PSFBL;

            CRM_HG_DICT[] SF = crmModels.HG_DICT.Read(1, 0, token);
            ViewBag.SF = SF;

            return View();
        }

        [HttpPost]
        public string Post_Print_PSF(string data)
        {
            try
            {
                CRM_COST_PSF[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_PSF[]>(data);
                Session["PRINTPSF"] = model;
                webmsg.KEY = 1;
                webmsg.MSG = "";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            catch (Exception e)
            {
                webmsg.KEY = 0;
                webmsg.MSG = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }

        public ActionResult PRINT_PSF(int Add)
        {
            token = appClass.CRM_Gettoken();

            if (Session["PRINTPSF"] != null)
            {
                CRM_COST_PSF[] PSFdata = (CRM_COST_PSF[])Session["PRINTPSF"];




                string str = PSFdata[0].PSFID.ToString();
                crmModels.COST_PSF.AddPrintCount(PSFdata[0].PSFID, token);
                for (int i = 1; i < PSFdata.Length; i++)
                {
                    str = str + "," + PSFdata[i].PSFID.ToString();
                    crmModels.COST_PSF.AddPrintCount(PSFdata[i].PSFID, token);
                }



                CRM_COST_PSF cx_print = new CRM_COST_PSF();
                cx_print.PSFIDSTR = str;
                if (PSFdata[0].PSFTYPE == 2030)
                {
                    cx_print.GSYEAR = PSFdata[0].GSYEAR;
                    cx_print.GSMONTH = PSFdata[0].GSMONTH;
                    CRM_COST_PSF[] data = crmModels.COST_PSF.ReportWLGS(cx_print, token);
                    ViewBag.data = data;
                }
                else if (PSFdata[0].PSFTYPE == 2031)
                {
                    cx_print.SEASON = PSFdata[0].SEASON;
                    CRM_COST_PSF[] data = crmModels.COST_PSF.ReportJXS(cx_print, token);
                    ViewBag.data = data;
                }
                else
                {
                    CRM_COST_PSF[] data = new CRM_COST_PSF[0];
                    ViewBag.data = data;
                }

            }
            else
            {
                CRM_COST_PSF[] data = new CRM_COST_PSF[0];
                ViewBag.data = data;
            }

            return View();
        }

        public ActionResult Select_Other()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 528;
            CRM_HG_DICT[] KHLX = crmModels.HG_DICT.Read(32, 0, token);
            ViewBag.KHLX = KHLX;

            CRM_HG_DICT[] CXYFYLX = crmModels.HG_DICT.Read(102, 0, token);
            ViewBag.CXYFYLX = CXYFYLX;

            CRM_HG_DICT[] OTHER_FYLB = crmModels.HG_DICT.Read(132, 0, token);
            ViewBag.OTHER_FYLB = OTHER_FYLB;
            return View();
        }

        public ActionResult Select_KADT()
        {
            Session["location"] = 529;
            return View();
        }

        public ActionResult Select_KADT_HX()
        {
            Session["location"] = 560;
            return View();
        }

        public ActionResult Update_KADT(int KADTTTID)
        {
            token = appClass.CRM_Gettoken();

            crmModels.COST_KADTTT.UpdateCost(KADTTTID, token);


            CRM_COST_KADTTT cxmodel = new CRM_COST_KADTTT();
            cxmodel.KADTTTID = KADTTTID;
            CRM_COST_KADTTT TTdata = crmModels.COST_KADTTT.ReadByParam(cxmodel, 0, token)[0];
            ViewBag.TTdata = TTdata;

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;

            CRM_HG_DICT[] CXLX = crmModels.HG_DICT.Read(73, 0, token);
            ViewBag.CXLX = CXLX;


            return View();
        }

        public ActionResult Update_KADT_HX(int KADTTTID)
        {
            token = appClass.CRM_Gettoken();

            crmModels.COST_KADTTT.UpdateCost(KADTTTID, token);


            CRM_COST_KADTTT cxmodel = new CRM_COST_KADTTT();
            cxmodel.KADTTTID = KADTTTID;
            CRM_COST_KADTTT TTdata = crmModels.COST_KADTTT.ReadByParam(cxmodel, 0, token)[0];
            ViewBag.TTdata = TTdata;

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;

            CRM_HG_DICT[] CXLX = crmModels.HG_DICT.Read(73, 0, token);
            ViewBag.CXLX = CXLX;


            return View();
        }

        public ActionResult Select_KATSCL()
        {
            Session["location"] = 530;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-3).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Select_KATSCL_HX()
        {
            Session["location"] = 561;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-3).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Update_KATSCL(int KATSCLTTID)
        {
            token = appClass.CRM_Gettoken();
            crmModels.COST_KATSCLTT.UpdateCost(KATSCLTTID, token);

            CRM_COST_KATSCLTT cxmodel = new CRM_COST_KATSCLTT();
            cxmodel.KATSCLTTID = KATSCLTTID;
            CRM_COST_KATSCLTT[] data = crmModels.COST_KATSCLTT.ReadByParam(cxmodel, 0, token);
            ViewBag.TTdata = data[0];

            CRM_HG_DICT[] DISPLAY = crmModels.HG_DICT.Read(9, 0, token);
            ViewBag.DISPLAY = DISPLAY;

            return View();
        }

        public ActionResult Update_KATSCL_HX(int KATSCLTTID)
        {
            token = appClass.CRM_Gettoken();
            crmModels.COST_KATSCLTT.UpdateCost(KATSCLTTID, token);

            CRM_COST_KATSCLTT cxmodel = new CRM_COST_KATSCLTT();
            cxmodel.KATSCLTTID = KATSCLTTID;
            CRM_COST_KATSCLTT[] data = crmModels.COST_KATSCLTT.ReadByParam(cxmodel, 0, token);
            ViewBag.TTdata = data[0];

            CRM_HG_DICT[] DISPLAY = crmModels.HG_DICT.Read(9, 0, token);
            ViewBag.DISPLAY = DISPLAY;

            return View();
        }

        public ActionResult Select_MDBS()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 531;
            CRM_HG_DICT[] PAYWAY = crmModels.HG_DICT.Read(93, 0, token);
            CRM_HG_DICT[] CXY = crmModels.HG_DICT.Read(111, 0, token);
            ViewBag.PAYWAY = PAYWAY;
            ViewBag.CXY = CXY;
            return View();
        }

        public ActionResult Select_MDBS_HX()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 534;
            CRM_HG_DICT[] PAYWAY = crmModels.HG_DICT.Read(93, 0, token);
            CRM_HG_DICT[] CXY = crmModels.HG_DICT.Read(111, 0, token);
            ViewBag.PAYWAY = PAYWAY;
            ViewBag.CXY = CXY;
            return View();
        }
        public ActionResult Select_JXSHXDJ()
        {
            Session["location"] = 535;

            return View();
        }
        [HttpPost]
        public string Data_Select_JSXHXZZF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(cxdata);
            model.ISACTIVE = 60;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByCostitemid(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Select_JXS_LKAFYTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYTT>(cxdata);
            int staffid = appClass.CRM_GetStaffid();
            CRM_COST_LKAFYTT[] data = crmModels.COST_LKAFYTT.ReadByParam(model, staffid, token);
            if (data.Length > 0)
            {
                CRM_COST_ZZFTT test = new CRM_COST_ZZFTT();
                test.LKAFYTTID = data[0].LKAFYTTID;
                test.TT_KHID = model.LKAID;
                test.COSTITEMID = Convert.ToInt32(model.COSTITEMID);
                test.TT_HTYEAR = model.HTYEAR;
                CRM_COST_ZZFTT[] branch = crmModels.COST_ZZFTT.ReadByTSCLF(test, token);

                return Newtonsoft.Json.JsonConvert.SerializeObject(branch);
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }


        }

        public ActionResult Update_JXSHXDJ(int HXDJTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_JXSHXDJTT cxmodel = new CRM_COST_JXSHXDJTT();
            cxmodel.HXDJTTID = HXDJTTID;
            CRM_COST_JXSHXDJTT[] TTdata = crmModels.COST_JXSHXDJTT.ReadByParam(cxmodel, 0, token);
            ViewBag.TTdata = TTdata[0];

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;

            CRM_COST_FI[] CWBH = crmModels.COST_FI.ReadByParam(new CRM_COST_FI(), token);
            ViewBag.CWBH = CWBH;

            CRM_COST_CBZX[] CBZX = crmModels.COST_CBZX.ReadByParam(new CRM_COST_CBZX(), token);
            ViewBag.CBZX = CBZX;

            CRM_HG_DICT[] SL = crmModels.HG_DICT.Read(86, 0, token);
            ViewBag.SL = SL;

            CRM_HG_DICT[] FYHXXS = crmModels.HG_DICT.Read(71, 0, token);
            ViewBag.FYHXXS = FYHXXS;
            return View();

        }
        [HttpPost]
        public string Data_Select_JSXHXZLMX_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX>(cxdata);
            CRM_COST_LKAHXZLMX[] data = crmModels.COST_LKAHXZLMX.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string GetData_JXSHXDJ(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_JXSHXDJTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_JXSHXDJTT>(cxdata);
            CRM_COST_JXSHXDJTT[] data = crmModels.COST_JXSHXDJTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);

        }
        [HttpPost]
        public string Select_JXSHXDJByID(int HXDJTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_JXSHXDJTT model = new CRM_COST_JXSHXDJTT();
            model.HXDJTTID = HXDJTTID;
            CRM_COST_JXSHXDJTT[] data = crmModels.COST_JXSHXDJTT.ReadByParam(model, 0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public string Insert_JXSHXDJ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_JXSHXDJTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_JXSHXDJTT>(data);
            CRM_COST_JXSHXDJTT cxmodel = new CRM_COST_JXSHXDJTT();
            cxmodel.KHID = model.KHID;
            cxmodel.HTYEAR = model.HTYEAR;
            CRM_COST_JXSHXDJTT[] cxdata = crmModels.COST_JXSHXDJTT.ReadByParam(cxmodel, 0, token);
            if (cxdata.Length > 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "客户在" + cxdata[0].HTYEAR + "合同年份已存在数据，不允许新增";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_JXSHXDJTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Delete_JXSHXDJ(int HXDJTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_JXSHXDJMX model = new CRM_COST_JXSHXDJMX();
            model.HXDJTTID = HXDJTTID;
            CRM_COST_JXSHXDJMX[] MXdata = crmModels.COST_JXSHXDJMX.ReadByParam(model, token);
            if (MXdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "存在明细数据，请先删除！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            int i = crmModels.COST_JXSHXDJTT.Delete(HXDJTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Update_JXSHXDJ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_JXSHXDJTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_JXSHXDJTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_JXSHXDJTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        public ActionResult Select_KAHXZL()
        {

            Session["location"] = 532;
            return View();
        }

        public ActionResult Update_KAHXZL(int HXZLTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLTT cxmodel = new CRM_COST_KAHXZLTT();
            cxmodel.HXZLTTID = HXZLTTID;
            CRM_COST_KAHXZLTT TTdata = crmModels.COST_KAHXZLTT.ReadByParam(cxmodel, 0, token)[0];
            ViewBag.TTdata = TTdata;

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;
            return View();
        }

        public ActionResult Select_SH_KAHXZL()
        {
            Session["location"] = 536;
            return View();
        }

        public ActionResult Update_SH_KAHXZL(int HXZLTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLTT cxmodel = new CRM_COST_KAHXZLTT();
            cxmodel.HXZLTTID = HXZLTTID;
            CRM_COST_KAHXZLTT TTdata = crmModels.COST_KAHXZLTT.ReadByParam(cxmodel, 0, token)[0];
            ViewBag.TTdata = TTdata;

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;
            return View();
        }

        public ActionResult Select_KAHXDJ()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 533;

            CRM_HG_DICT[] FYHXXS = crmModels.HG_DICT.Read(71, 0, token);
            ViewBag.FYHXXS = FYHXXS;


            return View();
        }

        public ActionResult Update_KAHXDJ(int HXDJTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXDJTT cxmodel = new CRM_COST_KAHXDJTT();
            cxmodel.HXDJTTID = HXDJTTID;
            CRM_COST_KAHXDJTT TTdata = crmModels.COST_KAHXDJTT.ReadByParam(cxmodel, 0, token)[0];
            ViewBag.TTdata = TTdata;

            CRM_COST_ITEM cxITEM = new CRM_COST_ITEM();
            cxITEM.COSTCLASS3 = 1441;
            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(cxITEM, token);
            ViewBag.ITEM = ITEM;

            CRM_COST_FI[] CWBH = crmModels.COST_FI.ReadByParam(new CRM_COST_FI(), token);
            ViewBag.CWBH = CWBH;

            CRM_COST_CBZX[] CBZX = crmModels.COST_CBZX.ReadByParam(new CRM_COST_CBZX(), token);
            ViewBag.CBZX = CBZX;

            CRM_HG_DICT[] SL = crmModels.HG_DICT.Read(86, 0, token);
            ViewBag.SL = SL;

            CRM_HG_DICT[] FYHXXS = crmModels.HG_DICT.Read(71, 0, token);
            ViewBag.FYHXXS = FYHXXS;

            CRM_HG_DICT[] PRINTKH = crmModels.HG_DICT.Read(98, 0, token);
            ViewBag.PRINTKH = PRINTKH;

            CRM_KH_GROUPList cx_group = new CRM_KH_GROUPList();
            cx_group.GMEMO = "KA分组二级";
            CRM_KH_GROUPList[] GROUP = crmModels.KH_GROUP.ReadByParam(cx_group, token);
            ViewBag.GROUP = GROUP;

            ViewBag.KouJian = crmModels.HG_DICT.ReadByDICID(4187, token);


            return View();
        }

        public ActionResult DaoRu_LKAYEAR()
        {
            return View();
        }

        public ActionResult Select_PRINT_KAHX()
        {
            Session["location"] = 538;
            token = appClass.CRM_Gettoken();
            CRM_COST_ITEM cx_item = new CRM_COST_ITEM();
            cx_item.COSTCLASS3 = 1441;
            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(cx_item, token);
            CRM_HG_DICT[] CXYFYLX = crmModels.HG_DICT.Read(102, 0, token);
            ViewBag.ITEM = ITEM;
            ViewBag.CXYFYLX = CXYFYLX;
            return View();
        }

        [HttpPost]
        public string Post_Print_KAHX(string data)
        {
            try
            {
                CRM_COST_KAHXDJMX[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXDJMX[]>(data);
                Session["PRINTKAHX"] = model;
                webmsg.KEY = 1;
                webmsg.MSG = "";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            catch (Exception e)
            {
                webmsg.KEY = 0;
                webmsg.MSG = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }

        public ActionResult PRINT_KAHX(int Add)
        {
            token = appClass.CRM_Gettoken();

            if (Session["PRINTKAHX"] != null)
            {
                CRM_COST_KAHXDJMX[] data = (CRM_COST_KAHXDJMX[])Session["PRINTKAHX"];
                PrintKAHX KAHX = new PrintKAHX();



                string str = data[0].HXDJMXID.ToString();
                crmModels.COST_KAHXDJMX.AddPrintCount(data[0].HXDJMXID, token);
                for (int i = 1; i < data.Length; i++)
                {
                    str = str + "," + data[i].HXDJMXID.ToString();
                    crmModels.COST_KAHXDJMX.AddPrintCount(data[i].HXDJMXID, token);
                }

                KAHX.KAHXDJMX = data;

                CRM_COST_KAHXDJMX cx_print = new CRM_COST_KAHXDJMX();
                cx_print.HXDJMXIDSTR = str;
                CRM_COST_KAHXDJMX[] HZdata = crmModels.COST_KAHXDJMX.ReadForPrint(cx_print, token);
                KAHX.HZ = new PrintKAHX.KAHXDJMX_HZ[HZdata.Length];
                decimal HXJEHJ = 0;
                for (int i = 0; i < HZdata.Length; i++)
                {
                    KAHX.HZ[i] = new PrintKAHX.KAHXDJMX_HZ();
                    KAHX.HZ[i].GNAME = HZdata[i].GNAME;
                    KAHX.HZ[i].CWHSBH = HZdata[i].CWHSBH;
                    KAHX.HZ[i].CBZXBH = HZdata[i].CBZXBH;
                    KAHX.HZ[i].CWHSBHDES = HZdata[i].CWHSBHDES;
                    KAHX.HZ[i].HXJE = HZdata[i].HXJE.ToString();
                    KAHX.HZ[i].FKFSAPSN = HZdata[i].FKFSAPSN;
                    KAHX.HZ[i].BEIZ = HZdata[i].BEIZ;

                    HXJEHJ = HXJEHJ + HZdata[i].HXJE;
                }


                //生成申请单号
                CRM_HG_STAFF staff = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token);
                CRM_HG_DICT cx_dict = new CRM_HG_DICT();
                cx_dict.TYPEID = 113;
                cx_dict.DICNAME = staff.STAFFNAME.Substring(0, 1);
                CRM_HG_DICT[] dict = crmModels.HG_DICT.ReadByParam(cx_dict, 0, token);
                if (dict.Length != 0)
                    ViewBag.NO = dict[0].DICMEMO + DateTime.Now.ToString("yyyyMMddHHmm");
                else
                    ViewBag.NO = "*" + DateTime.Now.ToString("yyyyMMddHHmm");

                ViewBag.HJ = HXJEHJ;
                ViewBag.HJ2 = MoneyToChinese(HXJEHJ.ToString());
                ViewBag.data = KAHX;
            }
            else
            {
                PrintKAHX[] KAHX = new PrintKAHX[0];
                ViewBag.data = KAHX;
            }

            return View();
        }

        public ActionResult Select_CXHD_CPLX()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 542;
            CRM_HG_DICT[] FYZCFS = crmModels.HG_DICT.Read(107, 0, token);
            ViewBag.FYZCFS = FYZCFS;
            return View();
        }

        public ActionResult Select_CXHDTT()
        {
            Session["location"] = 543;
            return View();
        }

        public ActionResult Update_CXHDTT(int CXHDID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHD cxdata = new CRM_COST_CXHD();
            cxdata.CXHDID = CXHDID;
            CRM_COST_CXHD TTdata = crmModels.COST_CXHD.ReadByParam(cxdata, 0, token)[0];
            ViewBag.TTdata = TTdata;

            CRM_HG_DICT[] FYZCFS = crmModels.HG_DICT.Read(107, 0, token);
            ViewBag.FYZCFS = FYZCFS;


            string year = DateTime.Now.Year.ToString();
            string begin = "";
            string end = "";
            if (year == TTdata.GSYEAR)
            {
                begin = year + "0101";
                end = DateTime.Now.ToString("yyyyMMdd");
            }
            else
            {
                begin = TTdata.GSYEAR + "0101";
                end = TTdata.GSYEAR + "1231";
            }
            SAP_RWJDInfo XSRW = crmModels.SAP_Report.SAP_RWJD(TTdata.SAPSN, TTdata.GSYEAR, begin, end, token);
            ViewBag.BNDXSRW = Convert.ToDouble(XSRW.Task1);
            ViewBag.BNDALRW = Convert.ToDouble(XSRW.Task2);

            if (TTdata.ISACTIVE == 10)
            {
                CRM_Report_KHModel cx_kh = new CRM_Report_KHModel();
                cx_kh.PCRMID = TTdata.CRMID;
                cx_kh.KHLX = 5;
                cx_kh.ISACTIVE = 3;
                CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cx_kh, 0, token);
                ViewBag.BAWDSL = KH.Length;
            }
            else
            {
                ViewBag.BAWDSL = TTdata.YBAWDSL;
            }


            return View();
        }

        public ActionResult Select_CXHDTT_HX()
        {
            Session["location"] = 545;
            return View();
        }

        public ActionResult Select_CXHDTT_PG()
        {
            Session["location"] = 546;
            return View();
        }

        public ActionResult Select_CXHDTT_SP()
        {
            Session["location"] = 547;
            return View();
        }

        public ActionResult Select_MDBS_HX2()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 548;
            CRM_HG_DICT[] PAYWAY = crmModels.HG_DICT.Read(93, 0, token);
            CRM_HG_DICT[] CXY = crmModels.HG_DICT.Read(111, 0, token);
            ViewBag.PAYWAY = PAYWAY;
            ViewBag.CXY = CXY;
            return View();
        }
        public ActionResult Select_CXYWH()
        {
            Session["location"] = 551;
            return View();
        }

        public ActionResult Select_KAHXZL_ZZF()
        {
            Session["location"] = 550;
            return View();
        }

        public ActionResult Update_KAHXZL_ZZF(int HXZLTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLTT cxmodel = new CRM_COST_KAHXZLTT();
            cxmodel.HXZLTTID = HXZLTTID;
            CRM_COST_KAHXZLTT TTdata = crmModels.COST_KAHXZLTT.ReadByParam(cxmodel, 0, token)[0];
            ViewBag.TTdata = TTdata;

            CRM_COST_ITEM[] ITEM = crmModels.COST_ITEM.ReadByParam(new CRM_COST_ITEM(), token);
            ViewBag.ITEM = ITEM;
            return View();
        }

        public ActionResult JXS_Report()
        {
            Session["location"] = 562;
            return View();
        }



        //KA销售导入
        [HttpPost]
        public string Data_Daoru_KAXS()
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
                    string[] sheet = { "KA销售导入" };


                    //开始做数据校验


                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //产品

                    #region

                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("销售类型") == false || data1.Columns.Contains("数据类型") == false || data1.Columns.Contains("客户编号") == false)
                        {
                            msg.Msg = "请使用产品新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try      //数据验证
                            {
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        int xhlx = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["销售类型"].ToString(), 87, 0, token);
                                        if (xhlx == 0)
                                        {
                                            msg.Msg = "KA销售导入" + (i + 2) + "行销售类型不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        int sjlx = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["数据类型"].ToString(), 88, 0, token);
                                        if (sjlx == 0)
                                        {
                                            msg.Msg = "KA销售导入" + (i + 2) + "行数据类型不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["客户编号"].ToString(), @"^\d+(\.\d+)?$") == false && data1.Rows[i]["客户编号"].ToString() != "")
                                        {
                                            msg.Msg = "KA销售导入" + (i + 2) + "行客户编号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        CRM_KH_KH CRMID = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["客户编号"].ToString(), token);
                                        if (CRMID.KHID == 0)
                                        {
                                            msg.Msg = "KA销售导入" + (i + 2) + "行数客户编号不正确，不存在该客户！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        data1.Rows[i]["客户名称"] = CRMID.MC;
                                        if (Regex.IsMatch(data1.Rows[i]["年份"].ToString(), @"^\d{4}$") == false && data1.Rows[i]["年份"].ToString() != "")
                                        {
                                            msg.Msg = "KA销售导入" + (i + 2) + "行年份格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["月份"].ToString(), @"(^0?[0-9]$|^1[0-2]$)") == false && data1.Rows[i]["月份"].ToString() != "")
                                        {
                                            msg.Msg = "KA销售导入" + (i + 2) + "行月份格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["合计销售"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data1.Rows[i]["合计销售"].ToString() != "")
                                        {
                                            msg.Msg = "KA销售导入" + (i + 2) + "行合计销售格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //decimal JX = Convert.ToDecimal(data1.Rows[i]["销售（除华东大润发碳性）"].ToString().Trim() == "" ? 0 : Convert.ToDouble(data1.Rows[i]["销售（除华东大润发碳性）"].ToString().Trim()));
                                        //decimal TX = Convert.ToDecimal(data1.Rows[i]["华东大润发碳性销售"].ToString().Trim() == "" ? 0 : Convert.ToDouble(data1.Rows[i]["华东大润发碳性销售"].ToString().Trim()));
                                        //decimal DP = Convert.ToDecimal(data1.Rows[i]["物美定牌销售"].ToString().Trim() == "" ? 0 : Convert.ToDouble(data1.Rows[i]["物美定牌销售"].ToString().Trim()));
                                        //decimal HJ = Convert.ToDecimal(data1.Rows[i]["合计销售"].ToString().Trim() == "" ? 0 : Convert.ToDouble(data1.Rows[i]["合计销售"].ToString().Trim()));
                                        //if (HJ != (JX + TX + DP))
                                        //{
                                        //    msg.Msg = "KA销售导入" + (i + 2) + "行合计销售大小不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
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

                    for (int i = 0; i < data1.Rows.Count; i++)   //数据到数据库
                    {
                        #region
                        CRM_COST_KAXS model = new CRM_COST_KAXS();
                        //crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["销售类型"].ToString().Trim(), 87, 0, token);
                        model.XSLX = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["销售类型"].ToString().Trim(), 87, 0, token);
                        model.SJLX = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["数据类型"].ToString().Trim(), 88, 0, token);
                        model.KHID = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["客户编号"].ToString(), token).KHID;
                        model.MC = data1.Rows[i]["客户名称"].ToString().Trim();
                        model.KAYEAR = data1.Rows[i]["年份"].ToString().Trim();
                        if (data1.Rows[i]["月份"].ToString().Trim().Length == 2)
                        {
                            model.KAMONTH = data1.Rows[i]["月份"].ToString().Trim();
                        }
                        else
                        {
                            model.KAMONTH = '0' + data1.Rows[i]["月份"].ToString().Trim();
                        }

                        model.JXXS = data1.Rows[i]["销售（除华东大润发碳性）"].ToString().Trim() == "" ? 0 : Convert.ToDouble(data1.Rows[i]["销售（除华东大润发碳性）"].ToString().Trim());
                        model.TXXS = data1.Rows[i]["华东大润发碳性销售"].ToString().Trim() == "" ? 0 : Convert.ToDouble(data1.Rows[i]["华东大润发碳性销售"].ToString().Trim());
                        model.DPXS = data1.Rows[i]["物美定牌销售"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(data1.Rows[i]["物美定牌销售"].ToString().Trim());
                        model.HJXS = data1.Rows[i]["合计销售"].ToString().Trim() == "" ? 0 : Convert.ToDouble(data1.Rows[i]["合计销售"].ToString().Trim());
                        model.THL = data1.Rows[i]["退货率"].ToString().Replace("%", "").Trim() == "" ? 0 : Convert.ToDecimal(data1.Rows[i]["退货率"].ToString().Trim());
                        model.BEIZ = "";
                        model.ISACTIVE = 1;
                        model.CJR = appClass.CRM_GetStaffid();


                        CRM_COST_KAXS CXMODEL = new CRM_COST_KAXS();
                        CXMODEL.KHID = model.KHID;
                        CXMODEL.XSLX = model.XSLX;
                        CXMODEL.SJLX = model.SJLX;
                        CXMODEL.KAYEAR = model.KAYEAR;
                        CXMODEL.KAMONTH = model.KAMONTH;
                        CRM_COST_KAXS[] data = crmModels.COST_KAXS.ReadByParam(CXMODEL, token);
                        if (data.Length > 0)
                        {
                            msg.Msg = "新增信息的第" + (i + 2) + "行出现问题，当前客户的销售数据类型本年本月已经存在不允许重复导入";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }


                        int j = crmModels.COST_KAXS.Create(model, token);

                        if (j <= 0)
                        {
                            msg.Msg = "新增信息的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
                    }
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



        //临时测试

        [HttpPost]
        public string Select_KAXSByID(int KAXSID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXS model = new CRM_COST_KAXS();
            model.KAXSID = KAXSID;
            CRM_COST_KAXS[] data = crmModels.COST_KAXS.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }
        [HttpPost]
        public string Select_KAXS(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS>(cxdata);
            CRM_COST_KAXS[] data = crmModels.COST_KAXS.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Data_Select_QSYJXS(string cxdata, string timestr)
        {
            //计算某客户的前三月的月均销售，如果只导入了两个月，那取两个月的月均销售
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS>(cxdata);
            DateTime time = Convert.ToDateTime(timestr + "-01");

            string lastmonth3 = time.AddMonths(-3).Month.ToString(), lastmonth3_year = time.AddMonths(-3).Year.ToString();
            string lastmonth1 = time.AddMonths(-1).Month.ToString(), lastmonth1_year = time.AddMonths(-1).Year.ToString();

            if (lastmonth3.Length == 1)
                lastmonth3 = "0" + lastmonth3;
            if (lastmonth1.Length == 1)
                lastmonth1 = "0" + lastmonth1;

            model.TIME_BEGIN = lastmonth3_year + "-" + lastmonth3;
            model.TIME_END = lastmonth1_year + "-" + lastmonth1;


            CRM_COST_KAXS[] data = crmModels.COST_KAXS.ReadByParam(model, token);

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Insert_KAXS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS>(data);

            CRM_COST_KAXS newmodel = new CRM_COST_KAXS();
            newmodel.KHID = model.KHID;
            CRM_COST_KAXS[] cxdata = crmModels.COST_KAXS.ReadByParam(newmodel, token);

            for (int i = 0; i < cxdata.Length; i++)
            {
                if (cxdata[i].KHID == model.KHID && cxdata[i].XSLX == model.XSLX && cxdata[i].SJLX == model.SJLX && cxdata[i].KAYEAR == model.KAYEAR && cxdata[i].KAMONTH == model.KAMONTH)
                {
                    webmsg.MSG = "该客户当月已存入数据，不允许新增数据";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int m = crmModels.COST_KAXS.Create(model, token);
            webmsg.KEY = m;
            if (m > 0)
                webmsg.MSG = "新增成功";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);



        }
        [HttpPost]
        public string Update_KAXS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KAXS.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Delete_KAXS(int KAXSID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KAXS.Delete(KAXSID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Select_KHTSByID(int TSID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TS model = new CRM_COST_TS();
            model.TSID = TSID;
            CRM_COST_TS[] data = crmModels.COST_TS.ReadByParam(model, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }

        [HttpPost]
        public string Insert_KHTS(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_TS>(cxdata);
            model.CJR = appClass.CRM_GetStaffid();
            model.YWY = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;
            int i = crmModels.COST_TS.Create(model, token);
            return i.ToString();
        }
        [HttpPost]
        public string GetData_KHTS(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_TS>(cxdata);
            // model.ISACTIVE = 10;
            CRM_COST_TS[] data = crmModels.COST_TS.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string GetKhdzByKHID(int KHID)
        {
            token = appClass.CRM_Gettoken();
            //CRM_KH_DZ MODEL = new CRM_KH_DZ();
            //MODEL.KHID = KHID;
            //   CRM_KH_DZ[] data = crmModels.KH_DZ.ReadByKHID(KHID, token);
            CRM_KH_DZList[] data = crmModels.KH_DZ.ReadByKHID(KHID, token);
            if (data.Length == 0)
            {
                // webmsg.KEY = 0;
                webmsg.MSG = "已经存在该客户的销售抬头！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
            }

        }
        [HttpPost]
        public string Update_KHTS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_TS>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_TS.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Delete_KHTS(int TSID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_TS.Delete(TSID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public int Insert_TSMX(string data)         //新增投诉明细
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TSMX model = JsonConvert.DeserializeObject<CRM_COST_TSMX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_TSMX.Create(model, token);
            return i;
        }
        [HttpPost]
        public string Select_TSMX(int dataid)   //查询投诉明细
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TSMX model = new CRM_COST_TSMX();
            model.TSID = dataid;
            CRM_COST_TSMX[] data = crmModels.COST_TSMX.ReadByParam(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        [HttpPost]
        public int Update_TSMX(string data)   //更新投诉明细
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TSMX model = JsonConvert.DeserializeObject<CRM_COST_TSMX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_TSMX.Update(model, token);
            return i;
        }
        [HttpPost]
        public int Delete_TSMX(int id)                 //删除投诉明细
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_TSMX.Delete(id, token);
            return i;
        }
        [HttpPost]
        public string Submit_KHTSSP(int TSID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TS cxmodel = new CRM_COST_TS();
            cxmodel.TSID = TSID;
            CRM_COST_TS TTmodel = crmModels.COST_TS.ReadByParam(cxmodel, 0, token)[0];
            CRM_COST_TSMX cxmodel2 = new CRM_COST_TSMX();
            cxmodel2.TSID = TSID;
            CRM_COST_TSMX[] MXmodel = crmModels.COST_TSMX.ReadByParam(cxmodel2, token);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(18, token)[0].CS.ToString();

            CRM_OA_KHTS list = new CRM_OA_KHTS();
            list.LCLX = "申请";
            list.TSLY = TTmodel.SOURCEDES;
            list.TSXX = TTmodel.TSXX;
            list.DAMAGE = TTmodel.DAMAGE == 1 ? "是" : "否";
            list.PRICE = TTmodel.PRICE.ToString();
            list.GG = TTmodel.GG;
            list.REASON = TTmodel.REASON;
            list.MC = TTmodel.MCNAME;
            list.TEL = TTmodel.LXDH;
            list.ADDRESS = TTmodel.KHDZ;
            list.KHYQ = TTmodel.KHYQ;
            list.YWY = TTmodel.STAFFNAME;
            list.FGLD = TTmodel.FGLDDES;
            list.WLXX = TTmodel.WLXXDES;
            list.FCSJ = TTmodel.FCSJ;
            list.JS = TTmodel.JS.ToString();
            list.TSSFYX = TTmodel.TSSFYX.ToString();
            list.TSJG = TTmodel.TSJG;
            //  list.TSFKSJ = TTmodel.TSFKSJ;
            list.KDDH = TTmodel.KDDH;
            list.BEIZ = TTmodel.BEIZ;
            list.KHTSMX = new CRM_OA_KHTSMX[MXmodel.Length];
            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.KHTSMX[i] = new CRM_OA_KHTSMX();
                list.KHTSMX[i].CPMC = MXmodel[i].CPXLDES;
                list.KHTSMX[i].BZGG = MXmodel[i].CPXHDES;
                list.KHTSMX[i].BLPSL = MXmodel[i].BLPSL.ToString();
                list.KHTSMX[i].RQM = MXmodel[i].RQM;
                list.KHTSMX[i].REASON = MXmodel[i].REASON;
            }




            List<CRM_OA_KHTS_IMG> all_img = new List<CRM_OA_KHTS_IMG>();
            for (int i = 0; i < MXmodel.Length; i++)
            {
                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(21, MXmodel[i].TSMXID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_KHTS_IMG temp = new CRM_OA_KHTS_IMG();
                    temp.IMGML = FJ[j].ML;
                    temp.IMGMS = "产品投诉信息照片";
                    all_img.Add(temp);
                }

                CRM_HG_WJJL[] FJ2 = crmModels.HG_WJJL.Read(30, TSID, token);
                for (int j = 0; j < FJ2.Length; j++)
                {
                    CRM_OA_KHTS_IMG temp = new CRM_OA_KHTS_IMG();
                    temp.IMGML = FJ2[j].ML;
                    temp.IMGMS = "投诉产品结果";
                    all_img.Add(temp);
                }


            }
            list.IMG = all_img.ToArray();







            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {


                TTmodel.ISACTIVE = 50;
                crmModels.COST_TS.Update(TTmodel, token);



                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = TSID;
                model.OACSLB = 2051;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }
        [HttpPost]
        public string Submit_KHTS(int TSID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_TS cxmodel = new CRM_COST_TS();
            cxmodel.TSID = TSID;
            CRM_COST_TS TTmodel = crmModels.COST_TS.ReadByParam(cxmodel, 0, token)[0];
            CRM_COST_TSMX cxmodel2 = new CRM_COST_TSMX();
            cxmodel2.TSID = TSID;
            CRM_COST_TSMX[] MXmodel = crmModels.COST_TSMX.ReadByParam(cxmodel2, token);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(18, token)[0].CS.ToString();

            CRM_OA_KHTS list = new CRM_OA_KHTS();
            list.LCLX = "反馈";
            list.TSLY = TTmodel.SOURCEDES;
            list.TSXX = TTmodel.TSXX;
            list.DAMAGE = TTmodel.DAMAGE == 1 ? "是" : "否";
            list.PRICE = TTmodel.PRICE.ToString();
            list.GG = TTmodel.GG;
            list.REASON = TTmodel.REASON;
            list.MC = TTmodel.MCNAME;
            list.TEL = TTmodel.LXDH;
            list.ADDRESS = TTmodel.KHDZ;
            list.KHYQ = TTmodel.KHYQ;
            list.YWY = TTmodel.STAFFNAME;
            list.FGLD = TTmodel.FGLDDES;

            list.KHTSMX = new CRM_OA_KHTSMX[MXmodel.Length];
            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.KHTSMX[i] = new CRM_OA_KHTSMX();
                list.KHTSMX[i].CPMC = MXmodel[i].CPXLDES;
                list.KHTSMX[i].BZGG = MXmodel[i].CPXHDES;
                list.KHTSMX[i].BLPSL = MXmodel[i].BLPSL.ToString();
                list.KHTSMX[i].RQM = MXmodel[i].RQM;
                list.KHTSMX[i].REASON = MXmodel[i].REASON;
            }

            List<CRM_OA_KHTS_IMG> all_img = new List<CRM_OA_KHTS_IMG>();
            for (int i = 0; i < MXmodel.Length; i++)
            {
                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(21, MXmodel[i].TSMXID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_KHTS_IMG temp = new CRM_OA_KHTS_IMG();
                    temp.IMGML = FJ[j].ML;
                    temp.IMGMS = "产品投诉信息照片";
                    all_img.Add(temp);
                }

                CRM_HG_WJJL[] FJ2 = crmModels.HG_WJJL.Read(30, TSID, token);
                for (int j = 0; j < FJ2.Length; j++)
                {
                    CRM_OA_KHTS_IMG temp = new CRM_OA_KHTS_IMG();
                    temp.IMGML = FJ2[j].ML;
                    temp.IMGMS = "投诉产品结果";
                    all_img.Add(temp);
                }


            }
            list.IMG = all_img.ToArray();


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {


                TTmodel.ISACTIVE = 20;
                crmModels.COST_TS.Update(TTmodel, token);



                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = TSID;
                model.OACSLB = 2014;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        //制作费用
        [HttpPost]
        public string Select_TTID_ISACTIVE(int TTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = new CRM_COST_ZZFTT();
            model.TTID = TTID;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(model, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0].ISACTIVE);
        }
        [HttpPost]
        public string Select_Create_FeeById(int TTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = new CRM_COST_ZZFTT();
            model.TTID = TTID;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(model, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }
        [HttpPost]
        public string GetData_Create_Fee(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(cxdata);
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Insert_Create_Fee(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;
            //    model.COSTITEMID = 14;
            int i = crmModels.COST_ZZFTT.Create(model, token);

            return i.ToString();
        }
        [HttpPost]
        public string Delete_Create_Fee(int TTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_ZZFTT.Delete(TTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Update_Create_Fee(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_ZZFTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        //广告公司
        [HttpPost]
        public string BackOrder_AdCompany(string GGGSID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GGGS[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GGGS[]>(GGGSID);
            for (int i = 0; i < checkdata.Length; i++)
            {
                //CRM_COST_GGGS model = new CRM_COST_GGGS();
                //model.GGGSID = checkdata[i].GGGSID;
                //CRM_COST_GGGS[] data = crmModels.COST_GGGS.ReadByParam(model, token);
                checkdata[i].ISACTIVE = 1;
                checkdata[i].XGR = appClass.CRM_GetStaffid();
                int m = crmModels.COST_GGGS.Update(checkdata[i], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "回退失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "回退成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string ChangeOrder_AdCompany(string GGGSID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GGGS[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GGGS[]>(GGGSID);
            for (int i = 0; i < checkdata.Length; i++)
            {
                //CRM_COST_GGGS model = new CRM_COST_GGGS();
                //model.GGGSID = checkdata[i].GGGSID;
                //CRM_COST_GGGS[] data = crmModels.COST_GGGS.ReadByParam(model, token);
                checkdata[i].ISACTIVE = 3;
                checkdata[i].XGR = appClass.CRM_GetStaffid();
                int m = crmModels.COST_GGGS.Update(checkdata[i], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "审核失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string SubmitOrder_AdCompany(string GGGSID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GGGS[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GGGS[]>(GGGSID);
            for (int i = 0; i < checkdata.Length; i++)
            {
                CRM_COST_GGGS model = new CRM_COST_GGGS();
                model.GGGSID = checkdata[i].GGGSID;
                CRM_COST_GGGS[] data = crmModels.COST_GGGS.ReadByParam(model, token);
                data[0].ISACTIVE = 2;
                CRM_HG_WJJL[] WJmodel1 = crmModels.HG_WJJL.Read(16, model.GGGSID, token);
                if (WJmodel1.Length == 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "广告制作协议不允许为空！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                CRM_HG_WJJL[] WJmodel2 = crmModels.HG_WJJL.Read(15, model.GGGSID, token);
                if (WJmodel2.Length == 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "广告公司开户许可不允许为空！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                CRM_HG_WJJL[] WJmodel3 = crmModels.HG_WJJL.Read(14, model.GGGSID, token);
                if (WJmodel3.Length == 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "广告公司营业执照不允许为空！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                int m = crmModels.COST_GGGS.Update(data[0], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "修改失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "修改成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string GetData_AdCompany(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GGGS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GGGS>(cxdata);
            CRM_COST_GGGS[] data = crmModels.COST_GGGS.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Insert_AdCompany(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GGGS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GGGS>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            //int i = crmModels.COST_GGGS.Create(model, token);
            int i = crmModels.COST_GGGS.Create(model, token);
            return i.ToString();

        }
        [HttpPost]
        public string Select_AdCompanyById(int GGGSID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GGGS model = new CRM_COST_GGGS();
            model.GGGSID = GGGSID;
            CRM_COST_GGGS[] data = crmModels.COST_GGGS.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }
        [HttpPost]
        public string Update_AdCompany(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GGGS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GGGS>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_GGGS.Update(model, token);
            //webmsg.KEY = i;
            //if (i > 0)
            //    webmsg.MSG = "修改成功！";
            //else
            //    webmsg.MSG = "修改失败！";
            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            return i.ToString();
        }
        [HttpPost]
        public string Submit_AdCompany(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GGGS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GGGS>(data);
            model.XGR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 2;

            CRM_HG_WJJL[] WJmodel1 = crmModels.HG_WJJL.Read(16, model.GGGSID, token);
            if (WJmodel1.Length == 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "广告制作协议不允许为空！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            CRM_HG_WJJL[] WJmodel2 = crmModels.HG_WJJL.Read(15, model.GGGSID, token);
            if (WJmodel2.Length == 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "广告公司开户许可不允许为空！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            CRM_HG_WJJL[] WJmodel3 = crmModels.HG_WJJL.Read(14, model.GGGSID, token);
            if (WJmodel3.Length == 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "广告公司营业执照不允许为空！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            int i = crmModels.COST_GGGS.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "提交成功！";
            else
                webmsg.MSG = "提交失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);

        }
        [HttpPost]
        public string Delete_AdCompany(int GGGSID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_GGGS.Delete(GGGSID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        //ABC评估表
        [HttpPost]
        public string GetData(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAPRODUCT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAPRODUCT>(cxdata);
            CRM_COST_LKAPRODUCT[] data = crmModels.COST_LKAPRODUCT.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Data_Insert_ABC(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAPRODUCT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAPRODUCT>(data);

            CRM_COST_LKAPRODUCT model1 = new CRM_COST_LKAPRODUCT();
            model1.SAPCP = model.SAPCP;
            CRM_COST_LKAPRODUCT[] da = crmModels.COST_LKAPRODUCT.ReadByParam(model1, token);

            if (da.Length > 0)
            {
                webmsg.MSG = "SAP编号已经存在";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                model.XGR = appClass.CRM_GetStaffid();
                model.ISACTIVE = 1;
                int i = crmModels.COST_LKAPRODUCT.Create(model, token);
                webmsg.KEY = i;
                if (i > 0)
                    webmsg.MSG = "新增成功";
                else
                    webmsg.MSG = "新增失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }
        [HttpPost]
        public string Data_Delete_ABC(string SAPCP)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAPRODUCT.Delete(SAPCP, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Data_Select_ABC_ProductById(string SAPCP)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAPRODUCT model = new CRM_COST_LKAPRODUCT();
            model.SAPCP = SAPCP;
            CRM_COST_LKAPRODUCT[] data = crmModels.COST_LKAPRODUCT.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }
        [HttpPost]
        public string Data_Update_ABC_Product(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAPRODUCT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAPRODUCT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_LKAPRODUCT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);

        }
        [HttpPost]
        public string Data_Daoru_ABC_Product()
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
                    string[] sheet = { "ABC产品评估表" };


                    //开始做数据校验


                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //产品

                    #region

                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("SAP编号") == false || data1.Columns.Contains("产品名称") == false || data1.Columns.Contains("包装数量") == false)
                        {
                            msg.Msg = "请使用产品新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try      //数据验证
                            {
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        CRM_COST_LKAPRODUCT model = new CRM_COST_LKAPRODUCT();
                                        model.SAPCP = data1.Rows[i]["SAP编号"].ToString();
                                        CRM_COST_LKAPRODUCT[] data = crmModels.COST_LKAPRODUCT.ReadByParam(model, token);
                                        if (data.Length > 0)
                                        {
                                            msg.Msg = "ABC产品评估表" + (i + 2) + "行(SAP编号:" + data1.Rows[i]["SAP编号"].ToString() + ")SAP编号已经存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["SAP编号"].ToString(), @"^[0-9]*$") == false && data1.Rows[i]["SAP编号"].ToString() != "")
                                        {
                                            msg.Msg = "ABC产品评估表" + (i + 2) + "行(SAP编号:" + data1.Rows[i]["SAP编号"].ToString() + ")SAP编号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["包装数量"].ToString(), @"^[0-9]*$") == false && data1.Rows[i]["包装数量"].ToString() != "")
                                        {
                                            msg.Msg = "ABC产品评估表" + (i + 2) + "行(SAP编号:" + data1.Rows[i]["SAP编号"].ToString() + ")包装数量格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["省外出厂价(元/只)"].ToString(), @"^\d+(\.\d+)?$") == false && data1.Rows[i]["省外出厂价(元/只)"].ToString() != "")
                                        {
                                            msg.Msg = "ABC产品评估表" + (i + 2) + "行(SAP编号:" + data1.Rows[i]["SAP编号"].ToString() + ")省外出厂价格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["浙江省内价格(元/只)"].ToString(), @"^\d+(\.\d+)?$)") == false && data1.Rows[i]["浙江省内价格(元/只)"].ToString() != "")
                                        {
                                            msg.Msg = "ABC产品评估表" + (i + 2) + "行(SAP编号:" + data1.Rows[i]["SAP编号"].ToString() + ")浙江省内价格格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //if (Regex.IsMatch(data1.Rows[i]["促销装费用(元/只)"].ToString(), @"^\d+(\.\d+)?$") == false && data1.Rows[i]["促销装费用(元/只)"].ToString() != "")
                                        //{
                                        //    msg.Msg = "ABC产品评估表" + (i + 2) + "行(SAP编号:" + data1.Rows[i]["SAP编号"].ToString() + ")促销装费用格式不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        if (Regex.IsMatch(data1.Rows[i]["省外毛利(元/只)"].ToString(), @"^[+-]?\d+(\.\d+)?$)") == false && data1.Rows[i]["省外毛利(元/只)"].ToString() != "")
                                        {
                                            msg.Msg = "ABC产品评估表" + (i + 2) + "行(SAP编号:" + data1.Rows[i]["SAP编号"].ToString() + ")省外毛利格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["省内毛利(元/只)"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data1.Rows[i]["省内毛利(元/只)"].ToString() != "")
                                        {
                                            msg.Msg = "ABC产品评估表" + (i + 2) + "行(SAP编号:" + data1.Rows[i]["SAP编号"].ToString() + ")省内毛利格式不正确！";
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

                    for (int i = 0; i < data1.Rows.Count; i++)   //数据到数据库
                    {
                        #region
                        CRM_COST_LKAPRODUCT model = new CRM_COST_LKAPRODUCT();
                        model.SAPCP = data1.Rows[i]["SAP编号"].ToString().Trim();
                        model.CPMC = data1.Rows[i]["产品名称"].ToString().Trim();
                        model.BZNUM = Convert.ToInt32(data1.Rows[i]["包装数量"].ToString().Trim());
                        model.PRICE_OUT = Convert.ToDouble(data1.Rows[i]["省外出厂价(元/只)"].ToString().Trim());
                        model.PRICE_IN = Convert.ToDouble(data1.Rows[i]["浙江省内价格(元/只)"].ToString().Trim());
                        model.PROMOTION = Convert.ToDouble(data1.Rows[i]["促销装费用(元/只)"].ToString().Trim() == "" ? 0 : Convert.ToDouble(data1.Rows[i]["促销装费用(元/只)"].ToString().Trim()));
                        model.PROFIT_OUT = Convert.ToDouble(data1.Rows[i]["省内毛利(元/只)"].ToString().Trim());
                        model.PROFIT_IN = Convert.ToDouble(data1.Rows[i]["省外毛利(元/只)"].ToString().Trim());
                        model.BEIZ = "";
                        model.ISACTIVE = 1;
                        model.XGR = appClass.CRM_GetStaffid();

                        int j = crmModels.COST_LKAPRODUCT.Create(model, token);

                        if (j <= 0)
                        {
                            msg.Msg = "新增产品的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
                    }
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
                            //    dataRow[j] = row.GetCell(j).ToString();
                            ICell cell = row.GetCell(j);

                            if (cell != null)
                            {
                                string cellValue = "";
                                if (cell.CellType == CellType.Numeric)
                                {
                                    short format = cell.CellStyle.DataFormat;
                                    if (format == 14 || format == 176 || format == 177)
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
            catch (Exception)
            {
                //MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
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
        public string Data_Insert_LKAXSTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAXSTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAXSTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;


            CRM_COST_LKAXSTT cxmodel = new CRM_COST_LKAXSTT();
            cxmodel.LKAID = model.LKAID;

            CRM_COST_LKAXSTT[] xianyou = crmModels.COST_LKAXS.ReadTTByParam(cxmodel, 0, token);
            if (xianyou.Length > 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "已经存在该客户的销售抬头！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            CRM_COST_LKAXSTT[] result = crmModels.COST_LKAXS.ReadKHbasic(model, token);

            model.JXSID = result[0].JXSID;
            model.YWYID = result[0].YWYID;
            model.SF = result[0].SF;
            model.CS = result[0].CS;


            int i = crmModels.COST_LKAXS.CreateTT(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAXSTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAXSTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAXSTT>(data);

            CRM_COST_LKAXSTT cxmodel = new CRM_COST_LKAXSTT();
            cxmodel.LKAXSTTID = model.LKAXSTTID;
            CRM_COST_LKAXSTT res = crmModels.COST_LKAXS.ReadTTByParam(cxmodel, 0, token)[0];
            res.LKAXSSJLX = model.LKAXSSJLX;
            res.XSSOURCE = model.XSSOURCE;
            res.BEIZ = model.BEIZ;
            res.XGR = appClass.CRM_GetStaffid();

            int i = crmModels.COST_LKAXS.UpdateTT(res, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAXSTTbyParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAXSTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAXSTT>(cxdata);
            CRM_COST_LKAXSTT[] data = crmModels.COST_LKAXS.ReadTTByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_LKAXSTT_KHbasic(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAXSTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAXSTT>(cxdata);
            CRM_COST_LKAXSTT[] data = crmModels.COST_LKAXS.ReadKHbasic(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
        }

        [HttpPost]
        public string Data_Delete_LKAXSTT(int LKAXSTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAXS.DeleteTT(LKAXSTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_LKAXSMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAXSMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAXSMX>(data);

            CRM_COST_LKAXSMX cxmodel = new CRM_COST_LKAXSMX();
            cxmodel.LKAXSTTID = model.LKAXSTTID;
            cxmodel.XSYEAR = model.XSYEAR;
            cxmodel.XSMONTH = model.XSMONTH;
            CRM_COST_LKAXSMX[] res = crmModels.COST_LKAXS.ReadMXByTTID(cxmodel, token);
            if (res.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "年月重复！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            int i = crmModels.COST_LKAXS.CreateMX(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAXSMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAXSMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAXSMX>(data);
            int i = crmModels.COST_LKAXS.UpdateMX(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAXSMXbyTTID(int LKAXSTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAXSMX model = new CRM_COST_LKAXSMX();
            model.LKAXSTTID = LKAXSTTID;
            CRM_COST_LKAXSMX[] data = crmModels.COST_LKAXS.ReadMXByTTID(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAXSMX(int LKAXSMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAXS.DeleteMX(LKAXSMXID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }



        //LKAYEAR
        [HttpPost]
        public string Data_Insert_LKAYearTT(string data)
        {
            token = appClass.CRM_Gettoken();

            try
            {
                CRM_COST_LKAYEARTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARTT>(data);

                CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
                cxmodel.HTYEAR = model.HTYEAR;
                cxmodel.LKAID = model.LKAID;
                CRM_COST_LKAYEARTT[] res = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel, 0, token);
                if (res.Length != 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "数据重复！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }

                cxmodel.HTYEAR = "";
                cxmodel.BEGINDATE = model.BEGINDATE;
                cxmodel.ENDDATE = model.ENDDATE;
                int count = crmModels.COST_LKAYEARTT.Verify(cxmodel, token);
                if (count != 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "年度费用起止日期与现有数据重复！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }


                model.SQR = appClass.CRM_GetStaffid();
                model.XGR = appClass.CRM_GetStaffid();
                model.ISACTIVE = 10;
                model.JXSID = crmModels.KH_KH.ReadJXSByKHID(model.LKAID, token).KHID;


                //allcount是两个时间点的跨度的月份总数，然后根据过15算一个月的原则把不算的月份删掉
                int allcount = (Convert.ToDateTime(model.ENDDATE).Year - Convert.ToDateTime(model.BEGINDATE).Year) * 12 + (Convert.ToDateTime(model.ENDDATE).Month - Convert.ToDateTime(model.BEGINDATE).Month) + 1;
                if (Convert.ToDateTime(model.BEGINDATE).Day > 15)
                {
                    allcount--;
                }
                if (Convert.ToDateTime(model.ENDDATE).Day < 15)
                {
                    allcount--;
                }
                model.MONTHCOUNT = allcount;

                CRM_KH_KHList KH = crmModels.KH_KH.Read(model.LKAID, token);
                model.FIRSTTIME = KH.FIRSTTIME;
                model.PSQK = KH.PSQK;
                model.FSFW = KH.FSFW;
                model.MANAGEWAY = KH.MANAGEWAY;
                model.PAYWAY = KH.PAYWAY;
                CRM_KH_KHQTXXList[] JP = crmModels.KH_KHQTXX.Read(model.LKAID, 3, token);
                if (JP.Length == 0)
                    model.JZPPNAME = "";
                else
                {
                    model.JZPPNAME = JP[0].XXMC;
                    for (int i = 1; i < JP.Length; i++)
                    {
                        model.JZPPNAME = model.JZPPNAME + "," + JP[i].XXMC;
                    }
                }
                model.GSLXR = KH.GSLXR;
                model.GSLXRZW = KH.GSLXRZW;
                model.GSLXDH = KH.GSLXDH;
                model.QTCP = KH.SUPPORTOTHER;
                //model.SFXJMC = KH.ISNEW;
                model.SFZJQDHT = KH.PACT;
                model.KAGXLKA = KH.BELONGKA;
                model.WEBSITE = KH.WEBSITE;
                model.ACCOUNT = KH.ACCOUNT;

                int LKAYEARTTID = crmModels.COST_LKAYEARTT.Create(model, token);
                webmsg.KEY = LKAYEARTTID;
                if (LKAYEARTTID > 0)                //抬头新增成功，然后开始新增细项数据
                {
                    webmsg.MSG = "新增成功！";
                    CRM_COST_LKAYEARMD[] MD = crmModels.COST_LKAYEARMD.ReadMDQKbyKHID(model.LKAID, token);
                    for (int i = 0; i < MD.Length; i++)            //新增门店子表
                    {
                        CRM_COST_LKAYEARMD MDmodel = new CRM_COST_LKAYEARMD();
                        MDmodel.LKAYEARTTID = LKAYEARTTID;
                        MDmodel.BAMDSL = MD[i].BAMDSL;
                        MDmodel.MDLX = MD[i].MDLX;
                        int ii = crmModels.COST_LKAYEARMD.Create(MDmodel, token);
                    }

                    CRM_HG_DICT[] XS = crmModels.HG_DICT.Read(66, 0, token);
                    for (int i = 0; i < XS.Length; i++)         //新增卖场销售子表
                    {
                        CRM_COST_LKAYEARXS XSmodel = new CRM_COST_LKAYEARXS();
                        XSmodel.LKAYEARTTID = LKAYEARTTID;
                        XSmodel.PP = XS[i].DICID;
                        int ii = crmModels.COST_LKAYEARXS.Create(XSmodel, token);
                    }

                    CRM_COST_LKAYEARCOST[] COST = crmModels.COST_LKAYEARCOST.ReadCOSTByKHID(model.LKAID, model.HTYEAR, token);
                    for (int i = 0; i < COST.Length; i++)     //新增费用申请子表
                    {
                        CRM_COST_LKAYEARCOST COSTmodel = new CRM_COST_LKAYEARCOST();
                        COSTmodel.LKAYEARTTID = LKAYEARTTID;
                        COSTmodel.COSTITEMID = COST[i].COSTITEMID;
                        COSTmodel.COSTITEMYEAR = model.HTYEAR;
                        COSTmodel.LASTHTTKNR = COST[i].LASTHTTKNR;
                        COSTmodel.LASTFYYGE = COST[i].LASTFYYGE;
                        COSTmodel.ISACTIVE = 1;
                        int ii = crmModels.COST_LKAYEARCOST.Create(COSTmodel, token);
                    }

                    CRM_COST_LKAYEARLIST[] LIST = crmModels.COST_LKAYEARLIST.ReadListByKHID(model.LKAID, model.HTYEAR, token);
                    for (int i = 0; i < LIST.Length; i++)         //新增LKA清单子表
                    {
                        CRM_COST_LKAYEARLIST LISTmodel = new CRM_COST_LKAYEARLIST();
                        LISTmodel.LKAYEARTTID = LKAYEARTTID;
                        LISTmodel.KHID = LIST[i].KHID;
                        LISTmodel.LAST2YEAR_HT = LIST[i].LAST2YEAR_HT;
                        LISTmodel.LAST2YEAR_GS = LIST[i].LAST2YEAR_GS;
                        LISTmodel.LASTYEAR_HT = LIST[i].LASTYEAR_HT;
                        LISTmodel.LASTYEAR_GS = LIST[i].LASTYEAR_GS;
                        LISTmodel.THISYEAR_HT = LIST[i].THISYEAR_HT;
                        LISTmodel.THISYEAR_GS = LIST[i].THISYEAR_GS;
                        LISTmodel.CCJ_HT = LIST[i].CCJ_HT;
                        LISTmodel.CCJ_GS = LIST[i].CCJ_GS;
                        int ii = crmModels.COST_LKAYEARLIST.Create(LISTmodel, token);
                    }

                }
                else
                    webmsg.MSG = "新增失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            catch (Exception e)
            {
                webmsg.KEY = 0;
                webmsg.MSG = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

        }

        [HttpPost]
        public string Data_Update_LKAYearTT(string data, string COST)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            if (model.ISACTIVE == 60)
                model.ISACTIVE = 45;
            int i = crmModels.COST_LKAYEARTT.Update(model, token);

            CRM_COST_LKAYEARCOST[] COSTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARCOST[]>(COST);
            for (int j = 0; j < COSTmodel.Length; j++)
            {
                //COSTmodel[j].TBZJ = (COSTmodel[j].THISFYYGE - COSTmodel[j].LASTFYYGE) / COSTmodel[j].LASTFYYGE;
                int ii = crmModels.COST_LKAYEARCOST.Update(COSTmodel[j], token);
            }


            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAYearTT_UpdateAll(string data, string COST)
        {
            //函数增加了一个参数，本来可以和上面那个函数写一起的，但是考虑到已经上线，如果有缓存的话会导致系统报错，所以另写一个
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_LKAYEARTT.Update(model, token);

            CRM_COST_LKAYEARCOST[] COSTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARCOST[]>(COST);
            for (int j = 0; j < COSTmodel.Length; j++)
            {
                //COSTmodel[j].TBZJ = (COSTmodel[j].THISFYYGE - COSTmodel[j].LASTFYYGE) / COSTmodel[j].LASTFYYGE;
                COSTmodel[j].THISFYYGE = COSTmodel[j].THISFYYGEXG;
                int ii = crmModels.COST_LKAYEARCOST.UpdateAll(COSTmodel[j], token);
            }


            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAYearTTbyParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARTT>(cxdata);
            CRM_COST_LKAYEARTT[] data = crmModels.COST_LKAYEARTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_LKAYearReportJXS(int LKAYEARTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARTT_JXS[] data = crmModels.COST_LKAYEARTT.ReportJXS(LKAYEARTTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAYearTT(int LKAYEARTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAYEARTT.Delete(LKAYEARTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Open_LKAYearTT(int LKAYEARTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARTT model = new CRM_COST_LKAYEARTT();
            model.LKAYEARTTID = LKAYEARTTID;
            model.ISACTIVE = 45;
            int i = crmModels.COST_LKAYEARTT.UpdateStatus(model, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "开放修改成功！";
            else
                webmsg.MSG = "开放修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_LKAYearMD(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARMD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARMD>(data);
            int i = crmModels.COST_LKAYEARMD.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAYearMD(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARMD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARMD>(data);
            int i = crmModels.COST_LKAYEARMD.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAYearMD(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARMD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARMD>(cxdata);
            CRM_COST_LKAYEARMD[] data = crmModels.COST_LKAYEARMD.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAYearMD(int MDID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAYEARMD.Delete(MDID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_LKAYEARXS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARXS>(data);
            int i = crmModels.COST_LKAYEARXS.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAYEARXS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARXS>(data);
            int i = crmModels.COST_LKAYEARXS.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAYEARXS(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARXS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARXS>(cxdata);
            CRM_COST_LKAYEARXS[] data = crmModels.COST_LKAYEARXS.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAYEARXS(int XSID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAYEARXS.Delete(XSID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_LKAYEARCP(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CP>(data);
            model.CPFL = crmModels.SAP_Report.SAP_CPFL(model.SAPCP, token);
            model.ISACTIVE = 1;

            CRM_COST_CP cxmodel = new CRM_COST_CP();
            cxmodel.SAPCP = model.SAPCP;
            cxmodel.LKAYEARTTID = model.LKAYEARTTID;
            CRM_COST_CP[] cxdata = crmModels.COST_CP.ReadByParam(cxmodel, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "该产品已经存在！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            int i = crmModels.COST_CP.Create(model, token);
            if (i > 0)     //要更新卖场销售中双鹿的销售数据
            {
                crmModels.COST_LKAYEARXS.UpdateSonlukXS(model.LKAYEARTTID, token);
            }
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAYEARCP(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CP>(data);
            int i = crmModels.COST_CP.Update(model, token);
            if (i > 0)     //要更新卖场销售中双鹿的销售数据
            {
                crmModels.COST_LKAYEARXS.UpdateSonlukXS(model.LKAYEARTTID, token);
                if (model.ISACTIVE == 3)
                {
                    CRM_COST_LKAYEARTT year = new CRM_COST_LKAYEARTT();
                    year.LKAYEARTTID = model.LKAYEARTTID;
                    year.ISACTIVE = 45;
                    crmModels.COST_LKAYEARTT.UpdateStatus(year, token);
                }

            }
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAYEARCP(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CP>(cxdata);
            CRM_COST_CP[] data = crmModels.COST_CP.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_ReportYEARData(int LKAYEARTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CP_YEARDATA data = crmModels.COST_CP.ReportYEARData(LKAYEARTTID, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAYEARCP(int CPID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CP cxmodel = new CRM_COST_CP();
            cxmodel.CPID = CPID;
            CRM_COST_CP model = crmModels.COST_CP.ReadByParam(cxmodel, token)[0];
            int i = crmModels.COST_CP.Delete(CPID, token);
            if (i > 0)     //要更新卖场销售中双鹿的销售数据
            {
                crmModels.COST_LKAYEARXS.UpdateSonlukXS(model.LKAYEARTTID, token);
                if (model.ISACTIVE == 3)
                {
                    CRM_COST_LKAYEARTT year = new CRM_COST_LKAYEARTT();
                    year.LKAYEARTTID = model.LKAYEARTTID;
                    year.ISACTIVE = 45;
                    crmModels.COST_LKAYEARTT.UpdateStatus(year, token);
                }

            }
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_LKAYEARCOST(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARCOST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARCOST>(data);
            int i = crmModels.COST_LKAYEARCOST.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAYEARCOST(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARCOST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARCOST>(data);
            int i = crmModels.COST_LKAYEARCOST.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAYEARCOST(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARCOST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARCOST>(cxdata);
            CRM_COST_LKAYEARCOST[] data = crmModels.COST_LKAYEARCOST.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAYEARCOST(int COSTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAYEARCOST.Delete(COSTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_LKAYEARLIST(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARLIST>(data);
            int i = crmModels.COST_LKAYEARLIST.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAYEARLIST(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARLIST>(data);
            int i = crmModels.COST_LKAYEARLIST.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAYEARLIST(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARLIST>(cxdata);
            CRM_COST_LKAYEARLIST[] data = crmModels.COST_LKAYEARLIST.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAYEARLIST(int LISTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAYEARLIST.Delete(LISTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_ITEM(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ITEM model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ITEM>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_ITEM.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_ITEM(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ITEM model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ITEM>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_ITEM.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_ITEM(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ITEM model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ITEM>(cxdata);
            CRM_COST_ITEM[] data = crmModels.COST_ITEM.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_ITEM(int COSTITEMID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_ITEM.Delete(COSTITEMID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_LKAYear(string newdata, string newCOST)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_LKAYEARTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARTT>(newdata);
            model.XGR = appClass.CRM_GetStaffid();
            if (model.ISACTIVE == 60)
                model.ISACTIVE = 45;
            int ii = crmModels.COST_LKAYEARTT.Update(model, token);


            CRM_COST_LKAYEARCOST[] COSTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARCOST[]>(newCOST);
            for (int j = 0; j < COSTmodel.Length; j++)
            {
                //COSTmodel[j].TBZJ = (COSTmodel[j].THISFYYGE - COSTmodel[j].LASTFYYGE) / COSTmodel[j].LASTFYYGE;
                int iii = crmModels.COST_LKAYEARCOST.Update(COSTmodel[j], token);
            }

            CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
            cxmodel.LKAYEARTTID = model.LKAYEARTTID;
            CRM_COST_LKAYEARTT data = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel, 0, token)[0];

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(14, token)[0].CS.ToString();

            CRM_OA_LKAYEAR list = new CRM_OA_LKAYEAR();
            list.SUBMITCOUNT = data.SUBMITCOUNT.ToString();
            list.HTYEAR = data.HTYEAR;
            list.SQR = staffmodel.STAFFNO;
            list.SQSJ = data.SQSJ;
            list.XGSJ = data.LASTXGSJ;
            list.JXSMC = data.JXSMC;
            list.JXSSAPSN = data.JXSSAPSN;
            list.LKACRMID = data.CRMID;
            list.LKAMC = data.LKAMC;
            list.BEGINDATE = data.BEGINDATE;
            list.ENDDATE = data.ENDDATE;

            int @monthcount_gs = 0;

            if (Convert.ToDateTime(data.HTYEAR + "-01-01") <= Convert.ToDateTime(data.BEGINDATE) && Convert.ToDateTime(data.HTYEAR + "-12-31") >= Convert.ToDateTime(data.BEGINDATE) && Convert.ToDateTime(data.HTYEAR + "-12-31") <= Convert.ToDateTime(data.ENDDATE))     //左交叉
            {
                @monthcount_gs = 12 - Convert.ToInt32(data.BEGINDATE.Split('-')[1]) + 1;
                if (Convert.ToInt32(data.BEGINDATE.Split('-')[2]) > 15)
                {
                    @monthcount_gs = @monthcount_gs - 1;
                }
            }
            else if (Convert.ToDateTime(data.HTYEAR + "-01-01") >= Convert.ToDateTime(data.BEGINDATE) && Convert.ToDateTime(data.HTYEAR + "-01-01") <= Convert.ToDateTime(data.ENDDATE) && Convert.ToDateTime(data.HTYEAR + "-12-31") >= Convert.ToDateTime(data.ENDDATE))       //右交叉
            {
                @monthcount_gs = Convert.ToInt32(data.ENDDATE.Split('-')[1]);
                if (Convert.ToInt32(data.ENDDATE.Split('-')[2]) < 15)
                {
                    @monthcount_gs = @monthcount_gs - 1;
                }
            }
            else if (Convert.ToDateTime(data.HTYEAR + "-01-01") >= Convert.ToDateTime(data.BEGINDATE) && Convert.ToDateTime(data.HTYEAR + "-12-31") <= Convert.ToDateTime(data.ENDDATE))       //申请了两年，合同年份被包含在中间
            {
                @monthcount_gs = 12;
            }
            else       //申请了半年，完全包含在合同年份内
            {
                @monthcount_gs = data.MONTHCOUNT;
            }

            list.MONTHCOUNT = @monthcount_gs.ToString();






            //list.MONTHCOUNT = data.MONTHCOUNT.ToString();


            //门店情况
            CRM_COST_LKAYEARMD MDQK_cx = new CRM_COST_LKAYEARMD();
            MDQK_cx.LKAYEARTTID = model.LKAYEARTTID;
            CRM_COST_LKAYEARMD[] MDQK = crmModels.COST_LKAYEARMD.ReadByParam(MDQK_cx, token);
            list.MDQK = new CRM_OA_LKAYEAR_MDQK[MDQK.Length];
            for (int i = 0; i < MDQK.Length; i++)
            {
                list.MDQK[i] = new CRM_OA_LKAYEAR_MDQK();
                list.MDQK[i].MDLX = MDQK[i].MDLXDES;
                list.MDQK[i].XYMDSL = MDQK[i].XYMDSL.ToString();
                list.MDQK[i].YJCMDSL = MDQK[i].YJCMDSL.ToString();
                list.MDQK[i].BNYJXZMDSL = MDQK[i].BNYJXZMDSL.ToString();
                list.MDQK[i].DPJCSL = MDQK[i].DPJCSL.ToString();
                list.MDQK[i].BASL = MDQK[i].BAMDSL.ToString();
                list.MDQK[i].DISPLAY = MDQK[i].ZYCLFS;
                list.MDQK[i].DISPLAY_ZB = MDQK[i].SLCLMJZB.ToString() + "%";
                list.MDQK[i].BEIZ = MDQK[i].BEIZ;
            }


            list.FIRSTTIME = data.FIRSTTIME;
            list.PSQK = data.PSQK;
            list.FSFW = data.FSFW;
            list.MANAGEWAY = data.MANAGEWAYDES;
            list.PAYWAY = data.PAYWAYDES;
            list.JZPP = data.JZPPNAME;
            list.NFGHS = data.NFGHSDES;
            list.NFCLFS = data.NFCLFS;
            list.NFCLZB = data.NFCLZB.ToString() + "%";
            list.GSLXR = data.GSLXR;
            list.GSLXRZW = data.GSLXRZWDES;
            list.GSLXRDH = data.GSLXDH;
            list.SUPPORTOTHER = data.QTCP == 1 ? "是" : "否";
            list.ISNEW = data.SFXJMC == 1 ? "是" : "否";
            list.PACT = data.SFZJQDHT == 1 ? "是" : "否";
            list.BELONGKA = data.KAGXLKA == 1 ? "是" : "否";


            //卖场销售
            CRM_COST_LKAYEARXS MCXS_cx = new CRM_COST_LKAYEARXS();
            MCXS_cx.LKAYEARTTID = model.LKAYEARTTID;
            CRM_COST_LKAYEARXS[] MCXS = crmModels.COST_LKAYEARXS.ReadByParam(MCXS_cx, token);
            list.MCXS = new CRM_OA_LKAYEAR_MCXS[MCXS.Length];
            for (int i = 0; i < MCXS.Length; i++)
            {
                list.MCXS[i] = new CRM_OA_LKAYEAR_MCXS();
                list.MCXS[i].PP = MCXS[i].PPDES;
                list.MCXS[i].LAST = MCXS[i].LASTYEARSJXS.ToString();
                list.MCXS[i].THIS = MCXS[i].THISYEARYJXS.ToString();
                list.MCXS[i].TBZJ = MCXS[i].TBZJ.ToString() + "%";
            }


            list.CHANGEREASON = data.XSBHYYSM;

            if (data.MCXSSOURCE == 1285)
                list.MCXSSOURCE = data.MCXSSOURCEDES + "(" + data.MCXSSOURCE_OTHER + ")";
            else
                list.MCXSSOURCE = data.MCXSSOURCEDES;

            if (data.MCFYSOURCE == 1289)
                list.MCFYSOURCE = data.MCFYSOURCEDES + "(" + data.MCFYSOURCE_OTHER + ")";
            else
                list.MCFYSOURCE = data.MCFYSOURCEDES;
            list.WEBSITE = data.WEBSITE;
            list.ACCOUNT = data.ACCOUNT;


            //费用明细
            CRM_COST_LKAYEARCOST COST_cx = new CRM_COST_LKAYEARCOST();
            COST_cx.LKAYEARTTID = model.LKAYEARTTID;
            CRM_COST_LKAYEARCOST[] COST = crmModels.COST_LKAYEARCOST.ReadByParam(COST_cx, token);
            #region
            for (int i = 0; i < COST.Length; i++)
            {
                switch (COST[i].COSTITEMID)
                {
                    case 1:
                        list.FL_LAST_NR = COST[i].LASTHTTKNR;
                        list.FL_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.FL_THIS_NR = COST[i].THISHTTKNR;
                        list.FL_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.FL_HISTORY = COST[i].THISFYYGE.ToString();
                        list.FL_TBZJ = COST[i].TBZJ.ToString();
                        list.FL_REASON = COST[i].FYZJYY;
                        list.FL_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.FL_LAST_JE = "";
                            list.FL_THIS_JE = "";
                            list.FL_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.FL_HISTORY = "";
                        }
                        break;
                    case 2:
                        list.XX_LAST_NR = COST[i].LASTHTTKNR;
                        list.XX_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.XX_THIS_NR = COST[i].THISHTTKNR;
                        list.XX_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.XX_HISTORY = COST[i].THISFYYGE.ToString();
                        list.XX_TBZJ = COST[i].TBZJ.ToString();
                        list.XX_REASON = COST[i].FYZJYY;
                        list.XX_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.XX_LAST_JE = "";
                            list.XX_THIS_JE = "";
                            list.XX_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.XX_HISTORY = "";
                        }
                        break;
                    case 3:
                        list.OTHER_LAST_NR = COST[i].LASTHTTKNR;
                        list.OTHER_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.OTHER_THIS_NR = COST[i].THISHTTKNR;
                        list.OTHER_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.OTHER_HISTORY = COST[i].THISFYYGE.ToString();
                        list.OTHER_TBZJ = COST[i].TBZJ.ToString();
                        list.OTHER_REASON = COST[i].FYZJYY;
                        list.OTHER_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.OTHER_LAST_JE = "";
                            list.OTHER_THIS_JE = "";
                            list.OTHER_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.OTHER_HISTORY = "";
                        }
                        break;
                    case 4:
                        list.JC_LAST_NR = COST[i].LASTHTTKNR;
                        list.JC_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.JC_THIS_NR = COST[i].THISHTTKNR;
                        list.JC_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.JC_HISTORY = COST[i].THISFYYGE.ToString();
                        list.JC_TBZJ = COST[i].TBZJ.ToString();
                        list.JC_REASON = COST[i].FYZJYY;
                        list.JC_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.JC_LAST_JE = "";
                            list.JC_THIS_JE = "";
                            list.JC_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.JC_HISTORY = "";
                        }
                        break;
                    case 5:
                        list.XP_LAST_NR = COST[i].LASTHTTKNR;
                        list.XP_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.XP_THIS_NR = COST[i].THISHTTKNR;
                        list.XP_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.XP_HISTORY = COST[i].THISFYYGE.ToString();
                        list.XP_TBZJ = COST[i].TBZJ.ToString();
                        list.XP_REASON = COST[i].FYZJYY;
                        list.XP_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.XP_LAST_JE = "";
                            list.XP_THIS_JE = "";
                            list.XP_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.XP_HISTORY = "";
                        }
                        break;
                    case 6:
                        list.HTXQ_LAST_NR = COST[i].LASTHTTKNR;
                        list.HTXQ_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.HTXQ_THIS_NR = COST[i].THISHTTKNR;
                        list.HTXQ_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.HTXQ_HISTORY = COST[i].THISFYYGE.ToString();
                        list.HTXQ_TBZJ = COST[i].TBZJ.ToString();
                        list.HTXQ_REASON = COST[i].FYZJYY;
                        list.HTXQ_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.HTXQ_LAST_JE = "";
                            list.HTXQ_THIS_JE = "";
                            list.HTXQ_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.HTXQ_HISTORY = "";
                        }
                        break;
                    case 7:
                        list.DJQ_LAST_NR = COST[i].LASTHTTKNR;
                        list.DJQ_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.DJQ_THIS_NR = COST[i].THISHTTKNR;
                        list.DJQ_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.DJQ_HISTORY = COST[i].THISFYYGE.ToString();
                        list.DJQ_TBZJ = COST[i].TBZJ.ToString();
                        list.DJQ_REASON = COST[i].FYZJYY;
                        list.DJQ_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.DJQ_LAST_JE = "";
                            list.DJQ_THIS_JE = "";
                            list.DJQ_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.DJQ_HISTORY = "";
                        }
                        break;
                    case 8:
                        list.XDKY_LAST_NR = COST[i].LASTHTTKNR;
                        list.XDKY_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.XDKY_THIS_NR = COST[i].THISHTTKNR;
                        list.XDKY_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.XDKY_HISTORY = COST[i].THISFYYGE.ToString();
                        list.XDKY_TBZJ = COST[i].TBZJ.ToString();
                        list.XDKY_REASON = COST[i].FYZJYY;
                        list.XDKY_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.XDKY_LAST_JE = "";
                            list.XDKY_THIS_JE = "";
                            list.XDKY_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.XDKY_HISTORY = "";
                        }
                        break;
                    case 9:
                        list.DISPLAY_LAST_NR = COST[i].LASTHTTKNR;
                        list.DISPLAY_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.DISPLAY_THIS_NR = COST[i].THISHTTKNR;
                        list.DISPLAY_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.DISPLAY_HISTORY = COST[i].THISFYYGE.ToString();
                        list.DISPLAY_TBZJ = COST[i].TBZJ.ToString();
                        list.DISPLAY_REASON = COST[i].FYZJYY;
                        list.DISPLAY_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.DISPLAY_LAST_JE = "";
                            list.DISPLAY_THIS_JE = "";
                            list.DISPLAY_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.DISPLAY_HISTORY = "";
                        }
                        break;
                    case 10:
                        list.SpecialDISPLAY_LAST_NR = COST[i].LASTHTTKNR;
                        list.SpecialDISPLAY_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.SpecialDISPLAY_THIS_NR = COST[i].THISHTTKNR;
                        list.SpecialDISPLAY_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.SpecialDISPLAY_HISTORY = COST[i].THISFYYGE.ToString();
                        list.SpecialDISPLAY_TBZJ = COST[i].TBZJ.ToString();
                        list.SpecialDISPLAY_REASON = COST[i].FYZJYY;
                        list.SpecialDISPLAY_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.SpecialDISPLAY_LAST_JE = "";
                            list.SpecialDISPLAY_THIS_JE = "";
                            list.SpecialDISPLAY_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.SpecialDISPLAY_HISTORY = "";
                        }
                        break;
                    case 11:
                        list.HaiBao_LAST_NR = COST[i].LASTHTTKNR;
                        list.HaiBao_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.HaiBao_THIS_NR = COST[i].THISHTTKNR;
                        list.HaiBao_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.HaiBao_HISTORY = COST[i].THISFYYGE.ToString();
                        list.HaiBao_TBZJ = COST[i].TBZJ.ToString();
                        list.HaiBao_REASON = COST[i].FYZJYY;
                        list.HaiBao_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.HaiBao_LAST_JE = "";
                            list.HaiBao_THIS_JE = "";
                            list.HaiBao_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.HaiBao_HISTORY = "";
                        }
                        break;
                    case 12:
                        list.DuiTou_LAST_NR = COST[i].LASTHTTKNR;
                        list.DuiTou_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.DuiTou_THIS_NR = COST[i].THISHTTKNR;
                        list.DuiTou_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.DuiTou_HISTORY = COST[i].THISFYYGE.ToString();
                        list.DuiTou_TBZJ = COST[i].TBZJ.ToString();
                        list.DuiTou_REASON = COST[i].FYZJYY;
                        list.DuiTou_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.DuiTou_LAST_JE = "";
                            list.DuiTou_THIS_JE = "";
                            list.DuiTou_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.DuiTou_HISTORY = "";
                        }
                        break;
                    case 13:
                        list.OTHER2_LAST_NR = COST[i].LASTHTTKNR;
                        list.OTHER2_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.OTHER2_THIS_NR = COST[i].THISHTTKNR;
                        list.OTHER2_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.OTHER2_HISTORY = COST[i].THISFYYGE.ToString();
                        list.OTHER2_TBZJ = COST[i].TBZJ.ToString();
                        list.OTHER2_REASON = COST[i].FYZJYY;
                        list.OTHER2_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.OTHER2_LAST_JE = "";
                            list.OTHER2_THIS_JE = "";
                            list.OTHER2_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.OTHER2_HISTORY = "";
                        }
                        break;
                    case 14:
                        list.ZZF_LAST_NR = COST[i].LASTHTTKNR;
                        list.ZZF_LAST_JE = COST[i].LASTFYYGE.ToString();
                        list.ZZF_THIS_NR = COST[i].THISHTTKNR;
                        list.ZZF_THIS_JE = COST[i].THISFYYGEXG.ToString();
                        list.ZZF_HISTORY = COST[i].THISFYYGE.ToString();
                        list.ZZF_TBZJ = COST[i].TBZJ.ToString();
                        list.ZZF_REASON = COST[i].FYZJYY;
                        list.ZZF_SHOW = COST[i].HTTKSFTX == 1 ? "是" : "否";

                        if (COST[i].LASTFYYGE == 0 && COST[i].THISFYYGEXG == 0)
                        {
                            list.ZZF_LAST_JE = "";
                            list.ZZF_THIS_JE = "";
                            list.ZZF_TBZJ = "";
                        }
                        if (COST[i].THISFYYGE == COST[i].THISFYYGEXG)
                        {
                            list.ZZF_HISTORY = "";
                        }
                        break;
                    default:

                        break;
                }
            }

            #endregion



            //产品利润
            CRM_COST_CP CPLR_cx = new CRM_COST_CP();
            CPLR_cx.LKAYEARTTID = model.LKAYEARTTID;
            CRM_COST_CP[] CPLR = crmModels.COST_CP.ReadByParam(CPLR_cx, token);
            list.CPLR = new CRM_OA_LKAYEAR_CPLR[CPLR.Length];
            for (int i = 0; i < CPLR.Length; i++)
            {
                list.CPLR[i] = new CRM_OA_LKAYEAR_CPLR();
                list.CPLR[i].CPMS = CPLR[i].CPMC;
                list.CPLR[i].CPLX = CPLR[i].CPFL;
                list.CPLR[i].MCGJ = CPLR[i].MCSJGJ.ToString();
                list.CPLR[i].MCSJ = CPLR[i].MCSJSJ.ToString();
                list.CPLR[i].XL_LAST = CPLR[i].LASTYEARSJXL.ToString();
                list.CPLR[i].XL_THIS = CPLR[i].THISYEARSLYG.ToString();
                list.CPLR[i].XS_LAST = CPLR[i].LASTYEARXSSJ.ToString();
                list.CPLR[i].XS_THIS = CPLR[i].THISYEARXSYG.ToString();
                list.CPLR[i].CCJ = CPLR[i].CCJXS.ToString();
                list.CPLR[i].ML = CPLR[i].MLXJ.ToString();

            }




            CRM_COST_CP_YEARDATA CPreport = crmModels.COST_CP.ReportYEARData(model.LKAYEARTTID, 0, token);
            list.A_XS = CPreport.A_XS.ToString();
            list.A_ZB = CPreport.A_ZB.ToString() + "%";
            list.B_XS = CPreport.B_XS.ToString();
            list.B_ZB = CPreport.B_ZB.ToString() + "%";
            list.C_XS = CPreport.C_XS.ToString();
            list.C_ZB = CPreport.C_ZB.ToString() + "%";
            list.MCXS_LS = CPreport.MCXS_LS.ToString();
            list.MCXS_GJ = CPreport.MCXS_GJ.ToString();
            list.MLZJ = CPreport.MLXJ.ToString();
            list.MLL = CPreport.MLL.ToString() + "%";
            list.GSSJLR = CPreport.GSSJLR.ToString();
            list.CXZFY = CPreport.CXZFY.ToString();
            list.CCJ_HT = CPreport.CCJXS_HT.ToString();
            list.CCJ_GS = CPreport.CCJXS_GS.ToString();
            list.GSZC_HT = CPreport.GSZCFY_HT.ToString();
            list.GSZC_GS = CPreport.GSZCFY_GS.ToString();



            list.JXS_RW = data.XSRW.ToString();
            list.JXS_JD = data.XSJD.ToString() + "%";
            list.A_JXS_RW = data.AXSRW.ToString();
            list.A_JXS_JD = data.AXSJD.ToString() + "%";
            list.BEIZ = data.BEIZ;


            //LKAlist
            CRM_COST_LKAYEARLIST LKALIST_cx = new CRM_COST_LKAYEARLIST();
            LKALIST_cx.LKAYEARTTID = model.LKAYEARTTID;
            CRM_COST_LKAYEARLIST[] LKALIST = crmModels.COST_LKAYEARLIST.ReadByParam(LKALIST_cx, token);
            list.LKALIST = new CRM_OA_LKAYEAR_LKALIST[LKALIST.Length];
            for (int i = 0; i < LKALIST.Length; i++)
            {
                list.LKALIST[i] = new CRM_OA_LKAYEAR_LKALIST();
                list.LKALIST[i].CRMID = LKALIST[i].CRMID;
                list.LKALIST[i].MC = LKALIST[i].KHMC;
                list.LKALIST[i].LAST_HT = LKALIST[i].LASTYEAR_HT.ToString();
                list.LKALIST[i].LAST_GS = LKALIST[i].LASTYEAR_GS.ToString();
                list.LKALIST[i].THIS_HT = LKALIST[i].THISYEAR_HT.ToString();
                list.LKALIST[i].THIS_GS = LKALIST[i].THISYEAR_GS.ToString();
                list.LKALIST[i].CCJ_HT = LKALIST[i].CCJ_HT.ToString();
                list.LKALIST[i].CCJ_GS = LKALIST[i].CCJ_GS.ToString();

            }



            //经销商报表
            CRM_COST_LKAYEARTT_JXS[] JXS = crmModels.COST_LKAYEARTT.ReportJXS(model.LKAYEARTTID, token);
            list.JXS = new CRM_OA_LKAYEAR_JXS[JXS.Length];
            for (int i = 0; i < JXS.Length; i++)
            {
                list.JXS[i] = new CRM_OA_LKAYEAR_JXS();
                list.JXS[i].YEAR = JXS[i].HTYEAR.ToString();


                string year = DateTime.Now.Year.ToString();
                string begin = "";
                string end = "";
                if (year == JXS[i].HTYEAR.ToString())
                {
                    begin = year + "0101";
                    end = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    begin = JXS[i].HTYEAR.ToString() + "0101";
                    end = JXS[i].HTYEAR.ToString() + "1231";
                }
                SAP_RWJDInfo XSRW = crmModels.SAP_Report.SAP_RWJD(data.JXSSAPSN, JXS[i].HTYEAR.ToString(), begin, end, token);
                list.JXS[i].XSRW = XSRW.Task1.ToString();

                list.JXS[i].SJXS = JXS[i].SJXS.ToString();
                list.JXS[i].SJXS_JX = JXS[i].SJXS_JX.ToString();
                list.JXS[i].LKA_HT = JXS[i].COST_HT.ToString();
                list.JXS[i].LKA_GS = JXS[i].COST_GS.ToString();
                list.JXS[i].FB_GS = JXS[i].FB_GS.ToString();
                list.JXS[i].SPSL = JXS[i].SPSL.ToString();
                list.JXS[i].ZFY = JXS[i].ZFY.ToString();
                list.JXS[i].ZFB = JXS[i].ZFB.ToString();
                list.JXS[i].YHX_GS = "";      //目前先手工在OA上填
            }



            //历史审批意见
            CRM_OA_OPINION OPINION_cx = new CRM_OA_OPINION();
            OPINION_cx.OACSLB = 1313;
            OPINION_cx.OACSBH = model.LKAYEARTTID;
            CRM_OA_OPINION[] OPINION = crmModels.OA_OPINION.ReadByParam(OPINION_cx, token);
            list.OPINION = new CRM_OA_LKAYEAR_OPINION[OPINION.Length];
            for (int i = 0; i < OPINION.Length; i++)
            {
                list.OPINION[i] = new CRM_OA_LKAYEAR_OPINION();
                list.OPINION[i].OPINION = OPINION[i].SPSJ + " " + OPINION[i].SPRNAME + " " + OPINION[i].ATTITUDE + " " + OPINION[i].OPINION;
                list.OPINION[i].HFNR = OPINION[i].HFSJ + " " + OPINION[i].STAFFNAME + " 回复内容： " + OPINION[i].HFNR;
            }



            CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(31, model.LKAYEARTTID, token);
            list.IMG = new CRM_OA_LKAYEAR_IMG[FJ.Length];
            for (int i = 0; i < FJ.Length; i++)
            {
                list.IMG[i] = new CRM_OA_LKAYEAR_IMG();
                list.IMG[i].IMGML = FJ[i].ML;
            }





            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                if (data.SUBMITCOUNT == 0)
                    data.ISACTIVE = 20;
                else
                    data.ISACTIVE = 50;

                crmModels.COST_LKAYEARTT.Update(data, token);


                CRM_OA_TRANSMIT OAmodel = new CRM_OA_TRANSMIT();
                OAmodel.OAID = info.Key;
                OAmodel.OACSBH = model.LKAYEARTTID;
                OAmodel.OACSLB = 1313;
                OAmodel.OAZT = 1;
                OAmodel.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(OAmodel, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);



        }

        [HttpPost]
        public string Data_Report_JXSReport(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CP_JXSReport cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CP_JXSReport>(cxdata);
            CRM_COST_CP_JXSReport[] data = crmModels.COST_CP.JXSReport(cxmodel, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Insert_LKAFYTT(string data, string DPdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYTT>(data);
            if (model.FYLB == 2)
            {
                //特殊陈列的话要校验重复性
                CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
                cxmodel.FYLB = 2;
                cxmodel.LKAID = model.LKAID;
                cxmodel.HTYEAR = model.HTYEAR;
                CRM_COST_LKAFYTT[] cxdata = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token);
                if (cxdata.Length != 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "数据重复！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }



            }

            model.JXSID = crmModels.KH_KH.ReadJXSByKHID(model.LKAID, token).KHID;
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_LKAFYTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
            {
                webmsg.MSG = "新增成功！";
                if (model.FYLB == 1)
                {
                    //堆头海报要新增单品数据
                    CRM_COST_LKADTDP[] DPmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKADTDP[]>(DPdata);
                    for (int j = 0; j < DPmodel.Length; j++)
                    {
                        DPmodel[j].LKAFYTTID = i;
                        DPmodel[j].ISACTIVE = 1;
                        DPmodel[j].CJR = appClass.CRM_GetStaffid();
                        int DPID = crmModels.COST_LKADTDP.Create(DPmodel[j], token);
                    }

                }
            }
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAFYTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_LKAFYTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAFYTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYTT>(cxdata);
            CRM_COST_LKAFYTT[] data = crmModels.COST_LKAFYTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAFYTT(int LKAFYTTID)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_LKAFYMXDT cxmodel = new CRM_COST_LKAFYMXDT();
            cxmodel.LKAFYTTID = LKAFYTTID;
            CRM_COST_LKAFYMXDT[] DT = crmModels.COST_LKAFYMXDT.ReadByParam(cxmodel, token);
            for (int j = 0; j < DT.Length; j++)
            {
                if (DT[j].ISACTIVE == 20 || DT[j].ISACTIVE == 30)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "存在审核中或已审核的数据！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }

            CRM_COST_LKAFYMXTSCL cxmodel2 = new CRM_COST_LKAFYMXTSCL();
            cxmodel2.LKAFYTTID = LKAFYTTID;
            CRM_COST_LKAFYMXTSCL[] TSCL = crmModels.COST_LKAFYMXTSCL.ReadByParam(cxmodel2, token);
            for (int j = 0; j < TSCL.Length; j++)
            {
                if (TSCL[j].ISACTIVE == 20 || TSCL[j].ISACTIVE == 30)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "存在审核中或已审核的数据！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }


            int i = crmModels.COST_LKAFYTT.Delete(LKAFYTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_LKAFYMXDT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXDT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXDT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;

            //校验，海报和堆头只能各有一个
            if (model.COSTITEMID == 11 || model.COSTITEMID == 12)
            {
                CRM_COST_LKAFYMXDT cx = new CRM_COST_LKAFYMXDT();
                cx.LKAFYTTID = model.LKAFYTTID;
                CRM_COST_LKAFYMXDT[] xianyou = crmModels.COST_LKAFYMXDT.ReadByParam(cx, token);
                for (int j = 0; j < xianyou.Length; j++)
                {
                    if (xianyou[j].COSTITEMID == model.COSTITEMID)
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "数据重复！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }
            }
            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = model.LKAFYTTID;
            CRM_COST_LKAFYTT TTmodel = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token)[0];


            CRM_COST_GETCOST COST = crmModels.COST_LKAYEARCOST.GetCost(TTmodel.LKAID, TTmodel.HTYEAR, token);

            CRM_COST_LKAYEARTT cxmodel2 = new CRM_COST_LKAYEARTT();
            cxmodel2.LKAID = TTmodel.LKAID;
            cxmodel2.HTYEAR = TTmodel.HTYEAR;
            CRM_COST_LKAYEARTT[] YearCost = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel2, 0, token);

            if (YearCost.Length != 0 && YearCost[0].ISACTIVE >= 45)      //有年度费用
            {
                if (model.COSTITEMID == 11)          //海报
                {
                    if (Convert.ToDecimal(model.CXFY) > (COST.HB_SP - COST.HB_SQ))         //
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "超过年度费用的审批金额！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }
                else if (model.COSTITEMID == 12)      //堆头
                {
                    if (Convert.ToDecimal(model.CXFY) > (COST.DT_SP - COST.DT_SQ))         //
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "超过年度费用的审批金额！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }
                else if (model.COSTITEMID == 13)      //其他费用
                {
                    if (Convert.ToDecimal(model.CXFY) > (COST.OTHER_SP - COST.OTHER_SQ))         //
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "超过年度费用的审批金额！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }
            }



            int i = crmModels.COST_LKAFYMXDT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAFYMXDT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXDT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXDT>(data);
            model.XGR = appClass.CRM_GetStaffid();

            //校验，海报和堆头只能各有一个
            if (model.COSTITEMID == 11 || model.COSTITEMID == 12)
            {
                CRM_COST_LKAFYMXDT cx = new CRM_COST_LKAFYMXDT();
                cx.LKAFYTTID = model.LKAFYTTID;
                CRM_COST_LKAFYMXDT[] xianyou = crmModels.COST_LKAFYMXDT.ReadByParam(cx, token);
                for (int j = 0; j < xianyou.Length; j++)
                {
                    if (xianyou[j].COSTITEMID == model.COSTITEMID && model.LKADTMXID != xianyou[j].LKADTMXID)
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "数据重复！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }
            }

            int i = crmModels.COST_LKAFYMXDT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAFYMXDT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXDT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXDT>(cxdata);
            CRM_COST_LKAFYMXDT[] data = crmModels.COST_LKAFYMXDT.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_LKAFYMXDT_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXDT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXDT>(cxdata);
            CRM_COST_LKAFYMXDT[] data = crmModels.COST_LKAFYMXDT.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAFYMXDT(int LKADTMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAFYMXDT.Delete(LKADTMXID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_LKADTDP(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKADTDP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKADTDP>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_LKADTDP.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKADTDP(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKADTDP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKADTDP>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_LKADTDP.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKADTDP(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKADTDP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKADTDP>(cxdata);
            CRM_COST_LKADTDP[] data = crmModels.COST_LKADTDP.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKADTDP(int DPID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKADTDP.Delete(DPID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }





        [HttpPost]
        public string Data_Submit_HaiBao(string data, string mxdata)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_LKAFYTT TTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYTT>(data);
            TTmodel.XGR = appClass.CRM_GetStaffid();
            int id = crmModels.COST_LKAFYTT.Update(TTmodel, token);

            if (id <= 0)
            {
                MessageInfo webmsg = new MessageInfo();
                webmsg.Key = "0";
                webmsg.Value = "保存失败！";
            }



            CRM_COST_LKAFYMXDT[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXDT[]>(mxdata);
            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = MXmodel[0].LKAFYTTID;
            CRM_COST_LKAFYTT TTdata = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token)[0];

            CRM_COST_LKADTDP cx_dp = new CRM_COST_LKADTDP();
            cx_dp.LKAFYTTID = MXmodel[0].LKAFYTTID;
            CRM_COST_LKADTDP[] DPmodel = crmModels.COST_LKADTDP.ReadByParam(cx_dp, token);

            for (int i = 0; i < DPmodel.Length; i++)
            {
                if (DPmodel[i].JHSL != 0 && TTdata.KHTHBEGINDATE == "")
                {
                    MessageInfo info1 = new MessageInfo();
                    info1.Key = "0";
                    info1.Value = "单品数据中进货数量不为0，抬头数据中客户提货时间必填";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(info1);
                }
            }




            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            //if (TTdata.FYLB == 3)
            //{
            //    basic.TemplateCode = crmModels.SYS_CS.Read(15, token)[0].CS.ToString();
            //}
            //else
            //{
            basic.TemplateCode = crmModels.SYS_CS.Read(25, token)[0].CS.ToString();
            //}
            CRM_OA_HaiBao list = new CRM_OA_HaiBao();
            list.HTYEAR = TTdata.HTYEAR;
            list.YWY = TTdata.YWYNAME;
            list.JXSNAME = TTdata.JXSNAME;
            list.JXSSAPSN = TTdata.JXSSAPSN;
            list.LKANAME = TTdata.LKANAME;
            list.LKACRMID = TTdata.LKACRMID;
            list.MDSL = TTdata.MDSL.ToString();
            list.YSPFY = TTdata.YSPNDJE.ToString();
            list.LJSPFY = TTdata.LJSQJE.ToString();
            list.YHXFY = TTdata.YHXNDJE.ToString();
            list.CJHDMDSL = TTdata.CJHDMDSL.ToString();
            list.HDBEGINDATE = TTdata.HDBEGINDATE;
            list.HDENDDATE = TTdata.HDENDDATE;
            list.KHTHBEGINDATE = TTdata.KHTHBEGINDATE;
            list.KHTHENDDATE = TTdata.KHTHENDDATE;

            //if (TTdata.FYLB == 3)    //暂时让其他费用照旧进行，只有堆头海报费会按新的流程走
            //{
            //    list.DP1 = TTdata.DP1DES;
            //    list.DP2 = TTdata.DP2DES;
            //    list.CCJ = TTdata.CCJ.ToString();
            //    list.ZCGJ = TTdata.ZCGJ.ToString();
            //    list.CXGJ = TTdata.CXGJ.ToString();
            //    list.ZCSJ = TTdata.ZCSJ.ToString();
            //    list.CXSJ = TTdata.CXSJ.ToString();
            //}

            list.DPYJXS = TTdata.DPYJXS.ToString();
            list.YJHDQJXS = TTdata.YJHDQJXS.ToString();
            list.HDFASM = TTdata.HDFASM;
            list.BELONGKA = crmModels.KH_KH.Read(TTdata.LKAID, token).BELONGKA == 1 ? "是" : "否";

            //费用明细
            double SQJE = 0;
            list.HaiBao_MX = new CRM_OA_HaiBao_MX[MXmodel.Length];
            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.HaiBao_MX[i] = new CRM_OA_HaiBao_MX();
                if (MXmodel[i].COSTITEMID == 13)
                {
                    list.HaiBao_MX[i].FYLX = MXmodel[i].CXLXDES;
                }
                else
                {
                    list.HaiBao_MX[i].FYLX = MXmodel[i].COSTITEMIDDES;
                }

                list.HaiBao_MX[i].CXFY = MXmodel[i].CXFY.ToString();

                SQJE = SQJE + MXmodel[i].CXFY;
            }



            list.YJFB = Math.Round((SQJE / TTdata.YJHDQJXS * 100), 2, MidpointRounding.AwayFromZero).ToString() + "%";


            //单品明细
            list.HaiBao_DP = new CRM_OA_HaiBao_DP[DPmodel.Length];
            for (int i = 0; i < DPmodel.Length; i++)
            {
                list.HaiBao_DP[i] = new CRM_OA_HaiBao_DP();
                list.HaiBao_DP[i].CPMC = DPmodel[i].CPMC;
                list.HaiBao_DP[i].JHSL = DPmodel[i].JHSL.ToString();
                list.HaiBao_DP[i].CCJ = DPmodel[i].CCJ.ToString();
                list.HaiBao_DP[i].ZCGJ = DPmodel[i].ZCGJ.ToString();
                list.HaiBao_DP[i].CXGJ = DPmodel[i].CXGJ.ToString();
                list.HaiBao_DP[i].ZCSJ = DPmodel[i].ZCSJ.ToString();
                list.HaiBao_DP[i].CXSJ = DPmodel[i].CXSJ.ToString();
                list.HaiBao_DP[i].ISCXZ = DPmodel[i].ISCXZ == 1 ? "是" : "否";
                list.HaiBao_DP[i].ISCXZCOUNT = DPmodel[i].ISCXZ.ToString();
            }





            //历史审批意见
            //CRM_OA_OPINION OPINION_cx = new CRM_OA_OPINION();
            //OPINION_cx.OACSLB = 1360;
            //OPINION_cx.OACSBH = MXmodel[0].LKADTMXID;
            //CRM_OA_OPINION[] OPINION = crmModels.OA_OPINION.ReadByParam(OPINION_cx, token);
            //list.OPINION = new CRM_OA_HaiBao_OPINION[OPINION.Length];
            //for (int i = 0; i < OPINION.Length; i++)
            //{
            //    list.OPINION[i] = new CRM_OA_HaiBao_OPINION();
            //    list.OPINION[i].OPINION = OPINION[i].SPSJ + " " + OPINION[i].SPRNAME + " " + OPINION[i].ATTITUDE + " " + OPINION[i].OPINION;
            //    list.OPINION[i].HFNR = OPINION[i].HFSJ + " " + OPINION[i].STAFFNAME + " " + OPINION[i].HFNR;
            //}


            List<CRM_OA_HaiBao_OPINION> all = new List<CRM_OA_HaiBao_OPINION>();
            for (int i = 0; i < MXmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 1360;
                cx_opinion.OACSBH = MXmodel[i].LKADTMXID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_HaiBao_OPINION temp = new CRM_OA_HaiBao_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MXmodel[i].COSTITEMIDDES + "-" + MXmodel[i].CXLXDES;
                    all.Add(temp);
                }
            }

            list.OPINION = all.ToArray();








            CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(32, TTdata.LKAFYTTID, token);
            list.IMG = new CRM_OA_HaiBao_IMG[FJ.Length];
            for (int i = 0; i < FJ.Length; i++)
            {
                list.IMG[i] = new CRM_OA_HaiBao_IMG();
                list.IMG[i].IMGML = FJ[i].ML;
            }


            if (TTdata.FYLB == 3)
            {
                list.TITLE = @"地方性卖场合同外费用申请与效果评估-活动补损费";
            }
            else
            {
                list.TITLE = @"地方性卖场合同外费用申请与效果评估-堆头费\海报费\促销装申请";
            }



            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int j = 0; j < MXmodel.Length; j++)
                {
                    MXmodel[j].ISACTIVE = 20;
                    crmModels.COST_LKAFYMXDT.Update(MXmodel[j], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = MXmodel[j].LKADTMXID;
                    model.OACSLB = 1360;
                    model.OAZT = 1;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }


        [HttpPost]
        public string Data_Submit_TSCL(string mxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXTSCL[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXTSCL[]>(mxdata);
            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = MXmodel[0].LKAFYTTID;
            CRM_COST_LKAFYTT TTdata = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token)[0];

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(16, token)[0].CS.ToString();

            CRM_OA_TSCL list = new CRM_OA_TSCL();
            list.HTYEAR = TTdata.HTYEAR;
            list.YWY = TTdata.YWYNAME;
            list.JXSNAME = TTdata.JXSNAME;
            list.JXSSAPSN = TTdata.JXSSAPSN;
            list.LKANAME = TTdata.LKANAME;
            list.LKACRMID = TTdata.LKACRMID;
            list.MDSL = TTdata.MDSL.ToString();
            list.YSPFY = TTdata.YSPNDJE.ToString();
            if (TTdata.KHLX == 1)
                list.LJSPFY = TTdata.LJSQJE_TSCL.ToString();
            else
                list.LJSPFY = TTdata.LJSQJE.ToString();
            list.YHXFY = TTdata.YHXNDJE.ToString();
            list.FYLX = "特殊陈列费";
            list.BELONGKA = crmModels.KH_KH.Read(TTdata.LKAID, token).BELONGKA == 1 ? "是" : "否";
            list.LCLX = "申请";
            if (TTdata.KHLX == 1)
                list.BDLX = "2";
            else
                list.BDLX = "1";
            list.JXSSAPSN2 = TTdata.JXSSAPSN2;
            list.YHXFY2 = TTdata.YHXSJFY.ToString();

            list.TSCL_MX = new CRM_OA_TSCL_MX[MXmodel.Length];
            //int MDSL = 0, KHID = 0;

            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.TSCL_MX[i] = new CRM_OA_TSCL_MX();
                //if (MXmodel[i].KHID != KHID)
                //{
                //    KHID = MXmodel[i].KHID;
                //    MDSL++;
                //}
                //list.TSCL_MX[i].MDSL = MDSL.ToString();
                list.TSCL_MX[i].MDMC = MXmodel[i].MC;
                list.TSCL_MX[i].DISPLAY = MXmodel[i].CLFSDES;
                list.TSCL_MX[i].BEGINDATE = MXmodel[i].BEGINDATE;
                list.TSCL_MX[i].ENDDATE = MXmodel[i].ENDDATE;
                list.TSCL_MX[i].SQFY = MXmodel[i].SQFYJE.ToString();
                list.TSCL_MX[i].YJXS = MXmodel[i].YJXS.ToString();
                list.TSCL_MX[i].YJFB = MXmodel[i].YJFB.ToString() + "%";
                list.TSCL_MX[i].BEIZ = MXmodel[i].BEIZ;
                list.TSCL_MX[i].RCYJXS = MXmodel[i].RCYJXS.ToString();
                list.TSCL_MX[i].MDCRMID = MXmodel[i].CRMID;
            }

            //还差一个按月合计的表报,OK不要了




            List<CRM_OA_TSCL_IMG> all_img = new List<CRM_OA_TSCL_IMG>();
            List<CRM_OA_TSCL_OPINION> all_opinion = new List<CRM_OA_TSCL_OPINION>();
            for (int i = 0; i < MXmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 1361;
                cx_opinion.OACSBH = MXmodel[i].LKATSCLMXID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_TSCL_OPINION temp = new CRM_OA_TSCL_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MXmodel[i].MC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(33, MXmodel[i].LKATSCLMXID, token);
                if (FJ.Length == 0)
                {
                    MessageInfo info2 = new MessageInfo();
                    info2.Key = "0";
                    info2.Value = "至少上传一个附件";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(info2);
                }
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_TSCL_IMG temp = new CRM_OA_TSCL_IMG();
                    temp.IMGML = FJ[j].ML;
                    temp.IMGMS = MXmodel[i].MC;
                    all_img.Add(temp);
                }



            }

            list.OPINION = all_opinion.ToArray();
            list.IMG = all_img.ToArray();



            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int j = 0; j < MXmodel.Length; j++)
                {
                    MXmodel[j].ISACTIVE = 20;
                    crmModels.COST_LKAFYMXTSCL.Update(MXmodel[j], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = MXmodel[j].LKATSCLMXID;
                    model.OACSLB = 1361;
                    model.OAZT = 1;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }

        [HttpPost]
        public string Data_Submit_TSCL_HX(string mxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXTSCL[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXTSCL[]>(mxdata);
            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = MXmodel[0].LKAFYTTID;
            CRM_COST_LKAFYTT TTdata = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token)[0];

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(16, token)[0].CS.ToString();

            CRM_OA_TSCL list = new CRM_OA_TSCL();
            list.HTYEAR = TTdata.HTYEAR;
            list.YWY = TTdata.YWYNAME;
            list.JXSNAME = TTdata.JXSNAME;
            list.JXSSAPSN = TTdata.JXSSAPSN;
            list.LKANAME = TTdata.LKANAME;
            list.LKACRMID = TTdata.LKACRMID;
            list.MDSL = TTdata.MDSL.ToString();
            list.YSPFY = TTdata.YSPNDJE.ToString();
            list.LJSPFY = TTdata.LJSQJE_TSCL.ToString();
            list.YHXFY = TTdata.YHXNDJE.ToString();
            list.FYLX = "特殊陈列费";
            list.BELONGKA = crmModels.KH_KH.Read(TTdata.LKAID, token).BELONGKA == 1 ? "是" : "否";
            list.LCLX = "核销";
            list.BDLX = "2";
            list.JXSSAPSN2 = TTdata.JXSSAPSN2;
            list.YHXFY2 = TTdata.YHXSJFY.ToString();

            list.TSCL_MX = new CRM_OA_TSCL_MX[MXmodel.Length];
            //int MDSL = 0, KHID = 0;

            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.TSCL_MX[i] = new CRM_OA_TSCL_MX();
                //if (MXmodel[i].KHID != KHID)
                //{
                //    KHID = MXmodel[i].KHID;
                //    MDSL++;
                //}
                //list.TSCL_MX[i].MDSL = MDSL.ToString();
                list.TSCL_MX[i].MDMC = MXmodel[i].MC;
                list.TSCL_MX[i].DISPLAY = MXmodel[i].CLFSDES;
                list.TSCL_MX[i].BEGINDATE = MXmodel[i].BEGINDATE;
                list.TSCL_MX[i].ENDDATE = MXmodel[i].ENDDATE;
                list.TSCL_MX[i].SQFY = MXmodel[i].SQFYJE.ToString();
                list.TSCL_MX[i].YJXS = MXmodel[i].YJXS.ToString();
                list.TSCL_MX[i].YJFB = MXmodel[i].YJFB.ToString() + "%";
                list.TSCL_MX[i].BEIZ = MXmodel[i].BEIZ;
                list.TSCL_MX[i].RCYJXS = MXmodel[i].RCYJXS.ToString();
                list.TSCL_MX[i].MDCRMID = MXmodel[i].CRMID;
                list.TSCL_MX[i].SJFY = MXmodel[i].SJFY.ToString();
                list.TSCL_MX[i].SJXS = MXmodel[i].SJXS.ToString();
                list.TSCL_MX[i].SJFB = MXmodel[i].SJFB.ToString() + "%";
                list.TSCL_MX[i].HDJSZJ = MXmodel[i].HDJSZJ;
            }






            List<CRM_OA_TSCL_IMG> all_img = new List<CRM_OA_TSCL_IMG>();
            List<CRM_OA_TSCL_OPINION> all_opinion = new List<CRM_OA_TSCL_OPINION>();
            for (int i = 0; i < MXmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 4205;
                cx_opinion.OACSBH = MXmodel[i].LKATSCLMXID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_TSCL_OPINION temp = new CRM_OA_TSCL_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MXmodel[i].MC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(43, MXmodel[i].LKATSCLMXID, token);
                if(FJ.Length == 0)
                {
                    MessageInfo info2 = new MessageInfo();
                    info2.Key = "0";
                    info2.Value = "至少上传一个核销附件";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(info2);
                }
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_TSCL_IMG temp = new CRM_OA_TSCL_IMG();
                    temp.IMGML = FJ[j].ML;
                    temp.IMGMS = MXmodel[i].MC;
                    all_img.Add(temp);
                }



            }

            list.OPINION = all_opinion.ToArray();
            list.IMG = all_img.ToArray();



            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int j = 0; j < MXmodel.Length; j++)
                {
                    MXmodel[j].ISACTIVE = 50;
                    crmModels.COST_LKAFYMXTSCL.Update(MXmodel[j], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = MXmodel[j].LKATSCLMXID;
                    model.OACSLB = 4205;
                    model.OAZT = 3;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }

        [HttpPost]
        public string Data_Submit_ZZF(int TTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT cxmodel = new CRM_COST_ZZFTT();
            cxmodel.TTID = TTID;
            CRM_COST_ZZFTT TTmodel = crmModels.COST_ZZFTT.ReadByParam(cxmodel, 0, token)[0];
            if (TTmodel.ZZLX == 1304)
            {
                CRM_HG_WJJL[] WJmodel = crmModels.HG_WJJL.Read(22, TTID, token);
                if (WJmodel.Length == 0)
                {
                    MessageInfo rm = new MessageInfo();
                    rm.Key = "0";
                    rm.Value = "制作类型为店招时，周围环境照片不允许为空！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rm);
                }
            }


            CRM_COST_ZZFMX cxmodel2 = new CRM_COST_ZZFMX();
            cxmodel2.TTID = TTID;
            CRM_COST_ZZFMX[] MXmodel = crmModels.COST_ZZFMX.ReadByParam(cxmodel2, token);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(17, token)[0].CS.ToString();

            CRM_OA_ZZF list = new CRM_OA_ZZF();
            list.ZZLX = TTmodel.ZZLXDES;


            switch (TTmodel.KHXZ)
            {
                case 10:
                    list.KHXZ = "潜在客户";
                    break;
                case 20:
                    list.KHXZ = "签约客户";
                    break;
                case 30:
                    list.KHXZ = "非签约客户";
                    break;
                default:
                    list.KHXZ = "";
                    break;
            }
            list.KHLX = TTmodel.KHLXDES;
            list.PKHMC = TTmodel.PKHIDDES;
            list.KHMC = TTmodel.MCNAME;
            list.ADDRESS = TTmodel.GGADDRESS;
            list.LXR = TTmodel.LXR;
            list.LXDH = TTmodel.LXDH;
            list.QKSM = TTmodel.QKSM;
            list.WZPG = TTmodel.WZPG;
            list.SALE_BEFORE = TTmodel.ZZQYDXS.ToString();
            list.SALE_AFTER = TTmodel.ZZHYDXS.ToString();
            list.CXY = TTmodel.SFYCXYZC == 1 ? "是" : "否";
            list.CXYFY = TTmodel.CXYFY.ToString();
            list.HAVEDISPLAYCOST = TTmodel.SFCSCLFY == 1 ? "是" : "否";
            list.DISPLAYCOST = TTmodel.CLFY.ToString();
            list.POPULATION = TTmodel.XQRK;
            list.DISCOUNT = TTmodel.GGJL;
            list.ADVER_COUNT = TTmodel.GGSL.ToString();
            list.ZZFXJ = TTmodel.ZZF.ToString();
            list.ZLF = TTmodel.GGZLF.ToString();
            list.BEGINDATE = TTmodel.ZLSTARTTIME;
            list.ENDDATE = TTmodel.ZLENDTIME;
            list.SQJE = TTmodel.SQJEAll.ToString();
            list.GGGSMC = TTmodel.GGGSMCALL;

            list.ZZF_MX = new CRM_OA_ZZF_MX[MXmodel.Length];
            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.ZZF_MX[i] = new CRM_OA_ZZF_MX();
                list.ZZF_MX[i].ITEM = MXmodel[i].GGXMIDDES;
                list.ZZF_MX[i].MJ = MXmodel[i].QUANTITY.ToString();
                list.ZZF_MX[i].PRICE = MXmodel[i].PRICE.ToString();
                list.ZZF_MX[i].XJ = MXmodel[i].AMOUNT.ToString();
                list.ZZF_MX[i].BEIZ = MXmodel[i].BEIZ;
            }

            //历史审批意见
            CRM_OA_OPINION OPINION_cx = new CRM_OA_OPINION();
            OPINION_cx.OACSLB = 1362;
            OPINION_cx.OACSBH = TTmodel.TTID;
            CRM_OA_OPINION[] OPINION = crmModels.OA_OPINION.ReadByParam(OPINION_cx, token);
            list.OPINION = new CRM_OA_ZZF_OPINION[OPINION.Length];
            for (int i = 0; i < OPINION.Length; i++)
            {
                list.OPINION[i] = new CRM_OA_ZZF_OPINION();
                list.OPINION[i].OPINION = OPINION[i].SPSJ + " " + OPINION[i].SPRNAME + " " + OPINION[i].ATTITUDE + " " + OPINION[i].OPINION;
                list.OPINION[i].HFNR = OPINION[i].HFSJ + " " + OPINION[i].STAFFNAME + " 回复内容： " + OPINION[i].HFNR;
            }



            List<CRM_OA_ZZF_IMG> all_img = new List<CRM_OA_ZZF_IMG>();


            CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(22, TTmodel.TTID, token);
            for (int j = 0; j < FJ.Length; j++)
            {
                CRM_OA_ZZF_IMG temp = new CRM_OA_ZZF_IMG();
                temp.IMGML = FJ[j].ML;
                temp.IMGMS = "周围环境照片";
                all_img.Add(temp);
            }

            CRM_HG_WJJL[] FJ2 = crmModels.HG_WJJL.Read(34, TTmodel.TTID, token);
            for (int j = 0; j < FJ2.Length; j++)
            {
                CRM_OA_ZZF_IMG temp = new CRM_OA_ZZF_IMG();
                temp.IMGML = FJ2[j].ML;
                temp.IMGMS = "广告效果图";
                all_img.Add(temp);
            }

            CRM_HG_WJJL[] FJ3 = crmModels.HG_WJJL.Read(35, TTmodel.TTID, token);
            for (int j = 0; j < FJ3.Length; j++)
            {
                CRM_OA_ZZF_IMG temp = new CRM_OA_ZZF_IMG();
                temp.IMGML = FJ3[j].ML;
                temp.IMGMS = "制作前照片";
                all_img.Add(temp);
            }

            //CRM_HG_WJJL[] FJ4 = crmModels.HG_WJJL.Read(36, TTmodel.TTID, token);
            //for (int j = 0; j < FJ4.Length; j++)
            //{
            //    CRM_OA_ZZF_IMG temp = new CRM_OA_ZZF_IMG();
            //    temp.IMGML = FJ4[j].ML;
            //    temp.IMGMS = "广告完成画面";
            //    all_img.Add(temp);
            //}



            CRM_COST_ZZFSJT cxsjt = new CRM_COST_ZZFSJT();
            cxsjt.TTID = TTmodel.TTID;
            CRM_COST_ZZFSJT[] SJT = crmModels.COST_ZZFSJT.ReadByParam(cxsjt, token);
            for (int j = 0; j < SJT.Length; j++)
            {
                CRM_HG_WJJL[] FJ5 = crmModels.HG_WJJL.Read(37, SJT[j].SJTID, token);
                for (int k = 0; k < FJ5.Length; k++)
                {
                    CRM_OA_ZZF_IMG temp = new CRM_OA_ZZF_IMG();
                    temp.IMGML = FJ5[k].ML;
                    temp.IMGMS = "广告设计图照片";
                    all_img.Add(temp);
                }
            }



            list.IMG = all_img.ToArray();






            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {


                TTmodel.ISACTIVE = 20;
                crmModels.COST_ZZFTT.Update(TTmodel, token);



                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = TTID;
                model.OACSLB = 1362;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }

        [HttpPost]
        public string Data_Insert_LKAFYMXTSCL(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXTSCL model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXTSCL>(data);
            model.XGR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;


            CRM_COST_LKAFYTT cxmodel = new CRM_COST_LKAFYTT();
            cxmodel.LKAFYTTID = model.LKAFYTTID;
            CRM_COST_LKAFYTT TTmodel = crmModels.COST_LKAFYTT.ReadByParam(cxmodel, 0, token)[0];


            CRM_COST_GETCOST COST = crmModels.COST_LKAYEARCOST.GetCost(TTmodel.LKAID, TTmodel.HTYEAR, token);

            CRM_COST_LKAYEARTT cxmodel2 = new CRM_COST_LKAYEARTT();
            cxmodel2.LKAID = TTmodel.LKAID;
            cxmodel2.HTYEAR = TTmodel.HTYEAR;
            CRM_COST_LKAYEARTT[] YearCost = crmModels.COST_LKAYEARTT.ReadByParam(cxmodel2, 0, token);

            if (YearCost.Length != 0 && YearCost[0].ISACTIVE >= 45)      //有年度费用
            {
                if (model.COSTITEMID == 10)          //特殊陈列费
                {
                    if (Convert.ToDecimal(model.SQFYJE) > (COST.TSCL_SP - COST.TSCL_SQ))         //
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "超过年度费用的审批金额！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }
            }



            int i = crmModels.COST_LKAFYMXTSCL.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAFYMXTSCL(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXTSCL model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXTSCL>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_LKAFYMXTSCL.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAFYMXTSCL(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXTSCL model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXTSCL>(cxdata);
            CRM_COST_LKAFYMXTSCL[] data = crmModels.COST_LKAFYMXTSCL.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_LKAFYMXTSCL_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAFYMXTSCL model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAFYMXTSCL>(cxdata);
            CRM_COST_LKAFYMXTSCL[] data = crmModels.COST_LKAFYMXTSCL.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAFYMXTSCL(int LKATSCLMXID, int LKAFYTTID)
        {
            token = appClass.CRM_Gettoken();

            //CRM_COST_LKAFYMXTSCL cxmodel = new CRM_COST_LKAFYMXTSCL();
            //cxmodel.LKAFYTTID = LKAFYTTID;
            //CRM_COST_LKAFYMXTSCL[] data = crmModels.COST_LKAFYMXTSCL.ReadByParam(cxmodel, token);
            //for (int j = 0; j < data.Length; j++)
            //{
            //    if (data[j].ISACTIVE != 10)
            //    {
            //        webmsg.KEY = 0;
            //        webmsg.MSG = "存在已审核的数据！";
            //        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            //    }
            //}

            int i = crmModels.COST_LKAFYMXTSCL.Delete(LKATSCLMXID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_LKAHXZLTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLTT>(data);

            CRM_COST_LKAHXZLTT cxmodel = new CRM_COST_LKAHXZLTT();
            cxmodel.LKAID = model.LKAID;
            cxmodel.HTYEAR = model.HTYEAR;
            CRM_COST_LKAHXZLTT[] xianyou = crmModels.COST_LKAHXZLTT.ReadByParam(cxmodel, 0, token);
            if (xianyou.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "数据重复！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            model.JXSID = crmModels.KH_KH.ReadJXSByKHID(model.LKAID, token).KHID;
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;


            cxmodel.BEGINDATE = model.BEGINDATE;
            cxmodel.ENDDATE = model.ENDDATE;
            CRM_COST_LKAHXZLTT info = crmModels.COST_LKAHXZLTT.ReadTTGLinfo(cxmodel, token);

            model.SPJE = info.SPJE;
            model.YHXJE = info.YHXJE;
            model.LKAXSSJLX = info.LKAXSSJLX;
            model.HTNDYGXS = info.HTNDYGXS;
            model.MQLKAXSSJ = info.MQLKAXSSJ;
            model.LKABNDWCL = info.LKABNDWCL;
            model.LKAYJCMDSL = info.LKAYJCMDSL;
            model.CRMBAMD = info.CRMBAMD;

            int i = crmModels.COST_LKAHXZLTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAHXZLTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLTT>(data);

            CRM_COST_LKAHXZLTT cxmodel = new CRM_COST_LKAHXZLTT();
            cxmodel.HXZLTTID = model.HXZLTTID;
            CRM_COST_LKAHXZLTT TTdata = crmModels.COST_LKAHXZLTT.ReadByParam(cxmodel, 0, token)[0];
            TTdata.SPZT = model.SPZT;
            TTdata.OPINION = model.OPINION;



            TTdata.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_LKAHXZLTT.Update(TTdata, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAHXZLTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLTT>(cxdata);
            CRM_COST_LKAHXZLTT[] data = crmModels.COST_LKAHXZLTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }



        [HttpPost]
        public string Data_Delete_LKAHXZLTT(int HXZLTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX[] data = crmModels.COST_LKAHXZLMX.ReadByTTID(HXZLTTID, token);
            for (int j = 0; j < data.Length; j++)
            {
                if (data[j].ISACTIVE != 10)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "存在已提交审核的数据！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                CRM_COST_LKAHXZLMX_LKAHXDJMX cxmodel2 = new CRM_COST_LKAHXZLMX_LKAHXDJMX();
                cxmodel2.HXZLMXID = data[j].HXZLMXID;
                CRM_COST_LKAHXZLMX_LKAHXDJMX[] conndata = crmModels.COST_LKAHXZLMX_LKAHXDJMX.ReadByParam(cxmodel2, token);
                if (conndata.Length != 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "存在已核销的数据！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }



            int i = crmModels.COST_LKAHXZLTT.Delete(HXZLTTID, token);
            webmsg.KEY = i;



            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_LKAHXZLMX(string data, int COSTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX>(data);


            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;
            int i = crmModels.COST_LKAHXZLMX.Create(model, token);

            CRM_COST_LKAYEARCOST_LKAHXZLMX connModel = new CRM_COST_LKAYEARCOST_LKAHXZLMX();
            connModel.HXZLMXID = i;
            connModel.COSTITEMID = model.COSTITEMID;
            connModel.COSTID = COSTID;
            crmModels.COST_LKAYEARCOST_LKAHXZLMX.Create(connModel, token);


            webmsg.KEY = i;


            if (model.COSTITEMID == 11 || model.COSTITEMID == 12)
            {
                //新增海报费时，需要把同一个TT下对应的堆头费也一起新增进去，反之同理
                model.COSTITEMID = 23 - model.COSTITEMID;       //把堆头或海报的COSTITEMID换成另一个

                CRM_COST_LKAFYMXDT cxmodel = new CRM_COST_LKAFYMXDT();
                cxmodel.LKAFYTTID = model.LKAFYTTID;
                cxmodel.COSTITEMID = model.COSTITEMID;
                cxmodel.ISACTIVE = 30;
                CRM_COST_LKAFYMXDT[] another = crmModels.COST_LKAFYMXDT.ReadByParam(cxmodel, token);
                if (another.Length == 1)
                {


                    model.FYSPJE = another[0].CXFY;
                    model.FYYHXJE = 0;
                    model.FYBCSQJE = another[0].CXFY;
                    model.SJXS = 0;
                    int ii = crmModels.COST_LKAHXZLMX.Create(model, token);

                    CRM_COST_LKAYEARCOST_LKAHXZLMX connModel2 = new CRM_COST_LKAYEARCOST_LKAHXZLMX();
                    connModel2.HXZLMXID = ii;
                    connModel2.COSTITEMID = model.COSTITEMID;
                    connModel2.COSTID = another[0].LKADTMXID;
                    crmModels.COST_LKAYEARCOST_LKAHXZLMX.Create(connModel2, token);
                }

            }




            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAHXZLMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_LKAHXZLMX.Update(model, token);
            webmsg.KEY = i;

            if (model.COSTITEMID == 11 || model.COSTITEMID == 12)
            {
                //修改海报费时，需要把同一个TT下对应的堆头费也一起修改，反之同理
                model.COSTITEMID = 23 - model.COSTITEMID;       //把堆头或海报的COSTITEMID换成另一个

                CRM_COST_LKAHXZLMX cxmodel = new CRM_COST_LKAHXZLMX();
                cxmodel.LKAFYTTID = model.LKAFYTTID;
                cxmodel.COSTITEMID = model.COSTITEMID;
                cxmodel.COSTITEMIDSTR = "11,12";
                CRM_COST_LKAHXZLMX[] another = crmModels.COST_LKAHXZLMX.ReadByParam(cxmodel, token);
                if (another.Length == 1)
                {

                    model.HXZLMXID = another[0].HXZLMXID;
                    model.FYSPJE = another[0].FYSPJE;
                    model.FYYHXJE = another[0].FYYHXJE;
                    model.FYBCSQJE = another[0].FYBCSQJE;
                    model.SJXS = 0;
                    int ii = crmModels.COST_LKAHXZLMX.Update(model, token);

                }
            }





            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_LKAHXZLMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX[]>(data);

            for (int i = 0; i < model.Length; i++)
            {
                if (model[i].COSTITEMID == 14)
                {
                    CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(19, model[i].HXZLMXID, token);
                    if (FJ.Length == 0)
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "请提交广告完成画面！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }





                model[i].ISACTIVE = 20;
                int ii = crmModels.COST_LKAHXZLMX.Update(model[i], token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "提交失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }

                if (model[i].COSTITEMID == 11 || model[i].COSTITEMID == 12)
                {
                    //提交海报费时，需要把同一个TT下对应的堆头费也一起提交，反之同理
                    model[i].COSTITEMID = 23 - model[i].COSTITEMID;       //把堆头或海报的COSTITEMID换成另一个

                    CRM_COST_LKAHXZLMX cxmodel = new CRM_COST_LKAHXZLMX();
                    cxmodel.LKAFYTTID = model[i].LKAFYTTID;
                    cxmodel.COSTITEMID = model[i].COSTITEMID;
                    cxmodel.COSTITEMIDSTR = "11,12";
                    CRM_COST_LKAHXZLMX[] another = crmModels.COST_LKAHXZLMX.ReadByParam(cxmodel, token);
                    if (another.Length == 1)
                    {
                        another[0].ISACTIVE = 20;
                        int iii = crmModels.COST_LKAHXZLMX.Update(another[0], token);
                        if (iii <= 0)
                        {
                            webmsg.KEY = iii;
                            webmsg.MSG = "提交失败2！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }

                }

            }




            webmsg.KEY = 1;

            if (webmsg.KEY > 0)
                webmsg.MSG = "提交成功！";
            else
                webmsg.MSG = "提交失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_SH_LKAHXZLMX(string data, string check)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX[]>(data);

            for (int i = 0; i < model.Length; i++)
            {
                model[i].ISACTIVE = 30;
                model[i].FYHXYHCNR = check;
                int ii = crmModels.COST_LKAHXZLMX.Update(model[i], token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "审核失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                if (model[i].COSTITEMID == 11 || model[i].COSTITEMID == 12)
                {
                    //审核海报费时，需要把同一个TT下对应的堆头费也一起审核，反之同理
                    model[i].COSTITEMID = 23 - model[i].COSTITEMID;       //把堆头或海报的COSTITEMID换成另一个

                    CRM_COST_LKAHXZLMX cxmodel = new CRM_COST_LKAHXZLMX();
                    cxmodel.LKAFYTTID = model[i].LKAFYTTID;
                    cxmodel.COSTITEMID = model[i].COSTITEMID;
                    cxmodel.COSTITEMIDSTR = "11,12";
                    CRM_COST_LKAHXZLMX[] another = crmModels.COST_LKAHXZLMX.ReadByParam(cxmodel, token);
                    if (another.Length == 1)
                    {
                        another[0].ISACTIVE = 30;
                        another[0].FYHXYHCNR = check;
                        int iii = crmModels.COST_LKAHXZLMX.Update(another[0], token);
                        if (iii <= 0)
                        {
                            webmsg.KEY = iii;
                            webmsg.MSG = "审核失败2！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }
                }



            }



            webmsg.KEY = 1;


            if (webmsg.KEY > 0)
                webmsg.MSG = "审核成功！";
            else
                webmsg.MSG = "审核失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_BACK_LKAHXZLMX(string data, string check)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX[]>(data);

            for (int i = 0; i < model.Length; i++)
            {
                model[i].ISACTIVE = 15;
                model[i].FYHXYHCNR = check;
                int ii = crmModels.COST_LKAHXZLMX.Update(model[i], token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "回退失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                if (model[i].COSTITEMID == 11 || model[i].COSTITEMID == 12)
                {
                    //回退海报费时，需要把同一个TT下对应的堆头费也一起回退，反之同理
                    model[i].COSTITEMID = 23 - model[i].COSTITEMID;       //把堆头或海报的COSTITEMID换成另一个

                    CRM_COST_LKAHXZLMX cxmodel = new CRM_COST_LKAHXZLMX();
                    cxmodel.LKAFYTTID = model[i].LKAFYTTID;
                    cxmodel.COSTITEMID = model[i].COSTITEMID;
                    cxmodel.COSTITEMIDSTR = "11,12";
                    CRM_COST_LKAHXZLMX[] another = crmModels.COST_LKAHXZLMX.ReadByParam(cxmodel, token);
                    if (another.Length == 1)
                    {
                        another[0].ISACTIVE = 15;
                        another[0].FYHXYHCNR = check;
                        int iii = crmModels.COST_LKAHXZLMX.Update(another[0], token);
                        if (iii <= 0)
                        {
                            webmsg.KEY = iii;
                            webmsg.MSG = "回退失败2！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }
                }
            }



            webmsg.KEY = 1;


            if (webmsg.KEY > 0)
                webmsg.MSG = "回退成功！";
            else
                webmsg.MSG = "回退失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAHXZLMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX>(cxdata);
            CRM_COST_LKAHXZLMX[] data = crmModels.COST_LKAHXZLMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_LKAHXZLMXinfo(string cxdata, string HTYEAR, int LKAID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX>(cxdata);
            CRM_COST_LKAHXZLMX data = crmModels.COST_LKAHXZLMX.ReadMXinfo(model, HTYEAR, LKAID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_LKAHXZLMX_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX>(cxdata);
            CRM_COST_LKAHXZLMX[] data = crmModels.COST_LKAHXZLMX.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAHXZLMX(int HXZLMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAHXZLMX.Delete(HXZLMXID, token);
            webmsg.KEY = i;

            crmModels.COST_LKAYEARCOST_LKAHXZLMX.DeleteByHXZLMXID(HXZLMXID, token);

            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_LKAHXZLMX_alter(int HXZLMXID, int LKAFYTTID)
        {
            token = appClass.CRM_Gettoken();


            CRM_COST_LKAHXZLMX cxmodel = new CRM_COST_LKAHXZLMX();
            cxmodel.LKAFYTTID = LKAFYTTID;
            cxmodel.COSTITEMIDSTR = "11,12";
            CRM_COST_LKAHXZLMX[] data = crmModels.COST_LKAHXZLMX.ReadByParam(cxmodel, token);
            for (int j = 0; j < data.Length; j++)
            {
                //删除关联表的数据
                crmModels.COST_LKAYEARCOST_LKAHXZLMX.DeleteByHXZLMXID(data[j].HXZLMXID, token);
            }

            int i = crmModels.COST_LKAHXZLMX.DeleteByLKAFYTTID(LKAFYTTID, token);     //根据LKAFYTTID删除同一个活动下的堆头海报
            webmsg.KEY = i;

            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_LKAHXZLMD(string data, int HXZLMXID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHList[] KHmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHList[]>(data);

            CRM_COST_LKAHXZLMD cxmodel = new CRM_COST_LKAHXZLMD();
            cxmodel.HXZLMXID = HXZLMXID;
            CRM_COST_LKAHXZLMD[] MDdata = crmModels.COST_LKAHXZLMD.ReadByParam(cxmodel, token);
            if (MDdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "只允许关联一家门店！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            CRM_COST_LKAHXZLMD model = new CRM_COST_LKAHXZLMD();
            model.HXZLMXID = HXZLMXID;
            model.KHID = KHmodel[0].KHID;
            int i = crmModels.COST_LKAHXZLMD.Create(model, token);

            if (i <= 0)
            {
                webmsg.KEY = i;
                webmsg.MSG = "新增失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            webmsg.KEY = 1;
            webmsg.MSG = "新增成功！";

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAHXZLMD(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMD>(data);
            int i = crmModels.COST_LKAHXZLMD.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAHXZLMD(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMD>(cxdata);
            CRM_COST_LKAHXZLMD[] data = crmModels.COST_LKAHXZLMD.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAHXZLMD(int HXZLMDMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAHXZLMD.Delete(HXZLMDMXID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_LKAYEARCOST_LKAHXZLMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARCOST_LKAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARCOST_LKAHXZLMX>(data);
            int i = crmModels.COST_LKAYEARCOST_LKAHXZLMX.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Select_LKAYEARCOST_LKAHXZLMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARCOST_LKAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARCOST_LKAHXZLMX>(cxdata);
            CRM_COST_LKAYEARCOST_LKAHXZLMX[] data = crmModels.COST_LKAYEARCOST_LKAHXZLMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAYEARCOST_LKAHXZLMX(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAYEARCOST_LKAHXZLMX.Delete(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_LKAHXDJTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXDJTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXDJTT>(data);

            CRM_COST_LKAHXDJTT cxmodel = new CRM_COST_LKAHXDJTT();
            cxmodel.LKAID = model.LKAID;
            cxmodel.HTYEAR = model.HTYEAR;
            CRM_COST_LKAHXDJTT[] xianyou = crmModels.COST_LKAHXDJTT.ReadByParam(cxmodel, 0, token);
            if (xianyou.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "数据重复！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }



            model.JXSID = crmModels.KH_KH.ReadJXSByKHID(model.LKAID, token).KHID;


            //找到对应的年度费用的数据
            CRM_COST_LKAYEARTT cx = new CRM_COST_LKAYEARTT();
            cx.LKAID = model.LKAID;
            cx.HTYEAR = model.HTYEAR;
            CRM_COST_LKAYEARTT[] LKAyear = crmModels.COST_LKAYEARTT.ReadByParam(cx, 0, token);
            if (LKAyear.Length == 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "没有对应的年度费用信息！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            if (LKAyear.Length > 1)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "存在多条对应的年度费用信息！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            model.BEGINDATE = LKAyear[0].BEGINDATE;
            model.ENDDATE = LKAyear[0].ENDDATE;
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_LKAHXDJTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAHXDJTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXDJTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXDJTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_LKAHXDJTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAHXDJTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXDJTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXDJTT>(cxdata);
            CRM_COST_LKAHXDJTT[] data = crmModels.COST_LKAHXDJTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAHXDJTT(int HXDJTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAHXDJTT.Delete(HXDJTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_LKAHXDJMX(string data, int HXZLMXID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXDJMX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_LKAHXDJMX.Create(model, token);
            webmsg.KEY = i;

            if (model.COSTITEMID == 14)
            {
                //制作费
                CRM_COST_ZZFTT_LKAHXDJMX connModel = new CRM_COST_ZZFTT_LKAHXDJMX();
                connModel.HXDJMXID = i;
                connModel.TTID = HXZLMXID;
                crmModels.COST_ZZFTT_LKAHXDJMX.Create(connModel, token);
            }
            else
            {
                CRM_COST_LKAHXZLMX_LKAHXDJMX nonnModel = new CRM_COST_LKAHXZLMX_LKAHXDJMX();
                nonnModel.HXZLMXID = HXZLMXID;
                nonnModel.HXDJMXID = i;
                crmModels.COST_LKAHXZLMX_LKAHXDJMX.Create(nonnModel, token);
            }




            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_LKAHXDJMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXDJMX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_LKAHXDJMX.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_LKAHXDJMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXDJMX>(cxdata);
            CRM_COST_LKAHXDJMX[] data = crmModels.COST_LKAHXDJMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAHXDJMX(int HXDJMXID, int COSTITEMID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAHXDJMX.Delete(HXDJMXID, token);
            webmsg.KEY = i;

            if (COSTITEMID == 14)
            {
                //制作费
                crmModels.COST_ZZFTT_LKAHXDJMX.DeleteByHXDJMXID(HXDJMXID, token);
            }
            else
            {
                crmModels.COST_LKAHXZLMX_LKAHXDJMX.DeleteByHXDJMXID(HXDJMXID, token);
            }



            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_LKAHXZLMX_LKAHXDJMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX_LKAHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX_LKAHXDJMX>(data);
            int i = crmModels.COST_LKAHXZLMX_LKAHXDJMX.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Select_LKAHXZLMX_LKAHXDJMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX_LKAHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX_LKAHXDJMX>(cxdata);
            CRM_COST_LKAHXZLMX_LKAHXDJMX[] data = crmModels.COST_LKAHXZLMX_LKAHXDJMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_LKAHXZLMX_LKAHXDJMX(CRM_COST_LKAHXZLMX_LKAHXDJMX model)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_LKAHXZLMX_LKAHXDJMX.Delete(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_ZZFTT_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(cxdata);
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_ZZFTT_Unconnected2(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(cxdata);
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.Read_Unconnected2(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_ZZFTT_LKAUnconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(cxdata);
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.Read_LKAUnconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_ZZFTT_KAUnconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(cxdata);
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.Read_KAUnconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Insert_FI(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_FI model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_FI>(data);
            model.ISACTIVE = 1;
            model.CJR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_FI.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_FI(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_FI model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_FI>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_FI.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_FI(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_FI model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_FI>(cxdata);
            CRM_COST_FI[] data = crmModels.COST_FI.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_FI(int CWHSBH)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_FI.Delete(CWHSBH, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_COST_CLFTT_STAFF(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT_STAFF>(data);
            model.CJR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CLFTT_STAFF.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_COST_CLFTT_STAFF(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT_STAFF>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CLFTT_STAFF.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_COST_CLFTT_STAFF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CLFTT_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFTT_STAFF>(cxdata);
            CRM_COST_CLFTT_STAFF[] data = crmModels.COST_CLFTT_STAFF.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_COST_CLFTT_STAFF(int ID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CLFTT_STAFF.Delete(ID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_CBZX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CBZX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CBZX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_CBZX.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_CBZX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CBZX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CBZX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CBZX.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_CBZX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CBZX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CBZX>(cxdata);
            CRM_COST_CBZX[] data = crmModels.COST_CBZX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_CBZX(string CBZXBH)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CBZX.Delete(CBZXBH, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Get_SAP_CPFL(string MATNR)
        {
            token = appClass.CRM_Gettoken();
            string CPFL = crmModels.SAP_Report.SAP_CPFL(MATNR, token);
            return CPFL;

        }

        [HttpPost]
        public string Data_Select_Opinion(int OACSBH, int OACSLB)
        {
            token = appClass.CRM_Gettoken();
            CRM_OA_OPINION cxmodel = new CRM_OA_OPINION();
            cxmodel.OACSLB = OACSLB;
            cxmodel.OACSBH = OACSBH;
            CRM_OA_OPINION[] data = crmModels.OA_OPINION.ReadByParam(cxmodel, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_Opinion(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_OA_OPINION model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_OA_OPINION>(data);
            model.STAFFID = appClass.CRM_GetStaffid();
            model.HFSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int i = crmModels.OA_OPINION.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "回复成功！";
            else
                webmsg.MSG = "回复失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_CostTime(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAHXZLMX>(cxdata);
            CRM_COST_LKAHXZLMX data = crmModels.COST_LKAHXZLMX.Read_CostTime(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Insert_KAYEARTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAYEARTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAYEARTT>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;


            CRM_COST_KAYEARTT cx_kayear = new CRM_COST_KAYEARTT();
            cx_kayear.HTYEAR = model.HTYEAR;
            cx_kayear.KHID = model.KHID;
            CRM_COST_KAYEARTT[] res = crmModels.COST_KAYEARTT.ReadByParam(cx_kayear, 0, token);
            if (res.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "数据重复！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            cx_kayear.HTYEAR = "";
            cx_kayear.BEGINDATE = model.BEGINDATE;
            cx_kayear.ENDDATE = model.ENDDATE;
            int count = crmModels.COST_KAYEARTT.Verify(cx_kayear, token);
            if (count != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "年度费用起止日期与现有数据重复！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }



            //allcount是两个时间点的跨度的月份总数，然后根据过15算一个月的原则把不算的月份删掉
            int allcount = (Convert.ToDateTime(model.ENDDATE).Year - Convert.ToDateTime(model.BEGINDATE).Year) * 12 + (Convert.ToDateTime(model.ENDDATE).Month - Convert.ToDateTime(model.BEGINDATE).Month) + 1;
            if (Convert.ToDateTime(model.BEGINDATE).Day > 15)
            {
                allcount--;
            }
            if (Convert.ToDateTime(model.ENDDATE).Day < 15)
            {
                allcount--;
            }
            model.MONTHCOUNT = allcount;

            model.YEAR_THIS = model.HTYEAR;

            CRM_COST_KAYEARTT cxmodel = new CRM_COST_KAYEARTT();
            cxmodel.KHID = model.KHID;
            cxmodel.HTYEAR = (Convert.ToInt32(model.HTYEAR) - 1).ToString();
            CRM_COST_KAYEARTT[] old = crmModels.COST_KAYEARTT.ReadByParam(cxmodel, 0, token);
            if (old.Length != 0)
            {
                model.YEAR_LAST = old[0].YEAR_THIS;
                model.ZQ_LAST = old[0].ZQ_THIS;
                model.MDSL_LAST = old[0].MDSL_THIS;
                model.POS_LAST = old[0].POS_THIS;
                model.JH_LAST = old[0].JH_THIS;
                model.KP_LAST = old[0].KP_THIS;
            }
            else
            {
                model.YEAR_LAST = (Convert.ToInt32(model.HTYEAR) - 1).ToString();
            }




            int i = crmModels.COST_KAYEARTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KAYEARTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAYEARTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAYEARTT>(data);
            model.XGR = appClass.CRM_GetStaffid();


            if (model.ISACTIVE == 60)
                model.ISACTIVE = 45;

            int i = crmModels.COST_KAYEARTT.Update(model, token);


            if (i > 0)
            {
                CRM_COST_KAYEARCOST cxmodel = new CRM_COST_KAYEARCOST();
                cxmodel.KAYEARTTID = model.KAYEARTTID;
                CRM_COST_KAYEARCOST[] COST = crmModels.COST_KAYEARCOST.ReadByParam(cxmodel, token);
                for (int j = 0; j < COST.Length; j++)
                {
                    if (model.JH_LAST != 0)
                    {
                        COST[j].FYL_LAST = COST[j].WSJE_LAST / model.JH_LAST * 100;
                    }
                    if (model.JH_THIS != 0)
                    {
                        COST[j].FYL_THIS = COST[j].WSJEXG_THIS / model.JH_THIS * 100;
                    }
                    crmModels.COST_KAYEARCOST.Update(COST[j], token);
                }
            }





            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KAYEARTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAYEARTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAYEARTT>(cxdata);
            CRM_COST_KAYEARTT[] data = crmModels.COST_KAYEARTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KAYEARTT(int KAYEARTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KAYEARTT.Delete(KAYEARTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_KAYEAR(int KAYEARTTID, string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAYEARTT kayearmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAYEARTT>(data);
            kayearmodel.XGR = appClass.CRM_GetStaffid();


            if (kayearmodel.ISACTIVE == 60)
                kayearmodel.ISACTIVE = 45;

            int id = crmModels.COST_KAYEARTT.Update(kayearmodel, token);


            if (id > 0)
            {
                CRM_COST_KAYEARCOST cx_kayear = new CRM_COST_KAYEARCOST();
                cx_kayear.KAYEARTTID = kayearmodel.KAYEARTTID;
                CRM_COST_KAYEARCOST[] COST = crmModels.COST_KAYEARCOST.ReadByParam(cx_kayear, token);
                for (int j = 0; j < COST.Length; j++)
                {
                    if (kayearmodel.JH_LAST != 0)
                    {
                        COST[j].FYL_LAST = COST[j].JE_LAST / kayearmodel.JH_LAST * 100;
                    }
                    if (kayearmodel.JH_THIS != 0)
                    {
                        COST[j].FYL_THIS = COST[j].JEXG_THIS / kayearmodel.JH_THIS * 100;
                    }
                    crmModels.COST_KAYEARCOST.Update(COST[j], token);
                }
            }




            CRM_COST_KAYEARTT cxmodel = new CRM_COST_KAYEARTT();
            cxmodel.KAYEARTTID = KAYEARTTID;
            CRM_COST_KAYEARTT TTmodel = crmModels.COST_KAYEARTT.ReadByParam(cxmodel, 0, token)[0];
            CRM_COST_KAYEARCOST cxmodel2 = new CRM_COST_KAYEARCOST();
            cxmodel2.KAYEARTTID = KAYEARTTID;
            CRM_COST_KAYEARCOST[] MXmodel = crmModels.COST_KAYEARCOST.ReadByParam(cxmodel2, token);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(20, token)[0].CS.ToString();

            CRM_OA_KAYEAR list = new CRM_OA_KAYEAR();
            list.MC = TTmodel.MC;
            list.BEGINDATE = TTmodel.BEGINDATE;
            list.ENDDATE = TTmodel.ENDDATE;
            list.YEAR = TTmodel.YEAR_LAST;
            list.YEAR2 = TTmodel.YEAR_THIS;
            list.ZQ = TTmodel.ZQ_LAST;
            list.ZQ2 = TTmodel.ZQ_THIS;
            list.BEIZ1 = TTmodel.ZQ_BEIZ;
            list.MDSL = TTmodel.MDSL_LAST.ToString();
            list.MDSL2 = TTmodel.MDSL_THIS.ToString();
            list.BEIZ2 = TTmodel.MDSL_BEIZ;
            list.POS = TTmodel.POS_LAST.ToString();
            list.POS2 = TTmodel.POS_THIS.ToString();
            list.BEIZ3 = TTmodel.POS_BEIZ;
            list.JH = TTmodel.JH_LAST.ToString();
            list.JH2 = TTmodel.JH_THIS.ToString();
            list.BEIZ4 = TTmodel.JH_BEIZ;
            list.KP = TTmodel.KP_LAST.ToString();
            list.KP2 = TTmodel.KP_THIS.ToString();
            list.BEIZ5 = TTmodel.KP_BEIZ;


            list.KAYEARMX = new CRM_OA_KAYEARMX[MXmodel.Length];
            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.KAYEARMX[i] = new CRM_OA_KAYEARMX();
                list.KAYEARMX[i].ITEM = MXmodel[i].COSTITEMIDDES;
                list.KAYEARMX[i].HTTK = MXmodel[i].HTTK_LAST;
                list.KAYEARMX[i].JE = MXmodel[i].JE_LAST.ToString();
                list.KAYEARMX[i].FYL = (MXmodel[i].FYL_LAST / 100).ToString();
                list.KAYEARMX[i].HTTK2 = MXmodel[i].HTTK_THIS;
                list.KAYEARMX[i].JE2 = MXmodel[i].JE_THIS.ToString();
                list.KAYEARMX[i].JE2XG = MXmodel[i].JEXG_THIS.ToString();
                list.KAYEARMX[i].FYL2 = (MXmodel[i].FYL_THIS / 100).ToString();
                list.KAYEARMX[i].BEIZ = MXmodel[i].BEIZ;
            }

            CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(25, TTmodel.KAYEARTTID, token);
            list.IMG = new CRM_OA_KAYEAR_IMG[FJ.Length];
            for (int i = 0; i < FJ.Length; i++)
            {
                list.IMG[i] = new CRM_OA_KAYEAR_IMG();
                list.IMG[i].IMGML = FJ[i].ML;
            }

            CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
            cx_opinion.OACSLB = 2022;
            cx_opinion.OACSBH = TTmodel.KAYEARTTID;
            CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);

            list.OPINION = new CRM_OA_KAYEAR_OPINION[opinion.Length];
            for (int i = 0; i < opinion.Length; i++)
            {
                list.OPINION[i] = new CRM_OA_KAYEAR_OPINION();
                list.OPINION[i].OPINION = opinion[i].SPSJ + " " + opinion[i].SPRNAME + " " + opinion[i].ATTITUDE + " " + opinion[i].OPINION;
                list.OPINION[i].HFNR = opinion[i].HFSJ + " " + opinion[i].STAFFNAME + " 回复内容： " + opinion[i].HFNR;
            }


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                if (TTmodel.SUBMITCOUNT == 0)
                    TTmodel.ISACTIVE = 20;
                else
                    TTmodel.ISACTIVE = 50;

                crmModels.COST_KAYEARTT.Update(TTmodel, token);



                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = KAYEARTTID;
                model.OACSLB = 2022;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Data_Insert_KAYEARCOST(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAYEARCOST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAYEARCOST>(data);

            CRM_COST_KAYEARCOST cxmodel = new CRM_COST_KAYEARCOST();
            cxmodel.KAYEARTTID = model.KAYEARTTID;
            cxmodel.COSTITEMID = model.COSTITEMID;
            CRM_COST_KAYEARCOST[] xianyou = crmModels.COST_KAYEARCOST.ReadByParam(cxmodel, token);
            if (xianyou.Length > 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "该费用项目已存在！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }




            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_KAYEARCOST.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KAYEARCOST(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAYEARCOST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAYEARCOST>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KAYEARCOST.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KAYEARCOST(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAYEARCOST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAYEARCOST>(cxdata);
            CRM_COST_KAYEARCOST[] data = crmModels.COST_KAYEARCOST.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_KAYEARCOST_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAYEARCOST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAYEARCOST>(cxdata);
            CRM_COST_KAYEARCOST[] data = crmModels.COST_KAYEARCOST.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KAYEARCOST(int COSTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KAYEARCOST.Delete(COSTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_PSF(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_PSF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_PSF>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_PSF.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_PSF(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_PSF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_PSF>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_PSF.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_PSF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_PSF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_PSF>(cxdata);
            CRM_COST_PSF[] data = crmModels.COST_PSF.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_PSF_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_PSF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_PSF>(cxdata);
            CRM_COST_PSF[] data = crmModels.COST_PSF.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_PSF(int PSFID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_PSF.Delete(PSFID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_OTHER(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_OTHER model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_OTHER>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_OTHER.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_OTHER(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_OTHER model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_OTHER>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_OTHER.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_OTHER(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_OTHER model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_OTHER>(cxdata);
            CRM_COST_OTHER[] data = crmModels.COST_OTHER.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_OTHER_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_OTHER model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_OTHER>(cxdata);
            CRM_COST_OTHER[] data = crmModels.COST_OTHER.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_OTHER(int OTHERID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_OTHER.Delete(OTHERID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_KADTTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTTT>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_KADTTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KADTTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KADTTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KADTTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTTT>(cxdata);
            CRM_COST_KADTTT[] data = crmModels.COST_KADTTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_KADTTT_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTTT>(cxdata);
            CRM_COST_KADTTT[] data = crmModels.COST_KADTTT.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KADTTT(int KADTTTID)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_KADTMX cxmodel = new CRM_COST_KADTMX();
            cxmodel.KADTTTID = KADTTTID;
            CRM_COST_KADTMX[] cxdata = crmModels.COST_KADTMX.ReadByParam(cxmodel, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "存在明细数据！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            int i = crmModels.COST_KADTTT.Delete(KADTTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_KADTDP(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTDP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTDP>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_KADTDP.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KADTDP(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTDP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTDP>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KADTDP.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KADTDP(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTDP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTDP>(cxdata);
            CRM_COST_KADTDP[] data = crmModels.COST_KADTDP.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KADTDP(int DPID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KADTDP.Delete(DPID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_KADTMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTMX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;
            int i = crmModels.COST_KADTMX.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KADTMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTMX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KADTMX.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KADTMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTMX>(cxdata);
            CRM_COST_KADTMX[] data = crmModels.COST_KADTMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KADTMX(int KADTMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KADTMX.Delete(KADTMXID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_KADT(string mxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTMX[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTMX[]>(mxdata);
            if (MXmodel.Length == 0)
            {
                MessageInfo info1 = new MessageInfo();
                info1.Key = "0";
                info1.Value = "至少输入一项费用！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(info1);
            }

            CRM_COST_KADTTT cxmodel = new CRM_COST_KADTTT();
            cxmodel.KADTTTID = MXmodel[0].KADTTTID;
            CRM_COST_KADTTT TTdata = crmModels.COST_KADTTT.ReadByParam(cxmodel, 0, token)[0];
            CRM_COST_KADTDP cxDP = new CRM_COST_KADTDP();
            cxDP.KADTTTID = MXmodel[0].KADTTTID;
            CRM_COST_KADTDP[] DPMX = crmModels.COST_KADTDP.ReadByParam(cxDP, token);

            if (DPMX.Length == 0)
            {
                MessageInfo info1 = new MessageInfo();
                info1.Key = "0";
                info1.Value = "至少输入一个单品！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(info1);
            }


            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(21, token)[0].CS.ToString();

            CRM_OA_KADT list = new CRM_OA_KADT();
            list.HTYEAR = TTdata.HTYEAR;
            list.YWY = TTdata.CJRNAME;
            list.MC = TTdata.MC;
            list.CRMID = TTdata.CRMID;
            list.MDSL = TTdata.MDSL.ToString();
            list.LJSQJE = TTdata.LJSQJE.ToString();
            list.YHXJE = TTdata.YHXNDJE.ToString();
            list.HDFASM = TTdata.HDFASM;
            list.BEGINDATE = TTdata.HDBEGINDATE;
            list.ENDDATE = TTdata.HDENDDATE;
            list.FAHUO = TTdata.FHDATE;
            list.DQ = TTdata.DQ;
            list.CXJB = TTdata.CXJB;
            list.RCYJXS = TTdata.RCYJXS.ToString();
            list.YJXS = TTdata.YJHDQJXS.ToString();
            list.BEIZ = TTdata.BEIZ;

            decimal SQJE = 0;
            list.KADTMX = new CRM_OA_KADTMX[MXmodel.Length];
            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.KADTMX[i] = new CRM_OA_KADTMX();
                list.KADTMX[i].FYLX = MXmodel[i].COSTITEMIDDES;
                list.KADTMX[i].CXLX = MXmodel[i].CXLXDES;
                list.KADTMX[i].FYJE = MXmodel[i].FYJE.ToString();
                list.KADTMX[i].CJHDMDSL = MXmodel[i].CJHDMDSL.ToString();
                list.KADTMX[i].PROMISE = MXmodel[i].PROMISE == 1 ? "是" : "否";

                SQJE = SQJE + MXmodel[i].FYJE;
            }
            list.YJFB = Math.Round((SQJE / TTdata.YJHDQJXS * 100), 2, MidpointRounding.AwayFromZero).ToString() + "%";


            list.KADTCP = new CRM_OA_KADTCP[DPMX.Length];
            for (int i = 0; i < DPMX.Length; i++)
            {
                list.KADTCP[i] = new CRM_OA_KADTCP();
                list.KADTCP[i].SAPCP = DPMX[i].SAPCP;
                list.KADTCP[i].CPMC = DPMX[i].CPMC;
                list.KADTCP[i].ZCGJ = DPMX[i].ZCGJ.ToString();
                list.KADTCP[i].CXGJ = DPMX[i].CXGJ.ToString();
                list.KADTCP[i].ZCSJ = DPMX[i].ZCSJ.ToString();
                list.KADTCP[i].CXSJ = DPMX[i].CXSJ.ToString();
                list.KADTCP[i].BHSL = DPMX[i].BHSL.ToString();
                list.KADTCP[i].BEIZ = DPMX[i].BEIZ;
            }


            CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(26, TTdata.KADTTTID, token);
            list.IMG = new CRM_OA_KADT_IMG[FJ.Length];
            for (int i = 0; i < FJ.Length; i++)
            {
                list.IMG[i] = new CRM_OA_KADT_IMG();
                list.IMG[i].IMGML = FJ[i].ML;
                list.IMG[i].IMGMS = FJ[i].WJM.Replace(".jpg", " ");
            }



            List<CRM_OA_KADT_OPINION> all = new List<CRM_OA_KADT_OPINION>();
            for (int i = 0; i < MXmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 2023;
                cx_opinion.OACSBH = MXmodel[i].KADTMXID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_KADT_OPINION temp = new CRM_OA_KADT_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MXmodel[i].COSTITEMIDDES + "-" + MXmodel[i].CXLXDES;
                    all.Add(temp);
                }
            }

            list.OPINION = all.ToArray();

            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int j = 0; j < MXmodel.Length; j++)
                {
                    MXmodel[j].ISACTIVE = 20;
                    crmModels.COST_KADTMX.Update(MXmodel[j], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = MXmodel[j].KADTMXID;
                    model.OACSLB = 2023;
                    model.OAZT = 1;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }

        [HttpPost]
        public string Data_Submit_KADT_HX(string mxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTMX[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTMX[]>(mxdata);
            CRM_COST_KADTTT cxmodel = new CRM_COST_KADTTT();
            cxmodel.KADTTTID = MXmodel[0].KADTTTID;
            CRM_COST_KADTTT TTdata = crmModels.COST_KADTTT.ReadByParam(cxmodel, 0, token)[0];
            CRM_COST_KADTDP cxDP = new CRM_COST_KADTDP();
            cxDP.KADTTTID = MXmodel[0].KADTTTID;
            CRM_COST_KADTDP[] DPMX = crmModels.COST_KADTDP.ReadByParam(cxDP, token);

            for (var i = 0; i < MXmodel.Length; i++)
            {
                if (MXmodel[i].SJXS == 0)
                {
                    MessageInfo info1 = new MessageInfo();
                    info1.Key = "0";
                    info1.Value = "请输入实际销售！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(info1);
                }
                if (MXmodel[i].ISACTIVE != 30 && MXmodel[i].ISACTIVE != 40 && MXmodel[i].ISACTIVE != 45)
                {
                    MessageInfo info1 = new MessageInfo();
                    info1.Key = "0";
                    info1.Value = "当前状态不可提交！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(info1);
                }
            }



            if (DPMX.Length == 0)
            {
                MessageInfo info1 = new MessageInfo();
                info1.Key = "0";
                info1.Value = "至少输入一个单品！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(info1);
            }


            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(21, token)[0].CS.ToString();

            CRM_OA_KADT list = new CRM_OA_KADT();
            list.HTYEAR = TTdata.HTYEAR;
            list.YWY = TTdata.CJRNAME;
            list.MC = TTdata.MC;
            list.CRMID = TTdata.CRMID;
            list.MDSL = TTdata.MDSL.ToString();
            list.LJSQJE = TTdata.LJSQJE.ToString();
            list.YHXJE = TTdata.YHXNDJE.ToString();
            list.HDFASM = TTdata.HDFASM;
            list.BEGINDATE = TTdata.HDBEGINDATE;
            list.ENDDATE = TTdata.HDENDDATE;
            list.FAHUO = TTdata.FHDATE;
            list.DQ = TTdata.DQ;
            list.CXJB = TTdata.CXJB;
            list.RCYJXS = TTdata.RCYJXS.ToString();
            list.YJXS = TTdata.YJHDQJXS.ToString();
            list.BEIZ = TTdata.BEIZ;

            decimal SQJE = 0;
            list.KADTMX = new CRM_OA_KADTMX[MXmodel.Length];
            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.KADTMX[i] = new CRM_OA_KADTMX();
                list.KADTMX[i].FYLX = MXmodel[i].COSTITEMIDDES;
                list.KADTMX[i].CXLX = MXmodel[i].CXLXDES;
                list.KADTMX[i].FYJE = MXmodel[i].FYJE.ToString();
                list.KADTMX[i].CJHDMDSL = MXmodel[i].CJHDMDSL.ToString();
                list.KADTMX[i].PROMISE = MXmodel[i].PROMISE == 1 ? "是" : "否";
                list.KADTMX[i].SJXS = MXmodel[i].SJXS.ToString();
                list.KADTMX[i].SJFY = MXmodel[i].SJFY.ToString();
                list.KADTMX[i].HDJSZJ = MXmodel[i].HDJSZJ.ToString();
                list.KADTMX[i].BEIZ = MXmodel[i].BEIZ2.ToString();

                SQJE = SQJE + MXmodel[i].FYJE;
            }
            list.YJFB = Math.Round((SQJE / TTdata.YJHDQJXS * 100), 2, MidpointRounding.AwayFromZero).ToString() + "%";


            list.KADTCP = new CRM_OA_KADTCP[DPMX.Length];
            for (int i = 0; i < DPMX.Length; i++)
            {
                list.KADTCP[i] = new CRM_OA_KADTCP();
                list.KADTCP[i].SAPCP = DPMX[i].SAPCP;
                list.KADTCP[i].CPMC = DPMX[i].CPMC;
                list.KADTCP[i].ZCGJ = DPMX[i].ZCGJ.ToString();
                list.KADTCP[i].CXGJ = DPMX[i].CXGJ.ToString();
                list.KADTCP[i].ZCSJ = DPMX[i].ZCSJ.ToString();
                list.KADTCP[i].CXSJ = DPMX[i].CXSJ.ToString();
                list.KADTCP[i].BHSL = DPMX[i].BHSL.ToString();
                list.KADTCP[i].BEIZ = DPMX[i].BEIZ;
            }


            CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(41, TTdata.KADTTTID, token);
            list.IMG = new CRM_OA_KADT_IMG[FJ.Length];
            for (int i = 0; i < FJ.Length; i++)
            {
                list.IMG[i] = new CRM_OA_KADT_IMG();
                list.IMG[i].IMGML = FJ[i].ML;
                list.IMG[i].IMGMS = FJ[i].WJM.Replace(".jpg", " ");
            }



            List<CRM_OA_KADT_OPINION> all = new List<CRM_OA_KADT_OPINION>();
            for (int i = 0; i < MXmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 4120;
                cx_opinion.OACSBH = MXmodel[i].KADTMXID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_KADT_OPINION temp = new CRM_OA_KADT_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MXmodel[i].COSTITEMIDDES + "-" + MXmodel[i].CXLXDES;
                    all.Add(temp);
                }
            }

            list.OPINION = all.ToArray();

            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int j = 0; j < MXmodel.Length; j++)
                {
                    MXmodel[j].ISACTIVE = 50;
                    crmModels.COST_KADTMX.Update(MXmodel[j], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = MXmodel[j].KADTMXID;
                    model.OACSLB = 4120;
                    model.OAZT = 3;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }

        [HttpPost]
        public string Data_Insert_KATSCLTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLTT>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;

            CRM_COST_KATSCLTT cxmodel = new CRM_COST_KATSCLTT();
            cxmodel.HTYEAR = model.HTYEAR;
            cxmodel.KHID = model.KHID;
            CRM_COST_KATSCLTT[] cxdata = crmModels.COST_KATSCLTT.ReadByParam(cxmodel, 0, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "数据重复！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }



            int i = crmModels.COST_KATSCLTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KATSCLTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KATSCLTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KATSCLTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLTT>(cxdata);
            CRM_COST_KATSCLTT[] data = crmModels.COST_KATSCLTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KATSCLTT(int KATSCLTTID)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_KATSCLMX cxmodel = new CRM_COST_KATSCLMX();
            cxmodel.KATSCLTTID = KATSCLTTID;
            CRM_COST_KATSCLMX[] cxdata = crmModels.COST_KATSCLMX.ReadByParam(cxmodel, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "存在明细数据！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }



            int i = crmModels.COST_KATSCLTT.Delete(KATSCLTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_KATSCLMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLMX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;
            int i = crmModels.COST_KATSCLMX.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KATSCLMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLMX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KATSCLMX.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KATSCLMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLMX>(cxdata);
            CRM_COST_KATSCLMX[] data = crmModels.COST_KATSCLMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_KATSCLMX_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLMX>(cxdata);
            CRM_COST_KATSCLMX[] data = crmModels.COST_KATSCLMX.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KATSCLMX(int KATSCLMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KATSCLMX.Delete(KATSCLMXID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_KATSCL(string mxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLMX[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLMX[]>(mxdata);
            CRM_COST_KATSCLTT cxmodel = new CRM_COST_KATSCLTT();
            cxmodel.KATSCLTTID = MXmodel[0].KATSCLTTID;
            CRM_COST_KATSCLTT TTdata = crmModels.COST_KATSCLTT.ReadByParam(cxmodel, 0, token)[0];

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(22, token)[0].CS.ToString();

            CRM_OA_KATSCL list = new CRM_OA_KATSCL();
            list.HTYEAR = TTdata.HTYEAR;
            list.YWY = TTdata.CJRNAME;
            list.MC = TTdata.MC;
            list.CRMID = TTdata.CRMID;
            list.MDSL = TTdata.MDSL.ToString();
            list.LJSQJE = TTdata.LJSQJE.ToString();
            list.YHXJE = TTdata.YHXNDJE.ToString();

            list.KATSCLMX = new CRM_OA_KATSCLMX[MXmodel.Length];

            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.KATSCLMX[i] = new CRM_OA_KATSCLMX();
                list.KATSCLMX[i].MC = MXmodel[i].MC;
                list.KATSCLMX[i].DISPLAY = MXmodel[i].CLFSDES;
                list.KATSCLMX[i].BEGINDATE = MXmodel[i].BEGINDATE;
                list.KATSCLMX[i].ENDDATE = MXmodel[i].ENDDATE;
                list.KATSCLMX[i].FYJE = MXmodel[i].FYJE.ToString();
                list.KATSCLMX[i].RCYJXS = MXmodel[i].RCYJXS.ToString();
                list.KATSCLMX[i].YJXS = MXmodel[i].YJXS.ToString();
                list.KATSCLMX[i].YJFB = (MXmodel[i].YJFB / 100).ToString();
                list.KATSCLMX[i].BEIZ = MXmodel[i].BEIZ;
            }





            List<CRM_OA_KATSCL_IMG> all_img = new List<CRM_OA_KATSCL_IMG>();
            List<CRM_OA_KATSCL_OPINION> all_opinion = new List<CRM_OA_KATSCL_OPINION>();
            for (int i = 0; i < MXmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 2024;
                cx_opinion.OACSBH = MXmodel[i].KATSCLMXID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_KATSCL_OPINION temp = new CRM_OA_KATSCL_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MXmodel[i].MC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(27, MXmodel[i].KATSCLMXID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_KATSCL_IMG temp = new CRM_OA_KATSCL_IMG();
                    temp.IMGML = FJ[j].ML;
                    temp.IMGMS = FJ[j].WJM.Replace(".jpg", " ");//MXmodel[i].MC;
                    all_img.Add(temp);
                }



            }

            list.OPINION = all_opinion.ToArray();
            list.IMG = all_img.ToArray();


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int j = 0; j < MXmodel.Length; j++)
                {
                    MXmodel[j].ISACTIVE = 20;
                    crmModels.COST_KATSCLMX.Update(MXmodel[j], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = MXmodel[j].KATSCLMXID;
                    model.OACSLB = 2024;
                    model.OAZT = 1;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }

        [HttpPost]
        public string Data_Submit_KATSCL_HX(string mxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLMX[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLMX[]>(mxdata);
            CRM_COST_KATSCLTT cxmodel = new CRM_COST_KATSCLTT();
            cxmodel.KATSCLTTID = MXmodel[0].KATSCLTTID;
            CRM_COST_KATSCLTT TTdata = crmModels.COST_KATSCLTT.ReadByParam(cxmodel, 0, token)[0];

            for (int i = 0; i < MXmodel.Length; i++)
            {
                if (MXmodel[i].SJXS == 0)
                {
                    MessageInfo info1 = new MessageInfo();
                    info1.Key = "0";
                    info1.Value = "请输入实际销售！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(info1);
                }
                if (MXmodel[i].ISACTIVE != 30 && MXmodel[i].ISACTIVE != 40 && MXmodel[i].ISACTIVE != 45)
                {
                    MessageInfo info1 = new MessageInfo();
                    info1.Key = "0";
                    info1.Value = "当前状态不可提交！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(info1);
                }
            }



            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(22, token)[0].CS.ToString();

            CRM_OA_KATSCL list = new CRM_OA_KATSCL();
            list.HTYEAR = TTdata.HTYEAR;
            list.YWY = TTdata.CJRNAME;
            list.MC = TTdata.MC;
            list.CRMID = TTdata.CRMID;
            list.MDSL = TTdata.MDSL.ToString();
            list.LJSQJE = TTdata.LJSQJE.ToString();
            list.YHXJE = TTdata.YHXNDJE.ToString();

            list.KATSCLMX = new CRM_OA_KATSCLMX[MXmodel.Length];

            for (int i = 0; i < MXmodel.Length; i++)
            {
                list.KATSCLMX[i] = new CRM_OA_KATSCLMX();
                list.KATSCLMX[i].MC = MXmodel[i].MC;
                list.KATSCLMX[i].DISPLAY = MXmodel[i].CLFSDES;
                list.KATSCLMX[i].BEGINDATE = MXmodel[i].BEGINDATE;
                list.KATSCLMX[i].ENDDATE = MXmodel[i].ENDDATE;
                list.KATSCLMX[i].FYJE = MXmodel[i].FYJE.ToString();
                list.KATSCLMX[i].RCYJXS = MXmodel[i].RCYJXS.ToString();
                list.KATSCLMX[i].YJXS = MXmodel[i].YJXS.ToString();
                list.KATSCLMX[i].YJFB = (MXmodel[i].YJFB / 100).ToString();
                list.KATSCLMX[i].BEIZ = MXmodel[i].BEIZ;
                list.KATSCLMX[i].SJXS = MXmodel[i].SJXS.ToString();
                list.KATSCLMX[i].SJFY = MXmodel[i].SJFY.ToString();
                list.KATSCLMX[i].HDJSZJ = MXmodel[i].HDJSZJ;
                list.KATSCLMX[i].BEIZ2 = MXmodel[i].BEIZ2;
            }





            List<CRM_OA_KATSCL_IMG> all_img = new List<CRM_OA_KATSCL_IMG>();
            List<CRM_OA_KATSCL_OPINION> all_opinion = new List<CRM_OA_KATSCL_OPINION>();
            for (int i = 0; i < MXmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 4121;
                cx_opinion.OACSBH = MXmodel[i].KATSCLMXID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_KATSCL_OPINION temp = new CRM_OA_KATSCL_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MXmodel[i].MC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(42, MXmodel[i].KATSCLMXID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_KATSCL_IMG temp = new CRM_OA_KATSCL_IMG();
                    temp.IMGML = FJ[j].ML;
                    temp.IMGMS = FJ[j].WJM.Replace(".jpg", " ");//MXmodel[i].MC;
                    all_img.Add(temp);
                }



            }

            list.OPINION = all_opinion.ToArray();
            list.IMG = all_img.ToArray();


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int j = 0; j < MXmodel.Length; j++)
                {
                    MXmodel[j].ISACTIVE = 50;
                    crmModels.COST_KATSCLMX.Update(MXmodel[j], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = MXmodel[j].KATSCLMXID;
                    model.OACSLB = 4121;
                    model.OAZT = 3;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);


        }

        [HttpPost]
        public string Data_Insert_MDBS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBS>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;
            int i = crmModels.COST_MDBS.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_MDBS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBS>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_MDBS.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_MDBS(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBS>(cxdata);
            CRM_COST_MDBS[] data = crmModels.COST_MDBS.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_MDBS_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBS>(cxdata);
            CRM_COST_MDBS[] data = crmModels.COST_MDBS.Read_Unconnected(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_MDBS(int MDBSID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_MDBS.Delete(MDBSID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_MDBS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBS[] MDBSmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBS[]>(data);


            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(19, token)[0].CS.ToString();
            basic.Subject = "直营门店直营卖场费用计划与效果评估 月份" + MDBSmodel[0].HTMONTH;

            CRM_OA_MDBS list = new CRM_OA_MDBS();
            list.MONTH = MDBSmodel[0].HTMONTH;
            list.LCTYPE = "申请";
            if (MDBSmodel[0].FYLB == 1)
                list.XTTYPE = "大润发欧尚";
            else
                list.XTTYPE = "非大润发欧尚";
            list.TITLE = "直营门店直营卖场费用计划";

            list.MDBSMX = new CRM_OA_MDBSMX[MDBSmodel.Length];
            for (int i = 0; i < MDBSmodel.Length; i++)
            {
                list.MDBSMX[i] = new CRM_OA_MDBSMX();
                list.MDBSMX[i].SF = MDBSmodel[i].SFDES;
                list.MDBSMX[i].CS = MDBSmodel[i].CSDES;
                list.MDBSMX[i].MC = MDBSmodel[i].MC;
                list.MDBSMX[i].MDMC = MDBSmodel[i].MDMC;
                list.MDBSMX[i].DISPLAY = MDBSmodel[i].DISPLAYITEM;
                list.MDBSMX[i].POSITION = MDBSmodel[i].DISPLAYPOSITION;
                list.MDBSMX[i].BEGINDATE = MDBSmodel[i].BEGINDATE;
                list.MDBSMX[i].ENDDATE = MDBSmodel[i].ENDDATE;
                list.MDBSMX[i].QSYJXS = MDBSmodel[i].QSYJXS.ToString();
                list.MDBSMX[i].YJFY = MDBSmodel[i].YJFY.ToString();
                list.MDBSMX[i].YJXS = MDBSmodel[i].YJXS.ToString();
                list.MDBSMX[i].FB = (MDBSmodel[i].YJFB / 100).ToString();
                list.MDBSMX[i].CXY = MDBSmodel[i].HAVECXYDES;
                list.MDBSMX[i].PAYWAY = MDBSmodel[i].PAYWAYDES;
                list.MDBSMX[i].XXDD = MDBSmodel[i].HAVEDD == 1 ? "是" : "否";
                list.MDBSMX[i].BEIZ2 = MDBSmodel[i].BEIZ;
            }


            List<CRM_OA_MDBS_IMG> all_img = new List<CRM_OA_MDBS_IMG>();
            List<CRM_OA_MDBS_OPINION> all_opinion = new List<CRM_OA_MDBS_OPINION>();
            for (int i = 0; i < MDBSmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 2015;
                cx_opinion.OACSBH = MDBSmodel[i].MDBSID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_MDBS_OPINION temp = new CRM_OA_MDBS_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MDBSmodel[i].MC + " " + MDBSmodel[i].MDMC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(28, MDBSmodel[i].MDBSID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_MDBS_IMG temp = new CRM_OA_MDBS_IMG();
                    temp.IMGML = FJ[j].ML;
                    temp.IMGMS = FJ[j].WJM.Replace(".jpg", " ");//MDBSmodel[i].MC;
                    all_img.Add(temp);
                }



            }

            list.OPINION = all_opinion.ToArray();
            list.IMG = all_img.ToArray();


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int i = 0; i < MDBSmodel.Length; i++)
                {
                    MDBSmodel[i].ISACTIVE = 20;
                    crmModels.COST_MDBS.Update(MDBSmodel[i], token);


                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = MDBSmodel[i].MDBSID;
                    model.OACSLB = 2015;
                    model.OAZT = 1;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }







            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Data_Submit_MDBS_HX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBS[] MDBSmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBS[]>(data);


            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(19, token)[0].CS.ToString();
            basic.Subject = "直营门店直营卖场费用计划与效果评估 月份" + MDBSmodel[0].HTMONTH;

            CRM_OA_MDBS list = new CRM_OA_MDBS();
            list.MONTH = MDBSmodel[0].HTMONTH;
            list.LCTYPE = "核销";
            if (MDBSmodel[0].FYLB == 1)
                list.XTTYPE = "大润发欧尚";
            else
                list.XTTYPE = "非大润发欧尚";
            list.TITLE = "直营门店直营卖场费用效果评估";

            list.MDBSMX = new CRM_OA_MDBSMX[MDBSmodel.Length];
            for (int i = 0; i < MDBSmodel.Length; i++)
            {
                list.MDBSMX[i] = new CRM_OA_MDBSMX();
                list.MDBSMX[i].SF = MDBSmodel[i].SFDES;
                list.MDBSMX[i].CS = MDBSmodel[i].CSDES;
                list.MDBSMX[i].MC = MDBSmodel[i].MC;
                list.MDBSMX[i].MDMC = MDBSmodel[i].MDMC;
                list.MDBSMX[i].DISPLAY = MDBSmodel[i].DISPLAYITEM;
                list.MDBSMX[i].POSITION = MDBSmodel[i].DISPLAYPOSITION;
                list.MDBSMX[i].BEGINDATE = MDBSmodel[i].BEGINDATE;
                list.MDBSMX[i].ENDDATE = MDBSmodel[i].ENDDATE;
                list.MDBSMX[i].QSYJXS = MDBSmodel[i].QSYJXS.ToString();
                list.MDBSMX[i].YJFY = MDBSmodel[i].YJFY.ToString();
                list.MDBSMX[i].YJXS = MDBSmodel[i].YJXS.ToString();
                list.MDBSMX[i].FB = (MDBSmodel[i].YJFB / 100).ToString();
                list.MDBSMX[i].CXY = MDBSmodel[i].HAVECXYDES;
                list.MDBSMX[i].PAYWAY = MDBSmodel[i].PAYWAYDES;
                list.MDBSMX[i].XXDD = MDBSmodel[i].HAVEDD == 1 ? "是" : "否";
                list.MDBSMX[i].HX_SJXS = MDBSmodel[i].SJXS.ToString();
                list.MDBSMX[i].SJFY = MDBSmodel[i].SJFY.ToString();
                list.MDBSMX[i].HX_FB = (MDBSmodel[i].SJFB / 100).ToString();
                list.MDBSMX[i].BEIZ2 = MDBSmodel[i].BEIZ;
                list.MDBSMX[i].BEIZ = MDBSmodel[i].BEIZ2;
            }


            List<CRM_OA_MDBS_IMG> all_img = new List<CRM_OA_MDBS_IMG>();
            List<CRM_OA_MDBS_OPINION> all_opinion = new List<CRM_OA_MDBS_OPINION>();
            for (int i = 0; i < MDBSmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 2021;
                cx_opinion.OACSBH = MDBSmodel[i].MDBSID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_MDBS_OPINION temp = new CRM_OA_MDBS_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MDBSmodel[i].MDMC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(28, MDBSmodel[i].MDBSID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_MDBS_IMG temp = new CRM_OA_MDBS_IMG();
                    temp.IMGML = FJ[j].ML;
                    temp.IMGMS = FJ[j].WJM.Replace(".jpg", " "); //MDBSmodel[i].MC;
                    all_img.Add(temp);
                }



            }

            list.OPINION = all_opinion.ToArray();
            list.IMG = all_img.ToArray();


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int i = 0; i < MDBSmodel.Length; i++)
                {
                    MDBSmodel[i].ISACTIVE = 50;
                    crmModels.COST_MDBS.Update(MDBSmodel[i], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = MDBSmodel[i].MDBSID;
                    model.OACSLB = 2021;
                    model.OAZT = 3;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }



            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Data_Submit_MDBS_HXDJ(string HXDJMXIDSTR)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBS cxmodel = new CRM_COST_MDBS();
            cxmodel.HXDJMXIDSTR = HXDJMXIDSTR;
            CRM_COST_MDBS[] MDBSmodel = crmModels.COST_MDBS.ReadByParam(cxmodel, 0, token);


            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(19, token)[0].CS.ToString();
            basic.Subject = "直营门店直营卖场费用计划与效果评估 月份" + MDBSmodel[0].HTMONTH;

            CRM_OA_MDBS list = new CRM_OA_MDBS();
            list.MONTH = MDBSmodel[0].HTMONTH;
            list.LCTYPE = "核销登记";
            if (MDBSmodel[0].FYLB == 1)
                list.XTTYPE = "大润发欧尚";
            else
                list.XTTYPE = "非大润发欧尚";
            list.TITLE = "直营门店直营卖场费用效果评估";
            if (MDBSmodel[0].ISTJ != 30)
                list.ISTJ = "1";
            else
                list.ISTJ = "0";

            list.MDBSMX = new CRM_OA_MDBSMX[MDBSmodel.Length];
            for (int i = 0; i < MDBSmodel.Length; i++)
            {
                list.MDBSMX[i] = new CRM_OA_MDBSMX();
                list.MDBSMX[i].SF = MDBSmodel[i].SFDES;
                list.MDBSMX[i].CS = MDBSmodel[i].CSDES;
                list.MDBSMX[i].MC = MDBSmodel[i].MC;
                list.MDBSMX[i].MDMC = MDBSmodel[i].MDMC;
                list.MDBSMX[i].DISPLAY = MDBSmodel[i].DISPLAYITEM;
                list.MDBSMX[i].POSITION = MDBSmodel[i].DISPLAYPOSITION;
                list.MDBSMX[i].BEGINDATE = MDBSmodel[i].BEGINDATE;
                list.MDBSMX[i].ENDDATE = MDBSmodel[i].ENDDATE;
                list.MDBSMX[i].QSYJXS = MDBSmodel[i].QSYJXS.ToString();
                list.MDBSMX[i].YJFY = MDBSmodel[i].YJFY.ToString();
                list.MDBSMX[i].YJXS = MDBSmodel[i].YJXS.ToString();
                list.MDBSMX[i].FB = (MDBSmodel[i].YJFB / 100).ToString();
                list.MDBSMX[i].CXY = MDBSmodel[i].HAVECXYDES;
                list.MDBSMX[i].PAYWAY = MDBSmodel[i].PAYWAYDES;
                list.MDBSMX[i].XXDD = MDBSmodel[i].HAVEDD == 1 ? "是" : "否";
                list.MDBSMX[i].HX_SJXS = MDBSmodel[i].SJXS.ToString();
                list.MDBSMX[i].SJFY = MDBSmodel[i].SJFY.ToString();
                list.MDBSMX[i].HX_FB = (MDBSmodel[i].SJFB / 100).ToString();
                list.MDBSMX[i].BEIZ2 = MDBSmodel[i].BEIZ;
                list.MDBSMX[i].BEIZ = MDBSmodel[i].BEIZ2;
                list.MDBSMX[i].THL = MDBSmodel[i].THL.Replace("；", "\n");
                list.MDBSMX[i].HXRQ = MDBSmodel[i].HXRQ;
                list.MDBSMX[i].HX_JE = MDBSmodel[i].HX_JE.ToString();
            }


            List<CRM_OA_MDBS_IMG> all_img = new List<CRM_OA_MDBS_IMG>();
            List<CRM_OA_MDBS_OPINION> all_opinion = new List<CRM_OA_MDBS_OPINION>();
            for (int i = 0; i < MDBSmodel.Length; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 2021;
                cx_opinion.OACSBH = MDBSmodel[i].MDBSID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_MDBS_OPINION temp = new CRM_OA_MDBS_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;
                    temp.MS = MDBSmodel[i].MDMC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(28, MDBSmodel[i].MDBSID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_MDBS_IMG temp = new CRM_OA_MDBS_IMG();
                    temp.IMGML = FJ[j].ML;
                    temp.IMGMS = FJ[j].WJM.Replace(".jpg", " "); //MDBSmodel[i].MC;
                    all_img.Add(temp);
                }



            }

            list.OPINION = all_opinion.ToArray();
            list.IMG = all_img.ToArray();


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                CRM_COST_KAHXDJMX KAmodel = new CRM_COST_KAHXDJMX();
                KAmodel.HXDJMXIDSTR = HXDJMXIDSTR;
                CRM_COST_KAHXDJMX[] KAdata = crmModels.COST_KAHXDJMX.ReadByParam(KAmodel, token);

                for (int i = 0; i < KAdata.Length; i++)
                {
                    KAdata[i].ISTJ = 30;
                    crmModels.COST_KAHXDJMX.Update(KAdata[i], token);



                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = KAdata[i].HXDJMXID;
                    model.OACSLB = 4190;
                    model.OAZT = 4;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }



            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Data_Insert_KAHXZLTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLTT>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;

            CRM_COST_KAHXZLTT cxmodel = new CRM_COST_KAHXZLTT();
            cxmodel.HTYEAR = model.HTYEAR;
            cxmodel.KHID = model.KHID;
            cxmodel.FYLB = model.FYLB;        //FYLB 1表示堆头海报特陈    2表示制作费
            CRM_COST_KAHXZLTT[] cxdata = crmModels.COST_KAHXZLTT.ReadByParam(cxmodel, 0, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "数据重复！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }



            int i = crmModels.COST_KAHXZLTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }



        [HttpPost]
        public string Data_Update_KAHXZLTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KAHXZLTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KAHXZLTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLTT>(cxdata);
            CRM_COST_KAHXZLTT[] data = crmModels.COST_KAHXZLTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KAHXZLTT(int HXZLTTID)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_KAHXZLMX[] MXdata = crmModels.COST_KAHXZLMX.ReadByTTID(HXZLTTID, token);
            if (MXdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "存在明细数据，请先删除！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            int i = crmModels.COST_KAHXZLTT.Delete(HXZLTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_KAHXZLMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLMX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;

            int i = 0;
            if (model.KADTTTID != 0)      //海报堆头的独立循环新增
            {
                CRM_COST_KADTMX cxmodel = new CRM_COST_KADTMX();
                cxmodel.KADTTTID = model.KADTTTID;
                CRM_COST_KADTMX[] DT = crmModels.COST_KADTMX.ReadByParam(cxmodel, token);
                for (int j = 0; j < DT.Length; j++)
                {
                    model.COSTID = DT[j].KADTMXID;
                    model.COSTITEMID = DT[j].COSTITEMID;
                    model.SQJE = DT[j].FYJE;
                    i = crmModels.COST_KAHXZLMX.Create(model, token);
                }
                i = model.KADTTTID;
            }
            else
            {
                i = crmModels.COST_KAHXZLMX.Create(model, token);
            }

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KAHXZLMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLMX>(data);
            model.XGR = appClass.CRM_GetStaffid();

            int i = 0;
            if (model.KADTTTID != 0)          //海报堆头活动补差需要根据KADTTTID进行批量修改
            {
                i = crmModels.COST_KAHXZLMX.UpdateByKADTTTID(model, token);
            }
            else
            {
                i = crmModels.COST_KAHXZLMX.Update(model, token);
            }


            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_KAHXZLMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLMX[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLMX[]>(data);

            for (int i = 0; i < model.Length; i++)
            {
                if (model[i].COSTITEMID == 53)
                {
                    CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(23, model[i].HXZLMXID, token);
                    if (FJ.Length == 0)
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "请提交广告完成画面！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }

                if (model[i].COSTITEMID == 51 || model[i].COSTITEMID == 52 || model[i].COSTITEMID == 55)
                {
                    //提交海报费时，需要把同一个TT下对应的堆头费和活动补差也一起提交，反之同理

                    CRM_COST_KAHXZLMX cxmodel = new CRM_COST_KAHXZLMX();
                    cxmodel.KADTTTID = model[i].KADTTTID;
                    //cxmodel.COSTITEMID = model[i].COSTITEMID;
                    cxmodel.COSTITEMIDSTR = "51,52,55";

                    CRM_COST_KAHXZLMX[] others = crmModels.COST_KAHXZLMX.ReadByParam(cxmodel, token);
                    for (int j = 0; j < others.Length; j++)
                    {
                        others[j].ISACTIVE = 20;
                        int iii = crmModels.COST_KAHXZLMX.Update(others[j], token);
                        if (iii <= 0)
                        {
                            webmsg.KEY = iii;
                            webmsg.MSG = "提交失败2！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }

                }
                else
                {
                    model[i].ISACTIVE = 20;
                    int ii = crmModels.COST_KAHXZLMX.Update(model[i], token);
                    if (ii <= 0)
                    {
                        webmsg.KEY = ii;
                        webmsg.MSG = "提交失败！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }

            }


            webmsg.KEY = 1;

            if (webmsg.KEY > 0)
                webmsg.MSG = "提交成功！";
            else
                webmsg.MSG = "提交失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_SH_KAHXZLMX(string data, string check)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLMX[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLMX[]>(data);

            for (int i = 0; i < model.Length; i++)
            {

                if (model[i].COSTITEMID == 51 || model[i].COSTITEMID == 52 || model[i].COSTITEMID == 55)
                {
                    //审核海报费时，需要把同一个TT下对应的堆头费活动补差也一起审核，反之同理


                    CRM_COST_KAHXZLMX cxmodel = new CRM_COST_KAHXZLMX();
                    cxmodel.KADTTTID = model[i].KADTTTID;
                    cxmodel.COSTITEMIDSTR = "51,52,55";
                    CRM_COST_KAHXZLMX[] others = crmModels.COST_KAHXZLMX.ReadByParam(cxmodel, token);
                    for (int j = 0; j < others.Length; j++)
                    {
                        others[j].ISACTIVE = 30;
                        others[j].FYHXYHCNR = check;
                        int iii = crmModels.COST_KAHXZLMX.Update(others[j], token);
                        if (iii <= 0)
                        {
                            webmsg.KEY = iii;
                            webmsg.MSG = "审核失败2！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }
                }
                else
                {
                    model[i].ISACTIVE = 30;
                    model[i].FYHXYHCNR = check;
                    int ii = crmModels.COST_KAHXZLMX.Update(model[i], token);
                    if (ii <= 0)
                    {
                        webmsg.KEY = ii;
                        webmsg.MSG = "审核失败！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }


            }



            webmsg.KEY = 1;


            if (webmsg.KEY > 0)
                webmsg.MSG = "审核成功！";
            else
                webmsg.MSG = "审核失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_BACK_KAHXZLMX(string data, string check)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLMX[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLMX[]>(data);

            for (int i = 0; i < model.Length; i++)
            {

                if (model[i].COSTITEMID == 51 || model[i].COSTITEMID == 52 || model[i].COSTITEMID == 55)
                {
                    //回退海报费时，需要把同一个TT下对应的堆头费活动补差也一起回退，反之同理

                    CRM_COST_KAHXZLMX cxmodel = new CRM_COST_KAHXZLMX();
                    cxmodel.KADTTTID = model[i].KADTTTID;
                    cxmodel.COSTITEMIDSTR = "51,52,55";
                    CRM_COST_KAHXZLMX[] others = crmModels.COST_KAHXZLMX.ReadByParam(cxmodel, token);
                    for (int j = 0; j < others.Length; j++)
                    {
                        others[j].ISACTIVE = 15;
                        others[j].FYHXYHCNR = check;
                        int iii = crmModels.COST_KAHXZLMX.Update(others[j], token);
                        if (iii <= 0)
                        {
                            webmsg.KEY = iii;
                            webmsg.MSG = "回退失败2！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }

                }
                else
                {
                    model[i].ISACTIVE = 15;
                    model[i].FYHXYHCNR = check;
                    int ii = crmModels.COST_KAHXZLMX.Update(model[i], token);
                    if (ii <= 0)
                    {
                        webmsg.KEY = ii;
                        webmsg.MSG = "回退失败！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                }
            }



            webmsg.KEY = 1;


            if (webmsg.KEY > 0)
                webmsg.MSG = "回退成功！";
            else
                webmsg.MSG = "回退失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KAHXZLMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLMX>(cxdata);
            CRM_COST_KAHXZLMX[] data = crmModels.COST_KAHXZLMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_KAHXZLMX_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXZLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXZLMX>(cxdata);
            CRM_COST_KAHXZLMX[] data = crmModels.COST_KAHXZLMX.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KAHXZLMX(int HXZLMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KAHXZLMX.Delete(HXZLMXID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_KAHXZLMX_alter(int KADTTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KAHXZLMX.DeleteByKADTTTID(KADTTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_KAHXDJTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXDJTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXDJTT>(data);

            //找到对应的年度费用的数据
            //CRM_COST_KAYEARTT cx = new CRM_COST_KAYEARTT();
            //cx.KHID = model.KHID;
            //cx.HTYEAR = model.HTYEAR;
            //CRM_COST_KAYEARTT[] KAyear = crmModels.COST_KAYEARTT.ReadByParam(cx, 0, token);
            //if (KAyear.Length == 0)
            //{
            //    webmsg.KEY = 0;
            //    webmsg.MSG = "没有对应的年度费用信息！";
            //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            //}
            //if (KAyear.Length > 1)
            //{
            //    webmsg.KEY = 0;
            //    webmsg.MSG = "存在多条对应的年度费用信息！";
            //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            //}


            //model.BEGINDATE = KAyear[0].BEGINDATE;
            //model.ENDDATE = KAyear[0].ENDDATE;
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;

            CRM_COST_KAHXDJTT cxmodel = new CRM_COST_KAHXDJTT();
            cxmodel.HTYEAR = model.HTYEAR;
            cxmodel.KHID = model.KHID;
            CRM_COST_KAHXDJTT[] cxdata = crmModels.COST_KAHXDJTT.ReadByParam(cxmodel, 0, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "数据重复！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            int i = crmModels.COST_KAHXDJTT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KAHXDJTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXDJTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXDJTT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KAHXDJTT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KAHXDJTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXDJTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXDJTT>(cxdata);
            CRM_COST_KAHXDJTT[] data = crmModels.COST_KAHXDJTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KAHXDJTT(int HXDJTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KAHXDJTT.Delete(HXDJTTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_KAHXDJMX(string data, int COSTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXDJMX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_KAHXDJMX.Create(model, token);
            if (i > 0)
            {
                //新增关联表的数据
                if (model.COSTITEMID == 51 || model.COSTITEMID == 52 || model.COSTITEMID == 55)
                {
                    //海报、堆头、活动补差
                    COST_KADTMX_KAHXDJMX conndata = new COST_KADTMX_KAHXDJMX();
                    conndata.HXDJMXID = i;
                    conndata.KADTMXID = COSTID;
                    crmModels.COST_KADTMX.Create_CONN(conndata, token);
                }
                else if (model.COSTITEMID == 60)
                {
                    //特陈
                    COST_KATSCLMX_KAHXDJMX conndata = new COST_KATSCLMX_KAHXDJMX();
                    conndata.HXDJMXID = i;
                    conndata.KATSCLMXID = COSTID;
                    crmModels.COST_KATSCLMX.Create_CONN(conndata, token);
                }
                else if (model.COSTITEMID == 53)
                {
                    //制作费
                    CRM_COST_ZZFTT_KAHXDJMX conndata = new CRM_COST_ZZFTT_KAHXDJMX();
                    conndata.HXDJMXID = i;
                    conndata.TTID = COSTID;
                    crmModels.COST_ZZFTT_KAHXDJMX.Create(conndata, token);
                }
                else if (model.COSTITEMID == 56)
                {
                    //门店补损
                    CRM_COST_MDBS_KAHXDJMX conndata = new CRM_COST_MDBS_KAHXDJMX();
                    conndata.HXDJMXID = i;
                    conndata.MDBSHXID = COSTID;
                    crmModels.COST_MDBS_KAHXDJMX.Create(conndata, token);
                }
                else if (model.COSTITEMID == 58 || model.COSTITEMID == 54)
                {
                    //其他费用
                    CRM_COST_OTHER_KAHXDJMX conndata = new CRM_COST_OTHER_KAHXDJMX();
                    conndata.HXDJMXID = i;
                    conndata.OTHERID = COSTID;
                    crmModels.COST_OTHER_KAHXDJMX.Create(conndata, token);
                }
                else if (model.COSTITEMID == 57)
                {
                    //配送费
                    CRM_COST_PSF_KAHXDJMX conndata = new CRM_COST_PSF_KAHXDJMX();
                    conndata.HXDJMXID = i;
                    conndata.PSFID = COSTID;
                    crmModels.COST_PSF_KAHXDJMX.Create(conndata, token);
                }
                else
                {
                    //合同费用
                    CRM_COST_KAYEARCOST_KAHXDJMX conndata = new CRM_COST_KAYEARCOST_KAHXDJMX();
                    conndata.HXDJMXID = i;
                    conndata.COSTID = COSTID;
                    crmModels.COST_KAYEARCOST_KAHXDJMX.Create(conndata, token);
                }
            }
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_KAHXDJMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXDJMX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_KAHXDJMX.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KAHXDJMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAHXDJMX>(cxdata);
            CRM_COST_KAHXDJMX[] data = crmModels.COST_KAHXDJMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KAHXDJMX(int HXDJMXID, int COSTITEMID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_KAHXDJMX.Delete(HXDJMXID, token);
            if (i > 0)
            {
                //删除关联表的数据
                if (COSTITEMID == 51 || COSTITEMID == 52 || COSTITEMID == 55)
                {
                    //海报堆头、活动补差
                    crmModels.COST_KADTMX.DeleteByHXDJMXID_CONN(HXDJMXID, token);
                }
                else if (COSTITEMID == 60)
                {
                    //特陈
                    crmModels.COST_KATSCLMX.DeleteByHXDJMXID(HXDJMXID, token);
                }
                else if (COSTITEMID == 56)
                {
                    //门店补损
                    crmModels.COST_MDBS_KAHXDJMX.Delete(HXDJMXID, token);
                }
                else if (COSTITEMID == 53)
                {
                    //制作费
                    crmModels.COST_ZZFTT_KAHXDJMX.DeleteByHXDJMXID(HXDJMXID, token);
                }
                else if (COSTITEMID == 58 || COSTITEMID == 54)
                {
                    //其他费用
                    crmModels.COST_OTHER_KAHXDJMX.Delete(HXDJMXID, token);
                }
                else if (COSTITEMID == 57)
                {
                    //配送费
                    crmModels.COST_PSF_KAHXDJMX.Delete(HXDJMXID, token);
                }
                else
                {
                    //合同费用
                    crmModels.COST_KAYEARCOST_KAHXDJMX.Delete(HXDJMXID, token);
                }
            }
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Data_Insert_JXSHXDJMX(string data, int COSTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_JXSHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_JXSHXDJMX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_JXSHXDJMX.Create(model, token);
            if (i > 0)
            {
                CRM_COST_JXSHXDJMX_COST newmodel = new CRM_COST_JXSHXDJMX_COST();
                newmodel.COSTID = COSTID;
                newmodel.COSTITEMID = model.COSTITEMID;
                newmodel.HXDJMXID = i;
                int j = crmModels.COST_JXSHXDJMX_COST.Create(newmodel, token);
                if (j < 0)
                {
                    webmsg.KEY = j;
                    webmsg.MSG = "新增失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_JXSHXDJMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_JXSHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_JXSHXDJMX>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_JXSHXDJMX.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_JXSHXDJMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_JXSHXDJMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_JXSHXDJMX>(cxdata);
            CRM_COST_JXSHXDJMX[] data = crmModels.COST_JXSHXDJMX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_JXSHXDJMX(int HXDJMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_JXSHXDJMX.Delete(HXDJMXID, token);

            crmModels.COST_JXSHXDJMX_COST.DeleteByHXDJMXID(HXDJMXID, token);


            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string JXS_ZZF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(cxdata);
            model.ISACTIVE = 40;
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string LKA_ZZF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(cxdata);
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.Read_LKA(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string KA_ZZF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(cxdata);
            CRM_COST_ZZFTT[] data = crmModels.COST_ZZFTT.Read_KA(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Submit_LKA_ZZF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT[] data = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT[]>(cxdata);
            for (int i = 0; i < data.Length; i++)
            {
                data[i].HXR = appClass.CRM_GetStaffid();
                crmModels.COST_ZZFTT.Update(data[i], token);

                CRM_COST_LKAYEARCOST_LKAHXZLMX model = new CRM_COST_LKAYEARCOST_LKAHXZLMX();
                model.COSTID = data[i].TTID;
                model.COSTITEMID = 14;
                CRM_COST_LKAYEARCOST_LKAHXZLMX[] data1 = crmModels.COST_LKAYEARCOST_LKAHXZLMX.ReadByTTID(model, token);

                CRM_COST_LKAHXZLMX model1 = new CRM_COST_LKAHXZLMX();
                model1.HXZLMXID = data1[i].HXZLMXID;
                model1.COSTITEMID = 14;
                model1.COSTITEMIDSTR = "14";
                CRM_COST_LKAHXZLMX[] a = crmModels.COST_LKAHXZLMX.ReadByParam(model1, token);
                a[i].ISACTIVE = 30;
                int m = crmModels.COST_LKAHXZLMX.Update(a[i], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "审核失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Back_LKA_ZZF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT[] data = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT[]>(cxdata);
            for (int i = 0; i < data.Length; i++)
            {
                data[i].HXR = appClass.CRM_GetStaffid();
                crmModels.COST_ZZFTT.Update(data[i], token);
                CRM_COST_LKAYEARCOST_LKAHXZLMX model = new CRM_COST_LKAYEARCOST_LKAHXZLMX();
                model.COSTID = data[i].TTID;
                model.COSTITEMID = 14;
                CRM_COST_LKAYEARCOST_LKAHXZLMX[] data1 = crmModels.COST_LKAYEARCOST_LKAHXZLMX.ReadByTTID(model, token);

                CRM_COST_LKAHXZLMX model1 = new CRM_COST_LKAHXZLMX();
                model1.HXZLMXID = data1[i].HXZLMXID;
                model1.COSTITEMID = 14;
                model1.COSTITEMIDSTR = "14";
                CRM_COST_LKAHXZLMX[] a = crmModels.COST_LKAHXZLMX.ReadByParam(model1, token);
                a[i].ISACTIVE = 10;
                int m = crmModels.COST_LKAHXZLMX.Update(a[i], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "回退失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "回退成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Submit_KA_ZZF(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT[] cxdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT[]>(data);
            for (int i = 0; i < cxdata.Length; i++)
            {
                cxdata[i].HXR = appClass.CRM_GetStaffid();
                crmModels.COST_ZZFTT.Update(cxdata[i], token);

                CRM_COST_KAHXZLMX model = new CRM_COST_KAHXZLMX();
                model.COSTID = cxdata[i].TTID;
                model.COSTITEMID = 53;
                model.COSTITEMIDSTR = "53";
                CRM_COST_KAHXZLMX[] newdata = crmModels.COST_KAHXZLMX.ReadByParam(model, token);
                newdata[0].ISACTIVE = 30;
                int m = crmModels.COST_KAHXZLMX.Update(newdata[i], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "审核失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Back_KA_ZZF(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT[] cxdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT[]>(data);
            for (int i = 0; i < cxdata.Length; i++)
            {

                cxdata[i].HXR = appClass.CRM_GetStaffid();
                crmModels.COST_ZZFTT.Update(cxdata[i], token);

                CRM_COST_KAHXZLMX model = new CRM_COST_KAHXZLMX();
                model.COSTID = cxdata[i].TTID;
                model.COSTITEMID = 53;
                model.COSTITEMIDSTR = "53";
                CRM_COST_KAHXZLMX[] newdata = crmModels.COST_KAHXZLMX.ReadByParam(model, token);
                newdata[i].ISACTIVE = 10;
                int m = crmModels.COST_KAHXZLMX.Update(newdata[i], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "回退失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }


            webmsg.KEY = 1;
            webmsg.MSG = "回退成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Submit_JSX_ZZF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT[]>(cxdata);
            for (int i = 0; i < checkdata.Length; i++)
            {
                checkdata[i].ISACTIVE = 60;
                checkdata[i].HXR = appClass.CRM_GetStaffid();
                int m = crmModels.COST_ZZFTT.Update(checkdata[i], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "审核失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Back_JSX_ZZF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT[]>(cxdata);
            for (int i = 0; i < checkdata.Length; i++)
            {
                checkdata[i].ISACTIVE = 30;
                checkdata[i].HXR = appClass.CRM_GetStaffid();
                int m = crmModels.COST_ZZFTT.Update(checkdata[i], token);
                if (m < 0)
                {
                    webmsg.KEY = m;
                    webmsg.MSG = "回退失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "回退成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Data_DaoRu_LKAYEARTT()
        {
            token = appClass.CRM_Gettoken();
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
                    string[] sheet = { "年度费用主数据", "门店情况", "费用明细", "产品利润" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //年度费用主数据
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("合同年份") == false || data1.Columns.Contains("申请人") == false || data1.Columns.Contains("申请日期") == false)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "请使用指定的导入模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data1.Rows.Count > 0)
                                {
                                    webmsg.KEY = 1;
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["合同年份"].ToString().Length != 4)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "年度费用主数据第" + (i + 2) + "行合同年份格式不正确！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        CRM_HG_STAFF cx_sqr = new CRM_HG_STAFF();
                                        cx_sqr.STAFFNAME = data1.Rows[i]["申请人"].ToString();
                                        CRM_HG_STAFFList[] SQR = crmModels.HG_STAFF.ReadByParam(cx_sqr, token);
                                        if (SQR.Length == 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "年度费用主数据第" + (i + 2) + "行申请人不存在！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        cx_sqr.STAFFNAME = data1.Rows[i]["修改人"].ToString();
                                        CRM_HG_STAFFList[] XGR = crmModels.HG_STAFF.ReadByParam(cx_sqr, token);
                                        if (XGR.Length == 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "年度费用主数据第" + (i + 2) + "行修改人不存在！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        //try
                                        //{
                                        //    DateTime temp1 = Convert.ToDateTime(data1.Rows[i]["申请日期"].ToString());
                                        //}
                                        //catch
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "年度费用主数据第" + (i + 2) + "行申请日期格式不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}
                                        //try
                                        //{
                                        //    DateTime temp2 = Convert.ToDateTime(data1.Rows[i]["最后修改日期"].ToString());
                                        //}
                                        //catch
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "年度费用主数据第" + (i + 2) + "行最后修改日期格式不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}
                                        CRM_Report_KHModel cx_kh = new CRM_Report_KHModel();
                                        cx_kh.CRMID = data1.Rows[i]["LKA系统CRM编号"].ToString();
                                        CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cx_kh, 0, token);
                                        if (KH.Length == 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "年度费用主数据第" + (i + 2) + "行LKA系统CRM编号不存在！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        else
                                        {
                                            if (KH[0].KHLX != 7 || KH[0].MCSX != 1)
                                            {
                                                webmsg.KEY = 0;
                                                webmsg.MSG = webmsg.MSG + "年度费用主数据第" + (i + 2) + "行LKA系统客户类型不正确！";
                                                //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                            }
                                        }


                                        if (data1.Rows[i]["经销商SAP编号"].ToString() != "" && crmModels.KH_HZHB.ReadSAPHZHB(data1.Rows[i]["经销商SAP编号"].ToString(), token) == null)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "年度费用主数据第" + (i + 2) + "行经销商SAP编号不存在！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        try
                                        {
                                            DateTime temp1 = Convert.ToDateTime(data1.Rows[i]["费用开始时间"].ToString());
                                        }
                                        catch
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "年度费用主数据第" + (i + 2) + "行费用开始时间格式不正确！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        try
                                        {
                                            DateTime temp2 = Convert.ToDateTime(data1.Rows[i]["费用结束时间"].ToString());
                                        }
                                        catch
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "年度费用主数据第" + (i + 2) + "行费用结束时间格式不正确！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }

                                        CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
                                        cxmodel.LKAID = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["LKA系统CRM编号"].ToString(), token).KHID;
                                        cxmodel.HTYEAR = "";
                                        cxmodel.BEGINDATE = Convert.ToDateTime(data1.Rows[i]["费用开始时间"]).ToString("yyyy-MM-dd");
                                        cxmodel.ENDDATE = Convert.ToDateTime(data1.Rows[i]["费用结束时间"]).ToString("yyyy-MM-dd");
                                        int count = crmModels.COST_LKAYEARTT.Verify(cxmodel, token);
                                        if (count != 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "年度费用主数据第" + (i + 2) + "行起止日期与现有数据重复！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }


                                        //int KHLX2 = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["大客户类型"].ToString(), 52, token);
                                        //if (KHLX2 == 0)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "经销商、电商、B2B第" + (i + 2) + "行大客户类型不存在！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}
                                    }

                                    if (webmsg.KEY == 0)
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
                    }
                    #endregion

                    DataTable data2 = ExcelToDataTable(savePath, sheet[1], true);      //门店情况
                    #region
                    if (data2 != null)
                    {
                        if (data2.Columns.Contains("合同年份") == false || data2.Columns.Contains("LKA系统CRM编号") == false || data2.Columns.Contains("门店类型") == false)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "请使用指定的导入模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data2.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data2.Rows.Count; i++)
                                    {

                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                webmsg.KEY = 0;
                                webmsg.MSG = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                            }



                        }
                    }
                    #endregion

                    DataTable data3 = ExcelToDataTable(savePath, sheet[2], true);      //费用明细
                    #region
                    if (data3 != null)
                    {
                        if (data3.Columns.Contains("合同年份") == false || data3.Columns.Contains("LKA系统CRM编号") == false || data3.Columns.Contains("进场费") == false)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "请使用指定的导入模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data3.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data3.Rows.Count; i++)
                                    {
                                        if (data3.Rows[i]["合同年份"].ToString().Length != 4)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行合同年份格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }

                                        CRM_Report_KHModel cx_kh = new CRM_Report_KHModel();
                                        cx_kh.CRMID = data3.Rows[i]["LKA系统CRM编号"].ToString();
                                        CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cx_kh, 0, token);
                                        if (KH.Length == 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行LKA系统CRM编号不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (KH[0].KHLX != 7 || KH[0].MCSX != 1)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行LKA系统客户类型不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }

                                        CRM_COST_LKAYEARTT cxyear = new CRM_COST_LKAYEARTT();
                                        cxyear.LKAID = KH[0].KHID;
                                        cxyear.HTYEAR = data3.Rows[i]["合同年份"].ToString();
                                        CRM_COST_LKAYEARTT[] LKAYEAR = crmModels.COST_LKAYEARTT.ReadByParam(cxyear, 0, token);
                                        if (LKAYEAR.Length == 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行对应年度费用不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }

                                        if (Regex.IsMatch(data3.Rows[i]["进场费"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["进场费"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行进场费格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["新品费"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["新品费"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行新品费格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["新店开业费"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["新店开业费"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行新店开业费格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["合同续签费"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["合同续签费"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行合同续签费格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["陈列费"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["陈列费"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行陈列费格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["店节庆，周年庆"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["店节庆，周年庆"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行店节庆，周年庆格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["特殊陈列费"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["特殊陈列费"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行特殊陈列费格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["海报费"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["海报费"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行海报费格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["堆头促销费"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["堆头促销费"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行堆头促销费格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["其他费用"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["其他费用"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行其他费用格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                        if (Regex.IsMatch(data3.Rows[i]["制作费"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data3.Rows[i]["制作费"].ToString() != "")
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "费用明细第" + (i + 2) + "行制作费格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }


                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                webmsg.KEY = 0;
                                webmsg.MSG = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                            }



                        }
                    }
                    #endregion

                    DataTable data4 = ExcelToDataTable(savePath, sheet[3], true);      //产品利润
                    #region
                    if (data4 != null)
                    {
                        if (data4.Columns.Contains("合同年份") == false || data4.Columns.Contains("LKA系统CRM编号") == false || data4.Columns.Contains("产品分类") == false)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "请使用指定的导入模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data4.Rows.Count > 0)
                                {
                                    webmsg.KEY = 1;
                                    for (int i = 0; i < data4.Rows.Count; i++)
                                    {

                                        CRM_COST_LKAYEARTT cx_lkayear = new CRM_COST_LKAYEARTT();
                                        cx_lkayear.HTYEAR = data4.Rows[i]["合同年份"].ToString();
                                        cx_lkayear.LKAID = crmModels.KH_KH.ReadByCRMID(data4.Rows[i]["LKA系统CRM编号"].ToString(), token).KHID;
                                        CRM_COST_LKAYEARTT[] LKAYEAR = crmModels.COST_LKAYEARTT.ReadByParam(cx_lkayear, 0, token);
                                        if (LKAYEAR.Length == 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行" + data4.Rows[i]["LKA系统CRM编号"].ToString() + "找不到对应的年度费用！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }

                                        CRM_COST_CP cx_cp = new CRM_COST_CP();
                                        cx_cp.SAPCP = data4.Rows[i]["产品编号"].ToString();
                                        cx_cp.LKAYEARTTID = LKAYEAR[0].LKAYEARTTID;
                                        CRM_COST_CP[] CP = crmModels.COST_CP.ReadByParam(cx_cp, token);
                                        if (CP.Length != 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行产品已经存在！";
                                            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }

                                        //if (data4.Rows[i]["合同年份"].ToString().Length != 4)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "费用明细第" + (i + 2) + "行合同年份格式不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}

                                        //CRM_Report_KHModel cx_kh = new CRM_Report_KHModel();
                                        //cx_kh.CRMID = data4.Rows[i]["LKA系统CRM编号"].ToString();
                                        //CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cx_kh, 0, token);
                                        //if (KH.Length == 0)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "费用明细第" + (i + 2) + "行LKA系统CRM编号不存在！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}
                                        //if (KH[0].KHLX != 7 || KH[0].MCSX != 1)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "费用明细第" + (i + 2) + "行LKA系统客户类型不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}

                                        //CRM_COST_LKAYEARTT cxyear = new CRM_COST_LKAYEARTT();
                                        //cxyear.LKAID = KH[0].KHID;
                                        //cxyear.HTYEAR = data4.Rows[i]["合同年份"].ToString();
                                        //CRM_COST_LKAYEARTT[] LKAYEAR = crmModels.COST_LKAYEARTT.ReadByParam(cxyear, 0, token);
                                        //if (LKAYEAR.Length == 0)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "费用明细第" + (i + 2) + "行对应年度费用不存在！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}




                                    }


                                    if (webmsg.KEY == 0)
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
                    }
                    #endregion




                    //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                    #region
                    //年度费用主数据
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        #region
                        CRM_COST_LKAYEARTT model = new CRM_COST_LKAYEARTT();
                        model.HTYEAR = data1.Rows[i]["合同年份"].ToString();
                        model.LKAID = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["LKA系统CRM编号"].ToString(), token).KHID;

                        CRM_COST_LKAYEARTT[] xianyou = crmModels.COST_LKAYEARTT.ReadByParam(model, 0, token);
                        if (xianyou.Length != 0)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "年度费用主数据的第" + (i + 2) + "行与已有数据重复！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }


                        CRM_HG_STAFF cx_staff = new CRM_HG_STAFF();
                        cx_staff.STAFFNAME = data1.Rows[i]["申请人"].ToString();
                        CRM_HG_STAFFList[] staff = crmModels.HG_STAFF.ReadByParam(cx_staff, token);
                        model.SQR = staff[0].STAFFID;

                        model.SQSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        model.XGR = staff[0].STAFFID;
                        model.LASTXGSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        model.JXSID = crmModels.KH_KH.ReadBySAPSN(data1.Rows[i]["经销商SAP编号"].ToString(), token).KHID;
                        model.BEGINDATE = Convert.ToDateTime(data1.Rows[i]["费用开始时间"]).ToString("yyyy-MM-dd");
                        model.ENDDATE = Convert.ToDateTime(data1.Rows[i]["费用结束时间"]).ToString("yyyy-MM-dd");

                        //allcount是两个时间点的跨度的月份总数，然后根据过15算一个月的原则把不算的月份删掉
                        int allcount = (Convert.ToDateTime(model.ENDDATE).Year - Convert.ToDateTime(model.BEGINDATE).Year) * 12 + (Convert.ToDateTime(model.ENDDATE).Month - Convert.ToDateTime(model.BEGINDATE).Month) + 1;
                        if (Convert.ToDateTime(model.BEGINDATE).Day > 15)
                        {
                            allcount--;
                        }
                        if (Convert.ToDateTime(model.ENDDATE).Day < 15)
                        {
                            allcount--;
                        }
                        model.MONTHCOUNT = allcount;

                        CRM_KH_KHList KH = crmModels.KH_KH.Read(model.LKAID, token);
                        model.FIRSTTIME = KH.FIRSTTIME;
                        model.PSQK = KH.PSQK;
                        model.FSFW = KH.FSFW;
                        model.MANAGEWAY = KH.MANAGEWAY;
                        model.PAYWAY = KH.PAYWAY;
                        CRM_KH_KHQTXXList[] JP = crmModels.KH_KHQTXX.Read(model.LKAID, 3, token);
                        if (JP.Length == 0)
                            model.JZPPNAME = "";
                        else
                        {
                            model.JZPPNAME = JP[0].XXMC;
                            for (int j = 1; j < JP.Length; j++)
                            {
                                model.JZPPNAME = model.JZPPNAME + "," + JP[j].XXMC;
                            }
                        }
                        model.GSLXR = KH.GSLXR;
                        model.GSLXRZW = KH.GSLXRZW;
                        model.GSLXDH = KH.GSLXDH;
                        model.QTCP = KH.SUPPORTOTHER;
                        //model.SFXJMC = KH.ISNEW;
                        model.SFZJQDHT = KH.PACT;
                        model.KAGXLKA = KH.BELONGKA;
                        model.WEBSITE = KH.WEBSITE;
                        model.ACCOUNT = KH.ACCOUNT;


                        model.ISACTIVE = 60;
                        int id = crmModels.COST_LKAYEARTT.Create(model, token);
                        if (id <= 0)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "新增年度费用主数据的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else                //抬头新增成功，然后开始新增细项数据
                        {
                            CRM_COST_LKAYEARMD[] MD = crmModels.COST_LKAYEARMD.ReadMDQKbyKHID(model.LKAID, token);
                            for (int j = 0; j < MD.Length; j++)            //新增门店子表
                            {
                                CRM_COST_LKAYEARMD MDmodel = new CRM_COST_LKAYEARMD();
                                MDmodel.LKAYEARTTID = id;
                                MDmodel.BAMDSL = MD[j].BAMDSL;
                                MDmodel.MDLX = MD[j].MDLX;
                                int ii = crmModels.COST_LKAYEARMD.Create(MDmodel, token);
                            }

                            CRM_HG_DICT[] XS = crmModels.HG_DICT.Read(66, 0, token);
                            for (int j = 0; j < XS.Length; j++)         //新增卖场销售子表
                            {
                                CRM_COST_LKAYEARXS XSmodel = new CRM_COST_LKAYEARXS();
                                XSmodel.LKAYEARTTID = id;
                                XSmodel.PP = XS[j].DICID;
                                int ii = crmModels.COST_LKAYEARXS.Create(XSmodel, token);
                            }

                            CRM_COST_LKAYEARCOST[] COST = crmModels.COST_LKAYEARCOST.ReadCOSTByKHID(model.LKAID, model.HTYEAR, token);
                            for (int j = 0; j < COST.Length; j++)     //新增费用申请子表
                            {
                                CRM_COST_LKAYEARCOST COSTmodel = new CRM_COST_LKAYEARCOST();
                                COSTmodel.LKAYEARTTID = id;
                                COSTmodel.COSTITEMID = COST[j].COSTITEMID;
                                COSTmodel.COSTITEMYEAR = model.HTYEAR;
                                COSTmodel.LASTHTTKNR = COST[j].LASTHTTKNR;
                                COSTmodel.LASTFYYGE = COST[j].LASTFYYGE;
                                COSTmodel.ISACTIVE = 1;
                                int ii = crmModels.COST_LKAYEARCOST.Create(COSTmodel, token);
                            }



                        }
                        #endregion
                    }
                    //门店情况
                    for (int i = 0; i < data2.Rows.Count; i++)
                    {

                    }
                    //费用明细
                    for (int i = 0; i < data3.Rows.Count; i++)
                    {
                        #region
                        //CRM_COST_LKAYEARCOST model = new CRM_COST_LKAYEARCOST();

                        CRM_COST_LKAYEARTT cx_lkayear = new CRM_COST_LKAYEARTT();
                        cx_lkayear.HTYEAR = data3.Rows[i]["合同年份"].ToString();
                        cx_lkayear.LKAID = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["LKA系统CRM编号"].ToString(), token).KHID;
                        CRM_COST_LKAYEARTT[] LKAYEAR = crmModels.COST_LKAYEARTT.ReadByParam(cx_lkayear, 0, token);
                        if (LKAYEAR.Length == 0)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "费用明细的第" + (i + 2) + "行找不到对应的年度费用！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }





                        CRM_COST_LKAYEARCOST cx_cost = new CRM_COST_LKAYEARCOST();
                        cx_cost.LKAYEARTTID = LKAYEAR[0].LKAYEARTTID;
                        CRM_COST_LKAYEARCOST[] cost = crmModels.COST_LKAYEARCOST.ReadByParam(cx_cost, token);
                        for (int j = 0; j < cost.Length; j++)
                        {
                            switch (cost[j].COSTITEMID)
                            {
                                case 4:
                                    //进场费
                                    if (data3.Rows[i]["进场费"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["进场费"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["进场费"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细进场费的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 5:
                                    //新品费
                                    if (data3.Rows[i]["新品费"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["新品费"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["新品费"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 6:
                                    //合同续签费
                                    if (data3.Rows[i]["合同续签费"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["合同续签费"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["合同续签费"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 7:
                                    //店节庆，周年庆
                                    if (data3.Rows[i]["店节庆，周年庆"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["店节庆，周年庆"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["店节庆，周年庆"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 8:
                                    //新店开业费
                                    if (data3.Rows[i]["新店开业费"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["新店开业费"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["新店开业费"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 9:
                                    //陈列费
                                    if (data3.Rows[i]["陈列费"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["陈列费"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["陈列费"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 10:
                                    //特殊陈列费
                                    if (data3.Rows[i]["特殊陈列费"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["特殊陈列费"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["特殊陈列费"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 11:
                                    //海报费
                                    if (data3.Rows[i]["海报费"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["海报费"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["海报费"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 12:
                                    //堆头促销费
                                    if (data3.Rows[i]["堆头促销费"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["堆头促销费"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["堆头促销费"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 13:
                                    //其他费用
                                    if (data3.Rows[i]["其他费用"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["其他费用"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["其他费用"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                case 14:
                                    //制作费
                                    if (data3.Rows[i]["制作费"].ToString().Trim() != "")
                                    {
                                        cost[j].THISFYYGE = Convert.ToDouble(data3.Rows[i]["制作费"].ToString());
                                        cost[j].THISFYYGEXG = Convert.ToDouble(data3.Rows[i]["制作费"].ToString());
                                        int id = crmModels.COST_LKAYEARCOST.UpdateSPJE(cost[j], token);
                                        if (id <= 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = "导入费用明细的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        }
                                    }

                                    break;
                                default:

                                    break;
                            }
                            crmModels.COST_LKAEachYEAR.UpdateByTTID(cost[j].LKAYEARTTID, token);

                        }



                        #endregion
                    }
                    //产品利润
                    for (int i = 0; i < data4.Rows.Count; i++)
                    {
                        CRM_COST_LKAYEARTT cx_lkayear = new CRM_COST_LKAYEARTT();
                        cx_lkayear.HTYEAR = data4.Rows[i]["合同年份"].ToString();
                        cx_lkayear.LKAID = crmModels.KH_KH.ReadByCRMID(data4.Rows[i]["LKA系统CRM编号"].ToString(), token).KHID;
                        CRM_COST_LKAYEARTT[] LKAYEAR = crmModels.COST_LKAYEARTT.ReadByParam(cx_lkayear, 0, token);
                        if (LKAYEAR.Length == 0)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "产品利润的第" + (i + 2) + "行找不到对应的年度费用！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }

                        CRM_COST_CP cp = new CRM_COST_CP();
                        cp.LKAYEARTTID = LKAYEAR[0].LKAYEARTTID;
                        cp.SAPCP = data4.Rows[i]["产品编号"].ToString();
                        cp.CPFL = data4.Rows[i]["产品分类"].ToString();
                        cp.MCSJGJ = Convert.ToDouble(data4.Rows[i]["卖场实际供价"]);
                        cp.MCSJSJ = Convert.ToDouble(data4.Rows[i]["卖场实际售价"]);
                        cp.LASTYEARSJXL = Convert.ToInt32(data4.Rows[i]["上年度实际销量"]);
                        cp.THISYEARSLYG = Convert.ToInt32(data4.Rows[i]["本年度销量预估"]);
                        cp.LASTYEARXSSJ = Convert.ToDouble(data4.Rows[i]["上年度销售实际"]);
                        cp.THISYEARXSYG = Convert.ToDouble(data4.Rows[i]["本年度销售预估"]);
                        cp.LASTYEARXSSJ_SJ = Convert.ToDecimal(data4.Rows[i]["上年度销售实际_售价"]);
                        cp.THISYEARXSYG_SJ = Convert.ToDecimal(data4.Rows[i]["本年度销售预估_售价"]);
                        cp.CCJXS = Convert.ToDouble(data4.Rows[i]["按出厂价计算销售"]);
                        cp.MLXJ = Convert.ToDouble(data4.Rows[i]["毛利小计"]);
                        cp.BEIZ = "";
                        cp.ISACTIVE = 3;
                        int id = crmModels.COST_CP.Create(cp, token);
                        if (id <= 0)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "导入产品利润的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            crmModels.COST_LKAYEARXS.UpdateSonlukXS(cp.LKAYEARTTID, token);
                            crmModels.COST_LKAEachYEAR.UpdateByTTID(cp.LKAYEARTTID, token);
                        }
                    }


                    #endregion
                    webmsg.KEY = 1;
                    webmsg.MSG = "新增成功！";
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
        public string Data_DaoRu_CPLR(int LKAYEARTTID)
        {
            token = appClass.CRM_Gettoken();
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
                    string[] sheet = { "产品利润" };


                    //开始做数据校验


                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //产品利润
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("产品名称") == false || data1.Columns.Contains("卖场实际供价（元/卡）") == false)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "请使用指定的导入模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data1.Rows.Count > 0)
                                {
                                    webmsg.KEY = 1;
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        //CRM_COST_LKAPRODUCT cx_cp = new CRM_COST_LKAPRODUCT();
                                        //cx_cp.SAPCP = data1.Rows[i]["产品编号"].ToString();
                                        //cx_cp.CLASS1 = 2076;
                                        //CRM_COST_LKAPRODUCT[] CP = crmModels.COST_LKAPRODUCT.ReadByParam(cx_cp, token);
                                        //if(CP.Length == 0)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行" + "找不到对应的产品编号！";
                                        //}

                                        CRM_COST_LKAPRODUCT cx_cp2 = new CRM_COST_LKAPRODUCT();
                                        cx_cp2.CPMC = data1.Rows[i]["产品名称"].ToString();
                                        cx_cp2.CLASS1 = 2076;
                                        CRM_COST_LKAPRODUCT[] CP2 = crmModels.COST_LKAPRODUCT.ReadByParam(cx_cp2, token);
                                        if (CP2.Length == 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行找不到对应的产品编号！";
                                        }
                                        else if (CP2.Length > 1)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行的产品名称存在多个对应的产品，请输入精确的产品名称！";
                                        }
                                        else
                                        {
                                            CRM_COST_CP cx_cp3 = new CRM_COST_CP();
                                            cx_cp3.SAPCP = CP2[0].SAPCP;
                                            cx_cp3.LKAYEARTTID = LKAYEARTTID;
                                            CRM_COST_CP[] CP3 = crmModels.COST_CP.ReadByParam(cx_cp3, token);
                                            if (CP3.Length != 0)
                                            {
                                                webmsg.KEY = 0;
                                                webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行的产品已经存在！";
                                            }
                                        }




                                        if (Regex.IsMatch(data1.Rows[i]["卖场实际供价（元/卡）"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行" + "的卖场实际供价格式不正确，金额精确到小数点后两位！";
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["卖场实际售价（元/卡）"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行" + "的卖场实际售价格式不正确，金额精确到小数点后两位！";
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["上年度实际销量（卡）"].ToString(), @"^\d+$") == false)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行" + "的上年度实际销量必须为整数！";
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["本年度销量预估（卡）"].ToString(), @"^\d+$") == false)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "产品利润的第" + (i + 2) + "行" + "的本年度销量预估必须为整数！";
                                        }



                                        //if (data4.Rows[i]["合同年份"].ToString().Length != 4)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "费用明细第" + (i + 2) + "行合同年份格式不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}

                                        //CRM_Report_KHModel cx_kh = new CRM_Report_KHModel();
                                        //cx_kh.CRMID = data4.Rows[i]["LKA系统CRM编号"].ToString();
                                        //CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cx_kh, 0, token);
                                        //if (KH.Length == 0)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "费用明细第" + (i + 2) + "行LKA系统CRM编号不存在！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}
                                        //if (KH[0].KHLX != 7 || KH[0].MCSX != 1)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "费用明细第" + (i + 2) + "行LKA系统客户类型不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}

                                        //CRM_COST_LKAYEARTT cxyear = new CRM_COST_LKAYEARTT();
                                        //cxyear.LKAID = KH[0].KHID;
                                        //cxyear.HTYEAR = data4.Rows[i]["合同年份"].ToString();
                                        //CRM_COST_LKAYEARTT[] LKAYEAR = crmModels.COST_LKAYEARTT.ReadByParam(cxyear, 0, token);
                                        //if (LKAYEAR.Length == 0)
                                        //{
                                        //    webmsg.KEY = 0;
                                        //    webmsg.MSG = "费用明细第" + (i + 2) + "行对应年度费用不存在！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                                        //}




                                    }


                                    if (webmsg.KEY == 0)
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
                    }
                    #endregion




                    //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入

                    //产品利润
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        #region
                        CRM_COST_LKAYEARTT cx_year = new CRM_COST_LKAYEARTT();
                        cx_year.LKAYEARTTID = LKAYEARTTID;
                        CRM_COST_LKAYEARTT[] LKAYEAR = crmModels.COST_LKAYEARTT.ReadByParam(cx_year, 0, token);


                        CRM_COST_LKAPRODUCT cx_cp = new CRM_COST_LKAPRODUCT();
                        cx_cp.CPMC = data1.Rows[i]["产品名称"].ToString();
                        cx_cp.CLASS1 = 2076;
                        CRM_COST_LKAPRODUCT[] CP = crmModels.COST_LKAPRODUCT.ReadByParam(cx_cp, token);

                        CRM_COST_CP cp = new CRM_COST_CP();
                        cp.LKAYEARTTID = LKAYEARTTID;
                        cp.SAPCP = CP[0].SAPCP;
                        cp.CPFL = crmModels.SAP_Report.SAP_CPFL(CP[0].SAPCP, token);
                        cp.MCSJGJ = Convert.ToDouble(data1.Rows[i]["卖场实际供价（元/卡）"]);
                        cp.MCSJSJ = Convert.ToDouble(data1.Rows[i]["卖场实际售价（元/卡）"]);
                        cp.LASTYEARSJXL = Convert.ToInt32(data1.Rows[i]["上年度实际销量（卡）"]);
                        cp.THISYEARSLYG = Convert.ToInt32(data1.Rows[i]["本年度销量预估（卡）"]);
                        cp.LASTYEARXSSJ = Convert.ToDouble(data1.Rows[i]["卖场实际供价（元/卡）"]) * Convert.ToDouble(data1.Rows[i]["上年度实际销量（卡）"]);
                        cp.THISYEARXSYG = Convert.ToDouble(data1.Rows[i]["卖场实际供价（元/卡）"]) * Convert.ToDouble(data1.Rows[i]["本年度销量预估（卡）"]);


                        CRM_KH_KHList KH = crmModels.KH_KH.Read(LKAYEAR[0].LKAID, token);
                        if (KH.SF == 165)
                        {
                            //省内
                            cp.CCJXS = Convert.ToDouble(data1.Rows[i]["本年度销量预估（卡）"]) * CP[0].BZNUM * CP[0].PRICE_IN;
                            cp.MLXJ = Convert.ToDouble(data1.Rows[i]["本年度销量预估（卡）"]) * CP[0].BZNUM * CP[0].PROFIT_IN;
                        }
                        {
                            //省外
                            cp.CCJXS = Convert.ToDouble(data1.Rows[i]["本年度销量预估（卡）"]) * CP[0].BZNUM * CP[0].PRICE_OUT;
                            cp.MLXJ = Convert.ToDouble(data1.Rows[i]["本年度销量预估（卡）"]) * CP[0].BZNUM * CP[0].PROFIT_OUT;
                        }



                        cp.BEIZ = "";
                        cp.ISACTIVE = 1;
                        int id = crmModels.COST_CP.Create(cp, token);
                        if (id > 0)     //要更新卖场销售中双鹿的销售数据
                        {
                            crmModels.COST_LKAYEARXS.UpdateSonlukXS(LKAYEARTTID, token);
                        }
                        else
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "导入产品利润的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        #endregion
                    }



                    webmsg.KEY = 1;
                    webmsg.MSG = "新增成功！";
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
        public string Data_Insert_CPLX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CPLX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CPLX>(data);
            model.CZR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_CPLX.Create(model, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_CPLX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CPLX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CPLX>(data);
            model.CZR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CPLX.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_CPLX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CPLX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CPLX>(cxdata);
            CRM_COST_CPLX[] data = crmModels.COST_CPLX.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_CPLX(int CPLXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CPLX.Delete(CPLXID, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_CXHD(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHD>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 10;

            CRM_KH_KH cxZDWD = new CRM_KH_KH();
            cxZDWD.KHID = model.KHID;
            cxZDWD.KHLX = 5;
            CRM_KH_KH[] ZDWD = crmModels.KH_KH.ReadByJXS(cxZDWD, token);
            model.YBAWDSL = ZDWD.Length;


            int i = crmModels.COST_CXHD.Create(model, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_CXHD(string data, string PG)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHD updatemodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHD>(data);
            updatemodel.XGR = appClass.CRM_GetStaffid();
            int cxhdid = crmModels.COST_CXHD.Update(updatemodel, token);

            CRM_COST_CXHD cx_cxhd = new CRM_COST_CXHD();
            cx_cxhd.CXHDID = cxhdid;
            CRM_COST_CXHD model = crmModels.COST_CXHD.ReadByParam(cx_cxhd, 0, token)[0];



            if (model.ISACTIVE == 10)
            {
                model.ISACTIVE = 20;
                //提交OA
                #region

                CRM_COST_CXHDTC cx_tc = new CRM_COST_CXHDTC();
                cx_tc.CXHDID = model.CXHDID;
                CRM_COST_CXHDTC[] TC = crmModels.COST_CXHDTC.ReadByParam(cx_tc, token);

                CRM_COST_GSZCFS cx_gszcfs = new CRM_COST_GSZCFS();
                cx_gszcfs.CXHDID = model.CXHDID;
                CRM_COST_GSZCFS[] GSZCFS = crmModels.COST_GSZCFS.ReadByParam(cx_gszcfs, token);



                CRM_OA_BASIC basic = new CRM_OA_BASIC();
                CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
                basic.LoginName = staffmodel.STAFFNO;
                basic.TemplateCode = crmModels.SYS_CS.Read(24, token)[0].CS.ToString();

                CRM_OA_CXHD list = new CRM_OA_CXHD();
                list.LCLX = "申请";
                list.SQRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                list.GSYEAR = model.GSYEAR;
                list.JXSMC = model.MC;
                list.JXSSAPSN = model.MC;
                list.HDMC = model.HDMC;
                list.HDBH = model.HDBH;
                list.HDDATE = model.HDBEGINDATE + "  -  " + model.HDENDDATE;
                list.THDATE = model.THBEGINDATE + "  -  " + model.THENDDATE;
                list.HDDX = model.HDDX;
                list.HDMD = model.HDMD;
                list.GSZCSM = model.GSZCSM;
                list.YJCJHDWDSL = model.CJHDWDSL.ToString();
                list.BASL = model.YBAWDSL.ToString();

                string year = DateTime.Now.Year.ToString();
                string begin = "";
                string end = "";
                if (year == model.GSYEAR)
                {
                    begin = year + "0101";
                    end = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    begin = model.GSYEAR + "0101";
                    end = model.GSYEAR + "1231";
                }
                SAP_RWJDInfo XSRW = crmModels.SAP_Report.SAP_RWJD(model.SAPSN, model.GSYEAR, begin, end, token);

                list.JXSXSRW = Convert.ToDouble(XSRW.Task1).ToString();
                list.JXSARW = Convert.ToDouble(XSRW.Task2).ToString();

                list.BASL = model.YBAWDSL.ToString();

                list.CXHDTC = new CRM_OA_CXHD_TC[TC.Length];
                for (int i = 0; i < TC.Length; i++)
                {
                    list.CXHDTC[i] = new CRM_OA_CXHD_TC();
                    list.CXHDTC[i].HDTCLX = "套餐" + TC[i].HXM;
                    list.CXHDTC[i].TCNR = TC[i].TCNR;
                    list.CXHDTC[i].TCJE = TC[i].TCJE.ToString();
                    list.CXHDTC[i].GIFT = TC[i].GIFT;
                    list.CXHDTC[i].PRICE = TC[i].GIFTPRICE.ToString();
                    list.CXHDTC[i].TCCOUNT = TC[i].TCCOUNT.ToString();
                    list.CXHDTC[i].YJXS = TC[i].YJXS.ToString();
                    list.CXHDTC[i].YJLPJE = TC[i].YJLPJE.ToString();
                    list.CXHDTC[i].FB = TC[i].FB.ToString();
                    list.CXHDTC[i].BEIZ = TC[i].BEIZ;
                }

                list.GSZCFS = new CRM_OA_CXHD_GSZCFS[GSZCFS.Length];
                for (int i = 0; i < GSZCFS.Length; i++)
                {
                    list.GSZCFS[i] = new CRM_OA_CXHD_GSZCFS();
                    list.GSZCFS[i].CPFL = GSZCFS[i].CPFL;
                    list.GSZCFS[i].DPMC = GSZCFS[i].CPLX;
                    list.GSZCFS[i].YJHDSL = GSZCFS[i].YJHDSL.ToString();
                    list.GSZCFS[i].YJXS = GSZCFS[i].YJXS.ToString();
                    list.GSZCFS[i].FYZCFS = GSZCFS[i].FYZCFSDES;
                    list.GSZCFS[i].FYZC = GSZCFS[i].FYZC.ToString();
                    list.GSZCFS[i].FYZCJE = GSZCFS[i].FYZCJE.ToString();
                    list.GSZCFS[i].SNYJXS = GSZCFS[i].SNYJXS.ToString();
                    list.GSZCFS[i].SNYJSL = GSZCFS[i].SNYJSL.ToString();
                }

                List<CRM_OA_CXHD_IMG> all_img = new List<CRM_OA_CXHD_IMG>();
                List<CRM_OA_CXHD_OPINION> all_opinion = new List<CRM_OA_CXHD_OPINION>();

                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 2066;
                cx_opinion.OACSBH = model.CXHDID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_CXHD_OPINION temp = new CRM_OA_CXHD_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;

                    //temp.MS = CXYmodel[i].MC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(38, model.CXHDID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_CXHD_IMG temp = new CRM_OA_CXHD_IMG();
                    temp.IMGML = FJ[j].ML;
                    //temp.IMGMS = CXYmodel[i].MC;
                    all_img.Add(temp);
                }

                list.OPINION = all_opinion.ToArray();
                list.IMG = all_img.ToArray();



                MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
                if (info.Key != "0" && info.Key != "-1")
                {



                    CRM_OA_TRANSMIT OAmodel = new CRM_OA_TRANSMIT();
                    OAmodel.OAID = info.Key;
                    OAmodel.OACSBH = model.CXHDID;
                    OAmodel.OACSLB = 2066;
                    OAmodel.OAZT = 1;
                    OAmodel.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(OAmodel, token);


                }
                else
                {
                    webmsg.KEY = Convert.ToInt32(info.Key);
                    webmsg.MSG = info.Value;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                #endregion
            }
            else if (model.ISACTIVE == 30)
            {
                model.ISACTIVE = 40;
                model.PG = PG;
            }
            else if (model.ISACTIVE == 40)
            {
                model.ISACTIVE = 45;

            }
            else if (model.ISACTIVE == 45)
            {
                model.ISACTIVE = 50;
                //提交OA
                #region

                CRM_COST_CXHDTC cx_tc = new CRM_COST_CXHDTC();
                cx_tc.CXHDID = model.CXHDID;
                CRM_COST_CXHDTC[] TC = crmModels.COST_CXHDTC.ReadByParam(cx_tc, token);

                CRM_COST_GSZCFS cx_gszcfs = new CRM_COST_GSZCFS();
                cx_gszcfs.CXHDID = model.CXHDID;
                CRM_COST_GSZCFS[] GSZCFS = crmModels.COST_GSZCFS.ReadByParam(cx_gszcfs, token);

                CRM_COST_CXHDPGHZ cx_pghz = new CRM_COST_CXHDPGHZ();
                cx_pghz.CXHDID = model.CXHDID;
                CRM_COST_CXHDPGHZ[] PGHZ = crmModels.COST_CXHDPGHZ.GetReport(cx_pghz, token);


                CRM_OA_BASIC basic = new CRM_OA_BASIC();
                CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
                basic.LoginName = staffmodel.STAFFNO;
                basic.TemplateCode = crmModels.SYS_CS.Read(24, token)[0].CS.ToString();

                CRM_OA_CXHD list = new CRM_OA_CXHD();
                list.LCLX = "核销";
                list.SQRQ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                list.GSYEAR = model.GSYEAR;
                list.JXSMC = model.MC;
                list.JXSSAPSN = model.MC;
                list.HDMC = model.HDMC;
                list.HDBH = model.HDBH;
                list.HDDATE = model.HDBEGINDATE + "  -  " + model.HDENDDATE;
                list.THDATE = model.THBEGINDATE + "  -  " + model.THENDDATE;
                list.HDDX = model.HDDX;
                list.HDMD = model.HDMD;
                list.GSZCSM = model.GSZCSM;
                list.YJCJHDWDSL = model.CJHDWDSL.ToString();
                list.BASL = model.YBAWDSL.ToString();

                string year = DateTime.Now.Year.ToString();
                string begin = "";
                string end = "";
                if (year == model.GSYEAR)
                {
                    begin = year + "0101";
                    end = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    begin = model.GSYEAR + "0101";
                    end = model.GSYEAR + "1231";
                }
                SAP_RWJDInfo XSRW = crmModels.SAP_Report.SAP_RWJD(model.SAPSN, model.GSYEAR, begin, end, token);

                list.JXSXSRW = Convert.ToDouble(XSRW.Task1).ToString();
                list.JXSARW = Convert.ToDouble(XSRW.Task2).ToString();

                list.BASL = model.YBAWDSL.ToString();
                list.PG = model.PG;

                CRM_COST_CJHDWD cx_cjhdwd = new CRM_COST_CJHDWD();
                cx_cjhdwd.CXHDID = model.CXHDID;
                CRM_COST_CJHDWD[] CJHGWD = crmModels.COST_CJHDWD.ReadByParam(cx_cjhdwd, token);
                list.CJHDWDSL = CJHGWD.Length.ToString() + "个（具体详见CRM系统）";



                list.CXHDTC = new CRM_OA_CXHD_TC[TC.Length];
                for (int i = 0; i < TC.Length; i++)
                {
                    list.CXHDTC[i] = new CRM_OA_CXHD_TC();
                    list.CXHDTC[i].HDTCLX = "套餐" + TC[i].HXM;
                    list.CXHDTC[i].TCNR = TC[i].TCNR;
                    list.CXHDTC[i].TCJE = TC[i].TCJE.ToString();
                    list.CXHDTC[i].GIFT = TC[i].GIFT;
                    list.CXHDTC[i].PRICE = TC[i].GIFTPRICE.ToString();
                    list.CXHDTC[i].TCCOUNT = TC[i].TCCOUNT.ToString();
                    list.CXHDTC[i].YJXS = TC[i].YJXS.ToString();
                    list.CXHDTC[i].YJLPJE = TC[i].YJLPJE.ToString();
                    list.CXHDTC[i].FB = TC[i].FB.ToString();
                    list.CXHDTC[i].BEIZ = TC[i].BEIZ;
                }

                list.GSZCFS = new CRM_OA_CXHD_GSZCFS[GSZCFS.Length];
                for (int i = 0; i < GSZCFS.Length; i++)
                {
                    list.GSZCFS[i] = new CRM_OA_CXHD_GSZCFS();
                    list.GSZCFS[i].CPFL = GSZCFS[i].CPFL;
                    list.GSZCFS[i].DPMC = GSZCFS[i].CPLX;
                    list.GSZCFS[i].YJHDSL = GSZCFS[i].YJHDSL.ToString();
                    list.GSZCFS[i].YJXS = GSZCFS[i].YJXS.ToString();
                    list.GSZCFS[i].FYZCFS = GSZCFS[i].FYZCFSDES;
                    list.GSZCFS[i].FYZC = GSZCFS[i].FYZC.ToString();
                    list.GSZCFS[i].FYZCJE = GSZCFS[i].FYZCJE.ToString();
                    list.GSZCFS[i].SNYJXS = GSZCFS[i].SNYJXS.ToString();
                    list.GSZCFS[i].SNYJSL = GSZCFS[i].SNYJSL.ToString();
                }

                list.CXHDPG = new CRM_OA_CXHD_CXHDPG[PGHZ.Length];
                for (int i = 0; i < PGHZ.Length; i++)
                {
                    list.CXHDPG[i] = new CRM_OA_CXHD_CXHDPG();
                    list.CXHDPG[i].CPFL = PGHZ[i].CPFL;
                    list.CXHDPG[i].DPMC = PGHZ[i].CPLX;
                    list.CXHDPG[i].SJHDSL = PGHZ[i].SJHDSL.ToString();
                    list.CXHDPG[i].SJHDXS = PGHZ[i].SJHDXS.ToString();
                    list.CXHDPG[i].FYZCFS = PGHZ[i].FYZCFSDES;
                    list.CXHDPG[i].FYZC = PGHZ[i].FYZC.ToString();
                    list.CXHDPG[i].FYZCJE = PGHZ[i].FYZCJE.ToString();
                    list.CXHDPG[i].SJTHL = PGHZ[i].SJTHL.ToString() + "%";
                    list.CXHDPG[i].BS = PGHZ[i].BS.ToString();
                    list.CXHDPG[i].BEIZ = PGHZ[i].BEIZ;
                }

                List<CRM_OA_CXHD_IMG> all_img = new List<CRM_OA_CXHD_IMG>();
                List<CRM_OA_CXHD_OPINION> all_opinion = new List<CRM_OA_CXHD_OPINION>();

                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION();
                cx_opinion.OACSLB = 2066;
                cx_opinion.OACSBH = model.CXHDID;
                CRM_OA_OPINION[] opinion = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion.Length; j++)
                {
                    CRM_OA_CXHD_OPINION temp = new CRM_OA_CXHD_OPINION();
                    temp.OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION;
                    temp.HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR;

                    //temp.MS = CXYmodel[i].MC;
                    all_opinion.Add(temp);
                }

                cx_opinion.OACSLB = 2079;
                CRM_OA_OPINION[] opinion2 = crmModels.OA_OPINION.ReadByParam(cx_opinion, token);
                for (int j = 0; j < opinion2.Length; j++)
                {
                    CRM_OA_CXHD_OPINION temp = new CRM_OA_CXHD_OPINION();
                    temp.OPINION = opinion2[j].SPSJ + " " + opinion2[j].SPRNAME + " " + opinion2[j].ATTITUDE + " " + opinion2[j].OPINION;
                    temp.HFNR = opinion2[j].HFSJ + " " + opinion2[j].STAFFNAME + " 回复内容： " + opinion2[j].HFNR;

                    //temp.MS = CXYmodel[i].MC;
                    all_opinion.Add(temp);
                }


                CRM_HG_WJJL[] FJ = crmModels.HG_WJJL.Read(38, model.CXHDID, token);
                for (int j = 0; j < FJ.Length; j++)
                {
                    CRM_OA_CXHD_IMG temp = new CRM_OA_CXHD_IMG();
                    temp.IMGML = FJ[j].ML;
                    //temp.IMGMS = CXYmodel[i].MC;
                    all_img.Add(temp);
                }

                list.OPINION = all_opinion.ToArray();
                list.IMG = all_img.ToArray();



                MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
                if (info.Key != "0" && info.Key != "-1")
                {



                    CRM_OA_TRANSMIT OAmodel = new CRM_OA_TRANSMIT();
                    OAmodel.OAID = info.Key;
                    OAmodel.OACSBH = model.CXHDID;
                    OAmodel.OACSLB = 2066;
                    OAmodel.OAZT = 1;
                    OAmodel.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(OAmodel, token);


                }
                else
                {
                    webmsg.KEY = Convert.ToInt32(info.Key);
                    webmsg.MSG = info.Value;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                #endregion
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "当前数据状态错误，无法修改！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }









            int id = crmModels.COST_CXHD.Update(model, token);
            webmsg.KEY = id;
            if (id > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }



        [HttpPost]
        public string Data_Select_CXHD(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHD>(cxdata);
            CRM_COST_CXHD[] data = crmModels.COST_CXHD.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_CXHD(int CXHDID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CXHD.Delete(CXHDID, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_CXHDTC(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDTC model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDTC>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_CXHDTC.Create(model, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_CXHDTC(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDTC model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDTC>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CXHDTC.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_CXHDTC(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDTC model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDTC>(cxdata);
            CRM_COST_CXHDTC[] data = crmModels.COST_CXHDTC.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_CXHDTC(int TCID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CXHDTC.Delete(TCID, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_GSZCFS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GSZCFS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GSZCFS>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;

            CRM_COST_LKAPRODUCT cx_cp = new CRM_COST_LKAPRODUCT();
            cx_cp.CPLXID = model.CPLXID;
            cx_cp.CLASS2 = 2077;
            CRM_COST_LKAPRODUCT[] CP = crmModels.COST_LKAPRODUCT.ReadByParam(cx_cp, token);
            if (CP.Length != 0)
            {
                string[] matnr = new string[CP.Length];
                for (int i = 0; i < CP.Length; i++)
                {
                    matnr[i] = CP[i].SAPCP;
                }

                CRM_COST_CXHD cx_cxhd = new CRM_COST_CXHD();
                cx_cxhd.CXHDID = model.CXHDID;
                CRM_COST_CXHD[] CXHD = crmModels.COST_CXHD.ReadByParam(cx_cxhd, 0, token);

                string begindate = "", enddate = "";
                begindate = CXHD[0].GSYEAR + "0101";
                enddate = CXHD[0].GSYEAR + "1231";

                SAP_RWJD2Info SAPdata = crmModels.SAP_Report.SAP_RWJD2(CXHD[0].SAPSN, begindate, enddate, matnr, token);

                model.SNYJXS = SAPdata.YJXS;
                model.SNYJSL = Convert.ToInt32(Math.Round(double.Parse(SAPdata.YJSL.ToString()), 2, MidpointRounding.AwayFromZero));


            }



            int id = crmModels.COST_GSZCFS.Create(model, token);

            webmsg.KEY = id;
            if (id > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_GSZCFS(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GSZCFS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GSZCFS>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_GSZCFS.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_GSZCFS(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_GSZCFS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_GSZCFS>(cxdata);
            CRM_COST_GSZCFS[] data = crmModels.COST_GSZCFS.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_GSZCFS(int ZCFSID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_GSZCFS.Delete(ZCFSID, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_CXHDPGQD(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDPGQD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDPGQD>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_CXHDPGQD.Create(model, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_CXHDPGQD(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDPGQD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDPGQD>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CXHDPGQD.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_CXHDPGQD(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDPGQD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDPGQD>(cxdata);
            CRM_COST_CXHDPGQD[] data = crmModels.COST_CXHDPGQD.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_CXHDPGQD(int PGQDID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CXHDPGQD.Delete(PGQDID, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Empty_CXHDPGQD(int CXHDID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CXHDPGQD.DeleteByCXHDID(CXHDID, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_CXHDPGHZ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDPGHZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDPGHZ>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_CXHDPGHZ.Create(model, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_CXHDPGHZ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDPGHZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDPGHZ>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_CXHDPGHZ.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_CXHDPGHZ(string cxdata, int ISACTIVE)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDPGHZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDPGHZ>(cxdata);
            if (ISACTIVE == 60)
            {
                //已核销的数据，查看数据库中保存的汇总数据
                CRM_COST_CXHDPGHZ[] data = crmModels.COST_CXHDPGHZ.ReadByParam(model, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            else
            {
                //未核销的数据，查看由清单实时查询的报表
                CRM_COST_CXHDPGHZ[] data = crmModels.COST_CXHDPGHZ.GetReport(model, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }

        }

        [HttpPost]
        public string Data_Report_CXHDPGHZ(int CXHDID)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CXHDPGHZ model = new CRM_COST_CXHDPGHZ();
            model.CXHDID = CXHDID;
            CRM_COST_CXHDPGHZ[] data = crmModels.COST_CXHDPGHZ.GetReport(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_CXHDPGHZ(int PGHZID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CXHDPGHZ.Delete(PGHZID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        [HttpPost]
        public string Data_FileUpload_CLFHX_DaoChu(string data)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                // CRM_COST_CLFHX[] cxmodel = JsonConvert.DeserializeObject<CRM_COST_CLFHX[]>(data);

                CRM_COST_CLFHX cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFHX>(data);
                CRM_COST_CLFHX[] model = crmModels.COST_CLFHX.ReadByParam(cxmodel, token);

                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/差旅费报销格式.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("财务对帐表");
                ISheet worksheet2 = workbook.GetSheet("业务员报销表");
                if (worksheet1 == null || worksheet2 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                int row1 = 0, row2 = 0;
                for (int i = 0; i < model.Length; i++)
                {
                    CRM_COST_CLFHX NODE = new CRM_COST_CLFHX();
                    NODE.CLFHXID = model[i].CLFHXID;
                    CRM_COST_CLFHX[] LIST = crmModels.COST_CLFHX.ReadByParam(NODE, token);

                    int cellIndex = 0;
                    int cellAdd = 0;

                    string[] str = model[i].XSSJ.Split('-');
                    string year = str[0];
                    string month = str[1];
                    string day = str[2];
                    string[] str2 = model[i].GSNY.Split('-');
                    string year2 = str2[0];
                    string month2 = str2[1];


                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1 + 1);
                    row.CreateCell(cellIndex++).SetCellValue(year);
                    row.CreateCell(cellIndex++).SetCellValue(month);
                    row.CreateCell(cellIndex++).SetCellValue(day);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WSJE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].STAFFNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].FGLDDES);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SFDES);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CWHSBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CWHSBHDES);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BEIZ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CBZX);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CBZXDES);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_JPWSJE);
                    if (model[i].JT_HCPSL == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_HCPSL, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_HCPWSJE);
                    if (model[i].JT_HCPSL2 == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_HCPSL2, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_HCPWSJE2);
                    if (model[i].JT_KCPSL == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_KCPSL, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_KCPWSJE);
                    if (model[i].JT_KCPSL2 == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_KCPSL2, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_KCPWSJE2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZS_DAYS);
                    if (model[i].ZS_SL == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].ZS_SL, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZS_WSJE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZS_DAYS2);
                    if (model[i].ZS_SL2 == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].ZS_SL2, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZS_WSJE2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BT_DAYS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BT_JE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].COSTITEMMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].QT_WSJE);
                    row.CreateCell(cellIndex++).SetCellValue(year2);
                    row.CreateCell(cellIndex++).SetCellValue(month2);
                    row1++;


                    //if (LIST.Length != 0 && LIST != null)
                    //{
                    NPOI.SS.UserModel.IRow NOrow = worksheet2.CreateRow(row2 + 1);
                    NOrow.CreateCell(cellAdd++).SetCellValue(year);
                    NOrow.CreateCell(cellAdd++).SetCellValue(month);
                    NOrow.CreateCell(cellAdd++).SetCellValue(day);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].HXJE);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].STAFFNAME);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].FGLDDES);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].SFDES);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].CWHSBH);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].CWHSBHDES);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].BEIZ);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].CBZX);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].CBZXDES);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_JPJE);
                    if (model[i].JT_HCPSL == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_HCPSL, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_HCPJE);
                    if (model[i].JT_HCPSL2 == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_HCPSL2, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_HCPJE2);
                    if (model[i].JT_KCPSL == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_KCPSL, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_KCPJE);
                    if (model[i].JT_KCPSL2 == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_KCPSL2, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_KCPJE2);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].ZS_DAYS);
                    if (model[i].ZS_SL == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].ZS_SL, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].ZS_JE);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].ZS_DAYS2);
                    if (model[i].ZS_SL2 == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].ZS_SL2, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].ZS_JE2);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].BT_DAYS);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].BT_JE);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].COSTITEMMC);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].QT_JE);
                    NOrow.CreateCell(cellAdd++).SetCellValue(year2);
                    NOrow.CreateCell(cellAdd++).SetCellValue(month2);

                    row2++;
                    //}

                }
                //ICellStyle style = workbook.CreateCellStyle();
                //style.Alignment = HorizontalAlignment.CenterSelection;//单元格必须有内容才能水平居中,放弃

                //for (int i = 0; i < model.Length + 1; i++)
                //{
                //    for (int j = 0; j < 31; j++)
                //    {
                //        ICell Temp_Cell1 = worksheet1.GetRow(i).GetCell(j);
                //        ICell Temp_Cell2 = worksheet2.GetRow(i).GetCell(j);

                //        Temp_Cell1.CellStyle = style;
                //        Temp_Cell2.CellStyle = style;
                //    }
                //}
                //获取当前列的宽度，然后对比本列的长度，取最大值
                for (int columnNum = 0; columnNum <= model.Length; columnNum++)
                {
                    int columnWidth = worksheet1.GetColumnWidth(columnNum) / 256;
                    for (int rowNum = 1; rowNum <= worksheet1.LastRowNum; rowNum++)
                    {
                        IRow currentRow;
                        //当前行未被使用过
                        if (worksheet1.GetRow(rowNum) == null)
                        {
                            currentRow = worksheet1.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = worksheet1.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            if (columnWidth < length)
                            {
                                columnWidth = length;
                            }
                        }
                    }
                    worksheet1.SetColumnWidth(columnNum, columnWidth * 256);
                }
                //获取当前列的宽度，然后对比本列的长度，取最大值
                for (int columnNum = 0; columnNum <= model.Length; columnNum++)
                {
                    int columnWidth = worksheet2.GetColumnWidth(columnNum) / 256;
                    for (int rowNum = 1; rowNum <= worksheet2.LastRowNum; rowNum++)
                    {
                        IRow currentRow;
                        //当前行未被使用过
                        if (worksheet2.GetRow(rowNum) == null)
                        {
                            currentRow = worksheet2.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = worksheet2.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            if (columnWidth < length)
                            {
                                columnWidth = length;
                            }
                        }
                    }
                    worksheet2.SetColumnWidth(columnNum, columnWidth * 256);
                }
                worksheet1.ForceFormulaRecalculation = true;
                worksheet2.ForceFormulaRecalculation = true;
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
        public string FileUpload_CLFHX_DaoChu(string data)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                CRM_COST_CLFHX[] model = JsonConvert.DeserializeObject<CRM_COST_CLFHX[]>(data);

                //CRM_COST_CLFHX cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CLFHX>(data);
                //CRM_COST_CLFHX[] model = crmModels.COST_CLFHX.ReadByParam(cxmodel, token);

                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/差旅费报销格式.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("财务对帐表");
                ISheet worksheet2 = workbook.GetSheet("业务员报销表");
                if (worksheet1 == null || worksheet2 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                int row1 = 0, row2 = 0;




                for (int i = 0; i < model.Length; i++)
                {
                    CRM_COST_CLFHX NODE = new CRM_COST_CLFHX();
                    NODE.CLFHXID = model[i].CLFHXID;
                    CRM_COST_CLFHX[] LIST = crmModels.COST_CLFHX.ReadByParam(NODE, token);



                    int cellIndex = 0;
                    int cellAdd = 0;

                    string[] str = model[i].XSSJ.Split('-');
                    string year = str[0];
                    string month = str[1];
                    string day = str[2];
                    string[] str2 = model[i].GSNY.Split('-');
                    string year2 = str2[0];
                    string month2 = str2[1];


                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1 + 1);
                    row.CreateCell(cellIndex++).SetCellValue(year);
                    row.CreateCell(cellIndex++).SetCellValue(month);
                    row.CreateCell(cellIndex++).SetCellValue(day);



                    row.CreateCell(cellIndex++).SetCellValue(model[i].WSJE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].STAFFNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].FGLDDES);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SFDES);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CWHSBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CWHSBHDES);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BEIZ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CBZX);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CBZXDES);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_JPWSJE);
                    if (model[i].JT_HCPSL == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_HCPSL, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_HCPWSJE);
                    if (model[i].JT_HCPSL2 == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_HCPSL2, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_HCPWSJE2);
                    if (model[i].JT_KCPSL == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_KCPSL, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_KCPWSJE);
                    if (model[i].JT_KCPSL2 == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_KCPSL2, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JT_KCPWSJE2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZS_DAYS);
                    if (model[i].ZS_SL == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].ZS_SL, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZS_WSJE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZS_DAYS2);
                    if (model[i].ZS_SL2 == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(0);
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].ZS_SL2, token).DICNAME);
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZS_WSJE2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BT_DAYS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BT_JE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].COSTITEMMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].QT_WSJE);
                    row.CreateCell(cellIndex++).SetCellValue(year2);
                    row.CreateCell(cellIndex++).SetCellValue(month2);
                    row1++;


                    //if (LIST.Length != 0 && LIST != null)
                    //{
                    NPOI.SS.UserModel.IRow NOrow = worksheet2.CreateRow(row2 + 1);
                    NOrow.CreateCell(cellAdd++).SetCellValue(year);
                    NOrow.CreateCell(cellAdd++).SetCellValue(month);
                    NOrow.CreateCell(cellAdd++).SetCellValue(day);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].HXJE);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].STAFFNAME);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].FGLDDES);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].SFDES);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].CWHSBH);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].CWHSBHDES);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].BEIZ);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].CBZX);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].CBZXDES);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_JPJE);
                    if (model[i].JT_HCPSL == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_HCPSL, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_HCPJE);
                    if (model[i].JT_HCPSL2 == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_HCPSL2, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_HCPJE2);
                    if (model[i].JT_KCPSL == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_KCPSL, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_KCPJE);
                    if (model[i].JT_KCPSL2 == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].JT_KCPSL2, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].JT_KCPJE2);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].ZS_DAYS);
                    if (model[i].ZS_SL == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].ZS_SL, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].ZS_JE);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].ZS_DAYS2);
                    if (model[i].ZS_SL2 == 0)
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(0);
                    }
                    else
                    {
                        NOrow.CreateCell(cellAdd++).SetCellValue(crmModels.HG_DICT.ReadByDICID(model[i].ZS_SL2, token).DICNAME);
                    }
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].ZS_JE2);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].BT_DAYS);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].BT_JE);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].COSTITEMMC);
                    NOrow.CreateCell(cellAdd++).SetCellValue(model[i].QT_JE);
                    NOrow.CreateCell(cellAdd++).SetCellValue(year2);
                    NOrow.CreateCell(cellAdd++).SetCellValue(month2);

                    row2++;
                    //}

                }
                //ICellStyle style = workbook.CreateCellStyle();
                //style.Alignment = HorizontalAlignment.CenterSelection;//单元格必须有内容才能水平居中,放弃

                //for (int i = 0; i < model.Length + 1; i++)
                //{
                //    for (int j = 0; j < 31; j++)
                //    {
                //        ICell Temp_Cell1 = worksheet1.GetRow(i).GetCell(j);
                //        ICell Temp_Cell2 = worksheet2.GetRow(i).GetCell(j);

                //        Temp_Cell1.CellStyle = style;
                //        Temp_Cell2.CellStyle = style;
                //    }
                //}
                //获取当前列的宽度，然后对比本列的长度，取最大值
                for (int columnNum = 0; columnNum <= model.Length; columnNum++)
                {
                    int columnWidth = worksheet1.GetColumnWidth(columnNum) / 256;
                    for (int rowNum = 1; rowNum <= worksheet1.LastRowNum; rowNum++)
                    {
                        IRow currentRow;
                        //当前行未被使用过
                        if (worksheet1.GetRow(rowNum) == null)
                        {
                            currentRow = worksheet1.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = worksheet1.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            if (columnWidth < length)
                            {
                                columnWidth = length;
                            }
                        }
                    }
                    worksheet1.SetColumnWidth(columnNum, columnWidth * 256);
                }
                //获取当前列的宽度，然后对比本列的长度，取最大值
                for (int columnNum = 0; columnNum <= model.Length; columnNum++)
                {
                    int columnWidth = worksheet2.GetColumnWidth(columnNum) / 256;
                    for (int rowNum = 1; rowNum <= worksheet2.LastRowNum; rowNum++)
                    {
                        IRow currentRow;
                        //当前行未被使用过
                        if (worksheet2.GetRow(rowNum) == null)
                        {
                            currentRow = worksheet2.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = worksheet2.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            if (columnWidth < length)
                            {
                                columnWidth = length;
                            }
                        }
                    }
                    worksheet2.SetColumnWidth(columnNum, columnWidth * 256);
                }

                worksheet1.ForceFormulaRecalculation = true;
                worksheet2.ForceFormulaRecalculation = true;
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
        public string Data_DaoChu_KAXS_KP(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                CRM_COST_KAXSReportKP cxmodel = JsonConvert.DeserializeObject<CRM_COST_KAXSReportKP>(cxdata);
                CRM_COST_KAXSReportKP[] model = crmModels.COST_KAXS.Report_KP(cxmodel, token);

                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/KA销售开票报表导出模版.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("开票");
                if (worksheet1 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 1;
                for (int i = 0; i < model.Length; i++)
                {

                    #region
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);

                    row.CreateCell(0).SetCellValue(model[i].GNAME);
                    row.CreateCell(1).SetCellValue(model[i].KP1);
                    row.CreateCell(2).SetCellValue(model[i].ZK1);
                    row.CreateCell(3).SetCellValue(model[i].HJ1);
                    row.CreateCell(4).SetCellValue(model[i].KP2);
                    row.CreateCell(5).SetCellValue(model[i].ZK2);
                    row.CreateCell(6).SetCellValue(model[i].HJ2);
                    row.CreateCell(7).SetCellValue(model[i].KP3);
                    row.CreateCell(8).SetCellValue(model[i].ZK3);
                    row.CreateCell(9).SetCellValue(model[i].HJ3);
                    row.CreateCell(10).SetCellValue(model[i].KP4);
                    row.CreateCell(11).SetCellValue(model[i].ZK4);
                    row.CreateCell(12).SetCellValue(model[i].HJ4);
                    row.CreateCell(13).SetCellValue(model[i].KP5);
                    row.CreateCell(14).SetCellValue(model[i].ZK5);
                    row.CreateCell(15).SetCellValue(model[i].HJ5);
                    row.CreateCell(16).SetCellValue(model[i].KP6);
                    row.CreateCell(17).SetCellValue(model[i].ZK6);
                    row.CreateCell(18).SetCellValue(model[i].HJ6);
                    row.CreateCell(19).SetCellValue(model[i].KP7);
                    row.CreateCell(20).SetCellValue(model[i].ZK7);
                    row.CreateCell(21).SetCellValue(model[i].HJ7);
                    row.CreateCell(22).SetCellValue(model[i].KP8);
                    row.CreateCell(23).SetCellValue(model[i].ZK8);
                    row.CreateCell(24).SetCellValue(model[i].HJ8);
                    row.CreateCell(25).SetCellValue(model[i].KP9);
                    row.CreateCell(26).SetCellValue(model[i].ZK9);
                    row.CreateCell(27).SetCellValue(model[i].HJ9);
                    row.CreateCell(28).SetCellValue(model[i].KP10);
                    row.CreateCell(29).SetCellValue(model[i].ZK10);
                    row.CreateCell(30).SetCellValue(model[i].HJ10);
                    row.CreateCell(31).SetCellValue(model[i].KP11);
                    row.CreateCell(32).SetCellValue(model[i].ZK11);
                    row.CreateCell(33).SetCellValue(model[i].HJ11);
                    row.CreateCell(34).SetCellValue(model[i].KP12);
                    row.CreateCell(35).SetCellValue(model[i].ZK12);
                    row.CreateCell(36).SetCellValue(model[i].HJ12);
                    row.CreateCell(37).SetCellValue(model[i].KP);
                    row.CreateCell(38).SetCellValue(model[i].ZK);
                    row.CreateCell(39).SetCellValue(model[i].HJ);


                    row1++;
                    #endregion
                }








                worksheet1.ForceFormulaRecalculation = true;
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
        public string Data_DaoChu_PSF(string data)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                CRM_COST_PSF[] model = JsonConvert.DeserializeObject<CRM_COST_PSF[]>(data);







                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/配送费导出模版.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("清单");
                ISheet worksheet2 = workbook.GetSheet("汇总_物流公司");
                ISheet worksheet3 = workbook.GetSheet("汇总_经销商");
                if (worksheet1 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 1, row2 = 0, row3 = 0;
                //写入清单数据
                for (int i = 0; i < model.Length; i++)
                {

                    #region
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);

                    row.CreateCell(0).SetCellValue(model[i].PSFTYPEDES);
                    row.CreateCell(1).SetCellValue(model[i].GSYEAR);
                    row.CreateCell(2).SetCellValue(model[i].SEASON);
                    row.CreateCell(3).SetCellValue(model[i].GSMONTH);
                    row.CreateCell(4).SetCellValue(model[i].JXSNAME);
                    row.CreateCell(5).SetCellValue(model[i].SAPSN);
                    row.CreateCell(6).SetCellValue(model[i].MC);
                    row.CreateCell(7).SetCellValue(model[i].CRMID);
                    row.CreateCell(8).SetCellValue(model[i].SAPSN);
                    row.CreateCell(9).SetCellValue(model[i].SJKPJE.ToString());
                    row.CreateCell(10).SetCellValue(model[i].FPKJJE.ToString());
                    row.CreateCell(11).SetCellValue(model[i].KPJEHJ.ToString());
                    row.CreateCell(12).SetCellValue(model[i].MDSL);
                    row.CreateCell(13).SetCellValue(model[i].JHJE.ToString());
                    row.CreateCell(14).SetCellValue(model[i].YSJE.ToString());
                    row.CreateCell(15).SetCellValue(model[i].MDPSF.ToString());
                    row.CreateCell(16).SetCellValue(model[i].ZCPSF.ToString());
                    row.CreateCell(17).SetCellValue(model[i].OTHER.ToString());
                    row.CreateCell(18).SetCellValue(model[i].PSFHJ.ToString());
                    row.CreateCell(19).SetCellValue(model[i].BEIZ);
                    row.CreateCell(20).SetCellValue(model[i].PRINTCOUNT);


                    row1++;
                    #endregion
                }


                //写入汇总数据
                string str = model[0].PSFID.ToString();
                for (int i = 1; i < model.Length; i++)
                {
                    str = str + "," + model[i].PSFID.ToString();
                    crmModels.COST_PSF.AddPrintCount(model[i].PSFID, token);
                }

                CRM_COST_PSF cx_print = new CRM_COST_PSF();
                cx_print.PSFIDSTR = str;
                if (model[0].PSFTYPE == 2030)
                {
                    cx_print.GSYEAR = model[0].GSYEAR;
                    cx_print.GSMONTH = model[0].GSMONTH;
                    CRM_COST_PSF[] HZdata = crmModels.COST_PSF.ReportWLGS(cx_print, token);


                    for (int i = 0; i < HZdata.Length; i++)
                    {
                        #region
                        if (i == 0)
                        {
                            NPOI.SS.UserModel.IRow row_1 = worksheet2.CreateRow(row2);
                            row_1.CreateCell(0).SetCellValue("所属期：");
                            row_1.CreateCell(1).SetCellValue(HZdata[i].GSYEAR + "年 " + HZdata[i].GSMONTH + "月");
                            row2 = row2 + 2;
                        }



                        NPOI.SS.UserModel.IRow row = worksheet2.CreateRow(row2);

                        row.CreateCell(0).SetCellValue(HZdata[i].GNAME);
                        row.CreateCell(1).SetCellValue(HZdata[i].KPJEHJ.ToString());
                        row.CreateCell(2).SetCellValue(HZdata[i].MDPSF.ToString());
                        row.CreateCell(3).SetCellValue(HZdata[i].ZCPSF.ToString());
                        row.CreateCell(4).SetCellValue(HZdata[i].OTHER.ToString());
                        row.CreateCell(5).SetCellValue(HZdata[i].PSFHJ.ToString());
                        row.CreateCell(6).SetCellValue(HZdata[i].BEIZ);

                        row2++;
                        #endregion
                    }



                }
                else if (model[0].PSFTYPE == 2031)
                {
                    cx_print.SEASON = model[0].SEASON;
                    CRM_COST_PSF[] HZdata = crmModels.COST_PSF.ReportJXS(cx_print, token);

                    for (int i = 0; i < HZdata.Length; i++)
                    {
                        #region
                        if (i == 0)
                        {
                            NPOI.SS.UserModel.IRow row_1 = worksheet3.CreateRow(row3);

                            string season = "";
                            switch (HZdata[i].SEASON)
                            {
                                case "1":
                                    season = "第一季度";
                                    break;
                                case "2":
                                    season = "第二季度";
                                    break;
                                case "3":
                                    season = "第三季度";
                                    break;
                                case "4":
                                    season = "第四季度";
                                    break;
                                default:
                                    break;
                            }

                            row_1.CreateCell(0).SetCellValue("所属季度：");
                            row_1.CreateCell(1).SetCellValue(season);
                            row3 = row3 + 2;
                        }



                        NPOI.SS.UserModel.IRow row = worksheet3.CreateRow(row3);

                        row.CreateCell(0).SetCellValue(HZdata[i].JXSNAME);
                        row.CreateCell(1).SetCellValue(HZdata[i].MDSL.ToString());
                        row.CreateCell(2).SetCellValue(HZdata[i].JHJE.ToString());
                        row.CreateCell(3).SetCellValue(HZdata[i].MDPSF.ToString());
                        row.CreateCell(4).SetCellValue(HZdata[i].OTHER.ToString());
                        row.CreateCell(5).SetCellValue(HZdata[i].PSFHJ.ToString());
                        row.CreateCell(6).SetCellValue(HZdata[i].BEIZ);

                        row3++;
                        #endregion
                    }





                }
                else
                {

                }

                worksheet1.ForceFormulaRecalculation = true;
                worksheet2.ForceFormulaRecalculation = true;
                worksheet3.ForceFormulaRecalculation = true;
                string now = "配送费" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
        public string Data_DaoChu_KAHX(string data)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                CRM_COST_KAHXDJMX[] model = JsonConvert.DeserializeObject<CRM_COST_KAHXDJMX[]>(data);

                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/KA费用报销单导出模版.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("清单");
                if (worksheet1 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 1;
                for (int i = 0; i < model.Length; i++)
                {

                    #region
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);

                    row.CreateCell(0).SetCellValue(model[i].COSTITEMIDDES);
                    row.CreateCell(1).SetCellValue(model[i].PRINTKHMC);
                    row.CreateCell(2).SetCellValue(model[i].CWHSBHDES);
                    row.CreateCell(3).SetCellValue(model[i].CBZXBHDES);
                    row.CreateCell(4).SetCellValue(model[i].FYHXXSDES);
                    row.CreateCell(5).SetCellValue(model[i].BEGINDATE);
                    row.CreateCell(6).SetCellValue(model[i].ENDDATE);
                    row.CreateCell(7).SetCellValue(model[i].HXJE.ToString());
                    row.CreateCell(8).SetCellValue(model[i].SLDES);
                    row.CreateCell(9).SetCellValue(model[i].WSJE.ToString());
                    row.CreateCell(10).SetCellValue(model[i].HXJE.ToString());
                    row.CreateCell(11).SetCellValue(model[i].BEIZ);
                    row.CreateCell(12).SetCellValue(model[i].PRINTCOUNT);


                    row1++;
                    #endregion
                }








                worksheet1.ForceFormulaRecalculation = true;
                string now = "KA费用报销单" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
        public string Data_CXYGZ_DaoChu(string data)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                //  CRM_COST_CLFHX[] model = JsonConvert.DeserializeObject<CRM_COST_CLFHX[]>(data);

                CRM_COST_CXYGZ cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXYGZ>(data);
                CRM_COST_CXYGZ[] model = crmModels.COST_CXYGZ.ReadByParam(cxmodel, token);

                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/促销员工资表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("促销员考核提成表");
                if (worksheet1 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有促销员工资表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                int row1 = 0;
                for (int i = 0; i < model.Length; i++)
                {
                    int Index = 0;
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1 + 1);
                    row.CreateCell(Index++).SetCellValue(i + 1);
                    row.CreateCell(Index++).SetCellValue(model[i].CXYYEAR);
                    row.CreateCell(Index++).SetCellValue(model[i].CXYMONTH);
                    row.CreateCell(Index++).SetCellValue(model[i].PKHIDDES);
                    row.CreateCell(Index++).SetCellValue(model[i].SFDES);
                    row.CreateCell(Index++).SetCellValue(model[i].CSDES);
                    row.CreateCell(Index++).SetCellValue(model[i].MC);
                    row.CreateCell(Index++).SetCellValue(model[i].CRMID);
                    row.CreateCell(Index++).SetCellValue(model[i].KHBEIZ);
                    row.CreateCell(Index++).SetCellValue(model[i].NAME);
                    row.CreateCell(Index++).SetCellValue(model[i].CODE);
                    row.CreateCell(Index++).SetCellValue(model[i].TEL);
                    row.CreateCell(Index++).SetCellValue(model[i].GWDES);
                    row.CreateCell(Index++).SetCellValue(model[i].GWGZ);
                    row.CreateCell(Index++).SetCellValue(model[i].BASE);
                    row.CreateCell(Index++).SetCellValue(model[i].CXYXHJE);
                    row.CreateCell(Index++).SetCellValue(model[i].TCJE);
                    row.CreateCell(Index++).SetCellValue(model[i].THCBKJ);
                    row.CreateCell(Index++).SetCellValue(model[i].YFHJ);
                    row.CreateCell(Index++).SetCellValue(model[i].SBKC);
                    row.CreateCell(Index++).SetCellValue(model[i].SFGZ);
                    row.CreateCell(Index++).SetCellValue(model[i].BANK);
                    row.CreateCell(Index++).SetCellValue(model[i].CARDNUM);
                    row.CreateCell(Index++).SetCellValue(model[i].BEIZ);
                    row1++;
                }
                for (int columnNum = 0; columnNum <= model.Length; columnNum++)
                {
                    int columnWidth = worksheet1.GetColumnWidth(columnNum) / 256;
                    for (int rowNum = 1; rowNum <= worksheet1.LastRowNum; rowNum++)
                    {
                        IRow currentRow;
                        //当前行未被使用过
                        if (worksheet1.GetRow(rowNum) == null)
                        {
                            currentRow = worksheet1.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = worksheet1.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            if (columnWidth < length)
                            {
                                columnWidth = length;
                            }
                        }
                    }
                    worksheet1.SetColumnWidth(columnNum, columnWidth * 256);
                }
                worksheet1.ForceFormulaRecalculation = true;
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
        public string Data_CXYGZ_DaoChuLes(string data)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                CRM_COST_CXYGZ[] model = JsonConvert.DeserializeObject<CRM_COST_CXYGZ[]>(data);

                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/打印导出促销员工资表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("促销员考核提成表");
                ISheet worksheet2 = workbook.GetSheet("促销活动费用申请");
                if (worksheet1 == null || worksheet2 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有促销员工资表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                int row1 = 0, row2 = 0;
                for (int i = 0; i < model.Length; i++)
                {

                    CRM_COST_CXYGZ cxmodel = new CRM_COST_CXYGZ();
                    cxmodel.CXYGZID = model[i].CXYGZID;
                    CRM_COST_CXYGZ[] data2 = crmModels.COST_CXYGZ.ReadByParam(cxmodel, token);

                    //if (model[i].GW == 2008)
                    //{

                    //}

                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1 + 1);
                    row.CreateCell(0).SetCellValue(i + 1);
                    row.CreateCell(1).SetCellValue(model[i].CXYYEAR);
                    row.CreateCell(2).SetCellValue(model[i].CXYMONTH);
                    row.CreateCell(3).SetCellValue(model[i].PKHIDDES);
                    row.CreateCell(4).SetCellValue(model[i].SFDES);
                    row.CreateCell(5).SetCellValue(model[i].CSDES);
                    row.CreateCell(6).SetCellValue(model[i].MC);
                    row.CreateCell(7).SetCellValue(model[i].NAME);
                    row.CreateCell(8).SetCellValue(model[i].CODE);
                    row.CreateCell(9).SetCellValue(model[i].TEL);
                    row.CreateCell(10).SetCellValue(model[i].GW);
                    row.CreateCell(11).SetCellValue(model[i].GWGZ);
                    row.CreateCell(12).SetCellValue(model[i].BASE);
                    row.CreateCell(13).SetCellValue(model[i].CXYXHJE);
                    row.CreateCell(14).SetCellValue(model[i].TCJE);
                    row.CreateCell(15).SetCellValue(model[i].THCBKJ);
                    row.CreateCell(16).SetCellValue(model[i].YFHJ);
                    row.CreateCell(17).SetCellValue(model[i].SBKC);
                    row.CreateCell(18).SetCellValue(model[i].SFGZ);
                    row.CreateCell(19).SetCellValue(model[i].BANK);
                    row.CreateCell(20).SetCellValue(model[i].CARDNUM);
                    row.CreateCell(21).SetCellValue(model[i].BEIZ);


                    row1++;


                    if (data2.Length != 0 && data2 != null)
                    {


                        NPOI.SS.UserModel.IRow cxrow = worksheet2.CreateRow(row2 + 1);
                        cxrow.CreateCell(0).SetCellValue(0 + 1);
                        cxrow.CreateCell(1).SetCellValue(data2[0].PKHIDDES);
                        cxrow.CreateCell(2).SetCellValue(data2[0].SFDES);
                        cxrow.CreateCell(3).SetCellValue(data2[0].CSDES);
                        cxrow.CreateCell(4).SetCellValue(data2[0].MC);
                        cxrow.CreateCell(5).SetCellValue(Convert.ToDouble(data2[0].KAXS));
                        cxrow.CreateCell(6).SetCellValue(data2[0].YFHJ);
                        cxrow.CreateCell(7).SetCellValue(data2[0].BEIZ);
                        row2++;


                    }

                }
                worksheet1.ForceFormulaRecalculation = true;
                worksheet2.ForceFormulaRecalculation = true;
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
        public string Data_DaoChu_SpaceArea(string data)
        {
            //  PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            CRM_COST_CXYGZ[] cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXYGZ[]>(data);
            if (cxmodel[0].GW == "2008")
            {
                string result = ToExcel(data, 1, "");
                return result;
            }
            else
            {
                string result = ToExcel(data, 0, "");

                return result;
            }
        }

        public string ToExcel(string data, int type, string token)
        {
            DataTable dt = JsonToDataTable(data);

            //NpoiExcel(dt, "123");

            switch (type)
            {
                case 0:
                    #region
                    dt.Columns.Remove("CXYGZID");
                    dt.Columns.Remove("CXYID");
                    dt.Columns.Remove("ISACTIVE");
                    dt.Columns.Remove("CJR");
                    dt.Columns.Remove("CJSJ");
                    dt.Columns.Remove("XGR");
                    dt.Columns.Remove("XGSJ");
                    dt.Columns.Remove("PRINTCOUNT");
                    dt.Columns.Remove("TIME_BEGIN");
                    dt.Columns.Remove("TIME_END");
                    dt.Columns.Remove("CXYGZIDSTR");
                    dt.Columns.Remove("XTMC");
                    dt.Columns.Remove("MDMC");
                    dt.Columns.Remove("GW");
                    dt.Columns.Remove("XHJE");
                    dt.Columns.Remove("KAXS");


                    dt.Columns["CXYYEAR"].ColumnName = "年份";
                    dt.Columns["CXYMONTH"].ColumnName = "月份";
                    dt.Columns["PKHIDDES"].ColumnName = "所属系统";
                    dt.Columns["SFDES"].ColumnName = "省份";
                    dt.Columns["CSDES"].ColumnName = "城市";
                    dt.Columns["MC"].ColumnName = "门店";
                    dt.Columns["NAME"].ColumnName = "姓名";
                    dt.Columns["CODE"].ColumnName = "身份证号码";
                    dt.Columns["TEL"].ColumnName = "手机号";
                    dt.Columns["GWDES"].ColumnName = "职位类别";
                    dt.Columns["GWGZ"].ColumnName = "岗位工资";
                    dt.Columns["BASE"].ColumnName = "考核基数";
                    dt.Columns["CXYXHJE"].ColumnName = "销售金额";
                    dt.Columns["TCJE"].ColumnName = "提成金额";
                    dt.Columns["THCBKJ"].ColumnName = "退货超标扣减";
                    dt.Columns["YFHJ"].ColumnName = "应发合计";
                    dt.Columns["SBKC"].ColumnName = "社保个人部分扣除";
                    dt.Columns["SFGZ"].ColumnName = "实发工资";
                    dt.Columns["BANK"].ColumnName = "开户银行";
                    dt.Columns["CARDNUM"].ColumnName = "卡号";
                    dt.Columns["BEIZ"].ColumnName = "备注";

                    dt.Columns["年份"].SetOrdinal(0);
                    dt.Columns["月份"].SetOrdinal(1);
                    dt.Columns["所属系统"].SetOrdinal(2);
                    dt.Columns["省份"].SetOrdinal(3);
                    dt.Columns["城市"].SetOrdinal(4);
                    dt.Columns["门店"].SetOrdinal(5);
                    dt.Columns["姓名"].SetOrdinal(6);
                    dt.Columns["身份证号码"].SetOrdinal(7);
                    dt.Columns["手机号"].SetOrdinal(8);
                    dt.Columns["职位类别"].SetOrdinal(9);
                    dt.Columns["岗位工资"].SetOrdinal(10);
                    dt.Columns["考核基数"].SetOrdinal(11);
                    dt.Columns["销售金额"].SetOrdinal(12);
                    dt.Columns["提成金额"].SetOrdinal(13);
                    dt.Columns["退货超标扣减"].SetOrdinal(14);
                    dt.Columns["应发合计"].SetOrdinal(15);
                    dt.Columns["社保个人部分扣除"].SetOrdinal(16);
                    dt.Columns["实发工资"].SetOrdinal(17);
                    dt.Columns["开户银行"].SetOrdinal(18);
                    dt.Columns["卡号"].SetOrdinal(19);
                    dt.Columns["备注"].SetOrdinal(20);




                    #endregion
                    break;
                case 1:
                    #region

                    dt.Columns.Remove("CXYGZID");
                    dt.Columns.Remove("CXYID");
                    dt.Columns.Remove("ISACTIVE");
                    dt.Columns.Remove("CJR");
                    dt.Columns.Remove("CJSJ");
                    dt.Columns.Remove("XGR");
                    dt.Columns.Remove("XGSJ");
                    dt.Columns.Remove("PRINTCOUNT");
                    dt.Columns.Remove("TIME_BEGIN");
                    dt.Columns.Remove("TIME_END");
                    dt.Columns.Remove("CXYGZIDSTR");
                    dt.Columns.Remove("XTMC");
                    dt.Columns.Remove("MDMC");
                    dt.Columns.Remove("GW");
                    dt.Columns.Remove("XHJE");
                    dt.Columns.Remove("KAXS");

                    dt.Columns.Remove("GWGZ");
                    dt.Columns.Remove("SBKC");
                    dt.Columns.Remove("SFGZ");


                    dt.Columns["CXYYEAR"].ColumnName = "年份";
                    dt.Columns["CXYMONTH"].ColumnName = "月份";
                    dt.Columns["PKHIDDES"].ColumnName = "所属系统";
                    dt.Columns["SFDES"].ColumnName = "省份";
                    dt.Columns["CSDES"].ColumnName = "城市";
                    dt.Columns["MC"].ColumnName = "门店";
                    dt.Columns["NAME"].ColumnName = "姓名";
                    dt.Columns["CODE"].ColumnName = "身份证号码";
                    dt.Columns["TEL"].ColumnName = "手机号";
                    dt.Columns["GWDES"].ColumnName = "职位类别";
                    //    dt.Columns["GWGZ"].ColumnName = "岗位工资";

                    dt.Columns["BASE"].ColumnName = "考核基数";
                    dt.Columns["CXYXHJE"].ColumnName = "销售金额";
                    dt.Columns["TCJE"].ColumnName = "提成金额";
                    dt.Columns["THCBKJ"].ColumnName = "退货超标扣减";
                    dt.Columns["YFHJ"].ColumnName = "应发合计";
                    //   dt.Columns["SBKC"].ColumnName = "社保个人部分扣除";
                    //     dt.Columns["SFGZ"].ColumnName = "实发工资";
                    dt.Columns["BANK"].ColumnName = "开户银行";
                    dt.Columns["CARDNUM"].ColumnName = "卡号";
                    dt.Columns["BEIZ"].ColumnName = "备注";





                    dt.Columns["年份"].SetOrdinal(0);
                    dt.Columns["月份"].SetOrdinal(1);
                    dt.Columns["所属系统"].SetOrdinal(2);
                    dt.Columns["省份"].SetOrdinal(3);
                    dt.Columns["城市"].SetOrdinal(4);
                    dt.Columns["门店"].SetOrdinal(5);
                    dt.Columns["姓名"].SetOrdinal(6);
                    dt.Columns["身份证号码"].SetOrdinal(7);
                    dt.Columns["手机号"].SetOrdinal(8);
                    dt.Columns["职位类别"].SetOrdinal(9);
                    // dt.Columns["岗位工资"].SetOrdinal(10);
                    dt.Columns["考核基数"].SetOrdinal(10);
                    dt.Columns["销售金额"].SetOrdinal(11);
                    dt.Columns["提成金额"].SetOrdinal(12);
                    dt.Columns["退货超标扣减"].SetOrdinal(13);
                    dt.Columns["应发合计"].SetOrdinal(14);
                    // dt.Columns["社保个人部分扣除"].SetOrdinal(16);
                    //   dt.Columns["实发工资"].SetOrdinal(17);
                    dt.Columns["开户银行"].SetOrdinal(15);
                    dt.Columns["卡号"].SetOrdinal(16);
                    dt.Columns["备注"].SetOrdinal(17);





                    break;
                #endregion

                default:

                    break;
            }

            string now = DateTime.Now.ToString("yyyyMMddHHmmss");
            //DataTabletoExcel(dt, @"E:\CRM\Areas\CRM\upload\" + now + ".xls");
            int j = DataToExcel(dt, now);
            if (j == 1)
            {
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = "err";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }





        private DataTable JsonToDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"$").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            //string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));
            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');
                //创建表   
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = "";
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('$');
                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }
                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('$')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            return tb;
        }

        public int DataToExcel(System.Data.DataTable m_DataTable, string s_FileName)
        {
            try
            {
                //string FileName = AppDomain.CurrentDomain.BaseDirectory + ("/Areas/CRM/upload/") + s_FileName + ".xls";  //文件存放路径  
                string FileName = FileSavePath + "\\upload\\" + s_FileName + ".xls";  //文件存放路径  
                if (System.IO.File.Exists(FileName))                                //存在则删除  
                {
                    System.IO.File.Delete(FileName);
                }
                System.IO.FileStream objFileStream;
                System.IO.StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                objStreamWriter = new System.IO.StreamWriter(objFileStream, Encoding.Unicode);
                for (int i = 0; i < m_DataTable.Columns.Count; i++)
                {
                    strLine = strLine + m_DataTable.Columns[i].Caption.ToString() + Convert.ToChar(9);      //写列标题  
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";
                for (int i = 0; i < m_DataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < m_DataTable.Columns.Count; j++)
                    {
                        if (m_DataTable.Rows[i].ItemArray[j] == null)
                            strLine = strLine + " " + Convert.ToChar(9);                                    //写内容  
                        else
                        {
                            string rowstr = "";
                            rowstr = m_DataTable.Rows[i].ItemArray[j].ToString();
                            if (rowstr.IndexOf("\r\n") > 0)
                                rowstr = rowstr.Replace("\r\n", " ");
                            if (rowstr.IndexOf("\t") > 0)
                                rowstr = rowstr.Replace("\t", " ");
                            strLine = strLine + rowstr + Convert.ToChar(9);
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                return 1;
            }
            catch
            {
                return 0;
            }

            //return FileName;        //返回生成文件的绝对路径  
        }




        [HttpPost]
        public string Data_Insert_CJHDWD(string data, string TCdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CJHDWD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CJHDWD>(data);
            CRM_COST_CXHDTC[] TCmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CXHDTC[]>(TCdata);
            model.ISACTIVE = 1;
            int i = crmModels.COST_CJHDWD.Create(model, token);
            if (i > 0)
            {
                for (int j = 0; j < TCmodel.Length; j++)
                {
                    CRM_COST_WDTC TC = new CRM_COST_WDTC();
                    TC.CJHDWDID = i;
                    TC.TCID = TCmodel[j].TCID;
                    TC.TCSL = TCmodel[j].TCSL;
                    TC.ISACTIVE = 1;
                    TC.CJR = appClass.CRM_GetStaffid();
                    int ii = crmModels.COST_WDTC.Create(TC, token);
                }
            }

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_CJHDWD(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CJHDWD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CJHDWD>(data);
            int i = crmModels.COST_CJHDWD.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_CJHDWD(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_CJHDWD model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_CJHDWD>(cxdata);
            CRM_COST_CJHDWD[] data = crmModels.COST_CJHDWD.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_CJHDWD(int CJHDWDID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_CJHDWD.Delete(CJHDWDID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_WDTC(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_WDTC model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_WDTC>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_WDTC.Create(model, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_WDTC(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_WDTC model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_WDTC>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_WDTC.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_WDTC(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_WDTC model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_WDTC>(cxdata);
            CRM_COST_WDTC[] data = crmModels.COST_WDTC.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_WDTC(int WDTCID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.COST_WDTC.Delete(WDTCID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_DaoRu_CXHD_SJFY(int CXHDID)
        {
            token = appClass.CRM_Gettoken();
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
                    string[] sheet = { "实际提货和费用支持" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //实际提货和费用支持
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("客户SAP编号") == false || data1.Columns.Contains("物料替代编号") == false || data1.Columns.Contains("实际发货量") == false)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "请使用指定的导入模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data1.Rows.Count > 0)
                                {
                                    webmsg.KEY = 1;
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["客户SAP编号"].ToString() != "")
                                        {
                                            CRM_Report_KHModel cxmodel = new CRM_Report_KHModel();
                                            cxmodel.SAPSN = data1.Rows[i]["客户SAP编号"].ToString();
                                            CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cxmodel, 0, token);
                                            if (KH.Length == 0)
                                            {
                                                webmsg.KEY = 0;
                                                webmsg.MSG = webmsg.MSG + "实际提货和费用支持第" + (i + 2) + "行客户SAP编号不存在！";
                                            }
                                        }
                                        else
                                        {
                                            CRM_Report_KHModel cxmodel = new CRM_Report_KHModel();
                                            cxmodel.CRMID = data1.Rows[i]["客户CRM编号"].ToString();
                                            CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cxmodel, 0, token);
                                            if (KH.Length == 0)
                                            {
                                                webmsg.KEY = 0;
                                                webmsg.MSG = webmsg.MSG + "实际提货和费用支持第" + (i + 2) + "行客户CRM编号不存在！";
                                            }
                                        }

                                        CRM_COST_LKAPRODUCT cx_lkacp = new CRM_COST_LKAPRODUCT();
                                        cx_lkacp.SAPCP = data1.Rows[i]["物料替代编号"].ToString();
                                        cx_lkacp.CLASS2 = 2077;
                                        CRM_COST_LKAPRODUCT[] cp = crmModels.COST_LKAPRODUCT.ReadByParam(cx_lkacp, token);
                                        if (cp.Length == 0)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "实际提货和费用支持第" + (i + 2) + "行物料替代编号不存在！";
                                        }

                                        if (Regex.IsMatch(data1.Rows[i]["实际发货量"].ToString().Trim(), @"^\d+$") == false)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "实际提货和费用支持第" + (i + 2) + "行实际发货量必须为整数！";
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["汇总金额"].ToString().Trim(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        {
                                            webmsg.KEY = 0;
                                            webmsg.MSG = webmsg.MSG + "实际提货和费用支持第" + (i + 2) + "行汇总金额格式不正确，金额保留小数点后两位！";
                                        }


                                    }

                                    if (webmsg.KEY == 0)
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
                    }
                    #endregion





                    //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                    #region
                    //实际提货和费用支持
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        #region
                        CRM_COST_CXHDPGQD model = new CRM_COST_CXHDPGQD();
                        model.CXHDID = CXHDID;



                        if (data1.Rows[i]["客户SAP编号"].ToString() != "")
                        {
                            CRM_Report_KHModel cxmodel = new CRM_Report_KHModel();
                            cxmodel.SAPSN = data1.Rows[i]["客户SAP编号"].ToString();
                            CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cxmodel, 0, token);
                            model.KHID = KH[0].KHID;
                        }
                        else
                        {
                            CRM_Report_KHModel cxmodel = new CRM_Report_KHModel();
                            cxmodel.CRMID = data1.Rows[i]["客户CRM编号"].ToString();
                            CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cxmodel, 0, token);
                            model.KHID = KH[0].KHID;
                        }



                        CRM_COST_LKAPRODUCT cx_lkacp = new CRM_COST_LKAPRODUCT();
                        cx_lkacp.SAPCP = data1.Rows[i]["物料替代编号"].ToString();
                        cx_lkacp.CLASS2 = 2077;
                        CRM_COST_LKAPRODUCT[] cp = crmModels.COST_LKAPRODUCT.ReadByParam(cx_lkacp, token);

                        model.SAPCP = data1.Rows[i]["物料替代编号"].ToString();
                        model.CPLXID = cp[0].CPLXID;
                        model.SJFHL = Convert.ToInt32(data1.Rows[i]["实际发货量"].ToString());
                        model.HZJE = Convert.ToDecimal(data1.Rows[i]["汇总金额"].ToString());
                        model.ISACTIVE = 1;
                        model.CJR = appClass.CRM_GetStaffid();


                        int id = crmModels.COST_CXHDPGQD.Create(model, token);
                        if (id < 0)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "实际提货和费用支持第" + (i + 2) + "行新增失败，请记录当前行数并联系管理员！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }



                        #endregion
                    }


                    #endregion
                    webmsg.KEY = 1;
                    webmsg.MSG = "新增成功！";
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
        public string Data_Insert_MDBSHX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBSHX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBSHX>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.COST_MDBSHX.Create(model, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_MDBSHX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBSHX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBSHX>(data);

            CRM_COST_MDBS_KAHXDJMX cxmodel = new CRM_COST_MDBS_KAHXDJMX();
            cxmodel.MDBSHXID = model.MDBSHXID;
            CRM_COST_MDBS_KAHXDJMX[] cxdata = crmModels.COST_MDBS_KAHXDJMX.ReadByParam(cxmodel, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "该数据已核销登记，无法修改！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }



            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.COST_MDBSHX.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_MDBSHX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBSHX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBSHX>(cxdata);
            CRM_COST_MDBSHX[] data = crmModels.COST_MDBSHX.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_MDBSHX_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBSHX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBSHX>(cxdata);
            CRM_COST_MDBSHX[] data = crmModels.COST_MDBSHX.Read_Unconnected(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_MDBSHX(int MDBSHXID)
        {
            token = appClass.CRM_Gettoken();

            CRM_COST_MDBS_KAHXDJMX cxmodel = new CRM_COST_MDBS_KAHXDJMX();
            cxmodel.MDBSHXID = MDBSHXID;
            CRM_COST_MDBS_KAHXDJMX[] cxdata = crmModels.COST_MDBS_KAHXDJMX.ReadByParam(cxmodel, token);
            if (cxdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "该数据已核销登记，无法删除！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            int i = crmModels.COST_MDBSHX.Delete(MDBSHXID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_DaoRu_MDBS()
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
                    string[] sheet = { "门店特陈补损费" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //门店特陈补损费
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("年份（四位数字）") == false || data1.Columns.Contains("月份") == false || data1.Columns.Contains("费用类别（是否大润发、欧尚）") == false)
                        {
                            msg.Msg = "请使用指定的导入模版！";
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
                                        if (data1.Rows[i]["年份（四位数字）"].ToString().Length != 4)
                                        {
                                            msg.Msg = "门店特陈补损费第" + (i + 2) + "行年份格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["月份"].ToString().Length > 2 || (Regex.IsMatch(data1.Rows[i]["月份"].ToString(), @"^[0-9]*$") == false))
                                        {
                                            msg.Msg = "门店特陈补损费第" + (i + 2) + "行月份格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["费用类别（是否大润发、欧尚）"].ToString() != "大润发、欧尚" && data1.Rows[i]["费用类别（是否大润发、欧尚）"].ToString() != "除大润发、欧尚")
                                        {
                                            msg.Msg = "门店特陈补损费第" + (i + 2) + "行费用类别内容错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }

                                        if (data1.Rows[i]["系统CRM编号"].ToString().Trim() == "" && data1.Rows[i]["门店CRM编号"].ToString().Trim() == "")
                                        {
                                            msg.Msg = "门店特陈补损费第" + (i + 2) + "行请填写系统或门店编号！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["系统CRM编号"].ToString() != "")
                                        {
                                            CRM_KH_KH KH = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["系统CRM编号"].ToString(), token);
                                            if (KH.KHID == 0)
                                            {
                                                msg.Msg = "门店特陈补损费第" + (i + 2) + "行系统客户不存在！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (KH.MCSX != 1)
                                            {
                                                msg.Msg = "门店特陈补损费第" + (i + 2) + "行系统客户的卖场属性不是系统！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                        if (data1.Rows[i]["门店CRM编号"].ToString() != "")
                                        {
                                            CRM_KH_KH KH2 = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["门店CRM编号"].ToString(), token);
                                            if (KH2.KHID == 0)
                                            {
                                                msg.Msg = "门店特陈补损费第" + (i + 2) + "行门店客户不存在！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (KH2.MCSX != 2)
                                            {
                                                msg.Msg = "门店特陈补损费第" + (i + 2) + "行门店客户的卖场属性不是门店！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                        if (data1.Rows[i]["陈列开始时间"].ToString() != "")
                                        {
                                            try
                                            {
                                                string date = Convert.ToDateTime(data1.Rows[i]["陈列开始时间"]).ToString();
                                            }
                                            catch
                                            {
                                                msg.Msg = "门店特陈补损费第" + (i + 2) + "行陈列开始时间格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                        if (data1.Rows[i]["陈列结束时间"].ToString() != "")
                                        {
                                            try
                                            {
                                                string date = Convert.ToDateTime(data1.Rows[i]["陈列结束时间"]).ToString();
                                            }
                                            catch
                                            {
                                                msg.Msg = "门店特陈补损费第" + (i + 2) + "行陈列结束时间间格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }

                                        //if (Regex.IsMatch(data1.Rows[i]["前三月均销售"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        //{
                                        //    msg.Msg = "门店特陈补损费第" + (i + 2) + "行前三月均销售格式不正确，金额保留小数点后两位！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        if (Regex.IsMatch(data1.Rows[i]["预计费用"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        {
                                            msg.Msg = "门店特陈补损费第" + (i + 2) + "行预计费用格式不正确，金额保留小数点后两位！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["预计本月销售"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        {
                                            msg.Msg = "门店特陈补损费第" + (i + 2) + "行预计本月销售格式不正确，金额保留小数点后两位！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //if (data1.Rows[i]["预计费比"].ToString() != "")
                                        //{
                                        //    if (Regex.IsMatch(data1.Rows[i]["预计费比"].ToString().Replace("%", ""), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        //    {
                                        //        msg.Msg = "门店特陈补损费第" + (i + 2) + "行预计费比格式不正确，金额保留小数点后两位！";
                                        //        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //    }
                                        //}

                                        int havecxy = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["有无促销员"].ToString(), 111, token);
                                        if (havecxy == 0)
                                        {
                                            msg.Msg = "门店特陈补损费第" + (i + 2) + "行有无促销员不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        int payway = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["支付方式"].ToString(), 93, token);
                                        if (payway == 0)
                                        {
                                            msg.Msg = "门店特陈补损费第" + (i + 2) + "行支付方式不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["有无形象地堆"].ToString() != "有" && data1.Rows[i]["有无形象地堆"].ToString() != "无")
                                        {
                                            msg.Msg = "门店特陈补损费第" + (i + 2) + "行有无形象地堆内容错误！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //if (Regex.IsMatch(data1.Rows[i]["实际销售"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        //{
                                        //    msg.Msg = "门店特陈补损费第" + (i + 2) + "行实际销售格式不正确，金额保留小数点后两位！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        //if (Regex.IsMatch(data1.Rows[i]["实际费用"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        //{
                                        //    msg.Msg = "门店特陈补损费第" + (i + 2) + "行实际费用格式不正确，金额保留小数点后两位！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        //if (data1.Rows[i]["实际费比"].ToString() != "")
                                        //{
                                        //    if (Regex.IsMatch(data1.Rows[i]["实际费比"].ToString().Replace("%", ""), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false)
                                        //    {
                                        //        msg.Msg = "门店特陈补损费第" + (i + 2) + "行实际费比格式不正确，金额保留小数点后两位！";
                                        //        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //    }
                                        //}





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
                        CRM_COST_MDBS model = new CRM_COST_MDBS();

                        model.HTYEAR = data1.Rows[i]["年份（四位数字）"].ToString();
                        model.COSTITEMID = 56;
                        string htmonth = data1.Rows[i]["月份"].ToString();
                        if (htmonth.Length == 1)
                            htmonth = "0" + htmonth;
                        model.HTMONTH = htmonth;
                        model.FYLB = data1.Rows[i]["费用类别（是否大润发、欧尚）"].ToString() == "大润发、欧尚" ? 1 : 2;

                        if (data1.Rows[i]["系统CRM编号"].ToString().Trim() != "")
                        {
                            CRM_KH_KH KH = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["系统CRM编号"].ToString(), token);
                            model.MDID = KH.KHID;
                        }

                        if (data1.Rows[i]["门店CRM编号"].ToString().Trim() != "")
                        {
                            //如果填了门店编号，系统编号取门店的上级客户
                            CRM_KH_KH KH = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["门店CRM编号"].ToString(), token);
                            model.MDID = KH.KHID;
                        }

                        model.DISPLAYITEM = data1.Rows[i]["陈列项目"].ToString();
                        model.DISPLAYPOSITION = data1.Rows[i]["陈列位置"].ToString();
                        model.BEGINDATE = Convert.ToDateTime(data1.Rows[i]["陈列开始时间"].ToString()).ToString("yyyy-MM-dd");
                        model.ENDDATE = Convert.ToDateTime(data1.Rows[i]["陈列结束时间"].ToString()).ToString("yyyy-MM-dd");
                        //model.QSYJXS = Convert.ToDecimal(data1.Rows[i]["前三月均销售"].ToString());

                        //取前三月均销售
                        CRM_COST_KAXS qsyjxs_model = new CRM_COST_KAXS();
                        if (data1.Rows[i]["系统CRM编号"].ToString().Trim() != "")
                        {
                            CRM_KH_KH KH = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["系统CRM编号"].ToString(), token);
                            qsyjxs_model.PKHID = KH.KHID;
                        }
                        else
                        {
                            CRM_KH_KH KH = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["门店CRM编号"].ToString(), token);
                            qsyjxs_model.KHID = KH.KHID;
                        }
                        string qsyjxs = Data_Select_QSYJXS(Newtonsoft.Json.JsonConvert.SerializeObject(qsyjxs_model), model.HTYEAR + "-" + model.HTMONTH);
                        CRM_COST_KAXS[] qsyjxs_data = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS[]>(qsyjxs);
                        decimal sum = 0;
                        if (qsyjxs_data.Length != 0)
                        {
                            for (int j = 0; j < qsyjxs_data.Length; j++)
                            {
                                sum = sum + Convert.ToDecimal(qsyjxs_data[j].JXXS) + Convert.ToDecimal(qsyjxs_data[j].TXXS);
                            }
                            if (data1.Rows[i]["系统CRM编号"].ToString().Trim() != "")
                            {
                                sum = sum / 3;
                            }
                            else
                            {
                                sum = sum / qsyjxs_data.Length;
                            }
                        }

                        model.QSYJXS = sum;
                        //取前三月均销售


                        model.YJFY = Convert.ToDecimal(data1.Rows[i]["预计费用"].ToString());
                        model.YJXS = Convert.ToDecimal(data1.Rows[i]["预计本月销售"].ToString());
                        model.YJFB = Convert.ToDecimal(Math.Round(Convert.ToDouble(model.YJFY / model.YJXS * 100), 2, MidpointRounding.AwayFromZero));
                        model.HAVECXY = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["有无促销员"].ToString(), 111, token);
                        model.PAYWAY = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["支付方式"].ToString(), 93, token);
                        model.HAVEDD = data1.Rows[i]["有无形象地堆"].ToString() == "有" ? 1 : 2;
                        model.BEIZ = data1.Rows[i]["备注"].ToString();
                        //model.SJFY = Convert.ToDecimal(data1.Rows[i]["实际费用"].ToString());
                        //model.SJXS = Convert.ToDecimal(data1.Rows[i]["实际销售"].ToString());
                        //if (data1.Rows[i]["实际费比"].ToString() != "")
                        //{
                        //    model.SJFB = Convert.ToDecimal(data1.Rows[i]["实际费比"].ToString().Replace("%", ""));
                        //}
                        //else
                        //{
                        //    model.SJFB = model.SJFY / model.SJXS * 100;
                        //}
                        //model.BEIZ2 = data1.Rows[i]["备注2"].ToString();


                        model.CJR = appClass.CRM_GetStaffid();

                        model.ISACTIVE = 10;






                        int id = crmModels.COST_MDBS.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "店特陈补损费第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
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


        [HttpPost]
        public string Data_Insert_STAFFDICT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFFDICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_STAFFDICT>(data);
            int i = crmModels.HG_STAFFDICT.Create(model, token);

            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
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
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string FILEEXPORT_KAMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();

            try
            {

                #region KA订单查询导出
                CRM_COST_KAXSReportMX selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXSReportMX>(cxdata);
                CRM_COST_KAXSReportMX[] model = crmModels.COST_KAXS.Report_MX(selectdata, token);
                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/KA明细POS报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(rowcount);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SF);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XTMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].MDMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BEIZ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CRMID);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].YWY);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TX13);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JX13);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ13);

                    // rowcount++;

                }

                sheet.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                #endregion
            }

            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public string FILEEXPORT_KAMXFH(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {

                #region KA订单查询导出
                CRM_COST_KAXS_Report_MXFH selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS_Report_MXFH>(cxdata);

                CRM_COST_KAXS_Report_MXFH[] model = crmModels.COST_KAXS.Report_MXFH(selectdata, token);
                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/KA明细发货报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(rowcount);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SF);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XTMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].MDMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BEIZ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CRMID);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].YWY);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL1);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL2);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL3);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL4);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL5);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL6);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL7);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL8);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL9);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL10);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL11);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL12);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXTH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXTH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJTH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL);

                }

                sheet.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                #endregion
            }

            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public string FILEEXPORT_KAMXKP(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {

                #region KA订单查询导出
                CRM_COST_KAXS_Report_MXFH selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS_Report_MXFH>(cxdata);

                CRM_COST_KAXS_Report_MXFH[] model = crmModels.COST_KAXS.Report_MXFH(selectdata, token);
                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/KA明细开票报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(rowcount);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SF);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XTMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].MDMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BEIZ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CRMID);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].YWY);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ1);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ2);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ3);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ4);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ5);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ6);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ7);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ8);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ9);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ10);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ11);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ12);


                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXXH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXZK);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXXH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TXZK);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ);


                }

                sheet.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                #endregion
            }

            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public string FILEEXPORT_KAPOS(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();



            try
            {

                #region KA订单查询导出
                CRM_COST_KAXS selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXS>(cxdata);

                CRM_COST_KAXS[] model = crmModels.COST_KAXS.Report(selectdata, token);
                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/KAPOS报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                Double HJ_POSHJ1 = 0.00;
                Double HJ_POSHJ2 = 0.00;
                Double HJ_POSHJ3 = 0.00;
                Double HJ_POSHJ4 = 0.00;
                Double HJ_POSHJ5 = 0.00;
                Double HJ_POSHJ6 = 0.00;
                Double HJ_POSHJ7 = 0.00;
                Double HJ_POSHJ8 = 0.00;
                Double HJ_POSHJ9 = 0.00;
                Double HJ_POSHJ10 = 0.00;
                Double HJ_POSHJ11 = 0.00;
                Double HJ_POSHJ12 = 0.00;
                Double HJ_POSHJ13 = 0.00;

                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    //  row.CreateCell(cellIndex++).SetCellValue(rowcount);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSHJ13);

                    HJ_POSHJ1 += model[i].POSHJ1;
                    HJ_POSHJ2 += model[i].POSHJ2;
                    HJ_POSHJ3 += model[i].POSHJ3;
                    HJ_POSHJ4 += model[i].POSHJ4;
                    HJ_POSHJ5 += model[i].POSHJ5;
                    HJ_POSHJ6 += model[i].POSHJ6;
                    HJ_POSHJ7 += model[i].POSHJ7;
                    HJ_POSHJ8 += model[i].POSHJ8;
                    HJ_POSHJ9 += model[i].POSHJ9;
                    HJ_POSHJ10 += model[i].POSHJ10;
                    HJ_POSHJ11 += model[i].POSHJ11;
                    HJ_POSHJ12 += model[i].POSHJ12;
                    HJ_POSHJ13 += model[i].POSHJ13;



                }
                //IRow LastRow = sheet.CreateRow(1);
                //LastRow.CreateCell(model.Length + 1).SetCellValue(model.Length + 1);



                int CellIndex = 0;
                IRow Crow = sheet.CreateRow((model.Length + 1));
                Crow.CreateCell(CellIndex++).SetCellValue("合计");
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ1);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ2);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ3);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ4);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ5);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ6);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ7);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ8);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ9);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ10);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ11);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ12);
                Crow.CreateCell(CellIndex++).SetCellValue(HJ_POSHJ13);






                sheet.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                #endregion
            }

            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public string FILEEXPORT_KAFH(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {

                #region KA订单查询导出
                CRM_COST_KAXSReportFH selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXSReportFH>(cxdata);

                CRM_COST_KAXSReportFH[] model = crmModels.COST_KAXS.Report_FH(selectdata, token);
                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/KA发货报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL3);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL4);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL5);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL6);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL7);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL8);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL9);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL10);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL11);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL12);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZK);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].HJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].THL);

                }

                sheet.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                #endregion
            }

            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public int Update_File(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_WJJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_WJJL>(data);
            model.SPR = appClass.CRM_GetStaffid();
            model.SPSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int i = crmModels.HG_WJJL.Update_SP(model, token);
            return i;
        }
        [HttpPost]
        public int Update_File2(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_WJJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_WJJL>(data);
            model.HFR = appClass.CRM_GetStaffid();
            model.HFSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int i = crmModels.HG_WJJL.Update_SP(model, token);
            return i;
        }
        public ActionResult LKA_SingleReport()
        {
            Session["location"] = 555;
            return View();
        }
        public string Select_LKA_SingleReport(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_LKAYEARTT_Report MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARTT_Report>(cxdata);
            CRM_COST_LKAYEARTT_Report[] data = crmModels.COST_LKAYEARTT.Report(MODEL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Report_NKAXS_COMPARE(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KAXSReport_Compare MODEL = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXSReport_Compare>(cxdata);
            CRM_COST_KAXSReport_Compare[] data = crmModels.COST_KAXS.Report_Compare(MODEL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string FILEEXPORT_KACOMPARE(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {

                #region KA订单查询导出
                CRM_COST_KAXSReport_Compare selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KAXSReport_Compare>(cxdata);

                CRM_COST_KAXSReport_Compare[] model = crmModels.COST_KAXS.Report_Compare(selectdata, token);
                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/KA对比报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;

                string RowCurrentName = "";
                string RowPastName = "";
                CRM_HG_DICT XSLX = crmModels.HG_DICT.ReadByDICID(selectdata.XSLX, token);

                string XSLXName = XSLX.DICNAME;

                if ((selectdata.BEGINDATE).Substring(0, 4) == (selectdata.ENDDATE).Substring(0, 4))
                {
                    RowCurrentName = (selectdata.BEGINDATE).Substring(0, 4) + "年" + (selectdata.BEGINDATE).Substring(5) + "月-" + (selectdata.ENDDATE).Substring(5) + "月" + XSLXName + "合计";
                    RowPastName = (Convert.ToString(Convert.ToInt32((selectdata.BEGINDATE).Substring(0, 4)) - 1)) + "年" + (selectdata.BEGINDATE).Substring(5) + "月-" + (selectdata.ENDDATE).Substring(5) + "月" + XSLXName + "合计";
                }
                else
                {
                    RowCurrentName = (selectdata.BEGINDATE).Substring(0, 4) + "年" + (selectdata.BEGINDATE).Substring(5) + "月-" + (selectdata.ENDDATE).Substring(0, 4) + "年" + (selectdata.ENDDATE).Substring(5) + "月" + XSLXName + "合计";
                    RowPastName = (Convert.ToString(Convert.ToInt32((selectdata.BEGINDATE).Substring(0, 4)) - 1)) + "年" + (selectdata.BEGINDATE).Substring(5) + "月-" + (Convert.ToString(Convert.ToInt32((selectdata.ENDDATE).Substring(0, 4)) - 1)) + "年" + (selectdata.ENDDATE).Substring(5) + "月" + XSLXName + "合计";
                }

                IRow HeadeRow = sheet.CreateRow(sheet.FirstRowNum);
                HeadeRow.CreateCell(0).SetCellValue("序号");
                HeadeRow.CreateCell(1).SetCellValue("系统");
                HeadeRow.CreateCell(2).SetCellValue(RowCurrentName);
                HeadeRow.CreateCell(3).SetCellValue(RowPastName);
                HeadeRow.CreateCell(4).SetCellValue("累计同比增长值");
                HeadeRow.CreateCell(5).SetCellValue("累计同比增长率");
                //   HeadeRow.SetColumnWidth(20 * 150);




                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(rowcount - 1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CURRENT_HJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PAST_HJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].COMPARE_NUM1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].COMPARE_NUM2);
                }
                AutoColumnWidth(sheet, 5);
                sheet.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                #endregion
            }

            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        public void AutoColumnWidth(ISheet sheet, int cols)
        {
            for (int col = 0; col <= cols; col++)
            {
                sheet.AutoSizeColumn(col);//自适应宽度，但是其实还是比实际文本要宽
                int columnWidth = sheet.GetColumnWidth(col) / 256;//获取当前列宽度
                for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow row = sheet.GetRow(rowIndex);
                    ICell cell = row.GetCell(col);
                    int contextLength = Encoding.UTF8.GetBytes(cell.ToString()).Length;//获取当前单元格的内容宽度
                    columnWidth = columnWidth < contextLength ? contextLength : columnWidth;

                }
                sheet.SetColumnWidth(col, columnWidth * 200);//

            }
        }

        [HttpPost]
        public string FILEEXPORT_LKA_SingleReport(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {

                #region KA订单查询导出
                CRM_COST_LKAYEARTT_Report selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_LKAYEARTT_Report>(cxdata);

                CRM_COST_LKAYEARTT_Report[] model = crmModels.COST_LKAYEARTT.Report(selectdata, token);
                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/LKA单品报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;


                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    //  row.CreateCell(cellIndex++).SetCellValue(rowcount);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].YWY);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXSSAP);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JXSMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CRMID);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].LKAMC);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].HTYEAR);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CPMC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CPFL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].NUM1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].NUM2);
                }
                AutoColumnWidth(sheet, 5);
                sheet.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                #endregion
            }

            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        public ActionResult EXPORT_DOWNLOAD_KATSCLTemplate(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/CRM/ExcelTemplate/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            // System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filename + ".xls");
        }
        [HttpPost]
        public string Data_Daoru_KATSCL(int KATSCLTTID)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
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


                if (fi.Exists == true)
                {
                    string[] sheet = { "KA特殊陈列明细" };


                    //开始做数据校验


                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //产品

                    #region

                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("门店编号") == false || data1.Columns.Contains("门店名称") == false || data1.Columns.Contains("开始日期") == false || data1.Columns.Contains("结束日期") == false
                            || data1.Columns.Contains("陈列方式") == false || data1.Columns.Contains("申请的费用金额") == false || data1.Columns.Contains("日常月均销售") == false)
                        {
                            msg.Info = "E";
                            msg.Msg = "请使用KA特殊陈列模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try      //数据验证
                            {
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        CRM_KH_KH CRMID = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["门店编号"].ToString(), token);
                                        if (CRMID.KHID == 0)
                                        {
                                            msg.Info = "E";
                                            msg.Msg = "KA特殊陈列明细导入" + (i + 2) + "行数门店编号不正确，不存在该客户！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        //CRM_KH_KH tempmodel = new CRM_KH_KH();
                                        //tempmodel.MC = data1.Rows[i]["门店名称"].ToString();
                                        //CRM_KH_KH[] temp = crmModels.KH_KH.Read(tempmodel, token);
                                        //if (temp.Length == 0)
                                        //{
                                        //    msg.Info = "E";
                                        //    msg.Msg = "KA特殊陈列明细导入" + (i + 2) + "行,客户名称不正确！";
                                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        //}
                                        int clfs = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["陈列方式"].ToString(), 9, 0, token);
                                        if (clfs == 0)
                                        {
                                            msg.Info = "E";
                                            msg.Msg = "KA特殊陈列明细导入" + (i + 2) + "行陈列方式不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["申请的费用金额"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data1.Rows[i]["申请的费用金额"].ToString() != "")
                                        {
                                            msg.Info = "E";
                                            msg.Msg = "KA销售导入" + (i + 2) + "行申请的费用金额格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["日常月均销售"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data1.Rows[i]["日常月均销售"].ToString() != "")
                                        {
                                            msg.Info = "E";
                                            msg.Msg = "KA销售导入" + (i + 2) + "行日常月均销售格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["预计销售"].ToString(), @"^[+-]?\d+(\.\d+)?$") == false && data1.Rows[i]["预计销售"].ToString() != "")
                                        {
                                            msg.Info = "E";
                                            msg.Msg = "KA销售导入" + (i + 2) + "行预计销售格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["开始日期"].ToString() == "" && data1.Rows[i]["结束日期"].ToString() == "")
                                        {
                                            msg.Info = "E";
                                            msg.Msg = "KA销售导入" + (i + 2) + "行日期格式不正确！";
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

                    for (int i = 0; i < data1.Rows.Count; i++)   //数据到数据库
                    {
                        #region
                        CRM_COST_KATSCLMX model = new CRM_COST_KATSCLMX();

                        model.KATSCLTTID = KATSCLTTID;
                        model.COSTITEMID = 60;
                        model.KHID = crmModels.KH_KH.ReadByCRMID(data1.Rows[i]["门店编号"].ToString(), token).KHID;
                        model.CLFS = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["陈列方式"].ToString().Trim(), 9, 0, token);

                        if ((data1.Rows[i]["开始日期"].ToString().Trim()).IndexOf("-") != -1)
                        {
                            model.BEGINDATE = data1.Rows[i]["开始日期"].ToString().Trim();
                        }
                        else
                        {
                            model.BEGINDATE = (data1.Rows[i]["开始日期"].ToString().Trim()).Replace(".", "-");
                        }
                        if ((data1.Rows[i]["结束日期"].ToString().Trim()).IndexOf("-") != -1)
                        {
                            model.ENDDATE = data1.Rows[i]["结束日期"].ToString().Trim();
                        }
                        else
                        {
                            model.ENDDATE = (data1.Rows[i]["结束日期"].ToString().Trim()).Replace(".", "-");
                        }
                        if (model.BEGINDATE.Length != 10)
                        {
                            StringBuilder Temp = new StringBuilder(model.BEGINDATE.Insert(9, "0"));
                            model.BEGINDATE = Temp.ToString();
                        }
                        if (model.ENDDATE.Length != 10)
                        {
                            StringBuilder Temp = new StringBuilder(model.ENDDATE.Insert(9, "0"));
                            model.ENDDATE = Temp.ToString();
                        }


                        model.FYJE = Convert.ToDecimal(data1.Rows[i]["申请的费用金额"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(data1.Rows[i]["申请的费用金额"].ToString().Trim()));
                        model.RCYJXS = Convert.ToDecimal(data1.Rows[i]["日常月均销售"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(data1.Rows[i]["日常月均销售"].ToString().Trim()));
                        model.YJXS = Convert.ToDecimal(data1.Rows[i]["预计销售"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(data1.Rows[i]["预计销售"].ToString().Trim()));
                        if (Convert.ToDecimal(data1.Rows[i]["预计销售"].ToString().Trim()) == 0)
                        {
                            model.YJFB = 0;
                        }
                        else
                        {
                            model.YJFB = Convert.ToDecimal(data1.Rows[i]["申请的费用金额"].ToString().Trim()) / Convert.ToDecimal(data1.Rows[i]["预计销售"].ToString().Trim()) * 100;
                        }

                        model.BEIZ = data1.Rows[i]["备注"].ToString();
                        model.ISACTIVE = 10;
                        model.CJR = appClass.CRM_GetStaffid();

                        int j = crmModels.COST_KATSCLMX.Create(model, token);

                        if (j <= 0)
                        {
                            msg.Msg = "新增信息的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
                    }
                    msg.Info = "S";
                    msg.Msg = "导入成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.Info = "E";
                    msg.Msg = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }

            catch (Exception e)
            {
                msg.Info = "E";
                msg.Msg = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }

        [HttpPost]
        public string Get_ThreePos(int KHID)
        {
            token = appClass.CRM_Gettoken();
            //   List<string> StrList = new List<string>();
            List<DateTime> TmpList = new List<DateTime>();
            string HJXS = "";
            string TmpStr = "";
            for (int i = -1; i > -4; --i)
            {
                DateTime Tmp = DateTime.Now.AddMonths(i);
                TmpList.Add(Tmp);
            }
            for (int i = 0; i < TmpList.Count; i++)
            {
                CRM_COST_KAXS model = new CRM_COST_KAXS();
                model.KAYEAR = TmpList[i].ToString().Split('/')[0];
                model.KAMONTH = TmpList[i].ToString().Split('/')[1];
                model.SJLX = 1462;
                model.KHID = KHID;
                CRM_COST_KAXS[] data = crmModels.COST_KAXS.ReadByParam(model, token);
                if (data.Length > 0)
                {
                    HJXS = data[0].HJXS.ToString();
                }
                else
                {
                    HJXS = "0";
                }
                //    StrList.Add(HJXS);
                TmpStr = TmpStr + HJXS + "-";
            }
            return TmpStr;
        }
        [HttpPost]
        public string Update_ZZFFEE(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_ZZFTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_ZZFTT>(data);
            int Num = 0;
            CRM_HG_WJJL[] WJmodel = crmModels.HG_WJJL.Read(36, model.TTID, token);
            for (int i = 0; i < WJmodel.Length; i++)
            {
                if (WJmodel[i].SPZT != 30)
                {
                    Num = 30;
                }
                else
                {
                    Num = 60;
                }
            }

            model.ISACTIVE = Num;
            model.XGR = appClass.CRM_GetStaffid();
            int TTID = crmModels.COST_ZZFTT.Update(model, token);
            webmsg.KEY = TTID;
            if (TTID > 0)
            {
                if (Num == 60)
                {
                    webmsg.MSG = "审核成功";
                }
                if (Num == 30)
                {
                    webmsg.MSG = "回退成功";
                }
            }
            else
                webmsg.MSG = "更新失败";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KADT_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KADTMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KADTMX>(cxdata);
            CRM_COST_KADTMX[] data = crmModels.COST_KADTMX.Read_Unconnected_CONN(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_KATSCL_Unconnected(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_KATSCLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_KATSCLMX>(cxdata);
            CRM_COST_KATSCLMX[] data = crmModels.COST_KATSCLMX.Read_Unconnected_CONN(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public decimal Data_Select_MDBScost(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_COST_MDBSHX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_MDBSHX>(data);
            decimal result = 0, EachMonthMoney = 0;
            DateTime begin = Convert.ToDateTime(model.BEGINDATE.Substring(0, 7));
            DateTime end = Convert.ToDateTime(model.ENDDATE.Substring(0, 7));
            int Year = 0, Month = 0, count = 0;
            Year = end.Year - begin.Year;
            Month = end.Month - begin.Month;
            count = Year * 12 + Month + 1;  //费用包含的月份数
            EachMonthMoney = model.HXJE / count; // 平均每个月的核销费用
            CRM_HG_DICT THL = crmModels.HG_DICT.ReadByDICID(4186, token);
            CRM_HG_DICT KouJian = crmModels.HG_DICT.ReadByDICID(4187, token);

            while (begin <= end)
            {
                //这里要用MDID和HTMONTH获取退货率，然后判断是否要减半，把算完后的金额加到result里面
                CRM_COST_KAXS cxmodel = new CRM_COST_KAXS();
                cxmodel.KHID = model.MDID;
                cxmodel.XSLX = 4188;
                cxmodel.SJLX = 4189;
                cxmodel.KAYEAR = begin.Year.ToString();
                cxmodel.KAMONTH = begin.Month.ToString();
                CRM_COST_KAXS[] KAXS = crmModels.COST_KAXS.ReadByParam(cxmodel, token);
                if (KAXS.Length != 0)
                {
                    //有退货率，看看有没有超过限额
                    if (KAXS[0].THL / 100 >= Convert.ToDecimal(THL.DICNAME))
                    {
                        //超了
                        result += EachMonthMoney * Convert.ToDecimal(KouJian.DICNAME);
                    }
                    else
                    {
                        //没超
                        result += EachMonthMoney;
                    }
                }
                else
                {
                    //没有退货率数据，按全额来算
                    result += EachMonthMoney;
                }

                begin = begin.AddMonths(1);
            }

            return result;
        }


    }
}
