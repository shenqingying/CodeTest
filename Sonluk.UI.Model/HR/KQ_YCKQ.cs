using Sonluk.UI.Model.HR.KQ_YCKQService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_YCKQ
    {
        private WS_HR_KQ_YCKQSoapClient client = new WS_HR_KQ_YCKQSoapClient("WS_HR_KQ_YCKQSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_YCKQ.asmx");
        public HR_KQ_YCKQ_SELECT SELECT(HR_KQ_YCKQ model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
