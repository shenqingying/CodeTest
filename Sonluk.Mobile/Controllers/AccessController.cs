using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.Mobile.Models;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Sonluk.UI.Model.CRM.CRM_LoginService;
using Sonluk.Mobile.APPCLASS;
using Sonluk.UI.Model.MES.RIGHT_ROLEService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.MES.SY_TYPEMXService;

namespace Sonluk.Mobile.Controllers
{
    public class AccessController : Controller
    {
        //
        // GET: /Access/
        AccountModels models = new AccountModels();
        PUBLICModels publicmodels = new PUBLICModels();
        SSOModels ssomodels = new SSOModels();
        CRMModels crmModels = new CRMModels();
        MESModels mesModels = new MESModels();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Main()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_RIGHT_ROLE menuinfo = models.RIGHT_ROLE.SELECT_ALL(STAFFID, 15, token);
            ViewData.Model = menuinfo;
            Session["TITLENAME"] = "主页";
            return View();
        }

        public ActionResult SignIn()
        {
            //ActionResult target = View();
            //ViewBag.UserVersion = ConfigurationManager.AppSettings["UserVersion"];
            //ViewBag.Message = "";
            //Session["TITLENAME"] = "登录";
            //return target;
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
                    if (tokeninfo.TokenInfo.access_token != "")
                    {
                        getlogininfo(tokeninfo);
                        Response.Cookies["TokenID"].Value = TOKENID;
                        target = RedirectToAction("Main", "Access");
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
                            if (tokeninfo.TokenInfo.access_token != "")
                            {
                                getlogininfo(tokeninfo);
                                target = RedirectToAction("Main", "Access");
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
        }
        public void getlogininfo(CRM_LoginInfo tokeninfo)
        {
            //Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
            //Session["token"] = tokeninfo.TokenInfo.access_token;
            //Session["STAFFID"] = tokeninfo.TokenInfo.STAFFID;
            //Session["NAME"] = crmModels.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token).STAFFNAME;
            //Response.Cookies["token"].Value = tokeninfo.TokenInfo.access_token;
            //Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
            AppClass.SetSession("ErrorMessage", null);
            AppClass.SetSession("token", tokeninfo.TokenInfo.access_token);
            AppClass.SetSession("STAFFID", tokeninfo.TokenInfo.STAFFID);
            CRM_HG_STAFF rst_CRM_HG_STAFF = models.HG_STAFF.ReadBySTAFFID(tokeninfo.TokenInfo.STAFFID, tokeninfo.TokenInfo.access_token);
            Session["ID"] = rst_CRM_HG_STAFF.STAFFUSER;
            Session["NAME"] = rst_CRM_HG_STAFF.STAFFNAME;
            TokenINFO model_TokenINFO = new TokenINFO();
            model_TokenINFO.STAFFID = tokeninfo.TokenInfo.STAFFID;
            model_TokenINFO.Token = tokeninfo.TokenInfo.access_token;
            model_TokenINFO.STAFFNAME = rst_CRM_HG_STAFF.STAFFNAME;
            Response.Cookies["tokeninfo"].Value = HttpUtility.UrlEncode(Newtonsoft.Json.JsonConvert.SerializeObject(model_TokenINFO));
            Response.Cookies["tokeninfo"].Expires = DateTime.Now.AddDays(2);



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
        public ActionResult Verify(string name, string password)
        {
            TokenInfo tokeninfo = models.CRM_Login.Login(name, password, "", "", 0, 0).TokenInfo;
            Response.Cookies["userName"].Value = name;
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(10);
            if (tokeninfo.access_token == null)
            {
                AppClass.SetSession("ErrorMessage", "用户名或密码错误");
                Response.Cookies["password"].Value = "";
                Response.Cookies["password"].Expires = DateTime.Now.AddDays(10);
            }
            else
            {
                AppClass.SetSession("ErrorMessage", null);
                AppClass.SetSession("token", tokeninfo.access_token);
                AppClass.SetSession("STAFFID", tokeninfo.STAFFID);
                CRM_HG_STAFF rst_CRM_HG_STAFF = models.HG_STAFF.ReadBySTAFFID(tokeninfo.STAFFID, tokeninfo.access_token);
                Session["ID"] = rst_CRM_HG_STAFF.STAFFUSER;
                Session["NAME"] = rst_CRM_HG_STAFF.STAFFNAME;
                Response.Cookies["password"].Value = password;
                Response.Cookies["password"].Expires = DateTime.Now.AddDays(10);
                TokenINFO model_TokenINFO = new TokenINFO();
                model_TokenINFO.STAFFID = tokeninfo.STAFFID;
                model_TokenINFO.Token = tokeninfo.access_token;
                model_TokenINFO.STAFFNAME = rst_CRM_HG_STAFF.STAFFNAME;
                Response.Cookies["tokeninfo"].Value = HttpUtility.UrlEncode(Newtonsoft.Json.JsonConvert.SerializeObject(model_TokenINFO));
                Response.Cookies["tokeninfo"].Expires = DateTime.Now.AddDays(2);
            }
            ActionResult target;
            if (tokeninfo.access_token == null)
            {
                target = RedirectToAction("SignIn", "Access");
            }
            else
            {
                target = RedirectToAction("Main", "Access");
            }
            return target;
        }
    }
}
