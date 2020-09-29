using Sonluk.UI.Model.CRM.KH_KHZZService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_KHZZ
    {
        private KH_KHZZSoapClient client = new KH_KHZZSoapClient("KH_KHZZSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_KHZZ.asmx");

        public int Create(CRM_KH_KHZZ model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_KH_KHZZ model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int Delete(int ZZID, string ptoken)
        {
            return client.Delete(ZZID, ptoken);
        }
        public int DeleteByKHID(int KHID, string ptoken)
        {
            return client.DeleteByKHID(KHID, ptoken);
        }
        public CRM_KH_KHZZList[] ReadByKHID(int KHID, string ptoken)
        {
            return client.ReadByKHID(KHID, ptoken);
        }
        public CRM_KH_KHZZ[] ReadByParam(CRM_KH_KHZZ model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_KH_KHZZ ReadByID(int ZZID, string ptoken)
        {
            return client.ReadByID(ZZID, ptoken);
        }


    }
}
