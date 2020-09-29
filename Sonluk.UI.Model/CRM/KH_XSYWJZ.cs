using Sonluk.UI.Model.CRM.KH_XSYWJZService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_XSYWJZ
    {
        private KH_XSYWJZSoapClient client = new KH_XSYWJZSoapClient("KH_XSYWJZSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_XSYWJZ.asmx");


        public int Create(CRM_KH_XSYWJZ model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_KH_XSYWJZ model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int Delete(int XSYWJZID, string ptoken)
        {
            return client.Delete(XSYWJZID, ptoken);
        }
        public CRM_KH_XSYWJZList[] ReadByKHID(int KHID, string ptoken)
        {
            return client.ReadByKHID(KHID, ptoken);
        }
        public CRM_KH_XSYWJZ ReadByID(int XSYWJZID, string ptoken)
        {
            return client.ReadByID(XSYWJZID, ptoken);
        }

    }
}
