using Sonluk.UI.Model.CRM.COST_GSZCFSService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_GSZCFS
    {
        private COST_GSZCFSSoapClient client = new COST_GSZCFSSoapClient("COST_GSZCFSSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_GSZCFS.asmx");

        public int Create(CRM_COST_GSZCFS model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_GSZCFS model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_GSZCFS[] ReadByParam(CRM_COST_GSZCFS model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int ZCFSID, string ptoken)
        {
            return client.Delete(ZCFSID, ptoken);
        }





    }
}
