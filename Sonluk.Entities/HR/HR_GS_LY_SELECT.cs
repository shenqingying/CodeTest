using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_GS_LY_SELECT
    {
        private List<HR_GS_LY_LIST> _HR_GS_LY_LIST;

        public List<HR_GS_LY_LIST> HR_GS_LY_LIST
        {
            get { return _HR_GS_LY_LIST; }
            set { _HR_GS_LY_LIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
