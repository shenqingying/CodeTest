using Sonluk.UI.Model.CRM.COST_CLFMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
   public class COST_CLFMX
    {
       private COST_CLFMXSoapClient client = new COST_CLFMXSoapClient("COST_CLFMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CLFMX.asmx");

       public int Create(CRM_COST_CLFMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }

       public int Update(CRM_COST_CLFMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
       public CRM_COST_CLFMX[] ReadByParam(CRM_COST_CLFMX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
       public CRM_COST_CLFMX[] ReadPart(CRM_COST_CLFMX model, string ptoken)
       {
           return client.ReadPart(model, ptoken);
       }
       public CRM_COST_CLFMX[] ReadByTTID(int CLFTTID, string ptoken)
       {
           return client.ReadByTTID(CLFTTID, ptoken);
       }
       public int Delete(int CLFMXID, string ptoken)
        {
            return client.Delete(CLFMXID, ptoken);
        }
    }
}
