using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_DEVICETYPE
    {
        int _DID;

        public int DID
        {
            get { return _DID; }
            set { _DID = value; }
        }
        string _DMS;

        public string DMS
        {
            get { return _DMS; }
            set { _DMS = value; }
        }
        int _XH;

        public int XH
        {
            get { return _XH; }
            set { _XH = value; }
        }
        string _BZ;

        public string BZ
        {
            get { return _BZ; }
            set { _BZ = value; }
        }
        int _ISDELETE;

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
    }
}
