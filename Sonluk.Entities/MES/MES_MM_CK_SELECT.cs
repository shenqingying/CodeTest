using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_MM_CK_SELECT
    {
        private List<MES_MM_CK> _MES_MM_CK;

        public List<MES_MM_CK> MES_MM_CK
        {
            get { return _MES_MM_CK; }
            set { _MES_MM_CK = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
