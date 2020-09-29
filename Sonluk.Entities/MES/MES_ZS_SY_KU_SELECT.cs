using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ZS_SY_KU_SELECT
    {
        private List<MES_ZS_SY_KU> _MES_ZS_SY_KU;

        public List<MES_ZS_SY_KU> MES_ZS_SY_KU
        {
            get { return _MES_ZS_SY_KU; }
            set { _MES_ZS_SY_KU = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
