using Sonluk.UI.Model.CRM.COST_KAHXDJTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KAHXDJTT
    {
        private COST_KAHXDJTTSoapClient client = new COST_KAHXDJTTSoapClient("COST_KAHXDJTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KAHXDJTT.asmx");

        public int Create(CRM_COST_KAHXDJTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KAHXDJTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_KAHXDJTT[] ReadByParam(CRM_COST_KAHXDJTT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int HXDJTTID, string ptoken)
        {
            return client.Delete(HXDJTTID, ptoken);
        }




    }
}
