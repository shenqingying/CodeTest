using Sonluk.UI.Model.CRM.COST_LKAFYMXDTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAFYMXDT
    {
        private COST_LKAFYMXDTSoapClient client = new COST_LKAFYMXDTSoapClient("COST_LKAFYMXDTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAFYMXDT.asmx");

        public int Create(CRM_COST_LKAFYMXDT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAFYMXDT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAFYMXDT[] ReadByParam(CRM_COST_LKAFYMXDT model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int GGGSID, string ptoken)
        {
            return client.Delete(GGGSID, ptoken);
        }
        public CRM_COST_LKAFYMXDT[] Read_Unconnected(CRM_COST_LKAFYMXDT model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }




    }
}
