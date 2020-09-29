using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_GS_GSSL_SELECT
    {
        private List<HR_GS_GSSL> _HR_GS_GSSL;

        public List<HR_GS_GSSL> HR_GS_GSSL
        {
            get { return _HR_GS_GSSL; }
            set { _HR_GS_GSSL = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
