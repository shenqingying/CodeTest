using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZBCFUN_GDLIST_READ
    {
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
    }
}
