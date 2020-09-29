using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_KQ_GSKQ
    {
        private string _GH;

        public string GH
        {
            get { return _GH; }
            set { _GH = value; }
        }
        private string _DEPTID;

        public string DEPTID
        {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }

        private string _KQRQKS;

        public string KQRQKS
        {
            get { return _KQRQKS; }
            set { _KQRQKS = value; }
        }
        private string _KQRQJS;

        public string KQRQJS
        {
            get { return _KQRQJS; }
            set { _KQRQJS = value; }
        }
        private string _GS;

        public string GS
        {
            get { return _GS; }
            set { _GS = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
    }
}
