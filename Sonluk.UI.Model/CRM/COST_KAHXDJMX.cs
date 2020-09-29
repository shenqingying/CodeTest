using Sonluk.UI.Model.CRM.COST_KAHXDJMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KAHXDJMX
    {
        private COST_KAHXDJMXSoapClient client = new COST_KAHXDJMXSoapClient("COST_KAHXDJMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KAHXDJMX.asmx");

        public int Create(CRM_COST_KAHXDJMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KAHXDJMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int UpdateByStr(CRM_COST_KAHXDJMX model, string ptoken)
        {
            return client.UpdateByStr(model, ptoken);
        }
        public CRM_COST_KAHXDJMX[] ReadByParam(CRM_COST_KAHXDJMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_COST_KAHXDJMX[] ReadForPrint(CRM_COST_KAHXDJMX model, string ptoken)
        {
            return client.ReadForPrint(model, ptoken);
        }
        public int Delete(int HXDJMXID, string ptoken)
        {
            return client.Delete(HXDJMXID, ptoken);
        }
        public int AddPrintCount(int HXDJMXID, string ptoken)
        {
            return client.AddPrintCount(HXDJMXID, ptoken);
        }



    }
}
