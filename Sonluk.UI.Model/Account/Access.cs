using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Utility;
using Sonluk.UI.Model.Account.AccessService;

namespace Sonluk.UI.Model.Account
{
    public class Access
    {

        private AccessSoapClient client = new AccessSoapClient("AccessSoap", AppConfig.Settings("RemoteAddress") + "Account/Access.asmx");

        public AccountInfo SignIn(string signInName, string password)
        {
            return client.SignIn(signInName, password);
        }
        public AccountInfo SignInSS0(string signInName, string password,string url)
        {
            return client.SignInSS0(signInName, password,url);
        }
        

        public bool ChangePassword(string signInName, string password, string newPassword)
        {
            return client.ChangePassword(signInName, password, newPassword);
        }
       
    }
}
