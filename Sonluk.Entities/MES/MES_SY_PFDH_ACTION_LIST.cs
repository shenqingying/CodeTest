using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PFDH_ACTION_LIST
    {
        private List<ZSL_BCST301> _ZSL_BCST301;

        public List<ZSL_BCST301> ZSL_BCST301
        {
            get { return _ZSL_BCST301; }
            set { _ZSL_BCST301 = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
