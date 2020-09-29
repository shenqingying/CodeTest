using Sonluk.UI.Model.CRM.COST_MDBSService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_MDBS
    {
        private COST_MDBSSoapClient client = new COST_MDBSSoapClient("COST_MDBSSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_MDBS.asmx");

        public int Create(CRM_COST_MDBS model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_MDBS model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_MDBS[] ReadByParam(CRM_COST_MDBS model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public CRM_COST_MDBS[] Read_Unconnected(CRM_COST_MDBS model, int STAFFID, string ptoken)
        {
            return client.Read_Unconnected(model, STAFFID, ptoken);
        }
        public int Delete(int MDBSID, string ptoken)
        {
            return client.Delete(MDBSID, ptoken);
        }






    }
}
