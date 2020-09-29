using Sonluk.UI.Model.CRM.PRODUCT_KBService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
   public class  PRODUCT_KB
    {
        private PRODUCT_KBSoapClient client = new PRODUCT_KBSoapClient("PRODUCT_KBSoap", AppConfig.Settings("RemoteAddress") + "CRM/PRODUCT_KB.asmx");

        public int Create(CRM_PRODUCT_KB model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_PRODUCT_KB model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_PRODUCT_KB[] ReadByParam(CRM_PRODUCT_KB model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int KBID, string ptoken)
        {
            return client.Delete(KBID, ptoken);
        }
    }
}
