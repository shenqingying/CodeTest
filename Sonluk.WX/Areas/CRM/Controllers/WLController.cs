using Newtonsoft.Json;
using Sonluk.UI.Model.CRM.CRM_LoginService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.WL_TTService;
using Sonluk.WX.APPCLASS;
using Sonluk.WX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class WLController : Controller
    {
        //
        // GET: /CRM/WL/

        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        string token = "";

        public ActionResult FollowWL() 
        {
            return View();
        }

        public ActionResult WLIndex()
        {
            Session["state"] = "WX";
            string name = "wl";
            string password = "wl123456";
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

                Response.Cookies["userName"].Value = name + "_" + password;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(10);
            }
            return View();
        }
        public ActionResult Sgion()
        {
            
           
            string url = System.Configuration.ConfigurationManager.AppSettings["Sgion_url"];
            
            
                string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];
                string redirect_uri = HttpUtility.UrlEncode(url);

                //string scope = "snsapi_base";           //不弹出授权页面，直接跳转，只能获取用户openid
                string scope = "snsapi_userinfo";      //弹出授权页面，可通过openid拿到昵称、性别、所在地

                string code = "https://open.weixin.qq.com/connect/oauth2/authorize?appid="
                    + appid + "&redirect_uri=" + redirect_uri + "&response_type=code&scope=" + scope + "&state=WX#wechat_redirect";

                Response.Redirect(code);
                return View();
            
        }

        [HttpPost]
        public int Insert_Wl(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_WL_TT model = JsonConvert.DeserializeObject<CRM_WL_TT>(data);
            model.ISACTIVE = 1;
            int i = crmModels.WL_TT.Create(model, token);
            return i;
        }
        [HttpPost]
        public string Select_Wl(int id)   
        {
            token = appClass.CRM_Gettoken();
            CRM_WL_TT model = new CRM_WL_TT();
            model.TTID = id;
            CRM_WL_TT[] data = crmModels.WL_TT.ReadByParam(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }
        

    }
}
