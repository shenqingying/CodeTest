using Sonluk.UI.Model.HR.KQ_GSKQService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_GSKQ
    {
        private WS_HR_KQ_GSKQSoapClient client = new WS_HR_KQ_GSKQSoapClient("WS_HR_KQ_GSKQSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_GSKQ.asmx");
        public HR_KQ_GSKQ_SELECT SELECT(HR_KQ_GSKQ model, int LB, string ptoken)
        {
            return client.SELECT(model, LB, ptoken);
        }
    }
}
