using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class PS_ZPSFUG_Q_CGDS
    {
        private Ps_cgds _T_OUT;
        private PS_MSG _T_MSG;

        public PS_MSG T_MSG
        {
            get { return _T_MSG; }
            set { _T_MSG = value; }
        }

        public Ps_cgds T_OUT
        {
            get { return _T_OUT; }
            set { _T_OUT = value; }
        }

        private List<TLINE> _LINES;

        public List<TLINE> LINES
        {
            get { return _LINES; }
            set { _LINES = value; }
        }
    }
}
