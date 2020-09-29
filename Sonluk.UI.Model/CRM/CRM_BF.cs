using Sonluk.UI.Model.CRM.CRM_BFService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class CRM_BF
    {
        private CRM_BFSoapClient client = new CRM_BFSoapClient("CRM_BFSoap", AppConfig.Settings("RemoteAddress") + "CRM/CRM_BF.asmx");
    }
}
