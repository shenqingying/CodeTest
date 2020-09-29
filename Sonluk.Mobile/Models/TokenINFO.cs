using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Mobile.Models
{
    public class TokenINFO
    {
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private string _token;

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        private string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
    }
}