using Sonluk.UI.Model.CRM.CRM_KQService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class CRM_KQ
    {
        private CRM_KQSoapClient client = new CRM_KQSoapClient("CRM_KQSoap", AppConfig.Settings("RemoteAddress") + "CRM/CRM_KQ.asmx");
    }
}
