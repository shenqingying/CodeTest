using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_TM_TMINFO_INSERT_GL
    {
        private MES_TM_TMINFO _MES_TM_TMINFO;

        public MES_TM_TMINFO MES_TM_TMINFO
        {
            get { return _MES_TM_TMINFO; }
            set { _MES_TM_TMINFO = value; }
        }

        private List<MES_TM_GL> _MES_TM_GL;

        public List<MES_TM_GL> MES_TM_GL
        {
            get { return _MES_TM_GL; }
            set { _MES_TM_GL = value; }
        }
    }
}
