using Sonluk.UI.Model.CRM.COST_JXSHXDJMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_JXSHXDJMX
    {
         private COST_JXSHXDJMXSoapClient client = new COST_JXSHXDJMXSoapClient("COST_JXSHXDJMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_JXSHXDJMX.asmx");

        public int Create(CRM_COST_JXSHXDJMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_JXSHXDJMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_JXSHXDJMX[] ReadByParam(CRM_COST_JXSHXDJMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int CXYID, string ptoken)
        {
            return client.Delete(CXYID, ptoken);
        }
    }
    
}
