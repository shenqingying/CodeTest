using Sonluk.UI.Model.CRM.COST_CXHDPGQDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CXHDPGQD
    {
        private COST_CXHDPGQDSoapClient client = new COST_CXHDPGQDSoapClient("COST_CXHDPGQDSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CXHDPGQD.asmx");

        public int Create(CRM_COST_CXHDPGQD model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CXHDPGQD model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CXHDPGQD[] ReadByParam(CRM_COST_CXHDPGQD model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int PGQDID, string ptoken)
        {
            return client.Delete(PGQDID, ptoken);
        }
        public int DeleteByCXHDID(int CXHDID, string ptoken)
        {
            return client.DeleteByCXHDID(CXHDID, ptoken);
        }




    }
}
