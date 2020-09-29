using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_GC_LAY
    {
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private string _GCMS;

        public string GCMS
        {
            get { return _GCMS; }
            set { _GCMS = value; }
        }

        private bool _LAY_CHECKED;

        public bool LAY_CHECKED
        {
            get { return _LAY_CHECKED; }
            set { _LAY_CHECKED = value; }
        }

        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
    }
}
