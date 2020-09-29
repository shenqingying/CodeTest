using Sonluk.UI.Model.CRM.COST_WDTCService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_WDTC
    {
        private COST_WDTCSoapClient client = new COST_WDTCSoapClient("COST_WDTCSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_WDTC.asmx");

        public int Create(CRM_COST_WDTC model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_WDTC model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_WDTC[] ReadByParam(CRM_COST_WDTC model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int WDTCID, string ptoken)
        {
            return client.Delete(WDTCID, ptoken);
        }




    }
}
