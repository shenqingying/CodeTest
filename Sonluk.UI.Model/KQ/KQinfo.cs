using Sonluk.UI.Model.KQ.KQinfoService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.KQ
{
    public class KQinfo
    {

        private KQinfoSoapClient client = new KQinfoSoapClient("KQinfoSoap", AppConfig.Settings("RemoteAddress") + "KQ/KQinfo.asmx");

        public string StaffCardID(string cardno)
        {
            return client.StaffCardID(cardno);
        }

    }
}
