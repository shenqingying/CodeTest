using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_RY_GSGL_SELECT
    {
        private List<HR_RY_GSGL_LIST> _HR_RY_GSGL_LIST;

        public List<HR_RY_GSGL_LIST> HR_RY_GSGL_LIST
        {
            get { return _HR_RY_GSGL_LIST; }
            set { _HR_RY_GSGL_LIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
