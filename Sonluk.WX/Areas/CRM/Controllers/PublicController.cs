using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Xml;
using System.Net;
using Sonluk.WX.Models;
using Sonluk.WX.Models.WX;
using Sonluk.WX.Models.QY;
using Newtonsoft.Json;
using Sonluk.UI.Model.CRM.HG_WJJLService;
using System.Web.Security;
using Sonluk.UI.Model.CRM.CRM_LoginService;
using System.Drawing;
using System.Drawing.Imaging;
using Sonluk.UI.Model.CRM.WX_OPENIDService;
using Sonluk.UI.Model.CRM.KQ_QDService;
using Newtonsoft.Json.Linq;
using Sonluk.WX.APPCLASS;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.OA_OPINIONService;
using System.Configuration;
using Sonluk.SSO.Models;
using Sonluk.UI.Model.MODEL;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class PublicController : Controller
    {
        //
        // GET: /CRM/Public/
        CRMModels crmModels = new CRMModels();
        AppClass appclass = new AppClass();
        SSOModels ssomodels = new SSOModels();
        PUBLICModels publicmodels = new PUBLICModels();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];

        public ActionResult test()
        {
            return View();
        }

        public ActionResult Index()
        {
            Session["TITLENAME"] = "主页";
            return View();
        }

        public ActionResult Index1()
        {
            Session["TITLENAME"] = "主页";
            return View();
        }

        public ActionResult Account()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            string code = Request.QueryString["code"];
            string state = Request.QueryString["state"];
            //string code = "021Ebud514VocN1oQWd51ku7d51Ebud6";

            HttpCookie cookie = new HttpCookie("UserInfo");
            string TOKENIDtemp = Request.QueryString["TOKENID"];
            string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];
            string corpid = System.Configuration.ConfigurationManager.AppSettings["CorpID"];
            string openid = "";
            string userid = "";

            if (!string.IsNullOrEmpty(code))               //有code
            {
                if (state == "WX")                             //微信公众号登录
                {
                    Session["state"] = "WX";
                    ViewBag.token = "当前登录平台：微信公众号";
                    Response.Cookies["state"].Value = "WX";

                    ViewBag.code = code;
                    if (string.IsNullOrEmpty(TOKENIDtemp))
                    {
                        //只有第一次时执行
                        string[] data = GetWebToken(code);
                        if (data[0] == "ok")
                        {
                            openid = data[1];
                            ViewBag.openid = openid;
                            Session["openid"] = openid;

                        }
                    }

                    //if (data[0] == "ok")                                      //成功获取openid
                    //{


                    //这里要判断openid是否在数据库中绑定过，如果有，就直接跳转Index
                    //CRM_LoginInfo tokeninfo = crmModels.CRM_Login.Login("", "", openid, appid, 0, 1);
                    //Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
                    ActionResult target;

                    //if (tokeninfo.TokenInfo.access_token == null)
                    //{
                    //没有绑定过微信，需要输入密码登录，然后要先跳转到SSO统一登录
                    target = RedirectToAction("SignIn", "Public");
                    string url = Request.Url.ToString();
                    string SSOURL = "";
                    if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1)
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
                    url = url + "&OPENID=" + openid + "&WXDLCS=" + appid + "&state=" + state + "&code=" + code;
                    if (LOGINTYPE == "1")
                    {
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
                        //第二次时执行
                        MES_RETURN_UI rst_MES_RETURN_UI = ssomodels.TOKEN_TOKENIDINFO.SELECT(TOKENID);
                        if (rst_MES_RETURN_UI.TYPE == "S")
                        {
                            Response.Cookies["token"].Value = rst_MES_RETURN_UI.MESSAGE;
                            Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
                            CRM_LoginInfo tokeninfo2 = crmModels.CRM_Login.Login_SSO_TOKEN(TOKENID, 0, 1);
                            if (tokeninfo2.TokenInfo.access_token != "")
                            {
                                getlogininfo(tokeninfo2);
                                Response.Cookies["TokenID"].Value = TOKENID;
                                //target = RedirectToAction("Index1", "Public");
                                CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo2.TokenInfo.STAFFID, tokeninfo2.TokenInfo.access_token);
                                if (staffdata.USERLX == 1107)
                                {
                                    target = RedirectToAction("Index1", "Order", new { area = "CRM" });
                                }
                                else
                                {
                                    target = RedirectToAction("Index1", "Public", new { area = "CRM" });
                                }
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
                        //第一次执行，跳转SSO
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
                                    CRM_LoginInfo tokeninfo2 = crmModels.CRM_Login.Login_SSO_TOKEN(Request.Cookies["TokenID"].Value, 0, 1);
                                    if (tokeninfo2.TokenInfo.access_token != "")
                                    {
                                        getlogininfo(tokeninfo2);
                                        //target = RedirectToAction("Index1", "Public");
                                        CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo2.TokenInfo.STAFFID, tokeninfo2.TokenInfo.access_token);
                                        if (staffdata.USERLX == 1107)
                                        {
                                            target = RedirectToAction("Index1", "Order", new { area = "CRM" });
                                        }
                                        else
                                        {
                                            target = RedirectToAction("Index1", "Public", new { area = "CRM" });
                                        }
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
                    //}
                    //else
                    //{
                    //    Session["token"] = tokeninfo.TokenInfo.access_token;
                    //    Session["STAFFID"] = tokeninfo.TokenInfo.STAFFID;
                    //    CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token);
                    //    Session["NAME"] = staffdata.STAFFNAME;
                    //    Session["USERLX"] = staffdata.USERLX;
                    //    if (staffdata.USERLX == 1107)
                    //    {
                    //        target = RedirectToAction("Index1", "Order", new { area = "CRM" });
                    //    }
                    //    else
                    //    {
                    //        target = RedirectToAction("Index1", "Public", new { area = "CRM" });
                    //    }

                    //    return target;
                    //}






                    //}
                    //else                                                    //获取openid失败
                    //{
                    //    ViewBag.errmsg = data[1];
                    //}
                }
                else if (state == "QY")                       //企业微信登录
                {
                    Session["state"] = "QY";
                    ViewBag.code = code;
                    ViewBag.token = "当前登录平台：企业微信";
                    Response.Cookies["state"].Value = "QY";

                    if (string.IsNullOrEmpty(TOKENIDtemp))
                    {
                        //只有第一次时执行
                        string[] data = GetQYwebToken(code);
                        if (data[0] == "ok")
                        {
                            userid = data[1];
                            ViewBag.userid = userid;
                            Session["openid"] = userid;
                        }

                    }

                    //if (data[0] == "ok")                                    //成功获取userid或openid
                    //{


                    //这里要判断userid是否在数据库中绑定过，如果有，就直接跳转Index
                    //CRM_LoginInfo tokeninfo = crmModels.CRM_Login.Login("", "", userid, corpid, 0, 1);
                    //Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
                    ActionResult target;

                    //if (tokeninfo.TokenInfo.access_token == null)
                    //{
                    //没有绑定过微信，需要输入密码登录，然后要先跳转到SSO统一登录
                    target = RedirectToAction("SignIn", "Public");
                    string url = Request.Url.ToString();
                    string SSOURL = "";
                    if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1)
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
                    url = url + "&OPENID=" + userid + "&WXDLCS=" + corpid + "&state=" + state + "&code=" + code;
                    if (LOGINTYPE == "1")
                    {
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
                            CRM_LoginInfo tokeninfo2 = crmModels.CRM_Login.Login_SSO_TOKEN(TOKENID, 0, 1);
                            if (tokeninfo2.TokenInfo.access_token != "")
                            {
                                getlogininfo(tokeninfo2);
                                Response.Cookies["TokenID"].Value = TOKENID;
                                //target = RedirectToAction("Index1", "Public");
                                CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo2.TokenInfo.STAFFID, tokeninfo2.TokenInfo.access_token);
                                if (staffdata.USERLX == 1107)
                                {
                                    target = RedirectToAction("Index1", "Order", new { area = "CRM" });
                                }
                                else
                                {
                                    target = RedirectToAction("Index1", "Public", new { area = "CRM" });
                                }


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
                                    CRM_LoginInfo tokeninfo2 = crmModels.CRM_Login.Login_SSO_TOKEN(Request.Cookies["TokenID"].Value, 0, 1);
                                    if (tokeninfo2.TokenInfo.access_token != "")
                                    {
                                        getlogininfo(tokeninfo2);
                                        //target = RedirectToAction("Index1", "Public");
                                        CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo2.TokenInfo.STAFFID, tokeninfo2.TokenInfo.access_token);
                                        if (staffdata.USERLX == 1107)
                                        {
                                            target = RedirectToAction("Index1", "Order", new { area = "CRM" });
                                        }
                                        else
                                        {
                                            target = RedirectToAction("Index1", "Public", new { area = "CRM" });
                                        }
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
                    //}
                    //else
                    //{
                    //    Session["token"] = tokeninfo.TokenInfo.access_token;
                    //    Session["STAFFID"] = tokeninfo.TokenInfo.STAFFID;
                    //    CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token);
                    //    Session["NAME"] = staffdata.STAFFNAME;
                    //    Session["USERLX"] = staffdata.USERLX;
                    //    if (staffdata.USERLX == 1107)
                    //    {
                    //        target = RedirectToAction("Index1", "Order", new { area = "CRM" });
                    //    }
                    //    else
                    //    {
                    //        target = RedirectToAction("Index1", "Public", new { area = "CRM" });
                    //    }
                    //    return target;
                    //}

                    //}
                    //else                                                     //获取userid或openid失败
                    //{
                    //    ViewBag.errmsg = data[1];
                    //}
                }
                else                                         //不太可能发生的情况
                {
                    Response.Cookies["state"].Value = "";
                    string msg = "登录失败,请联系管理员";
                    ViewBag.errmsg = msg;
                }
            }
            else                        //没有code
            {
                //没有绑定过微信，需要输入密码登录，然后要先跳转到SSO统一登录
                ActionResult target;
                target = RedirectToAction("SignIn", "Public");
                string url = Request.Url.ToString();
                string SSOURL = "";
                if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1)
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
                string WXDLCS = "";
                if (Session["state"] == null)
                {

                }
                else
                {
                    state = Session["state"].ToString();
                    if (state == "WX")
                    {
                        openid = Session["openid"].ToString();
                        WXDLCS = appid;
                    }
                    else if (state == "QY")
                    {
                        openid = Session["openid"].ToString();
                        WXDLCS = corpid;
                    }
                    else
                    {
                        openid = "";
                        WXDLCS = "";
                    }
                }

                url = url + "&OPENID=" + openid + "&WXDLCS=" + WXDLCS + "&state=" + state + "&code=" + code;
                if (LOGINTYPE == "1")
                {
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
                        CRM_LoginInfo tokeninfo2 = crmModels.CRM_Login.Login_SSO_TOKEN(TOKENID, 0, 1);
                        if (tokeninfo2.TokenInfo.access_token != "")
                        {
                            getlogininfo(tokeninfo2);
                            Response.Cookies["TokenID"].Value = TOKENID;
                            CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo2.TokenInfo.STAFFID, tokeninfo2.TokenInfo.access_token);
                            if (staffdata.USERLX == 1107)
                            {
                                target = RedirectToAction("Index1", "Order", new { area = "CRM" });
                            }
                            else
                            {
                                target = RedirectToAction("Index1", "Public", new { area = "CRM" });
                            }
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
                                CRM_LoginInfo tokeninfo2 = crmModels.CRM_Login.Login_SSO_TOKEN(Request.Cookies["TokenID"].Value, 0, 1);
                                if (tokeninfo2.TokenInfo.access_token != "")
                                {
                                    getlogininfo(tokeninfo2);
                                    CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo2.TokenInfo.STAFFID, tokeninfo2.TokenInfo.access_token);
                                    if (staffdata.USERLX == 1107)
                                    {
                                        target = RedirectToAction("Index1", "Order", new { area = "CRM" });
                                    }
                                    else
                                    {
                                        target = RedirectToAction("Index1", "Public", new { area = "CRM" });
                                    }
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

                //if (Session["state"] != null && Session["state"].ToString() == "WX")                         //微信公众号登录,点注销过来的
                //{
                //    ViewBag.token = "当前登录平台：微信公众号";

                //}
                //else if (Session["state"] != null && Session["state"].ToString() == "QY")                    //企业微信登录,点注销过来的
                //{
                //    ViewBag.token = "当前登录平台：企业微信";

                //}
                //else if (state == "PDA" || (Session["state"] != null && Session["state"].ToString() == "PDA"))           //PDA登录或者点了注销
                //{
                //    Session["state"] = "PDA";
                //    ViewBag.token = "当前登录平台：PDA";
                //}
                //else                                       //没有code也没有state,非微信登录
                //{
                //    string msg = "请从微信或企业微信登录";
                //    ViewBag.errmsg = msg;
                //    ViewBag.code = code;
                //}
            }

            return View();
        }

        public void getlogininfo(CRM_LoginInfo tokeninfo)
        {
            Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
            Session["token"] = tokeninfo.TokenInfo.access_token;
            Session["STAFFID"] = tokeninfo.TokenInfo.STAFFID;
            //Session["NAME"] = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token).STAFFNAME;
            Response.Cookies["token"].Value = tokeninfo.TokenInfo.access_token;
            Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
            Session["MYPW"] = null;

            CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token);
            Session["NAME"] = staffdata.STAFFNAME;
            Session["USERLX"] = staffdata.USERLX;
        }


        public ActionResult Verify(string name, string password, string auto)         //登录验证
        {
            //TokenInfo tokeninfo = models.UserToken.Token(name, password);          //验证登录信息
            CRM_LoginInfo tokeninfo = crmModels.CRM_Login.Login(name, password, "", "", 0, 1);

            Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
            CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token);

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

            }
            else
            {
                Session["ErrorMessage"] = null;
                Session["token"] = tokeninfo.TokenInfo.access_token;
                Session["STAFFID"] = tokeninfo.TokenInfo.STAFFID;

                Session["NAME"] = staffdata.STAFFNAME;
                Session["USERLX"] = staffdata.USERLX;
                //AccountInfo staffinfo = models.UserToken.AcceptToken(tokeninfo.access_token);
                //Session["ID"] = staffinfo.ID;
                //Session["NAME"] = staffinfo.Name;

                if (auto != null && auto == "on")
                {
                    CRM_WX_OPENID model = new CRM_WX_OPENID();
                    if (Session["openid"] != null)
                        model.OPENID = Session["openid"].ToString();
                    model.STAFFID = tokeninfo.TokenInfo.STAFFID;
                    if (Session["state"] != null)
                    {
                        if (Session["state"].ToString() == "WX")
                            model.WXDLCS = System.Configuration.ConfigurationManager.AppSettings["AppID"];
                        else if (Session["state"].ToString() == "QY")
                            model.WXDLCS = System.Configuration.ConfigurationManager.AppSettings["CorpID"];
                    }
                    crmModels.WX_OPENID.Create(model, "自动登录", tokeninfo.TokenInfo.access_token);
                }



                Response.Cookies["userName"].Value = name + "_" + password;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(10);
            }
            ActionResult target;
            if (tokeninfo.TokenInfo.access_token == null)
            {
                target = RedirectToAction("SignIn", "Public");
            }
            else
            {
                if (tokeninfo.TokenInfo.MESSAGE == "密码长度必须大于8位")
                {
                    //跳转到修改密码界面
                    target = RedirectToAction("Password", "System");
                }
                else
                {
                    if (staffdata.USERLX == 1107)
                    {
                        target = RedirectToAction("Index1", "Order");
                    }
                    else
                    {
                        target = RedirectToAction("Index1", "Public");
                    }

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
            model.EXPIRES_IN = Convert.ToInt32(token_modle.expires_in) / 2 + 200;
            crmModels.CRM_Login.WX_SYS_Update(model, token);

            string[] s = new string[2];
            s[0] = token_modle.access_token;
            s[1] = ticket;
            return s;
        }







        /// <summary>
        /// 公众号,企业号,获取Code
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCode(string TimeOut, string place)
        {
            //如果登录过期，根据cookie里面的tokenid重新刷新session
            if (!String.IsNullOrEmpty(TimeOut) && Request.Cookies["TokenID"] != null)
            {
                CRM_LoginInfo tokeninfo2 = crmModels.CRM_Login.Login_SSO_TOKEN(Request.Cookies["TokenID"].Value, 0, 1);
                if (tokeninfo2.TokenInfo.access_token != "")
                {
                    getlogininfo(tokeninfo2);
                    ActionResult target;
                    CRM_HG_STAFF staffdata = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo2.TokenInfo.STAFFID, tokeninfo2.TokenInfo.access_token);
                    if (staffdata.USERLX == 1107)
                    {
                        target = RedirectToAction("Index1", "Order", new { area = "CRM" });
                    }
                    else
                    {
                        target = RedirectToAction("Index1", "Public", new { area = "CRM" });
                    }
                }
            }
            string url = System.Configuration.ConfigurationManager.AppSettings["Code_url"];
            if (place == "WX")
            {
                string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];
                string redirect_uri = HttpUtility.UrlEncode(url);

                //string scope = "snsapi_base";           //不弹出授权页面，直接跳转，只能获取用户openid
                string scope = "snsapi_userinfo";      //弹出授权页面，可通过openid拿到昵称、性别、所在地

                string code = "https://open.weixin.qq.com/connect/oauth2/authorize?appid="
                    + appid + "&redirect_uri=" + redirect_uri + "&response_type=code&scope=" + scope + "&state=WX#wechat_redirect";

                Response.Redirect(code);
                return View();
            }
            else if (place == "QY")
            {
                string AgentId = System.Configuration.ConfigurationManager.AppSettings["AgentId"];
                string CorpID = System.Configuration.ConfigurationManager.AppSettings["CorpID"];
                string redirect_uri = HttpUtility.UrlEncode(url);
                //string scope = "snsapi_base";
                string scope = "snsapi_privateinfo";


                string code = "https://open.weixin.qq.com/connect/oauth2/authorize?appid="
                    + CorpID + "&redirect_uri=" + redirect_uri + "&response_type=code&scope=" + scope + "&agentid=" + AgentId + "&state=QY#wechat_redirect";

                Response.Redirect(code);

                return View();
            }
            else
            {
                //非微信登录
                ViewBag.token = "请从微信或企业微信登录";
                ActionResult target;

                target = RedirectToAction("SignIn", "Public");
                return target;
                //return View("SignIn");
            }

        }


        /// <summary>
        /// 公众号！获取网页授权Token,这个token跟全局token不一样，只有在获取openid用到
        /// </summary>
        /// <returns></returns>
        public string[] GetWebToken(string code)
        {
            string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];
            string secret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];
            string jsondata = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + secret + "&code=" + code + "&grant_type=authorization_code";

            WebRes res = new WebRes();
            string s = res.GetJson(jsondata);
            OpenID mod = JsonConvert.DeserializeObject<OpenID>(s);
            string[] data = new string[2];

            if (mod.Errcode != null)                 //获取openid失败
            {
                data[0] = mod.Errcode;
                data[1] = mod.Errmsg;
            }
            else                                     //成功获取openid
            {
                data[0] = "ok";
                data[1] = mod.Openid;
            }
            return data;
        }



        /// <summary>
        /// 企业微信！获取网页授权Token,这个token跟全局token不一样，只有在获取openid用到
        /// </summary>
        /// <returns></returns>
        public string[] GetQYwebToken(string code)
        {
            string corpid = System.Configuration.ConfigurationManager.AppSettings["CorpID"];
            string token = GetQYtoken(corpid)[0];
            string jsondata = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + token + "&code=" + code;
            WebRes res = new WebRes();
            string s = res.GetJson(jsondata);
            UserID mod = JsonConvert.DeserializeObject<UserID>(s);
            string[] data = new string[2];

            if (Convert.ToInt32(mod.errcode) == 0 && mod.errmsg == "ok")       //成功获取userid或openid
            {

                if (mod.UserId != null)           //userid不为空，即企业成员
                {
                    data[0] = "ok";
                    data[1] = mod.UserId;
                }
                else if (mod.OpenId != null)      //openid不为空,即非企业成员
                {
                    data[0] = "ok";
                    data[1] = mod.OpenId;
                }
                else                              //不太可能发送的情况
                {
                    data[0] = "不ok";
                    data[1] = "获取openid失败";
                }

            }
            else                                  //获取userid失败
            {
                data[0] = mod.errcode;
                data[1] = mod.errmsg;
            }

            return data;
        }


        public string Data_FileUpload(int DXID, string data)
        {
            var file = Request.Files[0];

            string date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss.fff");
            string fileName = date + "_" + DXID;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;     //文件名，包括后缀
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

        [HttpPost]
        public string GetSignature(string urldata)             //获取signature
        {
            try
            {
                string url = System.Web.HttpUtility.UrlDecode(urldata);
                CRM_WX_SYS token_model = new CRM_WX_SYS();
                string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];
                string corpid = System.Configuration.ConfigurationManager.AppSettings["CorpID"];
                string[] TokenAndTicket = new string[2];
                if (Session["state"].ToString() == "WX")
                {
                    TokenAndTicket = GetWXtoken(appid);
                }
                else if (Session["state"].ToString() == "QY")
                {
                    TokenAndTicket = GetQYtoken(corpid);
                }

                token_model.TICKET = TokenAndTicket[1];
                string timestamp = GetTimeStamp();
                string randomStr = GetRandCode(16);
                string string1 = "jsapi_ticket=" + token_model.TICKET + "&noncestr=" + randomStr + "&timestamp=" + timestamp + "&url=" + url;
                string signature = FormsAuthentication.HashPasswordForStoringInConfigFile(string1, "SHA1");
                Signature sign_model = new Signature();
                sign_model.Timestamp = timestamp;
                sign_model.Noncestr = randomStr;
                sign_model.Signa = signature;
                sign_model.Ticket = token_model.TICKET;
                //string data = "{'timestamp':'" + timestamp + "','noncestr':'" + randomStr + "','signature':'" + signature + "','ticket':'" + token_model.TICKET + "'}";
                string string_sign = Newtonsoft.Json.JsonConvert.SerializeObject(sign_model);
                return string_sign;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static string GetRandCode(int iLength)
        {
            string sCode = "";
            if (iLength == 0)
            {
                iLength = 4;
            }
            string codeSerial = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] arr = codeSerial.Split(',');
            int randValue = -1;
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < iLength; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);
                sCode += arr[randValue];
            }
            return sCode;
        }

        [HttpPost]
        public string GetAddress(string lon, string lat)
        {
            string key = System.Configuration.ConfigurationManager.AppSettings["TXmapKey"];
            string str = "https://apis.map.qq.com/ws/geocoder/v1/?location=" + lat + "," + lon + "&key=" + key + "&get_poi=1";
            TXaddress txaddress = JsonConvert.DeserializeObject<TXaddress>(GetJson(str));
            string address = Newtonsoft.Json.JsonConvert.SerializeObject(txaddress);
            return address;
        }


        [HttpPost]
        public string Data_Get_WX_IMG(string serverId, string appid, string imgdata, string qddata, string SF, string CS, string IMGSOURCE, int WJLX)
        {
            try
            {
                if (Session["token"] != null)
                {
                    token = Session["token"].ToString();
                }
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string[] serverIds = serverId.Split(',');
                for (int i = 0; i < serverIds.Length; i++)
                {
                    string name = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss.fff") + "_" + i;

                    string state = "QY";
                    if (Session["state"] != null)
                    {
                        state = Session["state"].ToString();
                    }
                    string url = "";

                    if (state == "WX")
                    {
                        string wxtoken = GetWXtoken(appid)[0];
                        url = "https://api.weixin.qq.com/cgi-bin/media/get?access_token=" + wxtoken + "&media_id=" + serverIds[i];
                    }
                    else if (state == "QY")
                    {
                        //appid = "ww47250b95f4ece306";
                        string qytoken = GetQYtoken(appid)[0];
                        url = "https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token=" + qytoken + "&media_id=" + serverIds[i];
                    }
                    else
                        return "0";


                    string savePath = FileSavePath + @"\upload\" + year + @"\" + month + @"\" + name + ".jpg";

                    if (HttpDownloadWXimg(url, savePath) == false)
                        return "0";
                    else
                    {
                        CRM_HG_WJmodel model = new CRM_HG_WJmodel();
                        CRM_HG_WJJLTT wjjltt = JsonConvert.DeserializeObject<CRM_HG_WJJLTT>(imgdata);
                        if (Session["STAFFID"] != null)
                            wjjltt.CZR = Convert.ToInt32(Session["STAFFID"]);
                        CRM_HG_WJJL wjjl = new CRM_HG_WJJL();
                        wjjl.WJM = name;
                        wjjl.ML = savePath;
                        wjjl.ISATIVE = 1;
                        wjjl.SPZT = 10;
                        wjjl.IMGSOURCE = IMGSOURCE;
                        wjjl.WJLX = WJLX;
                        wjjl.CZR = appclass.CRM_GetStaffid();
                        wjjl.CZSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        model.WJJL = wjjl;
                        model.WJJLTT = wjjltt;
                        int id = crmModels.HG_WJJL.Create(model, token);

                        //把上传图片时的定位信息保存到签到表
                        int province = crmModels.HG_DICT.ReadByDICNAME(SF, 1, token);
                        int city = crmModels.HG_DICT.ReadByDICNAME(CS, 2, token);
                        CRM_KQ_QD qdmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KQ_QD>(qddata);
                        qdmodel.QDGSID = id;
                        qdmodel.SF = province;
                        qdmodel.CS = city;
                        crmModels.KQ_QD.Create(qdmodel, token);




                    }
                }
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public bool HttpDownloadWXimg(string url, string path)
        {
            string tempPath = System.IO.Path.GetDirectoryName(path) + @"\temp";
            System.IO.Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + System.IO.Path.GetFileName(path) + ".temp"; //临时文件
            if (System.IO.File.Exists(tempFile))
            {
                System.IO.File.Delete(tempFile);    //存在则删除
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[2048];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();


                //此部分为附加内容，当文件小于1KB时，刷新微信token，重新下载图片
                if (System.IO.File.Exists(tempFile))
                {
                    FileInfo fi = new FileInfo(tempFile);
                    if (fi.Length <= 1024)
                    {
                        string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];
                        CRM_WX_SYS model = crmModels.CRM_Login.WX_SYS_ReadByWXAPPID(appid, token);
                        ReGetWXtoken(model.WX_SYSID);
                        return HttpDownload(url, path);
                    }
                    else
                    {
                        System.IO.File.Move(tempFile, path);
                        return true;

                    }
                }
                return false;
            }
            catch //(Exception ex)
            {
                //Label2.Text = ex.ToString();
                return false;
            }
        }

        public bool HttpDownload(string url, string path)
        {

            string tempPath = System.IO.Path.GetDirectoryName(path) + @"\temp";
            System.IO.Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + System.IO.Path.GetFileName(path) + ".temp"; //临时文件
            if (System.IO.File.Exists(tempFile))
            {
                System.IO.File.Delete(tempFile);    //存在则删除
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[2048];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();

                //此部分为附加内容，当文件小于1KB时，返回报错
                if (System.IO.File.Exists(tempFile))
                {
                    FileInfo fi = new FileInfo(tempFile);
                    if (fi.Length <= 1024)
                        return false;
                }
                else
                    return false;

                System.IO.File.Move(tempFile, path);
                return true;
            }
            catch //(Exception ex)
            {
                //Label2.Text = ex.ToString();
                return false;
            }
        }


        public void AddWaterText(string oldpath, string savepath, string watertext, WaterPositionMode position, string color, int alpha)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(oldpath);
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            Font font = new Font("arial", 25);
            SizeF ziSizeF = new SizeF();
            ziSizeF = graphics.MeasureString(watertext, font);
            float x = 0f;
            float y = 0f;
            switch (position)
            {
                case WaterPositionMode.LeftTop:
                    x = ziSizeF.Width / 2f;
                    y = 8f;
                    break;
                case WaterPositionMode.LeftBottom:
                    x = ziSizeF.Width / 2f;
                    y = image.Height - ziSizeF.Height;
                    break;
                case WaterPositionMode.RightTop:
                    x = image.Width * 1f - ziSizeF.Width / 2f;
                    y = 8f;
                    break;
                case WaterPositionMode.RightBottom:
                    x = image.Width - ziSizeF.Width;
                    y = image.Height - (ziSizeF.Height) * 3;
                    break;
                case WaterPositionMode.Center:
                    x = image.Width / 2;
                    y = image.Height / 2 - ziSizeF.Height / 2;
                    break;
            }

            StringFormat stringFormat = new StringFormat { Alignment = StringAlignment.Center };
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0));
            graphics.DrawString(watertext, font, solidBrush, x + 1f, y + 1f, stringFormat);
            SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, ColorTranslator.FromHtml(color)));
            graphics.DrawString(watertext, font, brush, x, y, stringFormat);
            solidBrush.Dispose();
            brush.Dispose();
            bitmap.Save(savepath, ImageFormat.Jpeg);






            bitmap.Dispose();
            image.Dispose();


        }

        public enum WaterPositionMode
        {
            LeftTop,
            LeftBottom,
            RightTop,
            RightBottom,
            Center
        }

        [HttpPost]
        public void test1()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string name = "2018_07_25_11_27_39.621_0";
            string old = @"E:\CRM\Areas\CRM\upload\" + year + @"\" + month + @"\" + name + ".jpg";
            string save = @"E:\CRM\Areas\CRM\upload\" + year + @"\" + month + @"\" + @"images\" + name + ".jpg";
            string text = name;
            string color = "Red";
            int alpha = 120;
            WaterPositionMode position = WaterPositionMode.RightBottom;

            AddWaterText(old, save, text, position, color, alpha);

            System.IO.File.Delete(@old);


        }

        [HttpPost]
        public string PostFunction()
        {

            string serviceAddress = "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token=15_Ey79DnrqT5c_IEjZxVjC3jkrvTA765AQrk1eZ3QfHpYHMWJdesLf7PUAn9PmIV5tBm4Wh5dTfd4xxNxa2tlp15MtnMFqSboJN5l1-G4F352YyF5PvT-X26qrtVyDACisgTREPw77d5J0Ldn4WMPcADAZPS";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";
            request.ContentType = "application/json";                          //otKEk1FYKxWN_RQEmMhwNBbnOpKQ
            string strContent = @"{""touser"":[""otKEk1ITo_sukOB5_6b13OISMHoI"",""otKEk1ITo_sukOB5_6b13OISMHoI""],""msgtype"": ""text"",""text"": { ""content"": ""www.baidu.com  <a href='www.sonluk.com'>双鹿</a>""}}";
            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(strContent);
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
        public ActionResult Data_SelectKH_Part(string data)          //查询客户列表
        {
            token = appclass.CRM_Gettoken();
            CRM_Report_KHModel report_model = JsonConvert.DeserializeObject<CRM_Report_KHModel>(data);
            CRM_KH_KHList[] list = crmModels.KH_KH.Report(report_model, Convert.ToInt32(Session["STAFFID"]), token);
            //string s = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            //return s;
            ViewBag.TTdata = list;
            return View();
        }

        [HttpPost]
        public ActionResult Select_FuJian(int GSDX, int GSDXID, int ReadOnly)
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_WJJL[] data = crmModels.HG_WJJL.Read(GSDX, GSDXID, token);
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
            ViewBag.fujian = data;


            ViewBag.GSDX = GSDX;
            ViewBag.GSDXID = GSDXID;
            ViewBag.ReadOnly = ReadOnly;
            return View();
        }

        [HttpPost]
        public ActionResult Select_Opinion(int OACSBH, int OACSLB, int ReadOnly)
        {
            token = appclass.CRM_Gettoken();
            CRM_OA_OPINION cxmodel = new CRM_OA_OPINION();
            cxmodel.OACSLB = OACSLB;
            cxmodel.OACSBH = OACSBH;
            CRM_OA_OPINION[] data = crmModels.OA_OPINION.ReadByParam(cxmodel, token);
            ViewBag.opinion = data;

            ViewBag.OACSBH = OACSBH;
            ViewBag.OACSLB = OACSLB;
            ViewBag.ReadOnly = ReadOnly;
            return View();
        }


    }
}
