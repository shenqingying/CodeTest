using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.Account.AccessService;
using System.Configuration;
using Sonluk.Models;
using System.Text.RegularExpressions;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.CRM.CRM_LoginService;
using Sonluk.UI.Model.SSO.TOKEN_TOKENIDINFOService;
using Newtonsoft.Json;
using Sonluk.API.SDK.Http;

namespace Sonluk.Controllers
{

    public class AccessController : Controller
    {
        AccountModels models = new AccountModels();
        PUBLICModels publicmodels = new PUBLICModels();
        SSOModels ssomodels = new SSOModels();
        CRMModels crmModels = new CRMModels();
        //
        // GET: /Access/x
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Access/
        public ActionResult SignIn()
        {
            #region  非SSO代码
            //ActionResult target = View();
            //ViewBag.UserVersion = ConfigurationManager.AppSettings["UserVersion"];
            //ViewBag.Message = "";
            //return target;
            #endregion
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

                    CRM_LoginInfo tokeninfo = crmModels.CRM_Login.Login_SSO_TOKEN(TOKENID, 1, 0);
                    if (tokeninfo.TokenInfo.access_token != "")
                    {
                        Session["crmtoken"] = tokeninfo.TokenInfo.access_token;
                        SSO_TOKEN_USERNAMEDY usernamedymodel = new SSO_TOKEN_USERNAMEDY();
                        usernamedymodel.ZHLB = 2;
                        usernamedymodel.STAFFID = tokeninfo.TokenInfo.STAFFID;
                        SSO_TOKEN_USERNAMEDY_SELECT usernamedyres = ssomodels.TOKEN_TOKENIDINFO.USERNAMEDY_SELECT(usernamedymodel, tokeninfo.TokenInfo.access_token);
                        if (usernamedyres.MES_RETURN.TYPE == "S")
                        {
                            if (usernamedyres.SSO_TOKEN_USERNAMEDY.Length > 0)
                            {
                                Response.Cookies["TokenID"].Value = TOKENID;
                                //SSOLoginLogci(usernamedyres.SSO_TOKEN_USERNAMEDY[0].ZHUSERNAME);
                                return SSOLoginLogci(usernamedyres.SSO_TOKEN_USERNAMEDY[0].ZHUSERNAME);
                            }
                            else
                            {
                                url = url + "&LOGINTYPE=2";
                                return Redirect(SSOURL + "?URL=" + url);
                            }
                        }
                        else
                        {
                            url = url + "&LOGINTYPE=2";
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

                            CRM_LoginInfo tokeninfo = crmModels.CRM_Login.Login_SSO_TOKEN(Request.Cookies["TokenID"].Value, 1, 0);
                            if (tokeninfo.TokenInfo.access_token != "")
                            {
                                Session["crmtoken"] = tokeninfo.TokenInfo.access_token;
                                SSO_TOKEN_USERNAMEDY usernamedymodel = new SSO_TOKEN_USERNAMEDY();
                                usernamedymodel.ZHLB = 2;
                                usernamedymodel.STAFFID = tokeninfo.TokenInfo.STAFFID;
                                SSO_TOKEN_USERNAMEDY_SELECT usernamedyres = ssomodels.TOKEN_TOKENIDINFO.USERNAMEDY_SELECT(usernamedymodel, tokeninfo.TokenInfo.access_token);
                                if (usernamedyres.MES_RETURN.TYPE == "S")
                                {
                                    if (usernamedyres.SSO_TOKEN_USERNAMEDY.Length > 0)
                                    {
                                        Response.Cookies["TokenID"].Value = TOKENID;
                                        return SSOLoginLogci(usernamedyres.SSO_TOKEN_USERNAMEDY[0].ZHUSERNAME);

                                    }
                                    else
                                    {
                                        url = url + "&LOGINTYPE=2";
                                        return Redirect(SSOURL + "?URL=" + url);
                                    }
                                }
                                else
                                {
                                    url = url + "&LOGINTYPE=2";
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
                            return Redirect(SSOURL + "?URL=" + url);
                        }
                    }
                }
            }
            //return target;
        }
        public ActionResult SSOLoginLogci(string name)
        {
            string url = SHttp.UrlQueryAdd(Request.Url.ToString(), new Dictionary<string, string>() { { "subFolder", Url.Action("SSOLoginLogci", "Access", new { area = "" }).Replace("/Access/SSOLoginLogci", "") } });
            AccountInfo account = models.Access.SignInSS0(name.ToUpper(), "", url);

            //List<Sonluk.UI.Model.SSO.UserTokenService.MenuInfo> menulist = new List<UI.Model.SSO.UserTokenService.MenuInfo>();

            //string url = Request.Url.ToString();
            //string xiugaiurl = "";
            //if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1)
            //{
            //    xiugaiurl = ConfigurationManager.AppSettings["SSOURLDROPOUTIN"];
            //}
            //else
            //{
            //    xiugaiurl = ConfigurationManager.AppSettings["SSOURLDROPOUTOUT"];
            //}
            //for (int i = 0; i < menuArr.Length; i++)
            //{
            //    if (menuArr[i].Node.Equals("修改密码"))
            //    {
            //        menuArr[i].Uri = xiugaiurl;
            //    }
            //    menulist.Add(menuArr[i]);
            //}
            //JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            //jsonSetting.NullValueHandling = NullValueHandling.Ignore;
            //account.Menu = JsonConvert.SerializeObject(menulist, jsonSetting);


            Session["Account"] = account;
            Session["Authorization"] = account.Authorization;
            Session["ErrorMessage"] = account.Message;
            Session["ErrorMessageDetails"] = account.MessageDetails;
            HttpCookie cookie = new HttpCookie("AccountName");
            cookie.Value = name;
            cookie.Path = "/";
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(cookie);

            ActionResult target;
            string index = "";
            if (account.Route.Auth == null || account.Route.Auth.Equals(""))
            {
                index = Url.Action(account.Route.Action, account.Route.Controller, new { area = account.Route.Area });
                target = RedirectToAction(account.Route.Action, account.Route.Controller, new { area = account.Route.Area });
            }
            else
            {
                index = Url.Action(account.Route.Action, account.Route.Controller, new { area = account.Route.Area, Auth = account.Route.Auth });
                target = RedirectToAction(account.Route.Action, account.Route.Controller, new { area = account.Route.Area, Auth = account.Route.Auth });
            }


            HttpCookie indexCookie = new HttpCookie("navBar");
            indexCookie.Value = Regex.Replace(index, @"[^a-zA-Z0-9]*", "");
            indexCookie.Path = "/";
            Response.Cookies.Add(indexCookie);

            return target;
        }
        //
        // GET: /Access/SignOut
        public ActionResult SignOut()
        {
            #region 非SSO代码
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("SignIn");
            #endregion
            //Session.Clear();
            //Session.Abandon();
            //ActionResult target;
            //target = RedirectToAction("SignIn", "Public",);
            //string url = Request.Url.ToString();
            //string SSOURL = "";
            //if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1)
            //{
            //    SSOURL = ConfigurationManager.AppSettings["SSOURLIN"];
            //}
            //else
            //{
            //    SSOURL = ConfigurationManager.AppSettings["SSOURLOUT"];
            //}
            //url = publicmodels.PUBLICFUN.get_my_jm(url);
            //Response.Cookies["TokenID"].Value = null;
            //url = url + "&LOGINTYPE=1";
            //return Redirect(SSOURL + "?URL=" + url);
        }


        //
        // POST: /Access/Verify
        [HttpPost]
        public ActionResult Verify(string name, string password)
        {
            AccountInfo account = models.Access.SignIn(name.ToUpper(), password);

            Session["Account"] = account;
            Session["Authorization"] = account.Authorization;
            Session["ErrorMessage"] = account.Message;
            Session["ErrorMessageDetails"] = account.MessageDetails;
            HttpCookie cookie = new HttpCookie("AccountName");
            cookie.Value = name;
            cookie.Path = "/";
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(cookie);

            ActionResult target;
            string index = "";
            if (account.Route.Auth == null || account.Route.Auth.Equals(""))
            {
                index = Url.Action(account.Route.Action, account.Route.Controller, new { area = account.Route.Area });
                target = RedirectToAction(account.Route.Action, account.Route.Controller, new { area = account.Route.Area });
            }
            else
            {
                index = Url.Action(account.Route.Action, account.Route.Controller, new { area = account.Route.Area, Auth = account.Route.Auth });
                target = RedirectToAction(account.Route.Action, account.Route.Controller, new { area = account.Route.Area, Auth = account.Route.Auth });
            }


            HttpCookie indexCookie = new HttpCookie("navBar");
            indexCookie.Value = Regex.Replace(index, @"[^a-zA-Z0-9]*", "");
            indexCookie.Path = "/";
            Response.Cookies.Add(indexCookie);

            return target;
        }


        //
        // GET: /Access/UpdatePassword
        [HttpGet]
        public ActionResult UpdatePassword()
        {
            #region 非SSO代码
            //return View();
            #endregion
            string url = Request.Url.ToString();
            string UPDATEPWDRUL = "";
            if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1)
            {
                UPDATEPWDRUL = ConfigurationManager.AppSettings["SSOURLDROPOUTIN"];
            }
            else
            {
                UPDATEPWDRUL = ConfigurationManager.AppSettings["SSOURLDROPOUTOUT"];
            }

            return Redirect(UPDATEPWDRUL + "?URL=" + url);
        }

        //
        // POST: /Access/UpdatePassword
        [HttpPost]
        public ActionResult UpdatePassword(string password, string newPassword)
        {
            AccountInfo account = (AccountInfo)Session["Account"];
            if (!models.Access.ChangePassword(account.ID, password, newPassword))
                Session["UpdatePasswordError"] = "当前密码错误";
            return View();
        }

        //
        // GET: /Access/Error
        public ActionResult Error()
        {
            return View();
        }

    }
}
