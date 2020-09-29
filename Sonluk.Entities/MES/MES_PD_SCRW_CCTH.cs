using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_SCRW_CCTH
    {
        private int _TH;

        public int TH
        {
            get { return _TH; }
            set { _TH = value; }
        }

        private string _KSTIME;

        public string KSTIME
        {
            get { return _KSTIME; }
            set { _KSTIME = value; }
        }

        private string _JSTIME;

        public string JSTIME
        {
            get { return _JSTIME; }
            set { _JSTIME = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
