using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_PX_PXZT_SELECT
    {
        private List<HR_PX_PXZT_LIST> _HR_PX_PXZT_LIST;

        public List<HR_PX_PXZT_LIST> HR_PX_PXZT_LIST
        {
            get { return _HR_PX_PXZT_LIST; }
            set { _HR_PX_PXZT_LIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
