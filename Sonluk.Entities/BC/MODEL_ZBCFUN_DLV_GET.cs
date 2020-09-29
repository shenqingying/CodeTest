using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class MODEL_ZBCFUN_DLV_GET
    {
        private List<ZSL_BCST100> _ET_RETURN;

        public List<ZSL_BCST100> ET_RETURN
        {
            get { return _ET_RETURN; }
            set { _ET_RETURN = value; }
        }

        private List<ZSL_BCS010> _ET_TTXX;

        public List<ZSL_BCS010> ET_TTXX
        {
            get { return _ET_TTXX; }
            set { _ET_TTXX = value; }
        }

        private List<ZSL_BCS011> _ET_HXMXX;

        public List<ZSL_BCS011> ET_HXMXX
        {
            get { return _ET_HXMXX; }
            set { _ET_HXMXX = value; }
        }
    }
}
