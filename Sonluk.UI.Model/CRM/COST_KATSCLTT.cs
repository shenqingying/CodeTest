using Sonluk.UI.Model.CRM.COST_KATSCLTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KATSCLTT
    {
        private COST_KATSCLTTSoapClient client = new COST_KATSCLTTSoapClient("COST_KATSCLTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KATSCLTT.asmx");

        public int Create(CRM_COST_KATSCLTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KATSCLTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int UpdateCost(int KATSCLTTID, string ptoken)
        {
            return client.UpdateCost(KATSCLTTID, ptoken);
        }
        public CRM_COST_KATSCLTT[] ReadByParam(CRM_COST_KATSCLTT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int KATSCLTTID, string ptoken)
        {
            return client.Delete(KATSCLTTID, ptoken);
        }





    }
}
