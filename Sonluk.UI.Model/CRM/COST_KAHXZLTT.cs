using Sonluk.UI.Model.CRM.COST_KAHXZLTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KAHXZLTT
    {
        private COST_KAHXZLTTSoapClient client = new COST_KAHXZLTTSoapClient("COST_KAHXZLTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KAHXZLTT.asmx");

        public int Create(CRM_COST_KAHXZLTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KAHXZLTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_KAHXZLTT[] ReadByParam(CRM_COST_KAHXZLTT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int HXZLTTID, string ptoken)
        {
            return client.Delete(HXZLTTID, ptoken);
        }




    }
}
