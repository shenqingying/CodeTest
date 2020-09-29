using Sonluk.UI.Model.CRM.COST_KADTTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KADTTT
    {
        private COST_KADTTTSoapClient client = new COST_KADTTTSoapClient("COST_KADTTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KADTTT.asmx");

        public int Create(CRM_COST_KADTTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KADTTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int UpdateCost(int KADTTTID, string ptoken)
        {
            return client.UpdateCost(KADTTTID, ptoken);
        }
        public CRM_COST_KADTTT[] ReadByParam(CRM_COST_KADTTT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public CRM_COST_KADTTT[] Read_Unconnected(CRM_COST_KADTTT model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }
        public int Delete(int KADTTTID, string ptoken)
        {
            return client.Delete(KADTTTID, ptoken);
        }

    }
}
