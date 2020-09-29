using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_TM_ZFDCMX
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TM;

        public string TM
        {
            get { return _TM; }
            set { _TM = value; }
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

        private int _SL;

        public int SL
        {
            get { return _SL; }
            set { _SL = value; }
        }
    }
}
