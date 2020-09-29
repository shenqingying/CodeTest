using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class WBSPARMS
    {
        List<ET_PRPS> _ET_PRPS;

        public List<ET_PRPS> ET_PRPS
        {
            get { return _ET_PRPS; }
            set { _ET_PRPS = value; }
        }
        List<ET_TCNRFPT> _ET_TCNRFPT;

        public List<ET_TCNRFPT> ET_TCNRFPT
        {
            get { return _ET_TCNRFPT; }
            set { _ET_TCNRFPT = value; }
        }
        PS_MSG _PS_MSG;

        public PS_MSG PS_MSG
        {
            get { return _PS_MSG; }
            set { _PS_MSG = value; }
        }
    }
}
