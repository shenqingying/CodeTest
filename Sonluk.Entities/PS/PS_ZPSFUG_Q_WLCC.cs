using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class PS_ZPSFUG_Q_WLCC
    {
        private ZSL_PSS_OUT_WLCC _T_OUT;
        private PS_MSG _T_MSG;

        public ZSL_PSS_OUT_WLCC T_OUT
        {
            get { return _T_OUT; }
            set { _T_OUT = value; }
        }

        public PS_MSG T_MSG
        {
            get { return _T_MSG; }
            set { _T_MSG = value; }
        }


    }
}
