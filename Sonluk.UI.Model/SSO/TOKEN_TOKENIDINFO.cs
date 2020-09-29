using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.SSO.TOKEN_TOKENIDINFOService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.SSO
{
    public class TOKEN_TOKENIDINFO
    {
        private WS_SSO_TOKEN_TOKENIDINFOSoapClient client = new WS_SSO_TOKEN_TOKENIDINFOSoapClient("WS_SSO_TOKEN_TOKENIDINFOSoap", AppConfig.Settings("RemoteAddress") + "SSO/WS_SSO_TOKEN_TOKENIDINFO.asmx");
        public MES_RETURN_UI SELECT(string TOKENID)
        {
            MES_RETURN mr = client.SELECT(TOKENID);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public SSO_TOKEN_USERNAMEDY_SELECT USERNAMEDY_SELECT(SSO_TOKEN_USERNAMEDY model, string ptoken)
        {
            return client.USERNAMEDY_SELECT(model, ptoken);
        }
    }
}
