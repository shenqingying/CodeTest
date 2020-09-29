using Sonluk.UI.Model.HR.KQ_KQINFOService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_KQINFO
    {
        private WS_HR_KQ_KQINFOSoapClient client = new WS_HR_KQ_KQINFOSoapClient("WS_HR_KQ_KQINFOSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_KQINFO.asmx");
        public HR_KQ_KQINFO_SELECT SELECT(HR_KQ_KQINFO model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
