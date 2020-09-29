using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ZS_SY_TL_SELECT
    {
        private List<MES_ZS_SY_TL> _MES_ZS_SY_TL;

        public List<MES_ZS_SY_TL> MES_ZS_SY_TL
        {
            get { return _MES_ZS_SY_TL; }
            set { _MES_ZS_SY_TL = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
