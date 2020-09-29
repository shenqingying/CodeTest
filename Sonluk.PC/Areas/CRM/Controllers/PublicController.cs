using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.HG_WJJLService;
using System.IO;
using Newtonsoft.Json;
using Sonluk.UI.Model.CRM.CRM_LoginService;
using System.Net;
using System.Text;
using Sonluk.UI.Model.CRM_OAService;
using Sonluk.UI.Model.CRM.KH_KHService;
using System.Data;
using System.Web.Script.Serialization;
using System.Collections;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Text.RegularExpressions;
using Sonluk.PC.APPCLASS;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.PC.Models.WX;
using Sonluk.PC.Models.QY;
using Sonluk.UI.Model.CRM.WX_OPENIDService;
using System.Configuration;
using Sonluk.UI.Model.MODEL;
using Sonluk.SSO.Models;
using Sonluk.UI.Model.CRM.COST_LKAHXZLTTService;
using Sonluk.UI.Model.CRM.COST_ZZFTTService;
using Sonluk.UI.Model.CRM.COST_PUBLICService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class PublicController : Controller
    {
        //
        // GET: /CRM/Public/
        AppClass appclass = new AppClass();
        CRMModels crmModels = new CRMModels();
        SSOModels ssomodels = new SSOModels();
        PUBLICModels publicmodels = new PUBLICModels();
        MESModels mesModels = new MESModels();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            ActionResult target;
            target = RedirectToAction("SignIn", "Public");
            string url = Request.Url.ToString();
            string SSOURL = "";
            if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1 || url.IndexOf("10.1") != -1)
            {
                SSOURL = ConfigurationManager.AppSettings["SSOURLIN"];
            }
            else
            {
                SSOURL = ConfigurationManager.AppSettings["SSOURLOUT"];
            }
            url = publicmodels.PUBLICFUN.get_my_jm(url);
            string LOGINTYPE = Request.QueryString["LOGINTYPE"];
            if (string.IsNullOrEmpty(LOGINTYPE))
            {
                LOGINTYPE = "";
            }
            if (LOGINTYPE == "1")
            {
                Session["MYPW"] = null;
                Response.Cookies["TokenID"].Value = null;
                url = url + "&LOGINTYPE=1";
                return Redirect(SSOURL + "?URL=" + url);
            }

            string TOKENID = Request.QueryString["TOKENID"];
            if (string.IsNullOrEmpty(TOKENID))
            {
                TOKENID = "";
            }
            if (TOKENID != "")
            {
                MES_RETURN_UI rst_MES_RETURN_UI = ssomodels.TOKEN_TOKENIDINFO.SELECT(TOKENID);
                if (rst_MES_RETURN_UI.TYPE == "S")
                {
                    Response.Cookies["token"].Value = rst_MES_RETURN_UI.MESSAGE;
                    Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
                    CRM_LoginInfo tokeninfo = crmModels.CRM_Login.Login_SSO_TOKEN_LANGUAGE(TOKENID, 1, 0);
                    if (!string.IsNullOrEmpty(tokeninfo.TokenInfo.access_token))
                    {
                        if (Session["token"] == null)
                        {
                            Session["MYPW"] = null;
                        }
                        getlogininfo(tokeninfo);
                        Response.Cookies["TokenID"].Value = TOKENID;
                        target = RedirectToAction("Index1", "Public");
                    }
                    else
                    {
                        return Redirect(SSOURL + "?URL=" + url);
                    }
                }
                else
                {
                    return Redirect(SSOURL + "?URL=" + url);
                }
            }
            else
            {
                if (Request.Cookies["TokenID"] == null)
                {
                    return Redirect(SSOURL + "?URL=" + url);
                }
                else
                {
                    if (string.IsNullOrEmpty(Request.Cookies["TokenID"].Value))
                    {
                        return Redirect(SSOURL + "?URL=" + url);
                    }
                    else
                    {
                        MES_RETURN_UI rst_MES_RETURN_UI = ssomodels.TOKEN_TOKENIDINFO.SELECT(Request.Cookies["TokenID"].Value);
                        if (rst_MES_RETURN_UI.TYPE == "S")
                        {
                            Response.Cookies["token"].Value = rst_MES_RETURN_UI.MESSAGE;
                            Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
                            CRM_LoginInfo tokeninfo = crmModels.CRM_Login.Login_SSO_TOKEN_LANGUAGE(Request.Cookies["TokenID"].Value, 1, 0);
                            if (!string.IsNullOrEmpty(tokeninfo.TokenInfo.access_token))
                            {
                                if (Session["token"] == null)
                                {
                                    Session["MYPW"] = null;
                                }
                                getlogininfo(tokeninfo);
                                target = RedirectToAction("Index1", "Public");
                            }
                            else
                            {
                                return Redirect(SSOURL + "?URL=" + url);
                            }
                        }
                        else
                        {
                            return Redirect(SSOURL + "?URL=" + url);
                        }
                    }
                }
            }
            return target;
            //return View();
        }
        public void getlogininfo(CRM_LoginInfo tokeninfo)
        {
            Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
            Session["token"] = tokeninfo.TokenInfo.access_token;
            Session["STAFFID"] = tokeninfo.TokenInfo.STAFFID;
            Session["NAME"] = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token).STAFFNAME;
            Response.Cookies["token"].Value = tokeninfo.TokenInfo.access_token;
            Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
            if (tokeninfo.TokenInfo.LANGUAGEID != 0)
            {
                MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                model_MES_SY_TYPEMX.ID = tokeninfo.TokenInfo.LANGUAGEID;
                MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST = mesModels.SY_TYPEMX.SELECT(model_MES_SY_TYPEMX, tokeninfo.TokenInfo.access_token);
                if (rst_MES_SY_TYPEMXLIST.Length > 0)
                {
                    Response.Cookies["Sonluk.Local.Culture"].Value = rst_MES_SY_TYPEMXLIST[0].MXNAME;
                    Response.Cookies["Sonluk.Local.Culture"].Expires = DateTime.Now.AddDays(10);
                }
                else
                {
                    Response.Cookies["Sonluk.Local.Culture"].Value = "zh-CN";
                    Response.Cookies["Sonluk.Local.Culture"].Expires = DateTime.Now.AddDays(10);
                }
            }
            else
            {
                Response.Cookies["Sonluk.Local.Culture"].Value = "zh-CN";
                Response.Cookies["Sonluk.Local.Culture"].Expires = DateTime.Now.AddDays(10);
            }
        }
        public ActionResult Verify(string name, string password)         //登录验证
        {
            CRM_LoginInfo tokeninfo = crmModels.CRM_Login.Login(name, password, "", "", 1, 0);         //验证登录信息
            Response.Cookies["userName"].Value = name;
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(10);
            Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
            if (tokeninfo.TokenInfo.access_token == null)
            {
                if (tokeninfo.TokenInfo.MSG == "E")
                {
                    Session["ErrorMessage"] = tokeninfo.TokenInfo.MESSAGE;
                }
                else
                {
                    Session["ErrorMessage"] = "用户名或密码错误";
                }

                Response.Cookies["password"].Value = "";
                Response.Cookies["password"].Expires = DateTime.Now.AddDays(10);
                Session["MYPW"] = null;
            }
            else
            {
                Session["ErrorMessage"] = null;
                Session["token"] = tokeninfo.TokenInfo.access_token;
                Session["STAFFID"] = tokeninfo.TokenInfo.STAFFID;
                Session["NAME"] = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token).STAFFNAME;

                //AccountInfo staffinfo = models.UserToken.AcceptToken(tokeninfo.access_token);
                //Session["ID"] = staffinfo.ID;
                //Session["NAME"] = staffinfo.Name;
                Response.Cookies["userName"].Value = name;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(10);
                Response.Cookies["password"].Value = password;
                Response.Cookies["password"].Expires = DateTime.Now.AddDays(10);
                Response.Cookies["token"].Value = tokeninfo.TokenInfo.access_token;
                Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
                Session["MYPW"] = null;
            }
            ActionResult target;
            if (tokeninfo.TokenInfo.access_token == null)
            {
                target = RedirectToAction("SignIn", "Public");
            }
            else
            {
                if (tokeninfo.TokenInfo.MSG == "E")
                {
                    //跳转到修改密码界面
                    target = RedirectToAction("Password", "System");
                    Session["passwordMSG"] = tokeninfo.TokenInfo.MESSAGE;
                }
                else
                {
                    target = RedirectToAction("Index1", "Public");
                }

            }
            return target;
        }


        public string[] GetWXtoken(string appid)         //获取公众号token
        {
            token = appclass.CRM_Gettoken();
            CRM_WX_SYS model = crmModels.CRM_Login.WX_SYS_ReadByWXAPPID(appid, token);

            DateTime nowtime = DateTime.Now;
            DateTime effective_time = Convert.ToDateTime(model.JLTIME).AddSeconds(model.EXPIRES_IN);
            if (effective_time <= nowtime)         //token过期的情况
            {
                string[] data = ReGetWXtoken(model.WX_SYSID);
                model.ACCESS_TOKEN = data[0];
                model.TICKET = data[1];
            }
            string[] s = new string[2];
            s[0] = model.ACCESS_TOKEN;
            s[1] = model.TICKET;
            return s;
        }

        public string[] ReGetWXtoken(int SYSID)                 //重新刷新公众号token
        {
            token = appclass.CRM_Gettoken();
            string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"]; //微信公众号appid
            string secret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];  //微信公众号appsecret
            string TokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret;
            string TokenJson = GetJson(TokenUrl);
            Access_token token_modle = JsonConvert.DeserializeObject<Access_token>(TokenJson);



            string TicketUrl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + token_modle.access_token + "&type=jsapi";
            string TicketJson = GetJson(TicketUrl);
            JSApi_Ticket Ticket_model = JsonConvert.DeserializeObject<JSApi_Ticket>(TicketJson);
            string ticket = Ticket_model.ticket;

            CRM_WX_SYS model = new CRM_WX_SYS();
            model.WX_SYSID = SYSID;
            model.WXAPPID = appid;
            model.ACCESS_TOKEN = token_modle.access_token;
            model.TICKET = ticket;
            model.EXPIRES_IN = Convert.ToInt32(token_modle.expires_in) / 4;// -200;
            crmModels.CRM_Login.WX_SYS_Update(model, token);

            string[] s = new string[2];
            s[0] = token_modle.access_token;
            s[1] = ticket;
            return s;
        }



        public string[] GetQYtoken(string corpid)             //获取企业微信token
        {
            token = appclass.CRM_Gettoken();

            CRM_WX_SYS model = crmModels.CRM_Login.WX_SYS_ReadByWXAPPID(corpid, token);

            DateTime nowtime = DateTime.Now;
            DateTime effective_time = Convert.ToDateTime(model.JLTIME).AddSeconds(model.EXPIRES_IN);
            if (effective_time <= nowtime)         //token过期的情况
            {
                string[] data = ReGetQYtoken(model.WX_SYSID);
                model.ACCESS_TOKEN = data[0];
                model.TICKET = data[1];
            }
            string[] s = new string[2];
            s[0] = model.ACCESS_TOKEN;
            s[1] = model.TICKET;
            return s;


        }

        public string[] ReGetQYtoken(int SYSID)                 //重新刷新企业微信token
        {
            token = appclass.CRM_Gettoken();
            string corpid = System.Configuration.ConfigurationManager.AppSettings["CorpID"]; //企业微信id
            string secret = System.Configuration.ConfigurationManager.AppSettings["Secret"];  //企业微信号appsecret
            string TokenUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + corpid + "&corpsecret=" + secret;
            string TokenJson = GetJson(TokenUrl);
            QY_Access_Token token_modle = JsonConvert.DeserializeObject<QY_Access_Token>(TokenJson);



            string TicketUrl = "https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=" + token_modle.access_token;
            string TicketJson = GetJson(TicketUrl);
            QY_Ticket Ticket_model = JsonConvert.DeserializeObject<QY_Ticket>(TicketJson);
            string ticket = Ticket_model.ticket;

            CRM_WX_SYS model = new CRM_WX_SYS();
            model.WX_SYSID = SYSID;
            model.WXAPPID = corpid;
            model.ACCESS_TOKEN = token_modle.access_token;
            model.TICKET = ticket;
            model.EXPIRES_IN = Convert.ToInt32(token_modle.expires_in) - 200;
            crmModels.CRM_Login.WX_SYS_Update(model, token);

            string[] s = new string[2];
            s[0] = token_modle.access_token;
            s[1] = ticket;
            return s;
        }

        [HttpPost]
        public string Data_FileUpload(int KHID, string data)
        {
            var file = Request.Files[0];

            string date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss.fff");
            string fileName = date + "_" + KHID;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            string Path = FileSavePath2 + @"\\upload\\" + year + @"\\" + month + @"\\" + fileName + "." + name[count];
            string savePath = FileSavePath + @"\upload\" + year + @"\" + month + @"\" + fileName + "." + name[count];

            file.SaveAs(savePath);
            FileInfo fi = new FileInfo(savePath);
            if (fi.Exists == true)
            {
                CRM_HG_WJmodel model = new CRM_HG_WJmodel();
                CRM_HG_WJJLTT wjjltt = JsonConvert.DeserializeObject<CRM_HG_WJJLTT>(data);
                CRM_HG_WJJL wjjl = new CRM_HG_WJJL();
                wjjl.WJM = gotname;
                wjjl.ML = savePath;
                wjjl.ISATIVE = 1;
                wjjl.IMGSOURCE = "相册";
                wjjl.CZR = appclass.CRM_GetStaffid();
                wjjl.CZSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                wjjl.SPZT = 10;
                model.WJJL = wjjl;
                model.WJJLTT = wjjltt;

                if (Session["token"] != null)
                {
                    token = Session["token"].ToString();
                }
                int i = crmModels.HG_WJJL.Create(model, token);

                string json = "{\"code\":0,\"res\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "{}";
            }

        }


        public string Data_FileUpload_WJLX(int KHID, string data, int WJLX)
        {
            var file = Request.Files[0];

            string date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss.fff");
            string fileName = date + "_" + KHID;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            string Path = FileSavePath2 + @"\\upload\\" + year + @"\\" + month + @"\\" + fileName + "." + name[count];
            string savePath = FileSavePath + @"\upload\" + year + @"\" + month + @"\" + fileName + "." + name[count];

            file.SaveAs(savePath);
            FileInfo fi = new FileInfo(savePath);
            if (fi.Exists == true)
            {
                CRM_HG_WJmodel model = new CRM_HG_WJmodel();
                CRM_HG_WJJLTT wjjltt = JsonConvert.DeserializeObject<CRM_HG_WJJLTT>(data);
                CRM_HG_WJJL wjjl = new CRM_HG_WJJL();
                wjjl.WJM = gotname;
                wjjl.ML = savePath;
                wjjl.ISATIVE = 1;
                wjjl.IMGSOURCE = "相册";
                //if (WJLX != null)
                    wjjl.WJLX = WJLX;
                wjjl.CZR = appclass.CRM_GetStaffid();
                wjjl.CZSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                model.WJJL = wjjl;
                model.WJJLTT = wjjltt;

                if (Session["token"] != null)
                {
                    token = Session["token"].ToString();
                }
                int i = crmModels.HG_WJJL.Create(model, token);

                string json = "{\"code\":0,\"res\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "{}";
            }

        }


        public string GetJson(string url)               //获得http get返回的值
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


        [HttpPost]
        public string GetAddress(string addr)
        {
            string key = System.Configuration.ConfigurationManager.AppSettings["TXmapKey"];
            string str = "https://apis.map.qq.com/ws/geocoder/v1/?address=" + addr + "&key=" + key;
            TXcode.TXzcode txaddress = JsonConvert.DeserializeObject<TXcode.TXzcode>(GetJson(str));
            string address = Newtonsoft.Json.JsonConvert.SerializeObject(txaddress);
            return address;
        }

        [HttpPost]
        public string Data_Select_DaiBan()
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            string staffno = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token).STAFFNO;
            string IP = Request.UserHostAddress;
            CRM_OA_INFO[] data = crmModels.CRM_OA.Pending(staffno, 0, 10, IP, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_GenZong()
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            string staffno = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token).STAFFNO;
            string IP = Request.UserHostAddress;
            CRM_OA_INFO[] data = crmModels.CRM_OA.Track(staffno, 0, 10, IP, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        public enum MyEnum
        {
            SpaceArea = 0,
            KaoQin = 1,
            Invoice = 2,
            KaoQinSummary = 3,
            BaiFang = 4,
            ZDF = 5,
            ZDWD = 6,
            LKA = 7,
            DuiZhang = 8,
            FaHuo = 9,
            ZheKou = 10,
            BaiFang_Dare = 11
        }

        public string ToExcel(string data, int type, string token)
        {
            DataTable dt = JsonToDataTable(data);
            //NpoiExcel(dt, "123");

            switch (type)
            {
                case 0:
                    //CRM_KH_BankList[] model = (CRM_KH_BankList[])data;
                    dt.Columns.Remove("FID");
                    dt.Columns.Remove("DICID");
                    dt.Columns.Remove("ISACTIVE");

                    dt.Columns["FIDDES"].ColumnName = "省份";
                    dt.Columns["DICIDDES"].ColumnName = "城市";
                    dt.Columns["MC"].ColumnName = "客户名称";
                    dt.Columns["HTXSRW"].ColumnName = "合同销售任务";
                    dt.Columns["XXMC"].ColumnName = "渠道";

                    break;
                case 1:

                    break;
                case 2:
                    #region
                    dt.Columns["JZ2"].SetOrdinal(9);     //把调整数据这一列放到差异销售前面

                    dt.Columns["VKBUR"].ColumnName = "销售办公室";
                    dt.Columns["BEZEI_BU"].ColumnName = "销售办公室描述";
                    dt.Columns["VKGRP"].ColumnName = "销售组";
                    dt.Columns["BEZEI"].ColumnName = "销售组描述";
                    dt.Columns["KUNNR1"].ColumnName = "SAP客户编号";
                    dt.Columns["NAME1"].ColumnName = "客户名称";
                    dt.Columns["TASK"].ColumnName = "年度销售任务";
                    dt.Columns["TASK1"].ColumnName = "计划销售任务";
                    dt.Columns["JZ"].ColumnName = "已完成销售(含折扣)";
                    dt.Columns["JZ2"].ColumnName = "调整数据";
                    dt.Columns["JZ1"].ColumnName = "差异销售(含折扣)";

                    #endregion
                    break;
                case 3:
                    #region
                    dt.Columns.Remove("STAFFID");
                    dt.Columns["DEPNAME"].SetOrdinal(2);

                    dt.Columns["STAFFNAME"].ColumnName = "姓名";
                    dt.Columns["STAFFNO"].ColumnName = "工号";
                    dt.Columns["DEPNAME"].ColumnName = "部门";
                    dt.Columns["DAYCOUNTS"].ColumnName = "工作日天数";
                    dt.Columns["ZCDAYCOUNTS"].ColumnName = "正常考勤天数";
                    dt.Columns["CCDAYCOUNTS"].ColumnName = "出差天数";
                    dt.Columns["QJDAYCOUNTS"].ColumnName = "请假天数";
                    dt.Columns["YCDAYCOUNTS"].ColumnName = "异常考勤天数";
                    dt.Columns["QQDAYCOUNTS"].ColumnName = "缺勤天数";
                    #endregion
                    break;
                case 4:
                    #region
                    dt.Columns.Remove("BFDJID");
                    dt.Columns.Remove("BFJHID");
                    dt.Columns.Remove("BFRYID");
                    dt.Columns.Remove("BFKH");
                    dt.Columns.Remove("BFID");
                    dt.Columns.Remove("BFLX");
                    dt.Columns.Remove("XSQD");
                    dt.Columns.Remove("LXRZW");
                    dt.Columns.Remove("BFMD");
                    dt.Columns.Remove("BFJG");
                    dt.Columns.Remove("XCBFSJ");
                    dt.Columns.Remove("XCBFJH");
                    dt.Columns.Remove("ISDELETE");
                    dt.Columns.Remove("BFCS");
                    dt.Columns.Remove("BFZQDES");
                    dt.Columns.Remove("BFJHMC");
                    dt.Columns.Remove("KHLX");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ISACTIVE"].ToString() == "1")
                        {
                            dt.Rows[i]["ISACTIVE"] = "已完成";
                        }
                        else
                        {
                            dt.Rows[i]["ISACTIVE"] = "未完成";
                        }
                        if (dt.Rows[i]["KQISACTIVE"].ToString() == "1")
                        {
                            dt.Rows[i]["KQISACTIVE"] = "是";
                        }
                        else
                        {
                            dt.Rows[i]["KQISACTIVE"] = "否";
                        }
                    }

                    dt.Columns["BFLXDES"].ColumnName = "拜访类型";
                    dt.Columns["ISACTIVE"].ColumnName = "拜访状态";
                    dt.Columns["STAFFNAME"].ColumnName = "拜访人员";
                    dt.Columns["STAFFNO"].ColumnName = "人员工号";
                    dt.Columns["KHMC"].ColumnName = "客户名称";
                    dt.Columns["CRMID"].ColumnName = "客户编号";
                    dt.Columns["BFDZ"].ColumnName = "拜访地点";
                    dt.Columns["JHBFKSSJ"].ColumnName = "拜访登记时间";
                    dt.Columns["JHBFJSSJ"].ColumnName = "拜访完成时间";
                    dt.Columns["BFMDDES"].ColumnName = "拜访目的";
                    dt.Columns["BFJGDES"].ColumnName = "拜访结果";
                    dt.Columns["LXR"].ColumnName = "联系人";
                    dt.Columns["LXRTEL"].ColumnName = "联系人电话";
                    dt.Columns["LXRZWDES"].ColumnName = "联系人职务";
                    dt.Columns["QTXX"].ColumnName = "其他信息";
                    dt.Columns["KHLXDES"].ColumnName = "客户类型";
                    dt.Columns["KQJL"].ColumnName = "拜访距离(米)";
                    dt.Columns["KQISACTIVE"].ColumnName = "距离是否有效";


                    dt.Columns["客户类型"].SetOrdinal(2);

                    #endregion
                    break;
                case 5:
                    #region
                    dt.Columns.Remove("ZDFID");
                    dt.Columns.Remove("SQRID");
                    dt.Columns.Remove("SQBMID");
                    dt.Columns.Remove("KHID");
                    dt.Columns.Remove("ISACTIVE");

                    dt.Columns["STAFFNAME"].ColumnName = "申请人";
                    dt.Columns["STAFFNO"].ColumnName = "工号";
                    dt.Columns["DEPNAME"].ColumnName = "部门";
                    dt.Columns["SQSJ"].ColumnName = "申请时间";
                    dt.Columns["ZDRQ"].ColumnName = "招待日期";
                    dt.Columns["KHNAME"].ColumnName = "客户名称";
                    dt.Columns["KHMX"].ColumnName = "客户姓名";
                    dt.Columns["JDRS"].ColumnName = "接待人数";
                    dt.Columns["PKRS"].ColumnName = "陪客人数";
                    dt.Columns["ZDLY"].ColumnName = "招待理由";
                    dt.Columns["YJJE"].ColumnName = "预计总金额";
                    #endregion
                    break;
                case 6:
                    #region
                    dt.Columns.Remove("SF");
                    dt.Columns.Remove("CS");
                    dt.Columns.Remove("WDLX");
                    dt.Columns.Remove("KHID");
                    dt.Columns.Remove("CPLX");
                    dt.Columns.Remove("CPLXDES");
                    dt.Columns.Remove("SHSL");
                    dt.Columns.Remove("CZR");
                    dt.Columns.Remove("IMG_MT");
                    dt.Columns.Remove("BFCS");
                    dt.Columns.Remove("BF_MT");
                    dt.Columns.Remove("BF_DISPLAY");
                    dt.Columns.Remove("ISYX");
                    dt.Columns.Remove("XL");
                    dt.Columns.Remove("SM");
                    dt.Columns.Remove("ISBZ");

                    dt.Columns["STAFF"].ColumnName = "业务员";
                    dt.Columns["FGLD"].ColumnName = "分管领导";
                    dt.Columns["JXSID"].ColumnName = "经销商编号";
                    dt.Columns["JXSNAME"].ColumnName = "经销商名称";
                    dt.Columns["JXSSAPSN"].ColumnName = "经销商SAP编号";
                    dt.Columns["CRMID"].ColumnName = "终端网点编号";
                    dt.Columns["MC"].ColumnName = "网点名称";
                    dt.Columns["PKHMC"].ColumnName = "直销商";
                    //dt.Columns["ISYX"].ColumnName = "有效网点开发";
                    dt.Columns["ISDZS"].ColumnName = "是否电子锁";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //if (dt.Rows[i]["有效网点开发"].ToString() != "0")
                        //{
                        //    dt.Rows[i]["有效网点开发"] = "是";
                        //}
                        //else
                        //{
                        //    dt.Rows[i]["有效网点开发"] = "否";
                        //}

                        if (dt.Rows[i]["是否电子锁"].ToString() != "0")
                        {
                            dt.Rows[i]["是否电子锁"] = "是";
                        }
                        else
                        {
                            dt.Rows[i]["是否电子锁"] = "否";
                        }

                        //if (dt.Rows[i]["ISBZ"].ToString() != "0")
                        //{
                        //    dt.Rows[i]["ISBZ"] = "是";
                        //}
                        //else
                        //{
                        //    dt.Rows[i]["ISBZ"] = "否";
                        //}

                        if (dt.Rows[i]["ImgSPcount"].ToString() != "0")
                        {
                            dt.Rows[i]["ImgSPcount"] = "是";
                        }
                        else
                        {
                            dt.Rows[i]["ImgSPcount"] = "否";
                        }

                        if (Convert.ToInt32(dt.Rows[i]["DisplayItemCount"].ToString()) >= 1)
                        {
                            dt.Rows[i]["DisplayItemCount"] = "是";
                        }
                        else
                        {
                            dt.Rows[i]["DisplayItemCount"] = "否";
                        }
                        dt.Rows[i]["WDLXDES"] = dt.Rows[i]["WDLXDES"].ToString().Replace(@"\\", @"\");
                    }

                    dt.Columns["HDMC"].ColumnName = "活动";
                    dt.Columns["CZSJ"].ColumnName = "创建时间";
                    dt.Columns["KHZZSJ"].ColumnName = "开发时间";
                    dt.Columns["SFDES"].ColumnName = "省份";
                    dt.Columns["CSDES"].ColumnName = "城市";
                    dt.Columns["MDDZ"].ColumnName = "正常地址";
                    dt.Columns["GSLXR"].ColumnName = "联系人";
                    dt.Columns["GSLXDH"].ColumnName = "联系电话";
                    dt.Columns["WDLXDES"].ColumnName = "网点类型";
                    dt.Columns["DISPLAY"].ColumnName = "陈列";
                    dt.Columns["ImgSPcount"].ColumnName = "陈列照片是否审核通过";
                    dt.Columns["DisplayItemCount"].ColumnName = "是否有双鹿陈列道具";
                    dt.Columns["XSPZ"].ColumnName = "销售品种";
                    dt.Columns["JINGPIN"].ColumnName = "竞品";
                    //dt.Columns["ISBZ"].ColumnName = "是否标准网点";
                    dt.Columns["BEIZ"].ColumnName = "备注";
                    //dt.Columns["XL"].ColumnName = "有效网点销量";
                    //dt.Columns["SM"].ColumnName = "有效网点说明";
                    dt.Columns["XYPP"].ColumnName = "现有品牌、数量";
                    dt.Columns["QDDZ"].ColumnName = "签到地址";
                    dt.Columns["QDDZSOURCE"].ColumnName = "地址来源";
                    dt.Columns["MT_SOURCE"].ColumnName = "门头照片";
                    dt.Columns["ISYC"].ColumnName = "拜访记录";
                    dt.Columns["BFMT_SOURCE"].ColumnName = "拜访门头照片";
                    dt.Columns["BFDISPLAY_SOURCE"].ColumnName = "拜访陈列照片";
                    dt.Columns["CZRDES"].ColumnName = "创建人";


                    dt.Columns["开发时间"].SetOrdinal(0);
                    dt.Columns["创建时间"].SetOrdinal(1);
                    dt.Columns["创建人"].SetOrdinal(2);
                    dt.Columns["业务员"].SetOrdinal(3);
                    dt.Columns["分管领导"].SetOrdinal(4);
                    dt.Columns["省份"].SetOrdinal(5);
                    dt.Columns["城市"].SetOrdinal(6);
                    dt.Columns["经销商编号"].SetOrdinal(7);
                    dt.Columns["经销商SAP编号"].SetOrdinal(8);
                    dt.Columns["经销商名称"].SetOrdinal(9);
                    dt.Columns["终端网点编号"].SetOrdinal(10);
                    dt.Columns["网点名称"].SetOrdinal(11);
                    dt.Columns["正常地址"].SetOrdinal(12);
                    dt.Columns["签到地址"].SetOrdinal(13);
                    dt.Columns["地址来源"].SetOrdinal(14);
                    dt.Columns["联系人"].SetOrdinal(15);
                    dt.Columns["联系电话"].SetOrdinal(16);
                    dt.Columns["网点类型"].SetOrdinal(17);
                    dt.Columns["直销商"].SetOrdinal(18);
                    dt.Columns["门头照片"].SetOrdinal(19);
                    dt.Columns["陈列"].SetOrdinal(20);
                    dt.Columns["陈列照片是否审核通过"].SetOrdinal(21);
                    dt.Columns["是否有双鹿陈列道具"].SetOrdinal(22);
                    dt.Columns["销售品种"].SetOrdinal(23);
                    dt.Columns["竞品"].SetOrdinal(24);
                    //dt.Columns["是否标准网点"].SetOrdinal(25);
                    dt.Columns["备注"].SetOrdinal(25);
                    //dt.Columns["有效网点开发"].SetOrdinal(26);
                    //dt.Columns["有效网点销量"].SetOrdinal(27);
                    //dt.Columns["有效网点说明"].SetOrdinal(28);
                    dt.Columns["是否电子锁"].SetOrdinal(26);
                    dt.Columns["现有品牌、数量"].SetOrdinal(27);
                    dt.Columns["活动"].SetOrdinal(28);
                    dt.Columns["拜访记录"].SetOrdinal(29);
                    dt.Columns["拜访门头照片"].SetOrdinal(30);
                    dt.Columns["拜访陈列照片"].SetOrdinal(31);
                    #endregion
                    break;
                case 7:
                    #region
                    dt.Columns.Remove("SF");
                    dt.Columns.Remove("CS");
                    dt.Columns.Remove("CZSJ_BEGIN");
                    dt.Columns.Remove("CZSJ_END");
                    dt.Columns.Remove("KHZZSJ_BEGIN");
                    dt.Columns.Remove("KHZZSJ_END");
                    dt.Columns.Remove("MCLC");
                    dt.Columns.Remove("KHID");
                    dt.Columns.Remove("DISIMG");
                    dt.Columns.Remove("DISIMG2");
                    dt.Columns.Remove("CZR");
                    dt.Columns.Remove("BFCS");
                    dt.Columns.Remove("BF_MT");
                    dt.Columns.Remove("BF_DISPLAY");
                    dt.Columns.Remove("IMG_MT");
                    dt.Columns.Remove("XL");
                    dt.Columns.Remove("SM");
                    dt.Columns.Remove("ISYX");
                    dt.Columns.Remove("DISPLAY_STATUS");
                    dt.Columns.Remove("DISPLAYITEM");

                    dt.Columns["SFDES"].ColumnName = "省份";
                    dt.Columns["CSDES"].ColumnName = "城市";
                    dt.Columns["CZSJ"].ColumnName = "客户创建时间";
                    dt.Columns["KHZZSJ"].ColumnName = "客户开发时间";
                    dt.Columns["MCLCDES"].ColumnName = "门店类型";
                    dt.Columns["MDDZ"].ColumnName = "门店地址";
                    dt.Columns["JCDPSL"].ColumnName = "进场单品数量";
                    dt.Columns["XSSJSM"].ColumnName = "双鹿销售主要品种";
                    dt.Columns["JINGPIN"].ColumnName = "竞品";
                    dt.Columns["MT_SOURCE"].ColumnName = "门头照片";
                    dt.Columns["DISPLAY"].ColumnName = "主陈列";
                    dt.Columns["DISPLAY2"].ColumnName = "二次陈列";
                    dt.Columns["ImgSPcount"].ColumnName = "陈列照片是否审核通过";
                    dt.Columns["DisplayItemCount"].ColumnName = "是否有双鹿陈列道具";
                    dt.Columns["BEIZ"].ColumnName = "备注";
                    //dt.Columns["XL"].ColumnName = "有效网点销量";
                    //dt.Columns["SM"].ColumnName = "有效网点说明";
                    dt.Columns["STAFF"].ColumnName = "业务员";
                    dt.Columns["JXSID"].ColumnName = "经销商编号";
                    dt.Columns["JXSNAME"].ColumnName = "经销商名称";
                    dt.Columns["JXSSAPSN"].ColumnName = "经销商SAP编号";
                    dt.Columns["PKHCRMID"].ColumnName = "卖场编号";
                    dt.Columns["PKHMC"].ColumnName = "卖场名称";
                    dt.Columns["MDJCSL"].ColumnName = "门店进场数量";
                    dt.Columns["PKHMDDZ"].ColumnName = "卖场总部地址";
                    dt.Columns["CRMID"].ColumnName = "门店编号";
                    dt.Columns["MC"].ColumnName = "门店名称";
                    //dt.Columns["ISYX"].ColumnName = "有效网点开发";
                    dt.Columns["QDDZ"].ColumnName = "签到地址";
                    dt.Columns["QDDZSOURCE"].ColumnName = "地址来源";
                    dt.Columns["ISYC"].ColumnName = "拜访记录";
                    dt.Columns["BFMT_SOURCE"].ColumnName = "拜访门头照片";
                    dt.Columns["BFDISPLAY_SOURCE"].ColumnName = "拜访陈列照片";
                    dt.Columns["CZRDES"].ColumnName = "创建人";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //if (dt.Rows[i]["有效网点开发"].ToString() != "0")
                        //{
                        //    dt.Rows[i]["有效网点开发"] = "是";
                        //}
                        //else
                        //{
                        //    dt.Rows[i]["有效网点开发"] = "否";
                        //}

                        if (dt.Rows[i]["陈列照片是否审核通过"].ToString() != "0")
                        {
                            dt.Rows[i]["陈列照片是否审核通过"] = "是";
                        }
                        else
                        {
                            dt.Rows[i]["陈列照片是否审核通过"] = "否";
                        }

                        if (Convert.ToInt32(dt.Rows[i]["是否有双鹿陈列道具"].ToString()) >= 1)
                        {
                            dt.Rows[i]["是否有双鹿陈列道具"] = "是";
                        }
                        else
                        {
                            dt.Rows[i]["是否有双鹿陈列道具"] = "否";
                        }
                    }

                    dt.Columns["创建人"].SetOrdinal(3);
                    dt.Columns["业务员"].SetOrdinal(5);
                    dt.Columns["经销商编号"].SetOrdinal(6);
                    dt.Columns["经销商SAP编号"].SetOrdinal(7);
                    dt.Columns["经销商名称"].SetOrdinal(8);
                    dt.Columns["卖场编号"].SetOrdinal(9);
                    dt.Columns["卖场名称"].SetOrdinal(10);
                    dt.Columns["门店进场数量"].SetOrdinal(11);
                    dt.Columns["卖场总部地址"].SetOrdinal(12);
                    dt.Columns["门店编号"].SetOrdinal(13);
                    dt.Columns["门店名称"].SetOrdinal(14);
                    dt.Columns["签到地址"].SetOrdinal(17);
                    dt.Columns["地址来源"].SetOrdinal(18);
                    dt.Columns["陈列照片是否审核通过"].SetOrdinal(25);
                    dt.Columns["是否有双鹿陈列道具"].SetOrdinal(26);
                    //dt.Columns["有效网点开发"].SetOrdinal(26);
                    //dt.Columns["有效网点销量"].SetOrdinal(27);
                    //dt.Columns["有效网点说明"].SetOrdinal(28);
                    dt.Columns["拜访记录"].SetOrdinal(27);
                    dt.Columns["拜访门头照片"].SetOrdinal(28);
                    dt.Columns["拜访陈列照片"].SetOrdinal(29);

                    #endregion
                    break;
                case 8:
                    #region

                    dt.Columns.Remove("SalesOrderDiscount");
                    dt.Columns.Remove("CustomerPO");
                    dt.Columns.Remove("SalesOrder");
                    dt.Columns.Remove("SalesOrderItem");
                    dt.Columns.Remove("Material");
                    dt.Columns.Remove("MaterialDescription");
                    dt.Columns.Remove("DeliveryDate");
                    dt.Columns.Remove("DeliveryItem");
                    dt.Columns.Remove("Currency");
                    dt.Columns.Remove("SOCustomerText");
                    dt.Columns.Remove("Quantity");
                    dt.Columns.Remove("QuantityDelivered");
                    dt.Columns.Remove("Unit");
                    dt.Columns.Remove("UnitDescription");
                    dt.Columns.Remove("Price");
                    dt.Columns.Remove("Amount");
                    dt.Columns.Remove("SalesOrganization");
                    dt.Columns.Remove("DistributionChannel");
                    dt.Columns.Remove("Division");
                    dt.Columns.Remove("DecreaseDiscount");
                    dt.Columns.Remove("IncreaseDiscount");
                    dt.Columns.Remove("AvailableDiscount");
                    dt.Columns.Remove("DocumentChangeNumber");
                    dt.Columns.Remove("Unit2");
                    dt.Columns.Remove("JE");



                    dt.Columns["Date"].ColumnName = "日期";
                    dt.Columns["Delivery"].ColumnName = "出库单编号";
                    dt.Columns["Customer"].ColumnName = "客户编号";
                    dt.Columns["CustomerName"].ColumnName = "客户名称";
                    dt.Columns["Type"].ColumnName = "业务类型";
                    dt.Columns["Receivable"].ColumnName = "本期应收";
                    dt.Columns["Payable"].ColumnName = "本期应付";
                    dt.Columns["Balance"].ColumnName = "结余金额";
                    dt.Columns["Invoice"].ColumnName = "金税发票号码";
                    dt.Columns["Remark"].ColumnName = "费用说明";



                    dt.Columns["日期"].SetOrdinal(0);
                    dt.Columns["出库单编号"].SetOrdinal(1);
                    dt.Columns["客户编号"].SetOrdinal(2);
                    dt.Columns["客户名称"].SetOrdinal(3);
                    dt.Columns["业务类型"].SetOrdinal(4);
                    dt.Columns["本期应收"].SetOrdinal(5);
                    dt.Columns["本期应付"].SetOrdinal(6);
                    dt.Columns["结余金额"].SetOrdinal(7);
                    dt.Columns["金税发票号码"].SetOrdinal(8);
                    dt.Columns["费用说明"].SetOrdinal(9);

                    #endregion
                    break;
                case 9:
                    #region
                    dt.Columns.Remove("SalesOrderDiscount");
                    dt.Columns.Remove("Payable");
                    dt.Columns.Remove("Receivable");
                    dt.Columns.Remove("Balance");
                    dt.Columns.Remove("Invoice");
                    dt.Columns.Remove("Remark");
                    dt.Columns.Remove("SOCustomerText");
                    dt.Columns.Remove("UnitDescription");
                    dt.Columns.Remove("SalesOrganization");
                    dt.Columns.Remove("DistributionChannel");
                    dt.Columns.Remove("Division");
                    dt.Columns.Remove("DecreaseDiscount");
                    dt.Columns.Remove("IncreaseDiscount");
                    dt.Columns.Remove("AvailableDiscount");
                    dt.Columns.Remove("DocumentChangeNumber");
                    dt.Columns.Remove("CustomerPO");
                    dt.Columns.Remove("Type");
                    dt.Columns.Remove("Price");
                    dt.Columns.Remove("Currency");
                    dt.Columns.Remove("Amount");
                    dt.Columns.Remove("Unit");


                    dt.Columns["Customer"].ColumnName = "客户编号";
                    dt.Columns["CustomerName"].ColumnName = "客户名称";
                    dt.Columns["Date"].ColumnName = "销售订单日期";
                    dt.Columns["SalesOrder"].ColumnName = "销售订单";
                    dt.Columns["SalesOrderItem"].ColumnName = "销售订单项目";
                    dt.Columns["Material"].ColumnName = "物料";
                    dt.Columns["MaterialDescription"].ColumnName = "描述";
                    dt.Columns["Quantity"].ColumnName = "订单数量";
                    dt.Columns["DeliveryDate"].ColumnName = "交货日期";
                    dt.Columns["Delivery"].ColumnName = "交货单号";
                    dt.Columns["DeliveryItem"].ColumnName = "交货项目";
                    dt.Columns["QuantityDelivered"].ColumnName = "交货数量";
                    dt.Columns["Unit2"].ColumnName = "基本单位";
                    dt.Columns["JE"].ColumnName = "金额";




                    dt.Columns["客户编号"].SetOrdinal(0);
                    dt.Columns["客户名称"].SetOrdinal(1);
                    dt.Columns["销售订单日期"].SetOrdinal(2);
                    dt.Columns["销售订单"].SetOrdinal(3);
                    dt.Columns["销售订单项目"].SetOrdinal(4);
                    dt.Columns["物料"].SetOrdinal(5);
                    dt.Columns["描述"].SetOrdinal(6);
                    dt.Columns["订单数量"].SetOrdinal(7);
                    dt.Columns["交货日期"].SetOrdinal(8);
                    dt.Columns["交货单号"].SetOrdinal(9);
                    dt.Columns["交货项目"].SetOrdinal(10);
                    dt.Columns["交货数量"].SetOrdinal(11);
                    dt.Columns["基本单位"].SetOrdinal(12);
                    dt.Columns["金额"].SetOrdinal(13);

                    #endregion
                    break;
                case 10:
                    #region
                    dt.Columns.Remove("SalesOrderDiscount");
                    dt.Columns.Remove("CustomerPO");
                    dt.Columns.Remove("SalesOrderItem");
                    dt.Columns.Remove("Material");
                    dt.Columns.Remove("MaterialDescription");
                    dt.Columns.Remove("DeliveryDate");
                    dt.Columns.Remove("Delivery");
                    dt.Columns.Remove("DeliveryItem");
                    dt.Columns.Remove("Payable");
                    dt.Columns.Remove("Receivable");
                    dt.Columns.Remove("Balance");
                    dt.Columns.Remove("Invoice");
                    dt.Columns.Remove("Currency");
                    dt.Columns.Remove("SOCustomerText");
                    dt.Columns.Remove("Quantity");
                    dt.Columns.Remove("QuantityDelivered");
                    dt.Columns.Remove("Unit");
                    dt.Columns.Remove("UnitDescription");
                    dt.Columns.Remove("Price");
                    dt.Columns.Remove("Amount");
                    dt.Columns.Remove("SalesOrganization");
                    dt.Columns.Remove("DistributionChannel");
                    dt.Columns.Remove("Division");
                    dt.Columns.Remove("Unit2");
                    dt.Columns.Remove("JE");


                    dt.Columns["Customer"].ColumnName = "客户编号";
                    dt.Columns["CustomerName"].ColumnName = "客户名称";
                    dt.Columns["Date"].ColumnName = "日期";
                    dt.Columns["SalesOrder"].ColumnName = "单据编号";
                    dt.Columns["Type"].ColumnName = "业务类型";
                    dt.Columns["IncreaseDiscount"].ColumnName = "折扣录入金额";
                    dt.Columns["DecreaseDiscount"].ColumnName = "折扣发放金额";
                    dt.Columns["AvailableDiscount"].ColumnName = "结余金额";
                    dt.Columns["DocumentChangeNumber"].ColumnName = "文档编号";
                    dt.Columns["Remark"].ColumnName = "备注";



                    dt.Columns["客户编号"].SetOrdinal(0);
                    dt.Columns["客户名称"].SetOrdinal(1);
                    dt.Columns["日期"].SetOrdinal(2);
                    dt.Columns["单据编号"].SetOrdinal(3);
                    dt.Columns["业务类型"].SetOrdinal(4);
                    dt.Columns["折扣录入金额"].SetOrdinal(5);
                    dt.Columns["折扣发放金额"].SetOrdinal(6);
                    dt.Columns["结余金额"].SetOrdinal(7);
                    dt.Columns["文档编号"].SetOrdinal(8);
                    dt.Columns["备注"].SetOrdinal(9);

                    #endregion
                    break;
                case 11:
                    dt.Columns.Remove("LAY_TABLE_INDEX");

                    dt.Columns["STAFFNAME"].ColumnName = "人员姓名";
                    dt.Columns["DEPNAME"].ColumnName = "部门";

                    break;
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

        public static DataTable ToDataTable(string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }

                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }

        public void DataTabletoExcel(DataTable dt, string path)
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].ColumnName.ToString() + "\t");
            }
            sb.Append(Environment.NewLine);

            for (int m = 0; m < dt.Rows.Count; m++)
            {
                System.Windows.Forms.Application.DoEvents();

                for (int n = 0; n < dt.Columns.Count; n++)
                {
                    sb.Append(dt.Rows[m][n].ToString() + "\t");
                }
                sb.Append(Environment.NewLine);
            }
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Close();
        }

        public void NpoiExcel(DataTable dt, string title)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Sheet1");

            NPOI.SS.UserModel.IRow headerrow = sheet.CreateRow(0);
            ICellStyle style = book.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = headerrow.CreateCell(i);
                cell.CellStyle = style;
                cell.SetCellValue(dt.Columns[i].ToString());

            }
            for (int I = 0; I <= dt.Rows.Count - 1; I++)
            {
                HSSFRow row2 = (HSSFRow)sheet.CreateRow(I + 1);
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    string DgvValue = dt.Rows[I][j].ToString();
                    row2.CreateCell(j).SetCellValue(DgvValue);
                    sheet.SetColumnWidth(j, 20 * 150);
                }
            }
            MemoryStream ms = new MemoryStream();
            book.Write(ms);

            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", "test.xls"));
            //  Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", HttpUtility.UrlEncode(title + "_" + DateTime.Now.ToString("yyyy-MM-dd"), System.Text.Encoding.UTF8)));
            Response.BinaryWrite(ms.ToArray());
            Response.End();
            book = null;
            ms.Close();
            ms.Dispose();
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


        [HttpPost]
        public void test2215()
        {
            crmModels.CRM_OA.CRM_OA_FLOW();
        }

        [HttpPost]
        public string Data_Select_UserInfo()
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_STAFF data = crmModels.HG_STAFF.ReadBySTAFFID(appclass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string SendMSG(int STAFFID, string MSG)
        {
            WX_MSG WXMSG = new WX_MSG();
            WXMSG.data = new Data();
            WXMSG.miniprogram = new MiniProgram();
            WXMSG.text = new TEXT();

            WXMSG.data.first = new KeyWord();
            WXMSG.data.first.value = "标题";

            WXMSG.data.keyword1 = new KeyWord();
            WXMSG.data.keyword1.value = "呵呵1";

            WXMSG.data.keyword2 = new KeyWord();
            WXMSG.data.keyword2.value = "呵呵2";

            WXMSG.data.keyword3 = new KeyWord();
            WXMSG.data.keyword3.value = "呵呵3";

            WXMSG.data.remark = new KeyWord();
            WXMSG.data.remark.value = "备注";

            WXMSG.text = new TEXT();
            WXMSG.text.content = "啦啦啦";
            WX_MSG_RETURN MSG_RETURN = crmModels.WX_OPENID.SendMSG(STAFFID, WXMSG, "AppID", "意见反馈通知");
            //WX_MSG_RETURN MSG_RETURN = crmModels.WX_OPENID.SendMSG(STAFFID, WXMSG, "CorpID", "意见反馈通知");
            return Newtonsoft.Json.JsonConvert.SerializeObject(MSG_RETURN);
        }
        //[HttpPost]
        //public string Data_Select_LKAHXZLTT_ForPublic(string cxdata)
        //{
        //    token = appclass.CRM_Gettoken();
        //    CRM_COST_HXZLTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_COST_HXZLTT>(cxdata);
        //    CRM_COST_HXZLTT[] data = crmModels.COST_LKAHXZLTT.ReadByPublic(model, appclass.CRM_GetStaffid(), token);
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        //}
        [HttpPost]
        public string Data_Select_LKAHXZLTT_ForPublic(string cxdata)
        {
            token = appclass.CRM_Gettoken();

            Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_HXZLTT model = new Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_HXZLTT();
            model.ISACTIVE = 20;

            Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_ZZFTT model_jxs = new Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_ZZFTT();
            model_jxs.ISACTIVE = 40;
            model_jxs.COSTITEMID = 34;
            model_jxs.KHLX = 1;

            Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_ZZFTT model_ka = new Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_ZZFTT();
            model_ka.COSTITEMID = 53;

            Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_ZZFTT model_lka = new Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_ZZFTT();
            model_lka.COSTITEMID = 14;

            Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_ZZFTT model_zdwd = new Sonluk.UI.Model.CRM.COST_PUBLICService.CRM_COST_ZZFTT();
            model_zdwd.ISACTIVE = 40;
            model_zdwd.COSTITEMID = 34;
            model_zdwd.KHLX = 5;

            CRM_COST_PUBLIC[] data = crmModels.COST_PUBLIC.ReadByPublic(model, model_jxs, model_ka, model_lka, model_zdwd, appclass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);


            //    return "";
            //   
        }


    }
}
