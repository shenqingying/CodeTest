using Sonluk.UI.Model.CRM.COST_KAHXZLMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KAHXZLMX
    {
        private COST_KAHXZLMXSoapClient client = new COST_KAHXZLMXSoapClient("COST_KAHXZLMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KAHXZLMX.asmx");

        public int Create(CRM_COST_KAHXZLMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KAHXZLMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int UpdateByKADTTTID(CRM_COST_KAHXZLMX model, string ptoken)
        {
            return client.UpdateByKADTTTID(model, ptoken);
        }
        public CRM_COST_KAHXZLMX[] ReadByParam(CRM_COST_KAHXZLMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_COST_KAHXZLMX[] ReadByTTID(int HXZLTTID, string ptoken)
        {
            return client.ReadByTTID(HXZLTTID, ptoken);
        }
        public CRM_COST_KAHXZLMX[] Read_Unconnected(CRM_COST_KAHXZLMX model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }
        public int Delete(int HXZLMXID, string ptoken)
        {
            return client.Delete(HXZLMXID, ptoken);
        }
        public int DeleteByKADTTTID(int KADTTTID, string ptoken)
        {
            return client.DeleteByKADTTTID(KADTTTID, ptoken);
        }



    }
}
