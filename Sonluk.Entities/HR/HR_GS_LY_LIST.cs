using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_GS_LY_LIST
    {
        private int _LYID;

        public int LYID
        {
            get { return _LYID; }
            set { _LYID = value; }
        }
        private string _GS;

        public string GS
        {
            get { return _GS; }
            set { _GS = value; }
        }
        private string _LYNAME;

        public string LYNAME
        {
            get { return _LYNAME; }
            set { _LYNAME = value; }
        }
        private int _ISACTION;

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }
        private string _GSNAME;

        public string GSNAME
        {
            get { return _GSNAME; }
            set { _GSNAME = value; }
        }
    }
}
