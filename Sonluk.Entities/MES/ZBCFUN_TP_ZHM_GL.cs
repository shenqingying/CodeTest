using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_TP_ZHM_GL
    {
        private List<ZSL_BCT012> _IT_TPZHNO_GL;

        public List<ZSL_BCT012> IT_TPZHNO_GL
        {
            get { return _IT_TPZHNO_GL; }
            set { _IT_TPZHNO_GL = value; }
        }
        private List<ZSL_BCT011> _ET_TPZHNO;

        public List<ZSL_BCT011> ET_TPZHNO
        {
            get { return _ET_TPZHNO; }
            set { _ET_TPZHNO = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
