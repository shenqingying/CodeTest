using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_XZDA_GZLB
    {
        private int _GZLBID;

        public int GZLBID
        {
            get { return _GZLBID; }
            set { _GZLBID = value; }
        }
        private string _GZLBNAME;

        public string GZLBNAME
        {
            get { return _GZLBNAME; }
            set { _GZLBNAME = value; }
        }
        private int _ZDID;

        public int ZDID
        {
            get { return _ZDID; }
            set { _ZDID = value; }
        }
        private string _ZDMS;

        public string ZDMS
        {
            get { return _ZDMS; }
            set { _ZDMS = value; }
        }
        private string _MYPW;

        public string MYPW
        {
            get { return _MYPW; }
            set { _MYPW = value; }
        }
    }
}
