using Sonluk.UI.Model.HR.SY_TYPEService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class SY_TYPE
    {
        private SY_TYPESoapClient client = new SY_TYPESoapClient("SY_TYPESoap2", AppConfig.Settings("RemoteAddress") + "HR/SY_TYPE.asmx");
        public HR_SY_TYPE_SELECT SELECT(string ptoken)
        {
            return client.SELECT(ptoken);
        }
    }
}
