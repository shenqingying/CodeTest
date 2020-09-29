using Sonluk.UI.Model.MES.BAT_SPECSService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class BAT_SPECS
    {
        private BAT_SPECSSoapClient client = new BAT_SPECSSoapClient("BAT_SPECSSoap", AppConfig.Settings("RemoteAddress") + "MES/BAT_SPECS.asmx");

        public MES_DCBZ_SELECT SELECT_SPECS_FULL(MES_DCBZ model, String token)
        {
            return client.SELECT_SPECS_FULL(model, token);
        }

        public MES_DCBZ_SELECT SELECT_LIST(MES_DCBZ model, String token)
        {
            return client.SELECT_LIST(model, token);
        }

        public MES_DCBZ_SELECT SELECT_LIST_LEFT(string DCXH, String token)
        {
            return client.SELECT_LIST_LEFT(DCXH, token);
        }

        public MES_RETURN_UI INSERT_FULL(MES_DCBZ model, String token)
        {
            MES_RETURN mr = client.INSERT_FULL(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE(MES_DCBZ model, String token)
        {
            MES_RETURN mr = client.UPDATE(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(string DCXH, String token)
        {
            MES_RETURN mr = client.DELETE(DCXH, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_DCBZ_SELECT SELECT_SPECS(MES_DCBZ model, String token)
        {
            return client.SELECT_SPECS(model, token);
        }

        public MES_DCBZ_SELECT SELECT_PERFOR(MES_DCBZ model, String token)
        {
            return client.SELECT_PERFOR(model, token);
        }
    }
}
