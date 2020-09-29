using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
   public class MES_SY_FJ_RWKB_SELECT
    {
        private List<MES_SY_FJ_RWKB> _MES_SY_FJ_RWKB;

        public List<MES_SY_FJ_RWKB> MES_SY_FJ_RWKB
        {
            get { return _MES_SY_FJ_RWKB; }
            set { _MES_SY_FJ_RWKB = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
