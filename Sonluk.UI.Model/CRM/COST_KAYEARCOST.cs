using Sonluk.UI.Model.CRM.COST_KAYEARCOSTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KAYEARCOST
    {
        private COST_KAYEARCOSTSoapClient client = new COST_KAYEARCOSTSoapClient("COST_KAYEARCOSTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KAYEARCOST.asmx");

        public int Create(CRM_COST_KAYEARCOST model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KAYEARCOST model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int UpdateSPJE(int KAYEARTTID, string ptoken)
        {
            return client.UpdateSPJE(KAYEARTTID, ptoken);
        }
        public CRM_COST_KAYEARCOST[] ReadByParam(CRM_COST_KAYEARCOST model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_COST_KAYEARCOST[] Read_Unconnected(CRM_COST_KAYEARCOST model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }
        public int Delete(int COSTID, string ptoken)
        {
            return client.Delete(COSTID, ptoken);
        }

    }
}
