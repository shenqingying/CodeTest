using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ROLE_GZZX
    {
        private int _ROLEID;

        public int ROLEID
        {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }

        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private string _GZZXBH;

        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }
    }
}
