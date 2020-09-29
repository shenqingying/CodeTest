using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PFDH_LIST
    {
        private List<MES_SY_PFDH> _MES_SY_PFDH;

        public List<MES_SY_PFDH> MES_SY_PFDH
        {
            get { return _MES_SY_PFDH; }
            set { _MES_SY_PFDH = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
