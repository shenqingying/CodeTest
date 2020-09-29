using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class ZBCFUN_DRFDD_DT_RETURN
    {
        private List<ZSL_BCS113> _ET_ORDERDATA;

        public List<ZSL_BCS113> ET_ORDERDATA
        {
            get { return _ET_ORDERDATA; }
            set { _ET_ORDERDATA = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
