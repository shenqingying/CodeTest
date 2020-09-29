using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class CNFHLIST
    {
        List<ZSL_GXCN> _ZSL_GXCN;

        public List<ZSL_GXCN> ZSL_GXCN
        {
            get { return _ZSL_GXCN; }
            set { _ZSL_GXCN = value; }
        }
        PS_MSG _PS_MSG;

        public PS_MSG PS_MSG
        {
            get { return _PS_MSG; }
            set { _PS_MSG = value; }
        }
    }
}
