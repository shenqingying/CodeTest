using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_DEVICE_CONTRACT
    {
        int _RYID;

        public int RYID
        {
            get { return _RYID; }
            set { _RYID = value; }
        }
        string _GZZXBH;

        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }

       
        string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
    }
}
