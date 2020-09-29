using Sonluk.UI.Model.CRM.COST_CXYService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CXY
    {
        private COST_CXYSoapClient client = new COST_CXYSoapClient("COST_CXYSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CXY.asmx");

        public int Create(CRM_COST_CXY model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CXY model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CXY[] ReadByParam(CRM_COST_CXY model,int STAFFID, string ptoken)
        {
            return client.ReadByParam(model,STAFFID, ptoken);
        }
        public CRM_COST_CXY[] ReadByGZ(CRM_COST_CXY model, string ptoken)
        {
            return client.ReadByGZ(model, ptoken);
        }
        public int Delete(int CXYID, string ptoken)
        {
            return client.Delete(CXYID, ptoken);
        }
    }
}
