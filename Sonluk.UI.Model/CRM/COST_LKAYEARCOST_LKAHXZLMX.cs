using Sonluk.UI.Model.CRM.COST_LKAYEARCOST_LKAHXZLMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAYEARCOST_LKAHXZLMX
    {
        private COST_LKAYEARCOST_LKAHXZLMXSoapClient client = new COST_LKAYEARCOST_LKAHXZLMXSoapClient("COST_LKAYEARCOST_LKAHXZLMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAYEARCOST_LKAHXZLMX.asmx");

        public int Create(CRM_COST_LKAYEARCOST_LKAHXZLMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAYEARCOST_LKAHXZLMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAYEARCOST_LKAHXZLMX[] ReadByParam(CRM_COST_LKAYEARCOST_LKAHXZLMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_COST_LKAYEARCOST_LKAHXZLMX[] ReadByTTID(CRM_COST_LKAYEARCOST_LKAHXZLMX model, string ptoken)
        {
            return client.ReadByTTID(model, ptoken);
        }
        public int Delete(CRM_COST_LKAYEARCOST_LKAHXZLMX model, string ptoken)
        {
            return client.Delete(model, ptoken);
        }
        public int DeleteByHXZLMXID(int HXZLMXID, string ptoken)
        {
            return client.DeleteByHXZLMXID(HXZLMXID, ptoken);
        }




    }
}
