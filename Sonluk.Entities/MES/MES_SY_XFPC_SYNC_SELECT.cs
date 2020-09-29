using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_XFPC_SYNC_SELECT
    {
        private List<ZSL_BCS304> _ZSL_BCS304;

        public List<ZSL_BCS304> ZSL_BCS304
        {
            get { return _ZSL_BCS304; }
            set { _ZSL_BCS304 = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
