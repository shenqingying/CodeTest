using Sonluk.UI.Model.CRM.COST_CLFMX_CLFHXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
  public  class COST_CLFMX_CLFHX
    {
      private COST_CLFMX_CLFHXSoapClient client = new COST_CLFMX_CLFHXSoapClient("COST_CLFMX_CLFHXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CLFMX_CLFHX.asmx");

        public int Create(CRM_COST_CLFMX_CLFHX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CLFMX_CLFHX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CLFMX_CLFHX[] ReadByParam(CRM_COST_CLFMX_CLFHX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_COST_CLFMX_CLFHX[] ReadByCLFHXID(int CLFHXID, string ptoken)
        {
            return client.ReadByCLFHXID(CLFHXID, ptoken);
        }
        public CRM_COST_CLFMX_CLFHX[] ReadByCLFMXID(int CLFMXID, string ptoken)
        {
            return client.ReadByCLFMXID(CLFMXID, ptoken);
        }
        public int Delete(CRM_COST_CLFMX_CLFHX model, string ptoken)
        {
            return client.Delete(model, ptoken);
        }
        public int DeleteByCLFHXID(int CLFHXID, string ptoken)
        {
            return client.DeleteByCLFHXID(CLFHXID, ptoken);
        }
    }
}
