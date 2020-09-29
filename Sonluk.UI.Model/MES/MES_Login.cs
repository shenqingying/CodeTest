using Sonluk.UI.Model.MES.MES_LoginService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class MES_Login
    {
        private MES_LoginSoapClient client = new MES_LoginSoapClient("MES_LoginSoap", AppConfig.Settings("RemoteAddress") + "MES/MES_Login.asmx");


        public MES_LoginINFO Login(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID)
        {
            return client.Login(name, password, OPENID, WXDLCS, PC, WX, GCID);
        }
        public MES_LoginINFO Login_language(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID, int LANGUAGEID)
        {
            return client.Login_language(name, password, OPENID, WXDLCS, PC, WX, GCID, LANGUAGEID);
        }
    }
}
