using Sonluk.UI.Model.EM.EM_MISSIONService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class EM_MISSION
    {
        //private FILE_PATHSoapClient client = new FILE_PATHSoapClient("FILE_PATHSoap", AppConfig.Settings("RemoteAddress") + "EM/FILE_PATH.asmx");
        private EM_MISSIONSoapClient client = new EM_MISSIONSoapClient("EM_MISSIONSoap", AppConfig.Settings("RemoteAddress") + "EM/EM_MISSION.asmx");
        public ZSD_XBZ_CHANGEINFORESULT ZSD_XBZ_CHANGEINFO_Read(string MISSION, string token)
        {

            return client.ZSD_XBZ_CHANGEINFO_Read(MISSION,token);
          

        }
       
        public ZSD_XBZ_MAINRESULT ZSD_XBZ_MAIN_Read(ZSD_XBZ_MAINRESULT importList, string token)
        {

            return client.ZSD_XBZ_MAIN_Read(importList,token);
           
        }
       
        public ZSD_XBZ_MAINRESULT ZSD_XBZ_MAIN_UPDATE(ZSD_XBZ_MAINRESULT importList, string token)
        {

            return client.ZSD_XBZ_MAIN_UPDATE(importList,token);
           

        }
    }
}
