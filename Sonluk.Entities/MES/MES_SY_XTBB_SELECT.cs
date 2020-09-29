using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_XTBB_SELECT
    {
        private List<MES_SY_XTBB> _MES_SY_XTBB;

        public List<MES_SY_XTBB> MES_SY_XTBB
        {
            get { return _MES_SY_XTBB; }
            set { _MES_SY_XTBB = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
