using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Utility;
using Sonluk.UI.Model.CRM.COST_ZZFMXService;

namespace Sonluk.UI.Model.CRM
{
    public class COST_ZZFMX
    {
        private COST_ZZFMXSoapClient client = new COST_ZZFMXSoapClient("COST_ZZFMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_ZZFMX.asmx");

        public int Create(CRM_COST_ZZFMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_ZZFMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_ZZFMX[] ReadByParam(CRM_COST_ZZFMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int MXID, string ptoken)
        {
            return client.Delete(MXID, ptoken);
        }
    }
}
