using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_KCDD_READ
    {
        private List<ZSL_BCST008> _CT_KCDD;

        public List<ZSL_BCST008> CT_KCDD
        {
            get { return _CT_KCDD; }
            set { _CT_KCDD = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
