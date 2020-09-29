using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PFDH_CHILD_SELECT
    {
        private List<MES_SY_PFDH_CHILD> _MES_SY_PFDH_CHILD;

        public List<MES_SY_PFDH_CHILD> MES_SY_PFDH_CHILD
        {
            get { return _MES_SY_PFDH_CHILD; }
            set { _MES_SY_PFDH_CHILD = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
