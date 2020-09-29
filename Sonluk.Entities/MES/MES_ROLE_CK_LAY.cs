using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ROLE_CK_LAY
    {
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private string _CKDM;

        public string CKDM
        {
            get { return _CKDM; }
            set { _CKDM = value; }
        }

        private string _CKMS;

        public string CKMS
        {
            get { return _CKMS; }
            set { _CKMS = value; }
        }

        private int _ROLEID;

        public int ROLEID
        {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }

        private bool _LAY_CHECKED;

        public bool LAY_CHECKED
        {
            get { return _LAY_CHECKED; }
            set { _LAY_CHECKED = value; }
        }
    }
}
