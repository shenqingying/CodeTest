using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_GZZX_SBH_SELECT
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<MES_SY_GZZX_SBH> _MES_SY_GZZX_SBH;

        public List<MES_SY_GZZX_SBH> MES_SY_GZZX_SBH
        {
            get { return _MES_SY_GZZX_SBH; }
            set { _MES_SY_GZZX_SBH = value; }
        }
    }
}
