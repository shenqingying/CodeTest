using Sonluk.UI.Model.MES.BAT_SPECS_SAMPService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class BAT_SPECS_SAMP
    {
        private BAT_SPECS_SAMPSoapClient client = new BAT_SPECS_SAMPSoapClient("BAT_SPECS_SAMPSoap", AppConfig.Settings("RemoteAddress") + "MES/BAT_SPECS_SAMP.asmx");

        public MES_DCCCCYSJ_SELECT SELECT(MES_DCCCCYSJ model, String token)
        {
            return client.SELECT(model, token);
        }

        public MES_RETURN_UI INSERT(MES_DCCCCYSJ model, String token)
        {
            MES_RETURN mr = client.INSERT(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE(MES_DCCCCYSJ model, String token)
        {
            MES_RETURN mr = client.UPDATE(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(int RI, String token)
        {
            MES_RETURN mr = client.DELETE(RI, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
