using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ZS_SY_JL_MX_SELECT
    {
        private List<MES_ZS_SY_JL_MX> _MES_ZS_SY_JL_MX;

        public List<MES_ZS_SY_JL_MX> MES_ZS_SY_JL_MX
        {
            get { return _MES_ZS_SY_JL_MX; }
            set { _MES_ZS_SY_JL_MX = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
