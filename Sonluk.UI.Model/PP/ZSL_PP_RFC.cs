using Sonluk.UI.Model.MES.ZSL_PP_RFCService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.PP
{
    public class ZSL_PP_RFC
    {
        private ZSL_PP_RFCSoapClient client = new ZSL_PP_RFCSoapClient("ZSL_PP_RFCSoap", AppConfig.Settings("RemoteAddress") + "PP/ZSL_PP_RFC.asmx");
        public ZPP_BZZYD_READ_RESULT[] ZPP_BZZYD_READ(string[] IV_AUFNR)
        {
            return client.ZPP_BZZYD_READ(IV_AUFNR);
        }
    }
}
