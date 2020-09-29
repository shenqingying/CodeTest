using Sonluk.UI.Model.CRM.COST_MDBSHXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_MDBSHX
    {

        private COST_MDBSHXSoapClient client = new COST_MDBSHXSoapClient("COST_MDBSHXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_MDBSHX.asmx");

        public int Create(CRM_COST_MDBSHX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_MDBSHX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_MDBSHX[] ReadByParam(CRM_COST_MDBSHX model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int CPLXID, string ptoken)
        {
            return client.Delete(CPLXID, ptoken);
        }
        public CRM_COST_MDBSHX[] Read_Unconnected(CRM_COST_MDBSHX model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }




    }
}
