using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Sonluk.UI.Model.SSO.UserTokenService;
using System.Net;
namespace Sonluk.PC.Controllers
{
    public class AccessController : Controller
    {
        //
        // GET: /Access/
        AccountModels models = new AccountModels();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            //string URL = ConfigurationManager.AppSettings["webAPIAddress"] + "SS0/User/Menu";
            //string body = "ptoken=" + Session["Token"].ToString() + "&parent=41";
            //URL = URL + "?" + body;
            //string Menu = GET_Return(URL);
            //MobileMenuInfo menuinfo = JsonConvert.DeserializeObject<MobileMenuInfo>(Menu);
            //List<MobileMenuInfo> menuchild = menuinfo.Children;
            //ViewData.Model = menuchild;
            //Session["MENUINFO"] = menuchild;
            //return View();
            MenuInfo menuinfo = models.UserToken.Menu(Session["Token"].ToString(), "41");
            MenuInfo[] menuchild = menuinfo.Children;
            Session["TITLENAME"] = "主页";
            Session["MENUINFO"] = menuchild;
            return View();
        }


        public ActionResult SignIn()
        {
            ActionResult target = View();
            ViewBag.UserVersion = ConfigurationManager.AppSettings["UserVersion"];
            ViewBag.Message = "";
            return target;
        }

        public ActionResult Verify(string name, string password)
        {
            //string URL = ConfigurationManager.AppSettings["webAPIAddress"] + "SS0/User/Token";
            //string body = "name=" + name + "&password=" + password;
            //URL = URL + "?" + body;
            //string G_Token = GET_Return(URL);
            //URL = "";

            //MobileTokenInfo tokeninfo = new MobileTokenInfo();
            //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(G_Token)))
            //{
            //    DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(MobileTokenInfo));
            //    tokeninfo = (MobileTokenInfo)deseralizer.ReadObject(ms);
            //}
            TokenInfo tokeninfo = models.UserToken.Token(name, password);

            if (tokeninfo.access_token == null)
            {
                Session["ErrorMessage"] = "用户名或密码错误";
                Session["MYPW"] = null;
            }
            else
            {
                Session["ErrorMessage"] = null;
                Session["Token"] = tokeninfo.access_token;
                //URL = ConfigurationManager.AppSettings["webAPIAddress"] + "SS0/User/AcceptToken";
                //body = "ptoken=" + Session["Token"].ToString();
                //URL = URL + "?" + body;
                //string satff = GET_Return(URL);
                //AccountInfo staffinfo = JsonConvert.DeserializeObject<AccountInfo>(satff);
                //Session["ID"] = staffinfo.ID;
                //Session["NAME"] = staffinfo.Name;
                AccountInfo staffinfo = models.UserToken.AcceptToken(tokeninfo.access_token);
                Session["ID"] = staffinfo.ID;
                Session["NAME"] = staffinfo.Name;


                Response.Cookies["userName"].Value = name + "_" + password;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(10);
                Session["MYPW"] = null;
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

        //public string GET_Return(string URL)
        //{
        //    string INFO = "";
        //    Encoding encoding = Encoding.UTF8;
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        //    request.Method = "GET";
        //    request.Accept = "text/html, application/xhtml+xml, */*";
        //    request.ContentType = "application/json";
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
        //    {
        //        INFO = reader.ReadToEnd();
        //    }
        //    return INFO;
        //}





    }
}
