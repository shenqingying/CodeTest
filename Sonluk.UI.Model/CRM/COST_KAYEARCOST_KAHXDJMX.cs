using Sonluk.UI.Model.CRM.COST_KAYEARCOST_KAHXDJMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KAYEARCOST_KAHXDJMX
    {
        private COST_KAYEARCOST_KAHXDJMXSoapClient client = new COST_KAYEARCOST_KAHXDJMXSoapClient("COST_KAYEARCOST_KAHXDJMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KAYEARCOST_KAHXDJMX.asmx");

        public int Create(CRM_COST_KAYEARCOST_KAHXDJMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public CRM_COST_KAYEARCOST_KAHXDJMX[] ReadByParam(CRM_COST_KAYEARCOST_KAHXDJMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int HXDJMXID, string ptoken)
        {
            return client.DeleteByHXDJMXID(HXDJMXID, ptoken);
        }





    }
}
