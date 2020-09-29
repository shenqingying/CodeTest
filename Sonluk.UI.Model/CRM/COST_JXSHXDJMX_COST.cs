using Sonluk.UI.Model.CRM.COST_JXSHXDJMX_COSTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
  public  class COST_JXSHXDJMX_COST
    {
        private COST_JXSHXDJMX_COSTSoapClient client = new COST_JXSHXDJMX_COSTSoapClient("COST_JXSHXDJMX_COSTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_JXSHXDJMX_COST.asmx");

        public int Create(CRM_COST_JXSHXDJMX_COST model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_JXSHXDJMX_COST model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_JXSHXDJMX_COST[] ReadByParam(CRM_COST_JXSHXDJMX_COST model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(CRM_COST_JXSHXDJMX_COST model, string ptoken)
        {
            return client.Delete(model, ptoken);
        }
        public int DeleteByHXDJMXID(int HXDJMXID, string ptoken)
        {
            return client.DeleteByHXDJMXID(HXDJMXID, ptoken);
        }
    }
}
