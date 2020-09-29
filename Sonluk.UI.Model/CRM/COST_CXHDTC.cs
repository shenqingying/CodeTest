using Sonluk.UI.Model.CRM.COST_CXHDTCService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CXHDTC
    {
        private COST_CXHDTCSoapClient client = new COST_CXHDTCSoapClient("COST_CXHDTCSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CXHDTC.asmx");

        public int Create(CRM_COST_CXHDTC model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CXHDTC model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CXHDTC[] ReadByParam(CRM_COST_CXHDTC model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int TCID, string ptoken)
        {
            return client.Delete(TCID, ptoken);
        }





    }
}
