using Sonluk.UI.Model.MES.SY_MACHINEINFOService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_MACHINEINFO
    {
        private SY_MACHINEINFOSoapClient client = new SY_MACHINEINFOSoapClient("SY_MACHINEINFOSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_MACHINEINFO.asmx");

        public MES_SY_MACHINEINFO insert(MES_SY_MACHINEINFO model, string ptoken)
        {
            return client.insert(model, ptoken);
        }

        public MES_SY_MACHINEINFO_SELECT SELECT(MES_SY_MACHINEINFO model, string ptoken)
        {
            return client.SELECT(model, ptoken);
            
        }
        public MES_SY_MACHINEINFO_SELECTBBXX SELECT_BBXX(MES_SY_MACHINEINFO_BBXX model,string ptoken)
        {
            return client.SELECT_BBXX(model, ptoken);
        }

    }
}
