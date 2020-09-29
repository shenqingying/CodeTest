using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_TM_TMINFO_INSERT_RETURN
    {
        private List<SELECT_MES_TM_TMINFO_PRINT> _SELECT_MES_TM_TMINFO_PRINT;

        public List<SELECT_MES_TM_TMINFO_PRINT> SELECT_MES_TM_TMINFO_PRINT
        {
            get { return _SELECT_MES_TM_TMINFO_PRINT; }
            set { _SELECT_MES_TM_TMINFO_PRINT = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
