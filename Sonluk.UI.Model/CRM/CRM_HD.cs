using Sonluk.UI.Model.CRM.CRM_HDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class CRM_HD
    {
        private CRM_HDSoapClient client = new CRM_HDSoapClient("CRM_HDSoap", AppConfig.Settings("RemoteAddress") + "CRM/CRM_HD.asmx");
    }
}
