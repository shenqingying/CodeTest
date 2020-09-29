using Sonluk.UI.Model.CRM.COST_TSService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
  public  class COST_TS
    {
      private COST_TSSoapClient client = new COST_TSSoapClient("COST_TSSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_TS.asmx");

        public int Create(CRM_COST_TS model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_TS model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_TS[] ReadByParam(CRM_COST_TS model, int CURRENTID, string ptoken)
        {
            return client.ReadByParam(model,CURRENTID, ptoken);
        }
        public int Delete(int TSID, string ptoken)
        {
            return client.Delete(TSID, ptoken);
        }
    }
}
