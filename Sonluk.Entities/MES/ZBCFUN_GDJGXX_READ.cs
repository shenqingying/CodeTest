using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_GDJGXX_READ
    {
        private ES_HEADER _ES_HEADER;

        public ES_HEADER ES_HEADER
        {
            get { return _ES_HEADER; }
            set { _ES_HEADER = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }

        private List<ET_BOM> _ET_BOM;

        public List<ET_BOM> ET_BOM
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
    }
}
