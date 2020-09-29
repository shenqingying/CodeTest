using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_SYS_CS
    {
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        string _CSNAME;

        public string CSNAME
        {
            get { return _CSNAME; }
            set { _CSNAME = value; }
        }
        int _CS;

        public int CS
        {
            get { return _CS; }
            set { _CS = value; }
        }
    }
}
