using Sonluk.UI.Model.CRM.COST_GGGSService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_GGGS
    {
        private COST_GGGSSoapClient client = new COST_GGGSSoapClient("COST_GGGSSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_GGGS.asmx");

        public int Create(CRM_COST_GGGS model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_GGGS model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_GGGS[] ReadByParam(CRM_COST_GGGS model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int GGGSID, string ptoken)
        {
            return client.Delete(GGGSID, ptoken);
        }




    }
}
