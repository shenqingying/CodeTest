using Sonluk.UI.Model.CRM.COST_CXYGZService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CXYGZ
    {
        private COST_CXYGZSoapClient client = new COST_CXYGZSoapClient("COST_CXYGZSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CXYGZ.asmx");

        public int Create(CRM_COST_CXYGZ model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CXYGZ model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CXYGZ[] ReadByParam(CRM_COST_CXYGZ model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int CXYGZID, string ptoken)
        {
            return client.Delete(CXYGZID, ptoken);
        }
        public int AddPrintCount(int CXYGZID, string ptoken)
        {
            return client.AddPrintCount(CXYGZID, ptoken);
        }
    }
}
