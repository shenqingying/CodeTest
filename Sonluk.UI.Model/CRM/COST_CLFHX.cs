using Sonluk.UI.Model.CRM.COST_CLFHXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
  public  class COST_CLFHX
    {
      private COST_CLFHXSoapClient client = new COST_CLFHXSoapClient("COST_CLFHXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CLFHX.asmx");

      public int Create(CRM_COST_CLFHX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
      public int Update(CRM_COST_CLFHX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
      public CRM_COST_CLFHX[] ReadByParam(CRM_COST_CLFHX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
      public int Delete(int CLFHXID, string ptoken)
        {
            return client.Delete(CLFHXID, ptoken);
        }
    }
}
