using Sonluk.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_LoginInfo
    {
        TokenInfo _TokenInfo;

        public TokenInfo TokenInfo
        {
            get { return _TokenInfo; }
            set { _TokenInfo = value; }
        }
        List<CRM_JURISDICTION_GROUP> _JURISDICTION_GROUP;

        public List<CRM_JURISDICTION_GROUP> JURISDICTION_GROUP
        {
            get { return _JURISDICTION_GROUP; }
            set { _JURISDICTION_GROUP = value; }
        }

      


    }
}
