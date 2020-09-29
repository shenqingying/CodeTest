using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_TL_TD_SELECT
    {
        private List<MES_PD_TL_TD> _MES_PD_TL_TD;

        public List<MES_PD_TL_TD> MES_PD_TL_TD
        {
            get { return _MES_PD_TL_TD; }
            set { _MES_PD_TL_TD = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
