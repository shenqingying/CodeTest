using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.UI.Model.CRM.KH_KHQTXXService;
using Sonluk.Utility;
namespace Sonluk.UI.Model.CRM
{
    public class KH_KHQTXX
    {
        private KH_KHQTXXSoapClient client = new KH_KHQTXXSoapClient("KH_KHQTXXSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_KHQTXX.asmx");
        

        public int Create(CRM_KH_KHQTXX model,string ptoken)
        {
            return client.Create(model,ptoken);
        }

        public int Update(CRM_KH_KHQTXX model, string ptoken)
        {
            return client.Update(model,ptoken);
        }

        public int Delete(int XXID, string ptoken)
        {
            return client.Delete(XXID,ptoken);
        }

        public CRM_KH_KHQTXXList[] Read(int KHID, int XXLB, string ptoken)
        {
            return client.Read(KHID, XXLB,ptoken);
        }
        public int DeleteByKHID_XXLB(int KHID, int XXLB, string ptoken)
        {

            return client.DeleteByKHID_XXLB(KHID, XXLB,ptoken);
          

        }
    }
}
