using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class ZBCFUN_DRFDD_CRT_RETURN
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private ZSL_BCS113 _ES_ORDERDATA;

        public ZSL_BCS113 ES_ORDERDATA
        {
            get { return _ES_ORDERDATA; }
            set { _ES_ORDERDATA = value; }
        }
    }
}
