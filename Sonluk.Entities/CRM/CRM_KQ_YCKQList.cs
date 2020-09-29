using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KQ_YCKQList
    {
        string _DATE;

        public string DATE
        {
            get { return _DATE; }
            set { _DATE = value; }
        }
        bool _ISAM;

        public bool ISAM
        {
            get { return _ISAM; }
            set { _ISAM = value; }
        }
        bool _ISQD;

        public bool ISQD
        {
            get { return _ISQD; }
            set { _ISQD = value; }
        }
    }
}
