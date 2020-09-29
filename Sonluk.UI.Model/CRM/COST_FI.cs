using Sonluk.UI.Model.CRM.COST_FIService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_FI
    {
        private COST_FISoapClient client = new COST_FISoapClient("COST_FISoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_FI.asmx");

        public int Create(CRM_COST_FI model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_FI model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_FI[] ReadByParam(CRM_COST_FI model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int CWHSBH, string ptoken)
        {
            return client.Delete(CWHSBH, ptoken);
        }


    }
}
