using Sonluk.UI.Model.CRM.COST_CLFTT_STAFFService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CLFTT_STAFF
    {
        private COST_CLFTT_STAFFSoapClient client = new COST_CLFTT_STAFFSoapClient("COST_CLFTT_STAFFSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CLFTT_STAFF.asmx");

        public int Create(CRM_COST_CLFTT_STAFF model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CLFTT_STAFF model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CLFTT_STAFF[] ReadByParam(CRM_COST_CLFTT_STAFF model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int ID, string ptoken)
        {
            return client.Delete(ID, ptoken);
        }




    }
}
