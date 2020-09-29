using Sonluk.UI.Model.CRM.COST_KADTMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KADTMX
    {
        private COST_KADTMXSoapClient client = new COST_KADTMXSoapClient("COST_KADTMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KADTMX.asmx");

        public int Create(CRM_COST_KADTMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KADTMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_KADTMX[] ReadByParam(CRM_COST_KADTMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int KADTMXID, string ptoken)
        {
            return client.Delete(KADTMXID, ptoken);
        }

        public int Create_CONN(COST_KADTMX_KAHXDJMX model, string ptoken)
        {
            return client.Create_CONN(model, ptoken);
        }
        public int DeleteByHXDJMXID_CONN(int KAHXDJMX, string ptoken)
        {
            return client.DeleteByHXDJMXID_CONN(KAHXDJMX, ptoken);
        }
        public CRM_COST_KADTMX[] Read_Unconnected_CONN(CRM_COST_KADTMX model, string ptoken)
        {
            return client.Read_Unconnected_CONN(model, ptoken);
        }

    }
}
