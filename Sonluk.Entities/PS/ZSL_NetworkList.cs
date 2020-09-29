using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ZSL_NetworkList
    {
        List<ZSL_NETWORK> _ZSL_NETWORK;

        public List<ZSL_NETWORK> ZSL_NETWORK
        {
            get { return _ZSL_NETWORK; }
            set { _ZSL_NETWORK = value; }
        }
        PS_MSG _PS_MSG;

        public PS_MSG PS_MSG
        {
            get { return _PS_MSG; }
            set { _PS_MSG = value; }
        }
    }
}
