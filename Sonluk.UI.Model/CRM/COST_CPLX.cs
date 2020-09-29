using Sonluk.UI.Model.CRM.COST_CPLXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CPLX
    {
        private COST_CPLXSoapClient client = new COST_CPLXSoapClient("COST_CPLXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CPLX.asmx");

        public int Create(CRM_COST_CPLX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CPLX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CPLX[] ReadByParam(CRM_COST_CPLX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int CPLXID, string ptoken)
        {
            return client.Delete(CPLXID, ptoken);
        }



    }
}
