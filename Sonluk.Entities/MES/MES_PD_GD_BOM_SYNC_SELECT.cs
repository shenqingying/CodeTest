using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_BOM_SYNC_SELECT
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<ZSL_BCS302_B> _ZSL_BCS302_B;

        public List<ZSL_BCS302_B> ZSL_BCS302_B
        {
            get { return _ZSL_BCS302_B; }
            set { _ZSL_BCS302_B = value; }
        }
    }
}
