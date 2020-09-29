using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class PS_ZPSFUG_Q_LJXJ
    {
        private ZSL_PSS_OUT_LJXJ _T_OUT_HEAD;
        private PS_MSG _T_MSG;

        public PS_MSG T_MSG
        {
            get { return _T_MSG; }
            set { _T_MSG = value; }
        }
        public ZSL_PSS_OUT_LJXJ T_OUT_HEAD
        {
            get { return _T_OUT_HEAD; }
            set { _T_OUT_HEAD = value; }
        }
        private List<ZSL_PSS_OUT_LJXJ01> _T_OUT_ITEM;

        public List<ZSL_PSS_OUT_LJXJ01> T_OUT_ITEM
        {
            get { return _T_OUT_ITEM; }
            set { _T_OUT_ITEM = value; }
        }


    }
}
