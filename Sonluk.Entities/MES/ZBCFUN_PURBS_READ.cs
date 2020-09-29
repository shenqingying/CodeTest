using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_PURBS_READ
    {
        private List<ZSL_BCS303_BS> _ET_PURBS;

        public List<ZSL_BCS303_BS> ET_PURBS
        {
            get { return _ET_PURBS; }
            set { _ET_PURBS = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
