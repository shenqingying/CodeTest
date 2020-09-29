using Sonluk.UI.Model.MES.ZS_SY_TLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ZS_SY_TL
    {
        private WS_MES_ZS_SY_TLSoapClient client = new WS_MES_ZS_SY_TLSoapClient("WS_MES_ZS_SY_TLSoap", AppConfig.Settings("RemoteAddress") + "MES/WS_MES_ZS_SY_TL.asmx");
        public MES_RETURN_UI INSERT(MES_ZS_SY_TL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_ZS_SY_TL_SELECT SELECT(MES_ZS_SY_TL model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE(MES_ZS_SY_TL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
