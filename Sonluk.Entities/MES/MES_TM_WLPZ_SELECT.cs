using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_TM_WLPZ_SELECT
    {
        private List<MES_TM_WLPZ> _MES_TM_WLPZ;

        public List<MES_TM_WLPZ> MES_TM_WLPZ
        {
            get { return _MES_TM_WLPZ; }
            set { _MES_TM_WLPZ = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
