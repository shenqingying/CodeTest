using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.KH_LXRService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_LXR
    {
        private KH_LXRSoapClient client = new KH_LXRSoapClient("KH_LXRSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_LXR.asmx");


        public int Create(CRM_KH_LXR model, string ptoken)
        {
            return client.Create(model, ptoken);
        }

        public int Update(CRM_KH_LXR model, string ptoken)
        {
            return client.Update(model, ptoken);
        }

        public int Delete(int KHLXRID, string ptoken)
        {
            return client.Delete(KHLXRID, ptoken);
        }

        public CRM_KH_LXRList[] Read(int KHID, int LB, string ptoken)
        {
            return client.Read(KHID, LB, ptoken);
        }

        public int DeleteByKHID(int KHID, string ptoken)
        {

            return client.DeleteByKHID(KHID, ptoken);


        }
    }
}
