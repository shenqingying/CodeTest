using Sonluk.UI.Model.MES.SY_MACBBService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_MACBB
    {
        private SY_MACBBSoapClient client = new SY_MACBBSoapClient("SY_MACBBSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_MACBB.asmx");
        public MES_RETURN INSERT(MES_SY_MACBB model, string ptoken)
        {
            return client.INSERT(model, ptoken);
        }
    }
}
