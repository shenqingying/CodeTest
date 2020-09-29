using Sonluk.UI.Model.CRM.BC_CHTT_FAKEService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class BC_CHTT_FAKE
    {
        private BC_CHTT_FAKESoapClient client = new BC_CHTT_FAKESoapClient("BC_CHTT_FAKESoap", AppConfig.Settings("RemoteAddress") + "CRM/BC_CHTT_FAKE.asmx");

        public int TTCreate(CRM_BC_CHTT model, string ptoken)
        {
            return client.TTCreate(model, ptoken);
        }
        public int MXCreate(CRM_BC_CHMX model, string ptoken)
        {
            return client.MXCreate(model, ptoken);
        }
        public int TTMXDelete(string ptoken)
        {
            return client.TTMXDelete(ptoken);
        }

    }
}
