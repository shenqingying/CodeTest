using Sonluk.Entities.BC;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SD
{
    public class ZBCFUN_KHXX_READ_RETURN
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }

        private List<ZSL_BCS111> _ET_CUSTDATA;

        public List<ZSL_BCS111> ET_CUSTDATA
        {
            get { return _ET_CUSTDATA; }
            set { _ET_CUSTDATA = value; }
        }
    }
}
