using Sonluk.UI.Model.CRM.COST_LKAFYTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAFYTT
    {
        private COST_LKAFYTTSoapClient client = new COST_LKAFYTTSoapClient("COST_LKAFYTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAFYTT.asmx");

        public int Create(CRM_COST_LKAFYTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAFYTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAFYTT[] ReadByParam(CRM_COST_LKAFYTT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int GGGSID, string ptoken)
        {
            return client.Delete(GGGSID, ptoken);
        }
         public int UpdateCost(int LKAFYTTID, string ptoken)
        {
            return client.UpdateCost(LKAFYTTID, ptoken);
        }




    }
}
