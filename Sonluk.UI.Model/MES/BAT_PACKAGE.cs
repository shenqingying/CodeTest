using Sonluk.UI.Model.MES.BAT_PACKAGEService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class BAT_PACKAGE
    {
        private BAT_PACKAGESoapClient client = new BAT_PACKAGESoapClient("BAT_PACKAGESoap", AppConfig.Settings("RemoteAddress") + "MES/BAT_PACKAGE.asmx");

        public MES_PD_GD_PACKINFO_SELECT SELECT_LIST(MES_PD_GD_PACKINFO_SEARCH model, string token, int STAFFID)
        {
            return client.SELECT_LIST(model, token, STAFFID);
        }

        public MES_PD_GD_PACKINFO SELECT_SINGLE(string GDDH, string token, int STAFFID)
        {
            return client.SELECT_SINGLE(GDDH, token, STAFFID);
        }

        public MES_RETURN_UI COVER(MES_PD_GD_PACKINFO model, string token, int STAFFID)
        {
            MES_RETURN mr = client.COVER(model, token, STAFFID);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(string GDDH, string token, int STAFFID)
        {
            MES_RETURN mr = client.DELETE(GDDH, token, STAFFID);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
