using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class STAFFDUTY_KH
    {
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        string _DUTYNAME;

        public string DUTYNAME
        {
            get { return _DUTYNAME; }
            set { _DUTYNAME = value; }
        }
        string _GNAME;

        public string GNAME
        {
            get { return _GNAME; }
            set { _GNAME = value; }
        }
    }
}
