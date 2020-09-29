using Sonluk.UI.Model.CRM.PRODUCT_PRODUCT_HHService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
   public class PRODUCT_PRODUCT_HH
    {
        private PRODUCT_PRODUCT_HHSoapClient client = new PRODUCT_PRODUCT_HHSoapClient("PRODUCT_PRODUCT_HHSoap", AppConfig.Settings("RemoteAddress") + "CRM/PRODUCT_PRODUCT_HH.asmx");

        public int Create(CRM_PRODUCT_PRODUCT_HH model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_PRODUCT_PRODUCT_HH model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_PRODUCT_PRODUCT_HH[] ReadByParam(CRM_PRODUCT_PRODUCT_HH model,  string ptoken)
        {
            return client.ReadByParam(model,  ptoken);
        }
        public CRM_PRODUCT_PRODUCT_HH[] ReadByProNum(CRM_PRODUCT_PRODUCT_HH model, string ptoken)
        {
            return client.ReadByProNum(model, ptoken);
        }
        public int Delete(int HHID, string ptoken)
        {
            return client.Delete(HHID, ptoken);
        }
    }
}
