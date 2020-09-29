using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ROLE_ASSEMBLE_LAY_SELECT
    {
        private List<MES_ROLE_ASSEMBLE_LAY> _MES_ROLE_ASSEMBLE_LAY;

        public List<MES_ROLE_ASSEMBLE_LAY> MES_ROLE_ASSEMBLE_LAY
        {
            get { return _MES_ROLE_ASSEMBLE_LAY; }
            set { _MES_ROLE_ASSEMBLE_LAY = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
