using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.UI.Model.Account;
using Sonluk.UI.Model.SSO;

namespace Sonluk.PC.Models
{
    public class AccountModels
    {
        private Access _Access;
        private UserToken _UserToken;

        public UserToken UserToken
        {
            get
            {
                if (_UserToken == null)
                    _UserToken = new UserToken();
                return _UserToken;
            }
            set { _UserToken = value; }
        }

        public Access Access
        {
            get
            {
                if (_Access == null)
                    _Access = new Access();
                return _Access;
            }
            set { _Access = value; }
        }
    }
}