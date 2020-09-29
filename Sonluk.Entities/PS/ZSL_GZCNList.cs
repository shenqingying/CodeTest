using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ZSL_GZCNList
    {
        List<T435T> _ET_T435T;

        public List<T435T> ET_T435T
        {
            get { return _ET_T435T; }
            set { _ET_T435T = value; }
        }
        List<ZSL_GZ_VLSCH> _ZSL_GZ_VLSCH;

        public List<ZSL_GZ_VLSCH> ZSL_GZ_VLSCH
        {
            get { return _ZSL_GZ_VLSCH; }
            set { _ZSL_GZ_VLSCH = value; }
        }
        List<ZSL_GZCN> _ZSL_GZCN;

        public List<ZSL_GZCN> ZSL_GZCN
        {
            get { return _ZSL_GZCN; }
            set { _ZSL_GZCN = value; }
        }
        PS_MSG _PS_MSG;

        public PS_MSG PS_MSG
        {
            get { return _PS_MSG; }
            set { _PS_MSG = value; }
        }
    }
}
