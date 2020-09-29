using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PLDH_SBBH_SELECT
    {
        private List<MES_SY_PLDH_SBBH> _MES_SY_PLDH_SBBH;

        public List<MES_SY_PLDH_SBBH> MES_SY_PLDH_SBBH
        {
            get { return _MES_SY_PLDH_SBBH; }
            set { _MES_SY_PLDH_SBBH = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
