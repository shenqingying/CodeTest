using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_STAFF_SELECT
    {
        private List<MES_SY_STAFF> _MES_SY_STAFF;

        public List<MES_SY_STAFF> MES_SY_STAFF
        {
            get { return _MES_SY_STAFF; }
            set { _MES_SY_STAFF = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
