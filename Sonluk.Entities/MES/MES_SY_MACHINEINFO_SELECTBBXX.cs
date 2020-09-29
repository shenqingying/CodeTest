using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_MACHINEINFO_SELECTBBXX
    {
        private List<MES_SY_MACHINEINFO_BBXX> _MES_SY_MACHINEINFO_BBXX;

        public List<MES_SY_MACHINEINFO_BBXX> MES_SY_MACHINEINFO_BBXX
        {
            get { return _MES_SY_MACHINEINFO_BBXX; }
            set { _MES_SY_MACHINEINFO_BBXX = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
