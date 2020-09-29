using MSXML2;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.Setting
{
    public  class Config
    {
        public static string GetRemoteAdress()
        {
            if (AppConfig.Settings("RemoteAddress_Spare") == null)
            {
                return AppConfig.Settings("RemoteAddress");
            }            
            XMLHTTP http = new XMLHTTP();
            http.open("GET", AppConfig.Settings("RemoteAddress"), false, null, null);
            http.send(null);
            int status = http.status;
            if (status == 200)
            {
                return AppConfig.Settings("RemoteAddress");
            }
            else
            {
                return AppConfig.Settings("RemoteAddress_Spare");
            }


           
        }

    }
}
