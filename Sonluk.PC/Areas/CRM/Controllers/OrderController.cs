using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.ORDER_TTService;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.KH_HZHBService;
using Sonluk.UI.Model.CRM.SAP_ORDERService;
using Sonluk.UI.Model.CRM.PRODUCT_PRODUCTService;
using Sonluk.UI.Model.CRM.PRODUCT_WARNService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.SAP_ReportService;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text;
using Sonluk.UI.Model.CRM.WX_OPENIDService;
using Sonluk.UI.Model.MES.SY_MATERIALService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /CRM/Order/
        CRMModels crmModels = new CRMModels();
        MESModels mesModels = new MESModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string CorpID = System.Configuration.ConfigurationManager.AppSettings["CorpID"];
        string AppID = System.Configuration.ConfigurationManager.AppSettings["AppID"];
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Insert_Order()
        {
            Session["location"] = 78;

            token = appClass.CRM_Gettoken();

            CRM_HG_STAFF STAFF = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token);    //STAFF为当前用户的数据
            ViewBag.STAFF = STAFF;

            string SAPSN = STAFF.STAFFNO;
            CRM_KH_KH[] SDF = crmModels.KH_KH.ReadSDFbyPKH(SAPSN, token);
            ViewBag.SDF = SDF;




            CRM_KH_KH KH = crmModels.KH_KH.ReadBySAPSN(SAPSN, token);     //kh为当前客户的数据
            ViewBag.KH = KH;



            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();




            //return View();
        }

        public ActionResult Choose_Product(string SDF)
        {
            token = appClass.CRM_Gettoken();
            //string SAPSN = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token).STAFFNO;
            CRM_KH_KH KHuser = crmModels.KH_KH.ReadBySAPSN(SDF, token);
            CRM_PRODUCT_PRODUCT[] data = crmModels.PRODUCT_PRODUCT.ReadCPLXByRight(KHuser.KHID, token);

            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CPLXML != "")
                {
                    string[] p = data[i].CPLXML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].CPLXML = netpath + path;
                }
            }
            ViewBag.CPLX = data;
            return View();
        }

        [HttpPost]
        public ActionResult Load_CP(string SDF, int CPLX, int ORDERTTID, string CPMC)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KH KHuser = crmModels.KH_KH.ReadBySAPSN(SDF, token);
            CRM_PRODUCT_PRODUCT[] data = crmModels.PRODUCT_PRODUCT.ReadByRight(KHuser.KHID, SDF, CPLX, ORDERTTID, CPMC, token);

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
            ViewBag.PRODUCT = data;
            return View();
        }

        public ActionResult Select_Order()
        {
            Session["location"] = 79;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult SH_Order()
        {
            Session["location"] = 81;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult GD_Order()
        {
            Session["location"] = 82;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            return View();
        }

        [HttpPost]
        public string Post_Print_Order(string data)
        {
            try
            {
                CRM_ORDER_TT[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT[]>(data);
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

        public ActionResult Print_Order(int Add)
        {
            token = appClass.CRM_Gettoken();

            if (Session["PRINTORDER"] != null)
            {
                CRM_ORDER_TT[] data = (CRM_ORDER_TT[])Session["PRINTORDER"];
                PrintOrder[] PO = new PrintOrder[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    PO[i] = new PrintOrder();
                    PO[i].TTdata = data[i];
                    PO[i].TTdata.TOTAL2 = MoneyToChinese(PO[i].TTdata.TOTAL.ToString());
                    PO[i].MXdata = crmModels.ORDER_TT.ReadMXbyTTID(data[i].ORDERTTID, token);
                    if (Add == 1)
                    {
                        crmModels.ORDER_TT.AddPrintCount(data[i].ORDERTTID, token);
                    }
                }

                ViewBag.data = PO;
            }
            else
            {
                PrintOrder[] PO = new PrintOrder[0];
                ViewBag.data = PO;
            }

            return View();
        }

        public ActionResult Update_Order(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);

            //CRM_KH_KHList KH = crmModels.KH_KH.Read(TTdata.KHID, token);     //kh为当前客户的数据
            //ViewBag.KH = KH;

            //CRM_KH_KH[] SDF = crmModels.KH_KH.ReadSDFbyPKH(KH.SAPSN, token);    //SDF为当前操作的客户对应的售达方
            //ViewBag.SDF = SDF;

            //CRM_HG_STAFF STAFF = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token);    //STAFF为当前用户的数据
            //ViewBag.STAFF = STAFF;

            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");
            //return View();

            if (TTdata.ISACTIVE == 10)
            {
                Auto_UpdateOrder(ORDERTTID, true);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Order_HJ(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);
            ViewBag.TTdata = TTdata;
            return View();
        }

        [HttpPost]
        public ActionResult Order_Confirm(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);
            ViewBag.TTdata = TTdata;
            return View();
        }

        public ActionResult Report_Order()
        {
            Session["location"] = 80;
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFF STAFF = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token);    //STAFF为当前用户的数据
            ViewBag.STAFF = STAFF;

            string SAPSN = STAFF.STAFFNO;
            CRM_KH_KH[] SDF = crmModels.KH_KH.ReadSDFbyPKH(SAPSN, token);
            ViewBag.SDF = SDF;

            CRM_KH_KH KH = crmModels.KH_KH.ReadBySAPSN(SAPSN, token);     //kh为当前客户的数据
            ViewBag.KH = KH;

            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        [HttpPost]
        public string Data_Insert_OrderTT(string data)
        {
            token = appClass.CRM_Gettoken();

            string SAPSN = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token).STAFFNO;
            CRM_KH_KH KHuser = crmModels.KH_KH.ReadBySAPSN(SAPSN, token);

            CRM_ORDER_TT cxdata = new CRM_ORDER_TT();
            cxdata.ISACTIVE = 10;
            cxdata.CJR = appClass.CRM_GetStaffid();
            CRM_ORDER_TT[] TTdata = crmModels.ORDER_TT.ReadTTbyParam(cxdata, 0, 0, 0, token);
            if (TTdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "存在未提交的订单！请处理";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            cxdata.ISACTIVE = 20;
            TTdata = crmModels.ORDER_TT.ReadTTbyParam(cxdata, 0, 0, 0, token);
            if (TTdata.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "存在未审核的订单！请联系业务员";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            CRM_ORDER_TT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(data);

            //校验付款时间，不可早于当前时间
            if (Convert.ToDateTime(model.FKSJ) < DateTime.Now.AddDays(-1))
            {
                webmsg.KEY = 0;
                webmsg.MSG = "付款时间不可早于当前日期！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            CRM_KH_KH SDF = crmModels.KH_KH.ReadBySAPSN(model.SDFID, token);
            CRM_KH_XSQYSJ XSQY = crmModels.KH_HZHB.ReadBySAPSN(model.SDFID, token);

            model.DDLX = 1233;
            model.KHID = KHuser.KHID;
            model.KHSAP = KHuser.SAPSN;
            model.KHNAME = KHuser.MC;
            model.SDFNAME = SDF.MC;
            model.TEL = SDF.GSLXDH;
            model.XSZZ = XSQY.XSZZ;
            model.FXQD = XSQY.FXQD;
            model.CPZ = XSQY.CPZ;

            model.ISACTIVE = 10;
            model.CJR = appClass.CRM_GetStaffid();


            int i = crmModels.ORDER_TT.CreateTT(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_OrderTTbyID(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT data = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_OrderTTbyParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(cxdata);
            //string SAPSN = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token).STAFFNO;
            //CRM_KH_KH KHuser = crmModels.KH_KH.ReadBySAPSN(SAPSN, token);
            model.CJR = appClass.CRM_GetStaffid();
            CRM_ORDER_TT[] data = crmModels.ORDER_TT.ReadTTbyParam(model, 0, 0, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_OrderTTforCopy(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(cxdata);
            //string SAPSN = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token).STAFFNO;
            //CRM_KH_KH KHuser = crmModels.KH_KH.ReadBySAPSN(SAPSN, token);
            model.CJR = appClass.CRM_GetStaffid();
            CRM_ORDER_TT[] data = crmModels.ORDER_TT.ReadTTbyParam(model, 0, 1, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_OrderTTCopyAndInsert(string TTdata, int FromID)
        {
            token = appClass.CRM_Gettoken();

            string SAPSN = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token).STAFFNO;
            CRM_KH_KH KHuser = crmModels.KH_KH.ReadBySAPSN(SAPSN, token);

            CRM_ORDER_TT cxdata = new CRM_ORDER_TT();
            cxdata.ISACTIVE = 10;
            cxdata.CJR = appClass.CRM_GetStaffid();
            CRM_ORDER_TT[] cxTTmodel = crmModels.ORDER_TT.ReadTTbyParam(cxdata, 0, 0, 0, token);
            if (cxTTmodel.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "存在未提交的订单！请处理";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            cxdata.ISACTIVE = 20;
            cxTTmodel = crmModels.ORDER_TT.ReadTTbyParam(cxdata, 0, 0, 0, token);
            if (cxTTmodel.Length != 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "存在未审核的订单！请联系业务员";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            CRM_ORDER_TT TTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(TTdata);

            //校验付款时间，不可早于当前时间
            if (Convert.ToDateTime(TTmodel.FKSJ) < DateTime.Now.AddDays(-1))
            {
                webmsg.KEY = 0;
                webmsg.MSG = "付款时间不可早于当前日期！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            CRM_KH_KH SDF = crmModels.KH_KH.ReadBySAPSN(TTmodel.SDFID, token);
            CRM_KH_XSQYSJ XSQY = crmModels.KH_HZHB.ReadBySAPSN(TTmodel.SDFID, token);

            TTmodel.DDLX = 1233;
            TTmodel.KHID = KHuser.KHID;
            TTmodel.KHSAP = KHuser.SAPSN;
            TTmodel.KHNAME = KHuser.MC;
            TTmodel.SDFNAME = SDF.MC;
            TTmodel.TEL = SDF.GSLXDH;
            TTmodel.XSZZ = XSQY.XSZZ;
            TTmodel.FXQD = XSQY.FXQD;
            TTmodel.CPZ = XSQY.CPZ;
            TTmodel.BEIZ = "";
            TTmodel.ISACTIVE = 10;
            TTmodel.CJR = appClass.CRM_GetStaffid();


            int ORDERID = crmModels.ORDER_TT.CreateTT(TTmodel, token);

            if (ORDERID < 0)
            {
                webmsg.KEY = ORDERID;
                webmsg.MSG = "新建订单失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            CRM_ORDER_MX[] Fromdata = crmModels.ORDER_TT.ReadMXbyTTID(FromID, token);
            for (int i = 0; i < Fromdata.Length; i++)
            {

                Fromdata[i].ORDERTTID = ORDERID;
                int ii = crmModels.ORDER_TT.CreateMX(Fromdata[i], token);
                webmsg.KEY = ii;
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "复制失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }

            }
            webmsg.KEY = ORDERID;
            webmsg.MSG = "复制成功！";
            Auto_UpdateOrder(ORDERID, false);
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_OrderTTbyRight(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(cxdata);

            CRM_ORDER_TT[] data = crmModels.ORDER_TT.ReadTTbyParam(model, appClass.CRM_GetStaffid(), 0, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_OrderTTbyGunRight(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(cxdata);

            CRM_ORDER_TT[] data = crmModels.ORDER_TT.ReadTTbyParam(model, appClass.CRM_GetStaffid(), 0, 1, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_OrderTT(string data)
        {
            //现在没有用，如果要用的话得先用逻辑ID查出整个结构体，然后把修改的值改进去，再去更新
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.ORDER_TT.UpdateTT(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_Order(int ORDERTTID, string SHIPID, string SHIPADD, string FKSJ)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);
            CRM_ORDER_MX[] MXdata = crmModels.ORDER_TT.ReadMXbyTTID(ORDERTTID, token);

            for (int k = 0; k < MXdata.Length; k++)
            {
                if (MXdata[k].DDSL == 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "订单中存在数量为0的行项目！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }


            TTdata.SHIPID = SHIPID;
            TTdata.SHIPADD = SHIPADD;
            TTdata.FKSJ = FKSJ;
            TTdata.TJR = appClass.CRM_GetStaffid();
            TTdata.TJSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int j = crmModels.ORDER_TT.UpdateTT(TTdata, token);
            if (j <= 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "更新订单失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            int i = crmModels.ORDER_TT.UpdateOrderIsactive(ORDERTTID, 20, token);
            if (i <= 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "更新提交失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            string WXres = "";
            try
            {
                CRM_WX_OPENIDList[] OPENID = crmModels.WX_OPENID.ReadByORDERTTID(TTdata.ORDERTTID, token);
                for (int x = 0; x < OPENID.Length; x++)
                {
                    if (OPENID[x].WXDLCS == CorpID)
                    {
                        WX_MSG wxmsg = new WX_MSG();
                        wxmsg.touser = OPENID[x].OPENID;
                        wxmsg.toparty = "";
                        wxmsg.totag = "";
                        wxmsg.msgtype = "text";
                        wxmsg.agentid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Agentid"]);
                        wxmsg.text = new TEXT();
                        string address = System.Configuration.ConfigurationManager.AppSettings["SHorder_QY"];
                        wxmsg.text.content = "您的客户：" + TTdata.SDFNAME + "于" + TTdata.TJSJ + "提交了一个销售订单，请及时查收哦。<a href=\"" + address + "\">点这里进入审核界面</a>";
                        wxmsg.safe = 0;



                        WXres = WeiXinMSG(wxmsg);
                    }

                }
            }
            catch//(Exception e)
            {
                //webmsg.KEY = 0;
                //webmsg.MSG = WXres;
                //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }



            webmsg.KEY = 1;
            webmsg.MSG = "提交成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Save_Order(int ORDERTTID, string SHIPID, string SHIPADD, string FKSJ)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);
            CRM_ORDER_MX[] MXdata = crmModels.ORDER_TT.ReadMXbyTTID(ORDERTTID, token);

            for (int k = 0; k < MXdata.Length; k++)
            {
                if (MXdata[k].DDSL == 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "订单中存在数量为0的行项目！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }


            TTdata.SHIPID = SHIPID;
            TTdata.SHIPADD = SHIPADD;
            TTdata.FKSJ = FKSJ;
            TTdata.TJR = appClass.CRM_GetStaffid();
            TTdata.TJSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int j = crmModels.ORDER_TT.UpdateTT(TTdata, token);
            if (j <= 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "更新订单失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            webmsg.KEY = 1;
            webmsg.MSG = "修改成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_SH_Order(int ORDERTTID, string BEIZ2)
        {
            token = appClass.CRM_Gettoken();

            CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);
            CRM_ORDER_MX[] MXdata = crmModels.ORDER_TT.ReadMXbyTTID(ORDERTTID, token);

            SAP_SOInfo order = new SAP_SOInfo();
            order.Header = new SAP_SOHeaderInfo();
            order.Header.SalesOrganization = TTdata.XSZZ;
            order.Header.DistributionChannel = TTdata.FXQD;
            order.Header.Division = TTdata.CPZ;
            order.Header.SoldToParty = TTdata.SDFID;
            order.Header.ShipToParty = TTdata.SHIPID;
            order.Header.CustomerPO = DateTime.Now.ToString("yyyyMMdd") + TTdata.ORDERTTID.ToString().PadLeft(6, '0');
            order.Header.CustomerPODate = DateTime.Now.ToString("yyyy-MM-dd");

            order.Items = new SAP_SOItemInfo[MXdata.Length];
            for (int k = 0; k < MXdata.Length; k++)
            {
                order.Items[k] = new SAP_SOItemInfo();
                order.Items[k].Material = MXdata[k].CPPH;

                if (MXdata[k].DDDW.Trim() == "CTN")
                {
                    MaterialUnitInfo[] Unit = crmModels.SAP_ORDER.UnitConversion(MXdata[k].CPPH, "CTN", token);
                    if (Unit.Length == 1)
                    {
                        order.Items[k].Quantity = MXdata[k].DDSL * Unit[0].Rate;

                        //找物料号的基本单位
                        MES_SY_MATERIAL cxmodel = new MES_SY_MATERIAL();
                        cxmodel.WLH = MXdata[k].CPPH;
                        MES_SY_MATERIAL_SELECT WL = mesModels.SY_MATERIAL.SELECT(cxmodel, token);
                        if (WL.MES_RETURN.TYPE != "S")
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "获取订单单位失败：" + WL.MES_RETURN.MESSAGE;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else if(WL.MES_SY_MATERIAL.Length == 0)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "没有找到" + MXdata[k].CPPH + "的基础单位";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        else
                        {
                            order.Items[k].SalesUnit = WL.MES_SY_MATERIAL[0].UNITSNAME;
                        }

                    }
                    else
                    {
                        //物料没有维护CTN的换算关系或维护了多个CTN的单位
                        order.Items[k].Quantity = MXdata[k].DDSL;
                        order.Items[k].SalesUnit = MXdata[k].DDDW;
                    }

                }
                else
                {
                    //单位不是CTN，目前来看不会有
                    order.Items[k].Quantity = MXdata[k].DDSL;
                    order.Items[k].SalesUnit = MXdata[k].DDDW;
                }

            }

            string result = crmModels.SAP_ORDER.Create(order, token);
            if (result == "")
            {
                webmsg.KEY = 0;
                webmsg.MSG = "订单提交SAP失败！";
                TTdata.SUCCESS = -1;
            }
            else
            {
                webmsg.KEY = 1;
                webmsg.MSG = "审核成功！";
                TTdata.SUCCESS = 1;
                TTdata.SAPORDER = result;
                crmModels.ORDER_TT.UpdateOrderIsactive(ORDERTTID, 50, token);
                TTdata.SHR = appClass.CRM_GetStaffid();
                TTdata.SHSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                TTdata.BEIZ2 = BEIZ2;
                crmModels.ORDER_TT.UpdateTT(TTdata, token);
            }
            CRM_ORDER_TT ordermodel = new CRM_ORDER_TT();
            ordermodel.ORDERTTID = ORDERTTID;
            ordermodel.SUCCESS = TTdata.SUCCESS;
            ordermodel.SAPORDER = result;
            ordermodel.KHPO = order.Header.CustomerPO;
            int l = crmModels.ORDER_TT.UpdateOrder_SAPORDER(ordermodel, token);
            if (l <= 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "回传订单失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            CRM_PRODUCT_WARN[] warn = crmModels.PRODUCT_WARN.ReadByKHIDandPRODUCTID(TTdata.KHID, 0, token);
            for (int m = 0; m < warn.Length; m++)
            {
                for (int n = 0; n < MXdata.Length; n++)
                {
                    if (warn[m].PRODUCTID == MXdata[n].PRODUCTID)
                    {
                        //warn[m].SYSL = warn减去预警
                    }
                }
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_SHBack_Order(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.ORDER_TT.UpdateOrderIsactive(ORDERTTID, 10, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "回退成功！";
            else
                webmsg.MSG = "回退失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        //[HttpPost]
        //public string Data_GD_Order(int ORDERTTID)
        //{
        //    token = appClass.CRM_Gettoken();
        //    int i = crmModels.ORDER_TT.UpdateOrderIsactive(ORDERTTID, 60, token);
        //    webmsg.KEY = i;
        //    if (i > 0)
        //    {
        //        webmsg.MSG = "归档成功！";
        //        CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);
        //        TTdata.GDR = appClass.CRM_GetStaffid();
        //        TTdata.GDSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //        crmModels.ORDER_TT.UpdateTT(TTdata, token);
        //    }
        //    else
        //        webmsg.MSG = "归档失败！";
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        //}

        [HttpPost]
        public string Data_GDBack_Order(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.ORDER_TT.UpdateOrderIsactive(ORDERTTID, 20, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "回退成功！";
            else
                webmsg.MSG = "回退失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_GD_Order(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT[] datas = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT[]>(data);
            for (int j = 0; j < datas.Length; j++)
            {
                int ii = crmModels.ORDER_TT.UpdateOrderIsactive(datas[j].ORDERTTID, 60, token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "归档失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                else
                {
                    CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(datas[j].ORDERTTID, token);
                    TTdata.XGR = appClass.CRM_GetStaffid();
                    TTdata.GDR = appClass.CRM_GetStaffid();
                    TTdata.GDSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    crmModels.ORDER_TT.UpdateTT(TTdata, token);
                }
            }

            webmsg.KEY = 1;
            webmsg.MSG = "归档成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_OrderTT(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.ORDER_TT.DeleteTT(ORDERTTID, "delete", token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Cancel_OrderTT(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.ORDER_TT.DeleteTT(ORDERTTID, "cancel", token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "作废成功！";
            else
                webmsg.MSG = "作废失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_OrderMX(int ORDERTTID, int PRODUCTID)
        {
            token = appClass.CRM_Gettoken();

            //先看看这个产品有没有重复
            CRM_ORDER_MX[] MXdata = crmModels.ORDER_TT.ReadMXbyTTID(ORDERTTID, token);
            for (int i = 0; i < MXdata.Length; i++)
            {
                if (MXdata[i].PRODUCTID == PRODUCTID)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "该产品已在订单中！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);



            CRM_PRODUCT_PRODUCT CP = crmModels.PRODUCT_PRODUCT.ReadByID(PRODUCTID, token);

            string SAPSN = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token).STAFFNO;
            CRM_KH_KH KHuser = crmModels.KH_KH.ReadBySAPSN(SAPSN, token);
            CRM_PRODUCT_WARN[] Warn = crmModels.PRODUCT_WARN.ReadByKHIDandPRODUCTID(KHuser.KHID, PRODUCTID, token);

            CRM_KH_XSQYSJ XSQY = crmModels.KH_HZHB.ReadBySAPSN(TTdata.SDFID, token);



            CRM_ORDER_MX model = new CRM_ORDER_MX();
            model.ORDERTTID = ORDERTTID;
            model.PRODUCTID = PRODUCTID;
            model.CPPH = CP.CPPH;
            model.CPMC = CP.CPMC;
            model.DDDW = CP.DDDW;
            model.DDSL = 0;
            model.RATE = CP.RATE;
            model.BZDW = CP.BZDW;
            model.BZSL = 0;
            double price = Convert.ToDouble(crmModels.SAP_ORDER.SAP_Price(CP.CPPH, TTdata.SDFID, XSQY.XSZZ, XSQY.FXQD, token));
            if (price == 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "该产品没有维护价格，请联系业务员！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            model.PRICE = price;
            model.AMOUNT = 0;
            if (Warn.Length != 0)
            {
                if (Warn[0].PROWARNID == 0)       //没有设置预警
                {
                    model.KYSL = 99999;
                }
                else
                {
                    model.KYSL = Warn[0].SYSL;
                }
            }
            else
            {
                model.KYSL = 99999;
            }

            model.BEIZ = "";
            model.ISACTIVE = 1;

            int ii = crmModels.ORDER_TT.CreateMX(model, token);
            webmsg.KEY = ii;
            if (ii > 0)
            {
                webmsg.MSG = "添加成功！";
                Auto_UpdateOrder(ORDERTTID, false);
            }
            else
                webmsg.MSG = "添加失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public bool Auto_UpdateOrder(int ORDERTTID, bool updateMX)
        {
            token = appClass.CRM_Gettoken();
            //更新订单抬头的信息
            CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);
            CRM_ORDER_MX[] MXdata = crmModels.ORDER_TT.ReadMXbyTTID(ORDERTTID, token);
            SAP_DiscountInfo[] discount = crmModels.SAP_ORDER.SAP_Discount(TTdata.SDFID, token);

            double total = 0;
            double MXzhekou = 0;
            for (int j = 0; j < MXdata.Length; j++)
            {
                total = total + MXdata[j].AMOUNT;
                MXzhekou = MXzhekou + (double)(Math.Round((decimal)(MXdata[j].AMOUNT * Convert.ToDouble(discount[0].Rate)), 2, MidpointRounding.AwayFromZero));
            }
            TTdata.TOTAL = total;
            TTdata.DISCOUNT = Convert.ToDouble(discount[0].Available);
            TTdata.RATE = Convert.ToDouble(discount[0].Rate);
            //double OrderDiscount = TTdata.TOTAL * Convert.ToDouble(discount[0].Rate);
            double OrderDiscount = MXzhekou;// * Convert.ToDouble(discount[0].Rate);
            if (Convert.ToDouble(discount[0].Available) >= OrderDiscount)
            {
                TTdata.DISCOUNT_THIS = OrderDiscount;
            }
            else
            {
                TTdata.DISCOUNT_THIS = Convert.ToDouble(discount[0].Available);
            }
            TTdata.DISCOUNT_BALANCE = TTdata.DISCOUNT - TTdata.DISCOUNT_THIS;
            TTdata.ACTUAL = TTdata.TOTAL - TTdata.DISCOUNT_THIS;
            TTdata.PREVIOUS_BALANCE = Convert.ToDouble(crmModels.SAP_ORDER.SAP_Balance(TTdata.SDFID, token));
            TTdata.PAY = TTdata.ACTUAL - TTdata.PREVIOUS_BALANCE;
            TTdata.XGR = appClass.CRM_GetStaffid();

            int i = crmModels.ORDER_TT.UpdateTT(TTdata, token);


            if (updateMX)
            {
                //更新订单中产品的价格
                CRM_KH_XSQYSJ XSQY = crmModels.KH_HZHB.ReadBySAPSN(TTdata.SDFID, token);
                for (int k = 0; k < MXdata.Length; k++)
                {
                    CRM_PRODUCT_WARN[] Warn = crmModels.PRODUCT_WARN.ReadByKHIDandPRODUCTID(TTdata.KHID, MXdata[k].PRODUCTID, token);
                    if (Warn.Length != 0)
                    {
                        if (Warn[0].PROWARNID == 0)
                        {
                            //没有设置预警
                            MXdata[k].KYSL = 99999;
                        }
                        else
                        {
                            MXdata[k].KYSL = Warn[0].SYSL;
                        }
                    }
                    else
                    {
                        MXdata[k].KYSL = 99999;
                    }


                    MXdata[k].PRICE = Convert.ToDouble(crmModels.SAP_ORDER.SAP_Price(MXdata[k].CPPH, TTdata.SDFID, XSQY.XSZZ, XSQY.FXQD, token));




                    int ii = crmModels.ORDER_TT.UpdateMX(MXdata[k], token);
                    if (ii <= 0)
                        return false;
                }



            }




            if (i > 0)
                return true;
            else
                return false;
        }

        [HttpPost]
        public string Data_Select_OrderMXbyTTID(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_MX[] data = crmModels.ORDER_TT.ReadMXbyTTID(ORDERTTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_OrderMX(string data, int DDSL)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_MX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_MX>(data);
            model.DDSL = DDSL;
            model.BZSL = model.DDSL * model.RATE;
            model.AMOUNT = model.BZSL * model.PRICE;
            int i = crmModels.ORDER_TT.UpdateMX(model, token);
            webmsg.KEY = i;
            if (i > 0)
            {
                webmsg.MSG = "修改成功！";
                Auto_UpdateOrder(model.ORDERTTID, false);
            }
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_OrderMX(int ORDERMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.ORDER_TT.DeleteMX(ORDERMXID, appClass.CRM_GetStaffid(), token);
            webmsg.KEY = i;
            if (i > 0)
            {
                webmsg.MSG = "删除成功！";
                int ORDERTTID = crmModels.ORDER_TT.ReadMXbyMXID(ORDERMXID, token).ORDERTTID;
                Auto_UpdateOrder(ORDERTTID, false);
            }
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_SHIPbySDF(string SAPSN)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_XSQYSJ XSQY = crmModels.KH_HZHB.ReadBySAPSN(SAPSN, token);
            SAP_CompanyInfo[] data = crmModels.SAP_ORDER.ShipToParty(SAPSN, XSQY.XSZZ, XSQY.FXQD, XSQY.CPZ, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_CPLXbyRight()
        {
            token = appClass.CRM_Gettoken();
            string SAPSN = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token).STAFFNO;
            CRM_KH_KH KHuser = crmModels.KH_KH.ReadBySAPSN(SAPSN, token);
            CRM_PRODUCT_PRODUCT[] data = crmModels.PRODUCT_PRODUCT.ReadCPLXByRight(KHuser.KHID, token);

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
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_CopyOrder(int ToID, int FromID)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_MX[] Todata = crmModels.ORDER_TT.ReadMXbyTTID(ToID, token);
            CRM_ORDER_MX[] Fromdata = crmModels.ORDER_TT.ReadMXbyTTID(FromID, token);
            for (int i = 0; i < Fromdata.Length; i++)
            {
                int samecount = 0;
                for (int j = 0; j < Todata.Length; j++)
                {
                    if (Todata[j].PRODUCTID == Fromdata[i].PRODUCTID)
                        samecount++;

                }
                if (samecount > 0)
                    continue;
                Fromdata[i].ORDERTTID = ToID;
                int ii = crmModels.ORDER_TT.CreateMX(Fromdata[i], token);
                webmsg.KEY = ii;
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "复制失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }

            }
            webmsg.KEY = 1;
            webmsg.MSG = "复制成功！";
            Auto_UpdateOrder(ToID, false);
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
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

            LowerMoney = Math.Round(double.Parse(LowerMoney), 2).ToString();

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
        public string Data_Report_DuiZhang(string SDF, string BEGIN, string END)
        {
            token = appClass.CRM_Gettoken();
            SAP_ReportInfo[] data = crmModels.SAP_Report.AC(SDF, BEGIN, END, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


        [HttpPost]
        public string Data_Report_FaHuo(string SDF, string BEGIN, string END)
        {
            token = appClass.CRM_Gettoken();
            SAP_ReportInfo[] data = crmModels.SAP_Report.SHFH(SDF, BEGIN, END, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


        [HttpPost]
        public string Data_Report_ZheKou(string SDF, string END)
        {
            token = appClass.CRM_Gettoken();
            SAP_ReportInfo[] data = crmModels.SAP_Report.ZKMX(SDF, "", END, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


        [HttpPost]
        public string Data_DuiZhangReport_daochu(string data)
        {
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 8, "");
            return result;
        }


        [HttpPost]
        public string Data_DuiZhangReport_daochuAll(string SDF, string BEGIN, string END)
        {
            token = appClass.CRM_Gettoken();
            SAP_ReportInfo[] data = crmModels.SAP_Report.AC(SDF, BEGIN, END, token);
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(Newtonsoft.Json.JsonConvert.SerializeObject(data), 8, "");
            return result;
        }


        [HttpPost]
        public string Data_FaHuoReport_daochu(string data)
        {
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 9, "");
            return result;
        }


        [HttpPost]
        public string Data_FaHuoReport_daochuAll(string SDF, string BEGIN, string END)
        {
            token = appClass.CRM_Gettoken();
            SAP_ReportInfo[] data = crmModels.SAP_Report.SHFH(SDF, BEGIN, END, token);
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(Newtonsoft.Json.JsonConvert.SerializeObject(data), 9, "");
            return result;
        }


        [HttpPost]
        public string Data_ZheKouReport_daochu(string data)
        {
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 10, "");
            return result;
        }


        [HttpPost]
        public string Data_ZheKouReport_daochuAll(string SDF, string END)
        {
            token = appClass.CRM_Gettoken();
            SAP_ReportInfo[] data = crmModels.SAP_Report.ZKMX(SDF, "", END, token);
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(Newtonsoft.Json.JsonConvert.SerializeObject(data), 10, "");
            return result;
        }

        [HttpPost]
        public string WeiXinMSG(WX_MSG wxmsg)
        {
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string[] result = otherController.GetQYtoken(CorpID);
            string serviceAddress = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + result[0];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";
            request.ContentType = "application/json";                          //otKEk1FYKxWN_RQEmMhwNBbnOpKQ


            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(wxmsg));
                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            //解析josn
            JObject jo = JObject.Parse(retString);
            //Response.Write(jo["message"]["mmmm"].ToString());
            return Newtonsoft.Json.JsonConvert.SerializeObject(jo);
        }

        [HttpPost]
        public string UpdateWrongOrder(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            //更新订单抬头的信息
            CRM_ORDER_TT TTdata = crmModels.ORDER_TT.ReadTTbyID(ORDERTTID, token);
            CRM_ORDER_MX[] MXdata = crmModels.ORDER_TT.ReadMXbyTTID(ORDERTTID, token);
            //SAP_DiscountInfo[] discount = crmModels.SAP_ORDER.SAP_Discount(TTdata.SDFID, token);

            double total = 0;
            double MXzhekou = 0;
            for (int j = 0; j < MXdata.Length; j++)
            {
                total = total + MXdata[j].AMOUNT;
                MXzhekou = MXzhekou + (double)(Math.Round((decimal)(MXdata[j].AMOUNT * TTdata.RATE), 2, MidpointRounding.AwayFromZero));
            }
            double OrderDiscount = MXzhekou;
            if (TTdata.DISCOUNT >= OrderDiscount)
            {
                TTdata.DISCOUNT_THIS = OrderDiscount;
            }
            TTdata.DISCOUNT_BALANCE = TTdata.DISCOUNT - TTdata.DISCOUNT_THIS;
            TTdata.ACTUAL = TTdata.TOTAL - TTdata.DISCOUNT_THIS;
            TTdata.PAY = TTdata.ACTUAL - TTdata.PREVIOUS_BALANCE;

            int i = crmModels.ORDER_TT.UpdateTT(TTdata, token);

            return "";
        }



    }
}
