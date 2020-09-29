using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Sonluk.WX.Models
{
    public class WebRes
    {
        public string GetJson(string url)
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
    }
}