using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_ROLE_DEPT_LIST
    {
        private int _DEPTID;

        public int DEPTID
        {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
        private string _DEPTNAME;

        public string DEPTNAME
        {
            get { return _DEPTNAME; }
            set { _DEPTNAME = value; }
        }
    }
}
