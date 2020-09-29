using Sonluk.UI.Model.CRM.WL_TTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
  public  class WL_TT
    {
      private WL_TTSoapClient client = new WL_TTSoapClient("WL_TTSoap", AppConfig.Settings("RemoteAddress") + "CRM/WL_TT.asmx");

        public int Create(CRM_WL_TT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_WL_TT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_WL_TT[] ReadByParam(CRM_WL_TT model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int TTID, string ptoken)
        {
            return client.Delete(TTID, ptoken);
        }
    }
}
