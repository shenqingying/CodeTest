using Sonluk.API.SDK.Http;
using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Sonluk.PC.Areas.WMS.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class SessionlessController : Controller
    {
        //通用请求（无需Session）
        [HttpPost]
        public string SApiPost(string url, string data, string query = null)
        {
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            if (query != null && query != "undefined") queryParams = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(query);
            queryParams.Add("ptoken", Request.Cookies.Get("token").Value);
            return new SHttp().ApiPost("WMS", url, data, queryParams);
        }
        [HttpPost]
        public string SApiGet(string url, string query = null)
        {
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            if (query != null && query != "undefined") queryParams = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(query);
            queryParams.Add("ptoken", Request.Cookies.Get("token").Value);
            return new SHttp().ApiGet("WMS", url, queryParams);
        }
        public ActionResult BarCode(string code, string format, string width, string height, string pure)
        {
            byte[] objcode = new MESModels().BarCode.CreateBarCode(code, format, Convert.ToInt32(width), Convert.ToInt32(height), Convert.ToInt32(pure));
            Response.ContentType = "image/jpg";
            Response.Clear();
            Response.BufferOutput = true;
            Response.BinaryWrite(objcode);
            Response.Flush();
            return View();
        }
    }
}
