using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PLDH_PH_SELECT
    {
        private List<MES_SY_PLDH_PH> _MES_SY_PLDH_PH;

        public List<MES_SY_PLDH_PH> MES_SY_PLDH_PH
        {
            get { return _MES_SY_PLDH_PH; }
            set { _MES_SY_PLDH_PH = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
