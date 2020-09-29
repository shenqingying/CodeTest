using Sonluk.UI.Model.BC.UserService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.BC
{
    public class User
    {
        private UserSoapClient client = new UserSoapClient("UserSoap", AppConfig.Settings("RemoteAddress") + "BC/User.asmx");

        public UserInfo Read(string signInName)
        {
            return client.Read(signInName);
        }
    }
}
