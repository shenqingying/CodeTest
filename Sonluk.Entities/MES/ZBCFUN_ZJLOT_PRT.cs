using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_ZJLOT_PRT
    {
        private ZSL_BCT304_LOT _ES_LOT;

        public ZSL_BCT304_LOT ES_LOT
        {
            get { return _ES_LOT; }
            set { _ES_LOT = value; }
        }

        private List<ZSL_BCT304_LOT> _ET_PLDH;

        public List<ZSL_BCT304_LOT> ET_PLDH
        {
            get { return _ET_PLDH; }
            set { _ET_PLDH = value; }
        }

        private List<ZSL_BCST024_PO> _ET_POLIST;

        public List<ZSL_BCST024_PO> ET_POLIST
        {
            get { return _ET_POLIST; }
            set { _ET_POLIST = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
