using Sonluk.UI.Model.CRM.COST_LKAYEARCOSTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAYEARCOST
    {
        private COST_LKAYEARCOSTSoapClient client = new COST_LKAYEARCOSTSoapClient("COST_LKAYEARCOSTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAYEARCOST.asmx");

        public int Create(CRM_COST_LKAYEARCOST model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAYEARCOST model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int UpdateAll(CRM_COST_LKAYEARCOST model, string ptoken)
        {
            return client.UpdateAll(model, ptoken);
        }
        public int UpdateSPJE(CRM_COST_LKAYEARCOST model, string ptoken)
        {
            return client.UpdateSPJE(model, ptoken);
        }
        public CRM_COST_LKAYEARCOST[] ReadByParam(CRM_COST_LKAYEARCOST model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int COSTID, string ptoken)
        {
            return client.Delete(COSTID, ptoken);
        }
        public CRM_COST_LKAYEARCOST[] ReadCOSTByKHID(int KHID, string YEAR, string ptoken)
        {
            return client.ReadCOSTByKHID(KHID, YEAR, ptoken);
        }
        public CRM_COST_GETCOST GetCost(int LKAID, string HTYEAR, string ptoken)
        {
            return client.GetCost(LKAID, HTYEAR, ptoken);
        }
    }
}
