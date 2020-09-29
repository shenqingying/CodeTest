using Sonluk.UI.Model.CRM.COST_LKAHXZLMDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAHXZLMD
    {
        private COST_LKAHXZLMDSoapClient client = new COST_LKAHXZLMDSoapClient("COST_LKAHXZLMDSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAHXZLMD.asmx");

        public int Create(CRM_COST_LKAHXZLMD model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAHXZLMD model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAHXZLMD[] ReadByParam(CRM_COST_LKAHXZLMD model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int HXZLMDMXID, string ptoken)
        {
            return client.Delete(HXZLMDMXID, ptoken);
        }



    }
}
