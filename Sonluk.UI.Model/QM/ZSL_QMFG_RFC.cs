using Sonluk.UI.Model.QM.ZSL_QMFG_RFCService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.QM
{
    public class ZSL_QMFG_RFC
    {
        private WS_QM_ZSL_QMFG_RFCSoapClient client = new WS_QM_ZSL_QMFG_RFCSoapClient("WS_QM_ZSL_QMFG_RFCSoap", AppConfig.Settings("RemoteAddress") + "QM/WS_QM_ZSL_QMFG_RFC.asmx");
        public ZSL_QMFM_012_SELECT ZSL_QMFM_012(ZSL_QMFM_012_SELECT model, string ptoken)
        {
            return client.ZSL_QMFM_012(model, ptoken);
        }
    }
}
