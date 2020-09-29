using Sonluk.UI.Model.CRM.COST_CBZXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CBZX
    {
        private COST_CBZXSoapClient client = new COST_CBZXSoapClient("COST_CBZXSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CBZX.asmx");

        public int Create(CRM_COST_CBZX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CBZX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CBZX[] ReadByParam(CRM_COST_CBZX model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(string CBZXBH, string ptoken)
        {
            return client.Delete(CBZXBH, ptoken);
        }




    }
}
