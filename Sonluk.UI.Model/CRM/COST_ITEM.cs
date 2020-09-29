using Sonluk.UI.Model.CRM.COST_ITEMService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_ITEM
    {
        private COST_ITEMSoapClient client = new COST_ITEMSoapClient("COST_ITEMSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_ITEM.asmx");

        public int Create(CRM_COST_ITEM model, string ptoken)
        {
            return client.Create(model,ptoken);
        }
        public int Update(CRM_COST_ITEM model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_ITEM[] ReadByParam(CRM_COST_ITEM model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int COSTITEMID, string ptoken)
        {
            return client.Delete(COSTITEMID, ptoken);
        }



    }
}
