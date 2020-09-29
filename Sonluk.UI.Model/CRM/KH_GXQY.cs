
using Sonluk.UI.Model.CRM.KH_GXQYService;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_GXQY
    {
        private KH_GXQYSoapClient client = new KH_GXQYSoapClient("KH_GXQYSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_GXQY.asmx");

        public int Create(CRM_KH_GXQY model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_KH_GXQY model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_KH_GXQYList[] Read(int KHID, string ptoken)
        {
            return client.Read(KHID, ptoken);
        }
        public int Delete(int GXQYID, string ptoken)
        {
            return client.Delete(GXQYID, ptoken);
        }

        public int DeleteByKHID(int KHID, string ptoken)
        {

            return client.DeleteByKHID(KHID,ptoken);


        }
    }
}
