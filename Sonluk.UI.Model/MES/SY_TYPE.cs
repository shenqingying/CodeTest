using Sonluk.UI.Model.MES.SY_TYPEService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_TYPE
    {
        private SY_TYPESoapClient client = new SY_TYPESoapClient("SY_TYPESoap", AppConfig.Settings("RemoteAddress") + "MES/SY_TYPE.asmx");
        public MES_SY_TYPE[] SELECT(string ptoken)
        {
            return client.SELECT(ptoken);
        }
    }
}
