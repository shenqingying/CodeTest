using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_RYGH_GS_SELECT
    {
        private List<MES_SY_RYGH_GS> _MES_SY_RYGH_GS;

        public List<MES_SY_RYGH_GS> MES_SY_RYGH_GS
        {
            get { return _MES_SY_RYGH_GS; }
            set { _MES_SY_RYGH_GS = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
