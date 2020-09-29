using Sonluk.UI.Model.MES.SY_LANGUAGE_RETURNService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_LANGUAGE_RETURN
    {
        private WS_MES_SY_LANGUAGE_RETURNSoapClient client = new WS_MES_SY_LANGUAGE_RETURNSoapClient("WS_MES_SY_LANGUAGE_RETURNSoap", AppConfig.Settings("RemoteAddress") + "MES/WS_MES_SY_LANGUAGE_RETURN.asmx");
        public MES_RETURN_UI RETURNMX_INSERT(MES_SY_LANGUAGE_RETURNMX model, string ptoken)
        {
            MES_RETURN mr = client.RETURNMX_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI RETURNMX_UPDATE(MES_SY_LANGUAGE_RETURNMX model, string ptoken)
        {
            MES_RETURN mr = client.RETURNMX_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_LANGUAGE_RETURNMX_SELECT RETURNMX_UPDATE(MES_SY_LANGUAGE_RETURNMX[] model, string ptoken)
        {
            return client.RETURNMX_SELECT(model, ptoken);
        }
    }
}
