using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ZS_SY_CLPB_WL_SELECT
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<MES_ZS_SY_CLPB_WL> _MES_ZS_SY_CLPB_WL;

        public List<MES_ZS_SY_CLPB_WL> MES_ZS_SY_CLPB_WL
        {
            get { return _MES_ZS_SY_CLPB_WL; }
            set { _MES_ZS_SY_CLPB_WL = value; }
        }
    }
}
