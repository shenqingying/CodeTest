using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class MODEL_ZBCFUN_THLOG_READ
    {
        private List<ZSL_BCT108> _ET_THLOG;

        public List<ZSL_BCT108> ET_THLOG
        {
            get { return _ET_THLOG; }
            set { _ET_THLOG = value; }
        }

        private RETURN_MSG _RETURN_MSG;

        public RETURN_MSG RETURN_MSG
        {
            get { return _RETURN_MSG; }
            set { _RETURN_MSG = value; }
        }
    }
}
