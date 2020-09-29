using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_TPINFO_SELECT
    {
        private List<ZSL_BCT009> _ET_TPINFO;

        public List<ZSL_BCT009> ET_TPINFO
        {
            get { return _ET_TPINFO; }
            set { _ET_TPINFO = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
