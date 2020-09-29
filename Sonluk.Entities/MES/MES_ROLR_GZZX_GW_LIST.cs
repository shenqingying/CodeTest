using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ROLR_GZZX_GW_LIST
    {
        private List<MES_ROLR_GZZX_GW> _MES_ROLR_GZZX_GW;

        public List<MES_ROLR_GZZX_GW> MES_ROLR_GZZX_GW
        {
            get { return _MES_ROLR_GZZX_GW; }
            set { _MES_ROLR_GZZX_GW = value; }
        }


        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
