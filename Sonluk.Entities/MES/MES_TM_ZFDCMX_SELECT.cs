using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_TM_ZFDCMX_SELECT
    {
        private List<MES_TM_ZFDCMX> _MES_TM_ZFDCMX;

        public List<MES_TM_ZFDCMX> MES_TM_ZFDCMX
        {
            get { return _MES_TM_ZFDCMX; }
            set { _MES_TM_ZFDCMX = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
