using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_DCXH_COUNT
    {
        private int _DCXHID;

        public int DCXHID
        {
            get { return _DCXHID; }
            set { _DCXHID = value; }
        }

        private string _DCXH;

        public string DCXH
        {
            get { return _DCXH; }
            set { _DCXH = value; }
        }

        private int _SL;

        public int SL
        {
            get { return _SL; }
            set { _SL = value; }
        }

        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
    }
}
