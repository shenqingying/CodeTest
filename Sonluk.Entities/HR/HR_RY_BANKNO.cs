using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_RY_BANKNO
    {
        private int _BANKNOID;

        public int BANKNOID
        {
            get { return _BANKNOID; }
            set { _BANKNOID = value; }
        }
        private int _RYID;

        public int RYID
        {
            get { return _RYID; }
            set { _RYID = value; }
        }
        private int _ZHLB;

        public int ZHLB
        {
            get { return _ZHLB; }
            set { _ZHLB = value; }
        }
        private int _BANK;

        public int BANK
        {
            get { return _BANK; }
            set { _BANK = value; }
        }
        private string _BANKNO;

        public string BANKNO
        {
            get { return _BANKNO; }
            set { _BANKNO = value; }
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
        private string _GH;

        public string GH
        {
            get { return _GH; }
            set { _GH = value; }
        }
        private string _DEPT;

        public string DEPT
        {
            get { return _DEPT; }
            set { _DEPT = value; }
        }
        private string _ZZZT;

        public string ZZZT
        {
            get { return _ZZZT; }
            set { _ZZZT = value; }
        }
    }
}
