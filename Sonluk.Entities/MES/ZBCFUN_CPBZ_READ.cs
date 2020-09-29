using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_CPBZ_READ
    {
        private ZSL_BCS003 _ES_HEADER;

        public ZSL_BCS003 ES_HEADER
        {
            get { return _ES_HEADER; }
            set { _ES_HEADER = value; }
        }

        private List<ZSL_BCS302_B> _ET_BOM;

        public List<ZSL_BCS302_B> ET_BOM
        {
            get { return _ET_BOM; }
            set { _ET_BOM = value; }
        }

        private List<ZSL_BCST302_R> _ET_RT;

        public List<ZSL_BCST302_R> ET_RT
        {
            get { return _ET_RT; }
            set { _ET_RT = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
