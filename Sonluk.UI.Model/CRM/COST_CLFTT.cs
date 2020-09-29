using Sonluk.UI.Model.CRM.COST_CLFTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
  public  class COST_CLFTT
    {
      private COST_CLFTTSoapClient client = new COST_CLFTTSoapClient("COST_CLFTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CLFTT.asmx");

      public int Create(CRM_COST_CLFTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
      public int Update(CRM_COST_CLFTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
      public CRM_COST_CLFTT[] ReadByParam(CRM_COST_CLFTT model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
      public CRM_COST_CLFTT[] ReadByAll(CRM_COST_CLFTT model,int CURRENTID, string ptoken)
      {
          return client.ReadByAll(model,CURRENTID, ptoken);
      }
        public int Delete(int TTID, string ptoken)
        {
            return client.Delete(TTID, ptoken);
        }
    }
}
