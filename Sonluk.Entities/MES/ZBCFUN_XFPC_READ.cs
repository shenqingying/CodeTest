using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_XFPC_READ
    {
        private List<ZSL_BCS304> _ET_CHARG;

        public List<ZSL_BCS304> ET_CHARG
        {
            get { return _ET_CHARG; }
            set { _ET_CHARG = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
