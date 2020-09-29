using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_MACHINEINFO_SELECT
    {
        private List<MES_SY_MACHINEINFO> _MES_SY_MACHINEINFO;

        public List<MES_SY_MACHINEINFO> MES_SY_MACHINEINFO
        {
            get { return _MES_SY_MACHINEINFO; }
            set { _MES_SY_MACHINEINFO = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
