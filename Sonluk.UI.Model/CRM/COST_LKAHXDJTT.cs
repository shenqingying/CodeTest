using Sonluk.UI.Model.CRM.COST_LKAHXDJTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAHXDJTT
    {
        private COST_LKAHXDJTTSoapClient client = new COST_LKAHXDJTTSoapClient("COST_LKAHXDJTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAHXDJTT.asmx");

        public int Create(CRM_COST_LKAHXDJTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAHXDJTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAHXDJTT[] ReadByParam(CRM_COST_LKAHXDJTT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int HXDJTTID, string ptoken)
        {
            return client.Delete(HXDJTTID, ptoken);
        }




    }
}
