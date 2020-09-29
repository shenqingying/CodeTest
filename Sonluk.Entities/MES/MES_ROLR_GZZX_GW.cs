using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ROLR_GZZX_GW
    {
        private int _ROLEID;

        public int ROLEID
        {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }

        private int _GWID;

        public int GWID
        {
            get { return _GWID; }
            set { _GWID = value; }
        }

        private string _GWNAME;

        public string GWNAME
        {
            get { return _GWNAME; }
            set { _GWNAME = value; }
        }

        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private bool _LAY_CHECKED;

        public bool LAY_CHECKED
        {
            get { return _LAY_CHECKED; }
            set { _LAY_CHECKED = value; }
        }
    }
}
