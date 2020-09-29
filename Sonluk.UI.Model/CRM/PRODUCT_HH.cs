using Sonluk.UI.Model.CRM.PRODUCT_HHService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
  public  class PRODUCT_HH
    {
        private PRODUCT_HHSoapClient client = new PRODUCT_HHSoapClient("PRODUCT_HHSoap", AppConfig.Settings("RemoteAddress") + "CRM/PRODUCT_HH.asmx");

        public int Create(CRM_PRODUCT_HH model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_PRODUCT_HH model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_PRODUCT_HH[] ReadByParam(CRM_PRODUCT_HH model,int STAFFID, string ptoken)
        {
            return client.ReadByParam(model,STAFFID, ptoken);
        }
        public int Delete(CRM_PRODUCT_HH model, string ptoken)
        {
            return client.Delete(model, ptoken);
        }
    }
}
