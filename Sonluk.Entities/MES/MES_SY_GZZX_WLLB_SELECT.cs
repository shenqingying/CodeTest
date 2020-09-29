using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_GZZX_WLLB_SELECT
    {
        private List<MES_SY_GZZX_WLLB> _MES_SY_GZZX_WLLB;

        public List<MES_SY_GZZX_WLLB> MES_SY_GZZX_WLLB
        {
            get { return _MES_SY_GZZX_WLLB; }
            set { _MES_SY_GZZX_WLLB = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
