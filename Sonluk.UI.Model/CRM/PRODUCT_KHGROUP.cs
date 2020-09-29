using Sonluk.UI.Model.CRM.PRODUCT_KHGROUPService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class PRODUCT_KHGROUP
    {
        private PRODUCT_KHGROUPSoapClient client = new PRODUCT_KHGROUPSoapClient("PRODUCT_KHGROUPSoap", AppConfig.Settings("RemoteAddress") + "CRM/PRODUCT_KHGROUP.asmx");


        public int Create(int KHID, int GROUPID, string ptoken)
        {
            return client.Create(KHID, GROUPID, ptoken);
        }
        public int Delete(int KHID, int GROUPID, string ptoken)
        {
            return client.Delete(KHID, GROUPID, ptoken);
        }
        public CRM_PRODUCT_KHGROUP[] Read(CRM_PRODUCT_KHGROUP model, string ptoken)
        {
            return client.Read(model, ptoken);
        }


    }
}
