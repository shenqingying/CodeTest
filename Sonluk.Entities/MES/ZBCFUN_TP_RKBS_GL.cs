using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_TP_RKBS_GL
    {
        private List<ZSL_BCT010> _IT_TPNO_GL;

        public List<ZSL_BCT010> IT_TPNO_GL
        {
            get { return _IT_TPNO_GL; }
            set { _IT_TPNO_GL = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
