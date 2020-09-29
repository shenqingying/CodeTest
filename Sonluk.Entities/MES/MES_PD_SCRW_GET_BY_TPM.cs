using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_SCRW_GET_BY_TPM
    {
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private string _GZZXBH;


        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }

        private string _SBBH;

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }

        private int _JLR;

        public int JLR
        {
            get { return _JLR; }
            set { _JLR = value; }
        }

        private string _TPM;

        public string TPM
        {
            get { return _TPM; }
            set { _TPM = value; }
        }
    }
}
