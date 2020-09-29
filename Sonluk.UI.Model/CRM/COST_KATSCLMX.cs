using Sonluk.UI.Model.CRM.COST_KATSCLMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KATSCLMX
    {
        private COST_KATSCLMXSoapClient client = new COST_KATSCLMXSoapClient("COST_KATSCLMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KATSCLMX.asmx");

        public int Create(CRM_COST_KATSCLMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KATSCLMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_KATSCLMX[] ReadByParam(CRM_COST_KATSCLMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_COST_KATSCLMX[] Read_Unconnected(CRM_COST_KATSCLMX model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }
        public int Delete(int KATSCLMXID, string ptoken)
        {
            return client.Delete(KATSCLMXID, ptoken);
        }

        public int Create_CONN(COST_KATSCLMX_KAHXDJMX model, string ptoken)
        {
            return client.Create_CONN(model, ptoken);
        }

        public CRM_COST_KATSCLMX[] Read_Unconnected_CONN(CRM_COST_KATSCLMX model, string ptoken)
        {
            return client.Read_Unconnected_CONN(model, ptoken);
        }

        public int DeleteByHXDJMXID(int HXDJMXID, string ptoken)
        {
            return client.DeleteByHXDJMXID(HXDJMXID, ptoken);
        }


    }
}
