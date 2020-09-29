using Sonluk.UI.Model.CRM.COST_LKAHXDJMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAHXDJMX
    {
        private COST_LKAHXDJMXSoapClient client = new COST_LKAHXDJMXSoapClient("COST_LKAHXDJMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAHXDJMX.asmx");

        public int Create(CRM_COST_LKAHXDJMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAHXDJMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAHXDJMX[] ReadByParam(CRM_COST_LKAHXDJMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int HXDJMXID, string ptoken)
        {
            return client.Delete(HXDJMXID, ptoken);
        }



    }
}
