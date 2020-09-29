using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_RYGH_SELECT
    {
        private List<MES_SY_RYGH> _MES_SY_RYGH;

        public List<MES_SY_RYGH> MES_SY_RYGH
        {
            get { return _MES_SY_RYGH; }
            set { _MES_SY_RYGH = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
