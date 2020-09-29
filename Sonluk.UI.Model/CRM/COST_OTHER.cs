using Sonluk.UI.Model.CRM.COST_OTHERService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_OTHER
    {
        private COST_OTHERSoapClient client = new COST_OTHERSoapClient("COST_OTHERSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_OTHER.asmx");

        public int Create(CRM_COST_OTHER model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_OTHER model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_OTHER[] ReadByParam(CRM_COST_OTHER model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public CRM_COST_OTHER[] Read_Unconnected(CRM_COST_OTHER model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }
        public int Delete(int COSTITEMID, string ptoken)
        {
            return client.Delete(COSTITEMID, ptoken);
        }




    }
}
