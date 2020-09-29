using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Common
{
    public class ErrorInfo
    {
        private string _errcode;

        public string Errcode
        {
            get { return _errcode; }
            set { _errcode = value; }
        }
        private string _errmsg;

        public string Errmsg
        {
            get { return _errmsg; }
            set { _errmsg = value; }
        }
    }
}
