using Sonluk.UI.Model.CRM.COST_LKADTDPService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKADTDP
    {
        private COST_LKADTDPSoapClient client = new COST_LKADTDPSoapClient("COST_LKADTDPSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKADTDP.asmx");

        public int Create(CRM_COST_LKADTDP model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKADTDP model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKADTDP[] ReadByParam(CRM_COST_LKADTDP model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int DPID, string ptoken)
        {
            return client.Delete(DPID, ptoken);
        }




    }
}
