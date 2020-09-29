using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_SY_TYPE_SELECT
    {
        private List<HR_SY_TYPE> _HR_SY_TYPE;

        public List<HR_SY_TYPE> HR_SY_TYPE
        {
            get { return _HR_SY_TYPE; }
            set { _HR_SY_TYPE = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
