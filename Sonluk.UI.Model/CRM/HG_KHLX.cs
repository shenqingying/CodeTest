using Sonluk.UI.Model.CRM.HG_KHLXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_KHLX
    {
        private HG_KHLXSoapClient client = new HG_KHLXSoapClient("HG_KHLXSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_KHLX.asmx");

        public int Create(int STAFFKHLXID, int DICID,string ptoken)
        {
            return client.Create(STAFFKHLXID,DICID, ptoken);
        }

        public CRM_HG_KHLXList[] Read(int STAFFKHLXID, int DICID, string ptoken)
        {
            return client.Read(STAFFKHLXID, DICID, ptoken);
        }

        public int Delete(int STAFFKHLXID, int DICID, string ptoken)
        {
            return client.Delete(STAFFKHLXID, DICID, ptoken);
        }


    }
}
