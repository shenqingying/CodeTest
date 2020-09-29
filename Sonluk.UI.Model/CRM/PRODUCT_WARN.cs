using Sonluk.UI.Model.CRM.PRODUCT_WARNService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class PRODUCT_WARN
    {
        private PRODUCT_WARNSoapClient client = new PRODUCT_WARNSoapClient("PRODUCT_WARNSoap", AppConfig.Settings("RemoteAddress") + "CRM/PRODUCT_WARN.asmx");

        public int Create(CRM_PRODUCT_WARN model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_PRODUCT_WARN model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int Delete(int PROWARNID, string ptoken)
        {
            return client.Delete(PROWARNID, ptoken);
        }
        public CRM_PRODUCT_WARN ReadByID(int PROWARNID, string ptoken)
        {
            return client.ReadByID(PROWARNID, ptoken);
        }
        public CRM_PRODUCT_WARN[] ReadByParam(CRM_PRODUCT_WARN model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_PRODUCT_WARN[] ReadByKHIDandPRODUCTID(int KHID, int PRODUCTID, string ptoken)
        {
            return client.ReadByKHIDandPRODUCTID(KHID, PRODUCTID, ptoken);
        }


    }
}
