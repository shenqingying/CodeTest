using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_KQ_DEPTID_FZID
    {
        private string _DEPTJGNO;

        public string DEPTJGNO
        {
            get { return _DEPTJGNO; }
            set { _DEPTJGNO = value; }
        }
        private int _FZID;

        public int FZID
        {
            get { return _FZID; }
            set { _FZID = value; }
        }
        private string _DEPTNAME;

        public string DEPTNAME
        {
            get { return _DEPTNAME; }
            set { _DEPTNAME = value; }
        }
        private int _DEPTID;

        public int DEPTID
        {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
    }
}
