using Sonluk.UI.Model.CRM.COST_KADTDPService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KADTDP
    {
        private COST_KADTDPSoapClient client = new COST_KADTDPSoapClient("COST_KADTDPSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KADTDP.asmx");

        public int Create(CRM_COST_KADTDP model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KADTDP model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_KADTDP[] ReadByParam(CRM_COST_KADTDP model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int DPID, string ptoken)
        {
            return client.Delete(DPID, ptoken);
        }





    }
}
