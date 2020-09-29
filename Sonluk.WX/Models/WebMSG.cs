using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.WX.Models
{
    public class WebMSG
    {
        int _KEY;

        public int KEY
        {
            get { return _KEY; }
            set { _KEY = value; }
        }
        string _MSG;

        public string MSG
        {
            get { return _MSG; }
            set { _MSG = value; }
        }
    }
}