using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.IO;
using System.Text;
using System.Web.Security;

namespace Sonluk.Mobile.Areas.CRM.Controllers
{
    public class WXController : Controller
    {
        //
        // GET: /CRM/WX/

        public ActionResult Index()
        {
            return View();
        }

        public void WXprove()
        {
            string Token = "token";
            if (string.IsNullOrEmpty(Token))
            {
                return;
            }
            string signature = System.Web.HttpContext.Current.Request.QueryString["signature"];
            string timestamp = System.Web.HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = System.Web.HttpContext.Current.Request.QueryString["nonce"];
            string echoString = System.Web.HttpContext.Current.Request.QueryString["echostr"];
            


            if (!string.IsNullOrEmpty(echoString))
            {
                System.Web.HttpContext.Current.Response.Write(echoString);
                System.Web.HttpContext.Current.Response.End();
            }
        }



    }
}
