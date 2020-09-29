using Sonluk.UI.Model.MES.SY_LANGUAGE_YMService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_LANGUAGE_YM
    {
        private WS_MES_SY_LANGUAGE_YMSoapClient client = new WS_MES_SY_LANGUAGE_YMSoapClient("WS_MES_SY_LANGUAGE_YMSoap", AppConfig.Settings("RemoteAddress") + "MES/WS_MES_SY_LANGUAGE_YM.asmx");
        public MES_SY_LANGUAGE_TABLEZD_SELECT SELECT_TABLEZD(MES_SY_LANGUAGE_TABLEZD model, string ptoken)
        {
            return client.SELECT_TABLEZD(model, ptoken);
        }
    }
}
