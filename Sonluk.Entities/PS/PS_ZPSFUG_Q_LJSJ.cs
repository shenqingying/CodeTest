using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class PS_ZPSFUG_Q_LJSJ
    {
        private ZSL_PSS_OUT_LJSJ _T_OUT;
        private PS_MSG _T_MSG;

        public PS_MSG T_MSG
        {
            get { return _T_MSG; }
            set { _T_MSG = value; }
        }

        public ZSL_PSS_OUT_LJSJ T_OUT
        {
            get { return _T_OUT; }
            set { _T_OUT = value; }
        }
    }
}
