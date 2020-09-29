using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class MODEL_ZBCFUN_ORT_GET
    {
        private List<ZSL_BCS008> _ET_ORTS;

        public List<ZSL_BCS008> ET_ORTS
        {
            get { return _ET_ORTS; }
            set { _ET_ORTS = value; }
        }


        private List<ZSL_BCST100> _ET_RETURN;

        public List<ZSL_BCST100> ET_RETURN
        {
            get { return _ET_RETURN; }
            set { _ET_RETURN = value; }
        }
    }
}
