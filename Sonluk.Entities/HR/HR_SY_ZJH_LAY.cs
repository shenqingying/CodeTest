using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_SY_ZJH_LAY
    {
        private int _ZJHID;

        public int ZJHID
        {
            get { return _ZJHID; }
            set { _ZJHID = value; }
        }
        private int _LYID;

        public int LYID
        {
            get { return _LYID; }
            set { _LYID = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private string _GS;

        public string GS
        {
            get { return _GS; }
            set { _GS = value; }
        }
        private int _ISMR;

        public int ISMR
        {
            get { return _ISMR; }
            set { _ISMR = value; }
        }
    }
}
