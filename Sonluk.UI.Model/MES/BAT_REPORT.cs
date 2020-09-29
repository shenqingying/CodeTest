using Sonluk.UI.Model.MES.BAT_REPORTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class BAT_REPORT
    {
        private BAT_REPORTSoapClient client = new BAT_REPORTSoapClient("BAT_REPORTSoap", AppConfig.Settings("RemoteAddress") + "MES/BAT_REPORT.asmx");

        public MES_BAT_REPORT SEARCH(MES_BAT_REPORT_SEARCH model, String token, int STAFFID)
        {
            return client.SEARCH(model, token, STAFFID);
        }
    }
}
