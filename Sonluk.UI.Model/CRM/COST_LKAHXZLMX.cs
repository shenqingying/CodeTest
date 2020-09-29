using Sonluk.UI.Model.CRM.COST_LKAHXZLMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAHXZLMX
    {
        private COST_LKAHXZLMXSoapClient client = new COST_LKAHXZLMXSoapClient("COST_LKAHXZLMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAHXZLMX.asmx");

        public int Create(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAHXZLMX[] ReadByParam(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_COST_LKAHXZLMX[] ReadByTTID(int HXZLTTID, string ptoken)
        {
            return client.ReadByTTID(HXZLTTID, ptoken);
        }
        public int Delete(int HXZLMXID, string ptoken)
        {
            return client.Delete(HXZLMXID, ptoken);
        }
        public int DeleteByLKAFYTTID(int LKAFYTTID, string ptoken)
        {
            return client.DeleteByLKAFYTTID(LKAFYTTID, ptoken);
        }
        public CRM_COST_LKAHXZLMX ReadMXinfo(CRM_COST_LKAHXZLMX model, string HTYEAR, int LKAID, string ptoken)
        {
            return client.ReadMXinfo(model, HTYEAR, LKAID, ptoken);
        }
        public CRM_COST_LKAHXZLMX[] Read_Unconnected(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }
        public CRM_COST_LKAHXZLMX Read_CostTime(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            return client.Read_CostTime(model, ptoken);
        }

    }
}
