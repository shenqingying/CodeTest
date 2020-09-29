using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_SELECT_BY_PFDH
    {
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

        private string _PFDH;

        public string PFDH
        {
            get { return _PFDH; }
            set { _PFDH = value; }
        }

        private string _RQ;

        public string RQ
        {
            get { return _RQ; }
            set { _RQ = value; }
        }

        private string _GZXXBH;

        public string GZXXBH
        {
            get { return _GZXXBH; }
            set { _GZXXBH = value; }
        }
    }
}
