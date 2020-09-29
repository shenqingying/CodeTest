using Sonluk.UI.Model.CRM.COST_ZZFTT_LKAHXDJMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_ZZFTT_LKAHXDJMX
    {
        private COST_ZZFTT_LKAHXDJMXSoapClient client = new COST_ZZFTT_LKAHXDJMXSoapClient("COST_ZZFTT_LKAHXDJMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_ZZFTT_LKAHXDJMX.asmx");

        public int Create(CRM_COST_ZZFTT_LKAHXDJMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public CRM_COST_ZZFTT_LKAHXDJMX[] ReadByParam(CRM_COST_ZZFTT_LKAHXDJMX model, string ptoken)
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
