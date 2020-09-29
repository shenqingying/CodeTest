using Sonluk.UI.Model.CRM.HG_RIGHTGROUPService;
using Sonluk.UI.Model.CRM.HG_RIGHTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_RIGHTGROUP
    {
        private HG_RIGHTGROUPSoapClient client = new HG_RIGHTGROUPSoapClient("HG_RIGHTGROUPSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_RIGHTGROUP.asmx");
        

        public int Create(CRM_HG_RIGHTGROUP model, string ptoken)
        {
            return client.Create(model, ptoken);
        }

        public int Update(CRM_HG_RIGHTGROUP model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
      
        public int Delete(int RIGHTID, string ptoken)
        {
            return client.Delete(RIGHTID, ptoken);
        }

        public CRM_HG_RIGHTGROUP[] Read(string ptoken)
        {
            return client.Read( ptoken);
        }
    }
}
