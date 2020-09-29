using Sonluk.UI.Model.CRM.COST_LKAFYMXTSCLService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAFYMXTSCL
    {

        private COST_LKAFYMXTSCLSoapClient client = new COST_LKAFYMXTSCLSoapClient("COST_LKAFYMXTSCLSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAFYMXTSCL.asmx");

        public int Create(CRM_COST_LKAFYMXTSCL model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAFYMXTSCL model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAFYMXTSCL[] ReadByParam(CRM_COST_LKAFYMXTSCL model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int GGGSID, string ptoken)
        {
            return client.Delete(GGGSID, ptoken);
        }
        public CRM_COST_LKAFYMXTSCL[] Read_Unconnected(CRM_COST_LKAFYMXTSCL model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }



    }
}
