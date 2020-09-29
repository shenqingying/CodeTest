using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_EMTYPE_LAY_SELECT
    {
        List<EM_SY_EMTYPE_LAY_LIST> _EM_SY_EMTYPE_LAY_LIST;

        public List<EM_SY_EMTYPE_LAY_LIST> EM_SY_EMTYPE_LAY_LIST
        {
            get { return _EM_SY_EMTYPE_LAY_LIST; }
            set { _EM_SY_EMTYPE_LAY_LIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
