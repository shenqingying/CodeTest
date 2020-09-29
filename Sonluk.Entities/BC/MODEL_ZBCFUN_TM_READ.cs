using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class MODEL_ZBCFUN_TM_READ
    {
        private List<ZSL_BCT100> _ET_TM;

        public List<ZSL_BCT100> ET_TM
        {
            get { return _ET_TM; }
            set { _ET_TM = value; }
        }

        private RETURN_MSG _RETURN_MSG;

        public RETURN_MSG RETURN_MSG
        {
            get { return _RETURN_MSG; }
            set { _RETURN_MSG = value; }
        }
    }
}
