using Sonluk.Entities.MES;
using Sonluk.Entities.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ZPSFUG_Q_XMXXOA_SELECT
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private ZSL_XMXX _CT_XM;

        public ZSL_XMXX CT_XM
        {
            get { return _CT_XM; }
            set { _CT_XM = value; }
        }
    }
}
