using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_TM_CZR_SELECT_CZR_NOW
    {
        private List<MES_TM_CZR> _MES_TM_CZR;

        public List<MES_TM_CZR> MES_TM_CZR
        {
            get { return _MES_TM_CZR; }
            set { _MES_TM_CZR = value; }
        }

        private string _CZR;

        public string CZR
        {
            get { return _CZR; }
            set { _CZR = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
