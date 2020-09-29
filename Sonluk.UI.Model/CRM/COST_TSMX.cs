using Sonluk.UI.Model.CRM.COST_TSMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_TSMX
    {
        private COST_TSMXSoapClient client = new COST_TSMXSoapClient("COST_TSMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_TSMX.asmx");

        public int Create(CRM_COST_TSMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_TSMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_TSMX[] ReadByParam(CRM_COST_TSMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int TSMXID, string ptoken)
        {
            return client.Delete(TSMXID, ptoken);
        }
    }
}
