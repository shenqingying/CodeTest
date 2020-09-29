using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_TL_DELETE_IN
    {
        private int _TMTLID;

        public int TMTLID
        {
            get { return _TMTLID; }
            set { _TMTLID = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private string _GH;

        public string GH
        {
            get { return _GH; }
            set { _GH = value; }
        }
        private string _GHNAME;

        public string GHNAME
        {
            get { return _GHNAME; }
            set { _GHNAME = value; }
        }
    }
}
