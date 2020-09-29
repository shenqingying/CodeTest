using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_ROLE_DEPT
    {
        private int _DEPTID;

        public int DEPTID
        {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
    }
}
