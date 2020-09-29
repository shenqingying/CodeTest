using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_TM_TMINFO_XCTMINFO
    {
        private List<MES_TM_TMINFO_XCTMINFO_BY_TMLIST> _MES_TM_TMINFO_XCTMINFO_BY_TMLIST;

        public List<MES_TM_TMINFO_XCTMINFO_BY_TMLIST> MES_TM_TMINFO_XCTMINFO_BY_TMLIST
        {
            get { return _MES_TM_TMINFO_XCTMINFO_BY_TMLIST; }
            set { _MES_TM_TMINFO_XCTMINFO_BY_TMLIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
