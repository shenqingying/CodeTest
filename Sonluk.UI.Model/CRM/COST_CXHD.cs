using Sonluk.UI.Model.CRM.COST_CXHDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CXHD
    {
        private COST_CXHDSoapClient client = new COST_CXHDSoapClient("COST_CXHDSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CXHD.asmx");

        public int Create(CRM_COST_CXHD model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CXHD model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CXHD[] ReadByParam(CRM_COST_CXHD model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int CXHDID, string ptoken)
        {
            return client.Delete(CXHDID, ptoken);
        }





    }
}
