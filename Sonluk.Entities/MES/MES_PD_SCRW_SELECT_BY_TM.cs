using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_SCRW_SELECT_BY_TM
    {
        private string _SBBH;

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }
        private string _ZPRQ;

        public string ZPRQ
        {
            get { return _ZPRQ; }
            set { _ZPRQ = value; }
        }
        private string _TM;

        public string TM
        {
            get { return _TM; }
            set { _TM = value; }
        }
    }
}
