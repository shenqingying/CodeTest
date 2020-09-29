using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_TM_TMINFO_DELETE_IN
    {
        private string _TM;

        public string TM
        {
            get { return _TM; }
            set { _TM = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private string _YGH;

        public string YGH
        {
            get { return _YGH; }
            set { _YGH = value; }
        }
        private string _YGNAME;

        public string YGNAME
        {
            get { return _YGNAME; }
            set { _YGNAME = value; }
        }
    }
}
