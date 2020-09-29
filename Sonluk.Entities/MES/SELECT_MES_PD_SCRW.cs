using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class SELECT_MES_PD_SCRW
    {
        private List<MES_PD_SCRW_LIST> _MES_PD_SCRW_LIST;

        public List<MES_PD_SCRW_LIST> MES_PD_SCRW_LIST
        {
            get { return _MES_PD_SCRW_LIST; }
            set { _MES_PD_SCRW_LIST = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }

        private MES_TM_TMINFO_INSERT_RETURN _TMINFO;

        public MES_TM_TMINFO_INSERT_RETURN TMINFO
        {
            get { return _TMINFO; }
            set { _TMINFO = value; }
        }

    }
}
