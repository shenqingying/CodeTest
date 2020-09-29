using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class MANUALPATH_SELECT
    {
        List<EM_SY_MANUALPATH> _EM_SY_MANUALPATH;

        public List<EM_SY_MANUALPATH> EM_SY_MANUALPATH
        {
            get { return _EM_SY_MANUALPATH; }
            set { _EM_SY_MANUALPATH = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
