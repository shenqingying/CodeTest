using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class PickingtaskInfo
    {
        private int ev_ljs;
        private int ev_ywcs;
        private List<ZSL_BCST106> zsl_bcst106;

        public int Ev_ljs
        {
            get { return ev_ljs; }
            set { ev_ljs = value; }
        }

        public int Ev_ywcs
        {
            get { return ev_ywcs; }
            set { ev_ywcs = value; }
        }

        public List<ZSL_BCST106> Zsl_bcs106
        {
            get { return zsl_bcst106; }
            set { zsl_bcst106 = value; }
        }
    }
}
