using Sonluk.UI.Model.HR.SY_CHANGEINFOService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class SY_CHANGEINFO
    {
        private WS_HR_SY_CHANGEINFOSoapClient client = new WS_HR_SY_CHANGEINFOSoapClient("WS_HR_SY_CHANGEINFOSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_SY_CHANGEINFO.asmx");
        public HR_SY_CHANGEINFO_SELECT SELECT(HR_SY_CHANGEINFO model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
