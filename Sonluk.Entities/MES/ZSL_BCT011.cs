using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZSL_BCT011
    {
        private string _MANDT;

        public string MANDT
        {
            get { return _MANDT; }
            set { _MANDT = value; }
        }
        private string _TPZHNO;

        public string TPZHNO
        {
            get { return _TPZHNO; }
            set { _TPZHNO = value; }
        }
        private int _ISDELETE;

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
        private int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private string _CJRNAME;

        public string CJRNAME
        {
            get { return _CJRNAME; }
            set { _CJRNAME = value; }
        }
        private string _CJRQ;

        public string CJRQ
        {
            get { return _CJRQ; }
            set { _CJRQ = value; }
        }
        private string _CJSJ;

        public string CJSJ
        {
            get { return _CJSJ; }
            set { _CJSJ = value; }
        }
    }
}
