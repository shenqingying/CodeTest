using Sonluk.UI.Model.CRM.OA_OPINIONService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class OA_OPINION
    {
        private OA_OPINIONSoapClient client = new OA_OPINIONSoapClient("OA_OPINIONSoap", AppConfig.Settings("RemoteAddress") + "CRM/OA_OPINION.asmx");


        public CRM_OA_OPINION[] ReadByParam(CRM_OA_OPINION model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Update(CRM_OA_OPINION model, string ptoken)
        {
            return client.Update(model, ptoken);
        }

    }
}
