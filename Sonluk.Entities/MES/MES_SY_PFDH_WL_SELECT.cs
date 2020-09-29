using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PFDH_WL_SELECT
    {
        private List<MES_SY_PFDH_WL> _MES_SY_PFDH_WL;

        public List<MES_SY_PFDH_WL> MES_SY_PFDH_WL
        {
            get { return _MES_SY_PFDH_WL; }
            set { _MES_SY_PFDH_WL = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
