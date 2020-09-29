using Sonluk.UI.Model.CRM.COST_KAYEARTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KAYEARTT
    {
        private COST_KAYEARTTSoapClient client = new COST_KAYEARTTSoapClient("COST_KAYEARTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KAYEARTT.asmx");

        public int Create(CRM_COST_KAYEARTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KAYEARTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int UpdateSubmitCount(int KAYEARTTID, string ptoken)
        {
            return client.UpdateSubmitCount(KAYEARTTID, ptoken);
        }
        public CRM_COST_KAYEARTT[] ReadByParam(CRM_COST_KAYEARTT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int KAYEARTTID, string ptoken)
        {
            return client.Delete(KAYEARTTID, ptoken);
        }
        public int Verify(CRM_COST_KAYEARTT model, string ptoken)
        {
            return client.Verify(model, ptoken);
        }


    }
}
