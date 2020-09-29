using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class ZMMFUN_PURBS_READ
    {
        List<ZSL_BCS303_BS> _ZSL_BCS303_BS;

        public List<ZSL_BCS303_BS> ZSL_BCS303_BS
        {
            get { return _ZSL_BCS303_BS; }
            set { _ZSL_BCS303_BS = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
