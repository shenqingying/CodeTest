using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class RktjInfo
    {

        private List<ZSL_BCST108> et_ttxx;

        public List<ZSL_BCST108> ET_TTXX
        {
            get { return et_ttxx; }
            set { et_ttxx = value; }
        }

        private List<ZSL_BCST108> et_mxxx;        

        public List<ZSL_BCST108> ET_MXXX
        {
            get { return et_mxxx; }
            set { et_mxxx = value; }
        }

    }
}
