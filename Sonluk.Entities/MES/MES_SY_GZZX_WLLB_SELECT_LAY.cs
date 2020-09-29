using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_GZZX_WLLB_SELECT_LAY
    {
        private List<MES_SY_GZZX_WLLB_LAY> _MES_SY_GZZX_WLLB_LAY;

        public List<MES_SY_GZZX_WLLB_LAY> MES_SY_GZZX_WLLB_LAY
        {
            get { return _MES_SY_GZZX_WLLB_LAY; }
            set { _MES_SY_GZZX_WLLB_LAY = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
