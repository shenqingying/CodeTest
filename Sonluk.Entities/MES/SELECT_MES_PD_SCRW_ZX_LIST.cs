﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class SELECT_MES_PD_SCRW_ZX_LIST
    {
        private List<MES_TM_TMINFO_LIST> _MES_TM_TMINFO_LIST;
        public List<MES_TM_TMINFO_LIST> MES_TM_TMINFO_LIST
        {
            get { return _MES_TM_TMINFO_LIST; }
            set { _MES_TM_TMINFO_LIST = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
