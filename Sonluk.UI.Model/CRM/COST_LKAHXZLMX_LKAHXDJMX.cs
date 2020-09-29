using Sonluk.UI.Model.CRM.COST_LKAHXZLMX_LKAHXDJMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAHXZLMX_LKAHXDJMX
    {
        private COST_LKAHXZLMX_LKAHXDJMXSoapClient client = new COST_LKAHXZLMX_LKAHXDJMXSoapClient("COST_LKAHXZLMX_LKAHXDJMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAHXZLMX_LKAHXDJMX.asmx");

        public int Create(CRM_COST_LKAHXZLMX_LKAHXDJMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAHXZLMX_LKAHXDJMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAHXZLMX_LKAHXDJMX[] ReadByParam(CRM_COST_LKAHXZLMX_LKAHXDJMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(CRM_COST_LKAHXZLMX_LKAHXDJMX model, string ptoken)
        {
            return client.Delete(model, ptoken);
        }
        public int DeleteByHXDJMXID(int HXDJMXID, string ptoken)
        {
            return client.DeleteByHXDJMXID(HXDJMXID, ptoken);
        }



    }
}
