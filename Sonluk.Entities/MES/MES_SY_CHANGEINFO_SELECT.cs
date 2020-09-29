using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_CHANGEINFO_SELECT
    {
        List<MES_SY_CHANGEINFOLIST> _MES_SY_CHANGEINFOLIST;

        public List<MES_SY_CHANGEINFOLIST> MES_SY_CHANGEINFOLIST
        {
            get { return _MES_SY_CHANGEINFOLIST; }
            set { _MES_SY_CHANGEINFOLIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
