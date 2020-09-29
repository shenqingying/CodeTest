using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ROLE_ASSEMBLE_SELECT
    {
        private List<MES_ROLE_ASSEMBLE> _MES_ROLE_ASSEMBLE;

        public List<MES_ROLE_ASSEMBLE> MES_ROLE_ASSEMBLE
        {
            get { return _MES_ROLE_ASSEMBLE; }
            set { _MES_ROLE_ASSEMBLE = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
