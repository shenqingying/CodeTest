using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
  public  class CRM_WL_TT
    {
        private int _TTID;

        public int TTID
        {
            get { return _TTID; }
            set { _TTID = value; }
        }
        private string _NUMBER;

        public string NUMBER
        {
            get { return _NUMBER; }
            set { _NUMBER = value; }
        }
        private int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private string _CJSJ;

        public string CJSJ
        {
            get { return _CJSJ; }
            set { _CJSJ = value; }
        }
        private int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        private string _BEIZ;

        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }
        string _CJSJ_BEGIN;

        public string CJSJ_BEGIN
        {
            get { return _CJSJ_BEGIN; }
            set { _CJSJ_BEGIN = value; }
        }
        string _CJSJ_END;

        public string CJSJ_END
        {
            get { return _CJSJ_END; }
            set { _CJSJ_END = value; }
        }
    }
}
