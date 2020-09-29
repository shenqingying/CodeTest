using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_STAFFIDBINDPB
    {
        private int _STAFFID;  //STAFFID

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private int _PBID;  //PBID

        public int PBID
        {
            get { return _PBID; }
            set { _PBID = value; }
        }

    }
}
