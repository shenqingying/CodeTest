using Sonluk.UI.Model.CRM.COST_LKAPRODUCTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAPRODUCT
    {
        private COST_LKAPRODUCTSoapClient client = new COST_LKAPRODUCTSoapClient("COST_LKAPRODUCTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAPRODUCT.asmx");


        public int Create(CRM_COST_LKAPRODUCT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAPRODUCT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAPRODUCT[] ReadByParam(CRM_COST_LKAPRODUCT model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(string SAPCP, string ptoken)
        {
            return client.Delete(SAPCP, ptoken);
        }


    }
}
