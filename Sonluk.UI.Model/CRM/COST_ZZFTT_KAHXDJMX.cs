using Sonluk.UI.Model.CRM.COST_ZZFTT_KAHXDJMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_ZZFTT_KAHXDJMX
    {
        private COST_ZZFTT_KAHXDJMXSoapClient client = new COST_ZZFTT_KAHXDJMXSoapClient("COST_ZZFTT_KAHXDJMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_ZZFTT_KAHXDJMX.asmx");

        public int Create(CRM_COST_ZZFTT_KAHXDJMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public CRM_COST_ZZFTT_KAHXDJMX[] ReadByParam(CRM_COST_ZZFTT_KAHXDJMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int HXDJMXID, int TTID, string ptoken)
        {
            return client.Delete(HXDJMXID, TTID, ptoken);
        }
        public int DeleteByHXDJMXID(int HXDJMXID, string ptoken)
        {
            return client.DeleteByHXDJMXID(HXDJMXID, ptoken);
        }

    }
}
