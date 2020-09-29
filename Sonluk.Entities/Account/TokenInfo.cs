using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Account
{
    public class TokenInfo
    {
        private string _access_token;
        private string _expires_in;

        public string access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }

        public string expires_in
        {
            get { return _expires_in; }
            set { _expires_in = value; }
        }

        private string _MSG;

        public string MSG
        {
            get { return _MSG; }
            set { _MSG = value; }
        }

        private string _MESSAGE;

        public string MESSAGE
        {
            get { return _MESSAGE; }
            set { _MESSAGE = value; }
        }


        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }

        private string _TOKENID;

        public string TOKENID
        {
            get { return _TOKENID; }
            set { _TOKENID = value; }
        }

    }
}
