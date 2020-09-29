using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ET_PRPS
    {
        string _PSPNR;

        public string PSPNR
        {
            get { return _PSPNR; }
            set { _PSPNR = value; }
        }
        string _POSID;

        public string POSID
        {
            get { return _POSID; }
            set { _POSID = value; }
        }
        string _POST1;

        public string POST1
        {
            get { return _POST1; }
            set { _POST1 = value; }
        }
    }
}
