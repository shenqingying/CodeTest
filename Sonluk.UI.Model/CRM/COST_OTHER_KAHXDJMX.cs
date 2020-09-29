using Sonluk.UI.Model.CRM.COST_OTHER_KAHXDJMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_OTHER_KAHXDJMX
    {
        private COST_OTHER_KAHXDJMXSoapClient client = new COST_OTHER_KAHXDJMXSoapClient("COST_OTHER_KAHXDJMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_OTHER_KAHXDJMX.asmx");

        public int Create(CRM_COST_OTHER_KAHXDJMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public CRM_COST_OTHER_KAHXDJMX[] ReadByParam(CRM_COST_OTHER_KAHXDJMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int HXDJMXID, string ptoken)
        {
            return client.DeleteByHXDJMXID(HXDJMXID, ptoken);
        }




    }
}
