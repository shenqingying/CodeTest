using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SSO
{
    public class SSO_TOKEN_TOKENIDINFO
    {
        private int _TOKENID;

        public int TOKENID
        {
            get { return _TOKENID; }
            set { _TOKENID = value; }
        }
        private string _TOKEN;

        public string TOKEN
        {
            get { return _TOKEN; }
            set { _TOKEN = value; }
        }
    }
}
