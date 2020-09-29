using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_SY_ZJH_LIST
    {
        private int _ZJHID;

        public int ZJHID
        {
            get { return _ZJHID; }
            set { _ZJHID = value; }
        }
        private string _GS;

        public string GS
        {
            get { return _GS; }
            set { _GS = value; }
        }
        private string _ZNAME;

        public string ZNAME
        {
            get { return _ZNAME; }
            set { _ZNAME = value; }
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
