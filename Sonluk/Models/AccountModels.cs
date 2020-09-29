using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.UI.Model.Account;

namespace Sonluk.Models
{
    public class AccountModels
    {
        private Access _Access;

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