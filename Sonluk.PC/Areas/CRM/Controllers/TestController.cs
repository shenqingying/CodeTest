using Newtonsoft.Json.Linq;
using Sonluk.API.SDK.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /CRM/Test/
        string API_Key = "LOMGGPqVo2btGgrTqm3458Qd";
        string Secret_Key = "OfW72ZblcVizq9jeBuFkj61piGzZUCAe";
        string token = "24.05f91d09babd502e1bea7fa9d00c9ddf.2592000.1575536080.282335-17698512";
        SHttp sHttp = new SHttp();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IDCard()
        {
            getAccessToken();
            //string token = "[调用鉴权接口获取的token]";
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/idcard?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            // 图片的base64编码
            string base64 = getFileBase64("C:\\Users\\cf\\Desktop\\123.jpg");
            String str = "id_card_side=" + "front" + "&image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            Console.WriteLine("身份证识别:");
            Console.WriteLine(result);

            string result2 = PostFunction(str, host);

            return View();
        }

        public string getAccessToken()
        {
            string authHost = "https://aip.baidubce.com/oauth/2.0/token";
            HttpClient client = new HttpClient();
            List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
            paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            paraList.Add(new KeyValuePair<string, string>("client_id", API_Key));
            paraList.Add(new KeyValuePair<string, string>("client_secret", Secret_Key));

            HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result);
            return result;
        }

        public static String getFileBase64(String fileName)
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open);
            byte[] arr = new byte[filestream.Length];
            filestream.Read(arr, 0, (int)filestream.Length);
            string baser64 = Convert.ToBase64String(arr);
            filestream.Close();
            return baser64;
        }

        public string PostFunction(string ModelStr, string URL)
        {

            string serviceAddress = URL;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";                          //otKEk1FYKxWN_RQEmMhwNBbnOpKQ
            string strContent = ModelStr;
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
        public string READ_DW_JHZ(string data)
        {
            string model = sHttp.SApiPost("WMS", "MES/SY/READ_DW_JHZ", data);
            return model;
        }


    }
}
