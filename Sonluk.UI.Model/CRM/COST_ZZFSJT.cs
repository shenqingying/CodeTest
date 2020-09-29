using Sonluk.UI.Model.CRM.COST_ZZFSJTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
 public   class COST_ZZFSJT
    {
        private COST_ZZFSJTSoapClient client = new COST_ZZFSJTSoapClient("COST_ZZFSJTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_ZZFSJT.asmx");

        public int Create(CRM_COST_ZZFSJT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_ZZFSJT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_ZZFSJT[] ReadByParam(CRM_COST_ZZFSJT model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int SJTID, string ptoken)
        {
            return client.Delete(SJTID, ptoken);
        }
    }
}
