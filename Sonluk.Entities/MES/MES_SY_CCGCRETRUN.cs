using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_CCGCRETRUN
    {
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
        private string _CCGC;

        public string CCGC
        {
            get { return _CCGC; }
            set { _CCGC = value; }
        }
        private string _TYPE;

        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        private string _MESSAGE;

        public string MESSAGE
        {
            get { return _MESSAGE; }
            set { _MESSAGE = value; }
        }
    }
}
