using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    class MES_SY_MACBB_LIST
    {
        private int _PBID;

        public int PBID
        {
            get { return _PBID; }
            set { _PBID = value; }
        }

        private int _SYID;

        public int SYID
        {
            get { return _SYID; }
            set { _SYID = value; }
        }

        private string _NEWBB;

        public string NEWBB
        {
            get { return _NEWBB; }
            set { _NEWBB = value; }
        }

        private string _WKINFO;

        public string WKINFO
        {
            get { return _WKINFO; }
            set { _WKINFO = value; }
        }
    }
}
