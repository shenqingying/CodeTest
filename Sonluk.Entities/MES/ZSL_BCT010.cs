using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZSL_BCT010
    {
        private string _MANDT;

        public string MANDT
        {
            get { return _MANDT; }
            set { _MANDT = value; }
        }
        private string _TPNO;

        public string TPNO
        {
            get { return _TPNO; }
            set { _TPNO = value; }
        }
        private string _TPM;

        public string TPM
        {
            get { return _TPM; }
            set { _TPM = value; }
        }
        private int _ISDELETE;

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
    }
}
