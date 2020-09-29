using Sonluk.UI.Model.CRM.PRODUCT_PRODUCTGROUPService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class PRODUCT_PRODUCTGROUP
    {
        private PRODUCT_PRODUCTGROUPSoapClient client = new PRODUCT_PRODUCTGROUPSoapClient("PRODUCT_PRODUCTGROUPSoap", AppConfig.Settings("RemoteAddress") + "CRM/PRODUCT_PRODUCTGROUP.asmx");



        public int Create(int PRODUCTID, int GROUPID, string ptoken)
        {
            return client.Create(PRODUCTID, GROUPID, ptoken);
        }
        public int Delete(int PRODUCTID, int GROUPID, string ptoken)
        {
            return client.Delete(PRODUCTID, GROUPID, ptoken);
        }
        public CRM_PRODUCT_PRODUCTGROUP[] Read(CRM_PRODUCT_PRODUCTGROUP model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
    }
}
