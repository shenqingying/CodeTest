using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_SBBHDEVICETYPE
    {
        string _SBBH;

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }
        int _DID;

        public int DID
        {
            get { return _DID; }
            set { _DID = value; }
        }
    }
}
