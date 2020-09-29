using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_LANGUAGE_RETURNMX_SELECT
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<MES_SY_LANGUAGE_RETURNMX> _MES_SY_LANGUAGE_RETURNMX;

        public List<MES_SY_LANGUAGE_RETURNMX> MES_SY_LANGUAGE_RETURNMX
        {
            get { return _MES_SY_LANGUAGE_RETURNMX; }
            set { _MES_SY_LANGUAGE_RETURNMX = value; }
        }
    }
}
