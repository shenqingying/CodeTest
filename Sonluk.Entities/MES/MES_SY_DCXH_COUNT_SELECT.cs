using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_DCXH_COUNT_SELECT
    {
        private List<MES_SY_DCXH_COUNT> _MES_SY_DCXH_COUNT;

        public List<MES_SY_DCXH_COUNT> MES_SY_DCXH_COUNT
        {
            get { return _MES_SY_DCXH_COUNT; }
            set { _MES_SY_DCXH_COUNT = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
