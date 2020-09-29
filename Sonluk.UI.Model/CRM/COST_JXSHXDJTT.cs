using Sonluk.UI.Model.CRM.COST_JXSHXDJTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
  public  class COST_JXSHXDJTT
    {
         private COST_JXSHXDJTTSoapClient client = new COST_JXSHXDJTTSoapClient("COST_JXSHXDJTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_JXSHXDJTT.asmx");

        public int Create(CRM_COST_JXSHXDJTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_JXSHXDJTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_JXSHXDJTT[] ReadByParam(CRM_COST_JXSHXDJTT model,int STAFFID, string ptoken)
        {
            return client.ReadByParam(model,STAFFID,ptoken);
        }
        public int Delete(int HXDJTTID, string ptoken)
        {
            return client.Delete(HXDJTTID, ptoken);
        }
    }
    
}
