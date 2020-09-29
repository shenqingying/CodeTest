using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class DaoRuMsg
    {

        private string _msg;

        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        private string _info;

        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }

        public string data { get => _data; set => _data = value; }

        string _data;

    }
}