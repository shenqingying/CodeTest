using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PFDH_WL
    {
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private int _PFLB;

        public int PFLB
        {
            get { return _PFLB; }
            set { _PFLB = value; }
        }

        private string _PFDH;

        public string PFDH
        {
            get { return _PFDH; }
            set { _PFDH = value; }
        }

        private string _WLH;

        public string WLH
        {
            get { return _WLH; }
            set { _WLH = value; }
        }

        private string _WLNAME;

        public string WLNAME
        {
            get { return _WLNAME; }
            set { _WLNAME = value; }
        }
    }
}
