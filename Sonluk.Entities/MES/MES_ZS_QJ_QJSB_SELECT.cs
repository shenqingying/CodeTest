using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ZS_QJ_QJSB_SELECT
    {
        private List<MES_ZS_QJ_QJSB> _MES_ZS_QJ_QJSB;

        public List<MES_ZS_QJ_QJSB> MES_ZS_QJ_QJSB
        {
            get { return _MES_ZS_QJ_QJSB; }
            set { _MES_ZS_QJ_QJSB = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
