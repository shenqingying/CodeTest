using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_YERACOUNT
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TMYEAR;

        public string TMYEAR
        {
            get { return _TMYEAR; }
            set { _TMYEAR = value; }
        }

        private int _TMCOUNT;

        public int TMCOUNT
        {
            get { return _TMCOUNT; }
            set { _TMCOUNT = value; }
        }

        private int _TMLB;

        public int TMLB
        {
            get { return _TMLB; }
            set { _TMLB = value; }
        }

        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }


        private int _LENGTH;

        public int LENGTH
        {
            get { return _LENGTH; }
            set { _LENGTH = value; }
        }
    }
}
