using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class MODEL_ZBCFUN_MAT_GET
    {
        private List<ZSL_BCS007> _ET_MATS;

        public List<ZSL_BCS007> ET_MATS
        {
            get { return _ET_MATS; }
            set { _ET_MATS = value; }
        }

        private List<ZSL_BCST100> _ET_RETURN;

        public List<ZSL_BCST100> ET_RETURN
        {
            get { return _ET_RETURN; }
            set { _ET_RETURN = value; }
        }
    }
}
