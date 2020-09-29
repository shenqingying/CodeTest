using Sonluk.UI.Model.CRM.PRODUCT_KBMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class PRODUCT_KBMX
    {
        private PRODUCT_KBMXSoapClient client = new PRODUCT_KBMXSoapClient("PRODUCT_KBMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/PRODUCT_KBMX.asmx");

        public int Create(CRM_PRODUCT_KBMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_PRODUCT_KBMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_PRODUCT_KBMX[] ReadByParam(CRM_PRODUCT_KBMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int DeleteByKBID(int KBID, string ptoken)
        {
            return client.DeleteByKBID(KBID, ptoken);
        }
        public int Delete(int KBMXID, string ptoken)
        {
            return client.Delete(KBMXID, ptoken);
        }
    }
}
