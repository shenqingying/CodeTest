using Sonluk.UI.Model.SSO.UserTokenService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.SSO
{
    public class UserToken
    {
        private UserTokenSoapClient client = new UserTokenSoapClient("UserTokenSoap", AppConfig.Settings("RemoteAddress") + "SSO/UserToken.asmx");

        public TokenInfo Token(string name, string password)
        {
            return client.Token(name, password);
        }

        public MenuInfo Menu(string ptoken, string parent)
        {
            return client.Menu(ptoken, parent);
        }

        public AccountInfo AcceptToken(string ptoken)
        {
            return client.AcceptToken(ptoken);
        }
    }
}
