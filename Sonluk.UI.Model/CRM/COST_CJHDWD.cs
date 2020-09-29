using Sonluk.UI.Model.CRM.COST_CJHDWDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CJHDWD
    {
        private COST_CJHDWDSoapClient client = new COST_CJHDWDSoapClient("COST_CJHDWDSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CJHDWD.asmx");

        public int Create(CRM_COST_CJHDWD model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CJHDWD model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CJHDWD[] ReadByParam(CRM_COST_CJHDWD model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int CJHDWDID, string ptoken)
        {
            return client.Delete(CJHDWDID, ptoken);
        }

    }
}
