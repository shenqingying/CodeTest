using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_DEPTPUSHRY
    {
        int _DEPTID;

        public int DEPTID
        {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }

       
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }

        string _DEPTNAME;

        public string DEPTNAME
        {
            get { return _DEPTNAME; }
            set { _DEPTNAME = value; }
        }
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
    }
}
