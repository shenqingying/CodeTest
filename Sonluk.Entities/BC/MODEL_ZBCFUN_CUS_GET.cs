using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class MODEL_ZBCFUN_CUS_GET
    {
        private List<ZSL_BCS009> _ET_CUSS;

        public List<ZSL_BCS009> ET_CUSS
        {
            get { return _ET_CUSS; }
            set { _ET_CUSS = value; }
        }

        private List<ZSL_BCST100> _ET_RETURN;

        public List<ZSL_BCST100> ET_RETURN
        {
            get { return _ET_RETURN; }
            set { _ET_RETURN = value; }
        }
    }
}
