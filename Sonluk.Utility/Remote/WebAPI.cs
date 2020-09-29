using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Sonluk.Utility.Remote
{
    public class WebAPI
    {
        public static string Request(string url,string param)
        {
            //string strURL = url + '?' + param;
            string strURL = url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "GET";
            request.Timeout = 100;
            // 添加header
            //request.Headers.Add("apikey", "628a673ebf7b8033e778407ba2e140b7");
            string StrDate = "";
            string strValue = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream(); ;
                
                StreamReader Reader = new StreamReader(s, Encoding.UTF8);
                while ((StrDate = Reader.ReadLine()) != null)
                {
                    strValue += StrDate + "\r\n";
                }
            }
            catch (Exception e) {
                strValue = "";
            }
            
            return strValue;
        }

        public static string Request(string url, string method, string param)
        {
            string strURL = url + '?' + param;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            request.Method = method;

            // 添加header
            //request.Headers.Add("apikey", "您自己的apikey");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = response.GetResponseStream(); ;
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }

        public static string Request(string url, string contentType,string method, string param)
        {
            string strURL = url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            request.ContentType = contentType;
            request.Method = method;

            // 添加header
            //request.Headers.Add("apikey", "您自己的apikey");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = response.GetResponseStream(); ;
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }
    }
}
