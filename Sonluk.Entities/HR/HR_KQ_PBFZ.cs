using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_KQ_PBFZ
    {
        private int _FZID;

        public int FZID
        {
            get { return _FZID; }
            set { _FZID = value; }
        }
        private string _FZNAME;

        public string FZNAME
        {
            get { return _FZNAME; }
            set { _FZNAME = value; }
        }
        private int _ISACTION;

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }
        private int _WORKDAY;

        public int WORKDAY
        {
            get { return _WORKDAY; }
            set { _WORKDAY = value; }
        }
        private int _FREEDAY;

        public int FREEDAY
        {
            get { return _FREEDAY; }
            set { _FREEDAY = value; }
        }
        private int _ISGLJR;

        public int ISGLJR
        {
            get { return _ISGLJR; }
            set { _ISGLJR = value; }
        }
        private int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private int _XGR;

        public int XGR
        {
            get { return _XGR; }
            set { _XGR = value; }
        }
    }
}
